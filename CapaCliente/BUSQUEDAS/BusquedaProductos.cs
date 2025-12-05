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
    public partial class BusquedaProductos : Form
    {
        CapaNegocio.CLASES.Conexion x = new CapaNegocio.CLASES.Conexion();
        SqlConnection con = new SqlConnection();
        public BusquedaProductos()
        {
            InitializeComponent();
            con.ConnectionString = x.conexion();

        }

        private void BusquedaProductos_Load(object sender, EventArgs e)
        {
            try
            {
                DgProductos.Rows[0].Selected = true;
            }
            catch { }
        }
        void cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select p.idProducto, p.Codigo as Codigo_de_Barras, p.Nombre as Nombre_del_Producto, p.PrecioVenta as Precio_de_Venta, p.PrecioCompra as Precio_de_Compra, p.Tipo as Categoria, p.Descripcion from catProducto p;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            DgProductos.DataSource = dt;

            // Ocultar columnas que no quieres ver en el grid
            DgProductos.Columns["idProducto"].Visible = false;


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

        private void DgProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = DgProductos.CurrentRow.Index;
            DgProductos.Rows[i].Selected = true;
        }
    }
}
