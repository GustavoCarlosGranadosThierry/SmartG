namespace SmartG.Catalogos.Emision
{
    partial class agregarEditarSubCobertura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(agregarEditarSubCobertura));
            this.lbCoberturaPrincipal = new Infragistics.Win.Misc.UltraLabel();
            this.cbCobertura = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.CoberturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.catalogosGral = new SmartG.Datasets.Catalogos.catalogosGral();
            this.txtSubCobertura = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbSubCobertura = new Infragistics.Win.Misc.UltraLabel();
            this.chkDefecto = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            this.btnGuardar = new Infragistics.Win.Misc.UltraButton();
            this.coberturasTableAdapter = new SmartG.Datasets.Catalogos.catalogosGralTableAdapters.CoberturasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cbCobertura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoberturasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogosGral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubCobertura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDefecto)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCoberturaPrincipal
            // 
            appearance1.TextHAlignAsString = "Right";
            this.lbCoberturaPrincipal.Appearance = appearance1;
            this.lbCoberturaPrincipal.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbCoberturaPrincipal.Location = new System.Drawing.Point(38, 45);
            this.lbCoberturaPrincipal.Name = "lbCoberturaPrincipal";
            this.lbCoberturaPrincipal.Size = new System.Drawing.Size(140, 23);
            this.lbCoberturaPrincipal.TabIndex = 0;
            this.lbCoberturaPrincipal.Text = "Cobertura Asignada";
            // 
            // cbCobertura
            // 
            this.cbCobertura.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cbCobertura.DataSource = this.CoberturasBindingSource;
            this.cbCobertura.DisplayMember = "Cobertura";
            this.cbCobertura.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbCobertura.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCobertura.LimitToList = true;
            this.cbCobertura.Location = new System.Drawing.Point(193, 41);
            this.cbCobertura.Name = "cbCobertura";
            this.cbCobertura.Size = new System.Drawing.Size(265, 24);
            this.cbCobertura.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.cbCobertura.TabIndex = 1;
            this.cbCobertura.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbCobertura.ValueMember = "ID";
            // 
            // CoberturasBindingSource
            // 
            this.CoberturasBindingSource.DataMember = "Coberturas";
            this.CoberturasBindingSource.DataSource = this.catalogosGral;
            // 
            // catalogosGral
            // 
            this.catalogosGral.DataSetName = "catalogosGral";
            this.catalogosGral.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtSubCobertura
            // 
            this.txtSubCobertura.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtSubCobertura.Location = new System.Drawing.Point(193, 86);
            this.txtSubCobertura.Name = "txtSubCobertura";
            this.txtSubCobertura.Size = new System.Drawing.Size(852, 24);
            this.txtSubCobertura.TabIndex = 3;
            // 
            // lbSubCobertura
            // 
            appearance2.TextHAlignAsString = "Right";
            this.lbSubCobertura.Appearance = appearance2;
            this.lbSubCobertura.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbSubCobertura.Location = new System.Drawing.Point(76, 90);
            this.lbSubCobertura.Name = "lbSubCobertura";
            this.lbSubCobertura.Size = new System.Drawing.Size(102, 23);
            this.lbSubCobertura.TabIndex = 2;
            this.lbSubCobertura.Text = "SubCobertura";
            // 
            // chkDefecto
            // 
            this.chkDefecto.Location = new System.Drawing.Point(193, 133);
            this.chkDefecto.Name = "chkDefecto";
            this.chkDefecto.Size = new System.Drawing.Size(265, 20);
            this.chkDefecto.TabIndex = 4;
            this.chkDefecto.Text = "Defecto";
            // 
            // btnCancelar
            // 
            appearance3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelar.Appearance = appearance3;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(555, 176);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(115, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            appearance4.ForeColor = System.Drawing.Color.Green;
            this.btnGuardar.Appearance = appearance4;
            this.btnGuardar.Location = new System.Drawing.Point(416, 176);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(115, 23);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // coberturasTableAdapter
            // 
            this.coberturasTableAdapter.ClearBeforeFill = true;
            // 
            // agregarEditarSubCobertura
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(1119, 230);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.chkDefecto);
            this.Controls.Add(this.txtSubCobertura);
            this.Controls.Add(this.lbSubCobertura);
            this.Controls.Add(this.lbCoberturaPrincipal);
            this.Controls.Add(this.cbCobertura);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "agregarEditarSubCobertura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar o Editar SubCoberturas";
            this.Load += new System.EventHandler(this.agregarEditarSubCobertura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbCobertura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoberturasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogosGral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubCobertura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDefecto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel lbCoberturaPrincipal;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbCobertura;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtSubCobertura;
        private Infragistics.Win.Misc.UltraLabel lbSubCobertura;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkDefecto;
        private Infragistics.Win.Misc.UltraButton btnCancelar;
        private Infragistics.Win.Misc.UltraButton btnGuardar;
        private System.Windows.Forms.BindingSource CoberturasBindingSource;
        private Datasets.Catalogos.catalogosGral catalogosGral;
        private Datasets.Catalogos.catalogosGralTableAdapters.CoberturasTableAdapter coberturasTableAdapter;
    }
}