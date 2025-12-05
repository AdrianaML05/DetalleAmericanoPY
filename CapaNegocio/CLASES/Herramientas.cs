using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.CLASES
{
    public class Herramientas
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        public Herramientas()
        {
            con.ConnectionString = x.conexion();
        }
        public int consecutivo(string campo, string tabla)
        {
            int id = 0;
            string consulta = $"select isnull(max({campo})+1,1) as maxid from {tabla}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader lector = cmd.ExecuteReader();
            if (lector.Read())
            {
                id = int.Parse(lector["maxid"].ToString());
            }
            con.Close();
            return id;
        }
    }
}
