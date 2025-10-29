namespace CapaCliente.FORMULARIOS
{
    partial class frmPaqueteria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPaqueteria));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.BTNGUARDAR = new System.Windows.Forms.ToolStripMenuItem();
            this.BTNBUSCAR = new System.Windows.Forms.ToolStripMenuItem();
            this.BTNLIMPIAR = new System.Windows.Forms.ToolStripMenuItem();
            this.BTNELIMINAR = new System.Windows.Forms.ToolStripMenuItem();
            this.TXTTELEFONO = new System.Windows.Forms.TextBox();
            this.TXTCALLE = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.TXTNOMBRE = new System.Windows.Forms.TextBox();
            this.TXTID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TXTNUMEXTERIOR = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TXTNUMINTERIOR = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TXTREFERENCIAS = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNGUARDAR,
            this.BTNBUSCAR,
            this.BTNLIMPIAR,
            this.BTNELIMINAR});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(751, 36);
            this.menuStrip1.TabIndex = 120;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // BTNGUARDAR
            // 
            this.BTNGUARDAR.Image = global::CapaCliente.Properties.Resources.disco_flexible;
            this.BTNGUARDAR.Name = "BTNGUARDAR";
            this.BTNGUARDAR.Size = new System.Drawing.Size(143, 32);
            this.BTNGUARDAR.Text = "GUARDAR";
            this.BTNGUARDAR.Click += new System.EventHandler(this.BTNGUARDAR_Click);
            // 
            // BTNBUSCAR
            // 
            this.BTNBUSCAR.Image = global::CapaCliente.Properties.Resources.lupa__1_;
            this.BTNBUSCAR.Name = "BTNBUSCAR";
            this.BTNBUSCAR.Size = new System.Drawing.Size(123, 32);
            this.BTNBUSCAR.Text = "BUSCAR";
            this.BTNBUSCAR.Click += new System.EventHandler(this.BTNBUSCAR_Click);
            // 
            // BTNLIMPIAR
            // 
            this.BTNLIMPIAR.Image = global::CapaCliente.Properties.Resources.limpiar;
            this.BTNLIMPIAR.Name = "BTNLIMPIAR";
            this.BTNLIMPIAR.Size = new System.Drawing.Size(126, 32);
            this.BTNLIMPIAR.Text = "LIMPIAR";
            this.BTNLIMPIAR.Click += new System.EventHandler(this.BTNLIMPIAR_Click);
            // 
            // BTNELIMINAR
            // 
            this.BTNELIMINAR.Image = global::CapaCliente.Properties.Resources.eliminar;
            this.BTNELIMINAR.Name = "BTNELIMINAR";
            this.BTNELIMINAR.Size = new System.Drawing.Size(141, 32);
            this.BTNELIMINAR.Text = "ELIMINAR";
            this.BTNELIMINAR.Click += new System.EventHandler(this.BTNELIMINAR_Click);
            // 
            // TXTTELEFONO
            // 
            this.TXTTELEFONO.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTTELEFONO.Location = new System.Drawing.Point(312, 380);
            this.TXTTELEFONO.Multiline = true;
            this.TXTTELEFONO.Name = "TXTTELEFONO";
            this.TXTTELEFONO.Size = new System.Drawing.Size(339, 34);
            this.TXTTELEFONO.TabIndex = 161;
            // 
            // TXTCALLE
            // 
            this.TXTCALLE.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTCALLE.Location = new System.Drawing.Point(312, 187);
            this.TXTCALLE.Multiline = true;
            this.TXTCALLE.Name = "TXTCALLE";
            this.TXTCALLE.Size = new System.Drawing.Size(339, 36);
            this.TXTCALLE.TabIndex = 160;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(165, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 159;
            this.label1.Text = "CALLE :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(117, 385);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 25);
            this.label3.TabIndex = 158;
            this.label3.Text = "TELEFONO :";
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.button9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button9.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Clarendon BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.Black;
            this.button9.Image = ((System.Drawing.Image)(resources.GetObject("button9.Image")));
            this.button9.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button9.Location = new System.Drawing.Point(0, 590);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(751, 85);
            this.button9.TabIndex = 157;
            this.button9.Text = "REGRESAR";
            this.button9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // TXTNOMBRE
            // 
            this.TXTNOMBRE.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTNOMBRE.Location = new System.Drawing.Point(312, 133);
            this.TXTNOMBRE.Multiline = true;
            this.TXTNOMBRE.Name = "TXTNOMBRE";
            this.TXTNOMBRE.Size = new System.Drawing.Size(339, 34);
            this.TXTNOMBRE.TabIndex = 156;
            // 
            // TXTID
            // 
            this.TXTID.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTID.Location = new System.Drawing.Point(312, 81);
            this.TXTID.Multiline = true;
            this.TXTID.Name = "TXTID";
            this.TXTID.Size = new System.Drawing.Size(339, 36);
            this.TXTID.TabIndex = 155;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(218, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 25);
            this.label4.TabIndex = 154;
            this.label4.Text = "ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(142, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 25);
            this.label2.TabIndex = 153;
            this.label2.Text = "NOMBRE :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(7, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(265, 25);
            this.label5.TabIndex = 162;
            this.label5.Text = "NUMERO EXTERIOR :";
            // 
            // TXTNUMEXTERIOR
            // 
            this.TXTNUMEXTERIOR.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTNUMEXTERIOR.Location = new System.Drawing.Point(312, 248);
            this.TXTNUMEXTERIOR.Multiline = true;
            this.TXTNUMEXTERIOR.Name = "TXTNUMEXTERIOR";
            this.TXTNUMEXTERIOR.Size = new System.Drawing.Size(339, 36);
            this.TXTNUMEXTERIOR.TabIndex = 163;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(7, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(258, 25);
            this.label6.TabIndex = 164;
            this.label6.Text = "NUMERO INTERIOR :";
            // 
            // TXTNUMINTERIOR
            // 
            this.TXTNUMINTERIOR.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTNUMINTERIOR.Location = new System.Drawing.Point(312, 309);
            this.TXTNUMINTERIOR.Multiline = true;
            this.TXTNUMINTERIOR.Name = "TXTNUMINTERIOR";
            this.TXTNUMINTERIOR.Size = new System.Drawing.Size(339, 36);
            this.TXTNUMINTERIOR.TabIndex = 165;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(75, 441);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(197, 25);
            this.label7.TabIndex = 166;
            this.label7.Text = "REFERENCIAS :";
            // 
            // TXTREFERENCIAS
            // 
            this.TXTREFERENCIAS.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTREFERENCIAS.Location = new System.Drawing.Point(312, 441);
            this.TXTREFERENCIAS.Multiline = true;
            this.TXTREFERENCIAS.Name = "TXTREFERENCIAS";
            this.TXTREFERENCIAS.Size = new System.Drawing.Size(339, 129);
            this.TXTREFERENCIAS.TabIndex = 167;
            // 
            // frmPaqueteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(209)))));
            this.ClientSize = new System.Drawing.Size(751, 675);
            this.Controls.Add(this.TXTREFERENCIAS);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TXTNUMINTERIOR);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TXTNUMEXTERIOR);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TXTTELEFONO);
            this.Controls.Add(this.TXTCALLE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.TXTNOMBRE);
            this.Controls.Add(this.TXTID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmPaqueteria";
            this.Text = "frmPaqueteria";
            this.Load += new System.EventHandler(this.frmPaqueteria_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem BTNGUARDAR;
        private System.Windows.Forms.ToolStripMenuItem BTNBUSCAR;
        private System.Windows.Forms.ToolStripMenuItem BTNLIMPIAR;
        private System.Windows.Forms.ToolStripMenuItem BTNELIMINAR;
        private System.Windows.Forms.TextBox TXTTELEFONO;
        private System.Windows.Forms.TextBox TXTCALLE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox TXTNOMBRE;
        private System.Windows.Forms.TextBox TXTID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TXTNUMEXTERIOR;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TXTNUMINTERIOR;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TXTREFERENCIAS;
    }
}