namespace SmartG.Catalogos
{
    partial class MainLimiteMaximo
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
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainLimiteMaximo));
            this.lbDivisaActual = new Infragistics.Win.Misc.UltraLabel();
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            this.btnGuardar = new Infragistics.Win.Misc.UltraButton();
            this.lbLimiteActual = new Infragistics.Win.Misc.UltraLabel();
            this.txtLimiteActual = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtDivisaActual = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtLimiteNuevo = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtDivisaNueva = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lbDivisaNuevo = new Infragistics.Win.Misc.UltraLabel();
            this.lbLimiteNuevo = new Infragistics.Win.Misc.UltraLabel();
            this.lbMon2 = new Infragistics.Win.Misc.UltraLabel();
            this.lbMon1 = new Infragistics.Win.Misc.UltraLabel();
            this.lbMon4 = new Infragistics.Win.Misc.UltraLabel();
            this.lbMon3 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtLimiteActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDivisaActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLimiteNuevo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDivisaNueva)).BeginInit();
            this.SuspendLayout();
            // 
            // lbDivisaActual
            // 
            appearance1.TextHAlignAsString = "Right";
            this.lbDivisaActual.Appearance = appearance1;
            this.lbDivisaActual.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbDivisaActual.Location = new System.Drawing.Point(12, 84);
            this.lbDivisaActual.Name = "lbDivisaActual";
            this.lbDivisaActual.Size = new System.Drawing.Size(120, 23);
            this.lbDivisaActual.TabIndex = 7;
            this.lbDivisaActual.Text = "Divisa actual";
            // 
            // btnCancelar
            // 
            appearance2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelar.Appearance = appearance2;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(541, 141);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            appearance3.ForeColor = System.Drawing.Color.Green;
            this.btnGuardar.Appearance = appearance3;
            this.btnGuardar.Location = new System.Drawing.Point(402, 141);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lbLimiteActual
            // 
            appearance4.TextHAlignAsString = "Right";
            this.lbLimiteActual.Appearance = appearance4;
            this.lbLimiteActual.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbLimiteActual.Location = new System.Drawing.Point(12, 40);
            this.lbLimiteActual.Name = "lbLimiteActual";
            this.lbLimiteActual.Size = new System.Drawing.Size(120, 23);
            this.lbLimiteActual.TabIndex = 6;
            this.lbLimiteActual.Text = "Límite actual";
            // 
            // txtLimiteActual
            // 
            this.txtLimiteActual.Enabled = false;
            this.txtLimiteActual.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLimiteActual.Location = new System.Drawing.Point(158, 36);
            this.txtLimiteActual.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtLimiteActual.Name = "txtLimiteActual";
            this.txtLimiteActual.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txtLimiteActual.PromptChar = ' ';
            this.txtLimiteActual.ReadOnly = true;
            this.txtLimiteActual.Size = new System.Drawing.Size(235, 24);
            this.txtLimiteActual.TabIndex = 10;
            // 
            // txtDivisaActual
            // 
            this.txtDivisaActual.Enabled = false;
            this.txtDivisaActual.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDivisaActual.Location = new System.Drawing.Point(158, 80);
            this.txtDivisaActual.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDivisaActual.Name = "txtDivisaActual";
            this.txtDivisaActual.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txtDivisaActual.PromptChar = ' ';
            this.txtDivisaActual.ReadOnly = true;
            this.txtDivisaActual.Size = new System.Drawing.Size(235, 24);
            this.txtDivisaActual.TabIndex = 11;
            // 
            // txtLimiteNuevo
            // 
            this.txtLimiteNuevo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLimiteNuevo.Location = new System.Drawing.Point(604, 36);
            this.txtLimiteNuevo.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtLimiteNuevo.Name = "txtLimiteNuevo";
            this.txtLimiteNuevo.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txtLimiteNuevo.PromptChar = ' ';
            this.txtLimiteNuevo.Size = new System.Drawing.Size(235, 24);
            this.txtLimiteNuevo.TabIndex = 0;
            // 
            // txtDivisaNueva
            // 
            this.txtDivisaNueva.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDivisaNueva.Location = new System.Drawing.Point(604, 80);
            this.txtDivisaNueva.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDivisaNueva.Name = "txtDivisaNueva";
            this.txtDivisaNueva.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txtDivisaNueva.PromptChar = ' ';
            this.txtDivisaNueva.Size = new System.Drawing.Size(235, 24);
            this.txtDivisaNueva.TabIndex = 1;
            // 
            // lbDivisaNuevo
            // 
            appearance5.TextHAlignAsString = "Right";
            this.lbDivisaNuevo.Appearance = appearance5;
            this.lbDivisaNuevo.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbDivisaNuevo.Location = new System.Drawing.Point(455, 84);
            this.lbDivisaNuevo.Name = "lbDivisaNuevo";
            this.lbDivisaNuevo.Size = new System.Drawing.Size(121, 23);
            this.lbDivisaNuevo.TabIndex = 15;
            this.lbDivisaNuevo.Text = "Divisa nueva";
            // 
            // lbLimiteNuevo
            // 
            appearance6.TextHAlignAsString = "Right";
            this.lbLimiteNuevo.Appearance = appearance6;
            this.lbLimiteNuevo.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbLimiteNuevo.Location = new System.Drawing.Point(455, 40);
            this.lbLimiteNuevo.Name = "lbLimiteNuevo";
            this.lbLimiteNuevo.Size = new System.Drawing.Size(121, 23);
            this.lbLimiteNuevo.TabIndex = 14;
            this.lbLimiteNuevo.Text = "Límite nuevo";
            // 
            // lbMon2
            // 
            appearance7.TextHAlignAsString = "Left";
            this.lbMon2.Appearance = appearance7;
            this.lbMon2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbMon2.Location = new System.Drawing.Point(409, 84);
            this.lbMon2.Name = "lbMon2";
            this.lbMon2.Size = new System.Drawing.Size(68, 23);
            this.lbMon2.TabIndex = 17;
            this.lbMon2.Text = "MXN";
            // 
            // lbMon1
            // 
            appearance8.TextHAlignAsString = "Left";
            this.lbMon1.Appearance = appearance8;
            this.lbMon1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbMon1.Location = new System.Drawing.Point(409, 40);
            this.lbMon1.Name = "lbMon1";
            this.lbMon1.Size = new System.Drawing.Size(68, 23);
            this.lbMon1.TabIndex = 16;
            this.lbMon1.Text = "MXN";
            // 
            // lbMon4
            // 
            appearance9.TextHAlignAsString = "Left";
            this.lbMon4.Appearance = appearance9;
            this.lbMon4.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbMon4.Location = new System.Drawing.Point(855, 84);
            this.lbMon4.Name = "lbMon4";
            this.lbMon4.Size = new System.Drawing.Size(91, 23);
            this.lbMon4.TabIndex = 19;
            this.lbMon4.Text = "MXN";
            // 
            // lbMon3
            // 
            appearance10.TextHAlignAsString = "Left";
            this.lbMon3.Appearance = appearance10;
            this.lbMon3.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbMon3.Location = new System.Drawing.Point(855, 40);
            this.lbMon3.Name = "lbMon3";
            this.lbMon3.Size = new System.Drawing.Size(91, 23);
            this.lbMon3.TabIndex = 18;
            this.lbMon3.Text = "MXN";
            // 
            // MainLimiteMaximo
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(960, 191);
            this.Controls.Add(this.lbMon4);
            this.Controls.Add(this.lbMon3);
            this.Controls.Add(this.lbMon2);
            this.Controls.Add(this.lbMon1);
            this.Controls.Add(this.lbDivisaNuevo);
            this.Controls.Add(this.lbLimiteNuevo);
            this.Controls.Add(this.txtDivisaNueva);
            this.Controls.Add(this.txtLimiteNuevo);
            this.Controls.Add(this.txtDivisaActual);
            this.Controls.Add(this.txtLimiteActual);
            this.Controls.Add(this.lbDivisaActual);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lbLimiteActual);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainLimiteMaximo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajustar Límite máximo de retención México";
            this.Load += new System.EventHandler(this.MainLimiteMaximo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtLimiteActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDivisaActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLimiteNuevo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDivisaNueva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel lbDivisaActual;
        private Infragistics.Win.Misc.UltraButton btnCancelar;
        private Infragistics.Win.Misc.UltraButton btnGuardar;
        private Infragistics.Win.Misc.UltraLabel lbLimiteActual;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtLimiteActual;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtDivisaActual;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtLimiteNuevo;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtDivisaNueva;
        private Infragistics.Win.Misc.UltraLabel lbDivisaNuevo;
        private Infragistics.Win.Misc.UltraLabel lbLimiteNuevo;
        private Infragistics.Win.Misc.UltraLabel lbMon2;
        private Infragistics.Win.Misc.UltraLabel lbMon1;
        private Infragistics.Win.Misc.UltraLabel lbMon4;
        private Infragistics.Win.Misc.UltraLabel lbMon3;
    }
}