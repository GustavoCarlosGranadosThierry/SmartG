using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Catalogos
{
    public partial class UsuariosEditar_ : Form
    {
        int IDUsuario;
        bool BloqueoTipoUsuario;

        public UsuariosEditar_(int IDusuario, bool bloqueoTipoUsuario = false)
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
            IDUsuario = IDusuario;
            BloqueoTipoUsuario = bloqueoTipoUsuario;
        }

        void CargarDataSets()
        {
            this.tipoUsuarioTableAdapter.Fill(this.catalogosGral.TipoUsuario);
        }

        void CargarDatosUsuario()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            Usuario UsuarioLoad = (from x in db.Usuarios where x.ID == IDUsuario select x).SingleOrDefault();
            if(UsuarioLoad != null)
            {
                txtUserName.Text = UsuarioLoad.UserName;
                txtNombre.Text = UsuarioLoad.Nombre;
                txtApellidoPaterno.Text = UsuarioLoad.ApellidoPaterno;
                txtApellidoMaterno.Text = UsuarioLoad.ApellidoMaterno;
                txtEmail.Text = UsuarioLoad.Email;
                cbTipoUsuario.Value = Convert.ToInt32(UsuarioLoad.TipoUsuario);
            }
            else
            {
                MessageBox.Show("El usuario no pudo ser recuperado, cierre esta ventana y reintente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UsuariosEditar__Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this);
            CargarDataSets();
            if (IDUsuario != 0)
            {
                btnAgregar.Text = "Actualizar Usuario";
                CargarDatosUsuario();
            }
            else
            {
                btnAgregar.Text = "Agregar Usuario";
            }

            if(BloqueoTipoUsuario)
            {
                txtUserName.Enabled = false;
                cbTipoUsuario.Enabled = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text == "" || txtNombre.Text == "" || lbApellidoPaterno.Text == "" || lbApellidoMaterno.Text == "" || txtEmail.Text == "" ||cbTipoUsuario.SelectedIndex == -1)
            {
                MessageBox.Show("Datos incompletos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IDUsuario == 0) // nuevo
            {
                Encripcion objEncrypt = new Encripcion();
                dbSmartGDataContext db = new dbSmartGDataContext();
                Usuario NewUsuario = new Usuario();
                NewUsuario.UserName = txtUserName.Text;
                NewUsuario.Password = objEncrypt.Encrypt("W3lc0me");
                // FIX agregar un metodo de envio de email xcon contraseña aleatoria;
                NewUsuario.Nombre = txtNombre.Text;
                NewUsuario.ApellidoPaterno = txtApellidoPaterno.Text;
                NewUsuario.ApellidoMaterno = txtApellidoMaterno.Text;
                NewUsuario.TipoUsuario = Convert.ToInt32(cbTipoUsuario.Value);
                NewUsuario.Email = txtEmail.Text;
                NewUsuario.Eliminado = false;
                db.Usuarios.InsertOnSubmit(NewUsuario);
                db.SubmitChanges();

                int IDnewUser = NewUsuario.ID;
                SmartG.UsuariosPerfil newUserPerfil = new SmartG. UsuariosPerfil();
                newUserPerfil.Usuario = IDnewUser;
                db.UsuariosPerfils.InsertOnSubmit(newUserPerfil);
                db.SubmitChanges();

                    MessageBox.Show("Usuario: " + txtUserName.Text + ", " + txtNombre.Text + " " + txtApellidoPaterno.Text + " " + txtApellidoMaterno.Text + " agregado correctamente."+ Environment.NewLine + Environment.NewLine
                        + "Edite sus accesos a las funcionalidades desde la ventana de Perfil de usuario."  +Environment.NewLine + Environment.NewLine
                        + "Utilizar el password de acceso único:        " + "W3lc0me", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DialogResult = DialogResult.Yes;
                Close();
            }
            else // edicion
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                Usuario EditUsuario = (from x in db.Usuarios where x.ID == IDUsuario select x).SingleOrDefault();
                EditUsuario.UserName = txtUserName.Text;
                EditUsuario.Nombre = txtNombre.Text;
                EditUsuario.ApellidoPaterno = txtApellidoPaterno.Text;
                EditUsuario.ApellidoMaterno = txtApellidoMaterno.Text;
                EditUsuario.TipoUsuario = Convert.ToInt32(cbTipoUsuario.Value);
                EditUsuario.Email = txtEmail.Text;
                db.SubmitChanges();
                MessageBox.Show("Usuario: " + txtUserName.Text + ", " + txtNombre.Text + " " + txtApellidoPaterno.Text + " " + txtApellidoMaterno.Text + " actualizado correctamente." 
                    , "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DialogResult = DialogResult.Yes;
                Close();
            }
        }
    }
}
