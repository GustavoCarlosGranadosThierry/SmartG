namespace SmartG.Catalogos.Emision
{
    partial class agregarEditarCoaseguros
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(agregarEditarCoaseguros));
            this.txtBroker = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbCoaseguradora = new Infragistics.Win.Misc.UltraLabel();
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            this.btnGuardar = new Infragistics.Win.Misc.UltraButton();
            this.txtBrokerCode = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbCodigoCoase = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtBroker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrokerCode)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBroker
            // 
            this.txtBroker.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtBroker.Location = new System.Drawing.Point(240, 67);
            this.txtBroker.Name = "txtBroker";
            this.txtBroker.Size = new System.Drawing.Size(808, 24);
            this.txtBroker.TabIndex = 3;
            // 
            // lbCoaseguradora
            // 
            appearance1.TextHAlignAsString = "Right";
            this.lbCoaseguradora.Appearance = appearance1;
            this.lbCoaseguradora.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbCoaseguradora.Location = new System.Drawing.Point(66, 71);
            this.lbCoaseguradora.Name = "lbCoaseguradora";
            this.lbCoaseguradora.Size = new System.Drawing.Size(159, 23);
            this.lbCoaseguradora.TabIndex = 2;
            this.lbCoaseguradora.Text = "Coaseguradora";
            // 
            // btnCancelar
            // 
            appearance2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelar.Appearance = appearance2;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(583, 117);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            appearance3.ForeColor = System.Drawing.Color.Green;
            this.btnGuardar.Appearance = appearance3;
            this.btnGuardar.Location = new System.Drawing.Point(444, 117);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtBrokerCode
            // 
            this.txtBrokerCode.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtBrokerCode.Location = new System.Drawing.Point(240, 25);
            this.txtBrokerCode.Name = "txtBrokerCode";
            this.txtBrokerCode.Size = new System.Drawing.Size(144, 24);
            this.txtBrokerCode.TabIndex = 1;
            // 
            // lbCodigoCoase
            // 
            appearance4.TextHAlignAsString = "Right";
            this.lbCodigoCoase.Appearance = appearance4;
            this.lbCodigoCoase.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbCodigoCoase.Location = new System.Drawing.Point(24, 29);
            this.lbCodigoCoase.Name = "lbCodigoCoase";
            this.lbCodigoCoase.Size = new System.Drawing.Size(201, 23);
            this.lbCodigoCoase.TabIndex = 0;
            this.lbCodigoCoase.Text = "Código Coaseguradora";
            // 
            // agregarEditarCoaseguros
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(1100, 164);
            this.Controls.Add(this.txtBroker);
            this.Controls.Add(this.lbCoaseguradora);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtBrokerCode);
            this.Controls.Add(this.lbCodigoCoase);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "agregarEditarCoaseguros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar o Editar Coaseguradoras";
            this.Load += new System.EventHandler(this.agregarEditarCoaseguros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtBroker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrokerCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtBroker;
        private Infragistics.Win.Misc.UltraLabel lbCoaseguradora;
        private Infragistics.Win.Misc.UltraButton btnCancelar;
        private Infragistics.Win.Misc.UltraButton btnGuardar;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtBrokerCode;
        private Infragistics.Win.Misc.UltraLabel lbCodigoCoase;
    }
}