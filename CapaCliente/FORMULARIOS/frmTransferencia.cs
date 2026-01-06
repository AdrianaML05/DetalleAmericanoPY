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
    public partial class frmTransferencia : Form
    {
        private decimal totalVenta;
        private string folioVenta;

        public frmTransferencia()
        {
            InitializeComponent();
        }

        // Constructor que recibe el total y el folio de la venta
        public frmTransferencia(decimal total, string folio)
        {
            InitializeComponent();
            totalVenta = total;
            folioVenta = folio;
        }

        private void frmTransferencia_Load(object sender, EventArgs e)
        {
            // Configurar el total (solo lectura con signo de pesos)
            txtTotal.Text = totalVenta.ToString("C2");
            txtTotal.ReadOnly = true;

            // Llenar automáticamente el motivo con "Pago" y el folio
            txtMotivo.Text = $"Pago {folioVenta}";
            txtMotivo.ReadOnly = true; // El motivo es automático, no se puede editar
        }

        // Propiedad para obtener el motivo
        public string Motivo
        {
            get { return txtMotivo.Text; }
        }
    }
}
