using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaCliente.FORMULARIOS
{
    public partial class frmPagoTarjeta : Form
    {
        private decimal totalVenta;

        public frmPagoTarjeta()
        {
            InitializeComponent();
        }

        // Constructor que recibe el total de la venta
        public frmPagoTarjeta(decimal total)
        {
            InitializeComponent();
            totalVenta = total;
        }

        private void frmPagoTarjeta_Load(object sender, EventArgs e)
        {
            // Llenar el ComboBox con los bancos
            CargarBancos();

            // Configurar el total (solo lectura con signo de pesos)
            txtTotal.Text = totalVenta.ToString("C2");
            txtTotal.ReadOnly = true;

            // Seleccionar Débito por defecto
            rbDebito.Checked = true;

            // Configurar validaciones de campos
            ConfigurarValidaciones();
        }

        private void CargarBancos()
        {
            cbmTerminal.Items.Clear();
            cbmTerminal.Items.Add("BBVA");
            cbmTerminal.Items.Add("Citibanamex");
            cbmTerminal.Items.Add("Santander");
            cbmTerminal.Items.Add("Banorte");
            cbmTerminal.Items.Add("HSBC");
            cbmTerminal.Items.Add("Scotiabank");
            cbmTerminal.SelectedIndex = 0; // Seleccionar BBVA por defecto
        }

        private void ConfigurarValidaciones()
        {
            // Número de autorización - solo números, máximo 10 caracteres
            txtNum.MaxLength = 10;
            txtNum.KeyPress += SoloNumeros_KeyPress;

            // Últimos 4 dígitos - solo números, máximo 4 caracteres
            txtNIP.MaxLength = 4;
            txtNIP.KeyPress += SoloNumeros_KeyPress;

            // Referencia - máximo 50 caracteres
            txtReferencia.MaxLength = 50;
        }

        // Validación para solo permitir números
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Propiedades para obtener los datos del pago
        public string TipoTarjeta
        {
            get { return rbCredito.Checked ? "Crédito" : "Débito"; }
        }

        public string NumeroAutorizacion
        {
            get { return txtNum.Text; }
        }

        public string Ultimos4Digitos
        {
            get { return txtNIP.Text; }
        }

        public string BancoTerminal
        {
            get { return cbmTerminal.SelectedItem?.ToString() ?? ""; }
        }

        public string Referencia
        {
            get { return txtReferencia.Text; }
        }

        // Validar que los campos obligatorios estén llenos
        public bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNum.Text))
            {
                MessageBox.Show("Por favor ingrese el número de autorización.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNum.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtNIP.Text) || txtNIP.Text.Length < 4)
            {
                MessageBox.Show("Por favor ingrese los últimos 4 dígitos de la tarjeta.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNIP.Focus();
                return false;
            }

            return true;
        }
    }
}
