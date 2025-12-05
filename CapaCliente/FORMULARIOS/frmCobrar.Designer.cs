namespace CapaCliente.FORMULARIOS
{
    partial class frmCobrar
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
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.txtPago = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMix = new System.Windows.Forms.Button();
            this.btnEfectivo = new System.Windows.Forms.Button();
            this.btnTarjeta = new System.Windows.Forms.Button();
            this.btnTransferencia = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnFinVenta = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCambio
            // 
            this.txtCambio.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtCambio.Font = new System.Drawing.Font("Swis721 Hv BT", 13.8F);
            this.txtCambio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.txtCambio.Location = new System.Drawing.Point(183, 326);
            this.txtCambio.Multiline = true;
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.Size = new System.Drawing.Size(270, 33);
            this.txtCambio.TabIndex = 11;
            // 
            // txtPago
            // 
            this.txtPago.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtPago.Font = new System.Drawing.Font("Swis721 Hv BT", 13.8F);
            this.txtPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.txtPago.Location = new System.Drawing.Point(183, 214);
            this.txtPago.Multiline = true;
            this.txtPago.Name = "txtPago";
            this.txtPago.Size = new System.Drawing.Size(270, 33);
            this.txtPago.TabIndex = 10;
            this.txtPago.TextChanged += new System.EventHandler(this.txtPago_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Swis721 Hv BT", 13.8F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.label3.Location = new System.Drawing.Point(259, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 27);
            this.label3.TabIndex = 9;
            this.label3.Text = "CAMBIO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Swis721 Hv BT", 13.8F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.label2.Location = new System.Drawing.Point(273, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 27);
            this.label2.TabIndex = 8;
            this.label2.Text = "PAGO:";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTotal.Font = new System.Drawing.Font("Swis721 Hv BT", 13.8F);
            this.txtTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.txtTotal.Location = new System.Drawing.Point(183, 85);
            this.txtTotal.Multiline = true;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(270, 47);
            this.txtTotal.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Swis721 Hv BT", 13.8F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.label1.Location = new System.Drawing.Point(269, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "TOTAL:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnMix);
            this.panel1.Controls.Add(this.btnEfectivo);
            this.panel1.Controls.Add(this.btnTarjeta);
            this.panel1.Controls.Add(this.btnTransferencia);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 637);
            this.panel1.TabIndex = 114;
            // 
            // btnMix
            // 
            this.btnMix.BackColor = System.Drawing.Color.Transparent;
            this.btnMix.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMix.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMix.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMix.FlatAppearance.BorderSize = 0;
            this.btnMix.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnMix.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnMix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMix.Font = new System.Drawing.Font("Clarendon BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnMix.Image = global::CapaCliente.Properties.Resources.tarjeta_de_credito__1_;
            this.btnMix.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMix.Location = new System.Drawing.Point(0, 438);
            this.btnMix.Name = "btnMix";
            this.btnMix.Size = new System.Drawing.Size(217, 146);
            this.btnMix.TabIndex = 115;
            this.btnMix.Text = "MIX";
            this.btnMix.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMix.UseVisualStyleBackColor = false;
            this.btnMix.Click += new System.EventHandler(this.btnMix_Click);
            // 
            // btnEfectivo
            // 
            this.btnEfectivo.BackColor = System.Drawing.Color.Transparent;
            this.btnEfectivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEfectivo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEfectivo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEfectivo.FlatAppearance.BorderSize = 0;
            this.btnEfectivo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnEfectivo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnEfectivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEfectivo.Font = new System.Drawing.Font("Clarendon BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEfectivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnEfectivo.Image = global::CapaCliente.Properties.Resources.flujo_de_efectivo;
            this.btnEfectivo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEfectivo.Location = new System.Drawing.Point(0, 292);
            this.btnEfectivo.Name = "btnEfectivo";
            this.btnEfectivo.Size = new System.Drawing.Size(217, 146);
            this.btnEfectivo.TabIndex = 112;
            this.btnEfectivo.Text = "EFECTIVO";
            this.btnEfectivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEfectivo.UseVisualStyleBackColor = false;
            this.btnEfectivo.Click += new System.EventHandler(this.btnEfectivo_Click);
            // 
            // btnTarjeta
            // 
            this.btnTarjeta.BackColor = System.Drawing.Color.Transparent;
            this.btnTarjeta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTarjeta.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTarjeta.FlatAppearance.BorderSize = 0;
            this.btnTarjeta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnTarjeta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTarjeta.Font = new System.Drawing.Font("Clarendon BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnTarjeta.Image = global::CapaCliente.Properties.Resources.tarjeta_de_credito;
            this.btnTarjeta.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTarjeta.Location = new System.Drawing.Point(0, 146);
            this.btnTarjeta.Name = "btnTarjeta";
            this.btnTarjeta.Size = new System.Drawing.Size(217, 146);
            this.btnTarjeta.TabIndex = 113;
            this.btnTarjeta.Text = "TARJETA";
            this.btnTarjeta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTarjeta.UseVisualStyleBackColor = false;
            this.btnTarjeta.Click += new System.EventHandler(this.btnTarjeta_Click);
            // 
            // btnTransferencia
            // 
            this.btnTransferencia.BackColor = System.Drawing.Color.Transparent;
            this.btnTransferencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransferencia.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTransferencia.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTransferencia.FlatAppearance.BorderSize = 0;
            this.btnTransferencia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnTransferencia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnTransferencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransferencia.Font = new System.Drawing.Font("Clarendon BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransferencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnTransferencia.Image = global::CapaCliente.Properties.Resources.transferencia_movil;
            this.btnTransferencia.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTransferencia.Location = new System.Drawing.Point(0, 0);
            this.btnTransferencia.Name = "btnTransferencia";
            this.btnTransferencia.Size = new System.Drawing.Size(217, 146);
            this.btnTransferencia.TabIndex = 111;
            this.btnTransferencia.Text = "TRANSFERENCIA";
            this.btnTransferencia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTransferencia.UseVisualStyleBackColor = false;
            this.btnTransferencia.Click += new System.EventHandler(this.btnTransferencia_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.panel2.Controls.Add(this.txtPago);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtCambio);
            this.panel2.Controls.Add(this.txtTotal);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(303, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(622, 408);
            this.panel2.TabIndex = 115;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("News706 BT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.label6.Location = new System.Drawing.Point(548, 34);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 36);
            this.label6.TabIndex = 174;
            this.label6.Text = "COBRO";
            // 
            // btnFinVenta
            // 
            this.btnFinVenta.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinVenta.Location = new System.Drawing.Point(524, 534);
            this.btnFinVenta.Name = "btnFinVenta";
            this.btnFinVenta.Size = new System.Drawing.Size(217, 50);
            this.btnFinVenta.TabIndex = 175;
            this.btnFinVenta.Text = "Concluir Venta";
            this.btnFinVenta.UseVisualStyleBackColor = true;
            this.btnFinVenta.Click += new System.EventHandler(this.btnFinVenta_Click);
            // 
            // frmCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(26)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(1057, 637);
            this.Controls.Add(this.btnFinVenta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmCobrar";
            this.Text = "frmCobrar";
            this.Load += new System.EventHandler(this.frmCobrar_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.TextBox txtPago;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTransferencia;
        private System.Windows.Forms.Button btnEfectivo;
        private System.Windows.Forms.Button btnTarjeta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMix;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnFinVenta;
    }
}