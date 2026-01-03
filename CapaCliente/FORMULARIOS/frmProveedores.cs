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
    public partial class frmProveedores : FormularioBase
    {
        static Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        public frmProveedores()
        {
            InitializeComponent();
            con.ConnectionString = x.conexion();
            EstablecerTamanoMinimo(900, 700);
            HabilitarMaximizar();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            CapaNegocio.CLASES.Herramientas h = new Herramientas();
            TXTID.Text = h.consecutivo("idProveedores", "catProveedores").ToString();
        }
        public void limpiar()
        {
            TXTNOMBRE.Clear();
            TXTTELEFONO.Clear();
            CapaNegocio.CLASES.Herramientas h = new Herramientas();
            TXTID.Text = h.consecutivo("idProveedores", "catProveedores").ToString();
            TXTNOMBRE.Focus();
            TXTTELEFONO.Focus();
        }
        bool encontro()
        {
            bool a = false;
            int idProveedores = int.Parse(TXTID.Text);
            string cadena = $"select * from catProveedores where idProveedores = '{idProveedores}'";
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

            CapaNegocio.CLASES.Proveedores x = new CapaNegocio.CLASES.Proveedores();
            x.idProveedores = int.Parse(TXTID.Text);
            x.Nombre = TXTNOMBRE.Text.Trim();
            x.numTelefono = TXTTELEFONO.Text.Trim();

            MessageBox.Show(x.Guaradar());
            limpiar();
        }

        private void BTNBUSCAR_Click(object sender, EventArgs e)
        {
            CapaCliente.BUSQUEDAS.BusquedaProveedores x = new CapaCliente.BUSQUEDAS.BusquedaProveedores();
            x.ShowDialog();
            if (x.DialogResult == DialogResult.OK)
            {
                TXTID.Text = x.DgProveedores.SelectedRows[0].Cells["idProveedores"].Value.ToString();
                TXTNOMBRE.Text = x.DgProveedores.SelectedRows[0].Cells["Nombre"].Value.ToString();
                TXTTELEFONO.Text = x.DgProveedores.SelectedRows[0].Cells["numTelefono"].Value.ToString();
            }
        }

        private void BTNLIMPIAR_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void BTNELIMINAR_Click(object sender, EventArgs e)
        {
            CapaNegocio.CLASES.Proveedores x = new CapaNegocio.CLASES.Proveedores();
            x.idProveedores = int.Parse(TXTID.Text);
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
