namespace CapaCliente.FORMULARIOS
{
    partial class frmEmpleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpleados));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.BTNGUARDAR = new System.Windows.Forms.ToolStripMenuItem();
            this.BTNBUSCAR = new System.Windows.Forms.ToolStripMenuItem();
            this.BTNLIMPIAR = new System.Windows.Forms.ToolStripMenuItem();
            this.BTNELIMINAR = new System.Windows.Forms.ToolStripMenuItem();
            this.button9 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.TXTRFC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TXTCURP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TXTTELEFONO = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TXTCORREO = new System.Windows.Forms.TextBox();
            this.TXTAPELLIDOMATERNO = new System.Windows.Forms.TextBox();
            this.TXTNOMBRE = new System.Windows.Forms.TextBox();
            this.TXTID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TXTAPELLIDOPATERNO = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TXTPUESTO = new System.Windows.Forms.TextBox();
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
            this.menuStrip1.Size = new System.Drawing.Size(851, 36);
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
            this.button9.Location = new System.Drawing.Point(0, 557);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(851, 95);
            this.button9.TabIndex = 150;
            this.button9.Text = "CERRAR";
            this.button9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(234, 352);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 25);
            this.label7.TabIndex = 149;
            this.label7.Text = "RFC :";
            // 
            // TXTRFC
            // 
            this.TXTRFC.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTRFC.Location = new System.Drawing.Point(346, 352);
            this.TXTRFC.MaxLength = 13;
            this.TXTRFC.Multiline = true;
            this.TXTRFC.Name = "TXTRFC";
            this.TXTRFC.Size = new System.Drawing.Size(410, 34);
            this.TXTRFC.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(216, 401);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 25);
            this.label5.TabIndex = 147;
            this.label5.Text = "CURP :";
            // 
            // TXTCURP
            // 
            this.TXTCURP.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTCURP.Location = new System.Drawing.Point(346, 400);
            this.TXTCURP.MaxLength = 18;
            this.TXTCURP.Multiline = true;
            this.TXTCURP.Name = "TXTCURP";
            this.TXTCURP.Size = new System.Drawing.Size(410, 34);
            this.TXTCURP.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(183, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 25);
            this.label3.TabIndex = 145;
            this.label3.Text = "CORREO :";
            // 
            // TXTTELEFONO
            // 
            this.TXTTELEFONO.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTTELEFONO.Location = new System.Drawing.Point(346, 250);
            this.TXTTELEFONO.MaxLength = 10;
            this.TXTTELEFONO.Multiline = true;
            this.TXTTELEFONO.Name = "TXTTELEFONO";
            this.TXTTELEFONO.Size = new System.Drawing.Size(410, 34);
            this.TXTTELEFONO.TabIndex = 4;
            this.TXTTELEFONO.TextChanged += new System.EventHandler(this.TXTTELEFONO_TextChanged);
            this.TXTTELEFONO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXTTELEFONO_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(155, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 25);
            this.label6.TabIndex = 143;
            this.label6.Text = "TELEFONO :";
            // 
            // TXTCORREO
            // 
            this.TXTCORREO.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTCORREO.Location = new System.Drawing.Point(346, 300);
            this.TXTCORREO.Multiline = true;
            this.TXTCORREO.Name = "TXTCORREO";
            this.TXTCORREO.Size = new System.Drawing.Size(410, 34);
            this.TXTCORREO.TabIndex = 5;
            // 
            // TXTAPELLIDOMATERNO
            // 
            this.TXTAPELLIDOMATERNO.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTAPELLIDOMATERNO.Location = new System.Drawing.Point(346, 201);
            this.TXTAPELLIDOMATERNO.Multiline = true;
            this.TXTAPELLIDOMATERNO.Name = "TXTAPELLIDOMATERNO";
            this.TXTAPELLIDOMATERNO.Size = new System.Drawing.Size(410, 31);
            this.TXTAPELLIDOMATERNO.TabIndex = 3;
            // 
            // TXTNOMBRE
            // 
            this.TXTNOMBRE.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTNOMBRE.Location = new System.Drawing.Point(346, 98);
            this.TXTNOMBRE.Multiline = true;
            this.TXTNOMBRE.Name = "TXTNOMBRE";
            this.TXTNOMBRE.Size = new System.Drawing.Size(410, 34);
            this.TXTNOMBRE.TabIndex = 1;
            // 
            // TXTID
            // 
            this.TXTID.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTID.Location = new System.Drawing.Point(12, 39);
            this.TXTID.Multiline = true;
            this.TXTID.Name = "TXTID";
            this.TXTID.ReadOnly = true;
            this.TXTID.Size = new System.Drawing.Size(56, 36);
            this.TXTID.TabIndex = 0;
            this.TXTID.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(180, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 25);
            this.label2.TabIndex = 137;
            this.label2.Text = "NOMBRE :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 25);
            this.label1.TabIndex = 136;
            this.label1.Text = "APELLIDO MATERNO :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(34, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(276, 25);
            this.label8.TabIndex = 151;
            this.label8.Text = "APELLIDO PATERNO :";
            // 
            // TXTAPELLIDOPATERNO
            // 
            this.TXTAPELLIDOPATERNO.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTAPELLIDOPATERNO.Location = new System.Drawing.Point(346, 149);
            this.TXTAPELLIDOPATERNO.Multiline = true;
            this.TXTAPELLIDOPATERNO.Name = "TXTAPELLIDOPATERNO";
            this.TXTAPELLIDOPATERNO.Size = new System.Drawing.Size(410, 34);
            this.TXTAPELLIDOPATERNO.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(186, 451);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 25);
            this.label9.TabIndex = 153;
            this.label9.Text = "PUESTO :";
            // 
            // TXTPUESTO
            // 
            this.TXTPUESTO.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTPUESTO.Location = new System.Drawing.Point(346, 449);
            this.TXTPUESTO.Multiline = true;
            this.TXTPUESTO.Name = "TXTPUESTO";
            this.TXTPUESTO.Size = new System.Drawing.Size(410, 34);
            this.TXTPUESTO.TabIndex = 8;
            // 
            // frmEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(209)))));
            this.ClientSize = new System.Drawing.Size(851, 652);
            this.Controls.Add(this.TXTPUESTO);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TXTAPELLIDOPATERNO);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TXTRFC);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TXTCURP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TXTTELEFONO);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TXTCORREO);
            this.Controls.Add(this.TXTAPELLIDOMATERNO);
            this.Controls.Add(this.TXTNOMBRE);
            this.Controls.Add(this.TXTID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEmpleados";
            this.Text = "frmEmpleados";
            this.Load += new System.EventHandler(this.frmEmpleados_Load);
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
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TXTRFC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TXTCURP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TXTTELEFONO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TXTCORREO;
        private System.Windows.Forms.TextBox TXTAPELLIDOMATERNO;
        private System.Windows.Forms.TextBox TXTNOMBRE;
        private System.Windows.Forms.TextBox TXTID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TXTAPELLIDOPATERNO;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TXTPUESTO;
    }
}