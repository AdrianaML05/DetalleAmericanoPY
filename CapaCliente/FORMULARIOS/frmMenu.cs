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
    public partial class frmMenu : FormularioBase  // Heredar de FormularioBase
    {
        public frmMenu()
        {
            InitializeComponent();
        
            // Configurar el menú principal para que se adapte a la pantalla
            EstablecerTamanoMinimo(1400, 900);
            HabilitarMaximizar();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            // Maximizar el formulario al iniciar (opcional)
            this.WindowState = FormWindowState.Maximized;
        }

        public void abrirformulario(object formopen)
        {
            if (this.Abrirform.Controls.Count > 0)
                this.Abrirform.Controls.RemoveAt(0);
           
                Form fh = formopen as Form;
                fh.TopLevel = false;
                fh.FormBorderStyle = FormBorderStyle.None;  // ⭐ QUITAR BORDES
                fh.Dock = DockStyle.Fill;
        
          this.Abrirform.Controls.Add(fh);
                this.Abrirform.Tag = fh;
          fh.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            abrirformulario(new frmVenta());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            abrirformulario(new frmEmpleados());
        }

        private void PRODUCTOS_Click(object sender, EventArgs e)
        {
      abrirformulario(new frmClientes());
      }

        private void button4_Click(object sender, EventArgs e)
        {
            abrirformulario(new frmProductos());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            abrirformulario(new frmPedidos());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            abrirformulario(new frmMunicipio());
        }

        private void button8_Click(object sender, EventArgs e)
      {
            abrirformulario(new frmEstado());
        }

        private void button5_Click(object sender, EventArgs e)
        {
     abrirformulario(new frmDomicilios());
        }

        private void INVENTARIO_Click(object sender, EventArgs e)
        {
          abrirformulario(new frmInventario());
        }

        private void PROVEEDORES_Click(object sender, EventArgs e)
        {
            abrirformulario(new frmProveedores());
    }

        private void COMPRA_Click(object sender, EventArgs e)
    {
            abrirformulario(new frmCompra());
      }

    private void button6_Click(object sender, EventArgs e)
        {
            abrirformulario(new frmEnvios());
     }

        private void REGRESAR_Click(object sender, EventArgs e)
        {
     DialogResult = DialogResult.Cancel;
        }

        private void button10_Click(object sender, EventArgs e)
    {
     abrirformulario(new frmPaqueteria());
        }
    }
}
