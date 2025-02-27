namespace SmartG
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.lbCambioPass = new System.Windows.Forms.Label();
            this.lbStatusFAQ = new System.Windows.Forms.Label();
            this.txtStatusServer = new System.Windows.Forms.TextBox();
            this.lbStatusLogin = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lbContrasena = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cambiarIdiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verificarRutaABaseDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.agregarUnNuevoUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugImportacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.picReload = new System.Windows.Forms.PictureBox();
            this.lbAmbiente = new System.Windows.Forms.Label();
            this.lbProduccion = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReload)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCambioPass
            // 
            this.lbCambioPass.AutoSize = true;
            this.lbCambioPass.BackColor = System.Drawing.Color.Transparent;
            this.lbCambioPass.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCambioPass.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbCambioPass.Location = new System.Drawing.Point(320, 215);
            this.lbCambioPass.Name = "lbCambioPass";
            this.lbCambioPass.Size = new System.Drawing.Size(194, 16);
            this.lbCambioPass.TabIndex = 4;
            this.lbCambioPass.Text = "¿Olvidaste tu contraseña?";
            this.lbCambioPass.MouseLeave += new System.EventHandler(this.LbCambioPass_MouseLeave);
            this.lbCambioPass.MouseHover += new System.EventHandler(this.LbCambioPass_MouseHover);
            // 
            // lbStatusFAQ
            // 
            this.lbStatusFAQ.AutoSize = true;
            this.lbStatusFAQ.BackColor = System.Drawing.Color.Transparent;
            this.lbStatusFAQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbStatusFAQ.Font = new System.Drawing.Font("Arial Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatusFAQ.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbStatusFAQ.Location = new System.Drawing.Point(32, 287);
            this.lbStatusFAQ.Name = "lbStatusFAQ";
            this.lbStatusFAQ.Size = new System.Drawing.Size(234, 15);
            this.lbStatusFAQ.TabIndex = 9;
            this.lbStatusFAQ.Text = "¿Qué hago si está en rojo el servicio?";
            this.lbStatusFAQ.Visible = false;
            this.lbStatusFAQ.Click += new System.EventHandler(this.LbStatusFAQ_Click);
            this.lbStatusFAQ.MouseLeave += new System.EventHandler(this.LbStatusFAQ_MouseLeave);
            this.lbStatusFAQ.MouseHover += new System.EventHandler(this.LbStatusFAQ_MouseHover);
            // 
            // txtStatusServer
            // 
            this.txtStatusServer.Enabled = false;
            this.txtStatusServer.Location = new System.Drawing.Point(443, 261);
            this.txtStatusServer.Name = "txtStatusServer";
            this.txtStatusServer.Size = new System.Drawing.Size(57, 20);
            this.txtStatusServer.TabIndex = 8;
            // 
            // lbStatusLogin
            // 
            this.lbStatusLogin.AutoSize = true;
            this.lbStatusLogin.Location = new System.Drawing.Point(343, 265);
            this.lbStatusLogin.Name = "lbStatusLogin";
            this.lbStatusLogin.Size = new System.Drawing.Size(95, 13);
            this.lbStatusLogin.TabIndex = 7;
            this.lbStatusLogin.Text = "Status del Servicio";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.DarkRed;
            this.btnClose.Location = new System.Drawing.Point(375, 169);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.Green;
            this.btnOK.Location = new System.Drawing.Point(465, 169);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 29);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Acceder";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(375, 126);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '•';
            this.txtPass.Size = new System.Drawing.Size(165, 22);
            this.txtPass.TabIndex = 1;
            // 
            // lbContrasena
            // 
            this.lbContrasena.AutoSize = true;
            this.lbContrasena.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(249)))));
            this.lbContrasena.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContrasena.Location = new System.Drawing.Point(267, 130);
            this.lbContrasena.Name = "lbContrasena";
            this.lbContrasena.Size = new System.Drawing.Size(89, 18);
            this.lbContrasena.TabIndex = 0;
            this.lbContrasena.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(375, 79);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(165, 22);
            this.txtUsuario.TabIndex = 6;
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(249)))));
            this.lbUsuario.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsuario.Location = new System.Drawing.Point(267, 80);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(62, 18);
            this.lbUsuario.TabIndex = 5;
            this.lbUsuario.Text = "Usuario";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarIdiomaToolStripMenuItem,
            this.verificarRutaABaseDeDatosToolStripMenuItem,
            this.toolStripSeparator1,
            this.agregarUnNuevoUsuarioToolStripMenuItem,
            this.debugImportacionToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(225, 120);
            // 
            // cambiarIdiomaToolStripMenuItem
            // 
            this.cambiarIdiomaToolStripMenuItem.Name = "cambiarIdiomaToolStripMenuItem";
            this.cambiarIdiomaToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.cambiarIdiomaToolStripMenuItem.Text = "Cambiar Idioma";
            this.cambiarIdiomaToolStripMenuItem.Click += new System.EventHandler(this.CambiarIdiomaToolStripMenuItem_Click);
            // 
            // verificarRutaABaseDeDatosToolStripMenuItem
            // 
            this.verificarRutaABaseDeDatosToolStripMenuItem.Name = "verificarRutaABaseDeDatosToolStripMenuItem";
            this.verificarRutaABaseDeDatosToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.verificarRutaABaseDeDatosToolStripMenuItem.Text = "Verificar ruta a Base de datos";
            this.verificarRutaABaseDeDatosToolStripMenuItem.Click += new System.EventHandler(this.VerificarRutaABaseDeDatosToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // agregarUnNuevoUsuarioToolStripMenuItem
            // 
            this.agregarUnNuevoUsuarioToolStripMenuItem.Name = "agregarUnNuevoUsuarioToolStripMenuItem";
            this.agregarUnNuevoUsuarioToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.agregarUnNuevoUsuarioToolStripMenuItem.Text = "Agregar un nuevo usuario";
            this.agregarUnNuevoUsuarioToolStripMenuItem.Click += new System.EventHandler(this.agregarUnNuevoUsuarioToolStripMenuItem_Click);
            // 
            // debugImportacionToolStripMenuItem
            // 
            this.debugImportacionToolStripMenuItem.Name = "debugImportacionToolStripMenuItem";
            this.debugImportacionToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.debugImportacionToolStripMenuItem.Text = "Debug importacion";
            this.debugImportacionToolStripMenuItem.Click += new System.EventHandler(this.debugImportacionToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // picReload
            // 
            this.picReload.BackColor = System.Drawing.Color.Transparent;
            this.picReload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picReload.Image = global::SmartG.Properties.Resources.refresh;
            this.picReload.Location = new System.Drawing.Point(522, 255);
            this.picReload.Name = "picReload";
            this.picReload.Size = new System.Drawing.Size(38, 34);
            this.picReload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picReload.TabIndex = 10;
            this.picReload.TabStop = false;
            this.picReload.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lbAmbiente
            // 
            this.lbAmbiente.AutoSize = true;
            this.lbAmbiente.BackColor = System.Drawing.Color.Transparent;
            this.lbAmbiente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAmbiente.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbAmbiente.Location = new System.Drawing.Point(115, 251);
            this.lbAmbiente.Name = "lbAmbiente";
            this.lbAmbiente.Size = new System.Drawing.Size(151, 14);
            this.lbAmbiente.TabIndex = 11;
            this.lbAmbiente.Text = "¿Olvidaste tu contraseña?";
            // 
            // lbProduccion
            // 
            this.lbProduccion.AutoSize = true;
            this.lbProduccion.BackColor = System.Drawing.Color.Transparent;
            this.lbProduccion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProduccion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbProduccion.Location = new System.Drawing.Point(115, 251);
            this.lbProduccion.Name = "lbProduccion";
            this.lbProduccion.Size = new System.Drawing.Size(151, 14);
            this.lbProduccion.TabIndex = 12;
            this.lbProduccion.Text = "¿Olvidaste tu contraseña?";
            // 
            // Login
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SmartG.Properties.Resources.LoginPage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.lbProduccion);
            this.Controls.Add(this.lbAmbiente);
            this.Controls.Add(this.picReload);
            this.Controls.Add(this.lbStatusFAQ);
            this.Controls.Add(this.lbCambioPass);
            this.Controls.Add(this.txtStatusServer);
            this.Controls.Add(this.lbStatusLogin);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lbContrasena);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lbUsuario);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picReload)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCambioPass;
        private System.Windows.Forms.Label lbStatusFAQ;
        private System.Windows.Forms.TextBox txtStatusServer;
        private System.Windows.Forms.Label lbStatusLogin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lbContrasena;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cambiarIdiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verificarRutaABaseDeDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem agregarUnNuevoUsuarioToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox picReload;
        private System.Windows.Forms.Label lbAmbiente;
        private System.Windows.Forms.Label lbProduccion;
        private System.Windows.Forms.ToolStripMenuItem debugImportacionToolStripMenuItem;
    }
}