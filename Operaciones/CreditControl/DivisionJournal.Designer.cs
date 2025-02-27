namespace SmartG.Operaciones.CreditControl
{
    partial class DivisionJournal
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Monto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Borrar");
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
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn1 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Monto");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn2 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Borrar");
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            this.ultraCalcManager1 = new Infragistics.Win.UltraWinCalcManager.UltraCalcManager(this.components);
            this.txtTotalDivision = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpDivision = new Infragistics.Win.Misc.UltraGroupBox();
            this.dgDivision = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.dsDivision = new Infragistics.Win.UltraWinDataSource.UltraDataSource(this.components);
            this.grpDetallesPago = new Infragistics.Win.Misc.UltraGroupBox();
            this.lbTotalJournal = new Infragistics.Win.Misc.UltraLabel();
            this.txtTotalJournal = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lbTotalDiv = new Infragistics.Win.Misc.UltraLabel();
            this.txtMonOriginal = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtSNum = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbMonedaJournal = new Infragistics.Win.Misc.UltraLabel();
            this.lbSnum = new Infragistics.Win.Misc.UltraLabel();
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            this.btnDividir = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCalcManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDivision)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpDivision)).BeginInit();
            this.grpDivision.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDivision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDivision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpDetallesPago)).BeginInit();
            this.grpDetallesPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalJournal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSNum)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraCalcManager1
            // 
            this.ultraCalcManager1.ContainingControl = this;
            // 
            // txtTotalDivision
            // 
            this.ultraCalcManager1.SetCalcSettings(this.txtTotalDivision, new Infragistics.Win.UltraWinCalcManager.CalcSettings(null, null, "sum( [//dgDivision/Band 0/Monto]  )", "Value", Infragistics.Win.UltraWinCalcManager.CalcErrorIconAlignment.Default, null));
            this.txtTotalDivision.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtTotalDivision.Enabled = false;
            this.txtTotalDivision.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtTotalDivision.Location = new System.Drawing.Point(146, 134);
            this.txtTotalDivision.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            this.txtTotalDivision.Name = "txtTotalDivision";
            this.txtTotalDivision.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txtTotalDivision.Size = new System.Drawing.Size(157, 24);
            this.txtTotalDivision.TabIndex = 30;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grpDivision, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grpDetallesPago, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(361, 618);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grpDivision
            // 
            this.grpDivision.Controls.Add(this.dgDivision);
            this.grpDivision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDivision.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpDivision.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpDivision.Location = new System.Drawing.Point(3, 233);
            this.grpDivision.Name = "grpDivision";
            this.grpDivision.Size = new System.Drawing.Size(355, 382);
            this.grpDivision.TabIndex = 5;
            this.grpDivision.Text = "Distribución de la Division Journal";
            this.grpDivision.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // dgDivision
            // 
            this.dgDivision.CalcManager = this.ultraCalcManager1;
            this.dgDivision.DataSource = this.dsDivision;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgDivision.DisplayLayout.Appearance = appearance1;
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 1;
            ultraGridColumn10.MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn10.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn10.MaskInput = "{currency:18.2}";
            ultraGridColumn10.Width = 225;
            ultraGridColumn1.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            appearance2.ImageBackground = global::SmartG.Properties.Resources.Delete_small;
            ultraGridColumn1.CellButtonAppearance = appearance2;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn1.Width = 76;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn10,
            ultraGridColumn1});
            this.dgDivision.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgDivision.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgDivision.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.dgDivision.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgDivision.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.dgDivision.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgDivision.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.dgDivision.DisplayLayout.MaxColScrollRegions = 1;
            this.dgDivision.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgDivision.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgDivision.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            this.dgDivision.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            this.dgDivision.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.dgDivision.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            this.dgDivision.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgDivision.DisplayLayout.Override.CellAppearance = appearance9;
            this.dgDivision.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.dgDivision.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.dgDivision.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.TextHAlignAsString = "Left";
            this.dgDivision.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.dgDivision.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgDivision.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            this.dgDivision.DisplayLayout.Override.RowAppearance = appearance12;
            this.dgDivision.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgDivision.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.dgDivision.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgDivision.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgDivision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDivision.Location = new System.Drawing.Point(2, 21);
            this.dgDivision.Name = "dgDivision";
            this.dgDivision.Size = new System.Drawing.Size(351, 359);
            this.dgDivision.TabIndex = 0;
            this.dgDivision.Text = "ultraGrid1";
            this.dgDivision.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgDivision_ClickCellButton);
            // 
            // dsDivision
            // 
            ultraDataColumn1.DataType = typeof(decimal);
            this.dsDivision.Band.Columns.AddRange(new object[] {
            ultraDataColumn1,
            ultraDataColumn2});
            // 
            // grpDetallesPago
            // 
            this.grpDetallesPago.Controls.Add(this.txtTotalDivision);
            this.grpDetallesPago.Controls.Add(this.lbTotalJournal);
            this.grpDetallesPago.Controls.Add(this.txtTotalJournal);
            this.grpDetallesPago.Controls.Add(this.lbTotalDiv);
            this.grpDetallesPago.Controls.Add(this.txtMonOriginal);
            this.grpDetallesPago.Controls.Add(this.txtSNum);
            this.grpDetallesPago.Controls.Add(this.lbMonedaJournal);
            this.grpDetallesPago.Controls.Add(this.lbSnum);
            this.grpDetallesPago.Controls.Add(this.btnCancelar);
            this.grpDetallesPago.Controls.Add(this.btnDividir);
            this.grpDetallesPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDetallesPago.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpDetallesPago.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpDetallesPago.Location = new System.Drawing.Point(3, 3);
            this.grpDetallesPago.Name = "grpDetallesPago";
            this.grpDetallesPago.Size = new System.Drawing.Size(355, 224);
            this.grpDetallesPago.TabIndex = 4;
            this.grpDetallesPago.Text = "Detalles del Pago";
            this.grpDetallesPago.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // lbTotalJournal
            // 
            appearance14.BackColor = System.Drawing.Color.Transparent;
            appearance14.TextVAlignAsString = "Middle";
            this.lbTotalJournal.Appearance = appearance14;
            this.lbTotalJournal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalJournal.Location = new System.Drawing.Point(25, 100);
            this.lbTotalJournal.Name = "lbTotalJournal";
            this.lbTotalJournal.Size = new System.Drawing.Size(115, 23);
            this.lbTotalJournal.TabIndex = 29;
            this.lbTotalJournal.Text = "Total del Journal:";
            // 
            // txtTotalJournal
            // 
            this.txtTotalJournal.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtTotalJournal.Enabled = false;
            this.txtTotalJournal.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtTotalJournal.Location = new System.Drawing.Point(146, 99);
            this.txtTotalJournal.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            this.txtTotalJournal.Name = "txtTotalJournal";
            this.txtTotalJournal.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txtTotalJournal.Size = new System.Drawing.Size(157, 24);
            this.txtTotalJournal.TabIndex = 28;
            // 
            // lbTotalDiv
            // 
            appearance15.BackColor = System.Drawing.Color.Transparent;
            appearance15.TextVAlignAsString = "Middle";
            this.lbTotalDiv.Appearance = appearance15;
            this.lbTotalDiv.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalDiv.Location = new System.Drawing.Point(25, 134);
            this.lbTotalDiv.Name = "lbTotalDiv";
            this.lbTotalDiv.Size = new System.Drawing.Size(115, 23);
            this.lbTotalDiv.TabIndex = 27;
            this.lbTotalDiv.Text = "Total de la division:";
            // 
            // txtMonOriginal
            // 
            this.txtMonOriginal.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtMonOriginal.Enabled = false;
            this.txtMonOriginal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonOriginal.Location = new System.Drawing.Point(146, 69);
            this.txtMonOriginal.MaxLength = 15;
            this.txtMonOriginal.Name = "txtMonOriginal";
            this.txtMonOriginal.Size = new System.Drawing.Size(157, 24);
            this.txtMonOriginal.TabIndex = 26;
            // 
            // txtSNum
            // 
            this.txtSNum.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtSNum.Enabled = false;
            this.txtSNum.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSNum.Location = new System.Drawing.Point(146, 39);
            this.txtSNum.MaxLength = 15;
            this.txtSNum.Name = "txtSNum";
            this.txtSNum.Size = new System.Drawing.Size(157, 24);
            this.txtSNum.TabIndex = 25;
            // 
            // lbMonedaJournal
            // 
            appearance16.BackColor = System.Drawing.Color.Transparent;
            appearance16.TextVAlignAsString = "Middle";
            this.lbMonedaJournal.Appearance = appearance16;
            this.lbMonedaJournal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMonedaJournal.Location = new System.Drawing.Point(25, 71);
            this.lbMonedaJournal.Name = "lbMonedaJournal";
            this.lbMonedaJournal.Size = new System.Drawing.Size(101, 23);
            this.lbMonedaJournal.TabIndex = 24;
            this.lbMonedaJournal.Text = "Moneda Original:";
            // 
            // lbSnum
            // 
            appearance17.BackColor = System.Drawing.Color.Transparent;
            appearance17.TextVAlignAsString = "Middle";
            this.lbSnum.Appearance = appearance17;
            this.lbSnum.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSnum.Location = new System.Drawing.Point(25, 39);
            this.lbSnum.Name = "lbSnum";
            this.lbSnum.Size = new System.Drawing.Size(115, 23);
            this.lbSnum.TabIndex = 23;
            this.lbSnum.Text = "S. Number: ";
            // 
            // btnCancelar
            // 
            this.btnCancelar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnCancelar.Location = new System.Drawing.Point(25, 180);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(135, 28);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnDividir
            // 
            this.btnDividir.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnDividir.Location = new System.Drawing.Point(168, 180);
            this.btnDividir.Name = "btnDividir";
            this.btnDividir.Size = new System.Drawing.Size(135, 28);
            this.btnDividir.TabIndex = 18;
            this.btnDividir.Text = "Dividir Pago";
            this.btnDividir.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnDividir.Click += new System.EventHandler(this.btnDividir_Click);
            // 
            // DivisionJournal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 618);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DivisionJournal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DivisionJournal";
            this.Load += new System.EventHandler(this.DivisionJournal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraCalcManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDivision)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpDivision)).EndInit();
            this.grpDivision.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDivision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDivision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpDetallesPago)).EndInit();
            this.grpDetallesPago.ResumeLayout(false);
            this.grpDetallesPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalJournal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Infragistics.Win.UltraWinCalcManager.UltraCalcManager ultraCalcManager1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Infragistics.Win.Misc.UltraGroupBox grpDetallesPago;
        private Infragistics.Win.Misc.UltraButton btnDividir;
        private Infragistics.Win.Misc.UltraGroupBox grpDivision;
        private Infragistics.Win.Misc.UltraButton btnCancelar;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMonOriginal;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtSNum;
        private Infragistics.Win.Misc.UltraLabel lbMonedaJournal;
        private Infragistics.Win.Misc.UltraLabel lbSnum;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtTotalDivision;
        private Infragistics.Win.Misc.UltraLabel lbTotalJournal;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtTotalJournal;
        private Infragistics.Win.Misc.UltraLabel lbTotalDiv;
        private Infragistics.Win.UltraWinGrid.UltraGrid dgDivision;
        private Infragistics.Win.UltraWinDataSource.UltraDataSource dsDivision;
    }
}