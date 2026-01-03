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
    public partial class frmVenta : FormularioBase  // Cambiar de Form a FormularioBase
    {
        static Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        DataTable dt = new DataTable();
        DataTable dtClientes = new DataTable();
        private int idClineteSelec = 1;
        
        public frmVenta()
        {
   InitializeComponent();
  
            // Configurar adaptabilidad del formulario
     EstablecerTamanoMinimo(1200, 800);
       HabilitarMaximizar();
        
            con.ConnectionString = x.conexion();
  crgarcb();
        CargarClientes();
        }
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
            dgClientes.DataSource = dtClientes;

            // Seleccionar el primer cliente (PÚBLICO GENERAL) por defecto
            if (dgClientes.Rows.Count > 0)
            {
                dgClientes.Rows[0].Selected = true;
                idClineteSelec = Convert.ToInt32(dgClientes.Rows[0].Cells["idCliente"].Value);
            }
        }

        //Configurar el Data Grid de Clientes
        private void ConfDataClientes()
        {
            // Ocultar la columna de ID
            if (dgClientes.Columns["idCliente"] != null)
                dgClientes.Columns["idCliente"].Visible = false;

            // Configurar ancho de columnas
            if (dgClientes.Columns["NombreCompleto"] != null)
            {
                dgClientes.Columns["NombreCompleto"].HeaderText = "Nombre Completo";
                dgClientes.Columns["NombreCompleto"].Width = 200;
            }

            if (dgClientes.Columns["Telefono"] != null)
            {
                dgClientes.Columns["Telefono"].HeaderText = "Teléfono";
                dgClientes.Columns["Telefono"].Width = 100;
            }

            if (dgClientes.Columns["Correo"] != null)
            {
                dgClientes.Columns["Correo"].HeaderText = "Correo";
                dgClientes.Columns["Correo"].Width = 150;
            }

            // Configuración general
            dgClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgClientes.MultiSelect = false;
            dgClientes.ReadOnly = true;
            dgClientes.AllowUserToAddRows = false;
            dgClientes.RowHeadersVisible = false;
        }
        public void crgarcb()
        {
            // 1. Consulta SQL que UNE las columnas de nombre.
            //    Uso "AprllidoMa" para coincidir con tu imagen.
            string consultaSQL = @"
            SELECT idEmpleados, Nombre + ' ' + ApellidoPa + ' ' + ApellidoMa AS NombreCompleto FROM catEmpleados ORDER BY NombreCompleto ASC; ";

            // 2. Prepara el DataTable
            DataTable dt = new DataTable();

            // 3. 'using' asegura que la conexión se cierre sola
            //    (Uso 'x.conexion' como en tu ejemplo anterior)
            using (SqlConnection con = new SqlConnection(x.conexion()))
            {
                // 4. El DataAdapter ejecuta la consulta
                using (SqlDataAdapter da = new SqlDataAdapter(consultaSQL, con))
                {
                    // 5. LLENA la tabla con los resultados (ej. "1", "Juan Pérez López")
                    da.Fill(dt);
                }
            }

            // 6. Asigna los datos al ComboBox (supongamos que se llama 'cmbClientes')
            CBEMPLAEADOS.DataSource = dt;

            // 7. Le dice al ComboBox que MUESTRE la columna "NombreCompleto"
            CBEMPLAEADOS.DisplayMember = "NombreCompleto";

            // 8. Le dice al ComboBox que el VALOR "oculto" es el "idCliente"
            CBEMPLAEADOS.ValueMember = "idEmpleados";
        }


        private void DgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        // Es el boton de Cobrar
        private void button6_Click(object sender, EventArgs e)
        {
            if (DGVENTA.Rows.Count == 0 || (DGVENTA.Rows.Count == 1 && DGVENTA.Rows[0].IsNewRow))
            {
                MessageBox.Show("No hay productos en la venta.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarStock())
                return;

            decimal total = Convert.ToDecimal(txtTotal.Text.Replace("$", "").Replace(",", ""));

            int idCliente = idClineteSelec;
            int idEmpleado = Convert.ToInt32(CBEMPLAEADOS.SelectedValue);

            frmCobrar formCobro = new frmCobrar(total, idCliente, idEmpleado, dt);
            if (formCobro.ShowDialog() == DialogResult.OK)
            {
                LimpiarVenta();
            }

        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
           confdg();
           ConfDataClientes();
            
        }

        private void TXTFILTRO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                e.Handled = true; // Bloquea el carácter
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                AgregarPorCodigoBarra();
                e.Handled = true; // Para evitar que el Enter haga un salto de línea en el TextBox
            }
        }
        
        void confdg()
        {
            //dt.Columns.Add("ID Producto");
            dt.Columns.Add("Codigo de Barra");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Precio Unitario", typeof(decimal));
            dt.Columns.Add("Subtotal", typeof(decimal));
            DGVENTA.DataSource = dt;

            // Formato modena para el precio unitario
            DGVENTA.Columns["Precio Unitario"].DefaultCellStyle.Format = "$#,##0.00";
            DGVENTA.Columns["Precio Unitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Formato de moneda para Subtota
            DGVENTA.Columns["Subtotal"].DefaultCellStyle.Format = "$#,##0.00";
            DGVENTA.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DGVENTA.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
        //void agregar()
        //{
        //    DataRow fila = dt.NewRow();
        //    fila[0] = 1;
        //    fila[1] = "Dulces";
        //    fila[2] = 4;
        //    fila[3] = 20;
        //    fila[4] = 80;
        //    dt.Rows.Add(fila);
        //    DGVENTA.DataSource = dt;
        //}

        private void button1_Click(object sender, EventArgs e)
        {

            //agregar();
            AgregarPorCodigoBarra();    
        }

        void AgregarPorCodigoBarra()
        {
            string CodigoBarra = TXTFILTRO.Text.Trim();
            if (string.IsNullOrEmpty(CodigoBarra))
            {
                MessageBox.Show("Por favor ingrese el codigo de barras.");
                return;
            }

            string query = "select * from catProducto where Codigo = @Codigo";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Codigo", CodigoBarra);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string Codigo = reader["Codigo"].ToString();
                string Nombre = reader["Nombre"].ToString();
                decimal precio = Convert.ToDecimal(reader["PrecioVenta"]);
                int cantidad = string.IsNullOrEmpty(txtCantidad.Text)? 1 : Convert.ToInt32(txtCantidad.Text);
                
                reader.Close();
                con.Close();

                // Buscar si el producto ya existe en el DataTable
                bool productoExiste = false;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Codigo de Barra"].ToString() == Codigo)
                    {
                        // Producto encontrado - sumar la cantidad
                        int cantidadActual = Convert.ToInt32(row["Cantidad"]);
                        int nuevaCantidad = cantidadActual + cantidad;
                        decimal nuevoSubtotal = nuevaCantidad * precio;
                        
                        row["Cantidad"] = nuevaCantidad;
                        row["Subtotal"] = nuevoSubtotal;
    
                        productoExiste = true;
                        break;
                    }
                }
                
                // Si el producto NO existe, agregarlo como nueva fila
                if (!productoExiste)
                {
                    decimal subtotal = cantidad * precio;
                    
                    DataRow fila = dt.NewRow();
                    fila["Codigo de Barra"] = Codigo;
                    fila["Nombre"] = Nombre;
                    fila["Cantidad"] = cantidad;
                    fila["Precio Unitario"] = precio;
                    fila["Subtotal"] = subtotal;
                    dt.Rows.Add(fila);
                }
            
                DGVENTA.DataSource = dt;
                txtCantidad.Clear();
                TXTFILTRO.Clear();

                CalcularTotal();
            }
            else
            {
                reader.Close();
                con.Close();
                MessageBox.Show("Producto no encontrado.");
            }
        }
        void CalcularTotal()
        {
            decimal total = 0;

            // Si prefieres usar el índice de la columna (por ejemplo, columna 3)
            foreach (DataGridViewRow row in DGVENTA.Rows)
            {
                if (!row.IsNewRow && row.Cells["Subtotal"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                }
            }

            txtTotal.Text = total.ToString("C2"); // Formato moneda
            //txtTotal.Text = total.ToString("N2");
        }
        private bool ValidarStock()
        {
            foreach (DataRow row in dt.Rows)
            {
                string codigoBarra = row["Codigo de Barra"].ToString();
                int cantidad = Convert.ToInt32(row["Cantidad"]);

                using (SqlConnection con = new SqlConnection(x.conexion()))
                {
                    con.Open();
                    string query = @"SELECT i.Stock 
                 FROM Inventario i
                 INNER JOIN catProducto p ON i.idProducto = p.idProducto
                 WHERE p.Codigo = @Codigo";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", codigoBarra);

                        object result = cmd.ExecuteScalar();
                        if (result == DBNull.Value)
                        {
                            MessageBox.Show($"No hay stock registrado para {row["Nombre"]}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        int stockActual = Convert.ToInt32(cmd.ExecuteScalar());

                        if (cantidad > stockActual)
                        {
                            MessageBox.Show($"Stock insuficiente para {row["Nombre"]}. Disponible: {stockActual}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarPorCodigoBarra();

            //if (DGVENTA.Rows.Count == 0 || (DGVENTA.Rows.Count == 1 && DGVENTA.Rows[0].IsNewRow))
            //{
            //    MessageBox.Show("No hay productos en la venta.", "Advertencia",
            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (!ValidarStock())
            //    return; 


            //decimal total = Convert.ToDecimal(txtTotal.Text.Replace("$", "").Replace(",", ""));

            //// Usar el cliente seleccionado del DataGridView
            //int idCliente = idClineteSelec;
            //int idEmpleado = Convert.ToInt32(CBEMPLAEADOS.SelectedValue); // CAMBIAR por el empleado actual


            //if (dt == null)
            //{
            //    MessageBox.Show("Error: No se puede Cargar los Detalles de la Venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            
            //frmCobrar formCobro = new frmCobrar(total, idCliente, idEmpleado, dt);
            //if(formCobro.ShowDialog() == DialogResult.OK)
            //{
            //    LimpiarVenta();
            //}
        }

        // button4 - REPETIR: Limpia la venta actual sin afectar la base de datos
        private void button4_Click(object sender, EventArgs e)
        {
            // Si no hay productos, no hay nada que limpiar
            if (DGVENTA.Rows.Count == 0 || (DGVENTA.Rows.Count == 1 && DGVENTA.Rows[0].IsNewRow))
            {
                MessageBox.Show("No hay productos para limpiar.", "Información",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Confirmar con el usuario
            DialogResult result = MessageBox.Show(
            "¿Está seguro que desea limpiar todos los productos?\n\n" +
            "Esta acción no se puede deshacer.",
             "Confirmar Limpieza",
               MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LimpiarVenta();
                MessageBox.Show("Venta limpiada correctamente.", "Éxito",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LimpiarVenta()
        {
           dt.Clear();
           txtTotal.Clear();
           TXTFILTRO.Clear();
           txtCantidad.Clear();
           txtFilCliente.Clear();

                // Reseleccionar PÚBLICO GENERAL
                if (dgClientes.Rows.Count > 0)
                {
                    dgClientes.Rows[0].Selected = true;
                    idClineteSelec = Convert.ToInt32(dgClientes.Rows[0].Cells["idCliente"].Value);
                }

                TXTFILTRO.Focus();
            }

            private void button1_Click_1(object sender, EventArgs e)
            {
                frmClientes x = new frmClientes();
                x.ShowDialog();
            }

            // Filtra mientras escribes ne el TextBox
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                string filtro = txtFilCliente.Text.Trim();

                if (string.IsNullOrEmpty(filtro))
                {
                    // Si el filtro está vacío, mostrar todos
                    dtClientes.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    // Filtrar por nombre, teléfono o correo
                    dtClientes.DefaultView.RowFilter = string.Format(
                        "NombreCompleto LIKE '%{0}%' OR NumeroTel LIKE '%{0}%' OR Correo LIKE '%{0}%'",
                        filtro.Replace("'", "''") // Escapar comillas simples
                    );
                }

                // Seleccionar la primera fila si hay resultados
                if (dgClientes.Rows.Count > 0)
                {
                    dgClientes.Rows[0].Selected = true;
                }
            }

            private void dgClientes_SelectionChanged(object sender, EventArgs e)
            {
                if (dgClientes.CurrentRow != null && dgClientes.CurrentRow.Cells["idCliente"].Value != null)
                {
                    idClineteSelec = Convert.ToInt32(dgClientes.CurrentRow.Cells["idCliente"].Value);
                }
            }

            private void dgClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0)
                {
                    TXTFILTRO.Focus(); // Enfocar en el textbox de código de barras
                }
            }

        private void txtFilCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Si hay solo un resultado, seleccionarlo automáticamente
                if (dgClientes.Rows.Count == 1)
                {
                    dgClientes.Rows[0].Selected = true;
                    TXTFILTRO.Focus(); // Ir al código de barras
                }
                e.Handled = true;
            }
        }

        private void CBEMPLAEADOS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           frmConsultaVenta x = new frmConsultaVenta();
            if (x.ShowDialog() == DialogResult.OK)
            {
                LimpiarVenta();
            }
        }

        // Limpia la venta actual sin afectar la base de datos
        private void btnRepetir_Click(object sender, EventArgs e)
        {
         // Si no hay productos, no hay nada que limpiar
        if (DGVENTA.Rows.Count == 0 || (DGVENTA.Rows.Count == 1 && DGVENTA.Rows[0].IsNewRow))
        {
          MessageBox.Show("No hay productos para limpiar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

            // Confirmar con el usuario
            DialogResult result = MessageBox.Show(
            "¿Está seguro que desea limpiar todos los productos?\n\n" + "Esta acción no se puede deshacer.",
           "Confirmar Limpieza",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LimpiarVenta();
                MessageBox.Show("Venta limpiada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
