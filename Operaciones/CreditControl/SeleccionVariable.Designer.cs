namespace SmartG.Operaciones.CreditControl
{
    partial class SeleccionVariable
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
            this.panel_FormaPagoSAT = new System.Windows.Forms.Panel();
            this.cbFormaPagoSAT = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.formaPagoSATBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturacion = new SmartG.Datasets.CreditControl.Facturacion();
            this.btnSeleFormaPagoSAT = new Infragistics.Win.Misc.UltraButton();
            this.lbFormaPagoSAT = new System.Windows.Forms.Label();
            this.panel_BancoExt = new System.Windows.Forms.Panel();
            this.txtBancoExt = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnBancoExt = new Infragistics.Win.Misc.UltraButton();
            this.lbBancoExt = new System.Windows.Forms.Label();
            this.panel_CondPago = new System.Windows.Forms.Panel();
            this.btnSeleFormaPago = new Infragistics.Win.Misc.UltraButton();
            this.cbFormaPago = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.formaPagoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbFormaPago = new System.Windows.Forms.Label();
            this.formaPagoSATTableAdapter = new SmartG.Datasets.CreditControl.FacturacionTableAdapters.FormaPagoSATTableAdapter();
            this.formaPagoTableAdapter = new SmartG.Datasets.CreditControl.FacturacionTableAdapters.FormaPagoTableAdapter();
            this.panel_FormaPagoSAT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbFormaPagoSAT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formaPagoSATBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturacion)).BeginInit();
            this.panel_BancoExt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBancoExt)).BeginInit();
            this.panel_CondPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbFormaPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formaPagoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_FormaPagoSAT
            // 
            this.panel_FormaPagoSAT.Controls.Add(this.cbFormaPagoSAT);
            this.panel_FormaPagoSAT.Controls.Add(this.btnSeleFormaPagoSAT);
            this.panel_FormaPagoSAT.Controls.Add(this.lbFormaPagoSAT);
            this.panel_FormaPagoSAT.Location = new System.Drawing.Point(0, 3);
            this.panel_FormaPagoSAT.Name = "panel_FormaPagoSAT";
            this.panel_FormaPagoSAT.Size = new System.Drawing.Size(290, 150);
            this.panel_FormaPagoSAT.TabIndex = 4;
            // 
            // cbFormaPagoSAT
            // 
            this.cbFormaPagoSAT.DataSource = this.formaPagoSATBindingSource;
            this.cbFormaPagoSAT.DisplayMember = "Descripcion";
            this.cbFormaPagoSAT.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbFormaPagoSAT.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbFormaPagoSAT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFormaPagoSAT.LimitToList = true;
            this.cbFormaPagoSAT.Location = new System.Drawing.Point(27, 58);
            this.cbFormaPagoSAT.Name = "cbFormaPagoSAT";
            this.cbFormaPagoSAT.Size = new System.Drawing.Size(228, 24);
            this.cbFormaPagoSAT.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.cbFormaPagoSAT.TabIndex = 15;
            this.cbFormaPagoSAT.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbFormaPagoSAT.ValueMember = "ID";
            // 
            // formaPagoSATBindingSource
            // 
            this.formaPagoSATBindingSource.DataMember = "FormaPagoSAT";
            this.formaPagoSATBindingSource.DataSource = this.facturacion;
            // 
            // facturacion
            // 
            this.facturacion.DataSetName = "Facturacion";
            this.facturacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnSeleFormaPagoSAT
            // 
            this.btnSeleFormaPagoSAT.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnSeleFormaPagoSAT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSeleFormaPagoSAT.Location = new System.Drawing.Point(81, 102);
            this.btnSeleFormaPagoSAT.Name = "btnSeleFormaPagoSAT";
            this.btnSeleFormaPagoSAT.Size = new System.Drawing.Size(111, 23);
            this.btnSeleFormaPagoSAT.TabIndex = 19;
            this.btnSeleFormaPagoSAT.Text = "Seleccionar";
            this.btnSeleFormaPagoSAT.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnSeleFormaPagoSAT.Click += new System.EventHandler(this.btnSeleFormaPagoSAT_Click);
            // 
            // lbFormaPagoSAT
            // 
            this.lbFormaPagoSAT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbFormaPagoSAT.Location = new System.Drawing.Point(-3, 9);
            this.lbFormaPagoSAT.Name = "lbFormaPagoSAT";
            this.lbFormaPagoSAT.Size = new System.Drawing.Size(280, 26);
            this.lbFormaPagoSAT.TabIndex = 0;
            this.lbFormaPagoSAT.Text = "Seleccione la forma de Pago";
            this.lbFormaPagoSAT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_BancoExt
            // 
            this.panel_BancoExt.Controls.Add(this.txtBancoExt);
            this.panel_BancoExt.Controls.Add(this.btnBancoExt);
            this.panel_BancoExt.Controls.Add(this.lbBancoExt);
            this.panel_BancoExt.Location = new System.Drawing.Point(0, 0);
            this.panel_BancoExt.Name = "panel_BancoExt";
            this.panel_BancoExt.Size = new System.Drawing.Size(290, 150);
            this.panel_BancoExt.TabIndex = 20;
            // 
            // txtBancoExt
            // 
            this.txtBancoExt.Location = new System.Drawing.Point(19, 53);
            this.txtBancoExt.Name = "txtBancoExt";
            this.txtBancoExt.Size = new System.Drawing.Size(228, 21);
            this.txtBancoExt.TabIndex = 20;
            // 
            // btnBancoExt
            // 
            this.btnBancoExt.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnBancoExt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnBancoExt.Location = new System.Drawing.Point(81, 102);
            this.btnBancoExt.Name = "btnBancoExt";
            this.btnBancoExt.Size = new System.Drawing.Size(111, 23);
            this.btnBancoExt.TabIndex = 19;
            this.btnBancoExt.Text = "Seleccionar";
            this.btnBancoExt.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnBancoExt.Click += new System.EventHandler(this.btnBancoExt_Click);
            // 
            // lbBancoExt
            // 
            this.lbBancoExt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbBancoExt.Location = new System.Drawing.Point(-3, 9);
            this.lbBancoExt.Name = "lbBancoExt";
            this.lbBancoExt.Size = new System.Drawing.Size(280, 26);
            this.lbBancoExt.TabIndex = 0;
            this.lbBancoExt.Text = "Ingrese el Banco Extranjero Ordenante";
            this.lbBancoExt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_CondPago
            // 
            this.panel_CondPago.Controls.Add(this.btnSeleFormaPago);
            this.panel_CondPago.Controls.Add(this.cbFormaPago);
            this.panel_CondPago.Controls.Add(this.lbFormaPago);
            this.panel_CondPago.Location = new System.Drawing.Point(0, 2);
            this.panel_CondPago.Name = "panel_CondPago";
            this.panel_CondPago.Size = new System.Drawing.Size(290, 149);
            this.panel_CondPago.TabIndex = 5;
            this.panel_CondPago.Visible = false;
            // 
            // btnSeleFormaPago
            // 
            this.btnSeleFormaPago.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnSeleFormaPago.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSeleFormaPago.Location = new System.Drawing.Point(81, 102);
            this.btnSeleFormaPago.Name = "btnSeleFormaPago";
            this.btnSeleFormaPago.Size = new System.Drawing.Size(111, 23);
            this.btnSeleFormaPago.TabIndex = 20;
            this.btnSeleFormaPago.Text = "Solicitar";
            this.btnSeleFormaPago.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnSeleFormaPago.Click += new System.EventHandler(this.btnSeleFormaPago_Click);
            // 
            // cbFormaPago
            // 
            this.cbFormaPago.DataSource = this.formaPagoBindingSource;
            this.cbFormaPago.DisplayMember = "FormaPago";
            this.cbFormaPago.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbFormaPago.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbFormaPago.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFormaPago.LimitToList = true;
            this.cbFormaPago.Location = new System.Drawing.Point(27, 58);
            this.cbFormaPago.Name = "cbFormaPago";
            this.cbFormaPago.Size = new System.Drawing.Size(228, 24);
            this.cbFormaPago.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.cbFormaPago.TabIndex = 16;
            this.cbFormaPago.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbFormaPago.ValueMember = "ID";
            this.cbFormaPago.ItemNotInList += new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.cbFormaPago_ItemNotInList);
            // 
            // formaPagoBindingSource
            // 
            this.formaPagoBindingSource.DataMember = "FormaPago";
            this.formaPagoBindingSource.DataSource = this.facturacion;
            // 
            // lbFormaPago
            // 
            this.lbFormaPago.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbFormaPago.Location = new System.Drawing.Point(-3, 12);
            this.lbFormaPago.Name = "lbFormaPago";
            this.lbFormaPago.Size = new System.Drawing.Size(280, 26);
            this.lbFormaPago.TabIndex = 0;
            this.lbFormaPago.Text = "Seleccione las condiciones de Pago";
            this.lbFormaPago.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formaPagoSATTableAdapter
            // 
            this.formaPagoSATTableAdapter.ClearBeforeFill = true;
            // 
            // formaPagoTableAdapter
            // 
            this.formaPagoTableAdapter.ClearBeforeFill = true;
            // 
            // SeleccionVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 152);
            this.Controls.Add(this.panel_FormaPagoSAT);
            this.Controls.Add(this.panel_CondPago);
            this.Controls.Add(this.panel_BancoExt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SeleccionVariable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SeleccionFormaPago";
            this.Load += new System.EventHandler(this.SeleccionFormaPago_Load);
            this.panel_FormaPagoSAT.ResumeLayout(false);
            this.panel_FormaPagoSAT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbFormaPagoSAT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formaPagoSATBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturacion)).EndInit();
            this.panel_BancoExt.ResumeLayout(false);
            this.panel_BancoExt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBancoExt)).EndInit();
            this.panel_CondPago.ResumeLayout(false);
            this.panel_CondPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbFormaPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formaPagoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_FormaPagoSAT;
        private System.Windows.Forms.Label lbFormaPagoSAT;
        private System.Windows.Forms.Panel panel_CondPago;
        private System.Windows.Forms.Label lbFormaPago;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbFormaPagoSAT;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbFormaPago;
        private Infragistics.Win.Misc.UltraButton btnSeleFormaPagoSAT;
        private Infragistics.Win.Misc.UltraButton btnSeleFormaPago;
        private Datasets.CreditControl.Facturacion facturacion;
        private System.Windows.Forms.BindingSource formaPagoSATBindingSource;
        private Datasets.CreditControl.FacturacionTableAdapters.FormaPagoSATTableAdapter formaPagoSATTableAdapter;
        private System.Windows.Forms.BindingSource formaPagoBindingSource;
        private Datasets.CreditControl.FacturacionTableAdapters.FormaPagoTableAdapter formaPagoTableAdapter;
        private System.Windows.Forms.Panel panel_BancoExt;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtBancoExt;
        private Infragistics.Win.Misc.UltraButton btnBancoExt;
        private System.Windows.Forms.Label lbBancoExt;
    }
}