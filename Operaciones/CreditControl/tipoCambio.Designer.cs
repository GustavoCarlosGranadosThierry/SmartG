namespace SmartG.Operaciones.CreditControl
{
    partial class tipoCambio
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
            this.lbMensajeTipoCambio = new System.Windows.Forms.Label();
            this.lbTipoCambio2 = new System.Windows.Forms.Label();
            this.lbTipoCambio1 = new System.Windows.Forms.Label();
            this.txtTipoCambio = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.btnAceptar = new Infragistics.Win.Misc.UltraButton();
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMensajeTipoCambio
            // 
            this.lbMensajeTipoCambio.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbMensajeTipoCambio.Location = new System.Drawing.Point(86, 57);
            this.lbMensajeTipoCambio.Name = "lbMensajeTipoCambio";
            this.lbMensajeTipoCambio.Size = new System.Drawing.Size(458, 69);
            this.lbMensajeTipoCambio.TabIndex = 11;
            this.lbMensajeTipoCambio.Text = "La moneda del recibo seleccionado (MXN) no coincide con la moneda del Journal (US" +
    "D), favor de ingresar el tipo de cambio para esta operacion para poder continuar" +
    ":";
            this.lbMensajeTipoCambio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbMensajeTipoCambio.Visible = false;
            // 
            // lbTipoCambio2
            // 
            this.lbTipoCambio2.AutoSize = true;
            this.lbTipoCambio2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbTipoCambio2.Location = new System.Drawing.Point(141, 146);
            this.lbTipoCambio2.Name = "lbTipoCambio2";
            this.lbTipoCambio2.Size = new System.Drawing.Size(80, 16);
            this.lbTipoCambio2.TabIndex = 10;
            this.lbTipoCambio2.Text = "MXN > USD";
            // 
            // lbTipoCambio1
            // 
            this.lbTipoCambio1.AutoSize = true;
            this.lbTipoCambio1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbTipoCambio1.Location = new System.Drawing.Point(130, 126);
            this.lbTipoCambio1.Name = "lbTipoCambio1";
            this.lbTipoCambio1.Size = new System.Drawing.Size(109, 16);
            this.lbTipoCambio1.TabIndex = 6;
            this.lbTipoCambio1.Text = "Tipo de Cambio";
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.Location = new System.Drawing.Point(292, 141);
            this.txtTipoCambio.MinValue = 0;
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txtTipoCambio.PromptChar = ' ';
            this.txtTipoCambio.Size = new System.Drawing.Size(197, 21);
            this.txtTipoCambio.TabIndex = 7;
            this.txtTipoCambio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTipoCambio_KeyDown);
            // 
            // btnAceptar
            // 
            this.btnAceptar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnAceptar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.Location = new System.Drawing.Point(358, 200);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(111, 23);
            this.btnAceptar.TabIndex = 19;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.Location = new System.Drawing.Point(182, 200);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(111, 23);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tipoCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 280);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lbMensajeTipoCambio);
            this.Controls.Add(this.lbTipoCambio2);
            this.Controls.Add(this.lbTipoCambio1);
            this.Controls.Add(this.txtTipoCambio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "tipoCambio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "tipoCambio";
            this.Load += new System.EventHandler(this.tipoCambio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMensajeTipoCambio;
        private System.Windows.Forms.Label lbTipoCambio2;
        private System.Windows.Forms.Label lbTipoCambio1;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtTipoCambio;
        private Infragistics.Win.Misc.UltraButton btnAceptar;
        private Infragistics.Win.Misc.UltraButton btnCancelar;
    }
}