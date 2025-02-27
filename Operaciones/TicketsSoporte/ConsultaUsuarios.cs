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
    public partial class ConsultaUsuarios : Form
    {
        int IDTicketSel = 0;
        Datasets.Catalogos.catalogosGralTableAdapters.TicketSoporteHistorialTableAdapter taHistorial = new Datasets.Catalogos.catalogosGralTableAdapters.TicketSoporteHistorialTableAdapter();

        public ConsultaUsuarios()
        {
            InitializeComponent();
        }

        private void ConsultaUsuarios_Load(object sender, EventArgs e)
        {
            this.ticketSoporteTableAdapter.FillByUsuario(this.catalogosGral.TicketSoporte, Program.Globals.UserName);
            SetFormSize(0);
        }

        void SetFormSize(int val)
        {
            grpEdicion.Visible = false;
            grpHistorial.Visible = false;
            switch (val)
            {
                case 0:
                    this.Size = new Size(1170, 317);
                    break;
                case 1:
                    this.Size = new Size(1170, 578);
                    grpEdicion.Visible = true;
                    break;
                case 2:
                    this.Size = new Size(1170, 578);
                    grpHistorial.Visible = true;
                    break;

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtTituloError.Text = "";
            cbTipoError.Text = "";
            cbModulo.Text = "";
            txtDescripcionError.Text = "";

            SetFormSize(0);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se aplicaran los cambios a este registro, continuar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                TicketSoporte ticketSave = (from x in db.TicketSoportes where x.ID == IDTicketSel select x).SingleOrDefault();
                ticketSave.tipoError = cbTipoError.Text;
                ticketSave.ModuloAfectado = cbModulo.Text;
                ticketSave.TituloError = txtTituloError.Text;
                ticketSave.DescripcionUsuarioError = txtDescripcionError.Text;
                db.SubmitChanges();
                MessageBox.Show("Guardado");
                btnCancelar_Click(null, null);
            }
        }

        private void dgTickets_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if(e.Cell.Column.Key == "Editar")
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                SetFormSize(1);
                IDTicketSel = Convert.ToInt32(dgTickets.ActiveRow.Cells["ID"].Value);
                TicketSoporte ticketSoporteEditar = (from x in db.TicketSoportes where x.ID == IDTicketSel select x).SingleOrDefault();
                txtTituloError.Text = ticketSoporteEditar.TituloError;
                cbTipoError.Text = ticketSoporteEditar.tipoError;
                cbModulo.Text = ticketSoporteEditar.ModuloAfectado;
                txtDescripcionError.Text = ticketSoporteEditar.DescripcionUsuarioError;
            }
            if (e.Cell.Column.Key == "Historial")
            {
                SetFormSize(2);
                this.ticketSoporteHistorialTableAdapter.FillByTicket(this.catalogosGral.TicketSoporteHistorial, Convert.ToInt32(dgTickets.ActiveRow.Cells["ID"].Value));
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgTickets_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            e.Row.Cells["Status"].Value = taHistorial.ScalarQuery_GetStatus(Convert.ToInt32(e.Row.Cells["ID"].Value));
        }

        private void dgTickets_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

        }

        private void btnCerrarHistorial_Click(object sender, EventArgs e)
        {
            btnCancelar_Click(null, null);
        }
    }
}
