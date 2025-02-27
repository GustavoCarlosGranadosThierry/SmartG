using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = NetOffice.OutlookApi;
using NetOffice.OutlookApi.Enums;


namespace SmartG.Operaciones.TicketsSoporte
{
    public partial class ConsultarTickets : Form
    {
        void CargarDatasSets()
        {
            this.ticketSoporteHistorialTableAdapter.Fill(this.catalogosGral.TicketSoporteHistorial);
            this.ticketSoporteTableAdapter.Fill(this.catalogosGral.TicketSoporte);
            dgTickets.Rows.ExpandAll(true);
            dgTickets.Rows.CollapseAll(true);

        }
        public ConsultarTickets()
        {
            InitializeComponent();
        }

        private void ConsultarTickets_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'catalogosGral.TicketSoporteStatus' table. You can move, or remove it, as needed.
            this.ticketSoporteStatusTableAdapter.Fill(this.catalogosGral.TicketSoporteStatus);
            CargarDatasSets();
            cbParametro.SelectedIndex = 0;
        }

        private void ultraGrid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            EditarTicket frmEditar = new EditarTicket(Convert.ToInt32(e.Row.Cells["ID"].Value));
            if (frmEditar.ShowDialog() == DialogResult.Yes)
                CargarDatasSets();

        }

        void EnviarEmail(int idTicket)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            Outlook.Application outlookApp = new Outlook.Application();
            Outlook.MailItem mailItem = outlookApp.CreateItem(OlItemType.olMailItem) as Outlook.MailItem;

            mailItem.Subject = "Ticket: " + (from x in db.TicketSoportes where x.ID == idTicket select x.Ticket).SingleOrDefault() + " (" + DateTime.Now.ToShortDateString()+ ")";
            string userName = (from x in db.TicketSoportes where x.ID == idTicket select x.usuario).SingleOrDefault().Split('-')[0].Replace(" ", "");
            string emailUser = (from x in db.Usuarios where x.UserName.Contains(userName) select x.Email).SingleOrDefault();
            mailItem.To = emailUser;
            mailItem.Display(false);
        }

        private void ToolsBarTicketsSoporte_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btnDuplicarSolicitud":
                    break;

                case "btnEditarSolicitud":
                    EditarTicket frmEditar = new EditarTicket(Convert.ToInt32(dgTickets.ActiveRow.Cells["ID"].Value));
                    if (frmEditar.ShowDialog() == DialogResult.Yes)
                        CargarDatasSets();
                    break;

                case "btnActualizar":
                    CargarDatasSets();
                    break;

                case "btnDescargarDocumentos":
                    DocumentosDB.ExtraerDocumentoSoporte(Convert.ToInt32(dgTickets.ActiveRow.Cells["ID"].Value));
                    break;

                case "btnContactarUsuario":
                    EnviarEmail(Convert.ToInt32(dgTickets.ActiveRow.Cells["ID"].Value));
                    break;

            }

        }

        private void dgTickets_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            if(e.Row.Band.Index == 0)
            {
                e.Row.Cells["Status"].Value = ticketSoporteHistorialTableAdapter.ScalarQuery_GetStatus(Convert.ToInt32(e.Row.Cells["ID"].Value));
                e.Row.Cells["Documentos"].Value = ticketSoporteHistorialTableAdapter.ScalarQuery_GetDocs(Convert.ToInt32(e.Row.Cells["ID"].Value));
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime p1 = Convert.ToDateTime(dateBusqueda.Value);
            DateTime p2 = Convert.ToDateTime(dateBusqueda.Value);
            TimeSpan ts = new TimeSpan(0, 0, 0);
            p1 = p1.Date + ts;
            ts = new TimeSpan(23, 59, 59);
            p2 = p2.Date + ts;
            switch (cbParametro.SelectedIndex)
            {
                case 0: //Ticket
                    this.ticketSoporteTableAdapter.FillByTicket(this.catalogosGral.TicketSoporte,txtBusqueda.Text);
                    break;
                case 1: //usuario
                    this.ticketSoporteTableAdapter.FillByUsuario(this.catalogosGral.TicketSoporte, txtBusqueda.Text);
                    break;
                case 2: //fecha
                    this.ticketSoporteTableAdapter.FillByFecha(this.catalogosGral.TicketSoporte, p1, p2);
                    break;
                case 3: //Status
                    this.ticketSoporteTableAdapter.FillByStatus(this.catalogosGral.TicketSoporte, Convert.ToInt32(cbStatus.Value));
                    break;
            }
            if (this.catalogosGral.TicketSoporte.Count == 0)
                MessageBox.Show("No hay registros", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar_Click(null, null);
        }

        private void cbParametro_ValueChanged(object sender, EventArgs e)
        {
            txtBusqueda.Visible = false;
            cbStatus.Visible = false;
            dateBusqueda.Visible = false;
            switch (cbParametro.SelectedIndex)
            {
                case 0:
                case 1:
                    txtBusqueda.Visible = true;
                    break;
                case 2:
                    dateBusqueda.Visible = true;
                    break;
                case 3:
                    cbStatus.Visible = true;
                    break;
            }
        }
    }
}
