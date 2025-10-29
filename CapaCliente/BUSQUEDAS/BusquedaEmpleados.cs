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
            SqlCommand cmd = new SqlCommand($"select * from catEmpleados", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            DgEmpleados.DataSource = dt;
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

        private void DgEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = DgEmpleados.CurrentRow.Index;
            DgEmpleados.Rows[i].Selected = true;
        }

        private void BTNACEPTAR_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
