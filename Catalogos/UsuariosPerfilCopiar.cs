using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Catalogos
{
    public partial class UsuariosPerfilCopiar : Form
    {
        int idDestino;

        public UsuariosPerfilCopiar(int idUsuarioReceptor)
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
            idDestino = idUsuarioReceptor;
        }

        private void UsuariosPerfilCopiar_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this);
            this.usuariosTableAdapter.Fill(this.catalogosGral.Usuarios);
            if (idDestino != 0)
                cbUsuarioDestino.Value = idDestino;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void BtnApliacr_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(cbUsuarioRemitente.Value) == 0 || Convert.ToInt32(cbUsuarioDestino.Value) == 0)
            {
                MessageBox.Show("Usuarios no validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt32(cbUsuarioRemitente.Value) == Convert.ToInt32(cbUsuarioDestino.Value))
            {
                MessageBox.Show("Usuarios no validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(MessageBox.Show("Se copiaran todos los permisos actuales, continuar?","Mensaje",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int idUsuarioRemitente = Convert.ToInt32(cbUsuarioRemitente.Value);
                int idUsuarioDestino = Convert.ToInt32(cbUsuarioDestino.Value);

                // Borra los permisos del usuario destino
                dbSmartGDataContext db = new dbSmartGDataContext();
                SmartG.UsuariosPerfil[] perfilborrar = (from x in db.UsuariosPerfils where x.Usuario == idUsuarioDestino select x).ToArray();
                if(perfilborrar.Count() > 0)
                {
                    db.UsuariosPerfils.DeleteAllOnSubmit(perfilborrar);
                    db.SubmitChanges();
                }

                // Copia el perfil nuevo
                SmartG.UsuariosPerfil[] perfilCopiar = (from x in db.UsuariosPerfils where x.Usuario == idUsuarioRemitente select x).ToArray();
                for (int i = 0; i < perfilCopiar.Count(); i++)
                {
                    SmartG.UsuariosPerfil nuevoPerfilDestino = new SmartG.UsuariosPerfil
                    {
                        Usuario = idUsuarioDestino,
                        Perfil = perfilCopiar[i].Perfil
                    };
                    db.UsuariosPerfils.InsertOnSubmit(nuevoPerfilDestino);
                    db.SubmitChanges();
                }

                MessageBox.Show("Perfil Copiado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DialogResult = DialogResult.Yes;
                UsuariosPerfil.returnIdUsuarioCopiado = idUsuarioDestino;
                this.Close();
            }
        }
    }    

}
