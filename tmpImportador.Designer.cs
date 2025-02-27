namespace SmartG
{
    partial class tmpImportador
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
            Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement1 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
            Infragistics.UltraChart.Resources.Appearance.GradientEffect gradientEffect1 = new Infragistics.UltraChart.Resources.Appearance.GradientEffect();
            Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement2 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
            Infragistics.UltraChart.Resources.Appearance.GradientEffect gradientEffect2 = new Infragistics.UltraChart.Resources.Appearance.GradientEffect();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tmpImportador));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgDatosImportar = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraPieChart1 = new Infragistics.Win.DataVisualization.UltraPieChart();
            this.ultraChart2 = new Infragistics.Win.UltraWinChart.UltraChart();
            this.ultraChart1 = new Infragistics.Win.UltraWinChart.UltraChart();
            this.testReportes = new SmartG.Datasets.Reportes.TestReportes();
            this.grpOpciones = new Infragistics.Win.Misc.UltraGroupBox();
            this.lbYear = new Infragistics.Win.Misc.UltraLabel();
            this.lbHasta = new Infragistics.Win.Misc.UltraLabel();
            this.lbInicio = new Infragistics.Win.Misc.UltraLabel();
            this.dateYear = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.dateFin = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.dateInicio = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.btnDemoReporte = new Infragistics.Win.Misc.UltraButton();
            this.btnImportar = new Infragistics.Win.Misc.UltraButton();
            this.btnCargarExcel = new Infragistics.Win.Misc.UltraButton();
            this.ultraCalendarInfo1 = new Infragistics.Win.UltraWinSchedule.UltraCalendarInfo(this.components);
            this.BindingSourceReporte = new System.Windows.Forms.BindingSource(this.components);
            this.polizaReporteDemoTableAdapter = new SmartG.Datasets.Reportes.TestReportesTableAdapters.PolizaReporteDemoTableAdapter();
            this.cYDEMOTableAdapter = new SmartG.Datasets.Reportes.TestReportesTableAdapters.CYDEMOTableAdapter();
            this.btnImportarDocs = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDatosImportar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraPieChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraChart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testReportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpOpciones)).BeginInit();
            this.grpOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgDatosImportar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.AutoScrollMargin = new System.Drawing.Size(0, 50);
            this.splitContainer1.Panel2.Controls.Add(this.ultraPieChart1);
            this.splitContainer1.Panel2.Controls.Add(this.ultraChart2);
            this.splitContainer1.Panel2.Controls.Add(this.ultraChart1);
            this.splitContainer1.Panel2.Controls.Add(this.grpOpciones);
            this.splitContainer1.Size = new System.Drawing.Size(1587, 781);
            this.splitContainer1.SplitterDistance = 778;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgDatosImportar
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgDatosImportar.DisplayLayout.Appearance = appearance1;
            this.dgDatosImportar.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgDatosImportar.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.dgDatosImportar.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgDatosImportar.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.dgDatosImportar.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgDatosImportar.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.dgDatosImportar.DisplayLayout.MaxColScrollRegions = 1;
            this.dgDatosImportar.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgDatosImportar.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgDatosImportar.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.dgDatosImportar.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.dgDatosImportar.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.dgDatosImportar.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.dgDatosImportar.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgDatosImportar.DisplayLayout.Override.CellAppearance = appearance8;
            this.dgDatosImportar.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.dgDatosImportar.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.dgDatosImportar.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.dgDatosImportar.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.dgDatosImportar.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgDatosImportar.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.dgDatosImportar.DisplayLayout.Override.RowAppearance = appearance11;
            this.dgDatosImportar.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgDatosImportar.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.dgDatosImportar.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgDatosImportar.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgDatosImportar.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.dgDatosImportar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDatosImportar.Location = new System.Drawing.Point(0, 0);
            this.dgDatosImportar.Name = "dgDatosImportar";
            this.dgDatosImportar.Size = new System.Drawing.Size(778, 781);
            this.dgDatosImportar.TabIndex = 0;
            this.dgDatosImportar.Text = "ultraGrid1";
            this.dgDatosImportar.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.dgDatosImportar_InitializeRow);
            // 
            // ultraPieChart1
            // 
            this.ultraPieChart1.BackColor = System.Drawing.Color.White;
            this.ultraPieChart1.FontSize = 14D;
            this.ultraPieChart1.Location = new System.Drawing.Point(13, 730);
            this.ultraPieChart1.Name = "ultraPieChart1";
            this.ultraPieChart1.SelectedStyle.Opacity = 1D;
            this.ultraPieChart1.SelectedStyle.Stroke = new Infragistics.Win.DataVisualization.SolidColorBrush(System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))));
            this.ultraPieChart1.SelectedStyle.StrokeThickness = 6D;
            this.ultraPieChart1.Size = new System.Drawing.Size(687, 382);
            this.ultraPieChart1.TabIndex = 4;
            this.ultraPieChart1.Text = "ultraPieChart1";
            this.ultraPieChart1.SliceClick += new Infragistics.Win.DataVisualization.SliceClickEventHandler(this.ultraPieChart1_SliceClick);
            // 
//			'UltraChart' properties's serialization: Since 'ChartType' changes the way axes look,
//			'ChartType' must be persisted ahead of any Axes change made in design time.
//		
            this.ultraChart2.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.LineChart;
            // 
            // ultraChart2
            // 
            this.ultraChart2.Axis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            paintElement1.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.None;
            paintElement1.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            this.ultraChart2.Axis.PE = paintElement1;
            this.ultraChart2.Axis.X.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.X.Labels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart2.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart2.Axis.X.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.ultraChart2.Axis.X.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.ultraChart2.Axis.X.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.X.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart2.Axis.X.Labels.SeriesLabels.FormatString = "";
            this.ultraChart2.Axis.X.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart2.Axis.X.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.X.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.ultraChart2.Axis.X.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.X.Labels.SeriesLabels.Visible = true;
            this.ultraChart2.Axis.X.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.X.Labels.Visible = true;
            this.ultraChart2.Axis.X.LineThickness = 1;
            this.ultraChart2.Axis.X.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.X.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart2.Axis.X.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.X.MajorGridLines.Visible = true;
            this.ultraChart2.Axis.X.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.X.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart2.Axis.X.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.X.MinorGridLines.Visible = false;
            this.ultraChart2.Axis.X.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart2.Axis.X.Visible = true;
            this.ultraChart2.Axis.X2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.X2.Labels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart2.Axis.X2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.ultraChart2.Axis.X2.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.ultraChart2.Axis.X2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.X2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.ultraChart2.Axis.X2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.X2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart2.Axis.X2.Labels.SeriesLabels.FormatString = "";
            this.ultraChart2.Axis.X2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.ultraChart2.Axis.X2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.X2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.ultraChart2.Axis.X2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.X2.Labels.SeriesLabels.Visible = true;
            this.ultraChart2.Axis.X2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.X2.Labels.Visible = false;
            this.ultraChart2.Axis.X2.LineThickness = 1;
            this.ultraChart2.Axis.X2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.X2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart2.Axis.X2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.X2.MajorGridLines.Visible = true;
            this.ultraChart2.Axis.X2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.X2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart2.Axis.X2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.X2.MinorGridLines.Visible = false;
            this.ultraChart2.Axis.X2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart2.Axis.X2.Visible = false;
            this.ultraChart2.Axis.Y.Extent = 53;
            this.ultraChart2.Axis.Y.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.Y.Labels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart2.Axis.Y.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.ultraChart2.Axis.Y.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.ultraChart2.Axis.Y.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.Y.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart2.Axis.Y.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.Y.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart2.Axis.Y.Labels.SeriesLabels.FormatString = "";
            this.ultraChart2.Axis.Y.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.ultraChart2.Axis.Y.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.Y.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart2.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.Y.Labels.SeriesLabels.Visible = true;
            this.ultraChart2.Axis.Y.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.Y.Labels.Visible = true;
            this.ultraChart2.Axis.Y.LineThickness = 1;
            this.ultraChart2.Axis.Y.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.Y.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart2.Axis.Y.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.Y.MajorGridLines.Visible = true;
            this.ultraChart2.Axis.Y.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.Y.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart2.Axis.Y.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.Y.MinorGridLines.Visible = false;
            this.ultraChart2.Axis.Y.TickmarkInterval = 50D;
            this.ultraChart2.Axis.Y.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart2.Axis.Y.Visible = true;
            this.ultraChart2.Axis.Y2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.Y2.Labels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart2.Axis.Y2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart2.Axis.Y2.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.ultraChart2.Axis.Y2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.Y2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart2.Axis.Y2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.Y2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart2.Axis.Y2.Labels.SeriesLabels.FormatString = "";
            this.ultraChart2.Axis.Y2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart2.Axis.Y2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.Y2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart2.Axis.Y2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.Y2.Labels.SeriesLabels.Visible = true;
            this.ultraChart2.Axis.Y2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.Y2.Labels.Visible = false;
            this.ultraChart2.Axis.Y2.LineThickness = 1;
            this.ultraChart2.Axis.Y2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.Y2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart2.Axis.Y2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.Y2.MajorGridLines.Visible = true;
            this.ultraChart2.Axis.Y2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.Y2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart2.Axis.Y2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.Y2.MinorGridLines.Visible = false;
            this.ultraChart2.Axis.Y2.TickmarkInterval = 50D;
            this.ultraChart2.Axis.Y2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart2.Axis.Y2.Visible = false;
            this.ultraChart2.Axis.Z.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.Z.Labels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart2.Axis.Z.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart2.Axis.Z.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.ultraChart2.Axis.Z.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.Z.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart2.Axis.Z.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.Z.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart2.Axis.Z.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart2.Axis.Z.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.Z.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart2.Axis.Z.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.Z.Labels.SeriesLabels.Visible = true;
            this.ultraChart2.Axis.Z.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.Z.Labels.Visible = false;
            this.ultraChart2.Axis.Z.LineThickness = 1;
            this.ultraChart2.Axis.Z.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.Z.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart2.Axis.Z.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.Z.MajorGridLines.Visible = true;
            this.ultraChart2.Axis.Z.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.Z.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart2.Axis.Z.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.Z.MinorGridLines.Visible = false;
            this.ultraChart2.Axis.Z.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart2.Axis.Z.Visible = false;
            this.ultraChart2.Axis.Z2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.Z2.Labels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart2.Axis.Z2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart2.Axis.Z2.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.ultraChart2.Axis.Z2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.Z2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart2.Axis.Z2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.Z2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart2.Axis.Z2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart2.Axis.Z2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.Z2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart2.Axis.Z2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.Z2.Labels.SeriesLabels.Visible = true;
            this.ultraChart2.Axis.Z2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.Z2.Labels.Visible = false;
            this.ultraChart2.Axis.Z2.LineThickness = 1;
            this.ultraChart2.Axis.Z2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.Z2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart2.Axis.Z2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.Z2.MajorGridLines.Visible = true;
            this.ultraChart2.Axis.Z2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.Z2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart2.Axis.Z2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.Z2.MinorGridLines.Visible = false;
            this.ultraChart2.Axis.Z2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart2.Axis.Z2.Visible = false;
            this.ultraChart2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ultraChart2.ColorModel.AlphaLevel = ((byte)(150));
            this.ultraChart2.ColorModel.ColorBegin = System.Drawing.Color.Pink;
            this.ultraChart2.ColorModel.ColorEnd = System.Drawing.Color.DarkRed;
            this.ultraChart2.ColorModel.ModelStyle = Infragistics.UltraChart.Shared.Styles.ColorModels.CustomLinear;
            this.ultraChart2.Data.SwapRowsAndColumns = true;
            this.ultraChart2.Effects.Effects.Add(gradientEffect1);
            this.ultraChart2.Location = new System.Drawing.Point(13, 452);
            this.ultraChart2.Name = "ultraChart2";
            this.ultraChart2.Size = new System.Drawing.Size(687, 256);
            this.ultraChart2.TabIndex = 3;
            this.ultraChart2.TitleTop.HorizontalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.TitleTop.Text = "GWD";
            this.ultraChart2.Tooltips.HighlightFillColor = System.Drawing.Color.DimGray;
            this.ultraChart2.Tooltips.HighlightOutlineColor = System.Drawing.Color.DarkGray;
            // 
            // ultraChart1
            // 
            this.ultraChart1.Axis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            paintElement2.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.None;
            paintElement2.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            this.ultraChart1.Axis.PE = paintElement2;
            this.ultraChart1.Axis.X.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.X.Labels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart1.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart1.Axis.X.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.ultraChart1.Axis.X.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.ultraChart1.Axis.X.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.X.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart1.Axis.X.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.X.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.X.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart1.Axis.X.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.X.Labels.SeriesLabels.Visible = true;
            this.ultraChart1.Axis.X.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.X.Labels.Visible = true;
            this.ultraChart1.Axis.X.LineThickness = 1;
            this.ultraChart1.Axis.X.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.X.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart1.Axis.X.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.X.MajorGridLines.Visible = true;
            this.ultraChart1.Axis.X.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.X.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart1.Axis.X.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.X.MinorGridLines.Visible = false;
            this.ultraChart1.Axis.X.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart1.Axis.X.Visible = true;
            this.ultraChart1.Axis.X2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.X2.Labels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart1.Axis.X2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.ultraChart1.Axis.X2.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.ultraChart1.Axis.X2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.X2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.ultraChart1.Axis.X2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.X2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart1.Axis.X2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.X2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.X2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart1.Axis.X2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.X2.Labels.SeriesLabels.Visible = true;
            this.ultraChart1.Axis.X2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.X2.Labels.Visible = false;
            this.ultraChart1.Axis.X2.LineThickness = 1;
            this.ultraChart1.Axis.X2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.X2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart1.Axis.X2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.X2.MajorGridLines.Visible = true;
            this.ultraChart1.Axis.X2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.X2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart1.Axis.X2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.X2.MinorGridLines.Visible = false;
            this.ultraChart1.Axis.X2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart1.Axis.X2.Visible = false;
            this.ultraChart1.Axis.Y.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.Y.Labels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart1.Axis.Y.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.ultraChart1.Axis.Y.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.ultraChart1.Axis.Y.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Y.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart1.Axis.Y.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.Y.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart1.Axis.Y.Labels.SeriesLabels.FormatString = "";
            this.ultraChart1.Axis.Y.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.ultraChart1.Axis.Y.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Y.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.ultraChart1.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.Y.Labels.SeriesLabels.Visible = true;
            this.ultraChart1.Axis.Y.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.Y.Labels.Visible = true;
            this.ultraChart1.Axis.Y.LineThickness = 1;
            this.ultraChart1.Axis.Y.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.Y.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart1.Axis.Y.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.Y.MajorGridLines.Visible = true;
            this.ultraChart1.Axis.Y.Margin.Far.Value = 2.3529411764705883D;
            this.ultraChart1.Axis.Y.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.Y.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart1.Axis.Y.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.Y.MinorGridLines.Visible = false;
            this.ultraChart1.Axis.Y.TickmarkInterval = 10D;
            this.ultraChart1.Axis.Y.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart1.Axis.Y.Visible = true;
            this.ultraChart1.Axis.Y2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.Y2.Labels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart1.Axis.Y2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart1.Axis.Y2.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.ultraChart1.Axis.Y2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Y2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart1.Axis.Y2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.Y2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart1.Axis.Y2.Labels.SeriesLabels.FormatString = "";
            this.ultraChart1.Axis.Y2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart1.Axis.Y2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Y2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.ultraChart1.Axis.Y2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.Y2.Labels.SeriesLabels.Visible = true;
            this.ultraChart1.Axis.Y2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.Y2.Labels.Visible = false;
            this.ultraChart1.Axis.Y2.LineThickness = 1;
            this.ultraChart1.Axis.Y2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.Y2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart1.Axis.Y2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.Y2.MajorGridLines.Visible = true;
            this.ultraChart1.Axis.Y2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.Y2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart1.Axis.Y2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.Y2.MinorGridLines.Visible = false;
            this.ultraChart1.Axis.Y2.TickmarkInterval = 10D;
            this.ultraChart1.Axis.Y2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart1.Axis.Y2.Visible = false;
            this.ultraChart1.Axis.Z.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.Z.Labels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart1.Axis.Z.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart1.Axis.Z.Labels.ItemFormatString = "";
            this.ultraChart1.Axis.Z.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Z.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart1.Axis.Z.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.Z.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart1.Axis.Z.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart1.Axis.Z.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Z.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart1.Axis.Z.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.Z.Labels.SeriesLabels.Visible = true;
            this.ultraChart1.Axis.Z.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.Z.Labels.Visible = false;
            this.ultraChart1.Axis.Z.LineThickness = 1;
            this.ultraChart1.Axis.Z.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.Z.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart1.Axis.Z.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.Z.MajorGridLines.Visible = true;
            this.ultraChart1.Axis.Z.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.Z.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart1.Axis.Z.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.Z.MinorGridLines.Visible = false;
            this.ultraChart1.Axis.Z.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart1.Axis.Z.Visible = false;
            this.ultraChart1.Axis.Z2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.Z2.Labels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart1.Axis.Z2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart1.Axis.Z2.Labels.ItemFormatString = "";
            this.ultraChart1.Axis.Z2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Z2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart1.Axis.Z2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.Z2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart1.Axis.Z2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart1.Axis.Z2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Z2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart1.Axis.Z2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.Z2.Labels.SeriesLabels.Visible = true;
            this.ultraChart1.Axis.Z2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.Z2.Labels.Visible = false;
            this.ultraChart1.Axis.Z2.LineThickness = 1;
            this.ultraChart1.Axis.Z2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.Z2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart1.Axis.Z2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.Z2.MajorGridLines.Visible = true;
            this.ultraChart1.Axis.Z2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.Z2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart1.Axis.Z2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.Z2.MinorGridLines.Visible = false;
            this.ultraChart1.Axis.Z2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart1.Axis.Z2.Visible = false;
            this.ultraChart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ultraChart1.ColorModel.AlphaLevel = ((byte)(150));
            this.ultraChart1.ColorModel.ColorBegin = System.Drawing.Color.Pink;
            this.ultraChart1.ColorModel.ColorEnd = System.Drawing.Color.DarkRed;
            this.ultraChart1.ColorModel.ModelStyle = Infragistics.UltraChart.Shared.Styles.ColorModels.CustomLinear;
            this.ultraChart1.Data.DataMember = "CYDEMO";
            this.ultraChart1.DataMember = "CYDEMO";
            this.ultraChart1.DataSource = this.testReportes;
            this.ultraChart1.Effects.Effects.Add(gradientEffect2);
            this.ultraChart1.Location = new System.Drawing.Point(13, 212);
            this.ultraChart1.Name = "ultraChart1";
            this.ultraChart1.Size = new System.Drawing.Size(687, 224);
            this.ultraChart1.TabIndex = 2;
            this.ultraChart1.TitleTop.HorizontalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.TitleTop.Text = "GWD";
            this.ultraChart1.Tooltips.HighlightFillColor = System.Drawing.Color.DimGray;
            this.ultraChart1.Tooltips.HighlightOutlineColor = System.Drawing.Color.DarkGray;
            // 
            // testReportes
            // 
            this.testReportes.DataSetName = "TestReportes";
            this.testReportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // grpOpciones
            // 
            this.grpOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOpciones.Controls.Add(this.btnImportarDocs);
            this.grpOpciones.Controls.Add(this.lbYear);
            this.grpOpciones.Controls.Add(this.lbHasta);
            this.grpOpciones.Controls.Add(this.lbInicio);
            this.grpOpciones.Controls.Add(this.dateYear);
            this.grpOpciones.Controls.Add(this.dateFin);
            this.grpOpciones.Controls.Add(this.dateInicio);
            this.grpOpciones.Controls.Add(this.btnDemoReporte);
            this.grpOpciones.Controls.Add(this.btnImportar);
            this.grpOpciones.Controls.Add(this.btnCargarExcel);
            this.grpOpciones.Location = new System.Drawing.Point(13, 21);
            this.grpOpciones.Name = "grpOpciones";
            this.grpOpciones.Size = new System.Drawing.Size(722, 164);
            this.grpOpciones.TabIndex = 0;
            this.grpOpciones.Text = "Opciones";
            // 
            // lbYear
            // 
            this.lbYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbYear.Location = new System.Drawing.Point(355, 95);
            this.lbYear.Name = "lbYear";
            this.lbYear.Size = new System.Drawing.Size(100, 23);
            this.lbYear.TabIndex = 4;
            this.lbYear.Text = "Año";
            this.lbYear.Visible = false;
            // 
            // lbHasta
            // 
            this.lbHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbHasta.Location = new System.Drawing.Point(213, 96);
            this.lbHasta.Name = "lbHasta";
            this.lbHasta.Size = new System.Drawing.Size(100, 23);
            this.lbHasta.TabIndex = 3;
            this.lbHasta.Text = "Hasta";
            // 
            // lbInicio
            // 
            this.lbInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbInicio.Location = new System.Drawing.Point(41, 96);
            this.lbInicio.Name = "lbInicio";
            this.lbInicio.Size = new System.Drawing.Size(100, 23);
            this.lbInicio.TabIndex = 2;
            this.lbInicio.Text = "Desde";
            // 
            // dateYear
            // 
            this.dateYear.Location = new System.Drawing.Point(349, 124);
            this.dateYear.Name = "dateYear";
            this.dateYear.Size = new System.Drawing.Size(106, 21);
            this.dateYear.TabIndex = 7;
            this.dateYear.Visible = false;
            // 
            // dateFin
            // 
            this.dateFin.Location = new System.Drawing.Point(207, 124);
            this.dateFin.Name = "dateFin";
            this.dateFin.Size = new System.Drawing.Size(106, 21);
            this.dateFin.TabIndex = 6;
            // 
            // dateInicio
            // 
            this.dateInicio.Location = new System.Drawing.Point(35, 124);
            this.dateInicio.MaskInput = "";
            this.dateInicio.Name = "dateInicio";
            this.dateInicio.Size = new System.Drawing.Size(106, 21);
            this.dateInicio.TabIndex = 5;
            // 
            // btnDemoReporte
            // 
            this.btnDemoReporte.Location = new System.Drawing.Point(501, 123);
            this.btnDemoReporte.Name = "btnDemoReporte";
            this.btnDemoReporte.Size = new System.Drawing.Size(106, 23);
            this.btnDemoReporte.TabIndex = 8;
            this.btnDemoReporte.Text = "Reportear";
            this.btnDemoReporte.Click += new System.EventHandler(this.btnDemoReporte_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(208, 47);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(106, 23);
            this.btnImportar.TabIndex = 1;
            this.btnImportar.Text = "Importar";
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnCargarExcel
            // 
            this.btnCargarExcel.Location = new System.Drawing.Point(36, 47);
            this.btnCargarExcel.Name = "btnCargarExcel";
            this.btnCargarExcel.Size = new System.Drawing.Size(106, 23);
            this.btnCargarExcel.TabIndex = 0;
            this.btnCargarExcel.Text = "Cargar Archivo";
            this.btnCargarExcel.Click += new System.EventHandler(this.btnCargarExcel_Click);
            // 
            // ultraCalendarInfo1
            // 
            this.ultraCalendarInfo1.DataBindingsForAppointments.BindingContextControl = this;
            this.ultraCalendarInfo1.DataBindingsForOwners.BindingContextControl = this;
            // 
            // BindingSourceReporte
            // 
            this.BindingSourceReporte.DataMember = "CYDEMO";
            this.BindingSourceReporte.DataSource = this.testReportes;
            // 
            // polizaReporteDemoTableAdapter
            // 
            this.polizaReporteDemoTableAdapter.ClearBeforeFill = true;
            // 
            // cYDEMOTableAdapter
            // 
            this.cYDEMOTableAdapter.ClearBeforeFill = true;
            // 
            // btnImportarDocs
            // 
            this.btnImportarDocs.Location = new System.Drawing.Point(462, 47);
            this.btnImportarDocs.Name = "btnImportarDocs";
            this.btnImportarDocs.Size = new System.Drawing.Size(145, 23);
            this.btnImportarDocs.TabIndex = 9;
            this.btnImportarDocs.Text = "Importar Docs";
            this.btnImportarDocs.Click += new System.EventHandler(this.btnImportarDocs_Click);
            // 
            // tmpImportador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1587, 781);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "tmpImportador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "temporal importacion";
            this.Load += new System.EventHandler(this.tmpImportador_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDatosImportar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraPieChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraChart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testReportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpOpciones)).EndInit();
            this.grpOpciones.ResumeLayout(false);
            this.grpOpciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceReporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Infragistics.Win.UltraWinGrid.UltraGrid dgDatosImportar;
        private Infragistics.Win.Misc.UltraGroupBox grpOpciones;
        private Infragistics.Win.Misc.UltraButton btnCargarExcel;
        private Infragistics.Win.Misc.UltraButton btnImportar;
        private Infragistics.Win.UltraWinChart.UltraChart ultraChart1;
        private Infragistics.Win.Misc.UltraButton btnDemoReporte;
        private System.Windows.Forms.BindingSource BindingSourceReporte;
        private Datasets.Reportes.TestReportes testReportes;
        private Datasets.Reportes.TestReportesTableAdapters.PolizaReporteDemoTableAdapter polizaReporteDemoTableAdapter;
        private Infragistics.Win.Misc.UltraLabel lbYear;
        private Infragistics.Win.Misc.UltraLabel lbHasta;
        private Infragistics.Win.Misc.UltraLabel lbInicio;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarInfo ultraCalendarInfo1;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dateYear;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dateFin;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dateInicio;
        private Datasets.Reportes.TestReportesTableAdapters.CYDEMOTableAdapter cYDEMOTableAdapter;
        private Infragistics.Win.UltraWinChart.UltraChart ultraChart2;
        private Infragistics.Win.DataVisualization.UltraPieChart ultraPieChart1;
        private Infragistics.Win.Misc.UltraButton btnImportarDocs;
    }
}