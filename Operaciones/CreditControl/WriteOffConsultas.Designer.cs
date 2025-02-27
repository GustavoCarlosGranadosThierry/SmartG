namespace SmartG.Operaciones.CreditControl
{
    partial class WriteOffConsultas
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("JournalWriteOffs", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Journal");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoMovimiento");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MontoOriginal");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NuevoMonto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Diferencia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("JustificacionUsuario");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAplicacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UserName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreUsuario");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            this.dgWriteOffs = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.journalWriteOffsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complementosPago = new SmartG.Datasets.CreditControl.ComplementosPago();
            this.journalWriteOffsTableAdapter = new SmartG.Datasets.CreditControl.ComplementosPagoTableAdapters.JournalWriteOffsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgWriteOffs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.journalWriteOffsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complementosPago)).BeginInit();
            this.SuspendLayout();
            // 
            // dgWriteOffs
            // 
            this.dgWriteOffs.DataSource = this.journalWriteOffsBindingSource;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgWriteOffs.DisplayLayout.Appearance = appearance1;
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 0;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 1;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 5;
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 7;
            ultraGridColumn14.Header.Editor = null;
            ultraGridColumn14.Header.VisiblePosition = 8;
            ultraGridColumn15.Header.Editor = null;
            ultraGridColumn15.Header.VisiblePosition = 9;
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 6;
            ultraGridColumn16.Width = 336;
            ultraGridColumn17.Header.Editor = null;
            ultraGridColumn17.Header.VisiblePosition = 10;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn18.Header.Editor = null;
            ultraGridColumn18.Header.VisiblePosition = 2;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 3;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 4;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn1,
            ultraGridColumn2});
            this.dgWriteOffs.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgWriteOffs.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgWriteOffs.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.dgWriteOffs.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgWriteOffs.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.dgWriteOffs.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgWriteOffs.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.dgWriteOffs.DisplayLayout.MaxColScrollRegions = 1;
            this.dgWriteOffs.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgWriteOffs.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgWriteOffs.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.dgWriteOffs.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.dgWriteOffs.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.dgWriteOffs.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgWriteOffs.DisplayLayout.Override.CellAppearance = appearance8;
            this.dgWriteOffs.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.dgWriteOffs.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.dgWriteOffs.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.dgWriteOffs.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.dgWriteOffs.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgWriteOffs.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.dgWriteOffs.DisplayLayout.Override.RowAppearance = appearance11;
            this.dgWriteOffs.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgWriteOffs.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.dgWriteOffs.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgWriteOffs.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgWriteOffs.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.dgWriteOffs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgWriteOffs.Location = new System.Drawing.Point(0, 0);
            this.dgWriteOffs.Name = "dgWriteOffs";
            this.dgWriteOffs.Size = new System.Drawing.Size(1136, 359);
            this.dgWriteOffs.TabIndex = 0;
            this.dgWriteOffs.Text = "ultraGrid1";
            // 
            // journalWriteOffsBindingSource
            // 
            this.journalWriteOffsBindingSource.DataMember = "JournalWriteOffs";
            this.journalWriteOffsBindingSource.DataSource = this.complementosPago;
            // 
            // complementosPago
            // 
            this.complementosPago.DataSetName = "ComplementosPago";
            this.complementosPago.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // journalWriteOffsTableAdapter
            // 
            this.journalWriteOffsTableAdapter.ClearBeforeFill = true;
            // 
            // WriteOffConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 359);
            this.Controls.Add(this.dgWriteOffs);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WriteOffConsultas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WriteOffs Consultas";
            this.Load += new System.EventHandler(this.WriteOffConsultas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgWriteOffs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.journalWriteOffsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complementosPago)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid dgWriteOffs;
        private Datasets.CreditControl.ComplementosPago complementosPago;
        private System.Windows.Forms.BindingSource journalWriteOffsBindingSource;
        private Datasets.CreditControl.ComplementosPagoTableAdapters.JournalWriteOffsTableAdapter journalWriteOffsTableAdapter;
    }
}