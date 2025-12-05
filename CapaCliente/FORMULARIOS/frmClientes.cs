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
    public partial class frmClientes : Form
    {
        static Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        public frmClientes()
        {
            InitializeComponent();
            con.ConnectionString = x.conexion();

        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            CapaNegocio.CLASES.Herramientas h = new Herramientas();
            TXTID.Text = h.consecutivo("idCliente", "catClientes").ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.Cancel;
            this.Close();
        }
        

        public void limpiar()
        {
            
            TXTNOMBRE.Clear();
            TXTAPELLIDOPATERNO.Clear();
            TXTAPELLIDOMATERNO.Clear();
            TXTTELEFONO.Clear();
            TXTCORREO.Clear();
            TXTVISITA.Clear();
            TXTTIPOCLIENTE.Clear();
            CapaNegocio.CLASES.Herramientas h = new Herramientas();
            TXTID.Text = h.consecutivo("idCliente", "catClientes").ToString();
            TXTNOMBRE.Focus();
            TXTAPELLIDOPATERNO.Focus();
            TXTAPELLIDOMATERNO.Focus();
            TXTTELEFONO.Focus();
            TXTCORREO.Focus();
            TXTVISITA.Focus();
            TXTTIPOCLIENTE.Focus();
        }
        bool encontro()
        {
            bool a = false;
            int idCliente = int.Parse(TXTID.Text);
            string cadena = $"select * from catClientes where idCliente = '{idCliente}'";
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

            //if (string.IsNullOrWhiteSpace(TXTAPELLIDOPATERNO.Text))
            //{
            //    MessageBox.Show("El campo APELLIDO PATERNO es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    TXTAPELLIDOPATERNO.Focus();
            //    return false;
            //}

            if (string.IsNullOrWhiteSpace(TXTAPELLIDOMATERNO.Text))
            {
                MessageBox.Show("El campo APELLIDO MATERNO es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTAPELLIDOMATERNO.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TXTTELEFONO.Text))
            {
                MessageBox.Show("El campo TELÉFONO es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTTELEFONO.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(TXTCORREO.Text))
            {
                MessageBox.Show("El campo CORREO es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTCORREO.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(TXTVISITA.Text))
            {
                MessageBox.Show("El campo VISITA es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTVISITA.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(TXTTIPOCLIENTE.Text))
            {
                MessageBox.Show("El campo TIPO CLIENTE es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTTIPOCLIENTE.Focus();
                return false;
            }

            return true; // Todos los campos son válidos
        }

        private void BTNGUARDAR_Click(object sender, EventArgs e)
        {
            //// Validar primero
            //if (!ValidarCampos())
            //{
            //    return; // Si hay errores, detener
            //}

            //CapaNegocio.CLASES.Clientes x = new CapaNegocio.CLASES.Clientes();
            //x.idCliente = int.Parse(TXTID.Text);
            //x.Nombre = TXTNOMBRE.Text.Trim();
            //x.ApellidoPa = TXTAPELLIDOPATERNO.Text.Trim();
            //x.ApellidoMa = TXTAPELLIDOMATERNO.Text.Trim();
            //x.NumeroTel = TXTTELEFONO.Text.Trim();
            //x.Correo = TXTCORREO.Text.Trim();
            //x.FechaNacimiento = DTPFECHANACIMIENTO.Value.Date; // Para DateTimePicke
            //x.numVisita = int.Parse(TXTVISITA.Text);
            //x.TipoCliente = TXTTIPOCLIENTE.Text.Trim();

            //MessageBox.Show(x.Guardar());
            //limpiar();
        }

        private void BTNBUSCAR_Click(object sender, EventArgs e)
        {
            //No Utilizar Este Codigo
            //CapaCliente.BUSQUEDAS.BusquedaClientes x = new CapaCliente.BUSQUEDAS.BusquedaClientes();
            //x.ShowDialog();
            //if (x.DialogResult == DialogResult.OK)
            //{
            //    TXTID.Text = x.DgClientes.SelectedRows[0].Cells["idCliente"].Value.ToString();
            //    TXTNOMBRE.Text = x.DgClientes.SelectedRows[0].Cells["Nombre"].Value.ToString();
            //    TXTAPELLIDOPATERNO.Text = x.DgClientes.SelectedRows[0].Cells["ApellidoPa"].Value.ToString();
            //    TXTAPELLIDOMATERNO.Text = x.DgClientes.SelectedRows[0].Cells["ApellidoMa"].Value.ToString();
            //    TXTTELEFONO.Text = x.DgClientes.SelectedRows[0].Cells["NumeroTel"].Value.ToString();
            //    TXTCORREO.Text = x.DgClientes.SelectedRows[0].Cells["Correo"].Value.ToString();
            //    DTPFECHANACIMIENTO.Text = x.DgClientes.SelectedRows[0].Cells["FechaNacimiento"].Value.ToString();
            //    TXTVISITA.Text = x.DgClientes.SelectedRows[0].Cells["numVisita"].Value.ToString();
            //    TXTTIPOCLIENTE.Text = x.DgClientes.SelectedRows[0].Cells["TipoCliente"].Value.ToString();
            //}
        }

        private void BNTLIMPIAR_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void BNTELIMINAR_Click(object sender, EventArgs e)
        {
            //CapaNegocio.CLASES.Clientes x = new CapaNegocio.CLASES.Clientes();
            //x.idCliente = int.Parse(TXTID.Text);
            //MessageBox.Show("Se elimino el registro.");
            //if (encontro() == true)
            //{
            //    MessageBox.Show(x.Eliminar());
            //    limpiar();
            //}
            //else
            //{
            //    MessageBox.Show("No se encontro el elemento a eliminar");
            //}
        }

        private void TXTTELEFONO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        private void BTNBUSCAR_Click_1(object sender, EventArgs e)
        {
            CapaCliente.BUSQUEDAS.BusquedaClientes x = new CapaCliente.BUSQUEDAS.BusquedaClientes();
            x.ShowDialog();
            if (x.DialogResult == DialogResult.OK)
            {
                TXTID.Text = x.DgClientes.SelectedRows[0].Cells["idCliente"].Value.ToString();
                TXTNOMBRE.Text = x.DgClientes.SelectedRows[0].Cells["Nombre"].Value.ToString();
                TXTAPELLIDOPATERNO.Text = x.DgClientes.SelectedRows[0].Cells["ApellidoPa"].Value.ToString();
                TXTAPELLIDOMATERNO.Text = x.DgClientes.SelectedRows[0].Cells["ApellidoMa"].Value.ToString();
                TXTTELEFONO.Text = x.DgClientes.SelectedRows[0].Cells["NumeroTel"].Value.ToString();
                TXTCORREO.Text = x.DgClientes.SelectedRows[0].Cells["Correo"].Value.ToString();
                DTPFECHANACIMIENTO.Text = x.DgClientes.SelectedRows[0].Cells["FechaNacimiento"].Value.ToString();
                TXTVISITA.Text = x.DgClientes.SelectedRows[0].Cells["numVisita"].Value.ToString();
                TXTTIPOCLIENTE.Text = x.DgClientes.SelectedRows[0].Cells["TipoCliente"].Value.ToString();
            }
        }

        private void BTNGUARDAR_Click_1(object sender, EventArgs e)
        {
            // Validar primero
            if (!ValidarCampos())
            {
                return; // Si hay errores, detener
            }

            CapaNegocio.CLASES.Clientes x = new CapaNegocio.CLASES.Clientes();
            x.idCliente = int.Parse(TXTID.Text);
            x.Nombre = TXTNOMBRE.Text.Trim();
            x.ApellidoPa = TXTAPELLIDOPATERNO.Text.Trim();
            x.ApellidoMa = TXTAPELLIDOMATERNO.Text.Trim();
            x.NumeroTel = TXTTELEFONO.Text.Trim();
            x.Correo = TXTCORREO.Text.Trim();
            x.FechaNacimiento = DTPFECHANACIMIENTO.Value.Date; // Para DateTimePicke
            x.numVisita = int.Parse(TXTVISITA.Text);
            x.TipoCliente = TXTTIPOCLIENTE.Text.Trim();

            MessageBox.Show(x.Guardar());
            limpiar();
        }

        private void BNTELIMINAR_Click_1(object sender, EventArgs e)
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
    }
}
