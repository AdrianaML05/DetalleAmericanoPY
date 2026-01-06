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
    public partial class frmMix : Form
    {
        private decimal totalVenta;

        public frmMix()
        {
            InitializeComponent();
        }

        // Constructor que recibe el total de la venta
        public frmMix(decimal total)
        {
            InitializeComponent();
            totalVenta = total;
        }

        private void frmMix_Load(object sender, EventArgs e)
        {
            // Mostrar el total
            txtTotal.Text = totalVenta.ToString("C2");
            txtTotal.ReadOnly = true;

            // Configurar txtDiferencia como solo lectura (se calcula automáticamente)
            txtDiferencia.ReadOnly = true;
            txtDiferencia.Text = totalVenta.ToString("C2"); // Inicialmente es el total

            // Seleccionar Débito por defecto
            rdDebito.Checked = true;

            // Configurar eventos y validaciones
            txtMonto.KeyPress += SoloNumeros_KeyPress;
            txtMonto.TextChanged += txtMonto_TextChanged;
            txtMonto.MaxLength = 10;
        }

        // Solo permitir números y un punto decimal
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Permitir números, punto decimal y teclas de control (backspace, etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && txt.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        // Calcular la diferencia automáticamente cuando cambia el monto de tarjeta
        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtMonto.Text, out decimal montoTarjeta))
            {
                decimal diferencia = totalVenta - montoTarjeta;

                if (diferencia >= 0)
                {
                    txtDiferencia.Text = diferencia.ToString("C2");
                }
                else
                {
                    txtDiferencia.Text = "$0.00";
                    MessageBox.Show("El monto de tarjeta no puede ser mayor al total.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMonto.Text = "";
                }
            }
            else
            {
                txtDiferencia.Text = totalVenta.ToString("C2");
            }
        }

        // Propiedad para obtener el monto de tarjeta
        public decimal MontoTarjeta
        {
            get
            {
                if (decimal.TryParse(txtMonto.Text, out decimal monto))
                    return monto;
                return 0;
            }
        }

        // Propiedad para obtener la diferencia en efectivo (lo que debe pagar)
        public decimal DiferenciaEfectivo
        {
            get
            {
                return totalVenta - MontoTarjeta;
            }
        }

        // Propiedad para saber si es crédito o débito
        public string TipoTarjeta
        {
            get
            {
                return rdCredito.Checked ? "Crédito" : "Débito";
            }
        }

        // Validar que los campos obligatorios estén llenos
        public bool ValidarCampos()
        {
            if (MontoTarjeta <= 0)
            {
                MessageBox.Show("Por favor ingrese el monto a pagar con tarjeta.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMonto.Focus();
                return false;
            }

            if (MontoTarjeta >= totalVenta)
            {
                MessageBox.Show("El monto de tarjeta debe ser menor al total.\nSi desea pagar todo con tarjeta, seleccione la opción TARJETA.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMonto.Focus();
                return false;
            }

            return true;
        }
    }
}
