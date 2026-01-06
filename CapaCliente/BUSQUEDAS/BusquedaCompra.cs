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
    public partial class BusquedaCompra : FORMULARIOS.FormularioBase
    {
        CapaNegocio.CLASES.Conexion x = new CapaNegocio.CLASES.Conexion();
        SqlConnection con = new SqlConnection();

        public BusquedaCompra()
        {
            InitializeComponent();
            con.ConnectionString = x.conexion();
            EstablecerTamanoMinimo(700, 500);
            HabilitarMaximizar();
        }

        private void BusquedaCompra_Load(object sender, EventArgs e)
        {
            CargarCompras();
            try
            {
                DgCompras.Rows[0].Selected = true;
            }
            catch { }
        }

        void CargarCompras()
        {
            string filtro = TXTFILTRO.Text.Trim();
            DataTable dt = new DataTable();

            string query = @"
  SELECT 
   c.idCompra,
      c.Folio,
    c.Fecha,
   p.Nombre AS Proveedor,
                c.Total
    FROM Compra c
            INNER JOIN catProveedores p ON c.idProveedores = p.idProveedores
            WHERE (@Filtro = '' OR c.Folio LIKE '%' + @Filtro + '%')
  ORDER BY c.Fecha DESC";

            con.Open();
      SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Filtro", filtro);
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    da.Fill(dt);
     DgCompras.DataSource = dt;

        // Ocultar columna idCompra
        if (DgCompras.Columns["idCompra"] != null)
          DgCompras.Columns["idCompra"].Visible = false;

        // Formato de columnas
  if (DgCompras.Columns["Fecha"] != null)
            DgCompras.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

     if (DgCompras.Columns["Total"] != null)
        {
    DgCompras.Columns["Total"].DefaultCellStyle.Format = "$#,##0.00";
            DgCompras.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        con.Close();
    }

        private void BTNBUSCAR_Click(object sender, EventArgs e)
        {
            CargarCompras();
        }

        private void BTNACEPTAR_Click(object sender, EventArgs e)
        {
            if (DgCompras.CurrentRow != null)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Seleccione una compra.", "Advertencia",
 MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BTNCANCELAR_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TXTFILTRO_TextChanged(object sender, EventArgs e)
        {
            CargarCompras();
        }

        private void DgCompras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DgCompras.Rows[e.RowIndex].Selected = true;
            }
        }

        private void DgCompras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
