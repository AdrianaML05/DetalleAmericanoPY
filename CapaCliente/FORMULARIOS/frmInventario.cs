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
    public partial class frmInventario : Form
    {
        static Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        DataTable dtInventario = new DataTable();

        // Definir el límite para considerar "bajo stock"
        private const int LIMITE_BAJO_STOCK = 10;

        public frmInventario()
        {
            InitializeComponent();
            con.ConnectionString = x.conexion();
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {
            CargarComboProductos();
            ConfigurarDataGrid();
            CargarInventario();

            // Configurar eventos
            btnProducto.SelectedIndexChanged += btnProducto_SelectedIndexChanged;
            ckBago.CheckedChanged += Filtros_CheckedChanged;
            skSin.CheckedChanged += Filtros_CheckedChanged;
            btnBuscar.Click += btnBuscar_Click;
            TXTID.KeyPress += TXTID_KeyPress;
        }

        /// <summary>
        /// Carga el ComboBox de productos con la opción "Todos" al inicio
        /// </summary>
        private void CargarComboProductos()
        {
            DataTable dtProductos = new DataTable();

            // Agregar columnas
            dtProductos.Columns.Add("idProducto", typeof(int));
            dtProductos.Columns.Add("Nombre", typeof(string));

            // Agregar opción "Todos" al inicio
            DataRow rowTodos = dtProductos.NewRow();
            rowTodos["idProducto"] = 0;
            rowTodos["Nombre"] = "-- Todos --";
            dtProductos.Rows.Add(rowTodos);

            // Cargar productos de la base de datos
            string query = "SELECT idProducto, Nombre FROM catProducto ORDER BY Nombre ASC";

            using (SqlConnection conn = new SqlConnection(x.conexion()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataRow row = dtProductos.NewRow();
                            row["idProducto"] = Convert.ToInt32(reader["idProducto"]);
                            row["Nombre"] = reader["Nombre"].ToString();
                            dtProductos.Rows.Add(row);
                        }
                    }
                }
            }

            btnProducto.DataSource = dtProductos;
            btnProducto.DisplayMember = "Nombre";
            btnProducto.ValueMember = "idProducto";
            btnProducto.SelectedIndex = 0; // Seleccionar "Todos" por defecto
        }

        /// <summary>
        /// Configura el DataGridView
        /// </summary>
        private void ConfigurarDataGrid()
        {
            dgInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgInventario.MultiSelect = false;
            dgInventario.ReadOnly = true;
            dgInventario.AllowUserToAddRows = false;
            dgInventario.AllowUserToDeleteRows = false;
            dgInventario.RowHeadersVisible = false;
            dgInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Carga el inventario desde la base de datos
        /// </summary>
        private void CargarInventario()
        {
            dtInventario.Clear();
            dtInventario = new DataTable();

            string query = @"
   SELECT 
    i.idInventario,
     p.idProducto,
                    p.Codigo AS Codigo_Barras,
          p.Nombre AS Producto,
           p.Tipo AS Categoria,
          i.Stock,
          p.PrecioCompra AS Precio_Compra,
     p.PrecioVenta AS Precio_Venta,
        CASE 
       WHEN i.Stock = 0 THEN 'Sin Stock'
       WHEN i.Stock <= @limiteBajoStock THEN 'Bajo Stock'
          ELSE 'Normal'
      END AS Estado
    FROM Inventario i
  INNER JOIN catProducto p ON i.idProducto = p.idProducto
       ORDER BY p.Nombre ASC";

            using (SqlConnection conn = new SqlConnection(x.conexion()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@limiteBajoStock", LIMITE_BAJO_STOCK);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dtInventario);
                    }
                }
            }

            dgInventario.DataSource = dtInventario;

            // Ocultar columnas de ID
            if (dgInventario.Columns["idInventario"] != null)
                dgInventario.Columns["idInventario"].Visible = false;
            if (dgInventario.Columns["idProducto"] != null)
                dgInventario.Columns["idProducto"].Visible = false;

            // Formato de moneda
            if (dgInventario.Columns["Precio_Compra"] != null)
            {
                dgInventario.Columns["Precio_Compra"].DefaultCellStyle.Format = "$#,##0.00";
                dgInventario.Columns["Precio_Compra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgInventario.Columns["Precio_Venta"] != null)
            {
                dgInventario.Columns["Precio_Venta"].DefaultCellStyle.Format = "$#,##0.00";
                dgInventario.Columns["Precio_Venta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Centrar columna Stock
            if (dgInventario.Columns["Stock"] != null)
                dgInventario.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Colorear filas según estado
            ColorearFilas();
        }

        /// <summary>
        /// Colorea las filas según el estado del stock
        /// </summary>
        private void ColorearFilas()
        {
            foreach (DataGridViewRow row in dgInventario.Rows)
            {
                if (row.Cells["Estado"].Value != null)
                {
                    string estado = row.Cells["Estado"].Value.ToString();

                    if (estado == "Sin Stock")
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200); // Rojo claro
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                    else if (estado == "Bajo Stock")
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200); // Amarillo claro
                        row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        /// <summary>
        /// Aplica los filtros seleccionados
        /// </summary>
        private void AplicarFiltros()
        {
            if (dtInventario == null || dtInventario.Rows.Count == 0)
                return;

            string filtro = "";
            List<string> condiciones = new List<string>();

            // Filtro por código de producto
            string codigo = TXTID.Text.Trim();
            if (!string.IsNullOrEmpty(codigo))
            {
                condiciones.Add($"Codigo_Barras LIKE '%{codigo.Replace("'", "''")}%'");
            }

            // Filtro por producto seleccionado en ComboBox
            if (btnProducto.SelectedValue != null)
            {
                int idProducto = Convert.ToInt32(btnProducto.SelectedValue);
                if (idProducto > 0) // Si no es "Todos"
                {
                    condiciones.Add($"idProducto = {idProducto}");
                }
            }

            // Filtro por bajo stock
            if (ckBago.Checked && !skSin.Checked)
            {
                condiciones.Add($"Stock > 0 AND Stock <= {LIMITE_BAJO_STOCK}");
            }
            // Filtro por sin stock
            else if (skSin.Checked && !ckBago.Checked)
            {
                condiciones.Add("Stock = 0");
            }
            // Ambos filtros activos (bajo stock O sin stock)
            else if (ckBago.Checked && skSin.Checked)
            {
                condiciones.Add($"(Stock = 0 OR Stock <= {LIMITE_BAJO_STOCK})");
            }

            // Construir filtro final
            if (condiciones.Count > 0)
            {
                filtro = string.Join(" AND ", condiciones);
            }

            try
            {
                dtInventario.DefaultView.RowFilter = filtro;
                ColorearFilas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar filtros: " + ex.Message, "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Busca por código de producto
        /// </summary>
        private void BuscarPorCodigo()
        {
            AplicarFiltros();

            if (dgInventario.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron productos con ese código.", "Búsqueda",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region Eventos

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarPorCodigo();
        }

        private void TXTID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Buscar al presionar Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                BuscarPorCodigo();
                e.Handled = true;
            }
        }

        private void btnProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void Filtros_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

        /// <summary>
        /// Limpia todos los filtros
        /// </summary>
        private void LimpiarFiltros()
        {
            TXTID.Clear();
            btnProducto.SelectedIndex = 0; // "Todos"
            ckBago.Checked = false;
            skSin.Checked = false;
            dtInventario.DefaultView.RowFilter = string.Empty;
            ColorearFilas();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
