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

namespace CapaCliente.FORMULARIOS
{
    public partial class frmProductos : Form
    {
        static Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        public frmProductos()
        {
            InitializeComponent();
            con.ConnectionString = x.conexion();
            CargarCategorias();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            CapaNegocio.CLASES.Herramientas h = new Herramientas();
            TXTID.Text = h.consecutivo("idProducto", "catProducto").ToString();
        }
        void limpiar()
        {
            TXTCODIGO.Clear();
            TXTNOMBRE.Clear();
            TXTPCOMPRA.Clear();
            TXTPVENTA.Clear();
            TXTDESCRIPCION.Clear();
            CapaNegocio.CLASES.Herramientas h = new Herramientas();
            TXTID.Text = h.consecutivo("idProducto", "catProducto").ToString();
            TXTCODIGO.Focus();
            TXTNOMBRE.Focus();
            TXTPCOMPRA.Focus();
            TXTPVENTA.Focus();
            TXTDESCRIPCION.Focus();

        }
        bool encontro()
        {
            bool a = false;
            int idProducto = int.Parse(TXTID.Text);
            string cadena = $"select * from catProducto where idProducto = '{idProducto}'";
            con.Open();
            SqlCommand cmd = new SqlCommand(cadena, con);
            SqlDataReader lector = cmd.ExecuteReader();
            if (lector.Read())
            {
                a = true;
            }
            else
            {
                a = false;
            }
            con.Close();
            return a;
        }
        private void CargarCategorias()
        {
            CBCAT.Items.Clear();

            CBCAT.Items.Add("Ropa");
            CBCAT.Items.Add("Maquillaje");
            CBCAT.Items.Add("Termos");
            CBCAT.Items.Add("Snacks");
            CBCAT.Items.Add("Bebidas");
            CBCAT.Items.Add("Accesorios");

            CBCAT.SelectedIndex = 0; // Selecciona la primera por defecto
        }
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(TXTNOMBRE.Text))
            {
                MessageBox.Show("El campo NOMBRE es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTNOMBRE.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TXTCODIGO.Text))
            {
                MessageBox.Show("El campo CODIGO es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTCODIGO.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TXTPCOMPRA.Text))
            {
                MessageBox.Show("El campo PRECIO DE COMPRA es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTPCOMPRA.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(TXTPVENTA.Text))
            {
                MessageBox.Show("El campo ORECIO DE VENTA es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTPVENTA.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(TXTDESCRIPCION.Text))
            {
                MessageBox.Show("El campo DESCRIPCION es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTDESCRIPCION.Focus();
                return false;
            }
            
            return true; // Todos los campos son válidos
        }

        private void gUARDARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Validar primero
            if (!ValidarCampos())
            {
                return; // Si hay errores, detener
            }

            // 1. Crea la instancia del objeto
            CapaNegocio.CLASES.Productos mun = new CapaNegocio.CLASES.Productos();


            // 2. Asigna las propiedades desde tus TextBoxes y ComboBoxes
            mun.idProducto = int.Parse(TXTID.Text);
            mun.Nombre = TXTNOMBRE.Text.Trim();
            mun.Codigo = TXTCODIGO.Text.Trim();
            mun.PrecioVenta = decimal.Parse(TXTPVENTA.Text);
            mun.PrecioCompra = decimal.Parse(TXTPCOMPRA.Text);
            mun.Tipo = CBCAT.SelectedItem.ToString();
            mun.Descripcion = TXTDESCRIPCION.Text.Trim();
            
            // 3. Obtiene los IDs de los ComboBoxes

            // ¡OJO! Tu tabla también tiene 'Referencias', necesitas agregarlo
            // Asumiendo que tienes un TextBox llamado 'TXTREFERENCIAS'

            // 4. Llama al método para guardar y muestra el resultado
            MessageBox.Show(mun.Guardar());

            // 5. Limpia los campos
            limpiar();
        }

        private void bUSCARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapaCliente.BUSQUEDAS.BusquedaProductos x = new CapaCliente.BUSQUEDAS.BusquedaProductos();
            x.ShowDialog();
            if (x.DialogResult == DialogResult.OK)
            {
                TXTID.Text = x.DgProductos.SelectedRows[0].Cells["idProducto"].Value.ToString();
                TXTCODIGO.Text = x.DgProductos.SelectedRows[0].Cells["Codigo_de_Barras"].Value.ToString();
                TXTNOMBRE.Text = x.DgProductos.SelectedRows[0].Cells["Nombre_del_Producto"].Value.ToString();
                TXTPVENTA.Text = x.DgProductos.SelectedRows[0].Cells["Precio_de_Venta"].Value.ToString();
                TXTPCOMPRA.Text = x.DgProductos.SelectedRows[0].Cells["Precio_de_Compra"].Value.ToString();
                string Tipo = x.DgProductos.SelectedRows[0].Cells["Categoria"].Value.ToString();
                CBCAT.SelectedValue = Tipo;
                TXTDESCRIPCION.Text = x.DgProductos.SelectedRows[0].Cells["Descripcion"].Value.ToString();
            }
        }

        private void eLIMINARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapaNegocio.CLASES.Productos x = new CapaNegocio.CLASES.Productos();
            x.idProducto = int.Parse(TXTID.Text);
            MessageBox.Show("Se elimino el registro.");
            if (encontro() == true)
            {
                MessageBox.Show(x.Eliminar());
                limpiar();
            }
            else
            {
                MessageBox.Show("No se encontro el elemento a eliminar");
            }
        }

        private void lIMPIARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
