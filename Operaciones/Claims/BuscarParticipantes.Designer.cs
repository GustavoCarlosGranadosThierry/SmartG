namespace SmartG.Operaciones.Claims
{
    partial class BuscarParticipantes
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
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ParticipantesClaims", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Nombre");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Dirección", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RFC");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Banco");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NumCuenta");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CLABE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoRelacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TelefonoContacto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EmailContacto");
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
            this.grpBusqueda = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            this.ultraTextEditor1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.cbFiltro = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btnConsultar = new Infragistics.Win.Misc.UltraButton();
            this.lbBuscar = new Infragistics.Win.Misc.UltraLabel();
            this.lbParametro = new Infragistics.Win.Misc.UltraLabel();
            this.grpCompletadas = new Infragistics.Win.Misc.UltraGroupBox();
            this.dgParticipantes = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.participantesClaimsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.claims = new SmartG.Datasets.Claims.Claims();
            this.participantesClaimsTableAdapter = new SmartG.Datasets.Claims.ClaimsTableAdapters.ParticipantesClaimsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.grpBusqueda)).BeginInit();
            this.grpBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFiltro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCompletadas)).BeginInit();
            this.grpCompletadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgParticipantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.participantesClaimsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.claims)).BeginInit();
            this.SuspendLayout();
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
            this.grpBusqueda.Location = new System.Drawing.Point(14, 14);
            this.grpBusqueda.Name = "grpBusqueda";
            this.grpBusqueda.Size = new System.Drawing.Size(867, 110);
            this.grpBusqueda.TabIndex = 9;
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
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            // cbFiltro
            // 
            this.cbFiltro.DisplayMember = "";
            this.cbFiltro.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbFiltro.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbFiltro.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            valueListItem4.DataValue = "ValueListItem3";
            valueListItem4.DisplayText = "Nombre";
            valueListItem10.DataValue = "ValueListItem0";
            valueListItem10.DisplayText = "Direccion";
            valueListItem9.DataValue = "ValueListItem1";
            valueListItem9.DisplayText = "RFC";
            this.cbFiltro.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem4,
            valueListItem10,
            valueListItem9});
            this.cbFiltro.LimitToList = true;
            this.cbFiltro.Location = new System.Drawing.Point(107, 50);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.Size = new System.Drawing.Size(177, 24);
            this.cbFiltro.TabIndex = 4;
            this.cbFiltro.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbFiltro.ValueMember = "ID";
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
            this.grpCompletadas.Controls.Add(this.dgParticipantes);
            this.grpCompletadas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpCompletadas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpCompletadas.Location = new System.Drawing.Point(14, 130);
            this.grpCompletadas.Name = "grpCompletadas";
            this.grpCompletadas.Size = new System.Drawing.Size(867, 328);
            this.grpCompletadas.TabIndex = 8;
            this.grpCompletadas.Text = "Registros de Participantes (Doble clic para seleccionar)";
            this.grpCompletadas.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // dgParticipantes
            // 
            this.dgParticipantes.DataSource = this.participantesClaimsBindingSource;
            appearance3.BackColor = System.Drawing.SystemColors.Window;
            appearance3.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgParticipantes.DisplayLayout.Appearance = appearance3;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 302;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 301;
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn19.Header.Editor = null;
            ultraGridColumn19.Header.VisiblePosition = 8;
            ultraGridColumn20.Header.Editor = null;
            ultraGridColumn20.Header.VisiblePosition = 9;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn19,
            ultraGridColumn20});
            this.dgParticipantes.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgParticipantes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgParticipantes.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.BorderColor = System.Drawing.SystemColors.Window;
            this.dgParticipantes.DisplayLayout.GroupByBox.Appearance = appearance4;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgParticipantes.DisplayLayout.GroupByBox.BandLabelAppearance = appearance5;
            this.dgParticipantes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance6.BackColor2 = System.Drawing.SystemColors.Control;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgParticipantes.DisplayLayout.GroupByBox.PromptAppearance = appearance6;
            this.dgParticipantes.DisplayLayout.MaxColScrollRegions = 1;
            this.dgParticipantes.DisplayLayout.MaxRowScrollRegions = 1;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            appearance7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgParticipantes.DisplayLayout.Override.ActiveCellAppearance = appearance7;
            appearance8.BackColor = System.Drawing.SystemColors.Highlight;
            appearance8.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgParticipantes.DisplayLayout.Override.ActiveRowAppearance = appearance8;
            this.dgParticipantes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.dgParticipantes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            this.dgParticipantes.DisplayLayout.Override.CardAreaAppearance = appearance9;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgParticipantes.DisplayLayout.Override.CellAppearance = appearance10;
            this.dgParticipantes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.dgParticipantes.DisplayLayout.Override.CellPadding = 0;
            appearance11.BackColor = System.Drawing.SystemColors.Control;
            appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance11.BorderColor = System.Drawing.SystemColors.Window;
            this.dgParticipantes.DisplayLayout.Override.GroupByRowAppearance = appearance11;
            appearance12.TextHAlignAsString = "Left";
            this.dgParticipantes.DisplayLayout.Override.HeaderAppearance = appearance12;
            this.dgParticipantes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgParticipantes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            this.dgParticipantes.DisplayLayout.Override.RowAppearance = appearance13;
            this.dgParticipantes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance14.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgParticipantes.DisplayLayout.Override.TemplateAddRowAppearance = appearance14;
            this.dgParticipantes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgParticipantes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgParticipantes.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.dgParticipantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgParticipantes.Font = new System.Drawing.Font("Arial", 9.75F);
            this.dgParticipantes.Location = new System.Drawing.Point(2, 21);
            this.dgParticipantes.Name = "dgParticipantes";
            this.dgParticipantes.Size = new System.Drawing.Size(863, 305);
            this.dgParticipantes.TabIndex = 2;
            this.dgParticipantes.Text = "ultraGrid1";
            this.dgParticipantes.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.dgParticipantes_DoubleClickRow);
            // 
            // participantesClaimsBindingSource
            // 
            this.participantesClaimsBindingSource.DataMember = "ParticipantesClaims";
            this.participantesClaimsBindingSource.DataSource = this.claims;
            // 
            // claims
            // 
            this.claims.DataSetName = "Claims";
            this.claims.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // participantesClaimsTableAdapter
            // 
            this.participantesClaimsTableAdapter.ClearBeforeFill = true;
            // 
            // BuscarParticipantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 473);
            this.Controls.Add(this.grpBusqueda);
            this.Controls.Add(this.grpCompletadas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BuscarParticipantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BuscarParticipantes";
            this.Load += new System.EventHandler(this.BuscarParticipantes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpBusqueda)).EndInit();
            this.grpBusqueda.ResumeLayout(false);
            this.grpBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFiltro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCompletadas)).EndInit();
            this.grpCompletadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgParticipantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.participantesClaimsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.claims)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox grpBusqueda;
        private Infragistics.Win.Misc.UltraButton btnCancelar;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbFiltro;
        private Infragistics.Win.Misc.UltraButton btnConsultar;
        private Infragistics.Win.Misc.UltraLabel lbBuscar;
        private Infragistics.Win.Misc.UltraLabel lbParametro;
        private Infragistics.Win.Misc.UltraGroupBox grpCompletadas;
        private Infragistics.Win.UltraWinGrid.UltraGrid dgParticipantes;
        private Datasets.Claims.Claims claims;
        private System.Windows.Forms.BindingSource participantesClaimsBindingSource;
        private Datasets.Claims.ClaimsTableAdapters.ParticipantesClaimsTableAdapter participantesClaimsTableAdapter;
    }
}