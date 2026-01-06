using CapaNegocio.CLASES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaCliente.FORMULARIOS
{
    public partial class frmCobrar : FormularioBase
    {
        static Conexion x = new Conexion();
      private decimal totalVenta;
        private int idCliente;
        private int idEmpleado;
private DataTable detalleVneta;
      private int formaPago = 3; // Por defecto Efectivo (según la tabla: 1=Transferencia, 2=Tarjeta, 3=Efectivo, 4=Mix)
 private string folioVenta; // Folio de la venta

        // Referencias a los formularios hijos
        private frmTransferencia formTransferencia;
        private frmPagoTarjeta formTarjeta;
        private frmMix formMix;

        // Constructor que recibe los 4 valores de la venta
        public frmCobrar(decimal toatl, int cliente, int empleado, DataTable detalle)
        {
      InitializeComponent();
    totalVenta = toatl;
            idCliente = cliente;
         idEmpleado = empleado;
            detalleVneta = detalle.Copy();
            folioVenta = GenerarFolio(); // Generar el folio al crear el formulario
    }

        public frmCobrar()
  {
            InitializeComponent();
            EstablecerTamanoMinimo(400, 300);
    DeshabilitarRedimensionar();  // No permitir redimensionar
        }

        private void frmCobrar_Load(object sender, EventArgs e)
        {
       txtTotal.Text = totalVenta.ToString("C2");
            txtTotal.ReadOnly = true;
            txtPago.Focus();

        // Configurar txtPago para solo números
 txtPago.KeyPress += txtPago_KeyPress;
   txtPago.MaxLength = 10;

            // Configurar txtCambio como solo lectura
          txtCambio.ReadOnly = true;

            // Marcar visualmente el botón de Efectivo como seleccionado por defecto
            MarcarBotonSeleccionado(btnEfectivo);

     // Mostrar campos de pago y cambio (Efectivo por defecto)
            MostrarCamposPagoCambio(true);
        }

     // Validación para solo permitir números en txtPago
        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
        {
      e.Handled = true;
            }

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && txtPago.Text.Contains("."))
   {
            e.Handled = true;
   }
        }

        private void txtPago_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPago.Text) && decimal.TryParse(txtPago.Text, out decimal pago))
   {
             decimal cambio = pago - totalVenta;
                txtCambio.Text = cambio >= 0 ? cambio.ToString("C2") : "$0.00";
            }
    else
   {
     txtCambio.Text = "$0.00";
      }
        }

        private void btnTarjeta_Click(object sender, EventArgs e)
        {
 formaPago = 2; // Tarjeta
MarcarBotonSeleccionado(btnTarjeta);
      MostrarCamposPagoCambio(false); // Ocultar todos los campos
            CargarFormularioEnPanel(new frmPagoTarjeta(totalVenta));
        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
     formaPago = 3; // Efectivo
            MarcarBotonSeleccionado(btnEfectivo);
   MostrarCamposPagoCambio(true); // Mostrar todos los campos
   LimpiarPanel2(); // Efectivo solo usa pago y cambio
        }

        private void btnMix_Click(object sender, EventArgs e)
        {
            formaPago = 4; // Mix
    MarcarBotonSeleccionado(btnMix);
      MostrarCamposPagoCambio(false); // Ocultar todos los campos (frmMix tiene los suyos)
        CargarFormularioEnPanel(new frmMix(totalVenta));
        }

        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            formaPago = 1; // Transferencia
MarcarBotonSeleccionado(btnTransferencia);
MostrarCamposPagoCambio(false); // Ocultar todos los campos
      CargarFormularioEnPanel(new frmTransferencia(totalVenta, folioVenta));
        }

        /// <summary>
        /// Muestra u oculta los campos de TOTAL, PAGO y CAMBIO
        /// </summary>
private void MostrarCamposPagoCambio(bool mostrar)
  {
     // Mostrar u ocultar los labels y textboxes de total, pago y cambio
            label1.Visible = mostrar; // Label "TOTAL:"
            txtTotal.Visible = mostrar;
            label2.Visible = mostrar; // Label "PAGO:"
            txtPago.Visible = mostrar;
     label3.Visible = mostrar; // Label "CAMBIO:"
          txtCambio.Visible = mostrar;

   // Limpiar los campos si se ocultan
            if (!mostrar)
     {
       txtPago.Clear();
        txtCambio.Text = "$0.00";
       }
        }

        /// <summary>
  /// Carga un formulario dentro del panel2
        /// </summary>
        private void CargarFormularioEnPanel(Form formulario)
    {
   // Limpiar referencias anteriores
     formTransferencia = null;
    formTarjeta = null;
            formMix = null;

 // Remover formularios hijos anteriores
var formulariosHijos = panel2.Controls.OfType<Form>().ToList();
     foreach (var form in formulariosHijos)
            {
        panel2.Controls.Remove(form);
                form.Dispose();
            }

 // Configurar el formulario hijo
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Bottom;
   formulario.BackColor = panel2.BackColor;

          // Guardar referencia al formulario
       if (formulario is frmTransferencia)
       formTransferencia = (frmTransferencia)formulario;
       else if (formulario is frmPagoTarjeta)
      formTarjeta = (frmPagoTarjeta)formulario;
      else if (formulario is frmMix)
        formMix = (frmMix)formulario;

            // Agregar al panel y mostrar
    panel2.Controls.Add(formulario);
          formulario.Show();
     }

     /// <summary>
        /// Limpia el panel2 (para efectivo que no necesita formulario adicional)
        /// </summary>
        private void LimpiarPanel2()
    {
            // Limpiar referencias
       formTransferencia = null;
  formTarjeta = null;
 formMix = null;

            // Remover solo los formularios hijos, mantener los controles originales
     var formulariosHijos = panel2.Controls.OfType<Form>().ToList();
foreach (var form in formulariosHijos)
            {
      panel2.Controls.Remove(form);
        form.Dispose();
    }
     }

     /// <summary>
        /// Marca visualmente el botón seleccionado y desmarca los demás
        /// </summary>
        private void MarcarBotonSeleccionado(Button botonSeleccionado)
   {
            // Color azul oscuro del fondo (10, 26, 68)
       Color colorNormal = Color.FromArgb(10, 26, 68);

   // Color para el botón seleccionado (verde claro que destaque)
 Color colorSeleccionado = Color.FromArgb(76, 175, 80); // Verde

    // Resetear todos los botones al color azul oscuro
        btnEfectivo.BackColor = colorNormal;
  btnTarjeta.BackColor = colorNormal;
        btnTransferencia.BackColor = colorNormal;
     btnMix.BackColor = colorNormal;

            // Marcar el botón seleccionado con verde
            botonSeleccionado.BackColor = colorSeleccionado;
        }

        private void FinalizarVenta()
   {
            // Validar según la forma de pago
  if (formaPago == 3) // Efectivo
      {
     if (string.IsNullOrEmpty(txtPago.Text))
    {
              MessageBox.Show("Por Favor Ingrese el Monto Pagado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
       return;
  }

 decimal pago = Convert.ToDecimal(txtPago.Text);
      decimal cambio = pago - totalVenta;

     if (cambio < 0)
    {
       MessageBox.Show("El Pago es Insuficiente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
return;
           }

  txtCambio.Text = cambio.ToString("C2");
     }
            else if (formaPago == 4) // Mix
   {
      if (formMix == null)
   {
 MessageBox.Show("Error en el formulario de pago mixto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
 return;
 }

        // Usar el método ValidarCampos del formulario Mix
     if (!formMix.ValidarCampos())
  {
          return;
                }
            }
     else if (formaPago == 2) // Tarjeta
 {
if (formTarjeta != null && !formTarjeta.ValidarCampos())
  {
return;
   }
      // Tarjeta - el pago es exacto, no hay cambio
    }
     else // Transferencia
      {
         // Transferencia - el pago es exacto, no hay cambio
  }

    if (GuardarVenta(formaPago))
     {
           string mensaje = $"Venta Registrada Exitosamente\n\n";
 mensaje += $"Folio: {folioVenta}\n";
 mensaje += $"Forma de Pago: {ObtenerNombreFormaPago(formaPago)}\n";
          mensaje += $"Total: {totalVenta.ToString("C2")}\n";

         if (formaPago == 3) // Efectivo
    {
             decimal cambio = Convert.ToDecimal(txtPago.Text) - totalVenta;
      mensaje += $"Cambio: {cambio.ToString("C2")}";
      }
 else if (formaPago == 4) // Mix
   {
   mensaje += $"Tarjeta ({formMix.TipoTarjeta}): {formMix.MontoTarjeta.ToString("C2")}\n";
            mensaje += $"Efectivo: {formMix.DiferenciaEfectivo.ToString("C2")}";
     }

          MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
     this.DialogResult = DialogResult.OK;
             this.Close();
     }
        }

        private string ObtenerNombreFormaPago(int idFormaPago)
        {
        switch (idFormaPago)
  {
        case 1: return "Transferencia";
       case 2: return "Tarjeta";
        case 3: return "Efectivo";
           case 4: return "Mix";
      default: return "Desconocido";
            }
        }

        private bool GuardarVenta(int idformaPago)
        {
   Ventas venta = new Ventas();
  venta.idVenta = 0;
     venta.Folio = folioVenta; // Usar el folio generado
            venta.Fecha = DateTime.Now.Date;
        venta.idCliente = idCliente;
     venta.idEmpleados = idEmpleado;
        venta.idFormaPago = idformaPago;
            venta.Total = totalVenta;

     foreach (DataRow row in detalleVneta.Rows)
  {
    string codigoBarra = row["Codigo de Barra"].ToString();
                int idProducto = ObtenerIdProducto(codigoBarra);
     venta.Detalles.Add(new Ventas.VentaDetalle
  {
         idProducto = idProducto,
     CantidadProducto = Convert.ToInt32(row["Cantidad"]),
            PrecioProducto = Convert.ToDecimal(row["Precio Unitario"]),
      SubTotal = Convert.ToDecimal(row["Subtotal"])
                });
            }

            string mensaje = venta.Guardar(venta);
       if (mensaje.Contains("Correctamente"))
            {
  return true;
       }
            else
            {
  MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
       }
        }

        private int ObtenerIdProducto(string codigoBarra)
        {
       using (SqlConnection con = new SqlConnection(x.conexion()))
            {
      con.Open();
         string query = "SELECT idProducto FROM catProducto WHERE Codigo = @Codigo";
  using (SqlCommand cmd = new SqlCommand(query, con))
                {
      cmd.Parameters.AddWithValue("@Codigo", codigoBarra);
         object result = cmd.ExecuteScalar();
          return result != null ? Convert.ToInt32(result) : 0;
         }
            }
 }

        private string GenerarFolio()
        {
      return $"V-{DateTime.Now:yyyyMMdd}-{DateTime.Now:HHmmss}";
        }

        private void btnFinVenta_Click(object sender, EventArgs e)
        {
            if (formaPago == 0)
       {
         MessageBox.Show("Por Favor Seleccione una Forma de Pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
 FinalizarVenta();
        }
    }
}
