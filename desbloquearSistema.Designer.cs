namespace SmartG
{
    partial class desbloquearSistema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(desbloquearSistema));
            this.lbDesbloquear = new Infragistics.Win.Misc.UltraLabel();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbDesbloquear
            // 
            this.lbDesbloquear.Location = new System.Drawing.Point(55, 43);
            this.lbDesbloquear.Name = "lbDesbloquear";
            this.lbDesbloquear.Size = new System.Drawing.Size(475, 23);
            this.lbDesbloquear.TabIndex = 0;
            this.lbDesbloquear.Text = "El sistema ha sido bloqueado por inactividad, introduce tu contraseña";
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(187, 97);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '•';
            this.txtPass.Size = new System.Drawing.Size(165, 22);
            this.txtPass.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.Green;
            this.btnOK.Location = new System.Drawing.Point(232, 150);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 29);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Acceder";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // desbloquearSistema
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 213);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lbDesbloquear);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "desbloquearSistema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "desbloquearSistema";
            this.Load += new System.EventHandler(this.desbloquearSistema_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel lbDesbloquear;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnOK;
    }
}