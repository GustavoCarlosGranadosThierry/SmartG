namespace SmartG.Operaciones.Claims
{
    partial class BuscarPoliza
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
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("BusquedPolizas", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Poliza");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PAM");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Linea de Negocios");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Broker");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Tipo de Transaccion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Emision");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Inicio Vigencia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Fin Vigencia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Nombre");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PolizaES");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Asegurado");
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
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            this.cbFiltro = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.grpBusqueda = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            this.ultraTextEditor1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnConsultar = new Infragistics.Win.Misc.UltraButton();
            this.lbBuscar = new Infragistics.Win.Misc.UltraLabel();
            this.lbParametro = new Infragistics.Win.Misc.UltraLabel();
            this.grpCompletadas = new Infragistics.Win.Misc.UltraGroupBox();
            this.dgPolizas = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.busquedPolizasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.liabilityInc = new SmartG.Datasets.Emision.Liability.LiabilityInc();
            this.busquedaPolizaTableAdapter = new SmartG.Datasets.Emision.Liability.LiabilityIncTableAdapters.BusquedaPolizaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cbFiltro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpBusqueda)).BeginInit();
            this.grpBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCompletadas)).BeginInit();
            this.grpCompletadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPolizas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.busquedPolizasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.liabilityInc)).BeginInit();
            this.SuspendLayout();
            // 
            // cbFiltro
            // 
            this.cbFiltro.DisplayMember = "";
            this.cbFiltro.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbFiltro.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbFiltro.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            valueListItem4.DataValue = "ValueListItem3";
            valueListItem4.DisplayText = "Asegurado";
            valueListItem9.DataValue = "ValueListItem1";
            valueListItem9.DisplayText = "Poliza ES";
            valueListItem10.DataValue = "ValueListItem0";
            valueListItem10.DisplayText = "Poliza MX";
            this.cbFiltro.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem4,
            valueListItem9,
            valueListItem10});
            this.cbFiltro.LimitToList = true;
            this.cbFiltro.Location = new System.Drawing.Point(107, 50);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.Size = new System.Drawing.Size(177, 24);
            this.cbFiltro.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.cbFiltro.TabIndex = 4;
            this.cbFiltro.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbFiltro.ValueMember = "ID";
            // 
            // grpBusqueda
            // 
            this.grpBusqueda.Controls.Add(this.btnCancelar);
            this.grpBusqueda.Controls.Add(this.ultraTextEditor1);
            this.grpBusqueda.Controls.Add(this.cbFiltro);
            this.grpBusqueda.Controls.Add(this.btnConsultar);
            this.grpBusqueda.Controls.Add(this.lbBuscar);
            this.grpBusqueda.Controls.Add(this.lbParametro);
            this.grpBusqueda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpBusqueda.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpBusqueda.Location = new System.Drawing.Point(12, 12);
            this.grpBusqueda.Name = "grpBusqueda";
            this.grpBusqueda.Size = new System.Drawing.Size(867, 110);
            this.grpBusqueda.TabIndex = 7;
            this.grpBusqueda.Text = "Opciones de Busqueda";
            this.grpBusqueda.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnCancelar.Location = new System.Drawing.Point(721, 51);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(111, 27);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCancelar.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // ultraTextEditor1
            // 
            this.ultraTextEditor1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.ultraTextEditor1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraTextEditor1.Location = new System.Drawing.Point(363, 52);
            this.ultraTextEditor1.MaxLength = 150;
            this.ultraTextEditor1.Name = "ultraTextEditor1";
            this.ultraTextEditor1.Size = new System.Drawing.Size(192, 24);
            this.ultraTextEditor1.TabIndex = 17;
            this.ultraTextEditor1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ultraTextEditor1_KeyDown);
            // 
            // btnConsultar
            // 
            this.btnConsultar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnConsultar.Location = new System.Drawing.Point(569, 51);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(111, 27);
            this.btnConsultar.TabIndex = 18;
            this.btnConsultar.Text = "Recargar";
            this.btnConsultar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // lbBuscar
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.TextVAlignAsString = "Middle";
            this.lbBuscar.Appearance = appearance1;
            this.lbBuscar.Location = new System.Drawing.Point(303, 51);
            this.lbBuscar.Name = "lbBuscar";
            this.lbBuscar.Size = new System.Drawing.Size(58, 23);
            this.lbBuscar.TabIndex = 15;
            this.lbBuscar.Text = "Buscar:";
            // 
            // lbParametro
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.TextVAlignAsString = "Middle";
            this.lbParametro.Appearance = appearance2;
            this.lbParametro.Location = new System.Drawing.Point(26, 53);
            this.lbParametro.Name = "lbParametro";
            this.lbParametro.Size = new System.Drawing.Size(115, 23);
            this.lbParametro.TabIndex = 10;
            this.lbParametro.Text = "Parametro:";
            // 
            // grpCompletadas
            // 
            this.grpCompletadas.Controls.Add(this.dgPolizas);
            this.grpCompletadas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpCompletadas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpCompletadas.Location = new System.Drawing.Point(12, 128);
            this.grpCompletadas.Name = "grpCompletadas";
            this.grpCompletadas.Size = new System.Drawing.Size(867, 328);
            this.grpCompletadas.TabIndex = 6;
            this.grpCompletadas.Text = "Registros de Polizas (Doble clic para seleccionar)";
            this.grpCompletadas.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // dgPolizas
            // 
            this.dgPolizas.DataSource = this.busquedPolizasBindingSource;
            appearance3.BackColor = System.Drawing.SystemColors.Window;
            appearance3.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgPolizas.DisplayLayout.Appearance = appearance3;
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 0;
            ultraGridColumn14.Header.Editor = null;
            ultraGridColumn14.Header.VisiblePosition = 2;
            ultraGridColumn15.Header.Editor = null;
            ultraGridColumn15.Header.VisiblePosition = 3;
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 4;
            ultraGridColumn17.Header.Editor = null;
            ultraGridColumn17.Header.VisiblePosition = 5;
            ultraGridColumn18.Header.Editor = null;
            ultraGridColumn18.Header.VisiblePosition = 6;
            ultraGridColumn19.Header.Editor = null;
            ultraGridColumn19.Header.VisiblePosition = 7;
            ultraGridColumn20.Header.Editor = null;
            ultraGridColumn20.Header.VisiblePosition = 8;
            ultraGridColumn21.Header.Editor = null;
            ultraGridColumn21.Header.VisiblePosition = 9;
            ultraGridColumn22.Header.Editor = null;
            ultraGridColumn22.Header.VisiblePosition = 10;
            ultraGridColumn23.Header.Editor = null;
            ultraGridColumn23.Header.VisiblePosition = 1;
            ultraGridColumn23.Hidden = true;
            ultraGridColumn24.Header.Editor = null;
            ultraGridColumn24.Header.VisiblePosition = 11;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24});
            this.dgPolizas.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgPolizas.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgPolizas.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.BorderColor = System.Drawing.SystemColors.Window;
            this.dgPolizas.DisplayLayout.GroupByBox.Appearance = appearance4;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgPolizas.DisplayLayout.GroupByBox.BandLabelAppearance = appearance5;
            this.dgPolizas.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance6.BackColor2 = System.Drawing.SystemColors.Control;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgPolizas.DisplayLayout.GroupByBox.PromptAppearance = appearance6;
            this.dgPolizas.DisplayLayout.MaxColScrollRegions = 1;
            this.dgPolizas.DisplayLayout.MaxRowScrollRegions = 1;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            appearance7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgPolizas.DisplayLayout.Override.ActiveCellAppearance = appearance7;
            appearance8.BackColor = System.Drawing.SystemColors.Highlight;
            appearance8.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgPolizas.DisplayLayout.Override.ActiveRowAppearance = appearance8;
            this.dgPolizas.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.dgPolizas.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            this.dgPolizas.DisplayLayout.Override.CardAreaAppearance = appearance9;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgPolizas.DisplayLayout.Override.CellAppearance = appearance10;
            this.dgPolizas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.dgPolizas.DisplayLayout.Override.CellPadding = 0;
            appearance11.BackColor = System.Drawing.SystemColors.Control;
            appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance11.BorderColor = System.Drawing.SystemColors.Window;
            this.dgPolizas.DisplayLayout.Override.GroupByRowAppearance = appearance11;
            appearance12.TextHAlignAsString = "Left";
            this.dgPolizas.DisplayLayout.Override.HeaderAppearance = appearance12;
            this.dgPolizas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgPolizas.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            this.dgPolizas.DisplayLayout.Override.RowAppearance = appearance13;
            this.dgPolizas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance14.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgPolizas.DisplayLayout.Override.TemplateAddRowAppearance = appearance14;
            this.dgPolizas.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgPolizas.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgPolizas.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.dgPolizas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPolizas.Font = new System.Drawing.Font("Arial", 9.75F);
            this.dgPolizas.Location = new System.Drawing.Point(2, 21);
            this.dgPolizas.Name = "dgPolizas";
            this.dgPolizas.Size = new System.Drawing.Size(863, 305);
            this.dgPolizas.TabIndex = 2;
            this.dgPolizas.Text = "ultraGrid1";
            this.dgPolizas.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.dgPolizas_DoubleClickRow);
            // 
            // busquedPolizasBindingSource
            // 
            this.busquedPolizasBindingSource.DataMember = "BusquedPolizas";
            this.busquedPolizasBindingSource.DataSource = this.liabilityInc;
            // 
            // liabilityInc
            // 
            this.liabilityInc.DataSetName = "LiabilityInc";
            this.liabilityInc.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // busquedaPolizaTableAdapter
            // 
            this.busquedaPolizaTableAdapter.ClearBeforeFill = true;
            // 
            // BuscarPoliza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 473);
            this.Controls.Add(this.grpBusqueda);
            this.Controls.Add(this.grpCompletadas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BuscarPoliza";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BuscarPoliza";
            this.Load += new System.EventHandler(this.BuscarPoliza_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbFiltro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpBusqueda)).EndInit();
            this.grpBusqueda.ResumeLayout(false);
            this.grpBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCompletadas)).EndInit();
            this.grpCompletadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPolizas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.busquedPolizasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.liabilityInc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbFiltro;
        private Infragistics.Win.Misc.UltraGroupBox grpBusqueda;
        private Infragistics.Win.Misc.UltraButton btnCancelar;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor1;
        private Infragistics.Win.Misc.UltraButton btnConsultar;
        private Infragistics.Win.Misc.UltraLabel lbBuscar;
        private Infragistics.Win.Misc.UltraLabel lbParametro;
        private Infragistics.Win.Misc.UltraGroupBox grpCompletadas;
        private Infragistics.Win.UltraWinGrid.UltraGrid dgPolizas;
        private Datasets.Emision.Liability.LiabilityInc liabilityInc;
        private System.Windows.Forms.BindingSource busquedPolizasBindingSource;
        private Datasets.Emision.Liability.LiabilityIncTableAdapters.BusquedaPolizaTableAdapter busquedaPolizaTableAdapter;
    }
}