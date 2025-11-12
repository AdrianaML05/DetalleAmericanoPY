namespace CapaCliente.BUSQUEDAS
{
    partial class BusquedaEmpleados
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
            this.DgEmpleados = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DgEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // TXTFILTRO
            // 
            this.TXTFILTRO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.TXTFILTRO.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTFILTRO.Location = new System.Drawing.Point(221, 34);
            this.TXTFILTRO.Multiline = true;
            this.TXTFILTRO.Name = "TXTFILTRO";
            this.TXTFILTRO.Size = new System.Drawing.Size(397, 37);
            this.TXTFILTRO.TabIndex = 38;
            // 
            // BTNCANCELAR
            // 
            this.BTNCANCELAR.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNCANCELAR.Location = new System.Drawing.Point(815, 513);
            this.BTNCANCELAR.Name = "BTNCANCELAR";
            this.BTNCANCELAR.Size = new System.Drawing.Size(132, 48);
            this.BTNCANCELAR.TabIndex = 37;
            this.BTNCANCELAR.Text = "CANCELAR";
            this.BTNCANCELAR.UseVisualStyleBackColor = true;
            this.BTNCANCELAR.Click += new System.EventHandler(this.BTNCANCELAR_Click);
            // 
            // BTNACEPTAR
            // 
            this.BTNACEPTAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNACEPTAR.Location = new System.Drawing.Point(815, 442);
            this.BTNACEPTAR.Name = "BTNACEPTAR";
            this.BTNACEPTAR.Size = new System.Drawing.Size(130, 47);
            this.BTNACEPTAR.TabIndex = 36;
            this.BTNACEPTAR.Text = "ACEPTAR";
            this.BTNACEPTAR.UseVisualStyleBackColor = true;
            this.BTNACEPTAR.Click += new System.EventHandler(this.BTNACEPTAR_Click);
            // 
            // BTNBUSCAR
            // 
            this.BTNBUSCAR.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNBUSCAR.Location = new System.Drawing.Point(333, 98);
            this.BTNBUSCAR.Name = "BTNBUSCAR";
            this.BTNBUSCAR.Size = new System.Drawing.Size(163, 37);
            this.BTNBUSCAR.TabIndex = 35;
            this.BTNBUSCAR.Text = "BUSCAR";
            this.BTNBUSCAR.UseVisualStyleBackColor = true;
            this.BTNBUSCAR.Click += new System.EventHandler(this.BTNBUSCAR_Click);
            // 
            // DgEmpleados
            // 
            this.DgEmpleados.AllowUserToAddRows = false;
            this.DgEmpleados.AllowUserToDeleteRows = false;
            this.DgEmpleados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgEmpleados.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.DgEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgEmpleados.Location = new System.Drawing.Point(32, 153);
            this.DgEmpleados.Name = "DgEmpleados";
            this.DgEmpleados.ReadOnly = true;
            this.DgEmpleados.RowHeadersWidth = 51;
            this.DgEmpleados.RowTemplate.Height = 24;
            this.DgEmpleados.Size = new System.Drawing.Size(747, 408);
            this.DgEmpleados.TabIndex = 39;
            this.DgEmpleados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgEmpleados_CellClick);
            // 
            // BusquedaEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(209)))));
            this.ClientSize = new System.Drawing.Size(990, 617);
            this.Controls.Add(this.TXTFILTRO);
            this.Controls.Add(this.BTNCANCELAR);
            this.Controls.Add(this.BTNACEPTAR);
            this.Controls.Add(this.BTNBUSCAR);
            this.Controls.Add(this.DgEmpleados);
            this.Name = "BusquedaEmpleados";
            this.Text = "BusquedaEmpleados";
            this.Load += new System.EventHandler(this.BusquedaEmpleados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgEmpleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTFILTRO;
        private System.Windows.Forms.Button BTNCANCELAR;
        private System.Windows.Forms.Button BTNACEPTAR;
        private System.Windows.Forms.Button BTNBUSCAR;
        public System.Windows.Forms.DataGridView DgEmpleados;
    }
}