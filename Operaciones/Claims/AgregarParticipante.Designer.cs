namespace SmartG.Operaciones.Claims
{
    partial class AgregarParticipante
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
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            this.grpDatosGenerales = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtEmail = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbEmail = new Infragistics.Win.Misc.UltraLabel();
            this.txtTelefono = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbTelefono = new Infragistics.Win.Misc.UltraLabel();
            this.lbTipo = new Infragistics.Win.Misc.UltraLabel();
            this.cbTipo = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.tipoRelacionParticipantesClaimsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.claims = new SmartG.Datasets.Claims.Claims();
            this.txtNombre = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtDireccion = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lnNombre = new Infragistics.Win.Misc.UltraLabel();
            this.lb = new Infragistics.Win.Misc.UltraLabel();
            this.grpDatosPago = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtClabe = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbRFC = new Infragistics.Win.Misc.UltraLabel();
            this.lbClabe = new Infragistics.Win.Misc.UltraLabel();
            this.txtCuenta = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbCuenta = new Infragistics.Win.Misc.UltraLabel();
            this.txtRFC = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtBanco = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbBanco = new Infragistics.Win.Misc.UltraLabel();
            this.btnGuardarAgregar = new Infragistics.Win.Misc.UltraButton();
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            this.btnGuardar = new Infragistics.Win.Misc.UltraButton();
            this.tipoRelacionParticipantesClaimsTableAdapter = new SmartG.Datasets.Claims.ClaimsTableAdapters.TipoRelacionParticipantesClaimsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.grpDatosGenerales)).BeginInit();
            this.grpDatosGenerales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoRelacionParticipantesClaimsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.claims)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpDatosPago)).BeginInit();
            this.grpDatosPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtClabe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRFC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBanco)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDatosGenerales
            // 
            this.grpDatosGenerales.Controls.Add(this.txtEmail);
            this.grpDatosGenerales.Controls.Add(this.lbEmail);
            this.grpDatosGenerales.Controls.Add(this.txtTelefono);
            this.grpDatosGenerales.Controls.Add(this.lbTelefono);
            this.grpDatosGenerales.Controls.Add(this.lbTipo);
            this.grpDatosGenerales.Controls.Add(this.cbTipo);
            this.grpDatosGenerales.Controls.Add(this.txtNombre);
            this.grpDatosGenerales.Controls.Add(this.txtDireccion);
            this.grpDatosGenerales.Controls.Add(this.lnNombre);
            this.grpDatosGenerales.Controls.Add(this.lb);
            this.grpDatosGenerales.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpDatosGenerales.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpDatosGenerales.Location = new System.Drawing.Point(28, 27);
            this.grpDatosGenerales.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpDatosGenerales.Name = "grpDatosGenerales";
            this.grpDatosGenerales.Size = new System.Drawing.Size(722, 236);
            this.grpDatosGenerales.TabIndex = 37;
            this.grpDatosGenerales.Text = "Datos Generales";
            this.grpDatosGenerales.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // txtEmail
            // 
            this.txtEmail.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtEmail.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(212, 183);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtEmail.MaxLength = 250;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(470, 24);
            this.txtEmail.TabIndex = 35;
            // 
            // lbEmail
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.TextVAlignAsString = "Middle";
            this.lbEmail.Appearance = appearance1;
            this.lbEmail.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.Location = new System.Drawing.Point(24, 179);
            this.lbEmail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(182, 34);
            this.lbEmail.TabIndex = 34;
            this.lbEmail.Text = "Email Contacto:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtTelefono.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(214, 149);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtTelefono.MaxLength = 250;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(470, 24);
            this.txtTelefono.TabIndex = 32;
            // 
            // lbTelefono
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.TextVAlignAsString = "Middle";
            this.lbTelefono.Appearance = appearance2;
            this.lbTelefono.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTelefono.Location = new System.Drawing.Point(24, 145);
            this.lbTelefono.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lbTelefono.Name = "lbTelefono";
            this.lbTelefono.Size = new System.Drawing.Size(195, 34);
            this.lbTelefono.TabIndex = 31;
            this.lbTelefono.Text = "Telefono Contacto:";
            // 
            // lbTipo
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.TextVAlignAsString = "Middle";
            this.lbTipo.Appearance = appearance3;
            this.lbTipo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTipo.Location = new System.Drawing.Point(23, 46);
            this.lbTipo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lbTipo.Name = "lbTipo";
            this.lbTipo.Size = new System.Drawing.Size(182, 34);
            this.lbTipo.TabIndex = 24;
            this.lbTipo.Text = "Tipo de Participante:";
            // 
            // cbTipo
            // 
            this.cbTipo.DataSource = this.tipoRelacionParticipantesClaimsBindingSource;
            this.cbTipo.DisplayMember = "TipoRelacion";
            this.cbTipo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbTipo.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbTipo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipo.LimitToList = true;
            this.cbTipo.Location = new System.Drawing.Point(214, 47);
            this.cbTipo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(468, 24);
            this.cbTipo.TabIndex = 23;
            this.cbTipo.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbTipo.ValueMember = "ID";
            // 
            // tipoRelacionParticipantesClaimsBindingSource
            // 
            this.tipoRelacionParticipantesClaimsBindingSource.DataMember = "TipoRelacionParticipantesClaims";
            this.tipoRelacionParticipantesClaimsBindingSource.DataSource = this.claims;
            // 
            // claims
            // 
            this.claims.DataSetName = "Claims";
            this.claims.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtNombre
            // 
            this.txtNombre.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtNombre.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(214, 81);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtNombre.MaxLength = 250;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(470, 24);
            this.txtNombre.TabIndex = 25;
            // 
            // txtDireccion
            // 
            this.txtDireccion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtDireccion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(214, 115);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDireccion.MaxLength = 250;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(470, 24);
            this.txtDireccion.TabIndex = 30;
            // 
            // lnNombre
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.TextVAlignAsString = "Middle";
            this.lnNombre.Appearance = appearance4;
            this.lnNombre.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnNombre.Location = new System.Drawing.Point(24, 77);
            this.lnNombre.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lnNombre.Name = "lnNombre";
            this.lnNombre.Size = new System.Drawing.Size(208, 34);
            this.lnNombre.TabIndex = 28;
            this.lnNombre.Text = "Nombre Completo:";
            // 
            // lb
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.TextVAlignAsString = "Middle";
            this.lb.Appearance = appearance5;
            this.lb.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb.Location = new System.Drawing.Point(23, 111);
            this.lb.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(195, 34);
            this.lb.TabIndex = 29;
            this.lb.Text = "Dirrección:";
            // 
            // grpDatosPago
            // 
            this.grpDatosPago.Controls.Add(this.txtClabe);
            this.grpDatosPago.Controls.Add(this.lbRFC);
            this.grpDatosPago.Controls.Add(this.lbClabe);
            this.grpDatosPago.Controls.Add(this.txtCuenta);
            this.grpDatosPago.Controls.Add(this.lbCuenta);
            this.grpDatosPago.Controls.Add(this.txtRFC);
            this.grpDatosPago.Controls.Add(this.txtBanco);
            this.grpDatosPago.Controls.Add(this.lbBanco);
            this.grpDatosPago.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpDatosPago.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpDatosPago.Location = new System.Drawing.Point(28, 284);
            this.grpDatosPago.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpDatosPago.Name = "grpDatosPago";
            this.grpDatosPago.Size = new System.Drawing.Size(722, 193);
            this.grpDatosPago.TabIndex = 38;
            this.grpDatosPago.Text = "Datos de Pago";
            this.grpDatosPago.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // txtClabe
            // 
            this.txtClabe.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtClabe.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClabe.Location = new System.Drawing.Point(212, 137);
            this.txtClabe.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtClabe.MaxLength = 18;
            this.txtClabe.Name = "txtClabe";
            this.txtClabe.Size = new System.Drawing.Size(470, 24);
            this.txtClabe.TabIndex = 38;
            // 
            // lbRFC
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.TextVAlignAsString = "Middle";
            this.lbRFC.Appearance = appearance6;
            this.lbRFC.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRFC.Location = new System.Drawing.Point(23, 39);
            this.lbRFC.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lbRFC.Name = "lbRFC";
            this.lbRFC.Size = new System.Drawing.Size(182, 34);
            this.lbRFC.TabIndex = 37;
            this.lbRFC.Text = "RFC:";
            // 
            // lbClabe
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            appearance7.TextVAlignAsString = "Middle";
            this.lbClabe.Appearance = appearance7;
            this.lbClabe.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClabe.Location = new System.Drawing.Point(24, 133);
            this.lbClabe.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lbClabe.Name = "lbClabe";
            this.lbClabe.Size = new System.Drawing.Size(182, 34);
            this.lbClabe.TabIndex = 34;
            this.lbClabe.Text = "CLABE:";
            // 
            // txtCuenta
            // 
            this.txtCuenta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtCuenta.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuenta.Location = new System.Drawing.Point(212, 107);
            this.txtCuenta.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCuenta.MaxLength = 250;
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(470, 24);
            this.txtCuenta.TabIndex = 32;
            // 
            // lbCuenta
            // 
            appearance8.BackColor = System.Drawing.Color.Transparent;
            appearance8.TextVAlignAsString = "Middle";
            this.lbCuenta.Appearance = appearance8;
            this.lbCuenta.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCuenta.Location = new System.Drawing.Point(23, 103);
            this.lbCuenta.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lbCuenta.Name = "lbCuenta";
            this.lbCuenta.Size = new System.Drawing.Size(195, 34);
            this.lbCuenta.TabIndex = 31;
            this.lbCuenta.Text = "Numero de Cuenta:";
            // 
            // txtRFC
            // 
            this.txtRFC.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtRFC.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRFC.Location = new System.Drawing.Point(212, 39);
            this.txtRFC.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtRFC.MaxLength = 13;
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Size = new System.Drawing.Size(470, 24);
            this.txtRFC.TabIndex = 25;
            // 
            // txtBanco
            // 
            this.txtBanco.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtBanco.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBanco.Location = new System.Drawing.Point(212, 73);
            this.txtBanco.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtBanco.MaxLength = 250;
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Size = new System.Drawing.Size(470, 24);
            this.txtBanco.TabIndex = 30;
            // 
            // lbBanco
            // 
            appearance9.BackColor = System.Drawing.Color.Transparent;
            appearance9.TextVAlignAsString = "Middle";
            this.lbBanco.Appearance = appearance9;
            this.lbBanco.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBanco.Location = new System.Drawing.Point(23, 69);
            this.lbBanco.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lbBanco.Name = "lbBanco";
            this.lbBanco.Size = new System.Drawing.Size(195, 34);
            this.lbBanco.TabIndex = 29;
            this.lbBanco.Text = "Nombre del Banco:";
            // 
            // btnGuardarAgregar
            // 
            this.btnGuardarAgregar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnGuardarAgregar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarAgregar.Location = new System.Drawing.Point(521, 504);
            this.btnGuardarAgregar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuardarAgregar.Name = "btnGuardarAgregar";
            this.btnGuardarAgregar.Size = new System.Drawing.Size(229, 28);
            this.btnGuardarAgregar.TabIndex = 39;
            this.btnGuardarAgregar.Text = "Guardar y Agregar";
            this.btnGuardarAgregar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnGuardarAgregar.Click += new System.EventHandler(this.btnGuardarAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(27, 504);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(229, 28);
            this.btnCancelar.TabIndex = 40;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(275, 504);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(229, 28);
            this.btnGuardar.TabIndex = 41;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // tipoRelacionParticipantesClaimsTableAdapter
            // 
            this.tipoRelacionParticipantesClaimsTableAdapter.ClearBeforeFill = true;
            // 
            // AgregarParticipante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 568);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardarAgregar);
            this.Controls.Add(this.grpDatosPago);
            this.Controls.Add(this.grpDatosGenerales);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AgregarParticipante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgregarParticipante";
            this.Load += new System.EventHandler(this.AgregarParticipante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpDatosGenerales)).EndInit();
            this.grpDatosGenerales.ResumeLayout(false);
            this.grpDatosGenerales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoRelacionParticipantesClaimsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.claims)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpDatosPago)).EndInit();
            this.grpDatosPago.ResumeLayout(false);
            this.grpDatosPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtClabe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRFC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBanco)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox grpDatosGenerales;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtEmail;
        private Infragistics.Win.Misc.UltraLabel lbEmail;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtTelefono;
        private Infragistics.Win.Misc.UltraLabel lbTelefono;
        private Infragistics.Win.Misc.UltraLabel lbTipo;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbTipo;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtNombre;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDireccion;
        private Infragistics.Win.Misc.UltraLabel lnNombre;
        private Infragistics.Win.Misc.UltraLabel lb;
        private Infragistics.Win.Misc.UltraGroupBox grpDatosPago;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtClabe;
        private Infragistics.Win.Misc.UltraLabel lbRFC;
        private Infragistics.Win.Misc.UltraLabel lbClabe;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCuenta;
        private Infragistics.Win.Misc.UltraLabel lbCuenta;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtRFC;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtBanco;
        private Infragistics.Win.Misc.UltraLabel lbBanco;
        private Infragistics.Win.Misc.UltraButton btnGuardarAgregar;
        private Infragistics.Win.Misc.UltraButton btnCancelar;
        private Infragistics.Win.Misc.UltraButton btnGuardar;
        private Datasets.Claims.Claims claims;
        private System.Windows.Forms.BindingSource tipoRelacionParticipantesClaimsBindingSource;
        private Datasets.Claims.ClaimsTableAdapters.TipoRelacionParticipantesClaimsTableAdapter tipoRelacionParticipantesClaimsTableAdapter;
    }
}