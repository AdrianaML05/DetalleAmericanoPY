using CapaNegocio.CLASES;
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

namespace CapaCliente.FORMULARIOS
{
    public partial class frmEstado : Form
    {
        private int idEstadoActual = 0;

        public frmEstado()
        {
            InitializeComponent();
        }

        private void frmEstado_Load(object sender, EventArgs e)
        {
            // Configurar txtID como solo lectura
            TXTID.ReadOnly = true;
            TXTID.Text = "Nuevo";
        }

        #region Botones

        // BUSCAR
        private void button3_Click(object sender, EventArgs e)
        {
            using (BUSQUEDAS.BusquedaEstado busqueda = new BUSQUEDAS.BusquedaEstado())
            {
                if (busqueda.ShowDialog() == DialogResult.OK && busqueda.DgEstados.CurrentRow != null)
                {
                    idEstadoActual = Convert.ToInt32(busqueda.DgEstados.CurrentRow.Cells["idEstado"].Value);
                    TXTID.Text = idEstadoActual.ToString();
                    TXTCODIGO.Text = busqueda.DgEstados.CurrentRow.Cells["Nombre"].Value.ToString();
                }
            }
        }

        // LIMPIAR
        private void button2_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        // GUARDAR
        private void button1_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        // ELIMINAR
        private void button4_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        // REGRESAR
        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Métodos

        private void Limpiar()
        {
            idEstadoActual = 0;
            TXTID.Text = "Nuevo";
            TXTCODIGO.Clear();
            TXTCODIGO.Focus();
        }

        private void Guardar()
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(TXTCODIGO.Text))
            {
                MessageBox.Show("Ingrese el nombre del estado.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTCODIGO.Focus();
                return;
            }

            // Crear objeto Estado
            Estado estado = new Estado();
            estado.idEstado = idEstadoActual;
            estado.Nombre = TXTCODIGO.Text.Trim();

            // Guardar
            string mensaje = estado.Guardar(estado);

            if (mensaje.Contains("Correctamente"))
            {
                MessageBox.Show(mensaje, "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Eliminar()
        {
            if (idEstadoActual == 0)
            {
                MessageBox.Show("Primero busque y seleccione un estado para eliminar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"¿Está seguro que desea eliminar el estado '{TXTCODIGO.Text}'?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Estado estado = new Estado();
                string mensaje = estado.Eliminar(idEstadoActual);

                if (mensaje.Contains("Correctamente"))
                {
                    MessageBox.Show(mensaje, "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }
}
