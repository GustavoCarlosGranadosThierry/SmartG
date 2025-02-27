using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Catalogos
{
    public partial class AgregarEditarBrokers : Form
    {
        int idBroker;
        string FileLicCargado;

        bool verificarBrokers()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            if (idBroker != 0)
            {
                int status = (from y in db.StatusFacturacions where y.Status == "Solicitado" select y.ID).SingleOrDefault();
                BrokersSolicitud revisarSol = (from x in db.BrokersSolicitud where x.Broker == idBroker && x.Status == status select x).SingleOrDefault();
                if (revisarSol != null)
                    return false;
            }

            if (txtBroker.Text == "" || txtBrokerCode.Text == "" || txtRFC.Text == "" || txtDireccion.Text == "" || txtEmail.Text == "" || txtLicenciaPath.Text == ""
                || txtBancoPago.Text == "" || txtCuentaBancaria.Text == "" || cbMoneda.Text == "")
            {
                MessageBox.Show("Datos Incompletos");
                return false;
            }

            if(txtClabe.Text + txtAbba.Text + txtSwift.Text == "")
            {
                MessageBox.Show("Ingrese al menos una referencia de pago bancario (clabe, abba, swift");
                return false;
            }


            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email no valido");
                return false;
            }
            if (Convert.ToDateTime(dateLicencia.Value) <= DateTime.Now)
            {
                MessageBox.Show("Fecha de expiración alcanzada");
                return false;
            }

            if(idBroker == 0)
            {
                Broker brokerN = (from x in db.Brokers where x.BrokerCode.ToUpper() == txtBrokerCode.Text.ToUpper() select x).SingleOrDefault();
                if (brokerN != null)
                {
                    if (brokerN.Broker1 == txtBroker.Text)
                    {
                        MessageBox.Show("Broker Code ya esta en uso");
                        return false;
                    }
                }
            }
            return true;
        }

        public AgregarEditarBrokers(int id = 0)
        {
            idBroker = id;
            InitializeComponent();
        }

        private void AgregarEditarBrokers_Load(object sender, EventArgs e)
        {
            this.liIncMonedaTableAdapter.Fill(this.liabilityInc.LiIncMoneda);
            Extensiones.Traduccion.traducirVentana(this);
            cbTipoPersona.SelectedIndex = 0;
            cbMoneda.SelectedIndex = 0;

            if (idBroker != 0)
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                Broker brokerEditar = (from x in db.Brokers where x.ID == idBroker select x).SingleOrDefault();
                txtBrokerCode.Text = brokerEditar.BrokerCode;
                txtBroker.Text = brokerEditar.Broker1;
                txtDireccion.Text = brokerEditar.DireccionFiscal;
                txtEmail.Text = brokerEditar.Email;

                if (brokerEditar.FechaExpiracionLicencia != null)
                    dateLicencia.Value = Convert.ToDateTime(brokerEditar.FechaExpiracionLicencia);

                if (brokerEditar.RFC != null)
                {
                    if (brokerEditar.RFC.Length == 13)
                        cbTipoPersona.Text = "P. Fisica";
                    else
                        cbTipoPersona.Text = "P. Moral";
                    txtRFC.Text = brokerEditar.RFC;
                }

                cbMoneda.Value = brokerEditar.Moneda;
                txtBancoPago.Text = brokerEditar.Banco;
                txtCuentaBancaria.Text = brokerEditar.CuentaBancaria;
                txtClabe.Text = brokerEditar.Clabe;
                txtSwift.Text = brokerEditar.Swift;
                txtAbba.Text = brokerEditar.ABBA;

                if (brokerEditar.LicenciaData != null)
                {
                    string CerFileName = brokerEditar.LicenciaFile;
                    Byte[] CertficadoBytes = brokerEditar.LicenciaData.ToArray();                
                    FileStream fsCer = new FileStream(System.IO.Directory.GetCurrentDirectory() + @"\" + CerFileName, FileMode.OpenOrCreate, FileAccess.Write);
                    BinaryWriter brCer = new BinaryWriter(fsCer);
                    brCer.Write(CertficadoBytes);
                    fsCer.Dispose();
                    txtLicenciaPath.Text = System.IO.Directory.GetCurrentDirectory() + @"\" + CerFileName;
                    FileLicCargado = System.IO.Directory.GetCurrentDirectory() + @"\sdk\" + CerFileName;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (verificarBrokers())
            {
                if (txtBroker.Text != "" && txtBrokerCode.Text != "")
                {
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    Broker brokerN;
                    if (idBroker == 0)
                        brokerN = new Broker();
                    else
                        brokerN = (from x in db.Brokers where x.ID == idBroker select x).SingleOrDefault();
                    brokerN.BrokerCode = txtBrokerCode.Text;
                    brokerN.Broker1 = txtBroker.Text;
                    brokerN.RFC = txtRFC.Text;
                    brokerN.DireccionFiscal = txtDireccion.Text;
                    brokerN.LicenciaFile = Path.GetFileName(txtLicenciaPath.Text);
                    brokerN.FechaExpiracionLicencia = Convert.ToDateTime(dateLicencia.Value);
                    brokerN.Email = txtEmail.Text;
                    brokerN.Aprobado = false;
                    brokerN.Eliminado = false;

                    Stream fsC = File.Open(txtLicenciaPath.Text, FileMode.Open);
                    BinaryReader brC = new BinaryReader(fsC);
                    Byte[] bytesC = brC.ReadBytes((Int32)fsC.Length);
                    fsC.Dispose();
                    brokerN.LicenciaData = bytesC;

                    brokerN.MonedaPago = Convert.ToInt32(cbMoneda.Value);
                    brokerN.Banco = txtBancoPago.Text;
                    brokerN.CuentaBancaria = txtCuentaBancaria.Text;
                    brokerN.Clabe = txtClabe.Text;
                    brokerN.ABBA = txtAbba.Text;
                    brokerN.Swift = txtSwift.Text;


                    if (idBroker == 0)
                        db.Brokers.InsertOnSubmit(brokerN);
                    db.SubmitChanges();

                    BrokersSolicitud nuevaSolicitud = new BrokersSolicitud();
                    nuevaSolicitud.UsuarioSolicitud = Program.Globals.UserID;
                    nuevaSolicitud.FechaSolicitud = DateTime.Now;
                    nuevaSolicitud.Broker = brokerN.ID;
                    if (idBroker != 0)
                    {
                        nuevaSolicitud.BrokerName = txtBroker.Text;
                        nuevaSolicitud.BrokerCode = txtBrokerCode.Text;
                    }
                    nuevaSolicitud.Status = (from y in db.StatusFacturacions where y.Status == "Solicitado" select y.ID).SingleOrDefault();
                    db.BrokersSolicitud.InsertOnSubmit(nuevaSolicitud);
                    db.SubmitChanges();
                    MessageBox.Show("Registro añadido", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    MainBrokers.idBroker = brokerN.ID;

                    if (File.Exists(FileLicCargado)) File.Delete(FileLicCargado);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbTipoPersona_ValueChanged(object sender, EventArgs e)
        {
            if (cbTipoPersona.Text == "P. Moral")
            {
                txtRFC.Text = "";
                txtRFC.InputMask = ">&&&######AAA";
            }
            else
            {
                txtRFC.Text = "";
                txtRFC.InputMask = ">&&&&######AAA";
            }
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnBuscarLicencia_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtLicenciaPath.Text =  openFileDialog1.FileName;
            }
        }

        private void ultraLabel3_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if(txtLicenciaPath.Text != "")
            {
                Process.Start(txtLicenciaPath.Text);
            }
        }
    }
}
