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

namespace CapaCliente.BUSQUEDAS
{
    public partial class BusquedaMunicipio : FORMULARIOS.FormularioBase
    {
   public DataGridView DgMunicipios => DgProductos;

        public BusquedaMunicipio()
 {
          InitializeComponent();
    EstablecerTamanoMinimo(700, 500);
       HabilitarMaximizar();
        }

   private void BusquedaMunicipio_Load(object sender, EventArgs e)
 {
   CargarMunicipios();
     ConfigurarDataGrid();
     }

  private void ConfigurarDataGrid()
   {
    DgProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
DgProductos.MultiSelect = false;
       DgProductos.ReadOnly = true;
   DgProductos.AllowUserToAddRows = false;
    DgProductos.RowHeadersVisible = false;
        DgProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

   // Ocultar idMunicipio e idEstado
     if (DgProductos.Columns["idMunicipio"] != null)
DgProductos.Columns["idMunicipio"].Visible = false;

 if (DgProductos.Columns["idEstado"] != null)
      DgProductos.Columns["idEstado"].Visible = false;
        }

   private void CargarMunicipios()
        {
     Municipio municipio = new Municipio();
   DgProductos.DataSource = municipio.Consultar(TXTFILTRO.Text.Trim());
       ConfigurarDataGrid();

     if (DgProductos.Rows.Count > 0)
     DgProductos.Rows[0].Selected = true;
        }

    private void BTNBUSCAR_Click(object sender, EventArgs e)
  {
  CargarMunicipios();
 }

 private void btnAceptar_Click(object sender, EventArgs e)
   {
if (DgProductos.CurrentRow != null)
{
 DialogResult = DialogResult.OK;
 }
  else
         {
 MessageBox.Show("Seleccione un municipio.", "Advertencia",
    MessageBoxButtons.OK, MessageBoxIcon.Warning);
 }
        }

private void btnCancelar_Click(object sender, EventArgs e)
   {
      DialogResult = DialogResult.Cancel;
        }

        private void TXTFILTRO_TextChanged(object sender, EventArgs e)
        {
      CargarMunicipios();
        }

      private void DgProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        if (e.RowIndex >= 0)
  {
    DialogResult = DialogResult.OK;
  }
     }
    }
}
