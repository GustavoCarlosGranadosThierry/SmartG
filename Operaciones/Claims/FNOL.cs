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
    public partial class FNOL : Form
    {
        int IDclaimActivo;

        public FNOL()
        {
            InitializeComponent();
        }

        void CargarDataSets()
        {
            this.fNOLTableAdapter.Fill(this.claims.FNOL);
            this.ajustadorEmpresasTableAdapter.Fill(this.claims.AjustadorEmpresas);
            this.tipoHistorialClaimsTableAdapter.Fill(this.claims.TipoHistorialClaims);
        }

        void CmabiarLayout(int tab)
        {
            cbParametroHistorial.Ribbon.Tabs[0].Groups["rgpSeguimiento"].Visible = false;
            cbParametroHistorial.Ribbon.Tabs[0].Groups["rgbFNOL"].Visible = false;
            cbParametroHistorial.Ribbon.Tabs[0].Groups["rgbAjustadores"].Visible = false;
            cbParametroHistorial.Ribbon.Tabs[0].Groups["rgpEmpresasAjuste"].Visible = false;
            cbParametroHistorial.Ribbon.Tabs[0].Groups["grpEdicionSiniestro"].Visible = false;
            cbParametroHistorial.Ribbon.Tabs[0].Groups["grpReservas"].Visible = false;            
            tabFNOL.Tabs[0].Visible = false;
            tabFNOL.Tabs[1].Visible = false;
            tabFNOL.Tabs[2].Visible = false;
            tabFNOL.Tabs[3].Visible = false;
            tabFNOL.Tabs[4].Visible = false;
            tabFNOL.Tabs[5].Visible = false;

            switch (tab)
            {
                case 0: // Abiertos
                    cbParametroHistorial.Ribbon.Tabs[0].Groups["rgpSeguimiento"].Visible = true;
                    cbParametroHistorial.Ribbon.Tabs[0].Groups["rgbFNOL"].Visible = true;
                    cbParametroHistorial.Ribbon.Tabs[0].Groups["rgbAjustadores"].Visible = true;
                    tabFNOL.Tabs[0].Visible = true;
                    tabFNOL.Tabs[1].Visible = true;
                    break;

                case 1: // Cerrados
                    //ToolsBarFNOL.Ribbon.Tabs[0].Groups["rbgCompletadas"].Visible = true;
                    break;

                case 2: // Empr Ajuste
                    cbParametroHistorial.Ribbon.Tabs[0].Groups["rgpEmpresasAjuste"].Visible = true;
                    tabFNOL.Tabs[2].Visible = true;
                    break;

                case 3: // Edicion Siniestro
                    cbParametroHistorial.Ribbon.Tabs[0].Groups["grpEdicionSiniestro"].Visible = true;
                    cbParametroHistorial.Ribbon.Tabs[0].Groups["grpReservas"].Visible = true;
                    tabFNOL.Tabs[3].Visible = true;
                    tabFNOL.Tabs[4].Visible = true;
                    tabFNOL.Tabs[5].Visible = true;
                    break;
            }
        }

        private void FNOL_Load(object sender, EventArgs e)
        {
            CargarDataSets();
            CmabiarLayout(0);
            cbCategoriaHistorial.SelectedIndex = 0;
            cbFiltroHistorial.SelectedIndex = 0;
            cbMonedaMontoReclamado.SelectedIndex = 0;
            cbParametro.SelectedIndex = 0;
            cbRamoSeguro.SelectedIndex = 0;
            cbUbicacion.SelectedIndex = 0;
        }

        void NuevoFNOL()
        {
            EditarFNOL frmNuevo = new EditarFNOL(0);
            if (frmNuevo.ShowDialog() == DialogResult.Yes)
                CargarDataSets();
        }

        void ModificarFNOL()
        {
            if(dgRegistrosClaims.ActiveRow.Cells["Status"].Value.ToString() == "Nuevo" || dgRegistrosClaims.ActiveRow.Cells["Status"].Value.ToString() == "En Proceso")
            {
                EditarFNOL frmNuevo = new EditarFNOL(Convert.ToInt32(dgRegistrosClaims.ActiveRow.Cells["ID"].Value));
                if (frmNuevo.ShowDialog() == DialogResult.Yes)
                    CargarDataSets();
            }
            else
            {
                MessageBox.Show("Este Siniestro ya ha sido atendido");
            }

        }

        void AgregarEmpresaAjuste()
        {
            EdiciónOrganizacionAjustadores frmNuevaEmpresa = new EdiciónOrganizacionAjustadores(0);
            if (frmNuevaEmpresa.ShowDialog() == DialogResult.Yes)
                CargarDataSets();
        }

        void EditarEmpresaAjuste()
        {
            if (dgEmpresasAjuste.ActiveRow == null)
                return;

            EdiciónOrganizacionAjustadores frmNuevaEmpresa = new EdiciónOrganizacionAjustadores(Convert.ToInt32(dgEmpresasAjuste.ActiveRow.Cells["ID"].Value));
            if (frmNuevaEmpresa.ShowDialog() == DialogResult.Yes)
                CargarDataSets();
        }

        void EliminarEmpresaAjuste()
        {
            if (dgEmpresasAjuste.ActiveRow == null)
                return;

            if (MessageBox.Show("Se borrará la empresa de Ajuste seleccionada, continuar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                int IDempresaEliminar = Convert.ToInt32(dgEmpresasAjuste.ActiveRow.Cells["ID"].Value);
                // Elimina Empresa
                AjustadorEmpresa ajustadorEmpresaEliminar = (from x in db.AjustadorEmpresas where x.ID == IDempresaEliminar select x).SingleOrDefault();
                ajustadorEmpresaEliminar.Eliminado = true;
                db.SubmitChanges();

                // Elimina a todos los ajustadores
                Ajustadore[] ajustadoreEliminar = (from x in db.Ajustadores where x.Organizacion == IDempresaEliminar select x).ToArray();
                if (ajustadoreEliminar.Count() > 0)
                {
                    for (int i = 0; i < ajustadoreEliminar.Count(); i++)
                    {
                        ajustadoreEliminar[i].Eliminado = true;
                        db.SubmitChanges();
                    }
                }
            }
        }

        void AsignacionAjustador()
        {
            if (dgRegistrosClaims.ActiveRow.Cells["Ajustador"].Value.ToString() == "") // Ajustador Nuevo
            {
                AsignarAjustador frmAsignar = new AsignarAjustador(Convert.ToInt32(dgRegistrosClaims.ActiveRow.Cells["ID"].Value));
                if (frmAsignar.ShowDialog() == DialogResult.Yes)
                    CargarDataSets();
            }
            else // Borra el ajustador actual y asigna uno nuevo
            {
                if (MessageBox.Show("El ajustador " + dgRegistrosClaims.ActiveRow.Cells["Ajustador"].Value.ToString() + " de la empresa" + 
                    dgRegistrosClaims.ActiveRow.Cells["Empresa Ajuste"].Value.ToString() + " ya ha sido asignado a este siniestro, desea sustituirlo?",
                    "Mensaje",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    SmartG.FNOL editFNOL = (from x in db.FNOLs where x.ID == Convert.ToInt32(dgRegistrosClaims.ActiveRow.Cells["ID"].Value) select x).SingleOrDefault();
                    editFNOL.Ajustador = null;
                    db.SubmitChanges();
                    MessageBox.Show("El ajustador " + dgRegistrosClaims.ActiveRow.Cells["Ajustador"].Value.ToString() + " de la empresa" +
                        dgRegistrosClaims.ActiveRow.Cells["Empresa Ajuste"].Value.ToString() + " ha sido relevado de este siniesto",
                        "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    AsignarAjustador frmAsignar = new AsignarAjustador(Convert.ToInt32(dgRegistrosClaims.ActiveRow.Cells["ID"].Value));
                    if (frmAsignar.ShowDialog() == DialogResult.Yes)
                        CargarDataSets();
                }
            }
        }

        void AgregarEditarParticipantes()
        {
            EditarParticipantes frmPart = new EditarParticipantes(Convert.ToInt32(dgRegistrosClaims.ActiveRow.Cells["ID"].Value));
            frmPart.ShowDialog();
            CargarInfoGeneralSiniestro(IDclaimActivo);
        }

        void EditarInformacion()
        {
            if(dgRegistrosClaims.ActiveRow.Cells["Status"].Value.ToString() != "En Proceso")
            {
                MessageBox.Show("Este registro no esta en proceso");
                return;
            }
            CmabiarLayout(3);
            IDclaimActivo = Convert.ToInt32(dgRegistrosClaims.ActiveRow.Cells["ID"].Value);
            CargarInfoGeneralSiniestro(IDclaimActivo);
        }

        void CargarInfoGeneralSiniestro(int IDClaim)
        {
            // Carlo data Sets
            this.liIncMonedaTableAdapter.Fill(this.liabilityInc.LiIncMoneda);
            this.claimsCatalogoUbicaciones163TableAdapter.Fill(this.claims.ClaimsCatalogoUbicaciones163);
            this.ramosSegurosTableAdapter.Fill(this.facturacion.RamosSeguros);

            // Carga los datos
            dbSmartGDataContext db = new dbSmartGDataContext();
            SmartG.FNOL FNOLrecupera = (from x in db.FNOLs where x.ID == IDClaim select x).SingleOrDefault();
            lbNumSiniestro.Text = FNOLrecupera.ClaimNum;
            txtPoliza.Text = FNOLrecupera.Poliza1.Poliza1;
            txtPersonaContacto.Text = FNOLrecupera.NombreContacto;
            txtTelContacto.Text = FNOLrecupera.TelefonoContacto;
            txtEmailContacto.Text = FNOLrecupera.EmailContacto;
            txtMontoReclamado.Value = FNOLrecupera.MontoReclamado;
            cbMonedaMontoReclamado.Value = FNOLrecupera.Moneda;
            cbUbicacion.Value = FNOLrecupera.Ubicacion;
            txtCausaSiniestro.Text = FNOLrecupera.CausaSiniestro;
            txtComentarios.Text = FNOLrecupera.ComentariosUsuario;
            cbRamoSeguro.Value = FNOLrecupera.RamoSeguro;

            int IDPoliza = FNOLrecupera.Poliza1.ID;
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
            cbRamoSeguro.Value = (from x in db.RamosLineaNegocios where x.LineaNegocio == Convert.ToInt32((from y in db.Poliza where y.ID == IDPoliza select y.LineaNegocios).SingleOrDefault()) select x.RamoSeguro).SingleOrDefault();

            // carga las coberturas
            this.polizaCoberturaTableAdapter.Fill(this.claims.PolizaCobertura, IDPoliza);

            FNOLPolizaCobertura[] fNOLPoliza = (from x in db.FNOLPolizaCoberturas where x.FNOL == IDClaim select x).ToArray();
            for (int i = 0; i < fNOLPoliza.Count(); i++)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgCoberturas.Rows)
                {
                    if (item.Cells["Cobertura"].Value.ToString() == fNOLPoliza[i].PolizaCobertura1.Coberturas.Cobertura)
                        item.Cells["Check"].Value = true;
                }
            }

            // Carga Ajustadores y participantes
            this.ajustadoresTableAdapter.FillByIDClaim(this.claims.Ajustadores, IDClaim);
            this.checkParticipantesTableAdapter.Fill(this.claims.CheckParticipantes, IDClaim);

            // Carga los Historiales
            this.fNOLHistorialTableAdapter.FillByIDClaim(this.claims.FNOLHistorial, IDClaim);

            // Carga las reservas
            this.reservasClaimsTableAdapter.FillByIDClaim(this.claims.ReservasClaims, IDClaim);

            txtIdemBruta.Value = Convert.ToDecimal((from x in db.ReservasClaims where x.FNOL == IDClaim && x.TipoReserva == 1 orderby x.ID descending select x.Reserva).FirstOrDefault());
            txtGastosBruta.Value = Convert.ToDecimal((from x in db.ReservasClaims where x.FNOL == IDClaim && x.TipoReserva == 3 orderby x.ID descending select x.Reserva).FirstOrDefault());
            txtIdemRecuperable.Value = Convert.ToDecimal((from x in db.ReservasClaims where x.FNOL == IDClaim && x.TipoReserva == 2 orderby x.ID descending select x.Reserva).FirstOrDefault());
            txtGastosRecuperable.Value = Convert.ToDecimal((from x in db.ReservasClaims where x.FNOL == IDClaim && x.TipoReserva == 4 orderby x.ID descending select x.Reserva).FirstOrDefault());
        }

        void GuardarCambiosInfoSiniestro(int IDClaim)
        {
            // Valida Informacion
            if (txtPersonaContacto.Text == "") { MessageBox.Show("No se ha ingresado una persona de Contacto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtTelContacto.Text == "") { MessageBox.Show("No se ha ingresado un telefono de Contacto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtEmailContacto.Text == "") { MessageBox.Show("No se ha ingresado un email de Contacto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (cbUbicacion.Text == "") { MessageBox.Show("No se ha ingresado una ubicación del Siniestro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (cbMonedaMontoReclamado.Text == "") { MessageBox.Show("No se ha ingresado una moneda del Siniestro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (cbRamoSeguro.Text == "") { MessageBox.Show("No se ha ingresado un ramo de seguropara el Siniestro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if(MessageBox.Show("Se actualizaran los datos Generales del Siniestro, continuar?","Mensaje",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                SmartG.FNOL nuevoFNOL = (from x in db.FNOLs where x.ID == IDClaim select x).SingleOrDefault();

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
                db.SubmitChanges();

                // Guardar Coberturas Afectadas
                FNOLPolizaCobertura[] fnolCobBorrar = (from x in db.FNOLPolizaCoberturas where x.FNOL == IDClaim select x).ToArray();
                if (fnolCobBorrar.Count() > 0)
                {
                    db.FNOLPolizaCoberturas.DeleteAllOnSubmit(fnolCobBorrar);
                    db.SubmitChanges();
                }
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgCoberturas.Rows)
                {
                    if (Convert.ToBoolean(item.Cells["Check"].Value))
                    {
                        FNOLPolizaCobertura nuevoFNOLCob = new FNOLPolizaCobertura();
                        nuevoFNOLCob.FNOL = IDClaim;
                        nuevoFNOLCob.PolizaCobertura = Convert.ToInt32(item.Cells["ID"].Value);
                        db.FNOLPolizaCoberturas.InsertOnSubmit(nuevoFNOLCob);
                        db.SubmitChanges();
                    }
                }
                MessageBox.Show("Registro FNOL: " + lbNumSiniestro.Text + " actualizado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        void AgregarNuevaActividad()
        {
            AgregarHistorial frmHistorial = new AgregarHistorial(IDclaimActivo);
            if (frmHistorial.ShowDialog() == DialogResult.Yes)
                CargarInfoGeneralSiniestro(IDclaimActivo);
        }

        void ReservaIndemnizacion()
        {
            EditarReserva frmInde = new EditarReserva(Convert.ToInt32(IDclaimActivo), true);
            if (frmInde.ShowDialog() == DialogResult.Yes)
                CargarInfoGeneralSiniestro(IDclaimActivo);
        }

        void ReservaGastos()
        {
            EditarReserva frmInde = new EditarReserva(Convert.ToInt32(IDclaimActivo), false);
            if (frmInde.ShowDialog() == DialogResult.Yes)
                CargarInfoGeneralSiniestro(IDclaimActivo);
        }

        private void ToolsBarFNOL_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btnActualizar":
                    CargarDataSets();
                    break;

                case "Agregar Nuevo FNOL":
                    NuevoFNOL();
                    break;

                case "Editar FNOL":
                    ModificarFNOL();
                    break;

                case "btnAgregarEmpresa":
                    AgregarEmpresaAjuste();
                    break;

                case "btnEditarEmpresa":
                    EditarEmpresaAjuste();
                    break;

                case "btnEliminarEmpresa":
                    EliminarEmpresaAjuste();
                    break;

                case "btnAsignarAjustador":
                    AsignacionAjustador();
                    break;

                case "btnAgregarEditarParticipantes":
                    AgregarEditarParticipantes();
                    break;

                case "btnEditarInfo":
                    EditarInformacion();
                    break;

                case "btnCerrar":
                    CmabiarLayout(0);
                    break;

                case "Editar Empresas de Ajuste":
                    CmabiarLayout(2);
                    break;

                case "btnGuardarCambios":
                    GuardarCambiosInfoSiniestro(IDclaimActivo);
                    break;

                case "btnAgregarNuevaActividad":
                    AgregarNuevaActividad();
                    break;

                //Reservas
                case "btnReservaIndemnizacion":
                    ReservaIndemnizacion();
                    break;

                case "btnAgregarReservaGastos":
                    ReservaGastos();
                    break;

                case "btnProcesarPagos":
                    break;


            }
        }

        private void dgEmpresasAjuste_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            EditarEmpresaAjuste();
        }

        private void tabFNOL_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            //switch (tabFNOL.SelectedTab.Index)
            //{
            //    case 0:
            //        CmabiarLayout(0);
            //        break;
            //    case 1:
            //        CmabiarLayout(1);
            //        break;
            //    case 2:
            //        CmabiarLayout(2);
            //        break;
            //}
        }

        private void btnConsultarHistorial_Click(object sender, EventArgs e)
        {

        }

        private void dgHistorial_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            FNOLHistorial historial = (from x in db.FNOLHistorials where x.ID == Convert.ToInt32(e.Row.Cells["ID"].Value) select x).SingleOrDefault();
            txtAutor.Text = historial.Usuario1.UserName;
            dateFechaCreacion.Value = historial.FechaCreacion;
            cbCategoriaHistorial.Value = historial.Tipo;
            txtDescripcion.Text = historial.Descripcion;
            txtNotasHistorial.Text = historial.Notas;
            txtCoberturaAfectada.Text = (from x in db.FNOLPolizaCoberturas where x.ID == historial.Cobertura select x.PolizaCobertura1.Coberturas.Cobertura).SingleOrDefault();

            this.fNOLHistorialArchivosTableAdapter.FillByIDHistorial(this.claims.FNOLHistorialArchivos, Convert.ToInt32(e.Row.Cells["ID"].Value));
            this.fNOLHistorialParticipanteTableAdapter.FillByIDHistorial(this.claims.FNOLHistorialParticipante, Convert.ToInt32(e.Row.Cells["ID"].Value));
        }

        private void dgDocumentosHistorial_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            DocumentosDB.ExtraerDocumentoClaimsHistorial(Convert.ToInt32(dgDocumentosHistorial.ActiveRow.Cells["ID"].Value));
        }
    }
}
