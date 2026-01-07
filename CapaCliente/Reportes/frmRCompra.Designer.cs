namespace CapaCliente.Reportes
{
    partial class frmRCompra
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
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.ckTodos = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.rvVenta = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha1.Location = new System.Drawing.Point(766, 220);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(172, 30);
            this.dtpFecha1.TabIndex = 195;
            // 
            // ckTodos
            // 
            this.ckTodos.AutoSize = true;
            this.ckTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckTodos.ForeColor = System.Drawing.Color.White;
            this.ckTodos.Location = new System.Drawing.Point(766, 276);
            this.ckTodos.Name = "ckTodos";
            this.ckTodos.Size = new System.Drawing.Size(90, 29);
            this.ckTodos.TabIndex = 194;
            this.ckTodos.Text = "Todos";
            this.ckTodos.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Swis721 Hv BT", 13.8F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(590, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 27);
            this.label1.TabIndex = 193;
            this.label1.Text = "Por periodo:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(766, 171);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(172, 30);
            this.dtpFecha.TabIndex = 192;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::CapaCliente.Properties.Resources.lupa;
            this.btnBuscar.Location = new System.Drawing.Point(972, 100);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 57);
            this.btnBuscar.TabIndex = 191;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Swis721 Hv BT", 13.8F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(670, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 27);
            this.label4.TabIndex = 189;
            this.label4.Text = "Folio:";
            // 
            // txtFolio
            // 
            this.txtFolio.Location = new System.Drawing.Point(766, 108);
            this.txtFolio.Multiline = true;
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(172, 36);
            this.txtFolio.TabIndex = 190;
            // 
            // rvVenta
            // 
            this.rvVenta.Location = new System.Drawing.Point(55, 321);
            this.rvVenta.Name = "rvVenta";
            this.rvVenta.ServerReport.BearerToken = null;
            this.rvVenta.Size = new System.Drawing.Size(1377, 505);
            this.rvVenta.TabIndex = 188;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("News706 BT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.label3.Location = new System.Drawing.Point(698, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(304, 36);
            this.label3.TabIndex = 187;
            this.label3.Text = "Reporte de Compra";
            // 
            // frmRCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(26)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(1488, 925);
            this.Controls.Add(this.dtpFecha1);
            this.Controls.Add(this.ckTodos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFolio);
            this.Controls.Add(this.rvVenta);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRCompra";
            this.Text = "frmRCompra";
            this.Load += new System.EventHandler(this.frmRCompra_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private System.Windows.Forms.CheckBox ckTodos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFolio;
        private Microsoft.Reporting.WinForms.ReportViewer rvVenta;
        private System.Windows.Forms.Label label3;
    }
}