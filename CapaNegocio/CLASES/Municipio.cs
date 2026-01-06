using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.CLASES
{
    public class Municipio
    {
      static Conexion co = new Conexion();
        SqlConnection con = new SqlConnection(co.conexion());
        SqlCommand comando = new SqlCommand();

  // Campos
        public int idMunicipio;
    public string Nombre;
        public int idEstado;

     public Municipio()
        {
        comando.Connection = con;
    }

     public Municipio(string sConexion)
        {
 con.ConnectionString = sConexion;
            comando.Connection = con;
        }

  public string Guardar(Municipio municipio)
        {
   string mensaje = "";

  using (SqlConnection con = new SqlConnection(co.conexion()))
    {
            string query;

  if (municipio.idMunicipio == 0)
       {
  // INSERT
          query = "INSERT INTO catMunicipio (Nombre, idEstado) VALUES (@Nombre, @idEstado); SELECT SCOPE_IDENTITY();";
        }
     else
   {
          // UPDATE
 query = "UPDATE catMunicipio SET Nombre = @Nombre, idEstado = @idEstado WHERE idMunicipio = @idMunicipio";
              }

                using (SqlCommand cmd = new SqlCommand(query, con))
          {
              cmd.Parameters.AddWithValue("@Nombre", municipio.Nombre);
                cmd.Parameters.AddWithValue("@idEstado", municipio.idEstado);

  if (municipio.idMunicipio > 0)
         cmd.Parameters.AddWithValue("@idMunicipio", municipio.idMunicipio);

try
             {
              con.Open();

     if (municipio.idMunicipio == 0)
 {
           object result = cmd.ExecuteScalar();
         if (result != null && result != DBNull.Value)
            {
      municipio.idMunicipio = Convert.ToInt32(result);
            mensaje = "Municipio Guardado Correctamente";
           }
   else
      {
    mensaje = "Error al Guardar el Municipio";
        }
       }
      else
             {
           int filas = cmd.ExecuteNonQuery();
   mensaje = filas > 0 ? "Municipio Actualizado Correctamente" : "Error al Actualizar el Municipio";
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
 }
     return mensaje;
        }

        public string Eliminar(int idMunicipio)
        {
            string mensaje = "";

   using (SqlConnection con = new SqlConnection(co.conexion()))
        {
                string query = "DELETE FROM catMunicipio WHERE idMunicipio = @idMunicipio";

           using (SqlCommand cmd = new SqlCommand(query, con))
                {
            cmd.Parameters.AddWithValue("@idMunicipio", idMunicipio);

    try
                {
con.Open();
      int filas = cmd.ExecuteNonQuery();
        mensaje = filas > 0 ? "Municipio Eliminado Correctamente" : "No se encontró el Municipio";
         }
            catch (Exception ex)
               {
                 if (ex.Message.Contains("REFERENCE"))
      mensaje = "No se puede eliminar, el Municipio tiene registros asociados";
        else
    mensaje = "Error: " + ex.Message;
      }
            finally
   {
            if (con.State == ConnectionState.Open)
     con.Close();
   }
      }
            }
          return mensaje;
        }

        public DataTable Consultar(string filtro = "")
        {
       DataTable dt = new DataTable();

  using (SqlConnection con = new SqlConnection(co.conexion()))
       {
                string query = @"SELECT m.idMunicipio, m.Nombre, m.idEstado, e.Nombre AS Estado 
  FROM catMunicipio m
            INNER JOIN catEstado e ON m.idEstado = e.idEstado
            WHERE (@Filtro = '' OR m.Nombre LIKE '%' + @Filtro + '%')
      ORDER BY m.Nombre";

       using (SqlCommand cmd = new SqlCommand(query, con))
    {
          cmd.Parameters.AddWithValue("@Filtro", filtro);
 using (SqlDataAdapter da = new SqlDataAdapter(cmd))
     {
           da.Fill(dt);
 }
 }
       }
            return dt;
        }

        public DataTable ObtenerEstados()
        {
  DataTable dt = new DataTable();

   using (SqlConnection con = new SqlConnection(co.conexion()))
         {
        string query = "SELECT idEstado, Nombre FROM catEstado ORDER BY Nombre";
  using (SqlDataAdapter da = new SqlDataAdapter(query, con))
       {
          da.Fill(dt);
             }
            }
     return dt;
        }
    }
}
