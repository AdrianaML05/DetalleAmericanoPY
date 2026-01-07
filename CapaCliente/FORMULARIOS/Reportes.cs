using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaCliente.Reportes;

namespace CapaCliente.FORMULARIOS
{
    public partial class Reportes : Form
    {
    private Panel panelPrincipal;

        public Reportes()
   {
          InitializeComponent();
        }

 // Constructor que recibe el panel donde se abrirán los reportes
  public Reportes(Panel panel)
    {
         InitializeComponent();
  panelPrincipal = panel;
        }

private void AbrirReporteEnPanel(Form formulario)
 {
       if (panelPrincipal != null)
            {
   // Limpiar el panel
     if (panelPrincipal.Controls.Count > 0)
         panelPrincipal.Controls.RemoveAt(0);

     // Configurar el formulario
    formulario.TopLevel = false;
   formulario.FormBorderStyle = FormBorderStyle.None;
          formulario.Dock = DockStyle.Fill;

   // Agregar al panel
    panelPrincipal.Controls.Add(formulario);
    panelPrincipal.Tag = formulario;
    formulario.Show();

         // Cerrar este mini menú
    this.Close();
}
   }

 private void btnVenta_Click(object sender, EventArgs e)
        {
  AbrirReporteEnPanel(new frmRVenta());
    }

       private void btnCompra_Click(object sender, EventArgs e)
 {
        AbrirReporteEnPanel(new frmRCompra());
 }

       private void btnInventario_Click(object sender, EventArgs e)
     {
AbrirReporteEnPanel(new frmRInvenatrio());
        }
    }
}
