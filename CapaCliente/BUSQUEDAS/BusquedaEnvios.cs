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
    public partial class BusquedaEnvios : FORMULARIOS.FormularioBase
    {
        public DataGridView DgEnvios => DgProductos;

        public BusquedaEnvios()
        {
            InitializeComponent();
            EstablecerTamanoMinimo(700, 500);
            HabilitarMaximizar();
        }

        private void BusquedaEnvios_Load(object sender, EventArgs e)
        {
            // Configurar eventos de RadioButtons
            rbPendiente.CheckedChanged += RadioButton_CheckedChanged;
            rbTransito.CheckedChanged += RadioButton_CheckedChanged;
            rbEntrega.CheckedChanged += RadioButton_CheckedChanged;
            rbCancelado.CheckedChanged += RadioButton_CheckedChanged;

            // Ninguno seleccionado por defecto (mostrar todos)
            rbPendiente.Checked = false;
            rbTransito.Checked = false;
            rbEntrega.Checked = false;
            rbCancelado.Checked = false;

            CargarEnvios();
            ConfigurarDataGrid();
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Solo recargar cuando se marca (no cuando se desmarca)
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                CargarEnvios();
            }
        }

        private void ConfigurarDataGrid()
        {
            DgProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgProductos.MultiSelect = false;
            DgProductos.ReadOnly = true;
            DgProductos.AllowUserToAddRows = false;
            DgProductos.RowHeadersVisible = false;
            DgProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ocultar columnas
            if (DgProductos.Columns["idEnvio"] != null)
                DgProductos.Columns["idEnvio"].Visible = false;

            if (DgProductos.Columns["EstatusId"] != null)
                DgProductos.Columns["EstatusId"].Visible = false;

            // Formato de fecha
            if (DgProductos.Columns["Fecha"] != null)
                DgProductos.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private int ObtenerEstatusSeleccionado()
        {
            if (rbPendiente.Checked) return 1;
            if (rbTransito.Checked) return 2;
            if (rbEntrega.Checked) return 3;
            if (rbCancelado.Checked) return 4;
            return 0; // 0 = Todos
        }

        private void CargarEnvios()
        {
            Envio envio = new Envio();
            int estatus = ObtenerEstatusSeleccionado();
            DgProductos.DataSource = envio.ConsultarEnvios(TXTFILTRO.Text.Trim(), estatus);
            ConfigurarDataGrid();

            if (DgProductos.Rows.Count > 0)
                DgProductos.Rows[0].Selected = true;
        }

        private void BTNBUSCAR_Click(object sender, EventArgs e)
        {
            CargarEnvios();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (DgProductos.CurrentRow != null)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Seleccione un envío.", "Advertencia",
                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TXTFILTRO_TextChanged(object sender, EventArgs e)
        {
            CargarEnvios();
        }

        private void DgProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DialogResult = DialogResult.OK;
            }
        }

        // Método para limpiar filtros de RadioButtons
        private void LimpiarFiltroEstatus()
        {
            rbPendiente.Checked = false;
            rbTransito.Checked = false;
            rbEntrega.Checked = false;
            rbCancelado.Checked = false;
            CargarEnvios();
        }
    }
}
