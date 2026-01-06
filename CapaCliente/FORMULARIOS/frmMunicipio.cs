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
    public partial class frmMunicipio : Form
    {
        private int idMunicipioActual = 0;

        public frmMunicipio()
        {
            InitializeComponent();
        }

        private void frmMunicipio_Load(object sender, EventArgs e)
        {
            // Configurar txtID como solo lectura
            TXTID.ReadOnly = true;
            TXTID.Text = "Nuevo";

            // Cargar estados en el ComboBox
            CargarEstados();
        }

        private void CargarEstados()
        {
            Municipio mun = new Municipio();
            DataTable dt = mun.ObtenerEstados();

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "idEstado";

            if (dt.Rows.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        #region Botones

        // BUSCAR
        private void button3_Click(object sender, EventArgs e)
        {
            using (BUSQUEDAS.BusquedaMunicipio busqueda = new BUSQUEDAS.BusquedaMunicipio())
            {
                if (busqueda.ShowDialog() == DialogResult.OK && busqueda.DgMunicipios.CurrentRow != null)
                {
                    idMunicipioActual = Convert.ToInt32(busqueda.DgMunicipios.CurrentRow.Cells["idMunicipio"].Value);
                    TXTID.Text = idMunicipioActual.ToString();
                    TXTCODIGO.Text = busqueda.DgMunicipios.CurrentRow.Cells["Nombre"].Value.ToString();

                    // Seleccionar el estado correspondiente
                    int idEstado = Convert.ToInt32(busqueda.DgMunicipios.CurrentRow.Cells["idEstado"].Value);
                    comboBox1.SelectedValue = idEstado;
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
            idMunicipioActual = 0;
            TXTID.Text = "Nuevo";
            TXTCODIGO.Clear();

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            TXTCODIGO.Focus();
        }

        private void Guardar()
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(TXTCODIGO.Text))
            {
                MessageBox.Show("Ingrese el nombre del municipio.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTCODIGO.Focus();
                return;
            }

            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un estado.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                return;
            }

            // Crear objeto Municipio
            Municipio municipio = new Municipio();
            municipio.idMunicipio = idMunicipioActual;
            municipio.Nombre = TXTCODIGO.Text.Trim();
            municipio.idEstado = Convert.ToInt32(comboBox1.SelectedValue);

            // Guardar
            string mensaje = municipio.Guardar(municipio);

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
            if (idMunicipioActual == 0)
            {
                MessageBox.Show("Primero busque y seleccione un municipio para eliminar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"¿Está seguro que desea eliminar el municipio '{TXTCODIGO.Text}'?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Municipio municipio = new Municipio();
                string mensaje = municipio.Eliminar(idMunicipioActual);

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
