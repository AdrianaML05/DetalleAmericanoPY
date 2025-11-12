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
    public partial class BusquedaProveedores : Form
    {
        CapaNegocio.CLASES.Conexion x = new CapaNegocio.CLASES.Conexion();
        SqlConnection con = new SqlConnection();
        public BusquedaProveedores()
        {
            InitializeComponent();
            con.ConnectionString = x.conexion;
        }

        private void BusquedaProveedores_Load(object sender, EventArgs e)
        {
            try
            {

                DgProveedores.Rows[0].Selected = true;
            }
            catch { }
        }
        void cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"select * from catProveedores", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            DgProveedores.DataSource = dt;
            DgProveedores.Columns[0].Visible = false; // Oculta la primera columna (ID)
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

        private void DgProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = DgProveedores.CurrentRow.Index;
            DgProveedores.Rows[i].Selected = true;

        }
    }
}
