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
    public partial class frmVenta : Form
    {
        public frmVenta()
        {
            InitializeComponent();
        }


        private void DgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmCobrar x = new frmCobrar();
            x.ShowDialog();
        }
    }
}
