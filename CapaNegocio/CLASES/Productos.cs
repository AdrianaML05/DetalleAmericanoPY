using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.CLASES
{
    public class Productos
    {
        static Conexion co = new Conexion();
        SqlConnection con = new SqlConnection(co.conexion()); //Trae todo lo que el metodo conexion contiene, permite la conexion BDD.
        SqlCommand comando = new SqlCommand();

        public int idProducto;
        public string Codigo, Nombre, Tipo, Descripcion;
        public decimal PrecioVenta, PrecioCompra;

        public Productos()
        {
            comando.Connection = con;
        }
        public string Guardar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure; //Confirma que los datos se obtendran de un PA
            comando.CommandText = "SP_catProductos"; //Nombre del PA
            comando.Parameters.Clear(); //Limpia los parametros, por si queda alguno en cache
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idProducto", idProducto);
            comando.Parameters.AddWithValue("@Codigo", Codigo);
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@PrecioVenta", PrecioVenta);
            comando.Parameters.AddWithValue("@PrecioCompra", PrecioCompra);
            comando.Parameters.AddWithValue("@Tipo", Tipo);
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);
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
            comando.CommandText = "SP_catProductos"; //Nombre del PA
            comando.Parameters.Clear(); //Limpia los parametros, por si queda alguno en cache
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idProducto", idProducto);
            con.Open(); //Abre conexion
            comando.ExecuteNonQuery(); //Ejecuta cuando no es una consulta
            mensaje = "CAMPO ELIMINADO";

            con.Close();
            return mensaje;
        }
    }
}
