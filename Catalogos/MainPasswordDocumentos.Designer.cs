namespace SmartG.Catalogos
{
    partial class MainPasswordDocumentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPasswordDocumentos));
            this.txtPass2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbPassword2 = new Infragistics.Win.Misc.UltraLabel();
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            this.btnGuardar = new Infragistics.Win.Misc.UltraButton();
            this.txtPass1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbPassword1 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPass2
            // 
            this.txtPass2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtPass2.Location = new System.Drawing.Point(235, 80);
            this.txtPass2.Name = "txtPass2";
            this.txtPass2.PasswordChar = '*';
            this.txtPass2.Size = new System.Drawing.Size(418, 24);
            this.txtPass2.TabIndex = 47;
            // 
            // lbPassword2
            // 
            appearance1.TextHAlignAsString = "Right";
            this.lbPassword2.Appearance = appearance1;
            this.lbPassword2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbPassword2.Location = new System.Drawing.Point(29, 84);
            this.lbPassword2.Name = "lbPassword2";
            this.lbPassword2.Size = new System.Drawing.Size(191, 23);
            this.lbPassword2.TabIndex = 46;
            this.lbPassword2.Text = "Repite la contraseña";
            // 
            // btnCancelar
            // 
            appearance2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelar.Appearance = appearance2;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(413, 134);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 49;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            appearance3.ForeColor = System.Drawing.Color.Green;
            this.btnGuardar.Appearance = appearance3;
            this.btnGuardar.Location = new System.Drawing.Point(274, 134);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 48;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtPass1
            // 
            this.txtPass1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtPass1.Location = new System.Drawing.Point(235, 38);
            this.txtPass1.Name = "txtPass1";
            this.txtPass1.PasswordChar = '*';
            this.txtPass1.Size = new System.Drawing.Size(418, 24);
            this.txtPass1.TabIndex = 45;
            // 
            // lbPassword1
            // 
            appearance4.TextHAlignAsString = "Right";
            this.lbPassword1.Appearance = appearance4;
            this.lbPassword1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbPassword1.Location = new System.Drawing.Point(29, 42);
            this.lbPassword1.Name = "lbPassword1";
            this.lbPassword1.Size = new System.Drawing.Size(191, 23);
            this.lbPassword1.TabIndex = 44;
            this.lbPassword1.Text = "Contraseña nueva";
            // 
            // MainPasswordDocumentos
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(751, 184);
            this.Controls.Add(this.txtPass2);
            this.Controls.Add(this.lbPassword2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtPass1);
            this.Controls.Add(this.lbPassword1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainPasswordDocumentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar Contraseña de documentos";
            this.Load += new System.EventHandler(this.MainPasswordDocumentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPass2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPass2;
        private Infragistics.Win.Misc.UltraLabel lbPassword2;
        private Infragistics.Win.Misc.UltraButton btnCancelar;
        private Infragistics.Win.Misc.UltraButton btnGuardar;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPass1;
        private Infragistics.Win.Misc.UltraLabel lbPassword1;
    }
}