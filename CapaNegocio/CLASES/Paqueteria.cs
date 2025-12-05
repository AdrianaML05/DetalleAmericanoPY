using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.CLASES
{
    public class Paqueteria
    {
        static Conexion co = new Conexion();
        SqlConnection con = new SqlConnection(co.conexion()); //Trae todo lo que el metodo conexion contiene, permite la conexion BDD.
        SqlCommand comando = new SqlCommand();

        public int idPaqueteria;
        public string Nombre, Calle, numExterior, numInterioir, Referencias, Telefono;
        public bool encontro = false;

        public Paqueteria()
        {
            comando.Connection = con;
        }
        public Paqueteria(string sConexion)
        {
            con.ConnectionString = sConexion; //Asegura la comparacion de valores
            comando.Connection = con;
        }
        public string Guardar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure; //Confirma que los datos se obtendran de un PA
            comando.CommandText = "SP_catPaqueteria"; //Nombre del PA
            comando.Parameters.Clear(); //Limpia los parametros, por si queda alguno en cache
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idPaqueteria", idPaqueteria);
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Calle", Calle);
            comando.Parameters.AddWithValue("@numExterior", numExterior);
            comando.Parameters.AddWithValue("@numInterioir", numInterioir);
            comando.Parameters.AddWithValue("@Referencias", Referencias);
            comando.Parameters.AddWithValue("@Telefono", Telefono);
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
            comando.CommandText = "SP_catPaqueteria"; //Nombre del PA
            comando.Parameters.Clear(); //Limpia los parametros, por si queda alguno en cache
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idPaqueteria", idPaqueteria);
            con.Open(); //Abre conexion
            comando.ExecuteNonQuery(); //Ejecuta cuando no es una consulta
            mensaje = "CAMPO ELIMINADO";

            con.Close();
            return mensaje;
        }
    }
    
}
