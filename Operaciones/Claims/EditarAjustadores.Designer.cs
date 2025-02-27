namespace SmartG.Operaciones.Claims
{
    partial class EditarAjustadores
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("RamosHonorariosAjustadores", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Check", 0);
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
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            this.cbClasifiacion = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.clasificacionAjustadoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.claims = new SmartG.Datasets.Claims.Claims();
            this.grpPoliza = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnCerrar = new Infragistics.Win.Misc.UltraButton();
            this.btnGuardar = new Infragistics.Win.Misc.UltraButton();
            this.dgRamos = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ramosHonorariosAjustadoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.txtObservaciones = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.txtEmail = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.txtTel = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.txtNombre = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtDireccion = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.clasificacionAjustadoresTableAdapter = new SmartG.Datasets.Claims.ClaimsTableAdapters.ClasificacionAjustadoresTableAdapter();
            this.ramosHonorariosAjustadoresTableAdapter = new SmartG.Datasets.Claims.ClaimsTableAdapters.RamosHonorariosAjustadoresTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cbClasifiacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clasificacionAjustadoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.claims)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPoliza)).BeginInit();
            this.grpPoliza.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRamos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramosHonorariosAjustadoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccion)).BeginInit();
            this.SuspendLayout();
            // 
            // cbClasifiacion
            // 
            this.cbClasifiacion.DataSource = this.clasificacionAjustadoresBindingSource;
            this.cbClasifiacion.DisplayMember = "Clasificacion";
            this.cbClasifiacion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbClasifiacion.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbClasifiacion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbClasifiacion.LimitToList = true;
            this.cbClasifiacion.Location = new System.Drawing.Point(215, 306);
            this.cbClasifiacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbClasifiacion.Name = "cbClasifiacion";
            this.cbClasifiacion.Size = new System.Drawing.Size(382, 24);
            this.cbClasifiacion.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.cbClasifiacion.TabIndex = 50;
            this.cbClasifiacion.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbClasifiacion.ValueMember = "ID";
            // 
            // clasificacionAjustadoresBindingSource
            // 
            this.clasificacionAjustadoresBindingSource.DataMember = "ClasificacionAjustadores";
            this.clasificacionAjustadoresBindingSource.DataSource = this.claims;
            // 
            // claims
            // 
            this.claims.DataSetName = "Claims";
            this.claims.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // grpPoliza
            // 
            this.grpPoliza.Controls.Add(this.btnCerrar);
            this.grpPoliza.Controls.Add(this.btnGuardar);
            this.grpPoliza.Controls.Add(this.dgRamos);
            this.grpPoliza.Controls.Add(this.ultraLabel7);
            this.grpPoliza.Controls.Add(this.ultraLabel5);
            this.grpPoliza.Controls.Add(this.cbClasifiacion);
            this.grpPoliza.Controls.Add(this.txtObservaciones);
            this.grpPoliza.Controls.Add(this.ultraLabel4);
            this.grpPoliza.Controls.Add(this.txtEmail);
            this.grpPoliza.Controls.Add(this.ultraLabel1);
            this.grpPoliza.Controls.Add(this.txtTel);
            this.grpPoliza.Controls.Add(this.ultraLabel6);
            this.grpPoliza.Controls.Add(this.txtNombre);
            this.grpPoliza.Controls.Add(this.txtDireccion);
            this.grpPoliza.Controls.Add(this.ultraLabel2);
            this.grpPoliza.Controls.Add(this.ultraLabel3);
            this.grpPoliza.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpPoliza.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpPoliza.Location = new System.Drawing.Point(12, 12);
            this.grpPoliza.Name = "grpPoliza";
            this.grpPoliza.Size = new System.Drawing.Size(648, 573);
            this.grpPoliza.TabIndex = 38;
            this.grpPoliza.Text = "Datos Ajustador";
            this.grpPoliza.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // btnCerrar
            // 
            this.btnCerrar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(156, 523);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(155, 23);
            this.btnCerrar.TabIndex = 56;
            this.btnCerrar.Text = "Descartar Cambios";
            this.btnCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(336, 523);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(155, 23);
            this.btnGuardar.TabIndex = 55;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgRamos
            // 
            this.dgRamos.DataSource = this.ramosHonorariosAjustadoresBindingSource;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgRamos.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn1.Width = 435;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.DataType = typeof(bool);
            ultraGridColumn3.DefaultCellValue = false;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 0;
            ultraGridColumn3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3});
            this.dgRamos.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgRamos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgRamos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.dgRamos.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgRamos.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.dgRamos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgRamos.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.dgRamos.DisplayLayout.MaxColScrollRegions = 1;
            this.dgRamos.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgRamos.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgRamos.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.dgRamos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.dgRamos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.dgRamos.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgRamos.DisplayLayout.Override.CellAppearance = appearance8;
            this.dgRamos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.dgRamos.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.dgRamos.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.dgRamos.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.dgRamos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgRamos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.dgRamos.DisplayLayout.Override.RowAppearance = appearance11;
            this.dgRamos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgRamos.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.dgRamos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgRamos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgRamos.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.dgRamos.Location = new System.Drawing.Point(31, 378);
            this.dgRamos.Name = "dgRamos";
            this.dgRamos.Size = new System.Drawing.Size(566, 120);
            this.dgRamos.TabIndex = 54;
            this.dgRamos.Text = "ultraGrid1";
            // 
            // ramosHonorariosAjustadoresBindingSource
            // 
            this.ramosHonorariosAjustadoresBindingSource.DataMember = "RamosHonorariosAjustadores";
            this.ramosHonorariosAjustadoresBindingSource.DataSource = this.claims;
            // 
            // ultraLabel7
            // 
            appearance13.BackColor = System.Drawing.Color.Transparent;
            appearance13.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance13;
            this.ultraLabel7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel7.Location = new System.Drawing.Point(31, 341);
            this.ultraLabel7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(446, 28);
            this.ultraLabel7.TabIndex = 53;
            this.ultraLabel7.Text = "Ramos de Seguro manejados por el ajustador (Ramos Empresa)";
            // 
            // ultraLabel5
            // 
            appearance14.BackColor = System.Drawing.Color.Transparent;
            appearance14.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance14;
            this.ultraLabel5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel5.Location = new System.Drawing.Point(31, 305);
            this.ultraLabel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(167, 28);
            this.ultraLabel5.TabIndex = 51;
            this.ultraLabel5.Text = "Clasificación Expertise";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtObservaciones.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(215, 194);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtObservaciones.MaxLength = 15000000;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(382, 95);
            this.txtObservaciones.TabIndex = 36;
            // 
            // ultraLabel4
            // 
            appearance15.BackColor = System.Drawing.Color.Transparent;
            appearance15.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance15;
            this.ultraLabel4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel4.Location = new System.Drawing.Point(31, 193);
            this.ultraLabel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(167, 28);
            this.ultraLabel4.TabIndex = 35;
            this.ultraLabel4.Text = "Observaciones ";
            // 
            // txtEmail
            // 
            this.txtEmail.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtEmail.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(215, 158);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.MaxLength = 150;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(382, 24);
            this.txtEmail.TabIndex = 34;
            // 
            // ultraLabel1
            // 
            appearance16.BackColor = System.Drawing.Color.Transparent;
            appearance16.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance16;
            this.ultraLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel1.Location = new System.Drawing.Point(31, 157);
            this.ultraLabel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(167, 28);
            this.ultraLabel1.TabIndex = 33;
            this.ultraLabel1.Text = "Email contacto";
            // 
            // txtTel
            // 
            this.txtTel.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtTel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTel.Location = new System.Drawing.Point(215, 122);
            this.txtTel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTel.MaxLength = 150;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(382, 24);
            this.txtTel.TabIndex = 32;
            // 
            // ultraLabel6
            // 
            appearance17.BackColor = System.Drawing.Color.Transparent;
            appearance17.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance17;
            this.ultraLabel6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel6.Location = new System.Drawing.Point(31, 121);
            this.ultraLabel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(167, 28);
            this.ultraLabel6.TabIndex = 31;
            this.ultraLabel6.Text = "Telefono Contacto";
            // 
            // txtNombre
            // 
            this.txtNombre.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtNombre.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(215, 50);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombre.MaxLength = 150;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(382, 24);
            this.txtNombre.TabIndex = 25;
            // 
            // txtDireccion
            // 
            this.txtDireccion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtDireccion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(215, 86);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDireccion.MaxLength = 150;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(382, 24);
            this.txtDireccion.TabIndex = 30;
            // 
            // ultraLabel2
            // 
            appearance18.BackColor = System.Drawing.Color.Transparent;
            appearance18.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance18;
            this.ultraLabel2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel2.Location = new System.Drawing.Point(31, 49);
            this.ultraLabel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(178, 28);
            this.ultraLabel2.TabIndex = 28;
            this.ultraLabel2.Text = "Nombre del Ajustador";
            // 
            // ultraLabel3
            // 
            appearance19.BackColor = System.Drawing.Color.Transparent;
            appearance19.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance19;
            this.ultraLabel3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel3.Location = new System.Drawing.Point(31, 85);
            this.ultraLabel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(167, 28);
            this.ultraLabel3.TabIndex = 29;
            this.ultraLabel3.Text = "Direccion Ajustador";
            // 
            // clasificacionAjustadoresTableAdapter
            // 
            this.clasificacionAjustadoresTableAdapter.ClearBeforeFill = true;
            // 
            // ramosHonorariosAjustadoresTableAdapter
            // 
            this.ramosHonorariosAjustadoresTableAdapter.ClearBeforeFill = true;
            // 
            // EditarAjustadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 605);
            this.Controls.Add(this.grpPoliza);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditarAjustadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Ajustadores";
            this.Load += new System.EventHandler(this.EditarAjustadores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbClasifiacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clasificacionAjustadoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.claims)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPoliza)).EndInit();
            this.grpPoliza.ResumeLayout(false);
            this.grpPoliza.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRamos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramosHonorariosAjustadoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox grpPoliza;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtEmail;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtTel;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtNombre;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDireccion;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtObservaciones;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbClasifiacion;
        private Infragistics.Win.UltraWinGrid.UltraGrid dgRamos;
        private Infragistics.Win.Misc.UltraButton btnCerrar;
        private Infragistics.Win.Misc.UltraButton btnGuardar;
        private Datasets.Claims.Claims claims;
        private System.Windows.Forms.BindingSource clasificacionAjustadoresBindingSource;
        private Datasets.Claims.ClaimsTableAdapters.ClasificacionAjustadoresTableAdapter clasificacionAjustadoresTableAdapter;
        private System.Windows.Forms.BindingSource ramosHonorariosAjustadoresBindingSource;
        private Datasets.Claims.ClaimsTableAdapters.RamosHonorariosAjustadoresTableAdapter ramosHonorariosAjustadoresTableAdapter;
    }
}