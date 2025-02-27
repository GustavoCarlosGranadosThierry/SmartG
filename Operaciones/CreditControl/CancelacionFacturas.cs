using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SmartG.Operaciones.CreditControl
{
    public partial class CancelacionFacturas : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // coleccion objetos
        #region objetos

        //Facturacion - CancelacionFacturas  - Control lbMotivo    Motivos registrados:
        //Facturacion - CancelacionFacturas  - Control lbObservacionesCC   Observaciones Credit C.
        //Facturacion - CancelacionFacturas  - Control btnCancelacion  Rechazar la Solicitud de Cancelacion

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region variables

        string facturaCancela;
        int idFactura;
        int idSolicitud = 0;
        Form MainFrm;

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region metodos

        public CancelacionFacturas(Form mainform, string Factura = "", int idFactu = 0 )
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
            facturaCancela = Factura;
            idFactura = idFactu;
            MainFrm = mainform;
        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region eventos

        private void CancelacionFacturas_Load(object sender, EventArgs e)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            btnCancelacion.Enabled = false;

            int StatusSolicitado = (from x in db.StatusFacturacions where x.Status == "Solicitado" select x.ID).SingleOrDefault();
            if ((from x in db.SolicitudCancelaciones where x.Factura == idFactura && x.Status == StatusSolicitado select x).FirstOrDefault() != null)
            {
                txtMotivos.Text = (from x in db.SolicitudCancelaciones where x.Factura == idFactura && x.Status == StatusSolicitado select x.ObservacionesUsuario).SingleOrDefault();
                idSolicitud = (from x in db.SolicitudCancelaciones where x.Factura == idFactura && x.Status == StatusSolicitado select x.ID).SingleOrDefault();
                btnCancelacion.Enabled = true;
            }
            Extensiones.Traduccion.traducirVentana(this);
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            if (txtObservacionesCC.Text != "")
            {
                if (MessageBox.Show("¿Desea cancelar la factura " + facturaCancela + " ?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    dbSmartGDataContext db = new dbSmartGDataContext();

                    if (idSolicitud != 0)
                    {
                        SolicitudCancelacione editarSolicitud = (from x in db.SolicitudCancelaciones where x.ID == idSolicitud select x).SingleOrDefault();
                        editarSolicitud.FechaAtencion = DateTime.Now;
                        editarSolicitud.ObservacionesCC = txtObservacionesCC.Text;
                        editarSolicitud.UsuarioCC = Program.Globals.UserID;
                        editarSolicitud.Status = (from x in db.StatusFacturacions where x.Status == "En Proceso" select x.ID).SingleOrDefault();
                        db.SubmitChanges();
                    }
                    else
                    {
                        SolicitudCancelacione nuevaSolicitud = new SolicitudCancelacione();
                        nuevaSolicitud.FechaSolicitud = DateTime.Now;
                        nuevaSolicitud.FechaAtencion = DateTime.Now;
                        nuevaSolicitud.ObservacionesCC = txtObservacionesCC.Text;
                        nuevaSolicitud.UsuarioCC = Program.Globals.UserID;
                        nuevaSolicitud.Usuario = Program.Globals.UserID;
                        nuevaSolicitud.Factura = idFactura;
                        nuevaSolicitud.Status = (from x in db.StatusFacturacions where x.Status == "En Proceso" select x.ID).SingleOrDefault();
                        db.SolicitudCancelaciones.InsertOnSubmit(nuevaSolicitud);
                        db.SubmitChanges();
                    }

                    int FolioFactura = Convert.ToInt32((from x in db.Facturacions where x.ID == idFactura select x.Folio).SingleOrDefault());
                    string SerieFactura = (from x in db.Facturacions where x.ID == idFactura select x.Serie).SingleOrDefault();

                    // Selecciona si la factura fue timbrada por Buzone o Finkok
                    int PrimerFolioTimbradoFinkok = 0;
                    PrimerFolioTimbradoFinkok = Extensiones.TimbradoWSfinkok.PrimerFolioFinkok(SerieFactura);

                    if (FolioFactura >= PrimerFolioTimbradoFinkok)
                        Extensiones.TimbradoWSfinkok.TimbrarCancelacion(idFactura, 1, MainFrm);
                    else
                        Extensiones.TimbradoWSfinkok.TimbrarCancelacionExterna(idFactura, 1, MainFrm);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Debe introducir información de cancelación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelacion_Click(object sender, EventArgs e)
        {
            if (txtObservacionesCC.Text != "")
            {
                if (MessageBox.Show("¿Desea rechazar la solicitud de cancelación?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    SolicitudCancelacione editarSolicitud = (from x in db.SolicitudCancelaciones where x.ID == idSolicitud select x).SingleOrDefault();
                    editarSolicitud.FechaAtencion = DateTime.Now;
                    editarSolicitud.ObservacionesCC = txtObservacionesCC.Text;
                    editarSolicitud.Status = (from x in db.StatusFacturacions where x.Status == "Rechazado" select x.ID).SingleOrDefault();
                    editarSolicitud.UsuarioCC = Program.Globals.UserID;
                    db.SubmitChanges();

                    // FIX Extensiones.AgregarLog("Solicitud Cancelaciones", "Update", idSolicitud, "Solicitud de Cancelacion de factura rechazada, " + txtObservacionesCC.Text);
                    MessageBox.Show("Rechazo completado", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Debe introducir información de cancelación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }

        }

        #endregion

    }
}
