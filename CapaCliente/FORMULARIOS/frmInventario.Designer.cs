namespace CapaCliente.FORMULARIOS
{
    partial class frmInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventario));
            this.TXTID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnProducto = new System.Windows.Forms.ComboBox();
            this.ckBago = new System.Windows.Forms.CheckBox();
            this.skSin = new System.Windows.Forms.CheckBox();
            this.dgInventario = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // TXTID
            // 
            this.TXTID.Location = new System.Drawing.Point(194, 111);
            this.TXTID.Multiline = true;
            this.TXTID.Name = "TXTID";
            this.TXTID.Size = new System.Drawing.Size(172, 36);
            this.TXTID.TabIndex = 139;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Swis721 Hv BT", 13.8F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.label4.Location = new System.Drawing.Point(72, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 27);
            this.label4.TabIndex = 138;
            this.label4.Text = "Codigo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Swis721 Hv BT", 13.8F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.label1.Location = new System.Drawing.Point(72, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 27);
            this.label1.TabIndex = 137;
            this.label1.Text = "Filtrar por:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(193, 878);
            this.panel2.TabIndex = 175;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Transparent;
            this.button9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button9.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Clarendon BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.button9.Image = ((System.Drawing.Image)(resources.GetObject("button9.Image")));
            this.button9.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button9.Location = new System.Drawing.Point(0, 763);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(193, 115);
            this.button9.TabIndex = 145;
            this.button9.Text = "REGRESAR";
            this.button9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.dgInventario);
            this.panel1.Controls.Add(this.skSin);
            this.panel1.Controls.Add(this.ckBago);
            this.panel1.Controls.Add(this.btnProducto);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TXTID);
            this.panel1.Location = new System.Drawing.Point(241, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1177, 650);
            this.panel1.TabIndex = 176;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("News706 BT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.label3.Location = new System.Drawing.Point(761, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 36);
            this.label3.TabIndex = 177;
            this.label3.Text = "INVENTARIO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Swis721 Hv BT", 13.8F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.label5.Location = new System.Drawing.Point(72, 35);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(275, 27);
            this.label5.TabIndex = 144;
            this.label5.Text = "BÚSQUEDA Y FILTROS";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::CapaCliente.Properties.Resources.lupa;
            this.btnBuscar.Location = new System.Drawing.Point(400, 103);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 57);
            this.btnBuscar.TabIndex = 153;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnProducto
            // 
            this.btnProducto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducto.FormattingEnabled = true;
            this.btnProducto.Location = new System.Drawing.Point(221, 195);
            this.btnProducto.Name = "btnProducto";
            this.btnProducto.Size = new System.Drawing.Size(170, 31);
            this.btnProducto.TabIndex = 154;
            // 
            // ckBago
            // 
            this.ckBago.AutoSize = true;
            this.ckBago.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckBago.Location = new System.Drawing.Point(447, 199);
            this.ckBago.Name = "ckBago";
            this.ckBago.Size = new System.Drawing.Size(125, 27);
            this.ckBago.TabIndex = 155;
            this.ckBago.Text = "Stock bajo";
            this.ckBago.UseVisualStyleBackColor = true;
            // 
            // skSin
            // 
            this.skSin.AutoSize = true;
            this.skSin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skSin.Location = new System.Drawing.Point(590, 200);
            this.skSin.Name = "skSin";
            this.skSin.Size = new System.Drawing.Size(112, 27);
            this.skSin.TabIndex = 156;
            this.skSin.Text = "Sin stock";
            this.skSin.UseVisualStyleBackColor = true;
            // 
            // dgInventario
            // 
            this.dgInventario.AllowUserToAddRows = false;
            this.dgInventario.AllowUserToDeleteRows = false;
            this.dgInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInventario.Location = new System.Drawing.Point(79, 273);
            this.dgInventario.Name = "dgInventario";
            this.dgInventario.ReadOnly = true;
            this.dgInventario.RowHeadersWidth = 51;
            this.dgInventario.RowTemplate.Height = 24;
            this.dgInventario.Size = new System.Drawing.Size(1041, 216);
            this.dgInventario.TabIndex = 157;
            // 
            // frmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(26)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(1470, 878);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmInventario";
            this.Text = "frmInventario";
            this.Load += new System.EventHandler(this.frmInventario_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInventario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TXTID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.CheckBox skSin;
        private System.Windows.Forms.CheckBox ckBago;
        private System.Windows.Forms.ComboBox btnProducto;
        private System.Windows.Forms.DataGridView dgInventario;
    }
}