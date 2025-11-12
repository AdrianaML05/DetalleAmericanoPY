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
    public partial class frmDomicilios : Form
    {
        static Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        public frmDomicilios()
        {
            InitializeComponent();
            con.ConnectionString = x.conexion;
            CargarMunicipiosConEstado();
            CargarComboClientes();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TXTCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        private void frmDomicilios_Load(object sender, EventArgs e)
        {
            CapaNegocio.CLASES.Herramientas h = new Herramientas();
            TXTID.Text = h.consecutivo("idDomicilio", "catDomicilios").ToString();
        }
        void limpiar()
        {
            TXTNOMBRE.Clear();
            TXTNUMEXTERIOR.Clear();
            TXTNUMINTERIOR.Clear();
            TXTCALLE.Clear();
            TXTCP.Clear();
            TXTREFERENCIAS.Clear();
            CapaNegocio.CLASES.Herramientas h = new Herramientas();
            TXTID.Text = h.consecutivo("idDomicilio", "catDomicilios").ToString();
            TXTNOMBRE.Focus();
            TXTNUMEXTERIOR.Focus();
            TXTNUMINTERIOR.Focus();
            TXTCALLE.Focus();
            TXTCP.Focus();
            TXTREFERENCIAS.Focus();
        }
        bool encontro()
        {
            bool a = false;
            int idDomicilio = int.Parse(TXTID.Text);
            string cadena = $"select * from catDomicilios where idDomicilio = '{idDomicilio}'";
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
        public void CargarMunicipiosConEstado()
        {
            // 1. Consulta SQL que UNE las dos tablas
            string consultaSQL = @" SELECT M.idMunicipio, M.Nombre + ' (' + E.Nombre + ')' AS NombreCompleto FROM catMunicipio AS M INNER JOIN dbo.catEstado AS E ON M.idEstado = E.idEstado ORDER BY NombreCompleto ASC; ";

            // 2. Prepara el DataTable
            DataTable dt = new DataTable();

            // 3. 'using' asegura que la conexión se cierre sola
            using (SqlConnection con = new SqlConnection(x.conexion))
            {
                // 4. El DataAdapter ejecuta la consulta
                using (SqlDataAdapter da = new SqlDataAdapter(consultaSQL, con))
                {
                    // 5. LLENA la tabla con los resultados (ej. "1", "Culiacán (Sinaloa)")
                    da.Fill(dt);
                }
            }

            // 6. Asigna los datos al ComboBox
            CBMUNICIPIO.DataSource = dt;

            // 7. Le dice al ComboBox que MUESTRE la columna "NombreCompleto"
            CBMUNICIPIO.DisplayMember = "NombreCompleto";

            // 8. Le dice al ComboBox que el VALOR "oculto" es el "idMunicipio"
            CBMUNICIPIO.ValueMember = "idMunicipio";
        }
        public void CargarComboClientes()
        {
            // 1. Consulta SQL que UNE las columnas de nombre.
            //    Uso "AprllidoMa" para coincidir con tu imagen.
            string consultaSQL = @"
        SELECT idCliente, Nombre + ' ' + ApellidoPa + ' ' + AprllidoMa AS NombreCompleto FROM dbo.catClientes ORDER BY NombreCompleto ASC; ";

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
            CBCLIENTE.DataSource = dt;

            // 7. Le dice al ComboBox que MUESTRE la columna "NombreCompleto"
            CBCLIENTE.DisplayMember = "NombreCompleto";

            // 8. Le dice al ComboBox que el VALOR "oculto" es el "idCliente"
            CBCLIENTE.ValueMember = "idCliente";
        }
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(TXTNOMBRE.Text))
            {
                MessageBox.Show("El campo NOMBRE es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTNOMBRE.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TXTNUMEXTERIOR.Text))
            {
                MessageBox.Show("El campo NUMERO EXTERIOR es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTNUMEXTERIOR.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TXTNUMINTERIOR.Text))
            {
                MessageBox.Show("El campo NUMERO INTERIOR es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTNUMINTERIOR.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(TXTCALLE.Text))
            {
                MessageBox.Show("El campo CALLE es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTCALLE.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(TXTCP.Text))
            {
                MessageBox.Show("El campo CODIGO POSTAL es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTCP.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(TXTREFERENCIAS.Text))
            {
                MessageBox.Show("El Campo REFERENCIAS es Obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTREFERENCIAS.Focus();
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
            CapaNegocio.CLASES.Domicilios mun = new CapaNegocio.CLASES.Domicilios();

          
            // 2. Asigna las propiedades desde tus TextBoxes y ComboBoxes
            mun.idDomicilio = int.Parse(TXTID.Text);
            mun.idCliente = Convert.ToInt32(CBCLIENTE.SelectedValue);
            mun.idMunicipio = Convert.ToInt32(CBMUNICIPIO.SelectedValue);
            mun.nombreDomicilio = TXTNOMBRE.Text.Trim(); // Este es el campo "NOMBRE"
            mun.numExtrior = TXTNUMEXTERIOR.Text.Trim();
            mun.numInterior = TXTNUMINTERIOR.Text.Trim();
            mun.calle = TXTCALLE.Text.Trim();
            mun.CP = TXTCP.Text.Trim();
            mun.Referencias = TXTREFERENCIAS.Text.Trim();

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
            CapaCliente.BUSQUEDAS.BusquedaDomicilios x = new CapaCliente.BUSQUEDAS.BusquedaDomicilios();
            x.ShowDialog();
            if (x.DialogResult == DialogResult.OK)
            {
                TXTID.Text = x.DgDomicilio.SelectedRows[0].Cells["idDomicilio"].Value.ToString();
                TXTNOMBRE.Text = x.DgDomicilio.SelectedRows[0].Cells["Nombre_Del_Domicilio"].Value.ToString();
                TXTNUMEXTERIOR.Text = x.DgDomicilio.SelectedRows[0].Cells["numExterior"].Value.ToString();
                TXTNUMINTERIOR.Text = x.DgDomicilio.SelectedRows[0].Cells["numInterior"].Value.ToString();
                string idCliente = x.DgDomicilio.SelectedRows[0].Cells["idCliente"].Value.ToString();
                CBCLIENTE.SelectedValue = idCliente;
                string idMunicipio = x.DgDomicilio.SelectedRows[0].Cells["idMunicipio"].Value.ToString();
                CBMUNICIPIO.SelectedValue = idMunicipio;
                TXTCALLE.Text = x.DgDomicilio.SelectedRows[0].Cells["Calle"].Value.ToString();
                TXTCP.Text = x.DgDomicilio.SelectedRows[0].Cells["Codigo_Postal"].Value.ToString();
                TXTREFERENCIAS.Text = x.DgDomicilio.SelectedRows[0].Cells["Referencias"].Value.ToString();
                
            }
        }

        private void eLIMINARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapaNegocio.CLASES.Clientes x = new CapaNegocio.CLASES.Clientes();
            x.idCliente = int.Parse(TXTID.Text);
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
    }
}
