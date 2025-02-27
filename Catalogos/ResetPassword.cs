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
    public partial class ResetPassword : Form
    {
        public ResetPassword()
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            if( txtPass.Text != txtRepePass.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden, favor de rectificar", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (!Encripcion.ValidatePassword(txtPass.Text))
                return;
            else
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                Usuario EditUser = (from x in db.Usuarios where x.ID == Program.Globals.UserID select x).SingleOrDefault();
                Encripcion objEncrypt = new Encripcion();
                EditUser.Password = objEncrypt.Encrypt(txtPass.Text);
                db.SubmitChanges();
                MessageBox.Show("Password actualizado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DialogResult = DialogResult.Yes;
                Close();
            }
        }


        private void txtRepePass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnCambiar_Click(null, null);
        }

        private void ResetPassword_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this);
        }
    }
}
