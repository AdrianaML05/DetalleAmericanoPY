using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaNegocio.CLASES
{
    public class Empleados
    {
        static Conexion co = new Conexion();
        SqlConnection con = new SqlConnection(co.conexion()); //Trae todo lo que el metodo conexion contiene, permite la conexion BDD.
        SqlCommand comando = new SqlCommand();

        public int idEmpleados;
        public string Nombre, ApellidoPa, ApellidoMa, Telefono, Correo, RFC, CURP, Puesto;
        public bool encontro = false;

        public Empleados()
        {
            comando.Connection = con;
        }
        public Empleados(string sConexion)
        {
            con.ConnectionString = sConexion; //Asegura la comparacion de valores
            comando.Connection = con;
        }
        public string Guardar()
        {
            string mensaje = "";

            try
            {
                comando.CommandType = CommandType.StoredProcedure; //Confirma que los datos se obtendran de un PA
                comando.CommandText = "SP_catEmpleados"; //Nombre del PA
                comando.Parameters.Clear(); //Limpia los parametros, por si queda alguno en cache
                comando.Parameters.AddWithValue("@op", 1);
                comando.Parameters.AddWithValue("@idEmpleados", idEmpleados);
                comando.Parameters.AddWithValue("@Nombre", Nombre);
                comando.Parameters.AddWithValue("@ApellidoPa", ApellidoPa);
                comando.Parameters.AddWithValue("@ApellidoMa", ApellidoMa);
                comando.Parameters.AddWithValue("@Telefono", Telefono);
                comando.Parameters.AddWithValue("@Correo", Correo);
                comando.Parameters.AddWithValue("@RFC", RFC);
                comando.Parameters.AddWithValue("@CURP", CURP);
                comando.Parameters.AddWithValue("@Puesto", Puesto);
                con.Open(); //Abre conexion
                comando.ExecuteNonQuery(); //Ejecuta cuando no es una consulta
                mensaje = "Se Guardo el Registro Exitosamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error al guardar el registro: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
            return mensaje;


        }
        public void Eliminar()
        {

            try
            {
                comando.CommandType = CommandType.StoredProcedure; //Confirma que los datos se obtendran de un PA
                comando.CommandText = "SP_catEmpleados"; //Nombre del PA
                comando.Parameters.Clear(); //Limpia los parametros, por si queda alguno en cache
                comando.Parameters.AddWithValue("@op", 3);
                comando.Parameters.AddWithValue("@idEmpleados", idEmpleados);

                con.Open(); //Abre conexion
                comando.ExecuteNonQuery(); //Ejecuta cuando no es una consulta
                //mensaje = "CAMPO ELIMINADO";

            }
            catch (Exception)
            {
                
            }
            finally
            {
                con.Close();
            }



        }
        

    }
}
