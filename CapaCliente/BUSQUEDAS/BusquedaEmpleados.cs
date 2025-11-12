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
    public partial class BusquedaEmpleados : Form
    {
        CapaNegocio.CLASES.Conexion x = new CapaNegocio.CLASES.Conexion();
        SqlConnection con = new SqlConnection();
        public BusquedaEmpleados()
        {
            InitializeComponent();
            con.ConnectionString = x.conexion;
        }

        private void BusquedaEmpleados_Load(object sender, EventArgs e)
        {
            try
            {
                DgEmpleados.Rows[0].Selected = true;
            }
            catch { }
        }
        void cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT idEmpleados, Nombre, ApellidoPa, ApellidoMa, CONCAT(Nombre, ' ', ApellidoPa, ' ', ApellidoMa) as NombreCompleto, Telefono, Correo, RFC, CURP, Puesto FROM catEmpleados", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            DgEmpleados.DataSource = dt;
            // Ocultar columnas que no quieres ver en el grid
            DgEmpleados.Columns["idEmpleados"].Visible = false;
            DgEmpleados.Columns["Nombre"].Visible = false;
            DgEmpleados.Columns["ApellidoPa"].Visible = false;
            DgEmpleados.Columns["ApellidoMa"].Visible = false;
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

        private void DgEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = DgEmpleados.CurrentRow.Index;
            DgEmpleados.Rows[i].Selected = true;
        }
    }
}
