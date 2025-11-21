using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaNegocio.CLASES
{
    public class Ventas
    {

        static Conexion co = new Conexion();
        SqlConnection con = new SqlConnection(co.conexion);
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

            using (SqlConnection con = new SqlConnection(co.conexion))
            using (SqlCommand cmd = new SqlCommand("SP_Venta", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Campos Para el Maestro
                cmd.Parameters.AddWithValue("@op", 1);
                cmd.Parameters.AddWithValue("@idVenta",
                    venta.idVenta == 0 ? (object)DBNull.Value : venta.idVenta);
                cmd.Parameters.AddWithValue("@idCliente", venta.idCliente);
                cmd.Parameters.AddWithValue("@idEmpleados",
                    venta.idEmpleados == 0 ? (object)DBNull.Value : venta.idEmpleados);
                cmd.Parameters.AddWithValue("@idFormaPago", venta.idFormaPago);
                cmd.Parameters.AddWithValue("@Folio", venta.Folio);
                cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);

                // Campos Para el Tipo Tabla 
                DataTable dtDetalles = new DataTable();
                dtDetalles.Columns.Add("idVentaDetalle", typeof(int));
                dtDetalles.Columns.Add("idVenta", typeof(int));
                dtDetalles.Columns.Add("idProducto", typeof(int));
                dtDetalles.Columns.Add("CantidadProducto", typeof(int));
                dtDetalles.Columns.Add("PrecioProducto", typeof(decimal));
                dtDetalles.Columns.Add("subTotal", typeof(decimal));

                // Se llena el Detalle
                foreach (var d in venta.Detalles)
                {
                    dtDetalles.Rows.Add(
                        0,
                        0,
                        d.idProducto,
                        d.CantidadProducto,
                        d.PrecioProducto,
                        d.SubTotal
                    );
                }

                // Enviar el Tipo Tabla al Procedimiento Almacenado
                SqlParameter tvp = cmd.Parameters.AddWithValue("@Detalles", dtDetalles);
                tvp.SqlDbType = SqlDbType.Structured;
                tvp.TypeName = "DetalleVenta";

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        mensaje = reader["Mensaje"].ToString();
                        venta.idVenta = Convert.ToInt32(reader["idVenta"]);
                    }
                    else
                    {
                        mensaje = "Venta guardada correctamente";
                    }
                }

                con.Close();
            }

            return mensaje;
        }

        public string Eliminar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure; //Confirma que los datos se obtendran de un PA
            comando.CommandText = "SP_Venta"; //Nombre del PA
            comando.Parameters.Clear(); //Limpia los parametros, por si queda alguno en cache
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idVenta", idVenta);
            con.Open(); //Abre conexion
            comando.ExecuteNonQuery(); //Ejecuta cuando no es una consulta
            mensaje = "CAMPO ELIMINADO";

            con.Close();
            return mensaje;
        }
    }
}
