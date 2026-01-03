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
    public partial class BusquedaClientes : FORMULARIOS.FormularioBase
    {
        CapaNegocio.CLASES.Conexion x = new CapaNegocio.CLASES.Conexion();
        SqlConnection con = new SqlConnection();
        public BusquedaClientes()
        {
            InitializeComponent();
            con.ConnectionString = x.conexion();
            EstablecerTamanoMinimo(700, 500);
            HabilitarMaximizar();
        }

        private void BusquedaClientes_Load(object sender, EventArgs e)
        {
            try
            {
                DgClientes.Rows[0].Selected = true;
            }
            catch { }
        }
        void cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT idCliente, Nombre, ApellidoPa, ApellidoMa, CONCAT(Nombre, ' ', ApellidoPa, ' ', ApellidoMa) as NombreCompleto, NumeroTel, Correo, FechaNacimiento, numVisita, TipoCliente FROM catClientes", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            DgClientes.DataSource = dt;

            // Ocultar columnas que no quieres ver en el grid
            DgClientes.Columns["idCliente"].Visible = false;
            DgClientes.Columns["Nombre"].Visible = false;
            DgClientes.Columns["ApellidoPa"].Visible = false;
            DgClientes.Columns["ApellidoMa"].Visible = false;

            con.Close();
        }

        private void BTNBUSCAR_Click(object sender, EventArgs e)
        {
            cargardg();
        }

        private void BTNCANCELAR_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TXTFILTRO_TextChanged(object sender, EventArgs e)
        {
            cargardg();
        }
        

        private void BTNACEPTAR_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void DgClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = DgClientes.CurrentRow.Index;
            DgClientes.Rows[i].Selected = true;
        }
    }
}
