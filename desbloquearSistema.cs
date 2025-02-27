using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG
{
    public partial class desbloquearSistema : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region variables

        bool cerrar = false;

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region eventos

        public desbloquearSistema()
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
            this.FormClosing += DesbloquearSistema_FormClosing;
        }

        private void DesbloquearSistema_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cerrar)
            {
                e.Cancel = true;
                return;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Encripcion objEncrypt = new Encripcion();
            string password = objEncrypt.Encrypt(txtPass.Text);
            try
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                Usuario logIn = (from x in db.Usuarios where x.UserName == Program.Globals.UserName && x.Password == password select x).SingleOrDefault();
                if (logIn != null)
                {
                    cerrar = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error en el acceso al sistema, por favor verifique sus credenciales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPass.Text = "";
                    txtPass.Focus();
                }
            }
            catch
            {
                MessageBox.Show("EL sistema no puede establecer conexión con la base de datos, se cerrara el sistema", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Main.cerrarDirecto = true;
                cerrar = true;
                Application.Exit();
            }
        }

        private void desbloquearSistema_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this);
        }

        #endregion
    }
}
