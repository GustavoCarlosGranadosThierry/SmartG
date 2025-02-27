namespace SmartG.Operaciones.Emision
{
    partial class SelectorLN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectorLN));
            this.btnAceptar = new Infragistics.Win.Misc.UltraButton();
            this.cbLineaNegocios = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.LNBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.liabilityInc = new SmartG.Datasets.Emision.Liability.LiabilityInc();
            this.lbTipoTransaccionTxt = new Infragistics.Win.Misc.UltraLabel();
            this.lbTipoTransaccion = new Infragistics.Win.Misc.UltraLabel();
            this.lbOrigenTxt = new Infragistics.Win.Misc.UltraLabel();
            this.lbOrigen = new Infragistics.Win.Misc.UltraLabel();
            this.lbLineaNegocios = new Infragistics.Win.Misc.UltraLabel();
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            this.lineaNegociosTableAdapter = new SmartG.Datasets.Emision.Liability.LiabilityIncTableAdapters.LineaNegociosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cbLineaNegocios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LNBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.liabilityInc)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnAceptar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(280, 233);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(138, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Comenzar";
            this.btnAceptar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cbLineaNegocios
            // 
            this.cbLineaNegocios.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cbLineaNegocios.DisplayMember = "LineaNegocios";
            this.cbLineaNegocios.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbLineaNegocios.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbLineaNegocios.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLineaNegocios.Location = new System.Drawing.Point(139, 180);
            this.cbLineaNegocios.Name = "cbLineaNegocios";
            this.cbLineaNegocios.Size = new System.Drawing.Size(248, 24);
            this.cbLineaNegocios.TabIndex = 5;
            this.cbLineaNegocios.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbLineaNegocios.ValueMember = "ID";
            // 
            // LNBindingSource
            // 
            this.LNBindingSource.DataMember = "LineaNegocios";
            this.LNBindingSource.DataSource = this.liabilityInc;
            // 
            // liabilityInc
            // 
            this.liabilityInc.DataSetName = "LiabilityInc";
            this.liabilityInc.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbTipoTransaccionTxt
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.lbTipoTransaccionTxt.Appearance = appearance1;
            this.lbTipoTransaccionTxt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTipoTransaccionTxt.Location = new System.Drawing.Point(212, 64);
            this.lbTipoTransaccionTxt.Name = "lbTipoTransaccionTxt";
            this.lbTipoTransaccionTxt.Size = new System.Drawing.Size(147, 23);
            this.lbTipoTransaccionTxt.TabIndex = 1;
            this.lbTipoTransaccionTxt.Text = "Nueva Póliza";
            // 
            // lbTipoTransaccion
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.lbTipoTransaccion.Appearance = appearance2;
            this.lbTipoTransaccion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTipoTransaccion.Location = new System.Drawing.Point(187, 35);
            this.lbTipoTransaccion.Name = "lbTipoTransaccion";
            this.lbTipoTransaccion.Size = new System.Drawing.Size(173, 23);
            this.lbTipoTransaccion.TabIndex = 0;
            this.lbTipoTransaccion.Text = "Tipo de transaccion:";
            // 
            // lbOrigenTxt
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.lbOrigenTxt.Appearance = appearance3;
            this.lbOrigenTxt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOrigenTxt.Location = new System.Drawing.Point(223, 122);
            this.lbOrigenTxt.Name = "lbOrigenTxt";
            this.lbOrigenTxt.Size = new System.Drawing.Size(88, 23);
            this.lbOrigenTxt.TabIndex = 3;
            this.lbOrigenTxt.Text = "Incoming";
            // 
            // lbOrigen
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.lbOrigen.Appearance = appearance4;
            this.lbOrigen.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOrigen.Location = new System.Drawing.Point(227, 93);
            this.lbOrigen.Name = "lbOrigen";
            this.lbOrigen.Size = new System.Drawing.Size(113, 23);
            this.lbOrigen.TabIndex = 2;
            this.lbOrigen.Text = "Origen:";
            // 
            // lbLineaNegocios
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.lbLineaNegocios.Appearance = appearance5;
            this.lbLineaNegocios.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLineaNegocios.Location = new System.Drawing.Point(187, 151);
            this.lbLineaNegocios.Name = "lbLineaNegocios";
            this.lbLineaNegocios.Size = new System.Drawing.Size(147, 23);
            this.lbLineaNegocios.TabIndex = 4;
            this.lbLineaNegocios.Text = "Linea de negocios:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(92, 233);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lineaNegociosTableAdapter
            // 
            this.lineaNegociosTableAdapter.ClearBeforeFill = true;
            // 
            // SelectorLN
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(520, 319);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lbLineaNegocios);
            this.Controls.Add(this.lbOrigenTxt);
            this.Controls.Add(this.lbOrigen);
            this.Controls.Add(this.lbTipoTransaccionTxt);
            this.Controls.Add(this.lbTipoTransaccion);
            this.Controls.Add(this.cbLineaNegocios);
            this.Controls.Add(this.btnAceptar);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SelectorLN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecciona la linea de negocios";
            this.Load += new System.EventHandler(this.SelectorLN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbLineaNegocios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LNBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.liabilityInc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton btnAceptar;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbLineaNegocios;
        private Infragistics.Win.Misc.UltraLabel lbTipoTransaccionTxt;
        private Infragistics.Win.Misc.UltraLabel lbTipoTransaccion;
        private Infragistics.Win.Misc.UltraLabel lbOrigenTxt;
        private Infragistics.Win.Misc.UltraLabel lbOrigen;
        private Infragistics.Win.Misc.UltraLabel lbLineaNegocios;
        private Infragistics.Win.Misc.UltraButton btnCancelar;
        private System.Windows.Forms.BindingSource LNBindingSource;
        private Datasets.Emision.Liability.LiabilityInc liabilityInc;
        private Datasets.Emision.Liability.LiabilityIncTableAdapters.LineaNegociosTableAdapter lineaNegociosTableAdapter;
    }
}