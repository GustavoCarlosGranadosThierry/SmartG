using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Operaciones.CreditControl
{
    public partial class MisFacturas : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // nombres y valores de todos los objetos que se encuentran en el formulario
        #region coleccion objetos

        #region primera tab datos generales CFDI

        #endregion
        #region segunda tab cliente
        #endregion
        #region tercera tab Conceptos
        #endregion
        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // nombres y valores de todos los objetos que se encuentran en el formulario
        #region Variables

        public static int sele = 1;
        Form MainForm;

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // nombres y valores de todos los objetos que se encuentran en el formulario
        #region MetodosProgramados
        void CargarDataSets()
        {
            try { this.checkFacturasTableAdapter.FillByUsuarioStatus(this.facturacion.CheckFacturas, Program.Globals.UserID); } catch { }
            try { this.checkFacturasTableAdapter.FillByUsuarioRechazado(this.facturacionRechazados.CheckFacturas, Program.Globals.UserID); } catch { }
            try { this.checkFacturasTableAdapter.FillByCompletados(this.facturacionCompletadas.CheckFacturas, Program.Globals.UserID); } catch { }
            try { this.solicitudCancelacionesTableAdapter.FillByUsuario(this.facturacion.SolicitudCancelaciones, Program.Globals.UserID); } catch { }

            // agrega los contadores a las tabs
            tabMisFacturas.Tabs[0].Text = tabMisFacturas.Tabs[0].Text.Split('(')[0].Trim() + " (" + this.facturacion.CheckFacturas.Rows.Count + ")";
            tabMisFacturas.Tabs[2].Text = tabMisFacturas.Tabs[2].Text.Split('(')[0].Trim() + " (" + this.facturacionRechazados.CheckFacturas.Rows.Count + ")";
        }

        void EditarSolicitud()
        {
            // Selecciona la tab visible para la operacion
            Infragistics.Win.UltraWinGrid.UltraGrid dgVisible = null;
            if (tabMisFacturas.ActiveTab.Index == 0)
                dgVisible = dgPendientes;
            else
                dgVisible = dgRechazadas;

            if (dgVisible.ActiveRow.Cells["Status_str"].Value.ToString() == "En Proceso")
            {
                MessageBox.Show("Este registro ya ha sido procesado por Credit Control y esta siendo enviada al proveedor de facturación para su timbrado, favor de esperar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgVisible.ActiveRow.Cells["Status_str"].Value.ToString() == "No solicitado" || dgVisible.ActiveRow.Cells["Status_str"].Value.ToString() == "Rechazado")
            {
                int IDfactura = Convert.ToInt32(dgVisible.ActiveRow.Cells["ID"].Value);
                Operaciones.CreditControl.Facturacion frmEditarFact = new Facturacion(IDfactura, "Normal");
                if (this.MdiParent.MdiChildren.Where(p => p.Text == "Facturacion").Count() > 0)
                {
                    MessageBox.Show("Ya hay una solicitud de Factura abierta, cerrarla antes de Editar una factura diferente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmEditarFact = this.MdiParent.MdiChildren.Where(p => p.Text == "Facturacion").First() as Operaciones.CreditControl.Facturacion;
                    frmEditarFact.Select();
                }
                else
                {
                    if (dgVisible.ActiveRow.Cells["Status_str"].Value.ToString() == "Rechazado")
                        MessageBox.Show("Descripción del Rechazo: " + Environment.NewLine + Environment.NewLine + dgVisible.ActiveRow.Cells["RechazoDes"].Value.ToString(), "Rechazo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    frmEditarFact.MdiParent = this.MdiParent;
                    frmEditarFact.Show();
                }
            }

            else
            {
                MessageBox.Show("Este registro ya ha sido solicitado, favor de recuperalo antes", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        void BorrarSolicitud()
        {
            if (dgPendientes.ActiveRow.Cells["Status_str"].Value.ToString() == "En Proceso")
            {
                MessageBox.Show("Este registro ya ha sido procesado por Credit Control y esta siendo enviada al proveedor de facturación para su timbrado, favor de esperar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (MessageBox.Show("Se actualizara el status de este registro a Cancelado, desea Continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int IDfactura = Convert.ToInt32(dgPendientes.ActiveRow.Cells["ID"].Value);
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    SmartG.Facturacion FactBorrar = (from x in db.Facturacions where x.ID == IDfactura select x).SingleOrDefault();
                    int StatusCancelado = (from x in db.StatusFacturacions where x.Status == "Cancelado" select x.ID).SingleOrDefault();
                    FactBorrar.StatusFacturacion = StatusCancelado;
                    db.SubmitChanges();
                    CargarDataSets();
                }
            }
        }

        void RecuperarSolicitud()
        {
            if (dgPendientes.ActiveRow.Cells["Status_str"].Value.ToString() != "Solicitado")
            {
                MessageBox.Show("Este registro aún no ha sido solicitada para facturación", "Mensaje");
                return;
            }

            dbSmartGDataContext db = new dbSmartGDataContext();
            SmartG.Facturacion RecuperarFact = (from x in db.Facturacions where x.ID == Convert.ToInt32(dgPendientes.ActiveRow.Cells["ID"].Value) select x).SingleOrDefault();
            RecuperarFact.StatusFacturacion = (from x in db.StatusFacturacions where x.Status == "No solicitado" select x.ID).SingleOrDefault();
            db.SubmitChanges();
            MessageBox.Show("Registro recuperado, puede editar nuevamente antes de la solicitud a Credit Control", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // FIX Extensiones.AgregarLog("Facturación", "Update", IDfactura, "Recuperación de una solicitud completada para edición");
            CargarDataSets();
        }

        void DuplicarSolicitud()
        {
            if (dgPendientes.ActiveRow.Cells["Status_str"].Value.ToString() != "No solicitado")
            {
                MessageBox.Show("Este registro ya ha sido solicitado para facturación, primero recuperé el registro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgPendientes.ActiveRow.Cells["RFC"].Value.ToString() == "")
            {
                MessageBox.Show("No se puede duplicar registros sin Cliente previamente seleccionado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Proceso para agregar pagadores
            string vDef = "0";
            Extensiones.Edicion.InputBox("Agregar Pagadores", "Este proceso duplicará este registro para que se ingresen multiples " +
            Environment.NewLine + "receptores para esta factura, ingrese el numero de total de pagadores de la poliza (Solo numeros):", ref vDef);
            bool test = int.TryParse(vDef, out int resutado);
            if (!test) { MessageBox.Show("El valor ingresado no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (resutado <= 0) { MessageBox.Show("No se ingresaron valores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            try
            {
                for (int i = 0; i < resutado; i++)
                {
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    int idFacturaOriginal = Convert.ToInt32(dgPendientes.ActiveRow.Cells["ID"].Value);

                    // Copia de Factura
                    SmartG.Facturacion oriFactura = (from x in db.Facturacions where x.ID == idFacturaOriginal select x).SingleOrDefault();
                    SmartG.Facturacion newFactura = new SmartG.Facturacion();
                    newFactura.TipoDocumento = oriFactura.TipoDocumento;
                    newFactura.Serie = oriFactura.Serie;
                    newFactura.Folio = oriFactura.Folio;
                    newFactura.FormaPagoSAT = oriFactura.FormaPagoSAT;
                    newFactura.CondicionesPago = oriFactura.CondicionesPago;
                    newFactura.MetodoPago = oriFactura.MetodoPago;
                    newFactura.UsoCDFI = oriFactura.UsoCDFI;
                    newFactura.DireccionCompañia = oriFactura.DireccionCompañia;
                    newFactura.Plazo = oriFactura.Plazo;
                    newFactura.LimitePago = oriFactura.LimitePago;
                    newFactura.Confirmacion = oriFactura.Confirmacion;
                    newFactura.TipoCambio = oriFactura.TipoCambio;
                    newFactura.Moneda = oriFactura.Moneda;
                    newFactura.Subtotal = oriFactura.Subtotal;
                    newFactura.Descuentos = oriFactura.Descuentos;
                    newFactura.ImpuestosTransladados = oriFactura.ImpuestosTransladados;
                    newFactura.ImpuestosRetenidos = oriFactura.ImpuestosRetenidos;
                    newFactura.Total = oriFactura.Total;
                    newFactura.StatusFacturacion = oriFactura.StatusFacturacion;
                    newFactura.FechaSolicitud = oriFactura.FechaSolicitud;
                    newFactura.UsuarioSolicitud = oriFactura.UsuarioSolicitud;
                    newFactura.FechaTimbrado = oriFactura.FechaTimbrado;
                    newFactura.UUID = oriFactura.UUID;
                    newFactura.UsuarioTimbrado = oriFactura.UsuarioTimbrado;
                    newFactura.RamoSeguro = oriFactura.RamoSeguro;
                    newFactura.ReferenciaFacCancelada = oriFactura.ReferenciaFacCancelada;
                    newFactura.ConceptoCancelacion = oriFactura.ConceptoCancelacion;
                    newFactura.Poliza_str = oriFactura.Poliza_str;
                    newFactura.iniVig = oriFactura.iniVig;
                    newFactura.finVig = oriFactura.finVig;
                    newFactura.RechazoDes = oriFactura.RechazoDes;
                    db.Facturacions.InsertOnSubmit(newFactura);
                    db.SubmitChanges();

                    int idFacturaNueva = newFactura.ID;

                    // Copia de Conceptos
                    FacturacionConcepto[] factConcepto = (from x in db.FacturacionConceptos where x.Facturacion == idFacturaOriginal select x).ToArray();
                    for (int j = 0; j < factConcepto.Count(); j++)
                    {
                        FacturacionConcepto newConcepto = new FacturacionConcepto();
                        newConcepto.ClaveProductoSAT = factConcepto[j].ClaveProductoSAT;
                        newConcepto.ClaveUnidadSAT = factConcepto[j].ClaveUnidadSAT;
                        newConcepto.Cantidad = factConcepto[j].Cantidad;
                        newConcepto.Identificacion = factConcepto[j].Identificacion;
                        newConcepto.Descripcion = factConcepto[j].Descripcion;
                        newConcepto.Precio = factConcepto[j].Precio;
                        newConcepto.Total = factConcepto[j].Total;
                        newConcepto.Descuento = factConcepto[j].Descuento;
                        newConcepto.Facturacion = idFacturaNueva;
                        db.FacturacionConceptos.InsertOnSubmit(newConcepto);
                        db.SubmitChanges();
                    }

                    // Copia de Participantes
                    FacturaParticipante factParticipante = (from x in db.FacturaParticipantes where x.Factura == idFacturaOriginal select x).SingleOrDefault();
                    if (factParticipante != null)
                    {
                        FacturaParticipante newParticipante = new FacturaParticipante();
                        newParticipante.Coasegurador = factParticipante.Coasegurador;
                        newParticipante.PorcentajeCoaseguroEmpresa = factParticipante.PorcentajeCoaseguroEmpresa;
                        newParticipante.Broker = factParticipante.Broker;
                        newParticipante.Factura = idFacturaNueva;
                        db.FacturaParticipantes.InsertOnSubmit(newParticipante);
                        db.SubmitChanges();
                    }
                }
                // FIX Extensiones.AgregarLog("Facturación", "Insert", IDfactura, "Duplicación de registros para agregar pagadores");
                MessageBox.Show("Se duplicaron " + resutado + " registros", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                CargarDataSets();
            }
            catch
            {
                MessageBox.Show("Error: Todos los datos de la solicitud de factura deberán de estar completos antes de " +
                    "realizar la duplicación de la misma, favor de editar y completar los datos faltantes antes de proceder " +
                    "con esta operación.", "Falta de información en Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void SolicitarCancelacion()
        {
            if (dgCompletadas.ActiveRow.Cells["Status_str"].Value.ToString() == "Cancelado")
            {
                MessageBox.Show("La factura ya esta Cancelada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Program.Globals.TipoUsuario == "Administrador")
            {
                Operaciones.CreditControl.selectorSolicitudCancelacion frmSeleccion = new selectorSolicitudCancelacion();
                if (frmSeleccion.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            else
            {
                sele = 1;
            }
            //Si es un usuario diferente a credit Control
            if (Program.Globals.TipoUsuario != "Credit Control" && sele == 1)
            {
                //Validamos que no haya solicitudes actuales para la factura seleccionada
                dbSmartGDataContext db = new dbSmartGDataContext();
                int idStatusSolicitado = (from x in db.StatusFacturacions where x.Status == "Solicitado" select x.ID).SingleOrDefault();
                int idStatusAplicado = (from x in db.StatusFacturacions where x.Status == "Aplicado" select x.ID).SingleOrDefault();
                int ConteoSolicitudes = (from x in db.SolicitudCancelaciones where (x.Factura == Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value.ToString()) && (x.Status == idStatusSolicitado || x.Status == idStatusAplicado)) select x).ToArray().Count();
                if (ConteoSolicitudes == 0)
                {
                    //validamos que no tenga comprobantes de pago aplicados                    
                    if ((from x in db.RecibosPagos where x.Facturacion == Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value) && x.Status == idStatusAplicado select x).ToArray().Count() > 0)
                    {
                        MessageBox.Show("La factura ya cuenta con comprobantes de pago por lo que no es posible solicitar una cancelacion desde esta terminal, pongase en contacto con el departamento de Credit Control para mas informacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MotivosCancelacion frmMotivos = new MotivosCancelacion(dgCompletadas.ActiveRow.Cells["Serie"].Value.ToString() + dgCompletadas.ActiveRow.Cells["Folio"].Value.ToString(), Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value.ToString()));
                        frmMotivos.ShowDialog();
                        tabMisFacturas.Tabs[3].Selected = true;
                        CargarDataSets();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Ya existe una solicitud para esta factura", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            else if (Program.Globals.TipoUsuario == "Credit Control" || sele == 2)
            {
                //validamos que no haya un registro pendiente
                dbSmartGDataContext db = new dbSmartGDataContext();
                int idStatusSolicitado = (from x in db.StatusFacturacions where x.Status == "Solicitado" select x.ID).SingleOrDefault();
                int idStatusAplicado = (from x in db.StatusFacturacions where x.Status == "Aplicado" select x.ID).SingleOrDefault();
                int ConteoSolicitudes = (from x in db.SolicitudCancelaciones where (x.Factura == Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value.ToString()) && (x.Status == idStatusSolicitado || x.Status == idStatusAplicado)) select x).ToArray().Count();
                if (ConteoSolicitudes == 0)
                {
                    //validamos que no tenga comprobantes de pago aplicados, si tiene se manda a llamar a la ventana de cancelaciones
                    if ((from x in db.RecibosPagos where x.Facturacion == Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value) && x.StatusFacturacion.Status == "Aplicado" select x).ToArray().Count() > 0)
                    {
                        if (MessageBox.Show("La factura ya cuenta con comprobantes de pago aplicados, ¿desea iniciar el proceso de generacion de solicitud y creacion de nota de credito?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                        {
                            CancelacionFacturas frmCancelacion = new CancelacionFacturas(MainForm, dgCompletadas.ActiveRow.Cells["Serie"].Value.ToString() + dgCompletadas.ActiveRow.Cells["Folio"].Value.ToString(), Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value.ToString()));
                            if (frmCancelacion.ShowDialog() == DialogResult.OK)
                            {
                                CargarDataSets();

                                if (MessageBox.Show("Solicitud de Cancelación generada correctamente, desea generar la nota de credito para esta factura?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                                {
                                    //Generacion de la nota de Credito
                                    Facturacion frmFacturacion = new Facturacion(Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value.ToString()), "Emitido", 1);
                                    frmFacturacion.ShowDialog();
                                }
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    //si no tiene se manda a llamar a la ventana con un 1
                    else
                    {
                        CancelacionFacturas frmCancelacion = new CancelacionFacturas(MainForm, dgCompletadas.ActiveRow.Cells["Serie"].Value.ToString() + dgCompletadas.ActiveRow.Cells["Folio"].Value.ToString(), Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value.ToString()));
                        if (frmCancelacion.ShowDialog() == DialogResult.OK)
                        {
                            CargarDataSets();
                        }
                    }
                }
                else // si ya hay una solicitud previa
                {
                    //validamos que no tenga comprobantes de pago aplicados, si tiene se manda a llamar a la ventana de cancelaciones
                    if ((from x in db.RecibosPagos where x.Facturacion == Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value) && x.StatusFacturacion.Status == "Aplicado" select x).ToArray().Count() > 0)
                    {
                        if (MessageBox.Show("La factura ya cuenta con comprobantes de pago aplicados, ¿desea continuar el proceso de generacion de solicitud y creacion de nota de credito?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                        {
                            CancelacionFacturas frmCancelacion = new CancelacionFacturas(MainForm, dgCompletadas.ActiveRow.Cells["Serie"].Value.ToString() + dgCompletadas.ActiveRow.Cells["Folio"].Value.ToString(), Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value.ToString()));
                            if (frmCancelacion.ShowDialog() == DialogResult.OK)
                            {
                                CargarDataSets();

                                if (MessageBox.Show("Solicitud de Cancelación generada correctamente, desea generar la nota de credito para esta factura?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                                {
                                    //Generacion de la nota de Credito
                                    Facturacion frmFacturacion = new Facturacion(Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value.ToString()), "Emitido", 1);
                                    frmFacturacion.ShowDialog();
                                }
                            }
                        }
                        else
                        {
                            return;
                        }

                    }
                    else // No tiene comprobantes
                    {
                        CancelacionFacturas frmCancelacion = new CancelacionFacturas(MainForm, dgCompletadas.ActiveRow.Cells["Serie"].Value.ToString() + dgCompletadas.ActiveRow.Cells["Folio"].Value.ToString(), Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value.ToString()));
                        if (frmCancelacion.ShowDialog() == DialogResult.OK)
                        {
                            CargarDataSets();
                        }
                    }
                }
            }
        }

        void EliminarSolicitudCancelacion()
        {
            string status = dgCancelaciones.ActiveRow.Cells["Status"].Value.ToString();
            if (status != "Solicitado")
            {
                MessageBox.Show("Esta solicitud ya ha sido procesada por Credit Control", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                if (MessageBox.Show("Desea anular esta solicitud de Cancelación?_", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    SolicitudCancelacione EliminaSolicitud = (from x in db.SolicitudCancelaciones where x.ID == Convert.ToInt32(dgCancelaciones.ActiveRow.Cells["ID"].Value) select x).SingleOrDefault();
                    EliminaSolicitud.Status = (from x in db.StatusFacturacions where x.Status == "Anulado" select x.ID).SingleOrDefault();
                    db.SubmitChanges();
                    CargarDataSets();
                }
            }
        }

        void DescargarDocs()
        {
            Datasets.DBdocumentos.BDdocsTableAdapters.DocumentosFacturacionNuevoTableAdapter documentosFacturacionNuevoTableAdapter = new Datasets.DBdocumentos.BDdocsTableAdapters.DocumentosFacturacionNuevoTableAdapter();
            DataTable dtTemp = documentosFacturacionNuevoTableAdapter.GetDataByFolioSerie(dgCompletadas.ActiveRow.Cells["Folio"].Value.ToString(), dgCompletadas.ActiveRow.Cells["Serie"].Value.ToString());
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                DocumentosDB.ExtraerDocumentosFacturacionDB(Convert.ToInt32(dtTemp.Rows[i]["Factura"].ToString()), dtTemp.Rows[i]["NombreDocumento"].ToString(),
                    dtTemp.Rows[i]["Folio"].ToString(), dtTemp.Rows[i]["Serie"].ToString());
            }
            MessageBox.Show("Archivos extraidos con éxito", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            dbSmartGDataContext db = new dbSmartGDataContext();
            try
            {
                int IDfactura = (from x in db.Facturacions where (x.Folio == Convert.ToInt32(dtTemp.Rows[0]["Folio"].ToString()) && x.Serie == dtTemp.Rows[0]["Serie"].ToString()) select x.ID).SingleOrDefault();
                string CondPago = (from x in db.Facturacions where x.ID == IDfactura select x.FormaPago.FormaPago1).SingleOrDefault().ToString();
                if (CondPago == "Anual" || CondPago == "Contado") { }
                else
                {
                    if (MessageBox.Show("Desea Generar los recibos de Pago para esta factura con forma de pago: " + CondPago + "?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        GenerarRecibos(IDfactura);
                    }
                }
            }
            catch { }
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SmartG-Documentos\");
        }

        void GenerarRecibos(int idFactura)
        {
            Espera frmWait = new Espera();
            frmWait.Show();
            this.Enabled = false;
            Extensiones.Cobranza.GenerarRecibosPago(idFactura, true);
            frmWait.Close();
            this.Enabled = true;
        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // nombres y valores de todos los objetos que se encuentran en el formulario
        #region EventosForm

        public MisFacturas(Form mainform)
        {
            InitializeComponent();
            MainForm = mainform;
        }

        private void MisFacturas_Load(object sender, EventArgs e)
        {
            //Extensiones.Traduccion.traducirVentana(this, tabMisFacturas, ToolsBarFMisFacturas);

            CargarDataSets();
            cbParametro.SelectedIndex = 0;
            ToolsBarFMisFacturas.Ribbon.Tabs[0].Groups["rbgSolicitudes"].Visible = true;
            ToolsBarFMisFacturas.Ribbon.Tabs[0].Groups["rbgCompletadas"].Visible = false;
            ToolsBarFMisFacturas.Ribbon.Tabs[0].Groups["rbgCancelaciones"].Visible = false;

        }

        private void ToolsBarFacturacion_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {

            switch (e.Tool.Key)
            {
                // Pendientes

                case "btnRecuperarSolicitud":
                    RecuperarSolicitud();
                    break;

                case "btnBorrarSolicitud":
                    BorrarSolicitud();
                    break;

                case "btnDuplicarSolicitud":
                    DuplicarSolicitud();
                    break;

                case "btnEditarSolicitud":
                    EditarSolicitud();
                    break;

                // Completadas

                case "btnNuevaSolicituddeCancelacion":
                    SolicitarCancelacion();
                    break;

                case "btnDescargarDocumentos":
                    DescargarDocs();
                    break;

                // Cancelaciones

                case "btnEliminarSolicitud":
                    EliminarSolicitudCancelacion();
                    break;

                // Actualizar
                case "btnActualizar":
                    CargarDataSets();
                    break;
            }
        }

        private void dgPendientes_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            EditarSolicitud();
        }

        private void tabMisFacturas_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            ToolsBarFMisFacturas.Ribbon.Tabs[0].Groups["rbgSolicitudes"].Visible = false;
            ToolsBarFMisFacturas.Ribbon.Tabs[0].Groups["rbgCompletadas"].Visible = false;
            ToolsBarFMisFacturas.Ribbon.Tabs[0].Groups["rbgCancelaciones"].Visible = false;
            switch (tabMisFacturas.ActiveTab.Index)
            {
                case 0: // Pendientes
                    ToolsBarFMisFacturas.Ribbon.Tabs[0].Groups["rbgSolicitudes"].Visible = true;
                    break;
                case 1: // Completadas
                    ToolsBarFMisFacturas.Ribbon.Tabs[0].Groups["rbgCompletadas"].Visible = true;
                    break;
                case 2: // Rechazadas
                    ToolsBarFMisFacturas.Ribbon.Tabs[0].Groups["rbgSolicitudes"].Visible = true;
                    break;
                case 3: // Cancelaciones
                    ToolsBarFMisFacturas.Ribbon.Tabs[0].Groups["rbgCancelaciones"].Visible = true;
                    break;
            }
        }

        private void dgRechazadas_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            EditarSolicitud();
        }

        private void cbParametro_ValueChanged(object sender, EventArgs e)
        {
            dateBusqueda.Visible = false;
            txtBusqueda.Visible = false;
            switch (cbParametro.SelectedIndex)
            {
                case 0: txtBusqueda.Visible = true; break;
                case 1: txtBusqueda.Visible = true; break;
                case 2: txtBusqueda.Visible = true; break;
                case 3: txtBusqueda.Visible = true; break;
                case 4: txtBusqueda.Visible = true; break;
                case 5: dateBusqueda.Visible = true; break;
                case 6: dateBusqueda.Visible = true; break;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime p1 = Convert.ToDateTime(dateBusqueda.Value);
                DateTime p2 = Convert.ToDateTime(dateBusqueda.Value);
                TimeSpan ts = new TimeSpan(0, 0, 0);
                p1 = p1.Date + ts;
                ts = new TimeSpan(23, 59, 59);
                p2 = p2.Date + ts;
                switch (cbParametro.SelectedIndex)
                {
                    case 0: //Cliente
                        this.checkFacturasTableAdapter.FillByXNomCliente(this.facturacionCompletadas.CheckFacturas, txtBusqueda.Text);
                        break;
                    case 1: //rfc
                        this.checkFacturasTableAdapter.FillByXrfc(this.facturacionCompletadas.CheckFacturas, txtBusqueda.Text);
                        break;
                    case 2: //poliza
                        this.checkFacturasTableAdapter.FillByXpoliza(this.facturacionCompletadas.CheckFacturas, txtBusqueda.Text);
                        break;
                    case 3: //folio
                        int busqueda = 0;
                        if (int.TryParse(txtBusqueda.Text, out busqueda))
                        {
                            this.checkFacturasTableAdapter.FillByXfolio(this.facturacionCompletadas.CheckFacturas, busqueda);
                        }
                        else { MessageBox.Show("Valor invalido"); return; }
                        break;
                    case 4://uuid
                        this.checkFacturasTableAdapter.FillByUUID(this.facturacionCompletadas.CheckFacturas, txtBusqueda.Text);
                        break;
                    case 5://fecha solici
                        this.checkFacturasTableAdapter.FillByXfechaSolicitud(this.facturacionCompletadas.CheckFacturas, p1, p2);
                        break;
                    case 6://fecha timbrado
                        this.checkFacturasTableAdapter.FillByXfechaTimbrado(this.facturacionCompletadas.CheckFacturas, p1, p2);
                        break;
                }
                if (this.facturacionCompletadas.CheckFacturas.Count == 0)
                    MessageBox.Show("No hay registros", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            catch { }

        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtBusqueda.Text != "")
            {
                btnBuscar_Click(null, null);
            }

        }

        private void dgCompletadas_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            DescargarDocs();
        }

        private void validarCB(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            Infragistics.Win.UltraWinEditors.UltraComboEditor cb = (Infragistics.Win.UltraWinEditors.UltraComboEditor)sender;

            if (cb.Items.Count > 0)
            {
                MessageBox.Show("Debe seleccionar un elemento valido de la lista " + cb.DisplayMember.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.RetainFocus = true;
            }
            else
            {
                e.RetainFocus = false;
                cb.Text = "";
            }
        }

        private void DataGrid_MouseDown(object sender, MouseEventArgs e)
        {
            UltraGrid DG = (UltraGrid)sender;
            if (e.Button == MouseButtons.Right)
            {
                UIElement element = ((UltraGrid)sender).DisplayLayout.UIElement.LastElementEntered;

                UltraGridCell cell = element.GetContext(typeof(UltraGridCell)) as UltraGridCell;
                if (cell != null)
                {
                    DG.ActiveRow = cell.Row;
                    Point mousePoint = new Point(e.X, e.Y);
                    ContextMenuStrip CMS = DG.ContextMenuStrip;
                    if (CMS != null)
                    {
                        DG.ActiveRow = null;
                        cell.Row.Selected = true;
                        DG.ActiveCell = cell;
                        CMS.Show(DG, mousePoint);
                    }
                }
            }
        }

        private void cmsSolicitudes_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (dgPendientes.ActiveRow == null)
            {
                MessageBox.Show("No se ha seleccionado ningún registro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (dgPendientes.Rows.Count > 0)
                {
                    for (int i = 0; i < dgPendientes.Rows.Count; i++)
                        dgPendientes.Rows[i].Update();
                }

                switch (e.ClickedItem.Text)
                {
                    case "Editar Solicitud":
                        EditarSolicitud();
                        break;
                    case "Recuperar Solicitud":
                        RecuperarSolicitud();
                        break;
                    case "Duplicar Solicitud":
                        DuplicarSolicitud();
                        break;
                }
            }

            #endregion

            //**********************************************************************************
            //**********************************************************************************
            //**********************************************************************************

        }

        private void cmsCompletadas_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (dgCompletadas.ActiveRow == null)
            {
                MessageBox.Show("No se ha seleccionado ningún registro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (dgCompletadas.Rows.Count > 0)
                {
                    for (int i = 0; i < dgCompletadas.Rows.Count; i++)
                        dgCompletadas.Rows[i].Update();
                }

                switch (e.ClickedItem.Text)
                {
                    case "Descargar Documentos":
                        DescargarDocs();
                        break;
                    case "Solicitar Cancelación":
                        SolicitarCancelacion();
                        break;
                }
            }
        }
    }
}
