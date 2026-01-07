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
    public partial class frmEnvios : Form
    {
        static Conexion x = new Conexion();
  SqlConnection con = new SqlConnection();
   DataTable dtDetalles = new DataTable();
        DataTable dtPedidos = new DataTable();
        private int idEnvioActual = 0;

 public frmEnvios()
        {
            InitializeComponent();
     con.ConnectionString = x.conexion();
        }

        private void frmEnvios_Load(object sender, EventArgs e)
{
            // Generar número de envío automático (empieza con E)
            GenerarNumeroEnvio();

     // Configurar fecha actual
    dtpFecha.Value = DateTime.Now;

   // Configurar DataGrid
  ConfigurarDataGrid();

      // Cargar ComboBoxes
  CargarDomicilios();
      CargarPaqueterias();
   CargarPedidos();

            // Configurar txtTotal y txtNumEnvio como solo lectura
       txtTotal.ReadOnly = true;
     txtTotal.Text = "$0.00";
  txtNumEnvio.ReadOnly = true;

    // Configurar campos de pedido como solo lectura
     txtCliente.ReadOnly = true;
   txtTotalPedido.ReadOnly = true;
    dtpFechaPedido.Enabled = false;

            // Seleccionar estatus por defecto
 rbPendiente.Checked = true;

      // Evento cuando cambia el pedido seleccionado
     cbFolioPedido.SelectedIndexChanged += cbFolioPedido_SelectedIndexChanged;
  }

        #region Número de Envío Automático

    private void GenerarNumeroEnvio()
     {
            // Formato: E-YYYYMMDD (E de Envío)
    txtNumEnvio.Text = $"E-{DateTime.Now:yyyyMMdd}";
    }

        #endregion

     #region Configuración de DataGrid

  private void ConfigurarDataGrid()
        {
   // Crear columnas para el DataTable de detalles
       dtDetalles.Columns.Add("idPedidoDetalle", typeof(int));
     dtDetalles.Columns.Add("FolioPedido");
 dtDetalles.Columns.Add("Cliente");
       dtDetalles.Columns.Add("CantPaquetes", typeof(int));
   dtDetalles.Columns.Add("TotalPedido", typeof(decimal));

   dgEnvio.DataSource = dtDetalles;

     // Ocultar columna idPedidoDetalle
 if (dgEnvio.Columns["idPedidoDetalle"] != null)
dgEnvio.Columns["idPedidoDetalle"].Visible = false;

// Renombrar columnas
if (dgEnvio.Columns["FolioPedido"] != null)
      dgEnvio.Columns["FolioPedido"].HeaderText = "Folio Pedido";

       if (dgEnvio.Columns["CantPaquetes"] != null)
 {
       dgEnvio.Columns["CantPaquetes"].HeaderText = "Cant. Paquetes";
   dgEnvio.Columns["CantPaquetes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      }

     if (dgEnvio.Columns["TotalPedido"] != null)
      {
  dgEnvio.Columns["TotalPedido"].HeaderText = "Total Pedido";
dgEnvio.Columns["TotalPedido"].DefaultCellStyle.Format = "$#,##0.00";
   dgEnvio.Columns["TotalPedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
     }

        // Configuración general
   dgEnvio.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
 dgEnvio.MultiSelect = false;
      dgEnvio.ReadOnly = true;
       dgEnvio.AllowUserToAddRows = false;
         dgEnvio.RowHeadersVisible = false;
     dgEnvio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

  #endregion

        #region Cargar ComboBoxes

  private void CargarDomicilios()
  {
    Envio envio = new Envio();
   DataTable dt = envio.ObtenerDomicilios();

    cbDomicilio.DataSource = dt;
    cbDomicilio.DisplayMember = "nombreDomicilio";
   cbDomicilio.ValueMember = "idDomicilio";

    if (dt.Rows.Count > 0)
       cbDomicilio.SelectedIndex = 0;
        }

     private void CargarPaqueterias()
   {
Envio envio = new Envio();
    DataTable dt = envio.ObtenerPaqueterias();

    cbPaqueteria.DataSource = dt;
    cbPaqueteria.DisplayMember = "Nombre";
   cbPaqueteria.ValueMember = "idPaqueteria";

    if (dt.Rows.Count > 0)
       cbPaqueteria.SelectedIndex = 0;
        }

   private void CargarPedidos()
        {
         Envio envio = new Envio();
            dtPedidos = envio.ObtenerPedidosActivos();

  cbFolioPedido.DataSource = dtPedidos;
   cbFolioPedido.DisplayMember = "Folio";
  cbFolioPedido.ValueMember = "idPedido";

    if (dtPedidos.Rows.Count > 0)
      {
 cbFolioPedido.SelectedIndex = 0;
    MostrarDatosPedido();
      }
   }

 private void cbFolioPedido_SelectedIndexChanged(object sender, EventArgs e)
   {
       MostrarDatosPedido();
        }

      private void MostrarDatosPedido()
        {
   if (cbFolioPedido.SelectedIndex >= 0 && dtPedidos.Rows.Count > 0)
        {
            DataRowView row = cbFolioPedido.SelectedItem as DataRowView;
    if (row != null)
   {
      txtCliente.Text = row["Cliente"].ToString();
     txtTotalPedido.Text = Convert.ToDecimal(row["Total"]).ToString("C2");
       dtpFechaPedido.Value = Convert.ToDateTime(row["FechaPedido"]);
    }
    }
    }

        #endregion

        #region Agregar Pedido al Envío

        private void btnAgregar_Click(object sender, EventArgs e)
   {
    AgregarPedido();
        }

     private void AgregarPedido()
 {
   if (cbFolioPedido.SelectedValue == null)
     {
          MessageBox.Show("Seleccione un pedido.", "Advertencia",
   MessageBoxButtons.OK, MessageBoxIcon.Warning);
       return;
   }

     int cantidad = 1;
 if (!string.IsNullOrEmpty(txtCantidad.Text))
    {
      if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
 {
      MessageBox.Show("La cantidad de paquetes debe ser un número mayor a 0.", "Advertencia",
    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
   }
     }

    int idPedido = Convert.ToInt32(cbFolioPedido.SelectedValue);
    DataRowView selectedRow = cbFolioPedido.SelectedItem as DataRowView;

 // Verificar si el pedido ya está agregado
       foreach (DataRow row in dtDetalles.Rows)
         {
     if (Convert.ToInt32(row["idPedidoDetalle"]) == idPedido)
     {
  MessageBox.Show("Este pedido ya está agregado al envío.", "Advertencia",
  MessageBoxButtons.OK, MessageBoxIcon.Warning);
    return;
        }
     }

  // Agregar el pedido al detalle
 DataRow fila = dtDetalles.NewRow();
      fila["idPedidoDetalle"] = idPedido;
     fila["FolioPedido"] = selectedRow["Folio"].ToString();
    fila["Cliente"] = selectedRow["Cliente"].ToString();
     fila["CantPaquetes"] = cantidad;
     fila["TotalPedido"] = Convert.ToDecimal(selectedRow["Total"]);
     dtDetalles.Rows.Add(fila);

  // Limpiar cantidad
   txtCantidad.Clear();

            // Recalcular total
   CalcularTotal();
  }

   private void CalcularTotal()
 {
   decimal total = 0;

  foreach (DataRow row in dtDetalles.Rows)
 {
      if (row["TotalPedido"] != null && row["TotalPedido"] != DBNull.Value)
     {
    total += Convert.ToDecimal(row["TotalPedido"]);
       }
     }

      txtTotal.Text = total.ToString("C2");
        }

  #endregion

        #region Eliminar Pedido del Envío

      private void btnEliminar_Click(object sender, EventArgs e)
        {
    EliminarPedido();
     }

   private void EliminarPedido()
    {
if (dgEnvio.CurrentRow == null || dgEnvio.CurrentRow.IsNewRow)
 {
  MessageBox.Show("Seleccione un pedido para eliminar.", "Advertencia",
      MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
}

     DialogResult result = MessageBox.Show(
     "¿Está seguro que desea eliminar este pedido del envío?",
 "Confirmar Eliminación",
  MessageBoxButtons.YesNo,
 MessageBoxIcon.Question);

   if (result == DialogResult.Yes)
  {
int rowIndex = dgEnvio.CurrentRow.Index;
           dtDetalles.Rows.RemoveAt(rowIndex);
   CalcularTotal();
     }
     }

      #endregion

        #region Guardar Envío

        private void btnGuardar_Click(object sender, EventArgs e)
        {
GuardarEnvio();
        }

        private void GuardarEnvio()
     {
     // Validaciones
if (cbDomicilio.SelectedValue == null)
     {
      MessageBox.Show("Seleccione un domicilio.", "Advertencia",
     MessageBoxButtons.OK, MessageBoxIcon.Warning);
     return;
    }

     if (cbPaqueteria.SelectedValue == null)
 {
       MessageBox.Show("Seleccione una paquetería.", "Advertencia",
  MessageBoxButtons.OK, MessageBoxIcon.Warning);
       return;
       }

   if (dtDetalles.Rows.Count == 0)
   {
 MessageBox.Show("Agregue al menos un pedido al envío.", "Advertencia",
  MessageBoxButtons.OK, MessageBoxIcon.Warning);
    return;
 }

     // Obtener estatus seleccionado
  int estatus = ObtenerEstatusSeleccionado();

     // Crear objeto Envio
 Envio envio = new Envio();
    envio.idEnvio = idEnvioActual;
envio.idDomicilio = Convert.ToInt32(cbDomicilio.SelectedValue);
         envio.idPaqueteria = Convert.ToInt32(cbPaqueteria.SelectedValue);
            envio.Estatus = estatus;
 envio.FechaEnvio = dtpFecha.Value.Date;

   // Agregar detalles
    foreach (DataRow row in dtDetalles.Rows)
{
envio.Detalles.Add(new Envio.EnvioDetalle
  {
        idPedidoDetalle = Convert.ToInt32(row["idPedidoDetalle"]),
CantPaquetes = Convert.ToInt32(row["CantPaquetes"]),
    Total = Convert.ToDecimal(row["TotalPedido"])
        });
            }

   // Guardar
string mensaje = envio.Guardar(envio);

  if (mensaje.Contains("Correctamente"))
            {
 MessageBox.Show($"{mensaje}\n\nNúmero de Envío: {txtNumEnvio.Text}", "Éxito",
   MessageBoxButtons.OK, MessageBoxIcon.Information);
  LimpiarEnvio();
        }
       else
     {
     MessageBox.Show(mensaje, "Error",
     MessageBoxButtons.OK, MessageBoxIcon.Error);
   }
        }

        private int ObtenerEstatusSeleccionado()
        {
     if (rbPendiente.Checked) return 1;
            if (rbTransito.Checked) return 2;
    if (rbEntrega.Checked) return 3;
 if (rbCancelado.Checked) return 4;
            return 1; // Por defecto Pendiente
}

    private void EstablecerEstatus(int estatus)
        {
      rbPendiente.Checked = estatus == 1;
  rbTransito.Checked = estatus == 2;
     rbEntrega.Checked = estatus == 3;
 rbCancelado.Checked = estatus == 4;
        }

        #endregion

        #region Limpiar Envío

  private void btnCancelar_Click(object sender, EventArgs e)
        {
  // Si no hay detalles, solo limpiar
 if (dtDetalles.Rows.Count == 0)
            {
LimpiarEnvio();
 return;
}

  DialogResult result = MessageBox.Show(
  "¿Está seguro que desea cancelar el envío actual?\n\n" +
   "Se limpiarán todos los campos y pedidos agregados.",
    "Confirmar Cancelación",
     MessageBoxButtons.YesNo,
     MessageBoxIcon.Question);

  if (result == DialogResult.Yes)
          {
LimpiarEnvio();
       MessageBox.Show("Envío cancelado.", "Información",
     MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LimpiarEnvio()
 {
  // Limpiar DataTable de detalles
  dtDetalles.Clear();

   // Limpiar campos
    txtCantidad.Clear();
            txtTotal.Text = "$0.00";
  idEnvioActual = 0;

            // Generar nuevo número de envío
     GenerarNumeroEnvio();

            // Resetear fecha a hoy
     dtpFecha.Value = DateTime.Now;

    // Resetear estatus a Pendiente
 rbPendiente.Checked = true;

  // Resetear ComboBoxes
       if (cbDomicilio.Items.Count > 0)
           cbDomicilio.SelectedIndex = 0;

       if (cbPaqueteria.Items.Count > 0)
 cbPaqueteria.SelectedIndex = 0;

          if (cbFolioPedido.Items.Count > 0)
{
cbFolioPedido.SelectedIndex = 0;
   MostrarDatosPedido();
            }
   }

        #endregion

        #region Buscar Envío

 private void button3_Click(object sender, EventArgs e)
        {
     // Abrir formulario de búsqueda de envíos
  using (BUSQUEDAS.BusquedaEnvios busqueda = new BUSQUEDAS.BusquedaEnvios())
  {
   if (busqueda.ShowDialog() == DialogResult.OK && busqueda.DgEnvios.CurrentRow != null)
{
// Obtener datos del envío seleccionado
         idEnvioActual = Convert.ToInt32(busqueda.DgEnvios.CurrentRow.Cells["idEnvio"].Value);
     int estatusId = Convert.ToInt32(busqueda.DgEnvios.CurrentRow.Cells["EstatusId"].Value);
    DateTime fecha = Convert.ToDateTime(busqueda.DgEnvios.CurrentRow.Cells["Fecha"].Value);

     // Cargar los detalles del envío
   CargarDetallesEnvio(idEnvioActual, fecha, estatusId);
         }
        }
        }

    private void CargarDetallesEnvio(int idEnvio, DateTime fecha, int estatus)
        {
      // Limpiar datos actuales
     dtDetalles.Clear();

     // Mostrar datos generales
    txtNumEnvio.Text = $"E-{idEnvio.ToString().PadLeft(8, '0')}";
     dtpFecha.Value = fecha;
            EstablecerEstatus(estatus);

   // Cargar detalles del envío
string query = @"
          SELECT 
  ed.idPedidoDetalle,
   p.Folio AS FolioPedido,
     c.Nombre + ' ' + c.ApellidoPa AS Cliente,
        ed.CantPaquetes,
      ed.Total AS TotalPedido
     FROM EnvioDetalle ed
   INNER JOIN Pedido p ON ed.idPedidoDetalle = p.idPedido
          INNER JOIN catClientes c ON p.idCliente = c.idCliente
           WHERE ed.idEnvio = @idEnvio";

            using (SqlConnection con = new SqlConnection(x.conexion()))
    {
con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
 {
       cmd.Parameters.AddWithValue("@idEnvio", idEnvio);
 using (SqlDataReader reader = cmd.ExecuteReader())
         {
      while (reader.Read())
       {
      DataRow fila = dtDetalles.NewRow();
     fila["idPedidoDetalle"] = Convert.ToInt32(reader["idPedidoDetalle"]);
  fila["FolioPedido"] = reader["FolioPedido"].ToString();
           fila["Cliente"] = reader["Cliente"].ToString();
       fila["CantPaquetes"] = Convert.ToInt32(reader["CantPaquetes"]);
          fila["TotalPedido"] = Convert.ToDecimal(reader["TotalPedido"]);
          dtDetalles.Rows.Add(fila);
     }
    }
       }
            }

         // Cargar domicilio y paquetería del envío
            string queryEnvio = "SELECT idDomicilio, idPaqueteria FROM Envio WHERE idEnvio = @idEnvio";
            using (SqlConnection con = new SqlConnection(x.conexion()))
            {
   con.Open();
       using (SqlCommand cmd = new SqlCommand(queryEnvio, con))
      {
      cmd.Parameters.AddWithValue("@idEnvio", idEnvio);
            using (SqlDataReader reader = cmd.ExecuteReader())
      {
  if (reader.Read())
    {
  if (reader["idDomicilio"] != DBNull.Value)
   cbDomicilio.SelectedValue = Convert.ToInt32(reader["idDomicilio"]);

     if (reader["idPaqueteria"] != DBNull.Value)
             cbPaqueteria.SelectedValue = Convert.ToInt32(reader["idPaqueteria"]);
  }
      }
  }
}

      // Recalcular total
     CalcularTotal();

 MessageBox.Show($"Envío cargado: E-{idEnvio.ToString().PadLeft(8, '0')}", "Información",
   MessageBoxButtons.OK, MessageBoxIcon.Information);
      }

  #endregion

  #region Cancelar Envío con RadioButton

  private void rbCancelado_CheckedChanged(object sender, EventArgs e)
      {
// Solo actuar si el envío ya existe y se seleccionó Cancelado
 if (rbCancelado.Checked && idEnvioActual > 0)
   {
                DialogResult result = MessageBox.Show(
       "¿Está seguro que desea CANCELAR este envío?\n\n" +
   "Esta acción marcará el envío como cancelado en la base de datos.",
        "Confirmar Cancelación de Envío",
       MessageBoxButtons.YesNo,
    MessageBoxIcon.Warning);

    if (result == DialogResult.Yes)
        {
          Envio envio = new Envio();
  string mensaje = envio.Cancelar(idEnvioActual);

   if (mensaje.Contains("Correctamente"))
   {
  MessageBox.Show(mensaje, "Éxito",
          MessageBoxButtons.OK, MessageBoxIcon.Information);
      // El envío ya está cancelado, deshabilitar edición
     }
  else
   {
    MessageBox.Show(mensaje, "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
    // Volver al estatus anterior
     rbPendiente.Checked = true;
        }
   }
     else
    {
  // Volver al estatus anterior
          rbPendiente.Checked = true;
        }
   }
        }

        #endregion

        #region Eventos de Botones

   private void button9_Click(object sender, EventArgs e)
      {
  this.Close();
    }

        // Eventos vacíos que ya estaban
  private void textBox7_TextChanged(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }
 private void label3_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
  private void label2_Click(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
   private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
    private void label1_Click(object sender, EventArgs e) { }
    private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void textBox6_TextChanged(object sender, EventArgs e) { }

        #endregion
    }
}
