using Infragistics.Win;
using Infragistics.Win.UltraWinListView;
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
    public partial class UsuariosPerfil : Form
    {

        public static int returnIdUsuarioCopiado;

        public UsuariosPerfil()
        {
            InitializeComponent();
        }

        void CargarDataSets()
        {
            this.usuariosTableAdapter.Fill(this.catalogosGral.Usuarios);
        }
        void GuardarCambios()
        {

            if (Convert.ToInt32(cbUsuarios.Value) == 0)
            {
                MessageBox.Show("No se ha seleccionado ningun usuario a editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                bool hayCheckeados = false;
                foreach (UltraListViewItem item in lvPermisos.Items)
                {
                    if (item.CheckState == CheckState.Checked)
                    {
                        hayCheckeados = true;
                        break;
                    }
                }
                if (!hayCheckeados)
                {
                    MessageBox.Show("No se asignaron ningun permiso al usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Se guardaran los cambios de perfil/acceso realizados para el usuario: " + cbUsuarios.Text + ", desea continuar?",
                            "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int IDusuario = Convert.ToInt32(cbUsuarios.Value);
                        dbSmartGDataContext db = new dbSmartGDataContext();
                        SmartG.UsuariosPerfil[] borrarPerfiles = (from x in db.UsuariosPerfils where x.Usuario == IDusuario select x).ToArray();
                        if (borrarPerfiles.Count() > 0)
                        {
                            db.UsuariosPerfils.DeleteAllOnSubmit(borrarPerfiles);
                            db.SubmitChanges();
                        }

                        foreach (UltraListViewItem item in lvPermisos.Items)
                        {
                            if (item.CheckState == CheckState.Checked)
                            {
                                SmartG.UsuariosPerfil NuevoAcceso = new SmartG.UsuariosPerfil
                                {
                                    Usuario = IDusuario,
                                    Perfil = Convert.ToInt32(item.SubItems["ID"].Value)
                                };
                                db.UsuariosPerfils.InsertOnSubmit(NuevoAcceso);
                                db.SubmitChanges();
                            }
                        }
                        MessageBox.Show("Perfil de usuario actualizado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
        }

        void CopiarPerfil()
        {
            int idUsuarioReceptor = Convert.ToInt32(cbUsuarios.Value);
            UsuariosPerfilCopiar frmCopiar = new UsuariosPerfilCopiar(idUsuarioReceptor);
            if (frmCopiar.ShowDialog() == DialogResult.Yes)
            {
                CargarDataSets();
                cbUsuarios.Value = returnIdUsuarioCopiado;
            }
        }

        void SeleccionarTodo()
        {
            try
            {
                CheckState sele = CheckState.Checked;
                if (lvPermisos.Items[0].CheckState == CheckState.Checked) sele = CheckState.Unchecked;
                foreach (UltraListViewItem item in lvPermisos.Items)
                {
                    item.CheckState = sele;
                }

            }
            catch { }
        }

        private void UsuariosPerfil_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this, tabUsuariosPerfil, ToolbarsUsuariosPerfil);
            CargarDataSets();
        }

        private void ToolbarsUsuariosPerfil_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Actualizar":
                    CargarDataSets();
                    break;

                case "btnAplicarCambios":
                    GuardarCambios();
                    break;

                case "btnCopiarPerfil":
                    CopiarPerfil();
                    break;                    

                case "btnDescartarSalir":
                    this.Close();
                    break;

                case "btnSeleccionartodo":
                    SeleccionarTodo();
                    break;
            }
        }

        private void CbUsuarios_ValueChanged(object sender, EventArgs e)
        {
            lvPermisos.Items.Clear();
            int IDusuario = Convert.ToInt32(cbUsuarios.Value);

            dbSmartGDataContext db = new dbSmartGDataContext();
            Perfile[] perfilesAcceso = (from x in db.Perfiles select x).ToArray();

            for (int i = 0; i < perfilesAcceso.Count(); i++)
            {
                UltraListViewItem it1 = new UltraListViewItem(perfilesAcceso[i].Descripcion, new object[] { perfilesAcceso[i].KeyName, perfilesAcceso[i].ID });
                if ((from x in db.UsuariosPerfils where x.Usuario == IDusuario && x.Perfil == perfilesAcceso[i].ID select x).ToArray().Count() > 0)
                    it1.CheckState = CheckState.Checked;
                lvPermisos.Items.Add(it1);
            }
            lvPermisos.Items.RefreshSort(true);
        }
    }
}
