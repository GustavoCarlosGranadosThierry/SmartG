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
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Globalization;
using System.Threading;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace SmartG.Operaciones.Emision
{
    public partial class MarineInc : Form
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
        //lbMon1          Mon1
        //lbAggregationPL     Aggregation PL
        //cbAggregationPL
        //lbAggregationPR     AggregationPR
        //cbAggregationPR
        //grpEstructuraLimite Estructura del Limite
        //lbEstructuraLimite Estructura Limite
        //lbGastosDefensa     Gastos de Defensa
        //cbEstructuraLimite
        //cbGastosDefensa
        //lbSujecion      Sujecion
        //lbPorcentajeLimite	% del Límite
        //txtSujecion
        //lbMon2          Mon2
        //txtGastosDefensa
        //lbMon3 Mon3
        //grpSublimites		2) Sublimites de Responsabilidad
        //grpControlSublimites    Control de Sublimites
        //chkSublimites       Aplican Sublimites
        //btnRecargarSublimites
        //lbRecargarSublimites	1) Click para recargar los sublimites por las coberturas de la Póliza
        //lbSublimiteManual	2) Agrege un sublimite manualmente
        //txtSublimiteManual
        //dgSublimites
        #endregion
        #region quinta tab deducibles y exclusiones
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
        int? idPolizaMa = 0;
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
        DateTime? fechaContinuidad;
        string DAM;
        int? PAM;
        int? country;
        int? Broker;
        int? aseguradoPrincipal;
        int? direccionAseguradoPrincipal;
        DataTable dtAseguradosAdicionales;
        string delimitacionTerritorial;
        string bienesAsegurados;
        string valoresSeguros;
        #endregion
        #region segunda tab coberturas
        DataTable dtCoberturas;
        DataTable dtCoberturasDB;
        #endregion
        #region tercera tab endosos
        DataTable dtEndosos;
        #endregion
        #region cuarta tab limites y sublimites
        decimal limiteMaximo;
        string estructuraLimite;
        string gastosDefensa;
        decimal sujecion;
        decimal defensaGastosCantidad;
        DataTable dtSublimites;
        #endregion
        #region quinta tab deducibles y exclusiones
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
        int? typeGoods;
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
        #region octava tab Coaseguros
        int? idCoaseguradorLider;
        decimal cantidadCoaseguro = 0;
        DataTable dtCoaseguros;
        #endregion
        #region novena tab Reaseguros
        DataTable dtReaseguro;
        int loadReaseguro = 0;
        int idIntermediarioDefault = 0;
        decimal cantidadReaseguro = 0;
        #endregion
        #region Variables Generales
        Control[] controlesObligatorios;
        Control[] labelsMonedas;
        int Marine;
        int Origen;
        int coberturaM = -1;
        int exclusionesM = -1;
        int? idDefaultCoaseguradora = 0;
        int? idDefaultReaseguradora = 0;
        bool controlSave = false;
        bool pasoValidaciones = false;
        string rutaDocumentoImportar = "";
        int ventana = 0;
        int tabAnterior;
        #endregion
        #region Variables Wording
        string strIniVig;
        string strFinVig;
        string strIniVig2;
        string strFinVig2;
        string diaAnterior;
        string strEmision;
        string strEmision2;
        string strContinuidad;
        string strMoneda;
        string strAbreMon;
        string strFormaPago;
        string strBroker;
        string strDireccionAsegu;
        string strRFC;
        string strGiroE;
        string strAseguAdicional;
        string strDelimitacionTemporal;
        string strDelimitacionTemporalTXT;
        string strdelimitacionTerritorial;
        string strLimite;
        string strGastosDefensa;
        string strCoberturas;
        string strCoberturas2;
        string strSublimites;
        string strDeducibles;
        string strExclusiones;
        double strPartReasegurada = 0;
        double strPartTotal = 0;
        double strInternationalCalc = 0;
        double strComisionInter = 0;
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
            lbPrimaCoaseguro.Text = txtPrimaMain.Value.ToString();

            decimal tmpPrima = Convert.ToDecimal(txtPrimaMain.Value);
            decimal tmpPorcPart = 0;

            for (int i = 0; i < dgCoaseguro.Rows.Count; i++)
            {
                if(dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text.ToString() != "")
                {
                    tmpPorcPart = Convert.ToDecimal(dgCoaseguro.Rows[i].Cells["PorcentajeParticipacion"].Value) / 100;
                    dgCoaseguro.Rows[i].Cells["Participacion"].Value = tmpPrima * tmpPorcPart;
                    tmpPorcPart = Convert.ToDecimal(dgCoaseguro.Rows[i].Cells["PorcentajeComisionBroker"].Value) / 100;
                    dgCoaseguro.Rows[i].Cells["ComisionBroker"].Value = tmpPrima * tmpPorcPart;
                }
            }
        }

        void calcularLabelCoaseguro()
        {
            lbPrimaCoaseguro.Text = txtPrimaMain.Value.ToString();
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
                        lbPrimaReaseguro.Text = (Convert.ToDecimal(txtPrimaMain.Value) * tmpPorc).ToString();
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
                if (dgReaseguro.Rows[i].Cells["Reaseguradora"].Text.ToString() != "")
                {
                    if (Convert.ToBoolean(dgReaseguro.Rows[i].Cells["Treaty"].Value))
                    {
                        tmpTotalTreaty += Convert.ToDecimal(dgReaseguro.Rows[i].Cells["PorcentajeParticipacion"].Text.ToString());
                    }
                    else
                    {
                        tmpTotalNoTreaty += Convert.ToDecimal(dgReaseguro.Rows[i].Cells["PorcentajeParticipacion"].Text.ToString());
                    }
                }
            }

            tmpTabulador = (tmpTotalTreaty - tmpTotalNoTreaty) / 100;

            for (int i = 0; i < dgReaseguro.Rows.Count; i++)
            {
                if (dgReaseguro.Rows[i].Cells["Reaseguradora"].Text.ToString() != "")
                {
                    if (Convert.ToBoolean(dgReaseguro.Rows[i].Cells["Treaty"].Value))
                    {
                        dgReaseguro.Rows[i].Cells["PorcentajePoliza"].Value = Convert.ToDecimal(dgReaseguro.Rows[i].Cells["PorcentajeParticipacion"].Text.ToString()) * tmpTabulador;
                        dgReaseguro.Rows[i].Cells["Participacion"].Value = Convert.ToDecimal(lbPrimaReaseguro.Text) * (Convert.ToDecimal(dgReaseguro.Rows[i].Cells["PorcentajePoliza"].Text.ToString()) / 100);
                    }
                    else
                    {
                        dgReaseguro.Rows[i].Cells["PorcentajePoliza"].Value = Convert.ToDecimal(dgReaseguro.Rows[i].Cells["PorcentajeParticipacion"].Text.ToString());
                        dgReaseguro.Rows[i].Cells["Participacion"].Value = Convert.ToDecimal(lbPrimaReaseguro.Text) * (Convert.ToDecimal(dgReaseguro.Rows[i].Cells["PorcentajePoliza"].Text.ToString()) / 100);
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
            cargarExclusiones();
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
            }
        }

        void cargarCoaseguros()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            PolizaCoaseguro[] coaseguros = (from x in db.PolizaCoaseguro where x.Poliza == idPoliza select x).ToArray();
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
            txtRetroValidaciones.Text += Environment.NewLine + "7) Coaseguros Cargados satisfactoriamente";
        }

        void cargarCoberturas()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();

            int?[] idCoberturas = (from x in db.PolizaCobertura where x.Poliza == idPoliza select x.Cobertura).ToArray();
            if (idCoberturas.Count() > 0)
            {
                coberturasDBTableAdapter.FillByTodosDB(this.coberturasOrdenadas.CoberturasDB, Marine, Origen);
                coberturasOrdenadas.Coberturas.Rows.Clear();
                bool encontro = false;
                for (int i = 0; i < idCoberturas.Count(); i++)
                {
                    encontro = false;
                    for (int j = 0; j < dgCoberturasDB.Rows.Count; j++)
                    {
                        if (idCoberturas[i] == Convert.ToInt32(dgCoberturasDB.Rows[j].Cells["ID"].Text.ToString()))
                        {
                            coberturasOrdenadas.Coberturas.Rows.Add(Convert.ToInt32(dgCoberturasDB.Rows[j].Cells["ID"].Text.ToString()),
                           Marine, dgCoberturasDB.Rows[j].Cells["Cobertura"].Text.ToString(), dgCoberturasDB.Rows[j].Cells["CoberturaIngles"].Text.ToString(),
                           dgCoberturasDB.Rows[j].Cells["GeniusCode"].Text.ToString(), Convert.ToBoolean(dgCoberturasDB.Rows[j].Cells["Defecto"].Text),
                           Convert.ToBoolean(dgCoberturasDB.Rows[j].Cells["userAdd"].Text), Convert.ToBoolean(dgCoberturasDB.Rows[j].Cells["Eliminado"].Text),
                           Origen, Convert.ToInt32(dgCoberturasDB.Rows[j].Cells["OrdenImpresion"].Text.ToString()));
                            coberturasOrdenadas.CoberturasDB.Rows.RemoveAt(dgCoberturasDB.Rows[j].Index);
                            encontro = true;
                        }
                    }

                    if (!encontro)
                    {
                        Coberturas cobTMP = (from x in db.Coberturas where x.ID == idCoberturas[i] select x).SingleOrDefault();
                        coberturasOrdenadas.Coberturas.Rows.Add(cobTMP.ID, Marine, cobTMP.Cobertura, cobTMP.CoberturaIngles, cobTMP.GeniusCode, cobTMP.Defecto, cobTMP.userAdd, cobTMP.Eliminado, cobTMP.Origen, cobTMP.OrdenImpresion);
                    }
                }
            }
            dgCoberturas.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            dgCoberturasDB.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            txtRetroValidaciones.Text += Environment.NewLine + "2) Coberturas cargadas satisfactoriamente";
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

        void cargarExclusiones()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();

            int?[] idExclusiones = (from x in db.PolizaExclusion where x.Poliza == idPoliza select x.Exclusion).ToArray();
            if (idExclusiones.Count() > 0)
            {
                chkExclusiones.Checked = true;
                dtExclusiones.Rows.Clear();
                for (int i = 0; i < idExclusiones.Count(); i++)
                {
                    Exclusiones tmpExclu = (from x in db.Exclusiones where x.ID == idExclusiones[i] select x).SingleOrDefault();
                    dtExclusiones.Rows.Add(tmpExclu.ID, tmpExclu.LineaNegocios, tmpExclu.Exclusion, tmpExclu.userAdd, tmpExclu.Eliminado);
                }
            }
            dgExclusiones.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            txtRetroValidaciones.Text += Environment.NewLine + "5) Exclusiones Cargadas satisfactoriamente";
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
            txtPolizaMX.Text = tmpPoliza.Poliza1;
            txtPolizaES.Text = tmpPoliza.PolizaES;
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

            PolizaMarine tmpPolizaMa = (from y in db.PolizaMarine where y.Poliza == idPoliza select y).SingleOrDefault();
            if (tmpPolizaMa != null)
            {
                idPolizaMa = tmpPolizaMa.ID;
                if (tmpPolizaMa.FechaContinuidad != null)
                {
                    dateFechaContinuidad.Value = tmpPolizaMa.FechaContinuidad;
                }
                cbPrograma.Value = tmpPolizaMa.Programa;
                try
                { txtBienesAsegurados.Rtf = tmpPolizaMa.BienesAsegurados; }
                catch
                { txtBienesAsegurados.Text = tmpPolizaMa.BienesAsegurados; }
                try
                { txtValoresSeguro.Rtf = tmpPolizaMa.ValoresSeguro; }
                catch
                { txtValoresSeguro.Text = tmpPolizaMa.ValoresSeguro; }
                cbTypeGoods.Value = tmpPolizaMa.TypeGoods;
                if (tmpPolizaMa.Ajustable != null)
                {
                    if (Convert.ToBoolean(tmpPolizaMa.Ajustable))
                        chkAjustable.Checked = true;
                }
            }
            txtRetroValidaciones.Text += "1) Datos Generales cargados satisfactoriamente";
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
            PolizaReaseguro[] reaseguros = (from x in db.PolizaReaseguro where x.Poliza == idPoliza select x).ToArray();

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
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strAbreMon + "  " + limiteMaximo.ToString("#,##0", new CultureInfo("en-US")) + Environment.NewLine); fila++;
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

            Word.Document docI = null;
            ac = new Word.Application();
            //ac.Visible = true;
            //wd.Options.PasteFormatBetweenDocuments = WdPasteOptions.wdMatchDestinationFormatting;
            ac.Options.PasteFormatBetweenDocuments = Word.Enums.WdPasteOptions.wdMatchDestinationFormatting;
            Word.Document doc = ac.Documents.Open(outputFile, m, readOnly,
                  m, m, m, m, m, m, m, m, m, m, m, m, m);

            if (rutaDocumentoImportar != "")
            {
                docI = ac.Documents.Open(rutaDocumentoImportar, m, readOnly,
                      m, m, m, m, m, m, m, m, m, m, m, m, m);
            }

            try
            {
                object bookmarkName = "DatosGenerales";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["DatosGenerales"].Start;
                    object finB = doc.Bookmarks["DatosGenerales"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    int fila = 1;
                    Word.Table tabla = doc.Tables.Add(rng, 2, 2);
                    tabla.Columns[1].PreferredWidth = 150;
                    tabla.Columns[2].PreferredWidth = 285;
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Número de póliza:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(polizaMX + Environment.NewLine); fila++;
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Moneda:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strMoneda + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Vigencia:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strIniVig + Environment.NewLine + strFinVig + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Asegurado:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(cbAseguradoMain.Text + Environment.NewLine + strDireccionAsegu + Environment.NewLine + Environment.NewLine + "RFC: "
                        + strRFC + Environment.NewLine + Environment.NewLine + "Giro empresarial: " + strGiroE + Environment.NewLine); fila++;
                    if (dgAseguAdicionales.Rows.Count > 0)
                    {
                        tabla.Rows.Add();
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Asegurados adicionales:");
                        tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strAseguAdicional + Environment.NewLine); fila++;
                    }
                    if (txtBienesAsegurados.Text != "")
                    {
                        bool tipoTexto = false;
                        tabla.Rows.Add();
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Bienes asegurados:");
                        try
                        { Clipboard.SetText(txtBienesAsegurados.Rtf, TextDataFormat.Rtf); tipoTexto = true; }
                        catch
                        { Clipboard.SetText(txtBienesAsegurados.Text, TextDataFormat.Text); tipoTexto = false; }
                        if (tipoTexto)
                        { tabla.Cell(fila, 2).Select(); ac.Selection.PasteSpecial(Word.Enums.WdPasteOptions.wdKeepSourceFormatting); fila++; }
                        else
                        { tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(Clipboard.GetText(TextDataFormat.Text) + Environment.NewLine); fila++; }
                    }
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Coberturas/clausulas contratadas:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strCoberturas + Environment.NewLine + strCoberturas2); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Límite máximo de responsabilidad:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strLimite + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Sublímites de responsabilidad:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText("No obstante, al Límite máximo de responsabilidad anteriormente indicado, se conviene que para los siguientes conceptos o coberturas aplicarán los siguientes sublímites:"
                        + Environment.NewLine + Environment.NewLine + strSublimites + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Límite territorial:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText("La póliza amparará el transporte de los bienes asegurados que se efectúe:" + Environment.NewLine + Environment.NewLine + "Desde: \t\t México"
                        + Environment.NewLine + "Hasta: \t\t" + strdelimitacionTerritorial + Environment.NewLine + Environment.NewLine + "Incluyendo Todos los Transbordos" + Environment.NewLine + "Incluyendo Carga / Descarga"
                        + Environment.NewLine + "Incluyendo Embarques Inter compañías o entre filiales" + Environment.NewLine + Environment.NewLine + "Se excluyen embarques desde y/o hasta y/o en estadía en países mencionados en el apartado de otras exclusiones de las condiciones generales."
                        + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Empaque y Embalaje:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText("El adecuado para el tipo de bien transportado." + Environment.NewLine + Environment.NewLine
                        + "El empaque y embalaje deberá ser elaborado con materiales inocuos y resistentes al producto que contienen, de tal manera que no reaccionen con el producto o alteren sus características físicas y/o químicas." + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Medios de conducción:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText("Para la conducción de los bienes asegurados se utilizarán indistintamente, aislados y/o combinados entre sí, los servicios de los vehículos a continuación indicados (marcados con “X”) de líneas establecidas o de empresas concesionarias y permisionarias de público para el transporte de carga:"
                        + Environment.NewLine + Environment.NewLine + "( X )Barco	( X )Camión" + Environment.NewLine + "( X )Ferrocarril	( X )Avión" + Environment.NewLine + Environment.NewLine
                        + "Queda entendido y convenido que se consideran amparados los bienes objeto de este seguro mientras estén siendo transportados en vehículos propiedad del Asegurado."); fila++;
                    if (chkDeducibles.Checked)
                    {
                        tabla.Rows.Add();
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Deducibles:");
                        tabla.Cell(fila, 2).Select(); ac.Selection.TypeText("Para toda y cada reclamación:" + Environment.NewLine + Environment.NewLine + strDeducibles + Environment.NewLine); fila++;
                    }
                    if (txtValoresSeguro.Text != "")
                    {
                        bool tipoTexto = false;
                        tabla.Rows.Add();
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Valor para el seguro:");
                        try
                        { Clipboard.SetText(txtValoresSeguro.Rtf, TextDataFormat.Rtf); tipoTexto = true; }
                        catch
                        { Clipboard.SetText(txtValoresSeguro.Text, TextDataFormat.Text); tipoTexto = false; }
                        if (tipoTexto)
                        { tabla.Cell(fila, 2).Select(); ac.Selection.PasteSpecial(Word.Enums.WdPasteOptions.wdKeepSourceFormatting); fila++; }
                        else
                        { tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(Clipboard.GetText(TextDataFormat.Text) + Environment.NewLine); fila++; }
                    }
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Cálculo de la prima:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 0; ac.Selection.ParagraphFormat.TabStops.Add(ac.CentimetersToPoints(10.5f), Word.Enums.WdAlignmentTabAlignment.wdRight, Word.Enums.WdTabLeader.wdTabLeaderDots);
                    ac.Selection.TypeText("Prima Neta\t" + primaNeta.ToString("#,##0.00", new CultureInfo("en-US")) + " " + strAbreMon + Environment.NewLine
                        + "Descuentos\t" + descuentos.ToString("#,##0.00", new CultureInfo("en-US")) + " " + strAbreMon + Environment.NewLine
                        + "Recargos\t" + recargoFraccionado.ToString("#,##0.00", new CultureInfo("en-US")) + " " + strAbreMon + Environment.NewLine
                        + "IVA (" + cbIVA.Text + ")\t" + Convert.ToDouble(txtImpuestos.Value).ToString("#,##0.00", new CultureInfo("en-US")) + " " + strAbreMon + Environment.NewLine
                        + "____________________________________________" + Environment.NewLine
                        + "Prima total\t" + Convert.ToDouble(txtPrimaTotal.Value).ToString("#,##0.00", new CultureInfo("en-US")) + " " + strAbreMon + Environment.NewLine + Environment.NewLine +
                        "Embarques desde y/o hasta  y/o dentro de las áreas geográficas clasificadas como “Altas o Severas” en la lista de observación global de cargas (Global Cargo Watch List o GCWL por sus siglas en inglés) pueden ser cubiertos conforme a lo estipulado en la cláusula de primas."
                        + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Forma de pago:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strFormaPago + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Asegurador:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText("XL Seguros México, S.A. de C.V. " + Environment.NewLine + "Antonio Dovalí Jaime No. 70" + Environment.NewLine + "Torre C, Piso 8" + Environment.NewLine
                        + "Col. Zedec Santa Fe, C.P. 01210" + Environment.NewLine + "Ciudad de México." + Environment.NewLine + Environment.NewLine + "R.F.C.: XIM - 040220 – 119" + Environment.NewLine); fila++;
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Agente de seguros:");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strBroker); fila++;
                }

                bool borrarTodo = false;

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
                            int fila = 1;
                            Word.Table tabla = doc.Tables.Add(rng, 1, 1);
                            tabla.Rows.LeftIndent = ac.CentimetersToPoints(2.0f);
                            tabla.PreferredWidth = ac.CentimetersToPoints(13.5f);
                            for (int i = 0; i < dgEndosos.Rows.Count; i++)
                            {
                                if (Convert.ToBoolean(dgEndosos.Rows[i].Cells["Aplica"].Value))
                                {
                                    bool tipoTexto = false;
                                    entro = true;
                                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.ParagraphFormat.Style = Word.Enums.WdBuiltinStyle.wdStyleHeading4;
                                    ac.Selection.TypeText(dgEndosos.Rows[i].Cells["Endoso"].Text);
                                    tabla.Cell(fila, 1).Select(); ac.Selection.ParagraphFormat.LeftIndent = ac.CentimetersToPoints(0.5f);
                                    try
                                    { Clipboard.SetText(dgEndosos.Rows[i].Cells["Texto"].Text, TextDataFormat.Rtf); tipoTexto = true; }
                                    catch
                                    { Clipboard.SetText(dgEndosos.Rows[i].Cells["Texto"].Text, TextDataFormat.Text); tipoTexto = false; }
                                    tabla.Rows.Add();
                                    fila++;
                                    if (tipoTexto)
                                    { tabla.Cell(fila, 1).Select(); ac.Selection.PasteSpecial(Word.Enums.WdPasteOptions.wdKeepTextOnly); fila++; }
                                    else
                                    { tabla.Cell(fila, 1).Select(); ac.Selection.TypeText(Clipboard.GetText(TextDataFormat.Text)); fila++; }

                                    if (i + 1 < dgEndosos.Rows.Count)
                                        tabla.Rows.Add();
                                }
                            }
                            tabla.Select();
                            ac.Selection.ParagraphFormat.SpaceBefore = 0;
                            ac.Selection.ParagraphFormat.SpaceAfter = 0;
                        }
                        else
                        {
                            borrarTodo = true;
                            object inicioB = doc.Bookmarks["EndososEmision"].Start;
                            object finB = doc.Bookmarks["EndososEmision"].End;
                            Word.Range rng = doc.Range(inicioB, finB);
                            rng.Select();
                            ac.Selection.Cut();
                        }
                    }
                    else
                    {
                        borrarTodo = true;
                        object inicioB = doc.Bookmarks["EndososEmision"].Start;
                        object finB = doc.Bookmarks["EndososEmision"].End;
                        Word.Range rng = doc.Range(inicioB, finB);
                        rng.Select();
                        ac.Selection.Cut();
                    }
                }

                bookmarkName = "EndososManuales";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    if (rutaDocumentoImportar != "")
                    {
                        object iniciof = docI.Content.Start;
                        object finf = docI.Content.End;
                        Word.Range rngf = docI.Range(iniciof, finf);
                        rngf.Select();
                        rngf.Copy();

                        object inicioB = doc.Bookmarks["EndososManuales"].Start;
                        object finB = doc.Bookmarks["EndososManuales"].End;
                        Word.Range rng = doc.Range(inicioB, finB);
                        rng.Select();
                        ac.Selection.PasteAndFormat(Word.Enums.WdRecoveryType.wdFormatPlainText);
                    }
                    else
                    {
                        if (borrarTodo)
                        {
                            object inicioB = doc.Bookmarks["CondicionesParticulares"].Start;
                            object finB = doc.Bookmarks["CondicionesParticulares"].End;
                            Word.Range rng = doc.Range(inicioB, finB);
                            rng.Select();
                            ac.Selection.Cut();
                        }
                        else
                        {
                            object inicioB = doc.Bookmarks["EndososManuales"].Start;
                            object finB = doc.Bookmarks["EndososManuales"].End;
                            Word.Range rng = doc.Range(inicioB, finB);
                            rng.Select();
                            ac.Selection.Cut();
                        }
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
                                {//[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;
                                    tabla.Cell(fila, columna).Select(); ac.Selection.ParagraphFormat.Alignment = Word.Enums.WdParagraphAlignment.wdAlignParagraphCenter; ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Compañía líder:\t Participación: " + dgCoaseguro.Rows[i].Cells["PorcentajeParticipacion"].Text); fila++;
                                    tabla.Cell(fila, columna).Select(); ac.Selection.InlineShapes.AddPicture("C:\\SmartG\\firmaCEO.png"); fila++;
                                    tabla.Cell(fila, columna).Select(); ac.Selection.ParagraphFormat.Alignment = Word.Enums.WdParagraphAlignment.wdAlignParagraphCenter; ac.Selection.Font.Bold = 1; ac.Selection.TypeText(dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text);
                                    columna = 3;
                                    fila = fila - 2;
                                    File.Delete("C:\\SmartG\\firmaCEO.png");
                                }
                                else
                                {
                                    if (columna == 1)
                                    {
                                        tabla.Cell(fila, columna).Select(); ac.Selection.ParagraphFormat.Alignment = Word.Enums.WdParagraphAlignment.wdAlignParagraphCenter; ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Compañía seguidora:\t Participación: " + dgCoaseguro.Rows[i].Cells["PorcentajeParticipacion"].Text); fila++;
                                        tabla.Rows[fila].Height = 115; fila++;
                                        tabla.Cell(fila, columna).Select(); ac.Selection.ParagraphFormat.Alignment = Word.Enums.WdParagraphAlignment.wdAlignParagraphCenter; ac.Selection.Font.Bold = 1; ac.Selection.TypeText(dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text);
                                        columna = 3;
                                        fila = fila - 2;
                                    }
                                    else
                                    {
                                        tabla.Cell(fila, columna).Select(); ac.Selection.ParagraphFormat.Alignment = Word.Enums.WdParagraphAlignment.wdAlignParagraphCenter; ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Compañía seguidora:\t Participación: " + dgCoaseguro.Rows[i].Cells["PorcentajeParticipacion"].Text); fila = fila + 2;
                                        tabla.Cell(fila, columna).Select(); ac.Selection.ParagraphFormat.Alignment = Word.Enums.WdParagraphAlignment.wdAlignParagraphCenter; ac.Selection.Font.Bold = 1; ac.Selection.TypeText(dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text + Environment.NewLine);
                                        brinco = true;
                                    }
                                }

                                if (i + 1 != dgCoaseguro.Rows.Count() - 1)
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

                if (rutaDocumentoImportar != "")
                    ((Word._Document)docI).Close();
                ((Word._Document)doc).Close();
                ((Word._Application)ac).Quit();
                File.Delete("C:\\SmartG\\" + file); // borramos el documento temporal
                txtRetroValidaciones.Text += Environment.NewLine + "Wording generado satisfactoriamente";
            }
            catch
            {
                ((Word._Document)doc).Close();
                if (rutaDocumentoImportar != "")
                    ((Word._Document)docI).Close();
                ((Word._Application)ac).Quit();
                File.Delete("C:\\SmartG\\" + file); // borramos el documento temporal
                MessageBox.Show("Ocurrió un error al generar el wording, favor de contactar al soporte técnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                controlSave = false;
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
            // 4 = error en poliza Marine
            // 5 = error en coberturas
            // 6 = error en endosos emision
            // 7 = error en sublimites
            // 8 = error en deducibles
            // 9 = error en exclusiones
            // 10 = error en info schedule
            // 11 = error en clientes
            // 12 = error en coaseguro
            // 13 = error en reaseguro

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
                            if (guardarPolizaMarine())
                            {
                                if (guardarPolizaCobertura())
                                {
                                    if (guardarPolizaEndosos())
                                    {
                                        if (guardarPolizaSublimite())
                                        {
                                            if (guardarPolizaDeducibles())
                                            {
                                                if (guardarPolizaExclusiones())
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
                                                                    codigoVuelta = 13;
                                                                }
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
                nuevaPoliza.LineaNegocios = Marine;
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

        bool guardarPolizaMarine()
        {
            try
            {
                bool tmpAgregar = false;
                dbSmartGDataContext db = new dbSmartGDataContext();
                PolizaMarine nuevaPolizaMarine = (from x in db.PolizaMarine where x.Poliza == idPoliza select x).SingleOrDefault();
                if (nuevaPolizaMarine == null)
                {
                    nuevaPolizaMarine = new PolizaMarine();
                    nuevaPolizaMarine.Poliza = idPoliza;
                    tmpAgregar = true;
                }
                nuevaPolizaMarine.Origen = Origen;
                nuevaPolizaMarine.Programa = programa;
                nuevaPolizaMarine.ValoresSeguro = valoresSeguros;
                nuevaPolizaMarine.BienesAsegurados = bienesAsegurados;
                nuevaPolizaMarine.TypeGoods = typeGoods;
                nuevaPolizaMarine.FechaContinuidad = fechaContinuidad;
                nuevaPolizaMarine.Ajustable = ajustable;
                if (tmpAgregar)
                    db.PolizaMarine.InsertOnSubmit(nuevaPolizaMarine);
                db.SubmitChanges();
                idPolizaMa = nuevaPolizaMarine.ID;
                return true;
            }
            catch (Exception)
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
                        nuevaCoberturaDB.LineaNegocios = Marine;
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
                        nuevaPolizaSub.Monto = Convert.ToDecimal(dgSublimites.Rows[i].Cells["Monto"].Text.ToString());
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
                        nuevaPoliDedu.Porcentaje = Convert.ToDecimal(dgDeducibles.Rows[i].Cells["Porcentaje"].Text.ToString());
                        nuevaPoliDedu.Minimo = Convert.ToDecimal(dgDeducibles.Rows[i].Cells["Minimo"].Text.ToString());
                        nuevaPoliDedu.Maximo = Convert.ToDecimal(dgDeducibles.Rows[i].Cells["Maximo"].Text.ToString());
                        nuevaPoliDedu.SIR = Convert.ToBoolean(dgDeducibles.Rows[i].Cells["SIR"].Value.ToString());
                        nuevaPoliDedu.Agregado = Convert.ToDecimal(dgDeducibles.Rows[i].Cells["Agregado"].Text.ToString());
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

        bool guardarPolizaExclusiones()
        {
            try
            {
                dbSmartGDataContext db = new dbSmartGDataContext();

                // borramos los registros anterioes
                borrarRegistros(3);

                if (chkExclusiones.Checked)
                {
                    // registramos los nuevos valores
                    for (int i = 0; i < dgExclusiones.Rows.Count; i++)
                    {
                        PolizaExclusion nuevaPoliExclu = new PolizaExclusion();
                        nuevaPoliExclu.Poliza = idPoliza;
                        if (Convert.ToInt32(dgExclusiones.Rows[i].Cells["ID"].Text.ToString()) < 0)
                        {
                            Exclusiones nuevaExclusion = new Exclusiones();
                            nuevaExclusion.LineaNegocios = Marine;
                            nuevaExclusion.Exclusion = dgExclusiones.Rows[i].Cells["Exclusion"].Text.ToString();
                            nuevaExclusion.userAdd = true;
                            nuevaExclusion.Eliminado = false;
                            db.Exclusiones.InsertOnSubmit(nuevaExclusion);
                            db.SubmitChanges();
                            nuevaPoliExclu.Exclusion = nuevaExclusion.ID;
                        }
                        else
                            nuevaPoliExclu.Exclusion = Convert.ToInt32(dgExclusiones.Rows[i].Cells["ID"].Text.ToString());

                        db.PolizaExclusion.InsertOnSubmit(nuevaPoliExclu);
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
                                    nuevoPolizaCoase.Participacion = Convert.ToDecimal(dgCoaseguro.Rows[i].Cells["PorcentajeParticipacion"].Text.ToString());
                                    nuevoPolizaCoase.Monto = Convert.ToDecimal(dgCoaseguro.Rows[i].Cells["Participacion"].Text.ToString());
                                    nuevoPolizaCoase.PorcComision = Convert.ToDecimal(dgCoaseguro.Rows[i].Cells["PorcentajeComisionBroker"].Text.ToString());
                                    nuevoPolizaCoase.MontoComision = Convert.ToDecimal(dgCoaseguro.Rows[i].Cells["ComisionBroker"].Text.ToString());
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
                            nuevaPolizaReaseguro.PorcParticipacion = Convert.ToDecimal(dgReaseguro.Rows[i].Cells["PorcentajeParticipacion"].Text.ToString());
                            nuevaPolizaReaseguro.Participacion = Convert.ToDecimal(dgReaseguro.Rows[i].Cells["Participacion"].Text.ToString());
                            nuevaPolizaReaseguro.PorcComision = Convert.ToDecimal(dgReaseguro.Rows[i].Cells["PorcentajeComision"].Text.ToString());
                            nuevaPolizaReaseguro.Comision = Convert.ToDecimal(dgReaseguro.Rows[i].Cells["Comision"].Text.ToString());
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
            fechaContinuidad = Convert.ToDateTime(dateFechaContinuidad.Value);

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
            try
            {
                bienesAsegurados = txtBienesAsegurados.Rtf;
            }
            catch
            {
                bienesAsegurados = txtBienesAsegurados.Text;
            }
            try
            {
                valoresSeguros = txtValoresSeguro.Rtf;
            }
            catch
            {
                valoresSeguros = txtValoresSeguro.Text;
            }

            ///////////////////////////////////////////////////////////////////////////////////
            //     segunda tab
            ///////////////////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////////////////////
            //     tercera tab
            ///////////////////////////////////////////////////////////////////////////////////
            limiteMaximo = Convert.ToDecimal(txtLimiteMaximo.Value);

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
            if (cbTypeGoods.Value != null)
                typeGoods = Convert.ToInt32(cbTypeGoods.Value);
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
            strExclusiones = "";
            strAseguAdicional = "";
            strCoberturas2 = "";
            strIniVig = "Desde: " + formatearFecha(Convert.ToDateTime(dateInicioVig.Value), 1);
            strFinVig = "Hasta: " + formatearFecha(Convert.ToDateTime(dateFinVigencia.Value), 1);
            strIniVig2 = formatearFecha(Convert.ToDateTime(dateInicioVig.Value), 2);
            strFinVig2 = formatearFecha(Convert.ToDateTime(dateFinVigencia.Value), 2);
            strEmision = formatearFecha(Convert.ToDateTime(dateEmision.Value), 1);
            strEmision2 = formatearFecha(Convert.ToDateTime(dateEmision.Value), 2);
            if (chkReaseguro.Checked)
                diaAnterior = formatearFecha(obtenerDiaHabilAnterior(), 2);
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
            } // asegurados adicionales
            if (cbDelimitacionTerritorial.Text == "Solo Nacional")
                strdelimitacionTerritorial = "Dentro del territorio de los Estados Unidos Mexicanos únicamente.";
            else if (cbDelimitacionTerritorial.Text == "Mundial (Excepto USA, PR y Canadá)")
                strdelimitacionTerritorial = "Dentro del territorio de los Estados Unidos Mexicanos y en todo el Mundo, excluyendo los Estados Unidos de América, Puerto Rico, Canadá (inclusive los territorios y posesiones de estos últimos).";
            else
                strdelimitacionTerritorial = "Dentro del territorio de los Estados Unidos Mexicanos y en todo el Mundo, incluyendo los Estados Unidos de América, Puerto Rico, Canadá (inclusive los territorios y posesiones de estos últimos).";

            for (int i = 0; i < dgCoberturas.Rows.Count; i++)
            {
                if (!dgCoberturas.Rows[i].Cells["Cobertura"].Text.Contains("Disposiciones para Reclamaciones"))
                {
                    strCoberturas += "- " + dgCoberturas.Rows[i].Cells["Cobertura"].Text + "\n";
                }
                else
                {
                    if (strCoberturas2 != "")
                        strCoberturas2 += "- " + dgCoberturas.Rows[i].Cells["Cobertura"].Text.Replace("Disposiciones para Reclamaciones:", "") + "\n";
                    else
                        strCoberturas2 = "Disposiciones para Reclamaciones" + Environment.NewLine + "- " + dgCoberturas.Rows[i].Cells["Cobertura"].Text.Replace("Disposiciones para Reclamaciones:","") + "\n";
                }
            }
            for (int i = 0; i < dgSublimites.Rows.Count; i++)
            {
                strSublimites += "- " + dgSublimites.Rows[i].Cells["Sublimite"].Text + ": " + double.Parse(dgSublimites.Rows[i].Cells["Monto"].Text).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + "\n";
            }

            for (int i = 0; i < dgExclusiones.Rows.Count; i++)
            {
                strExclusiones += "- " + dgExclusiones.Rows[i].Cells["Exclusion"].Text + "\n";
            }

            if (dgDeducibles.Rows.Count == 0)
                strDeducibles = "No aplican deducibles";
            else
            {
                string txtSir;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in dgDeducibles.Rows)
                {
                    int caso = 0;
                    if (Convert.ToDouble(row.Cells["Porcentaje"].Text) > 0 && Convert.ToDouble(row.Cells["Minimo"].Text) == 0 && Convert.ToDouble(row.Cells["Maximo"].Text) == 0 && Convert.ToDouble(row.Cells["Agregado"].Text) == 0) { caso = 1; }
                    if (Convert.ToDouble(row.Cells["Porcentaje"].Text) > 0 && Convert.ToDouble(row.Cells["Minimo"].Text) > 0 && Convert.ToDouble(row.Cells["Maximo"].Text) == 0 && Convert.ToDouble(row.Cells["Agregado"].Text) == 0) { caso = 2; }
                    if (Convert.ToDouble(row.Cells["Porcentaje"].Text) > 0 && Convert.ToDouble(row.Cells["Minimo"].Text) > 0 && Convert.ToDouble(row.Cells["Maximo"].Text) > 0 && Convert.ToDouble(row.Cells["Agregado"].Text) == 0) { caso = 3; }
                    if (Convert.ToDouble(row.Cells["Porcentaje"].Text) == 0 && Convert.ToDouble(row.Cells["Minimo"].Text) > 0 && Convert.ToDouble(row.Cells["Maximo"].Text) == 0 && Convert.ToDouble(row.Cells["Agregado"].Text) == 0) { caso = 4; }
                    if (Convert.ToDouble(row.Cells["Porcentaje"].Text) == 0 && Convert.ToDouble(row.Cells["Minimo"].Text) > 0 && Convert.ToDouble(row.Cells["Maximo"].Text) > 0 && Convert.ToDouble(row.Cells["Agregado"].Text) == 0) { caso = 5; }
                    if (Convert.ToDouble(row.Cells["Porcentaje"].Text) == 0 && Convert.ToDouble(row.Cells["Minimo"].Text) > 0 && Convert.ToDouble(row.Cells["Maximo"].Text) == 0 && Convert.ToDouble(row.Cells["Agregado"].Text) > 0) { caso = 6; }
                    if (Convert.ToDouble(row.Cells["Porcentaje"].Text) == 0 && Convert.ToDouble(row.Cells["Minimo"].Text) == 0 && Convert.ToDouble(row.Cells["Maximo"].Text) == 0 && Convert.ToDouble(row.Cells["Agregado"].Text) > 0) { caso = 7; }
                    txtSir = ""; if (Convert.ToBoolean(row.Cells["SIR"].Value)) { txtSir = "Retención del Asegurado: "; }
                    switch (caso)
                    {
                        case 1: // Solo porcentaje
                            strDeducibles += "- " + row.Cells["Deducible"].Text + ": " + txtSir + double.Parse(row.Cells["Porcentaje"].Text).ToString("#,##0", new CultureInfo("en-US")) + "% por evento.";
                            break;
                        case 2: // Porcentaje con minimo
                            strDeducibles += "- " + row.Cells["Deducible"].Text + ": " + txtSir + double.Parse(row.Cells["Porcentaje"].Text).ToString("#,##0", new CultureInfo("en-US")) + "% con mínimo de " + double.Parse(row.Cells["Minimo"].Text).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + " por evento";
                            break;
                        case 3: // Porcentaje con min y max
                            strDeducibles += "- " + row.Cells["Deducible"].Text + ": " + txtSir + double.Parse(row.Cells["Porcentaje"].Text).ToString("#,##0", new CultureInfo("en-US")) + "% con mínimo de " + double.Parse(row.Cells["Minimo"].Text).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + " y máximo de " + double.Parse(row.Cells["Maximo"].Text).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + " por evento";
                            break;
                        case 4: // Solo min
                            strDeducibles += "- " + row.Cells["Deducible"].Text + ": " + txtSir + double.Parse(row.Cells["Minimo"].Text).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + " por evento";
                            break;
                        case 5: // Min y Max
                            strDeducibles += "- " + row.Cells["Deducible"].Text + ": " + txtSir + double.Parse(row.Cells["Minimo"].Text).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + " con máximo de " + double.Parse(row.Cells["Maximo"].Text.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + " por evento";
                            break;
                        case 6: // Caso con Agregado y Minimo
                            strDeducibles += "- " + row.Cells["Deducible"].Text + ": " + txtSir + double.Parse(row.Cells["Minimo"].Text).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + " por evento y " + double.Parse(row.Cells["Agregado"].Text).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + " en el agregado por el periodo de la póliza";
                            break;
                        case 7: // Caso con Agregado solo
                            strDeducibles += "- " + row.Cells["Deducible"].Text + ": " + txtSir + double.Parse(row.Cells["Agregado"].Text).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + " en el agregado por el periodo de la póliza";
                            break;
                    }
                    strDeducibles += "\n";
                }
            }

            strLimite = "Por evento: \t\t $ " + limiteMaximo.ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + Environment.NewLine + Environment.NewLine +
                "El límite máximo de responsabilidad corresponde a límite en un solo embarque o sobre un mismo vehículo, por una sola vez o en un solo lugar de almacenamiento o estacionamiento propio del viaje cubierto.";

            if (txtBienesAsegurados.Text.Contains("Escriba aquí"))
                txtBienesAsegurados.Text = "";

            if (txtValoresSeguro.Text.Contains("Escriba aquí"))
                txtValoresSeguro.Text = "";
        }

        void iniciarDatos()
        {
            /* // TODO: This line of code loads data into the 'coberturasOrdenadas.Coberturas' table. You can move, or remove it, as needed.
            this.coberturasTableAdapter.Fill(this.coberturasOrdenadas.Coberturas);
            // TODO: This line of code loads data into the 'coberturasOrdenadas.CoberturasDB' table. You can move, or remove it, as needed.
            this.coberturasDBTableAdapter.Fill(this.coberturasOrdenadas.CoberturasDB);
             * */
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
            // llena los paises del form en inglés
            liIncPaisTableAdapter.Fill(this.liabilityInc1.LiIncPais);
            // llena los programas para Marine incoming
            liIncProgramasTableAdapter.FillByDefaultLiInc(this.liabilityInc1.LiIncProgramas, Marine, Origen);
            // llena las monedas default
            liIncMonedaTableAdapter.Fill(this.liabilityInc1.LiIncMoneda);
            cbMoneda.Value = 1;
            // llena los producing office default
            lNPOTableAdapter.FillByConsultaLNPOporIDLineaNegocio(this.liabilityInc1.LNPO, Marine);
            cbProducingOffice.DisplayMember = "Producing Office";
            cbProducingOffice.ValueMember = "ID";
            // llena los activity Code
            liIncActivityCodeTableAdapter.FillByDefaultLi(this.liabilityInc1.LiIncActivityCode, Marine);
            cbActivityCode.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            // llenamos los type of goods
            typeGoodsTableAdapter.Fill(this.liabilityInc1.TypeGoods);
            cbTypeGoods.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
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
            coberturasDBTableAdapter.FillByDefaultDBOrigen(this.coberturasOrdenadas.CoberturasDB, Marine, Origen);
            // llenado de las coberturas default
            coberturasTableAdapter.FillByDefaultOrigen(this.coberturasOrdenadas.Coberturas, Marine, Origen);
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
            // damos formato a los dos richtextbox con el texto default
            txtBienesAsegurados.Text = "Todos los bienes inherentes al ramo de la actividad empresarial del Asegurado y por los cuales tenga algún interés asegurable, ya sean de su propiedad y/o de terceros bajo su custodia, consistentes en, pero no limitados a:"
                + Environment.NewLine + Environment.NewLine + "Escriba aquí";
            txtValoresSeguro.Text = "No obstante a que se indique lo contrario en las condiciones generales y/o particulares de la presente póliza queda entendido y convenido que la valuación de reclamaciones será hecha en la base siguiente:"
                + Environment.NewLine + Environment.NewLine + "Escriba aquí";
            // endosos emision
            #region generamos el datatable endosos
            DataTable dtEndosos = new DataTable();
            dtEndosos.Columns.Add("Aplica", typeof(bool));
            dtEndosos.Columns.Add("ID", typeof(int));
            dtEndosos.Columns.Add("Endoso", typeof(string));
            dtEndosos.Columns.Add("Texto Agregado", typeof(string));
            dtEndosos.Columns.Add("Texto", typeof(string));
            dtEndosos.Columns.Add("Cobertura", typeof(int));
            #endregion
            #region llenamos el DT temporal
            DataTable dttmpEnd = endosoEmisionTableAdapter.GetDataByActivosCobertura(Marine, Origen);
            for (int i = 0; i < dttmpEnd.Rows.Count; i++)
            {
                dtEndosos.Rows.Add(false, Convert.ToInt32(dttmpEnd.Rows[i]["ID"].ToString()), dttmpEnd.Rows[i]["Endoso"].ToString(), "", dttmpEnd.Rows[i]["EndosoTXT"].ToString(), Convert.ToInt32(dttmpEnd.Rows[i]["Cobertura"].ToString()));
            }
            #endregion
            #region llenamos el grid de endosos y formateamos
            dgEndosos.DataSource = dtEndosos;
            dgEndosos.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
            dgEndosos.DisplayLayout.Bands[0].Columns["Texto"].Hidden = true;
            dgEndosos.DisplayLayout.Bands[0].Columns["Cobertura"].Hidden = true;
            dgEndosos.DisplayLayout.Bands[0].Columns["Endoso"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            dgEndosos.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            dgEndosos.DisplayLayout.Bands[0].Columns["Texto Agregado"].Width = 500;
            dgEndosos.DisplayLayout.Bands[0].Columns["Texto Agregado"].AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.VisibleRows;
            dgEndosos.DisplayLayout.Bands[0].Columns["Texto Agregado"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            dgEndosos.DisplayLayout.Bands[0].Columns["Texto Agregado"].Hidden = true;
            #endregion
            seleccionarEndosos();
            // iniciamos el cb de PAM
            txtPAM.Value = Program.Globals.UserID;
        }

        void llenarControlesObligatorios()
        {
            controlesObligatorios = new Control[27];
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
            controlesObligatorios[13] = txtLimiteMaximo;
            controlesObligatorios[18] = txtTituloPolizaGenius;
            controlesObligatorios[19] = cbPaymentConditions;
            controlesObligatorios[20] = cbActivityCode;
            controlesObligatorios[21] = txtPrimaMain;
            controlesObligatorios[22] = cbIVA;
            controlesObligatorios[23] = cbTipoPrima;
            controlesObligatorios[24] = txtTipoPoliza;
            controlesObligatorios[25] = cbFormaPago;
            controlesObligatorios[26] = txtNumPagos;
        }

        void llenarMonedas()
        {
            labelsMonedas = new Control[14];
            labelsMonedas[0] = lbMon1;
            labelsMonedas[1] = lbMon4;
            labelsMonedas[2] = lbMon5;
            labelsMonedas[3] = lbMon6;
            labelsMonedas[4] = lbMon7;
            labelsMonedas[5] = lbMon8;
            labelsMonedas[6] = lbMon9;
            labelsMonedas[7] = lbMon10;
            labelsMonedas[8] = lbMon11;
            labelsMonedas[9] = lbMon12;
            labelsMonedas[10] = lbMon13;
            labelsMonedas[11] = lbMon14;
            labelsMonedas[12] = lbMon15;
            labelsMonedas[13] = lbMon16;
        }

        void llenarTablaCoaseguro()
        {
            if (dgCoaseguro.Rows.Count == 0)
            {
                // inicializamos el grid y lo formateamos
                dgCoaseguro.DataSource = dtCoaseguros;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["Coaseguradora"].Header.VisiblePosition = 0;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["Coaseguradora"].Width = 350;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeParticipacion"].Header.VisiblePosition = 1;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeParticipacion"].MinValue = 0;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeParticipacion"].MaxValue = 100;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["Participacion"].Header.VisiblePosition = 2;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeComisionBroker"].Header.VisiblePosition = 3;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["ComisionBroker"].Header.VisiblePosition = 4;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeParticipacion"].Header.Caption = "% Participacion";
                dgCoaseguro.DisplayLayout.Bands[0].Columns["Participacion"].Header.Caption = "$ Participacion";
                dgCoaseguro.DisplayLayout.Bands[0].Columns["Participacion"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeComisionBroker"].Header.Caption = "% Comision Broker";
                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeComisionBroker"].MinValue = 0;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["PorcentajeComisionBroker"].MaxValue = 100;
                dgCoaseguro.DisplayLayout.Bands[0].Columns["ComisionBroker"].Header.Caption = "$ Comision Broker";
                dgCoaseguro.DisplayLayout.Bands[0].Columns["ComisionBroker"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
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
                DataTable dtReaseTMP = liIncReaseguradorasTableAdapter.GetDataByDefaultMA();
                for (int i = 0; i < dtReaseTMP.Rows.Count; i++)
                {
                    dtReaseguro.Rows.Add(Convert.ToBoolean(dtReaseTMP.Rows[i]["Treaty"].ToString()), 0, 0, 0, 0, 0);
                }
                dgReaseguro.DisplayLayout.Bands[0].Columns["Reaseguradora"].Header.VisiblePosition = 0;
                dgReaseguro.DisplayLayout.Bands[0].Columns["Reaseguradora"].Width = 500;
                dgReaseguro.DisplayLayout.Bands[0].Columns["Intermediario"].Header.VisiblePosition = 7;
                dgReaseguro.DisplayLayout.Bands[0].Columns["Intermediario"].Width = 500;
                dgReaseguro.DisplayLayout.Bands[0].Columns["Treaty"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajeParticipacion"].Header.Caption = "% Participacion";
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajeParticipacion"].MinValue = 0;
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajeParticipacion"].MaxValue = 100;
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajePoliza"].Header.Caption = "% Aplica en la Poliza";
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajePoliza"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                dgReaseguro.DisplayLayout.Bands[0].Columns["Participacion"].Header.Caption = "$ Participacion";
                dgReaseguro.DisplayLayout.Bands[0].Columns["Participacion"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajeComision"].Header.Caption = "% Comision RIC";
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajeComision"].MinValue = 0;
                dgReaseguro.DisplayLayout.Bands[0].Columns["PorcentajeComision"].MaxValue = 100;
                dgReaseguro.DisplayLayout.Bands[0].Columns["Comision"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                dgReaseguro.DisplayLayout.Bands[0].Columns["Comision"].Header.Caption = "$ Comision RIC";
                dtReaseguro.Rows.Add(false, 0, 0, 0, 0, 0);
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
            }
        }

        DateTime obtenerDiaHabilAnterior()
        {
            DateTime demo = Convert.ToDateTime(dateEmision.Value);
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
            // llena los paises del form en inglés
            liIncPaisTableAdapter.Fill(this.liabilityInc1.LiIncPais);
            // llena los programas para Marine incoming
            liIncProgramasTableAdapter.FillByDefaultLiInc(this.liabilityInc1.LiIncProgramas, Marine, Origen);
            // llena las monedas default
            liIncMonedaTableAdapter.Fill(this.liabilityInc1.LiIncMoneda);
            cbMoneda.Value = 1;
            // llena los producing office default
            lNPOTableAdapter.FillByConsultaLNPOporIDLineaNegocio(this.liabilityInc1.LNPO, Marine);
            cbProducingOffice.DisplayMember = "Producing Office";
            cbProducingOffice.ValueMember = "ID";
            // llena los activity Code
            liIncActivityCodeTableAdapter.FillByDefaultLi(this.liabilityInc1.LiIncActivityCode, Marine);
            cbActivityCode.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            // llenamos los type of goods
            typeGoodsTableAdapter.Fill(this.liabilityInc1.TypeGoods);
            cbTypeGoods.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
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
            coberturasDBTableAdapter.FillByDefaultDBOrigen(this.coberturasOrdenadas.CoberturasDB, Marine, Origen);
            // llenado de las coberturas default
            coberturasTableAdapter.FillByDefaultOrigen(this.coberturasOrdenadas.Coberturas, Marine, Origen);
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
            DataTable dttmpEnd = endosoEmisionTableAdapter.GetDataByActivos(Marine, Origen);
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
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar los datos Marine.";
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
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar las exclusiones.";
                    break;
                case 10:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar la información de facturación.";
                    break;
                case 11:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar asegurados.";
                    break;
                case 12:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar los coaseguros.";
                    break;
                case 13:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar los reaseguros.";
                    break;
            }
        }

        void seleccionarEndosos()
        {
            for (int i = 0; i < dgEndosos.Rows.Count; i++)
            {
                int idEndosotmp = Convert.ToInt32(dgEndosos.Rows[i].Cells["Cobertura"].Text);
                bool encontro = false;
                for (int j = 0; j < dgCoberturas.Rows.Count; j++)
                {
                    int idCoberturatmp = Convert.ToInt32(dgCoberturas.Rows[j].Cells["ID"].Text);
                    if (idEndosotmp == idCoberturatmp)
                    {
                        encontro = true;
                        dgEndosos.Rows[i].Cells["Aplica"].Value = true;
                    }
                }

                if(!encontro)
                {
                    dgEndosos.Rows[i].Cells["Aplica"].Value = false;
                }
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

            if (dgExclusiones.Rows.Count > 0)
            {
                for (int i = 0; i < dgExclusiones.Rows.Count; i++)
                    dgExclusiones.Rows[i].Update();
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

        bool validarCliente()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            bool autorizado = Convert.ToBoolean((from x in db.Clientes where x.ID == Convert.ToInt32(cbAseguradoMain.Value) select x.Aprobado).SingleOrDefault());
            return autorizado;
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
                            txtRetroValidaciones.Text += Environment.NewLine + "Error: el campo Poliza MX debe llenarse correctamente: MX + 8 dígitos seguimiento + MA + 2 dígitos año de emisión + caracter A,B o C  (Datos Generales)";
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
                            txtRetroValidaciones.Text += Environment.NewLine + "Error: el campo Poliza ES debe llenarse correctamente: ES + 8 dígitos seguimiento + MA + 2 dígitos año de emisión + caracter A,B o C (Datos Generales)";
                        }
                    }
                    for (int i = 2; i < 13; i++)
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
                    if (chkSublimites.Checked && dgSublimites.Rows.Count == 0)
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debes de introducir sublimites si activaste la opción de sublimites (Límites y sublímites)";
                    }
                    if (chkSublimites.Checked)
                    {
                        for (int i = 0; i < dgSublimites.Rows.Count; i++)
                        {
                            if (Convert.ToDecimal(dgSublimites.Rows[i].Cells["Monto"].Text) > Convert.ToDecimal(txtLimiteMaximo.Value) || Convert.ToDecimal(dgSublimites.Rows[i].Cells["Monto"].Text) <= 0)
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

                case 4: // tab deducibles y exclusiones
                    if (chkDeducibles.Checked && dgDeducibles.Rows.Count <= 0)
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debes de introducir deducibles si activaste la opción de deducibles (Deducibles y Exclusiones)";
                    }
                    if (chkDeducibles.Checked && dgDeducibles.Rows.Count > 0)
                    {
                        if (!validarTablaDeducibles())
                        {
                            tmpValida = false;
                        }
                    }
                    if (chkExclusiones.Checked && dgExclusiones.Rows.Count <= 0)
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debes de introducir exclusiones si activaste la opción de exclusiones (Deducibles y Exclusiones)";
                    }
                    if (tmpValida) // pasó todas las validaciones
                        txtRetroValidaciones.Text += Environment.NewLine + "5) Sección Deducibles y Exclusiones OK";
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
                    txtRetroValidaciones.Text += Environment.NewLine + "Error: el deducible " + row.Cells["Deducible"].Value.ToString() + " no tiene los datos correctos ingresados (Deducibles y Exclusiones)";
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
                    for (int j = i+1; j < dgCoaseguro.Rows.Count; j++)
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
                if (dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text.ToString() != "" && dgCoaseguro.Rows[i].Cells["Coaseguradora"].Text.ToString() != "0")
                {
                    tmpParticipacion += Convert.ToDecimal(dgCoaseguro.Rows[i].Cells["PorcentajeParticipacion"].Text.ToString());
                    tmpBrokerage += Convert.ToDecimal(dgCoaseguro.Rows[i].Cells["PorcentajeComisionBroker"].Text.ToString());
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
                if (dgReaseguro.Rows[i].Cells["Reaseguradora"].Text.ToString() != "" && dgReaseguro.Rows[i].Cells["Reaseguradora"].Text.ToString() != "0")
                {
                    tmpParticipacion += Convert.ToDecimal(dgReaseguro.Rows[i].Cells["PorcentajePoliza"].Text.ToString());
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

        private void btnBorrarBusqueda_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgCoberturasDB.Rows.Count; i++)
            {
                dgCoberturasDB.Rows[i].Appearance.ResetBackColor();
            }
            for (int i = 0; i < dgCoberturas.Rows.Count; i++)
            {
                dgCoberturas.Rows[i].Appearance.ResetBackColor();
            }
        }

        private void btnBuscarCobertura_Click(object sender, EventArgs e)
        {
            if (txtBusquedaCobertura.Text != "")
            {
                btnBorrarBusqueda_Click(null, null);

                for (int i = 0; i < dgCoberturasDB.Rows.Count; i++)
                {
                    if (dgCoberturasDB.Rows[i].Cells["Cobertura"].Text.ToUpper().Contains(txtBusquedaCobertura.Text.ToUpper()))
                    {
                        dgCoberturasDB.Rows[i].Appearance.BackColor = Color.LightGreen;
                    }
                }

                for (int i = 0; i < dgCoberturas.Rows.Count; i++)
                {
                    if (dgCoberturas.Rows[i].Cells["Cobertura"].Text.ToUpper().Contains(txtBusquedaCobertura.Text.ToUpper()))
                    {
                        dgCoberturas.Rows[i].Appearance.BackColor = Color.LightGreen;
                    }
                }
            }
            else
            {
                btnBorrarBusqueda_Click(null, null);
            }
        }

        private void btnEndososTodos_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgEndosos.Rows.Count; i++)
            {
                dgEndosos.Rows[i].Cells["Aplica"].Value = true;
            }
        }

        private void btnEndososNinguno_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgEndosos.Rows.Count; i++)
            {
                dgEndosos.Rows[i].Cells["Aplica"].Value = false;
            }
        }

        private void btnEnviarCobertura_Click(object sender, EventArgs e)
        {
            if (dgCoberturasDB.Selected.Rows.Count == 1)
            {
                coberturasOrdenadas.Coberturas.Rows.Add(Convert.ToInt32(dgCoberturasDB.ActiveRow.Cells["ID"].Text.ToString()),
                    Marine, dgCoberturasDB.ActiveRow.Cells["Cobertura"].Text.ToString(), dgCoberturasDB.ActiveRow.Cells["CoberturaIngles"].Text.ToString(),
                    dgCoberturasDB.ActiveRow.Cells["GeniusCode"].Text.ToString(), Convert.ToBoolean(dgCoberturasDB.ActiveRow.Cells["Defecto"].Text),
                    Convert.ToBoolean(dgCoberturasDB.ActiveRow.Cells["userAdd"].Text), Convert.ToBoolean(dgCoberturasDB.ActiveRow.Cells["Eliminado"].Text),
                    Origen, Convert.ToInt32(dgCoberturasDB.ActiveRow.Cells["OrdenImpresion"].Text.ToString()));
                int msgIndex = coberturasOrdenadas.CoberturasDB.Rows.IndexOf(coberturasOrdenadas.CoberturasDB.FindByID(Convert.ToInt32(dgCoberturasDB.ActiveRow.Cells["ID"].Text.ToString())));
                coberturasOrdenadas.CoberturasDB.Rows.RemoveAt(msgIndex);

                coberturasOrdenadas.Tables[0].AcceptChanges();
                coberturasOrdenadas.Tables[1].AcceptChanges();

                coberturasOrdenadas.Tables[0].DefaultView.Sort = "OrdenImpresion ASC";
                coberturasOrdenadas.Tables[0].AcceptChanges();
                coberturasOrdenadas.Tables[1].DefaultView.Sort = "OrdenImpresion ASC";
                coberturasOrdenadas.Tables[1].AcceptChanges();
                dgCoberturas.DataSource = coberturasOrdenadas.Tables[0].DefaultView;
                dgCoberturasDB.DataSource = coberturasOrdenadas.Tables[1].DefaultView;

            }
            else
            {
                if (dgCoberturasDB.Selected.Rows.Count < 1)
                    MessageBox.Show("Debes seleccionar una cobertura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Debes seleccionar solo una cobertura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            seleccionarEndosos();
        }

        private void btnQuitarCobertura_Click(object sender, EventArgs e)
        {
            if (dgCoberturas.Selected.Rows.Count == 1)
            {
                coberturasOrdenadas.CoberturasDB.Rows.Add(Convert.ToInt32(dgCoberturas.ActiveRow.Cells["ID"].Text.ToString()),
                   Marine, dgCoberturas.ActiveRow.Cells["Cobertura"].Text.ToString(), dgCoberturas.ActiveRow.Cells["CoberturaIngles"].Text.ToString(),
                   dgCoberturas.ActiveRow.Cells["GeniusCode"].Text.ToString(), Convert.ToBoolean(dgCoberturas.ActiveRow.Cells["Defecto"].Text),
                   Convert.ToBoolean(dgCoberturas.ActiveRow.Cells["userAdd"].Text), Convert.ToBoolean(dgCoberturas.ActiveRow.Cells["Eliminado"].Text),
                   Origen, Convert.ToInt32(dgCoberturas.ActiveRow.Cells["OrdenImpresion"].Text.ToString()));

                int msgIndex = coberturasOrdenadas.Coberturas.Rows.IndexOf(coberturasOrdenadas.Coberturas.FindByID(Convert.ToInt32(dgCoberturas.ActiveRow.Cells["ID"].Text.ToString())));
                coberturasOrdenadas.Coberturas.Rows.RemoveAt(msgIndex);

                coberturasOrdenadas.Tables[0].AcceptChanges();
                coberturasOrdenadas.Tables[1].AcceptChanges();

                coberturasOrdenadas.Tables[0].DefaultView.Sort = "OrdenImpresion ASC";
                coberturasOrdenadas.Tables[0].AcceptChanges();
                coberturasOrdenadas.Tables[1].DefaultView.Sort = "OrdenImpresion ASC";
                coberturasOrdenadas.Tables[1].AcceptChanges();
                dgCoberturas.DataSource = coberturasOrdenadas.Tables[0].DefaultView;
                dgCoberturasDB.DataSource = coberturasOrdenadas.Tables[1].DefaultView;
            }
            else
            {
                if (dgCoberturas.Selected.Rows.Count < 1)
                    MessageBox.Show("Debes seleccionar una cobertura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Debes seleccionar solo una cobertura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            seleccionarEndosos();
        }

        private void btnRecargarDeducibles_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas sustituir los valores por los que están actualmente en la sección Coberturas?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                dtDeducibles.Rows.Clear();
                for (int i = 0; i < dgCoberturas.Rows.Count; i++)
                {
                    dtDeducibles.Rows.Add(dgCoberturas.Rows[i].Cells["Cobertura"].Text.ToString(), 0, 0, 0, false, 0);
                }
                dgDeducibles.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
        }

        private void btnRecargarExclusiones_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas sustituir los valores por defecto?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                dtExclusiones.Rows.Clear();
                dtExclusiones = liIncExclusionesTableAdapter.GetDataByDefault(Marine);
                dgExclusiones.DataSource = dtExclusiones;
                dgExclusiones.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
                dgExclusiones.DisplayLayout.Bands[0].Columns["LineaNegocios"].Hidden = true;
                dgExclusiones.DisplayLayout.Bands[0].Columns["userAdd"].Hidden = true;
                dgExclusiones.DisplayLayout.Bands[0].Columns["Eliminado"].Hidden = true;
                dgExclusiones.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
        }

        private void btnRecargarSublimites_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas sustituir los valores por los que están actualmente en la sección Coberturas?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                dtSublimites.Rows.Clear();
                for (int i = 0; i < dgCoberturas.Rows.Count; i++)
                {
                    dtSublimites.Rows.Add(dgCoberturas.Rows[i].Cells["Cobertura"].Text.ToString(), 0);
                }
                dgSublimites.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
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
                //Comenzamos con el line of business (Marine)
                string codigoGenius = "CARG";

                if (cbAseguradoMain.Text.Length > 16)
                    //parseamos el nombre del cliente a 16 letras
                    codigoGenius = codigoGenius + " " + cbAseguradoMain.Text.Substring(0, 22) + " " + "MX";
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
                btnRecargarDeducibles.Visible = true;
                lbRecargarDeducibles.Visible = true;
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


                for (int i = 0; i < dgCoberturas.Rows.Count; i++)
                {
                    dtDeducibles.Rows.Add(dgCoberturas.Rows[i].Cells["Cobertura"].Text.ToString(), 0, 0, 0, false, 0);
                }

                dgDeducibles.DataSource = dtDeducibles;
                dgDeducibles.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);


                dgDeducibles.DisplayLayout.Bands[0].Columns["Porcentaje"].MinValue = 0;
                dgDeducibles.DisplayLayout.Bands[0].Columns["Porcentaje"].MaxValue = 100;
                dgDeducibles.DisplayLayout.Bands[0].Columns["Minimo"].MinValue = 0;
                dgDeducibles.DisplayLayout.Bands[0].Columns["Maximo"].MinValue = 0;
                dgDeducibles.DisplayLayout.Bands[0].Columns["Agregado"].MinValue = 0;
            }
            // se ocultan los controles
            else
            {
                btnRecargarDeducibles.Visible = false;
                lbRecargarDeducibles.Visible = false;
                lbDeducibleManual.Visible = false;
                txtDeducibleManual.Visible = false;
                dgDeducibles.Visible = false;
                dtDeducibles.Rows.Clear();
            }
        }

        private void chkExclusiones_CheckedChanged(object sender, EventArgs e)
        {
            // se muestran los controles y se llenan las exclusiones con la informacion de la db
            if (chkExclusiones.Checked)
            {
                btnRecargarExclusiones.Visible = true;
                lbRecargarExclusiones.Visible = true;
                lbExclusionManual.Visible = true;
                txtExclusionManual.Visible = true;
                dgExclusiones.Visible = true;

                dtExclusiones = liIncExclusionesTableAdapter.GetDataByDefault(Marine);
                dgExclusiones.DataSource = dtExclusiones;
                dgExclusiones.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
                dgExclusiones.DisplayLayout.Bands[0].Columns["LineaNegocios"].Hidden = true;
                dgExclusiones.DisplayLayout.Bands[0].Columns["userAdd"].Hidden = true;
                dgExclusiones.DisplayLayout.Bands[0].Columns["Eliminado"].Hidden = true;
                dgExclusiones.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
            //se ocultan y se resetean todos los controles
            else
            {
                btnRecargarExclusiones.Visible = false;
                lbRecargarExclusiones.Visible = false;
                lbExclusionManual.Visible = false;
                txtExclusionManual.Visible = false;
                dgExclusiones.Visible = false;

                dtExclusiones.Rows.Clear();
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
                dateLTAInception.Value = dateInicioVig.Value;
                dateLTAExpiry.Value = Convert.ToDateTime(dateLTAInception.Value).AddYears(2);
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

                dtSublimites.Rows.Add("Almacenaje Extraordinario", 0);
                dtSublimites.Rows.Add("Por cualquier Exhibición", 0);

                //for (int i = 0; i < dgCoberturas.Rows.Count; i++)
                //{
                //    dtSublimites.Rows.Add(dgCoberturas.Rows[i].Cells["Cobertura"].Text.ToString(), 0);
                //}

                dgSublimites.DataSource = dtSublimites;
                dgSublimites.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                dgSublimites.DisplayLayout.Bands[0].Columns["Monto"].DefaultCellValue = 0;
                dgSublimites.DisplayLayout.Bands[0].Columns["Sublimite"].NullText = "Nuevo Sublímite";
                dgSublimites.DisplayLayout.Bands[0].Columns["Monto"].MinValue = 0;
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
                decimal tmpPrima = Convert.ToDecimal(txtComisionTotalBrok.Value);
                decimal tmpPorcPart = Convert.ToDecimal(e.Cell.Value) / 100;
                dgCoaseguro.ActiveRow.Cells["ComisionBroker"].Value = tmpPrima * tmpPorcPart;
            }
            if (e.Cell.Column.Header.Caption == "Coaseguradora")
            {
                if (e.Cell.Value != DBNull.Value)
                {
                    if (Convert.ToInt32(e.Cell.Value) != idDefaultCoaseguradora && e.Cell.Row.Index == 0)
                    {
                        e.Cell.Value = idDefaultCoaseguradora;
                    }

                    if (e.Cell.Row.Index + 1 == dgCoaseguro.Rows.Count && e.Cell.Value.ToString() != "")
                    {
                        dtCoaseguros.Rows.Add(0, 0, 0, 0);
                    }

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
                if (dgCoaseguro.ActiveRow.Index + 1 == dgCoaseguro.Rows.Count)
                    dtCoaseguros.Rows.Add(0, 0, 0, 0);
            }
        }

        private void dgCoberturasDB_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            btnEnviarCobertura_Click(sender, e);
        }

        private void dgCoberturas_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            btnQuitarCobertura_Click(sender, e);
        }

        private void dgDeducibles_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
        }

        private void dgDeducibles_CellDataError(object sender, Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs e)
        {
            e.RestoreOriginalValue = true;
            e.RaiseErrorEvent = false;
        }

        private void dgExclusiones_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
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

                    if (e.Cell.Row.Index + 1 == dgReaseguro.Rows.Count && e.Cell.Value.ToString() != "") // llenamos los valores treaty, participacion y comision contra lo que haya seleccionado el usuario y agregamos nueva fila
                    {
                        dgReaseguro.Rows[e.Cell.Row.Index].Cells["Treaty"].Value = Convert.ToBoolean(liIncReaseguradorasTableAdapter.ScalarTreaty(Convert.ToInt32(e.Cell.Value)));
                        dgReaseguro.Rows[e.Cell.Row.Index].Cells["PorcentajeParticipacion"].Value = Convert.ToDecimal(liIncReaseguradorasTableAdapter.ScalarFijoInterno(Convert.ToInt32(e.Cell.Value)));
                        dgReaseguro.Rows[e.Cell.Row.Index].Cells["PorcentajeComision"].Value = Convert.ToDecimal(liIncReaseguradorasTableAdapter.ScalarComision(Convert.ToInt32(e.Cell.Value)));

                        dtReaseguro.Rows.Add(false, 0, 0, 0, 0, 0);
                    }

                    if (e.Cell.Row.Index > 1 && e.Cell.Value.ToString() != "") // update para cualqiuer fila que no sea la última
                    {
                        dgReaseguro.Rows[e.Cell.Row.Index].Cells["Treaty"].Value = Convert.ToBoolean(liIncReaseguradorasTableAdapter.ScalarTreaty(Convert.ToInt32(e.Cell.Value)));
                        dgReaseguro.Rows[e.Cell.Row.Index].Cells["PorcentajeParticipacion"].Value = Convert.ToDecimal(liIncReaseguradorasTableAdapter.ScalarFijoInterno(Convert.ToInt32(e.Cell.Value)));
                        dgReaseguro.Rows[e.Cell.Row.Index].Cells["PorcentajeComision"].Value = Convert.ToDecimal(liIncReaseguradorasTableAdapter.ScalarComision(Convert.ToInt32(e.Cell.Value)));
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
                if (dgReaseguro.ActiveRow.Index + 1 == dgReaseguro.Rows.Count)
                    dtReaseguro.Rows.Add(false, 0, 0, 0, 0, 0);
            }
        }

        private void dgReaseguro_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
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

        private void dgReaseguro_Leave(object sender, EventArgs e)
        {
            calcularReaseguros();
        }

        private void dgSublimites_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
        }

        private void dgSublimites_CellDataError(object sender, Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs e)
        {
            e.RestoreOriginalValue = true;
            e.RaiseErrorEvent = false;
        }

        public MarineInc(int idVentana = 0, int idPolizaTemp = 0)
        {
            InitializeComponent();
            llenarControlesObligatorios();
            dbSmartGDataContext db = new dbSmartGDataContext();

            // obtenemos los id's importantes utilizados en todo el formulario
            Marine = (from x in db.LineaNegocios where x.LineaNegocios1 == "Marine" select x.ID).SingleOrDefault();
            Origen = (from x in db.Origen where x.Origen1 == "Incoming" select x.ID).SingleOrDefault();
            ventana = idVentana;
            if (idPolizaTemp != 0)
                idPoliza = idPolizaTemp;

        }

        private void MarineInc_FormClosing(object sender, FormClosingEventArgs e)
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

        private void MarineInc_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this, tabControlLiability, ToolsBarMarineInc);

            llenarMonedas();
            iniciarDatos();
            if (ventana == 1) // carga de ventanas para edicion de guardados
            {
                cargarAvances();
            }
            validarDatos(tabControlLiability.ActiveTab.Index);
            txtRetroValidaciones.Text = "";
            tabAnterior = tabControlLiability.ActiveTab.Index;
            this.FormClosing += MarineInc_FormClosing;
        }

        private void tabControlLiability_SelectedTabChanging(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangingEventArgs e)
        {
            validarDatos(tabAnterior);
            tabAnterior = tabControlLiability.ActiveTab.Index;
        }

        private void ToolsBarLiabilityInc_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            terminarEdicionGrids();

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

                                    DocumentosDB nuevoPreview = new DocumentosDB();
                                    if (nuevoPreview.ExtraerDocumentoDB("CoverMarine.docx"))
                                    {
                                        txtRetroValidaciones.Text += Environment.NewLine + "Generando Cover...";
                                        generarCover("CoverMarine.docx", 2);
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

                                    if (nuevoPreview.ExtraerDocumentoDB("WordingMarineInc.docx"))
                                    {
                                        txtRetroValidaciones.Text += Environment.NewLine + "Generando Wording...";
                                        generarWording("WordingMarineInc.docx", 2);
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

                                    generarPoliza();

                                    string rutaGuardado = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + "\\";
                                    nuevoPreview.CopiarTripticoDerechos(rutaGuardado);
                                    DocumentosDB.GuardarDocumentosDB(rutaGuardado, Convert.ToInt32(idPoliza), Marine, polizaMX, txtPAM.Text, emision);

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


                                DocumentosDB nuevoPreview = new DocumentosDB();
                                if (nuevoPreview.ExtraerDocumentoDB("PreviewCoverMarine.docx"))
                                {
                                    txtRetroValidaciones.Text += Environment.NewLine + "Generando Cover...";
                                    generarCover("PreviewCoverMarine.docx", 1);
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

                                if (nuevoPreview.ExtraerDocumentoDB("PreviewWordingMarineInc.docx"))
                                {
                                    txtRetroValidaciones.Text += Environment.NewLine + "Generando Wording...";
                                    generarWording("PreviewWordingMarineInc.docx", 1);
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

        private void txtBusquedaCobertura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txtBusquedaCobertura.Text != "")
                {
                    btnBorrarBusqueda_Click(null, null);
                    btnBuscarCobertura_Click(null, null);
                }
                else
                    btnBorrarBusqueda_Click(null, null);
            }
        }

        private void txtCoasePorcBrokerage_Leave(object sender, EventArgs e)
        {
            double tmpPorc = Convert.ToDouble(txtCoasePorcBrokerage.Value) / 100;
            double tmpComi = Convert.ToDouble(txtComisionTotalBrok.Value);

            txtCoaseComiBrokerage.Value = tmpPorc * tmpComi;
        }

        private void txtExclusionManual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && txtExclusionManual.Text != "")
            {
                dtExclusiones.Rows.Add(exclusionesM, Marine, txtExclusionManual.Text, true, false);
                exclusionesM--;
                txtExclusionManual.Text = "";
                dgExclusiones.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
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
                liabilityInc1.LiIncCoberturas.Rows.Add(coberturaM, Marine, txtNuevaCobertura.Text, "N/A", "OTH", false, true, false, 1);
                coberturaM--;
                txtNuevaCobertura.Text = "";
                dgCoberturas.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
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
            MessageBox.Show("El formato correcto para la póliza MX es el siguiente: MX + 8 dígitos de seguimiento + MA + 2 dítigos del año de emisión + 1 caracter, verifica los datos ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtPorParticipacionXL_Leave(object sender, EventArgs e)
        {
            double tmpPorc = Convert.ToDouble(txtPorParticipacionXL.Value) / 100;
            double tmpPrima = Convert.ToDouble(txtPrimaMain.Value);

            txtParticipacionXL.Value = tmpPorc * tmpPrima;
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

        private void btnImportarWord_Click(object sender, EventArgs e)
        {
            OpenFileDialog importarFile = new OpenFileDialog();
            importarFile.InitialDirectory = Directory.GetCurrentDirectory();
            importarFile.Filter = "Archivos Word (*.docx)|*.docx";
            importarFile.FilterIndex = 1;
            importarFile.RestoreDirectory = true;

            if (importarFile.ShowDialog() == DialogResult.OK)
            {
                rutaDocumentoImportar = importarFile.FileName;
                imgWord.Visible = true;
            }
        }

        private void btnEliminarArchivo_Click(object sender, EventArgs e)
        {
            if (rutaDocumentoImportar == "")
            {
                MessageBox.Show("No has importado ningun documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("¿Deseas eliminar el archivo seleccionado?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    rutaDocumentoImportar = "";
                    imgWord.Visible = false;
                    MessageBox.Show("Documento eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void btnRevisarArchivoImportado_Click(object sender, EventArgs e)
        {
            if (rutaDocumentoImportar != "")
            {
                string outputFile = rutaDocumentoImportar;
                object m = System.Reflection.Missing.Value;
                object readOnly = (object)false;
                Word.Application ac = null;
                ac = new Word.Application();
                ac.Visible = true;

                Word.Document doc = ac.Documents.Open(outputFile, m, readOnly,
                      m, m, m, m, m, m, m, m, m, m, m, m, m);
            }
            else
            {
                MessageBox.Show("No has importado ningun documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCoberturaUP_Click(object sender, EventArgs e)
        {
            if (dgCoberturas.ActiveRow.Index != 0 && dgCoberturas.Selected.Rows.Count == 1)
            {
                int rowTmpA = dgCoberturas.ActiveRow.Index;
                int rowTmpB = dgCoberturas.ActiveRow.Index - 1;
                int tmpPosA = Convert.ToInt32(dgCoberturas.ActiveRow.Cells["OrdenImpresion"].Text);
                int tmpPosB = Convert.ToInt32(dgCoberturas.Rows[rowTmpB].Cells["OrdenImpresion"].Text);

                coberturasOrdenadas.Coberturas.Rows[rowTmpA]["OrdenImpresion"] = tmpPosB;
                coberturasOrdenadas.Coberturas.Rows[rowTmpB]["OrdenImpresion"] = tmpPosA;
                coberturasOrdenadas.Tables[0].AcceptChanges();
                coberturasOrdenadas.Tables[0].DefaultView.Sort = "OrdenImpresion ASC";
                coberturasOrdenadas.Tables[0].AcceptChanges();
                dgCoberturas.DataSource = coberturasOrdenadas.Tables[0].DefaultView;

                /*coberturasOrdenadas.CoberturasDB.Rows.Add(Convert.ToInt32(dgCoberturas.ActiveRow.Cells["ID"].Text.ToString()),
                   Marine, dgCoberturas.ActiveRow.Cells["Cobertura"].Text.ToString(), dgCoberturas.ActiveRow.Cells["CoberturaIngles"].Text.ToString(),
                   dgCoberturas.ActiveRow.Cells["GeniusCode"].Text.ToString(), Convert.ToBoolean(dgCoberturas.ActiveRow.Cells["Defecto"].Text),
                   Convert.ToBoolean(dgCoberturas.ActiveRow.Cells["userAdd"].Text), Convert.ToBoolean(dgCoberturas.ActiveRow.Cells["Eliminado"].Text),
                   Origen, Convert.ToInt32(dgCoberturas.ActiveRow.Cells["OrdenImpresion"].Text.ToString()));

                int msgIndex = coberturasOrdenadas.Coberturas.Rows.IndexOf(coberturasOrdenadas.Coberturas.FindByID(Convert.ToInt32(dgCoberturas.ActiveRow.Cells["ID"].Text.ToString())));
                coberturasOrdenadas.Coberturas.Rows.RemoveAt(msgIndex);

                coberturasOrdenadas.Tables[0].AcceptChanges();
                coberturasOrdenadas.Tables[1].AcceptChanges();

                coberturasOrdenadas.Tables[0].DefaultView.Sort = "OrdenImpresion ASC";
                coberturasOrdenadas.Tables[0].AcceptChanges();
                coberturasOrdenadas.Tables[1].DefaultView.Sort = "OrdenImpresion ASC";
                coberturasOrdenadas.Tables[1].AcceptChanges();
                dgCoberturas.DataSource = coberturasOrdenadas.Tables[0].DefaultView;
                dgCoberturasDB.DataSource = coberturasOrdenadas.Tables[1].DefaultView;
                 * */
            }
        }

        private void btnCoberturaDown_Click(object sender, EventArgs e)
        {

        }

        private void dgCoberturas_SelectionDrag(object sender, CancelEventArgs e)
        {
            //ultraGrid1.DoDragDrop(ultraGrid1.Selected.Rows, DragDropEffects.Move);
            dgCoberturas.DoDragDrop(dgCoberturas.Selected.Rows, DragDropEffects.Move);
        }

        private void dgCoberturas_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            Infragistics.Win.UltraWinGrid.UltraGrid grid = sender as Infragistics.Win.UltraWinGrid.UltraGrid;
            Point pointInGridCoords = grid.PointToClient(new Point(e.X, e.Y));
            if (pointInGridCoords.Y < 20)
                // Scroll up.RowScrollAction.LineUp
                this.dgCoberturas.ActiveRowScrollRegion.Scroll(Infragistics.Win.UltraWinGrid.RowScrollAction.LineUp);
            else if (pointInGridCoords.Y > grid.Height - 20)
                // Scroll down.
                this.dgCoberturas.ActiveRowScrollRegion.Scroll(Infragistics.Win.UltraWinGrid.RowScrollAction.LineDown);
        }

        private void dgCoberturas_DragDrop(object sender, DragEventArgs e)
        {
            int dropIndex;

            //Get the position on the grid where the dragged row(s) are to be dropped.
            //get the grid coordinates of the row (the drop zone)
            UIElement uieOver = dgCoberturas.DisplayLayout.UIElement.ElementFromPoint(
            dgCoberturas.PointToClient(new Point(e.X, e.Y)));

            //get the row that is the drop zone/or where the dragged row is to be dropped
            UltraGridRow ugrOver = uieOver.GetContext(typeof(UltraGridRow), true) as
            UltraGridRow;

            if (ugrOver != null)
            {
                dropIndex = ugrOver.Index;    //index/position of drop zone in grid

                //get the dragged row(s)which are to be dragged to another position in the grid
                SelectedRowsCollection SelRows = (SelectedRowsCollection)e.Data.GetData(typeof(SelectedRowsCollection)) as
                SelectedRowsCollection;
                //get the count of selected rows and drop each starting at the dropIndex
                foreach (UltraGridRow aRow in SelRows)
                {
                    //move the selected row(s) to the drop zone
                    dgCoberturas.Rows.Move(aRow, dropIndex);
                }

            }
        }
    }


    #endregion

    //**********************************************************************************
    //**********************************************************************************
    //**********************************************************************************



}
