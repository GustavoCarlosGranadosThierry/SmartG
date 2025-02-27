namespace SmartG.Operaciones.Claims
{
    partial class SeleccionEsquemaHonorario
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.btnGuardar = new Infragistics.Win.Misc.UltraButton();
            this.cbViaticos = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.honorariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.claims = new SmartG.Datasets.Claims.Claims();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.honorariosTableAdapter = new SmartG.Datasets.Claims.ClaimsTableAdapters.HonorariosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cbViaticos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.honorariosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.claims)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(79, 108);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(181, 28);
            this.btnGuardar.TabIndex = 53;
            this.btnGuardar.Text = "Editar";
            this.btnGuardar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cbViaticos
            // 
            this.cbViaticos.DataSource = this.honorariosBindingSource;
            this.cbViaticos.DisplayMember = "NombreEstructura";
            this.cbViaticos.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbViaticos.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbViaticos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbViaticos.LimitToList = true;
            this.cbViaticos.Location = new System.Drawing.Point(35, 61);
            this.cbViaticos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbViaticos.Name = "cbViaticos";
            this.cbViaticos.Size = new System.Drawing.Size(278, 24);
            this.cbViaticos.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.cbViaticos.TabIndex = 52;
            this.cbViaticos.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbViaticos.ValueMember = "ID";
            // 
            // honorariosBindingSource
            // 
            this.honorariosBindingSource.DataMember = "Honorarios";
            this.honorariosBindingSource.DataSource = this.claims;
            // 
            // claims
            // 
            this.claims.DataSetName = "Claims";
            this.claims.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ultraLabel2
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance1;
            this.ultraLabel2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel2.Location = new System.Drawing.Point(25, 14);
            this.ultraLabel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(288, 34);
            this.ultraLabel2.TabIndex = 54;
            this.ultraLabel2.Text = "Seleccione el Esquema de Honorarios a editar";
            // 
            // honorariosTableAdapter
            // 
            this.honorariosTableAdapter.ClearBeforeFill = true;
            // 
            // SeleccionEsquemaHonorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 156);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cbViaticos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SeleccionEsquemaHonorario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeleccionEsquemaHonorario";
            this.Load += new System.EventHandler(this.SeleccionEsquemaHonorario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbViaticos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.honorariosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.claims)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton btnGuardar;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbViaticos;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Datasets.Claims.Claims claims;
        private System.Windows.Forms.BindingSource honorariosBindingSource;
        private Datasets.Claims.ClaimsTableAdapters.HonorariosTableAdapter honorariosTableAdapter;
    }
}