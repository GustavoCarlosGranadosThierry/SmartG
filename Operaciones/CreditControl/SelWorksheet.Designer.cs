namespace SmartG.Operaciones.CreditControl
{
    partial class SelWorksheet
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraComboEditor1 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btnBuscarJournal = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.ultraComboEditor1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraLabel1
            // 
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance2;
            this.ultraLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel1.Location = new System.Drawing.Point(12, 39);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(359, 23);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "Seleccione la pestaña donde se encuentra el Jounal";
            // 
            // ultraComboEditor1
            // 
            this.ultraComboEditor1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraComboEditor1.Location = new System.Drawing.Point(73, 83);
            this.ultraComboEditor1.Name = "ultraComboEditor1";
            this.ultraComboEditor1.Size = new System.Drawing.Size(245, 24);
            this.ultraComboEditor1.TabIndex = 1;
            // 
            // btnBuscarJournal
            // 
            this.btnBuscarJournal.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnBuscarJournal.Location = new System.Drawing.Point(130, 131);
            this.btnBuscarJournal.Name = "btnBuscarJournal";
            this.btnBuscarJournal.Size = new System.Drawing.Size(111, 23);
            this.btnBuscarJournal.TabIndex = 19;
            this.btnBuscarJournal.Text = "Continuar";
            this.btnBuscarJournal.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnBuscarJournal.Click += new System.EventHandler(this.btnBuscarJournal_Click);
            // 
            // SelWorksheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 177);
            this.Controls.Add(this.btnBuscarJournal);
            this.Controls.Add(this.ultraComboEditor1);
            this.Controls.Add(this.ultraLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelWorksheet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelWorksheet";
            ((System.ComponentModel.ISupportInitialize)(this.ultraComboEditor1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ultraComboEditor1;
        private Infragistics.Win.Misc.UltraButton btnBuscarJournal;
    }
}