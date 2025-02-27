namespace SmartG.Operaciones.CreditControl
{
    partial class selectorSolicitudCancelacion
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
            this.lbOpciones = new Infragistics.Win.Misc.UltraLabel();
            this.btnSolicitar = new Infragistics.Win.Misc.UltraButton();
            this.btnGenerarCancelacion = new Infragistics.Win.Misc.UltraButton();
            this.btnSalir = new Infragistics.Win.Misc.UltraButton();
            this.SuspendLayout();
            // 
            // lbOpciones
            // 
            appearance1.TextHAlignAsString = "Center";
            this.lbOpciones.Appearance = appearance1;
            this.lbOpciones.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbOpciones.Location = new System.Drawing.Point(191, 48);
            this.lbOpciones.Name = "lbOpciones";
            this.lbOpciones.Size = new System.Drawing.Size(274, 23);
            this.lbOpciones.TabIndex = 4;
            this.lbOpciones.Text = "Seleccione una opción";
            // 
            // btnSolicitar
            // 
            this.btnSolicitar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnSolicitar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSolicitar.Location = new System.Drawing.Point(67, 77);
            this.btnSolicitar.Name = "btnSolicitar";
            this.btnSolicitar.Size = new System.Drawing.Size(173, 43);
            this.btnSolicitar.TabIndex = 9;
            this.btnSolicitar.Text = "Solicitar una Cancelación";
            this.btnSolicitar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnSolicitar.Click += new System.EventHandler(this.btnSolicitar_Click);
            // 
            // btnGenerarCancelacion
            // 
            this.btnGenerarCancelacion.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnGenerarCancelacion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGenerarCancelacion.Location = new System.Drawing.Point(259, 77);
            this.btnGenerarCancelacion.Name = "btnGenerarCancelacion";
            this.btnGenerarCancelacion.Size = new System.Drawing.Size(173, 43);
            this.btnGenerarCancelacion.TabIndex = 10;
            this.btnGenerarCancelacion.Text = "Generar una Cancelación";
            this.btnGenerarCancelacion.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnGenerarCancelacion.Click += new System.EventHandler(this.btnGenerarCancelacion_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnSalir.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSalir.Location = new System.Drawing.Point(442, 77);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(173, 43);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // selectorSolicitudCancelacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(691, 182);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGenerarCancelacion);
            this.Controls.Add(this.btnSolicitar);
            this.Controls.Add(this.lbOpciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "selectorSolicitudCancelacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "selectorSolicitudCancelacion";
            this.Load += new System.EventHandler(this.selectorSolicitudCancelacion_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Infragistics.Win.Misc.UltraLabel lbOpciones;
        private Infragistics.Win.Misc.UltraButton btnSolicitar;
        private Infragistics.Win.Misc.UltraButton btnGenerarCancelacion;
        private Infragistics.Win.Misc.UltraButton btnSalir;
    }
}