using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Catalogos
{
    public partial class EditarEmpresa : Form
    {

        void CargarDatosIniciales()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            EmpresaDetalles EmpActual = (from x in db.EmpresaDetalles where x.Principal == true select x).FirstOrDefault();

            txtNombre.Text = EmpActual.Nombre;
            txtRfc.Text = EmpActual.RFC;
            txtCalle.Text = EmpActual.Calle;
            txtNumExt.Text = EmpActual.NumExt;
            txtNumInt.Text = EmpActual.NumInt;
            txtCP.Text = EmpActual.CP;
            cbColonia.Text = EmpActual.Colonia;
            txtLocalidad.Text = EmpActual.Localidad;
            txtMunicipio.Text = EmpActual.Municipio;
            txtEstado.Text = EmpActual.Estado;
            cbPais.Value = EmpActual.Pais;
            txtRegFiscal.Text = EmpActual.RegimenDescripcion;
            txtCodRegFiscal.Text = EmpActual.RegimenCodigo;

            // carga logo
            picLogo.Image = DocumentosDB.ByteArrayToImage(EmpActual.Logo.ToArray());
            if (File.Exists(@"C:\SmartG\logo.bmp"))
                File.Delete(@"C:\SmartG\logo.bmp");

            using (var bitmap = new Bitmap(picLogo.Width, picLogo.Height))
            {
                picLogo.DrawToBitmap(bitmap, picLogo.ClientRectangle);
                bitmap.Save(@"C:\SmartG\logo.bmp", ImageFormat.Bmp);
            }
            txtLogoPath.Text = @"C:\SmartG\logo.bmp";

            // Carga Firma
            picFirma.Image = DocumentosDB.ByteArrayToImage(EmpActual.FirmaCEO.ToArray());
            if (File.Exists(@"C:\SmartG\firma.bmp"))
                File.Delete(@"C:\SmartG\firma.bmp");

            using (var bitmap = new Bitmap(picFirma.Width, picFirma.Height))
            {
                picFirma.DrawToBitmap(bitmap, picFirma.ClientRectangle);
                bitmap.Save(@"C:\SmartG\firma.bmp", ImageFormat.Bmp);
            }
            txtFirmaPath.Text = @"C:\SmartG\firma.bmp";
        }

        void GuardarCambios()
        {
            // Verifica datos

            if (txtNombre.Text == "" || txtRfc.Text == "" || txtCalle.Text == "" || txtNumExt.Text == "" || txtNumInt.Text == "" || 
                txtCP.Text == "" || cbColonia.Text == "" || txtLocalidad.Text == "" || txtMunicipio.Text == "" || txtEstado.Text == "" || 
                txtRegFiscal.Text == "" || txtCodRegFiscal.Text == "" )
            { MessageBox.Show("Ingrese todos los datos para actualizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (MessageBox.Show("Se sobreescribiran los datos de la empresa actual: " + txtNombre.Text + ".  Continuar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Quita los default
                dbSmartGDataContext db = new dbSmartGDataContext();
                EmpresaDetalles[] TodosRegistros = (from x in db.EmpresaDetalles where x.ID > 0 select x).ToArray();

                for (int i = 0; i < TodosRegistros.Count(); i++)
                {
                    TodosRegistros[i].Principal = false;
                }
                db.SubmitChanges();
                db.Dispose();
                db = new dbSmartGDataContext();

                EmpresaDetalles NuevoReg = new EmpresaDetalles();
                NuevoReg.Nombre = txtNombre.Text;
                NuevoReg.RFC = txtRfc.Text;
                NuevoReg.Calle = txtCalle.Text;
                NuevoReg.NumExt = txtNumExt.Text;
                NuevoReg.NumInt = txtNumInt.Text;
                NuevoReg.CP = txtCP.Text;
                NuevoReg.Colonia = cbColonia.Text;
                NuevoReg.Localidad = txtLocalidad.Text;
                NuevoReg.Municipio = txtMunicipio.Text;
                NuevoReg.Estado = txtEstado.Text;
                NuevoReg.Pais = Convert.ToInt32(cbPais.Value);
                NuevoReg.RegimenDescripcion = txtRegFiscal.Text;
                NuevoReg.RegimenCodigo = txtCodRegFiscal.Text;
                NuevoReg.Principal = true;
                NuevoReg.Logo = DocumentosDB.ImageToByteArray(new FileInfo(txtLogoPath.Text));
                NuevoReg.FirmaCEO = DocumentosDB.ImageToByteArray(new FileInfo(txtFirmaPath.Text));
                db.EmpresaDetalles.InsertOnSubmit(NuevoReg);
                db.SubmitChanges();

                if (File.Exists(@"C:\SmartG\logo.bmp"))
                    File.Delete(@"C:\SmartG\logo.bmp");
                if (File.Exists(@"C:\SmartG\firma.bmp"))
                    File.Delete(@"C:\SmartG\firma.bmp");

                MessageBox.Show("Datos de la empresa actualizados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
        }

        public EditarEmpresa()
        {
            InitializeComponent();
        }

        private void ToolsBarCompliance_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btnGuardarCambios":
                    GuardarCambios();
                    break;

                case "btnSalir":
                    this.Close();
                    break;
            }
        }

        private void EditarEmpresa_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this, tabEmpresaDetalle, ToolsBarEditarEmpresa);
            this.paisTableAdapter.Fill(this.catalogosGral.Pais);
            CargarDatosIniciales();
        }

        private void btnBuscarLogo_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo fs = new FileInfo(openFileDialog1.FileName);
                long filesize = fs.Length / 1024;
                if(filesize > 1024)
                {
                    MessageBox.Show("La imagen a ingresar no debe de sobrepasar los 256kb, reintente con otra imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtLogoPath.Text = openFileDialog1.FileName;
                picLogo.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void txtCP_Leave(object sender, EventArgs e)
        {
            if (txtCP.TextLength == 5)
                BusquedaCP();
        }
        private void BusquedaCP()
        {
            //Bloquea el proceso si el cliente es extranjero
            string cp = txtCP.Text;
            string request = "https://api-codigos-postales.herokuapp.com/v2/codigo_postal/" + cp;
            try
            {
                //Limpia todo
                txtMunicipio.Text = "";
                txtEstado.Text = "";
                cbColonia.Items.Clear();

                //Obtiene la respuesta del API y corrigue el texto
                WebClient client2 = new WebClient();
                //string response = client2.DownloadString(request).ToString();
                string response = new Extensiones.ConsultaBanxico.TimedWebClient { Timeout = 3000 }.DownloadString(request);

                byte[] bytes = Encoding.GetEncoding(1252).GetBytes(response);
                var strFixed = Encoding.UTF8.GetString(bytes);

                // Separa municipio y estado

                string[] strarray = strFixed.Split(',');
                char[] trimchar = { '"', ']', '}' };

                //Municipio
                string municipio = strarray[1].Substring(12).Trim(trimchar);
                txtMunicipio.Text = municipio;

                //Estado
                string estado = strarray[2].Substring(9).Trim(trimchar);
                txtEstado.Text = estado;

                // Rellena los combobox

                string[] strarray_col = strFixed.Split('[');
                string colonias = strarray_col[1].Replace("\"", "").TrimEnd(trimchar);
                string[] lista_colonias = colonias.Split(',');

                Infragistics.Win.ValueList vl = new Infragistics.Win.ValueList();
                int contador = 0;
                for (int i = 0; i < lista_colonias.Length; i++)
                {
                    vl.ValueListItems.Add(contador, lista_colonias[i]);
                    contador++;
                }
                cbColonia.ValueList = vl;

                if (cbColonia.Items.Count > 0)
                {
                    cbColonia.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error due to: " + ex.Message);
            }
        }

        private void btnBuscarFirma_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo fs = new FileInfo(openFileDialog1.FileName);
                long filesize = fs.Length / 1024;
                if (filesize > 1024)
                {
                    MessageBox.Show("La imagen a ingresar no debe de sobrepasar los 256kb, reintente con otra imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtFirmaPath.Text = openFileDialog1.FileName;
                picFirma.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
    }
}
