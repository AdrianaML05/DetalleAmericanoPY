namespace CapaCliente.BUSQUEDAS
{
    partial class BusquedaProveedores
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
            this.DgProveedores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DgProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // TXTFILTRO
            // 
            this.TXTFILTRO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.TXTFILTRO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTFILTRO.Location = new System.Drawing.Point(217, 72);
            this.TXTFILTRO.Multiline = true;
            this.TXTFILTRO.Name = "TXTFILTRO";
            this.TXTFILTRO.Size = new System.Drawing.Size(397, 37);
            this.TXTFILTRO.TabIndex = 43;
            this.TXTFILTRO.TextChanged += new System.EventHandler(this.TXTFILTRO_TextChanged);
            // 
            // BTNCANCELAR
            // 
            this.BTNCANCELAR.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNCANCELAR.Location = new System.Drawing.Point(811, 551);
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
            this.BTNACEPTAR.Location = new System.Drawing.Point(811, 480);
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
            this.BTNBUSCAR.Location = new System.Drawing.Point(329, 136);
            this.BTNBUSCAR.Name = "BTNBUSCAR";
            this.BTNBUSCAR.Size = new System.Drawing.Size(163, 37);
            this.BTNBUSCAR.TabIndex = 40;
            this.BTNBUSCAR.Text = "BUSCAR";
            this.BTNBUSCAR.UseVisualStyleBackColor = true;
            this.BTNBUSCAR.Click += new System.EventHandler(this.BTNBUSCAR_Click);
            // 
            // DgProveedores
            // 
            this.DgProveedores.AllowUserToAddRows = false;
            this.DgProveedores.AllowUserToDeleteRows = false;
            this.DgProveedores.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.DgProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgProveedores.Location = new System.Drawing.Point(28, 191);
            this.DgProveedores.Name = "DgProveedores";
            this.DgProveedores.ReadOnly = true;
            this.DgProveedores.RowHeadersWidth = 51;
            this.DgProveedores.RowTemplate.Height = 24;
            this.DgProveedores.Size = new System.Drawing.Size(747, 408);
            this.DgProveedores.TabIndex = 44;
            // 
            // BusquedaProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(209)))));
            this.ClientSize = new System.Drawing.Size(971, 628);
            this.Controls.Add(this.TXTFILTRO);
            this.Controls.Add(this.BTNCANCELAR);
            this.Controls.Add(this.BTNACEPTAR);
            this.Controls.Add(this.BTNBUSCAR);
            this.Controls.Add(this.DgProveedores);
            this.Name = "BusquedaProveedores";
            this.Text = "BusquedaProveedores";
            this.Load += new System.EventHandler(this.BusquedaProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgProveedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTFILTRO;
        private System.Windows.Forms.Button BTNCANCELAR;
        private System.Windows.Forms.Button BTNACEPTAR;
        private System.Windows.Forms.Button BTNBUSCAR;
        public System.Windows.Forms.DataGridView DgProveedores;
    }
}