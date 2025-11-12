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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }
        public void abrirformulario(object formopen)
        {
            if (this.Abrirform.Controls.Count > 0)
                this.Abrirform.Controls.RemoveAt(0);
            Form fh = formopen as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.Abrirform.Controls.Add(fh);
            this.Abrirform.Tag = fh;
            fh.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            abrirformulario(new frmVenta());
            //frmVenta x = new frmVenta();
            //x.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            abrirformulario(new frmEmpleados());
            //frmEmpleados x = new frmEmpleados();
            //x.ShowDialog();
        }

        private void PRODUCTOS_Click(object sender, EventArgs e)
        {
            abrirformulario(new frmClientes());
            //frmClientes x = new frmClientes();
            //x.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            abrirformulario(new frmProductos());
            //frmProductos x = new frmProductos();
            //x.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            abrirformulario(new frmPedidos());
            //frmPedidos x = new frmPedidos();
            //x.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmMunicipio x = new frmMunicipio();
            x.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmEstado x = new frmEstado();
            x.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            abrirformulario(new frmDomicilios());
            //frmDomicilios x = new frmDomicilios();
            //x.ShowDialog();
        }

        private void INVENTARIO_Click(object sender, EventArgs e)
        {
            abrirformulario(new frmInventario());
            //frmInventario x = new frmInventario();
            //x.ShowDialog();
        }

        private void PROVEEDORES_Click(object sender, EventArgs e)
        {
            abrirformulario(new frmProveedores());
            //frmProveedores x = new frmProveedores();
            //x.ShowDialog();
        }

        private void COMPRA_Click(object sender, EventArgs e)
        {
            abrirformulario(new frmCompra());
            //frmCompra x = new frmCompra();
            //x.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            abrirformulario(new frmEnvios());
            //frmEnvios x = new frmEnvios();
            //x.ShowDialog();
        }

        private void REGRESAR_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            abrirformulario(new frmPaqueteria());
            //frmPaqueteria x = new frmPaqueteria();
            //x.ShowDialog();
        }
    }
}
