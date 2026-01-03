using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaNegocio.CLASES
{
    public class Ventas
    {

        static Conexion co = new Conexion();
        SqlConnection con = new SqlConnection(co.conexion());
        SqlCommand comando = new SqlCommand();

        // ====== CAMPOS MAESTRO ======
        public int idVenta, idCliente, idEmpleados, idFormaPago;
        public string Folio;
        public DateTime Fecha;
        public decimal Total;

        // ====== LISTA DE DETALLES ======
        public List<VentaDetalle> Detalles { get; set; } = new List<VentaDetalle>();

        public Ventas()
        {
            comando.Connection = con;
        }
        public Ventas(string sConexion)
        {
            con.ConnectionString = sConexion; //Asegura la comparacion de valores
            comando.Connection = con;
        }

        public class VentaDetalle
        {
            public int idVentaDetalle { get; set; }
            public int idVenta { get; set; }
            public int idProducto { get; set; }
            public int CantidadProducto { get; set; }
            public decimal PrecioProducto { get; set; }
            public decimal SubTotal { get; set; }
        }

        public string Guardar(Ventas venta)
        {
            string mensaje = "";

            using (SqlConnection con = new SqlConnection(co.conexion()))
            using (SqlCommand cmd = new SqlCommand("SP_Venta", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Campos Para el Maestro
                cmd.Parameters.AddWithValue("@op", 2);
                cmd.Parameters.AddWithValue("@idVenta",
                    venta.idVenta == 0 ? (object)DBNull.Value : venta.idVenta);
                cmd.Parameters.AddWithValue("@Folio", venta.Folio);
                cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);
                cmd.Parameters.AddWithValue("@idCliente", venta.idCliente);
                cmd.Parameters.AddWithValue("@idEmpleados",
                    venta.idEmpleados == 0 ? (object)DBNull.Value : venta.idEmpleados);
                cmd.Parameters.AddWithValue("@idFormaPago", venta.idFormaPago);
                cmd.Parameters.AddWithValue("@Total", venta.Total);

                // Campos Para el Tipo Tabla 
                DataTable dtDetalles = new DataTable();
                dtDetalles.Columns.Add("idVentaDetalle", typeof(int));
                dtDetalles.Columns.Add("idVenta", typeof(int));
                dtDetalles.Columns.Add("idProducto", typeof(int));
                dtDetalles.Columns.Add("CantidadProducto", typeof(int));
                dtDetalles.Columns.Add("PrecioProducto", typeof(decimal));
                dtDetalles.Columns.Add("subTotal", typeof(decimal));

                Herramientas h = new Herramientas();
                int siguinteId = h.consecutivo("idVentaDetalle", "VentaDetalle");

                
                // Se llena el Detalle
                foreach (var d in venta.Detalles)
                {
                    dtDetalles.Rows.Add(
                        siguinteId++,
                        0,
                        d.idProducto,
                        d.CantidadProducto,
                        d.PrecioProducto,
                        d.SubTotal
                    );
                }

                // Enviar el Tipo Tabla al Procedimiento Almacenado
                SqlParameter tvp = cmd.Parameters.AddWithValue("@detalles", dtDetalles);
                tvp.SqlDbType = SqlDbType.Structured;
                tvp.TypeName = "DetalleVenta";

                con.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    venta.idVenta = Convert.ToInt32(result);
                    mensaje = "Venta Guardada Correctamente";
                }
                else
                {
                    mensaje = "Error al Guardar la Venta";
                }
                con.Close();
            }
            return mensaje;
        }

        public string Cancelar(int idVenta, string motivo, int usuarioCancelo)
        {
            string mensaje = "";

            using (SqlConnection con = new SqlConnection(co.conexion()))
            using (SqlCommand cmd = new SqlCommand("SP_Venta", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@op", 3);
                cmd.Parameters.AddWithValue("@idVenta", idVenta);
                cmd.Parameters.AddWithValue("@motivoCancelacion", motivo);
                cmd.Parameters.AddWithValue("@usuarioCancelo", usuarioCancelo);

                cmd.Parameters.AddWithValue("@Folio", DBNull.Value);
                cmd.Parameters.AddWithValue("@Fecha", DBNull.Value);
                cmd.Parameters.AddWithValue("@idCliente", DBNull.Value);
                cmd.Parameters.AddWithValue("@idEmpleados", DBNull.Value);
                cmd.Parameters.AddWithValue("@idFormaPago", DBNull.Value);
                cmd.Parameters.AddWithValue("@Total", DBNull.Value);

                //Tipo Tabla Vacío
                DataTable dtVacio = new DataTable();
                dtVacio.Columns.Add("idVentaDetalle", typeof(int));
                dtVacio.Columns.Add("idVenta", typeof(int));
                dtVacio.Columns.Add("idProducto", typeof(int));
                dtVacio.Columns.Add("CantidadProducto", typeof(int));
                dtVacio.Columns.Add("PrecioProducto", typeof(decimal));
                dtVacio.Columns.Add("subTotal", typeof(decimal));

                SqlParameter tvp = cmd.Parameters.AddWithValue("@detalles", dtVacio);
                tvp.SqlDbType = SqlDbType.Structured;
                tvp.TypeName = "DetalleVenta";
                
                try
                {
                    con.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
    
                    // Si el SP no devuelve filas afectadas o devuelve -1, la cancelación fue exitosa
                    mensaje = "Venta Cancelada Correctamente";
                }
                catch (Exception ex)
                {
                    mensaje = "Error al Cancelar la Venta: " + ex.Message;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return mensaje;
        }
    }
}
