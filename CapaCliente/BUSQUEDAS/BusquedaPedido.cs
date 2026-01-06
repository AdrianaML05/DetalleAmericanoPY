using CapaNegocio.CLASES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaCliente.BUSQUEDAS
{
    public partial class BusquedaPedido : FORMULARIOS.FormularioBase
    {
        CapaNegocio.CLASES.Conexion x = new CapaNegocio.CLASES.Conexion();
        SqlConnection con = new SqlConnection();

        public BusquedaPedido()
        {
            InitializeComponent();
            con.ConnectionString = x.conexion();
            EstablecerTamanoMinimo(700, 500);
            HabilitarMaximizar();
        }

        private void BusquedaPedido_Load(object sender, EventArgs e)
        {
            CargarPedidos();
            try
            {
                DgPedidos.Rows[0].Selected = true;
            }
            catch { }
        }

        void CargarPedidos()
        {
            string filtro = TXTFILTRO.Text.Trim();
            DataTable dt = new DataTable();

            string query = @"
    SELECT 
        p.idPedido,
        p.Folio,
   p.FechaPedido AS Fecha,
        c.Nombre + ' ' + c.ApellidoPa AS Cliente,
 p.Total,
        p.Estatus
    FROM Pedido p
    INNER JOIN catClientes c ON p.idCliente = c.idCliente
    WHERE (@Filtro = '' OR p.Folio LIKE '%' + @Filtro + '%')
 ORDER BY p.FechaPedido DESC";

            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Filtro", filtro);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            DgPedidos.DataSource = dt;

            // Ocultar columna idPedido
            if (DgPedidos.Columns["idPedido"] != null)
                DgPedidos.Columns["idPedido"].Visible = false;

            // Formato de columnas
            if (DgPedidos.Columns["Fecha"] != null)
                DgPedidos.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (DgPedidos.Columns["Total"] != null)
            {
                DgPedidos.Columns["Total"].DefaultCellStyle.Format = "$#,##0.00";
                DgPedidos.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            con.Close();
        }

        private void BTNBUSCAR_Click(object sender, EventArgs e)
        {
            CargarPedidos();
        }

        private void BTNACEPTAR_Click(object sender, EventArgs e)
        {
            if (DgPedidos.CurrentRow != null)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Seleccione un pedido.", "Advertencia",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BTNCANCELAR_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TXTFILTRO_TextChanged(object sender, EventArgs e)
        {
            CargarPedidos();
        }

        private void DgPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DgPedidos.Rows[e.RowIndex].Selected = true;
            }
        }

        private void DgPedidos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
