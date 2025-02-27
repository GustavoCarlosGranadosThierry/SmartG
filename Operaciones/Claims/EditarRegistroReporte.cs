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
    public partial class EditarRegistroReporte : Form
    {
        int IDreporte;

        void cargarDataSets()
        {
            this.claimsCatalogoTipoBien13TableAdapter.Fill(this.claims.ClaimsCatalogoTipoBien13);
            this.claimsCatalogoCoberturas1711TableAdapter.Fill(this.claims.ClaimsCatalogoCoberturas1711);
            this.claimsCatalogoUbicaciones163TableAdapter.Fill(this.claims.ClaimsCatalogoUbicaciones163);
            this.statusClaimsTableAdapter.Fill(this.claims.StatusClaims);
        }

        void RecuperarDatos()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            ClaimsReporteGC RegistroClaimRecuperado = (from x in db.ClaimsReporteGCs where x.ID == IDreporte select x).SingleOrDefault();
            lbNumClaimRecuperado.Text = RegistroClaimRecuperado.ClaimNumber;
            lbNumPolizaRecuperado.Text = RegistroClaimRecuperado.PolicyNumber;
            cbStatus.Value = RegistroClaimRecuperado.Status;
            cbUbicacion.Value = RegistroClaimRecuperado.Ubicacion;
            cbTipoBien.Value = RegistroClaimRecuperado.TipoBien;
            cbCobertura.Value = RegistroClaimRecuperado.Coberura;
        }

        public EditarRegistroReporte(int IDreporteClaims)
        {
            InitializeComponent();
            IDreporte = IDreporteClaims;
        }


        private void EditarRegistroReporte_Load(object sender, EventArgs e)
        {
            cargarDataSets();
            RecuperarDatos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            int idStatus = 0;
            if (cbCobertura.Text != "" && cbTipoBien.Text != "" && cbUbicacion.Text != "")
                idStatus = (from x in db.StatusClaims where x.Status == "Completo" select x.ID).SingleOrDefault();
            else
                idStatus = (from x in db.StatusClaims where x.Status == "Incompleto" select x.ID).SingleOrDefault();

            ClaimsReporteGC reporteUpdate = (from x in db.ClaimsReporteGCs where x.ID == IDreporte select x).SingleOrDefault();
            reporteUpdate.Status = idStatus;
            reporteUpdate.Ubicacion = Convert.ToInt32( cbUbicacion.Value);
            reporteUpdate.TipoBien = Convert.ToInt32(cbTipoBien.Value);
            reporteUpdate.Coberura = Convert.ToInt32(cbCobertura.Value);
            db.SubmitChanges();
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void cbUbicacion_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
