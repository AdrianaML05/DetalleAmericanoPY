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
    public partial class frmPedidos : Form
    {
        static Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        DataTable dtProductos = new DataTable();
        DataTable dtClientes = new DataTable();
        private int idClienteSelec = 1; // Por defecto PÚBLICO GENERAL

        public frmPedidos()
        {
            InitializeComponent();
            con.ConnectionString = x.conexion();
        }

        private void frmPedidos_Load(object sender, EventArgs e)
        {
            // Generar folio automático (empieza con P de Pedido)
            GenerarFolio();

            // Configurar fecha actual
            dtpFecha.Value = DateTime.Now;

            // Configurar DataGrids
            ConfigurarDataGridProductos();
            ConfigurarDataGridClientes();

            // Cargar clientes
            CargarClientes();

            // Configurar eventos
            txtCodigo.KeyPress += txtCodigo_KeyPress;
            txtCantidad.KeyPress += SoloNumeros_KeyPress;
            txtBuscar.TextChanged += txtBuscar_TextChanged;

            // Configurar txtTotal como solo lectura
            txtTotal.ReadOnly = true;
            txtTotal.Text = "$0.00";

            // Configurar txtFoli como solo lectura
            txtFoli.ReadOnly = true;
        }

        #region Folio Automático

        private void GenerarFolio()
        {
            // Formato: P-YYYYMMDD (P de Pedido)
            txtFoli.Text = $"P-{DateTime.Now:yyyyMMdd}";
        }

        #endregion

        #region Configuración de DataGrids

        private void ConfigurarDataGridProductos()
        {
            // Crear columnas para el DataTable de productos
            dtProductos.Columns.Add("idProducto", typeof(int));
            dtProductos.Columns.Add("Codigo");
            dtProductos.Columns.Add("Nombre");
            dtProductos.Columns.Add("Cantidad", typeof(int));
            dtProductos.Columns.Add("Precio", typeof(decimal));
            dtProductos.Columns.Add("SubTotal", typeof(decimal));

            dgProductos.DataSource = dtProductos;

            // Ocultar columna idProducto
            if (dgProductos.Columns["idProducto"] != null)
                dgProductos.Columns["idProducto"].Visible = false;

            // Formato de moneda
            if (dgProductos.Columns["Precio"] != null)
            {
                dgProductos.Columns["Precio"].DefaultCellStyle.Format = "$#,##0.00";
                dgProductos.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgProductos.Columns["SubTotal"] != null)
            {
                dgProductos.Columns["SubTotal"].DefaultCellStyle.Format = "$#,##0.00";
                dgProductos.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgProductos.Columns["Cantidad"] != null)
                dgProductos.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Configuración general
            dgProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgProductos.MultiSelect = false;
            dgProductos.ReadOnly = true;
            dgProductos.AllowUserToAddRows = false;
            dgProductos.RowHeadersVisible = false;
            dgProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ConfigurarDataGridClientes()
        {
            // Configuración general
            dgCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgCliente.MultiSelect = false;
            dgCliente.ReadOnly = true;
            dgCliente.AllowUserToAddRows = false;
            dgCliente.RowHeadersVisible = false;
            dgCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Evento de selección
            dgCliente.SelectionChanged += dgCliente_SelectionChanged;
        }

        #endregion

        #region Cargar Clientes

        private void CargarClientes()
        {
            string query = @"
          SELECT 
     idCliente,
         Nombre + ' ' + ApellidoPa + ' ' + ApellidoMa AS NombreCompleto,
           NumeroTel,
 Correo
            FROM catClientes 
  ORDER BY 
  CASE WHEN idCliente = 1 THEN 0 ELSE 1 END,
                Nombre ASC";

            using (SqlConnection con = new SqlConnection(x.conexion()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    dtClientes = new DataTable();
                    da.Fill(dtClientes);
                }
            }

            dgCliente.DataSource = dtClientes;

            // Ocultar columna idCliente
            if (dgCliente.Columns["idCliente"] != null)
                dgCliente.Columns["idCliente"].Visible = false;

            // Renombrar columnas
            if (dgCliente.Columns["NombreCompleto"] != null)
                dgCliente.Columns["NombreCompleto"].HeaderText = "Nombre Completo";

            if (dgCliente.Columns["NumeroTel"] != null)
                dgCliente.Columns["NumeroTel"].HeaderText = "Teléfono";

            // Seleccionar el primer cliente (PÚBLICO GENERAL) por defecto
            if (dgCliente.Rows.Count > 0)
            {
                dgCliente.Rows[0].Selected = true;
                idClienteSelec = Convert.ToInt32(dgCliente.Rows[0].Cells["idCliente"].Value);
            }
        }

        private void dgCliente_SelectionChanged(object sender, EventArgs e)
        {
            if (dgCliente.CurrentRow != null && dgCliente.CurrentRow.Cells["idCliente"].Value != null)
            {
                idClienteSelec = Convert.ToInt32(dgCliente.CurrentRow.Cells["idCliente"].Value);
            }
        }

        // Filtrar clientes mientras escribe
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(filtro))
            {
                dtClientes.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                dtClientes.DefaultView.RowFilter = string.Format(
                    "NombreCompleto LIKE '%{0}%' OR NumeroTel LIKE '%{0}%' OR Correo LIKE '%{0}%'",
                    filtro.Replace("'", "''")
                );
            }

            // Seleccionar la primera fila si hay resultados
            if (dgCliente.Rows.Count > 0)
            {
                dgCliente.Rows[0].Selected = true;
                idClienteSelec = Convert.ToInt32(dgCliente.Rows[0].Cells["idCliente"].Value);
            }
        }

        #endregion

        #region Agregar Productos

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AgregarProducto();
                e.Handled = true;
            }
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void AgregarProducto()
        {
            string codigo = txtCodigo.Text.Trim();
            if (string.IsNullOrEmpty(codigo))
            {
                MessageBox.Show("Por favor ingrese el código del producto.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = 1;
            if (!string.IsNullOrEmpty(txtCantidad.Text))
            {
                if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser un número mayor a 0.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Buscar producto en la base de datos
            string query = "SELECT idProducto, Codigo, Nombre, PrecioVenta FROM catProducto WHERE Codigo = @Codigo";

            using (SqlConnection con = new SqlConnection(x.conexion()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int idProducto = Convert.ToInt32(reader["idProducto"]);
                            string codigoProducto = reader["Codigo"].ToString();
                            string nombre = reader["Nombre"].ToString();
                            decimal precio = Convert.ToDecimal(reader["PrecioVenta"]);

                            reader.Close();

                            // Verificar si el producto ya existe en el DataTable
                            bool productoExiste = false;
                            foreach (DataRow row in dtProductos.Rows)
                            {
                                if (Convert.ToInt32(row["idProducto"]) == idProducto)
                                {
                                    // Producto encontrado - sumar la cantidad
                                    int cantidadActual = Convert.ToInt32(row["Cantidad"]);
                                    int nuevaCantidad = cantidadActual + cantidad;
                                    decimal nuevoSubtotal = nuevaCantidad * precio;

                                    row["Cantidad"] = nuevaCantidad;
                                    row["SubTotal"] = nuevoSubtotal;

                                    productoExiste = true;
                                    break;
                                }
                            }

                            // Si el producto NO existe, agregarlo como nueva fila
                            if (!productoExiste)
                            {
                                decimal subtotal = cantidad * precio;

                                DataRow fila = dtProductos.NewRow();
                                fila["idProducto"] = idProducto;
                                fila["Codigo"] = codigoProducto;
                                fila["Nombre"] = nombre;
                                fila["Cantidad"] = cantidad;
                                fila["Precio"] = precio;
                                fila["SubTotal"] = subtotal;
                                dtProductos.Rows.Add(fila);
                            }

                            // Limpiar campos
                            txtCodigo.Clear();
                            txtCantidad.Clear();
                            txtCodigo.Focus();

                            // Recalcular total
                            CalcularTotal();
                        }
                        else
                        {
                            reader.Close();
                            MessageBox.Show("Producto no encontrado.", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void CalcularTotal()
        {
            decimal total = 0;

            foreach (DataRow row in dtProductos.Rows)
            {
                if (row["SubTotal"] != null && row["SubTotal"] != DBNull.Value)
                {
                    total += Convert.ToDecimal(row["SubTotal"]);
                }
            }

            txtTotal.Text = total.ToString("C2");
        }

        #endregion

        #region Eliminar Producto

        private void EliminarProducto()
        {
            if (dgProductos.CurrentRow == null || dgProductos.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "¿Está seguro que desea eliminar este producto de la lista?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int rowIndex = dgProductos.CurrentRow.Index;
                dtProductos.Rows.RemoveAt(rowIndex);
                CalcularTotal();
            }
        }

        #endregion

        #region Guardar Pedido

        private void GuardarPedido()
        {
            // Validaciones
            if (idClienteSelec == 0)
            {
                MessageBox.Show("Seleccione un cliente.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtProductos.Rows.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto al pedido.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear objeto Pedido
            Pedido pedido = new Pedido();
            pedido.idPedido = 0;
            pedido.Folio = txtFoli.Text;
            pedido.FechaPedido = dtpFecha.Value.Date;
            pedido.idCliente = idClienteSelec;
            pedido.idFormaPago = 1; // Por defecto efectivo, puedes agregar un ComboBox si lo necesitas
            pedido.Total = Convert.ToDecimal(txtTotal.Text.Replace("$", "").Replace(",", ""));

            // Agregar detalles
            foreach (DataRow row in dtProductos.Rows)
            {
                pedido.Detalles.Add(new Pedido.PedidoDetalle
                {
                    idProducto = Convert.ToInt32(row["idProducto"]),
                    Cantidad = Convert.ToInt32(row["Cantidad"]),
                    Precio = Convert.ToDecimal(row["Precio"]),
                    SubTotal = Convert.ToDecimal(row["SubTotal"])
                });
            }

            // Guardar
            string mensaje = pedido.Guardar(pedido);

            if (mensaje.Contains("Correctamente"))
            {
                MessageBox.Show($"{mensaje}\n\nFolio: {txtFoli.Text}", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarPedido();
            }
            else
            {
                MessageBox.Show(mensaje, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Limpiar Pedido

        private void LimpiarPedido()
        {
            // Limpiar DataTable de productos
            dtProductos.Clear();

            // Limpiar campos
            txtCodigo.Clear();
            txtCantidad.Clear();
            txtBuscar.Clear();
            txtTotal.Text = "$0.00";

            // Generar nuevo folio
            GenerarFolio();

            // Resetear fecha a hoy
            dtpFecha.Value = DateTime.Now;

            // Resetear filtro de clientes
            dtClientes.DefaultView.RowFilter = string.Empty;

            // Seleccionar primer cliente (PÚBLICO GENERAL)
            if (dgCliente.Rows.Count > 0)
            {
                dgCliente.Rows[0].Selected = true;
                idClienteSelec = Convert.ToInt32(dgCliente.Rows[0].Cells["idCliente"].Value);
            }

            txtCodigo.Focus();
        }

        #endregion

        #region Eventos de Botones

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarPedido();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Si no hay productos, solo limpiar
            if (dtProductos.Rows.Count == 0)
            {
                LimpiarPedido();
                return;
            }

            DialogResult result = MessageBox.Show(
                "¿Está seguro que desea cancelar el pedido actual?\n\n" +
                "Se limpiarán todos los campos y productos agregados.",
                "Confirmar Cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LimpiarPedido();
                MessageBox.Show("Pedido cancelado.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarProducto();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarProducto();
        }

        private void btnBuscarPro_Click(object sender, EventArgs e)
        {
            AgregarProducto();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            // Abrir formulario de clientes para registrar uno nuevo
            using (frmClientes frmCli = new frmClientes())
            {
                frmCli.ShowDialog();
            }

            // Recargar lista de clientes después de cerrar el formulario
            CargarClientes();
        }

        private void btnBuscar1_Click(object sender, EventArgs e)
        {
            // Abrir formulario de búsqueda de pedidos
            using (BUSQUEDAS.BusquedaPedido busqueda = new BUSQUEDAS.BusquedaPedido())
            {
                if (busqueda.ShowDialog() == DialogResult.OK && busqueda.DgPedidos.CurrentRow != null)
                {
                    // Obtener datos del pedido seleccionado
                    int idPedido = Convert.ToInt32(busqueda.DgPedidos.CurrentRow.Cells["idPedido"].Value);
                    string folio = busqueda.DgPedidos.CurrentRow.Cells["Folio"].Value.ToString();
                    DateTime fecha = Convert.ToDateTime(busqueda.DgPedidos.CurrentRow.Cells["Fecha"].Value);

                    // Cargar los detalles del pedido
                    CargarDetallesPedido(idPedido, folio, fecha);
                }
            }
        }

        /// <summary>
        /// Carga los detalles de un pedido existente para visualización
        /// </summary>
        private void CargarDetallesPedido(int idPedido, string folio, DateTime fecha)
        {
            // Limpiar datos actuales
            dtProductos.Clear();

            // Mostrar folio y fecha
            txtFoli.Text = folio;
            dtpFecha.Value = fecha;

            // Cargar detalles del producto
            string query = @"
          SELECT 
      pd.idProducto,
            p.Codigo,
        p.Nombre,
               pd.Cantidad,
pd.Precio,
  pd.SubTotal
                FROM PedidoDetalle pd
          INNER JOIN catProducto p ON pd.idProducto = p.idProducto
          WHERE pd.idPedido = @idPedido";

            using (SqlConnection con = new SqlConnection(x.conexion()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@idPedido", idPedido);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataRow fila = dtProductos.NewRow();
                            fila["idProducto"] = Convert.ToInt32(reader["idProducto"]);
                            fila["Codigo"] = reader["Codigo"].ToString();
                            fila["Nombre"] = reader["Nombre"].ToString();
                            fila["Cantidad"] = Convert.ToInt32(reader["Cantidad"]);
                            fila["Precio"] = Convert.ToDecimal(reader["Precio"]);
                            fila["SubTotal"] = Convert.ToDecimal(reader["SubTotal"]);
                            dtProductos.Rows.Add(fila);
                        }
                    }
                }
            }

            // Cargar cliente del pedido
            string queryCliente = "SELECT idCliente FROM Pedido WHERE idPedido = @idPedido";
            using (SqlConnection con = new SqlConnection(x.conexion()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryCliente, con))
                {
                    cmd.Parameters.AddWithValue("@idPedido", idPedido);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        int idCliente = Convert.ToInt32(result);
                        // Seleccionar el cliente en el grid
                        foreach (DataGridViewRow row in dgCliente.Rows)
                        {
                            if (Convert.ToInt32(row.Cells["idCliente"].Value) == idCliente)
                            {
                                row.Selected = true;
                                idClienteSelec = idCliente;
                                break;
                            }
                        }
                    }
                }
            }

            // Recalcular total
            CalcularTotal();

            MessageBox.Show($"Pedido cargado: {folio}", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
