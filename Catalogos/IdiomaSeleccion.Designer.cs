namespace SmartG.Catalogos
{
    partial class IdiomaSeleccion
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
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.grpEdicionIdioma = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            this.btnAplicar = new Infragistics.Win.Misc.UltraButton();
            this.cbIdiomas = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lbIdiomaSeleccionado = new Infragistics.Win.Misc.UltraLabel();
            this.lbCambiarIdioma = new Infragistics.Win.Misc.UltraLabel();
            this.lbIdiomaActual = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grpEdicionIdioma)).BeginInit();
            this.grpEdicionIdioma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbIdiomas)).BeginInit();
            this.SuspendLayout();
            // 
            // grpEdicionIdioma
            // 
            this.grpEdicionIdioma.Controls.Add(this.btnCancelar);
            this.grpEdicionIdioma.Controls.Add(this.btnAplicar);
            this.grpEdicionIdioma.Controls.Add(this.cbIdiomas);
            this.grpEdicionIdioma.Controls.Add(this.lbIdiomaSeleccionado);
            this.grpEdicionIdioma.Controls.Add(this.lbCambiarIdioma);
            this.grpEdicionIdioma.Controls.Add(this.lbIdiomaActual);
            this.grpEdicionIdioma.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpEdicionIdioma.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpEdicionIdioma.Location = new System.Drawing.Point(12, 12);
            this.grpEdicionIdioma.Name = "grpEdicionIdioma";
            this.grpEdicionIdioma.Size = new System.Drawing.Size(367, 182);
            this.grpEdicionIdioma.TabIndex = 1;
            this.grpEdicionIdioma.Text = "Edición de idioma SmartG";
            this.grpEdicionIdioma.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnCancelar.Location = new System.Drawing.Point(40, 129);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(132, 24);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnAplicar.Location = new System.Drawing.Point(187, 129);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(132, 24);
            this.btnAplicar.TabIndex = 10;
            this.btnAplicar.Text = "Aplicar Cambios";
            this.btnAplicar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // cbIdiomas
            // 
            this.cbIdiomas.DisplayMember = "ProducingOffice";
            this.cbIdiomas.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbIdiomas.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbIdiomas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            valueListItem2.DataValue = "English";
            valueListItem1.DataValue = "Español";
            valueListItem3.DataValue = "Português";
            this.cbIdiomas.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem2,
            valueListItem1,
            valueListItem3});
            this.cbIdiomas.LimitToList = true;
            this.cbIdiomas.Location = new System.Drawing.Point(159, 78);
            this.cbIdiomas.Name = "cbIdiomas";
            this.cbIdiomas.Size = new System.Drawing.Size(160, 24);
            this.cbIdiomas.TabIndex = 9;
            this.cbIdiomas.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbIdiomas.ValueMember = "ID";
            this.cbIdiomas.ItemNotInList += new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.cbIdiomas_ItemNotInList);
            // 
            // lbIdiomaSeleccionado
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.lbIdiomaSeleccionado.Appearance = appearance1;
            this.lbIdiomaSeleccionado.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIdiomaSeleccionado.Location = new System.Drawing.Point(159, 44);
            this.lbIdiomaSeleccionado.Name = "lbIdiomaSeleccionado";
            this.lbIdiomaSeleccionado.Size = new System.Drawing.Size(147, 23);
            this.lbIdiomaSeleccionado.TabIndex = 1;
            this.lbIdiomaSeleccionado.Text = "Idioma";
            // 
            // lbCambiarIdioma
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.lbCambiarIdioma.Appearance = appearance2;
            this.lbCambiarIdioma.Location = new System.Drawing.Point(17, 82);
            this.lbCambiarIdioma.Name = "lbCambiarIdioma";
            this.lbCambiarIdioma.Size = new System.Drawing.Size(147, 23);
            this.lbCambiarIdioma.TabIndex = 2;
            this.lbCambiarIdioma.Text = "Cambiar Idioma:";
            // 
            // lbIdiomaActual
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.lbIdiomaActual.Appearance = appearance3;
            this.lbIdiomaActual.Location = new System.Drawing.Point(17, 44);
            this.lbIdiomaActual.Name = "lbIdiomaActual";
            this.lbIdiomaActual.Size = new System.Drawing.Size(147, 23);
            this.lbIdiomaActual.TabIndex = 0;
            this.lbIdiomaActual.Text = "Idioma Actual:";
            // 
            // IdiomaSeleccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 205);
            this.Controls.Add(this.grpEdicionIdioma);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IdiomaSeleccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IdiomaSeleccion";
            this.Load += new System.EventHandler(this.IdiomaSeleccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpEdicionIdioma)).EndInit();
            this.grpEdicionIdioma.ResumeLayout(false);
            this.grpEdicionIdioma.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbIdiomas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox grpEdicionIdioma;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbIdiomas;
        private Infragistics.Win.Misc.UltraLabel lbIdiomaSeleccionado;
        private Infragistics.Win.Misc.UltraLabel lbCambiarIdioma;
        private Infragistics.Win.Misc.UltraLabel lbIdiomaActual;
        private Infragistics.Win.Misc.UltraButton btnAplicar;
        private Infragistics.Win.Misc.UltraButton btnCancelar;
    }
}