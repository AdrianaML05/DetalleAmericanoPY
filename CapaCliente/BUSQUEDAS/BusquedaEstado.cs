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
    public partial class BusquedaEstado : FORMULARIOS.FormularioBase
    {
        public DataGridView DgEstados => DgProductos;

        public BusquedaEstado()
        {
            InitializeComponent();
            EstablecerTamanoMinimo(600, 500);
            HabilitarMaximizar();
        }

        private void BusquedaEstado_Load(object sender, EventArgs e)
        {
            CargarEstados();
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

            // Ocultar idEstado
            if (DgProductos.Columns["idEstado"] != null)
                DgProductos.Columns["idEstado"].Visible = false;
        }

        private void CargarEstados()
        {
            Estado estado = new Estado();
            DgProductos.DataSource = estado.Consultar(TXTFILTRO.Text.Trim());
            ConfigurarDataGrid();

            if (DgProductos.Rows.Count > 0)
                DgProductos.Rows[0].Selected = true;
        }

        private void BTNBUSCAR_Click(object sender, EventArgs e)
        {
            CargarEstados();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (DgProductos.CurrentRow != null)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Seleccione un estado.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TXTFILTRO_TextChanged(object sender, EventArgs e)
        {
            CargarEstados();
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
