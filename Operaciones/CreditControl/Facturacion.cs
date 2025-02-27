using Infragistics.Win;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Operaciones.CreditControl
{
    public partial class Facturacion : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // nombres y valores de todos los objetos que se encuentran en el formulario
        #region coleccion objetos

        #region primera tab datos generales CFDI
        // grpDatosCFDI         1) Datos Generales del CFDI
        // lbTipoDocumento      Tipo de Documento
        // lbSerie              Serie:
        // lbUsoCFDI             Uso del CFDI:
        // cbTipoDocumento 
        // cbSerie
        // cbUsoCFDI
        // lbCondicionesPago    Condiciones de Pago
        // lbFormaPago          Forma de Pago:
        // lbMetodoPago         Método de Pago:
        // cbCondicionesPago
        // cbFormaPago
        // cbMetodoPago

        // grpDatosPoliza       2) Datos de la Póliza
        // grpDatosGralPoliza   Datos Generales de la Póliza
        // lbPoliza             Poliza:
        // lbIniVig             Inicio de Vigencia:
        // lbFinVig             Fin de Vigencia:
        // lbRamo               Ramo de Seguro:
        // lbFechaEmision       Fecha de Emisión:
        // lbPlazoPago          Plazo de Pago:
        // lbLimitePago         Limite de Pago:
        // txtPoliza
        // dateIniVig
        // dateFinVig
        // cbRamo
        // dateFechaEmision
        // txtPlazoPago
        // dateLimitePago
        // grpParticipantes     Participantes
        // lbBroker             Agente de Seguros:
        // lbCoasegurador       Coasegurador Lider:
        // cbBroker
        // cbCoasegurador
        // lbParticipancion     % de Participación de XL Seguros:
        // txtParticipancionCoaseguro

        // grpDoctoRelacionado  3) Documento Relacionado
        // chkDoctoRelacionado  Esta factura tiene relación con otro documento ya emitido?
        // lbDoctoRelacionado   Documento Relacionado:
        // lbTipoRelacion       Tipo de Relación:
        // cbDoctoRelacionado
        // cbTipoRelacion

        #endregion
        #region segunda tab cliente
        // grpCliente           1) Cliente / Receptor de la Factura
        // lbCliente            Cliente / Receptor
        // lbDireccion          Dirección:
        // cbCliente
        // cbDireccion

        // grpCuentaPago        2) Cuenta de Pago (Cobranza Universal)
        // btnAsignarCuenta     Asignar una cuenta de Pago
        // lbCuentaMXN          Cuenta MXN:
        // lbSucursalMXN        Sucursal MXN: 
        // lbCuentaUSD          Cuenta USD:
        // lbSucursalUSD        Sucursal USD:
        // cbCuentaMXN
        // cbSucursalMXN
        // cbCuentaUSD
        // cbSucursalUSD
        #endregion
        #region tercera tab Conceptos
        // grpMoneda                1) Moneda de la Factura
        // lbMoneda                 Moneda:
        // lbTipoCambio             Tipo de Cambio:
        // cbMoneda
        // txtTipoCambio
        // btnConsultarTipoCambio   Consultar

        // grpConceptos             2) Conceptos a Facturar
        // dgConceptos
        // chkImpuestoRetenido      Aplicar Retención de Impuestos?
        // lbIVA                    % IVA:
        // lbSubtotal               Subtotal:
        // lbDescuentos             Descuentos:
        // lbImpuestoTransladado    Impuesto Transaladado:
        // lbImpuestoRetenido       Impuesto Retenido:
        // lbTotal                  Total a Facturar:
        // cbIVA
        // txtSubtotal
        // txtDescuentos
        // txtImpuestosTransladado
        // txtImpuestoRetenido 
        // txtTotal
        // grpConfirmacion          Confirmación para Timbrado
        // txtConfirmación
        #endregion
        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region variables
        #region primera tab datos generales CFDI
        int TipoDocumento;
        string vSerie;
        int UsoCFDI;
        int CondicionesPago;
        int FormaPago;
        int MetodoPago;
        string Poliza;
        DateTime IniVig;
        DateTime FinVig;
        int RamoSeguro;
        DateTime FechaEmision;
        int PlazoPago;
        DateTime LimitePago;
        int Broker;
        int Coasegurador;
        decimal PorcentajeCoaseguro;
        decimal PorcentajeBrokerage;
        bool chkDoctoRela;
        int idPolizaRelacion;
        int TipoRelacion;
        #endregion
        #region segunda tab Cliente
        int idCliente;
        int idDireccionCliente;
        int idCuentaPago;
        #endregion
        #region tercera tab Conceptos
        int Moneda;
        decimal TipoCambio;
        bool checkImpuestosRete;
        decimal Subtotal;
        decimal Descuentos;
        decimal ImpTransaladado;
        decimal ImpRetenido;
        decimal Total;
        string Confirmacion;

        bool iniciarValidaciones = false;
        public static DateTime NuevoIniVig;
        public static DateTime NuevoFinVig;

        #endregion

        // declaracion de variables que no habitan en los tabs
        int StatusFactura;
        int idFactura = 0;
        int claseDoc = 0;
        string IndicadorBase;
        public static string folioCancela;
        public static string serieCancela;
        int idEmpresa;
        bool Cambios = false;

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region MetodosProgramados

        void iniciarValores()
        {
            cbTipoDocumento.Text = "Factura";
            cbSerie.Text = "F";
            cbIVA.Text = "16%";
            cbCoasegurador.Text = "Sin Coaseguro";
            cbBroker.Text = "Sin Agente de Seguros";
            cbFormaPago.Text = "Por definir";
            cbMetodoPago.Text = "Pago en parcialidades o diferido";
            cbUsoCFDI.Text = "Gastos en general";
            cbTipoRelacion.Text = "Sin Especificar";
            txtPlazoPago.Value = 30;
            cbMoneda.Text = "Pesos Mexicanos";
            dateIniVig.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
            dateFinVig.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 59, 0);
            dateFechaEmision.Value = DateTime.Now;

        }

        void CargarDataSets(bool soloClientes)
        {
            this.clientesTableAdapter.Fill(this.facturacion1.Clientes);
            if (soloClientes)
                return;

            this.motivosCancelacionTableAdapter.Fill(this.facturacion2.MotivosCancelacion);
            try { this.facturacionTableAdapter.FillByUUIDnotNull(this.facturacion2._Facturacion); } catch { }
            this.coaseguradorasTableAdapter.Fill(this.facturacion2.Coaseguradoras);
            this.brokersTableAdapter.Fill(this.facturacion2.Brokers);
            this.metodoPagoTableAdapter.Fill(this.facturacion1.MetodoPago);
            this.formaPagoSATTableAdapter.Fill(this.facturacion1.FormaPagoSAT);
            this.formaPagoTableAdapter.Fill(this.facturacion1.FormaPago);
            this.usoCDFITableAdapter.Fill(this.facturacion1.UsoCDFI);
            this.tipoDocumentoTableAdapter.Fill(this.facturacion1.TipoDocumento);
            this.monedaTableAdapter.Fill(this.facturacion2.Moneda);
            this.ramosSegurosTableAdapter.Fill(this.facturacion2.RamosSeguros);
            this.claveUnidadSATTableAdapter.Fill(this.facturacion1.ClaveUnidadSAT);
            this.claveProductoSATTableAdapter.Fill(this.facturacion1.ClaveProductoSAT);
            this.cuentasBancariasTableAdapter.Fill(this.facturacion2.CuentasBancarias);
            this.iVATableAdapter.Fill(this.facturacion2.IVA);

            cbBroker.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            cbCoasegurador.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            cbDoctoRelacionado.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            cbTipoRelacion.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            cbCliente.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
        }

        void RegistroModificar()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();

            // Factura
            SmartG.Facturacion FacturaRecupera = (from x in db.Facturacions where x.ID == idFactura select x).SingleOrDefault();
            cbTipoDocumento.Value = FacturaRecupera.TipoDocumento;
            cbSerie.Text = FacturaRecupera.Serie;
            cbFormaPago.Value = FacturaRecupera.FormaPagoSAT;
            if (FacturaRecupera.CondicionesPago != null) cbCondicionesPago.Value = FacturaRecupera.CondicionesPago;
            if (FacturaRecupera.MetodoPago != null) cbMetodoPago.Value = FacturaRecupera.MetodoPago;
            cbUsoCFDI.Value = FacturaRecupera.UsoCDFI;
            txtPlazoPago.Value = FacturaRecupera.Plazo;
            dateLimitePago.Value = FacturaRecupera.LimitePago;
            txtConfirmación.Text = FacturaRecupera.Confirmacion;
            if (FacturaRecupera.Cliente != null) cbCliente.Value = FacturaRecupera.Cliente;
            if (FacturaRecupera.ClienteDireccion != null)
            {
                this.clientesDireccionesTableAdapter.FillByCliente(this.facturacion1.ClientesDirecciones, Convert.ToInt32(cbCliente.Value));
                cbDireccion.Value = FacturaRecupera.ClienteDireccion;
            }
            if  (FacturaRecupera.ClienteCuentaBancaria != null)
            {
                cbCuentaMXN.Value = FacturaRecupera.ClienteCuentaBancaria;
                cbCuentaUSD.Value = FacturaRecupera.ClienteCuentaBancaria;
                cbSucursalMXN.Value = FacturaRecupera.ClienteCuentaBancaria;
                cbSucursalUSD.Value = FacturaRecupera.ClienteCuentaBancaria;
            }
            txtTipoCambio.Value = FacturaRecupera.TipoCambio;
            if (FacturaRecupera.Moneda != null) cbMoneda.Value = FacturaRecupera.Moneda;
            txtSubtotal.Value = FacturaRecupera.Subtotal;
            txtDescuentos.Value = FacturaRecupera.Descuentos;
            txtImpuestosTransladado.Value = FacturaRecupera.ImpuestosTransladados;
            txtImpuestoRetenido.Value = FacturaRecupera.ImpuestosRetenidos;
            txtTotal.Value = FacturaRecupera.Total;
            txtNombreAnexo.Text = FacturaRecupera.NombreAnexo;
            if (FacturaRecupera.RamoSeguro != null) cbRamo.Value = FacturaRecupera.RamoSeguro;
            if (FacturaRecupera.ReferenciaFacCancelada != null)
            {
                cbDoctoRelacionado.Value = FacturaRecupera.ReferenciaFacCancelada;
                chkDoctoRelacionado.Checked = true;
            }
            cbTipoRelacion.Value = FacturaRecupera.ConceptoCancelacion;
            txtPoliza.Value = FacturaRecupera.Poliza_str;
            dateIniVig.Value = FacturaRecupera.iniVig;
            dateFinVig.Value = FacturaRecupera.finVig;
            dateFechaEmision.Value = Convert.ToDateTime(FacturaRecupera.LimitePago).AddDays(-Convert.ToInt32(FacturaRecupera.Plazo));
            txtAuditNumber.Text = FacturaRecupera.AuditNumber;
            cbIVA.Value = FacturaRecupera.IVA;
            if (cbIVA.Text == "") cbIVA.Text = "16%";

            // Conceptos
            SmartG.FacturacionConcepto[] FacturaRecuperadaConceptos = (from x in db.FacturacionConceptos where x.Facturacion == idFactura select x).ToArray();
            if(FacturaRecuperadaConceptos.Count() > 0)
            {
                dsConceptos.Rows.Clear();
                for (int i = 0; i < FacturaRecuperadaConceptos.Count(); i++)
                {
                    dsConceptos.Rows.Add(new object[] {
                        FacturaRecuperadaConceptos[i].ClaveProductoSAT,
                        FacturaRecuperadaConceptos[i].ClaveUnidadSAT,
                        FacturaRecuperadaConceptos[i].Cantidad,
                        FacturaRecuperadaConceptos[i].Identificacion,
                        FacturaRecuperadaConceptos[i].Descripcion,
                        FacturaRecuperadaConceptos[i].Precio,
                        FacturaRecuperadaConceptos[i].Total,
                        FacturaRecuperadaConceptos[i].Descuento });
                    if (claseDoc == 1)
                        break;
                }
            }

            // Participantes
            SmartG.FacturaParticipante FacturaRecuperadaParticipante = (from x in db.FacturaParticipantes where x.Factura == idFactura select x).SingleOrDefault();
            if (FacturaRecuperadaParticipante != null)
            {
                if(FacturaRecuperadaParticipante.Coasegurador != null) cbCoasegurador.Value = FacturaRecuperadaParticipante.Coasegurador;
                if(FacturaRecuperadaParticipante.PorcentajeCoaseguroEmpresa != null) txtParticipancionCoaseguro.Value = FacturaRecuperadaParticipante.PorcentajeCoaseguroEmpresa;
                if(FacturaRecuperadaParticipante.Broker != null) cbBroker.Value = FacturaRecuperadaParticipante.Broker;
                if (FacturaRecuperadaParticipante.PorcentajeBrokerage != null) txtBrokerage.Value = FacturaRecuperadaParticipante.PorcentajeBrokerage;
            }

            if (claseDoc == 1) // nota de credito generada desde cancelacion y comprobantes generados
            {
                // FIX
            }
            if (IndicadorBase == "Emitido")
            {
                idFactura = 0;
            }
            Cambios = false;
        }

        void CalcularMontos()
        {
            //Subtotal = 0;
            //Descuentos = 0;
            //ImpTransaladado = 0;
            //ImpRetenido = 0;
            //Total = 0;

            //dbSmartGDataContext db = new dbSmartGDataContext();
            //decimal IVAdecimal = Convert.ToDecimal((from x in db.IVAs where x.ID == Convert.ToInt32(cbIVA.Value) select x.IVAdecimal).SingleOrDefault());
            //foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in dgConceptos.Rows)
            //{
            //    if (row.Cells["Descripción"].Value.ToString() == "") continue;
            //    try { row.Cells["Importe"].Value = Convert.ToDecimal(row.Cells["Precio Unitario"].Value) * Convert.ToInt32(row.Cells["Cantidad"].Value); } catch { }
            //    try { Subtotal += Convert.ToDecimal(row.Cells["Importe"].Value); } catch { }
            //    try { Descuentos += Convert.ToDecimal(row.Cells["Descuento"].Value); } catch { }
            //}

            //ImpTransaladado = (Subtotal - Descuentos) * IVAdecimal;

            //if (chkImpuestoRetenido.Checked)
            //{
            //    decimal subimporte = Subtotal - Descuentos;
            //    decimal tIva = ImpTransaladado;

            //    decimal ISR = subimporte * 0.10M;
            //    decimal rteIVA = tIva * 0.66666666666666666667M;
            //    ImpRetenido = ISR + rteIVA;
            //}

            //Total = Subtotal - Descuentos + ImpTransaladado - ImpRetenido;

            //txtSubtotal.Value = Math.Round(Subtotal, 2);
            //txtDescuentos.Value = Math.Round(Descuentos, 2);
            //txtImpuestosTransladado.Value = Math.Round(ImpTransaladado, 2);
            //txtImpuestoRetenido.Value = Math.Round(ImpRetenido, 2);
            //txtTotal.Value = Math.Round(Total,2);
        }

        void CargarVariables()
        {
            TipoDocumento = Convert.ToInt32(cbTipoDocumento.Value);
            vSerie = cbSerie.Text;
            UsoCFDI = Convert.ToInt32(cbUsoCFDI.Value);
            CondicionesPago = Convert.ToInt32(cbCondicionesPago.Value);
            FormaPago = Convert.ToInt32(cbFormaPago.Value);
            MetodoPago = Convert.ToInt32(cbMetodoPago.Value);

            Poliza = txtPoliza.Text;
            IniVig = Convert.ToDateTime(dateIniVig.Value);
            FinVig = Convert.ToDateTime(dateFinVig.Value);
            RamoSeguro = Convert.ToInt32(cbRamo.Value);
            FechaEmision = Convert.ToDateTime(dateFechaEmision.Value);
            PlazoPago = Convert.ToInt32(txtPlazoPago.Value);
            LimitePago = Convert.ToDateTime(dateLimitePago.Value);
            Broker = Convert.ToInt32(cbBroker.Value);
            Coasegurador = Convert.ToInt32(cbCoasegurador.Value);
            PorcentajeCoaseguro = Convert.ToDecimal(txtParticipancionCoaseguro.Value);
            PorcentajeBrokerage = Convert.ToDecimal(txtBrokerage.Value);

            chkDoctoRela = chkDoctoRelacionado.Checked;
            if (cbDoctoRelacionado.Text != "")
                idPolizaRelacion = Convert.ToInt32(cbDoctoRelacionado.Value);
            else
                idPolizaRelacion = 0;
            TipoRelacion = Convert.ToInt32(cbTipoRelacion.Value);

            idCliente = Convert.ToInt32(cbCliente.Value);
            idDireccionCliente = Convert.ToInt32(cbDireccion.Value);

            idCuentaPago = Convert.ToInt32(cbCuentaMXN.Value);
            Moneda= Convert.ToInt32(cbMoneda.Value);
            TipoCambio= Convert.ToDecimal(txtTipoCambio.Value);
            checkImpuestosRete = chkImpuestoRetenido.Checked;
            Subtotal= Convert.ToDecimal(txtSubtotal.Value);
            Descuentos= Convert.ToDecimal(txtDescuentos.Value);
            ImpTransaladado= Convert.ToDecimal(txtImpuestosTransladado.Value);
            ImpRetenido= Convert.ToDecimal(txtImpuestoRetenido.Value);
            Total= Convert.ToDecimal(txtTotal.Value);
            Confirmacion = txtConfirmación.Text;

            dbSmartGDataContext db = new dbSmartGDataContext();
            idEmpresa = (from x in db.EmpresaDetalles where x.Principal == true select x.ID).FirstOrDefault();
            StatusFactura = (from x in db.StatusFacturacions where x.Status == "No solicitado" select x.ID).FirstOrDefault();
        }

        void GuardarAvances()
        {
            if (dgConceptos.Rows.Count > 0)
            {
                for (int i = 0; i < dgConceptos.Rows.Count; i++)
                    dgConceptos.Rows[i].Update();
            }

            CargarVariables();
            if (!ValidacionNumPoliza(Poliza)) return;

            dbSmartGDataContext db = new dbSmartGDataContext();
            SmartG.Facturacion newFactura;
            if (idFactura == 0)
                newFactura = new SmartG.Facturacion();
            else
                newFactura = (from x in db.Facturacions where x.ID == idFactura select x).SingleOrDefault();

            newFactura.TipoDocumento = TipoDocumento;
            newFactura.Serie = vSerie;
            newFactura.FormaPagoSAT = FormaPago;
            if (CondicionesPago != 0) newFactura.CondicionesPago = CondicionesPago;
            if (MetodoPago != 0) newFactura.MetodoPago = MetodoPago;
            newFactura.UsoCDFI = UsoCFDI;
            newFactura.DireccionCompañia = idEmpresa;
            newFactura.Plazo = PlazoPago;
            newFactura.LimitePago = LimitePago;
            newFactura.Confirmacion = Confirmacion;
            if (idCliente != 0) newFactura.Cliente = idCliente;
            newFactura.NombreAnexo = txtNombreAnexo.Text;
            if (idDireccionCliente != 0) newFactura.ClienteDireccion = idDireccionCliente;
            if (idCuentaPago != 0) newFactura.ClienteCuentaBancaria = idCuentaPago;
            newFactura.TipoCambio = TipoCambio;
            if(Moneda != 0) newFactura.Moneda = Moneda;
            newFactura.Subtotal = Math.Round(Subtotal,2);
            newFactura.Descuentos = Math.Round(Descuentos,2);
            newFactura.ImpuestosTransladados = Math.Round(ImpTransaladado,2);
            newFactura.ImpuestosRetenidos = Math.Round(ImpRetenido,2);
            newFactura.Total = Math.Round(Total,2);

            int StatusSolicitado = (from x in db.StatusFacturacions where x.Status == "Solicitado" select x.ID).SingleOrDefault();
            if (newFactura.StatusFacturacion == StatusSolicitado)
            {
                if (!ValidacionInformacion()) return;
                newFactura.StatusFacturacion = StatusSolicitado;
            }
            else
                newFactura.StatusFacturacion = StatusFactura;

            if (newFactura.UsuarioSolicitud == null) newFactura.UsuarioSolicitud = Program.Globals.UserID;

            if (RamoSeguro != 0) newFactura.RamoSeguro = RamoSeguro;

            if (idPolizaRelacion != 0)
                newFactura.ReferenciaFacCancelada = idPolizaRelacion;
            else
                newFactura.ReferenciaFacCancelada = null;
               
            newFactura.ConceptoCancelacion = TipoRelacion;
            newFactura.Poliza_str = Poliza;
            newFactura.iniVig = IniVig;
            newFactura.finVig = FinVig;
            newFactura.AuditNumber = txtAuditNumber.Text;
            newFactura.IVA = Convert.ToInt32(cbIVA.Value);
            if (idFactura == 0)
                db.Facturacions.InsertOnSubmit(newFactura);
            db.SubmitChanges();
            idFactura = newFactura.ID;

            // Borra Participantes
            FacturaParticipante[] aBorrarPar = (from x in db.FacturaParticipantes where x.Factura == idFactura select x).ToArray();
            if (aBorrarPar.Count() > 0)
            {
                db.FacturaParticipantes.DeleteAllOnSubmit(aBorrarPar);
                db.SubmitChanges();
            }

            // Agrega Participantes
            SmartG.FacturaParticipante newFacturaPart;
            newFacturaPart = new SmartG.FacturaParticipante();
            newFacturaPart.Factura = idFactura;
            newFacturaPart.Coasegurador = Coasegurador;
            newFacturaPart.PorcentajeCoaseguroEmpresa = PorcentajeCoaseguro;
            newFacturaPart.Broker = Broker;
            newFacturaPart.PorcentajeBrokerage = PorcentajeBrokerage;
            db.FacturaParticipantes.InsertOnSubmit(newFacturaPart);
            db.SubmitChanges();

            // Borra Conceptos
            FacturacionConcepto[] aBorrarCon = (from x in db.FacturacionConceptos where x.Facturacion == idFactura select x).ToArray();
            if (aBorrarCon.Count() > 0)
            {
                db.FacturacionConceptos.DeleteAllOnSubmit(aBorrarCon);
                db.SubmitChanges();
            }

            // Agrega conceptos
            int Count = 0;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in dgConceptos.Rows)
            {
                if (row.Cells["Descripción"].Value.ToString() == "")
                    continue;
                try
                {

                    int idProducto = 0;
                    int.TryParse(row.Cells["Clave de Producto"].Value.ToString(), out idProducto);
                    if (idProducto == 0)
                        idProducto = (from x in db.ClaveProductoSATs where x.Descripcion == dgConceptos.DisplayLayout.Bands[0].Columns["Clave de Producto"].NullText.ToString() select x.ID).SingleOrDefault();

                    int idUnidad = 0;
                    int.TryParse(row.Cells["Clave de Unidad"].Value.ToString(), out idUnidad);
                    if (idUnidad == 0)
                        idUnidad = (from x in db.ClaveUnidadSATs where x.Descripciion == dgConceptos.DisplayLayout.Bands[0].Columns["Clave de Unidad"].NullText.ToString() select x.ID).SingleOrDefault();

                    SmartG.FacturacionConcepto newFacturaConce = new FacturacionConcepto();
                    newFacturaConce.Facturacion = idFactura;
                    newFacturaConce.ClaveProductoSAT = idProducto;
                    newFacturaConce.ClaveUnidadSAT = idUnidad;
                    newFacturaConce.Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    newFacturaConce.Identificacion = row.Cells["Identificación"].Value.ToString();
                    newFacturaConce.Descripcion = row.Cells["Descripción"].Value.ToString();
                    newFacturaConce.Precio = Math.Round(Convert.ToDecimal(row.Cells["Precio Unitario"].Value),2);
                    newFacturaConce.Total = Math.Round(Convert.ToDecimal(row.Cells["Importe"].Value), 2);
                    newFacturaConce.Descuento = Math.Round(Convert.ToDecimal(row.Cells["Descuento"].Value), 2);
                    db.FacturacionConceptos.InsertOnSubmit(newFacturaConce);
                    db.SubmitChanges();
                    Count++;
                }   catch { }
            }

            if (Count == 0)
            {
                MessageBox.Show("No se han ingresados conceptos para esta factura, se han guardado los cambios, pero no se enviara para su procesamiento. " +
                        "ID de la operación: " + idFactura, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //MessageBox.Show("Registro guardado, ID: " + idFactura.ToString(), "Guardado,", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Cambios = false;
        }

        void EnviarSolicitud()
        {
            if (!ValidacionInformacion()) return;
            GuardarAvances();
            dbSmartGDataContext db = new dbSmartGDataContext();

            // Verificacion Cliente Aprobado
            bool aprobado = Convert.ToBoolean((from x in db.Clientes where x.ID == Convert.ToInt32(cbCliente.Value) select x.Aprobado).SingleOrDefault());
            if (!aprobado)
            {
                MessageBox.Show("El cliente " + cbCliente.Text + " no se encuentra autorizado para facturación, solicite la activación del cliente con su administrador", 
                    "Error autorización cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            // Actualiza la solicitud a solicitada
            SmartG.Facturacion FactActualizar = (from x in db.Facturacions where x.ID == idFactura select x).SingleOrDefault();
            FactActualizar.StatusFacturacion = (from x in db.StatusFacturacions where x.Status == "Solicitado" select x.ID).SingleOrDefault();
            FactActualizar.FechaSolicitud = DateTime.Now;
            db.SubmitChanges();
            MessageBox.Show("Solicitud completada y enviada para procesamiento.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Cambios = false;
            this.Close();
        }

        bool ValidacionInformacion()
        {
            CargarVariables();
            dbSmartGDataContext db = new dbSmartGDataContext();
            // tab 1 - Datos Generales
            if (cbTipoDocumento.Text == "Factura" && cbSerie.Text == "NC")
            {
                MessageBox.Show("Error: El tipo de Serie no coincide con el tipo de Documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            if (!ValidacionVacio(cbCondicionesPago, "Condiciones de Pago")) { return false; }
            if (!ValidacionVacio(cbMetodoPago, "Método de Pago")) { return false; }
            if (!ValidacionVacio(cbFormaPago, "Forma de Pago")) { return false; }
            if (!ValidacionVacio(cbUsoCFDI, "Uso del CDFI")) { return false; }
            if (!ValidacionVacio(txtPoliza, "Numero de Poliza")) { return false; }
            if (Convert.ToDateTime(dateIniVig.Value) >= Convert.ToDateTime(dateFinVig.Value))
                { MessageBox.Show("Las fechas de vigencia no son correctas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (!ValidacionVacio(txtPlazoPago, "Plazo de Pago")) { return false; }
            if (!ValidacionVacio(cbRamo, "Ramo de Seguro")) { return false; }
            if (!ValidacionVacio(txtAuditNumber, "Genius Audit Number")) { return false; }
            //if((from x in db.Facturacions where x.AuditNumber == txtAuditNumber.Text && x.ID != idFactura select x).ToArray().Count() > 0)
            //    { MessageBox.Show("El Genius Audit Number ya fue registrado en otra operación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }

            if (Convert.ToDecimal(txtParticipancionCoaseguro.Value) == 0)
                { MessageBox.Show("No se ingreso un % de Coaseguro para XL México", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }

            if (!ValidacionVacio(cbBroker, "Agente o Broker")) { return false; }

            if (!(cbBroker.Text == "Sin Agente de Seguros" || (cbBroker.Text == "Directo")))
            {
               if(Convert.ToDecimal(txtBrokerage.Value) == 0)
                {
                    if(MessageBox.Show("No se ha ingresado un valor para el broker " + cbBroker.Text + ", desea continuar con un brokerage de 0%", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)== DialogResult.No)
                        return false;
                }
            }                        

            int Idtemp = 0;
            try { Idtemp = Convert.ToInt32(cbDoctoRelacionado.Value); } catch { }
            if (Idtemp > 0)
            {
                if (cbTipoRelacion.Text == "Sin Especificar")
                {
                    MessageBox.Show("Se indico un documento relacionado para esta factura, pero no se ingreso un Motivo para el mismo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // tab 2 - Cliente
            if (!ValidacionVacio(cbCliente, "Cliente")) { return false; }
            if (!ValidacionVacio(cbDireccion, "Direccion del Cliente")) { return false; }
            if (!ValidacionVacio(cbCuentaMXN, "Asignación de cuenta Bancaria")) { return false; }

            // tab 3 - Conceptos
            if (!ValidacionVacio(txtTipoCambio, "Tipo de Cambio")) { return false; }
            if (!ValidacionVacio(cbMoneda, "Moneda")) { return false; }
            decimal tipocambio = 0; decimal.TryParse(txtTipoCambio.Value.ToString(), out tipocambio);
            if (cbMoneda.Text == "Pesos Mexicanos" && tipocambio != 1)
            {
                MessageBox.Show("Error: Se ha seleccionado Moneda: MXN, pero el tipo de cambio es diferente a 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            if (cbMoneda.Text == "Dólares Estadounidenses" && tipocambio <= 1)
            {
                MessageBox.Show("Error: Se ha seleccionado Moneda: USD, pero el tipo de cambio es igual o menor a 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            if (dgConceptos.Rows.Count == 0)
            {
                MessageBox.Show("Error: No se han ingresado conceptos a la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }

            //var conteo = (from x in db.FacturacionConceptos where idFactura == x.Facturacion select x);
            //if (conteo.Count() == 0) { MessageBox.Show("No se han encontrado conceptos/productos para esta transacción en la base de datos, favor de contactar con soporte técnico"); return false; }

            if (Convert.ToDecimal(txtTotal.Value) <= 0) { MessageBox.Show("El total de la factura es incorrecto, revisar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            bool valClaveProduto = false;
            for (int i = 0; i < dgConceptos.Rows.Count ; i++)
            {
                if (dgConceptos.Rows[i].Cells["Clave de Producto"].Value.ToString() == "01010101") { valClaveProduto = true; }
            }
            if (valClaveProduto == true)
            {
                if (MessageBox.Show("Alguno de los conceptos ingresados fue colocado con la clave de unidad generica \" 01010101 - No existe en el el catalogo\"" +
                    Environment.NewLine + Environment.NewLine + "Continuar con la solicitud de la factura?",
                    "Mensaje", MessageBoxButtons.YesNo) == DialogResult.No) { return false; }
            }

            // Valida que el monto de la NC no deje la factura por debajo de cero

            if(Idtemp > 0 && cbSerie.Text == "NC")
            {
                // Calcula Saldos
                int MonedaFactura = Convert.ToInt32((from x in db.Facturacions where x.ID == Idtemp select x.Moneda).SingleOrDefault());

                decimal TotalFactura = Convert.ToDecimal((from x in db.Facturacions where x.ID == Idtemp select x.Total).SingleOrDefault());
                decimal tipoCambioFactura = Convert.ToDecimal((from x in db.Facturacions where x.ID == Idtemp select x.TipoCambio).SingleOrDefault());

                int IDstatusAplicado = (from x in db.StatusFacturacions where x.Status == "Aplicado" select x.ID).SingleOrDefault();
                int IDstatusFacGen = (from x in db.StatusFacturacions where x.Status == "Factura Generada" select x.ID).SingleOrDefault();
                int IDstatusRecGen = (from x in db.StatusFacturacions where x.Status == "Recibos Generados" select x.ID).SingleOrDefault();

                string MonedaAplicar = (from x in db.Monedas where x.ID == MonedaFactura select x.Abreviacion).SingleOrDefault();

                decimal MontoPagado = Convert.ToDecimal((from x in db.JournalDivisions
                                                         where x.RecibosPago.Facturacion == Idtemp &&
                                                                x.ComprobantesPago.Status == IDstatusAplicado
                                                         select x).ToArray().Sum(x => x.Monto_division));

                decimal MontoNCs = Convert.ToDecimal((from x in db.Facturacions
                                                      where
                            x.Serie == "NC" &&
                            x.ReferenciaFacCancelada == Idtemp &&
                            (x.StatusFacturacion == IDstatusFacGen || x.StatusFacturacion == IDstatusRecGen)
                                                      select x).ToArray().Sum(x => x.Total));

                decimal PendienteCobro = TotalFactura - MontoPagado - MontoNCs;

                if(PendienteCobro - Total < 0)
                {
                    if (MessageBox.Show("La factura a la cual se hace referencia no cuenta con saldo deudor suficiente para ingresar esta nota de crédito." + Environment.NewLine + Environment.NewLine +
                    "Factura:                                 " + (from x in db.Facturacions where x.ID == Idtemp select (x.Serie + x.Folio)).SingleOrDefault() + Environment.NewLine +
                    "Moneda de la factura:         " + MonedaAplicar + Environment.NewLine +
                    "Total de la Factura:              " + TotalFactura.ToString("C2") + Environment.NewLine +
                    "Monto Pagado:                   " + MontoPagado.ToString("C2") + Environment.NewLine +
                    "Notas de crédito:                " + MontoNCs.ToString("C2") + Environment.NewLine +
                    "Pendiente de Cobro:          " + PendienteCobro.ToString("C2") + Environment.NewLine + Environment.NewLine +
                    "Nota de Crédito actual:       " + Total.ToString("C2") + Environment.NewLine +
                    "Saldo posterior de la factura:   " + (PendienteCobro - Total).ToString("C2") + Environment.NewLine + Environment.NewLine + "Desea continuar con la solicitud de todos modos?",
                    "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                        return false;
                }
            }
            return true;
        }

        bool ValidacionNumPoliza(string Poliza_str)
        {
            string pol_formato = "El numero de Poliza no tiene el formato correcto. Apegarse a la siguiente estructura: " + Environment.NewLine + Environment.NewLine +
                        "Logitud Total: 15 Caracteres" + Environment.NewLine +
                        "1: Primeros 2 Caracteres (Pais): MX o GB " + Environment.NewLine +
                        "2: Siguientes 8 Caracteres (Num Seguimiento)" + Environment.NewLine +
                        "3: Siguientes 2 Caracteres (Linea de Negocio): PR, LI, MA, etc." + Environment.NewLine +
                        "4: Siguientes 2 Caracteres (Año de emisión)" + Environment.NewLine +
                        "5: Ultimo Caracter (Numero de polizas en el año): A, B o C" + Environment.NewLine + Environment.NewLine;

            if (Poliza_str.Length != 15)
            {
                MessageBox.Show(pol_formato + "Error en longitud, debe contener 15 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string pol_s1 = Poliza_str.Substring(0, 2);
            string pol_s2 = Poliza_str.Substring(2, 8);
            string pol_s3 = Poliza_str.Substring(10, 2);
            string pol_s4 = Poliza_str.Substring(12, 2);
            string pol_s5 = Poliza_str.Substring(14, 1);

            //Validacion s1 
            if (pol_s1 != "MX")
            { MessageBox.Show(pol_formato + "Error en seccion 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            //Validacion s2
            int numero; bool conver = int.TryParse(pol_s2, out numero);
            if (conver == false) { MessageBox.Show(pol_formato + "Error en Seccion 2"); return false; }
            //Validacion s3
            string[] lobs_code = { "PR", "LI", "DO", "EO", "BL", "CR", "CA", "MA", "SP", "AV" };
            bool veri_s3 = false;
            foreach (var item in lobs_code)
            {
                if (pol_s3 == item)
                {
                    veri_s3 = true;
                }
            }
            if (veri_s3 == false) { MessageBox.Show(pol_formato + "Error en Seccion 3", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            //Validacion s4
            int numero2; bool conver2 = int.TryParse(pol_s4, out numero2);
            if (conver2 == false) { MessageBox.Show(pol_formato + "Error en Seccion 4", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            //Validacion s5
            if (pol_s5 != "A")
            {
                if (pol_s5 != "B")
                {
                    if (pol_s5 != "C")
                    { MessageBox.Show(pol_formato + "Error en seccion 5", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
                }
            }
            return true;
        }

        void CambiosEnDatos()
        {
            Cambios = true;
        }

        private bool ValidacionVacio(Control ctr, string nomCampo)
        {
            if (ctr.Text == "")
            {
                MessageBox.Show("Error de Validación. el campo " + nomCampo + " no puede estar vacio", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        void AbrirRecibosEspeciales()
        {
            if (idFactura == 0)
            {
                cbCondicionesPago.SelectedIndex = 0;
                return;
            }

            if( Convert.ToDateTime( dateIniVig.Value) >= Convert.ToDateTime(dateFinVig.Value))
            {
                MessageBox.Show("Las fechas de inicio y fin de vigencia de la poliza no son correctas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cbCondicionesPago.SelectedIndex = 0;
                return;
            }

            if (Convert.ToDecimal( txtTotal.Value) == 0)
            {
                MessageBox.Show("Agregue primero los valores de conceptos a la solicitud de factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cbCondicionesPago.SelectedIndex = 0;
                return;
            }

            RecibosPagoEdicion frmEditarRecibos = new RecibosPagoEdicion(idFactura);
            if(frmEditarRecibos.ShowDialog() == DialogResult.Yes)
            {
                dateIniVig.Value = NuevoIniVig;
                dateFinVig.Value = NuevoFinVig;
            }
            else
                cbCondicionesPago.SelectedIndex = 0;
        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region EventosForm

        public Facturacion(int ID, string Indicadorbase, int tipoDoc = 0)
        {
            InitializeComponent();
            idFactura = ID;
            IndicadorBase = Indicadorbase;
            claseDoc = tipoDoc;
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            CargarDataSets(false);
            iniciarValores();

            // Recuperacion de Registros
            if (idFactura != 0 || IndicadorBase == "Emitido")
            {
                RegistroModificar();
            }

            if(Program.Globals.TipoUsuario == "Administrador" || Program.Globals.TipoUsuario == "Credit Control" )
            {
                //chkDoctoRelacionado.Enabled = true;
                grpConfirmacion.Visible = true;
                chkImpuestoRetenido.Visible = true;
                txtAuditNumEco.Visible = true;
            }

            //Extensiones.Traduccion.traducirVentana(this,tabControlFacturacion,ToolsBarFacturacion);
            iniciarValidaciones = true;
        }

        private void cb_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            try
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
            catch
            {
                Infragistics.Win.UltraWinGrid.UltraCombo cb = (Infragistics.Win.UltraWinGrid.UltraCombo)sender;

                if (cb.Rows.Count > 0)
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
        }

        private void chkDoctoRelacionado_CheckedChanged(object sender, EventArgs e)
        {
            if(chkDoctoRelacionado.Checked)
            {
                cbDoctoRelacionado.Enabled = true;
                cbTipoRelacion.Enabled = true;
            }
            else
            {
                cbDoctoRelacionado.Enabled = false;
                cbTipoRelacion.Enabled = false;
                cbDoctoRelacionado.Text = "";
            }
        }

        private void dgConceptos_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if(e.Cell.Column.Header.Caption == "Clave de Producto")
            {
                if(dgConceptos.Rows[e.Cell.Row.Index].Cells["Descripción"].Value.ToString() == "" && dgConceptos.Rows[e.Cell.Row.Index].Cells["Identificación"].Value.ToString() == "")
                {
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    string Concepto = (from x in db.ClaveProductoSATs where x.ID == Convert.ToInt32(dgConceptos.Rows[e.Cell.Row.Index].Cells["Clave de Producto"].Value) select x.Descripcion).SingleOrDefault();
                    dgConceptos.Rows[e.Cell.Row.Index].Cells["Descripción"].Value = Concepto;

                    if (Concepto == "Recargo por Pago fraccionado" || Concepto == "Gastos de expedición")
                        dgConceptos.Rows[e.Cell.Row.Index].Cells["Identificación"].Value = "Recargo";
                    else
                        dgConceptos.Rows[e.Cell.Row.Index].Cells["Identificación"].Value = "Nueva Póliza";
                }
            }

            if (e.Cell.Column.Header.Caption == "Precio Unitario" || e.Cell.Column.Header.Caption == "Descuento")
            {
                if (e.Cell.Value != DBNull.Value)
                {
                    CalcularMontos();
                }
            }
        }

        private void dgConceptos_AfterRowsDeleted(object sender, EventArgs e)
        {
            CalcularMontos();
        }

        private void dgConceptos_CellDataError(object sender, Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs e)
        {
            MessageBox.Show("Debes introducir un valor válido para el campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.RaiseErrorEvent = false;
            e.RestoreOriginalValue = true;
        }

        private void cbTipoDocumento_ValueChanged(object sender, EventArgs e)
        {
            cbSerie.Items.Clear();
            if (cbTipoDocumento.Text == "Factura")
            {
                cbSerie.Items.Add(0, "F");
                cbSerie.Items.Add(1, "S");
                cbSerie.Text = "F";
                cbUsoCFDI.Text = "Gastos en general";
                dgConceptos.DisplayLayout.Bands[0].Columns["Clave de Producto"].NullText = "No existe en el catálogo";
                dgConceptos.DisplayLayout.Bands[0].Columns["Clave de Unidad"].NullText = "Unidad de servicio";
            }
            else
            {
                cbSerie.Items.Add(0, "NC");
                cbSerie.Text = "NC";
                cbUsoCFDI.Text = "Devoluciones, descuentos o bonificaciones";
                dgConceptos.DisplayLayout.Bands[0].Columns["Clave de Producto"].NullText = "Servicios de Facturación";
                dgConceptos.DisplayLayout.Bands[0].Columns["Clave de Unidad"].NullText = "Actividad";
            }
            CambiosEnDatos();
        }

        private void txtPlazoPago_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dateLimitePago.Value = Convert.ToDateTime(dateFechaEmision.Value).AddDays(int.Parse(txtPlazoPago.Text));
            }
            catch { }
            CambiosEnDatos();
        }

        private void ToolsBarFacturacion_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (dgConceptos.Rows.Count > 0)
            {
                for (int i = 0; i < dgConceptos.Rows.Count; i++)
                    dgConceptos.Rows[i].Update();
            }

            switch (e.Tool.Key)
            {
                case "btnGuardarAvances":
                    GuardarAvances();                                          
                    break;

                case "btnCerrarVentana":
                    this.Close();                                         
                    break;

                case "btnValidarRegistro":
                    if (ValidacionInformacion())
                        MessageBox.Show("Información correcta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;

                case "btnEnviarSolicitud":
                    EnviarSolicitud();                                          
                    break;

                case "btnActualizar":
                    CargarDataSets(true);
                    break;

            }
        }

        private void txtPoliza_Leave(object sender, EventArgs e)
        {
            txtPoliza.Text.Replace(" ", "");
            txtPoliza.Text = txtPoliza.Text.ToUpper();
        }

        private void btnConsultarTipoCambio_Click(object sender, EventArgs e)
        {
            if (cbMoneda.Text == "Pesos Mexicanos") { txtTipoCambio.Value = 1; return; }

            // Consulta el RSS de banxico para USD
            decimal TipoCambio = Extensiones.ConsultaBanxico.ObtenerTipoCambio(DateTime.Now);
            if(TipoCambio != 0)
                txtTipoCambio.Value = TipoCambio;
            else            
                MessageBox.Show("No se puede contactar con el Servidor de Banxico en este momento, favor de revisar su conexión a internet y reintentar", 
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void chkImpuestoRetenido_CheckedChanged(object sender, EventArgs e)
        {
            CalcularMontos();
        }

        private void cbCliente_Leave(object sender, EventArgs e)
        {
            try
            {
                this.clientesDireccionesTableAdapter.FillByCliente(this.facturacion1.ClientesDirecciones, Convert.ToInt32(cbCliente.Value));
            }
            catch
            {
                MessageBox.Show("Este cliente no tiene direcciones registradas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.facturacion1.ClientesDirecciones.Rows.Count == 0)
            {
                MessageBox.Show("Este cliente no tiene direcciones registradas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cbDireccion.SelectedIndex = 0;
            }
            CambiosEnDatos();
            cbCuentaMXN.Value = -1;
            cbSucursalMXN.Value = -1;
            cbCuentaUSD.Value = -1;
            cbSucursalUSD.Value = -1;

        }

        private void Facturacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Cambios)
            {
                if(MessageBox.Show("Desea guardar los cambios realizados antes de salir?","Guardar avances",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    GuardarAvances();
                }
            }
        }

        private void CambiosEnDatos(object sender, EventArgs e)
        {
            CambiosEnDatos();
        }

        private void btnAsignarCuenta_Click(object sender, EventArgs e)
        {
            if (cbCliente.Text == "") { MessageBox.Show("No se ha asignado ningun Cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            int IDCuentaBancaria = 1;  if (cbTipoDocumento.Text == "Factura")  IDCuentaBancaria = 2; 
            int IDClienteTemp = Convert.ToInt32(cbCliente.Value);
            dbSmartGDataContext db = new dbSmartGDataContext();

            SmartG.ClienteCuentaBancaria nuevaCuentaCliente;
            nuevaCuentaCliente = (from x in db.ClienteCuentaBancarias where (IDClienteTemp == x.Cliente && IDCuentaBancaria == x.CuentaBancaria) select x).SingleOrDefault();
            if (nuevaCuentaCliente == null)
                nuevaCuentaCliente = new ClienteCuentaBancaria();

            nuevaCuentaCliente.Cliente = IDClienteTemp;
            nuevaCuentaCliente.CuentaBancaria = IDCuentaBancaria;
            if(nuevaCuentaCliente.ID == 0)
                db.ClienteCuentaBancarias.InsertOnSubmit(nuevaCuentaCliente);
            db.SubmitChanges();

            int idClienteCuenta = nuevaCuentaCliente.ID;
            this.cuentasBancariasTableAdapter.Fill(this.facturacion2.CuentasBancarias);

            cbCuentaMXN.Value = idClienteCuenta;
            cbSucursalMXN.Value = idClienteCuenta;
            cbCuentaUSD.Value = idClienteCuenta;
            cbSucursalUSD.Value = idClienteCuenta;
        }

        private void cbIVA_ValueChanged(object sender, EventArgs e)
        {
            CalcularMontos();
            dbSmartGDataContext db = new dbSmartGDataContext();
            txtIVAdecimal.Value = Convert.ToDecimal((from x in db.IVAs where x.ID == Convert.ToInt32(cbIVA.Value) select x.IVAdecimal).SingleOrDefault());
        }

        private void cbMoneda_Leave(object sender, EventArgs e)
        {
            btnConsultarTipoCambio_Click(null, null);
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

        private void cbCondicionesPago_ValueChanged(object sender, EventArgs e)
        {
            if (cbCondicionesPago.Text == "Otro")
                btnEditarRecibos.Visible = true;
            if (!iniciarValidaciones) return;

            btnEditarRecibos.Visible = false;
            CambiosEnDatos();
            if(cbCondicionesPago.Text == "Otro")
            {
                btnEditarRecibos.Visible = true;
                GuardarAvances();
                AbrirRecibosEspeciales();
            }
            else
            {
                if( idFactura != 0)
                {
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    RecibosPagoEspecial[] recibosBorrar = (from x in db.RecibosPagoEspecials where x.Facturacion == idFactura select x).ToArray();
                    if (recibosBorrar.Count() > 0)
                    {
                        db.RecibosPagoEspecials.DeleteAllOnSubmit(recibosBorrar);
                        db.SubmitChanges();
                    }
                }
            }
        }

        private void btnEditarRecibos_Click(object sender, EventArgs e)
        {
            GuardarAvances();
            AbrirRecibosEspeciales();
        }

        private void cbBroker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateFechaEmision_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dateLimitePago.Value = Convert.ToDateTime(dateFechaEmision.Value).AddDays(int.Parse(txtPlazoPago.Text));
            }
            catch { }
            CambiosEnDatos();
        }

        private void txtAuditNumber_ValueChanged(object sender, EventArgs e)
        {
            txtAuditNumEco.Value = txtAuditNumber.Value;
            CambiosEnDatos();
        }

        private void cbBroker_Leave(object sender, EventArgs e)
        {
            if(cbBroker.Text == "Sin Agente de Seguros" || cbBroker.Text == "Directo")
                txtBrokerage.Value = 0;
        }

        #endregion
    }
}
