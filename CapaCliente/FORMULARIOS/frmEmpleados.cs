using CapaNegocio.CLASES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace CapaCliente.FORMULARIOS
{
    public partial class frmEmpleados : Form  // VOLVER a Form (no FormularioBase)
    {
        static Conexion x = new Conexion();
   SqlConnection con = new SqlConnection();
    
    public frmEmpleados()
        {
       InitializeComponent();
     
      // QUITAR configuración de FormularioBase
       // EstablecerTamanoMinimo(900, 700);
   // HabilitarMaximizar();
   // this.FormBorderStyle = FormBorderStyle.FixedSingle;
 
    con.ConnectionString = x.conexion();
     }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            CapaNegocio.CLASES.Herramientas h = new Herramientas();
            TXTID.Text = h.consecutivo("idEmpleados", "catEmpleados").ToString();
        }

        public void limpiar()
        {
            TXTNOMBRE.Clear();
            TXTAPELLIDOMATERNO.Clear();
            TXTAPELLIDOPATERNO.Clear();
            TXTTELEFONO.Clear();
            TXTCORREO.Clear();
            TXTRFC.Clear();
            TXTCURP.Clear();
            TXTPUESTO.Clear();
            CapaNegocio.CLASES.Herramientas h = new Herramientas();
            TXTID.Text = h.consecutivo("idEmpleados", "catEmpleados").ToString();
            TXTNOMBRE.Focus();
            TXTAPELLIDOMATERNO.Focus();
            TXTAPELLIDOPATERNO.Focus();
            TXTCORREO.Focus();
            TXTTELEFONO.Focus();
            TXTRFC.Focus();
            TXTCURP.Focus();
            TXTPUESTO.Focus();

        }
        bool encontro()
        {
            bool a = false;
            int idEmpleados = int.Parse(TXTID.Text);
            string cadena = $"select * from catEmpleados where idEmpleados = '{idEmpleados}'";
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

            return true; // Todos los campos son válidos
        }

        //===============================================
        // Los siguientes botones no se usan ya que 
        // Ubo un error y se crearon nuevos
        //===============================================
        private void BTNGUARDAR_Click(object sender, EventArgs e)
        {
            //===============================================
            //      No se usa este boton, se repite abajo
            //===============================================
        }

        private void BTNBUSCAR_Click(object sender, EventArgs e)
        {
            //===============================================
            //      No se usa este boton, se repite abajo
            //===============================================
        }

        private void BTNLIMPIAR_Click(object sender, EventArgs e)
        {
            //===============================================
            //      No se usa este boton, se repite abajo
            //===============================================
        }

        private void BTNELIMINAR_Click(object sender, EventArgs e)
        {
            //===============================================
            //      No se usa este boton, se repite abajo
            //===============================================
        }

        private void TXTTELEFONO_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTTELEFONO_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void TXTTELEFONO_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //==============================================
            //  Bloquea los caracteres que no sean numeros
            //==============================================

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        //===============================================
        // Se repite porque se creo un nuevo boton buscar
        //===============================================
        private void BTNBUSCAR_Click_1(object sender, EventArgs e)
        {
            CapaCliente.BUSQUEDAS.BusquedaEmpleados x = new CapaCliente.BUSQUEDAS.BusquedaEmpleados();
            x.ShowDialog();
            if (x.DialogResult == DialogResult.OK)
            {
                TXTID.Text = x.DgEmpleados.SelectedRows[0].Cells["idEmpleados"].Value.ToString();
                TXTNOMBRE.Text = x.DgEmpleados.SelectedRows[0].Cells["Nombre"].Value.ToString();
                TXTAPELLIDOPATERNO.Text = x.DgEmpleados.SelectedRows[0].Cells["ApellidoPa"].Value.ToString();
                TXTAPELLIDOMATERNO.Text = x.DgEmpleados.SelectedRows[0].Cells["ApellidoMa"].Value.ToString();
                TXTTELEFONO.Text = x.DgEmpleados.SelectedRows[0].Cells["Telefono"].Value.ToString();
                TXTCORREO.Text = x.DgEmpleados.SelectedRows[0].Cells["Correo"].Value.ToString();
                TXTRFC.Text = x.DgEmpleados.SelectedRows[0].Cells["RFC"].Value.ToString();
                TXTCURP.Text = x.DgEmpleados.SelectedRows[0].Cells["CURP"].Value.ToString();
                TXTPUESTO.Text = x.DgEmpleados.SelectedRows[0].Cells["Puesto"].Value.ToString();

            }

        }

        //===================================================
        //  Se repite porque se creo un nuevo boton limpiar
        //====================================================
        private void BTNLIMPIAR_Click_1(object sender, EventArgs e)
        {
            limpiar();  
        }

        //===================================================
        //  Se repite porque se creo un nuevo boton Guardar
        //====================================================
        private void BTNGUARDAR_Click_1(object sender, EventArgs e)
        {
            // Validar primero
            if (!ValidarCampos())
            {
                return; // Si hay errores, detener
            }

            CapaNegocio.CLASES.Empleados x = new CapaNegocio.CLASES.Empleados();
            x.idEmpleados = int.Parse(TXTID.Text);
            x.Nombre = TXTNOMBRE.Text.Trim();
            x.ApellidoPa = TXTAPELLIDOPATERNO.Text.Trim();
            x.ApellidoMa = TXTAPELLIDOMATERNO.Text.Trim();
            x.Telefono = TXTTELEFONO.Text.Trim();
            x.Correo = TXTCORREO.Text.Trim();
            x.RFC = TXTRFC.Text.Trim();
            x.CURP = TXTCURP.Text.Trim();
            x.Puesto = TXTPUESTO.Text.Trim();

            MessageBox.Show(x.Guardar());
            limpiar();
        }


        //===================================================
        //  Se repite porque se creo un nuevo boton Eliminar
        //====================================================
        private void BTNELIMINAR_Click_1(object sender, EventArgs e)
        {
            CapaNegocio.CLASES.Empleados x = new CapaNegocio.CLASES.Empleados();
            x.idEmpleados = int.Parse(TXTID.Text);
            if (encontro() == true)
            {
                //MessageBox.Show(x.Eliminar());
                x.Eliminar();
                MessageBox.Show("Se elimino el registro.");
                limpiar();
            }
            else
            {
                MessageBox.Show("No se encontro el elemento a eliminar");
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
