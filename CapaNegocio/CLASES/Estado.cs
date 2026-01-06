using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.CLASES
{
    public class Estado
    {
      static Conexion co = new Conexion();
        SqlConnection con = new SqlConnection(co.conexion());
        SqlCommand comando = new SqlCommand();

        // Campos
        public int idEstado;
        public string Nombre;

        public Estado()
 {
            comando.Connection = con;
        }

    public Estado(string sConexion)
        {
            con.ConnectionString = sConexion;
         comando.Connection = con;
        }

        public string Guardar(Estado estado)
        {
            string mensaje = "";

        using (SqlConnection con = new SqlConnection(co.conexion()))
   {
     string query;
        
    if (estado.idEstado == 0)
                {
          // INSERT
   query = "INSERT INTO catEstado (Nombre) VALUES (@Nombre); SELECT SCOPE_IDENTITY();";
     }
    else
           {
                    // UPDATE
  query = "UPDATE catEstado SET Nombre = @Nombre WHERE idEstado = @idEstado";
       }

                using (SqlCommand cmd = new SqlCommand(query, con))
           {
      cmd.Parameters.AddWithValue("@Nombre", estado.Nombre);
                
     if (estado.idEstado > 0)
          cmd.Parameters.AddWithValue("@idEstado", estado.idEstado);

      try
        {
        con.Open();
        
          if (estado.idEstado == 0)
   {
       object result = cmd.ExecuteScalar();
       if (result != null && result != DBNull.Value)
               {
           estado.idEstado = Convert.ToInt32(result);
         mensaje = "Estado Guardado Correctamente";
        }
            else
   {
            mensaje = "Error al Guardar el Estado";
        }
 }
     else
               {
      int filas = cmd.ExecuteNonQuery();
       mensaje = filas > 0 ? "Estado Actualizado Correctamente" : "Error al Actualizar el Estado";
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

        public string Eliminar(int idEstado)
        {
         string mensaje = "";

      using (SqlConnection con = new SqlConnection(co.conexion()))
    {
      string query = "DELETE FROM catEstado WHERE idEstado = @idEstado";

     using (SqlCommand cmd = new SqlCommand(query, con))
                {
   cmd.Parameters.AddWithValue("@idEstado", idEstado);

      try
 {
        con.Open();
      int filas = cmd.ExecuteNonQuery();
                  mensaje = filas > 0 ? "Estado Eliminado Correctamente" : "No se encontró el Estado";
            }
  catch (Exception ex)
    {
        if (ex.Message.Contains("REFERENCE"))
  mensaje = "No se puede eliminar, el Estado tiene Municipios asociados";
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
                string query = @"SELECT idEstado, Nombre FROM catEstado 
         WHERE (@Filtro = '' OR Nombre LIKE '%' + @Filtro + '%')
       ORDER BY Nombre";

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
    }
}
