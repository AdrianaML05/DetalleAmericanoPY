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

namespace CapaCliente.FORMULARIOS
{
    public partial class frmConsultaVenta : FormularioBase  // Cambiar de Form a FormularioBase
    {
        static Conexion x = new Conexion();
        DataTable dtVentas = new DataTable();
        private int idVentaSeleccionada = 0;

        public frmConsultaVenta()
        {
            InitializeComponent();
 
            // Configurar tamaño y comportamiento del formulario
            EstablecerTamanoMinimo(720, 700);
            HabilitarMaximizar();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmConsultaVenta_Load(object sender, EventArgs e)
        {
            ConfigurarComboEstado();
            ConfigurarDataGridVentas();
            ConfigurarDataGridDetalle();

            // Establecer las Fechas por defecto para el Ultimo mes
            dtpFechaInicio.Value = DateTime.Now.AddMonths(-1);
            dtpFechaFin.Value = DateTime.Now;

            // NO cargar ventas al inicio - los grids quedan vacíos
            InicializarDataGridsVacios();

            // Deshabilitar el botón cancelar al inicio
            btnCancelar.Enabled = false;
        }

        private void ConfigurarComboEstado()
        {
            cmbEstado.Items.Add("Todas");
            cmbEstado.Items.Add("Completadas");
            cmbEstado.Items.Add("Canceladas");
            cmbEstado.SelectedIndex = 0;
        }

        private void ConfigurarDataGridVentas()
        {
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.MultiSelect = false;
            dgvVentas.ReadOnly = true;
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.RowHeadersVisible = false;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ConfigurarDataGridDetalle()
        {
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.MultiSelect = false;
            dgvDetalle.ReadOnly = true;
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void InicializarDataGridsVacios()
        {
            // Inicializar grid de ventas vacío
            dgvVentas.DataSource = null;

            // Inicializar grid de detalle vacío
            dgvDetalle.DataSource = null;

            // Resetear ID de venta seleccionada
            idVentaSeleccionada = 0;
        }

        private void CargarVentas()
        {
            string query = @"SELECT v.idVenta as 'ID', v.Folio, CONVERT(VARCHAR, v.Fecha, 103) AS 'Fecha', c.Nombre + ' ' + c.ApellidoPa + ' ' + c.ApellidoMa AS 'Cliente', e.Nombre + ' ' + e.ApellidoPa AS 'Empleado', fp.Descripcion AS 'Forma Pago', v.Total, v.Estatus, ISNULL(CONVERT(VARCHAR, v.FechaCancelacion, 103), '') AS 'Fecha Cancelación', ISNULL(v.MotivoCancelacion, '') AS 'Motivo' FROM Venta v INNER JOIN catClientes c ON v.idCliente = c.idCliente INNER JOIN catEmpleados e ON v.idEmpleados = e.idEmpleados INNER JOIN catFormaPago fp ON v.idFormaPago = fp.idFormaPago WHERE v.Fecha BETWEEN @FechaInicio AND @FechaFin";

            // Agregar filtros adicionales
            if (!string.IsNullOrEmpty(txtFolio.Text))
            {
                query += " AND v.Folio LIKE @Folio";
            }

            if (!string.IsNullOrEmpty(txtCliente.Text))
            {
                query += " AND (c.Nombre + ' ' + c.ApellidoPa + ' ' + c.ApellidoMa) LIKE @Cliente";
            }

            if (cmbEstado.SelectedIndex > 0)
            {
                string estado = cmbEstado.SelectedItem.ToString() == "Completadas" ? "Completada" : "Cancelada";
                query += " AND v.Estatus = @Estatus";
            }

            query += " ORDER BY v.idVenta DESC";

            using (SqlConnection con = new SqlConnection(x.conexion()))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FechaInicio", dtpFechaInicio.Value.Date);
                    cmd.Parameters.AddWithValue("@FechaFin", dtpFechaFin.Value.Date.AddDays(1).AddSeconds(-1));

                    if (!string.IsNullOrEmpty(txtFolio.Text))
                        cmd.Parameters.AddWithValue("@Folio", "%" + txtFolio.Text + "%");

                    if (!string.IsNullOrEmpty(txtCliente.Text))
                        cmd.Parameters.AddWithValue("@Cliente", "%" + txtCliente.Text + "%");

                    if (cmbEstado.SelectedIndex > 0)
                    {
                        string estado = cmbEstado.SelectedItem.ToString() == "Completadas" ? "Completada" : "Cancelada";
                        cmd.Parameters.AddWithValue("@Estatus", estado);
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        dtVentas = new DataTable();
                        da.Fill(dtVentas);
                    }
                }
            }

            dgvVentas.DataSource = dtVentas;

            // Ocultar columnas innecesarias
            if (dgvVentas.Columns["ID"] != null)
                dgvVentas.Columns["ID"].Visible = false;

            // Formato de columnas
            if (dgvVentas.Columns["Total"] != null)
            {
                dgvVentas.Columns["Total"].DefaultCellStyle.Format = "C2";
                dgvVentas.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Colorear filas según estado
            foreach (DataGridViewRow row in dgvVentas.Rows)
            {
                if (row.Cells["Estatus"].Value != null && row.Cells["Estatus"].Value.ToString() == "Cancelada")
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                    row.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                }
            }

            // Si hay datos, seleccionar la primera fila automáticamente
            if (dgvVentas.Rows.Count > 0)
            {
                dgvVentas.ClearSelection();
                dgvVentas.Rows[0].Selected = true;
                dgvVentas.CurrentCell = dgvVentas.Rows[0].Cells["Folio"];

                // Cargar el detalle de la primera fila
                idVentaSeleccionada = Convert.ToInt32(dgvVentas.Rows[0].Cells["ID"].Value);
                CargarDetalle(idVentaSeleccionada);

                // Habilitar/deshabilitar botón cancelar según el estado
                string estatus = dgvVentas.Rows[0].Cells["Estatus"].Value?.ToString() ?? "";
                btnCancelar.Enabled = (estatus == "Completada" || estatus == "Activa");
            }
            else
            {
                // No hay resultados - limpiar detalle
                dgvDetalle.DataSource = null;
                idVentaSeleccionada = 0;
                btnCancelar.Enabled = false;
            }
        }

        private void dgvVentas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow != null && dgvVentas.CurrentRow.Cells["ID"].Value != null)
            {
                idVentaSeleccionada = Convert.ToInt32(dgvVentas.CurrentRow.Cells["ID"].Value);
                CargarDetalle(idVentaSeleccionada);

                // Habilitar/deshabilitar botón cancelar según el estado
                string estatus = dgvVentas.CurrentRow.Cells["Estatus"].Value?.ToString() ?? "";
                btnCancelar.Enabled = (estatus == "Completada" || estatus == "Activa");
            }
            else
            {
                // No hay selección válida
                idVentaSeleccionada = 0;
                dgvDetalle.DataSource = null;
                btnCancelar.Enabled = false;
            }
        }

        private void CargarDetalle(int idVenta)
        {
            string query = @"SELECT p.Nombre AS 'Producto', vd.CantidadProducto AS 'Cantidad', vd.PrecioProducto AS 'Precio Unitario', vd.subTotal AS 'Subtotal' FROM VentaDetalle vd INNER JOIN catProducto p ON vd.idProducto = p.idProducto WHERE vd.idVenta = @idVenta";

            using (SqlConnection con = new SqlConnection(x.conexion()))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@idVenta", idVenta);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dtDetalle = new DataTable();
                        da.Fill(dtDetalle);
                        dgvDetalle.DataSource = dtDetalle;
                    }
                }
            }

            // Formato de columnas
            if (dgvDetalle.Columns["Precio Unitario"] != null)
            {
                dgvDetalle.Columns["Precio Unitario"].DefaultCellStyle.Format = "C2";
                dgvDetalle.Columns["Precio Unitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvDetalle.Columns["Subtotal"] != null)
            {
                dgvDetalle.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
                dgvDetalle.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarVentas();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFolio.Clear();
            txtCliente.Clear();
            cmbEstado.SelectedIndex = 0;
            dtpFechaInicio.Value = DateTime.Now.AddMonths(-1);
            dtpFechaFin.Value = DateTime.Now;

            // Limpiar los DataGrids
            InicializarDataGridsVacios();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (idVentaSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una venta para cancelar.", "Advertencia",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar que el row actual no sea null
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("No hay una venta seleccionada.", "Advertencia",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar que la venta esté activa o completada
            string estatus = dgvVentas.CurrentRow.Cells["Estatus"].Value?.ToString() ?? "";
            if (estatus != "Activa" && estatus != "Completada")
            {
                MessageBox.Show("Solo se pueden cancelar ventas activas o completadas.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mostrar formulario de cancelación
            frmMotivoCancelacion formMotivo = new frmMotivoCancelacion();
            if (formMotivo.ShowDialog() == DialogResult.OK)
            {
                string motivo = formMotivo.Motivo;

                // Confirmar cancelación
                string mensaje = $"¿Está seguro que desea cancelar la venta {dgvVentas.CurrentRow.Cells["Folio"].Value}?\n\n" + $"Cliente: {dgvVentas.CurrentRow.Cells["Cliente"].Value}\n" + $"Total: {dgvVentas.CurrentRow.Cells["Total"].Value}\n" + $"Motivo: {motivo}\n\n" + $"Esta acción devolverá el inventario.";

                DialogResult result = MessageBox.Show(mensaje, "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int idEmpleado = 1; // Obtener del login

                    Ventas venta = new Ventas();
                    string respuesta = venta.Cancelar(idVentaSeleccionada, motivo, idEmpleado);

                    if (respuesta.Contains("correctamente") || respuesta.Contains("Correctamente"))
                    {
                        MessageBox.Show(respuesta, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarVentas(); // Recargar ventas
                    }
                    else
                    {
                        MessageBox.Show(respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
