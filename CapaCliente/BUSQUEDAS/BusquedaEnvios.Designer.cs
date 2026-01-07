namespace CapaCliente.BUSQUEDAS
{
    partial class BusquedaEnvios
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.BTNBUSCAR = new System.Windows.Forms.Button();
            this.DgProductos = new System.Windows.Forms.DataGridView();
            this.rbCancelado = new System.Windows.Forms.RadioButton();
            this.rbEntrega = new System.Windows.Forms.RadioButton();
            this.rbTransito = new System.Windows.Forms.RadioButton();
            this.rbPendiente = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.DgProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // TXTFILTRO
            // 
            this.TXTFILTRO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.TXTFILTRO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTFILTRO.Location = new System.Drawing.Point(260, 41);
            this.TXTFILTRO.Multiline = true;
            this.TXTFILTRO.Name = "TXTFILTRO";
            this.TXTFILTRO.Size = new System.Drawing.Size(247, 37);
            this.TXTFILTRO.TabIndex = 38;
            this.TXTFILTRO.TextChanged += new System.EventHandler(this.TXTFILTRO_TextChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(808, 523);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(132, 48);
            this.btnCancelar.TabIndex = 37;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(808, 452);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(130, 47);
            this.btnAceptar.TabIndex = 36;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // BTNBUSCAR
            // 
            this.BTNBUSCAR.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNBUSCAR.Location = new System.Drawing.Point(561, 41);
            this.BTNBUSCAR.Name = "BTNBUSCAR";
            this.BTNBUSCAR.Size = new System.Drawing.Size(163, 37);
            this.BTNBUSCAR.TabIndex = 35;
            this.BTNBUSCAR.Text = "BUSCAR";
            this.BTNBUSCAR.UseVisualStyleBackColor = true;
            this.BTNBUSCAR.Click += new System.EventHandler(this.BTNBUSCAR_Click);
            // 
            // DgProductos
            // 
            this.DgProductos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.DgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgProductos.Location = new System.Drawing.Point(25, 163);
            this.DgProductos.Name = "DgProductos";
            this.DgProductos.RowHeadersWidth = 51;
            this.DgProductos.RowTemplate.Height = 24;
            this.DgProductos.Size = new System.Drawing.Size(747, 408);
            this.DgProductos.TabIndex = 39;
            this.DgProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgProductos_CellDoubleClick);
            // 
            // rbCancelado
            // 
            this.rbCancelado.AutoSize = true;
            this.rbCancelado.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCancelado.Location = new System.Drawing.Point(522, 114);
            this.rbCancelado.Name = "rbCancelado";
            this.rbCancelado.Size = new System.Drawing.Size(130, 28);
            this.rbCancelado.TabIndex = 163;
            this.rbCancelado.TabStop = true;
            this.rbCancelado.Text = "Cancelado";
            this.rbCancelado.UseVisualStyleBackColor = true;
            // 
            // rbEntrega
            // 
            this.rbEntrega.AutoSize = true;
            this.rbEntrega.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEntrega.Location = new System.Drawing.Point(378, 113);
            this.rbEntrega.Name = "rbEntrega";
            this.rbEntrega.Size = new System.Drawing.Size(129, 28);
            this.rbEntrega.TabIndex = 162;
            this.rbEntrega.TabStop = true;
            this.rbEntrega.Text = "Entregado";
            this.rbEntrega.UseVisualStyleBackColor = true;
            // 
            // rbTransito
            // 
            this.rbTransito.AutoSize = true;
            this.rbTransito.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTransito.Location = new System.Drawing.Point(227, 113);
            this.rbTransito.Name = "rbTransito";
            this.rbTransito.Size = new System.Drawing.Size(135, 28);
            this.rbTransito.TabIndex = 161;
            this.rbTransito.TabStop = true;
            this.rbTransito.Text = "En tránsito";
            this.rbTransito.UseVisualStyleBackColor = true;
            // 
            // rbPendiente
            // 
            this.rbPendiente.AutoSize = true;
            this.rbPendiente.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPendiente.Location = new System.Drawing.Point(87, 113);
            this.rbPendiente.Name = "rbPendiente";
            this.rbPendiente.Size = new System.Drawing.Size(125, 28);
            this.rbPendiente.TabIndex = 160;
            this.rbPendiente.TabStop = true;
            this.rbPendiente.Text = "Pendiente";
            this.rbPendiente.UseVisualStyleBackColor = true;
            // 
            // BusquedaEnvios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(209)))));
            this.ClientSize = new System.Drawing.Size(958, 599);
            this.Controls.Add(this.rbCancelado);
            this.Controls.Add(this.rbEntrega);
            this.Controls.Add(this.rbTransito);
            this.Controls.Add(this.rbPendiente);
            this.Controls.Add(this.TXTFILTRO);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.BTNBUSCAR);
            this.Controls.Add(this.DgProductos);
            this.Name = "BusquedaEnvios";
            this.Text = "BusquedaEnvios";
            this.Load += new System.EventHandler(this.BusquedaEnvios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTFILTRO;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button BTNBUSCAR;
        public System.Windows.Forms.DataGridView DgProductos;
        private System.Windows.Forms.RadioButton rbCancelado;
        private System.Windows.Forms.RadioButton rbEntrega;
        private System.Windows.Forms.RadioButton rbTransito;
        private System.Windows.Forms.RadioButton rbPendiente;
    }
}