using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaCliente.FORMULARIOS
{
    /// <summary>
    /// Clase base para todos los formularios del proyecto
  /// Proporciona funcionalidad de adaptación automática a diferentes tamaños de pantalla
    /// </summary>
    public class FormularioBase : Form
    {
        // Tamaño original del formulario en tiempo de diseño
        private Size tamanoOriginal;
        private Rectangle rectanguloOriginal;
        
     // Factor de escala para controles
        private float factorEscalaX;
        private float factorEscalaY;

  public FormularioBase()
        {
    // Configurar eventos
        this.Load += FormularioBase_Load;
    this.Resize += FormularioBase_Resize;
     
      // Configurar propiedades base
    this.AutoScaleMode = AutoScaleMode.Font;
this.StartPosition = FormStartPosition.CenterScreen;
        }

    private void FormularioBase_Load(object sender, EventArgs e)
        {
            // Guardar tamaño original del formulario
            tamanoOriginal = this.ClientSize;
   rectanguloOriginal = new Rectangle(this.Location, this.Size);
       
     // Calcular factores de escala iniciales
      factorEscalaX = 1.0f;
            factorEscalaY = 1.0f;
  
            // Guardar posiciones originales de todos los controles
        GuardarPosicionesOriginales(this);
    
    // Aplicar configuración de pantalla
            AjustarAPantalla();
 }

        private void FormularioBase_Resize(object sender, EventArgs e)
        {
       if (tamanoOriginal.Width > 0 && tamanoOriginal.Height > 0)
        {
     // Calcular nuevos factores de escala
      factorEscalaX = (float)this.ClientSize.Width / tamanoOriginal.Width;
           factorEscalaY = (float)this.ClientSize.Height / tamanoOriginal.Height;
            
      // Redimensionar todos los controles
         RedimensionarControles(this);
   }
        }

        /// <summary>
     /// Guarda las posiciones y tamaños originales de todos los controles
   /// </summary>
  private void GuardarPosicionesOriginales(Control contenedor)
        {
          foreach (Control control in contenedor.Controls)
   {
     // Guardar posición y tamaño original en el Tag del control
  if (control.Tag == null || !(control.Tag is Rectangle))
    {
       control.Tag = new Rectangle(control.Location, control.Size);
              }
           
          // Si el control tiene controles hijos, procesarlos recursivamente
                if (control.HasChildren)
     {
     GuardarPosicionesOriginales(control);
 }
  }
        }

        /// <summary>
        /// Redimensiona todos los controles según los factores de escala
     /// </summary>
        private void RedimensionarControles(Control contenedor)
    {
            foreach (Control control in contenedor.Controls)
          {
    // Obtener rectángulo original del control
      if (control.Tag is Rectangle rectanguloOriginal)
         {
   // Calcular nueva posición y tamaño
          int nuevoX = (int)(rectanguloOriginal.X * factorEscalaX);
   int nuevoY = (int)(rectanguloOriginal.Y * factorEscalaY);
   int nuevoAncho = (int)(rectanguloOriginal.Width * factorEscalaX);
   int nuevoAlto = (int)(rectanguloOriginal.Height * factorEscalaY);
         
    // Aplicar nueva posición y tamaño
 control.Location = new Point(nuevoX, nuevoY);
        control.Size = new Size(nuevoAncho, nuevoAlto);
            
  // Ajustar tamaño de fuente proporcionalmente
        AjustarFuente(control);
        }
           
         // Si el control tiene controles hijos, procesarlos recursivamente
          if (control.HasChildren)
   {
                RedimensionarControles(control);
        }
 }
        }

        /// <summary>
     /// Ajusta el tamaño de fuente del control según el factor de escala
      /// </summary>
        private void AjustarFuente(Control control)
        {
      if (control.Font != null)
        {
   // Calcular factor de escala promedio
      float factorEscalaPromedio = (factorEscalaX + factorEscalaY) / 2;
       
    // Evitar fuentes demasiado pequeñas o grandes
      float nuevoTamanoFuente = control.Font.Size * factorEscalaPromedio;
                
     // Limitar tamaño de fuente
                if (nuevoTamanoFuente < 6f) nuevoTamanoFuente = 6f;
      if (nuevoTamanoFuente > 72f) nuevoTamanoFuente = 72f;
                
      try
        {
       control.Font = new Font(control.Font.FontFamily, nuevoTamanoFuente, control.Font.Style);
         }
    catch
      {
   // Si falla, mantener fuente original
      }
         }
   }

        /// <summary>
        /// Ajusta el formulario al tamaño de la pantalla
        /// </summary>
        private void AjustarAPantalla()
        {
      // Obtener tamaño de pantalla de trabajo (sin barra de tareas)
    Rectangle areaTrabajoScreen = Screen.FromControl(this).WorkingArea;
 
        // Calcular tamaño máximo (90% de la pantalla)
            int anchoMaximo = (int)(areaTrabajoScreen.Width * 0.9);
       int altoMaximo = (int)(areaTrabajoScreen.Height * 0.9);
     
            // Si el formulario es más grande que el área de trabajo, ajustarlo
            if (this.Width > anchoMaximo || this.Height > altoMaximo)
            {
         // Mantener proporción del formulario
      float proporcion = (float)this.Width / this.Height;
     
          if (this.Width > anchoMaximo)
         {
                this.Width = anchoMaximo;
    this.Height = (int)(anchoMaximo / proporcion);
          }
             
   if (this.Height > altoMaximo)
       {
 this.Height = altoMaximo;
      this.Width = (int)(altoMaximo * proporcion);
       }
     }
            
   // Centrar formulario
            this.StartPosition = FormStartPosition.CenterScreen;
    }

        /// <summary>
        /// Establece un tamaño mínimo personalizado para el formulario
        /// </summary>
        protected void EstablecerTamanoMinimo(int ancho, int alto)
        {
            this.MinimumSize = new Size(ancho, alto);
      }

        /// <summary>
        /// Permite maximizar el formulario adaptándose a la pantalla
      /// </summary>
        protected void HabilitarMaximizar()
 {
          this.MaximizeBox = true;
        this.FormBorderStyle = FormBorderStyle.Sizable;
        }

      /// <summary>
    /// Deshabilita el cambio de tamaño del formulario
        /// </summary>
    protected void DeshabilitarRedimensionar()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }
    }
}
