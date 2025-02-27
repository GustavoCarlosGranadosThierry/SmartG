namespace SmartG.Operaciones.Claims
{
    partial class SelFechas
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.dateInicio = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.dateFin = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.btnCerrar = new Infragistics.Win.Misc.UltraButton();
            this.btnGenerar = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraComboEditor1 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.dateInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraComboEditor1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel1.Location = new System.Drawing.Point(47, 32);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "Fecha de Inicio";
            // 
            // dateInicio
            // 
            this.dateInicio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.dateInicio.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateInicio.Location = new System.Drawing.Point(179, 28);
            this.dateInicio.Name = "dateInicio";
            this.dateInicio.Size = new System.Drawing.Size(263, 24);
            this.dateInicio.TabIndex = 1;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel2.Location = new System.Drawing.Point(47, 71);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel2.TabIndex = 2;
            this.ultraLabel2.Text = "Fecha de Fin";
            // 
            // dateFin
            // 
            this.dateFin.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.dateFin.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFin.Location = new System.Drawing.Point(179, 67);
            this.dateFin.Name = "dateFin";
            this.dateFin.Size = new System.Drawing.Size(263, 24);
            this.dateFin.TabIndex = 3;
            // 
            // btnCerrar
            // 
            this.btnCerrar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(107, 159);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(111, 23);
            this.btnCerrar.TabIndex = 19;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnGenerar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Location = new System.Drawing.Point(277, 159);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(111, 23);
            this.btnGenerar.TabIndex = 20;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel3.Location = new System.Drawing.Point(47, 109);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(132, 23);
            this.ultraLabel3.TabIndex = 21;
            this.ultraLabel3.Text = "Linea de Negocio";
            this.ultraLabel3.Click += new System.EventHandler(this.ultraLabel3_Click);
            // 
            // ultraComboEditor1
            // 
            this.ultraComboEditor1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.ultraComboEditor1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            valueListItem1.DataValue = "Liability";
            valueListItem2.DataValue = "Property";
            this.ultraComboEditor1.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.ultraComboEditor1.Location = new System.Drawing.Point(179, 109);
            this.ultraComboEditor1.Name = "ultraComboEditor1";
            this.ultraComboEditor1.Size = new System.Drawing.Size(263, 24);
            this.ultraComboEditor1.TabIndex = 22;
            // 
            // SelFechas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 222);
            this.Controls.Add(this.ultraComboEditor1);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dateFin);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.dateInicio);
            this.Controls.Add(this.ultraLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelFechas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelFechas";
            this.Load += new System.EventHandler(this.SelFechas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraComboEditor1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dateInicio;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dateFin;
        private Infragistics.Win.Misc.UltraButton btnCerrar;
        private Infragistics.Win.Misc.UltraButton btnGenerar;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ultraComboEditor1;
    }
}