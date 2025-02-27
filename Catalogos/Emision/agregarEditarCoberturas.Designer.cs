namespace SmartG.Catalogos.Emision
{
    partial class agregarEditarCoberturas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(agregarEditarCoberturas));
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            this.btnGuardar = new Infragistics.Win.Misc.UltraButton();
            this.txtCobertura = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbCobertura = new Infragistics.Win.Misc.UltraLabel();
            this.cbLineaNegocios = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.LNBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.catalogosGral = new SmartG.Datasets.Catalogos.catalogosGral();
            this.lbLineaNegocios = new Infragistics.Win.Misc.UltraLabel();
            this.lineaNegociosTableAdapter = new SmartG.Datasets.Catalogos.catalogosGralTableAdapters.LineaNegociosTableAdapter();
            this.txtCoberturaIngles = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbCoberturaIngles = new Infragistics.Win.Misc.UltraLabel();
            this.txtGeniusCode = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbGeniusCode = new Infragistics.Win.Misc.UltraLabel();
            this.lbOrigen = new Infragistics.Win.Misc.UltraLabel();
            this.cbOrigen = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.OrigenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.origenTableAdapter = new SmartG.Datasets.Catalogos.catalogosGralTableAdapters.OrigenTableAdapter();
            this.chkDefecto = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            ((System.ComponentModel.ISupportInitialize)(this.txtCobertura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLineaNegocios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LNBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogosGral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoberturaIngles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGeniusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOrigen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrigenBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDefecto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            appearance1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelar.Appearance = appearance1;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(581, 237);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            appearance2.ForeColor = System.Drawing.Color.Green;
            this.btnGuardar.Appearance = appearance2;
            this.btnGuardar.Location = new System.Drawing.Point(442, 237);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtCobertura
            // 
            this.txtCobertura.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtCobertura.Location = new System.Drawing.Point(188, 57);
            this.txtCobertura.Name = "txtCobertura";
            this.txtCobertura.Size = new System.Drawing.Size(946, 24);
            this.txtCobertura.TabIndex = 3;
            // 
            // lbCobertura
            // 
            appearance3.TextHAlignAsString = "Right";
            this.lbCobertura.Appearance = appearance3;
            this.lbCobertura.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbCobertura.Location = new System.Drawing.Point(12, 61);
            this.lbCobertura.Name = "lbCobertura";
            this.lbCobertura.Size = new System.Drawing.Size(159, 23);
            this.lbCobertura.TabIndex = 2;
            this.lbCobertura.Text = "Cobertura";
            // 
            // cbLineaNegocios
            // 
            this.cbLineaNegocios.DataSource = this.LNBindingSource;
            this.cbLineaNegocios.DisplayMember = "LineaNegocios";
            this.cbLineaNegocios.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbLineaNegocios.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbLineaNegocios.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLineaNegocios.LimitToList = true;
            this.cbLineaNegocios.Location = new System.Drawing.Point(188, 156);
            this.cbLineaNegocios.Name = "cbLineaNegocios";
            this.cbLineaNegocios.Size = new System.Drawing.Size(265, 24);
            this.cbLineaNegocios.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.cbLineaNegocios.TabIndex = 8;
            this.cbLineaNegocios.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbLineaNegocios.ValueMember = "ID";
            // 
            // LNBindingSource
            // 
            this.LNBindingSource.DataMember = "LineaNegocios";
            this.LNBindingSource.DataSource = this.catalogosGral;
            // 
            // catalogosGral
            // 
            this.catalogosGral.DataSetName = "catalogosGral";
            this.catalogosGral.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbLineaNegocios
            // 
            appearance4.TextHAlignAsString = "Right";
            this.lbLineaNegocios.Appearance = appearance4;
            this.lbLineaNegocios.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbLineaNegocios.Location = new System.Drawing.Point(12, 160);
            this.lbLineaNegocios.Name = "lbLineaNegocios";
            this.lbLineaNegocios.Size = new System.Drawing.Size(159, 23);
            this.lbLineaNegocios.TabIndex = 7;
            this.lbLineaNegocios.Text = "Linea Negocios";
            // 
            // lineaNegociosTableAdapter
            // 
            this.lineaNegociosTableAdapter.ClearBeforeFill = true;
            // 
            // txtCoberturaIngles
            // 
            this.txtCoberturaIngles.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtCoberturaIngles.Location = new System.Drawing.Point(188, 92);
            this.txtCoberturaIngles.Name = "txtCoberturaIngles";
            this.txtCoberturaIngles.Size = new System.Drawing.Size(946, 24);
            this.txtCoberturaIngles.TabIndex = 5;
            // 
            // lbCoberturaIngles
            // 
            appearance5.TextHAlignAsString = "Right";
            this.lbCoberturaIngles.Appearance = appearance5;
            this.lbCoberturaIngles.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbCoberturaIngles.Location = new System.Drawing.Point(12, 96);
            this.lbCoberturaIngles.Name = "lbCoberturaIngles";
            this.lbCoberturaIngles.Size = new System.Drawing.Size(159, 23);
            this.lbCoberturaIngles.TabIndex = 4;
            this.lbCoberturaIngles.Text = "Cobertura Inglés";
            // 
            // txtGeniusCode
            // 
            this.txtGeniusCode.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtGeniusCode.Location = new System.Drawing.Point(188, 23);
            this.txtGeniusCode.Name = "txtGeniusCode";
            this.txtGeniusCode.Size = new System.Drawing.Size(144, 24);
            this.txtGeniusCode.TabIndex = 1;
            // 
            // lbGeniusCode
            // 
            appearance6.TextHAlignAsString = "Right";
            this.lbGeniusCode.Appearance = appearance6;
            this.lbGeniusCode.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbGeniusCode.Location = new System.Drawing.Point(31, 27);
            this.lbGeniusCode.Name = "lbGeniusCode";
            this.lbGeniusCode.Size = new System.Drawing.Size(140, 23);
            this.lbGeniusCode.TabIndex = 0;
            this.lbGeniusCode.Text = "Genius Code";
            // 
            // lbOrigen
            // 
            appearance7.TextHAlignAsString = "Right";
            this.lbOrigen.Appearance = appearance7;
            this.lbOrigen.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbOrigen.Location = new System.Drawing.Point(80, 197);
            this.lbOrigen.Name = "lbOrigen";
            this.lbOrigen.Size = new System.Drawing.Size(91, 23);
            this.lbOrigen.TabIndex = 9;
            this.lbOrigen.Text = "Origen";
            // 
            // cbOrigen
            // 
            this.cbOrigen.DataSource = this.OrigenBindingSource;
            this.cbOrigen.DisplayMember = "Origen";
            this.cbOrigen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbOrigen.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbOrigen.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOrigen.LimitToList = true;
            this.cbOrigen.Location = new System.Drawing.Point(188, 193);
            this.cbOrigen.Name = "cbOrigen";
            this.cbOrigen.Size = new System.Drawing.Size(265, 24);
            this.cbOrigen.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.cbOrigen.TabIndex = 10;
            this.cbOrigen.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbOrigen.ValueMember = "ID";
            // 
            // OrigenBindingSource
            // 
            this.OrigenBindingSource.DataMember = "Origen";
            this.OrigenBindingSource.DataSource = this.catalogosGral;
            // 
            // origenTableAdapter
            // 
            this.origenTableAdapter.ClearBeforeFill = true;
            // 
            // chkDefecto
            // 
            this.chkDefecto.Location = new System.Drawing.Point(188, 127);
            this.chkDefecto.Name = "chkDefecto";
            this.chkDefecto.Size = new System.Drawing.Size(265, 20);
            this.chkDefecto.TabIndex = 6;
            this.chkDefecto.Text = "Defecto";
            // 
            // agregarEditarCoberturas
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(1148, 275);
            this.Controls.Add(this.chkDefecto);
            this.Controls.Add(this.lbOrigen);
            this.Controls.Add(this.cbOrigen);
            this.Controls.Add(this.txtGeniusCode);
            this.Controls.Add(this.lbGeniusCode);
            this.Controls.Add(this.txtCoberturaIngles);
            this.Controls.Add(this.lbCoberturaIngles);
            this.Controls.Add(this.lbLineaNegocios);
            this.Controls.Add(this.cbLineaNegocios);
            this.Controls.Add(this.txtCobertura);
            this.Controls.Add(this.lbCobertura);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "agregarEditarCoberturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar o Editar Coberturas";
            this.Load += new System.EventHandler(this.agregarEditarCoberturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCobertura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLineaNegocios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LNBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogosGral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoberturaIngles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGeniusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOrigen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrigenBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDefecto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton btnCancelar;
        private Infragistics.Win.Misc.UltraButton btnGuardar;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCobertura;
        private Infragistics.Win.Misc.UltraLabel lbCobertura;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbLineaNegocios;
        private Infragistics.Win.Misc.UltraLabel lbLineaNegocios;
        private System.Windows.Forms.BindingSource LNBindingSource;
        private Datasets.Catalogos.catalogosGral catalogosGral;
        private Datasets.Catalogos.catalogosGralTableAdapters.LineaNegociosTableAdapter lineaNegociosTableAdapter;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCoberturaIngles;
        private Infragistics.Win.Misc.UltraLabel lbCoberturaIngles;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtGeniusCode;
        private Infragistics.Win.Misc.UltraLabel lbGeniusCode;
        private Infragistics.Win.Misc.UltraLabel lbOrigen;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbOrigen;
        private System.Windows.Forms.BindingSource OrigenBindingSource;
        private Datasets.Catalogos.catalogosGralTableAdapters.OrigenTableAdapter origenTableAdapter;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkDefecto;
    }
}