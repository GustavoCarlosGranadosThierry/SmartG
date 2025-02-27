using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices;

namespace SmartG
{
    public partial class Login : Form
    {

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // nombres y valores de todos los objetos que se encuentran en el formulario
        #region coleccion objetos

        //lbUsuario Usuario
        //txtUsuario
        //lbContrasena    Contraseña
        //btnOK   Acceder
        //btnClose    Cerrar
        //lbCambioPass    ¿Olvidaste tu contraseña?
        //lbStatus    Status del Servicio
        //txtStatusServer
        //lbStatusFAQ	¿Qué hago si está en rojo el servicio?
        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region variables

        int ContadorErrores = 0;
        public static bool StatusConexion;

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region Metodos programados

        void borrarArchivos()
        {
            if (File.Exists(Environment.CurrentDirectory + "CerPem.pem"))
            {
                try
                {
                    File.Delete(Environment.CurrentDirectory + "CerPem.pem");
                }
                catch
                {
                }
            }
            if (File.Exists(Environment.CurrentDirectory + "KeyPem.pem"))
            {
                try
                {
                    File.Delete(Environment.CurrentDirectory + "KeyPem.pem");
                }
                catch
                {
                }
            }
        }

        public static bool IsServerConnected()
        {
            using (SqlConnection connection = new SqlConnection(SmartG.Properties.Settings.Default.XLCatlinConnectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        void ResearPassword()
        {
            if (txtPass.Text == "W3lc0me")
            {
                Catalogos.ResetPassword frmResetPass = new Catalogos.ResetPassword();
                if (frmResetPass.ShowDialog() != DialogResult.Yes)
                    Application.Exit();
            }
        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region eventos del form

        public Login()
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
            borrarArchivos();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (StatusConexion)
            {
                txtStatusServer.BackColor = Color.Lime;
                picReload.Visible = false;
            }
            else
            {
                txtStatusServer.BackColor = Color.Red;
                lbStatusFAQ.Visible = true;
                btnOK.Enabled = false;
            }

            if (Properties.Settings.Default.XLCatlinConnectionString.Contains("CopyLive"))
            {
                lbAmbiente.ForeColor = Color.Blue;
                lbProduccion.Visible = false;
            }
            else
            {
                lbAmbiente.Visible = false;
            }

            txtUsuario.Text = Properties.Settings.Default.usuarioDefault;
            Extensiones.Traduccion.traducirVentana(this);
            Extensiones.Traduccion.TraducirContextMenu(contextMenuStrip1);
        }

        private void LbCambioPass_MouseHover(object sender, EventArgs e)
        {
            lbCambioPass.ForeColor = Color.Blue;
            Cursor = Cursors.Hand;
        }

        private void LbCambioPass_MouseLeave(object sender, EventArgs e)
        {
            lbCambioPass.ForeColor = Color.Black;
            Cursor = Cursors.Default;
        }

        private void LbStatusFAQ_MouseHover(object sender, EventArgs e)
        {
            lbStatusFAQ.ForeColor = Color.Blue;
            Cursor = Cursors.Hand;
        }

        private void LbStatusFAQ_MouseLeave(object sender, EventArgs e)
        {
            lbStatusFAQ.ForeColor = Color.Black;
            Cursor = Cursors.Default;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            Encripcion objEncrypt = new Encripcion();
            string password = objEncrypt.Encrypt(txtPass.Text);

            dbSmartGDataContext db = new dbSmartGDataContext();
            Usuario logIn = (from x in db.Usuarios where x.UserName == txtUsuario.Text && x.Password == password && x.Eliminado == false select x).SingleOrDefault();
            if (logIn != null)
            {
                string pass = objEncrypt.Decrypt(logIn.Password);
                if (pass == txtPass.Text)
                {
                    // Pone las variables de global sobre el usuario logeado
                    Program.Globals.UserID = logIn.ID;
                    Program.Globals.TipoUsuario = (from x in db.TipoUsuarios where x.ID == logIn.TipoUsuario select x.TipoUsuario1).SingleOrDefault();
                    Program.Globals.UserName = logIn.UserName;
                    Program.Globals.CurrentSessionID = Extensiones.ChangeLog.LogInLog();
                    Program.Globals.NombreCompletoUsuario = logIn.ApellidoPaterno + ", " + logIn.Nombre;
                    Properties.Settings.Default.usuarioDefault = txtUsuario.Text;
                    Properties.Settings.Default.Save();

                    // Ingreso al sistema
                    Main frmMain = new Main();
                    Hide();
                    ResearPassword();
                            frmMain.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error en el acceso al sistema, por favor verifique sus credenciales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPass.Text = "";
                    txtPass.Focus();
                }
            }
            else
            {
                MessageBox.Show("El usuario y/o contraseña no son validos, por favor verifique sus credenciales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Text = "";
                txtPass.Focus();
                ContadorErrores++;
            }

            if (ContadorErrores >= 3)
                Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LbStatusFAQ_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("El sistema no se encuentra conectado al Servidor de SmartG, favor de verificar que este equipo de encuentré dentro de la misma red que el Servidor de SmartG." + Environment.NewLine +
                "Si se encuentra fuera su oficina, favor de revisar su conexión VPN." + Environment.NewLine + Environment.NewLine +
                "Si el problema persiste, comuniquesé con soporte técnico de SmartG al email: " + ErrorHandler.emailMain + Environment.NewLine + Environment.NewLine +
                "Abrir nueva solicitud de soporte?", "Error de conexión", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                ErrorHandler frmError = new ErrorHandler("No hay conexión a la base de datos", "");
                frmError.ShowDialog();
            }
        }

        private void CambiarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.IdiomaSeleccion frmSelIdioma = new Catalogos.IdiomaSeleccion();
            if (frmSelIdioma.ShowDialog() == DialogResult.Yes)
            {
                Extensiones.Traduccion.traducirVentana(this);
                Extensiones.Traduccion.TraducirContextMenu(contextMenuStrip1);
            }
        }

        private void VerificarRutaABaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Extensiones.Edicion.VerificarRutaBD();
        }

        private void agregarUnNuevoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtStatusServer.BackColor != Color.Lime)
            {
                MessageBox.Show("No hay conexión a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                string EnterdPass = "";
                Extensiones.Edicion.InputBox("Admin Password", "Ingrese el password del administrador", ref EnterdPass, true);
                Encripcion objEncrypt = new Encripcion();
                string EnterdPassEnc = objEncrypt.Encrypt(EnterdPass);
                string PassAdmin = (from x in db.Usuarios where x.UserName == "admin" select x.Password).SingleOrDefault();
                if (EnterdPassEnc != PassAdmin)
                {
                    MessageBox.Show("Password ingresado incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string NuevoUserName = "";
                    Extensiones.Edicion.InputBox("Nuevo Usuario", "Ingrese un nuevo UserName", ref NuevoUserName);
                    if (NuevoUserName == "" || NuevoUserName.Length < 5)
                    {
                        MessageBox.Show("Ingrese un nombre valido, con almenos 5 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if ((from x in db.Usuarios where x.UserName == NuevoUserName select x).ToArray().Count() != 0)
                        {
                            MessageBox.Show("El usuario ya existe en la base", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            string NuevoPassword = "";
                            Extensiones.Edicion.InputBox("Nuevo Password", "Ingrese un nuevo Password valido ", ref NuevoPassword, true);
                            if (NuevoPassword == "" || !Encripcion.ValidatePassword(NuevoPassword))
                            {
                                MessageBox.Show("Ingrese un password valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                Usuario newUsuario = new Usuario();
                                newUsuario.UserName = NuevoUserName;
                                newUsuario.Password = objEncrypt.Encrypt(NuevoPassword);
                                db.Usuarios.InsertOnSubmit(newUsuario);
                                db.SubmitChanges();
                                MessageBox.Show("Usuario Registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Login.StatusConexion = Login.IsServerConnected();
            if (StatusConexion)
            {
                txtStatusServer.BackColor = Color.Lime;
                lbStatusFAQ.Visible = false;
                btnOK.Enabled = true;
                picReload.Visible = false;
            }
            else
            {
                txtStatusServer.BackColor = Color.Red;
                lbStatusFAQ.Visible = true;
                btnOK.Enabled = false;
                picReload.Visible = true;
            }
            this.Cursor = Cursors.Arrow;

        }

        private void debugImportacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tmpImportador frmTmp = new tmpImportador();
            frmTmp.ShowDialog();
        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
    }
}
