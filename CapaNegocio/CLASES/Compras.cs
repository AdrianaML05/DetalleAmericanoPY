using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.CLASES
{
    public class Compras
    {
        static Conexion co = new Conexion();
        SqlConnection con = new SqlConnection(co.conexion());
        SqlCommand comando = new SqlCommand();

        // ====== CAMPOS MAESTRO ======
        public int idCompra, idProveedores;
        public DateTime Fecha;
        public decimal Total;
        public string Folio; // Campo para el folio

        // ====== LISTA DE DETALLES ======
        public List<CompraDetalle> Detalles { get; set; } = new List<CompraDetalle>();

        public Compras()
        {
            comando.Connection = con;
        }

        public Compras(string sConexion)
        {
            con.ConnectionString = sConexion;
            comando.Connection = con;
        }

        public class CompraDetalle
        {
            public int idCompraDetalle { get; set; }
            public int idCompra { get; set; }
            public int idProducto { get; set; }
            public int Cantidad { get; set; }
            public decimal Precio { get; set; }
            public decimal SubTotal { get; set; }
        }

        public string Guardar(Compras compra)
        {
            string mensaje = "";

            using (SqlConnection con = new SqlConnection(co.conexion()))
            using (SqlCommand cmd = new SqlCommand("SP_Compra", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Campos Para el Maestro
                cmd.Parameters.AddWithValue("@op", 2);
                cmd.Parameters.AddWithValue("@idCompra",
                       compra.idCompra == 0 ? (object)DBNull.Value : compra.idCompra);
                cmd.Parameters.AddWithValue("@Fecha", compra.Fecha);
                cmd.Parameters.AddWithValue("@idProveedores", compra.idProveedores);
                cmd.Parameters.AddWithValue("@Total", compra.Total);
                cmd.Parameters.AddWithValue("@Folio", compra.Folio ?? (object)DBNull.Value); // Agregar Folio

                // Campos Para el Tipo Tabla 
                DataTable dtDetalles = new DataTable();
                dtDetalles.Columns.Add("idCompraDetalle", typeof(int));
                dtDetalles.Columns.Add("idProducto", typeof(int));
                dtDetalles.Columns.Add("idCompra", typeof(int));
                dtDetalles.Columns.Add("Cantidad", typeof(int));
                dtDetalles.Columns.Add("Precio", typeof(decimal));
                dtDetalles.Columns.Add("SubTotal", typeof(decimal));

                Herramientas h = new Herramientas();
                int siguinteId = h.consecutivo("idCompraDetalle", "CompraDetalle");

                // Se llena el Detalle
                foreach (var d in compra.Detalles)
                {
                    dtDetalles.Rows.Add(
                          siguinteId++,
                                d.idProducto,
                       0, // idCompra se asigna en el SP
                          d.Cantidad,
                     d.Precio,
                         d.SubTotal
                              );
                }

                // Enviar el Tipo Tabla al Procedimiento Almacenado
                SqlParameter tvp = cmd.Parameters.AddWithValue("@detalles", dtDetalles);
                tvp.SqlDbType = SqlDbType.Structured;
                tvp.TypeName = "DetalleCompra";

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        compra.idCompra = Convert.ToInt32(result);
                        mensaje = "Compra Guardada Correctamente";
                    }
                    else
                    {
                        mensaje = "Error al Guardar la Compra";
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

        public string Cancelar(int idCompra, string motivo, int usuarioCancelo)
        {
            string mensaje = "";

            using (SqlConnection con = new SqlConnection(co.conexion()))
            using (SqlCommand cmd = new SqlCommand("SP_Compra", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@op", 3);
                cmd.Parameters.AddWithValue("@idCompra", idCompra);
                cmd.Parameters.AddWithValue("@MotivoCancelacion", motivo);
                cmd.Parameters.AddWithValue("@UsuarioCancelo", usuarioCancelo);

                cmd.Parameters.AddWithValue("@Fecha", DBNull.Value);
                cmd.Parameters.AddWithValue("@idProveedores", DBNull.Value);
                cmd.Parameters.AddWithValue("@Total", DBNull.Value);

                // Tipo Tabla Vacío
                DataTable dtVacio = new DataTable();
                dtVacio.Columns.Add("idCompraDetalle", typeof(int));
                dtVacio.Columns.Add("idProducto", typeof(int));
                dtVacio.Columns.Add("idCompra", typeof(int));
                dtVacio.Columns.Add("Cantidad", typeof(int));
                dtVacio.Columns.Add("Precio", typeof(decimal));
                dtVacio.Columns.Add("SubTotal", typeof(decimal));

                SqlParameter tvp = cmd.Parameters.AddWithValue("@detalles", dtVacio);
                tvp.SqlDbType = SqlDbType.Structured;
                tvp.TypeName = "DetalleCompra";

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    mensaje = "Compra Cancelada Correctamente";
                }
                catch (Exception ex)
                {
                    mensaje = "Error al Cancelar la Compra: " + ex.Message;
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
