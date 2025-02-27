using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SmartG.Operaciones.CreditControl
{
    public partial class AdministracionFacturas : Form
    {
        Form MainFrm;
        const bool GenerarPDFpersonalizados = false;

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // nombres y valores de todos los objetos que se encuentran en el formulario
        #region coleccion objetos
        #region primeraTab

        // grpPendientes            Solicitudes Pendientes de Procesamiento (Doble Clic para Editar)
        // dgPendientes     
        #endregion

        #region segundaTab

        // grpBusqueda              Busqueda de Facturas
        // lbParametro              Parametro:
        // cbParametro
        // lbBuscar                 Buscar:
        // dateBusqueda
        // txtBusqueda
        // btnBuscar                Consultar
        // grpCompletadas           Solicitudes  Procesadas por Credit Control
        // dgCompletadas
        #endregion

        #region terceraTab

        // grpCancelaciones     Solicitudes de Cancelaciones (Doble Clic para Procesar)
        // dgCancelaciones
        #endregion
        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // nombres y valores de todos los objetos que se encuentran en el formulario
        #region MetodosProgramados
        void CargarDataSets()
        {
            try
            { this.checkFacturasTableAdapter.FillBySolicitados(this.facturacion.CheckFacturas); }
            catch { }
            try { this.checkFacturasTableAdapter.Fill(this.Basefacturacion.CheckFacturas); } catch { }
            this.solicitudCancelacionesTableAdapter.Fill(this.facturacion.SolicitudCancelaciones);
        }

        void RechazarSolicitud()
        {
            string vDef = "";
            Extensiones.Edicion.InputBox("Rechazo de Solicitud", "Ingrese una descripción del Rechazo de la Solicitud", ref vDef);
            if (vDef == "")
            {
                MessageBox.Show("Ingrese una razon del rechazo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dbSmartGDataContext db = new dbSmartGDataContext();
            SmartG.Facturacion solRechazada = (from x in db.Facturacions where x.ID == Convert.ToInt32(dgPendientes.ActiveRow.Cells["ID"].Value) select x).SingleOrDefault();
            solRechazada.StatusFacturacion = (from x in db.StatusFacturacions where x.Status == "Rechazado" select x.ID).SingleOrDefault();
            solRechazada.RechazoDes = vDef;
            db.SubmitChanges();

            // FIX Extensiones.AgregarLog("Facturacion", "Update", IDfactura, "Solicitud de Factura Rechazada, motivo: " + vDef);
            MessageBox.Show("Registro Rechazado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarDataSets();
        }

        void EditarSolicitud()
        {
            if (dgPendientes.Rows.Count == 0)
                return;
            int IDfactura = Convert.ToInt32(dgPendientes.ActiveRow.Cells["ID"].Value);
            Operaciones.CreditControl.Facturacion frmEditarFact = new Facturacion(IDfactura, "Normal");
            if (this.MdiParent.MdiChildren.Where(p => p.Text == "Facturacion").Count() > 0)
            {
                MessageBox.Show("Ya hay una solicitud de Factura abierta, cerrarla antes de Editar una factura diferente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmEditarFact = this.MdiParent.MdiChildren.Where(p => p.Text == "Facturacion").First() as Operaciones.CreditControl.Facturacion;
                frmEditarFact.Select();
            }
            else
            {
                frmEditarFact.MdiParent = this.MdiParent;
                frmEditarFact.Show();
            }
        }

        void ProcesarTimbrado()
        {
            // Verifica que se hayan seleccionado por lo menos 1 registro
            if (dgPendientes.ActiveRow == null) { MessageBox.Show("No se selecciono ningún registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            
            // Valida el status
            int idSolicitud = Convert.ToInt32(dgPendientes.ActiveRow.Cells["ID"].Value.ToString());
            if (dgPendientes.ActiveRow.Cells["Status_str"].Value.ToString() != "Solicitado")
            {
                MessageBox.Show("La solicitud con ID: " + idSolicitud + " no sera procesada pues su estatus no es Solicitado.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }

            if (dgPendientes.ActiveRow.Cells["Serie"].Value.ToString() == "NC")
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                if ((from x in db.Facturacions where x.ID == idSolicitud select x.ReferenciaFacCancelada).SingleOrDefault() == null)
                {
                    MessageBox.Show("La solicitud con ID: " + idSolicitud + " no sera procesada no se le ha asignado una Factura de Referencia para esa Nota de Crédito",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
            }


            if (MessageBox.Show("Se mandarán a timbrado la soliciud seleccionada, continuar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Asigna el folio Correspondiente
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    // revisa si ya fue asignado un folio anteriormente
                    if ((from x in db.Facturacions where x.ID == idSolicitud select x.Folio).SingleOrDefault().ToString() == "")
                    {
                        string serie = dgPendientes.ActiveRow.Cells["Serie"].Value.ToString();
                        Datasets.CreditControl.FacturacionTableAdapters.FacturacionTableAdapter taFact = new Datasets.CreditControl.FacturacionTableAdapters.FacturacionTableAdapter();
                        int NumFolio = Convert.ToInt32(taFact.ScalarQuery_GetNuevoFolio(serie));
                        SmartG.Facturacion facturaProcesada = (from x in db.Facturacions where x.ID == idSolicitud select x).SingleOrDefault();
                        facturaProcesada.StatusFacturacion = (from x in db.StatusFacturacions where x.Status == "En Proceso" select x.ID).SingleOrDefault();
                        facturaProcesada.Folio = NumFolio;
                        db.SubmitChanges();
                    }
                    else
                    {
                        SmartG.Facturacion facturaProcesada = (from x in db.Facturacions where x.ID == idSolicitud select x).SingleOrDefault();
                        facturaProcesada.StatusFacturacion = (from x in db.StatusFacturacions where x.Status == "En Proceso" select x.ID).SingleOrDefault();
                        db.SubmitChanges();
                    }

                    // Asocia la factura con alguna poliza
                    int idPoliza = 0;
                    try
                    {
                        string PolizaEnFactura = (from x in db.Facturacions where x.ID == idSolicitud select x.Poliza_str).SingleOrDefault();
                        idPoliza = (from x in db.Poliza where x.Poliza1 == PolizaEnFactura select x.ID).SingleOrDefault();
                    }
                    catch { }

                    if (idPoliza != 0)
                    {
                        if ((from x in db.PolizaFacturas where x.Factura == idSolicitud || x.Poliza == idPoliza select x).ToArray().Count() == 0)
                        {
                            PolizaFactura polizaFacturaNueva = new PolizaFactura();
                            polizaFacturaNueva.Poliza = idPoliza;
                            polizaFacturaNueva.Factura = idSolicitud;
                            db.PolizaFacturas.InsertOnSubmit(polizaFacturaNueva);
                            db.SubmitChanges();
                        }
                    }

                    // Timbra la poliza
                    Extensiones.TimbradoWSfinkok.TimbrarFactura(idSolicitud, MainFrm);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                CargarDataSets();
            }
        }

        void CopiarRegistro()
        {
            int IDfactura = Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value);
            Operaciones.CreditControl.Facturacion frmEditarFact = new Facturacion(IDfactura, "Emitido");
            if (this.MdiParent.MdiChildren.Where(p => p.Text == "Facturacion").Count() > 0)
            {
                MessageBox.Show("Ya hay una solicitud de Factura abierta, cerrarla antes de Editar una factura diferente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmEditarFact = this.MdiParent.MdiChildren.Where(p => p.Text == "Facturacion").First() as Operaciones.CreditControl.Facturacion;
                frmEditarFact.Select();
            }
            else
            {
                if (MessageBox.Show("Se generará una nueva solicitud de facturación con la información copiada del registro seleccionado, continuar?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmEditarFact.MdiParent = this.MdiParent;
                    frmEditarFact.Show();
                }
            }
        }

        void ReprocesarTimbrado()
        {
            if (dgCompletadas.ActiveRow.Cells["Status_str"].Value.ToString() == "En Proceso" || dgCompletadas.ActiveRow.Cells["Status_str"].Value.ToString() == "Error")
            {
                if (MessageBox.Show("Se reprocesará la solicitud de facturación del folio seleccionado, desea continuar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Extensiones.TimbradoWSfinkok.TimbrarFactura(Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value), MainFrm);
                    CargarDataSets();
                }
            }
            else
                MessageBox.Show("Esta factura/NC ya ha sido procesada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void VerErrores()
        {
            if (dgCompletadas.ActiveRow.Cells["RechazoDes"].Value.ToString() == "")
            {
                MessageBox.Show("No hay error para mostrar", "Error de timbrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Detalle del error de Timbrado:" + Environment.NewLine + Environment.NewLine + dgCompletadas.ActiveRow.Cells["RechazoDes"].Value.ToString(), "Error de timbrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void EditarRegistro()
        {
            if (dgCompletadas.ActiveRow.Cells["Status_str"].Value.ToString() == "Factura Generada" || dgCompletadas.ActiveRow.Cells["Status_str"].Value.ToString() == "Recibos Generados")
            {
                Operaciones.CreditControl.EditarFactura frmEditar = new EditarFactura(Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value));
                frmEditar.ShowDialog();
                if (frmEditar.DialogResult == DialogResult.OK)
                {
                    CargarDataSets();
                }
            }
            else
                MessageBox.Show("No se puden procesar esta factura debido a su status actual", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void ProcesarCancelacion()
        {
            if (dgCancelaciones.ActiveRow.Cells["Status"].Value.ToString() == "Solicitado")
            {
                string Seriefolio = dgCancelaciones.ActiveRow.Cells["Serie"].Value.ToString() + dgCancelaciones.ActiveRow.Cells["Folio"].Value.ToString();
                int idFactura = Convert.ToInt32(dgCancelaciones.ActiveRow.Cells["Factura"].Value);
                CancelacionFacturas frmCancelacion = new CancelacionFacturas(MainFrm, Seriefolio, idFactura);
                frmCancelacion.ShowDialog();
                CargarDataSets();
            }
            else
            {
                if (dgCancelaciones.ActiveRow.Cells["Status"].Value.ToString() == "En Proceso")
                {
                    if (MessageBox.Show("Se volvera a enviar la solicitud de Cancelacion, continiuar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dbSmartGDataContext db = new dbSmartGDataContext();
                        int IDfactura = Convert.ToInt32((from x in db.SolicitudCancelaciones where x.ID == Convert.ToInt32(dgCancelaciones.ActiveRow.Cells["ID"].Value) select x.Factura).SingleOrDefault());
                        int FolioFactura = Convert.ToInt32((from x in db.Facturacions where x.ID == IDfactura select x.Folio).SingleOrDefault());
                        string SerieFactura = (from x in db.Facturacions where x.ID == IDfactura select x.Serie).SingleOrDefault();

                        // Selecciona si la factura fue timbrada por Buzone o Finkok
                        int PrimerFolioTimbradoFinkok = 0;
                        PrimerFolioTimbradoFinkok = Extensiones.TimbradoWSfinkok.PrimerFolioFinkok(SerieFactura);
                        if (FolioFactura >= PrimerFolioTimbradoFinkok)
                            Extensiones.TimbradoWSfinkok.TimbrarCancelacion(IDfactura, 1, MainFrm);
                        else
                            Extensiones.TimbradoWSfinkok.TimbrarCancelacionExterna(IDfactura, 1, MainFrm);

                        CargarDataSets();
                    }
                }
                else
                    MessageBox.Show("Solicitud de cancelación ya atendida", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        void GenerarReporte(int NumReporte)
        {
            // 1 - Pendientes
            // 2 - Completadas
            // 3 - Cancelaciones

            string rutaFile = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rutaFile = saveFileDialog1.FileName;
                try
                {
                    string NomReporte = "";
                    switch (NumReporte)
                    {
                        case 1:
                            ultraGridExcelExporter1.Export(dgPendientes, rutaFile);
                            NomReporte = "Pendientes de Autorizar";
                            break;
                        case 2:
                            ultraGridExcelExporter1.Export(dgCompletadas, rutaFile);
                            NomReporte = "Completadas";
                            break;
                        case 3:
                            ultraGridExcelExporter1.Export(dgCancelaciones, rutaFile);
                            NomReporte = "Solicitudes de Cancelaciones";
                            break;

                        default:
                            return;
                    }
                    // Agrega los encabezados
                    Extensiones.Reportes.EditarEncabezados(rutaFile, DateTime.Now, DateTime.Now, true, "Reporte Facturacion " + NomReporte, 20);
                    System.Diagnostics.Process.Start(rutaFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        void EditarDatos()
        {
            if (dgCompletadas.ActiveRow.Cells["Status_str"].Value.ToString() == "En Proceso" || dgCompletadas.ActiveRow.Cells["Status_str"].Value.ToString() == "Error")
            {
                Facturacion frmEditar = new Facturacion(Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value), "Normal");
                if (this.MdiParent.MdiChildren.Where(p => p.Text == "Facturacion").Count() > 0)
                {
                    MessageBox.Show("Ya hay una solicitud de Factura abierta, cerrarla antes de Editar una factura diferente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmEditar = this.MdiParent.MdiChildren.Where(p => p.Text == "Facturacion").First() as Operaciones.CreditControl.Facturacion;
                    frmEditar.Select();
                }
                else
                {
                    frmEditar.MdiParent = this.MdiParent;
                    frmEditar.Show();
                }
            }
            else
            {
                MessageBox.Show("Solo se pueden editar facturas en status de En Proceso o Error", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void RegenerarPDF()
        {
            if (dgCompletadas.ActiveRow != null)
            {
                if (dgCompletadas.ActiveRow.Cells["Status_str"].Value.ToString() == "Factura Generada" || dgCompletadas.ActiveRow.Cells["Status_str"].Value.ToString() == "Recibos Generados")
                {
                    RegenerarPDF frmRegenerar = new RegenerarPDF(Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value), true);
                    frmRegenerar.ShowDialog();
                }
                else
                    MessageBox.Show("Esta factura aun no ha sido procesada o esta cancelada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void DescargarFactura()
        {
            Datasets.DBdocumentos.BDdocsTableAdapters.DocumentosFacturacionNuevoTableAdapter documentosFacturacionNuevoTableAdapter = new Datasets.DBdocumentos.BDdocsTableAdapters.DocumentosFacturacionNuevoTableAdapter();
            DataTable dtTemp = documentosFacturacionNuevoTableAdapter.GetDataByFolioSerie(dgCompletadas.ActiveRow.Cells["Folio"].Value.ToString(), dgCompletadas.ActiveRow.Cells["Serie"].Value.ToString());
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                DocumentosDB.ExtraerDocumentosFacturacionDB(Convert.ToInt32(dtTemp.Rows[i]["Factura"].ToString()), dtTemp.Rows[i]["NombreDocumento"].ToString(),
                    dtTemp.Rows[i]["Folio"].ToString(), dtTemp.Rows[i]["Serie"].ToString());
            }
            MessageBox.Show("Archivos extraidos con éxito", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SmartG-Documentos\");
        }

        void SolicitarCancelacion()
        {
            if (dgCompletadas.ActiveRow.Cells["Status_str"].Value.ToString() == "Cancelado")
            {
                MessageBox.Show("La factura ya esta Cancelada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
                        CancelacionFacturas frmCancelacion = new CancelacionFacturas(MainFrm, dgCompletadas.ActiveRow.Cells["Serie"].Value.ToString() + dgCompletadas.ActiveRow.Cells["Folio"].Value.ToString(), Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value.ToString()));
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
                        return;
                }
                //si no tiene se manda a llamar a la ventana con un 1
                else
                {
                    CancelacionFacturas frmCancelacion = new CancelacionFacturas(MainFrm, dgCompletadas.ActiveRow.Cells["Serie"].Value.ToString() + dgCompletadas.ActiveRow.Cells["Folio"].Value.ToString(), Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value.ToString()));
                    if (frmCancelacion.ShowDialog() == DialogResult.OK)
                        CargarDataSets();
                }
            }
            else // si ya hay una solicitud previa
            {
                //validamos que no tenga comprobantes de pago aplicados, si tiene se manda a llamar a la ventana de cancelaciones
                if ((from x in db.RecibosPagos where x.Facturacion == Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value) && x.StatusFacturacion.Status == "Aplicado" select x).ToArray().Count() > 0)
                {
                    if (MessageBox.Show("La factura ya cuenta con comprobantes de pago aplicados, ¿desea continuar el proceso de generacion de solicitud y creacion de nota de credito?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        CancelacionFacturas frmCancelacion = new CancelacionFacturas(MainFrm, dgCompletadas.ActiveRow.Cells["Serie"].Value.ToString() + dgCompletadas.ActiveRow.Cells["Folio"].Value.ToString(), Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value.ToString()));
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
                        return;

                }
                else // No tiene comprobantes
                {
                    CancelacionFacturas frmCancelacion = new CancelacionFacturas(MainFrm, dgCompletadas.ActiveRow.Cells["Serie"].Value.ToString() + dgCompletadas.ActiveRow.Cells["Folio"].Value.ToString(), Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value.ToString()));
                    if (frmCancelacion.ShowDialog() == DialogResult.OK)
                        CargarDataSets();
                }
            }
        }

        void BuscarRelacionados()
        {
            int IDFacturaSeleccionada = Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value);
            dbSmartGDataContext db = new dbSmartGDataContext();
            SmartG.Facturacion[] RelacionAbajo = (from x in db.Facturacions where x.ReferenciaFacCancelada == IDFacturaSeleccionada select x).ToArray();
            int? IDRelacionArriba = (from x in db.Facturacions where x.ID == IDFacturaSeleccionada select x.ReferenciaFacCancelada).SingleOrDefault();

            if (RelacionAbajo.Count() > 0 && IDRelacionArriba != null) // Tiene ambas relaciones
            {
                string RelacionArribaDesc = "";
                for (int i = 0; i < RelacionAbajo.Count(); i++)
                {
                    RelacionArribaDesc += RelacionAbajo[i].Serie + RelacionAbajo[i].Folio.ToString() + " " + RelacionAbajo[i].Poliza_str + ", " + RelacionAbajo[i].StatusFacturacion1.Status + ", " +
                        RelacionAbajo[i].MotivosCancelacion.Descripcion + Environment.NewLine;
                }
                string RelacionDesc = (from x in db.Facturacions where x.ID == IDRelacionArriba select (x.Serie + x.Folio.ToString() + " " + x.Poliza_str + ", " + x.StatusFacturacion1.Status + ", ")).SingleOrDefault();
                RelacionDesc += (from x in db.Facturacions where x.ID == IDFacturaSeleccionada select x.MotivosCancelacion.Descripcion).SingleOrDefault();

                MessageBox.Show("Se encontraron " + RelacionAbajo.Count() + " documentos que hacen referencia a este: " + Environment.NewLine +
                    Environment.NewLine + RelacionArribaDesc + Environment.NewLine + Environment.NewLine + "Ademas, este documento hace referencia a otro: " +
                    Environment.NewLine + Environment.NewLine + RelacionDesc, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (RelacionAbajo.Count() > 0 && IDRelacionArriba == null) // Solo relacion abajo
            {
                string RelacionArribaDesc = "";
                for (int i = 0; i < RelacionAbajo.Count(); i++)
                {
                    RelacionArribaDesc += RelacionAbajo[i].Serie + RelacionAbajo[i].Folio.ToString() + " " + RelacionAbajo[i].Poliza_str + ", " + RelacionAbajo[i].StatusFacturacion1.Status + ", " +
                        RelacionAbajo[i].MotivosCancelacion.Descripcion + Environment.NewLine;
                }
                MessageBox.Show("Se encontraron " + RelacionAbajo.Count() + " documentos que hacen referencia a este: " + Environment.NewLine +
                    Environment.NewLine + RelacionArribaDesc, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (RelacionAbajo.Count() == 0 && IDRelacionArriba != null) // Solo relacion arriba
            {
                string RelacionDesc = (from x in db.Facturacions where x.ID == IDRelacionArriba select (x.Serie + x.Folio.ToString() + " " + x.Poliza_str + ", " + x.StatusFacturacion1.Status + ", ")).SingleOrDefault();
                RelacionDesc += (from x in db.Facturacions where x.ID == IDFacturaSeleccionada select x.MotivosCancelacion.Descripcion).SingleOrDefault();
                MessageBox.Show("Este documento hace referencia a otro: " + Environment.NewLine + Environment.NewLine + RelacionDesc, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (RelacionAbajo.Count() == 0 && IDRelacionArriba == null) // No hay relacion
            {
                MessageBox.Show("Esta factura / nota de crédito no tiene relaciones registradas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        async void ReportesSaldosInsolutos()
        {
            if(MessageBox.Show("Este es un proceso lento, SmartG podria tardar entre 5 a 10 min en generar el reporte, desea continuar?","Mensaje",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Espera esperaFrm = new Espera();
                esperaFrm.Message = "Procesando Timbrado...";
                esperaFrm.Show();
                MainFrm.Enabled = false;
                MainFrm.Cursor = Cursors.WaitCursor;

                try
                {
                    await Task.Run(() => GenerarReporte());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un problema al generar el Reporte" + Environment.NewLine + "Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    MainFrm.Enabled = true;
                    MainFrm.Cursor = Cursors.Arrow;
                    esperaFrm.Close();
                }
            }
        }

        void GenerarReporte()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            try { dgCompletadas.DisplayLayout.Bands[0].Columns.Add("SaldoInsoluto"); } catch { }
            for (int i = 0; i < dgCompletadas.Rows.Count(); i++)
            {
                int IDfactura = Convert.ToInt32(dgCompletadas.Rows[i].Cells["ID"].Value);
                int MonedaFactura = Convert.ToInt32((from x in db.Facturacions where x.ID == IDfactura select x.Moneda).SingleOrDefault());

                decimal TotalFactura = Convert.ToDecimal((from x in db.Facturacions where x.ID == IDfactura select x.Total).SingleOrDefault());
                decimal tipoCambioFactura = Convert.ToDecimal((from x in db.Facturacions where x.ID == IDfactura select x.TipoCambio).SingleOrDefault());

                int IDstatusAplicado = (from x in db.StatusFacturacions where x.Status == "Aplicado" select x.ID).SingleOrDefault();
                int IDstatusFacGen = (from x in db.StatusFacturacions where x.Status == "Factura Generada" select x.ID).SingleOrDefault();
                int IDstatusRecGen = (from x in db.StatusFacturacions where x.Status == "Recibos Generados" select x.ID).SingleOrDefault();

                string MonedaAplicar = (from x in db.Monedas where x.ID == MonedaFactura select x.Abreviacion).SingleOrDefault();

                decimal MontoPagado = Convert.ToDecimal((from x in db.JournalDivisions
                                                         where x.RecibosPago.Facturacion == IDfactura &&
                                                                x.ComprobantesPago.Status == IDstatusAplicado
                                                         select x).ToArray().Sum(x => x.Monto_division));

                decimal MontoNCs = Convert.ToDecimal((from x in db.Facturacions
                                                      where
                            x.Serie == "NC" &&
                            x.ReferenciaFacCancelada == IDfactura &&
                            (x.StatusFacturacion == IDstatusFacGen || x.StatusFacturacion == IDstatusRecGen)
                                                      select x).ToArray().Sum(x => x.Total));

                decimal PendienteCobro = TotalFactura - MontoPagado - MontoNCs;
                dgCompletadas.Rows[i].Cells["SaldoInsoluto"].Value = PendienteCobro;

            }
            string rutaFile = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rutaFile = saveFileDialog1.FileName;
                ultraGridExcelExporter1.Export(dgCompletadas, rutaFile);
                // Agrega los encabezados
                Extensiones.Reportes.EditarEncabezados(rutaFile, DateTime.Now, DateTime.Now, true, "Reporte Facturacion - Saldo", 20);
                System.Diagnostics.Process.Start(rutaFile);
            }
        }

        void ConsultarSaldoInsoluto()
        {
            if (dgCompletadas.ActiveRow.Cells["Status_str"].Value.ToString() == "Factura Generada" || dgCompletadas.ActiveRow.Cells["Status_str"].Value.ToString() == "Recibos Generados")
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                int IDfactura = Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value);
                int MonedaFactura = Convert.ToInt32((from x in db.Facturacions where x.ID == IDfactura select x.Moneda).SingleOrDefault());

                decimal TotalFactura = Convert.ToDecimal((from x in db.Facturacions where x.ID == IDfactura select x.Total).SingleOrDefault());
                decimal tipoCambioFactura = Convert.ToDecimal((from x in db.Facturacions where x.ID == IDfactura select x.TipoCambio).SingleOrDefault());

                int IDstatusAplicado = (from x in db.StatusFacturacions where x.Status == "Aplicado" select x.ID).SingleOrDefault();
                int IDstatusFacGen = (from x in db.StatusFacturacions where x.Status == "Factura Generada" select x.ID).SingleOrDefault();
                int IDstatusRecGen = (from x in db.StatusFacturacions where x.Status == "Recibos Generados" select x.ID).SingleOrDefault();

                string MonedaAplicar = (from x in db.Monedas where x.ID == MonedaFactura select x.Abreviacion).SingleOrDefault();

                decimal MontoPagado = Convert.ToDecimal((from x in db.JournalDivisions
                                                         where x.RecibosPago.Facturacion == IDfactura &&
                                                                x.ComprobantesPago.Status == IDstatusAplicado
                                                         select x).ToArray().Sum(x => x.Monto_division));

                decimal MontoNCs = Convert.ToDecimal((from x in db.Facturacions
                                                      where
                            x.Serie == "NC" &&
                            x.ReferenciaFacCancelada == IDfactura &&
                            (x.StatusFacturacion == IDstatusFacGen || x.StatusFacturacion == IDstatusRecGen)
                                                      select x).ToArray().Sum(x => x.Total));

                decimal PendienteCobro = TotalFactura - MontoPagado - MontoNCs;

                MessageBox.Show(
                    "Factura:                                 " + (from x in db.Facturacions where x.ID == IDfactura select (x.Serie + x.Folio)).SingleOrDefault() +  Environment.NewLine +
                    "Moneda de la factura:         " + MonedaAplicar + Environment.NewLine +
                    "Total de la Factura:              " + TotalFactura.ToString("C2") + Environment.NewLine +
                    "Monto Pagado:                   " + MontoPagado.ToString("C2") + Environment.NewLine +
                    "Notas de crédito:                " + MontoNCs.ToString("C2") + Environment.NewLine +
                    "Pendiente de Cobro:          " + PendienteCobro.ToString("C2") + Environment.NewLine, 
                    "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Esta factura no ha sido procesada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // nombres y valores de todos los objetos que se encuentran en el formulario
        #region EventosForm

        public AdministracionFacturas(Form mainForm)
        {
            InitializeComponent();
            MainFrm = mainForm;
        }

        private void AdministracionFacturas_Load(object sender, EventArgs e)
        {
            CargarDataSets();
            cbParametro.SelectedIndex = 0;
            //Extensiones.Traduccion.traducirVentana(this, AdminFactTabControl, AdministracionFacToolBar);
        }

        private void ToolsBarAdminFacturas_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (dgPendientes.Rows.Count > 0)
            {
                for (int i = 0; i < dgPendientes.Rows.Count; i++)
                    dgPendientes.Rows[i].Update();
            }

            switch (e.Tool.Key)
            {
                // Solicitudes Pendientes

                case "btnRechazarSolicitud":
                    RechazarSolicitud();
                    break;

                case "btnEditarSolicitud":
                    EditarSolicitud();
                    break;

                case "btnActualizar":
                    CargarDataSets();
                    break;

                case "btnProcesarSeleccionadas":
                    ProcesarTimbrado();
                    break;

                case "btnGenerarReporte":
                    if (AdminFactTabControl.SelectedTab.Index == 0)
                        GenerarReporte(1);
                    else
                        GenerarReporte(3);
                    break;

                case "btnNuevaFactura":
                case "btnNuevaFacturaOpen":
                    Operaciones.CreditControl.Facturacion frmFact = new Operaciones.CreditControl.Facturacion(0, "Normal");
                    if (this.MdiChildren.Where(p => p.Text == "Facturacion").Count() > 0)
                    {
                        frmFact = this.MdiChildren.Where(p => p.Text == "Facturacion").First() as Operaciones.CreditControl.Facturacion;
                        frmFact.Select();
                    }
                    else
                    {
                        frmFact.MdiParent = MainFrm;
                        frmFact.Show();
                    }
                    break;

                case "btnNuevoRetenciones":
                    Retenciones frmRetenciones = new Retenciones(MainFrm);
                    frmRetenciones.ShowDialog();
                    break;

                // Base de Facturación

                case "btnCopiaRegistro":
                    CopiarRegistro();
                    break;

                case "btnReprocesar":
                    ReprocesarTimbrado();
                    break;

                case "btnGenerarRecibos":
                    if (dgCompletadas.ActiveRow.Cells["Status_str"].Value.ToString() == "Factura Generada" || dgCompletadas.ActiveRow.Cells["Status_str"].Value.ToString() == "Recibos Generados")
                    {
                        if (MessageBox.Show("Se generaran los recibos de la factura, continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Extensiones.Cobranza.GenerarRecibosPago(Convert.ToInt32(dgCompletadas.ActiveRow.Cells["ID"].Value), false);
                            MessageBox.Show("Proceso Completado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show("No se puden procesar esta factura debido a su status actual", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case "btnEditarRegistro":
                    EditarRegistro();
                    break;

                case "btnVerErrores":
                    VerErrores();
                    break;

                case "btnEditarDatos":
                    EditarDatos();
                    break;

                case "btnRegenerarFactura":
                    RegenerarPDF();
                    break;

                case "btnDescargarFactura":
                    DescargarFactura();
                    break;

                case "btnReporteSaldosInsolutos":
                    ReportesSaldosInsolutos();
                    break;                   

                // Cancelaciones
                case "btnProcesarCancelacion":
                    ProcesarCancelacion();
                    break;
            }
        }

        private void TabMisFacturas_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            AdministracionFacToolBar.Ribbon.Tabs[0].Groups["rbgSolicitudes"].Visible = false;
            AdministracionFacToolBar.Ribbon.Tabs[0].Groups["rgbBase"].Visible = false;
            AdministracionFacToolBar.Ribbon.Tabs[0].Groups["rgbCancelaciones"].Visible = false;
            AdministracionFacToolBar.Ribbon.Tabs[0].Groups["rgbCobranzaUniversal"].Visible = false;

            switch (AdminFactTabControl.SelectedTab.Index)
            {
                case 0:
                    AdministracionFacToolBar.Ribbon.Tabs[0].Groups["rbgSolicitudes"].Visible = true;
                    break;
                case 1:
                    AdministracionFacToolBar.Ribbon.Tabs[0].Groups["rgbBase"].Visible = true;
                    break;
                case 2:
                    AdministracionFacToolBar.Ribbon.Tabs[0].Groups["rgbCancelaciones"].Visible = true;
                    break;
                case 3:
                    AdministracionFacToolBar.Ribbon.Tabs[0].Groups["rgbCobranzaUniversal"].Visible = true;
                    break;

            }

        }

        private void ValidarCB(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
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

        private void dgCancelaciones_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            ProcesarCancelacion();
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
                case 0: //Cliente
                    this.checkFacturasTableAdapter.FillByXNomCliente(this.Basefacturacion.CheckFacturas, txtBusqueda.Text);
                    break;
                case 1: //rfc
                    this.checkFacturasTableAdapter.FillByXrfc(this.Basefacturacion.CheckFacturas, txtBusqueda.Text);
                    break;
                case 2: //poliza
                    this.checkFacturasTableAdapter.FillByXpoliza(this.Basefacturacion.CheckFacturas, txtBusqueda.Text);
                    break;
                case 3: //folio
                    int busqueda = 0;
                    if (int.TryParse(txtBusqueda.Text, out busqueda))
                    {
                        this.checkFacturasTableAdapter.FillByXfolio(this.Basefacturacion.CheckFacturas, busqueda);
                    }
                    else { MessageBox.Show("Valor invalido"); return; }
                    break;
                case 4: //uuid
                    this.checkFacturasTableAdapter.FillByUUID(this.Basefacturacion.CheckFacturas, txtBusqueda.Text);
                    break;
                case 5: //fechatimbrado
                    this.checkFacturasTableAdapter.FillByXfechaSolicitud(this.Basefacturacion.CheckFacturas, p1, p2);
                    break;

                case 6: //fechatimbrado
                    this.checkFacturasTableAdapter.FillByXfechaTimbrado(this.Basefacturacion.CheckFacturas, p1, p2);
                    break;

                case 7: //fechatimbrado
                    this.checkFacturasTableAdapter.FillByAuditNumber(this.Basefacturacion.CheckFacturas, txtBusqueda.Text);
                    break;
            }
            if (this.Basefacturacion.CheckFacturas.Count == 0)
                MessageBox.Show("No hay registros", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtBusqueda.Text != "")
            {
                btnBuscar_Click(null, null);
            }

        }

        private void cbParametro_ValueChanged(object sender, EventArgs e)
        {
            txtBusqueda.Visible = false;
            dateBusqueda.Visible = false;
            if (cbParametro.SelectedIndex == 5 || cbParametro.SelectedIndex == 6)
                dateBusqueda.Visible = true;
            else
                txtBusqueda.Visible = true;

        }

        private void btnExcelReporteJournal_Click(object sender, EventArgs e)
        {
            GenerarReporte(2);
        }

        private void dgPendientes_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            EditarSolicitud();
        }
        #endregion

        private void cms_dgCompletados_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (dgCompletadas.ActiveRow == null)
            {
                MessageBox.Show("No se ha seleccionado ningún registro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                switch (e.ClickedItem.Text)
                {
                    case "Descargar documentos de la Factura":
                        DescargarFactura();
                        break;

                    case "Ver Errores":
                        VerErrores();
                        break;

                    case "Regenerar PDF":
                        RegenerarPDF();
                        break;

                    case "Cancelar Documento":
                        SolicitarCancelacion();
                        break;

                    case "Buscar Documentos Relacionados":
                        BuscarRelacionados();
                        break;

                    case "Consultar Saldo Pendiente de Pago":
                        ConsultarSaldoInsoluto();
                        break;

                    case "Editar Status / Recibos":
                        EditarRegistro();
                        break;

                    case "Editar Factura":
                        EditarDatos();
                        break;               
                }
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

        private void cms_dgCancelaciones_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (dgCancelaciones.ActiveRow == null)
            {
                MessageBox.Show("No se ha seleccionado ningún registro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                switch (e.ClickedItem.Text)
                {
                    case "Cancelar Documento":
                        ProcesarCancelacion();
                        break;
                }
            }
        }

        private void cms_dgSolicitudes_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
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
                    case "Timbrar Documento":
                        ProcesarTimbrado();
                        break;
                    case "Rechazar Solicitud":
                        RechazarSolicitud();
                        break;
                    case "Editar Solicitud":
                        EditarSolicitud();
                        break;     
                }
            }
        }
    }
}
