namespace SmartG.Operaciones.CreditControl
{
    partial class MotivosCancelacion
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
            this.lbFactura = new System.Windows.Forms.Label();
            this.lbMotivoCancela = new System.Windows.Forms.Label();
            this.txtMotivos = new System.Windows.Forms.TextBox();
            this.btnSolicitar = new Infragistics.Win.Misc.UltraButton();
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            this.SuspendLayout();
            // 
            // lbFactura
            // 
            this.lbFactura.AutoSize = true;
            this.lbFactura.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbFactura.Location = new System.Drawing.Point(235, 55);
            this.lbFactura.Name = "lbFactura";
            this.lbFactura.Size = new System.Drawing.Size(0, 16);
            this.lbFactura.TabIndex = 7;
            // 
            // lbMotivoCancela
            // 
            this.lbMotivoCancela.AutoSize = true;
            this.lbMotivoCancela.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbMotivoCancela.Location = new System.Drawing.Point(109, 39);
            this.lbMotivoCancela.Name = "lbMotivoCancela";
            this.lbMotivoCancela.Size = new System.Drawing.Size(340, 16);
            this.lbMotivoCancela.TabIndex = 6;
            this.lbMotivoCancela.Text = "Ingrese un motivo de Cancelación para su Solicitud:";
            // 
            // txtMotivos
            // 
            this.txtMotivos.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtMotivos.Location = new System.Drawing.Point(49, 71);
            this.txtMotivos.Name = "txtMotivos";
            this.txtMotivos.Size = new System.Drawing.Size(443, 22);
            this.txtMotivos.TabIndex = 4;
            // 
            // btnSolicitar
            // 
            this.btnSolicitar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnSolicitar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSolicitar.Location = new System.Drawing.Point(295, 119);
            this.btnSolicitar.Name = "btnSolicitar";
            this.btnSolicitar.Size = new System.Drawing.Size(197, 23);
            this.btnSolicitar.TabIndex = 8;
            this.btnSolicitar.Text = "Solicitar";
            this.btnSolicitar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnSolicitar.Click += new System.EventHandler(this.btnConsultarTipoCambio_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.Location = new System.Drawing.Point(49, 119);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(197, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // MotivosCancelacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 199);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSolicitar);
            this.Controls.Add(this.lbFactura);
            this.Controls.Add(this.lbMotivoCancela);
            this.Controls.Add(this.txtMotivos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MotivosCancelacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MotivosCancelacion";
            this.Load += new System.EventHandler(this.MotivosCancelacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFactura;
        private System.Windows.Forms.Label lbMotivoCancela;
        private System.Windows.Forms.TextBox txtMotivos;
        private Infragistics.Win.Misc.UltraButton btnSolicitar;
        private Infragistics.Win.Misc.UltraButton btnCancelar;
    }
}