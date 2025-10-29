namespace CapaCliente.BUSQUEDAS
{
    partial class BusquedaPaqueteria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TXTFILTRO = new System.Windows.Forms.TextBox();
            this.BTNCANCELAR = new System.Windows.Forms.Button();
            this.BTNACEPTAR = new System.Windows.Forms.Button();
            this.BTNBUSCAR = new System.Windows.Forms.Button();
            this.DgPaqueteria = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DgPaqueteria)).BeginInit();
            this.SuspendLayout();
            // 
            // TXTFILTRO
            // 
            this.TXTFILTRO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.TXTFILTRO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTFILTRO.Location = new System.Drawing.Point(212, 67);
            this.TXTFILTRO.Multiline = true;
            this.TXTFILTRO.Name = "TXTFILTRO";
            this.TXTFILTRO.Size = new System.Drawing.Size(397, 37);
            this.TXTFILTRO.TabIndex = 43;
            this.TXTFILTRO.TextChanged += new System.EventHandler(this.TXTFILTRO_TextChanged);
            // 
            // BTNCANCELAR
            // 
            this.BTNCANCELAR.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNCANCELAR.Location = new System.Drawing.Point(806, 546);
            this.BTNCANCELAR.Name = "BTNCANCELAR";
            this.BTNCANCELAR.Size = new System.Drawing.Size(132, 48);
            this.BTNCANCELAR.TabIndex = 42;
            this.BTNCANCELAR.Text = "CANCELAR";
            this.BTNCANCELAR.UseVisualStyleBackColor = true;
            this.BTNCANCELAR.Click += new System.EventHandler(this.BTNCANCELAR_Click);
            // 
            // BTNACEPTAR
            // 
            this.BTNACEPTAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNACEPTAR.Location = new System.Drawing.Point(806, 475);
            this.BTNACEPTAR.Name = "BTNACEPTAR";
            this.BTNACEPTAR.Size = new System.Drawing.Size(130, 47);
            this.BTNACEPTAR.TabIndex = 41;
            this.BTNACEPTAR.Text = "ACEPTAR";
            this.BTNACEPTAR.UseVisualStyleBackColor = true;
            this.BTNACEPTAR.Click += new System.EventHandler(this.BTNACEPTAR_Click);
            // 
            // BTNBUSCAR
            // 
            this.BTNBUSCAR.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNBUSCAR.Location = new System.Drawing.Point(324, 131);
            this.BTNBUSCAR.Name = "BTNBUSCAR";
            this.BTNBUSCAR.Size = new System.Drawing.Size(163, 37);
            this.BTNBUSCAR.TabIndex = 40;
            this.BTNBUSCAR.Text = "BUSCAR";
            this.BTNBUSCAR.UseVisualStyleBackColor = true;
            this.BTNBUSCAR.Click += new System.EventHandler(this.BTNBUSCAR_Click);
            // 
            // DgPaqueteria
            // 
            this.DgPaqueteria.AllowUserToAddRows = false;
            this.DgPaqueteria.AllowUserToDeleteRows = false;
            this.DgPaqueteria.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.DgPaqueteria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgPaqueteria.Location = new System.Drawing.Point(23, 186);
            this.DgPaqueteria.Name = "DgPaqueteria";
            this.DgPaqueteria.ReadOnly = true;
            this.DgPaqueteria.RowHeadersWidth = 51;
            this.DgPaqueteria.RowTemplate.Height = 24;
            this.DgPaqueteria.Size = new System.Drawing.Size(747, 408);
            this.DgPaqueteria.TabIndex = 44;
            // 
            // BusquedaPaqueteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(209)))));
            this.ClientSize = new System.Drawing.Size(960, 660);
            this.Controls.Add(this.TXTFILTRO);
            this.Controls.Add(this.BTNCANCELAR);
            this.Controls.Add(this.BTNACEPTAR);
            this.Controls.Add(this.BTNBUSCAR);
            this.Controls.Add(this.DgPaqueteria);
            this.Name = "BusquedaPaqueteria";
            this.Text = "BusquedaPaqueteria";
            this.Load += new System.EventHandler(this.BusquedaPaqueteria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgPaqueteria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTFILTRO;
        private System.Windows.Forms.Button BTNCANCELAR;
        private System.Windows.Forms.Button BTNACEPTAR;
        private System.Windows.Forms.Button BTNBUSCAR;
        public System.Windows.Forms.DataGridView DgPaqueteria;
    }
}