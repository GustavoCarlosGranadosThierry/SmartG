using SmartG.Extensiones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Operaciones.Claims
{
    public partial class EditarReserva : Form
    {
        int IDClaim;
        bool Indemnizacion;

        public EditarReserva(int idclaim, bool isIndemnizacion)
        {
            InitializeComponent();
            IDClaim = idclaim;
            Indemnizacion = isIndemnizacion;
        }    

        private void EditarReserva_Load(object sender, EventArgs e)
        {
            this.liIncMonedaTableAdapter.Fill(this.liabilityInc.LiIncMoneda);
            this.tipoTransaccionReservaTableAdapter.Fill(this.claims.TipoTransaccionReserva);
            if (Indemnizacion)
                this.tipoReservaClaimsTableAdapter.FillByIndemizacionGasto(this.claims.TipoReservaClaims, "Indemnización");
            else
                this.tipoReservaClaimsTableAdapter.FillByIndemizacionGasto(this.claims.TipoReservaClaims, "Gasto");

            cbCategoria.SelectedIndex = 0;
            cbMonedaAnterior.SelectedIndex = 0;
            cbNuevaMoneda.SelectedIndex = 0;
            cbTipoReserva.SelectedIndex = 0;

            // Consulta TC
            txtTipoCambio.Value = ConsultaBanxico.ObtenerTipoCambio(DateTime.Now);
            if (Indemnizacion)
                Text = Text + "Indemnización";
            else
                Text = Text + "Gastos";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtNuevaReserva.Value) == 0 || txtNotasHistorial.Text == "")
            {
                MessageBox.Show("Datos incompletos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                FNOLHistorial historialReserva = new FNOLHistorial();
                historialReserva.FNOL = IDClaim;
                historialReserva.Tipo = (from x in db.TipoHistorialClaims where x.TipoActividad == "Financiero  - Reservas" select x.ID).SingleOrDefault();
                historialReserva.Descripcion = "Movimiento de Reserva";
                historialReserva.Cobertura = (from x in db.FNOLPolizaCoberturas where x.FNOL == IDClaim select x.ID).FirstOrDefault();
                historialReserva.Notas = txtNotasHistorial.Text;
                historialReserva.Usuario = Program.Globals.UserID;
                historialReserva.FechaCreacion = DateTime.Now;
                db.FNOLHistorials.InsertOnSubmit(historialReserva);
                db.SubmitChanges();

                ReservasClaim reservasClaim = new ReservasClaim();
                reservasClaim.FNOL = IDClaim;
                reservasClaim.TipoReserva = Convert.ToInt32(cbTipoReserva.Value);
                reservasClaim.Reserva = Convert.ToDecimal(txtNuevaReserva.Value);
                reservasClaim.Moneda = Convert.ToInt32(cbNuevaMoneda.Value);
                reservasClaim.TipoCambio = Convert.ToDecimal(txtTipoCambio.Value);
                reservasClaim.TipoTransaccion = Convert.ToInt32(cbCategoria.Value);
                reservasClaim.Historial = historialReserva.ID;
                db.ReservasClaims.InsertOnSubmit(reservasClaim);
                db.SubmitChanges();

                MessageBox.Show("Reserva agregada correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DialogResult = DialogResult.Yes;
                Close();
            }
        }
            
        private void cbTipoReserva_ValueChanged(object sender, EventArgs e)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            int TipoReserva = Convert.ToInt32(cbTipoReserva.Value);
            decimal ReservaAnterior = Convert.ToDecimal((from x in db.ReservasClaims where x.FNOL == IDClaim && x.TipoReserva == TipoReserva orderby x.ID descending select x.Reserva).FirstOrDefault());
            txtReservaAnterior.Value = ReservaAnterior;
        }

        private void btnConsultarTC_Click(object sender, EventArgs e)
        {
            txtTipoCambio.Value = ConsultaBanxico.ObtenerTipoCambio(DateTime.Now);
            if (Convert.ToDecimal(txtTipoCambio.Value) == 0)
                MessageBox.Show("No se puede conectar con el servidor de Banxico", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
