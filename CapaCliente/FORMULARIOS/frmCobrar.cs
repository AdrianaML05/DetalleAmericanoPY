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
    public partial class frmCobrar : Form
    {
        static Conexion x = new Conexion();
        private decimal totalVenta;
        private int idCliente;
        private int idEmpleado;
        private DataTable detalleVneta;
        private int formaPago = 1;

        // contructor que recibe los 4 valores de la venta
        public frmCobrar(decimal toatl, int cliente, int empleado, DataTable detalle)
        {
            InitializeComponent();
            totalVenta = toatl;
            idCliente = cliente;
            idEmpleado = empleado;
            detalleVneta = detalle.Copy();
        }

        public frmCobrar()
        {
            InitializeComponent();
        }

        private void frmCobrar_Load(object sender, EventArgs e)
        {
            txtTotal.Text = totalVenta.ToString("C2");
            txtTotal.ReadOnly = true;
            txtPago.Focus();
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
            formaPago = 2;
            
        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            formaPago = 3;
            
        }

        private void btnMix_Click(object sender, EventArgs e)
        {
            formaPago = 4;
            
        }

        private void FinalizarVenta()
        {
            // Validar efectivo y mix para el pago 
            if (formaPago == 3 || formaPago == 4) // Aqui indica si es efectivo o mix
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
            else
            {
                // Tarjeta y Transferencia, el pago es exacto
                txtPago.Text = totalVenta.ToString();
                txtCambio.Text = "$0.00";
            }
            if (GuardarVenta(formaPago))
            {
                string mensaje = $"Venta Registrada Exitosamente\n\n";

                if (formaPago == 3 || formaPago == 4)
                {
                    decimal cambio = Convert.ToDecimal(txtPago.Text) - totalVenta;
                    mensaje += $"Cambio: {cambio.ToString("C2")}";
                }

                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool GuardarVenta(int idformaPago)
        {
            //using (SqlConnection con = new SqlConnection(x.conexion))
            //{
            //    con.Open();
            //    using (SqlCommand cmd = new SqlCommand("SP_Venta", con))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;

            //        // Parametros para el procedimieto almacenado
            //        cmd.Parameters.AddWithValue("@op", 2);
            //        cmd.Parameters.AddWithValue("@idVenta", 0);
            //        cmd.Parameters.AddWithValue("@Folio", GenerarFolio());
            //        cmd.Parameters.AddWithValue("@Fecha", DateTime.Now.Date);
            //        cmd.Parameters.AddWithValue("@idCliente", idCliente);
            //        cmd.Parameters.AddWithValue("@idEmpleados", idEmpleado);
            //        cmd.Parameters.AddWithValue("@idFormaPago", idformaPago);
            //        cmd.Parameters.AddWithValue("@Total", totalVenta);

            //        SqlParameter detallesParam = cmd.Parameters.AddWithValue("@detalles", CrearTablaDetalles());
            //        detallesParam.SqlDbType = SqlDbType.Structured;
            //        detallesParam.TypeName = "DetalleVenta";

            //        object result = cmd.ExecuteScalar();

            //        if (result != null)
            //        {
            //            int idVentaGenerada = Convert.ToInt32(result);
            //            return true;
            //        }
            //    }
            //}
            //return false;

            Ventas venta = new Ventas();
            venta.idVenta = 0;
            venta.Folio = GenerarFolio();
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

        //private DataTable CrearTablaDetalles()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("idVentaDetalle", typeof(int));
        //    dt.Columns.Add("idVenta", typeof(int));
        //    dt.Columns.Add("idProducto", typeof(int));
        //    dt.Columns.Add("CantidadProducto", typeof(int));
        //    dt.Columns.Add("PrecioProducto", typeof(decimal));
        //    dt.Columns.Add("subTotal", typeof(decimal));

        //    int contador = 1;
        //    foreach (DataRow row in detalleVneta.Rows)
        //    {
        //        DataRow newRow = dt.NewRow();
        //        newRow["idVentaDetalle"] = contador++;
        //        newRow["idVenta"] = 0;

        //        string codigoBarra = row["Codigo de Barra"].ToString();
        //        newRow["idProducto"] = ObtenerIdProducto(codigoBarra);

        //        newRow["CantidadProducto"] = Convert.ToInt32(row["Cantidad"]);
        //        newRow["PrecioProducto"] = Convert.ToDecimal(row["Precio Unitario"]);
        //        newRow["subTotal"] = Convert.ToDecimal(row["Subtotal"]);
        //        dt.Rows.Add(newRow);
        //    }
        //    return dt;
        //}
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

        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            formaPago = 1;
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
