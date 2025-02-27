namespace SmartG.Operaciones.CreditControl.Cobranza
{
    partial class SelPorcentajeBrokerage
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.btnBuscarJournal = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.txtPorcentaje = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorcentaje)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscarJournal
            // 
            this.btnBuscarJournal.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnBuscarJournal.Location = new System.Drawing.Point(135, 120);
            this.btnBuscarJournal.Name = "btnBuscarJournal";
            this.btnBuscarJournal.Size = new System.Drawing.Size(111, 23);
            this.btnBuscarJournal.TabIndex = 25;
            this.btnBuscarJournal.Text = "Continuar";
            this.btnBuscarJournal.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnBuscarJournal.Click += new System.EventHandler(this.btnBuscarJournal_Click);
            // 
            // ultraLabel1
            // 
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance1;
            this.ultraLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel1.Location = new System.Drawing.Point(11, 12);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(359, 66);
            this.ultraLabel1.TabIndex = 23;
            this.ultraLabel1.Text = "No existe una poliza emitida para asignar a esta factura, por lo que se desconoce" +
    " el % de comisión a pagarle al Broker, favor de ingresarlo:";
            // 
            // txtPorcentaje
            // 
            appearance2.TextHAlignAsString = "Center";
            this.txtPorcentaje.Appearance = appearance2;
            this.txtPorcentaje.Location = new System.Drawing.Point(93, 84);
            this.txtPorcentaje.MaskInput = "nnn.nn%";
            this.txtPorcentaje.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtPorcentaje.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txtPorcentaje.Size = new System.Drawing.Size(194, 21);
            this.txtPorcentaje.TabIndex = 26;
            // 
            // SelPorcentajeBrokerage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 163);
            this.Controls.Add(this.txtPorcentaje);
            this.Controls.Add(this.btnBuscarJournal);
            this.Controls.Add(this.ultraLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelPorcentajeBrokerage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelPorcentajeBrokerage";
            this.Load += new System.EventHandler(this.SelPorcentajeBrokerage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPorcentaje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton btnBuscarJournal;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtPorcentaje;
    }
}