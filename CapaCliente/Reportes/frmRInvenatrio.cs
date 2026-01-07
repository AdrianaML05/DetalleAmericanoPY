using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using CapaNegocio.CLASES;

namespace CapaCliente.Reportes
{
    public partial class frmRInvenatrio : Form
    {
        private static Conexion conexionDB = new Conexion();

        public frmRInvenatrio()
     {
   InitializeComponent();
      }

     private void frmRInvenatrio_Load(object sender, EventArgs e)
        {
            // Configurar el checkbox de Todos
   ckTodos.CheckedChanged += ckTodos_CheckedChanged;

      // Configurar el botón de búsqueda
            btnBuscar.Click += btnBuscar_Click;

    // Inicializar el ReportViewer vacío (sin cargar datos)
   InicializarReporteVacio();
   }

        private void InicializarReporteVacio()
        {
   try
      {
 // Buscar la ruta del reporte
          string rutaReporte = BuscarRutaReporte();

       if (!string.IsNullOrEmpty(rutaReporte))
             {
          // Configurar el ReportViewer con el reporte pero sin datos
   rvVenta.LocalReport.ReportPath = rutaReporte;
      rvVenta.LocalReport.DataSources.Clear();

           // Crear un DataTable vacío con la estructura correcta
       DataTable dtVacio = CrearEstructuraVacia();
         ReportDataSource rds = new ReportDataSource("RPInventario", dtVacio);
     rvVenta.LocalReport.DataSources.Add(rds);

     rvVenta.RefreshReport();
           }
    }
  catch (Exception)
     {
    // Si hay error, simplemente no mostrar nada
  }
        }

      private DataTable CrearEstructuraVacia()
        {
        DataTable dt = new DataTable();
            dt.Columns.Add("idInventario", typeof(int));
  dt.Columns.Add("idProducto", typeof(int));
            dt.Columns.Add("Producto", typeof(string));
          dt.Columns.Add("Stock", typeof(int));
        return dt;
        }

        private void ckTodos_CheckedChanged(object sender, EventArgs e)
        {
     // Habilitar/Deshabilitar controles de filtro según el checkbox
txtFolio.Enabled = !ckTodos.Checked;

            if (ckTodos.Checked)
            {
     txtFolio.Clear();
     // Cargar todos los registros automáticamente al marcar el checkbox
                CargarReporte(null, true);
   }
      else
            {
     // Si se desmarca, limpiar el reporte
        InicializarReporteVacio();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
          if (ckTodos.Checked)
{
        // Cargar todos los registros
      CargarReporte(null, true);
     }
            else
            {
    string producto = string.IsNullOrWhiteSpace(txtFolio.Text) ? null : txtFolio.Text.Trim();

   // Si hay producto, buscar por producto
                if (!string.IsNullOrEmpty(producto))
          {
          CargarReporte(producto, false);
       }
             else
        {
 // Si no hay filtro, mostrar todos
   CargarReporte(null, true);
              }
 }
     }

        private DataTable ObtenerDatosInventario()
        {
 DataTable dt = new DataTable();

            // Consulta con las columnas que existen en vw_Inventario
  string query = @"SELECT 
             idInventario, 
      idProducto, 
   Producto, 
     Stock 
       FROM dbo.vw_Inventario";

     using (SqlConnection con = new SqlConnection(conexionDB.conexion()))
            {
    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
        {
        da.Fill(dt);
                }
            }

        return dt;
        }

        private void CargarReporte(string producto, bool todos)
        {
 try
    {
 // Obtener los datos de la vista usando nuestra conexión
     DataTable datosCompletos = ObtenerDatosInventario();

           // Crear un DataTable para los datos filtrados
     DataTable datosFiltrados;

                if (todos)
        {
// Si es "Todos", usar todos los datos
           datosFiltrados = datosCompletos;
     }
           else if (!string.IsNullOrEmpty(producto))
     {
        // Filtrar por Producto
     DataView dv = new DataView(datosCompletos);
          dv.RowFilter = $"Producto LIKE '%{producto.Replace("'", "''")}%'";

        datosFiltrados = dv.ToTable();
  }
       else
         {
   datosFiltrados = datosCompletos;
     }

     // Verificar si hay datos
        if (datosFiltrados.Rows.Count == 0)
         {
     MessageBox.Show("No se encontraron registros con los criterios de búsqueda.",
      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
  }

        // Buscar la ruta del reporte
    string rutaReporte = BuscarRutaReporte();

            if (string.IsNullOrEmpty(rutaReporte))
       {
            MessageBox.Show("No se encontró el archivo del reporte RP_Inventario.rdlc",
             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         return;
                }

                // Configurar el ReportViewer
    rvVenta.LocalReport.ReportPath = rutaReporte;

                // Limpiar DataSources anteriores
           rvVenta.LocalReport.DataSources.Clear();

       // Agregar el DataSource con los datos filtrados
          ReportDataSource rds = new ReportDataSource("RPInventario", datosFiltrados);
       rvVenta.LocalReport.DataSources.Add(rds);

             // Refrescar el reporte
        rvVenta.RefreshReport();
   }
        catch (Exception ex)
     {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message, "Error",
 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string BuscarRutaReporte()
        {
       // Lista de posibles rutas donde puede estar el reporte
     string[] posiblesRutas = new string[]
          {
           System.IO.Path.Combine(Application.StartupPath, "RP_Inventario.rdlc"),
     System.IO.Path.Combine(Application.StartupPath, @"Reportes\RP_Inventario.rdlc"),
         System.IO.Path.Combine(Application.StartupPath, @"..\..\..\CapaNegocio\Reportes\RP_Inventario.rdlc"),
        System.IO.Path.Combine(Application.StartupPath, @"..\..\..\..\CapaNegocio\Reportes\RP_Inventario.rdlc"),
      @"D:\DetalleAmericano2.1\CapaNegocio\Reportes\RP_Inventario.rdlc"
            };

       foreach (string ruta in posiblesRutas)
      {
      string rutaCompleta = System.IO.Path.GetFullPath(ruta);
      if (System.IO.File.Exists(rutaCompleta))
      {
    return rutaCompleta;
         }
            }

    return null;
}
    }
}
