namespace CapaCliente.BUSQUEDAS
{
    partial class BusquedaPedido
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
            this.label1 = new System.Windows.Forms.Label();
            this.BTNCANCELAR = new System.Windows.Forms.Button();
            this.BTNACEPTAR = new System.Windows.Forms.Button();
            this.TXTFILTRO = new System.Windows.Forms.TextBox();
            this.BTNBUSCAR = new System.Windows.Forms.Button();
            this.DgPedidos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DgPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(37, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 24);
            this.label1.TabIndex = 53;
            this.label1.Text = "BUSCAR POR FOLIO:";
            // 
            // BTNCANCELAR
            // 
            this.BTNCANCELAR.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNCANCELAR.Location = new System.Drawing.Point(648, 523);
            this.BTNCANCELAR.Name = "BTNCANCELAR";
            this.BTNCANCELAR.Size = new System.Drawing.Size(136, 37);
            this.BTNCANCELAR.TabIndex = 52;
            this.BTNCANCELAR.Text = "CANCELAR";
            this.BTNCANCELAR.UseVisualStyleBackColor = true;
            this.BTNCANCELAR.Click += new System.EventHandler(this.BTNCANCELAR_Click);
            // 
            // BTNACEPTAR
            // 
            this.BTNACEPTAR.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNACEPTAR.Location = new System.Drawing.Point(506, 523);
            this.BTNACEPTAR.Name = "BTNACEPTAR";
            this.BTNACEPTAR.Size = new System.Drawing.Size(136, 37);
            this.BTNACEPTAR.TabIndex = 51;
            this.BTNACEPTAR.Text = "ACEPTAR";
            this.BTNACEPTAR.UseVisualStyleBackColor = true;
            this.BTNACEPTAR.Click += new System.EventHandler(this.BTNACEPTAR_Click);
            // 
            // TXTFILTRO
            // 
            this.TXTFILTRO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.TXTFILTRO.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTFILTRO.Location = new System.Drawing.Point(291, 34);
            this.TXTFILTRO.Multiline = true;
            this.TXTFILTRO.Name = "TXTFILTRO";
            this.TXTFILTRO.Size = new System.Drawing.Size(314, 30);
            this.TXTFILTRO.TabIndex = 49;
            this.TXTFILTRO.TextChanged += new System.EventHandler(this.TXTFILTRO_TextChanged);
            // 
            // BTNBUSCAR
            // 
            this.BTNBUSCAR.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNBUSCAR.Location = new System.Drawing.Point(648, 31);
            this.BTNBUSCAR.Name = "BTNBUSCAR";
            this.BTNBUSCAR.Size = new System.Drawing.Size(136, 37);
            this.BTNBUSCAR.TabIndex = 48;
            this.BTNBUSCAR.Text = "BUSCAR";
            this.BTNBUSCAR.UseVisualStyleBackColor = true;
            this.BTNBUSCAR.Click += new System.EventHandler(this.BTNBUSCAR_Click);
            // 
            // DgPedidos
            // 
            this.DgPedidos.AllowUserToAddRows = false;
            this.DgPedidos.AllowUserToDeleteRows = false;
            this.DgPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgPedidos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.DgPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgPedidos.Location = new System.Drawing.Point(37, 93);
            this.DgPedidos.MultiSelect = false;
            this.DgPedidos.Name = "DgPedidos";
            this.DgPedidos.ReadOnly = true;
            this.DgPedidos.RowHeadersVisible = false;
            this.DgPedidos.RowHeadersWidth = 51;
            this.DgPedidos.RowTemplate.Height = 24;
            this.DgPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgPedidos.Size = new System.Drawing.Size(747, 408);
            this.DgPedidos.TabIndex = 50;
            this.DgPedidos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgPedidos_CellClick);
            this.DgPedidos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgPedidos_CellDoubleClick);
            // 
            // BusquedaPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(209)))));
            this.ClientSize = new System.Drawing.Size(820, 590);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTNCANCELAR);
            this.Controls.Add(this.BTNACEPTAR);
            this.Controls.Add(this.TXTFILTRO);
            this.Controls.Add(this.BTNBUSCAR);
            this.Controls.Add(this.DgPedidos);
            this.Name = "BusquedaPedido";
            this.Text = "Búsqueda de Pedidos";
            this.Load += new System.EventHandler(this.BusquedaPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNCANCELAR;
        private System.Windows.Forms.Button BTNACEPTAR;
        private System.Windows.Forms.TextBox TXTFILTRO;
        private System.Windows.Forms.Button BTNBUSCAR;
        public System.Windows.Forms.DataGridView DgPedidos;
    }
}