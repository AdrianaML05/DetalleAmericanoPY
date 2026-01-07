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
    public partial class frmRVenta : Form
    {
        private static Conexion conexionDB = new Conexion();

        public frmRVenta()
        {
            InitializeComponent();
        }

        private void frmRVenta_Load(object sender, EventArgs e)
        {
            // Configurar el checkbox de Todos
            ckTodos.CheckedChanged += ckTodos_CheckedChanged;

            // Configurar el botón de búsqueda
            btnBuscar.Click += btnBuscar_Click;

            // Inicializar fechas a hoy
            dtpFecha.Value = DateTime.Today;
            dtpFecha1.Value = DateTime.Today;

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
                    ReportDataSource rds = new ReportDataSource("RPVenta", dtVacio);
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
            dt.Columns.Add("idVenta", typeof(int));
            dt.Columns.Add("Folio", typeof(string));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("TotalVenta", typeof(decimal));
            dt.Columns.Add("Estatus", typeof(string));
            dt.Columns.Add("idEmpleados", typeof(int));
            dt.Columns.Add("NombreEmpleado", typeof(string));
            dt.Columns.Add("idCliente", typeof(int));
            dt.Columns.Add("NombreCliente", typeof(string));
            dt.Columns.Add("idProducto", typeof(int));
            dt.Columns.Add("NombreProducto", typeof(string));
            dt.Columns.Add("idVentaDetalle", typeof(int));
            dt.Columns.Add("CantidadProducto", typeof(int));
            dt.Columns.Add("PrecioProducto", typeof(decimal));
            dt.Columns.Add("subTotal", typeof(decimal));
            dt.Columns.Add("idFormaPago", typeof(int));
            dt.Columns.Add("FormaPago", typeof(string));
            return dt;
        }

        private void ckTodos_CheckedChanged(object sender, EventArgs e)
        {
            // Habilitar/Deshabilitar controles de filtro según el checkbox
            txtFolio.Enabled = !ckTodos.Checked;
            dtpFecha.Enabled = !ckTodos.Checked;
            dtpFecha1.Enabled = !ckTodos.Checked;

            if (ckTodos.Checked)
            {
                txtFolio.Clear();
                // Cargar todos los registros automáticamente al marcar el checkbox
                CargarReporte(null, null, null, true);
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
                CargarReporte(null, null, null, true);
            }
            else
            {
                string folio = string.IsNullOrWhiteSpace(txtFolio.Text) ? null : txtFolio.Text.Trim();

                // Si hay folio, buscar por folio
                if (!string.IsNullOrEmpty(folio))
                {
                    CargarReporte(folio, null, null, false);
                }
                else
                {
                    // Buscar por rango de fechas
                    DateTime fechaInicio = dtpFecha.Value.Date;
                    DateTime fechaFin = dtpFecha1.Value.Date;

                    // Validar que la fecha inicio no sea mayor que la fecha fin
                    if (fechaInicio > fechaFin)
                    {
                        MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha fin.",
    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    CargarReporte(null, fechaInicio, fechaFin, false);
                }
            }
        }

        private DataTable ObtenerDatosVentas()
        {
            DataTable dt = new DataTable();

            // Consulta con las columnas que existen en vw_Ventas
            string query = @"SELECT 
        idVenta, 
         Folio, 
            Fecha, 
        TotalVenta, 
      Estatus, 
    idCliente, 
       NombreCliente, 
        idEmpleados, 
         NombreEmpleado, 
        idFormaPago, 
           FormaPago, 
                idVentaDetalle, 
           idProducto, 
        NombreProducto, 
       CantidadProducto, 
       PrecioProducto, 
  subTotal 
            FROM dbo.vw_Ventas";

            using (SqlConnection con = new SqlConnection(conexionDB.conexion()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

        private void CargarReporte(string folio, DateTime? fechaInicio, DateTime? fechaFin, bool todos)
        {
            try
            {
                // Obtener los datos de la vista usando nuestra conexión
                DataTable datosCompletos = ObtenerDatosVentas();

                // Crear un DataTable para los datos filtrados
                DataTable datosFiltrados;

                if (todos)
                {
                    // Si es "Todos", usar todos los datos
                    datosFiltrados = datosCompletos;
                }
                else if (!string.IsNullOrEmpty(folio))
                {
                    // Filtrar por Folio
                    DataView dv = new DataView(datosCompletos);
                    dv.RowFilter = $"Folio LIKE '%{folio.Replace("'", "''")}%'";
                    datosFiltrados = dv.ToTable();
                }
                else if (fechaInicio.HasValue && fechaFin.HasValue)
                {
                    // Filtrar por rango de fechas
                    DataView dv = new DataView(datosCompletos);
                    dv.RowFilter = $"Fecha >= '{fechaInicio.Value:yyyy-MM-dd}' AND Fecha < '{fechaFin.Value.AddDays(1):yyyy-MM-dd}'";
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
                    MessageBox.Show("No se encontró el archivo del reporte RP_Venta.rdlc",
"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Configurar el ReportViewer
                rvVenta.LocalReport.ReportPath = rutaReporte;

                // Limpiar DataSources anteriores
                rvVenta.LocalReport.DataSources.Clear();

                // Agregar el DataSource con los datos filtrados
                ReportDataSource rds = new ReportDataSource("RPVenta", datosFiltrados);
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
                System.IO.Path.Combine(Application.StartupPath, "RP_Venta.rdlc"),
    System.IO.Path.Combine(Application.StartupPath, @"Reportes\RP_Venta.rdlc"),
          System.IO.Path.Combine(Application.StartupPath, @"..\..\..\CapaNegocio\Reportes\RP_Venta.rdlc"),
             System.IO.Path.Combine(Application.StartupPath, @"..\..\..\..\CapaNegocio\Reportes\RP_Venta.rdlc"),
   @"D:\DetalleAmericano2.1\CapaNegocio\Reportes\RP_Venta.rdlc"
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
