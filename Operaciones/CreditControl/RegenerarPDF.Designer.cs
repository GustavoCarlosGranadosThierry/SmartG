namespace SmartG.Operaciones.CreditControl
{
    partial class RegenerarPDF
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
            this.grpBusqueda = new Infragistics.Win.Misc.UltraGroupBox();
            this.lbIdentificacionFactura = new Infragistics.Win.Misc.UltraLabel();
            this.lbFactura = new Infragistics.Win.Misc.UltraLabel();
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            this.btnRegenerar = new Infragistics.Win.Misc.UltraButton();
            this.cbBroker = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.brokersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturacion = new SmartG.Datasets.CreditControl.Facturacion();
            this.cbDireccion = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.clientesDireccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbBroker = new Infragistics.Win.Misc.UltraLabel();
            this.lb = new Infragistics.Win.Misc.UltraLabel();
            this.brokersTableAdapter = new SmartG.Datasets.CreditControl.FacturacionTableAdapters.BrokersTableAdapter();
            this.clientesDireccionesTableAdapter = new SmartG.Datasets.CreditControl.FacturacionTableAdapters.ClientesDireccionesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.grpBusqueda)).BeginInit();
            this.grpBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbBroker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brokersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDireccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesDireccionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBusqueda
            // 
            this.grpBusqueda.Controls.Add(this.lbIdentificacionFactura);
            this.grpBusqueda.Controls.Add(this.lbFactura);
            this.grpBusqueda.Controls.Add(this.btnCancelar);
            this.grpBusqueda.Controls.Add(this.btnRegenerar);
            this.grpBusqueda.Controls.Add(this.cbBroker);
            this.grpBusqueda.Controls.Add(this.cbDireccion);
            this.grpBusqueda.Controls.Add(this.lbBroker);
            this.grpBusqueda.Controls.Add(this.lb);
            this.grpBusqueda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpBusqueda.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpBusqueda.Location = new System.Drawing.Point(18, 12);
            this.grpBusqueda.Name = "grpBusqueda";
            this.grpBusqueda.Size = new System.Drawing.Size(715, 200);
            this.grpBusqueda.TabIndex = 3;
            this.grpBusqueda.Text = "Regenerar Factura";
            this.grpBusqueda.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // lbIdentificacionFactura
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.TextVAlignAsString = "Middle";
            this.lbIdentificacionFactura.Appearance = appearance1;
            this.lbIdentificacionFactura.Location = new System.Drawing.Point(118, 38);
            this.lbIdentificacionFactura.Name = "lbIdentificacionFactura";
            this.lbIdentificacionFactura.Size = new System.Drawing.Size(556, 23);
            this.lbIdentificacionFactura.TabIndex = 26;
            this.lbIdentificacionFactura.Text = "[Identificacion factura]";
            // 
            // lbFactura
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.TextVAlignAsString = "Middle";
            this.lbFactura.Appearance = appearance2;
            this.lbFactura.Location = new System.Drawing.Point(27, 38);
            this.lbFactura.Name = "lbFactura";
            this.lbFactura.Size = new System.Drawing.Size(115, 23);
            this.lbFactura.TabIndex = 25;
            this.lbFactura.Text = "Factura:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnCancelar.Location = new System.Drawing.Point(154, 152);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(194, 27);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRegenerar
            // 
            this.btnRegenerar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnRegenerar.Location = new System.Drawing.Point(354, 152);
            this.btnRegenerar.Name = "btnRegenerar";
            this.btnRegenerar.Size = new System.Drawing.Size(194, 27);
            this.btnRegenerar.TabIndex = 23;
            this.btnRegenerar.Text = "Guardar y Regenerar";
            this.btnRegenerar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnRegenerar.Click += new System.EventHandler(this.btnRegenerar_Click);
            // 
            // cbBroker
            // 
            this.cbBroker.DataSource = this.brokersBindingSource;
            this.cbBroker.DisplayMember = "Broker";
            this.cbBroker.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbBroker.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbBroker.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cbBroker.LimitToList = true;
            this.cbBroker.Location = new System.Drawing.Point(118, 109);
            this.cbBroker.Name = "cbBroker";
            this.cbBroker.Size = new System.Drawing.Size(556, 24);
            this.cbBroker.TabIndex = 22;
            this.cbBroker.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbBroker.ValueMember = "ID";
            // 
            // brokersBindingSource
            // 
            this.brokersBindingSource.DataMember = "Brokers";
            this.brokersBindingSource.DataSource = this.facturacion;
            // 
            // facturacion
            // 
            this.facturacion.DataSetName = "Facturacion";
            this.facturacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbDireccion
            // 
            this.cbDireccion.DataSource = this.clientesDireccionesBindingSource;
            this.cbDireccion.DisplayMember = "DirComp";
            this.cbDireccion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbDireccion.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbDireccion.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cbDireccion.LimitToList = true;
            this.cbDireccion.Location = new System.Drawing.Point(118, 73);
            this.cbDireccion.Name = "cbDireccion";
            this.cbDireccion.Size = new System.Drawing.Size(556, 24);
            this.cbDireccion.TabIndex = 21;
            this.cbDireccion.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbDireccion.ValueMember = "ID";
            // 
            // clientesDireccionesBindingSource
            // 
            this.clientesDireccionesBindingSource.DataMember = "ClientesDirecciones";
            this.clientesDireccionesBindingSource.DataSource = this.facturacion;
            // 
            // lbBroker
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.TextVAlignAsString = "Middle";
            this.lbBroker.Appearance = appearance3;
            this.lbBroker.Location = new System.Drawing.Point(27, 110);
            this.lbBroker.Name = "lbBroker";
            this.lbBroker.Size = new System.Drawing.Size(143, 23);
            this.lbBroker.TabIndex = 15;
            this.lbBroker.Text = "Broker:";
            // 
            // lb
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.TextVAlignAsString = "Middle";
            this.lb.Appearance = appearance4;
            this.lb.Location = new System.Drawing.Point(27, 74);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(115, 23);
            this.lb.TabIndex = 10;
            this.lb.Text = "Dirección:";
            // 
            // brokersTableAdapter
            // 
            this.brokersTableAdapter.ClearBeforeFill = true;
            // 
            // clientesDireccionesTableAdapter
            // 
            this.clientesDireccionesTableAdapter.ClearBeforeFill = true;
            // 
            // RegenerarPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 224);
            this.Controls.Add(this.grpBusqueda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegenerarPDF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegenerarPDF";
            this.Load += new System.EventHandler(this.RegenerarPDF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpBusqueda)).EndInit();
            this.grpBusqueda.ResumeLayout(false);
            this.grpBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbBroker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brokersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDireccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesDireccionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox grpBusqueda;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbBroker;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbDireccion;
        private Infragistics.Win.Misc.UltraLabel lbBroker;
        private Infragistics.Win.Misc.UltraLabel lb;
        private Infragistics.Win.Misc.UltraButton btnCancelar;
        private Infragistics.Win.Misc.UltraButton btnRegenerar;
        private Datasets.CreditControl.Facturacion facturacion;
        private System.Windows.Forms.BindingSource brokersBindingSource;
        private Datasets.CreditControl.FacturacionTableAdapters.BrokersTableAdapter brokersTableAdapter;
        private System.Windows.Forms.BindingSource clientesDireccionesBindingSource;
        private Datasets.CreditControl.FacturacionTableAdapters.ClientesDireccionesTableAdapter clientesDireccionesTableAdapter;
        private Infragistics.Win.Misc.UltraLabel lbIdentificacionFactura;
        private Infragistics.Win.Misc.UltraLabel lbFactura;
    }
}