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
    public partial class BusquedaPaqueteria : Form
    {
        CapaNegocio.CLASES.Conexion x = new CapaNegocio.CLASES.Conexion();
        SqlConnection con = new SqlConnection();
        public BusquedaPaqueteria()
        {
            InitializeComponent();
            con.ConnectionString = x.conexion;
        }

        private void BusquedaPaqueteria_Load(object sender, EventArgs e)
        {
            try
            {
                DgPaqueteria.Rows[0].Selected = true;
            }
            catch { }
        }
        void cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"select * from catPaqueteria", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            DgPaqueteria.DataSource = dt;
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
        private void DgPaqueteria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = DgPaqueteria.CurrentRow.Index;
            DgPaqueteria.Rows[i].Selected = true;
        }

        private void BTNACEPTAR_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
