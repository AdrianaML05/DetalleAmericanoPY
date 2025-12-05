using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.CLASES
{
    public class Proveedores
    {
        static Conexion co = new Conexion();
        SqlConnection con = new SqlConnection(co.conexion()); //Trae todo lo que el metodo conexion contiene, permite la conexion BDD.
        SqlCommand comando = new SqlCommand();

        public int idProveedores;
        public string Nombre, numTelefono;

        public Proveedores()
        {
            comando.Connection = con;
        }

        public Proveedores(string sConexion)
        {
            con.ConnectionString = sConexion; //Asegura la comparacion de valores
            comando.Connection = con;
        }

        public string Guaradar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure; //Confirma que los datos se obtendran de un PA
            comando.CommandText = "SP_catProveedores"; //Nombre del PA
            comando.Parameters.Clear(); //Limpia los parametros, por si queda alguno en cache
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idProveedores", idProveedores);
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@numTelefono", numTelefono);
            con.Open(); //Abre conexion
            comando.ExecuteNonQuery(); //Ejecuta cuando no es una consulta
            mensaje = "Listo";
            con.Close();
            return mensaje;

        }
        public string Eliminar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure; //Confirma que los datos se obtendran de un PA
            comando.CommandText = "SP_catProveedores"; //Nombre del PA
            comando.Parameters.Clear(); //Limpia los parametros, por si queda alguno en cache
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idProveedores", idProveedores);
            con.Open(); //Abre conexion
            comando.ExecuteNonQuery(); //Ejecuta cuando no es una consulta
            mensaje = "CAMPO ELIMINADO";

            con.Close();
            return mensaje;
        }

    }
}
