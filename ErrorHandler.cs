using System;
using System.IO;
using System.Windows.Forms;
using Outlook = NetOffice.OutlookApi;
using NetOffice.OutlookApi.Enums;
using System.Reflection;
using System.Linq;


namespace SmartG
{
    public partial class ErrorHandler : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // coleccion objetos
        #region objetos

            //lbAgregarFiles Agregar documentos:
            //btnAgregar Añadir archivo
            //lbDescripcionInterna    Descripción interna del error:
            //btnCancelar Cancelar
            //btnEnviar Enviar Reporte
            //lbDescripcionError  Descripción del error:
            //lbTipoError Tipo de error detectado
            //lbTituloError   Titulo del error:
            //lbModulo Modulo del sistema afectado
            //lbFecha Fecha de envio:
            //lbUsuario Usuario:

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region variables

        string NumeroTicket = "No disponible";
        string DriIP;
        string VersionSmartG;

        public static string emailMain = "smartgdesk@kreios.mx";
        string emailCC = "fcastellanos@kreios.mx ; ggranados @kreios.mx";

        #endregion

      //**********************************************************************************
      //**********************************************************************************
      //**********************************************************************************
      // metodos programados utilizados en el form
        #region metodos

      void EnviarEmail()
        {
            try
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                emailMain = (from x in db.EmailDistribucions where x.ListaDistribucion == "Soporte" select x.DireccionEmailPrincipal).SingleOrDefault();
                emailCC = (from x in db.EmailDistribucions where x.ListaDistribucion == "Soporte" select x.DireccionEmailCC).SingleOrDefault();
            }
            catch { }
            Outlook.Application outlookApp = new Outlook.Application();
            Outlook.MailItem mailItem = outlookApp.CreateItem(OlItemType.olMailItem) as Outlook.MailItem;

            string textoBody =
                "<p><strong>Usuario Solicitante:</strong>" + txtUsuario.Text + "</p>" +
                "<p><strong>Fecha del Reporte:</strong>" + Convert.ToDateTime(dateFechaEnvio.Value) + "</p>" +
                "<p><strong>Tipo de Error:</strong>" + cbModulo.Text + "</p>" +
                "<p><strong>Modulo Afectado:</strong>" + lbModulo.Text + "</p>" +
                "<p><strong>Titulo Error:</strong>" + txtTituloError.Text + "</p>" +
                "<p><strong>Descripci&oacute;n Error del usuario:</strong>" + txtDescripcionError.Text + "</p>" +
                "<p><strong>Descripci&oacute;n Error Interna SmartG:</strong>" + txtDescripcionInterna.Text + "</p>" +
                "<p><strong>Versi&oacute;n SmartG:</strong>" + VersionSmartG + "</p>" +
                "<p><strong>Direcci&oacute;n IP Acceso:</strong>" + DriIP + "</p>"; ;

            mailItem.Subject = "Reporte de Error: " + NumeroTicket + " (" + dateFechaEnvio.Value + ")"; ;
            mailItem.To = emailMain;
            mailItem.CC = emailCC;
            mailItem.HTMLBody = textoBody;

            //Inserta reporte al correo
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgFiles.Rows)
            {
                mailItem.Attachments.Add(item.Cells["Archivo"].Value.ToString(), OlAttachmentType.olByValue, Type.Missing, Type.Missing);
            }
            mailItem.Send();
        }


        void GrabarenBD()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            TicketSoporte nuevoticket = new TicketSoporte();
            nuevoticket.usuario = txtUsuario.Text;
            nuevoticket.fechaReporte = Convert.ToDateTime(dateFechaEnvio.Value);
            nuevoticket.tipoError = cbTipoError.Text;
            nuevoticket.ModuloAfectado = cbModulo.Text;
            nuevoticket.TituloError = txtTituloError.Text;
            nuevoticket.DescripcionUsuarioError = DriIP + "  " + VersionSmartG + " || " + txtDescripcionError.Text;
            nuevoticket.DescripcionInternaError = txtDescripcionInterna.Text;            
            db.TicketSoportes.InsertOnSubmit(nuevoticket);
            db.SubmitChanges();

            nuevoticket.Ticket = "XL - " + nuevoticket.ID.ToString().PadLeft(6, '0');
            db.SubmitChanges();
            NumeroTicket = nuevoticket.Ticket;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgFiles.Rows)
            {
                try
                {
                    Stream fs = File.Open(item.Cells["Archivo"].Value.ToString(), FileMode.Open);
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    TicketSoporteDocumento nuevoDocumento = new TicketSoporteDocumento();
                    nuevoDocumento.ticketSoporte = nuevoticket.ID;
                    nuevoDocumento.NombreDocumento = Path.GetFileName(item.Cells["Archivo"].Value.ToString());
                    nuevoDocumento.Data = bytes;
                    db.TicketSoporteDocumentos.InsertOnSubmit(nuevoDocumento);
                    db.SubmitChanges();
                }
                catch { }
            }

            TicketSoporteHistorial ticketSoporteHistorialNuevo = new TicketSoporteHistorial();
            ticketSoporteHistorialNuevo.Ticket = nuevoticket.ID;
            ticketSoporteHistorialNuevo.Status = 1;
            ticketSoporteHistorialNuevo.Observaciones = "Nuevo Ticket Solicitado";
            ticketSoporteHistorialNuevo.Fecha = DateTime.Now;
            db.TicketSoporteHistorials.InsertOnSubmit(ticketSoporteHistorialNuevo);
            db.SubmitChanges();
        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region eventos

        public ErrorHandler(string errorMessage, string errorStack)
        {
            InitializeComponent();
            txtTituloError.Text = errorMessage;
            txtDescripcionInterna.Text = errorStack;
        }

        private void ErrorHandler_Load(object sender, EventArgs e)
        {
            try
            {
                if (Program.Globals.UserName != null)
                    txtUsuario.Text = Program.Globals.UserName + " - " + Program.Globals.NombreCompletoUsuario;
                else
                    txtUsuario.Text = Properties.Settings.Default.usuarioDefault;
            }
            catch
            {
                txtUsuario.Enabled = true;
            }
            dateFechaEnvio.Value = DateTime.Now;
            if (txtDescripcionInterna.Text != "") cbTipoError.Text = "Error interno SmartG";
            DriIP = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList[0].ToString();
            VersionSmartG = Environment.MachineName + "|| Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Extensiones.Traduccion.traducirVentana(this);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ultraDataSource1.Rows.Add(new object[] { openFileDialog1.FileName });
            }
        }

        private void dgFiles_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            dgFiles.ActiveRow.Delete();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || cbTipoError.Text == "" || txtTituloError.Text == "" || cbModulo.Text == "" || txtDescripcionError.Text == "")
            {
                MessageBox.Show("Datos incompletos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (txtDescripcionError.Text.Length <= 30)
            {
                MessageBox.Show("Favor de incluir una descripción del error mas detallada.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                bool reporteEnviado = false;
                try
                {
                    GrabarenBD();
                    reporteEnviado = true;
                }
                catch { }

                try
                {
                    EnviarEmail();
                    reporteEnviado = true;
                }
                catch { }

                if (!reporteEnviado)
                {
                    MessageBox.Show("El reporte no pudo ser enviado ni por email ni agregado a la base de datos, favor de comunicarse al telefono: "
                        + Properties.Settings.Default.TelefonoAtencion + "para atender su solicitud lo antes posible. Gracias!", "Error de envio",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Reporte enviado");
                    this.Close();
                }
            }
        }

        #endregion
    }
}
