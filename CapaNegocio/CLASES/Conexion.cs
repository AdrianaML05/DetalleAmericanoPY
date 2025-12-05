using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.CLASES
{
    public class Conexion
    {
        //public string conexion = @"Data source= ELEAZARLAP\DETALLEAMERICANO;Initial Catalog= Detalle_Americano; user id = sa; password = nFbiTEr7sJG1f58X";
        public string conexion()
        {
            string conex = "";
            string ruta = @"D:\conexion\DetAm.txt";
            using (StreamReader file = new StreamReader(ruta))
            {
                conex = @"" + file.ReadToEnd();
                file.Close();
            }
            return conex;
        }
    }
}
