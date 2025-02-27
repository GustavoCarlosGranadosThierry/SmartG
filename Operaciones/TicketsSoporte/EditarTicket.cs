using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Operaciones.TicketsSoporte
{
    public partial class EditarTicket : Form
    {
        int IDTicket;

        public EditarTicket(int IDticket)
        {
            InitializeComponent();
            IDTicket = IDticket;
        }

        private void EditarTicket_Load(object sender, EventArgs e)
        {
            this.ticketSoporteStatusTableAdapter.Fill(this.catalogosGral.TicketSoporteStatus);
            this.usuariosTableAdapter.Fill(this.catalogosGral.Usuarios);

            dbSmartGDataContext db = new dbSmartGDataContext();
            TicketSoporte ticketRecuperado = (from x in db.TicketSoportes where x.ID == IDTicket select x).SingleOrDefault();
            txtNumTicket.Text = ticketRecuperado.Ticket;
            txtTituloError.Text = ticketRecuperado.TituloError;
            txtUsuarioSol.Text = ticketRecuperado.usuario;
            cbTipoError.Text = ticketRecuperado.tipoError;
            dateLevantamiento.Value = Convert.ToDateTime(ticketRecuperado.fechaReporte);
            cbModulo.Text = ticketRecuperado.ModuloAfectado;
            txtDescripcionError.Text = ticketRecuperado.DescripcionUsuarioError;
            txtDescripcionInterna.Text = ticketRecuperado.DescripcionInternaError;

            cbUsuarioTecnico.Value = Program.Globals.UserID;
            dateFechaAplicacion.Value = DateTime.Now;
            cbStatus.Value = (from x in db.TicketSoporteHistorials where x.Ticket == IDTicket orderby x.ID descending select x.TicketSoporteStatus.Status).FirstOrDefault();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Validacion
            if(txtNumTicket.Text == "" ||
                txtTituloError.Text == "" ||
                txtUsuarioSol.Text == "" ||
                cbTipoError.Text == "" ||
                cbModulo.Text == "" ||
                txtDescripcionError.Text == "" ||
                txtDescripcionInterna.Text == "" ||
                txtComentarioAtencion.Text == "")
            {
                MessageBox.Show("Valores incompletos");
                return;
            }

            if (MessageBox.Show("Se aplicaran los cambios a este registro, continuar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                //Guarda los valores del ticket
                TicketSoporte ticketSave = (from x in db.TicketSoportes where x.ID == IDTicket select x).SingleOrDefault();
                ticketSave.tipoError = cbTipoError.Text;
                ticketSave.ModuloAfectado = cbModulo.Text;
                ticketSave.TituloError = txtTituloError.Text;
                ticketSave.DescripcionUsuarioError = txtDescripcionError.Text;
                ticketSave.DescripcionInternaError = txtDescripcionInterna.Text;
                db.SubmitChanges();

                //Guarda los valores del historico
                TicketSoporteHistorial ticketHistorial = new TicketSoporteHistorial();
                ticketHistorial.Ticket = IDTicket;
                ticketHistorial.usuario = Convert.ToInt32(cbUsuarioTecnico.Value);
                ticketHistorial.Status = Convert.ToInt32(cbStatus.Value);
                ticketHistorial.Observaciones = txtComentarioAtencion.Text;
                ticketHistorial.Fecha = Convert.ToDateTime(dateFechaAplicacion.Value);
                db.TicketSoporteHistorials.InsertOnSubmit(ticketHistorial);
                db.SubmitChanges();

                DialogResult = DialogResult.Yes;
                Close();
            }
        }
    }
}
