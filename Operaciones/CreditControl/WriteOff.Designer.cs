namespace SmartG.Operaciones.CreditControl
{
    partial class WriteOff
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
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            this.lbBuscar = new Infragistics.Win.Misc.UltraLabel();
            this.txtSnum = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.txtTipoMovimiento = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtJustificacion = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnAplicar = new Infragistics.Win.Misc.UltraButton();
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            this.cbMoneda = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.monedaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturacion = new SmartG.Datasets.CreditControl.Facturacion();
            this.txtMontoOriginal = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtMontoModificado = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.monedaTableAdapter = new SmartG.Datasets.CreditControl.FacturacionTableAdapters.MonedaTableAdapter();
            this.txtDiferencia = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            ((System.ComponentModel.ISupportInitialize)(this.txtSnum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoMovimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJustificacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMoneda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monedaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMontoOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMontoModificado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiferencia)).BeginInit();
            this.SuspendLayout();
            // 
            // lbBuscar
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.TextVAlignAsString = "Middle";
            this.lbBuscar.Appearance = appearance1;
            this.lbBuscar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBuscar.Location = new System.Drawing.Point(29, 24);
            this.lbBuscar.Name = "lbBuscar";
            this.lbBuscar.Size = new System.Drawing.Size(182, 23);
            this.lbBuscar.TabIndex = 18;
            this.lbBuscar.Text = "Journal SNum";
            // 
            // txtSnum
            // 
            appearance2.TextHAlignAsString = "Right";
            this.txtSnum.Appearance = appearance2;
            this.txtSnum.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtSnum.Enabled = false;
            this.txtSnum.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSnum.Location = new System.Drawing.Point(217, 23);
            this.txtSnum.MaxLength = 15;
            this.txtSnum.Name = "txtSnum";
            this.txtSnum.Size = new System.Drawing.Size(271, 24);
            this.txtSnum.TabIndex = 19;
            // 
            // ultraLabel1
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance3;
            this.ultraLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel1.Location = new System.Drawing.Point(29, 60);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(182, 23);
            this.ultraLabel1.TabIndex = 20;
            this.ultraLabel1.Text = "Tipo de Movimiento";
            // 
            // ultraLabel2
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance4;
            this.ultraLabel2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel2.Location = new System.Drawing.Point(29, 132);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(182, 23);
            this.ultraLabel2.TabIndex = 21;
            this.ultraLabel2.Text = "Monto Original Journal";
            // 
            // ultraLabel3
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance5;
            this.ultraLabel3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel3.Location = new System.Drawing.Point(29, 96);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(182, 23);
            this.ultraLabel3.TabIndex = 22;
            this.ultraLabel3.Text = "Moneda Journal";
            // 
            // ultraLabel4
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance6;
            this.ultraLabel4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel4.Location = new System.Drawing.Point(29, 168);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(182, 23);
            this.ultraLabel4.TabIndex = 23;
            this.ultraLabel4.Text = "Monto Modificado Journal";
            // 
            // ultraLabel5
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            appearance7.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance7;
            this.ultraLabel5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel5.Location = new System.Drawing.Point(29, 204);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(182, 23);
            this.ultraLabel5.TabIndex = 24;
            this.ultraLabel5.Text = "Diferencia";
            // 
            // ultraLabel6
            // 
            appearance8.BackColor = System.Drawing.Color.Transparent;
            appearance8.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance8;
            this.ultraLabel6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel6.Location = new System.Drawing.Point(29, 240);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(182, 23);
            this.ultraLabel6.TabIndex = 25;
            this.ultraLabel6.Text = "Justificación usuario";
            // 
            // txtTipoMovimiento
            // 
            appearance9.TextHAlignAsString = "Right";
            this.txtTipoMovimiento.Appearance = appearance9;
            this.txtTipoMovimiento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtTipoMovimiento.Enabled = false;
            this.txtTipoMovimiento.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoMovimiento.Location = new System.Drawing.Point(217, 59);
            this.txtTipoMovimiento.MaxLength = 15;
            this.txtTipoMovimiento.Name = "txtTipoMovimiento";
            this.txtTipoMovimiento.Size = new System.Drawing.Size(271, 24);
            this.txtTipoMovimiento.TabIndex = 27;
            // 
            // txtJustificacion
            // 
            this.txtJustificacion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtJustificacion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJustificacion.Location = new System.Drawing.Point(217, 239);
            this.txtJustificacion.MaxLength = 200000;
            this.txtJustificacion.Multiline = true;
            this.txtJustificacion.Name = "txtJustificacion";
            this.txtJustificacion.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtJustificacion.Size = new System.Drawing.Size(271, 77);
            this.txtJustificacion.TabIndex = 28;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAplicar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnAplicar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.Location = new System.Drawing.Point(279, 353);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(144, 28);
            this.btnAplicar.TabIndex = 29;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(107, 353);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(144, 28);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cbMoneda
            // 
            appearance10.TextHAlignAsString = "Right";
            this.cbMoneda.Appearance = appearance10;
            this.cbMoneda.DataSource = this.monedaBindingSource;
            this.cbMoneda.DisplayMember = "Moneda";
            this.cbMoneda.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbMoneda.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbMoneda.Enabled = false;
            this.cbMoneda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMoneda.LimitToList = true;
            this.cbMoneda.Location = new System.Drawing.Point(217, 96);
            this.cbMoneda.Name = "cbMoneda";
            this.cbMoneda.Size = new System.Drawing.Size(271, 24);
            this.cbMoneda.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.cbMoneda.TabIndex = 31;
            this.cbMoneda.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbMoneda.ValueMember = "ID";
            // 
            // monedaBindingSource
            // 
            this.monedaBindingSource.DataMember = "Moneda";
            this.monedaBindingSource.DataSource = this.facturacion;
            // 
            // facturacion
            // 
            this.facturacion.DataSetName = "Facturacion";
            this.facturacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtMontoOriginal
            // 
            appearance11.TextHAlignAsString = "Right";
            this.txtMontoOriginal.Appearance = appearance11;
            this.txtMontoOriginal.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtMontoOriginal.Enabled = false;
            this.txtMontoOriginal.Location = new System.Drawing.Point(217, 131);
            this.txtMontoOriginal.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            this.txtMontoOriginal.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoOriginal.Name = "txtMontoOriginal";
            this.txtMontoOriginal.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txtMontoOriginal.Size = new System.Drawing.Size(271, 24);
            this.txtMontoOriginal.TabIndex = 32;
            // 
            // txtMontoModificado
            // 
            appearance12.TextHAlignAsString = "Right";
            this.txtMontoModificado.Appearance = appearance12;
            this.txtMontoModificado.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtMontoModificado.Location = new System.Drawing.Point(217, 167);
            this.txtMontoModificado.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            this.txtMontoModificado.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoModificado.Name = "txtMontoModificado";
            this.txtMontoModificado.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txtMontoModificado.Size = new System.Drawing.Size(271, 24);
            this.txtMontoModificado.TabIndex = 33;
            this.txtMontoModificado.ValueChanged += new System.EventHandler(this.txtMontoModificado_ValueChanged);
            // 
            // monedaTableAdapter
            // 
            this.monedaTableAdapter.ClearBeforeFill = true;
            // 
            // txtDiferencia
            // 
            appearance13.TextHAlignAsString = "Right";
            this.txtDiferencia.Appearance = appearance13;
            this.txtDiferencia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtDiferencia.Enabled = false;
            this.txtDiferencia.Location = new System.Drawing.Point(217, 203);
            this.txtDiferencia.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            this.txtDiferencia.MaskInput = "-nnnnnnn.nn";
            this.txtDiferencia.Name = "txtDiferencia";
            this.txtDiferencia.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txtDiferencia.Size = new System.Drawing.Size(271, 24);
            this.txtDiferencia.TabIndex = 34;
            // 
            // WriteOff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 411);
            this.Controls.Add(this.txtDiferencia);
            this.Controls.Add(this.txtMontoModificado);
            this.Controls.Add(this.txtMontoOriginal);
            this.Controls.Add(this.cbMoneda);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.txtJustificacion);
            this.Controls.Add(this.txtTipoMovimiento);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.ultraLabel5);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.lbBuscar);
            this.Controls.Add(this.txtSnum);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WriteOff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Write Off";
            this.Load += new System.EventHandler(this.WriteOff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSnum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoMovimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJustificacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMoneda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monedaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMontoOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMontoModificado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiferencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel lbBuscar;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtSnum;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtTipoMovimiento;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtJustificacion;
        private Infragistics.Win.Misc.UltraButton btnAplicar;
        private Infragistics.Win.Misc.UltraButton btnCancelar;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbMoneda;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtMontoOriginal;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtMontoModificado;
        private Datasets.CreditControl.Facturacion facturacion;
        private System.Windows.Forms.BindingSource monedaBindingSource;
        private Datasets.CreditControl.FacturacionTableAdapters.MonedaTableAdapter monedaTableAdapter;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtDiferencia;
    }
}