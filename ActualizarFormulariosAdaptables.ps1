# Script PowerShell para actualizar formularios a FormularioBase
# Ejecutar desde la raíz del proyecto: .\ActualizarFormulariosAdaptables.ps1

Write-Host "===========================================================" -ForegroundColor Cyan
Write-Host "  ACTUALIZADOR DE FORMULARIOS ADAPTABLES" -ForegroundColor Cyan
Write-Host "===========================================================" -ForegroundColor Cyan
Write-Host ""

# Ruta base del proyecto
$rutaBase = Get-Location

# Rutas de formularios
$rutaFormularios = Join-Path $rutaBase "CapaCliente\FORMULARIOS"
$rutaBusquedas = Join-Path $rutaBase "CapaCliente\BUSQUEDAS"

# Función para actualizar un archivo
function Actualizar-Formulario {
    param (
  [string]$rutaArchivo,
        [string]$nombreFormulario
    )
    
    if (Test-Path $rutaArchivo) {
        Write-Host "Procesando: $nombreFormulario..." -ForegroundColor Yellow
      
        # Leer contenido del archivo
        $contenido = Get-Content $rutaArchivo -Raw
        
    # Verificar si ya hereda de FormularioBase
        if ($contenido -match ":\s*FormularioBase") {
         Write-Host "  ? Ya usa FormularioBase" -ForegroundColor Green
      return
        }
        
        # Verificar si hereda de Form
        if ($contenido -match ":\s*Form\s*{") {
   # Reemplazar ": Form" por ": FormularioBase"
   $nuevoContenido = $contenido -replace "(public\s+partial\s+class\s+$nombreFormulario)\s*:\s*Form", '$1 : FormularioBase'
            
 # Guardar cambios
        Set-Content -Path $rutaArchivo -Value $nuevoContenido -Encoding UTF8
      
            Write-Host "  ? Actualizado a FormularioBase" -ForegroundColor Green
   } else {
     Write-Host "  ? No se pudo actualizar (formato no reconocido)" -ForegroundColor Red
 }
    } else {
   Write-Host "  ? Archivo no encontrado: $rutaArchivo" -ForegroundColor Red
    }
}

# Lista de formularios principales
$formulariosPrincipales = @(
    "frmVenta",
    "frmCobrar",
    "frmClientes",
    "frmCompra",
    "frmCompraDetalle",
    "frmDomicilios",
    "frmEmpleados",
    "frmEnvios",
    "frmEstado",
    "frmInventario",
    "frmMenu",
    "frmMotivoCancelacion",
    "frmMunicipio",
    "frmPaqueteria",
    "frmPedidos",
    "frmPedidoDetalle",
    "frmProductos",
    "frmProveedores"
)

# Lista de formularios de búsqueda
$formulariosBusqueda = @(
  "BusquedaClientes",
 "BusquedaDomicilios",
  "BusquedaEmpleados",
    "BusquedaEnvios",
    "BusquedaEstado",
    "BusquedaMunicipio",
    "BusquedaPaqueteria",
    "BusquedaProductos",
    "BusquedaProveedores"
)

Write-Host "Actualizando Formularios Principales..." -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan

foreach ($form in $formulariosPrincipales) {
    $archivo = Join-Path $rutaFormularios "$form.cs"
    Actualizar-Formulario -rutaArchivo $archivo -nombreFormulario $form
}

Write-Host ""
Write-Host "Actualizando Formularios de Búsqueda..." -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan

foreach ($form in $formulariosBusqueda) {
    $archivo = Join-Path $rutaBusquedas "$form.cs"
    Actualizar-Formulario -rutaArchivo $archivo -nombreFormulario $form
}

Write-Host ""
Write-Host "===========================================================" -ForegroundColor Cyan
Write-Host "  PROCESO COMPLETADO" -ForegroundColor Cyan
Write-Host "===========================================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "SIGUIENTE PASO:" -ForegroundColor Yellow
Write-Host "1. Compilar el proyecto en Visual Studio" -ForegroundColor White
Write-Host "2. Verificar que no haya errores" -ForegroundColor White
Write-Host "3. Probar cada formulario" -ForegroundColor White
Write-Host ""
Write-Host "Presiona cualquier tecla para salir..." -ForegroundColor Gray
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
