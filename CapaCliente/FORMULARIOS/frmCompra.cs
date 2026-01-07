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
    public partial class frmCompra : Form
    {
        static Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        DataTable dtProductos = new DataTable(); // DataTable para productos a comprar
        DataTable dtProveedores = new DataTable(); // DataTable para proveedores
        private int idProveedorSelec = 0;

        public frmCompra()
        {
            InitializeComponent();
            con.ConnectionString = x.conexion();
        }

        private void frmCompra_Load(object sender, EventArgs e)
        {
            // Generar folio automático (empieza con C)
            GenerarFolio();

            // Configurar fecha actual
            dtpFecha.Value = DateTime.Now;

            // Configurar DataGrids
            ConfigurarDataGridProductos();
            ConfigurarDataGridProveedores();

            // Cargar proveedores
            CargarProveedores();

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

        

        private void GenerarFolio()
        {
            // Formato simplificado: C-YYYYMMDD (C de Compra)
            txtFoli.Text = $"C-{DateTime.Now:yyyyMMdd}";
        }

        
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

        private void ConfigurarDataGridProveedores()
        {
            // Configuración general
            dgProveedor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgProveedor.MultiSelect = false;
            dgProveedor.ReadOnly = true;
            dgProveedor.AllowUserToAddRows = false;
            dgProveedor.RowHeadersVisible = false;
            dgProveedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Evento de selección
            dgProveedor.SelectionChanged += dgProveedor_SelectionChanged;
        }


        private void CargarProveedores()
        {
            string query = @"
            select idProveedores, Nombre, numTelefono from catProveedores 
            order by Nombre asc";

            using (SqlConnection con = new SqlConnection(x.conexion()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    dtProveedores = new DataTable();
                    da.Fill(dtProveedores);
                }
            }

            dgProveedor.DataSource = dtProveedores;

            // Ocultar columna idProveedores
            if (dgProveedor.Columns["idProveedores"] != null)
                dgProveedor.Columns["idProveedores"].Visible = false;

            // Renombrar columna numTelefono a Teléfono
            if (dgProveedor.Columns["numTelefono"] != null)
                dgProveedor.Columns["numTelefono"].HeaderText = "Teléfono";

            // Seleccionar el primer proveedor si existe
            if (dgProveedor.Rows.Count > 0)
            {
                dgProveedor.Rows[0].Selected = true;
                idProveedorSelec = Convert.ToInt32(dgProveedor.Rows[0].Cells["idProveedores"].Value);
            }
        }

        private void dgProveedor_SelectionChanged(object sender, EventArgs e)
        {
            if (dgProveedor.CurrentRow != null && dgProveedor.CurrentRow.Cells["idProveedores"].Value != null)
            {
                idProveedorSelec = Convert.ToInt32(dgProveedor.CurrentRow.Cells["idProveedores"].Value);
            }
        }

        // Filtrar proveedores mientras escribe
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(filtro))
            {
                dtProveedores.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                dtProveedores.DefaultView.RowFilter = string.Format("Nombre LIKE '%{0}%' OR numTelefono LIKE '%{0}%'",
                filtro.Replace("'", "''")
                );
            }

            // Seleccionar la primera fila si hay resultados
            if (dgProveedor.Rows.Count > 0)
            {
                dgProveedor.Rows[0].Selected = true;
                idProveedorSelec = Convert.ToInt32(dgProveedor.Rows[0].Cells["idProveedores"].Value);
            }
        }

        

        

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
            string query = "SELECT idProducto, Codigo, Nombre, PrecioCompra FROM catProducto WHERE Codigo = @Codigo";

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
                            decimal precio = Convert.ToDecimal(reader["PrecioCompra"]);

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
                            // PRODUCTO NO ENCONTRADO - Ofrecer registrarlo
                            reader.Close();
                            OfrecerRegistroProducto(codigo, cantidad);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Ofrece al usuario registrar un producto nuevo cuando no existe
        /// </summary>
        private void OfrecerRegistroProducto(string codigo, int cantidadSolicitada)
        {
            DialogResult resultado = MessageBox.Show(
                $"El producto con código '{codigo}' no está registrado.\n\n" + "¿Desea registrarlo ahora?", "Producto no encontrado",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Abrir formulario de productos con el código prellenado
                using (frmProductos frmProd = new frmProductos())
                {
                    // Pasar el código al formulario
                    frmProd.CodigoInicial = codigo;
                    frmProd.ModoRegistroRapido = true;

                    if (frmProd.ShowDialog() == DialogResult.OK)
                    {
                        // Producto registrado exitosamente, intentar agregarlo
                        txtCodigo.Text = codigo;
                        txtCantidad.Text = cantidadSolicitada.ToString();
                        AgregarProducto();
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

        

        

        private void EliminarProducto()
        {
            if (dgProductos.CurrentRow == null || dgProductos.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este producto de la lista?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int rowIndex = dgProductos.CurrentRow.Index;
                dtProductos.Rows.RemoveAt(rowIndex);
                CalcularTotal();
            }
        }

       

        private void GuardarCompra()
        {
            // Validaciones
            if (idProveedorSelec == 0)
            {
                MessageBox.Show("Seleccione un proveedor.", "Advertencia",
           MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtProductos.Rows.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto a la compra.", "Advertencia",
           MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear objeto Compra
            Compras compra = new Compras();
            compra.idCompra = 0;
            compra.Folio = txtFoli.Text; // Agregar el folio
            compra.Fecha = dtpFecha.Value.Date;
            compra.idProveedores = idProveedorSelec;
            compra.Total = Convert.ToDecimal(txtTotal.Text.Replace("$", "").Replace(",", ""));

            // Agregar detalles
            foreach (DataRow row in dtProductos.Rows)
            {
                compra.Detalles.Add(new Compras.CompraDetalle
                {
                    idProducto = Convert.ToInt32(row["idProducto"]),
                    Cantidad = Convert.ToInt32(row["Cantidad"]),
                    Precio = Convert.ToDecimal(row["Precio"]),
                    SubTotal = Convert.ToDecimal(row["SubTotal"])
                });
            }

            // Guardar
            string mensaje = compra.Guardar(compra);

            if (mensaje.Contains("Correctamente"))
            {
                MessageBox.Show($"{mensaje}\n\nFolio: {txtFoli.Text}", "Éxito",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCompra();
            }
            else
            {
                MessageBox.Show(mensaje, "Error",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        

        private void LimpiarCompra()
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

            // Resetear filtro de proveedores
            dtProveedores.DefaultView.RowFilter = string.Empty;

            // Seleccionar primer proveedor
            if (dgProveedor.Rows.Count > 0)
            {
                dgProveedor.Rows[0].Selected = true;
                idProveedorSelec = Convert.ToInt32(dgProveedor.Rows[0].Cells["idProveedores"].Value);
            }

            txtCodigo.Focus();
        }

        private void CancelarCompra()
        {
            // Si no hay productos, solo limpiar
            if (dtProductos.Rows.Count == 0)
            {
                LimpiarCompra();
                return;
            }

            DialogResult result = MessageBox.Show(
                   "¿Está seguro que desea cancelar la compra actual?\n\n" +
                     "Se limpiarán todos los campos y productos agregados.",
                "Confirmar Cancelación",
                   MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LimpiarCompra();
                MessageBox.Show("Compra cancelada.", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        

        

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void gUARDARToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCompra();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CancelarCompra();
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
            // Buscar producto por código
            AgregarProducto();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            // Abrir formulario de proveedores para registrar uno nuevo
            using (frmProveedores frmProv = new frmProveedores())
            {
                frmProv.ShowDialog();
            }

            // Recargar lista de proveedores después de cerrar el formulario
            CargarProveedores();
        }

        

        private void btnBuscar1_Click(object sender, EventArgs e)
        {
            // Abrir formulario de búsqueda de compras
            using (BUSQUEDAS.BusquedaCompra busqueda = new BUSQUEDAS.BusquedaCompra())
            {
                if (busqueda.ShowDialog() == DialogResult.OK && busqueda.DgCompras.CurrentRow != null)
                {
                    // Obtener datos de la compra seleccionada
                    int idCompra = Convert.ToInt32(busqueda.DgCompras.CurrentRow.Cells["idCompra"].Value);
                    string folio = busqueda.DgCompras.CurrentRow.Cells["Folio"].Value.ToString();
                    DateTime fecha = Convert.ToDateTime(busqueda.DgCompras.CurrentRow.Cells["Fecha"].Value);

                    // Cargar los detalles de la compra
                    CargarDetallesCompra(idCompra, folio, fecha);
                }
            }
        }

        /// <summary>
        /// Carga los detalles de una compra existente para visualización
        /// </summary>
        private void CargarDetallesCompra(int idCompra, string folio, DateTime fecha)
        {
            // Limpiar datos actuales
            dtProductos.Clear();

            // Mostrar folio y fecha
            txtFoli.Text = folio;
            dtpFecha.Value = fecha;

            // Cargar detalles del producto
            string query = @"select cd.idProducto, p.Codigo, p.Nombre, cd.Cantidad, cd.Precio, cd.SubTotal from CompraDetalle cd inner join catProducto p ON cd.idProducto = p.idProducto where cd.idCompra = @idCompra";

            using (SqlConnection con = new SqlConnection(x.conexion()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@idCompra", idCompra);
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

            // Cargar proveedor de la compra
            string queryProveedor = "select idProveedores from Compra where idCompra = @idCompra";
            using (SqlConnection con = new SqlConnection(x.conexion()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryProveedor, con))
                {
                    cmd.Parameters.AddWithValue("@idCompra", idCompra);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        int idProveedor = Convert.ToInt32(result);
                        // Seleccionar el proveedor en el grid
                        foreach (DataGridViewRow row in dgProveedor.Rows)
                        {
                            if (Convert.ToInt32(row.Cells["idProveedores"].Value) == idProveedor)
                            {
                                row.Selected = true;
                                idProveedorSelec = idProveedor;
                                break;
                            }
                        }
                    }
                }
            }

            // Recalcular total
            CalcularTotal();

            MessageBox.Show($"Compra cargada: {folio}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
