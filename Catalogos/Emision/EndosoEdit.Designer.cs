namespace SmartG.Catalogos.Emision
{
    partial class EndosoEdit
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
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndosoEdit));
            this.lbLineaNegocios = new Infragistics.Win.Misc.UltraLabel();
            this.cbLineaNegocios = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.LNbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.liabilityInc = new SmartG.Datasets.Emision.Liability.LiabilityInc();
            this.txtNombreEndoso = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbNombreEndoso = new Infragistics.Win.Misc.UltraLabel();
            this.cbOrigen = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.OrigenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbOrigen = new Infragistics.Win.Misc.UltraLabel();
            this.chkDefault = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lbTexto = new Infragistics.Win.Misc.UltraLabel();
            this.txtStatus = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnIngresarTexto = new Infragistics.Win.Misc.UltraButton();
            this.btnGuardar = new Infragistics.Win.Misc.UltraButton();
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            this.btnConsultarTexto = new Infragistics.Win.Misc.UltraButton();
            this.lineaNegociosTableAdapter = new SmartG.Datasets.Emision.Liability.LiabilityIncTableAdapters.LineaNegociosTableAdapter();
            this.origenTableAdapter = new SmartG.Datasets.Emision.Liability.LiabilityIncTableAdapters.OrigenTableAdapter();
            this.lbAnexo = new Infragistics.Win.Misc.UltraLabel();
            this.cbAnexo = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lbEndosoCobertura = new Infragistics.Win.Misc.UltraLabel();
            this.cbCoberturas = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.CoberturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.liIncCoberturasTableAdapter = new SmartG.Datasets.Emision.Liability.LiabilityIncTableAdapters.LiIncCoberturasTableAdapter();
            this.btnLimpiar = new Infragistics.Win.Misc.UltraButton();
            this.liIncCoberturasDBTableAdapter = new SmartG.Datasets.Emision.Liability.LiabilityIncTableAdapters.LiIncCoberturasDBTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cbLineaNegocios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LNbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.liabilityInc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreEndoso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOrigen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrigenBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDefault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAnexo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCoberturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoberturasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lbLineaNegocios
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.TextHAlignAsString = "Center";
            this.lbLineaNegocios.Appearance = appearance1;
            this.lbLineaNegocios.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLineaNegocios.Location = new System.Drawing.Point(376, 95);
            this.lbLineaNegocios.Name = "lbLineaNegocios";
            this.lbLineaNegocios.Size = new System.Drawing.Size(133, 23);
            this.lbLineaNegocios.TabIndex = 2;
            this.lbLineaNegocios.Text = "Linea Negocios:";
            // 
            // cbLineaNegocios
            // 
            this.cbLineaNegocios.DataSource = this.LNbindingSource;
            this.cbLineaNegocios.DisplayMember = "LineaNegocios";
            this.cbLineaNegocios.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbLineaNegocios.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbLineaNegocios.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLineaNegocios.LimitToList = true;
            this.cbLineaNegocios.Location = new System.Drawing.Point(276, 126);
            this.cbLineaNegocios.Name = "cbLineaNegocios";
            this.cbLineaNegocios.Size = new System.Drawing.Size(333, 24);
            this.cbLineaNegocios.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.cbLineaNegocios.TabIndex = 3;
            this.cbLineaNegocios.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbLineaNegocios.ValueMember = "ID";
            this.cbLineaNegocios.ValueChanged += new System.EventHandler(this.activarAnexo);
            // 
            // LNbindingSource
            // 
            this.LNbindingSource.DataMember = "LineaNegocios";
            this.LNbindingSource.DataSource = this.liabilityInc;
            // 
            // liabilityInc
            // 
            this.liabilityInc.DataSetName = "LiabilityInc";
            this.liabilityInc.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtNombreEndoso
            // 
            this.txtNombreEndoso.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtNombreEndoso.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreEndoso.Location = new System.Drawing.Point(92, 63);
            this.txtNombreEndoso.Name = "txtNombreEndoso";
            this.txtNombreEndoso.Size = new System.Drawing.Size(701, 24);
            this.txtNombreEndoso.TabIndex = 1;
            // 
            // lbNombreEndoso
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.TextHAlignAsString = "Center";
            this.lbNombreEndoso.Appearance = appearance2;
            this.lbNombreEndoso.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombreEndoso.Location = new System.Drawing.Point(369, 32);
            this.lbNombreEndoso.Name = "lbNombreEndoso";
            this.lbNombreEndoso.Size = new System.Drawing.Size(147, 23);
            this.lbNombreEndoso.TabIndex = 0;
            this.lbNombreEndoso.Text = "Nombre Endoso:";
            // 
            // cbOrigen
            // 
            this.cbOrigen.DataSource = this.OrigenBindingSource;
            this.cbOrigen.DisplayMember = "Origen";
            this.cbOrigen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbOrigen.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbOrigen.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOrigen.LimitToList = true;
            this.cbOrigen.Location = new System.Drawing.Point(276, 189);
            this.cbOrigen.Name = "cbOrigen";
            this.cbOrigen.Size = new System.Drawing.Size(333, 24);
            this.cbOrigen.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.cbOrigen.TabIndex = 5;
            this.cbOrigen.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbOrigen.ValueMember = "ID";
            this.cbOrigen.ValueChanged += new System.EventHandler(this.activarAnexo);
            // 
            // OrigenBindingSource
            // 
            this.OrigenBindingSource.DataMember = "Origen";
            this.OrigenBindingSource.DataSource = this.liabilityInc;
            // 
            // lbOrigen
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.TextHAlignAsString = "Center";
            this.lbOrigen.Appearance = appearance3;
            this.lbOrigen.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOrigen.Location = new System.Drawing.Point(376, 158);
            this.lbOrigen.Name = "lbOrigen";
            this.lbOrigen.Size = new System.Drawing.Size(133, 23);
            this.lbOrigen.TabIndex = 4;
            this.lbOrigen.Text = "Origen:";
            // 
            // chkDefault
            // 
            appearance4.FontData.BoldAsString = "True";
            appearance4.FontData.SizeInPoints = 10F;
            this.chkDefault.Appearance = appearance4;
            this.chkDefault.BackColor = System.Drawing.Color.Transparent;
            this.chkDefault.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkDefault.Location = new System.Drawing.Point(388, 221);
            this.chkDefault.Name = "chkDefault";
            this.chkDefault.Size = new System.Drawing.Size(108, 20);
            this.chkDefault.TabIndex = 8;
            this.chkDefault.Text = "Por defecto";
            // 
            // lbTexto
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.TextHAlignAsString = "Center";
            this.lbTexto.Appearance = appearance5;
            this.lbTexto.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbTexto.Location = new System.Drawing.Point(191, 336);
            this.lbTexto.Name = "lbTexto";
            this.lbTexto.Size = new System.Drawing.Size(133, 23);
            this.lbTexto.TabIndex = 12;
            this.lbTexto.Text = "Texto ingresado:";
            // 
            // txtStatus
            // 
            this.txtStatus.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(330, 332);
            this.txtStatus.MaxLength = 15;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(94, 24);
            this.txtStatus.TabIndex = 13;
            // 
            // btnIngresarTexto
            // 
            this.btnIngresarTexto.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnIngresarTexto.Location = new System.Drawing.Point(443, 333);
            this.btnIngresarTexto.Name = "btnIngresarTexto";
            this.btnIngresarTexto.Size = new System.Drawing.Size(113, 23);
            this.btnIngresarTexto.TabIndex = 14;
            this.btnIngresarTexto.Text = "Ingresar Texto";
            this.btnIngresarTexto.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnIngresarTexto.Click += new System.EventHandler(this.btnIngresarTexto_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnGuardar.Location = new System.Drawing.Point(391, 386);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(113, 23);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnCancelar.Location = new System.Drawing.Point(391, 428);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(113, 23);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConsultarTexto
            // 
            this.btnConsultarTexto.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnConsultarTexto.Location = new System.Drawing.Point(576, 333);
            this.btnConsultarTexto.Name = "btnConsultarTexto";
            this.btnConsultarTexto.Size = new System.Drawing.Size(113, 23);
            this.btnConsultarTexto.TabIndex = 15;
            this.btnConsultarTexto.Text = "Ver Texto";
            this.btnConsultarTexto.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnConsultarTexto.Click += new System.EventHandler(this.btnConsultarTexto_Click);
            // 
            // lineaNegociosTableAdapter
            // 
            this.lineaNegociosTableAdapter.ClearBeforeFill = true;
            // 
            // origenTableAdapter
            // 
            this.origenTableAdapter.ClearBeforeFill = true;
            // 
            // lbAnexo
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.TextHAlignAsString = "Center";
            this.lbAnexo.Appearance = appearance6;
            this.lbAnexo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAnexo.Location = new System.Drawing.Point(660, 158);
            this.lbAnexo.Name = "lbAnexo";
            this.lbAnexo.Size = new System.Drawing.Size(133, 23);
            this.lbAnexo.TabIndex = 6;
            this.lbAnexo.Text = "Anexo:";
            this.lbAnexo.Visible = false;
            // 
            // cbAnexo
            // 
            this.cbAnexo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbAnexo.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbAnexo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            valueListItem4.DataValue = 0;
            valueListItem4.DisplayText = "1";
            valueListItem5.DataValue = 0;
            valueListItem5.DisplayText = "2";
            valueListItem6.DataValue = 0;
            valueListItem6.DisplayText = "3";
            valueListItem7.DataValue = 0;
            valueListItem7.DisplayText = "4";
            this.cbAnexo.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem4,
            valueListItem5,
            valueListItem6,
            valueListItem7});
            this.cbAnexo.Location = new System.Drawing.Point(645, 189);
            this.cbAnexo.Name = "cbAnexo";
            this.cbAnexo.Size = new System.Drawing.Size(167, 24);
            this.cbAnexo.TabIndex = 7;
            this.cbAnexo.Visible = false;
            // 
            // lbEndosoCobertura
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            appearance7.TextHAlignAsString = "Center";
            this.lbEndosoCobertura.Appearance = appearance7;
            this.lbEndosoCobertura.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEndosoCobertura.Location = new System.Drawing.Point(330, 258);
            this.lbEndosoCobertura.Name = "lbEndosoCobertura";
            this.lbEndosoCobertura.Size = new System.Drawing.Size(210, 23);
            this.lbEndosoCobertura.TabIndex = 9;
            this.lbEndosoCobertura.Text = "Cobertura (Si aplica)";
            // 
            // cbCoberturas
            // 
            appearance8.TextHAlignAsString = "Left";
            this.cbCoberturas.Appearance = appearance8;
            this.cbCoberturas.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cbCoberturas.DataSource = this.CoberturasBindingSource;
            this.cbCoberturas.DisplayMember = "Cobertura";
            this.cbCoberturas.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbCoberturas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCoberturas.LimitToList = true;
            this.cbCoberturas.Location = new System.Drawing.Point(92, 287);
            this.cbCoberturas.Name = "cbCoberturas";
            this.cbCoberturas.Size = new System.Drawing.Size(701, 24);
            this.cbCoberturas.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.cbCoberturas.TabIndex = 10;
            this.cbCoberturas.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbCoberturas.ValueMember = "ID";
            this.cbCoberturas.ItemNotInList += new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.validarCB);
            // 
            // CoberturasBindingSource
            // 
            this.CoberturasBindingSource.DataMember = "LiIncCoberturasDB";
            this.CoberturasBindingSource.DataSource = this.liabilityInc;
            // 
            // liIncCoberturasTableAdapter
            // 
            this.liIncCoberturasTableAdapter.ClearBeforeFill = true;
            // 
            // btnLimpiar
            // 
            appearance9.ImageBackground = global::SmartG.Properties.Resources.error;
            this.btnLimpiar.Appearance = appearance9;
            this.btnLimpiar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnLimpiar.Location = new System.Drawing.Point(808, 283);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(33, 32);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // liIncCoberturasDBTableAdapter
            // 
            this.liIncCoberturasDBTableAdapter.ClearBeforeFill = true;
            // 
            // EndosoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 483);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.cbCoberturas);
            this.Controls.Add(this.lbEndosoCobertura);
            this.Controls.Add(this.cbAnexo);
            this.Controls.Add(this.lbAnexo);
            this.Controls.Add(this.btnConsultarTexto);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnIngresarTexto);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lbTexto);
            this.Controls.Add(this.chkDefault);
            this.Controls.Add(this.cbOrigen);
            this.Controls.Add(this.lbOrigen);
            this.Controls.Add(this.txtNombreEndoso);
            this.Controls.Add(this.lbNombreEndoso);
            this.Controls.Add(this.cbLineaNegocios);
            this.Controls.Add(this.lbLineaNegocios);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EndosoEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar o Editar Endosos";
            this.Load += new System.EventHandler(this.EndosoEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbLineaNegocios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LNbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.liabilityInc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreEndoso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOrigen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrigenBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDefault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAnexo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCoberturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoberturasBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel lbLineaNegocios;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbLineaNegocios;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtNombreEndoso;
        private Infragistics.Win.Misc.UltraLabel lbNombreEndoso;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbOrigen;
        private Infragistics.Win.Misc.UltraLabel lbOrigen;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkDefault;
        private Infragistics.Win.Misc.UltraLabel lbTexto;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtStatus;
        private Infragistics.Win.Misc.UltraButton btnIngresarTexto;
        private Infragistics.Win.Misc.UltraButton btnGuardar;
        private Infragistics.Win.Misc.UltraButton btnCancelar;
        private Infragistics.Win.Misc.UltraButton btnConsultarTexto;
        private System.Windows.Forms.BindingSource LNbindingSource;
        private Datasets.Emision.Liability.LiabilityInc liabilityInc;
        private Datasets.Emision.Liability.LiabilityIncTableAdapters.LineaNegociosTableAdapter lineaNegociosTableAdapter;
        private System.Windows.Forms.BindingSource OrigenBindingSource;
        private Datasets.Emision.Liability.LiabilityIncTableAdapters.OrigenTableAdapter origenTableAdapter;
        private Infragistics.Win.Misc.UltraLabel lbAnexo;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbAnexo;
        private Infragistics.Win.Misc.UltraLabel lbEndosoCobertura;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbCoberturas;
        private System.Windows.Forms.BindingSource CoberturasBindingSource;
        private Datasets.Emision.Liability.LiabilityIncTableAdapters.LiIncCoberturasTableAdapter liIncCoberturasTableAdapter;
        private Infragistics.Win.Misc.UltraButton btnLimpiar;
        private Datasets.Emision.Liability.LiabilityIncTableAdapters.LiIncCoberturasDBTableAdapter liIncCoberturasDBTableAdapter;
    }
}