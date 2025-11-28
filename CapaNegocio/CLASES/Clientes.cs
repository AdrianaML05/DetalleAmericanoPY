using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.CLASES
{
    public class Clientes
    {
        static Conexion co = new Conexion();
        SqlConnection con = new SqlConnection(co.conexion); //Trae todo lo que el metodo conexion contiene, permite la conexion BDD.
        SqlCommand comando = new SqlCommand();

        public int idCliente, numVisita;
        public string Nombre, ApellidoPa, ApellidoMa, NumeroTel, Correo, TipoCliente;
        public DateTime FechaNacimiento;

        public Clientes()
        {
            comando.Connection = con;
        }
        public Clientes(string sConexion)
        {
            con.ConnectionString = sConexion; //Asegura la comparacion de valores
            comando.Connection = con;
        }
        public string Guardar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure; //Confirma que los datos se obtendran de un PA
            comando.CommandText = "SP_catClientes"; //Nombre del PA
            comando.Parameters.Clear(); //Limpia los parametros, por si queda alguno en cache
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idCliente", idCliente);
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@ApellidoPa", ApellidoPa);
            comando.Parameters.AddWithValue("@ApellidoMa", ApellidoMa);
            comando.Parameters.AddWithValue("@NumeroTel", NumeroTel);
            comando.Parameters.AddWithValue("@Correo", Correo);
            comando.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
            comando.Parameters.AddWithValue("@numVisita", numVisita);
            comando.Parameters.AddWithValue("@TipoCliente", TipoCliente);
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
            comando.CommandText = "SP_catClientes"; //Nombre del PA
            comando.Parameters.Clear(); //Limpia los parametros, por si queda alguno en cache
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idCliente", idCliente);
            con.Open(); //Abre conexion
            comando.ExecuteNonQuery(); //Ejecuta cuando no es una consulta
            mensaje = "CAMPO ELIMINADO";

            con.Close();
            return mensaje;
        }
    }

}
