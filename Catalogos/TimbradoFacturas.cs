using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Catalogos
{
    public partial class TimbradoFacturas : Form
    {
        string FileCerCargado;
        string FileKeyCargado;

        void CargarDatosIniciales()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            txtRFC.Text = (from x in db.EmpresaDetalles where x.Principal == true select x.RFC).FirstOrDefault();

            TimbradoSDK timbrado = (from x in db.TimbradoSDKs where x.Activo == true select x).FirstOrDefault();
            if (timbrado != null)
            {
                txtUsuarioPAC.Text = timbrado.PACusuario;
                txtPassPAC.Text = timbrado.PACpassword;

                string CerFileName = timbrado.FileCertificadoName;
                Byte[] CertficadoBytes = timbrado.FileCertificadoData.ToArray();
                FileStream fsCer = new FileStream(System.IO.Directory.GetCurrentDirectory() + @"\sdk\" + CerFileName, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryWriter brCer = new BinaryWriter(fsCer);
                brCer.Write(CertficadoBytes);
                fsCer.Dispose();
                txtCertificado.Text = System.IO.Directory.GetCurrentDirectory() + @"\sdk\" + CerFileName;
                FileCerCargado = System.IO.Directory.GetCurrentDirectory() + @"\sdk\" + CerFileName;

                string KeyFileName = timbrado.FileKeyName;
                Byte[] KeyBytes = timbrado.FileKeyData.ToArray();
                FileStream fsKey = new FileStream(System.IO.Directory.GetCurrentDirectory() + @"\sdk\" + KeyFileName, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryWriter brKey = new BinaryWriter(fsKey);
                brKey.Write(KeyBytes);
                fsKey.Dispose();
                txtLlave.Text = System.IO.Directory.GetCurrentDirectory() + @"\sdk\" + KeyFileName;
                FileKeyCargado = System.IO.Directory.GetCurrentDirectory() + @"\sdk\" + KeyFileName;
                txtPassLlave.Text = timbrado.SATpassword;
            }

        }

        void GuardarCambios()
        {
            if(txtCertificado.Text == "" ||
                txtLlave.Text == "" ||
                txtPassLlave.Text == "" ||
                txtPassPAC.Text == "" ||
                txtRFC.Text == "" ||
                txtUsuarioPAC.Text == "" )
            {
                MessageBox.Show("Datos incorrectos o faltantes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dbSmartGDataContext db = new dbSmartGDataContext();
            TimbradoSDK[] alltimbrado = (from x in db.TimbradoSDKs select x).ToArray();
            for (int i = 0; i < alltimbrado.Count(); i++)
            {
                alltimbrado[i].Activo = false;
            }
            db.SubmitChanges();

            TimbradoSDK nuevoActivo = new TimbradoSDK();
            nuevoActivo.PACusuario = txtUsuarioPAC.Text;
            nuevoActivo.PACpassword = txtPassPAC.Text;

            Stream fsC = File.Open(txtCertificado.Text, FileMode.Open);
            BinaryReader brC = new BinaryReader(fsC);
            Byte[] bytesC = brC.ReadBytes((Int32)fsC.Length);
            fsC.Dispose();
            nuevoActivo.FileCertificadoData = bytesC;
            nuevoActivo.FileCertificadoName = Path.GetFileName(txtCertificado.Text);

            Stream fsK = File.Open(txtLlave.Text, FileMode.Open);
            BinaryReader brK = new BinaryReader(fsK);
            Byte[] bytesK = brK.ReadBytes((Int32)fsK.Length);
            fsK.Dispose();
            nuevoActivo.FileKeyData = bytesK;
            nuevoActivo.FileKeyName = Path.GetFileName(txtLlave.Text);

            nuevoActivo.SATpassword = txtPassLlave.Text;
            nuevoActivo.Activo = true;
            nuevoActivo.FechaActivacion = DateTime.Now;

            db.TimbradoSDKs.InsertOnSubmit(nuevoActivo);
            db.SubmitChanges();

            if (File.Exists(FileCerCargado)) File.Delete(FileCerCargado);
            if (File.Exists(FileKeyCargado)) File.Delete(FileKeyCargado);

            MessageBox.Show("Configuración del timbrado actualizados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }

        public TimbradoFacturas()
        {
            InitializeComponent();
        }

        private void btnCertificado_Click(object sender, EventArgs e)
        {
            if(openFileDialogCertificado.ShowDialog() == DialogResult.OK)
            {
                txtCertificado.Text = openFileDialogCertificado.FileName;
            }
        }

        private void btnBuscarLlave_Click(object sender, EventArgs e)
        {
            if (openFileDialogLlave.ShowDialog() == DialogResult.OK)
            {
                txtLlave.Text = openFileDialogLlave.FileName;
            }
        }

        private void TimbradoFacturas_Load(object sender, EventArgs e)
        {
            CargarDatosIniciales();
        }

        private void ToolsBarEditarTimbrado_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btnGuardar Cambios":
                    GuardarCambios();
                    break;

                case "btnSalir":
                    Close();
                    break;
            }
        }

        private void TimbradoFacturas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(FileCerCargado)) File.Delete(FileCerCargado);
            if (File.Exists(FileKeyCargado)) File.Delete(FileKeyCargado);
        }
    }
}
