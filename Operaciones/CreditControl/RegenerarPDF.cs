using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Operaciones.CreditControl
{
    public partial class RegenerarPDF : Form
    {
        bool ProcesoFactura;

        int IDFactura;
        int IDcliente;
        int IDComprobante;

        int Folio;
        string Serie;

        public RegenerarPDF(int idDocumento, bool isFactura)
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
            ProcesoFactura = isFactura;
            if (isFactura)
                IDFactura = idDocumento;
            else
                IDComprobante = idDocumento;
        }

        private void RegenerarPDF_Load(object sender, EventArgs e)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            if(ProcesoFactura)
            {
                IDcliente = Convert.ToInt32((from x in db.Facturacions where x.ID == IDFactura select x.Cliente).SingleOrDefault());
                this.clientesDireccionesTableAdapter.FillByCliente(this.facturacion.ClientesDirecciones, IDcliente);
                this.brokersTableAdapter.Fill(this.facturacion.Brokers);
                cbBroker.Value = (from x in db.FacturaParticipantes where x.Factura == IDFactura select x.Broker).FirstOrDefault();
                try { cbDireccion.Value = (from x in db.Facturacions where x.ID == IDFactura select x.ClienteDireccion).SingleOrDefault(); } catch { }

                Folio = Convert.ToInt32((from x in db.Facturacions where x.ID == IDFactura select x.Folio).SingleOrDefault());
                Serie = (from x in db.Facturacions where x.ID == IDFactura select x.Serie).SingleOrDefault().ToString();
                lbIdentificacionFactura.Text = Serie + Folio;
            }
            else
            {
                JournalDivision journalDivision = (from x in db.JournalDivisions where x.ComprobantePagoID == IDComprobante orderby x.ID descending select x).FirstOrDefault();
                IDFactura = journalDivision.RecibosPago.Facturacion1.ID;
                IDcliente = (from x in db.Facturacions where x.ID == journalDivision.RecibosPago.Facturacion1.ID select x.Cliente1.ID).SingleOrDefault();
                this.clientesDireccionesTableAdapter.FillByCliente(this.facturacion.ClientesDirecciones, IDcliente);
                this.brokersTableAdapter.Fill(this.facturacion.Brokers);
                cbBroker.Value = (from x in db.FacturaParticipantes where x.Factura == IDFactura select x.Broker).FirstOrDefault();
                try { cbDireccion.Value = (from x in db.Facturacions where x.ID == IDFactura select x.ClienteDireccion).SingleOrDefault(); } catch { }

                Folio = Convert.ToInt32((from x in db.ComprobantesPagos where x.ID == IDComprobante select x.Folio).SingleOrDefault());
                Serie = "PP";
                lbIdentificacionFactura.Text = Serie + Folio;
            }

            // Revisa que el PDF pueda ser regenerado
            bool isRegenerable = false;
            if (Folio >= Extensiones.TimbradoWSfinkok.PrimerFolioFinkok(Serie)) isRegenerable = true;
            if(!isRegenerable)
            {
                MessageBox.Show("Este documento fue timbrado con un proveedor anterior y la estructura del XML no permite la regeneración de PDF", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void ProcesoRegenerarPDF(int IDdocumento, bool isFactura)
        {
            // Obtiene el xml
            string CarpeteTemp = Environment.CurrentDirectory +  @"\sdk\";
            string TemporalZip = CarpeteTemp + "temp.zip";
            string TemporalXml;
            string TemporalPdf;
            string Serie = "";
            string Folio = "";

            Directory.CreateDirectory(Path.GetDirectoryName(CarpeteTemp));

            dbSmartGDataContext db = new dbSmartGDataContext();

            if(isFactura)
            {
                SmartG.Facturacion updateFactura = (from x in db.Facturacions where x.ID == IDdocumento select x).SingleOrDefault();
                TemporalPdf = Directory.GetCurrentDirectory() + @"\sdk\" + updateFactura.Serie + updateFactura.Folio + "_" + updateFactura.Cliente1.RFC + "_" + updateFactura.Poliza_str + "_PDF.pdf";
                Serie = updateFactura.Serie;
                Folio = updateFactura.Folio.ToString();
            }
            else
            {
                ComprobantesPago updateComprobante = (from x in db.ComprobantesPagos where x.ID == IDdocumento select x).SingleOrDefault();
                TemporalPdf = Directory.GetCurrentDirectory() + @"\sdk\PP" + updateComprobante.Folio + "_PDF.pdf";
                Serie = "PP";
                Folio = updateComprobante.Folio.ToString();

            }
            Byte[] bytData = null;
            string constring = Properties.Settings.Default.DocumentosSmartGConnectionString;
            SqlCommand command;
            if (isFactura)
                command = new SqlCommand(@"SELECT Data FROM DocumentosFacturacion WHERE Factura='" + IDdocumento.ToString() + "' AND NombreDocumento LIKE '%xml%'");
            else
            {
                command = new SqlCommand(@"SELECT Data FROM DocumentosFacturacion WHERE Folio='" + Folio + "' AND Serie = 'PP' AND NombreDocumento LIKE '%xml%'");
            }

            command.CommandType = CommandType.Text;
            SqlConnection myconn = new SqlConnection(constring);
            command.Connection = myconn;
            myconn.Open();
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                bytData = (byte[])dr["Data"];
            }
            if (bytData != null)
            {
                FileStream fs1 = new FileStream(TemporalZip, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryWriter br1 = new BinaryWriter(fs1);
                br1.Write(bytData);
                fs1.Dispose();
            }
            else
            {
                MessageBox.Show("No se encontro el archivo XML en la base de datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try // Fix en caso de que el Xml no este comprimido en un zip y sea directamente un xml (en nuevo sistema de facturacion)
            {
                System.IO.Compression.ZipFile.ExtractToDirectory(TemporalZip, CarpeteTemp);
                DirectoryInfo dinfo = new DirectoryInfo(CarpeteTemp);
                FileInfo[] Files = dinfo.GetFiles("*.xml");
                TemporalXml = CarpeteTemp + Files[0].Name;
            }
            catch
            {
                File.Move(TemporalZip, CarpeteTemp + "temp.xml");
                TemporalXml = CarpeteTemp + "temp.xml";
            }

            // Obtiene el Logo
            EmpresaDetalles EmpActual = (from x in db.EmpresaDetalles where x.Principal == true select x).FirstOrDefault();
            Image LogoCompañia = DocumentosDB.ByteArrayToImage(EmpActual.Logo.ToArray());

            // Genera el PDF nuevo y zip
            if(isFactura)
            {
                Extensiones.CreaPDF crearPDF = new Extensiones.CreaPDF(IDdocumento, TemporalXml, TemporalPdf, LogoCompañia, false);
            }
            else
            {
                JournalDivision journalDivision = (from x in db.JournalDivisions where x.ComprobantePagoID == IDdocumento orderby x.ID descending select x).FirstOrDefault();
                Extensiones.CreaPDF crearPDF = new Extensiones.CreaPDF(journalDivision.RecibosPago.Facturacion1.ID, TemporalXml, TemporalPdf, LogoCompañia, false);
            }

            File.Delete(TemporalZip);
            File.Delete(TemporalXml);

            // Actualiza el pdf en la base
            BaseDatos.DocumentsDBDataContext documentsDBDataContext = new BaseDatos.DocumentsDBDataContext();
            BaseDatos.DocumentosFacturacion nuevoComp = (from x in documentsDBDataContext.DocumentosFacturacions where x.Factura == IDdocumento && x.Serie == Serie && x.Folio == Folio && x.NombreDocumento.Contains("pdf") select x).FirstOrDefault();

            using (Stream fs = File.Open(TemporalPdf, FileMode.Open))
            {
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                nuevoComp.Data = bytes;
                documentsDBDataContext.SubmitChanges();
            }
            try
            {
                File.Move(TemporalPdf, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SmartG-Documentos\" + Path.GetFileName(TemporalPdf));
            }
            catch
            {
                MessageBox.Show("El pdf generado no pudo ser movido a tu carpeta local, pero ha sido almacenado en Base de datos, favor de descargarlo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MessageBox.Show("Documento modificado y guardado en la base de datos correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);          
            
        }

        private void btnRegenerar_Click(object sender, EventArgs e)
        {
            // guarda los nuevos valores
            if (ProcesoFactura)
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                SmartG.Facturacion facturacionEdit = (from x in db.Facturacions where x.ID == IDFactura select x).SingleOrDefault();
                facturacionEdit.ClienteDireccion = Convert.ToInt32(cbDireccion.Value);
                FacturaParticipante facturaParticipanteEdit = (from x in db.FacturaParticipantes where x.Factura == IDFactura select x).FirstOrDefault();
                facturaParticipanteEdit.Broker = Convert.ToInt32(cbBroker.Value);
                db.SubmitChanges();
                ProcesoRegenerarPDF(IDFactura, ProcesoFactura);
            }
            else
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                JournalDivision[] journalDivision = (from x in db.JournalDivisions where x.ComprobantePagoID == IDComprobante orderby x.ID descending select x).ToArray();
                SmartG.Facturacion facturacionEdit = (from x in db.Facturacions where x.ID == journalDivision[0].RecibosPago.Facturacion1.ID select x).SingleOrDefault();
                facturacionEdit.ClienteDireccion = Convert.ToInt32(cbDireccion.Value);
                FacturaParticipante facturaParticipanteEdit = (from x in db.FacturaParticipantes where x.Factura == journalDivision[0].RecibosPago.Facturacion1.ID select x).FirstOrDefault();
                facturaParticipanteEdit.Broker = Convert.ToInt32(cbBroker.Value);
                db.SubmitChanges();
                ProcesoRegenerarPDF(IDComprobante, ProcesoFactura);
            }
            this.Close();
        }
    }
}
