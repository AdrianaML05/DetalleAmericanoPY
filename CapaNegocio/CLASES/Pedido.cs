using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.CLASES
{
    public class Pedido
    {
        static Conexion co = new Conexion();
        SqlConnection con = new SqlConnection(co.conexion());
        SqlCommand comando = new SqlCommand();

        // ====== CAMPOS MAESTRO ======
        public int idPedido, idCliente, idFormaPago;
        public string Folio;
        public DateTime FechaPedido;
        public decimal Total;

        // ====== LISTA DE DETALLES ======
        public List<PedidoDetalle> Detalles { get; set; } = new List<PedidoDetalle>();

        public Pedido()
        {
            comando.Connection = con;
        }

        public Pedido(string sConexion)
        {
            con.ConnectionString = sConexion;
            comando.Connection = con;
        }

        public class PedidoDetalle
        {
            public int idPedidoDetalle { get; set; }
            public int idPedido { get; set; }
            public int idProducto { get; set; }
            public int Cantidad { get; set; }
            public decimal Precio { get; set; }
            public decimal SubTotal { get; set; }
        }

        public string Guardar(Pedido pedido)
        {
            string mensaje = "";

            using (SqlConnection con = new SqlConnection(co.conexion()))
            using (SqlCommand cmd = new SqlCommand("SP_Pedido", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Campos Para el Maestro
                cmd.Parameters.AddWithValue("@op", 2);
                cmd.Parameters.AddWithValue("@idPedido",
              pedido.idPedido == 0 ? (object)DBNull.Value : pedido.idPedido);
                cmd.Parameters.AddWithValue("@Folio", pedido.Folio ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaPedido", pedido.FechaPedido);
                cmd.Parameters.AddWithValue("@idCliente", pedido.idCliente);
                cmd.Parameters.AddWithValue("@idFormaPago", pedido.idFormaPago);
                cmd.Parameters.AddWithValue("@Total", pedido.Total);

                // Campos Para el Tipo Tabla 
                DataTable dtDetalles = new DataTable();
                dtDetalles.Columns.Add("idPedidoDetalle", typeof(int));
                dtDetalles.Columns.Add("idPedido", typeof(int));
                dtDetalles.Columns.Add("idProducto", typeof(int));
                dtDetalles.Columns.Add("Cantidad", typeof(int));
                dtDetalles.Columns.Add("Precio", typeof(decimal));
                dtDetalles.Columns.Add("SubTotal", typeof(decimal));

                Herramientas h = new Herramientas();
                int siguienteId = h.consecutivo("idPedidoDetalle", "PedidoDetalle");

                // Se llena el Detalle
                foreach (var d in pedido.Detalles)
                {
                    dtDetalles.Rows.Add(
                            siguienteId++,
                      0, // idPedido se asigna en el SP
                       d.idProducto,
                       d.Cantidad,
                       d.Precio,
                      d.SubTotal
                    );
                }

                // Enviar el Tipo Tabla al Procedimiento Almacenado
                SqlParameter tvp = cmd.Parameters.AddWithValue("@detalles", dtDetalles);
                tvp.SqlDbType = SqlDbType.Structured;
                tvp.TypeName = "DetallePedido";

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        pedido.idPedido = Convert.ToInt32(result);
                        mensaje = "Pedido Guardado Correctamente";
                    }
                    else
                    {
                        mensaje = "Error al Guardar el Pedido";
                    }
                }
                catch (Exception ex)
                {
                    mensaje = "Error: " + ex.Message;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return mensaje;
        }

        public string Cancelar(int idPedido, string motivo, int usuarioCancelo)
        {
            string mensaje = "";

            using (SqlConnection con = new SqlConnection(co.conexion()))
            using (SqlCommand cmd = new SqlCommand("SP_Pedido", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@op", 3);
                cmd.Parameters.AddWithValue("@idPedido", idPedido);
                cmd.Parameters.AddWithValue("@MotivoCancelacion", motivo);
                cmd.Parameters.AddWithValue("@UsuarioCancelo", usuarioCancelo);

                cmd.Parameters.AddWithValue("@Folio", DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaPedido", DBNull.Value);
                cmd.Parameters.AddWithValue("@idCliente", DBNull.Value);
                cmd.Parameters.AddWithValue("@idFormaPago", DBNull.Value);
                cmd.Parameters.AddWithValue("@Total", DBNull.Value);

                // Tipo Tabla Vacío
                DataTable dtVacio = new DataTable();
                dtVacio.Columns.Add("idPedidoDetalle", typeof(int));
                dtVacio.Columns.Add("idPedido", typeof(int));
                dtVacio.Columns.Add("idProducto", typeof(int));
                dtVacio.Columns.Add("Cantidad", typeof(int));
                dtVacio.Columns.Add("Precio", typeof(decimal));
                dtVacio.Columns.Add("SubTotal", typeof(decimal));

                SqlParameter tvp = cmd.Parameters.AddWithValue("@detalles", dtVacio);
                tvp.SqlDbType = SqlDbType.Structured;
                tvp.TypeName = "DetallePedido";

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    mensaje = "Pedido Cancelado Correctamente";
                }
                catch (Exception ex)
                {
                    mensaje = "Error al Cancelar el Pedido: " + ex.Message;
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
