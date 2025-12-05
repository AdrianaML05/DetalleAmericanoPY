using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.CLASES
{
    public class Domicilios
    {
        static Conexion co = new Conexion();
        SqlConnection con = new SqlConnection(co.conexion()); //Trae todo lo que el metodo conexion contiene, permite la conexion BDD.
        SqlCommand comando = new SqlCommand();

        public int idDomicilio, idCliente, idMunicipio;
        public string nombreDomicilio, numExterior, numInterior, calle, CP;
        public string Referencias;

        public Domicilios()
        {
            comando.Connection = con;
        }
        public Domicilios(string sConexion)
        {
            con.ConnectionString = sConexion; //Asegura la comparacion de valores
            comando.Connection = con;
        }

        public string Guardar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure; //Confirma que los datos se obtendran de un PA
            comando.CommandText = "SP_catDomiclio"; //Nombre del PA
            comando.Parameters.Clear(); //Limpia los parametros, por si queda alguno en cache
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idDomicilio", idDomicilio);
            comando.Parameters.AddWithValue("@idCliente", idCliente);
            comando.Parameters.AddWithValue("@idMunicipio", idMunicipio);
            comando.Parameters.AddWithValue("@nombreDomicilio", nombreDomicilio);
            comando.Parameters.AddWithValue("@numExterior", numExterior);
            comando.Parameters.AddWithValue("@numInterior", @numInterior);
            comando.Parameters.AddWithValue("@calle", calle);
            comando.Parameters.AddWithValue("@CP", CP);
            comando.Parameters.AddWithValue("@Referencias", Referencias);
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
            comando.CommandText = "SP_catDomiclio"; //Nombre del PA
            comando.Parameters.Clear(); //Limpia los parametros, por si queda alguno en cache
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idDomicilio", idDomicilio);
            con.Open(); //Abre conexion
            comando.ExecuteNonQuery(); //Ejecuta cuando no es una consulta
            mensaje = "CAMPO ELIMINADO";

            con.Close();
            return mensaje;
        }
    }
}
