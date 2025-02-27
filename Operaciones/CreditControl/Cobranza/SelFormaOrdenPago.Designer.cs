namespace SmartG.Operaciones.CreditControl.Cobranza
{
    partial class SelFormaOrdenPago
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.btnBuscarJournal = new Infragistics.Win.Misc.UltraButton();
            this.cbFormaPagosBroker = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cbFormaPagosBroker)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscarJournal
            // 
            this.btnBuscarJournal.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnBuscarJournal.Location = new System.Drawing.Point(168, 129);
            this.btnBuscarJournal.Name = "btnBuscarJournal";
            this.btnBuscarJournal.Size = new System.Drawing.Size(111, 23);
            this.btnBuscarJournal.TabIndex = 22;
            this.btnBuscarJournal.Text = "Continuar";
            this.btnBuscarJournal.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnBuscarJournal.Click += new System.EventHandler(this.btnBuscarJournal_Click);
            // 
            // cbFormaPagosBroker
            // 
            this.cbFormaPagosBroker.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbFormaPagosBroker.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            valueListItem1.DataValue = "Una sola Exhibición";
            valueListItem2.DataValue = "Misma que los Recibos";
            this.cbFormaPagosBroker.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.cbFormaPagosBroker.Location = new System.Drawing.Point(50, 81);
            this.cbFormaPagosBroker.Name = "cbFormaPagosBroker";
            this.cbFormaPagosBroker.Size = new System.Drawing.Size(359, 24);
            this.cbFormaPagosBroker.TabIndex = 21;
            // 
            // ultraLabel1
            // 
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance1;
            this.ultraLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel1.Location = new System.Drawing.Point(50, 37);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(359, 23);
            this.ultraLabel1.TabIndex = 20;
            this.ultraLabel1.Text = "Seleccione la forma de Ordenes de pago para el Broker";
            // 
            // SelFormaOrdenPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 189);
            this.Controls.Add(this.btnBuscarJournal);
            this.Controls.Add(this.cbFormaPagosBroker);
            this.Controls.Add(this.ultraLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelFormaOrdenPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelFormaOrdenPago";
            this.Load += new System.EventHandler(this.SelFormaOrdenPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbFormaPagosBroker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton btnBuscarJournal;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbFormaPagosBroker;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
    }
}