namespace SmartG.Catalogos
{
    partial class VisorSolicitudesUsuario
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ClientesSolicitudSeguimiento", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ClienteSolicitud");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Comentario");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaLevantamiento", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario Comentario");
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
            Infragistics.Win.UltraWinToolbars.RibbonTab ribbonTab1 = new Infragistics.Win.UltraWinToolbars.RibbonTab("rbnMain");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup2 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("grpFiltros");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnNuevoComentario");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnDescargarDocumentos");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup1 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("rgpActualizar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnActualizar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnNuevoComentario");
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnDescargarDocumentos");
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnActualizar");
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisorSolicitudesUsuario));
            this.dgSolicitudesDetalle = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.clientesSolicitudSeguimientoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.catalogosGral = new SmartG.Datasets.Catalogos.catalogosGral();
            this.ToolbarsManagerConsultasAML = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._BusquedaPolizas_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._BusquedaPolizas_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._BusquedaPolizas_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._BusquedaPolizas_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.VisorSolicitudesUsuario_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this.clientesSolicitudSeguimientoTableAdapter = new SmartG.Datasets.Catalogos.catalogosGralTableAdapters.ClientesSolicitudSeguimientoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgSolicitudesDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesSolicitudSeguimientoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogosGral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarsManagerConsultasAML)).BeginInit();
            this.VisorSolicitudesUsuario_Fill_Panel.ClientArea.SuspendLayout();
            this.VisorSolicitudesUsuario_Fill_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgSolicitudesDetalle
            // 
            this.dgSolicitudesDetalle.DataSource = this.clientesSolicitudSeguimientoBindingSource;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgSolicitudesDetalle.DisplayLayout.Appearance = appearance1;
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 0;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 1;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 4;
            ultraGridColumn13.Width = 767;
            ultraGridColumn14.Header.Editor = null;
            ultraGridColumn14.Header.VisiblePosition = 3;
            ultraGridColumn15.Header.Editor = null;
            ultraGridColumn15.Header.VisiblePosition = 2;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15});
            this.dgSolicitudesDetalle.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgSolicitudesDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgSolicitudesDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.dgSolicitudesDetalle.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgSolicitudesDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.dgSolicitudesDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgSolicitudesDetalle.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.dgSolicitudesDetalle.DisplayLayout.MaxColScrollRegions = 1;
            this.dgSolicitudesDetalle.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgSolicitudesDetalle.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgSolicitudesDetalle.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.dgSolicitudesDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.dgSolicitudesDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.dgSolicitudesDetalle.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgSolicitudesDetalle.DisplayLayout.Override.CellAppearance = appearance8;
            this.dgSolicitudesDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.dgSolicitudesDetalle.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.dgSolicitudesDetalle.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.dgSolicitudesDetalle.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.dgSolicitudesDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgSolicitudesDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.dgSolicitudesDetalle.DisplayLayout.Override.RowAppearance = appearance11;
            this.dgSolicitudesDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.dgSolicitudesDetalle.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgSolicitudesDetalle.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.dgSolicitudesDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgSolicitudesDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgSolicitudesDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.dgSolicitudesDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSolicitudesDetalle.Location = new System.Drawing.Point(0, 0);
            this.dgSolicitudesDetalle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgSolicitudesDetalle.Name = "dgSolicitudesDetalle";
            this.dgSolicitudesDetalle.Size = new System.Drawing.Size(1063, 375);
            this.dgSolicitudesDetalle.TabIndex = 0;
            // 
            // clientesSolicitudSeguimientoBindingSource
            // 
            this.clientesSolicitudSeguimientoBindingSource.DataMember = "ClientesSolicitudSeguimiento";
            this.clientesSolicitudSeguimientoBindingSource.DataSource = this.catalogosGral;
            // 
            // catalogosGral
            // 
            this.catalogosGral.DataSetName = "catalogosGral";
            this.catalogosGral.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ToolbarsManagerConsultasAML
            // 
            this.ToolbarsManagerConsultasAML.DesignerFlags = 1;
            this.ToolbarsManagerConsultasAML.DockWithinContainer = this;
            this.ToolbarsManagerConsultasAML.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ToolbarsManagerConsultasAML.Office2007UICompatibility = false;
            this.ToolbarsManagerConsultasAML.Ribbon.FileMenuStyle = Infragistics.Win.UltraWinToolbars.FileMenuStyle.None;
            ribbonTab1.Caption = "Consultas Detalle AML";
            ribbonGroup2.Caption = "Opciones";
            buttonTool1.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            buttonTool3.InstanceProps.MinimumSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            ribbonGroup2.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool3});
            ribbonGroup1.Caption = "Registros";
            buttonTool6.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            ribbonGroup1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool6});
            ribbonTab1.Groups.AddRange(new Infragistics.Win.UltraWinToolbars.RibbonGroup[] {
            ribbonGroup2,
            ribbonGroup1});
            this.ToolbarsManagerConsultasAML.Ribbon.NonInheritedRibbonTabs.AddRange(new Infragistics.Win.UltraWinToolbars.RibbonTab[] {
            ribbonTab1});
            this.ToolbarsManagerConsultasAML.Ribbon.Visible = true;
            this.ToolbarsManagerConsultasAML.ShowFullMenusDelay = 500;
            this.ToolbarsManagerConsultasAML.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2013;
            appearance13.Image = global::SmartG.Properties.Resources.add1;
            buttonTool4.SharedPropsInternal.AppearancesLarge.Appearance = appearance13;
            buttonTool4.SharedPropsInternal.Caption = "Agregar Nuevo Comentario";
            appearance14.Image = global::SmartG.Properties.Resources.abrirRegistro;
            buttonTool5.SharedPropsInternal.AppearancesLarge.Appearance = appearance14;
            buttonTool5.SharedPropsInternal.Caption = "Descargar Documentos";
            appearance15.Image = global::SmartG.Properties.Resources.reload;
            buttonTool7.SharedPropsInternal.AppearancesLarge.Appearance = appearance15;
            buttonTool7.SharedPropsInternal.Caption = "Actualizar";
            this.ToolbarsManagerConsultasAML.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool4,
            buttonTool5,
            buttonTool7});
            this.ToolbarsManagerConsultasAML.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ToolbarsManagerConsultasAML_ToolClick);
            // 
            // _BusquedaPolizas_Toolbars_Dock_Area_Top
            // 
            this._BusquedaPolizas_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._BusquedaPolizas_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._BusquedaPolizas_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._BusquedaPolizas_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._BusquedaPolizas_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._BusquedaPolizas_Toolbars_Dock_Area_Top.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._BusquedaPolizas_Toolbars_Dock_Area_Top.Name = "_BusquedaPolizas_Toolbars_Dock_Area_Top";
            this._BusquedaPolizas_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1065, 149);
            this._BusquedaPolizas_Toolbars_Dock_Area_Top.ToolbarsManager = this.ToolbarsManagerConsultasAML;
            // 
            // _BusquedaPolizas_Toolbars_Dock_Area_Bottom
            // 
            this._BusquedaPolizas_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._BusquedaPolizas_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._BusquedaPolizas_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._BusquedaPolizas_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._BusquedaPolizas_Toolbars_Dock_Area_Bottom.InitialResizeAreaExtent = 1;
            this._BusquedaPolizas_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 524);
            this._BusquedaPolizas_Toolbars_Dock_Area_Bottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._BusquedaPolizas_Toolbars_Dock_Area_Bottom.Name = "_BusquedaPolizas_Toolbars_Dock_Area_Bottom";
            this._BusquedaPolizas_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1065, 1);
            this._BusquedaPolizas_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ToolbarsManagerConsultasAML;
            // 
            // _BusquedaPolizas_Toolbars_Dock_Area_Left
            // 
            this._BusquedaPolizas_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._BusquedaPolizas_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._BusquedaPolizas_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._BusquedaPolizas_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._BusquedaPolizas_Toolbars_Dock_Area_Left.InitialResizeAreaExtent = 1;
            this._BusquedaPolizas_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 149);
            this._BusquedaPolizas_Toolbars_Dock_Area_Left.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._BusquedaPolizas_Toolbars_Dock_Area_Left.Name = "_BusquedaPolizas_Toolbars_Dock_Area_Left";
            this._BusquedaPolizas_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(1, 375);
            this._BusquedaPolizas_Toolbars_Dock_Area_Left.ToolbarsManager = this.ToolbarsManagerConsultasAML;
            // 
            // _BusquedaPolizas_Toolbars_Dock_Area_Right
            // 
            this._BusquedaPolizas_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._BusquedaPolizas_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._BusquedaPolizas_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._BusquedaPolizas_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._BusquedaPolizas_Toolbars_Dock_Area_Right.InitialResizeAreaExtent = 1;
            this._BusquedaPolizas_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1064, 149);
            this._BusquedaPolizas_Toolbars_Dock_Area_Right.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._BusquedaPolizas_Toolbars_Dock_Area_Right.Name = "_BusquedaPolizas_Toolbars_Dock_Area_Right";
            this._BusquedaPolizas_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(1, 375);
            this._BusquedaPolizas_Toolbars_Dock_Area_Right.ToolbarsManager = this.ToolbarsManagerConsultasAML;
            // 
            // VisorSolicitudesUsuario_Fill_Panel
            // 
            // 
            // VisorSolicitudesUsuario_Fill_Panel.ClientArea
            // 
            this.VisorSolicitudesUsuario_Fill_Panel.ClientArea.Controls.Add(this.dgSolicitudesDetalle);
            this.VisorSolicitudesUsuario_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.VisorSolicitudesUsuario_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisorSolicitudesUsuario_Fill_Panel.Location = new System.Drawing.Point(1, 149);
            this.VisorSolicitudesUsuario_Fill_Panel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.VisorSolicitudesUsuario_Fill_Panel.Name = "VisorSolicitudesUsuario_Fill_Panel";
            this.VisorSolicitudesUsuario_Fill_Panel.Size = new System.Drawing.Size(1063, 375);
            this.VisorSolicitudesUsuario_Fill_Panel.TabIndex = 9;
            // 
            // clientesSolicitudSeguimientoTableAdapter
            // 
            this.clientesSolicitudSeguimientoTableAdapter.ClearBeforeFill = true;
            // 
            // VisorSolicitudesUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 525);
            this.Controls.Add(this.VisorSolicitudesUsuario_Fill_Panel);
            this.Controls.Add(this._BusquedaPolizas_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._BusquedaPolizas_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._BusquedaPolizas_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._BusquedaPolizas_Toolbars_Dock_Area_Top);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VisorSolicitudesUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visor Solicitudes de Anti-Money Laundry";
            this.Load += new System.EventHandler(this.VisorSolicitudesUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSolicitudesDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesSolicitudSeguimientoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogosGral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarsManagerConsultasAML)).EndInit();
            this.VisorSolicitudesUsuario_Fill_Panel.ClientArea.ResumeLayout(false);
            this.VisorSolicitudesUsuario_Fill_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Infragistics.Win.UltraWinGrid.UltraGrid dgSolicitudesDetalle;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ToolbarsManagerConsultasAML;
        private Infragistics.Win.Misc.UltraPanel VisorSolicitudesUsuario_Fill_Panel;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _BusquedaPolizas_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _BusquedaPolizas_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _BusquedaPolizas_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _BusquedaPolizas_Toolbars_Dock_Area_Top;
        private Datasets.Catalogos.catalogosGral catalogosGral;
        private System.Windows.Forms.BindingSource clientesSolicitudSeguimientoBindingSource;
        private Datasets.Catalogos.catalogosGralTableAdapters.ClientesSolicitudSeguimientoTableAdapter clientesSolicitudSeguimientoTableAdapter;
    }
}