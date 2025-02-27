namespace SmartG.Operaciones.CreditControl
{
    partial class WriteOffLimitesEdicion
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
            this.lbLimiteMXN = new Infragistics.Win.Misc.UltraLabel();
            this.lbLimiteUSD = new Infragistics.Win.Misc.UltraLabel();
            this.txtLimiteMXN = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtLimiteUSD = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lbMonMXN = new Infragistics.Win.Misc.UltraLabel();
            this.lbMonUSD = new Infragistics.Win.Misc.UltraLabel();
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            this.btnAceptar = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtLimiteMXN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLimiteUSD)).BeginInit();
            this.SuspendLayout();
            // 
            // lbLimiteMXN
            // 
            this.lbLimiteMXN.Location = new System.Drawing.Point(50, 33);
            this.lbLimiteMXN.Name = "lbLimiteMXN";
            this.lbLimiteMXN.Size = new System.Drawing.Size(170, 23);
            this.lbLimiteMXN.TabIndex = 0;
            this.lbLimiteMXN.Text = "Limite Máximo en Pesos";
            // 
            // lbLimiteUSD
            // 
            this.lbLimiteUSD.Location = new System.Drawing.Point(50, 70);
            this.lbLimiteUSD.Name = "lbLimiteUSD";
            this.lbLimiteUSD.Size = new System.Drawing.Size(276, 23);
            this.lbLimiteUSD.TabIndex = 1;
            this.lbLimiteUSD.Text = "Limite Máximo en Dolares";
            // 
            // txtLimiteMXN
            // 
            this.txtLimiteMXN.Location = new System.Drawing.Point(253, 29);
            this.txtLimiteMXN.Name = "txtLimiteMXN";
            this.txtLimiteMXN.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txtLimiteMXN.Size = new System.Drawing.Size(211, 24);
            this.txtLimiteMXN.TabIndex = 2;
            // 
            // txtLimiteUSD
            // 
            this.txtLimiteUSD.Location = new System.Drawing.Point(253, 66);
            this.txtLimiteUSD.Name = "txtLimiteUSD";
            this.txtLimiteUSD.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txtLimiteUSD.Size = new System.Drawing.Size(211, 24);
            this.txtLimiteUSD.TabIndex = 3;
            // 
            // lbMonMXN
            // 
            this.lbMonMXN.Location = new System.Drawing.Point(483, 33);
            this.lbMonMXN.Name = "lbMonMXN";
            this.lbMonMXN.Size = new System.Drawing.Size(170, 23);
            this.lbMonMXN.TabIndex = 4;
            this.lbMonMXN.Text = "MXN";
            // 
            // lbMonUSD
            // 
            this.lbMonUSD.Location = new System.Drawing.Point(483, 70);
            this.lbMonUSD.Name = "lbMonUSD";
            this.lbMonUSD.Size = new System.Drawing.Size(170, 23);
            this.lbMonUSD.TabIndex = 5;
            this.lbMonUSD.Text = "USD";
            // 
            // btnCancelar
            // 
            this.btnCancelar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnCancelar.Location = new System.Drawing.Point(100, 129);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(194, 27);
            this.btnCancelar.TabIndex = 26;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnAceptar.Location = new System.Drawing.Point(300, 129);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(194, 27);
            this.btnAceptar.TabIndex = 25;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // WriteOffLimitesEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 188);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lbMonUSD);
            this.Controls.Add(this.lbMonMXN);
            this.Controls.Add(this.txtLimiteUSD);
            this.Controls.Add(this.txtLimiteMXN);
            this.Controls.Add(this.lbLimiteUSD);
            this.Controls.Add(this.lbLimiteMXN);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WriteOffLimitesEdicion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WriteOffLimitesEdicion";
            this.Load += new System.EventHandler(this.WriteOffLimitesEdicion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtLimiteMXN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLimiteUSD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel lbLimiteMXN;
        private Infragistics.Win.Misc.UltraLabel lbLimiteUSD;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtLimiteMXN;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtLimiteUSD;
        private Infragistics.Win.Misc.UltraLabel lbMonMXN;
        private Infragistics.Win.Misc.UltraLabel lbMonUSD;
        private Infragistics.Win.Misc.UltraButton btnCancelar;
        private Infragistics.Win.Misc.UltraButton btnAceptar;
    }
}