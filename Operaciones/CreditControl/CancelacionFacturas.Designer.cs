namespace SmartG.Operaciones.CreditControl
{
    partial class CancelacionFacturas
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
            this.txtObservacionesCC = new System.Windows.Forms.TextBox();
            this.lbObservacionesCC = new System.Windows.Forms.Label();
            this.txtMotivos = new System.Windows.Forms.TextBox();
            this.lbMotivo = new System.Windows.Forms.Label();
            this.btnSolicitar = new Infragistics.Win.Misc.UltraButton();
            this.btnCancelacion = new Infragistics.Win.Misc.UltraButton();
            this.btnCerrar = new Infragistics.Win.Misc.UltraButton();
            this.SuspendLayout();
            // 
            // txtObservacionesCC
            // 
            this.txtObservacionesCC.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtObservacionesCC.Location = new System.Drawing.Point(222, 111);
            this.txtObservacionesCC.Multiline = true;
            this.txtObservacionesCC.Name = "txtObservacionesCC";
            this.txtObservacionesCC.Size = new System.Drawing.Size(346, 47);
            this.txtObservacionesCC.TabIndex = 14;
            // 
            // lbObservacionesCC
            // 
            this.lbObservacionesCC.AutoSize = true;
            this.lbObservacionesCC.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbObservacionesCC.Location = new System.Drawing.Point(62, 114);
            this.lbObservacionesCC.Name = "lbObservacionesCC";
            this.lbObservacionesCC.Size = new System.Drawing.Size(160, 16);
            this.lbObservacionesCC.TabIndex = 13;
            this.lbObservacionesCC.Text = "Observaciones Credit C.";
            // 
            // txtMotivos
            // 
            this.txtMotivos.Enabled = false;
            this.txtMotivos.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtMotivos.Location = new System.Drawing.Point(222, 54);
            this.txtMotivos.Multiline = true;
            this.txtMotivos.Name = "txtMotivos";
            this.txtMotivos.Size = new System.Drawing.Size(346, 47);
            this.txtMotivos.TabIndex = 12;
            // 
            // lbMotivo
            // 
            this.lbMotivo.AutoSize = true;
            this.lbMotivo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbMotivo.Location = new System.Drawing.Point(62, 57);
            this.lbMotivo.Name = "lbMotivo";
            this.lbMotivo.Size = new System.Drawing.Size(138, 16);
            this.lbMotivo.TabIndex = 11;
            this.lbMotivo.Text = "Motivos registrados: ";
            // 
            // btnSolicitar
            // 
            this.btnSolicitar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnSolicitar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSolicitar.Location = new System.Drawing.Point(77, 174);
            this.btnSolicitar.Name = "btnSolicitar";
            this.btnSolicitar.Size = new System.Drawing.Size(365, 23);
            this.btnSolicitar.TabIndex = 18;
            this.btnSolicitar.Text = "Aceptar y Cancelar la Factura";
            this.btnSolicitar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnSolicitar.Click += new System.EventHandler(this.btnSolicitar_Click);
            // 
            // btnCancelacion
            // 
            this.btnCancelacion.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnCancelacion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancelacion.Location = new System.Drawing.Point(77, 215);
            this.btnCancelacion.Name = "btnCancelacion";
            this.btnCancelacion.Size = new System.Drawing.Size(365, 23);
            this.btnCancelacion.TabIndex = 19;
            this.btnCancelacion.Text = "Rechazar la Solicitud de Cancelacion";
            this.btnCancelacion.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCancelacion.Click += new System.EventHandler(this.btnCancelacion_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.Location = new System.Drawing.Point(463, 196);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(105, 23);
            this.btnCerrar.TabIndex = 20;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // CancelacionFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 307);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnCancelacion);
            this.Controls.Add(this.btnSolicitar);
            this.Controls.Add(this.txtObservacionesCC);
            this.Controls.Add(this.lbObservacionesCC);
            this.Controls.Add(this.txtMotivos);
            this.Controls.Add(this.lbMotivo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CancelacionFacturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CancelacionFacturas";
            this.Load += new System.EventHandler(this.CancelacionFacturas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtObservacionesCC;
        private System.Windows.Forms.Label lbObservacionesCC;
        private System.Windows.Forms.TextBox txtMotivos;
        private System.Windows.Forms.Label lbMotivo;
        private Infragistics.Win.Misc.UltraButton btnSolicitar;
        private Infragistics.Win.Misc.UltraButton btnCancelacion;
        private Infragistics.Win.Misc.UltraButton btnCerrar;
    }
}