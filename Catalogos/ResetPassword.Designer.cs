namespace SmartG.Catalogos
{
    partial class ResetPassword
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
            this.txtRepePass = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbRepePass = new Infragistics.Win.Misc.UltraLabel();
            this.txtPass = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbPass = new Infragistics.Win.Misc.UltraLabel();
            this.btnCambiar = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtRepePass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRepePass
            // 
            this.txtRepePass.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtRepePass.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepePass.Location = new System.Drawing.Point(241, 85);
            this.txtRepePass.Margin = new System.Windows.Forms.Padding(4);
            this.txtRepePass.MaxLength = 100;
            this.txtRepePass.Name = "txtRepePass";
            this.txtRepePass.PasswordChar = '•';
            this.txtRepePass.Size = new System.Drawing.Size(345, 24);
            this.txtRepePass.TabIndex = 60;
            this.txtRepePass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRepePass_KeyDown);
            // 
            // lbRepePass
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.TextVAlignAsString = "Middle";
            this.lbRepePass.Appearance = appearance1;
            this.lbRepePass.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbRepePass.Location = new System.Drawing.Point(41, 81);
            this.lbRepePass.Margin = new System.Windows.Forms.Padding(4);
            this.lbRepePass.Name = "lbRepePass";
            this.lbRepePass.Size = new System.Drawing.Size(197, 39);
            this.lbRepePass.TabIndex = 59;
            this.lbRepePass.Text = "Repetir Password";
            // 
            // txtPass
            // 
            this.txtPass.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtPass.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(241, 38);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtPass.MaxLength = 100;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '•';
            this.txtPass.Size = new System.Drawing.Size(345, 24);
            this.txtPass.TabIndex = 58;
            // 
            // lbPass
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.TextVAlignAsString = "Middle";
            this.lbPass.Appearance = appearance2;
            this.lbPass.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbPass.Location = new System.Drawing.Point(41, 35);
            this.lbPass.Margin = new System.Windows.Forms.Padding(4);
            this.lbPass.Name = "lbPass";
            this.lbPass.Size = new System.Drawing.Size(197, 39);
            this.lbPass.TabIndex = 57;
            this.lbPass.Text = "Nuevo Password";
            // 
            // btnCambiar
            // 
            this.btnCambiar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnCambiar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCambiar.Location = new System.Drawing.Point(209, 145);
            this.btnCambiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(219, 33);
            this.btnCambiar.TabIndex = 62;
            this.btnCambiar.Text = "Cambiar Password";
            this.btnCambiar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 214);
            this.Controls.Add(this.btnCambiar);
            this.Controls.Add(this.txtRepePass);
            this.Controls.Add(this.lbRepePass);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lbPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ResetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ResetPassword";
            this.Load += new System.EventHandler(this.ResetPassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtRepePass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtRepePass;
        private Infragistics.Win.Misc.UltraLabel lbRepePass;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPass;
        private Infragistics.Win.Misc.UltraLabel lbPass;
        private Infragistics.Win.Misc.UltraButton btnCambiar;
    }
}