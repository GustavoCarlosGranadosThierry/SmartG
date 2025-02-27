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
    public partial class Usuarios : Form
    {
        void CargarDatasets()
        {
            this.usuariosTableAdapter.Fill(this.catalogosGral.Usuarios);
        }

        void AgregarUsuarioNuevo()
        {
            UsuariosEditar_ frmEditarUsuario = new UsuariosEditar_(0);
            if (frmEditarUsuario.ShowDialog() == DialogResult.Yes)
                CargarDatasets();
        }

        void EditarUsuario()
        {
            int Iduser = Convert.ToInt32(dgUsuarios.ActiveRow.Cells["ID"].Value);
            UsuariosEditar_ frmEditarUsuario = new UsuariosEditar_(Iduser);
            if (frmEditarUsuario.ShowDialog() == DialogResult.Yes)
                CargarDatasets();
        }

        void EliminarUsuario()
        {
            string UserName = dgUsuarios.ActiveRow.Cells["UserName"].Value.ToString();
            string NombreUsuario = dgUsuarios.ActiveRow.Cells["Nombre"].Value.ToString() + " " + dgUsuarios.ActiveRow.Cells["ApellidoPaterno"].Value.ToString() + " " + dgUsuarios.ActiveRow.Cells["ApellidoMaterno"].Value.ToString();
            if (MessageBox.Show("Desea eliminar al usuario: " + UserName + ", " + NombreUsuario + "?", "Mensaje", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int idUserBorrar = Convert.ToInt32(dgUsuarios.ActiveRow.Cells["ID"].Value);
                dbSmartGDataContext db = new dbSmartGDataContext();
                Usuario ElimUser = (from x in db.Usuarios where x.ID == idUserBorrar select x).SingleOrDefault();
                ElimUser.Eliminado = true;
                db.SubmitChanges();
                MessageBox.Show("Usuario: " + UserName + " eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                CargarDatasets();
            }
        }

        void ResetPassword()
        {
            string UserName = dgUsuarios.ActiveRow.Cells["UserName"].Value.ToString();
            string NombreUsuario = dgUsuarios.ActiveRow.Cells["Nombre"].Value.ToString() + " " + dgUsuarios.ActiveRow.Cells["ApellidoPaterno"].Value.ToString() + " " + dgUsuarios.ActiveRow.Cells["ApellidoMaterno"].Value.ToString();
            if (MessageBox.Show("Se resetará el password del usuario: " + UserName + ", " + NombreUsuario + " a los valores default. Continuar?", "Mensaje",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int idUserReset = Convert.ToInt32(dgUsuarios.ActiveRow.Cells["ID"].Value);
                Encripcion objEncrypt = new Encripcion();
                dbSmartGDataContext db = new dbSmartGDataContext();
                Usuario ResetUser = (from x in db.Usuarios where x.ID == idUserReset select x).SingleOrDefault();
                ResetUser.Password = objEncrypt.Encrypt("W3lc0me");
                // FIX agregar un metodo de envio de email con contraseña aleatoria;
                db.SubmitChanges();
                MessageBox.Show("El password del usuario: " + UserName + " ha sido resetado. Utilizar el password de acceso único: " + "W3lc0me", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                CargarDatasets();
            }
        }

        public Usuarios()
        {
            InitializeComponent();
        }
        private void Usuarios_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this, tabUsuarios, ToolbarsUsuarios);
            CargarDatasets();
            cbParametro.SelectedIndex = 0;
        }

        private void ToolbarsUsuarios_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btnAgregarNuevoUsuario":
                    AgregarUsuarioNuevo();
                    break;

                case "btnModificarUsuario":
                    EditarUsuario();
                    break;

                case "btnActualizar":
                    CargarDatasets();
                    break;

                case "btnResetPassword":
                    ResetPassword();
                    break;

                case "btnEliminarUsuario":
                    EliminarUsuario();
                    break;
            }
        }

        private void dgUsuarios_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            EditarUsuario();
        }
    }
}
