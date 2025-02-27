namespace SmartG.Catalogos.Emision
{
    partial class agregarEditarToBPO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(agregarEditarToBPO));
            this.lbTOBPO = new Infragistics.Win.Misc.UltraLabel();
            this.txtTOBPO = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnGuardar = new Infragistics.Win.Misc.UltraButton();
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtTOBPO)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTOBPO
            // 
            appearance1.TextHAlignAsString = "Right";
            this.lbTOBPO.Appearance = appearance1;
            this.lbTOBPO.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbTOBPO.Location = new System.Drawing.Point(53, 43);
            this.lbTOBPO.Name = "lbTOBPO";
            this.lbTOBPO.Size = new System.Drawing.Size(140, 23);
            this.lbTOBPO.TabIndex = 0;
            this.lbTOBPO.Text = "Producing Office";
            // 
            // txtTOBPO
            // 
            this.txtTOBPO.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtTOBPO.Location = new System.Drawing.Point(208, 39);
            this.txtTOBPO.Name = "txtTOBPO";
            this.txtTOBPO.Size = new System.Drawing.Size(352, 24);
            this.txtTOBPO.TabIndex = 1;
            // 
            // btnGuardar
            // 
            appearance2.ForeColor = System.Drawing.Color.Green;
            this.btnGuardar.Appearance = appearance2;
            this.btnGuardar.Location = new System.Drawing.Point(191, 90);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(122, 23);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            appearance3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelar.Appearance = appearance3;
            this.btnCancelar.Location = new System.Drawing.Point(330, 90);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(122, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // agregarEditarToBPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 156);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtTOBPO);
            this.Controls.Add(this.lbTOBPO);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "agregarEditarToBPO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "agregarEditarToBPO";
            this.Load += new System.EventHandler(this.agregarEditarToBPO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTOBPO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel lbTOBPO;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtTOBPO;
        private Infragistics.Win.Misc.UltraButton btnGuardar;
        private Infragistics.Win.Misc.UltraButton btnCancelar;
    }
}