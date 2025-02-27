namespace SmartG.Operaciones.CreditControl
{
    partial class RecibosPagoEdicion
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
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Pago #");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Inicio Vigencia Recibo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Fin Vigencia Recibo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Plazo Pago");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha Limite Pago", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Prima Neta");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Impuesto");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Prima Total");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Borrar", 0);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn1 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Pago #");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn2 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Inicio Vigencia Recibo");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn3 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Fin Vigencia Recibo");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn4 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Plazo Pago");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn5 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Fecha Limite Pago");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn6 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Prima Neta");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn7 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Impuesto");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn8 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Prima Total");
            this.dgRecibosPago = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraCalcManager1 = new Infragistics.Win.UltraWinCalcManager.UltraCalcManager(this.components);
            this.txtTotalRecibos = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtPrimaTotal = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.dsRecibosPago = new Infragistics.Win.UltraWinDataSource.UltraDataSource(this.components);
            this.lbIniVig = new Infragistics.Win.Misc.UltraLabel();
            this.lbFinVig = new Infragistics.Win.Misc.UltraLabel();
            this.dateIniVig = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.dateFinVig = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.lbTotalFactura = new Infragistics.Win.Misc.UltraLabel();
            this.btnGuardar = new Infragistics.Win.Misc.UltraButton();
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            this.lbTotalRecibos = new Infragistics.Win.Misc.UltraLabel();
            this.chkFechasInterpuestas = new System.Windows.Forms.CheckBox();
            this.txtImpuestos = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            ((System.ComponentModel.ISupportInitialize)(this.dgRecibosPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCalcManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalRecibos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrimaTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRecibosPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIniVig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFinVig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImpuestos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgRecibosPago
            // 
            this.dgRecibosPago.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgRecibosPago.CalcManager = this.ultraCalcManager1;
            this.dgRecibosPago.DataSource = this.dsRecibosPago;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgRecibosPago.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn1.MaskInput = "";
            ultraGridColumn1.NullText = "0";
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 4;
            ultraGridColumn4.NullText = "0";
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn5.Formula = "dateadd( \"d\" , [Plazo Pago] , [Fin Vigencia Recibo] )";
            ultraGridColumn5.FormulaErrorValue = "Falta FinVig";
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 5;
            ultraGridColumn5.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn5.MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn5.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn5.MaskInput = "{date}";
            appearance2.TextHAlignAsString = "Right";
            ultraGridColumn6.CellAppearance = appearance2;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 6;
            ultraGridColumn6.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn6.MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn6.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn6.MaskInput = "{LOC}$ -n,nnn,nnn,nnn.nn";
            ultraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            appearance3.TextHAlignAsString = "Right";
            ultraGridColumn7.CellAppearance = appearance3;
            ultraGridColumn7.Formula = "round( [Prima Neta] *   [//txtImpuestos] , 2 , 0 )";
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 7;
            ultraGridColumn7.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn7.MaskInput = "{LOC}$ -n,nnn,nnn.nn";
            ultraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            appearance4.TextHAlignAsString = "Right";
            ultraGridColumn8.CellAppearance = appearance4;
            ultraGridColumn8.Formula = "round(  [Prima Neta] + [Impuesto] , 2 , 0 )";
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 8;
            ultraGridColumn8.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
            ultraGridColumn8.MaskInput = "{LOC}$ -n,nnn,nnn.nn";
            ultraGridColumn8.NullText = "0";
            ultraGridColumn8.Width = 101;
            ultraGridColumn9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            appearance5.ImageBackground = global::SmartG.Properties.Resources.Delete_small;
            ultraGridColumn9.CellButtonAppearance = appearance5;
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 0;
            ultraGridColumn9.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn9.Width = 50;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9});
            this.dgRecibosPago.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgRecibosPago.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgRecibosPago.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.dgRecibosPago.DisplayLayout.GroupByBox.Appearance = appearance6;
            appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgRecibosPago.DisplayLayout.GroupByBox.BandLabelAppearance = appearance7;
            this.dgRecibosPago.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance8.BackColor2 = System.Drawing.SystemColors.Control;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgRecibosPago.DisplayLayout.GroupByBox.PromptAppearance = appearance8;
            this.dgRecibosPago.DisplayLayout.MaxColScrollRegions = 1;
            this.dgRecibosPago.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgRecibosPago.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance10.BackColor = System.Drawing.SystemColors.Highlight;
            appearance10.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgRecibosPago.DisplayLayout.Override.ActiveRowAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.White;
            this.dgRecibosPago.DisplayLayout.Override.AddRowAppearance = appearance11;
            this.dgRecibosPago.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            this.dgRecibosPago.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.dgRecibosPago.DisplayLayout.Override.AllowMultiCellOperations = ((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)((((((((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Delete) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Undo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Redo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Reserved)));
            this.dgRecibosPago.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.dgRecibosPago.DisplayLayout.Override.AutoEditMode = Infragistics.Win.DefaultableBoolean.True;
            this.dgRecibosPago.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.dgRecibosPago.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            this.dgRecibosPago.DisplayLayout.Override.CardAreaAppearance = appearance12;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            appearance13.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgRecibosPago.DisplayLayout.Override.CellAppearance = appearance13;
            this.dgRecibosPago.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.dgRecibosPago.DisplayLayout.Override.CellPadding = 0;
            appearance14.BackColor = System.Drawing.SystemColors.Control;
            appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance14.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance14.BorderColor = System.Drawing.SystemColors.Window;
            this.dgRecibosPago.DisplayLayout.Override.GroupByRowAppearance = appearance14;
            appearance15.TextHAlignAsString = "Left";
            this.dgRecibosPago.DisplayLayout.Override.HeaderAppearance = appearance15;
            this.dgRecibosPago.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgRecibosPago.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance16.BackColor = System.Drawing.SystemColors.Window;
            appearance16.BorderColor = System.Drawing.Color.Silver;
            this.dgRecibosPago.DisplayLayout.Override.RowAppearance = appearance16;
            this.dgRecibosPago.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance17.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgRecibosPago.DisplayLayout.Override.TemplateAddRowAppearance = appearance17;
            this.dgRecibosPago.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgRecibosPago.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgRecibosPago.Location = new System.Drawing.Point(49, 134);
            this.dgRecibosPago.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgRecibosPago.Name = "dgRecibosPago";
            this.dgRecibosPago.Size = new System.Drawing.Size(964, 394);
            this.dgRecibosPago.TabIndex = 0;
            this.dgRecibosPago.Text = "ultraGrid1";
            this.dgRecibosPago.AfterRowInsert += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.dgRecibosPago_AfterRowInsert);
            this.dgRecibosPago.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgRecibosPago_ClickCellButton);
            // 
            // ultraCalcManager1
            // 
            this.ultraCalcManager1.ContainingControl = this;
            this.ultraCalcManager1.NamedReferences.AddRange(new object[] {
            new Infragistics.Win.UltraWinCalcManager.NamedReference("NamedReference 0", "[//txtImp]", null, null)});
            // 
            // txtTotalRecibos
            // 
            this.txtTotalRecibos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraCalcManager1.SetCalcSettings(this.txtTotalRecibos, new Infragistics.Win.UltraWinCalcManager.CalcSettings(null, null, "sum( [//dgRecibosPago/Band 0/Prima Total] )", "Value", Infragistics.Win.UltraWinCalcManager.CalcErrorIconAlignment.Default, null));
            this.txtTotalRecibos.Enabled = false;
            this.txtTotalRecibos.Location = new System.Drawing.Point(791, 78);
            this.txtTotalRecibos.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            this.txtTotalRecibos.MaskInput = "{LOC}$nn,nnn,nnn.nn";
            this.txtTotalRecibos.Name = "txtTotalRecibos";
            this.txtTotalRecibos.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txtTotalRecibos.Size = new System.Drawing.Size(222, 24);
            this.txtTotalRecibos.TabIndex = 21;
            // 
            // txtPrimaTotal
            // 
            this.txtPrimaTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraCalcManager1.SetCalcSettings(this.txtPrimaTotal, new Infragistics.Win.UltraWinCalcManager.CalcSettings(null, null, "", "Value", Infragistics.Win.UltraWinCalcManager.CalcErrorIconAlignment.Default, null));
            this.txtPrimaTotal.Enabled = false;
            this.txtPrimaTotal.Location = new System.Drawing.Point(791, 40);
            this.txtPrimaTotal.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            this.txtPrimaTotal.MaskInput = "{LOC}$nn,nnn,nnn.nn";
            this.txtPrimaTotal.Name = "txtPrimaTotal";
            this.txtPrimaTotal.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txtPrimaTotal.Size = new System.Drawing.Size(222, 24);
            this.txtPrimaTotal.TabIndex = 6;
            // 
            // dsRecibosPago
            // 
            ultraDataColumn1.DataType = typeof(int);
            ultraDataColumn2.DataType = typeof(System.DateTime);
            ultraDataColumn3.DataType = typeof(System.DateTime);
            ultraDataColumn4.DataType = typeof(int);
            ultraDataColumn4.DefaultValue = 30;
            ultraDataColumn5.DataType = typeof(System.DateTime);
            ultraDataColumn6.DataType = typeof(decimal);
            ultraDataColumn6.DefaultValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            ultraDataColumn7.DataType = typeof(decimal);
            ultraDataColumn7.DefaultValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            ultraDataColumn8.DataType = typeof(decimal);
            ultraDataColumn8.DefaultValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.dsRecibosPago.Band.Columns.AddRange(new object[] {
            ultraDataColumn1,
            ultraDataColumn2,
            ultraDataColumn3,
            ultraDataColumn4,
            ultraDataColumn5,
            ultraDataColumn6,
            ultraDataColumn7,
            ultraDataColumn8});
            // 
            // lbIniVig
            // 
            this.lbIniVig.Location = new System.Drawing.Point(49, 29);
            this.lbIniVig.Name = "lbIniVig";
            this.lbIniVig.Size = new System.Drawing.Size(187, 23);
            this.lbIniVig.TabIndex = 1;
            this.lbIniVig.Text = "Inicio de Vigencia:";
            // 
            // lbFinVig
            // 
            this.lbFinVig.Location = new System.Drawing.Point(49, 67);
            this.lbFinVig.Name = "lbFinVig";
            this.lbFinVig.Size = new System.Drawing.Size(187, 23);
            this.lbFinVig.TabIndex = 2;
            this.lbFinVig.Text = "Fin de Vigencia:";
            // 
            // dateIniVig
            // 
            this.dateIniVig.Location = new System.Drawing.Point(201, 25);
            this.dateIniVig.Name = "dateIniVig";
            this.dateIniVig.Size = new System.Drawing.Size(274, 24);
            this.dateIniVig.TabIndex = 3;
            // 
            // dateFinVig
            // 
            this.dateFinVig.Location = new System.Drawing.Point(201, 63);
            this.dateFinVig.Name = "dateFinVig";
            this.dateFinVig.Size = new System.Drawing.Size(274, 24);
            this.dateFinVig.TabIndex = 4;
            // 
            // lbTotalFactura
            // 
            this.lbTotalFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotalFactura.Location = new System.Drawing.Point(639, 44);
            this.lbTotalFactura.Name = "lbTotalFactura";
            this.lbTotalFactura.Size = new System.Drawing.Size(187, 23);
            this.lbTotalFactura.TabIndex = 5;
            this.lbTotalFactura.Text = "Total de la Factura: ";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGuardar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(541, 558);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(243, 26);
            this.btnGuardar.TabIndex = 18;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(258, 558);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(243, 26);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lbTotalRecibos
            // 
            this.lbTotalRecibos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotalRecibos.Location = new System.Drawing.Point(639, 82);
            this.lbTotalRecibos.Name = "lbTotalRecibos";
            this.lbTotalRecibos.Size = new System.Drawing.Size(187, 23);
            this.lbTotalRecibos.TabIndex = 20;
            this.lbTotalRecibos.Text = "Total en los Recibos";
            // 
            // chkFechasInterpuestas
            // 
            this.chkFechasInterpuestas.AutoSize = true;
            this.chkFechasInterpuestas.Location = new System.Drawing.Point(49, 103);
            this.chkFechasInterpuestas.Name = "chkFechasInterpuestas";
            this.chkFechasInterpuestas.Size = new System.Drawing.Size(531, 20);
            this.chkFechasInterpuestas.TabIndex = 23;
            this.chkFechasInterpuestas.Text = "Las fechas de Inicio y Fin de Viegencia de los recibos pueden sobreponerse entre " +
    "ellas";
            this.chkFechasInterpuestas.UseVisualStyleBackColor = true;
            // 
            // txtImpuestos
            // 
            this.ultraCalcManager1.SetCalcSettings(this.txtImpuestos, new Infragistics.Win.UltraWinCalcManager.CalcSettings(null, null, null, "Value", Infragistics.Win.UltraWinCalcManager.CalcErrorIconAlignment.Default, null));
            this.txtImpuestos.Location = new System.Drawing.Point(791, 10);
            this.txtImpuestos.MaskInput = "{LOC}nnn.nn%";
            this.txtImpuestos.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtImpuestos.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtImpuestos.Name = "txtImpuestos";
            this.txtImpuestos.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txtImpuestos.Size = new System.Drawing.Size(222, 24);
            this.txtImpuestos.TabIndex = 24;
            this.txtImpuestos.Visible = false;
            // 
            // RecibosPagoEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 618);
            this.Controls.Add(this.txtImpuestos);
            this.Controls.Add(this.chkFechasInterpuestas);
            this.Controls.Add(this.txtTotalRecibos);
            this.Controls.Add(this.lbTotalRecibos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtPrimaTotal);
            this.Controls.Add(this.lbTotalFactura);
            this.Controls.Add(this.dateFinVig);
            this.Controls.Add(this.dateIniVig);
            this.Controls.Add(this.lbFinVig);
            this.Controls.Add(this.lbIniVig);
            this.Controls.Add(this.dgRecibosPago);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecibosPagoEdicion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edición de Recibos de Pago";
            this.Load += new System.EventHandler(this.RecibosPagoEdicion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgRecibosPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCalcManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalRecibos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrimaTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRecibosPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIniVig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFinVig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImpuestos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid dgRecibosPago;
        private Infragistics.Win.UltraWinDataSource.UltraDataSource dsRecibosPago;
        private Infragistics.Win.Misc.UltraLabel lbFinVig;
        private Infragistics.Win.Misc.UltraLabel lbIniVig;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dateFinVig;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dateIniVig;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtPrimaTotal;
        private Infragistics.Win.Misc.UltraLabel lbTotalFactura;
        private Infragistics.Win.Misc.UltraButton btnCancelar;
        private Infragistics.Win.Misc.UltraButton btnGuardar;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtTotalRecibos;
        private Infragistics.Win.Misc.UltraLabel lbTotalRecibos;
        private System.Windows.Forms.CheckBox chkFechasInterpuestas;
        private Infragistics.Win.UltraWinCalcManager.UltraCalcManager ultraCalcManager1;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtImpuestos;
    }
}