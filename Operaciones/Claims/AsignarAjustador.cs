using Infragistics.Win.UltraWinListView;
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


namespace SmartG.Operaciones.Claims
{
    public partial class AsignarAjustador : Form
    {
        int IDClaim;
        int IDRamoClaim;
        int IDEmpresa;
        int IDAjustador;

        public AsignarAjustador(int idclaim)
        {
            InitializeComponent();
            IDClaim = idclaim;
        }

        private void AsignarAjustador_Load(object sender, EventArgs e)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            IDRamoClaim = Convert.ToInt32((from x in db.FNOLs where x.ID == IDClaim select x.RamoSeguro).SingleOrDefault());
            this.ajustadorEmpresasTableAdapter.FillByRamo(this.claims.AjustadorEmpresas, IDRamoClaim);
        }

        private void cbEmpresa_ValueChanged(object sender, EventArgs e)
        {
            IDEmpresa = Convert.ToInt32(cbEmpresa.Value);
            this.ajustadoresTableAdapter.FillByOrganizacionRamo(this.claims.Ajustadores, IDRamoClaim, IDEmpresa);
            cbAjustador.Text = "";
            lvAjustador.Items.Clear();
            lvHonorariosLimites.Items.Clear();
            lvHonorariosViaticos.Items.Clear();
        }

        private void cbAjustador_ValueChanged(object sender, EventArgs e)
        {
            if (cbAjustador.Text == "") return;
            dbSmartGDataContext db = new dbSmartGDataContext();
            IDAjustador = Convert.ToInt32(cbAjustador.Value);
            lvAjustador.Items.Clear();
            lvHonorariosLimites.Items.Clear();
            lvHonorariosViaticos.Items.Clear();

            Ajustadore AjustadorDetalle = (from x in db.Ajustadores where x.ID == IDAjustador select x).SingleOrDefault();
            int ClaimsActivos = (from x in db.FNOLs where x.Ajustador == IDAjustador && x.Status == (from y in db.StatusClaims where y.Status == "En Proceso" select y.ID).SingleOrDefault() select x).ToArray().Count();
            int ClaimsHistoricos = (from x in db.FNOLs where x.Ajustador == IDAjustador select x).ToArray().Count();

            UltraListViewItem it1 = new UltraListViewItem("Dirección", new object[] { AjustadorDetalle.Direccion }); lvAjustador.Items.Add(it1);
            UltraListViewItem it2 = new UltraListViewItem("Teléfono", new object[] { AjustadorDetalle.Telefono }); lvAjustador.Items.Add(it2);
            UltraListViewItem it3 = new UltraListViewItem("Email", new object[] { AjustadorDetalle.Email }); lvAjustador.Items.Add(it3);
            UltraListViewItem it4 = new UltraListViewItem("Observaciones", new object[] { AjustadorDetalle.Observaciones }); lvAjustador.Items.Add(it4);
            UltraListViewItem it5 = new UltraListViewItem("Clasificación", new object[] { AjustadorDetalle.ClasificacionAjustadore.Clasificacion }); lvAjustador.Items.Add(it5);
            UltraListViewItem it6 = new UltraListViewItem("Claims Asignados", new object[] { ClaimsActivos }); lvAjustador.Items.Add(it6);
            UltraListViewItem it7 = new UltraListViewItem("Historico Claims", new object[] { ClaimsHistoricos }); lvAjustador.Items.Add(it7);

            int IDHonorario = Convert.ToInt32((from x in db.AjustadorEmpresaHonorariosRamos where 
                                               x.EmpresaAjuste == IDEmpresa && x.Ramo == IDRamoClaim orderby x.ID descending select x.Honorario).FirstOrDefault());

            HonorarioLimite[] honorarioLimite = (from x in db.HonorarioLimites where x.Honorario == IDHonorario select x).ToArray();
            for (int i = 0; i < honorarioLimite.Count(); i++)
            {
                UltraListViewItem itH = new UltraListViewItem(honorarioLimite[i].De, new object[] { honorarioLimite[i].Hasta, honorarioLimite[i].Monto }); lvHonorariosLimites.Items.Add(itH);
            }

            HonorariosViatico[] honorarioViatico = (from x in db.HonorariosViaticos where x.Honorario == IDHonorario select x).ToArray();
            for (int i = 0; i < honorarioViatico.Count(); i++)
            {
                UltraListViewItem itV = new UltraListViewItem(honorarioViatico[i].Viatico1.Viatico1, new object[] { honorarioViatico[i].Descripcion }); lvHonorariosViaticos.Items.Add(itV);
            }
        }

        private void bntBuscar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se aplicará el Ajustador a este Siniestro, continuar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                SmartG.FNOL fnolCambio = (from x in db.FNOLs where x.ID == IDClaim select x).SingleOrDefault();
                fnolCambio.Ajustador = IDAjustador;
                fnolCambio.FechaAsignacionAjustador = DateTime.Now;
                fnolCambio.UsuarioAsignacionAjustador = Program.Globals.UserID;
                fnolCambio.Status = (from x in db.StatusClaims where x.Status == "En Proceso" select x.ID).SingleOrDefault();
                db.SubmitChanges();
                MessageBox.Show("Ajustador Asignado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if(MessageBox.Show("Enviar Email con la información al Ajustador?","Mensaje",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    EnviarEmail();
                DialogResult = DialogResult.Yes;
                Close();
            }
        }

        void EnviarEmail()
        {
            Outlook.Application outlookApp = new Outlook.Application();
            Outlook.MailItem mailItem = outlookApp.CreateItem(OlItemType.olMailItem) as Outlook.MailItem;

            string textoBody =
                "<p>Estimado cliente, le informamos que hemos recibido el aviso de perdida con los siguientes datos:</p><p> </p>" +
                "<p><strong>Numero de Siniestro:    </strong>" + "tbd"+ "</p>" +
                "<p><strong>Poliza afectada:    </strong>" + "tbd" + "</p>" +
                "<p><strong>Coberturas Afectadas:    </strong>" + "tbd" + "</p>" +
                "<p><strong>Persona de Contacto:    </strong>" + "tbd" + "</p>" +
                "<p><strong>Telefono de Contacto:    </strong>" + "tbd" + "</p>" +
                "<p><strong>Email Contacto:</strong>:    " + "tbd" + "</p>" +
                "<p><strong>Descripción previa del siniestro:    </strong>" + "tbd" + "</p>" +
                "<p> </p><p>Si alguno de los datos antes mencionados son incorrectos o si usted no levanto esta solicitud favor de comunicarse con el área de soporte a Siniestros al telefono: XXXX</p>";

            mailItem.Subject = "Reporte de nuevo siniestro para ajuste: " + "tbd" + ", " + "tbd";
            mailItem.To = ""; //txtEmailContacto.Text;
            //mailItem.CC = emailCC;
            mailItem.HTMLBody = textoBody;
            mailItem.Display();
        }
    }
}
