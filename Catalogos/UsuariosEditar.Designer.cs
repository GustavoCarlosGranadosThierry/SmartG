namespace SmartG.Catalogos
{
    partial class UsuariosEditar_
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.tipoUsuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.catalogosGral = new SmartG.Datasets.Catalogos.catalogosGral();
            this.tipoUsuarioTableAdapter = new SmartG.Datasets.Catalogos.catalogosGralTableAdapters.TipoUsuarioTableAdapter();
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            this.btnAgregar = new Infragistics.Win.Misc.UltraButton();
            this.cbTipoUsuario = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.txtEmail = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtApellidoMaterno = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtApellidoPaterno = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtNombre = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbNombre = new Infragistics.Win.Misc.UltraLabel();
            this.lbTipoUsuario = new Infragistics.Win.Misc.UltraLabel();
            this.lbEmail = new Infragistics.Win.Misc.UltraLabel();
            this.lbApellidoMaterno = new Infragistics.Win.Misc.UltraLabel();
            this.lbApellidoPaterno = new Infragistics.Win.Misc.UltraLabel();
            this.txtUserName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbUserName = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.tipoUsuarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogosGral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTipoUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApellidoMaterno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApellidoPaterno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName)).BeginInit();
            this.SuspendLayout();
            // 
            // tipoUsuarioBindingSource
            // 
            this.tipoUsuarioBindingSource.DataMember = "TipoUsuario";
            this.tipoUsuarioBindingSource.DataSource = this.catalogosGral;
            // 
            // catalogosGral
            // 
            this.catalogosGral.DataSetName = "catalogosGral";
            this.catalogosGral.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tipoUsuarioTableAdapter
            // 
            this.tipoUsuarioTableAdapter.ClearBeforeFill = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.Location = new System.Drawing.Point(77, 344);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(219, 33);
            this.btnCancelar.TabIndex = 62;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnAgregar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.Location = new System.Drawing.Point(313, 344);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(219, 33);
            this.btnAgregar.TabIndex = 61;
            this.btnAgregar.Text = "Agregar / Modificar";
            this.btnAgregar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // cbTipoUsuario
            // 
            this.cbTipoUsuario.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cbTipoUsuario.DataSource = this.tipoUsuarioBindingSource;
            this.cbTipoUsuario.DisplayMember = "TipoUsuario";
            this.cbTipoUsuario.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbTipoUsuario.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbTipoUsuario.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoUsuario.Location = new System.Drawing.Point(235, 266);
            this.cbTipoUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.cbTipoUsuario.Name = "cbTipoUsuario";
            this.cbTipoUsuario.Size = new System.Drawing.Size(345, 24);
            this.cbTipoUsuario.TabIndex = 60;
            this.cbTipoUsuario.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbTipoUsuario.ValueMember = "ID";
            // 
            // txtEmail
            // 
            this.txtEmail.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtEmail.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(235, 219);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(345, 24);
            this.txtEmail.TabIndex = 59;
            // 
            // txtApellidoMaterno
            // 
            this.txtApellidoMaterno.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtApellidoMaterno.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidoMaterno.Location = new System.Drawing.Point(235, 173);
            this.txtApellidoMaterno.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellidoMaterno.MaxLength = 100;
            this.txtApellidoMaterno.Name = "txtApellidoMaterno";
            this.txtApellidoMaterno.Size = new System.Drawing.Size(345, 24);
            this.txtApellidoMaterno.TabIndex = 58;
            // 
            // txtApellidoPaterno
            // 
            this.txtApellidoPaterno.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtApellidoPaterno.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidoPaterno.Location = new System.Drawing.Point(235, 126);
            this.txtApellidoPaterno.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellidoPaterno.MaxLength = 100;
            this.txtApellidoPaterno.Name = "txtApellidoPaterno";
            this.txtApellidoPaterno.Size = new System.Drawing.Size(345, 24);
            this.txtApellidoPaterno.TabIndex = 57;
            // 
            // txtNombre
            // 
            this.txtNombre.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtNombre.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(235, 79);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(345, 24);
            this.txtNombre.TabIndex = 56;
            // 
            // lbNombre
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.TextVAlignAsString = "Middle";
            this.lbNombre.Appearance = appearance1;
            this.lbNombre.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbNombre.Location = new System.Drawing.Point(35, 75);
            this.lbNombre.Margin = new System.Windows.Forms.Padding(4);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(197, 39);
            this.lbNombre.TabIndex = 55;
            this.lbNombre.Text = "Nombre:";
            // 
            // lbTipoUsuario
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.TextVAlignAsString = "Middle";
            this.lbTipoUsuario.Appearance = appearance2;
            this.lbTipoUsuario.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbTipoUsuario.Location = new System.Drawing.Point(35, 262);
            this.lbTipoUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.lbTipoUsuario.Name = "lbTipoUsuario";
            this.lbTipoUsuario.Size = new System.Drawing.Size(197, 39);
            this.lbTipoUsuario.TabIndex = 54;
            this.lbTipoUsuario.Text = "Tipo de Usuario";
            // 
            // lbEmail
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.TextVAlignAsString = "Middle";
            this.lbEmail.Appearance = appearance3;
            this.lbEmail.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbEmail.Location = new System.Drawing.Point(35, 216);
            this.lbEmail.Margin = new System.Windows.Forms.Padding(4);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(197, 39);
            this.lbEmail.TabIndex = 53;
            this.lbEmail.Text = "Email";
            // 
            // lbApellidoMaterno
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.TextVAlignAsString = "Middle";
            this.lbApellidoMaterno.Appearance = appearance4;
            this.lbApellidoMaterno.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbApellidoMaterno.Location = new System.Drawing.Point(35, 169);
            this.lbApellidoMaterno.Margin = new System.Windows.Forms.Padding(4);
            this.lbApellidoMaterno.Name = "lbApellidoMaterno";
            this.lbApellidoMaterno.Size = new System.Drawing.Size(197, 39);
            this.lbApellidoMaterno.TabIndex = 52;
            this.lbApellidoMaterno.Text = "Apellido Materno";
            // 
            // lbApellidoPaterno
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.TextVAlignAsString = "Middle";
            this.lbApellidoPaterno.Appearance = appearance5;
            this.lbApellidoPaterno.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbApellidoPaterno.Location = new System.Drawing.Point(35, 122);
            this.lbApellidoPaterno.Margin = new System.Windows.Forms.Padding(4);
            this.lbApellidoPaterno.Name = "lbApellidoPaterno";
            this.lbApellidoPaterno.Size = new System.Drawing.Size(197, 39);
            this.lbApellidoPaterno.TabIndex = 51;
            this.lbApellidoPaterno.Text = "Apellido Paterno";
            // 
            // txtUserName
            // 
            this.txtUserName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtUserName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(235, 32);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserName.MaxLength = 100;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(345, 24);
            this.txtUserName.TabIndex = 50;
            // 
            // lbUserName
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.TextVAlignAsString = "Middle";
            this.lbUserName.Appearance = appearance6;
            this.lbUserName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbUserName.Location = new System.Drawing.Point(35, 29);
            this.lbUserName.Margin = new System.Windows.Forms.Padding(4);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(197, 39);
            this.lbUserName.TabIndex = 49;
            this.lbUserName.Text = "Nombre del usuario:";
            // 
            // UsuariosEditar_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 413);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cbTipoUsuario);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtApellidoMaterno);
            this.Controls.Add(this.txtApellidoPaterno);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.lbTipoUsuario);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.lbApellidoMaterno);
            this.Controls.Add(this.lbApellidoPaterno);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lbUserName);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UsuariosEditar_";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UsuariosEditar_";
            this.Load += new System.EventHandler(this.UsuariosEditar__Load);
            ((System.ComponentModel.ISupportInitialize)(this.tipoUsuarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogosGral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTipoUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApellidoMaterno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApellidoPaterno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Datasets.Catalogos.catalogosGral catalogosGral;
        private System.Windows.Forms.BindingSource tipoUsuarioBindingSource;
        private Datasets.Catalogos.catalogosGralTableAdapters.TipoUsuarioTableAdapter tipoUsuarioTableAdapter;
        private Infragistics.Win.Misc.UltraButton btnCancelar;
        private Infragistics.Win.Misc.UltraButton btnAgregar;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbTipoUsuario;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtEmail;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtApellidoMaterno;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtApellidoPaterno;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtNombre;
        private Infragistics.Win.Misc.UltraLabel lbNombre;
        private Infragistics.Win.Misc.UltraLabel lbTipoUsuario;
        private Infragistics.Win.Misc.UltraLabel lbEmail;
        private Infragistics.Win.Misc.UltraLabel lbApellidoMaterno;
        private Infragistics.Win.Misc.UltraLabel lbApellidoPaterno;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtUserName;
        private Infragistics.Win.Misc.UltraLabel lbUserName;
    }
}