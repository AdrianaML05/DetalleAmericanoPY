using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.CLASES
{
    public class Envio
    {
        static Conexion co = new Conexion();
        SqlConnection con = new SqlConnection(co.conexion());
        SqlCommand comando = new SqlCommand();

        // ====== CAMPOS MAESTRO ======
        public int idEnvio;
        public int idDomicilio;
        public int idPaqueteria;
        public int Estatus; // 1=Pendiente, 2=En tránsito, 3=Entregado, 4=Cancelado
        public DateTime FechaEnvio;

        // ====== LISTA DE DETALLES ======
        public List<EnvioDetalle> Detalles { get; set; } = new List<EnvioDetalle>();

        public Envio()
        {
            comando.Connection = con;
        }

        public Envio(string sConexion)
        {
            con.ConnectionString = sConexion;
            comando.Connection = con;
        }

        public class EnvioDetalle
        {
            public int idEnvioDetalle { get; set; }
            public int idEnvio { get; set; }
            public int idPedidoDetalle { get; set; }
            public int CantPaquetes { get; set; }
            public decimal Total { get; set; }

            // Campos adicionales para mostrar en el grid (no se guardan en BD)
            public string FolioPedido { get; set; }
            public string Cliente { get; set; }
            public decimal TotalPedido { get; set; }
        }

        public string Guardar(Envio envio)
        {
            string mensaje = "";

            using (SqlConnection con = new SqlConnection(co.conexion()))
            using (SqlCommand cmd = new SqlCommand("SP_Envio", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Campos Para el Maestro
                cmd.Parameters.AddWithValue("@op", 2);
                cmd.Parameters.AddWithValue("@idEnvio",
          envio.idEnvio == 0 ? (object)DBNull.Value : envio.idEnvio);
                cmd.Parameters.AddWithValue("@idDomicilio", envio.idDomicilio);
                cmd.Parameters.AddWithValue("@idPaqueteria", envio.idPaqueteria);
                cmd.Parameters.AddWithValue("@Estatus", envio.Estatus);
                cmd.Parameters.AddWithValue("@FechaEnvio", envio.FechaEnvio);

                // Campos Para el Tipo Tabla 
                DataTable dtDetalles = new DataTable();
                dtDetalles.Columns.Add("idEnvioDetalle", typeof(int));
                dtDetalles.Columns.Add("idEnvio", typeof(int));
                dtDetalles.Columns.Add("idPedidoDetalle", typeof(int));
                dtDetalles.Columns.Add("CantPaquetes", typeof(int));
                dtDetalles.Columns.Add("Total", typeof(decimal));

                Herramientas h = new Herramientas();
                int siguienteId = h.consecutivo("idEnvioDetalle", "EnvioDetalle");

                // Se llena el Detalle
                foreach (var d in envio.Detalles)
                {
                    dtDetalles.Rows.Add(
                      siguienteId++,
                            0, // idEnvio se asigna en el SP
                           d.idPedidoDetalle,
                     d.CantPaquetes,
                      d.Total
                     );
                }

                // Enviar el Tipo Tabla al Procedimiento Almacenado
                SqlParameter tvp = cmd.Parameters.AddWithValue("@detalles", dtDetalles);
                tvp.SqlDbType = SqlDbType.Structured;
                tvp.TypeName = "DetalleEnvio";

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        envio.idEnvio = Convert.ToInt32(result);
                        mensaje = "Envío Guardado Correctamente";
                    }
                    else
                    {
                        mensaje = "Error al Guardar el Envío";
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

        public string Cancelar(int idEnvio)
        {
            string mensaje = "";

            using (SqlConnection con = new SqlConnection(co.conexion()))
            using (SqlCommand cmd = new SqlCommand("SP_Envio", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@op", 3);
                cmd.Parameters.AddWithValue("@idEnvio", idEnvio);

                // Parámetros opcionales con valores nulos
                cmd.Parameters.AddWithValue("@idDomicilio", DBNull.Value);
                cmd.Parameters.AddWithValue("@idPaqueteria", DBNull.Value);
                cmd.Parameters.AddWithValue("@Estatus", DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaEnvio", DBNull.Value);

                // Tipo Tabla Vacío
                DataTable dtVacio = new DataTable();
                dtVacio.Columns.Add("idEnvioDetalle", typeof(int));
                dtVacio.Columns.Add("idEnvio", typeof(int));
                dtVacio.Columns.Add("idPedidoDetalle", typeof(int));
                dtVacio.Columns.Add("CantPaquetes", typeof(int));
                dtVacio.Columns.Add("Total", typeof(decimal));

                SqlParameter tvp = cmd.Parameters.AddWithValue("@detalles", dtVacio);
                tvp.SqlDbType = SqlDbType.Structured;
                tvp.TypeName = "DetalleEnvio";

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    mensaje = "Envío Cancelado Correctamente";
                }
                catch (Exception ex)
                {
                    mensaje = "Error al Cancelar el Envío: " + ex.Message;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return mensaje;
        }

        public DataTable ConsultarEnvios(string filtro = "", int estatus = 0)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(co.conexion()))
            {
                string query = @"SELECT e.idEnvio,'E-' + RIGHT('00000000' + CAS(e.idEnvio AS VARCHAR), 8) AS Folio, e.FechaEnvio AS Fecha, d.nombreDomicilio AS Domicilio, p.Nombre AS Paqueteria, CASE e.Estatus WHEN 1 THEN 'Pendiente' WHEN 2 THEN 'En tránsito' WHEN 3 THEN 'Entregado' WHEN 4 THEN 'Cancelado' ELSE 'Desconocido' END AS Estatus, e.Estatus AS EstatusId FROM Envio e LEFT JOIN catDomicilios d ON e.idDomicilio = d.idDomicilio LEFT JOIN catPaqueteria p ON e.idPaqueteria = p.idPaqueteria WHERE (@Filtro = '' OR CAST(e.idEnvio AS VARCHAR) LIKE '%' + @Filtro + '%') AND (@Estatus = 0 OR e.Estatus = @Estatus) ORDER BY e.FechaEnvio DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Filtro", filtro);
                    cmd.Parameters.AddWithValue("@Estatus", estatus);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable ObtenerDomicilios()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(co.conexion()))
            {
                string query = @"SELECT idDomicilio, nombreDomicilio 
    FROM catDomicilios ORDER BY nombreDomicilio";
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable ObtenerPaqueterias()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(co.conexion()))
            {
                string query = "SELECT idPaqueteria, Nombre FROM catPaqueteria ORDER BY Nombre";
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable ObtenerPedidosActivos()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(co.conexion()))
            {
                string query = @"
                SELECT 
    p.idPedido,
       p.Folio,
  p.FechaPedido,
                    c.Nombre + ' ' + c.ApellidoPa AS Cliente,
       p.Total
       FROM Pedido p
          INNER JOIN catClientes c ON p.idCliente = c.idCliente
     WHERE p.Estatus = 'Activa'
  ORDER BY p.FechaPedido DESC";

                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}
