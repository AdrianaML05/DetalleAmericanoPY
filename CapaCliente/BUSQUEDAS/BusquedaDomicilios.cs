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
    public partial class BusquedaDomicilios : Form
    {
        CapaNegocio.CLASES.Conexion x = new CapaNegocio.CLASES.Conexion();
        SqlConnection con = new SqlConnection();
        public BusquedaDomicilios()
        {
            InitializeComponent();
            con.ConnectionString = x.conexion;
        }

        private void BusquedaDomicilios_Load(object sender, EventArgs e)
        {
            try
            {
                DgDomicilio.Rows[0].Selected = true;
            }
            catch { }
        }
        void cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select d.idDomicilio, d.nombreDomicilio as Nombre_Del_Domicilio, d.calle as Calle, d.numExterior, d.numInterior, d.CP as Codigo_Postal, d.Referencias, m.Nombre AS Municipio, c.Nombre as Cliente, d.idMunicipio, d.idCliente from catDomicilios as d JOIN catMunicipio as m on d.idMunicipio = m.idMunicipio JOIN catClientes as c on d.idCliente = c.idCliente;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            DgDomicilio.DataSource = dt;

            // Ocultar columnas que no quieres ver en el grid
            DgDomicilio.Columns["idDomicilio"].Visible = false;
            

            con.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BTNBUSCAR_Click(object sender, EventArgs e)
        {
            cargardg();
        }

        private void TXTFILTRO_TextChanged(object sender, EventArgs e)
        {
            cargardg();
        }

        private void DgDomicilio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = DgDomicilio.CurrentRow.Index;
            DgDomicilio.Rows[i].Selected = true;
        }
    }
}
