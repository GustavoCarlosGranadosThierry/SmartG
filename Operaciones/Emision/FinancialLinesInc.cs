using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Word = NetOffice.WordApi;
using Excel = NetOffice.ExcelApi;
using NetOffice.ExcelApi.Enums;
using NetOffice.ExcelApi.Tools.Utils;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Globalization;
using System.Threading;

namespace SmartG.Operaciones.Emision
{
    public partial class FinancialLinesInc : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // nombres y valores de todos los objetos que se encuentran en el formulario
        #region coleccion objetos
        #region primera tab datos generales
        //grpDatosPoliza	1) Datos de la Póliza
        //lbTipoTransaccion Tipo de transaccion:
        //lbTipoTransaccionTxt
        //lbPolizaMX        Poliza MX:
        //lbPolizaES        Poliza ES:
        //txtPolizaMX
        //txtPolizaES
        //chkAjustable      Ajustable
        //chkPortafolio     Portafolio
        //lbProducingOffice Producing Office
        //cbProducingOffice
        //lbToB             ToB
        //cbToB
        //lbMoneda          Moneda
        //cbMoneda
        //lbPrograma        Programa
        //cbPrograma
        //grpTipoCambio     Aplicar tipo de Cambio
        //txtTipoCambio
        //btnTipoCambio     Aplicar

        //grpFechasPoliza	2) Fechas de la Poliza
        //lbInicioVig       Inicio de Vigencia:
        //lbFinVigencia     Fin de Vigencia:
        //dateInicioVig
        //dateFinVigencia
        //lbEmision         Fecha de emision:
        //chkRetroactiva    Retroactiva
        //dateEmision
        //dateRetroactiva
        //lbProducto        Producto
        //cbProducto
        //lbFechaContinuidad  Fecha Continuidad:
        //dateFechaContinuidad
        //chkLimitada       Ilimitada

        //grpParticipantes	3) Participantes
        //grpAdministradores  Administradores
        //lbDAM             DAM
        //lbPAM             PAM
        //txtDAM
        //txtPAM
        //lbCountry         Country of Settlement
        //lbBroker          Broker
        //cbCountry
        //cbBroker
        //grpAsegurados     grpAsegurados
        //lbMainAsegurado
        //cbAseguradoMain
        //lbDireccion
        //cbDireccionRegistrada
        //lbAseguradoAdicional
        //txtAseguAdicional
        //grpListaAseguAdicionales
        //dgAseguAdicionales

        //grpUbicaciones	4) Ubicaciones y datos Adicionales
        //lbDelimitacionTerritorial Delimitación Territorial de la Cobertura:
        //cbDelimitacionTerritorial Solo Nacional, Mundial (Excepto USA, PR y Canadá), Mundial
        #endregion
        #region segunda tab coberturas
        //grpCoberturasDB		1) Coberturas en la base de datos
        //grpAccionesCobDB Acciones
        //lbInstruccionesCobDB	1) Click para agregar la cobertura seleccionada a la póliza
        //btnEnviarCobertura  Agregar
        //grpCoberturas		2) Coberturas de la Póliza
        //grpAccionesCob Acciones
        //lbInstruccionesCob	1) Click para quitar la cobertura seleccionada de la póliza
        //btnQuitarCobertura  Quitar
        //lbInstruccionesCob2	2) Agrega una cobertura para la póliza actual manualmente
        //txtNuevaCobertura
        //dgCoberturasDB
        //dgCoberturas
        #endregion
        #region Tercera tab endosos
        //grpEndososMain        1) Endosos aplicables en la póliza
        //grpEndosos		Selecciona los endosos que quieras que aparezcan en el wording
        //dgEndosos
        //btnEndososTodos   Seleccionar Todos
        //btnEndososNinguno	Quitar Todos
        #endregion
        #region cuarta tab limites y sublimites
        //grpLimites		1) Informacion de Limites
        //grpLimiteMaximo     Limite Máximo de Responsabilidad
        //lbLimiteMaximoCombinado Limite Máximo Combinado
        //txtLimiteMaximo
        //lbExcesoConsejeros Exceso para consejeros independientes
        //txtExcesoConsejeros
        //lbMon1          Mon1
        //grpEstructuraLimite Estructura del Limite
        //lbEstructuraLimite Estructura Limite
        //cbEstructuraLimite
        //lbSujecion      Sujecion
        //txtSujecion
        //lbMon2          Mon2
        //lbMon3 Mon3
        //grpSublimites		2) Sublimites de Responsabilidad
        //grpControlSublimites    Control de Sublimites
        //chkSublimites       Aplican Sublimites
        //btnRecargarSublimites
        //lbRecargarSublimites	1) Click para recargar los sublimites por las coberturas de la Póliza
        //lbSublimiteManual	2) Agrege un sublimite manualmente
        //txtSublimiteManual
        //dgSublimites
        //chkSublimitesTodos    Agregar todas las coberturas
        #endregion
        #region quinta tab deducibles
        //grpDeducibles		1) Deducibles aplicables a la póliza
        //grpControlDeducibles    Control de Deducibles
        //chkDeducibles       Aplican Deducibles
        //btnRecargarDeducibles
        //lbRecargarDeducibles	1) Click para recargar los deducibles por las coberturas de la Póliza
        //lbDeducibleManual	2) Agrege un deducible manualmente
        //txtDeducibleManual
        //dgDeducibles
        //grpExclusiones		2) Exclusiones aplicables a la póliza
        //grpControlExclusiones   Control de Exclusiones
        //chkExclusiones      Aplican Exclusiones
        //btnRecargarExclusiones
        //lbRecargarExclusiones	1) Click para recargar las exclusiones por defecto desde la base de datos
        //lbExclusionManual	2) Agrega una exclusión manualmente
        //dgExclusiones
        #endregion
        #region sexta tab valores genius
        //grpValoresGenius	1) Ingresa los valores GENIUS
        //lbTituloPolizaGenius Título Poliza
        //txtTituloPolizaGenius
        //btnTituloPolizaGenius Generar
        //chkLTARenegotiable LTA Renegotiable
        //lbLTAInception      LTA Inception
        //dateLTAInception
        //lbLTAExpiry     LTA Expiry
        //dateLTAExpiry
        //lbPaymentConditions Payment Conditions
        //cbPaymentConditions
        //lbActivityCode      Activity Code
        //cbActivityCode
        //grpDatosParticipations  Datos para Participations
        //chkAdminPremium   Admin Premium
        //chkAdminCLaims    Admin Claims
        //chkGenerateDocuments  GenerateDocuments
        //grpTieInLimits Cláusula Tie-in Limits
        //chkTieInLimits  Aplica Tie-in Limits
        //lbNumPolizaGlobal   Número de Póliza Global:
        //txtNumPolizaGlobal
        //lbTitularPolizaGlobal   Titular Póliza Global:
        //txtTitularPolizaGlobal
        //lbLimiteRespTieInLimits Límite de Responsabilidad
        //txtLimiteMaximoTieInLimits
        //cbAbreviacionMonedaTieIn
        #endregion
        #region septima tab info schedule
        //grpPrimayBrokerage	1) Prima y Brokerage
        //grpPrima        Cálculo de la Prima
        //lbPrima Prima
        //txtPrimaMain
        //lbMon4          Mon4
        //lbIVAPrima      IVA %
        //cbIVA
        //grpBrokerage        Brokerage
        //chkIsBrokerage      Incluir Brokerage
        //txtBrokeragePorc
        //lbComisionBrokerage Comisión
        //txtComisionBrokerage
        //lbMon6 Mon6
        //lbIVABrokerage IVA
        //txtIVABrokerage
        //lbMon7          Mon7
        //lbComisionTotalBrok Comisión Total
        //txtComisionTotalBrok
        //lbMon8          Mon8
        //grpTipoPrima        Tipo de Prima
        //lbTipoPrima     Tipo de Prima
        //cbTipoPrima
        //lbMon5 Mon5
        //lbTurnOver TurnOver
        //txtTurnOver
        //grpFacturacion		2) Facturación - Schedule
        //lbTipoPoliza        Tipo de Póliza
        //txtTipoPoliza
        //lbFormaPago Forma de Pago
        //cbFormaPago
        //lbNumPagos      Número de Pagos
        //txtNumPagos
        //lbObservaciones Observaciones
        //txtObservaciones
        //lbPrimaNeta     Prima Neta
        //txtPrimaNeta
        //lbMon9          Mon9
        //lbDescuentos        Descuentos
        //txtDescuentos
        //lbMon10 Mon10
        //lbRecFraccionado Recargo Fraccionado
        //txtRecFraccionado
        //lbMon11 Mon11
        //lbGastosExpedicion Gastos Expedición
        //txtGastosExpedicion
        //lbMon12 Mon12
        //lbImpuestos Impuestos
        //txtImpuestos
        //lbMon13         Mon13
        //lbPrimaTotal        Prima Total
        //txtPrimaTotal
        //lbMon14         Mon14
        #endregion
        #region octava Tab coaseguros
        //grpPrincipalCoaseguros	1) Tipo de Coaseguro
        //chkCoaseguro        Aplica Coaseguro
        //grpTipoCoaseguro Especifica el Tipo
        //lbCoaseguroTipo Coaseguro:
        //cbTipoCoaseguro
        //lbPrimaConsiderarCoase  Prima a Considerar:
        //lbPrimaCoaseguro primaCoaseguro
        //lbMon15 Mon15
        //grpCatalogoCoase Catalogo de Coaseguradoras
        //cbCatalogoCoase
        //lbParticipacionCoase    Participación
        //txtParticipacionCoase
        //btnAgregarCoase Agregar
        //grpCoaseguroSeguidor	2) Coaseguro Seguidor
        //lbCoaseguradorLider Coasegurador Lider
        //cbCoaseguradorLider
        //lbParticipacionXL	% Participación XL
        //grpCoaseguroLider	2) Coaseguro Lider
        //dgCoaseguro
        #endregion
        #region novena tab reaseguros
        //grpInfoReaseguro	1) Informacion de Reaseguro
        //chkReaseguro        Aplica Reaseguro
        //lbPrimaConsiderarRease Prima a Considerar:
        //lbPrimaReaseguro primaReaseguro
        //lbMon16 Mon16
        //grpReaseguro		2) Reaseguro
        //dgReaseguro
        //lbInformacionRiesgo   Información del Riesgo:
        //txtInformacionRiesgo
        #endregion
        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region variables
        #region primera tab datos generales
        public int? idPoliza = 0;
        int? idPolizaFL = 0;
        string polizaMX;
        string polizaES;
        string tipoOperacion;
        bool portafolio;
        bool ajustable;
        int? ToB;
        int? moneda;
        string mon;
        int? programa;
        DateTime iniVig;
        DateTime finVig;
        DateTime emision;
        bool retroactiva;
        DateTime? fechaRetroactiva;
        DateTime? fechaContinuidad;
        bool limitada;
        string DAM;
        int? PAM;
        int? country;
        int? Broker;
        int? aseguradoPrincipal;
        int? direccionAseguradoPrincipal;
        DataTable dtAseguradosAdicionales;
        string delimitacionTerritorial;
        int? productoSel;
        #endregion
        #region segunda tab coberturas
        #endregion
        #region tercera tab endosos
        DataTable dtEndosos;
        #endregion
        #region cuarta tab limites y sublimites
        decimal limiteMaximo;
        decimal excesoConsejeros;
        string estructuraLimite;
        decimal sujecion;
        DataTable dtSublimites;
        #endregion
        #region quinta tab deducibles
        DataTable dtDeducibles;
        DataTable dtExclusiones;
        #endregion
        #region sexta tab valores genius
        string tituloPolizaGenius;
        bool LTARenegotiable;
        DateTime? LTAInception;
        DateTime? LTAExpiry;
        string paymentCondition;
        int? activityCode;
        bool adminClaims;
        bool adminPremium;
        bool generateDocuments;
        bool isTieinLimits;
        string numPolizaGlobal;
        string titularPolizaGlobal;
        decimal limiteMaximoTieIn;
        string abreMonedaTieIn;
        #endregion
        #region septima tab info schedule
        decimal primaNeta;
        decimal primaTotal;
        string IVA;
        bool isBrokerage;
        decimal porcBrokerage;
        decimal comisionBrokerage;
        decimal ivaBrokerage;
        decimal comisionTotalBrokerage;
        string tipoPrima;
        decimal turnOver;
        string tipoPoliza;
        int? formaPago;
        int? numeroPagos;
        string observaciones;
        decimal descuentos;
        decimal recargoFraccionado;
        decimal gastosExpedicion;
        decimal impuestosNetos;
        decimal totalPoliza;
        #endregion
        #region octava tab coaseguros
        int? idCoaseguradorLider;
        decimal porcParticipacionXL;
        DataTable dtCoaseguros;
        decimal cantidadCoaseguro = 0;
        #endregion
        #region novena tab reaseguros
        DataTable dtReaseguro;
        int idIntermediarioDefault = 0;
        int loadReaseguro = 0;
        decimal cantidadReaseguro = 0;
        #endregion
        #region Variables Generales
        Control[] controlesObligatorios;
        Control[] labelsMonedas;
        string[] extensionesDefault;
        int FinancialLines;
        int Origen;
        int coberturaM = -1;
        int exclusionesM = -1;
        int? idDefaultCoaseguradora = 0;
        int? idDefaultReaseguradora = 0;
        bool pasoValidaciones = false;
        int ventana = 0;
        int tabAnterior = 0;
        bool controlSave = false;
        #endregion
        #region Variables Wording
        string strIniVig;
        string strFinVig;
        string strIniVig2;
        string strFinVig2;
        string strEmision2;
        string diaAnterior;
        string strRetroactiva;
        string strEmision;
        string strContinuidad;
        string strExceso;
        string strMoneda;
        string strAbreMon;
        string strFormaPago;
        string strBroker;
        string strDireccionAsegu;
        string strRFC;
        string strGiroE;
        string strAseguAdicional;
        string strLimite;
        string strCoberturas;
        string strCoberturas2;
        string strSublimites;
        string strDeducibles;
        double strPartReasegurada = 0;
        double strPartTotal = 0;
        double strInternationalCalc = 0;
        double strComisionInter = 0;
        string modoClaims;
        #endregion
        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region MetodosProgramados

        bool borrarRegistros(int solicitud)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            try
            {
                switch (solicitud)
                {
                    case 0: // PolizaCoberturas
                        PolizaCobertura[] aBorrarCob = (from x in db.PolizaCobertura where x.Poliza == idPoliza select x).ToArray();
                        if (aBorrarCob.Count() > 0)
                        {
                            db.PolizaCobertura.DeleteAllOnSubmit(aBorrarCob);
                            db.SubmitChanges();
                        }
                        break;

                    case 1: // PolizaSublimites
                        PolizaSublimites[] aBorrarSubL = (from x in db.PolizaSublimites where x.Poliza == idPoliza select x).ToArray();
                        if (aBorrarSubL.Count() > 0)
                        {
                            db.PolizaSublimites.DeleteAllOnSubmit(aBorrarSubL);
                            db.SubmitChanges();
                        }
                        break;

                    case 2: // PolizaDeducibles
                        PolizaDeducible[] aBorrarDedu = (from x in db.PolizaDeducible where x.Poliza == idPoliza select x).ToArray();
                        if (aBorrarDedu.Count() > 0)
                        {
                            db.PolizaDeducible.DeleteAllOnSubmit(aBorrarDedu);
                            db.SubmitChanges();
                        }
                        break;

                    case 3: // PolizaExclusiones
                        PolizaExclusion[] aBorrarExclu = (from x in db.PolizaExclusion where x.Poliza == idPoliza select x).ToArray();
                        if (aBorrarExclu.Count() > 0)
                        {
                            db.PolizaExclusion.DeleteAllOnSubmit(aBorrarExclu);
                            db.SubmitChanges();
                        }
                        break;

                    case 4: // InfoSchedule
                        InfoSchedule infoDelete = (from x in db.InfoSchedule where x.Poliza == idPoliza select x).SingleOrDefault();
                        if (infoDelete != null)
                        {
                            db.InfoSchedule.DeleteOnSubmit(infoDelete);
                            db.SubmitChanges();
                        }
                        break;

                    case 5: // Clientes
                        PolizaCliente[] aBorrarClientes = (from x in db.PolizaCliente where x.Poliza == idPoliza select x).ToArray();
                        if (aBorrarClientes.Count() > 0)
                        {
                            db.PolizaCliente.DeleteAllOnSubmit(aBorrarClientes);
                            db.SubmitChanges();
                        }
                        break;

                    case 6: // Coaseguros
                        PolizaCoaseguro[] aBorrarCoase = (from x in db.PolizaCoaseguro where x.Poliza == idPoliza select x).ToArray();
                        if (aBorrarCoase.Count() > 0)
                        {
                            db.PolizaCoaseguro.DeleteAllOnSubmit(aBorrarCoase);
                            db.SubmitChanges();
                        }
                        break;

                    case 7: // reaseguro
                        PolizaReaseguro[] aBorrarRease = (from x in db.PolizaReaseguro where x.Poliza == idPoliza select x).ToArray();
                        if (aBorrarRease.Count() > 0)
                        {
                            db.PolizaReaseguro.DeleteAllOnSubmit(aBorrarRease);
                            db.SubmitChanges();
                        }
                        break;

                    case 8:
                        PolizaEndosoEmision[] aBorrarEndoEmi = (from x in db.PolizaEndosoEmision where x.Poliza == idPoliza select x).ToArray();
                        if (aBorrarEndoEmi.Count() > 0)
                        {
                            db.PolizaEndosoEmision.DeleteAllOnSubmit(aBorrarEndoEmi);
                            db.SubmitChanges();
                        }
                        break;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        void calcularBrokerage()
        {
            double tmpPorcBrokerage = Convert.ToDouble(txtBrokeragePorc.Value) / 100;
            double tmpPrima = Convert.ToDouble(txtPrimaMain.Value);
            double tmpIVA = 0.16;
            switch (cbIVA.Text)
            {
                case "0%":
                    tmpIVA = 0;
                    break;
                case "16%":
                    tmpIVA = 0.16;
                    break;
                case "Exento":
                    tmpIVA = 0;
                    break;
            }
            
            txtComisionBrokerage.Value = tmpPrima * tmpPorcBrokerage;
            txtIVABrokerage.Value = Convert.ToDouble(txtComisionBrokerage.Value) * tmpIVA;
            txtComisionTotalBrok.Value = Convert.ToDouble(txtComisionBrokerage.Value) + Convert.ToDouble(txtIVABrokerage.Value);
        }

        void calcularCoaseguros()
        {
            //lbPrimaCoaseguro.Text = txtPrimaMain.Value.ToString();

            decimal tmpPrima = Convert.ToDecimal(txtPrimaMain.Value);
            decimal tmpPorcPart = 0;
            decimal tmpPorcBrokerage = Convert.ToDecimal(txtComisionBrokerage.Value);

            for (int i = 0; i < dgCoaseguro.Rows.Count; i++)
            {
                if (dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text.ToString() != "" && dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text.ToString() != "Selecciona un Coasegurador")
                {
                    tmpPorcPart = Convert.ToDecimal(dgCoaseguro.Rows[i].Cells["PorcentajeParticipacion"].Value) / 100;
                    dgCoaseguro.Rows[i].Cells["Participacion"].Value = tmpPrima * tmpPorcPart;
                    tmpPorcPart = Convert.ToDecimal(dgCoaseguro.Rows[i].Cells["PorcentajeComisionBroker"].Value) / 100;
                    dgCoaseguro.Rows[i].Cells["ComisionBroker"].Value = tmpPorcBrokerage * tmpPorcPart;
                }
            }
        }

        void calcularLabelCoaseguro()
        {
            lbPrimaCoaseguro.Text = "$ " + Convert.ToDouble(txtPrimaMain.Value).ToString("#,##0.00", new CultureInfo("en-US"));
            cantidadCoaseguro = Convert.ToDecimal(txtPrimaMain.Value);
        }

        void calcularLabelReaseguro()
        {
            if (chkCoaseguro.Checked && dgCoaseguro.Rows.Count > 0)
            {
                //obtenemos la cantidad con la que entrará el reaseguro
                bool encontro = false;
                for (int i = 0; i < dgCoaseguro.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dgCoaseguro.Rows[i].Cells["Coaseguradora"].Value) == idDefaultCoaseguradora)
                    {
                        decimal tmpPorc = Convert.ToDecimal(dgCoaseguro.Rows[i].Cells["PorcentajeParticipacion"].Value) / 100;
                        lbPrimaReaseguro.Text = "$ " + (Convert.ToDecimal(txtPrimaMain.Value) * tmpPorc).ToString("#,##0.00", new CultureInfo("en-US"));
                        cantidadReaseguro = Convert.ToDecimal(txtPrimaMain.Value) * tmpPorc;
                        encontro = true;
                        break;
                    }
                }
                if (!encontro)
                {
                    MessageBox.Show("Ocurrió un error, no se encuentra el coasegurador XL México en la tabla Coaseguros, favor de verificarlo y agregarlo manualmente en caso de haber sido borrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chkReaseguro.Checked = false;
                    return;
                }
            }
            else
            {
                lbPrimaReaseguro.Text = txtPrimaMain.Value.ToString();
                cantidadReaseguro = Convert.ToDecimal(txtPrimaMain.Value);
            }
        }

        void calcularPrimaTotal()
        {
            txtPrimaNeta.Value = txtPrimaMain.Value;
            double tmpPrima = Convert.ToDouble(txtPrimaMain.Value);
            double tmpDescuentos = Convert.ToDouble(txtDescuentos.Value);
            double tmpRecFracc = Convert.ToDouble(txtRecFraccionado.Value);
            double tmpGastosExp = Convert.ToDouble(txtGastosExpedicion.Value);
            double tmpIVA = 0.16;
            switch (cbIVA.Text)
            {
                case "0%":
                    tmpIVA = 0;
                    break;
                case "16%":
                    tmpIVA = 0.16;
                    break;
                case "Exento":
                    tmpIVA = 0;
                    break;
            }
            double tmpTotalNeto = tmpPrima - tmpDescuentos + tmpRecFracc + tmpGastosExp;
            double tmpIVANeto = tmpTotalNeto * tmpIVA;
            txtImpuestos.Value = tmpIVANeto;
            txtPrimaTotal.Value = tmpTotalNeto + tmpIVANeto;
        }

        void calcularReaseguros()
        {
            decimal tmpTotalTreaty = 0;
            decimal tmpTotalNoTreaty = 0;
            decimal tmpTabulador = 0;

            for (int i = 0; i < dgReaseguro.Rows.Count; i++)
            {
                if (dgReaseguro.Rows[i].Cells["Reaseguradora"].Text.ToString() != "" && dgReaseguro.Rows[i].Cells["Reaseguradora"].Text.ToString() != "Selecciona una Reaseguradora")
                {
                    if (Convert.ToBoolean(dgReaseguro.Rows[i].Cells["Treaty"].Value))
                    {
                        tmpTotalTreaty += Convert.ToDecimal(dgReaseguro.Rows[i].Cells["PorcentajeParticipacion"].Value.ToString());
                    }
                    else
                    {
                        tmpTotalNoTreaty += Convert.ToDecimal(dgReaseguro.Rows[i].Cells["PorcentajeParticipacion"].Value.ToString());
                    }
                }
            }

            tmpTabulador = (tmpTotalTreaty - tmpTotalNoTreaty) / 100;

            for (int i = 0; i < dgReaseguro.Rows.Count; i++)
            {
                if (dgReaseguro.Rows[i].Cells["Reaseguradora"].Text.ToString() != "" && dgReaseguro.Rows[i].Cells["Reaseguradora"].Text.ToString() != "Selecciona una Reaseguradora")
                {
                    if (Convert.ToBoolean(dgReaseguro.Rows[i].Cells["Treaty"].Value))
                    {
                        dgReaseguro.Rows[i].Cells["PorcentajePoliza"].Value = Convert.ToDecimal(dgReaseguro.Rows[i].Cells["PorcentajeParticipacion"].Value.ToString()) * tmpTabulador;
                        dgReaseguro.Rows[i].Cells["Participacion"].Value = cantidadReaseguro * (Convert.ToDecimal(dgReaseguro.Rows[i].Cells["PorcentajePoliza"].Value.ToString()) / 100);
                    }
                    else
                    {
                        dgReaseguro.Rows[i].Cells["PorcentajePoliza"].Value = Convert.ToDecimal(dgReaseguro.Rows[i].Cells["PorcentajeParticipacion"].Value.ToString());
                        dgReaseguro.Rows[i].Cells["Participacion"].Value = cantidadReaseguro * (Convert.ToDecimal(dgReaseguro.Rows[i].Cells["PorcentajePoliza"].Value.ToString()) / 100);
                    }

                }

                decimal tmpPrima = Convert.ToDecimal(dgReaseguro.Rows[i].Cells["Participacion"].Value);
                decimal tmpPorcPart = Convert.ToDecimal(dgReaseguro.Rows[i].Cells["PorcentajeComision"].Value) / 100;
                dgReaseguro.Rows[i].Cells["Comision"].Value = tmpPrima * tmpPorcPart;
            }

        }

        void cargarAvances()
        {
            txtRetroValidaciones.Text = "";
            cargarPoliza();
            cargarCoberturas();
            cargarEndosos();
            cargarSublimites();
            cargarDeducibles();
            cargarInfoSchedule();
            cargarClientes();
            cargarCoaseguros();
            cargarReaseguro();
            txtRetroValidaciones.Text += Environment.NewLine + "Datos cargados con éxito";
            txtRetroValidaciones.SelectionStart = txtRetroValidaciones.TextLength;
            txtRetroValidaciones.ScrollToCaret();
            terminarEdicionGrids();
        }

        void cargarClientes()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            cbAseguradoMain.Value = (from x in db.PolizaCliente where x.Poliza == idPoliza && x.Principal == true select x.Cliente).SingleOrDefault();
            cbDireccionRegistrada.Value = (from x in db.PolizaCliente where x.Poliza == idPoliza && x.Principal == true select x.Direccion).SingleOrDefault();
            PolizaCliente[] aseguAdicionales = (from x in db.PolizaCliente where x.Poliza == idPoliza && x.Principal == false select x).ToArray();
            if (aseguAdicionales.Count() > 0)
            {
                for (int i = 0; i < aseguAdicionales.Count(); i++)
                {
                    dtAseguradosAdicionales.Rows.Add(aseguAdicionales[i].NombreAsegurado);
                }
                dgAseguAdicionales.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
        }

        void cargarCoaseguros()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            if (ventana != 2)
            {
                PolizaCoaseguro[] coaseguros = (from x in db.PolizaCoaseguro where x.Poliza == idPoliza select x).ToArray();
                if (coaseguros.Count() > 0)
                {
                    chkCoaseguro.Checked = true;
                    if (coaseguros[0].Tipo == "Lider")
                    {
                        cbTipoCoaseguro.Text = "Coaseguro Lider";
                        dtCoaseguros.Rows.Clear();
                        calcularLabelCoaseguro();
                        for (int i = 0; i < coaseguros.Count(); i++)
                        {
                            dtCoaseguros.Rows.Add(coaseguros[i].Participacion, coaseguros[i].Monto, coaseguros[i].PorcComision, coaseguros[i].MontoComision);

                        }
                        dgCoaseguro.DataSource = dtCoaseguros;
                        for (int i = 0; i < coaseguros.Count(); i++)
                        {
                            dgCoaseguro.Rows[i].Cells["Coaseguradora"].Value = coaseguros[i].Coaseguradora;
                            dgCoaseguro.Rows[i].Update();
                        }
                        dgCoaseguro.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);


                        cbCoaseBrokerageOtro.Items.Clear();

                        for (int i = 0; i < dgCoaseguro.Rows.Count; i++)
                        {
                            if (dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text.ToString() != "")
                                cbCoaseBrokerageOtro.Items.Add(dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text.ToString());
                        }

                        if (coaseguros[0].CoaseguradoraAdministra != null)
                        {
                            if (coaseguros[0].CoaseguradoraAdministra == idDefaultCoaseguradora)
                            {
                                cbCoaseBrokerageSel.Text = "XL Seguros";
                            }
                            else
                            {
                                cbCoaseBrokerageSel.Text = "Otro";
                                cbCoaseBrokerageOtro.Text = (from x in db.Coaseguradoras where x.ID == coaseguros[0].CoaseguradoraAdministra select x.Nombre).SingleOrDefault();
                            }
                        }
                    }
                    else
                    {
                        cbTipoCoaseguro.Text = "Coaseguro Seguidor";
                        calcularLabelCoaseguro();
                        txtPorParticipacionXL.Value = coaseguros[0].Participacion;
                        txtParticipacionXL.Value = coaseguros[0].Monto;
                        txtCoasePorcBrokerage.Value = coaseguros[0].PorcComision;
                        txtCoaseComiBrokerage.Value = coaseguros[0].MontoComision;

                        cbCoaseguradorLider.Value = coaseguros[0].Coaseguradora;

                        if (coaseguros[0].CoaseguradoraAdministra != null)
                        {
                            if (coaseguros[0].CoaseguradoraAdministra == idDefaultCoaseguradora)
                            {
                                cbCoaseBrokerageSel.Text = "XL Seguros";
                            }
                            else
                            {
                                cbCoaseBrokerageSel.Text = "Otro";
                            }
                        }
                    }
                }
                txtRetroValidaciones.Text += Environment.NewLine + "8) Coaseguros Cargados satisfactoriamente";
            }
            else
            {
                PolizaCoaseguro[] coaseguros = (from x in db.PolizaCoaseguro where x.Poliza == idPoliza && x.Activo == true select x).ToArray();
                if (coaseguros.Count() > 0)
                {
                    chkCoaseguro.Checked = true;
                    if (coaseguros[0].Tipo == "Lider")
                    {
                        cbTipoCoaseguro.Text = "Coaseguro Lider";
                        dtCoaseguros.Rows.Clear();
                        lbPrimaCoaseguro.Text = txtPrimaMain.Value.ToString();
                        for (int i = 0; i < coaseguros.Count(); i++)
                        {
                            dtCoaseguros.Rows.Add(coaseguros[i].Participacion, coaseguros[i].Monto, coaseguros[i].PorcComision, coaseguros[i].MontoComision);

                        }
                        dgCoaseguro.DataSource = dtCoaseguros;
                        for (int i = 0; i < coaseguros.Count(); i++)
                        {
                            dgCoaseguro.Rows[i].Cells["Coaseguradora"].Value = coaseguros[i].Coaseguradora;
                        }
                        dgCoaseguro.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);


                        cbCoaseBrokerageOtro.Items.Clear();

                        for (int i = 0; i < dgCoaseguro.Rows.Count; i++)
                        {
                            if (dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text.ToString() != "")
                                cbCoaseBrokerageOtro.Items.Add(dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text.ToString());
                        }

                        if (coaseguros[0].CoaseguradoraAdministra != null)
                        {
                            if (coaseguros[0].CoaseguradoraAdministra == idDefaultCoaseguradora)
                            {
                                cbCoaseBrokerageSel.Text = "XL Seguros";
                            }
                            else
                            {
                                cbCoaseBrokerageSel.Text = "Otro";
                                cbCoaseBrokerageOtro.Text = (from x in db.Coaseguradoras where x.ID == coaseguros[0].CoaseguradoraAdministra select x.Nombre).SingleOrDefault();
                            }
                        }
                    }
                    else
                    {
                        cbTipoCoaseguro.Text = "Coaseguro Seguidor";
                        lbPrimaCoaseguro.Text = txtPrimaMain.Value.ToString();

                        txtPorParticipacionXL.Value = coaseguros[0].Participacion;
                        txtParticipacionXL.Value = coaseguros[0].Monto;
                        txtCoasePorcBrokerage.Value = coaseguros[0].PorcComision;
                        txtCoaseComiBrokerage.Value = coaseguros[0].MontoComision;

                        cbCoaseguradorLider.Value = coaseguros[0].Coaseguradora;

                        if (coaseguros[0].CoaseguradoraAdministra != null)
                        {
                            if (coaseguros[0].CoaseguradoraAdministra == idDefaultCoaseguradora)
                            {
                                cbCoaseBrokerageSel.Text = "XL Seguros";
                            }
                            else
                            {
                                cbCoaseBrokerageSel.Text = "Otro";
                            }
                        }
                    }
                }
                txtRetroValidaciones.Text += Environment.NewLine + "8) Coaseguros Cargados satisfactoriamente";
            }
        }

        void cargarCoberturas()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();

            int?[] idCoberturas = (from x in db.PolizaCobertura where x.Poliza == idPoliza select x.Cobertura).ToArray();
            if (idCoberturas.Count() > 0)
            {
                liIncCoberturasDBTableAdapter.FillByTodosDBProducto(this.liabilityInc1.LiIncCoberturasDB, FinancialLines, Origen, productoSel);
                liabilityInc1.LiIncCoberturas.Rows.Clear();
                bool encontro = false;
                for (int i = 0; i < idCoberturas.Count(); i++)
                {
                    encontro = false;
                    for (int j = 0; j < dgCoberturasDB.Rows.Count; j++)
                    {
                        if (idCoberturas[i] == Convert.ToInt32(dgCoberturasDB.Rows[j].Cells["ID"].Text.ToString()))
                        {
                            liabilityInc1.LiIncCoberturas.Rows.Add(Convert.ToInt32(dgCoberturasDB.Rows[j].Cells["ID"].Text.ToString()),
                           FinancialLines, dgCoberturasDB.Rows[j].Cells["Cobertura"].Text.ToString(), dgCoberturasDB.Rows[j].Cells["CoberturaIngles"].Text.ToString(),
                           dgCoberturasDB.Rows[j].Cells["GeniusCode"].Text.ToString(), Convert.ToBoolean(dgCoberturasDB.Rows[j].Cells["Defecto"].Text),
                           Convert.ToBoolean(dgCoberturasDB.Rows[j].Cells["userAdd"].Text), Convert.ToBoolean(dgCoberturasDB.Rows[j].Cells["Eliminado"].Text),
                           1);
                            liabilityInc1.LiIncCoberturasDB.Rows.RemoveAt(dgCoberturasDB.Rows[j].Index);
                            encontro = true;
                        }
                    }

                    if (!encontro)
                    {
                        Coberturas cobTMP = (from x in db.Coberturas where x.ID == idCoberturas[i] select x).SingleOrDefault();
                        liabilityInc1.LiIncCoberturas.Rows.Add(cobTMP.ID, FinancialLines, cobTMP.Cobertura, cobTMP.CoberturaIngles, cobTMP.GeniusCode, cobTMP.Defecto, cobTMP.userAdd, cobTMP.Eliminado, cobTMP.Origen);
                    }
                }
            }
            dgCoberturas.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            dgCoberturasDB.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            txtRetroValidaciones.Text += Environment.NewLine + "2) Coberturas cargadas satisfactoriamente";
        }

        void cargarEndosos()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            PolizaEndosoEmision[] endosos = (from x in db.PolizaEndosoEmision where x.Poliza == idPoliza select x).ToArray();
            if (endosos.Count() > 0)
            {
                for (int k = 0; k < dgEndosos.Rows.Count; k++)
                {
                    dgEndosos.Rows[k].Cells["Aplica"].Value = false;
                }

                for (int j = 0; j < endosos.Count(); j++)
                {
                    for (int i = 0; i < dgEndosos.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dgEndosos.Rows[i].Cells["ID"].Text) == endosos[j].EndosoEmision)
                        {
                            dgEndosos.Rows[i].Cells["Aplica"].Value = true;
                        }
                    }
                }
            }
            dgEndosos.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            txtRetroValidaciones.Text += Environment.NewLine + "3) Endosos Cargados satisfactoriamente";
        }

        void cargarDeducibles()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            PolizaDeducible[] deducibles = (from x in db.PolizaDeducible where x.Poliza == idPoliza select x).ToArray();
            if (deducibles.Count() > 0)
            {
                chkDeducibles.Checked = true;
                dtDeducibles.Rows.Clear();
                for (int i = 0; i < deducibles.Count(); i++)
                {
                    dtDeducibles.Rows.Add(deducibles[i].Deducible, deducibles[i].Porcentaje, deducibles[i].Minimo, deducibles[i].Maximo, deducibles[i].SIR, deducibles[i].Agregado);
                }
            }
            dgDeducibles.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            txtRetroValidaciones.Text += Environment.NewLine + "4) Deducibles Cargados satisfactoriamente";
        }

        void cargarInfoSchedule()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            InfoSchedule tmpInfo = (from x in db.InfoSchedule where x.Poliza == idPoliza select x).SingleOrDefault();
            if (tmpInfo != null)
            {
                cbFormaPago.Value = tmpInfo.FormaPago;
                txtPrimaMain.Value = tmpInfo.Prima;
                txtPrimaNeta.Value = tmpInfo.Prima;
                cbIVA.Text = tmpInfo.IVA;
                if (tmpInfo.isBrokerage != null)
                {
                    if (Convert.ToBoolean(tmpInfo.isBrokerage))
                    {
                        chkIsBrokerage.Checked = true;
                        txtBrokeragePorc.Value = tmpInfo.PorcentajeBrokerage;
                    }
                }
                cbTipoPrima.Text = tmpInfo.TipoPrima;
                txtTurnOver.Value = tmpInfo.TurnOver;
                txtTipoPoliza.Text = tmpInfo.TipoPoliza;
                txtNumPagos.Value = tmpInfo.NumeroPagos;
                txtObservaciones.Text = tmpInfo.Observaciones;
                txtDescuentos.Value = tmpInfo.Descuentos;
                txtRecFraccionado.Value = tmpInfo.RecargoFraccionado;
            }
            calcularPrimaTotal();
            calcularBrokerage();

            txtRetroValidaciones.Text += Environment.NewLine + "6) Prima Cargada satisfactoriamente";
        }

        void cargarPoliza()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            Poliza tmpPoliza = (from x in db.Poliza where x.ID == idPoliza select x).SingleOrDefault();
            if (tmpPoliza.Portafolio != null)
            {
                if (Convert.ToBoolean(tmpPoliza.Portafolio))
                    chkPortafolio.Checked = true;
            }

            if (tmpPoliza.ToB != null)
            {
                LNTB lntbTmp = (from x in db.LNTB where x.ID == tmpPoliza.ToB select x).SingleOrDefault();
                int? tmpid = lntbTmp.LNPO;
                cbProducingOffice.Value = tmpid;
                cbToB.Value = Convert.ToInt32(tmpPoliza.ToB);
            }

            cbMoneda.Value = tmpPoliza.Moneda;
            dateInicioVig.Value = tmpPoliza.IniVig;
            dateFinVigencia.Value = tmpPoliza.FinVig;
            dateEmision.Value = tmpPoliza.Emision;
            txtDAM.Text = tmpPoliza.DAM;
            txtPAM.Value = tmpPoliza.PAM;
            cbCountry.Value = tmpPoliza.PaisAcuerdo;
            cbBroker.Value = tmpPoliza.Broker;
            cbDelimitacionTerritorial.Text = tmpPoliza.TerritorioCobertura;
            txtLimiteMaximo.Value = tmpPoliza.LimiteMaximo;
            txtTituloPolizaGenius.Text = tmpPoliza.PolizaGenius;
            txtInformacionRiesgo.Text = tmpPoliza.InformacionReaseguro;

            if (tmpPoliza.LTARenegociable != null)
            {
                if (Convert.ToBoolean(tmpPoliza.LTARenegociable))
                {
                    dateLTAInception.Value = tmpPoliza.LTAInseption;
                    dateLTAExpiry.Value = tmpPoliza.LTAExpiry;
                }
            }
            cbPaymentConditions.Text = tmpPoliza.PaymentCondition;
            cbActivityCode.Value = tmpPoliza.ActivityCode;
            chkAdminClaims.Checked = Convert.ToBoolean(tmpPoliza.AdminClaims);
            chkAdminPremium.Checked = Convert.ToBoolean(tmpPoliza.AdminPremium);
            chkGenerateDocuments.Checked = Convert.ToBoolean(tmpPoliza.GenerateDocuments);
            txtRetroValidaciones.Text += "1) Datos Generales cargados satisfactoriamente";

            PolizaFL tmpPolizaFL = (from y in db.PolizaFL where y.Poliza == idPoliza select y).SingleOrDefault();
            if (tmpPolizaFL != null)
            {
                idPolizaFL = tmpPolizaFL.ID;
                cbProducto.Value = tmpPolizaFL.Producto;
                productoSel = tmpPolizaFL.Producto;

                if (tmpPolizaFL.Ajustable != null)
                {
                    if (Convert.ToBoolean(tmpPolizaFL.Ajustable))
                        chkAjustable.Checked = true;
                }
                if (tmpPolizaFL.Ilimitada != null)
                {
                    if (Convert.ToBoolean(tmpPolizaFL.Ilimitada))
                        chkLimitada.Checked = true;
                }
                if (tmpPolizaFL.Retroactivo != null)
                {
                    if (Convert.ToBoolean(tmpPolizaFL.Retroactivo))
                    {
                        chkRetroactiva.Checked = true;
                        dateRetroactiva.Value = tmpPolizaFL.FechaRetroactivo;
                    }
                }
                dateFechaContinuidad.Value = tmpPolizaFL.FechaContinuidad;
                txtExcesoConsejeros.Value = tmpPolizaFL.ExcesoConsejeros;
                cbEstructuraLimite.Text = tmpPolizaFL.EstructuraLimite;
                txtSujecion.Value = tmpPolizaFL.Sujecion;
                cbPrograma.Value = tmpPolizaFL.Programa;
                if (tmpPolizaFL.isClausulaTieIn != null)
                {
                    if (Convert.ToBoolean(tmpPolizaFL.isClausulaTieIn))
                    {
                        chkTieInLimits.Checked = true;
                        txtNumPolizaGlobal.Text = tmpPolizaFL.NumPolizaGlobal;
                        txtTitularPolizaGlobal.Text = tmpPolizaFL.TitularPolizaGlobal;
                        txtLimiteMaximoTieInLimits.Value = tmpPolizaFL.LimiteResponsabilidad;
                        cbAbreviacionMonedaTieIn.Text = tmpPolizaFL.AbreviacionMoneda;
                    }
                }
            }

            txtPolizaMX.Text = tmpPoliza.Poliza1;
            txtPolizaES.Text = tmpPoliza.PolizaES;

            // cargamos la info segun el producto
            PolizaFLProducto[] elementosCarga = (from x in db.PolizaFLProducto where x.PolizaFL == idPolizaFL select x).ToArray();
            if (elementosCarga.Count() > 0)
            {
                for (int i = 0; i < elementosCarga.Count(); i++)
                {
                    Control[] ctrl = this.Controls.Find(elementosCarga[i].Control, true);
                    if (ctrl.Count() > 0)
                    {
                        string tipoControl = elementosCarga[i].TipoControl;
                        switch (tipoControl)
                        {
                            case "int":
                                Infragistics.Win.UltraWinEditors.UltraNumericEditor controlInt = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)ctrl[0];
                                controlInt.Value = Convert.ToInt32(elementosCarga[i].Valor);
                                break;

                            case "string":
                                ctrl[0].Text = elementosCarga[i].Valor;
                                break;

                            case "decimal":
                                Infragistics.Win.UltraWinEditors.UltraNumericEditor controlDecimal = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)ctrl[0];
                                controlDecimal.Value = Convert.ToDecimal(elementosCarga[i].Valor);
                                break;

                            case "bool":
                                Infragistics.Win.UltraWinEditors.UltraCheckEditor controlCheck = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)ctrl[0];
                                controlCheck.Checked = Convert.ToBoolean(elementosCarga[i].Valor);
                                break;

                            case "date":
                                Infragistics.Win.UltraWinEditors.UltraDateTimeEditor controlFecha = (Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)ctrl[0];
                                controlFecha.Value = Convert.ToDateTime(elementosCarga[i].Valor);
                                break;

                            case "double":
                                Infragistics.Win.UltraWinEditors.UltraNumericEditor controlDouble = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)ctrl[0];
                                controlDouble.Value = Convert.ToDouble(elementosCarga[i].Valor);
                                break;

                            case "rtf":
                                System.Windows.Forms.RichTextBox rich = (System.Windows.Forms.RichTextBox)ctrl[0];
                                rich.Rtf = elementosCarga[i].Valor;
                                break;
                        }
                    }
                }
            }
        }

        public void cargarPolizaMain()
        {
            if (ventana != 2)
            {
                if (MessageBox.Show("Se borrarán los datos de la ventana actual, ¿Deseas continuar con la carga de la póliza?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ResetearControles.ResetearTodo(this);
                    iniciarDatos();
                    cargarAvances();
                }
            }
        }

        void cargarReaseguro()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            if (ventana != 2)
            {
                PolizaReaseguro[] reaseguros = (from x in db.PolizaReaseguro where x.Poliza == idPoliza select x).ToArray();
                if (reaseguros.Count() > 0)
                {
                    loadReaseguro = 1;
                    chkReaseguro.Checked = true;
                    dtReaseguro.Rows.Clear();
                    dgReaseguro.DataSource = dtReaseguro;
                    for (int i = 0; i < reaseguros.Count(); i++)
                    {
                        dtReaseguro.Rows.Add(false, reaseguros[i].PorcParticipacion, 0, reaseguros[i].Participacion, reaseguros[i].PorcComision, reaseguros[i].Comision);
                    }
                    dgReaseguro.DataSource = dtReaseguro;

                    for (int i = 0; i < reaseguros.Count(); i++)
                    {
                        dgReaseguro.Rows[i].Cells["Reaseguradora"].Value = reaseguros[i].Reaseguradora;
                        dgReaseguro.Rows[i].Cells["Intermediario"].Value = reaseguros[i].Intermediario;
                        dgReaseguro.Rows[i].Cells["Treaty"].Value = (from x in db.Reaseguradoras where x.ID == reaseguros[i].Reaseguradora select x.Treaty).SingleOrDefault();
                    }
                    loadReaseguro = 0;
                    calcularReaseguros();
                }
                txtRetroValidaciones.Text += Environment.NewLine + "8) Reaseguros Cargados satisfactoriamente";
            }
            else
            {
                PolizaReaseguro[] reaseguros = (from x in db.PolizaReaseguro where x.Poliza == idPoliza && x.Activo == true select x).ToArray();
                calcularLabelReaseguro();
                if (reaseguros.Count() > 0)
                {
                    chkReaseguro.Checked = true;
                    dtReaseguro.Rows.Clear();
                    for (int i = 0; i < reaseguros.Count(); i++)
                    {
                        dtReaseguro.Rows.Add(false, reaseguros[i].PorcParticipacion, 0, reaseguros[i].Participacion, reaseguros[i].PorcComision, reaseguros[i].Comision);
                    }
                    dgReaseguro.DataSource = dtReaseguro;

                    for (int i = 0; i < reaseguros.Count(); i++)
                    {
                        dgReaseguro.Rows[i].Cells["Reaseguradora"].Value = reaseguros[i].Reaseguradora;
                        dgReaseguro.Rows[i].Cells["Intermediario"].Value = reaseguros[i].Intermediario;
                        dgReaseguro.Rows[i].Cells["Treaty"].Value = (from x in db.Reaseguradoras where x.ID == reaseguros[i].Reaseguradora select x.Treaty).SingleOrDefault();
                    }

                    calcularReaseguros();
                }
                txtRetroValidaciones.Text += Environment.NewLine + "8) Reaseguros Cargados satisfactoriamente";
            }
        }

        void cargarSublimites()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            PolizaSublimites[] sublimites = (from x in db.PolizaSublimites where x.Poliza == idPoliza select x).ToArray();
            if (sublimites.Count() > 0)
            {
                chkSublimites.Checked = true;
                dtSublimites.Rows.Clear();
                for (int i = 0; i < sublimites.Count(); i++)
                {
                    dtSublimites.Rows.Add(sublimites[i].SubLimite, sublimites[i].Monto);
                }
            }

            dgSublimites.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            txtRetroValidaciones.Text += Environment.NewLine + "3) Sublimites Cargados satisfactoriamente";
        }

        string formatearFecha(DateTime fecha, int tipoFormato)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            if (tipoFormato == 1) // fecha y hora
                return fecha.ToString("dd") + " de " + fecha.ToString("MMMM") + " de " + fecha.ToString("yyyy") + " a las " + fecha.ToString("HH:mm:ss");
            else
                return fecha.ToString("dd") + " de " + fecha.ToString("MMMM") + " de " + fecha.ToString("yyyy");
        }

        void generarCover(string file, int tipo)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            if (tipo == 1)
                txtRetroValidaciones.Text += Environment.NewLine + "Comienzo de creación de previo del cover. por favor espere...";
            else
                txtRetroValidaciones.Text += Environment.NewLine + "Comienzo de creación del cover. por favor espere...";
            string outputFile = "C:\\SmartG\\" + file; // FIX
            object m = System.Reflection.Missing.Value;
            object readOnly = (object)false;
            Word.Application ac = null;
            ac = new Word.Application();

            Word.Document doc = ac.Documents.Open(outputFile, m, readOnly,
                  m, m, m, m, m, m, m, m, m, m, m, m, m);
            try
            {
                object bookmarkName = "TipoSeguro";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["TipoSeguro"].Start;
                    object finB = doc.Bookmarks["TipoSeguro"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(txtTipoPoliza.Text);
                }

                bookmarkName = "Asegurado";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["Asegurado"].Start;
                    object finB = doc.Bookmarks["Asegurado"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(cbAseguradoMain.Text);
                }

                bookmarkName = "Poliza";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["Poliza"].Start;
                    object finB = doc.Bookmarks["Poliza"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(txtPolizaMX.Text);
                }

                bookmarkName = "Fecha";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["Fecha"].Start;
                    object finB = doc.Bookmarks["Fecha"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strEmision2);
                }

                // generamos el documento
                string outputFilePDF;
                string outputFileWord;
                string bloquea = "";
                if (tipo == 1)
                {
                    outputFilePDF = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\Previews\Preview_" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_Cover_" + polizaMX + ".pdf";
                    outputFileWord = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\Previews\Preview_" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_Cover_" + polizaMX + ".docx";
                }
                else
                {
                    outputFilePDF = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_Cover_" + polizaMX + ".pdf";
                    outputFileWord = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_Cover_" + polizaMX + ".docx";
                }
                Directory.CreateDirectory(Path.GetDirectoryName(outputFilePDF));
                // guardamos como pdf
                ((Word._Document)doc).SaveAs2(outputFilePDF, Word.Enums.WdSaveFormat.wdFormatPDF);
                // guardamos como docx. En caso de haber una contraseña en el sistema para los documentos aplicar, en caso contrario dejamos los documentos sin bloquear
                PasswordDocumentos passBloquea = (from x in db.PasswordDocumentos where x.Activo == true select x).SingleOrDefault();
                if (passBloquea != null)
                {
                    Encripcion objEncrypt = new Encripcion();
                    bloquea = objEncrypt.Decrypt(passBloquea.Password);
                }
                if (tipo == 1)
                {
                    ((Word._Document)doc).SaveAs(outputFileWord);
                }
                else
                {
                    if (bloquea == "") // caso en donde no bloqueamos
                    {
                        ((Word._Document)doc).SaveAs(outputFileWord);
                    }
                    else // bloqueamos documentos
                    {
                        ((Word._Document)doc).Protect(Word.Enums.WdProtectionType.wdAllowOnlyReading, m, bloquea, m, m);
                        ((Word._Document)doc).SaveAs(outputFileWord);
                    }
                }
            ((Word._Document)doc).Close();
                ((Word._Application)ac).Quit();
                File.Delete("C:\\SmartG\\" + file); // borramos el documento temporal
                txtRetroValidaciones.Text += Environment.NewLine + "Cover generado satisfactoriamente";

            }
            catch
            {
                ((Word._Document)doc).Close();
                ((Word._Application)ac).Quit();
                File.Delete("C:\\SmartG\\" + file); // borramos el documento temporal
                MessageBox.Show("Ocurrió un error al generar el Cover, favor de contactar al soporte técnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                controlSave = false;
            }
        }

        void generarSchedule(string file, int tipo)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            if (txtObservaciones.Text == "")
                txtObservaciones.Text = "Según especificación adjunta";
            if (tipo == 1)
                txtRetroValidaciones.Text += Environment.NewLine + "Comienzo de creación de previo del cover. por favor espere...";
            else
                txtRetroValidaciones.Text += Environment.NewLine + "Comienzo de creación del cover. por favor espere...";
            string outputFile = "C:\\SmartG\\" + file; // FIX
            object m = System.Reflection.Missing.Value;
            object readOnly = (object)false;
            Word.Application ac = null;
            ac = new Word.Application();

            Word.Document doc = ac.Documents.Open(outputFile, m, readOnly,
                  m, m, m, m, m, m, m, m, m, m, m, m, m);
            try
            {
                #region Sustituir
                object bookmarkName = "Asegurado";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["Asegurado"].Start;
                    object finB = doc.Bookmarks["Asegurado"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(cbAseguradoMain.Text);
                }
                bookmarkName = "Domicilio";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["Domicilio"].Start;
                    object finB = doc.Bookmarks["Domicilio"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strDireccionAsegu);
                }
                bookmarkName = "RFC";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["RFC"].Start;
                    object finB = doc.Bookmarks["RFC"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strRFC);
                }
                bookmarkName = "Giro";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["Giro"].Start;
                    object finB = doc.Bookmarks["Giro"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strGiroE);
                }
                bookmarkName = "TipoPoliza";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["TipoPoliza"].Start;
                    object finB = doc.Bookmarks["TipoPoliza"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(txtTipoPoliza.Text);
                }
                bookmarkName = "Poliza";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["Poliza"].Start;
                    object finB = doc.Bookmarks["Poliza"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(txtPolizaMX.Text);
                }
                bookmarkName = "Operacion";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["Operacion"].Start;
                    object finB = doc.Bookmarks["Operacion"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(lbTipoTransaccionTxt.Text);
                }
                bookmarkName = "Emision";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["Emision"].Start;
                    object finB = doc.Bookmarks["Emision"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strEmision2);
                }
                bookmarkName = "horaIni";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["horaIni"].Start;
                    object finB = doc.Bookmarks["horaIni"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(Convert.ToDateTime(dateInicioVig.Value).ToShortTimeString());
                }
                bookmarkName = "horaFin";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["horaFin"].Start;
                    object finB = doc.Bookmarks["horaFin"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(Convert.ToDateTime(dateFinVigencia.Value).ToShortTimeString());
                }
                bookmarkName = "iniVig";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["iniVig"].Start;
                    object finB = doc.Bookmarks["iniVig"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strIniVig2);
                }
                bookmarkName = "finVig";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["finVig"].Start;
                    object finB = doc.Bookmarks["finVig"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strFinVig2);
                }
                bookmarkName = "formaPago";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["formaPago"].Start;
                    object finB = doc.Bookmarks["formaPago"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strFormaPago);
                }
                bookmarkName = "Moneda";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["Moneda"].Start;
                    object finB = doc.Bookmarks["Moneda"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strMoneda);
                }
                bookmarkName = "broker";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["broker"].Start;
                    object finB = doc.Bookmarks["broker"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strBroker);
                }
                bookmarkName = "mon";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["mon"].Start;
                    object finB = doc.Bookmarks["mon"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strAbreMon);
                }
                bookmarkName = "mon2";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["mon2"].Start;
                    object finB = doc.Bookmarks["mon2"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strAbreMon);
                }
                bookmarkName = "mon3";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["mon3"].Start;
                    object finB = doc.Bookmarks["mon3"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strAbreMon);
                }
                bookmarkName = "mon4";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["mon4"].Start;
                    object finB = doc.Bookmarks["mon4"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strAbreMon);
                }
                bookmarkName = "mon5";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["mon5"].Start;
                    object finB = doc.Bookmarks["mon5"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strAbreMon);
                }
                bookmarkName = "mon6";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["mon6"].Start;
                    object finB = doc.Bookmarks["mon6"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strAbreMon);
                }
                bookmarkName = "mon7";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["mon7"].Start;
                    object finB = doc.Bookmarks["mon7"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strAbreMon);
                }
                bookmarkName = "mon8";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["mon8"].Start;
                    object finB = doc.Bookmarks["mon8"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strAbreMon);
                }
                bookmarkName = "limiteMax";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["limiteMax"].Start;
                    object finB = doc.Bookmarks["limiteMax"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(Convert.ToDouble(txtLimiteMaximo.Value).ToString("#,##0", new CultureInfo("en-US")));
                }
                bookmarkName = "prima1";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["prima1"].Start;
                    object finB = doc.Bookmarks["prima1"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(primaNeta.ToString("#,##0.00", new CultureInfo("en-US")));
                }
                bookmarkName = "prima2";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["prima2"].Start;
                    object finB = doc.Bookmarks["prima2"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(primaNeta.ToString("#,##0.00", new CultureInfo("en-US")));
                }
                bookmarkName = "descuentos";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["descuentos"].Start;
                    object finB = doc.Bookmarks["descuentos"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(descuentos.ToString("#,##0.00", new CultureInfo("en-US")));
                }
                bookmarkName = "recargos";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["recargos"].Start;
                    object finB = doc.Bookmarks["recargos"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(recargoFraccionado.ToString("#,##0.00", new CultureInfo("en-US")));
                }
                bookmarkName = "gastosExpedicion";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["gastosExpedicion"].Start;
                    object finB = doc.Bookmarks["gastosExpedicion"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(Convert.ToDouble(txtGastosExpedicion.Value).ToString("#,##0.00", new CultureInfo("en-US")));
                }
                bookmarkName = "impuestos";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["impuestos"].Start;
                    object finB = doc.Bookmarks["impuestos"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(Convert.ToDouble(txtImpuestos.Value).ToString("#,##0.00", new CultureInfo("en-US")));
                }
                bookmarkName = "total";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["total"].Start;
                    object finB = doc.Bookmarks["total"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(Convert.ToDouble(txtPrimaTotal.Value).ToString("#,##0.00", new CultureInfo("en-US")));
                }
                bookmarkName = "Observaciones";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["Observaciones"].Start;
                    object finB = doc.Bookmarks["Observaciones"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(txtObservaciones.Text);
                }
                #endregion
                // generamos el documento
                string outputFilePDF;
                string outputFileWord;
                string bloquea = "";
                if (tipo == 1)
                {
                    outputFilePDF = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\Previews\Preview_" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_Schedule_" + polizaMX + ".pdf";
                    outputFileWord = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\Previews\Preview_" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_Schedule_" + polizaMX + ".docx";
                }
                else
                {
                    outputFilePDF = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_Schedule_" + polizaMX + ".pdf";
                    outputFileWord = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_Schedule_" + polizaMX + ".docx";
                }
                Directory.CreateDirectory(Path.GetDirectoryName(outputFilePDF));
                // guardamos como pdf
                ((Word._Document)doc).SaveAs2(outputFilePDF, Word.Enums.WdSaveFormat.wdFormatPDF);
                // guardamos como docx. En caso de haber una contraseña en el sistema para los documentos aplicar, en caso contrario dejamos los documentos sin bloquear
                PasswordDocumentos passBloquea = (from x in db.PasswordDocumentos where x.Activo == true select x).SingleOrDefault();
                if (passBloquea != null)
                {
                    Encripcion objEncrypt = new Encripcion();
                    bloquea = objEncrypt.Decrypt(passBloquea.Password);
                }
                if (tipo == 1)
                {
                    ((Word._Document)doc).SaveAs(outputFileWord);
                }
                else
                {
                    if (bloquea == "") // caso en donde no bloqueamos
                    {
                        ((Word._Document)doc).SaveAs(outputFileWord);
                    }
                    else // bloqueamos documentos
                    {
                        ((Word._Document)doc).Protect(Word.Enums.WdProtectionType.wdAllowOnlyReading, m, bloquea, m, m);
                        ((Word._Document)doc).SaveAs(outputFileWord);
                    }
                }
            ((Word._Document)doc).Close();
                ((Word._Application)ac).Quit();
                File.Delete("C:\\SmartG\\" + file); // borramos el documento temporal
                txtRetroValidaciones.Text += Environment.NewLine + "Schedule generado satisfactoriamente";
            }
            catch
            {
                ((Word._Document)doc).Close();
                ((Word._Application)ac).Quit();
                File.Delete("C:\\SmartG\\" + file); // borramos el documento temporal
                MessageBox.Show("Ocurrió un error al generar el Schedule, favor de contactar al soporte técnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                controlSave = false;
            }
        }

        void generarNotaReaseguro(string file, int tipo)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            if (tipo == 1)
                txtRetroValidaciones.Text += Environment.NewLine + "Comienzo de creación de previo del cover. por favor espere...";
            else
                txtRetroValidaciones.Text += Environment.NewLine + "Comienzo de creación del cover. por favor espere...";
            string outputFile = "C:\\SmartG\\" + file; // FIX
            object m = System.Reflection.Missing.Value;
            object readOnly = (object)false;
            Word.Application ac = null;
            ac = new Word.Application();

            Word.Document doc = ac.Documents.Open(outputFile, m, readOnly,
                  m, m, m, m, m, m, m, m, m, m, m, m, m);
            try
            {
                object bookmarkName = "datosGenerales";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["DatosGenerales"].Start;
                    object finB = doc.Bookmarks["DatosGenerales"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    int fila = 1;
                    Word.Table tabla = doc.Tables.Add(rng, 2, 2);
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Tipo:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText("Cesión Opcional de Reaseguro" + Environment.NewLine); fila++;
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Reasegurado:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText("XL Seguros México, S.A. de C.V." + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Reasegurador:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText("XL Insurance Company SE." + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("MX Policy ref:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(txtPolizaMX.Text + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("XLICL Policy ref:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(txtPolizaES.Text + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Asegurado Original:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(cbAseguradoMain.Text + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Dirección:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strDireccionAsegu + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Periodo:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strIniVig + Environment.NewLine + strFinVig + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Interés:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(txtTipoPoliza.Text + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Moneda:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strMoneda + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Límite máximo de responsabilidad:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strAbreMon + "  " + limiteMaximo.ToString("#,##0.00", new CultureInfo("en-US")) + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Prima por el periodo al 100%:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strAbreMon + "  " + primaNeta.ToString("#,##0.00", new CultureInfo("en-US")) + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Soporte:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strPartReasegurada.ToString() + "% parte del " + strPartTotal.ToString() + "%" + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Comisión del reaseguro:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strComisionInter.ToString("#,##0.00", new CultureInfo("en-US")) + "%" + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Condiciones:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText("Todos los demás términos y condiciones de este reaseguro como se especifica en Optional Cession Reinsurance Treaty de que esta Nota de Cobertura concede. " + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Información:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(txtInformacionRiesgo.Text + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Fecha:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(diaAnterior + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Firma:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText("XL Insurance Company SE" + Environment.NewLine + "RGRE-801-02-320237 " + Environment.NewLine); fila++;
                }
                // generamos el documento
                string outputFilePDF;
                string outputFileWord;
                string bloquea = "";
                if (tipo == 1)
                {
                    outputFilePDF = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\Previews\Preview_" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_notaReaseguro_" + polizaMX + ".pdf";
                    outputFileWord = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\Previews\Preview_" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_notaReaseguro_" + polizaMX + ".docx";
                }
                else
                {
                    outputFilePDF = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_notaReaseguro_" + polizaMX + ".pdf";
                    outputFileWord = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_notaReaseguro_" + polizaMX + ".docx";
                }
                Directory.CreateDirectory(Path.GetDirectoryName(outputFilePDF));
                // guardamos como pdf
                ((Word._Document)doc).SaveAs2(outputFilePDF, Word.Enums.WdSaveFormat.wdFormatPDF);
                // guardamos como docx. En caso de haber una contraseña en el sistema para los documentos aplicar, en caso contrario dejamos los documentos sin bloquear
                PasswordDocumentos passBloquea = (from x in db.PasswordDocumentos where x.Activo == true select x).SingleOrDefault();
                if (passBloquea != null)
                {
                    Encripcion objEncrypt = new Encripcion();
                    bloquea = objEncrypt.Decrypt(passBloquea.Password);
                }
                if (tipo == 1)
                {
                    ((Word._Document)doc).SaveAs(outputFileWord);
                }
                else
                {
                    if (bloquea == "") // caso en donde no bloqueamos
                    {
                        ((Word._Document)doc).SaveAs(outputFileWord);
                    }
                    else // bloqueamos documentos
                    {
                        ((Word._Document)doc).Protect(Word.Enums.WdProtectionType.wdAllowOnlyReading, m, bloquea, m, m);
                        ((Word._Document)doc).SaveAs(outputFileWord);
                    }
                }
            ((Word._Document)doc).Close();
                ((Word._Application)ac).Quit();
                File.Delete("C:\\SmartG\\" + file); // borramos el documento temporal
                txtRetroValidaciones.Text += Environment.NewLine + "Nota de reaseguro generado satisfactoriamente";

            }
            catch
            {
                ((Word._Document)doc).Close();
                ((Word._Application)ac).Quit();
                File.Delete("C:\\SmartG\\" + file); // borramos el documento temporal
                MessageBox.Show("Ocurrió un error al generar la nota de reaseguro, favor de contactar al soporte técnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                controlSave = false;
            }
        }

        void generarWording(string file, int tipo)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            if (tipo == 1)
                txtRetroValidaciones.Text += Environment.NewLine + "Comienzo de creación de previo. por favor espere...";
            else
                txtRetroValidaciones.Text += Environment.NewLine + "Comienzo de creación de wording. por favor espere...";
            string outputFile = "C:\\SmartG\\" + file; // FIX
            object m = System.Reflection.Missing.Value;
            object readOnly = (object)false;
            Word.Application ac = null;
            ac = new Word.Application();

            Word.Document doc = ac.Documents.Open(outputFile, m, readOnly,
                  m, m, m, m, m, m, m, m, m, m, m, m, m);

            try
            {
                object bookmarkName = "TipoPoliza";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["TipoPoliza"].Start;
                    object finB = doc.Bookmarks["TipoPoliza"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(txtTipoPoliza.Text);
                }

                bookmarkName = "DatosGenerales";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["DatosGenerales"].Start;
                    object finB = doc.Bookmarks["DatosGenerales"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    int fila = 1;
                    int indiceWording = 1;
                    Word.Table tabla = doc.Tables.Add(rng, 2, 2);
                    tabla.Columns[1].PreferredWidth = 150;
                    tabla.Columns[2].PreferredWidth = 285;
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(indiceWording.ToString() + ".    Número de póliza:"); indiceWording++;
                    tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(polizaMX + Environment.NewLine); fila++;
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(indiceWording.ToString() + ".    Moneda:"); indiceWording++;
                    tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 0; ac.Selection.TypeText(strMoneda + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(indiceWording.ToString() + ".    Contratante:"); indiceWording++;
                    tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(cbAseguradoMain.Text); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("       Dirección:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 0; ac.Selection.TypeText(strDireccionAsegu + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("");
                    tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("RFC: " + strRFC + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("");
                    tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Giro empresarial: " + strGiroE + Environment.NewLine); fila++;
                    if (dgAseguAdicionales.Rows.Count > 0)
                    {
                        tabla.Rows.Add();
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Contratante(s) adicional(es):");
                        tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 0; ac.Selection.TypeText(strAseguAdicional + Environment.NewLine); fila++;
                    }
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(indiceWording.ToString() + ".    Periodo de la póliza:"); indiceWording++;
                    tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 0; ac.Selection.TypeText(strIniVig + Environment.NewLine + strFinVig + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(indiceWording.ToString() + ".    Límite de responsabilidad:"); indiceWording++;
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText("En el agregado para el Período de la Póliza para todas las coberturas y extensiones (con excepción de la Cobertura 2.2):"); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("");
                    tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(strLimite + " para toda y cada perdida y en el agregado anual." + Environment.NewLine + strExceso); fila++;
                    if (chkDeducibles.Checked)
                    {
                        tabla.Rows.Add();
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(indiceWording.ToString() + ".    Deducibles:" + Environment.NewLine + "(Los Deducibles no son aplicables a Pérdidas de cualquier Persona Asegurada a menos que tales Pérdidas puedan ser indemnizadas por la Sociedad)"); indiceWording++;
                        tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 0; ac.Selection.TypeText("Para cualquier reclamo" + Environment.NewLine + Environment.NewLine + strDeducibles +
                            Environment.NewLine); fila++;
                    }
                    
                    if(cbProducto.SelectedIndex != 0) // FIX temporal fl incoming
                    {
                        if (txtServiciosProfesionales.Text != "")
                        {
                            tabla.Rows.Add();
                            tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(indiceWording.ToString() + ".    Servicios Profesionales:"); indiceWording++;
                            tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(txtServiciosProfesionales.Text + Environment.NewLine); fila++;
                        }

                        tabla.Rows.Add();
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(indiceWording.ToString() + ".    Territorialidad"); indiceWording++;
                        if (cbTerritorio.Text != "Otro")
                        {
                            tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(cbTerritorio.Text + Environment.NewLine); fila++;
                        }
                        else
                        {
                            tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(txtOtroTerritorio.Text + Environment.NewLine); fila++;
                        }

                        tabla.Rows.Add();
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(indiceWording.ToString() + ".    Jurisdicción"); indiceWording++;
                        if (cbJurisdiccion.Text != "Otro")
                        {
                            tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(cbJurisdiccion.Text + Environment.NewLine); fila++;
                        }
                        else
                        {
                            tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(txtJurisOtro.Text + Environment.NewLine); fila++;
                        }

                        if (txtProrrogaNotificaciones.Text != "")
                        {
                            tabla.Rows.Add();
                            tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(indiceWording.ToString() + ".    Prorroga para Notificaciones:"); indiceWording++;
                            tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(txtProrrogaNotificaciones.Text + Environment.NewLine); fila++;
                        }
                    }

                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(indiceWording.ToString() + ".    Cálculo de la prima:"); indiceWording++;
                    tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 0; ac.Selection.ParagraphFormat.TabStops.Add(ac.CentimetersToPoints(8.5f), Word.Enums.WdAlignmentTabAlignment.wdRight, Word.Enums.WdTabLeader.wdTabLeaderDots);
                    ac.Selection.TypeText("Prima Neta\t" + primaNeta.ToString("#,##0.00", new CultureInfo("en-US")) + " " + strAbreMon + Environment.NewLine
                         + "Descuentos\t" + descuentos.ToString("#,##0.00", new CultureInfo("en-US")) + " " + strAbreMon + Environment.NewLine
                         + "Recargos\t" + recargoFraccionado.ToString("#,##0.00", new CultureInfo("en-US")) + " " + strAbreMon + Environment.NewLine
                         + "IVA (" + cbIVA.Text + ")\t" + Convert.ToDouble(txtImpuestos.Value).ToString("#,##0.00", new CultureInfo("en-US")) + " " + strAbreMon + Environment.NewLine
                             + "____________________________________________"); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("");
                    tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Prima total\t" + Convert.ToDouble(txtPrimaTotal.Value).ToString("#,##0.00", new CultureInfo("en-US")) + " " + strAbreMon + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(indiceWording.ToString() + ".    Forma de pago:"); indiceWording++;
                    tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 0; ac.Selection.TypeText(strFormaPago + Environment.NewLine); fila++;
                    if (chkRetroactiva.Checked)
                    {
                        tabla.Rows.Add();
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(indiceWording.ToString() + ".    Fecha de Retroactividad:"); indiceWording++;
                        tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strRetroactiva + Environment.NewLine); fila++;
                    }
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(indiceWording.ToString() + ".    Fecha de continuidad:"); indiceWording++;
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strContinuidad + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(indiceWording.ToString() + ".    Periodo de descubrimiento:"); indiceWording++;
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText("No aplica" + Environment.NewLine + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(indiceWording.ToString() + ".    Coberturas del seguro:"); indiceWording++;
                    if (cbProducto.SelectedIndex == 0)
                    {
                        tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strCoberturas + Environment.NewLine + Environment.NewLine + strCoberturas2 + Environment.NewLine); fila++;
                    }
                    else
                    {
                        tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strCoberturas + Environment.NewLine + Environment.NewLine); fila++;
                    }
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(indiceWording.ToString() + ".    Extensiones de Cobertura:" + Environment.NewLine + "Sublímites asegurados (incluidos dentro del Límite de Responsabilidad)"); indiceWording++;
                    tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 0; ac.Selection.ParagraphFormat.TabStops.Add(ac.CentimetersToPoints(8.5f), Word.Enums.WdAlignmentTabAlignment.wdRight, Word.Enums.WdTabLeader.wdTabLeaderDots);
                    ac.Selection.TypeText("Para los efectos del presente contrato de seguro, se hace constar que se han contratado las siguientes extensiones que se indican como 'Cubierta'. 'N/A' o el recuadro vacío, significa no contratada"
                    + Environment.NewLine + Environment.NewLine + strSublimites + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(indiceWording.ToString() + ".    Agente de seguros:"); indiceWording++;
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strBroker + Environment.NewLine); fila++;
                }

                bookmarkName = "EndososEmision";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    if (dgEndosos.Rows.Count > 0)
                    {
                        bool entro = false;
                        for (int i = 0; i < dgEndosos.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(dgEndosos.Rows[i].Cells["Aplica"].Value))
                            {
                                entro = true;
                                break;
                            }
                        }

                        if (entro)
                        {
                            object inicioB = doc.Bookmarks["EndososEmision"].Start;
                            object finB = doc.Bookmarks["EndososEmision"].End;
                            Word.Range rng = doc.Range(inicioB, finB);
                            rng.Select();

                            for (int i = 0; i < dgEndosos.Rows.Count; i++)
                            {
                                if (Convert.ToBoolean(dgEndosos.Rows[i].Cells["Aplica"].Value))
                                {
                                    bool tipoTexto = false;
                                    entro = true;
                                    ac.Selection.Font.Bold = 1; ac.Selection.ParagraphFormat.Style = Word.Enums.WdBuiltinStyle.wdStyleHeading4;
                                    ac.Selection.Font.Size = 14; ac.Selection.ParagraphFormat.Alignment = Word.Enums.WdParagraphAlignment.wdAlignParagraphCenter;
                                    ac.Selection.TypeText(dgEndosos.Rows[i].Cells["Endoso"].Text + Environment.NewLine + Environment.NewLine);
                                    inicioB = rng.StoryLength - 1;
                                    rng = doc.Range(inicioB, inicioB);
                                    rng.Select();
                                    ac.Selection.Font.Size = 10; ac.Selection.ParagraphFormat.Alignment = Word.Enums.WdParagraphAlignment.wdAlignParagraphLeft;
                                    try
                                    { Clipboard.SetText(dgEndosos.Rows[i].Cells["Texto"].Text, TextDataFormat.Rtf); tipoTexto = true; }
                                    catch
                                    { Clipboard.SetText(dgEndosos.Rows[i].Cells["Texto"].Text, TextDataFormat.Text); tipoTexto = false; }
                                    if (tipoTexto)
                                    { ac.Selection.PasteAndFormat(Word.Enums.WdRecoveryType.wdFormatOriginalFormatting); }
                                    else
                                    { ac.Selection.TypeText(Clipboard.GetText(TextDataFormat.Text) + Environment.NewLine); }
                                    doc.Words.Last.InsertBreak(Word.Enums.WdBreakType.wdPageBreak);
                                    inicioB = rng.StoryLength - 1;
                                    rng = doc.Range(inicioB, inicioB);
                                    rng.Select();
                                }
                            }
                        }
                        else
                        {
                            object inicioB = doc.Bookmarks["EndososEmision"].Start;
                            object finB = doc.Bookmarks["EndososEmision"].End;
                            Word.Range rng = doc.Range(inicioB, finB);
                            rng.Select();
                            ac.Selection.Cut();
                        }
                    }
                    else
                    {
                        object inicioB = doc.Bookmarks["EndososEmision"].Start;
                        object finB = doc.Bookmarks["EndososEmision"].End;
                        Word.Range rng = doc.Range(inicioB, finB);
                        rng.Select();
                        ac.Selection.Cut();
                    }
                }

                bookmarkName = "ClausulaCoaseguros";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    if (chkCoaseguro.Checked && cbTipoCoaseguro.Text == "Coaseguro Lider")
                    {
                        DocumentosDB extraerFirma = new DocumentosDB();
                        extraerFirma.ExtraerFirmaCEO();
                        object inicioB = doc.Bookmarks["FechaCoaseguro"].Start;
                        object finB = doc.Bookmarks["FechaCoaseguro"].End;
                        Word.Range rng = doc.Range(inicioB, finB);
                        rng.Select();
                        ac.Selection.TypeText("México, Ciudad de México a " + formatearFecha(Convert.ToDateTime(dateEmision.Value), 2));
                        inicioB = doc.Bookmarks["TablaCoaseguro"].Start;
                        finB = doc.Bookmarks["TablaCoaseguro"].End;
                        rng = doc.Range(inicioB, finB);
                        rng.Select();
                        int fila = 1;
                        int columna = 1;
                        bool brinco = false;
                        Word.Table tabla = doc.Tables.Add(rng, 3, 3);
                        #region Formatear Columnas
                        tabla.Columns[1].Width = 220;
                        tabla.Columns[2].Width = 30;
                        tabla.Columns[3].Width = 220;
                        #endregion
                        for (int i = 0; i < dgCoaseguro.Rows.Count; i++)
                        {
                            if (dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text.ToString() != "" && dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text.ToString() != "0")
                            {
                                if (i == 0)
                                {
                                    tabla.Cell(fila, columna).Select(); ac.Selection.Font.Name = "Arial"; ac.Selection.Font.Size = 10; ac.Selection.ParagraphFormat.Alignment = Word.Enums.WdParagraphAlignment.wdAlignParagraphCenter; ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Compañía líder:\n Participación: " + Convert.ToDecimal(dgCoaseguro.Rows[i].Cells["PorcentajeParticipacion"].Value).ToString("#,##0.00", new CultureInfo("en-US")) + "%"); fila++;
                                    tabla.Cell(fila, columna).Select(); ac.Selection.ParagraphFormat.Alignment = Word.Enums.WdParagraphAlignment.wdAlignParagraphCenter; ac.Selection.InlineShapes.AddPicture("C:\\SmartG\\firmaCEO.png"); fila++;
                                    tabla.Cell(fila, columna).Select(); ac.Selection.ParagraphFormat.Alignment = Word.Enums.WdParagraphAlignment.wdAlignParagraphCenter; ac.Selection.Font.Bold = 1; ac.Selection.TypeText("___________________________________" + Environment.NewLine); fila++;
                                    tabla.Cell(fila, columna).Select(); ac.Selection.ParagraphFormat.Alignment = Word.Enums.WdParagraphAlignment.wdAlignParagraphCenter; ac.Selection.Font.Bold = 1; ac.Selection.TypeText(dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text);
                                    columna = 3;
                                    fila = fila - 3;
                                    File.Delete("C:\\SmartG\\firmaCEO.png");
                                }
                                else
                                {
                                    if (columna == 1)
                                    {
                                        tabla.Cell(fila, columna).Select(); ac.Selection.Font.Name = "Arial"; ac.Selection.Font.Size = 10; ac.Selection.ParagraphFormat.Alignment = Word.Enums.WdParagraphAlignment.wdAlignParagraphCenter; ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Compañía seguidora:\n Participación: " + Convert.ToDecimal(dgCoaseguro.Rows[i].Cells["PorcentajeParticipacion"].Value).ToString("#,##0.00", new CultureInfo("en-US")) + "%"); fila++;
                                        tabla.Rows[fila].Height = 115; fila++;
                                        tabla.Cell(fila, columna).Select(); ac.Selection.ParagraphFormat.Alignment = Word.Enums.WdParagraphAlignment.wdAlignParagraphCenter; ac.Selection.Font.Bold = 1; ac.Selection.TypeText("___________________________________" + Environment.NewLine); fila++;
                                        tabla.Cell(fila, columna).Select(); ac.Selection.ParagraphFormat.Alignment = Word.Enums.WdParagraphAlignment.wdAlignParagraphCenter; ac.Selection.Font.Bold = 1; ac.Selection.TypeText(dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text);
                                        columna = 3;
                                        fila = fila - 3;
                                    }
                                    else
                                    {
                                        tabla.Cell(fila, columna).Select(); ac.Selection.Font.Name = "Arial"; ac.Selection.Font.Size = 10; ac.Selection.ParagraphFormat.Alignment = Word.Enums.WdParagraphAlignment.wdAlignParagraphCenter; ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Compañía seguidora:\n Participación: " + Convert.ToDecimal(dgCoaseguro.Rows[i].Cells["PorcentajeParticipacion"].Value).ToString("#,##0.00", new CultureInfo("en-US")) + "%"); fila = fila + 2;
                                        tabla.Cell(fila, columna).Select(); ac.Selection.ParagraphFormat.Alignment = Word.Enums.WdParagraphAlignment.wdAlignParagraphCenter; ac.Selection.Font.Bold = 1; ac.Selection.TypeText("___________________________________" + Environment.NewLine); fila++;
                                        tabla.Cell(fila, columna).Select(); ac.Selection.ParagraphFormat.Alignment = Word.Enums.WdParagraphAlignment.wdAlignParagraphCenter; ac.Selection.Font.Bold = 1; ac.Selection.TypeText(dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text + Environment.NewLine);
                                        brinco = true;
                                    }
                                }

                                if (i + 1 != dgCoaseguro.Rows.Count())
                                {
                                    if (brinco && i != 0)
                                    {
                                        columna = 1;
                                        fila = fila + 2;
                                        #region Añadimos filas
                                        tabla.Rows.Add();
                                        tabla.Rows.Add();
                                        tabla.Rows.Add();
                                        tabla.Rows.Add();
                                        tabla.Rows.Add();
                                        #endregion
                                        brinco = false;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        object inicioB = doc.Bookmarks["ClausulaCoaseguros"].Start;
                        object finB = doc.Bookmarks["ClausulaCoaseguros"].End;
                        Word.Range rng = doc.Range(inicioB, finB);
                        rng.Select();
                        ac.Selection.Cut();
                    }
                }

                bookmarkName = "ClausulaTie";
                if (chkTieInLimits.Checked) // si no tiene tie in limits cae en la excepcion
                {
                    try
                    {
                        object inicioB = doc.Bookmarks["TiePoliza"].Start;
                        object finB = doc.Bookmarks["TiePoliza"].End;
                        Word.Range rng = doc.Range(inicioB, finB);
                        rng.Select();
                        ac.Selection.TypeText(numPolizaGlobal);

                        inicioB = doc.Bookmarks["TieNombre"].Start;
                        finB = doc.Bookmarks["TieNombre"].End;
                        rng = doc.Range(inicioB, finB);
                        rng.Select();
                        ac.Selection.TypeText(titularPolizaGlobal);

                        inicioB = doc.Bookmarks["TieNumPoliza"].Start;
                        finB = doc.Bookmarks["TieNumPoliza"].End;
                        rng = doc.Range(inicioB, finB);
                        rng.Select();
                        ac.Selection.TypeText(polizaMX);

                        inicioB = doc.Bookmarks["TieNombreTitular"].Start;
                        finB = doc.Bookmarks["TieNombreTitular"].End;
                        rng = doc.Range(inicioB, finB);
                        rng.Select();
                        ac.Selection.TypeText(cbAseguradoMain.Text);

                        inicioB = doc.Bookmarks["TieNombre2"].Start;
                        finB = doc.Bookmarks["TieNombre2"].End;
                        rng = doc.Range(inicioB, finB);
                        rng.Select();
                        ac.Selection.TypeText(titularPolizaGlobal);

                        inicioB = doc.Bookmarks["TieMon"].Start;
                        finB = doc.Bookmarks["TieMon"].End;
                        rng = doc.Range(inicioB, finB);
                        rng.Select();
                        ac.Selection.TypeText(abreMonedaTieIn);

                        inicioB = doc.Bookmarks["TieLimite"].Start;
                        finB = doc.Bookmarks["TieLimite"].End;
                        rng = doc.Range(inicioB, finB);
                        rng.Select();
                        ac.Selection.TypeText(limiteMaximoTieIn.ToString());
                    }
                    catch
                    {
                        if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                        {
                            object inicioB = doc.Bookmarks["ClausulaTie"].Start;
                            object finB = doc.Bookmarks["ClausulaTie"].End;
                            Word.Range rng = doc.Range(inicioB, finB);
                            rng.Select();
                            ac.Selection.Cut();
                        }
                    }
                }
                else
                {
                    if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                    {
                        object inicioB = doc.Bookmarks["ClausulaTie"].Start;
                        object finB = doc.Bookmarks["ClausulaTie"].End;
                        Word.Range rng = doc.Range(inicioB, finB);
                        rng.Select();
                        ac.Selection.Cut();
                    }
                }

                bookmarkName = "TablaContenidos";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["TablaContenidos"].Start;
                    object finB = doc.Bookmarks["TablaContenidos"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    Word.TableOfContents tablaC = doc.TablesOfContents.Add(rng);
                    tablaC.Update();
                }

                // generamos el documento
                string outputFilePDF;
                string outputFileWord;
                string bloquea = "";
                if (tipo == 1)
                {
                    outputFilePDF = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\Previews\Preview_" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_Wording_" + polizaMX + ".pdf";
                    outputFileWord = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\Previews\Preview_" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_Wording_" + polizaMX + ".docx";
                }
                else
                {
                    outputFilePDF = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_Wording_" + polizaMX + ".pdf";
                    outputFileWord = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_Wording_" + polizaMX + ".docx";
                }
                Directory.CreateDirectory(Path.GetDirectoryName(outputFilePDF));
                // guardamos como pdf
                ((Word._Document)doc).SaveAs2(outputFilePDF, Word.Enums.WdSaveFormat.wdFormatPDF);
                // guardamos como docx. En caso de haber una contraseña en el sistema para los documentos aplicar, en caso contrario dejamos los documentos sin bloquear
                PasswordDocumentos passBloquea = (from x in db.PasswordDocumentos where x.Activo == true select x).SingleOrDefault();
                if (passBloquea != null)
                {
                    Encripcion objEncrypt = new Encripcion();
                    bloquea = objEncrypt.Decrypt(passBloquea.Password);
                }
                if (tipo == 1)
                {
                    ((Word._Document)doc).SaveAs(outputFileWord);
                }
                else
                {
                    if (bloquea == "") // caso en donde no bloqueamos
                    {
                        ((Word._Document)doc).SaveAs(outputFileWord);
                    }
                    else // bloqueamos documentos
                    {
                        ((Word._Document)doc).Protect(Word.Enums.WdProtectionType.wdAllowOnlyReading, m, bloquea, m, m);
                        ((Word._Document)doc).SaveAs(outputFileWord);
                    }
                }
            ((Word._Document)doc).Close();
                ((Word._Application)ac).Quit();
                File.Delete("C:\\SmartG\\" + file); // borramos el documento temporal
                txtRetroValidaciones.Text += Environment.NewLine + "Wording generado satisfactoriamente";
            }
            catch
            {
                ((Word._Document)doc).Close();
                ((Word._Application)ac).Quit();
                File.Delete("C:\\SmartG\\" + file); // borramos el documento temporal
                MessageBox.Show("Ocurrió un error al generar el wording, favor de contactar al soporte técnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                controlSave = false;
            }
        }

        public void GenerarInstrucciones(string file)
        {
            string inputFile = "C:\\SmartG\\" + file;
            string outputFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + "\\" + file;
            Directory.CreateDirectory(Path.GetDirectoryName(outputFile));
            File.Copy(inputFile, outputFile, true);
            File.Delete(inputFile);

            dbSmartGDataContext db = new dbSmartGDataContext();
            Excel.Application xlApp = new Excel.Application();
            try
            {
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(outputFile);
                Excel.Worksheet workSheet = (Excel.Worksheet)xlWorkbook.Worksheets[1];
                //xlApp.Visible = true;

                #region POLIZA MX

                #region Seccion master
                workSheet.Range("C2").Value = polizaMX;
                workSheet.Range("C6").Value = tituloPolizaGenius;
                workSheet.Range("C7").Value = (from x in db.Clientes where x.ID == Convert.ToInt32(cbAseguradoMain.Value) select x.NameCode).SingleOrDefault();
                workSheet.Range("C8").Value = (from x in db.Brokers where x.ID == Convert.ToInt32(cbBroker.Value) select x.BrokerCode).SingleOrDefault();
                workSheet.Range("C9").Value = cbCoaseguradorLider.Text;
                workSheet.Range("C10").Value = txtPAM.Text;
                workSheet.Range("C11").Value = cbPrograma.Text;
                workSheet.Range("C12").Value = cbProducingOffice.Text;
                workSheet.Range("E8").Value = polizaES;
                workSheet.Range("E9").Value = "ID";
                workSheet.Range("E10").Value = (from x in db.Pais where x.ID == Convert.ToInt32(cbCountry.Value) select x.Codigo2 + " - " + x.NombreIngles).SingleOrDefault();

                workSheet.Range("C15").Value = formatearFecha(Convert.ToDateTime(dateInicioVig.Value), 1);
                workSheet.Range("C16").Value = formatearFecha(Convert.ToDateTime(dateFinVigencia.Value), 1);
                if (chkLTARenegotiable.Checked)
                {
                    workSheet.Range("C17").Value = "Renegotiable";
                    workSheet.Range("E17").Value = LTAInception.ToString();
                    workSheet.Range("E18").Value = LTAExpiry.ToString();
                }
                else
                {
                    workSheet.Range("C17").Value = "No";
                    workSheet.Range("E17").Value = "";
                    workSheet.Range("E18").Value = "";
                }

                workSheet.Range("E15").Value = emision.Year.ToString();
                workSheet.Range("E16").Value = "Do not modify default value";

                switch (cbDelimitacionTerritorial.SelectedIndex)
                {
                    case 0:
                        workSheet.Range("C21").Value = "MX";
                        workSheet.Range("E44").Value = "MX";
                        break;
                    case 1:
                        workSheet.Range("C21").Value = "WXUSC";
                        workSheet.Range("E44").Value = "WXUSC";
                        break;
                    case 2:
                        workSheet.Range("C21").Value = "WW";
                        workSheet.Range("E44").Value = "WW";
                        break;
                }

                workSheet.Range("C22").Value = "Yes";
                if (cbEstructuraLimite.SelectedIndex == 0)
                    workSheet.Range("C23").Value = "Yes";
                else
                    workSheet.Range("C23").Value = "No";

                workSheet.Range("E21").Value = cbToB.Text;
                if (chkPortafolio.Checked)
                    workSheet.Range("E22").Value = "Yes";
                else
                    workSheet.Range("E22").Value = "No";
                #endregion

                #region Seccion terms & conditions
                workSheet.Range("C27").Value = cbMoneda.Text;
                workSheet.Range("C28").Value = "INS - Payment from original Insurer";
                switch (cbFormaPago.Text)
                {
                    case "Contado":
                        workSheet.Range("C29").Value = "ANN";
                        workSheet.Range("E28").Value = "BAS - Basic Processing";
                        break;
                    case "Anual":
                        workSheet.Range("C29").Value = "ANN";
                        workSheet.Range("E28").Value = "BAS - Basic Processing";
                        break;
                    case "Mensual":
                        workSheet.Range("C29").Value = "MTH";
                        workSheet.Range("E28").Value = "INS";
                        break;
                    case "Trimestral":
                        workSheet.Range("C29").Value = "QTR";
                        workSheet.Range("E28").Value = "INS";
                        break;
                    case "Semestral":
                        workSheet.Range("C29").Value = "HLF";
                        workSheet.Range("E28").Value = "INS";
                        break;
                }
                workSheet.Range("C30").Value = paymentCondition;
                workSheet.Range("C32").Value = "MAN - Manual Renewal";
                workSheet.Range("E27").Value = cbMoneda.Text;
                workSheet.Range("E29").Value = txtNumPagos.Value.ToString();
                workSheet.Range("E30").Value = "30";
                if (chkAjustable.Checked)
                    workSheet.Range("C35").Value = "Yes";
                else
                    workSheet.Range("C35").Value = "No";
                workSheet.Range("C37").Value = "30";
                workSheet.Range("E35").Value = "W -XL Insurance";
                workSheet.Range("E36").Value = "Yes";
                workSheet.Range("E37").Value = "CMT - Payments to claimant";
                #endregion

                #region Seccion de coberturas
                workSheet.Range("B41").Value = "ROW: Rest of the World";
                workSheet.Range("C43").Value = "703";
                workSheet.Range("C44").Value = cbToB.Text;
                workSheet.Range("E43").Value = cbActivityCode.Text;
                if (chkRetroactiva.Checked)
                    workSheet.Range("C48").Value = fechaRetroactiva.ToString();
                else
                    workSheet.Range("C48").Value = "N/A";

                int filaInicio = 50;
                workSheet.Range("B" + (filaInicio).ToString()).Value = "Limit PL/PR Combinned (LPPC)"; filaInicio++;

                workSheet.Range("B" + (filaInicio).ToString()).Value = "PREM PL/PR Combinned (PPPC)"; filaInicio++;
                Excel.Range r = workSheet.get_Range("A" + (filaInicio).ToString(), "A" + (filaInicio).ToString()).EntireRow;
                r.Insert(XlInsertShiftDirection.xlShiftDown);
                workSheet.Range("B" + (filaInicio).ToString() + ":E" + (filaInicio).ToString()).Merge();

                if (chkDeducibles.Checked)
                {
                    for (int i = 0; i < dgDeducibles.Rows.Count; i++)
                    {
                        Coberturas cobTMP = (from x in db.Coberturas where x.Cobertura == dgDeducibles.Rows[i].Cells["Deducible"].Text select x).FirstOrDefault();
                        string strDeduTmp = "";
                        if (cobTMP != null)
                        {
                            strDeduTmp = "Deduct " + cobTMP.CoberturaIngles + " (D" + cobTMP.GeniusCode + ")";
                        }
                        else
                        {
                            strDeduTmp = "Deduct Other" + dgDeducibles.Rows[i].Cells["Deducible"].Text + " (D" + "OTH" + ")";
                        }

                        workSheet.Range("B" + (filaInicio).ToString()).Value = strDeduTmp; filaInicio++;

                        if (i + 1 < dgDeducibles.Rows.Count)
                        {
                            r = workSheet.get_Range("A" + (filaInicio).ToString(), "A" + (filaInicio).ToString()).EntireRow;
                            r.Insert(XlInsertShiftDirection.xlShiftDown);
                            workSheet.Range("B" + (filaInicio).ToString() + ":E" + (filaInicio).ToString()).Merge();
                        }
                    }
                }

                int desplace = dgDeducibles.Rows.Count;
                #endregion

                #region Seccion limites
                workSheet.Range("C" + (53 + desplace).ToString()).Value = "Limit PL/PR Combinned (LPPC)";
                if (cbEstructuraLimite.SelectedIndex == 0)
                    workSheet.Range("C" + (54 + desplace).ToString()).Value = "N/A";
                else
                    workSheet.Range("C" + (54 + desplace).ToString()).Value = txtSujecion.Value.ToString();
                workSheet.Range("C" + (56 + desplace).ToString()).Value = double.Parse(txtLimiteMaximo.Value.ToString()).ToString("#,##0.00", new CultureInfo("en-US"));
                workSheet.Range("C" + (57 + desplace).ToString()).Value = "";
                workSheet.Range("E" + (54 + desplace).ToString()).Value = "X";
                workSheet.Range("E" + (55 + desplace).ToString()).Value = modoClaims;
                workSheet.Range("E" + (56 + desplace).ToString()).Value = "Yes";
                workSheet.Range("E" + (57 + desplace).ToString()).Value = "";
                #endregion

                #region Seccion deducibles
                if (chkDeducibles.Checked) // Se salta todo el proceso si No hay deducibles
                {
                    for (int i = 0; i < dgDeducibles.Rows.Count; i++)
                    {
                        Coberturas cobTMP = (from x in db.Coberturas where x.Cobertura == dgDeducibles.Rows[i].Cells["Deducible"].Text select x).FirstOrDefault();
                        string strDeduTmp = "";
                        if (cobTMP != null)
                        {
                            strDeduTmp = "Deduct " + cobTMP.CoberturaIngles + " (D" + cobTMP.GeniusCode + ")";
                        }
                        else
                        {
                            strDeduTmp = "Deduct Other" + dgDeducibles.Rows[i].Cells["Deducible"].Text + " (D" + "OTH" + ")";
                        }

                        //datos del deducible individual

                        string notes = "{Leave empty}"; if (Convert.ToBoolean(dgDeducibles.Rows[i].Cells["SIR"].Value)) { notes = "SIR"; }
                        string maxDeduc = double.Parse(dgDeducibles.Rows[i].Cells["Maximo"].Value.ToString()).ToString("#,##0.00", new CultureInfo("en-US"));
                        string minDeduc = double.Parse(dgDeducibles.Rows[i].Cells["Minimo"].Value.ToString()).ToString("#,##0.00", new CultureInfo("en-US"));
                        string aggregationDeduc = double.Parse(dgDeducibles.Rows[i].Cells["Agregado"].Value.ToString()).ToString("#,##0.00", new CultureInfo("en-US"));
                        string percentajeDeduc = double.Parse(dgDeducibles.Rows[i].Cells["Porcentaje"].Value.ToString()).ToString("#,##0.00", new CultureInfo("en-US")) + " %";

                        workSheet.Range("C" + (61 + desplace).ToString()).Value = strDeduTmp;
                        workSheet.Range("C" + (62 + desplace).ToString()).Value = maxDeduc;
                        workSheet.Range("C" + (63 + desplace).ToString()).Value = aggregationDeduc;
                        workSheet.Range("E" + (61 + desplace).ToString()).Value = notes;
                        workSheet.Range("E" + (62 + desplace).ToString()).Value = minDeduc;
                        workSheet.Range("E" + (63 + desplace).ToString()).Value = percentajeDeduc;

                        if (i != dgDeducibles.Rows.Count - 1) //Copia un nuevo set de filas
                        {
                            workSheet.Range((61 + desplace).ToString() + ":" + (63 + desplace).ToString()).Copy();
                            desplace = desplace + 3;
                            Excel.Range oRange = workSheet.Range("B" + (61 + desplace).ToString()).EntireRow;
                            oRange.Insert(XlInsertShiftDirection.xlShiftDown);
                            workSheet.Range("C" + (61 + desplace).ToString()).Value = "";
                            workSheet.Range("C" + (62 + desplace).ToString()).Value = "";
                            workSheet.Range("C" + (63 + desplace).ToString()).Value = "";
                            workSheet.Range("E" + (61 + desplace).ToString()).Value = "";
                            workSheet.Range("E" + (62 + desplace).ToString()).Value = "";
                            workSheet.Range("E" + (63 + desplace).ToString()).Value = "";
                        }
                    }
                }
                #endregion

                #region Seccion prima
                workSheet.Range("C" + (67 + desplace).ToString()).Value = "001 - Standard";
                workSheet.Range("C" + (68 + desplace).ToString()).Value = "";
                workSheet.Range("C" + (69 + desplace).ToString()).Value = double.Parse(txtPrimaNeta.Value.ToString()).ToString("#,##0.00", new CultureInfo("en-US"));
                workSheet.Range("C" + (70 + desplace).ToString()).Value = "";
                workSheet.Range("E" + (67 + desplace).ToString()).Value = "";
                workSheet.Range("E" + (68 + desplace).ToString()).Value = double.Parse(txtSujecion.Value.ToString()).ToString("#,##0.00", new CultureInfo("en-US"));
                workSheet.Range("E" + (69 + desplace).ToString()).Value = cbTipoPrima.Text;
                workSheet.Range("E" + (70 + desplace).ToString()).Value = double.Parse(txtPrimaNeta.Value.ToString()).ToString("#,##0.00", new CultureInfo("en-US"));
                #endregion

                #region Seccion participantes
                if (chkAdminPremium.Checked)
                    workSheet.Range("C" + (79 + desplace).ToString()).Value = "Yes";
                else
                    workSheet.Range("C" + (79 + desplace).ToString()).Value = "No";

                if (chkAdminClaims.Checked)
                    workSheet.Range("E" + (79 + desplace).ToString()).Value = "Yes";
                else
                    workSheet.Range("E" + (79 + desplace).ToString()).Value = "No";

                if (chkGenerateDocuments.Checked)
                    workSheet.Range("C" + (80 + desplace).ToString()).Value = "Yes";
                else
                    workSheet.Range("C" + (80 + desplace).ToString()).Value = "No";


                string coaStatus = "";
                if (!chkCoaseguro.Checked) { coaStatus = "sin Coaseguro"; }
                else coaStatus = cbTipoCoaseguro.Text;

                switch (coaStatus)
                {
                    case "sin Coaseguro":

                        workSheet.Range("C" + (83 + desplace).ToString()).Value = "I - Insurer";
                        workSheet.Range("C" + (84 + desplace).ToString()).Value = "Q2";
                        workSheet.Range("C" + (85 + desplace).ToString()).Value = "100.00%";
                        workSheet.Range("E" + (83 + desplace).ToString()).Value = "Yes";
                        workSheet.Range("E" + (84 + desplace).ToString()).Value = "XL Seguros México";
                        workSheet.Range("E" + (85 + desplace).ToString()).Value = "100.00%";



                        workSheet.Range("C" + (89 + desplace).ToString()).Value = "{Do no add any value}";
                        workSheet.Range("C" + (90 + desplace).ToString()).Value = "{Do no add any value}";
                        workSheet.Range("C" + (91 + desplace).ToString()).Value = "{Do no add any value}";
                        workSheet.Range("E" + (89 + desplace).ToString()).Value = "{Do no add any value}";
                        workSheet.Range("E" + (90 + desplace).ToString()).Value = "{Do no add any value}";


                        break;

                    case "Coaseguro Seguidor":

                        workSheet.Range("C" + (83 + desplace).ToString()).Value = "I - Insurer";
                        workSheet.Range("C" + (84 + desplace).ToString()).Value = "Q2";
                        workSheet.Range("C" + (85 + desplace).ToString()).Value = "100.00%";
                        workSheet.Range("E" + (83 + desplace).ToString()).Value = "Yes";
                        workSheet.Range("E" + (84 + desplace).ToString()).Value = "XL Seguros México";
                        workSheet.Range("E" + (85 + desplace).ToString()).Value = txtPorParticipacionXL.Value.ToString() + " %";

                        workSheet.Range("C" + (89 + desplace).ToString()).Value = "{Do no add any value}";
                        workSheet.Range("C" + (90 + desplace).ToString()).Value = "{Do no add any value}";
                        workSheet.Range("C" + (91 + desplace).ToString()).Value = "{Do no add any value}";
                        workSheet.Range("E" + (89 + desplace).ToString()).Value = "{Do no add any value}";
                        workSheet.Range("E" + (90 + desplace).ToString()).Value = "{Do no add any value}";
                        break;

                    case "Coaseguro Lider":

                        workSheet.Range("C" + (83 + desplace).ToString()).Value = "I - Insurer";
                        workSheet.Range("C" + (84 + desplace).ToString()).Value = "Q2";
                        workSheet.Range("C" + (85 + desplace).ToString()).Value = "100.00%";
                        workSheet.Range("E" + (83 + desplace).ToString()).Value = "Yes";
                        workSheet.Range("E" + (84 + desplace).ToString()).Value = "XL Seguros México";
                        workSheet.Range("E" + (85 + desplace).ToString()).Value = "100.00%";


                        for (int i = 0; i < dgCoaseguro.Rows.Count; i++)
                        {
                            if (dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text != "")
                            {
                                string minorParticipationRtnd = "";
                                string minorParticipationNameCode = "";
                                string minorParticipationName = "";
                                string minorParticipationLine = "";
                                string minorParticipationWhole = "";

                                Coaseguradora coaseTMP = (from x in db.Coaseguradoras1 where x.ID == Convert.ToInt32(dgCoaseguro.Rows[i].Cells["Coaseguradora"].Value) select x).SingleOrDefault();

                                if (i == 0) { minorParticipationRtnd = "Yes"; } else { minorParticipationRtnd = "No"; }
                                minorParticipationNameCode = coaseTMP.Codigo;
                                minorParticipationName = coaseTMP.Nombre;
                                minorParticipationLine = double.Parse(dgCoaseguro.Rows[i].Cells["PorcentajeParticipacion"].Value.ToString()).ToString("#,##0.00", new CultureInfo("en-US"));
                                minorParticipationWhole = minorParticipationLine;

                                workSheet.Range("C" + (89 + desplace).ToString()).Value = minorParticipationRtnd;
                                workSheet.Range("C" + (90 + desplace).ToString()).Value = minorParticipationName;
                                workSheet.Range("C" + (91 + desplace).ToString()).Value = minorParticipationWhole;
                                workSheet.Range("E" + (89 + desplace).ToString()).Value = minorParticipationNameCode;
                                workSheet.Range("E" + (90 + desplace).ToString()).Value = minorParticipationLine;

                                if (i != dgCoaseguro.Rows.Count - 1) //Copia un nuevo set de filas
                                {
                                    workSheet.Range((89 + desplace).ToString() + ":" + (91 + desplace).ToString()).Copy();
                                    desplace = desplace + 3;
                                    Excel.Range oRange = workSheet.Range("B" + (89 + desplace).ToString()).EntireRow;
                                    oRange.Insert(XlInsertShiftDirection.xlShiftDown);
                                    workSheet.Range("C" + (89 + desplace).ToString()).Value = "";
                                    workSheet.Range("C" + (90 + desplace).ToString()).Value = "";
                                    workSheet.Range("C" + (91 + desplace).ToString()).Value = "";
                                    workSheet.Range("E" + (89 + desplace).ToString()).Value = "";
                                    workSheet.Range("E" + (90 + desplace).ToString()).Value = "";
                                }
                            }
                        }
                        break;
                }
                #endregion

                #region Seccion deductibles
                int deductionsCount = 0;
                var decutionsSrt = new List<string>();
                int rngcount = 0;
                if (cbIVA.Text == "16%") // agrega el IVA
                {
                    rngcount = rngcount + 10;
                    decutionsSrt.Add(rngcount.ToString());
                    decutionsSrt.Add("PVMPCT");
                    decutionsSrt.Add("16.000000");
                    decutionsSrt.Add("4 - AC as Premium");
                    deductionsCount++;
                }
                if (chkIsBrokerage.Checked) // Agrega el Brokerage
                {
                    rngcount = rngcount + 10;
                    decutionsSrt.Add(rngcount.ToString());
                    decutionsSrt.Add("BRKPCT");
                    decutionsSrt.Add(txtBrokeragePorc.Value.ToString());
                    decutionsSrt.Add("Broker/Agent");
                    deductionsCount++;
                }
                if (chkIsBrokerage.Checked && cbIVA.Text == "16%") // Agrega el IVA del Brokerage
                {
                    rngcount = rngcount + 10;
                    decutionsSrt.Add(rngcount.ToString());
                    decutionsSrt.Add("BVMPCT");
                    decutionsSrt.Add("16.000000");
                    decutionsSrt.Add("Broker/Agent");
                    deductionsCount++;
                }
                var decutionsSrtFull = decutionsSrt.ToArray();

                int Conta = 0;

                for (int i = 0; i < deductionsCount; i++)
                {
                    workSheet.Range("C" + (96 + desplace).ToString()).Value = decutionsSrtFull[Conta + 0];
                    workSheet.Range("C" + (97 + desplace).ToString()).Value = decutionsSrtFull[Conta + 2];
                    workSheet.Range("E" + (96 + desplace).ToString()).Value = decutionsSrtFull[Conta + 1];
                    workSheet.Range("E" + (97 + desplace).ToString()).Value = decutionsSrtFull[Conta + 3];
                    Conta = Conta + 4;
                    if (i != deductionsCount - 1) //Copia un nuevo set de filas
                    {
                        workSheet.Range((96 + desplace).ToString() + ":" + (97 + desplace).ToString()).Copy();
                        desplace = desplace + 2;
                        Excel.Range oRange = workSheet.Range("B" + (96 + desplace).ToString()).EntireRow;
                        oRange.Insert(XlInsertShiftDirection.xlShiftDown);
                        workSheet.Range("C" + (96 + desplace).ToString()).Value = "";
                        workSheet.Range("C" + (97 + desplace).ToString()).Value = "";
                        workSheet.Range("E" + (96 + desplace).ToString()).Value = "";
                        workSheet.Range("E" + (97 + desplace).ToString()).Value = "";
                    }
                }
                #endregion

                #region Seccion reaseguros MX
                if (!chkReaseguro.Checked) // Caso sin Reaseguro
                {
                    workSheet.Range("C" + (101 + desplace).ToString()).Value = "{Do not add any row}";
                }
                else // Caso con Reaseguro
                {
                    double netCession = 0;
                    for (int i = 0; i < dgReaseguro.Rows.Count; i++)
                    {
                        double RIPREMper = 0;
                        double RIPREMcur = 0;
                        double RICper = 0;
                        double RICcur = 0;

                        Reaseguradoras reaseTMP = (from x in db.Reaseguradoras where x.ID == Convert.ToInt32(dgReaseguro.Rows[i].Cells["Reaseguradora"].Value) select x).SingleOrDefault();

                        if (i == 0) // caso para la reaseguradora por defecto
                        {
                            for (int j = 1; j < dgReaseguro.Rows.Count; j++)
                            {
                                if (Convert.ToBoolean(dgReaseguro.Rows[j].Cells["Treaty"].Value))
                                {
                                    RIPREMper += Convert.ToDouble(dgReaseguro.Rows[j].Cells["PorcentajeParticipacion"].Value);
                                    RICcur += Convert.ToDouble(dgReaseguro.Rows[j].Cells["Comision"].Value);
                                }
                            }
                            RIPREMcur = (RIPREMper / 100) * Convert.ToDouble(cantidadReaseguro);
                            RICper = RICcur / RIPREMcur;
                            netCession += -RIPREMcur + RICcur;

                            // Pega en las instrucciones
                            workSheet.Range("C" + (101 + desplace).ToString()).Value = "10";
                            workSheet.Range("C" + (102 + desplace).ToString()).Value = reaseTMP.RI_Policy;
                            workSheet.Range("C" + (103 + desplace).ToString()).Value = (RIPREMper / 100).ToString("P6");
                            workSheet.Range("C" + (104 + desplace).ToString()).Value = "Current";
                            workSheet.Range("E" + (101 + desplace).ToString()).Value = "Yes";
                            workSheet.Range("E" + (102 + desplace).ToString()).Value = "{Automatic Generated, do not change default}";
                            workSheet.Range("E" + (103 + desplace).ToString()).Value = RICper.ToString("P6");
                            workSheet.Range("E" + (104 + desplace).ToString()).Value = "RI/*BK";
                        }

                        else if (!Convert.ToBoolean(dgReaseguro.Rows[i].Cells["Treaty"].Value) && dgReaseguro.Rows[i].Cells["Reaseguradora"].Text != "") // nacionales
                        {
                            RIPREMper = Convert.ToDouble(dgReaseguro.Rows[i].Cells["PorcentajeParticipacion"].Value); // % participacion
                            RIPREMcur = Convert.ToDouble(dgReaseguro.Rows[i].Cells["Participacion"].Value); // $ participacion
                            RICper = Convert.ToDouble(dgReaseguro.Rows[i].Cells["PorcentajeComision"].Value) / 100; // % comision
                            RICcur = Convert.ToDouble(dgReaseguro.Rows[i].Cells["Comision"].Value); // $ comision
                            netCession += -RIPREMcur + RICcur;

                            // Genera nuevas filas y las limpia
                            workSheet.Range((101 + desplace).ToString() + ":" + (104 + desplace).ToString()).Copy();
                            desplace = desplace + 4;
                            Excel.Range oRange = workSheet.Range("B" + (101 + desplace).ToString()).EntireRow;
                            oRange.Insert(XlInsertShiftDirection.xlShiftDown);
                            workSheet.Range("C" + (101 + desplace).ToString()).Value = "";
                            workSheet.Range("C" + (102 + desplace).ToString()).Value = "";
                            workSheet.Range("C" + (103 + desplace).ToString()).Value = "";
                            workSheet.Range("C" + (104 + desplace).ToString()).Value = "";
                            workSheet.Range("E" + (101 + desplace).ToString()).Value = "";
                            workSheet.Range("E" + (102 + desplace).ToString()).Value = "";
                            workSheet.Range("E" + (103 + desplace).ToString()).Value = "";
                            workSheet.Range("E" + (104 + desplace).ToString()).Value = "";

                            // Pega las nuevas variables
                            workSheet.Range("C" + (101 + desplace).ToString()).Value = "20";
                            workSheet.Range("C" + (102 + desplace).ToString()).Value = reaseTMP.RI_Policy;
                            workSheet.Range("C" + (103 + desplace).ToString()).Value = (RIPREMper / 100).ToString("P6");
                            workSheet.Range("C" + (104 + desplace).ToString()).Value = "Current";
                            workSheet.Range("E" + (101 + desplace).ToString()).Value = "Yes";
                            workSheet.Range("E" + (102 + desplace).ToString()).Value = "{Automatic Generated, do not change default}";
                            workSheet.Range("E" + (103 + desplace).ToString()).Value = RICper.ToString("P6");
                            workSheet.Range("E" + (104 + desplace).ToString()).Value = "RI/*BK";
                        }

                    }

                    // Obtiene el MX NET
                    // MX Gross
                    double iva_per = .16;
                    if (cbIVA.Text == "16%") { iva_per = 0.16; }
                    else iva_per = 0;
                    double netPrima = Convert.ToDouble(cantidadReaseguro) + (Convert.ToDouble(cantidadReaseguro) * iva_per);

                    double netBroker = (Convert.ToDouble(txtBrokeragePorc.Value) / 100) * Convert.ToDouble(cantidadReaseguro) * (1 + iva_per);
                    double netReceivable = netPrima - netBroker;

                    // MX Outwards

                    double MXNet = netReceivable + netCession;

                    workSheet.Range("B" + (105 + desplace).ToString()).Value = "(Validation) MX Net";
                    workSheet.Range("C" + (105 + desplace).ToString()).Value = double.Parse(MXNet.ToString()).ToString("#,##0.00", new CultureInfo("en-US"));
                }
                #endregion

                #endregion

                workSheet.Range("C:C").Columns.AutoFit();
                workSheet.Range("E:E").Columns.AutoFit();
                xlApp.DisplayAlerts = false;
                xlApp.ActiveWorkbook.Save();
                xlApp.Quit();
                xlApp.Dispose();

                #region POLIZA ES
                #region Guardado sin póliza ES
                if (!chkReaseguro.Checked)
                {
                    Excel.Application xlApp_ES = new Excel.Application();
                    Excel.Workbook xlWorkbook_ES = xlApp_ES.Workbooks.Open(outputFile);
                    Excel.Worksheet workSheet_ES = (Excel.Worksheet)xlWorkbook_ES.Worksheets[2];
                    workSheet_ES.Delete();
                    workSheet_ES = (Excel.Worksheet)xlWorkbook_ES.Worksheets[1];
                    PasswordDocumentos passBloquea = (from x in db.PasswordDocumentos where x.Activo == true select x).SingleOrDefault();
                    if (passBloquea != null)
                    {
                        Encripcion objEncrypt = new Encripcion();
                        workSheet_ES.Protect(objEncrypt.Decrypt(passBloquea.Password));
                    }
                    xlApp_ES.DisplayAlerts = false;
                    xlApp_ES.ActiveWorkbook.Save();
                    xlApp_ES.Quit();
                    xlApp_ES.Dispose();
                }
                #endregion

                #region Creacion de hoja ES
                else
                {
                    xlApp = new Excel.Application();
                    xlWorkbook = xlApp.Workbooks.Open(outputFile);
                    workSheet = (Excel.Worksheet)xlWorkbook.Worksheets[2];
                    //xlApp.Visible = true;

                    #region Seccion Master
                    workSheet.Range("C2").Value = polizaES;
                    workSheet.Range("C6").Value = tituloPolizaGenius;
                    workSheet.Range("C7").Value = (from x in db.Clientes where x.ID == Convert.ToInt32(cbAseguradoMain.Value) select x.NameCode).SingleOrDefault();
                    workSheet.Range("C8").Value = (from x in db.Brokers where x.ID == Convert.ToInt32(cbBroker.Value) select x.BrokerCode).SingleOrDefault();
                    workSheet.Range("C9").Value = cbCoaseguradorLider.Text;
                    workSheet.Range("C10").Value = txtPAM.Text;
                    workSheet.Range("C11").Value = cbPrograma.Text;
                    workSheet.Range("C12").Value = cbProducingOffice.Text;
                    workSheet.Range("E8").Value = polizaES;
                    workSheet.Range("E9").Value = "IW";
                    workSheet.Range("E10").Value = (from x in db.Pais where x.ID == Convert.ToInt32(cbCountry.Value) select x.Codigo2 + " - " + x.NombreIngles).SingleOrDefault();

                    workSheet.Range("C15").Value = formatearFecha(Convert.ToDateTime(dateInicioVig.Value), 1);
                    workSheet.Range("C16").Value = formatearFecha(Convert.ToDateTime(dateFinVigencia.Value), 1);
                    workSheet.Range("E15").Value = emision.Year.ToString();
                    if (chkLTARenegotiable.Checked)
                    {
                        workSheet.Range("C17").Value = "Renegotiable";
                        workSheet.Range("E17").Value = LTAInception.ToString();
                        workSheet.Range("E18").Value = LTAExpiry.ToString();
                    }
                    else
                    {
                        workSheet.Range("C17").Value = "No";
                        workSheet.Range("E17").Value = "";
                        workSheet.Range("E18").Value = "";
                    }

                    workSheet.Range("E16").Value = "Do not modify default value";
                    switch (cbDelimitacionTerritorial.SelectedIndex)
                    {
                        case 0:
                            workSheet.Range("C21").Value = "MX";
                            workSheet.Range("E44").Value = "MX";
                            break;
                        case 1:
                            workSheet.Range("C21").Value = "WXUSC";
                            workSheet.Range("E44").Value = "WXUSC";
                            break;
                        case 2:
                            workSheet.Range("C21").Value = "WW";
                            workSheet.Range("E44").Value = "WW";
                            break;
                    }
                    workSheet.Range("C22").Value = "No";
                    workSheet.Range("C22").Value = "Yes";
                    if (cbEstructuraLimite.SelectedIndex == 0)
                        workSheet.Range("C23").Value = "Yes";
                    else
                        workSheet.Range("C23").Value = "No";

                    workSheet.Range("E21").Value = cbToB.Text;
                    if (chkPortafolio.Checked)
                        workSheet.Range("E22").Value = "Yes";
                    else
                        workSheet.Range("E22").Value = "No";
                    #endregion

                    #region Seccion Terms & Conditions
                    if (cbMoneda.Text.Contains("Pesos Mexicanos"))
                    {
                        workSheet.Range("C27").Value = "Dólares Estadounidenses (USD)";
                        workSheet.Range("E27").Value = "Dólares Estadounidenses (USD)";
                    }
                    else
                    {
                        workSheet.Range("C27").Value = cbMoneda.Text;
                        workSheet.Range("E27").Value = cbMoneda.Text;
                    }
                    workSheet.Range("C28").Value = "LDR - Payments to Leader";
                    switch (cbFormaPago.Text)
                    {
                        case "Contado":
                            workSheet.Range("C29").Value = "ANN";
                            workSheet.Range("E28").Value = "BAS - Basic Processing";
                            break;
                        case "Anual":
                            workSheet.Range("C29").Value = "ANN";
                            workSheet.Range("E28").Value = "BAS - Basic Processing";
                            break;
                        case "Mensual":
                            workSheet.Range("C29").Value = "MTH";
                            workSheet.Range("E28").Value = "INS";
                            break;
                        case "Trimestral":
                            workSheet.Range("C29").Value = "QTR";
                            workSheet.Range("E28").Value = "INS";
                            break;
                        case "Semestral":
                            workSheet.Range("C29").Value = "HLF";
                            workSheet.Range("E28").Value = "INS";
                            break;
                    }

                    workSheet.Range("C30").Value = "C - Premium Payment Close";
                    workSheet.Range("C32").Value = "MAN - Manual Renewal";

                    workSheet.Range("E29").Value = txtNumPagos.Value.ToString();
                    workSheet.Range("E30").Value = "120";

                    if (chkAjustable.Checked)
                        workSheet.Range("C35").Value = "Yes";
                    else
                        workSheet.Range("C35").Value = "No";
                    workSheet.Range("C37").Value = "30";
                    workSheet.Range("E35").Value = "L - Leader";
                    workSheet.Range("E36").Value = "Yes";
                    workSheet.Range("E37").Value = "LDR - Payments to Leader";
                    #endregion

                    #region Seccion coberturas
                    workSheet.Range("B41").Value = "ROW: Rest of the World";
                    workSheet.Range("C43").Value = "703";
                    workSheet.Range("C44").Value = cbToB.Text;
                    workSheet.Range("E43").Value = cbActivityCode.Text;
                    if (chkRetroactiva.Checked)
                        workSheet.Range("C48").Value = fechaRetroactiva.ToString();
                    else
                        workSheet.Range("C48").Value = "N/A";

                    // Pega las coberturas
                    filaInicio = 50;
                    workSheet.Range("B" + (filaInicio).ToString()).Value = "Limit PL/PR Combinned (LPPC)"; filaInicio++;

                    workSheet.Range("B" + (filaInicio).ToString()).Value = "PREM PL/PR Combinned (PPPC)"; filaInicio++;
                    r = workSheet.get_Range("A" + (filaInicio).ToString(), "A" + (filaInicio).ToString()).EntireRow;
                    r.Insert(XlInsertShiftDirection.xlShiftDown);
                    workSheet.Range("B" + (filaInicio).ToString() + ":E" + (filaInicio).ToString()).Merge();

                    if (chkDeducibles.Checked)
                    {
                        for (int i = 0; i < dgDeducibles.Rows.Count; i++)
                        {
                            Coberturas cobTMP = (from x in db.Coberturas where x.Cobertura == dgDeducibles.Rows[i].Cells["Deducible"].Text select x).FirstOrDefault();
                            string strDeduTmp = "";
                            if (cobTMP != null)
                            {
                                strDeduTmp = "Deduct " + cobTMP.CoberturaIngles + " (D" + cobTMP.GeniusCode + ")";
                            }
                            else
                            {
                                strDeduTmp = "Deduct Other" + dgDeducibles.Rows[i].Cells["Deducible"].Text + " (D" + "OTH" + ")";
                            }

                            workSheet.Range("B" + (filaInicio).ToString()).Value = strDeduTmp; filaInicio++;

                            if (i + 1 < dgDeducibles.Rows.Count)
                            {
                                r = workSheet.get_Range("A" + (filaInicio).ToString(), "A" + (filaInicio).ToString()).EntireRow;
                                r.Insert(XlInsertShiftDirection.xlShiftDown);
                                workSheet.Range("B" + (filaInicio).ToString() + ":E" + (filaInicio).ToString()).Merge();
                            }
                        }
                    }

                    desplace = dgDeducibles.Rows.Count;
                    #endregion

                    #region Seccion limites
                    workSheet.Range("C" + (53 + desplace).ToString()).Value = "Limit PL/PR Combinned (LPPC)";
                    if (cbEstructuraLimite.SelectedIndex == 0)
                        workSheet.Range("C" + (54 + desplace).ToString()).Value = "N/A";
                    else
                        workSheet.Range("C" + (54 + desplace).ToString()).Value = txtSujecion.Value.ToString();
                    workSheet.Range("C" + (56 + desplace).ToString()).Value = double.Parse(txtLimiteMaximo.Value.ToString()).ToString("#,##0.00", new CultureInfo("en-US"));
                    workSheet.Range("C" + (57 + desplace).ToString()).Value = "";
                    workSheet.Range("E" + (54 + desplace).ToString()).Value = "X";
                    workSheet.Range("E" + (55 + desplace).ToString()).Value = modoClaims;
                    workSheet.Range("E" + (56 + desplace).ToString()).Value = "Yes";
                    workSheet.Range("E" + (57 + desplace).ToString()).Value = "";
                    #endregion

                    #region Seccion deducibles
                    // Pega los deducibles
                    if (chkDeducibles.Checked) // Se salta todo el proceso si No hay deducibles
                    {
                        for (int i = 0; i < dgDeducibles.Rows.Count; i++)
                        {
                            Coberturas cobTMP = (from x in db.Coberturas where x.Cobertura == dgDeducibles.Rows[i].Cells["Deducible"].Text select x).FirstOrDefault();
                            string strDeduTmp = "";
                            if (cobTMP != null)
                            {
                                strDeduTmp = "Deduct " + cobTMP.CoberturaIngles + " (D" + cobTMP.GeniusCode + ")";
                            }
                            else
                            {
                                strDeduTmp = "Deduct Other" + dgDeducibles.Rows[i].Cells["Deducible"].Text + " (D" + "OTH" + ")";
                            }

                            //datos del deducible individual double.Parse(row.Cells["Maximo"].Text.ToString()).ToString("#,##0.00", new CultureInfo("en-US"))

                            string notes = "{Leave empty}"; if (Convert.ToBoolean(dgDeducibles.Rows[i].Cells["SIR"].Value)) { notes = "SIR"; }
                            string maxDeduc = double.Parse(dgDeducibles.Rows[i].Cells["Maximo"].Value.ToString()).ToString("#,##0.00", new CultureInfo("en-US"));
                            string minDeduc = double.Parse(dgDeducibles.Rows[i].Cells["Minimo"].Value.ToString()).ToString("#,##0.00", new CultureInfo("en-US"));
                            string aggregationDeduc = double.Parse(dgDeducibles.Rows[i].Cells["Agregado"].Value.ToString()).ToString("#,##0.00", new CultureInfo("en-US"));
                            string percentajeDeduc = double.Parse(dgDeducibles.Rows[i].Cells["Porcentaje"].Value.ToString()).ToString("#,##0.00", new CultureInfo("en-US")) + " %";

                            workSheet.Range("C" + (61 + desplace).ToString()).Value = strDeduTmp;
                            workSheet.Range("C" + (62 + desplace).ToString()).Value = maxDeduc;
                            workSheet.Range("C" + (63 + desplace).ToString()).Value = aggregationDeduc;
                            workSheet.Range("E" + (61 + desplace).ToString()).Value = notes;
                            workSheet.Range("E" + (62 + desplace).ToString()).Value = minDeduc;
                            workSheet.Range("E" + (63 + desplace).ToString()).Value = percentajeDeduc;

                            if (i != dgDeducibles.Rows.Count - 1) //Copia un nuevo set de filas
                            {
                                workSheet.Range((61 + desplace).ToString() + ":" + (63 + desplace).ToString()).Copy();
                                desplace = desplace + 3;
                                Excel.Range oRange = workSheet.Range("B" + (61 + desplace).ToString()).EntireRow;
                                oRange.Insert(XlInsertShiftDirection.xlShiftDown);
                                workSheet.Range("C" + (61 + desplace).ToString()).Value = "";
                                workSheet.Range("C" + (62 + desplace).ToString()).Value = "";
                                workSheet.Range("C" + (63 + desplace).ToString()).Value = "";
                                workSheet.Range("E" + (61 + desplace).ToString()).Value = "";
                                workSheet.Range("E" + (62 + desplace).ToString()).Value = "";
                                workSheet.Range("E" + (63 + desplace).ToString()).Value = "";
                            }
                        }
                    }
                    #endregion

                    #region Seccion prima
                    workSheet.Range("C" + (67 + desplace).ToString()).Value = "001 - Standard";
                    workSheet.Range("C" + (68 + desplace).ToString()).Value = "";
                    workSheet.Range("C" + (69 + desplace).ToString()).Value = double.Parse(txtPrimaNeta.Value.ToString()).ToString("#,##0.00", new CultureInfo("en-US"));
                    workSheet.Range("C" + (70 + desplace).ToString()).Value = "";
                    workSheet.Range("E" + (67 + desplace).ToString()).Value = "";
                    workSheet.Range("E" + (68 + desplace).ToString()).Value = double.Parse(txtSujecion.Value.ToString()).ToString("#,##0.00", new CultureInfo("en-US"));
                    workSheet.Range("E" + (69 + desplace).ToString()).Value = cbTipoPrima.Text;
                    workSheet.Range("E" + (70 + desplace).ToString()).Value = double.Parse(txtPrimaNeta.Value.ToString()).ToString("#,##0.00", new CultureInfo("en-US"));
                    #endregion

                    #region Seccion participantes
                    if (chkAdminPremium.Checked)
                        workSheet.Range("C" + (79 + desplace).ToString()).Value = "Yes";
                    else
                        workSheet.Range("C" + (79 + desplace).ToString()).Value = "No";

                    if (chkAdminClaims.Checked)
                        workSheet.Range("E" + (79 + desplace).ToString()).Value = "Yes";
                    else
                        workSheet.Range("E" + (79 + desplace).ToString()).Value = "No";

                    if (chkGenerateDocuments.Checked)
                        workSheet.Range("C" + (80 + desplace).ToString()).Value = "Yes";
                    else
                        workSheet.Range("C" + (80 + desplace).ToString()).Value = "No";


                    coaStatus = "";
                    if (!chkCoaseguro.Checked) { coaStatus = "sin Coaseguro"; }
                    else coaStatus = cbTipoCoaseguro.Text;

                    switch (coaStatus)
                    {
                        case "sin Coaseguro":

                            workSheet.Range("C" + (83 + desplace).ToString()).Value = "I - Insurer";
                            workSheet.Range("C" + (84 + desplace).ToString()).Value = "Q2";
                            workSheet.Range("C" + (85 + desplace).ToString()).Value = "100.00%";
                            workSheet.Range("E" + (83 + desplace).ToString()).Value = "Yes";
                            workSheet.Range("E" + (84 + desplace).ToString()).Value = "XL Seguros México";
                            workSheet.Range("E" + (85 + desplace).ToString()).Value = "100.00%";



                            workSheet.Range("C" + (89 + desplace).ToString()).Value = "{Do no add any value}";
                            workSheet.Range("C" + (90 + desplace).ToString()).Value = "{Do no add any value}";
                            workSheet.Range("C" + (91 + desplace).ToString()).Value = "{Do no add any value}";
                            workSheet.Range("E" + (89 + desplace).ToString()).Value = "{Do no add any value}";
                            workSheet.Range("E" + (90 + desplace).ToString()).Value = "{Do no add any value}";


                            break;

                        case "Coaseguro Seguidor":

                            workSheet.Range("C" + (83 + desplace).ToString()).Value = "I - Insurer";
                            workSheet.Range("C" + (84 + desplace).ToString()).Value = "Q2";
                            workSheet.Range("C" + (85 + desplace).ToString()).Value = "100.00%";
                            workSheet.Range("E" + (83 + desplace).ToString()).Value = "Yes";
                            workSheet.Range("E" + (84 + desplace).ToString()).Value = "XL Seguros México";
                            workSheet.Range("E" + (85 + desplace).ToString()).Value = txtPorParticipacionXL.Value.ToString() + " %";

                            workSheet.Range("C" + (89 + desplace).ToString()).Value = "{Do no add any value}";
                            workSheet.Range("C" + (90 + desplace).ToString()).Value = "{Do no add any value}";
                            workSheet.Range("C" + (91 + desplace).ToString()).Value = "{Do no add any value}";
                            workSheet.Range("E" + (89 + desplace).ToString()).Value = "{Do no add any value}";
                            workSheet.Range("E" + (90 + desplace).ToString()).Value = "{Do no add any value}";
                            break;

                        case "Coaseguro Lider":

                            workSheet.Range("C" + (83 + desplace).ToString()).Value = "I - Insurer";
                            workSheet.Range("C" + (84 + desplace).ToString()).Value = "Q2";
                            workSheet.Range("C" + (85 + desplace).ToString()).Value = "100.00%";
                            workSheet.Range("E" + (83 + desplace).ToString()).Value = "Yes";
                            workSheet.Range("E" + (84 + desplace).ToString()).Value = "XL Seguros México";
                            workSheet.Range("E" + (85 + desplace).ToString()).Value = "100.00%";


                            for (int i = 0; i < dgCoaseguro.Rows.Count; i++)
                            {
                                if (dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text != "")
                                {
                                    string minorParticipationRtnd = "";
                                    string minorParticipationNameCode = "";
                                    string minorParticipationName = "";
                                    string minorParticipationLine = "";
                                    string minorParticipationWhole = "";

                                    Coaseguradora coaseTMP = (from x in db.Coaseguradoras1 where x.ID == Convert.ToInt32(dgCoaseguro.Rows[i].Cells["Coaseguradora"].Value) select x).SingleOrDefault();

                                    if (i == 0) { minorParticipationRtnd = "Yes"; } else { minorParticipationRtnd = "No"; }
                                    minorParticipationNameCode = coaseTMP.Codigo;
                                    minorParticipationName = coaseTMP.Nombre;
                                    minorParticipationLine = double.Parse(dgCoaseguro.Rows[i].Cells["PorcentajeParticipacion"].Value.ToString()).ToString("#,##0.00", new CultureInfo("en-US"));
                                    minorParticipationWhole = minorParticipationLine;

                                    workSheet.Range("C" + (89 + desplace).ToString()).Value = minorParticipationRtnd;
                                    workSheet.Range("C" + (90 + desplace).ToString()).Value = minorParticipationName;
                                    workSheet.Range("C" + (91 + desplace).ToString()).Value = minorParticipationWhole;
                                    workSheet.Range("E" + (89 + desplace).ToString()).Value = minorParticipationNameCode;
                                    workSheet.Range("E" + (90 + desplace).ToString()).Value = minorParticipationLine;

                                    if (i != dgCoaseguro.Rows.Count - 1) //Copia un nuevo set de filas
                                    {
                                        workSheet.Range((89 + desplace).ToString() + ":" + (91 + desplace).ToString()).Copy();
                                        desplace = desplace + 3;
                                        Excel.Range oRange = workSheet.Range("B" + (89 + desplace).ToString()).EntireRow;
                                        oRange.Insert(XlInsertShiftDirection.xlShiftDown);
                                        workSheet.Range("C" + (89 + desplace).ToString()).Value = "";
                                        workSheet.Range("C" + (90 + desplace).ToString()).Value = "";
                                        workSheet.Range("C" + (91 + desplace).ToString()).Value = "";
                                        workSheet.Range("E" + (89 + desplace).ToString()).Value = "";
                                        workSheet.Range("E" + (90 + desplace).ToString()).Value = "";
                                    }
                                }
                            }
                            break;
                    }
                    #endregion

                    #region Seccion deductibles
                    double DedRIC = 0;
                    int count_part = 0;
                    DedRIC = Convert.ToDouble(dgReaseguro.Rows[0].Cells["PorcentajeComision"].Value); count_part++;
                    DedRIC = DedRIC / count_part;

                    workSheet.Range("C" + (96 + desplace).ToString()).Value = "10";
                    workSheet.Range("C" + (97 + desplace).ToString()).Value = DedRIC.ToString("P6");
                    workSheet.Range("E" + (96 + desplace).ToString()).Value = "RICPCT";
                    workSheet.Range("E" + (97 + desplace).ToString()).Value = "4 - AC as Premium";
                    #endregion

                    #region Seccion reaseguro
                    string RI_Calc = "{Do not add any row}";
                    string RI_RIRI = "";
                    string RI_RIPolicy = "";
                    string RI_RIPolicyTitle = "";
                    string RI_PremiumCession = "";
                    string RI_TotalComm = "";
                    string RI_AltStatus = "";
                    string RI_RISection = "";
                    double partRestan = 0;
                    for (int i = 1; i < dgReaseguro.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgReaseguro.Rows[i].Cells["Treaty"].Value) && dgReaseguro.Rows[i].Cells["Reaseguradora"].Text != "")
                        {
                            partRestan += Convert.ToDouble(dgReaseguro.Rows[i].Cells["PorcentajeParticipacion"].Value) / 100;
                        }
                    }

                    double NetPayable = 0;
                    int calc = 10;

                    for (int i = 1; i < dgReaseguro.Rows.Count; i++)
                    {
                        Reaseguradoras reaseTMP = (from x in db.Reaseguradoras where x.ID == Convert.ToInt32(dgReaseguro.Rows[i].Cells["Reaseguradora"].Value) select x).SingleOrDefault();

                        if (Convert.ToBoolean(dgReaseguro.Rows[i].Cells["Treaty"].Value) && dgReaseguro.Rows[i].Cells["Reaseguradora"].Text != "")
                        {
                            double PREM_ce = (Convert.ToDouble(dgReaseguro.Rows[i].Cells["PorcentajeParticipacion"].Value) / 100) / partRestan; // porc partici
                            double PREM_cu = -Convert.ToDouble(dgReaseguro.Rows[i].Cells["Participacion"].Value); // participacion
                            double RIC_ce = Convert.ToDouble(dgReaseguro.Rows[i].Cells["PorcentajeComision"].Value) / 100; // porc comision
                            double RIC_cu = Convert.ToDouble(dgReaseguro.Rows[i].Cells["Comision"].Value); // comision
                            NetPayable += PREM_cu + RIC_cu;

                            RI_Calc = calc.ToString(); calc += 10;
                            RI_RIPolicy = reaseTMP.RI_Policy;
                            RI_PremiumCession = PREM_ce.ToString("P6");
                            RI_AltStatus = "Current";
                            RI_RIRI = "Yes";
                            RI_RIPolicyTitle = "{Automatic Generated, do not change default}";
                            RI_RISection = "RI/*BK";
                            RI_TotalComm = RIC_ce.ToString("P6");

                            workSheet.Range("C" + (101 + desplace).ToString()).Value = RI_Calc;
                            workSheet.Range("C" + (102 + desplace).ToString()).Value = RI_RIPolicy;
                            workSheet.Range("C" + (103 + desplace).ToString()).Value = RI_PremiumCession;
                            workSheet.Range("C" + (104 + desplace).ToString()).Value = RI_AltStatus;
                            workSheet.Range("E" + (101 + desplace).ToString()).Value = RI_RIRI;
                            workSheet.Range("E" + (102 + desplace).ToString()).Value = RI_RIPolicyTitle;
                            workSheet.Range("E" + (103 + desplace).ToString()).Value = RI_TotalComm;
                            workSheet.Range("E" + (104 + desplace).ToString()).Value = RI_RISection;
                        }

                        if (i != dgReaseguro.Rows.Count - 2) //Copia un nuevo set de filas
                        {
                            workSheet.Range((101 + desplace).ToString() + ":" + (104 + desplace).ToString()).Copy();
                            desplace = desplace + 4;
                            Excel.Range oRange = workSheet.Range("B" + (101 + desplace).ToString()).EntireRow;
                            oRange.Insert(XlInsertShiftDirection.xlShiftDown);
                            workSheet.Range("C" + (101 + desplace).ToString()).Value = "";
                            workSheet.Range("C" + (102 + desplace).ToString()).Value = "";
                            workSheet.Range("C" + (103 + desplace).ToString()).Value = "";
                            workSheet.Range("C" + (104 + desplace).ToString()).Value = "";
                            workSheet.Range("E" + (101 + desplace).ToString()).Value = "";
                            workSheet.Range("E" + (102 + desplace).ToString()).Value = "";
                            workSheet.Range("E" + (103 + desplace).ToString()).Value = "";
                            workSheet.Range("E" + (104 + desplace).ToString()).Value = "";
                        }
                    }

                    double SPPRE = 0;
                    double SPRIC = 0;

                    for (int i = 1; i < dgReaseguro.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgReaseguro.Rows[i].Cells["Treaty"].Value) && dgReaseguro.Rows[i].Cells["Reaseguradora"].Text != "")
                        {
                            SPPRE += Convert.ToDouble(dgReaseguro.Rows[i].Cells["Participacion"].Value);
                            SPRIC += Convert.ToDouble(dgReaseguro.Rows[i].Cells["Comision"].Value);
                        }
                    }

                    double netReceivable = SPPRE - SPRIC;
                    double spainNet = NetPayable + netReceivable;

                    workSheet.Range("B" + (105 + desplace).ToString()).Value = "(Validation) ES Net";
                    workSheet.Range("C" + (105 + desplace).ToString()).Value = spainNet.ToString("C2");
                    #endregion

                    workSheet.Range("C:C").Columns.AutoFit();
                    workSheet.Range("E:E").Columns.AutoFit();
                    PasswordDocumentos passBloquea = (from x in db.PasswordDocumentos where x.Activo == true select x).SingleOrDefault();
                    if (passBloquea != null)
                    {
                        Encripcion objEncrypt = new Encripcion();
                        workSheet.Protect(objEncrypt.Decrypt(passBloquea.Password));
                    }
                    xlApp.DisplayAlerts = false;
                    xlApp.ActiveWorkbook.Save();
                    xlApp.Quit();
                    xlApp.Dispose();
                }
                #endregion
                #endregion

            }
            catch (Exception ex)
            {
                xlApp.Quit();
                xlApp.Dispose();
                MessageBox.Show("Ocurrió un error al generar las instrucciones Genius, favor de contactar al soporte técnico" + Environment.NewLine + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                controlSave = false;
                File.Delete(outputFile);
            }
        }

        void generarPoliza()
        {
            try
            {
                string CoverPDF = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_Cover_" + polizaMX + ".pdf";
                string SchedulePDF = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_Schedule_" + polizaMX + ".pdf";
                string WordingPDF = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_Wording_" + polizaMX + ".pdf";
                string PolizaPDF = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_Poliza_" + polizaMX + ".pdf";
                PdfDocument targetDoc = new PdfDocument();

                // añade Cover
                using (PdfDocument pdfDoc = PdfReader.Open(CoverPDF, PdfDocumentOpenMode.Import))
                {
                    for (int i = 0; i < pdfDoc.PageCount; i++)
                    {
                        targetDoc.AddPage(pdfDoc.Pages[i]);
                    }
                }
                // añade Schedule
                using (PdfDocument pdfDoc = PdfReader.Open(SchedulePDF, PdfDocumentOpenMode.Import))
                {
                    for (int i = 0; i < pdfDoc.PageCount; i++)
                    {
                        targetDoc.AddPage(pdfDoc.Pages[i]);
                    }
                }

                // añade Wording
                using (PdfDocument pdfDoc = PdfReader.Open(WordingPDF, PdfDocumentOpenMode.Import))
                {
                    for (int i = 0; i < pdfDoc.PageCount; i++)
                    {
                        targetDoc.AddPage(pdfDoc.Pages[i]);
                    }
                }
                targetDoc.Save(PolizaPDF);
                //File.Delete(CoverPDF);
                //File.Delete(SchedulePDF);
                //File.Delete(WordingPDF);
            }
            catch
            {
                MessageBox.Show("Error al combinar los documentos en una póliza, favor de contactar al soporte técnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int guardarAvances()
        {
            // codigos de errores
            // 0 = guardado Correcto
            // 1 = error en la creación de la póliza, falta el MX
            // 2 = error en la creación de la póliza, MX ya registrado
            // 3 = error en la creación de la póliza, error no controlado al generarla
            // 4 = error en poliza FL
            // 5 = error en coberturas
            // 6 = error en endosos emision
            // 7 = error en sublimites
            // 8 = error en deducibles
            // 9 = error en info schedule
            // 10 = error en clientes
            // 11 = error en coaseguro
            // 12 = error en reaseguro

            int codigoVuelta = 0;

            if (ventana == 0 || ventana == 1)
            {
                if (txtPolizaMX.Text != "")
                {
                    if (validarPoliza(txtPolizaMX))
                    {
                        guardarVariables();
                        bool tmpContinuarSave = guardarPoliza();
                        if (tmpContinuarSave)
                        {
                            if (guardarPolizaFL())
                            {
                                if (guardarPolizaCobertura())
                                {
                                    if (guardarPolizaEndosos())
                                    {
                                        if (guardarPolizaSublimite())
                                        {
                                            if (guardarPolizaDeducibles())
                                            {
                                                if (guardarInfoSchedule())
                                                {
                                                    if (guardarClientes())
                                                    {
                                                        if (guardarCoaseguros())
                                                        {
                                                            if (guardarReaseguros())
                                                            {
                                                                tmpContinuarSave = true;
                                                            }
                                                            else
                                                            {
                                                                tmpContinuarSave = false;
                                                                codigoVuelta = 12;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            tmpContinuarSave = false;
                                                            codigoVuelta = 11;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        tmpContinuarSave = false;
                                                        codigoVuelta = 10;
                                                    }
                                                }
                                                else
                                                {
                                                    tmpContinuarSave = false;
                                                    codigoVuelta = 9;
                                                }
                                            }
                                            else
                                            {
                                                tmpContinuarSave = false;
                                                codigoVuelta = 8;
                                            }
                                        }
                                        else
                                        {
                                            tmpContinuarSave = false;
                                            codigoVuelta = 7;
                                        }
                                    }
                                    else
                                    {
                                        tmpContinuarSave = false;
                                        codigoVuelta = 6;
                                    }
                                }
                                else
                                {
                                    tmpContinuarSave = false;
                                    codigoVuelta = 5;
                                }
                            }
                            else
                            {
                                tmpContinuarSave = false;
                                codigoVuelta = 4;
                            }
                        }
                        else
                        {
                            codigoVuelta = 3;
                        }

                        if (tmpContinuarSave)
                        {
                            codigoVuelta = 0;
                        }
                        else
                        {
                            for (int i = 0; i < 9; i++)
                            {
                                borrarRegistros(i);
                            }
                            
                        }
                    }
                    else
                    {
                        codigoVuelta = 2;
                    }
                }
                else
                {
                    codigoVuelta = 1;
                }
            }

            return codigoVuelta;
        }

        bool guardarClientes()
        {
            try
            {
                dbSmartGDataContext db = new dbSmartGDataContext();

                // borramos todos los registros
                borrarRegistros(5);

                //FIX
                string tmpClientes = "";

                // registramos los nuevos valores
                PolizaCliente nuevoCliente = new PolizaCliente();
                nuevoCliente.Poliza = idPoliza;
                nuevoCliente.Cliente = aseguradoPrincipal;
                nuevoCliente.Activo = true;
                nuevoCliente.Principal = true;
                nuevoCliente.Direccion = direccionAseguradoPrincipal;

                PolizaCliente clienteAdi = new PolizaCliente();

                for (int i = 0; i < dgAseguAdicionales.Rows.Count; i++)
                {
                    clienteAdi = new PolizaCliente();
                    clienteAdi.Poliza = idPoliza;
                    clienteAdi.Principal = false;
                    clienteAdi.Activo = true;
                    clienteAdi.NombreAsegurado = dgAseguAdicionales.Rows[i].Cells["Asegurado Adicional"].Text.ToString();
                    db.PolizaCliente.InsertOnSubmit(clienteAdi);
                    db.SubmitChanges();

                    if (i == 0)
                        tmpClientes = dgAseguAdicionales.Rows[i].Cells["Asegurado Adicional"].Text.ToString();
                    else
                        tmpClientes += ", " + dgAseguAdicionales.Rows[i].Cells["Asegurado Adicional"].Text.ToString();
                }

                nuevoCliente.aseguradosAdicionales = tmpClientes;
                db.PolizaCliente.InsertOnSubmit(nuevoCliente);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        bool guardarCoaseguros()
        {
            try
            {
                dbSmartGDataContext db = new dbSmartGDataContext();

                // borramos todos los registros
                borrarRegistros(6);

                if (chkCoaseguro.Checked)
                {
                    // registramos los nuevos valores
                    PolizaCoaseguro nuevoPolizaCoase;

                    if (cbTipoCoaseguro.Text != "")
                    {
                        if (cbTipoCoaseguro.Text == "Coaseguro Lider")
                        {
                            for (int i = 0; i < dgCoaseguro.Rows.Count; i++)
                            {
                                if (dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text.ToString() != "" && dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text.ToString() != "0")
                                {
                                    nuevoPolizaCoase = new PolizaCoaseguro();
                                    nuevoPolizaCoase.Poliza = idPoliza;
                                    nuevoPolizaCoase.Tipo = "Lider";
                                    nuevoPolizaCoase.Coaseguradora = Convert.ToInt32(dgCoaseguro.Rows[i].Cells["Coaseguradora"].Value);
                                    nuevoPolizaCoase.Participacion = Convert.ToDecimal(dgCoaseguro.Rows[i].Cells["PorcentajeParticipacion"].Value);
                                    nuevoPolizaCoase.Monto = Convert.ToDecimal(dgCoaseguro.Rows[i].Cells["Participacion"].Value);
                                    nuevoPolizaCoase.PorcComision = Convert.ToDecimal(dgCoaseguro.Rows[i].Cells["PorcentajeComisionBroker"].Value);
                                    nuevoPolizaCoase.MontoComision = Convert.ToDecimal(dgCoaseguro.Rows[i].Cells["ComisionBroker"].Value);
                                    nuevoPolizaCoase.CoaseguradoraAdministra = idCoaseguradorLider;
                                    db.PolizaCoaseguro.InsertOnSubmit(nuevoPolizaCoase);
                                    db.SubmitChanges();
                                }
                            }

                            return true;
                        }
                        else if (cbCoaseguradorLider.Text != "")
                        {
                            nuevoPolizaCoase = new PolizaCoaseguro();
                            nuevoPolizaCoase.Poliza = idPoliza;
                            nuevoPolizaCoase.Tipo = "Seguidor";
                            nuevoPolizaCoase.Coaseguradora = Convert.ToInt32(cbCoaseguradorLider.Value);
                            nuevoPolizaCoase.Participacion = Convert.ToDecimal(txtPorParticipacionXL.Value);
                            nuevoPolizaCoase.Monto = Convert.ToDecimal(txtParticipacionXL.Value);
                            nuevoPolizaCoase.PorcComision = Convert.ToDecimal(txtCoasePorcBrokerage.Value);
                            nuevoPolizaCoase.MontoComision = Convert.ToDecimal(txtCoaseComiBrokerage.Value);
                            nuevoPolizaCoase.CoaseguradoraAdministra = idCoaseguradorLider;
                            db.PolizaCoaseguro.InsertOnSubmit(nuevoPolizaCoase);
                            db.SubmitChanges();
                            return true;
                        }
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        void guardarControl(Control control)
        {
            string nomControl = "";
            string tipoControl = "";
            string valorControl = "";
            bool entro = false;

            if (control.HasChildren)
            {
                foreach (Control subControl in control.Controls)
                {
                    guardarControl(subControl);
                }
            }

            nomControl = control.Name;

            if (control is Infragistics.Win.UltraWinEditors.UltraNumericEditor)
            {
                Infragistics.Win.UltraWinEditors.UltraNumericEditor numero = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)control;
                if (numero.NumericType == Infragistics.Win.UltraWinEditors.NumericType.Integer)
                    tipoControl = "int";
                else if (numero.NumericType == Infragistics.Win.UltraWinEditors.NumericType.Double)
                    tipoControl = "double";
                else
                    tipoControl = "decimal";
                valorControl = numero.Value.ToString();
                entro = true;
            }

            if (control is Infragistics.Win.UltraWinEditors.UltraTextEditor)
            {
                Infragistics.Win.UltraWinEditors.UltraTextEditor texto = (Infragistics.Win.UltraWinEditors.UltraTextEditor)control;
                tipoControl = "string";
                valorControl = texto.Text;
                entro = true;
            }

            if (control is Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit)
            {
                Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit mascara = (Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit)control;
                tipoControl = "string";
                valorControl = mascara.Text;
                entro = true;
            }

            if (control is Infragistics.Win.UltraWinEditors.UltraCheckEditor)
            {
                Infragistics.Win.UltraWinEditors.UltraCheckEditor check = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)control;
                tipoControl = "bool";
                valorControl = check.Checked.ToString();
                entro = true;
            }

            if (control is Infragistics.Win.UltraWinEditors.UltraComboEditor)
            {
                Infragistics.Win.UltraWinEditors.UltraComboEditor cb = (Infragistics.Win.UltraWinEditors.UltraComboEditor)control;
                tipoControl = "string";
                valorControl = cb.Text;
                entro = true;
            }

            if (control is Infragistics.Win.UltraWinGrid.UltraCombo)
            {
                Infragistics.Win.UltraWinGrid.UltraCombo cb = (Infragistics.Win.UltraWinGrid.UltraCombo)control;
                tipoControl = "string";
                valorControl = cb.Text;
                entro = true;
            }

            if (control is System.Windows.Forms.RichTextBox)
            {
                System.Windows.Forms.RichTextBox rich = (System.Windows.Forms.RichTextBox)control;
                try
                {
                    valorControl = rich.Rtf;
                    tipoControl = "rtf";
                    entro = true;
                }
                catch
                {
                    valorControl = rich.Text;
                    tipoControl = "string";
                    entro = true;
                }
            }

            // guardamos el control en la db
            if (entro)
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                PolizaFLProducto nuevoRegistro = new PolizaFLProducto();
                nuevoRegistro.Control = nomControl;
                nuevoRegistro.TipoControl = tipoControl;
                nuevoRegistro.Valor = valorControl;
                nuevoRegistro.PolizaFL = idPolizaFL;
                db.PolizaFLProducto.InsertOnSubmit(nuevoRegistro);
                db.SubmitChanges();
            }
        }

        bool guardarInfoSchedule()
        {
            try
            {
                bool tmpAgregar = false;
                dbSmartGDataContext db = new dbSmartGDataContext();
                InfoSchedule nuevaInfo = (from x in db.InfoSchedule where x.Poliza == idPoliza select x).SingleOrDefault();
                if (nuevaInfo == null)
                {
                    nuevaInfo = new InfoSchedule();
                    nuevaInfo.Poliza = idPoliza;
                    tmpAgregar = true;
                    nuevaInfo.Activo = true;
                }
                nuevaInfo.FormaPago = formaPago;
                nuevaInfo.Prima = primaNeta;
                nuevaInfo.IVA = IVA;
                nuevaInfo.isBrokerage = isBrokerage;
                nuevaInfo.PorcentajeBrokerage = porcBrokerage;
                nuevaInfo.Comision = comisionTotalBrokerage;
                nuevaInfo.TipoPrima = tipoPrima;
                nuevaInfo.TurnOver = turnOver;
                nuevaInfo.TipoPoliza = tipoPoliza;
                nuevaInfo.NumeroPagos = numeroPagos;
                nuevaInfo.Observaciones = observaciones;
                nuevaInfo.Descuentos = descuentos;
                nuevaInfo.RecargoFraccionado = recargoFraccionado;
                nuevaInfo.GastosExpedicion = gastosExpedicion;
                nuevaInfo.IVAmonto = impuestosNetos;
                nuevaInfo.TotalPoliza = totalPoliza;
                if (tmpAgregar)
                    db.InfoSchedule.InsertOnSubmit(nuevaInfo);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        bool guardarPoliza()
        {
            try
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                Poliza nuevaPoliza;
                if (idPoliza == 0)
                    nuevaPoliza = new Poliza();
                else
                    nuevaPoliza = (from x in db.Poliza where x.ID == idPoliza select x).SingleOrDefault();

                nuevaPoliza.Poliza1 = polizaMX;
                nuevaPoliza.LineaNegocios = FinancialLines;
                nuevaPoliza.TipoTransaccion = tipoOperacion;
                nuevaPoliza.Broker = Broker;
                nuevaPoliza.IniVig = iniVig;
                nuevaPoliza.FinVig = finVig;
                nuevaPoliza.Emision = emision;
                nuevaPoliza.Moneda = moneda;
                nuevaPoliza.DAM = DAM;
                nuevaPoliza.PAM = PAM;
                nuevaPoliza.PaisAcuerdo = country;
                nuevaPoliza.Portafolio = portafolio;
                nuevaPoliza.ToB = ToB;
                nuevaPoliza.TerritorioCobertura = delimitacionTerritorial;
                nuevaPoliza.LTARenegociable = LTARenegotiable;
                nuevaPoliza.LTAInseption = LTAInception;
                nuevaPoliza.LTAExpiry = LTAExpiry;
                nuevaPoliza.PaymentCondition = paymentCondition;
                nuevaPoliza.ActivityCode = activityCode;
                nuevaPoliza.AdminClaims = adminClaims;
                nuevaPoliza.AdminPremium = adminPremium;
                nuevaPoliza.GenerateDocuments = generateDocuments;
                nuevaPoliza.Status = 2; // FIX
                nuevaPoliza.PolizaGenius = tituloPolizaGenius;
                nuevaPoliza.PolizaES = polizaES;
                nuevaPoliza.LimiteMaximo = limiteMaximo;
                nuevaPoliza.InformacionReaseguro = txtInformacionRiesgo.Text;
                if (idPoliza == 0)
                {
                    nuevaPoliza.UsuarioCreador = Program.Globals.UserID;
                    nuevaPoliza.FechaCreacion = DateTime.Now;
                    db.Poliza.InsertOnSubmit(nuevaPoliza);
                }
                db.SubmitChanges();
                idPoliza = nuevaPoliza.ID;
                return true;
            }
            catch
            {
                return false;
            }
        }

        bool guardarPolizaFL()
        {
            try
            {
                bool tmpAgregar = false;
                dbSmartGDataContext db = new dbSmartGDataContext();
                PolizaFL nuevaPolizaFL = (from x in db.PolizaFL where x.Poliza == idPoliza select x).SingleOrDefault();
                if (nuevaPolizaFL == null)
                {
                    nuevaPolizaFL = new PolizaFL();
                    nuevaPolizaFL.Poliza = idPoliza;
                    tmpAgregar = true;
                }
                nuevaPolizaFL.Producto = productoSel;
                nuevaPolizaFL.Ajustable = ajustable;
                nuevaPolizaFL.Ilimitada = limitada;
                nuevaPolizaFL.Retroactivo = retroactiva;
                nuevaPolizaFL.FechaRetroactivo = fechaRetroactiva;
                nuevaPolizaFL.FechaContinuidad = fechaContinuidad;
                nuevaPolizaFL.ExcesoConsejeros = excesoConsejeros;
                nuevaPolizaFL.EstructuraLimite = estructuraLimite;
                nuevaPolizaFL.Sujecion = sujecion;
                nuevaPolizaFL.Origen = Origen;
                nuevaPolizaFL.Programa = programa;
                nuevaPolizaFL.isClausulaTieIn = isTieinLimits;
                nuevaPolizaFL.NumPolizaGlobal = numPolizaGlobal;
                nuevaPolizaFL.TitularPolizaGlobal = titularPolizaGlobal;
                nuevaPolizaFL.LimiteResponsabilidad = limiteMaximoTieIn;
                nuevaPolizaFL.AbreviacionMoneda = abreMonedaTieIn;

                if (tmpAgregar)
                    db.PolizaFL.InsertOnSubmit(nuevaPolizaFL);
                db.SubmitChanges();
                idPolizaFL = nuevaPolizaFL.ID;

                // guardamos la info de cada uno de los productos
                foreach (Control control in tabCtrlDatos.SelectedTab.TabPage.Controls)
                {
                    guardarControl(control);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        bool guardarPolizaCobertura()
        {
            try
            {
                dbSmartGDataContext db = new dbSmartGDataContext();

                // borramos los registros anteriores
                borrarRegistros(0);

                // registramos los nuevos valores
                for (int i = 0; i < dgCoberturas.Rows.Count; i++)
                {
                    PolizaCobertura nuevaCobertura = new PolizaCobertura();
                    nuevaCobertura.Poliza = idPoliza;
                    nuevaCobertura.OrdenImpresion = i;
                    if (Convert.ToInt32(dgCoberturas.Rows[i].Cells["ID"].Text.ToString()) < 0)
                    {
                        Coberturas nuevaCoberturaDB = new Coberturas();
                        nuevaCoberturaDB.LineaNegocios = FinancialLines;
                        nuevaCoberturaDB.Cobertura = dgCoberturas.Rows[i].Cells["Cobertura"].Text.ToString();
                        nuevaCoberturaDB.CoberturaIngles = "TBD";
                        nuevaCoberturaDB.GeniusCode = "TBD";
                        nuevaCoberturaDB.Defecto = false;
                        nuevaCoberturaDB.userAdd = true;
                        nuevaCoberturaDB.Eliminado = false;
                        nuevaCoberturaDB.Origen = Origen;
                        db.Coberturas.InsertOnSubmit(nuevaCoberturaDB);
                        db.SubmitChanges();
                        nuevaCobertura.Cobertura = nuevaCoberturaDB.ID;
                    }
                    else
                        nuevaCobertura.Cobertura = Convert.ToInt32(dgCoberturas.Rows[i].Cells["ID"].Text.ToString());

                    db.PolizaCobertura.InsertOnSubmit(nuevaCobertura);
                    db.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        bool guardarPolizaEndosos()
        {
            try
            {
                dbSmartGDataContext db = new dbSmartGDataContext();

                // borramos los registros anteriores
                borrarRegistros(8);

                // registramos los nuevos valores
                for (int i = 0; i < dgEndosos.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgEndosos.Rows[i].Cells["Aplica"].Value))
                    {
                        PolizaEndosoEmision nuevaPolizaEndoso = new PolizaEndosoEmision();
                        nuevaPolizaEndoso.Poliza = idPoliza;
                        nuevaPolizaEndoso.EndosoEmision = Convert.ToInt32(dgEndosos.Rows[i].Cells["ID"].Text);
                        nuevaPolizaEndoso.Texto = "";
                        db.PolizaEndosoEmision.InsertOnSubmit(nuevaPolizaEndoso);
                        db.SubmitChanges();
                    }
                }

                return true;
            }
            catch
            {

                return false;
            }
        }

        bool guardarPolizaDeducibles()
        {
            try
            {
                dbSmartGDataContext db = new dbSmartGDataContext();

                // borramos los registros anteriores
                borrarRegistros(2);

                if (chkDeducibles.Checked)
                {
                    // registramos los nuevos valores
                    for (int i = 0; i < dgDeducibles.Rows.Count; i++)
                    {
                        PolizaDeducible nuevaPoliDedu = new PolizaDeducible();
                        nuevaPoliDedu.Poliza = idPoliza;
                        nuevaPoliDedu.Deducible = dgDeducibles.Rows[i].Cells["Deducible"].Text.ToString();
                        nuevaPoliDedu.Porcentaje = Convert.ToDecimal(dgDeducibles.Rows[i].Cells["Porcentaje"].Value);
                        nuevaPoliDedu.Minimo = Convert.ToDecimal(dgDeducibles.Rows[i].Cells["Minimo"].Value);
                        nuevaPoliDedu.Maximo = Convert.ToDecimal(dgDeducibles.Rows[i].Cells["Maximo"].Value);
                        try
                        {
                            nuevaPoliDedu.SIR = Convert.ToBoolean(dgDeducibles.Rows[i].Cells["SIR"].Value.ToString());
                        }
                        catch
                        {
                            nuevaPoliDedu.SIR = false;
                        }
                        nuevaPoliDedu.Agregado = Convert.ToDecimal(dgDeducibles.Rows[i].Cells["Agregado"].Value);
                        db.PolizaDeducible.InsertOnSubmit(nuevaPoliDedu);
                        db.SubmitChanges();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        bool guardarPolizaSublimite()
        {
            try
            {
                dbSmartGDataContext db = new dbSmartGDataContext();

                // borramos los registros anteriores
                borrarRegistros(1);

                if (chkSublimites.Checked)
                {
                    // registramos los nuevos valores
                    for (int i = 0; i < dgSublimites.Rows.Count; i++)
                    {
                        PolizaSublimites nuevaPolizaSub = new PolizaSublimites();
                        nuevaPolizaSub.Poliza = idPoliza;
                        nuevaPolizaSub.SubLimite = dgSublimites.Rows[i].Cells["Sublimite"].Text.ToString();
                        nuevaPolizaSub.Monto = Convert.ToDecimal(dgSublimites.Rows[i].Cells["Monto"].Value);
                        db.PolizaSublimites.InsertOnSubmit(nuevaPolizaSub);
                        db.SubmitChanges();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        bool guardarReaseguros()
        {
            try
            {
                dbSmartGDataContext db = new dbSmartGDataContext();

                // borramos todos los registros
                borrarRegistros(7);

                if (chkReaseguro.Checked)
                {
                    //registramos los nuevos valores
                    PolizaReaseguro nuevaPolizaReaseguro = new PolizaReaseguro();

                    for (int i = 0; i < dgReaseguro.Rows.Count; i++)
                    {
                        if (dgReaseguro.Rows[i].Cells["Reaseguradora"].Text.ToString() != "" && dgReaseguro.Rows[i].Cells["Reaseguradora"].Text.ToString() != "0")
                        {
                            nuevaPolizaReaseguro.Poliza = idPoliza;
                            nuevaPolizaReaseguro.Reaseguradora = Convert.ToInt32(dgReaseguro.Rows[i].Cells["Reaseguradora"].Value);
                            nuevaPolizaReaseguro.PorcParticipacion = Convert.ToDecimal(dgReaseguro.Rows[i].Cells["PorcentajeParticipacion"].Value);
                            nuevaPolizaReaseguro.Participacion = Convert.ToDecimal(dgReaseguro.Rows[i].Cells["Participacion"].Value);
                            nuevaPolizaReaseguro.PorcComision = Convert.ToDecimal(dgReaseguro.Rows[i].Cells["PorcentajeComision"].Value);
                            nuevaPolizaReaseguro.Comision = Convert.ToDecimal(dgReaseguro.Rows[i].Cells["Comision"].Value);
                            if (dgReaseguro.Rows[i].Cells["Intermediario"].Text.ToString() != "")
                                nuevaPolizaReaseguro.Intermediario = Convert.ToInt32(dgReaseguro.Rows[i].Cells["Intermediario"].Value);
                            db.PolizaReaseguro.InsertOnSubmit(nuevaPolizaReaseguro);
                            db.SubmitChanges();
                            nuevaPolizaReaseguro = new PolizaReaseguro();
                        }
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        void guardarVariables()
        {
            ///////////////////////////////////////////////////////////////////////////////////
            //     primera pestaña
            ///////////////////////////////////////////////////////////////////////////////////
            polizaMX = txtPolizaMX.Text;
            polizaES = txtPolizaES.Text;
            tipoOperacion = lbTipoTransaccionTxt.Text;
            ajustable = chkAjustable.Checked;
            portafolio = chkPortafolio.Checked;

            if (cbToB.Value != null)
                ToB = Convert.ToInt32(cbToB.Value);

            if (cbMoneda.Value != null)
                moneda = Convert.ToInt32(cbMoneda.Value);

            if (cbPrograma.Value != null)
                programa = Convert.ToInt32(cbPrograma.Value);

            iniVig = Convert.ToDateTime(dateInicioVig.Value);
            finVig = Convert.ToDateTime(dateFinVigencia.Value);
            emision = Convert.ToDateTime(dateEmision.Value);

            if (chkRetroactiva.Checked)
            {
                retroactiva = true;
                fechaRetroactiva = Convert.ToDateTime(dateRetroactiva.Value);
            }
            else
            {
                retroactiva = false;
                fechaRetroactiva = null;
            }
            fechaContinuidad = Convert.ToDateTime(dateFechaContinuidad.Value);
            limitada = chkLimitada.Checked;

            DAM = txtDAM.Text;

            if (txtPAM.Value != null)
                PAM = Convert.ToInt32(txtPAM.Value);

            if (cbCountry.Value != null)
                country = Convert.ToInt32(cbCountry.Value);

            if (cbBroker.Value != null)
                Broker = Convert.ToInt32(cbBroker.Value);

            if (cbAseguradoMain.Value != null)
                aseguradoPrincipal = Convert.ToInt32(cbAseguradoMain.Value);

            if (cbDireccionRegistrada.Value != null)
                direccionAseguradoPrincipal = Convert.ToInt32(cbDireccionRegistrada.Value);

            delimitacionTerritorial = cbDelimitacionTerritorial.Text;
            if (cbProducto.Value != null)
                productoSel = Convert.ToInt32(cbProducto.Value);

            ///////////////////////////////////////////////////////////////////////////////////
            //     segunda tab
            ///////////////////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////////////////////
            //     tercera tab
            ///////////////////////////////////////////////////////////////////////////////////
            limiteMaximo = Convert.ToDecimal(txtLimiteMaximo.Value);
            estructuraLimite = cbEstructuraLimite.Text;
            sujecion = Convert.ToDecimal(txtSujecion.Value);
            excesoConsejeros = Convert.ToDecimal(txtExcesoConsejeros.Value);

            ///////////////////////////////////////////////////////////////////////////////////
            //     cuarta tab
            ///////////////////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////////////////////
            //     quinta tab
            ///////////////////////////////////////////////////////////////////////////////////
            tituloPolizaGenius = txtTituloPolizaGenius.Text;
            if (chkLTARenegotiable.Checked)
            {
                LTARenegotiable = true;
                LTAInception = Convert.ToDateTime(dateLTAInception.Value);
                LTAExpiry = Convert.ToDateTime(dateLTAExpiry.Value);
            }
            else
            {
                LTARenegotiable = false;
                LTAInception = null;
                LTAExpiry = null;
            }
            paymentCondition = cbPaymentConditions.Text;
            if (cbActivityCode.Value != null)
                activityCode = Convert.ToInt32(cbActivityCode.Value);
            adminClaims = chkAdminClaims.Checked;
            adminPremium = chkAdminPremium.Checked;
            generateDocuments = chkGenerateDocuments.Checked;

            isTieinLimits = chkTieInLimits.Checked;
            numPolizaGlobal = txtNumPolizaGlobal.Text;
            titularPolizaGlobal = txtTitularPolizaGlobal.Text;
            limiteMaximoTieIn = Convert.ToDecimal(txtLimiteMaximoTieInLimits.Value);
            abreMonedaTieIn = cbAbreviacionMonedaTieIn.Text;
            ///////////////////////////////////////////////////////////////////////////////////
            //     sexta tab
            ///////////////////////////////////////////////////////////////////////////////////
            primaNeta = Convert.ToDecimal(txtPrimaNeta.Value);
            primaTotal = Convert.ToDecimal(txtPrimaTotal.Value);
            IVA = cbIVA.Text;
            isBrokerage = chkIsBrokerage.Checked;
            porcBrokerage = Convert.ToDecimal(txtBrokeragePorc.Value);
            comisionBrokerage = Convert.ToDecimal(txtComisionBrokerage.Value);
            ivaBrokerage = Convert.ToDecimal(txtIVABrokerage.Value);
            comisionTotalBrokerage = Convert.ToDecimal(txtComisionTotalBrok.Value);
            tipoPrima = cbTipoPrima.Text;
            turnOver = Convert.ToDecimal(txtTurnOver.Value);
            tipoPoliza = txtTipoPoliza.Text;
            if (cbFormaPago.Value != null)
                formaPago = Convert.ToInt32(cbFormaPago.Value);
            if (txtNumPagos.Value != null)
                numeroPagos = Convert.ToInt32(txtNumPagos.Value);
            observaciones = txtObservaciones.Text;
            descuentos = Convert.ToDecimal(txtDescuentos.Value);
            recargoFraccionado = Convert.ToDecimal(txtRecFraccionado.Value);
            impuestosNetos = Convert.ToDecimal(txtImpuestos.Value);
            gastosExpedicion = Convert.ToDecimal(txtGastosExpedicion.Value);
            totalPoliza = Convert.ToDecimal(txtPrimaTotal.Value);
            ///////////////////////////////////////////////////////////////////////////////////
            //     septima tab
            ///////////////////////////////////////////////////////////////////////////////////
            if (cbCoaseBrokerageSel.Text == "XL Seguros")
            {
                idCoaseguradorLider = idDefaultCoaseguradora;
            }
            else
            {
                if (cbCoaseBrokerageSel.Text != "")
                {
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    idCoaseguradorLider = (from x in db.Coaseguradoras where x.Nombre == cbCoaseBrokerageOtro.Text select x.ID).SingleOrDefault();
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////
            //     octava tab
            ///////////////////////////////////////////////////////////////////////////////////
        }

        void guardarVariablesWording()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            strCoberturas = "";
            strSublimites = "";
            strDeducibles = "";
            strAseguAdicional = "";
            strExceso = "";
            strCoberturas2 = "";
            strIniVig = "Desde: " + formatearFecha(Convert.ToDateTime(dateInicioVig.Value), 1) + " Hrs.";
            strFinVig = "Hasta: " + formatearFecha(Convert.ToDateTime(dateFinVigencia.Value), 1) + " Hrs.";
            strIniVig2 = formatearFecha(Convert.ToDateTime(dateInicioVig.Value), 2);
            strFinVig2 = formatearFecha(Convert.ToDateTime(dateFinVigencia.Value), 2);
            strRetroactiva = formatearFecha(Convert.ToDateTime(dateRetroactiva.Value), 1);
            if (chkReaseguro.Checked)
                diaAnterior = formatearFecha(obtenerDiaHabilAnterior(), 2);
            strEmision = formatearFecha(Convert.ToDateTime(dateEmision.Value), 1);
            strEmision2 = formatearFecha(Convert.ToDateTime(dateEmision.Value), 2);
            strContinuidad = formatearFecha(Convert.ToDateTime(dateFechaContinuidad.Value), 1);
            strFormaPago = cbFormaPago.Text;
            strMoneda = cbMoneda.Text;
            strAbreMon = liIncMonedaTableAdapter.ScalarMon(Convert.ToInt32(cbMoneda.Value));
            Broker tmpBroker = (from x in db.Brokers where x.ID == Convert.ToInt32(cbBroker.Value) select x).SingleOrDefault();
            strBroker = tmpBroker.Broker1 + " (" + tmpBroker.BrokerCode + ")";
            strDireccionAsegu = (from x in db.ClientesDirecciones
                                 where x.ID == Convert.ToInt32(cbDireccionRegistrada.Value)
                                 select x.Calle + " " + x.NumExterior + " " + x.NumInterior + Environment.NewLine + x.Colonia
+ Environment.NewLine + x.Municipio + " " + x.Estado + Environment.NewLine + "CP " + x.CP + ", " + x.Pai.Nombre).SingleOrDefault();
            strRFC = (from x in db.Clientes where x.ID == Convert.ToInt32(cbAseguradoMain.Value) select x.RFC).SingleOrDefault();
            strGiroE = (from x in db.Clientes where x.ID == Convert.ToInt32(cbAseguradoMain.Value) select x.GiroEmpresarial).SingleOrDefault();
            for (int i = 0; i < dgAseguAdicionales.Rows.Count; i++)
            {
                if (i == 0)
                    strAseguAdicional = dgAseguAdicionales.Rows[i].Cells["Asegurado Adicional"].Text.ToString();
                else
                    strAseguAdicional += ", " + dgAseguAdicionales.Rows[i].Cells["Asegurado Adicional"].Text.ToString();
            }

            strLimite = strAbreMon + " " + limiteMaximo.ToString("#,##0", new CultureInfo("en-US"));
            if (excesoConsejeros > 0)
            {
                strExceso = "\n Límite de exceso especial para consejeros independientes (Cobertura 2.2): No aplica.\n";
            }

            modoClaims = "C - Claims Made";

            if (dgDeducibles.Rows.Count == 0)
                strDeducibles = "No aplican deducibles";
            else
            {
                string txtSir;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in dgDeducibles.Rows)
                {//Convert.ToDouble(row.Cells["Agregado"].Text) > 0
                    int caso = 0;
                    if (Convert.ToDouble(row.Cells["Porcentaje"].Value) > 0 && Convert.ToDouble(row.Cells["Minimo"].Value) == 0 && Convert.ToDouble(row.Cells["Maximo"].Value) == 0 && Convert.ToDouble(row.Cells["Agregado"].Value) == 0) { caso = 1; }
                    if (Convert.ToDouble(row.Cells["Porcentaje"].Value) > 0 && Convert.ToDouble(row.Cells["Minimo"].Value) > 0 && Convert.ToDouble(row.Cells["Maximo"].Value) == 0 && Convert.ToDouble(row.Cells["Agregado"].Value) == 0) { caso = 2; }
                    if (Convert.ToDouble(row.Cells["Porcentaje"].Value) > 0 && Convert.ToDouble(row.Cells["Minimo"].Value) > 0 && Convert.ToDouble(row.Cells["Maximo"].Value) > 0 && Convert.ToDouble(row.Cells["Agregado"].Value) == 0) { caso = 3; }
                    if (Convert.ToDouble(row.Cells["Porcentaje"].Value) == 0 && Convert.ToDouble(row.Cells["Minimo"].Value) > 0 && Convert.ToDouble(row.Cells["Maximo"].Value) == 0 && Convert.ToDouble(row.Cells["Agregado"].Value) == 0) { caso = 4; }
                    if (Convert.ToDouble(row.Cells["Porcentaje"].Value) == 0 && Convert.ToDouble(row.Cells["Minimo"].Value) > 0 && Convert.ToDouble(row.Cells["Maximo"].Value) > 0 && Convert.ToDouble(row.Cells["Agregado"].Value) == 0) { caso = 5; }
                    if (Convert.ToDouble(row.Cells["Porcentaje"].Value) == 0 && Convert.ToDouble(row.Cells["Minimo"].Value) > 0 && Convert.ToDouble(row.Cells["Maximo"].Value) == 0 && Convert.ToDouble(row.Cells["Agregado"].Value) > 0) { caso = 6; }
                    if (Convert.ToDouble(row.Cells["Porcentaje"].Value) == 0 && Convert.ToDouble(row.Cells["Minimo"].Value) == 0 && Convert.ToDouble(row.Cells["Maximo"].Value) == 0 && Convert.ToDouble(row.Cells["Agregado"].Value) > 0) { caso = 7; }
                    if (Convert.ToDouble(row.Cells["Porcentaje"].Value) == 0 && Convert.ToDouble(row.Cells["Minimo"].Value) != 0 && Convert.ToDouble(row.Cells["Maximo"].Value) != 0 && Convert.ToDouble(row.Cells["Agregado"].Value) > 0) { caso = 8; }
                    txtSir = ""; if (Convert.ToBoolean(row.Cells["SIR"].Value)) { txtSir = "Retención del Asegurado: "; }
                    switch (caso)
                    {
                        case 1: // Solo porcentaje
                            strDeducibles += "- " + row.Cells["Deducible"].Text + ": " + txtSir + double.Parse(row.Cells["Porcentaje"].Value.ToString()).ToString("#,##0", new CultureInfo("en-US")) + "% por evento.";
                            break;
                        case 2: // Porcentaje con minimo
                            strDeducibles += "- " + row.Cells["Deducible"].Text + ": " + txtSir + double.Parse(row.Cells["Porcentaje"].Value.ToString()).ToString("#,##0", new CultureInfo("en-US")) + "% con mínimo de " + double.Parse(row.Cells["Minimo"].Value.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + " por evento";
                            break;
                        case 3: // Porcentaje con min y max
                            strDeducibles += "- " + row.Cells["Deducible"].Text + ": " + txtSir + double.Parse(row.Cells["Porcentaje"].Value.ToString()).ToString("#,##0", new CultureInfo("en-US")) + "% con mínimo de " + double.Parse(row.Cells["Minimo"].Value.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + " y máximo de " + double.Parse(row.Cells["Maximo"].Value.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + " por evento";
                            break;
                        case 4: // Solo min
                            strDeducibles += "- " + row.Cells["Deducible"].Text + ": " + txtSir + double.Parse(row.Cells["Minimo"].Value.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + " por evento";
                            break;
                        case 5: // Min y Max
                            strDeducibles += "- " + row.Cells["Deducible"].Text + ": " + txtSir + double.Parse(row.Cells["Minimo"].Value.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + " con máximo de " + double.Parse(row.Cells["Maximo"].Value.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + " por evento";
                            break;
                        case 6: // Caso con Agregado y Minimo
                            strDeducibles += "- " + row.Cells["Deducible"].Text + ": " + txtSir + double.Parse(row.Cells["Minimo"].Value.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + " por evento y " + double.Parse(row.Cells["Agregado"].Value.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + " en el agregado por el periodo de la póliza";
                            break;
                        case 7: // Caso con Agregado solo
                            strDeducibles += "- " + row.Cells["Deducible"].Text + ": " + txtSir + double.Parse(row.Cells["Agregado"].Value.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + " en el agregado por el periodo de la póliza";
                            break;
                        case 8:// caso con todo menos porcentaje
                            strDeducibles += "- " + row.Cells["Deducible"].Text + ": " + txtSir + double.Parse(row.Cells["Minimo"].Value.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + " con máximo de " + double.Parse(row.Cells["Maximo"].Value.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " por evento y " + double.Parse(row.Cells["Agregado"].Value.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + " en el agregado por el periodo de la póliza";
                            break;
                    }
                    strDeducibles += "\n";
                }
            }

            bool coberturaConsejeros = false;

            for (int i = 0; i < dgCoberturas.Rows.Count; i++)
            {
                if (!Regex.IsMatch(dgCoberturas.Rows[i].Cells["Cobertura"].Text, @"(^|\s)" + "-" + @"(\s|$)"))
                {
                    if (dgCoberturas.Rows[i].Cells["Cobertura"].Text != "Protección Especial Excedente para Consejeros Independientes")
                    {
                        if (i == 0)
                            strCoberturas = "Cobertura de seguro 2.1" + Environment.NewLine + "- " + dgCoberturas.Rows[i].Cells["Cobertura"].Text;
                        else
                            strCoberturas += Environment.NewLine + "- " + dgCoberturas.Rows[i].Cells["Cobertura"].Text;
                    }
                    else
                    {
                        strCoberturas2 = "Cobertura de seguro 2.2" + Environment.NewLine + "Protección especial excedente para Consejeros Independientes";
                        coberturaConsejeros = true;
                    }
                }
            }

            if(!coberturaConsejeros)
                strCoberturas2 = "Cobertura de seguro 2.2 (no cubierta)" + Environment.NewLine + "Protección especial excedente para Consejeros Independientes";


            int indiceSubs = 1;
            bool encontro = false;


            for (int i = 0; i < extensionesDefault.Count(); i++)
            {
                encontro = false;

                for (int j = 0; j < dgSublimites.Rows.Count(); j++)
                {
                    if (dgSublimites.Rows[j].Cells["Sublimite"].Text.Contains(extensionesDefault[i]))
                    {
                        encontro = true;
                        strSublimites += "3." + indiceSubs + ". " + extensionesDefault[i] + "\t" + "Cubierta" + Environment.NewLine +
                            "Sublimitada a " + strAbreMon + " " + Convert.ToDouble(dgSublimites.Rows[j].Cells["Monto"].Value).ToString("#,##0", new CultureInfo("en-US")) + " toda y cada pérdida y en el agregado anual" + Environment.NewLine + Environment.NewLine;
                    }
                }

                if (!encontro)
                {
                    strSublimites += "3." + indiceSubs + ". " + extensionesDefault[i] + "\t" + "N/A" + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                }
                indiceSubs++;
            }

        }

        void iniciarDatos()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            // iniciamos el tipo de datos
            lbTipoTransaccionTxt.Text = "Nueva Póliza";
            // añadimos horas a la fecha inicial
            dateInicioVig.Value = DateTime.Today.AddHours(12);
            // añadimos un año a la fecha final y las horas
            dateFinVigencia.Value = DateTime.Today.AddYears(1).AddHours(11).AddMinutes(59).AddSeconds(59);
            // fecha actual a la emisión
            dateEmision.Value = DateTime.Now;
            // llena los usuarios
            usuariosTableAdapter.Fill(this.liabilityInc1.LiIncUsuarios);
            // llena los brokers
            liIncBrokersTableAdapter.Fill(this.liabilityInc1.LiIncBrokers);
            cbBroker.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            // llenar los clientes
            liIncClientesTableAdapter.Fill(this.liabilityInc1.LiIncClientes);
            cbAseguradoMain.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            // llenar los productos
            productoTableAdapter.FillByProductosActivos(this.liabilityInc1.Producto, FinancialLines, Origen);
            if (cbProducto.Items.Count > 0)
            {
                cbProducto.SelectedIndex = 0;
                productoSel = Convert.ToInt32(cbProducto.Value);
            }
            // llena los paises del form en inglés
            liIncPaisTableAdapter.Fill(this.liabilityInc1.LiIncPais);
            // llena los programas para FinancialLines incoming
            liIncProgramasTableAdapter.FillByDefaultLiInc(this.liabilityInc1.LiIncProgramas, FinancialLines, Origen);
            // llena las monedas default
            liIncMonedaTableAdapter.Fill(this.liabilityInc1.LiIncMoneda);
            cbMoneda.Value = 1;
            // llena los producing office default
            lNPOTableAdapter.FillByConsultaLNPOporIDLineaNegocio(this.liabilityInc1.LNPO, FinancialLines);
            cbProducingOffice.DisplayMember = "Producing Office";
            cbProducingOffice.ValueMember = "ID";
            // llena los activity Code
            liIncActivityCodeTableAdapter.FillByDefaultLi(this.liabilityInc1.LiIncActivityCode, FinancialLines);
            cbActivityCode.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            // llenado de las coaseguradoras default
            liIncCoaseguradorasTableAdapter.FillByActivos(this.liabilityInc1.LiIncCoaseguradoras);
            cbCoaseguradorLider.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            // llenamos las reaseguradoras default
            liIncReaseguradorasTableAdapter.FillByActivos(this.liabilityInc1.LiIncReaseguradoras);
            cbReaseguradoras.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            // llenado de los intermediarios default
            liIncIntermediariosReaseguroTableAdapter.FillByActivos(this.liabilityInc1.LiIncIntermediariosReaseguro);
            cbIntermediarios.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            // llenado de las formas de pago default
            liIncFormaPagoTableAdapter.Fill(this.liabilityInc1.LiIncFormaPago);
            // llenado de los aggregation PR
            liIncAggregationPRTableAdapter.Fill(this.liabilityInc1.LiIncAggregationPR);
            // llenado de los aggregation PL
            liIncAggregationPLTableAdapter.Fill(this.liabilityInc1.LiIncAggregationPL);
            // llenado de las coberturas DB
            liIncCoberturasDBTableAdapter.FillByDefaultDBOrigenProducto(this.liabilityInc1.LiIncCoberturasDB, FinancialLines, Origen, productoSel);
            // llenado de las coberturas default
            liIncCoberturasTableAdapter.FillByDefaultOrigenProducto(this.liabilityInc1.LiIncCoberturas, FinancialLines, Origen, productoSel);
            dgCoberturas.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            dgCoberturasDB.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            // formateamos el dt para los asegurados adicionales
            dtAseguradosAdicionales = new DataTable();
            dtAseguradosAdicionales.Columns.Add("Asegurado Adicional", typeof(string));
            dgAseguAdicionales.DataSource = dtAseguradosAdicionales;
            // formateamos el dt para coaseguro lider
            dtCoaseguros = new DataTable();
            dtCoaseguros.Columns.Add("PorcentajeParticipacion", typeof(decimal));
            dtCoaseguros.Columns.Add("Participacion", typeof(decimal));
            dtCoaseguros.Columns.Add("PorcentajeComisionBroker", typeof(decimal));
            dtCoaseguros.Columns.Add("ComisionBroker", typeof(decimal));
            // busqueda del coaseguro default xl seguros
            idDefaultCoaseguradora = liIncCoaseguradorasTableAdapter.ScalarIDCoaseguradoraXL("XL Seguros México, S.A. de C.V.");
            // formateamos el dt para reaseguro
            dtReaseguro = new DataTable();
            dtReaseguro.Columns.Add("Treaty", typeof(bool));
            dtReaseguro.Columns.Add("PorcentajeParticipacion", typeof(decimal));
            dtReaseguro.Columns.Add("PorcentajePoliza", typeof(decimal));
            dtReaseguro.Columns.Add("Participacion", typeof(decimal));
            dtReaseguro.Columns.Add("PorcentajeComision", typeof(decimal));
            dtReaseguro.Columns.Add("Comision", typeof(decimal));
            // buscamos el reasegurador default xl seguros
            idDefaultReaseguradora = Convert.ToInt32(liIncReaseguradorasTableAdapter.ScalarIDReaseguradoraXL("XL Seguros México, S.A. de C.V."));
            idIntermediarioDefault = (from x in db.IntermediariosReaseguro where x.Clave == "0000" select x.ID).SingleOrDefault();
            // endosos emision
            #region generamos el datatable endosos
            DataTable dtEndosos = new DataTable();
            dtEndosos.Columns.Add("Aplica", typeof(bool));
            dtEndosos.Columns.Add("ID", typeof(int));
            dtEndosos.Columns.Add("Endoso", typeof(string));
            dtEndosos.Columns.Add("Texto Agregado", typeof(string));
            dtEndosos.Columns.Add("Texto", typeof(string));
            #endregion
            #region llenamos el DT temporal
            DataTable dttmpEnd = endosoEmisionTableAdapter.GetDataByActivos(FinancialLines, Origen);
            for (int i = 0; i < dttmpEnd.Rows.Count; i++)
            {
                dtEndosos.Rows.Add(true, Convert.ToInt32(dttmpEnd.Rows[i]["ID"].ToString()), dttmpEnd.Rows[i]["Endoso"].ToString(), "", dttmpEnd.Rows[i]["EndosoTXT"].ToString());
            }
            #endregion
            #region llenamos el grid de endosos y formateamos
            dgEndosos.DataSource = dtEndosos;
            dgEndosos.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
            dgEndosos.DisplayLayout.Bands[0].Columns["Texto"].Hidden = true;
            dgEndosos.DisplayLayout.Bands[0].Columns["Endoso"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            dgEndosos.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            dgEndosos.DisplayLayout.Bands[0].Columns["Texto Agregado"].Width = 500;
            dgEndosos.DisplayLayout.Bands[0].Columns["Texto Agregado"].AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.VisibleRows;
            dgEndosos.DisplayLayout.Bands[0].Columns["Texto Agregado"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            dgEndosos.DisplayLayout.Bands[0].Columns["Texto Agregado"].Hidden = true;
            #endregion
            // iniciamos el cb de PAM
            txtPAM.Value = Program.Globals.UserID;
            // iniciamos el array de extensiones
            #region Array de extensiones
            llenarExtensiones();
            #endregion
            cbJurisdiccion.SelectedIndex = 0;
            cbTerritorio.SelectedIndex = 0;
        }

        void llenarControlesObligatorios()
        {
            controlesObligatorios = new Control[25];
            controlesObligatorios[0] = txtPolizaMX;
            controlesObligatorios[1] = txtPolizaES;
            controlesObligatorios[2] = cbProducingOffice;
            controlesObligatorios[3] = cbToB;
            controlesObligatorios[4] = cbMoneda;
            controlesObligatorios[5] = cbPrograma;
            controlesObligatorios[6] = txtDAM;
            controlesObligatorios[7] = txtPAM;
            controlesObligatorios[8] = cbCountry;
            controlesObligatorios[9] = cbBroker;
            controlesObligatorios[10] = cbAseguradoMain;
            controlesObligatorios[11] = cbDireccionRegistrada;
            controlesObligatorios[12] = cbDelimitacionTerritorial;
            controlesObligatorios[13] = cbProducto;
            controlesObligatorios[14] = txtLimiteMaximo;
            controlesObligatorios[15] = cbEstructuraLimite;
            controlesObligatorios[16] = txtTituloPolizaGenius;
            controlesObligatorios[17] = cbPaymentConditions;
            controlesObligatorios[18] = cbActivityCode;
            controlesObligatorios[19] = txtPrimaMain;
            controlesObligatorios[20] = cbIVA;
            controlesObligatorios[21] = cbTipoPrima;
            controlesObligatorios[22] = txtTipoPoliza;
            controlesObligatorios[23] = cbFormaPago;
            controlesObligatorios[24] = txtNumPagos;
        }

        void llenarExtensiones()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            int[] coberturaTmp = (from x in db.Coberturas where x.LineaNegocios == FinancialLines && x.Producto == productoSel && x.Origen == Origen select x.ID).ToArray();
            string tmpTextos = "";
            if (coberturaTmp.Count() > 0)
            {
                for (int i = 0; i < coberturaTmp.Count(); i++)
                {
                    CoberturasTextoSubl tmpCobeTexto = (from x in db.CoberturasTextoSubl where x.Cobertura == coberturaTmp[i] select x).SingleOrDefault();
                    if (tmpCobeTexto != null)
                    {
                        if (i == 0 && tmpCobeTexto.TextoSublimites1.Texto != "")
                            tmpTextos = tmpCobeTexto.TextoSublimites1.Texto;
                        else if (tmpCobeTexto.TextoSublimites1.Texto != "")
                        {
                            if(tmpTextos == "")
                                tmpTextos = tmpCobeTexto.TextoSublimites1.Texto;
                            else
                                tmpTextos += ";" + tmpCobeTexto.TextoSublimites1.Texto;
                        }
                    }
                }
                extensionesDefault = tmpTextos.Split(';');
            }

        }

        void llenarMonedas()
        {
            labelsMonedas = new Control[16];
            labelsMonedas[0] = lbMon1;
            labelsMonedas[1] = lbMon2;
            labelsMonedas[2] = lbMon3;
            labelsMonedas[3] = lbMon4;
            labelsMonedas[4] = lbMon5;
            labelsMonedas[5] = lbMon6;
            labelsMonedas[6] = lbMon7;
            labelsMonedas[7] = lbMon8;
            labelsMonedas[8] = lbMon9;
            labelsMonedas[9] = lbMon10;
            labelsMonedas[10] = lbMon11;
            labelsMonedas[11] = lbMon12;
            labelsMonedas[12] = lbMon13;
            labelsMonedas[13] = lbMon14;
            labelsMonedas[14] = lbMon15;
            labelsMonedas[15] = lbMon16;
        }

        void llenarTablaCoaseguro()
        {
            if (dgCoaseguro.Rows.Count == 0)
            {
                // inicializamos el grid y lo formateamos
                dgCoaseguro.DataSource = dtCoaseguros;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["Coaseguradora"].Header.VisiblePosition = 0;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["Coaseguradora"].Width = 350;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["Coaseguradora"].DefaultCellValue = null;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["Coaseguradora"].NullText = "Selecciona un Coasegurador";

                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeParticipacion"].Header.VisiblePosition = 1;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeParticipacion"].Header.Caption = "% Participacion";
                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeParticipacion"].DefaultCellValue = 0;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeParticipacion"].MinValue = 0;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeParticipacion"].MaxValue = 100;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeParticipacion"].MaskInput = "{LOC} nnn%";
                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeParticipacion"].PromptChar = '\0';
                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeParticipacion"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;

                dgCoaseguro.DisplayLayout.Bands[0].Columns["Participacion"].Header.VisiblePosition = 2;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["Participacion"].Header.Caption = "$ Participacion";
                dgCoaseguro.DisplayLayout.Bands[0].Columns["Participacion"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["Participacion"].DefaultCellValue = 0;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["Participacion"].MinValue = 0;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["Participacion"].MaskInput = "{LOC}$ nnn,nnn,nnn,nnn.nn";
                dgCoaseguro.DisplayLayout.Bands[0].Columns["Participacion"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;

                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeComisionBroker"].Header.VisiblePosition = 3;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeComisionBroker"].Header.Caption = "% Comision Broker";
                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeComisionBroker"].DefaultCellValue = 0;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeComisionBroker"].MinValue = 0;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeComisionBroker"].MaxValue = 100;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeComisionBroker"].MaskInput = "{LOC} nnn%";
                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeComisionBroker"].PromptChar = '\0';
                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeComisionBroker"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;

                dgCoaseguro.DisplayLayout.Bands[0].Columns["ComisionBroker"].Header.VisiblePosition = 4;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["ComisionBroker"].Header.Caption = "$ Comision Broker";
                dgCoaseguro.DisplayLayout.Bands[0].Columns["ComisionBroker"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["ComisionBroker"].DefaultCellValue = 0;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["ComisionBroker"].MinValue = 0;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["ComisionBroker"].MaskInput = "{LOC}$ nnn,nnn,nnn,nnn.nn";
                dgCoaseguro.DisplayLayout.Bands[0].Columns["ComisionBroker"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;

                dtCoaseguros.Rows.Add(0, 0, 0, 0);
                dgCoaseguro.Rows[0].Cells["Coaseguradora"].Value = idDefaultCoaseguradora;
            }
        }

        void llenarTablaReaseguro()
        {
            if (dgReaseguro.Rows.Count == 0)
            {
                // inicializamos el grid y lo formateamos
                dgReaseguro.DataSource = dtReaseguro;
                DataTable dtReaseTMP = liIncReaseguradorasTableAdapter.GetDataByDefault();
                for (int i = 0; i < dtReaseTMP.Rows.Count; i++)
                {
                    dtReaseguro.Rows.Add(Convert.ToBoolean(dtReaseTMP.Rows[i]["Treaty"].ToString()), 0, 0, 0, 0, 0);
                }
                dgReaseguro.DisplayLayout.Bands[0].Columns["Reaseguradora"].Header.VisiblePosition = 0;
                dgReaseguro.DisplayLayout.Bands[0].Columns["Reaseguradora"].Width = 500;
                dgReaseguro.DisplayLayout.Bands[0].Columns["Reaseguradora"].DefaultCellValue = null;
                dgReaseguro.DisplayLayout.Bands[0].Columns["Reaseguradora"].NullText = "Selecciona una Reaseguradora";

                dgReaseguro.DisplayLayout.Bands[0].Columns["Intermediario"].Header.VisiblePosition = 7;
                dgReaseguro.DisplayLayout.Bands[0].Columns["Intermediario"].Width = 500;

                dgReaseguro.DisplayLayout.Bands[0].Columns["Treaty"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajeParticipacion"].Header.Caption = "% Participacion";
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajeParticipacion"].DefaultCellValue = 0;
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajeParticipacion"].MinValue = 0;
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajeParticipacion"].MaxValue = 100;
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajeParticipacion"].MaskInput = "{LOC} nnn.nn%";
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajeParticipacion"].PromptChar = '\0';
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajeParticipacion"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;

                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajePoliza"].Header.Caption = "% Aplica en la Poliza";
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajePoliza"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajePoliza"].DefaultCellValue = 0;
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajePoliza"].MinValue = 0;
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajePoliza"].MaxValue = 100;
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajePoliza"].MaskInput = "{LOC} nnn.nn%";
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajePoliza"].PromptChar = '\0';
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajePoliza"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;

                dgReaseguro.DisplayLayout.Bands[0].Columns["Participacion"].Header.Caption = "$ Participacion";
                dgReaseguro.DisplayLayout.Bands[0].Columns["Participacion"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                dgReaseguro.DisplayLayout.Bands[0].Columns["Participacion"].DefaultCellValue = 0;
                dgReaseguro.DisplayLayout.Bands[0].Columns["Participacion"].MinValue = 0;
                dgReaseguro.DisplayLayout.Bands[0].Columns["Participacion"].MaskInput = "{LOC}$ nnn,nnn,nnn,nnn";
                dgReaseguro.DisplayLayout.Bands[0].Columns["Participacion"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;

                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajeComision"].Header.Caption = "% Comision RIC";
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajeComision"].DefaultCellValue = 0;
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajeComision"].MinValue = 0;
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajeComision"].MaxValue = 100;
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajeComision"].MaskInput = "{LOC} nnn.nn%";
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajeComision"].PromptChar = '\0';
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajeComision"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;

                dgReaseguro.DisplayLayout.Bands[0].Columns["Comision"].Header.Caption = "$ Comision RIC";
                dgReaseguro.DisplayLayout.Bands[0].Columns["Comision"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                dgReaseguro.DisplayLayout.Bands[0].Columns["Comision"].DefaultCellValue = 0;
                dgReaseguro.DisplayLayout.Bands[0].Columns["Comision"].MinValue = 0;
                dgReaseguro.DisplayLayout.Bands[0].Columns["Comision"].MaskInput = "{LOC}$ nnn,nnn,nnn,nnn";
                dgReaseguro.DisplayLayout.Bands[0].Columns["Comision"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;

                //dtReaseguro.Rows.Add(false, 0, 0, 0, 0, 0);
                for (int i = 0; i < dtReaseTMP.Rows.Count; i++)
                {
                    dgReaseguro.Rows[i].Cells["Reaseguradora"].Value = Convert.ToInt32(dtReaseTMP.Rows[i]["ID"].ToString());
                }
                for (int i = 0; i < dtReaseTMP.Rows.Count; i++)
                {
                    dgReaseguro.Rows[i].Cells["PorcentajeComision"].Value = Convert.ToDecimal(dtReaseTMP.Rows[i]["Comision"].ToString());
                }
                for (int i = 0; i < dtReaseTMP.Rows.Count; i++)
                {
                    dgReaseguro.Rows[i].Cells["PorcentajeParticipacion"].Value = Convert.ToDecimal(dtReaseTMP.Rows[i]["Fijo Interno"].ToString());
                }
                if (idIntermediarioDefault != 0)
                {
                    for (int i = 0; i < dtReaseTMP.Rows.Count; i++)
                    {
                        dgReaseguro.Rows[i].Cells["Intermediario"].Value = idIntermediarioDefault;
                    }
                }
            }
            terminarEdicionGrids();
        }

        DateTime obtenerDiaHabilAnterior()
        {
            DateTime demo = Convert.ToDateTime(dateInicioVig.Value);
            DateTime result;
            switch (demo.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    result = demo.AddDays(-2);
                    break;

                case DayOfWeek.Monday:
                    result = demo.AddDays(-3);
                    break;

                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Friday:
                    result = demo.AddDays(-1);
                    break;

                case DayOfWeek.Saturday:
                    result = demo.AddDays(-1);
                    break;

                default:
                    throw new ArgumentOutOfRangeException("DayOfWeek=" + demo.DayOfWeek);
            }
            return result;
        }

        void recargarCatalogos()
        {
            int usuariotmp = Convert.ToInt32(txtPAM.Value);
            int brokertmp = Convert.ToInt32(cbBroker.Value);
            int clientetmp = Convert.ToInt32(cbAseguradoMain.Value);
            int paistmp = Convert.ToInt32(cbCountry.Value);
            int programatmp = Convert.ToInt32(cbPrograma.Value);
            int monedatmp = Convert.ToInt32(cbMoneda.Value);
            int potmp = Convert.ToInt32(cbProducingOffice.Value);
            int tobtmp = Convert.ToInt32(cbToB.Value);
            int activitytmp = Convert.ToInt32(cbActivityCode.Value);
            int formapagotmp = Convert.ToInt32(cbFormaPago.Value);
            // llena los usuarios
            usuariosTableAdapter.Fill(this.liabilityInc1.LiIncUsuarios);
            // llena los brokers
            liIncBrokersTableAdapter.Fill(this.liabilityInc1.LiIncBrokers);
            cbBroker.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            // llenar los clientes
            liIncClientesTableAdapter.Fill(this.liabilityInc1.LiIncClientes);
            cbAseguradoMain.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            this.liIncClientesDireccionesTableAdapter.FillByCliente(this.liabilityInc1.LiIncClientesDirecciones, Convert.ToInt32(cbAseguradoMain.Value));
            if (cbDireccionRegistrada.Items.Count > 0)
                cbDireccionRegistrada.SelectedIndex = 0;
            // llenar los productos
            productoTableAdapter.FillByProductosActivos(this.liabilityInc1.Producto, FinancialLines, Origen);
            // llena los paises del form en inglés
            liIncPaisTableAdapter.Fill(this.liabilityInc1.LiIncPais);
            // llena los programas para FinancialLines incoming
            liIncProgramasTableAdapter.FillByDefaultLiInc(this.liabilityInc1.LiIncProgramas, FinancialLines, Origen);
            // llena las monedas default
            liIncMonedaTableAdapter.Fill(this.liabilityInc1.LiIncMoneda);
            cbMoneda.Value = 1;
            // llena los producing office default
            lNPOTableAdapter.FillByConsultaLNPOporIDLineaNegocio(this.liabilityInc1.LNPO, FinancialLines);
            cbProducingOffice.DisplayMember = "Producing Office";
            cbProducingOffice.ValueMember = "ID";
            // llena los activity Code
            liIncActivityCodeTableAdapter.FillByDefaultLi(this.liabilityInc1.LiIncActivityCode, FinancialLines);
            cbActivityCode.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            // llenado de las coaseguradoras default
            liIncCoaseguradorasTableAdapter.FillByActivos(this.liabilityInc1.LiIncCoaseguradoras);
            cbCoaseguradorLider.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            // llenamos las reaseguradoras default
            liIncReaseguradorasTableAdapter.FillByActivos(this.liabilityInc1.LiIncReaseguradoras);
            cbReaseguradoras.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            // llenado de los intermediarios default
            liIncIntermediariosReaseguroTableAdapter.FillByActivos(this.liabilityInc1.LiIncIntermediariosReaseguro);
            cbIntermediarios.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            // llenado de las formas de pago default
            liIncFormaPagoTableAdapter.Fill(this.liabilityInc1.LiIncFormaPago);
            // llenado de las coberturas DB
            liIncCoberturasDBTableAdapter.FillByDefaultDBOrigen(this.liabilityInc1.LiIncCoberturasDB, FinancialLines, Origen);
            // llenado de las coberturas default
            liIncCoberturasTableAdapter.FillByDefaultOrigen(this.liabilityInc1.LiIncCoberturas, FinancialLines, Origen);
            dgCoberturas.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            dgCoberturasDB.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            // busqueda del coaseguro default xl seguros
            idDefaultCoaseguradora = liIncCoaseguradorasTableAdapter.ScalarIDCoaseguradoraXL("XL Seguros México, S.A. de C.V.");
            // buscamos el reasegurador default xl seguros
            idDefaultReaseguradora = Convert.ToInt32(liIncReaseguradorasTableAdapter.ScalarIDReaseguradoraXL("XL Seguros México, S.A. de C.V."));
            // endosos emision
            #region generamos el datatable endosos
            DataTable dtEndosos = new DataTable();
            dtEndosos.Columns.Add("Aplica", typeof(bool));
            dtEndosos.Columns.Add("ID", typeof(int));
            dtEndosos.Columns.Add("Endoso", typeof(string));
            dtEndosos.Columns.Add("Texto Agregado", typeof(string));
            dtEndosos.Columns.Add("Texto", typeof(string));
            #endregion
            #region llenamos el DT temporal
            DataTable dttmpEnd = endosoEmisionTableAdapter.GetDataByActivos(FinancialLines, Origen);
            for (int i = 0; i < dttmpEnd.Rows.Count; i++)
            {
                dtEndosos.Rows.Add(true, Convert.ToInt32(dttmpEnd.Rows[i]["ID"].ToString()), dttmpEnd.Rows[i]["Endoso"].ToString(), "", dttmpEnd.Rows[i]["EndosoTXT"].ToString());
            }
            #endregion
            #region llenamos el grid de endosos y formateamos
            dgEndosos.DataSource = dtEndosos;
            dgEndosos.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
            dgEndosos.DisplayLayout.Bands[0].Columns["Texto"].Hidden = true;
            dgEndosos.DisplayLayout.Bands[0].Columns["Endoso"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            dgEndosos.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            dgEndosos.DisplayLayout.Bands[0].Columns["Texto Agregado"].Width = 500;
            dgEndosos.DisplayLayout.Bands[0].Columns["Texto Agregado"].AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.VisibleRows;
            dgEndosos.DisplayLayout.Bands[0].Columns["Texto Agregado"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            dgEndosos.DisplayLayout.Bands[0].Columns["Texto Agregado"].Hidden = true;
            #endregion

            txtPAM.Value = usuariotmp;
            cbBroker.Value = brokertmp;
            cbAseguradoMain.Value = clientetmp;
            cbCountry.Value = paistmp;
            cbPrograma.Value = programatmp;
            cbMoneda.Value = monedatmp;
            cbProducingOffice.Value = potmp;
            cbToB.Value = tobtmp;
            cbActivityCode.Value = activitytmp;
            cbFormaPago.Value = formapagotmp;
        }

        void retroalimentacion(int caso)
        {
            switch (caso)
            {
                case 0:
                    txtRetroValidaciones.Text += Environment.NewLine + "2) Poliza Guardada con éxito.";
                    break;
                case 1:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error: Debes de ingresar una póliza MX válida para poder continuar con el guardado.";
                    break;
                case 2:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error: La póliza ya ha sido registrada en el sistema previamente, el folio MX es exclusivo.";
                    break;
                case 3:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error no controlado en el guardado. Se deshicieron los cambios.";
                    break;
                case 4:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar los datos FL.";
                    break;
                case 5:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar las coberturas.";
                    break;
                case 6:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar los endosos de emisión.";
                    break;
                case 7:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar los sublimites.";
                    break;
                case 8:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar los deducibles.";
                    break;
                case 9:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar la información de facturación.";
                    break;
                case 10:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar asegurados.";
                    break;
                case 11:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar los coaseguros.";
                    break;
                case 12:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar los reaseguros.";
                    break;
            }
        }

        void terminarEdicionGrids()
        {
            if (dgAseguAdicionales.Rows.Count > 0)
            {
                for (int i = 0; i < dgAseguAdicionales.Rows.Count; i++)
                    dgAseguAdicionales.Rows[i].Update();
            }

            if (dgEndosos.Rows.Count > 0)
            {
                for (int i = 0; i < dgEndosos.Rows.Count; i++)
                    dgEndosos.Rows[i].Update();
            }

            if (dgSublimites.Rows.Count > 0)
            {
                for (int i = 0; i < dgSublimites.Rows.Count; i++)
                    dgSublimites.Rows[i].Update();
            }

            if (dgDeducibles.Rows.Count > 0)
            {
                for (int i = 0; i < dgDeducibles.Rows.Count; i++)
                    dgDeducibles.Rows[i].Update();
            }

            if (dgCoaseguro.Rows.Count > 0)
            {
                for (int i = 0; i < dgCoaseguro.Rows.Count; i++)
                    dgCoaseguro.Rows[i].Update();
            }

            if (dgReaseguro.Rows.Count > 0)
            {
                for (int i = 0; i < dgReaseguro.Rows.Count; i++)
                    dgReaseguro.Rows[i].Update();
            }

        }

        void terminarPolizaNueva()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            Poliza tmpPolizaFinal = (from x in db.Poliza where x.ID == idPoliza select x).SingleOrDefault();
            tmpPolizaFinal.Status = (from y in db.Status where y.Status1 == "Completado" select y.ID).SingleOrDefault();
            tmpPolizaFinal.FechaConclusionRegistro = DateTime.Now;
            db.SubmitChanges();
        }

        bool validarCampos(Control ctrl)
        {
            if (ctrl.Text == "")
            {
                return false;
            }
            return true;
        }

        bool validarCorrectos()
        {
            for (int i = 0; i < 9; i++)
            {
                if (tabControlLiability.Tabs[i].Appearance.ForeColor != Color.Green)
                {
                    return false;
                }
            }
            return true;
        }

        bool validarCliente()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            bool autorizado = Convert.ToBoolean((from x in db.Clientes where x.ID == Convert.ToInt32(cbAseguradoMain.Value) select x.Aprobado).SingleOrDefault());
            return autorizado;
        }

        void validarDatos(int indiceTab)
        {
            bool tmpValida = true;
            switch (indiceTab)
            {
                case 0: // tab datos generales
                    if (txtPolizaMX.Text == "")
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: el campo Poliza MX no puede estar vacio (Datos Generales)";
                    }
                    else if (txtPolizaMX.Text != "")
                    {
                        if (!validarPoliza(txtPolizaMX))
                        {
                            tmpValida = false;
                            txtRetroValidaciones.Text += Environment.NewLine + "Error: el campo Poliza MX debe llenarse correctamente: MX + 8 dígitos seguimiento + DO + 2 dígitos año de emisión + caracter A,B o C  (Datos Generales)";
                        }
                    }
                    if (chkReaseguro.Checked && txtPolizaES.Text == "")
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: el campo Poliza ES no puede estar vacio si se activó el reaseguro (Datos Generales)";
                    }
                    else if (chkReaseguro.Checked && txtPolizaES.Text != "")
                    {
                        if (!validarPoliza(txtPolizaES))
                        {
                            tmpValida = false;
                            txtRetroValidaciones.Text += Environment.NewLine + "Error: el campo Poliza ES debe llenarse correctamente: ES + 8 dígitos seguimiento + DO + 2 dígitos año de emisión + caracter A,B o C (Datos Generales)";
                        }
                    }
                    for (int i = 2; i < 14; i++)
                    {
                        if (!validarCampos(controlesObligatorios[i]))
                        {
                            tmpValida = false;
                            txtRetroValidaciones.Text += Environment.NewLine + "Error: todos los campos a excepción de los asegurados adicionales son obligatorios en la sección Datos Generales (Datos Generales)";
                            break;
                        }
                    }
                    if (DateTime.Compare(Convert.ToDateTime(dateFinVigencia.Value), Convert.ToDateTime(dateInicioVig.Value)) != 1)
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: La fecha de inicio de vigencia no puede ser mayor a la de fin de vigencia (Datos Generales)";
                    }
                    if (chkRetroactiva.Checked)
                    {
                        if (DateTime.Compare(Convert.ToDateTime(dateRetroactiva.Value), Convert.ToDateTime(dateInicioVig.Value)) > 0)
                        {
                            tmpValida = false;
                            txtRetroValidaciones.Text += Environment.NewLine + "Error: La fecha de retroactividad no puede ser mayor a la de inicio de vigencia (Datos Generales)";
                        }
                    }
                    if (tmpValida) // pasó todas las validaciones
                        txtRetroValidaciones.Text += Environment.NewLine + "1) Sección Datos Generales OK";
                    break;

                case 1:// tab coberturas
                    if (dgCoberturas.Rows.Count == 0)
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debes de introducir al menos una cobertura en la póliza (Coberturas)";
                    }
                    if (tmpValida) // pasó todas las validaciones
                        txtRetroValidaciones.Text += Environment.NewLine + "2) Sección Coberturas OK";
                    break;

                case 2: // endosos
                    if (tmpValida) // pasó todas las validaciones
                        txtRetroValidaciones.Text += Environment.NewLine + "3) Sección Endosos emisión OK";
                    break;

                case 3: // tab limites y sublimites
                    if (Convert.ToDecimal(txtLimiteMaximo.Value) <= 0)
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: el límite máximo no puede ser cero (Límites y sublímites)";
                    }
                    if (cbEstructuraLimite.Text == "")
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debes seleccionar un valor para la estructura límite (Límites y sublímites)";
                    }
                    if (txtSujecion.Visible && Convert.ToDecimal(txtSujecion.Value) <= 0)
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: el valor de la sujeción no puede ser cero (Límites y sublímites)";
                    }
                    if (chkSublimites.Checked && dgSublimites.Rows.Count == 0)
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debes de introducir sublimites si activaste la opción de sublimites (Límites y sublímites)";
                    }
                    if (chkSublimites.Checked)
                    {
                        for (int i = 0; i < dgSublimites.Rows.Count; i++)
                        {
                            if (Convert.ToDecimal(dgSublimites.Rows[i].Cells["Monto"].Value) > Convert.ToDecimal(txtLimiteMaximo.Value) || Convert.ToDecimal(dgSublimites.Rows[i].Cells["Monto"].Value) <= 0)
                            {
                                tmpValida = false;
                                txtRetroValidaciones.Text += Environment.NewLine + "Error: el sublímite: " + dgSublimites.Rows[i].Cells["Sublimite"].Text + " no pueden ser cero ni mayor al límite máximo (Límites y sublímites)";
                            }
                        }
                    }
                    #region validacionLimiteMaximo
                    // proceso de validación del límite máximo
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    SmartG.LimiteMaximo limiteVerifica = (from x in db.LimiteMaximo where x.Activo == true select x).SingleOrDefault();
                    if (limiteVerifica != null)
                    {
                        // sacamos el valor de la base de datos correspondiente al valor
                        double? limiteDB = Convert.ToDouble(limiteVerifica.LimiteMaximo1);
                        double? divisaDB = Convert.ToDouble(limiteVerifica.Divisa);

                        // elegimos el caso
                        int caso = 0;
                        if (!chkCoaseguro.Checked && !chkReaseguro.Checked) { caso = 1; } // no hay coaseguro ni reaseguro
                        else if (chkCoaseguro.Checked && !chkReaseguro.Checked) { caso = 2; } // hay coaseguro sin reaseguro
                        else if ((chkCoaseguro.Checked && chkReaseguro.Checked) || (!chkCoaseguro.Checked && chkReaseguro.Checked)) { caso = 3; } //hay o no hay coaseguro y si hay reaseguro

                        // sacamos el valor del limite maximo de la poliza
                        double limitePoliza = Convert.ToDouble(txtLimiteMaximo.Value);
                        // si la moneda de la poliza está en dólares convertimos la cantidad , si no han seleccionado una moneda mandamos el error directamente
                        if (cbMoneda.Text != "")
                        {
                            string tmpAbrevia = (from x in db.Monedas where x.ID == Convert.ToInt32(cbMoneda.Value) select x.Abreviacion).SingleOrDefault();
                            if (tmpAbrevia == "USD")
                            {
                                limiteDB = limiteDB / divisaDB;
                            }
                            switch (caso)
                            {
                                case 1:
                                    if (limitePoliza * 0.001 > limiteDB)
                                    {
                                        tmpValida = false;
                                        txtRetroValidaciones.Text += Environment.NewLine + "Error: el límite máximo de retención de México ha sido sobrepasado, esta póliza no se puede procesar con esos valores, favor de contactar a un administrador para resolver este problema. (Límites y sublímites)";
                                    }
                                    break;
                                case 2:
                                    if (cbTipoCoaseguro.Text != "")
                                    {
                                        if (idDefaultCoaseguradora == Convert.ToInt32(dgCoaseguro.Rows[0].Cells["Coaseguradora"].Value) && cbTipoCoaseguro.Text != "")
                                        {
                                            double coaseguroReg = 0;
                                            if (cbTipoCoaseguro.Text == "Coaseguro Lider")
                                                coaseguroReg = Convert.ToDouble(dgCoaseguro.Rows[0].Cells["Participacion"].Value);
                                            else
                                                coaseguroReg = Convert.ToDouble(txtParticipacionXL.Value);
                                            double primaPoliza = Convert.ToDouble(txtPrimaMain.Value);
                                            double porCoaseguro = coaseguroReg / primaPoliza;
                                            if (porCoaseguro * 0.001 * limitePoliza > limiteDB)
                                            {
                                                tmpValida = false;
                                                txtRetroValidaciones.Text += Environment.NewLine + "Error: el límite máximo de retención de México ha sido sobrepasado, esta póliza no se puede procesar con esos valores, favor de contactar a un administrador para resolver este problema. (Límites y sublímites)";
                                            }
                                        }
                                        else
                                        {
                                            tmpValida = false;
                                            txtRetroValidaciones.Text += Environment.NewLine + "Error: la coaseguradora por defecto no se encuentra en el registro o hay problemas en el mismo, intenta seleccionar un típo de coaseguro (lider o seguidor) y llenar correctamente o bien favor de contactar a un administrador para resolver este problema. (Límites y sublímites)";
                                        }
                                    }
                                    else
                                    {
                                        tmpValida = false;
                                        txtRetroValidaciones.Text += Environment.NewLine + "Error: la coaseguradora por defecto no se encuentra en el registro o hay problemas en el mismo, intenta seleccionar un típo de coaseguro (lider o seguidor) y llenar correctamente o bien favor de contactar a un administrador para resolver este problema. (Límites y sublímites)";
                                    }
                                    break;
                                case 3:
                                    if (idDefaultReaseguradora == Convert.ToInt32(dgReaseguro.Rows[0].Cells["Reaseguradora"].Value))
                                    {//Participacion
                                        double reaseguroReg = Convert.ToDouble(dgReaseguro.Rows[0].Cells["Participacion"].Value);
                                        double primaPolizaReg = Convert.ToDouble(txtPrimaMain.Value);
                                        double porcReaseguro = reaseguroReg / primaPolizaReg;
                                        if (porcReaseguro * 0.001 * limitePoliza > limiteDB)
                                        {
                                            tmpValida = false;
                                            txtRetroValidaciones.Text += Environment.NewLine + "Error: el límite máximo de retención de México ha sido sobrepasado, esta póliza no se puede procesar con esos valores, favor de contactar a un administrador para resolver este problema. (Límites y sublímites)";
                                        }
                                    }
                                    else
                                    {
                                        tmpValida = false;
                                        txtRetroValidaciones.Text += Environment.NewLine + "Error: no se encuentra la reaseguradora por defecto en el registro o hay algun problema en el mismo, favor de contactar a un administrador para resolver este problema. (Límites y sublímites)";
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            tmpValida = false;
                            txtRetroValidaciones.Text += Environment.NewLine + "Error: debes de seleccionar una moneda válida de la pestaña Datos Generales antes de poder evaluar el límite máximo de retención. (Límites y sublímites)";
                        }
                    }
                    else
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debe de haber un límite máximo registrado en el sistema, consulte al soporte técnico. (Límites y sublímites)";
                    }
                    #endregion
                    if (tmpValida) // pasó todas las validaciones
                        txtRetroValidaciones.Text += Environment.NewLine + "4) Sección Limites y Sublimites OK";
                    break;

                case 4: // tab deducibles
                    if (chkDeducibles.Checked && dgDeducibles.Rows.Count <= 0)
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debes de introducir deducibles si activaste la opción de deducibles (Deducibles)";
                    }
                    if (chkDeducibles.Checked && dgDeducibles.Rows.Count > 0)
                    {
                        if (!validarTablaDeducibles())
                        {
                            tmpValida = false;
                        }
                    }
                    if (tmpValida) // pasó todas las validaciones
                        txtRetroValidaciones.Text += Environment.NewLine + "5) Sección Deducibles OK";
                    break;

                case 5: // tab valores Genius
                    if (txtTituloPolizaGenius.Text == "")
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debes de introducir un título de póliza Genius Válido (Valores Genius)";

                    }
                    if (chkLTARenegotiable.Checked)
                    {
                        if (DateTime.Compare(Convert.ToDateTime(dateLTAExpiry.Value), Convert.ToDateTime(dateLTAInception.Value)) != 1)
                        {
                            tmpValida = false;
                            txtRetroValidaciones.Text += Environment.NewLine + "Error: La fecha LTA Inception no puede ser mayor a la de LTA Expiry (Valores Genius)";
                        }
                    }
                    if (cbPaymentConditions.Text == "")
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: el valor Payment Conditions no puede estar vacio (Valores Genius)";
                    }
                    if (cbActivityCode.Text == "")
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: el valor Activity code no puede estar vacio (Valores Genius)";
                    }

                    if (chkTieInLimits.Checked)
                    {
                        if (txtNumPolizaGlobal.Text == "")
                        {
                            tmpValida = false;
                            txtRetroValidaciones.Text += Environment.NewLine + "Error: el valor número de póliza global no puede estar vacio si está activada la opción tie-in limits (Valores Genius)";
                        }

                        if (txtTitularPolizaGlobal.Text == "")
                        {
                            tmpValida = false;
                            txtRetroValidaciones.Text += Environment.NewLine + "Error: el valor titular póliza global no puede estar vacio si está activada la opción tie-in limits (Valores Genius)";
                        }

                        //if () // FIX , preguntar por la restricción si puede ser cero
                        //{
                        //    tmpValida = false;
                        //    txtRetroValidaciones.Text += Environment.NewLine + "Error: el valor número de póliza global no puede estar vacio si está activada la opción tie-in limits (Valores Genius)";
                        //}
                    }

                    if (tmpValida) // pasó todas las validaciones
                        txtRetroValidaciones.Text += Environment.NewLine + "6) Sección Valores Genius OK";
                    break;

                case 6: // tab prima
                    if (Convert.ToDecimal(txtPrimaMain.Value) == 0)
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debes de introducir una prima mayor a 0 (Prima)";
                    }
                    if (cbIVA.Text == "")
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debes de seleccionar un valor para el IVA (Prima)";
                    }
                    if (cbTipoPrima.Text == "")
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debes de seleccionar un tipo de Prima (Prima)";
                    }
                    if (txtTurnOver.Visible && Convert.ToDecimal(txtTurnOver.Value) <= 0)
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: el valor del TurnOver no puede ser cero (Prima)";
                    }
                    if (txtTipoPoliza.Text == "")
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: el valor del TurnOver no puede ser cero (Prima)";
                    }
                    if (cbFormaPago.Text == "")
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debes de elegir unan forma de pago (Prima)";
                    }
                    if (Convert.ToInt32(txtNumPagos.Value) <= 0)
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: el número de pagos no puede ser cero (Prima)";
                    }
                    if (tmpValida) // pasó todas las validaciones
                        txtRetroValidaciones.Text += Environment.NewLine + "7) Sección Prima OK";
                    break;

                case 7: // tab coaseguros
                    if (chkCoaseguro.Checked)
                    {
                        if (cbTipoCoaseguro.Text == "")
                        {
                            tmpValida = false;
                            txtRetroValidaciones.Text += Environment.NewLine + "Error: debes seleccionar un tipo de coaseguro (Coaseguro)";
                        }
                        if (cbCoaseBrokerageSel.Text == "")
                        {
                            tmpValida = false;
                            txtRetroValidaciones.Text += Environment.NewLine + "Error: se debe seleccionar quién administrará el coaseguro (Coaseguro)";
                        }
                        if (cbCoaseBrokerageOtro.Visible && cbCoaseBrokerageOtro.Text == "")
                        {
                            tmpValida = false;
                            txtRetroValidaciones.Text += Environment.NewLine + "Error: se debe seleccionar un coasegurador administrador (Coaseguro)";
                        }
                        if (cbTipoCoaseguro.Text == "Coaseguro Lider")
                        {
                            if (!validarTablaCoaseguros())
                            {
                                tmpValida = false;
                            }
                        }
                        if (cbTipoCoaseguro.Text == "Coaseguro Seguidor")
                        {
                            if (cbCoaseguradorLider.Text == "")
                            {
                                tmpValida = false;
                                txtRetroValidaciones.Text += Environment.NewLine + "Error: se debe seleccionar un coasegurador lider (Coaseguro)";
                            }
                            if (Convert.ToDecimal(txtPorParticipacionXL.Value) <= 0)
                            {
                                tmpValida = false;
                                txtRetroValidaciones.Text += Environment.NewLine + "Error: el valor de participación de XL Seguros no puede ser cero (Coaseguro)";
                            }
                        }
                    }
                    if (tmpValida) // pasó todas las validaciones
                        txtRetroValidaciones.Text += Environment.NewLine + "8) Sección Coaseguro OK";
                    break;

                case 8: // tab reaseguros
                    if (chkReaseguro.Checked)
                    {
                        if (!validarTablaReaseguros())
                        {
                            tmpValida = false;
                        }
                    }
                    if (tmpValida) // pasó todas las validaciones
                        txtRetroValidaciones.Text += Environment.NewLine + "9) Sección Reaseguro OK";
                    break;
            }

            //pintamos la tab en cuestión
            if (tmpValida)
            {
                tabControlLiability.Tabs[indiceTab].Appearance.BorderColor3DBase = Color.Green;
                tabControlLiability.Tabs[indiceTab].Appearance.ForeColor = Color.Green;
            }
            else
            {
                tabControlLiability.Tabs[indiceTab].Appearance.BorderColor3DBase = Color.Red;
                tabControlLiability.Tabs[indiceTab].Appearance.ForeColor = Color.Red;
            }

        }

        void validarFechaReaseguro()
        {
            if (chkReaseguro.Checked)
            {
                string iString = "2018-07-01 00:00 AM";
                DateTime oDate = DateTime.ParseExact(iString, "yyyy-MM-dd HH:mm tt", System.Globalization.CultureInfo.InvariantCulture);
                if (DateTime.Compare(Convert.ToDateTime(dateEmision.Value), oDate) == -1)
                {
                    MessageBox.Show("Se está registrando una póliza con fecha de emisión previa al primero de julio del año 2018, se sugiere hacer el ajuste manual a las reaseguradoras, en caso contrario has caso omiso del mensaje", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        bool validarPoliza(Control ctr)
        {
            if (ctr.Text.ToString().Count() == 15)
            {
                char ultimo = ctr.Text.ToString()[14];
                if (System.Char.IsDigit(ultimo))
                {
                    return false;
                }
                else
                {
                    if (ultimo != 'A' && ultimo != 'B' && ultimo != 'C')
                    {
                        return false;
                    }
                }

                if (ctr.Name == "txtPolizaMX")
                {
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    Poliza tmpPoliza;

                    if (idPoliza == 0) // primver save
                        tmpPoliza = (from x in db.Poliza where x.Poliza1 == ctr.Text select x).SingleOrDefault();
                    else // saves posteriores
                        tmpPoliza = (from x in db.Poliza where x.Poliza1 == ctr.Text && x.ID != idPoliza select x).SingleOrDefault();

                    if (tmpPoliza != null)
                    {
                        MessageBox.Show("Error: ya existe una póliza con ese folio, no puedes continuar sin un número de póliza exclusivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                return true;
            }
            else
                return false;
        }

        bool validarTablaDeducibles()
        {
            //validacion valores en el grid
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in dgDeducibles.Rows)
            {
                int caso = 0;
                if (Convert.ToDecimal(row.Cells["Porcentaje"].Value) != 0 && Convert.ToDecimal(row.Cells["Minimo"].Value) == 0 && Convert.ToDecimal(row.Cells["Maximo"].Value) == 0 && Convert.ToDecimal(row.Cells["Agregado"].Value) == 0) { caso = 1; }
                if (Convert.ToDecimal(row.Cells["Porcentaje"].Value) != 0 && Convert.ToDecimal(row.Cells["Minimo"].Value) != 0 && Convert.ToDecimal(row.Cells["Maximo"].Value) == 0 && Convert.ToDecimal(row.Cells["Agregado"].Value) == 0) { caso = 2; }
                if (Convert.ToDecimal(row.Cells["Porcentaje"].Value) != 0 && Convert.ToDecimal(row.Cells["Minimo"].Value) != 0 && Convert.ToDecimal(row.Cells["Maximo"].Value) != 0 && Convert.ToDecimal(row.Cells["Agregado"].Value) == 0) { caso = 3; }
                if (Convert.ToDecimal(row.Cells["Porcentaje"].Value) == 0 && Convert.ToDecimal(row.Cells["Minimo"].Value) != 0 && Convert.ToDecimal(row.Cells["Maximo"].Value) == 0 && Convert.ToDecimal(row.Cells["Agregado"].Value) == 0) { caso = 4; }
                if (Convert.ToDecimal(row.Cells["Porcentaje"].Value) == 0 && Convert.ToDecimal(row.Cells["Minimo"].Value) != 0 && Convert.ToDecimal(row.Cells["Maximo"].Value) != 0 && Convert.ToDecimal(row.Cells["Agregado"].Value) == 0) { caso = 5; }
                if (Convert.ToDecimal(row.Cells["Porcentaje"].Value) == 0 && Convert.ToDecimal(row.Cells["Minimo"].Value) != 0 && Convert.ToDecimal(row.Cells["Maximo"].Value) == 0 && Convert.ToDecimal(row.Cells["Agregado"].Value) != 0) { caso = 6; }
                if (Convert.ToDecimal(row.Cells["Porcentaje"].Value) == 0 && Convert.ToDecimal(row.Cells["Minimo"].Value) == 0 && Convert.ToDecimal(row.Cells["Maximo"].Value) == 0 && Convert.ToDecimal(row.Cells["Agregado"].Value) != 0) { caso = 7; }
                if (caso == 0)
                {
                    txtRetroValidaciones.Text += Environment.NewLine + "Error: el deducible " + row.Cells["Deducible"].Value.ToString() + " no tiene los datos correctos ingresados (Deducibles)";
                    return false;
                }
            }
            return true;
        }

        bool validarTablaCoaseguros()
        {
            // validamos que haya coaseguradores registrados
            if (dgCoaseguro.Rows.Count == 0)
            {
                txtRetroValidaciones.Text += Environment.NewLine + "Error: no hay coaseguradores registrados (Coaseguro)";
                return false;
            }

            // validamos que no haya coaseguradores repetidos
            int idTmp = 0;
            for (int i = 0; i < dgCoaseguro.Rows.Count; i++)
            {
                if (dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text.ToString() != "")
                {
                    idTmp = Convert.ToInt32(dgCoaseguro.Rows[i].Cells["Coaseguradora"].Value);
                    for (int j = i + 1; j < dgCoaseguro.Rows.Count; j++)
                    {
                        if (dgCoaseguro.Rows[j].Cells["Coaseguradora"].Text.ToString() != "")
                        {
                            if (idTmp == Convert.ToInt32(dgCoaseguro.Rows[j].Cells["Coaseguradora"].Value))
                            {
                                txtRetroValidaciones.Text += Environment.NewLine + "Error: no puede haber coaseguradoras repetidas en el registro (Coaseguro)";
                                return false;
                            }
                        }
                    }
                }
            }

            decimal tmpParticipacion = 0;
            decimal tmpBrokerage = 0;

            // validamos que las cantidades sumen 100% para participación y brokerage
            for (int i = 0; i < dgCoaseguro.Rows.Count; i++)
            {
                if (dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text.ToString() != "" && dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text.ToString() != "0"
                    && dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text.ToString() != "Selecciona un Coasegurador")
                {
                    tmpParticipacion += Convert.ToDecimal(dgCoaseguro.Rows[i].Cells["PorcentajeParticipacion"].Value.ToString());
                    tmpBrokerage += Convert.ToDecimal(dgCoaseguro.Rows[i].Cells["PorcentajeComisionBroker"].Value.ToString());
                }
            }
            if (tmpParticipacion != 100)
            {
                txtRetroValidaciones.Text += Environment.NewLine + "Error: los porcentajes de las participaciones no suman 100 % (Coaseguro)";
                return false;
            }
            if (tmpBrokerage != 100)
            {
                txtRetroValidaciones.Text += Environment.NewLine + "Error: los porcentajes del pago de brokerage no suman 100 % (Coaseguro)";
                return false;
            }

            bool tmpEncontroXL = false;
            // validamos que exista el coasegurador XL
            for (int i = 0; i < dgCoaseguro.Rows.Count; i++)
            {
                if (dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text.ToString() != "")
                {
                    if (Convert.ToInt32(dgCoaseguro.Rows[i].Cells["Coaseguradora"].Value) == idDefaultCoaseguradora)
                    {
                        tmpEncontroXL = true;
                    }
                }
            }
            if (!tmpEncontroXL)
            {
                txtRetroValidaciones.Text += Environment.NewLine + "Error: no se ha registrado a XL Seguros como coasegurador (Coaseguro)";
                return false;
            }

            return true;
        }

        bool validarTablaReaseguros()
        {
            // validamos que haya coaseguradores registrados
            if (dgReaseguro.Rows.Count == 0)
            {
                txtRetroValidaciones.Text += Environment.NewLine + "Error: no hay reaseguradores registrados (Reaseguro)";
                return false;
            }

            // validamos que no haya reaseguradoras repetidos
            int idTmp = 0;
            for (int i = 0; i < dgReaseguro.Rows.Count; i++)
            {
                if (dgReaseguro.Rows[i].Cells["Reaseguradora"].Text.ToString() != "")
                {
                    idTmp = Convert.ToInt32(dgReaseguro.Rows[i].Cells["Reaseguradora"].Value);
                    for (int j = i + 1; j < dgReaseguro.Rows.Count; j++)
                    {
                        if (dgReaseguro.Rows[j].Cells["Reaseguradora"].Text.ToString() != "")
                        {
                            if (idTmp == Convert.ToInt32(dgReaseguro.Rows[j].Cells["Reaseguradora"].Value))
                            {
                                txtRetroValidaciones.Text += Environment.NewLine + "Error: no puede haber reaseguradoras repetidas en el registro (Reaseguro)";
                                return false;
                            }
                        }
                    }
                }
            }

            decimal tmpParticipacion = 0;
            // validamos que las cantidades sumen 100% para la participacion
            for (int i = 0; i < dgReaseguro.Rows.Count; i++)
            {
                if (dgReaseguro.Rows[i].Cells["Reaseguradora"].Text.ToString() != "" && dgReaseguro.Rows[i].Cells["Reaseguradora"].Text.ToString() != "0" &&
                    dgReaseguro.Rows[i].Cells["Reaseguradora"].Text.ToString() != "Selecciona una Reaseguradora")
                {
                    tmpParticipacion += Convert.ToDecimal(dgReaseguro.Rows[i].Cells["PorcentajePoliza"].Value.ToString());
                }
            }
            if (tmpParticipacion != 100)
            {
                txtRetroValidaciones.Text += Environment.NewLine + "Error: los porcentajes de las participaciones no suman 100% en la columna Porcentaje Póliza (Reaseguro)";
                return false;
            }


            bool tmpEncontroXL = false;
            // validamos que exista el reasegurador XL
            for (int i = 0; i < dgReaseguro.Rows.Count; i++)
            {
                if (dgReaseguro.Rows[i].Cells["Reaseguradora"].Text.ToString() != "")
                {
                    if (Convert.ToInt32(dgReaseguro.Rows[i].Cells["Reaseguradora"].Value) == idDefaultReaseguradora)
                    {
                        tmpEncontroXL = true;
                    }
                }
            }
            if (!tmpEncontroXL)
            {
                txtRetroValidaciones.Text += Environment.NewLine + "Error: no se ha registrado a XL Seguros como reasegurador (Reaseguro)";
                return false;
            }

            for (int i = 0; i < dgReaseguro.Rows.Count; i++)
            {
                if (dgReaseguro.Rows[i].Cells["Reaseguradora"].Text.ToString() != "")
                {
                    if (dgReaseguro.Rows[i].Cells["Intermediario"].Text.ToString() == "")
                    {
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: la reaseguradora " + dgReaseguro.Rows[i].Cells["Reaseguradora"].Text + " no cuenta con un intermediario registrado. (Reaseguro)";
                        return false;
                    }
                }
            }



            return true;
        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region EventosForm

        private void btnEnviarCobertura_Click(object sender, EventArgs e)
        {
            if (dgCoberturasDB.Selected.Rows.Count == 1)
            {
                liabilityInc1.LiIncCoberturas.Rows.Add(Convert.ToInt32(dgCoberturasDB.ActiveRow.Cells["ID"].Text.ToString()),
                    FinancialLines, dgCoberturasDB.ActiveRow.Cells["Cobertura"].Text.ToString(), dgCoberturasDB.ActiveRow.Cells["CoberturaIngles"].Text.ToString(),
                    dgCoberturasDB.ActiveRow.Cells["GeniusCode"].Text.ToString(), Convert.ToBoolean(dgCoberturasDB.ActiveRow.Cells["Defecto"].Text),
                    Convert.ToBoolean(dgCoberturasDB.ActiveRow.Cells["userAdd"].Text), Convert.ToBoolean(dgCoberturasDB.ActiveRow.Cells["Eliminado"].Text),
                    Origen);
                liabilityInc1.LiIncCoberturasDB.Rows.RemoveAt(dgCoberturasDB.ActiveRow.Index);
            }
            else
            {
                if (dgCoberturasDB.Selected.Rows.Count < 1)
                    MessageBox.Show("Debes seleccionar una cobertura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Debes seleccionar solo una cobertura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitarCobertura_Click(object sender, EventArgs e)
        {
            if (dgCoberturas.Selected.Rows.Count == 1)
            {
                liabilityInc1.LiIncCoberturasDB.Rows.Add(Convert.ToInt32(dgCoberturas.ActiveRow.Cells["ID"].Text.ToString()),
                   FinancialLines, dgCoberturas.ActiveRow.Cells["Cobertura"].Text.ToString(), dgCoberturas.ActiveRow.Cells["CoberturaIngles"].Text.ToString(),
                   dgCoberturas.ActiveRow.Cells["GeniusCode"].Text.ToString(), Convert.ToBoolean(dgCoberturas.ActiveRow.Cells["Defecto"].Text),
                   Convert.ToBoolean(dgCoberturas.ActiveRow.Cells["userAdd"].Text), Convert.ToBoolean(dgCoberturas.ActiveRow.Cells["Eliminado"].Text),
                   Origen);
                liabilityInc1.LiIncCoberturas.Rows.RemoveAt(dgCoberturas.ActiveRow.Index);
            }
            else
            {
                if (dgCoberturas.Selected.Rows.Count < 1)
                    MessageBox.Show("Debes seleccionar una cobertura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Debes seleccionar solo una cobertura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRecargarSublimites_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas sustituir los valores por los que están actualmente en la sección Coberturas?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                dtSublimites.Rows.Clear();
                dbSmartGDataContext db = new dbSmartGDataContext();


                for (int i = 0; i < dgCoberturas.Rows.Count; i++)
                {
                    int idTemp = Convert.ToInt32(dgCoberturas.Rows[i].Cells["ID"].Text);
                    int?[] idsTemp = (from x in db.CoberturasTextoSubl where x.Cobertura == idTemp select x.TextoSublimites).ToArray();
                    if (idsTemp.Count() > 0)
                    {
                        for (int j = 0; j < idsTemp.Count(); j++)
                        {
                            TextoSublimites txtTmp = (from y in db.TextoSublimites where y.ID == idsTemp[j] select y).SingleOrDefault();
                            dtSublimites.Rows.Add(txtTmp.Texto, 0);
                        }
                    }
                }

                dgSublimites.DataSource = dtSublimites;
                dgSublimites.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                dgSublimites.DisplayLayout.Bands[0].Columns["Monto"].DefaultCellValue = 0;
                dgSublimites.DisplayLayout.Bands[0].Columns["Sublimite"].NullText = "Nuevo Sublímite";
                dgSublimites.DisplayLayout.Bands[0].Columns["Monto"].MinValue = 0;
            }
        }

        private void btnTipoCambio_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtTipoCambio.Value) > 0)
            {
                if (MessageBox.Show("Esta operación cambiara todo los valores ingresados en el formato, desea continuar?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    //limites
                    decimal tipoCambio = Convert.ToDecimal(txtTipoCambio.Value);
                    txtLimiteMaximo.Value = Convert.ToDecimal(txtLimiteMaximo.Value) * tipoCambio;
                    txtSujecion.Value = Convert.ToDecimal(txtSujecion.Value) * tipoCambio;

                    //sublimites
                    for (int i = 0; i < dgSublimites.Rows.Count; i++)
                    {
                        dgSublimites.Rows[i].Cells["Monto"].Value = Convert.ToDecimal(dgSublimites.Rows[i].Cells["Monto"].Value) * tipoCambio;
                    }

                    //deducibles
                    for (int i = 0; i < dgDeducibles.Rows.Count; i++)
                    {
                        dgDeducibles.Rows[i].Cells["Minimo"].Value = Convert.ToDecimal(dgDeducibles.Rows[i].Cells["Minimo"].Value) * tipoCambio;
                        dgDeducibles.Rows[i].Cells["Maximo"].Value = Convert.ToDecimal(dgDeducibles.Rows[i].Cells["Maximo"].Value) * tipoCambio;
                    }

                    txtPrimaMain.Value = Convert.ToDecimal(txtPrimaMain.Value) * tipoCambio;
                    txtTurnOver.Value = Convert.ToDecimal(txtTurnOver.Value) * tipoCambio;

                    calcularPrimaTotal();
                    calcularBrokerage();
                    calcularLabelCoaseguro();
                    calcularCoaseguros();
                    calcularLabelReaseguro();
                    calcularReaseguros();
                }
            }
        }

        private void btnTituloPolizaGenius_Click(object sender, EventArgs e)
        {
            if (cbAseguradoMain.Text != "")
            {
                //Comenzamos con el line of business (FinancialLines)
                string codigoGenius = "LIAB";

                if (cbAseguradoMain.Text.Length > 16)
                    //parseamos el nombre del cliente a 16 letras
                    codigoGenius = codigoGenius + " " + cbAseguradoMain.Text.Substring(0, 15) + " " + "MEXICO MX";
                else
                    codigoGenius = codigoGenius + " " + cbAseguradoMain.Text + " " + "MEXICO MX";

                txtTituloPolizaGenius.Text = codigoGenius.ToUpper();
            }
            else
            {
                MessageBox.Show("Debes asignar un asegurado adicional para generar el título de la póliza en Genius", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbAseguradoMain_ValueChanged(object sender, EventArgs e)
        {
            if (cbAseguradoMain.Text != "")
            {
                try
                {
                    // llenamos las direcciones con lo seleccionado
                    this.liIncClientesDireccionesTableAdapter.FillByCliente(this.liabilityInc1.LiIncClientesDirecciones, Convert.ToInt32(cbAseguradoMain.Value));
                    if (cbDireccionRegistrada.Items.Count > 0)
                        cbDireccionRegistrada.SelectedIndex = 0;
                }
                catch
                {
                }
            }
        }

        private void cbCoaseguradorLider_ValueChanged(object sender, EventArgs e)
        {
            if (cbCoaseguradorLider.Text != "")
            {
                cbCoaseBrokerageOtro.Items.Clear();
                cbCoaseBrokerageOtro.Items.Add(cbCoaseguradorLider.Text);
                cbCoaseBrokerageOtro.Text = cbCoaseguradorLider.Text;
            }
        }

        private void cbCoaseBrokerageSel_ValueChanged(object sender, EventArgs e)
        {
            if (cbCoaseBrokerageSel.Text == "Otro")
            {
                lbCoaseBrokerageOtro.Visible = true;
                cbCoaseBrokerageOtro.Visible = true;
            }
            else
            {
                lbCoaseBrokerageOtro.Visible = false;
                cbCoaseBrokerageOtro.Visible = false;
            }
        }

        private void cbEstructuraLimite_ValueChanged(object sender, EventArgs e)
        {
            if (cbEstructuraLimite.Text == "Capa de Exceso")
            {
                lbSujecion.Visible = true;
                txtSujecion.Visible = true;
                lbMon2.Visible = true;
            }
            else
            {
                lbSujecion.Visible = false;
                txtSujecion.Visible = false;
                lbMon2.Visible = false;
            }
        }

        private void cbFormaPago_ValueChanged(object sender, EventArgs e)
        {
            double recargo = 0;
            switch (cbFormaPago.Text)
            {
                case "Contado":
                    txtRecFraccionado.Value = 0;
                    txtNumPagos.Value = 1;
                    break;
                case "Mensual":
                    recargo = Convert.ToDouble(txtPrimaMain.Value) * 0.06;
                    txtRecFraccionado.Value = recargo;
                    txtNumPagos.Value = 12;
                    break;
                case "Trimestral":
                    recargo = Convert.ToDouble(txtPrimaMain.Value) * 0.05;
                    txtRecFraccionado.Value = recargo;
                    txtNumPagos.Value = 4;
                    break;
                case "Semestral":
                    recargo = Convert.ToDouble(txtPrimaMain.Value) * 0.03;
                    txtRecFraccionado.Value = recargo;
                    txtNumPagos.Value = 2;
                    break;
                case "Anual":
                    txtRecFraccionado.Value = 0;
                    txtNumPagos.Value = 1;
                    break;
                default:
                    txtRecFraccionado.Value = 0;
                    txtNumPagos.Value = 1;
                    break;
            }
            calcularPrimaTotal();
        }

        private void cbMoneda_ValueChanged(object sender, EventArgs e)
        {
            if (cbMoneda.Text != "")
            {
                mon = liIncMonedaTableAdapter.ScalarMon(Convert.ToInt32(cbMoneda.Value));
                for (int i = 0; i < labelsMonedas.Count(); i++)
                {
                    labelsMonedas[i].Text = mon;
                }
            }
        }

        private void cbProducto_ValueChanged(object sender, EventArgs e)
        {
            //if (cbProducto.Text == "Directivos y Funcionarios")
            //{
            //    txtTipoPoliza.Text = "Responsabilidad Civil Directivos y Funcionarios";
            //    txtPolizaMX.InputMask = "MX########DO##A";
            //    txtPolizaES.InputMask = "ES########DO##A";
            //}
            //else
            //{
            //    txtTipoPoliza.Text = "Responsabilidad Civil Errores y Omisiones";
            //    txtPolizaMX.InputMask = "MX########EO##A";
            //    txtPolizaES.InputMask = "ES########EO##A";
            //}
            if (cbProducto.Text != "")
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                Producto productoTmp = (from x in db.Producto where x.ID == Convert.ToInt32(cbProducto.Value) select x).SingleOrDefault();
                if (productoTmp != null)
                {
                    txtPolizaMX.InputMask = productoTmp.MascaraPolizaMX;
                    txtPolizaES.InputMask = productoTmp.MascaraPolizaES;
                }

                productoSel = Convert.ToInt32(cbProducto.Value);
                // llenado de las coberturas DB
                liIncCoberturasDBTableAdapter.FillByDefaultDBOrigenProducto(this.liabilityInc1.LiIncCoberturasDB, FinancialLines, Origen, productoSel);
                // llenado de las coberturas default
                liIncCoberturasTableAdapter.FillByDefaultOrigenProducto(this.liabilityInc1.LiIncCoberturas, FinancialLines, Origen, productoSel);
                dgCoberturas.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                dgCoberturasDB.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);

                if (chkSublimites.Checked)
                {
                    dtSublimites.Rows.Clear();
                }

                llenarExtensiones();

                switch (cbProducto.SelectedIndex)
                {
                    case 0:
                        tabCtrlDatos.Tabs[0].Visible = true;
                        tabCtrlDatos.Tabs[1].Visible = false;
                        break;

                    case 1:
                        tabCtrlDatos.Tabs[1].Visible = true;
                        tabCtrlDatos.Tabs[0].Visible = false;
                        break;
                }
            }
        }

        private void cbProducingOffice_ValueChanged(object sender, EventArgs e)
        {
            if (cbProducingOffice.Text != "")
            {
                cbToB.Text = "";
                lNTBTableAdapter.FillByConsultaLNTBporIDLNPO(this.liabilityInc1.LNTB, Convert.ToInt32(cbProducingOffice.Value));
                cbToB.DisplayMember = "Trade of Business";
                cbToB.ValueMember = "ID";
            }
        }

        private void cbTipoCoaseguro_ValueChanged(object sender, EventArgs e)
        {
            if (cbTipoCoaseguro.Text != "")
            {
                cbCoaseBrokerageOtro.Items.Clear();
                cbCoaseguradorLider.Text = "";
                if (cbTipoCoaseguro.Text == "Coaseguro Lider")
                {
                    grpCoaseguroLider.Visible = true;
                    grpCoaseguroSeguidor.Visible = false;
                    llenarTablaCoaseguro();
                }
                else
                {
                    grpCoaseguroLider.Visible = false;
                    grpCoaseguroSeguidor.Visible = true;
                }
            }
        }

        private void cbTipoPrima_ValueChanged(object sender, EventArgs e)
        {
            if (cbTipoPrima.Text == "TurnOver")
            {
                lbTurnOver.Visible = true;
                txtTurnOver.Visible = true;
                lbMon5.Visible = true;
            }
            else
            {
                lbTurnOver.Visible = false;
                txtTurnOver.Visible = false;
                lbMon5.Visible = false;
            }
        }

        private void chkCoaseguro_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCoaseguro.Checked)
            {
                grpTipoCoaseguro.Visible = true;
            }
            else
            {
                grpTipoCoaseguro.Visible = false;
                grpCoaseguroLider.Visible = false;
                grpCoaseguroSeguidor.Visible = false;
                cbTipoCoaseguro.Text = "";
            }

            if (chkReaseguro.Checked)
            {
                calcularLabelReaseguro();
                calcularReaseguros();
            }
            //chkReaseguro_CheckedChanged(sender, e);
        }

        private void chkDeducibles_CheckedChanged(object sender, EventArgs e)
        {
            // se genera el datatable con datos
            if (chkDeducibles.Checked)
            {
                lbDeducibleManual.Visible = true;
                txtDeducibleManual.Visible = true;
                dgDeducibles.Visible = true;

                dtDeducibles = new DataTable();
                dtDeducibles.Columns.Add("Deducible", typeof(string));
                dtDeducibles.Columns.Add("Porcentaje", typeof(decimal));
                dtDeducibles.Columns.Add("Minimo", typeof(decimal));
                dtDeducibles.Columns.Add("Maximo", typeof(decimal));
                dtDeducibles.Columns.Add("SIR", typeof(bool));
                dtDeducibles.Columns.Add("Agregado", typeof(decimal));

                dtDeducibles.Rows.Add("Para cualquier Reclamo EE.UU y/o Canadá y/o fuera de EE.UU y/o Canadá", 0, 0, 0, false, 0);
                dtDeducibles.Rows.Add("Para cualquier Reclamo de Valores contra la Sociedad en EE.UU y/o Canadá", 0, 0, 0, false, 0);
                dtDeducibles.Rows.Add("Para cualquier Reclamo de Valores contra la sociedad fuera de EE.UU o Canadá", 0, 0, 0, false, 0);
                dtDeducibles.Rows.Add("Cualqueier Reclamo", 0, 0, 0, false, 0);

                dgDeducibles.DataSource = dtDeducibles;
                dgDeducibles.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);

                dgDeducibles.DisplayLayout.Bands[0].Columns["Deducible"].NullText = "Nuevo Deducible";
                dgDeducibles.DisplayLayout.Bands[0].Columns["Porcentaje"].MinValue = 0;
                dgDeducibles.DisplayLayout.Bands[0].Columns["Porcentaje"].MaxValue = 100;
                dgDeducibles.DisplayLayout.Bands[0].Columns["Porcentaje"].DefaultCellValue = 0;
                dgDeducibles.DisplayLayout.Bands[0].Columns["Porcentaje"].MaskInput = "{LOC} nnn.nn%";
                dgDeducibles.DisplayLayout.Bands[0].Columns["Porcentaje"].PromptChar = '\0';
                dgDeducibles.DisplayLayout.Bands[0].Columns["Porcentaje"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
                dgDeducibles.DisplayLayout.Bands[0].Columns["Minimo"].MinValue = 0;
                dgDeducibles.DisplayLayout.Bands[0].Columns["Minimo"].DefaultCellValue = 0;
                dgDeducibles.DisplayLayout.Bands[0].Columns["Minimo"].MaskInput = "{LOC}$ nnn,nnn,nnn,nnn";
                dgDeducibles.DisplayLayout.Bands[0].Columns["Minimo"].PromptChar = '\0';
                dgDeducibles.DisplayLayout.Bands[0].Columns["Minimo"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
                dgDeducibles.DisplayLayout.Bands[0].Columns["Maximo"].MinValue = 0;
                dgDeducibles.DisplayLayout.Bands[0].Columns["Maximo"].DefaultCellValue = 0;
                dgDeducibles.DisplayLayout.Bands[0].Columns["Maximo"].MaskInput = "{LOC}$ nnn,nnn,nnn,nnn";
                dgDeducibles.DisplayLayout.Bands[0].Columns["Maximo"].PromptChar = '\0';
                dgDeducibles.DisplayLayout.Bands[0].Columns["Maximo"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
                dgDeducibles.DisplayLayout.Bands[0].Columns["Agregado"].MinValue = 0;
                dgDeducibles.DisplayLayout.Bands[0].Columns["Agregado"].DefaultCellValue = 0;
                dgDeducibles.DisplayLayout.Bands[0].Columns["Agregado"].MaskInput = "{LOC}$ nnn,nnn,nnn,nnn";
                dgDeducibles.DisplayLayout.Bands[0].Columns["Agregado"].PromptChar = '\0';
                dgDeducibles.DisplayLayout.Bands[0].Columns["Agregado"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
                dgDeducibles.DisplayLayout.Bands[0].Columns["SIR"].DefaultCellValue = false;
            }
            // se ocultan los controles
            else
            {
                lbDeducibleManual.Visible = false;
                txtDeducibleManual.Visible = false;
                dgDeducibles.Visible = false;
                dtDeducibles.Rows.Clear();
            }
        }

        private void chkIsBrokerage_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsBrokerage.Checked)
            {
                txtBrokeragePorc.Enabled = true;
                calcularBrokerage();
            }
            else
                txtBrokeragePorc.Enabled = false;
        }

        private void chkLTARenegotiable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLTARenegotiable.Checked)
            {
                dateLTAInception.Enabled = true;
                dateLTAExpiry.Enabled = true;
            }
            else
            {
                dateLTAInception.Enabled = false;
                dateLTAExpiry.Enabled = false;
            }
        }

        private void chkReaseguro_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReaseguro.Checked)
            {
                lbPrimaConsiderarRease.Visible = true;
                lbPrimaReaseguro.Visible = true;
                lbMon16.Visible = true;
                grpReaseguro.Visible = true;
                lbInformacionRiesgo.Visible = true;
                txtInformacionRiesgo.Visible = true;
                calcularLabelReaseguro();
                llenarTablaReaseguro();
                validarFechaReaseguro();
            }
            else
            {
                lbPrimaConsiderarRease.Visible = false;
                lbPrimaReaseguro.Visible = false;
                lbMon16.Visible = false;
                grpReaseguro.Visible = false;
                lbInformacionRiesgo.Visible = false;
                txtInformacionRiesgo.Visible = false;
                lbPrimaReaseguro.Text = "0";
                txtPolizaES.Text = "";
            }
        }

        private void chkSublimites_CheckedChanged(object sender, EventArgs e)
        {
            // se agregan los sublimites al form
            if (chkSublimites.Checked)
            {
                btnRecargarSublimites.Visible = true;
                lbRecargarSublimites.Visible = true;
                lbSublimiteManual.Visible = true;
                txtSublimiteManual.Visible = true;
                dgSublimites.Visible = true;

                dtSublimites = new DataTable();
                dtSublimites.Columns.Add("Sublimite", typeof(string));
                dtSublimites.Columns.Add("Monto", typeof(decimal));

                //for (int i = 0; i < dgCoberturas.Rows.Count; i++)
                //{
                //    dtSublimites.Rows.Add(dgCoberturas.Rows[i].Cells["Cobertura"].Text.ToString(), 0);
                //}

                dbSmartGDataContext db = new dbSmartGDataContext();
               

                for (int i = 0; i < dgCoberturas.Rows.Count; i++)
                {
                    int idTemp = Convert.ToInt32(dgCoberturas.Rows[i].Cells["ID"].Text);
                    int?[] idsTemp = (from x in db.CoberturasTextoSubl where x.Cobertura == idTemp select x.TextoSublimites).ToArray();
                    if (idsTemp.Count() > 0)
                    {
                        for (int j = 0; j < idsTemp.Count(); j++)
                        {
                            TextoSublimites txtTmp = (from y in db.TextoSublimites where y.ID == idsTemp[j] select y).SingleOrDefault();
                            dtSublimites.Rows.Add(txtTmp.Texto, 0);
                        }
                    }
                }

                dgSublimites.DataSource = dtSublimites;
                dgSublimites.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                dgSublimites.DisplayLayout.Bands[0].Columns["Monto"].DefaultCellValue = 0;
                dgSublimites.DisplayLayout.Bands[0].Columns["Sublimite"].NullText = "Nuevo Sublímite";
                dgSublimites.DisplayLayout.Bands[0].Columns["Monto"].MinValue = 0;
                dgSublimites.DisplayLayout.Bands[0].Columns["Monto"].MaskInput = "{LOC}$ nnn,nnn,nnn,nnn";
                dgSublimites.DisplayLayout.Bands[0].Columns["Monto"].PromptChar = '\0';
                dgSublimites.DisplayLayout.Bands[0].Columns["Monto"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            }
            // se eliminan los sublimites y se ocultan los controles
            else
            {
                btnRecargarSublimites.Visible = false;
                lbRecargarSublimites.Visible = false;
                lbSublimiteManual.Visible = false;
                txtSublimiteManual.Visible = false;
                dgSublimites.Visible = false;
                dtSublimites.Rows.Clear();
            }
        }

        private void chkTieInLimits_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTieInLimits.Checked)
            {
                lbNumPolizaGlobal.Visible = true;
                txtNumPolizaGlobal.Visible = true;
                lbTitularPolizaGlobal.Visible = true;
                txtTitularPolizaGlobal.Visible = true;
                lbLimiteRespTieInLimits.Visible = true;
                txtLimiteMaximoTieInLimits.Visible = true;
                cbAbreviacionMonedaTieIn.Visible = true;
            }
            else
            {
                lbNumPolizaGlobal.Visible = false;
                txtNumPolizaGlobal.Visible = false;
                txtNumPolizaGlobal.Text = "";
                lbTitularPolizaGlobal.Visible = false;
                txtTitularPolizaGlobal.Visible = false;
                txtTitularPolizaGlobal.Text = "";
                lbLimiteRespTieInLimits.Visible = false;
                txtLimiteMaximoTieInLimits.Visible = false;
                txtLimiteMaximoTieInLimits.Value = 0;
                cbAbreviacionMonedaTieIn.Visible = false;
                cbAbreviacionMonedaTieIn.Text = "";
            }
        }

        private void dateEmision_ValueChanged(object sender, EventArgs e)
        {
            validarFechaReaseguro();
        }

        private void dgAseguAdicionales_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
        }

        private void dgCoaseguro_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell.Column.Header.Caption == "% Participacion")
            {
                decimal tmpPrima = Convert.ToDecimal(txtPrimaMain.Value);
                decimal tmpPorcPart = Convert.ToDecimal(e.Cell.Value) / 100;
                dgCoaseguro.ActiveRow.Cells["Participacion"].Value = tmpPrima * tmpPorcPart;
            }
            if (e.Cell.Column.Header.Caption == "% Comision Broker")
            {
                decimal tmpPrima = Convert.ToDecimal(txtComisionBrokerage.Value);
                decimal tmpPorcPart = Convert.ToDecimal(e.Cell.Value) / 100;
                dgCoaseguro.ActiveRow.Cells["ComisionBroker"].Value = tmpPrima * tmpPorcPart;
            }
            if (e.Cell.Column.Header.Caption == "Coaseguradora")
            {
                if (e.Cell.Value != DBNull.Value)
                {
                    // reseteamos a la coaseguradora por defecto
                    if (Convert.ToInt32(e.Cell.Value) != idDefaultCoaseguradora && e.Cell.Row.Index == 0)
                    {
                        e.Cell.Value = idDefaultCoaseguradora;
                    }

                    //if (e.Cell.Row.Index + 1 == dgCoaseguro.Rows.Count && e.Cell.Value.ToString() != "")
                    //{
                    //    dtCoaseguros.Rows.Add(0, 0, 0, 0);
                    //}

                    // actualizamos el cb de otras coaseguradoras para administrar pagos
                    if (e.Cell.Row.Index != 0)
                    {
                        cbCoaseBrokerageOtro.Items.Clear();
                        for (int i = 1; i < dgCoaseguro.Rows.Count; i++)
                        {
                            if (dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text.ToString() != "")
                                cbCoaseBrokerageOtro.Items.Add(dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text.ToString());
                        }
                        cbCoaseBrokerageOtro.Text = e.Cell.Text;
                    }
                }
                else
                {
                    e.Cell.Value = 0;
                }
            }

            if (chkReaseguro.Checked)
            {
                calcularLabelReaseguro();
                calcularReaseguros();
            }
        }

        private void dgCoaseguro_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            if (dgCoaseguro.ActiveRow.Index == 0)
            {
                MessageBox.Show("No puedes eliminar al coasegurador XL Seguros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else
            {
                e.DisplayPromptMsg = false;
                //if (dgCoaseguro.ActiveRow.Index + 1 == dgCoaseguro.Rows.Count)
                //    dtCoaseguros.Rows.Add(0, 0, 0, 0);
            }
        }

        private void dgDeducibles_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
        }

        private void dgCoberturasDB_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            btnEnviarCobertura_Click(sender, e);
        }

        private void dgCoberturas_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            btnQuitarCobertura_Click(sender, e);
        }

        private void dgReaseguro_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell.Column.Header.Caption == "Reaseguradora")
            {
                if (e.Cell.Value != DBNull.Value)
                {
                    if (Convert.ToInt32(e.Cell.Value) != idDefaultReaseguradora && e.Cell.Row.Index == 0) // reseteamos al Reasegurador XL
                    {
                        e.Cell.Value = idDefaultReaseguradora;
                    }

                    if (e.Cell.Row.Index + 1 == dgReaseguro.Rows.Count && e.Cell.Value.ToString() != "") // llenamos los valores treaty, participacion y comision contra lo que haya seleccionado el usuario 
                    {
                        if (loadReaseguro == 0)
                        {
                            dgReaseguro.Rows[e.Cell.Row.Index].Cells["Treaty"].Value = Convert.ToBoolean(liIncReaseguradorasTableAdapter.ScalarTreaty(Convert.ToInt32(e.Cell.Value)));
                            dgReaseguro.Rows[e.Cell.Row.Index].Cells["PorcentajeParticipacion"].Value = Convert.ToDecimal(liIncReaseguradorasTableAdapter.ScalarFijoInterno(Convert.ToInt32(e.Cell.Value)));
                            dgReaseguro.Rows[e.Cell.Row.Index].Cells["PorcentajeComision"].Value = Convert.ToDecimal(liIncReaseguradorasTableAdapter.ScalarComision(Convert.ToInt32(e.Cell.Value)));
                        }
                    }
                    else if (e.Cell.Row.Index > 1 && e.Cell.Value.ToString() != "") // update para cualqiuer fila que no sea la última
                    {
                        if (loadReaseguro == 0)
                        {
                            dgReaseguro.Rows[e.Cell.Row.Index].Cells["Treaty"].Value = Convert.ToBoolean(liIncReaseguradorasTableAdapter.ScalarTreaty(Convert.ToInt32(e.Cell.Value)));
                            dgReaseguro.Rows[e.Cell.Row.Index].Cells["PorcentajeParticipacion"].Value = Convert.ToDecimal(liIncReaseguradorasTableAdapter.ScalarFijoInterno(Convert.ToInt32(e.Cell.Value)));
                            dgReaseguro.Rows[e.Cell.Row.Index].Cells["PorcentajeComision"].Value = Convert.ToDecimal(liIncReaseguradorasTableAdapter.ScalarComision(Convert.ToInt32(e.Cell.Value)));
                        }
                    }
                }
                else
                {
                    e.Cell.Value = 0;
                }
            }
        }

        private void dgReaseguro_AfterRowsDeleted(object sender, EventArgs e)
        {
            if (dgReaseguro.Rows.Count > 1)
            {
                calcularReaseguros();
            }
        }

        private void dgReaseguro_AfterRowUpdate(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            calcularReaseguros();
        }

        private void dgReaseguro_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            if (dgReaseguro.ActiveRow.Index == 0)
            {
                MessageBox.Show("No puedes eliminar al reasegurador XL Seguros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else
            {
                e.DisplayPromptMsg = false;
                //if (dgReaseguro.ActiveRow.Index + 1 == dgReaseguro.Rows.Count)
                //    dtReaseguro.Rows.Add(false, 0, 0, 0, 0, 0);
            }
        }

        private void dgReaseguro_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(e.Row.Cells["Treaty"].Value))
                {
                    e.Row.Cells["Treaty"].Appearance.BackColor = Color.CadetBlue;
                }
                else
                {
                    e.Row.Cells["Treaty"].Appearance.BackColor = Color.CornflowerBlue;
                }
            }
            catch
            {
            }
        }

        private void dgReaseguro_Leave(object sender, EventArgs e)
        {
            calcularReaseguros();
        }

        private void dgSublimites_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
        }

        public FinancialLinesInc(int idVentana = 0, int idPolizaTemp = 0)
        {
            InitializeComponent();
            llenarControlesObligatorios();
            dbSmartGDataContext db = new dbSmartGDataContext();

            // obtenemos los id's importantes utilizados en todo el formulario
            FinancialLines = (from x in db.LineaNegocios where x.LineaNegocios1 == "Financial Lines" select x.ID).SingleOrDefault();
            Origen = (from x in db.Origen where x.Origen1 == "Incoming" select x.ID).SingleOrDefault();
            ventana = idVentana;
            if (idPolizaTemp != 0)
                idPoliza = idPolizaTemp;

        }

        private void FinancialLinesInc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (controlSave != true)
            {
                if (MessageBox.Show("¿Deseas guardar antes de cerrar la ventana?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    txtRetroValidaciones.Text = "1) Sistema preparandose para guardar";
                    retroalimentacion(guardarAvances());
                }
            }
            else
            {
                txtRetroValidaciones.Text = "1) Sistema preparandose para guardar";
                retroalimentacion(guardarAvances());
                terminarPolizaNueva();
            }
        }

        private void FinancialLinesInc_Load(object sender, EventArgs e)
        {
            //Extensiones.Traduccion.traducirVentana(this, tabControlLiability, ToolsBarFinancialLinesInc);

            llenarMonedas();
            iniciarDatos();
            if (ventana == 1) // carga de ventanas para edicion de guardados
            {
                cargarAvances();
            }
            validarDatos(tabControlLiability.ActiveTab.Index);
            txtRetroValidaciones.Text = "";
            tabAnterior = tabControlLiability.ActiveTab.Index;
            this.FormClosing += FinancialLinesInc_FormClosing;
        }

        private void tabControlLiability_SelectedTabChanging(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangingEventArgs e)
        {
            validarDatos(tabAnterior);
            tabAnterior = tabControlLiability.ActiveTab.Index;
        }

        private void ToolsBarLiabilityInc_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            terminarEdicionGrids();
            dbSmartGDataContext db = new dbSmartGDataContext();
            
            switch (e.Tool.Key)
            {
                case "GuardarAvances":
                    txtRetroValidaciones.Text = "1) Sistema preparandose para guardar";
                    retroalimentacion(guardarAvances());
                    break;

                case "CerrarVentana":
                    if (txtPolizaMX.Text == "")
                        this.Close();
                    else if (MessageBox.Show("¿Deseas guardar tus cambios antes de salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        if (validarPoliza(txtPolizaMX))
                        {
                            txtRetroValidaciones.Text = "1) Sistema preparandose para guardar";
                            retroalimentacion(guardarAvances());
                            this.Close();
                        }
                    }
                    else
                    {
                        this.Close();
                    }
                    break;

                case "ValidarRegistro":
                    txtRetroValidaciones.Text = "Comenzando el proceso de validación completa:";
                    for (int i = 0; i < 9; i++)
                    {
                        validarDatos(i);
                    }
                    txtRetroValidaciones.Text += Environment.NewLine + "Proceso de validación completado.";
                    txtRetroValidaciones.SelectionStart = txtRetroValidaciones.TextLength;
                    txtRetroValidaciones.ScrollToCaret();
                    break;

                case "ConcluirRegistro":
                    bool primerSave = false;
                    if (idPoliza == 0)
                    {
                        if (MessageBox.Show("Para continuar con este proceso debes de guardar la póliza en el sistema, ¿deseas continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            txtRetroValidaciones.Text = "1) Sistema preparandose para guardar";
                            retroalimentacion(guardarAvances());
                            if (idPoliza != 0)
                                primerSave = true;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                        primerSave = true;

                    if (primerSave)
                    {
                        if (MessageBox.Show("Para utilizar esta función es necesario validar los datos de la póliza, ¿deseas continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                        {
                            for (int i = 0; i < 9; i++)
                            {
                                validarDatos(i);
                            }

                            if (validarCorrectos() && validarCliente())
                            {
                                if (MessageBox.Show("Esta función concluirá el registro y generará los documentos finales, se recomienda generar un previo de la póliza para su revisión ya que una vez finalizado el registro no se podrá cambiar, si aun así deseas continuar con la conclusión del proceso has click en Si", "Aviso importante", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                {
                                    controlSave = true;
                                    txtRetroValidaciones.Text = "Comenzando proceso de generación de documentos";
                                    guardarVariables();
                                    guardarVariablesWording();
                                    string tmpWording = (from x in db.Producto where x.ID == Convert.ToInt32(cbProducto.Value) select x.NombreDocumento).SingleOrDefault();

                                    DocumentosDB nuevoPreview = new DocumentosDB();
                                    if (nuevoPreview.ExtraerDocumentoDB("CoverFL.docx"))
                                    {
                                        txtRetroValidaciones.Text += Environment.NewLine + "Generando Cover...";
                                        generarCover("CoverFL.docx", 2);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ocurrió un error inesperado al generar el documento (cover), favor de contactar al soporte técnico para futura referencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    txtRetroValidaciones.SelectionStart = txtRetroValidaciones.TextLength;
                                    txtRetroValidaciones.ScrollToCaret();

                                    if (nuevoPreview.ExtraerDocumentoDB("Schedule.docx"))
                                    {
                                        txtRetroValidaciones.Text += Environment.NewLine + "Generando Schedule...";
                                        generarSchedule("Schedule.docx", 2);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ocurrió un error inesperado al generar el documento (schedule), favor de contactar al soporte técnico para futura referencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    txtRetroValidaciones.SelectionStart = txtRetroValidaciones.TextLength;
                                    txtRetroValidaciones.ScrollToCaret();

                                    if (nuevoPreview.ExtraerDocumentoDB(tmpWording))
                                    {
                                        txtRetroValidaciones.Text += Environment.NewLine + "Generando Wording...";
                                        generarWording(tmpWording, 2);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ocurrió un error inesperado al generar el documento (wording), favor de contactar al soporte técnico para futura referencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    txtRetroValidaciones.SelectionStart = txtRetroValidaciones.TextLength;
                                    txtRetroValidaciones.ScrollToCaret();

                                    if (chkReaseguro.Checked)
                                    {
                                        if (nuevoPreview.ExtraerDocumentoDB("NotaCobertura.docx"))
                                        {
                                            txtRetroValidaciones.Text += Environment.NewLine + "Generando nota de Reaseguro...";
                                            generarNotaReaseguro("NotaCobertura.docx", 2);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Ocurrió un error inesperado al generar el documento (nota Reaseguro), favor de contactar al soporte técnico para futura referencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        txtRetroValidaciones.SelectionStart = txtRetroValidaciones.TextLength;
                                        txtRetroValidaciones.ScrollToCaret();
                                    }

                                    if (nuevoPreview.ExtraerDocumentoDB("InstruccionesGenius.xlsx"))
                                    {
                                        txtRetroValidaciones.Text += Environment.NewLine + "Generando Instrucciones Genius...";
                                        GenerarInstrucciones("InstruccionesGenius.xlsx");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ocurrió un error inesperado al generar el documento (Instrucciones Genius), comprueba que el archivo no lo tengas abierto, en caso de que esté abierto cierralo y vuelve a solicitar al sistema que genere los documentos, en caso contrario favor de contactar al soporte técnico para futura referencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    txtRetroValidaciones.SelectionStart = txtRetroValidaciones.TextLength;
                                    txtRetroValidaciones.ScrollToCaret();

                                    generarPoliza();


                                    string rutaGuardado = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + "\\";
                                    nuevoPreview.CopiarTripticoDerechos(rutaGuardado);
                                    DocumentosDB.GuardarDocumentosDB(rutaGuardado, Convert.ToInt32(idPoliza), FinancialLines, polizaMX, txtPAM.Text, emision);

                                    if (controlSave)
                                    {
                                        if (MessageBox.Show("¿Deseas crear una factura con la información de esta póliza?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                                        {
                                            Extensiones.Cobranza.NuevaSolicitudFacturacion(Convert.ToInt32(idPoliza), this);
                                        }

                                        if (MessageBox.Show("Archivo generado satisfactoriamente, ¿Deseas abrir la carpeta?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                                        {
                                            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX;
                                            Process.Start(folder);
                                        }

                                        this.Close();
                                    }

                                }
                            }
                            else
                            {
                                MessageBox.Show("Todos los campos deben de ser ingresados correctamente, da click en el botón 'Validar Registro' para conocer qué falta. Así mismo el cliente debe de haber sido previamente autorizado por un Administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    break;

                case "ValidarActiveTab":
                    txtRetroValidaciones.Text = "Validando Datos:";
                    validarDatos(tabControlLiability.ActiveTab.Index);
                    break;

                case "btnRecargarCatalogos":
                    recargarCatalogos();
                    txtRetroValidaciones.Text = "Catálogos actualizados satisfactoriamente";
                    break;

                case "GenerarPreview":
                    bool primerSaveP = false;
                    if (idPoliza == 0)
                    {
                        if (MessageBox.Show("Para continuar con este proceso debes de guardar la póliza en el sistema, ¿deseas continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            txtRetroValidaciones.Text = "1) Sistema preparandose para guardar";
                            retroalimentacion(guardarAvances());
                            if (idPoliza != 0)
                                primerSaveP = true;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                        primerSaveP = true;

                    if (primerSaveP)
                    {
                        if (MessageBox.Show("Para utilizar esta función es necesario validar los datos de la póliza, ¿deseas continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                        {
                            for (int i = 0; i < 9; i++)
                            {
                                validarDatos(i);
                            }

                            if (validarCorrectos())
                            {
                                txtRetroValidaciones.Text = "Comenzando proceso de generación de previo";
                                guardarVariables();
                                guardarVariablesWording();
                                string tmpWording = "Preview" + (from x in db.Producto where x.ID == Convert.ToInt32(cbProducto.Value) select x.NombreDocumento).SingleOrDefault();

                                DocumentosDB nuevoPreview = new DocumentosDB();
                                if (nuevoPreview.ExtraerDocumentoDB("PreviewCoverFL.docx"))
                                {
                                    txtRetroValidaciones.Text += Environment.NewLine + "Generando Cover...";
                                    generarCover("PreviewCoverFL.docx", 1);
                                }
                                else
                                {
                                    MessageBox.Show("Ocurrió un error inesperado al generar el documento (cover), favor de contactar al soporte técnico para futura referencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                txtRetroValidaciones.SelectionStart = txtRetroValidaciones.TextLength;
                                txtRetroValidaciones.ScrollToCaret();

                                if (nuevoPreview.ExtraerDocumentoDB("previewSchedule.docx"))
                                {
                                    txtRetroValidaciones.Text += Environment.NewLine + "Generando Schedule...";
                                    generarSchedule("previewSchedule.docx", 1);
                                }
                                else
                                {
                                    MessageBox.Show("Ocurrió un error inesperado al generar el documento (schedule), favor de contactar al soporte técnico para futura referencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                txtRetroValidaciones.SelectionStart = txtRetroValidaciones.TextLength;
                                txtRetroValidaciones.ScrollToCaret();

                                if (nuevoPreview.ExtraerDocumentoDB(tmpWording))
                                {
                                    txtRetroValidaciones.Text += Environment.NewLine + "Generando Wording...";
                                    generarWording(tmpWording, 1);
                                }
                                else
                                {
                                    MessageBox.Show("Ocurrió un error inesperado al generar el documento (wording), favor de contactar al soporte técnico para futura referencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                txtRetroValidaciones.SelectionStart = txtRetroValidaciones.TextLength;
                                txtRetroValidaciones.ScrollToCaret();

                                if (chkReaseguro.Checked)
                                {
                                    if (nuevoPreview.ExtraerDocumentoDB("PreviewNotaCobertura.docx"))
                                    {
                                        txtRetroValidaciones.Text += Environment.NewLine + "Generando nota de Reaseguro...";
                                        generarNotaReaseguro("PreviewNotaCobertura.docx", 1);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ocurrió un error inesperado al generar el documento (nota Reaseguro), favor de contactar al soporte técnico para futura referencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    txtRetroValidaciones.SelectionStart = txtRetroValidaciones.TextLength;
                                    txtRetroValidaciones.ScrollToCaret();
                                }

                                if (MessageBox.Show("Archivo generado satisfactoriamente, ¿Deseas abrir la carpeta?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                                {
                                    string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX;
                                    Process.Start(folder);
                                }
                            }
                        }
                    }
                    break;
            }

        }

        private void txtAseguAdicional_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtAseguAdicional.Text != "")
            {
                dtAseguradosAdicionales.Rows.Add(txtAseguAdicional.Text);
                txtAseguAdicional.Text = "";
                dgAseguAdicionales.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
        }

        private void txtBrokeragePorc_Leave(object sender, EventArgs e)
        {
            calcularBrokerage();
            if (Convert.ToDecimal(txtBrokeragePorc.Value) > 15)
            {
                MessageBox.Show("El sistema ha calculado el brokerage con un valor mayor al 15%, revisa este dato y si es correcto no hagas caso a este mensaje", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtCoasePorcBrokerage_Leave(object sender, EventArgs e)
        {
            double tmpPorc = Convert.ToDouble(txtCoasePorcBrokerage.Value) / 100;
            double tmpComi = Convert.ToDouble(txtComisionTotalBrok.Value);

            txtCoaseComiBrokerage.Value = tmpPorc * tmpComi;
        }

        private void txtDeducibleManual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && txtDeducibleManual.Text != "")
            {
                dtDeducibles.Rows.Add(txtDeducibleManual.Text, 0, 0, 0, false, 0);
                txtDeducibleManual.Text = "";
                dgDeducibles.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
        }

        private void txtNuevaCobertura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtNuevaCobertura.Text != "")
            {
                liabilityInc1.LiIncCoberturas.Rows.Add(coberturaM, FinancialLines, txtNuevaCobertura.Text, "N/A", "OTH", false, true, false, 1);
                coberturaM--;
                txtNuevaCobertura.Text = "";
                dgCoberturas.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
        }

        private void txtPorParticipacionXL_Leave(object sender, EventArgs e)
        {
            double tmpPorc = Convert.ToDouble(txtPorParticipacionXL.Value) / 100;
            double tmpPrima = Convert.ToDouble(txtPrimaMain.Value);

            txtParticipacionXL.Value = tmpPorc * tmpPrima;
        }

        private void txtPolizaES_Leave(object sender, EventArgs e)
        {
            if (txtPolizaES.Text != "")
                txtPolizaES.Text = txtPolizaES.Text.ToUpper();
        }

        private void txtPolizaES_MaskValidationError(object sender, Infragistics.Win.UltraWinMaskedEdit.MaskValidationErrorEventArgs e)
        {
            if (!chkReaseguro.Checked)
            {
                e.RetainFocus = false;
            }
        }

        private void txtPolizaMX_Leave(object sender, EventArgs e)
        {
            if (txtPolizaMX.Text != "")
                txtPolizaMX.Text = txtPolizaMX.Text.ToUpper();
        }

        private void txtPolizaMX_MaskValidationError(object sender, Infragistics.Win.UltraWinMaskedEdit.MaskValidationErrorEventArgs e)
        {
            MessageBox.Show("El formato correcto para la póliza MX es el siguiente: MX + 8 dígitos de seguimiento + DO + 2 dítigos del año de emisión + 1 caracter, verifica los datos ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }      

        private void txtPrimaMain_Leave(object sender, EventArgs e)
        {
            calcularPrimaTotal();
            calcularBrokerage();
            calcularLabelCoaseguro();
            calcularCoaseguros();
            calcularLabelReaseguro();
            calcularReaseguros();
        }

        private void txtSublimiteManual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && txtSublimiteManual.Text != "")
            {
                dtSublimites.Rows.Add(txtSublimiteManual.Text, 0);
                txtSublimiteManual.Text = "";
                dgSublimites.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
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

        private void ValidarCeldas(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell.Column.DataType == typeof(decimal) && e.Cell.Value.ToString() == "")
            {
                e.Cell.Value = 0;
            }
            if (e.Cell.Column.DataType == typeof(string) && e.Cell.Value.ToString() == "")
            {
                if (e.Cell.Column.Header.Caption != "Descripcion")
                    e.Cell.Value = "No especificado";
            }
        }

        private void validarCBGrid(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
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

        private void validarGrid(object sender, Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs e)
        {
            MessageBox.Show("Debes introducir un valor válido para el campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.RaiseErrorEvent = false;
            e.RestoreOriginalValue = true;
        }

        private void cbJurisdiccion_ValueChanged(object sender, EventArgs e)
        {
            if (cbJurisdiccion.Text == "Otro")
            {
                lbOtro.Visible = true;
                txtJurisOtro.Visible = true;
            }
            else
            {
                lbOtro.Visible = false;
                txtJurisOtro.Visible = false;
                txtJurisOtro.Text = "";
            }
        }

        private void cbTerritorio_ValueChanged(object sender, EventArgs e)
        {
            if (cbTerritorio.Text == "Otro")
            {
                lbOtroTerritorio.Visible = true;
                txtOtroTerritorio.Visible = true;
            }
            else
            {
                lbOtroTerritorio.Visible = false;
                txtOtroTerritorio.Visible = false;
                txtOtroTerritorio.Text = "";
            }
        }

        private void dgAseguAdicionales_AfterRowUpdate(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            dgAseguAdicionales.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
        }

        private void dgAseguAdicionales_AfterRowsDeleted(object sender, EventArgs e)
        {
            dgAseguAdicionales.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
        }

        private void dgSublimites_AfterRowUpdate(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            dgSublimites.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
        }

        private void dgSublimites_AfterRowsDeleted(object sender, EventArgs e)
        {
            dgSublimites.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
        }

        private void dgDeducibles_AfterRowUpdate(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            dgDeducibles.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
        }

        private void dgDeducibles_AfterRowsDeleted(object sender, EventArgs e)
        {
            dgDeducibles.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            ////tabCtrlDatos
            foreach (Control control in tabCtrlDatos.SelectedTab.TabPage.Controls)
            {
                guardarControl(control);
            }
        }

       

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************



    }
}
