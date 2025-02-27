namespace SmartG.Operaciones.CreditControl
{
    partial class EditarFactura
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.cbStatus = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.statusFacturacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturacion = new SmartG.Datasets.CreditControl.Facturacion();
            this.cbCondicones = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.formaPagoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAplicar = new Infragistics.Win.Misc.UltraButton();
            this.grpDatos = new Infragistics.Win.Misc.UltraGroupBox();
            this.lbEditarDireccion = new Infragistics.Win.Misc.UltraLabel();
            this.cbDirecciones = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.clientesDireccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            this.lbCondiciones = new Infragistics.Win.Misc.UltraLabel();
            this.lbStatus = new Infragistics.Win.Misc.UltraLabel();
            this.formaPagoTableAdapter = new SmartG.Datasets.CreditControl.FacturacionTableAdapters.FormaPagoTableAdapter();
            this.statusFacturacionTableAdapter = new SmartG.Datasets.CreditControl.FacturacionTableAdapters.StatusFacturacionTableAdapter();
            this.clientesDireccionesTableAdapter = new SmartG.Datasets.CreditControl.FacturacionTableAdapters.ClientesDireccionesTableAdapter();
            this.btnNuevoReciboCeros = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.cbStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusFacturacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCondicones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formaPagoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpDatos)).BeginInit();
            this.grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDirecciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesDireccionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cbStatus
            // 
            this.cbStatus.DataSource = this.statusFacturacionBindingSource;
            this.cbStatus.DisplayMember = "Status";
            this.cbStatus.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbStatus.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatus.LimitToList = true;
            this.cbStatus.Location = new System.Drawing.Point(212, 72);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(305, 24);
            this.cbStatus.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.cbStatus.TabIndex = 13;
            this.cbStatus.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbStatus.ValueMember = "ID";
            this.cbStatus.ItemNotInList += new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.validarCB);
            // 
            // statusFacturacionBindingSource
            // 
            this.statusFacturacionBindingSource.DataMember = "StatusFacturacion";
            this.statusFacturacionBindingSource.DataSource = this.facturacion;
            // 
            // facturacion
            // 
            this.facturacion.DataSetName = "Facturacion";
            this.facturacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbCondicones
            // 
            this.cbCondicones.DataSource = this.formaPagoBindingSource;
            this.cbCondicones.DisplayMember = "FormaPago";
            this.cbCondicones.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbCondicones.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbCondicones.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCondicones.LimitToList = true;
            this.cbCondicones.Location = new System.Drawing.Point(212, 36);
            this.cbCondicones.Name = "cbCondicones";
            this.cbCondicones.Size = new System.Drawing.Size(305, 24);
            this.cbCondicones.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.cbCondicones.TabIndex = 12;
            this.cbCondicones.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbCondicones.ValueMember = "ID";
            this.cbCondicones.ItemNotInList += new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.validarCB);
            // 
            // formaPagoBindingSource
            // 
            this.formaPagoBindingSource.DataMember = "FormaPago";
            this.formaPagoBindingSource.DataSource = this.facturacion;
            // 
            // btnAplicar
            // 
            this.btnAplicar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnAplicar.Location = new System.Drawing.Point(36, 145);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(480, 27);
            this.btnAplicar.TabIndex = 17;
            this.btnAplicar.Text = "Aplicar Cambios";
            this.btnAplicar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnAplicar.Click += new System.EventHandler(this.btnAsignarCuenta_Click);
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.btnNuevoReciboCeros);
            this.grpDatos.Controls.Add(this.lbEditarDireccion);
            this.grpDatos.Controls.Add(this.cbDirecciones);
            this.grpDatos.Controls.Add(this.btnCancelar);
            this.grpDatos.Controls.Add(this.lbCondiciones);
            this.grpDatos.Controls.Add(this.lbStatus);
            this.grpDatos.Controls.Add(this.btnAplicar);
            this.grpDatos.Controls.Add(this.cbStatus);
            this.grpDatos.Controls.Add(this.cbCondicones);
            this.grpDatos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpDatos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpDatos.Location = new System.Drawing.Point(40, 26);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(562, 269);
            this.grpDatos.TabIndex = 18;
            this.grpDatos.Text = "Datos de la Factura";
            this.grpDatos.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // lbEditarDireccion
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.lbEditarDireccion.Appearance = appearance4;
            this.lbEditarDireccion.Location = new System.Drawing.Point(36, 111);
            this.lbEditarDireccion.Name = "lbEditarDireccion";
            this.lbEditarDireccion.Size = new System.Drawing.Size(147, 23);
            this.lbEditarDireccion.TabIndex = 22;
            this.lbEditarDireccion.Text = "Editar Dirección";
            // 
            // cbDirecciones
            // 
            this.cbDirecciones.DataSource = this.clientesDireccionesBindingSource;
            this.cbDirecciones.DisplayMember = "DirComp";
            this.cbDirecciones.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbDirecciones.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbDirecciones.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDirecciones.LimitToList = true;
            this.cbDirecciones.Location = new System.Drawing.Point(212, 107);
            this.cbDirecciones.Name = "cbDirecciones";
            this.cbDirecciones.Size = new System.Drawing.Size(305, 24);
            this.cbDirecciones.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.cbDirecciones.TabIndex = 21;
            this.cbDirecciones.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbDirecciones.ValueMember = "ID";
            // 
            // clientesDireccionesBindingSource
            // 
            this.clientesDireccionesBindingSource.DataMember = "ClientesDirecciones";
            this.clientesDireccionesBindingSource.DataSource = this.facturacion;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnCancelar.Location = new System.Drawing.Point(35, 220);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(480, 27);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCancelar.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // lbCondiciones
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.lbCondiciones.Appearance = appearance5;
            this.lbCondiciones.Location = new System.Drawing.Point(35, 40);
            this.lbCondiciones.Name = "lbCondiciones";
            this.lbCondiciones.Size = new System.Drawing.Size(147, 23);
            this.lbCondiciones.TabIndex = 19;
            this.lbCondiciones.Text = "Condiciones de Pago";
            // 
            // lbStatus
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.lbStatus.Appearance = appearance6;
            this.lbStatus.Location = new System.Drawing.Point(36, 76);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(147, 23);
            this.lbStatus.TabIndex = 18;
            this.lbStatus.Text = "Status Facturación";
            // 
            // formaPagoTableAdapter
            // 
            this.formaPagoTableAdapter.ClearBeforeFill = true;
            // 
            // statusFacturacionTableAdapter
            // 
            this.statusFacturacionTableAdapter.ClearBeforeFill = true;
            // 
            // clientesDireccionesTableAdapter
            // 
            this.clientesDireccionesTableAdapter.ClearBeforeFill = true;
            // 
            // btnNuevoReciboCeros
            // 
            this.btnNuevoReciboCeros.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnNuevoReciboCeros.Location = new System.Drawing.Point(35, 183);
            this.btnNuevoReciboCeros.Name = "btnNuevoReciboCeros";
            this.btnNuevoReciboCeros.Size = new System.Drawing.Size(480, 27);
            this.btnNuevoReciboCeros.TabIndex = 23;
            this.btnNuevoReciboCeros.Text = "Agregar Nuevo Recibo en Ceros";
            this.btnNuevoReciboCeros.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnNuevoReciboCeros.Click += new System.EventHandler(this.btnNuevoReciboCeros_Click);
            // 
            // EditarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 332);
            this.ControlBox = false;
            this.Controls.Add(this.grpDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditarFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditarFactura";
            this.Load += new System.EventHandler(this.EditarFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusFacturacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCondicones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formaPagoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpDatos)).EndInit();
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDirecciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesDireccionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbStatus;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbCondicones;
        private Infragistics.Win.Misc.UltraButton btnAplicar;
        private Infragistics.Win.Misc.UltraGroupBox grpDatos;
        private Infragistics.Win.Misc.UltraLabel lbCondiciones;
        private Infragistics.Win.Misc.UltraLabel lbStatus;
        private Infragistics.Win.Misc.UltraButton btnCancelar;
        private Datasets.CreditControl.Facturacion facturacion;
        private System.Windows.Forms.BindingSource formaPagoBindingSource;
        private Datasets.CreditControl.FacturacionTableAdapters.FormaPagoTableAdapter formaPagoTableAdapter;
        private System.Windows.Forms.BindingSource statusFacturacionBindingSource;
        private Datasets.CreditControl.FacturacionTableAdapters.StatusFacturacionTableAdapter statusFacturacionTableAdapter;
        private Infragistics.Win.Misc.UltraLabel lbEditarDireccion;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbDirecciones;
        private System.Windows.Forms.BindingSource clientesDireccionesBindingSource;
        private Datasets.CreditControl.FacturacionTableAdapters.ClientesDireccionesTableAdapter clientesDireccionesTableAdapter;
        private Infragistics.Win.Misc.UltraButton btnNuevoReciboCeros;
    }
}