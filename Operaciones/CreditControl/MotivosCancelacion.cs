using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SmartG.Operaciones.CreditControl
{
    public partial class MotivosCancelacion : Form
    {

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // coleccion objetos
        #region objetos

        //lbMotivoCancela Ingrese un motivo de Cancelación para su Solicitud:
        //lbFactura N/A

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region variables

        string facturaCancela;
        int idFactura;

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region eventos

        public MotivosCancelacion(string Factura = "", int idFactu = 0)
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
            facturaCancela = Factura;
            idFactura = idFactu;
        }

        private void btnConsultarTipoCambio_Click(object sender, EventArgs e)
        {
            if (txtMotivos.Text != "")
            {
                if (MessageBox.Show("Se solicitará la cancelación de la factura: " + facturaCancela + ", continuar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    SolicitudCancelacione newSolicitud = new SolicitudCancelacione();
                    newSolicitud.Usuario = Program.Globals.UserID;
                    newSolicitud.FechaSolicitud = DateTime.Now;
                    newSolicitud.Factura = idFactura;
                    newSolicitud.Status = (from x in db.StatusFacturacions where x.Status == "Solicitado" select x.ID).SingleOrDefault();
                    newSolicitud.ObservacionesUsuario = txtMotivos.Text;
                    db.SolicitudCancelaciones.InsertOnSubmit(newSolicitud);
                    db.SubmitChanges();          

                    // FIX Extensiones.AgregarLog("Solicitudes Cancelacion", "Insert", 0, "Ingreso de una nueva solicitud de Cancelacion para revisión, factura: id " + idFactura);
                    MessageBox.Show("Registro satisfactorio", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un motivo de cancelacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void MotivosCancelacion_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
