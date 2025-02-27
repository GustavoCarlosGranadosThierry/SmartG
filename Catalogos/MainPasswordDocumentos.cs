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
    public partial class MainPasswordDocumentos : Form
    {
        int idAnterior = 0;
        public MainPasswordDocumentos()
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
        }

        private void MainPasswordDocumentos_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this);
            dbSmartGDataContext db = new dbSmartGDataContext();
            PasswordDocumentos anterior = (from x in db.PasswordDocumentos where x.Activo == true select x).SingleOrDefault();
            if (anterior != null)
            {
                idAnterior = anterior.ID;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtPass1.Text == txtPass2.Text && txtPass1.Text != "" && txtPass2.Text != "")
            {
                if (MessageBox.Show("¿Deseas actualizar la contraseña para los documentos que emite el sistema?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Encripcion nuevoEncripta = new Encripcion();
                    string tmpPass = nuevoEncripta.Encrypt(txtPass1.Text);

                    dbSmartGDataContext db = new dbSmartGDataContext();
                    PasswordDocumentos nuevoPass = new PasswordDocumentos();
                    nuevoPass.Password = tmpPass;
                    nuevoPass.FechaCambio = DateTime.Now;
                    nuevoPass.Activo = true;
                    nuevoPass.Usuario = Program.Globals.UserID;
                    db.PasswordDocumentos.InsertOnSubmit(nuevoPass);

                    PasswordDocumentos anterior = (from x in db.PasswordDocumentos where x.ID == idAnterior select x).SingleOrDefault();
                    if (anterior != null)
                    {
                        anterior.Activo = false;
                    }

                    db.SubmitChanges();
                    MessageBox.Show("Contraseña cambiada con éxito, esta ventana se cerrará", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();

                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
