namespace SmartG.Operaciones.Claims
{
    partial class EditarReserva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarReserva));
            this.cbTipoReserva = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.tipoReservaClaimsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.claims = new SmartG.Datasets.Claims.Claims();
            this.lbTipoReserva = new Infragistics.Win.Misc.UltraLabel();
            this.tipoReservaClaimsTableAdapter = new SmartG.Datasets.Claims.ClaimsTableAdapters.TipoReservaClaimsTableAdapter();
            this.lbReservaAnt = new Infragistics.Win.Misc.UltraLabel();
            this.txtReservaAnterior = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtNuevaReserva = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lbNuevaReserva = new Infragistics.Win.Misc.UltraLabel();
            this.cbMonedaAnterior = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cbNuevaMoneda = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.txtTipoCambio = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lb = new Infragistics.Win.Misc.UltraLabel();
            this.cbCategoria = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lbCategoria = new Infragistics.Win.Misc.UltraLabel();
            this.tipoTransaccionReservaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoTransaccionReservaTableAdapter = new SmartG.Datasets.Claims.ClaimsTableAdapters.TipoTransaccionReservaTableAdapter();
            this.btnConsultarTC = new Infragistics.Win.Misc.UltraButton();
            this.txtNotasHistorial = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbNotas = new Infragistics.Win.Misc.UltraLabel();
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            this.btnGuardar = new Infragistics.Win.Misc.UltraButton();
            this.liabilityInc = new SmartG.Datasets.Emision.Liability.LiabilityInc();
            this.liIncMonedaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.liIncMonedaTableAdapter = new SmartG.Datasets.Emision.Liability.LiabilityIncTableAdapters.LiIncMonedaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cbTipoReserva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoReservaClaimsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.claims)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReservaAnterior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNuevaReserva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonedaAnterior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNuevaMoneda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCategoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoTransaccionReservaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotasHistorial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.liabilityInc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.liIncMonedaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cbTipoReserva
            // 
            this.cbTipoReserva.DataSource = this.tipoReservaClaimsBindingSource;
            this.cbTipoReserva.DisplayMember = "TipoReserva";
            this.cbTipoReserva.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbTipoReserva.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbTipoReserva.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoReserva.LimitToList = true;
            this.cbTipoReserva.Location = new System.Drawing.Point(218, 26);
            this.cbTipoReserva.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbTipoReserva.Name = "cbTipoReserva";
            this.cbTipoReserva.Size = new System.Drawing.Size(328, 24);
            this.cbTipoReserva.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.cbTipoReserva.TabIndex = 16;
            this.cbTipoReserva.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbTipoReserva.ValueMember = "ID";
            this.cbTipoReserva.ValueChanged += new System.EventHandler(this.cbTipoReserva_ValueChanged);
            // 
            // tipoReservaClaimsBindingSource
            // 
            this.tipoReservaClaimsBindingSource.DataMember = "TipoReservaClaims";
            this.tipoReservaClaimsBindingSource.DataSource = this.claims;
            // 
            // claims
            // 
            this.claims.DataSetName = "Claims";
            this.claims.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbTipoReserva
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.TextVAlignAsString = "Middle";
            this.lbTipoReserva.Appearance = appearance1;
            this.lbTipoReserva.Location = new System.Drawing.Point(27, 26);
            this.lbTipoReserva.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbTipoReserva.Name = "lbTipoReserva";
            this.lbTipoReserva.Size = new System.Drawing.Size(134, 28);
            this.lbTipoReserva.TabIndex = 15;
            this.lbTipoReserva.Text = "Tipo de Reserva";
            // 
            // tipoReservaClaimsTableAdapter
            // 
            this.tipoReservaClaimsTableAdapter.ClearBeforeFill = true;
            // 
            // lbReservaAnt
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.TextVAlignAsString = "Middle";
            this.lbReservaAnt.Appearance = appearance2;
            this.lbReservaAnt.Location = new System.Drawing.Point(27, 97);
            this.lbReservaAnt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbReservaAnt.Name = "lbReservaAnt";
            this.lbReservaAnt.Size = new System.Drawing.Size(161, 28);
            this.lbReservaAnt.TabIndex = 17;
            this.lbReservaAnt.Text = "Reserva Anterior (Gross)";
            // 
            // txtReservaAnterior
            // 
            this.txtReservaAnterior.Enabled = false;
            this.txtReservaAnterior.Location = new System.Drawing.Point(219, 98);
            this.txtReservaAnterior.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            this.txtReservaAnterior.Name = "txtReservaAnterior";
            this.txtReservaAnterior.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txtReservaAnterior.Size = new System.Drawing.Size(233, 24);
            this.txtReservaAnterior.TabIndex = 18;
            // 
            // txtNuevaReserva
            // 
            this.txtNuevaReserva.Location = new System.Drawing.Point(219, 134);
            this.txtNuevaReserva.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            this.txtNuevaReserva.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNuevaReserva.Name = "txtNuevaReserva";
            this.txtNuevaReserva.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txtNuevaReserva.Size = new System.Drawing.Size(233, 24);
            this.txtNuevaReserva.TabIndex = 20;
            // 
            // lbNuevaReserva
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.TextVAlignAsString = "Middle";
            this.lbNuevaReserva.Appearance = appearance3;
            this.lbNuevaReserva.Location = new System.Drawing.Point(27, 133);
            this.lbNuevaReserva.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbNuevaReserva.Name = "lbNuevaReserva";
            this.lbNuevaReserva.Size = new System.Drawing.Size(134, 28);
            this.lbNuevaReserva.TabIndex = 19;
            this.lbNuevaReserva.Text = "Nueva Reserva ";
            // 
            // cbMonedaAnterior
            // 
            this.cbMonedaAnterior.DataSource = this.liIncMonedaBindingSource;
            this.cbMonedaAnterior.DisplayMember = "Abreviacion";
            this.cbMonedaAnterior.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbMonedaAnterior.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbMonedaAnterior.Enabled = false;
            this.cbMonedaAnterior.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMonedaAnterior.LimitToList = true;
            this.cbMonedaAnterior.Location = new System.Drawing.Point(460, 97);
            this.cbMonedaAnterior.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbMonedaAnterior.Name = "cbMonedaAnterior";
            this.cbMonedaAnterior.Size = new System.Drawing.Size(86, 24);
            this.cbMonedaAnterior.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.cbMonedaAnterior.TabIndex = 21;
            this.cbMonedaAnterior.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbMonedaAnterior.ValueMember = "ID";
            // 
            // cbNuevaMoneda
            // 
            this.cbNuevaMoneda.DataSource = this.liIncMonedaBindingSource;
            this.cbNuevaMoneda.DisplayMember = "Abreviacion";
            this.cbNuevaMoneda.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbNuevaMoneda.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbNuevaMoneda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNuevaMoneda.LimitToList = true;
            this.cbNuevaMoneda.Location = new System.Drawing.Point(460, 134);
            this.cbNuevaMoneda.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbNuevaMoneda.Name = "cbNuevaMoneda";
            this.cbNuevaMoneda.Size = new System.Drawing.Size(86, 24);
            this.cbNuevaMoneda.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.cbNuevaMoneda.TabIndex = 22;
            this.cbNuevaMoneda.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbNuevaMoneda.ValueMember = "ID";
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.Location = new System.Drawing.Point(219, 170);
            this.txtTipoCambio.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txtTipoCambio.Size = new System.Drawing.Size(233, 24);
            this.txtTipoCambio.TabIndex = 24;
            // 
            // lb
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.TextVAlignAsString = "Middle";
            this.lb.Appearance = appearance4;
            this.lb.Location = new System.Drawing.Point(27, 169);
            this.lb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(186, 28);
            this.lb.TabIndex = 23;
            this.lb.Text = "Tipo de Cambio (MXN-USD)";
            // 
            // cbCategoria
            // 
            this.cbCategoria.DataSource = this.tipoTransaccionReservaBindingSource;
            this.cbCategoria.DisplayMember = "TipoTransaccion";
            this.cbCategoria.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbCategoria.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbCategoria.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategoria.LimitToList = true;
            this.cbCategoria.Location = new System.Drawing.Point(218, 62);
            this.cbCategoria.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(328, 24);
            this.cbCategoria.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.cbCategoria.TabIndex = 26;
            this.cbCategoria.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbCategoria.ValueMember = "ID";
            // 
            // lbCategoria
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.TextVAlignAsString = "Middle";
            this.lbCategoria.Appearance = appearance5;
            this.lbCategoria.Location = new System.Drawing.Point(27, 61);
            this.lbCategoria.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbCategoria.Name = "lbCategoria";
            this.lbCategoria.Size = new System.Drawing.Size(161, 28);
            this.lbCategoria.TabIndex = 25;
            this.lbCategoria.Text = "Categoria Transaccional";
            // 
            // tipoTransaccionReservaBindingSource
            // 
            this.tipoTransaccionReservaBindingSource.DataMember = "TipoTransaccionReserva";
            this.tipoTransaccionReservaBindingSource.DataSource = this.claims;
            // 
            // tipoTransaccionReservaTableAdapter
            // 
            this.tipoTransaccionReservaTableAdapter.ClearBeforeFill = true;
            // 
            // btnConsultarTC
            // 
            this.btnConsultarTC.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnConsultarTC.Location = new System.Drawing.Point(460, 170);
            this.btnConsultarTC.Name = "btnConsultarTC";
            this.btnConsultarTC.Size = new System.Drawing.Size(86, 23);
            this.btnConsultarTC.TabIndex = 27;
            this.btnConsultarTC.Text = "Consultar";
            this.btnConsultarTC.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnConsultarTC.Click += new System.EventHandler(this.btnConsultarTC_Click);
            // 
            // txtNotasHistorial
            // 
            this.txtNotasHistorial.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtNotasHistorial.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotasHistorial.Location = new System.Drawing.Point(27, 250);
            this.txtNotasHistorial.MaxLength = 15;
            this.txtNotasHistorial.Multiline = true;
            this.txtNotasHistorial.Name = "txtNotasHistorial";
            this.txtNotasHistorial.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotasHistorial.Size = new System.Drawing.Size(519, 143);
            this.txtNotasHistorial.TabIndex = 29;
            // 
            // lbNotas
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.TextVAlignAsString = "Middle";
            this.lbNotas.Appearance = appearance6;
            this.lbNotas.Location = new System.Drawing.Point(27, 221);
            this.lbNotas.Name = "lbNotas";
            this.lbNotas.Size = new System.Drawing.Size(203, 23);
            this.lbNotas.TabIndex = 28;
            this.lbNotas.Text = "Notas del Registro";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(47, 417);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(229, 24);
            this.btnCancelar.TabIndex = 48;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGuardar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(295, 417);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(229, 24);
            this.btnGuardar.TabIndex = 49;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // liabilityInc
            // 
            this.liabilityInc.DataSetName = "LiabilityInc";
            this.liabilityInc.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // liIncMonedaBindingSource
            // 
            this.liIncMonedaBindingSource.DataMember = "LiIncMoneda";
            this.liIncMonedaBindingSource.DataSource = this.liabilityInc;
            // 
            // liIncMonedaTableAdapter
            // 
            this.liIncMonedaTableAdapter.ClearBeforeFill = true;
            // 
            // EditarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 471);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtNotasHistorial);
            this.Controls.Add(this.lbNotas);
            this.Controls.Add(this.btnConsultarTC);
            this.Controls.Add(this.cbCategoria);
            this.Controls.Add(this.lbCategoria);
            this.Controls.Add(this.txtTipoCambio);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.cbNuevaMoneda);
            this.Controls.Add(this.cbMonedaAnterior);
            this.Controls.Add(this.txtNuevaReserva);
            this.Controls.Add(this.lbNuevaReserva);
            this.Controls.Add(this.txtReservaAnterior);
            this.Controls.Add(this.lbReservaAnt);
            this.Controls.Add(this.cbTipoReserva);
            this.Controls.Add(this.lbTipoReserva);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditarReserva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Reserva - ";
            this.Load += new System.EventHandler(this.EditarReserva_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbTipoReserva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoReservaClaimsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.claims)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReservaAnterior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNuevaReserva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonedaAnterior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNuevaMoneda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCategoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoTransaccionReservaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotasHistorial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.liabilityInc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.liIncMonedaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbTipoReserva;
        private Infragistics.Win.Misc.UltraLabel lbTipoReserva;
        private Datasets.Claims.Claims claims;
        private System.Windows.Forms.BindingSource tipoReservaClaimsBindingSource;
        private Datasets.Claims.ClaimsTableAdapters.TipoReservaClaimsTableAdapter tipoReservaClaimsTableAdapter;
        private Infragistics.Win.Misc.UltraLabel lbReservaAnt;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtReservaAnterior;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtNuevaReserva;
        private Infragistics.Win.Misc.UltraLabel lbNuevaReserva;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbMonedaAnterior;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbNuevaMoneda;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtTipoCambio;
        private Infragistics.Win.Misc.UltraLabel lb;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbCategoria;
        private Infragistics.Win.Misc.UltraLabel lbCategoria;
        private System.Windows.Forms.BindingSource tipoTransaccionReservaBindingSource;
        private Datasets.Claims.ClaimsTableAdapters.TipoTransaccionReservaTableAdapter tipoTransaccionReservaTableAdapter;
        private Infragistics.Win.Misc.UltraButton btnConsultarTC;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtNotasHistorial;
        private Infragistics.Win.Misc.UltraLabel lbNotas;
        private Infragistics.Win.Misc.UltraButton btnCancelar;
        private Infragistics.Win.Misc.UltraButton btnGuardar;
        private Datasets.Emision.Liability.LiabilityInc liabilityInc;
        private System.Windows.Forms.BindingSource liIncMonedaBindingSource;
        private Datasets.Emision.Liability.LiabilityIncTableAdapters.LiIncMonedaTableAdapter liIncMonedaTableAdapter;
    }
}