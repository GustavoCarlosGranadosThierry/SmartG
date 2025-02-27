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
    public partial class EditarFNOL : Form
    {
        int IDClaim;
        int IDPoliza;

        public static int IDUbicacion;
        public static int IDPolizaBusqueda;

        public EditarFNOL(int idClaim)
        {
            InitializeComponent();
            IDClaim = idClaim;
        }

        void CargarDataSets()
        {
            try { this.busquedaPolizaTableAdapter.Fill(this.liabilityInc.BusquedPolizas); } catch { }
            this.liIncMonedaTableAdapter.Fill(this.liabilityInc.LiIncMoneda);
            this.claimsCatalogoUbicaciones163TableAdapter.Fill(this.claims.ClaimsCatalogoUbicaciones163);
            this.ramosSegurosTableAdapter.Fill(this.facturacion.RamosSeguros);
        }

        private void EditarFNOL_Load(object sender, EventArgs e)
        {
            CargarDataSets();
            if (IDClaim != 0)
                RecuperarDatos();
        }

        void RecuperarDatos()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            SmartG.FNOL FNOLrecupera = (from x in db.FNOLs where x.ID == IDClaim select x).SingleOrDefault();
            lbNumSiniestro.Text = FNOLrecupera.ClaimNum;
            cbPoliza.Value = FNOLrecupera.Poliza;
            txtPersonaContacto.Text = FNOLrecupera.NombreContacto;
            txtTelContacto.Text = FNOLrecupera.TelefonoContacto;
            txtEmailContacto.Text = FNOLrecupera.EmailContacto;
            txtMontoReclamado.Value = FNOLrecupera.MontoReclamado;
            cbMonedaMontoReclamado.Value = FNOLrecupera.Moneda;
            cbUbicacion.Value = FNOLrecupera.Ubicacion;
            txtCausaSiniestro.Text = FNOLrecupera.CausaSiniestro;
            txtComentarios.Text = FNOLrecupera.ComentariosUsuario;
            cbRamoSeguro.Value = FNOLrecupera.RamoSeguro;
            cbPoliza.Enabled = false;
            Text = "Editar Siniestro";
        }

        private void cbParametro_ValueChanged(object sender, EventArgs e)
        {
            IDPoliza = Convert.ToInt32(cbPoliza.Value);
            dbSmartGDataContext db = new dbSmartGDataContext();
            txtAsegurado.Text = (from x in db.PolizaCliente
                                 where x.Poliza == IDPoliza && x.Principal == true
                                 orderby x.Endoso descending
                                 select (x.Cliente1.RazonSocial + " " + x.Cliente1.Nombre + " " + x.Cliente1.ApellidoPaterno + " " + x.Cliente1.ApellidoMaterno)).FirstOrDefault();
            txtDirAsegurado.Text = (from x in db.ClientesDirecciones
                                    where x.ID == Convert.ToInt32((from y in db.PolizaCliente
                                                                   where y.Poliza == IDPoliza && y.Principal == true
                                                                   orderby y.Endoso descending
                                                                   select y.Direccion).FirstOrDefault())
                                    select (x.Calle + ", " + x.NumExterior + ", " + x.NumInterior + ", " + x.Colonia + ", "
                                    + x.CP + ", " + x.Municipio + ", " + x.Estado + ", " + x.Pai.Nombre)).SingleOrDefault();
            txtLimiteMax.Text = Convert.ToDecimal((from x in db.Poliza where x.ID == IDPoliza select x.LimiteMaximo).SingleOrDefault()).ToString("C2");
            dateIniVig.Value = Convert.ToDateTime((from x in db.Poliza where x.ID == IDPoliza select x.IniVig).SingleOrDefault());
            dateFinVig.Value = Convert.ToDateTime((from x in db.Poliza where x.ID == IDPoliza select x.FinVig).SingleOrDefault());

            txtPrimaTotal.Text = (from x in db.InfoSchedule where x.Poliza == IDPoliza orderby x.ID descending select x.Prima).FirstOrDefault().ToString();
            lbMonedaPol1.Text = (from x in db.Poliza where x.ID == IDPoliza select x.Moneda1.Abreviacion).SingleOrDefault();
            lbMonedaPol2.Text = lbMonedaPol1.Text;

            cbRamoSeguro.Value = (from x in db.RamosLineaNegocios where x.LineaNegocio == Convert.ToInt32((from y in db.Poliza where y.ID == IDPoliza select y.LineaNegocios).SingleOrDefault()) select x.RamoSeguro).SingleOrDefault() ;

            // Saldo Pagado
            //decimal TotalFactura = Convert.ToDecimal((from x in db.Facturacions where x.Poliza_str == cbPoliza.Text select x).ToArray().Sum(x => x.Total));
            //decimal tipoCambioFactura = Convert.ToDecimal((from x in db.Facturacions where x.Poliza_str == cbPoliza.Text select x.TipoCambio).FirstOrDefault());

            //int IDstatusAplicado = (from x in db.StatusFacturacions where x.Status == "Aplicado" select x.ID).SingleOrDefault();
            //string MonedaAplicar = (from x in db.Monedas where x.ID == MonedaFactura select x.Abreviacion).SingleOrDefault();

            //decimal MontoInsoluto = Convert.ToDecimal((from x in db.JournalDivisions
            //                                           where x.RecibosPago.Facturacion == IDfactura &&
            //                  x.ComprobantesPago.Status == IDstatusAplicado
            //                                           select x).ToArray().Sum(x => x.Monto_division));

            //decimal PendienteCobro = TotalFactura - MontoInsoluto;
            //decimal PendienteDespuesAplicacion = PendienteCobro - reciboPago;

            dateUltimoPago.Value = (from x in db.JournalDivisions where x.RecibosPago.Facturacion1.Poliza_str == cbPoliza.Text orderby x.ID descending select x.Journal.Value_Date).FirstOrDefault();

            // carga las coberturas
            this.polizaCoberturaTableAdapter.Fill(this.claims.PolizaCobertura, IDPoliza);

            if (IDClaim != 0)
            {
                FNOLPolizaCobertura[] fNOLPoliza = (from x in db.FNOLPolizaCoberturas where x.FNOL == IDClaim select x).ToArray();
                for (int i = 0; i < fNOLPoliza.Count(); i++)
                {
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgCoberturas.Rows)
                    {
                        if (item.Cells["Cobertura"].Value.ToString() == fNOLPoliza[i].PolizaCobertura1.Coberturas.Cobertura)
                            item.Cells["Check"].Value = true;
                    }
                }
            }
        }

        private void bntBuscar_Click(object sender, EventArgs e)
        {
            IDPolizaBusqueda = 0;
            BuscarPoliza frmPoliza = new BuscarPoliza();
            if (frmPoliza.ShowDialog() == DialogResult.Yes)
                cbPoliza.Value = IDPolizaBusqueda;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Valida Informacion
            if (cbPoliza.Text == "") { MessageBox.Show("No se ha identificado una poliza a afectar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtPersonaContacto.Text == "") { MessageBox.Show("No se ha ingresado una persona de Contacto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtTelContacto.Text == "") { MessageBox.Show("No se ha ingresado un telefono de Contacto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtEmailContacto.Text == "") { MessageBox.Show("No se ha ingresado un email de Contacto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (cbUbicacion.Text == "") { MessageBox.Show("No se ha ingresado una ubicación del Siniestro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (cbMonedaMontoReclamado.Text == "") { MessageBox.Show("No se ha ingresado una moneda del Siniestro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (cbRamoSeguro.Text == "") { MessageBox.Show("No se ha ingresado un ramo de seguropara el Siniestro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            bool Nuevo = true;
            if (IDClaim != 0) Nuevo = false;

            dbSmartGDataContext db = new dbSmartGDataContext();
            SmartG.FNOL nuevoFNOL = null;
            if (IDClaim == 0)
            {
                int ConteoRepetidos = (from x in db.FNOLs where x.Poliza == Convert.ToInt32(cbPoliza.Value) && x.StatusClaim.Status != "Cerrado"  select x).ToArray().Count();
                if(ConteoRepetidos > 0)
                    if(MessageBox.Show("Ya se tiene un FNOL registrado para esta poliza, desea agregar uno más?","Mensaje FNOL en curso",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
                        return;

                nuevoFNOL = new SmartG.FNOL();
                nuevoFNOL.FechaLevantamiento = DateTime.Now;
                nuevoFNOL.Status = (from x in db.StatusClaims where x.Status == "Nuevo" select x.ID).SingleOrDefault();
            }
            else
                nuevoFNOL = (from x in db.FNOLs where x.ID == IDClaim select x).SingleOrDefault();

            nuevoFNOL.Poliza = Convert.ToInt32(cbPoliza.Value);
            nuevoFNOL.CausaSiniestro = txtCausaSiniestro.Text;
            nuevoFNOL.NombreContacto = txtPersonaContacto.Text;
            nuevoFNOL.TelefonoContacto = txtTelContacto.Text;
            nuevoFNOL.EmailContacto = txtEmailContacto.Text;
            nuevoFNOL.MontoReclamado = Convert.ToDecimal(txtMontoReclamado.Value);
            nuevoFNOL.Moneda = Convert.ToInt32(cbMonedaMontoReclamado.Value);
            nuevoFNOL.Ubicacion = Convert.ToInt32(cbUbicacion.Value);
            nuevoFNOL.UsuarioLevantamiento = Program.Globals.UserID;
            nuevoFNOL.ComentariosUsuario = txtComentarios.Text;
            nuevoFNOL.RamoSeguro = Convert.ToInt32(cbRamoSeguro.Value);

            if (IDClaim == 0)
            {
                db.FNOLs.InsertOnSubmit(nuevoFNOL);
                db.SubmitChanges();

                string ClaimNum = "CLN" + nuevoFNOL.ID.ToString().PadLeft(6,'0');
                lbNumSiniestro.Text = ClaimNum;
                nuevoFNOL.ClaimNum = ClaimNum;
                db.SubmitChanges();
                IDClaim = nuevoFNOL.ID;
            }
            else
                db.SubmitChanges();

            // Guardar Coberturas Afectadas
            FNOLPolizaCobertura[] fnolCobBorrar = (from x in db.FNOLPolizaCoberturas where x.FNOL == IDClaim select x).ToArray();
            if (fnolCobBorrar.Count() > 0)
            {
                try
                {
                    db.FNOLPolizaCoberturas.DeleteAllOnSubmit(fnolCobBorrar);
                    db.SubmitChanges();
                }
                catch
                {
                    db = new dbSmartGDataContext();
                }
            }
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgCoberturas.Rows)
            {
                if(Convert.ToBoolean(item.Cells["Check"].Value))
                {
                    // revisa si ya esta agregaba previamente
                    bool agregado = false;
                    for (int i = 0; i < fnolCobBorrar.Count(); i++)
                    {
                        if (fnolCobBorrar[i].PolizaCobertura == Convert.ToInt32(item.Cells["ID"].Value))
                            agregado = true;
                    }
                    if (!agregado)
                    {
                        FNOLPolizaCobertura nuevoFNOLCob = new FNOLPolizaCobertura();
                        nuevoFNOLCob.FNOL = IDClaim;
                        nuevoFNOLCob.PolizaCobertura = Convert.ToInt32(item.Cells["ID"].Value);
                        db.FNOLPolizaCoberturas.InsertOnSubmit(nuevoFNOLCob);
                        db.SubmitChanges();
                    }
                }
            }

            if (Nuevo)
            {
                FNOLHistorial historialReserva = new FNOLHistorial();
                historialReserva.FNOL = IDClaim;
                historialReserva.Tipo = (from x in db.TipoHistorialClaims where x.TipoActividad == "Cobertura - FNOL" select x.ID).SingleOrDefault();
                historialReserva.Descripcion = "Nuevo FNOL registrado";
                historialReserva.Notas = "Nuevo FNOL registrado";
                historialReserva.Usuario = Program.Globals.UserID;
                historialReserva.FechaCreacion = DateTime.Now;
                db.FNOLHistorials.InsertOnSubmit(historialReserva);
                db.SubmitChanges();

                MessageBox.Show("Nuevo FNOL ingresado, numero de seguimiento: " + lbNumSiniestro.Text, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (MessageBox.Show("Enviar Email de confirmación a la persona de Contacto y broker asignado de la cuenta?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    EnviarEmail();
            }
            else
            {
                FNOLHistorial historialReserva = new FNOLHistorial();
                historialReserva.FNOL = IDClaim;
                historialReserva.Tipo = (from x in db.TipoHistorialClaims where x.TipoActividad == "Cobertura - FNOL" select x.ID).SingleOrDefault();
                historialReserva.Descripcion = "Edicion del FNOL";
                historialReserva.Notas = "Modificación del FNOL inicial";
                historialReserva.Usuario = Program.Globals.UserID;
                historialReserva.FechaCreacion = DateTime.Now;
                db.FNOLHistorials.InsertOnSubmit(historialReserva);
                db.SubmitChanges();

                MessageBox.Show("Registro FNOL: " + lbNumSiniestro.Text + " actualizado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            DialogResult = DialogResult.Yes;
            Close();
        }

        void EnviarEmail()
        {
            Outlook.Application outlookApp = new Outlook.Application();
            Outlook.MailItem mailItem = outlookApp.CreateItem(OlItemType.olMailItem) as Outlook.MailItem;

            string CoberturasAfectadas = "";

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgCoberturas.Rows)
            {
                if (Convert.ToBoolean(item.Cells["Check"].Value))
                {
                    CoberturasAfectadas += item.Cells["Cobertura"].Text + Environment.NewLine;
                }
            }

            string textoBody =
                "<p>Estimado cliente, le informamos que hemos recibido el aviso de perdida con los siguientes datos:</p><p> </p>" +
                "<p><strong>Numero de Siniestro:    </strong>" + lbNumSiniestro.Text + "</p>" +
                "<p><strong>Poliza afectada:    </strong>" + cbPoliza.Text + "</p>" +
                "<p><strong>Coberturas Afectadas:    </strong>" + CoberturasAfectadas + "</p>" +
                "<p><strong>Persona de Contacto:    </strong>" + txtPersonaContacto.Text + "</p>" +
                "<p><strong>Telefono de Contacto:    </strong>" + txtTelContacto.Text + "</p>" +
                "<p><strong>Email Contacto:</strong>:    " + txtEmailContacto.Text + "</p>" +
                "<p><strong>Descripción previa del siniestro:    </strong>" + txtCausaSiniestro.Text + "</p>" +
                "<p> </p><p>Si alguno de los datos antes mencionados son incorrectos o si usted no levanto esta solicitud favor de comunicarse con el área de soporte a Siniestros al telefono: XXXX</p>";

            mailItem.Subject = "Reporte de nuevo siniestro reportado: " + lbNumSiniestro.Text + ", " + cbPoliza.Text ; 
            mailItem.To = txtEmailContacto.Text;
            //mailItem.CC = emailCC;
            mailItem.HTMLBody = textoBody;
            mailItem.Display();

        }

        private void btnBuscarUbicacion_Click(object sender, EventArgs e)
        {
            IDUbicacion = 0;
            BuscarUbicaciones frmUbicaciones = new BuscarUbicaciones();
            if (frmUbicaciones.ShowDialog() == DialogResult.Yes)
                cbUbicacion.Value = IDUbicacion;
        }
    }
}
