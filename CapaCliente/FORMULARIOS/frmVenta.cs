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
    public partial class frmVenta : Form
    {
        static Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        public frmVenta()
        {

            InitializeComponent();
            con.ConnectionString = x.conexion;
            crgarcb();
            

        }
        public void crgarcb()
        {
            // 1. Consulta SQL que UNE las columnas de nombre.
            //    Uso "AprllidoMa" para coincidir con tu imagen.
            string consultaSQL = @"
            SELECT idCliente, Nombre + ' ' + ApellidoPa + ' ' + ApellidoMa AS NombreCompleto FROM dbo.catClientes ORDER BY NombreCompleto ASC; ";

            // 2. Prepara el DataTable
            DataTable dt = new DataTable();

            // 3. 'using' asegura que la conexión se cierre sola
            //    (Uso 'x.conexion' como en tu ejemplo anterior)
            using (SqlConnection con = new SqlConnection(x.conexion))
            {
                // 4. El DataAdapter ejecuta la consulta
                using (SqlDataAdapter da = new SqlDataAdapter(consultaSQL, con))
                {
                    // 5. LLENA la tabla con los resultados (ej. "1", "Juan Pérez López")
                    da.Fill(dt);
                }
            }

            // 6. Asigna los datos al ComboBox (supongamos que se llama 'cmbClientes')
            CBEMPLAEADOS.DataSource = dt;

            // 7. Le dice al ComboBox que MUESTRE la columna "NombreCompleto"
            CBEMPLAEADOS.DisplayMember = "NombreCompleto";

            // 8. Le dice al ComboBox que el VALOR "oculto" es el "idCliente"
            CBEMPLAEADOS.ValueMember = "idCliente";
        }


        private void DgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmCobrar x = new frmCobrar();
            x.ShowDialog();
        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
           confdg();
        }

        private void TXTFILTRO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                AgregarPorCodigoBarra();
                e.Handled = true; // Para evitar que el Enter haga un salto de línea en el TextBox
            }
        }
        DataTable dt = new DataTable();
        void confdg()
        {
            //dt.Columns.Add("ID Producto");
            dt.Columns.Add("Codigo de Barra");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Precio Unitario");
            dt.Columns.Add("Subtotal");
            DGVENTA.DataSource = dt;
        }
        //void agregar()
        //{
        //    DataRow fila = dt.NewRow();
        //    fila[0] = 1;
        //    fila[1] = "Dulces";
        //    fila[2] = 4;
        //    fila[3] = 20;
        //    fila[4] = 80;
        //    dt.Rows.Add(fila);
        //    DGVENTA.DataSource = dt;
        //}

        private void button1_Click(object sender, EventArgs e)
        {

            //agregar();
            AgregarPorCodigoBarra();    
        }

        void AgregarPorCodigoBarra()
        {
            string CodigoBarra = TXTFILTRO.Text.Trim();
            if (string.IsNullOrEmpty(CodigoBarra))
            {
                MessageBox.Show("Por favor ingrese el codigo de barras.");
                return;
            }

            string query = "select * from catProducto where Codigo = @Codigo";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Codigo", CodigoBarra);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //string idProducto = reader["idProducto"].ToString();
                string Codigo = reader["Codigo"].ToString();
                string Nombre = reader["Nombre"].ToString();
                decimal prcio = Convert.ToDecimal(reader["PrecioVenta"].ToString()); // <--- ERROR AQUÍ
                int cantidad = string.IsNullOrEmpty(txtCantidad.Text)? 1 : Convert.ToInt32(txtCantidad.Text);
                decimal subtotal = cantidad * prcio;

                DataRow fila = dt.NewRow();
                //fila["ID Producto"] = idProducto;
                fila["Codigo de Barra"] = reader["Codigo"].ToString();
                fila["Nombre"] = Nombre;
                fila["Cantidad"] = cantidad;
                fila["Precio Unitario"] = reader["PrecioVenta"].ToString();
                fila["Subtotal"] = subtotal;
                dt.Rows.Add(fila);
                DGVENTA.DataSource = dt;
                txtCantidad.Clear();
                TXTFILTRO.Clear();
            }
            else
            {
                MessageBox.Show("Producto no encontrado.");
            }
            reader.Close();
            con.Close();

        }
    }
}
