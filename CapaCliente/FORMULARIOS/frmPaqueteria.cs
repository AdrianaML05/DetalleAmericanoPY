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
    public partial class frmPaqueteria : Form
    {
        static Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        public frmPaqueteria()
        {
            InitializeComponent();
            con.ConnectionString = x.conexion;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPaqueteria_Load(object sender, EventArgs e)
        {
            CapaNegocio.CLASES.Herramientas h = new Herramientas();
            TXTID.Text = h.consecutivo("idPaqueteria", "catPaqueteria").ToString();
        }
        public void limpiar()
        {
            TXTNOMBRE.Clear();
            TXTCALLE.Clear();
            TXTNUMEXTERIOR.Clear();
            TXTNUMINTERIOR.Clear();
            TXTREFERENCIAS.Clear();
            TXTTELEFONO.Clear();
            CapaNegocio.CLASES.Herramientas h = new Herramientas();
            TXTID.Text = h.consecutivo("idPaqueteria", "catPaqueteria").ToString();
            TXTNOMBRE.Focus();
            TXTCALLE.Focus();
            TXTNUMEXTERIOR.Focus();
            TXTNUMINTERIOR.Focus();
            TXTREFERENCIAS.Focus();
            TXTTELEFONO.Focus();
        }
        bool encontro()
        {
            bool a = false;
            int idPaqueteria = int.Parse(TXTID.Text);
            string cadena = $"select * from catPaqueteria where idPaqueteria = '{idPaqueteria}'";
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
        private bool ValidarCampos()
        {

            if (string.IsNullOrWhiteSpace(TXTNOMBRE.Text))
            {
                MessageBox.Show("El campo NOMBRE es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTNOMBRE.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TXTCALLE.Text))
            {
                MessageBox.Show("El campo CALLE es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTCALLE.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TXTNUMEXTERIOR.Text))
            {
                MessageBox.Show("El campo NUMEROINTERIOR es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTNUMEXTERIOR.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(TXTNUMINTERIOR.Text))
            {
                MessageBox.Show("El campo NUMERO EXTERIOR es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTNUMINTERIOR.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(TXTREFERENCIAS.Text))
            {
                MessageBox.Show("El campo REFERENCIAS es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTREFERENCIAS.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(TXTTELEFONO.Text))
            {
                MessageBox.Show("El campo TELEFONO es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTTELEFONO.Focus();
                return false;
            }

            return true; // Todos los campos son válidos
        }

        private void BTNGUARDAR_Click(object sender, EventArgs e)
        {
            // Validar primero
            if (!ValidarCampos())
            {
                return; // Si hay errores, detener
            }

            CapaNegocio.CLASES.Paqueteria x = new CapaNegocio.CLASES.Paqueteria();
            x.idPaqueteria = int.Parse(TXTID.Text);
            x.Nombre = TXTNOMBRE.Text.Trim();
            x.Calle = TXTCALLE.Text.Trim();
            x.numExterior = TXTNUMEXTERIOR.Text.Trim();
            x.numInterioir = TXTNUMINTERIOR.Text.Trim();
            x.Referencias = TXTREFERENCIAS.Text.Trim();
            x.Telefono = TXTTELEFONO.Text.Trim();
            
            MessageBox.Show(x.Guardar());
            limpiar();
        }

        private void BTNBUSCAR_Click(object sender, EventArgs e)
        {
            CapaCliente.BUSQUEDAS.BusquedaPaqueteria x = new CapaCliente.BUSQUEDAS.BusquedaPaqueteria();
            x.ShowDialog();
            if (x.DialogResult == DialogResult.OK)
            {
                TXTID.Text = x.DgPaqueteria.SelectedRows[0].Cells["idPaqueteria"].Value.ToString();
                TXTNOMBRE.Text = x.DgPaqueteria.SelectedRows[0].Cells["Nombre"].Value.ToString();
                TXTCALLE.Text = x.DgPaqueteria.SelectedRows[0].Cells["Calle"].Value.ToString();
                TXTNUMEXTERIOR.Text = x.DgPaqueteria.SelectedRows[0].Cells["numExterior"].Value.ToString();
                TXTNUMINTERIOR.Text = x.DgPaqueteria.SelectedRows[0].Cells["numInterior"].Value.ToString();
                TXTREFERENCIAS.Text = x.DgPaqueteria.SelectedRows[0].Cells["Referencias"].Value.ToString();
                TXTTELEFONO.Text = x.DgPaqueteria.SelectedRows[0].Cells["Telefono"].Value.ToString();
                

            }
        }

        private void BTNLIMPIAR_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void BTNELIMINAR_Click(object sender, EventArgs e)
        {
            CapaNegocio.CLASES.Paqueteria x = new CapaNegocio.CLASES.Paqueteria();
            x.idPaqueteria = int.Parse(TXTID.Text);
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

        private void TXTTELEFONO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
