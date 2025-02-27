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
    public partial class LiabilityProd : Form
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
        //txtQuoteNumber
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
        //lbQuoteNumber Quote Number:
        //lbJurisdiccion      Jurisdicción
        //cbJurisdiccion
        //lbOtro Otro
        //txtJurisOtro
        //lbInteresAsegurable Interes Asegurable
        //txtInteresAsegurable
        //lbUbicacion     Ubicación del Riesgo
        //txtUbicacion

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
        #region Tercera tab Endosos
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
        //chkExclusiones        Aplican Exclusiones
        //txtExclusiones
        //lbExclusionManual    1) Agrege la(s) exclusión(es)
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
        //lbBaseCalculo     Base de cálculo
        //txtBaseCalculo
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
        int? idPolizaLia = 0;
        string polizaMX;
        string polizaES;
        string quoteNumber;
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
        string DAM;
        int? PAM;
        int? country;
        int? Broker;
        int? aseguradoPrincipal;
        int? direccionAseguradoPrincipal;
        DataTable dtAseguradosAdicionales;
        string delimitacionTerritorial;
        string jurisdiccion;
        string jurisdiccionOtro;
        string interesAsegurable;
        string ubicacionRiesgo;
        #endregion
        #region segunda tab coberturas
        DataTable dtCoberturas;
        DataTable dtCoberturasDB;
        DataTable dtSubCoberturas;
        DataTable dtSubCoberturasDB;
        DataSet dsCoberturas;
        DataSet dsCoberturasDB;
        #endregion
        #region tercera tab endosos
        DataTable dtEndosos;
        #endregion
        #region cuarta tab limites y sublimites
        decimal limiteMaximo;
        int? aggregationPL;
        int? aggregationPR;
        string estructuraLimite;
        string gastosDefensa;
        decimal sujecion;
        decimal defensaGastosCantidad;
        DataTable dtSublimites;
        #endregion
        #region quinta tab deducibles y exclusiones
        DataTable dtDeducibles;
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
        string baseCalculo;
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
        int Liability;
        int Origen;
        int coberturaM = -1;
        bool controlSave = false;
        int? idDefaultCoaseguradora = 0;
        int? idDefaultReaseguradora = 0;
        int ventana = 0;
        int tabAnterior = 0;
        ///////// Para endosos
        int? idEndoso;
        DataTable dtControles;
        string tipoEndosoG;
        decimal primaAnterior = 0;
        int consecutivoAnteriorEndoso = 0;
        string direccionAnterior = "";
        DateTime fechaFinAnterior;
        bool endososClientePrincipal = false;
        bool endososClienteAdicional = false;
        bool endososCoberturas = false;
        bool endososEndososEmision = false;
        bool endososSublimites = false;
        bool endososDeducibles = false;
        bool endososExclusiones = false;
        bool endososCoaseguros = false;
        bool endososReaseguros = false;
        bool endososIsInfoSchedule = false;
        string polizaAnterior = "";
        string polizaNuevo = "";
        string coberturasAnterior = "";
        string coberturasNuevo = "";
        string infoPrima = "";
        #endregion
        #region Variables Wording
        string strIniVig;
        string strFinVig;
        string strIniVig2;
        string strFinVig2;
        string diaAnterior;
        string strRetroactiva;
        string strEmision;
        string strEmision2;
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
        string strCoberturasAdicional;
        string strSublimites;
        string strDeducibles;
        double strPartReasegurada = 0;
        double strPartTotal = 0;
        double strInternationalCalc = 0;
        double strComisionInter = 0;
        string strJurisdiccion;
        string modoClaims;
        #endregion
        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region MetodosProgramados

        void actualizarStatusEndosos()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();

            if (endososClientePrincipal)
            {
                PolizaCliente[] aCambiarStatusClientePrincipal = (from x in db.PolizaCliente where x.Poliza == idPoliza && x.Activo == true && x.Principal == true select x).ToArray();
                if (aCambiarStatusClientePrincipal.Count() > 0)
                {
                    for (int i = 0; i < aCambiarStatusClientePrincipal.Count(); i++)
                    {
                        aCambiarStatusClientePrincipal[i].Activo = false;
                    }
                    db.SubmitChanges();
                }
            }

            if (endososClienteAdicional)
            {
                PolizaCliente[] aCambiarStatusClienteAdicional = (from x in db.PolizaCliente where x.Poliza == idPoliza && x.Activo == true && x.Principal == false select x).ToArray();
                if (aCambiarStatusClienteAdicional.Count() > 0)
                {
                    for (int i = 0; i < aCambiarStatusClienteAdicional.Count(); i++)
                    {
                        aCambiarStatusClienteAdicional[i].Activo = false;
                    }
                    db.SubmitChanges();
                }
            }

            if (endososCoberturas)
            {
                PolizaCobertura[] aCambiarStatusCoberturas = (from x in db.PolizaCobertura where x.Poliza == idPoliza && x.Activo == true select x).ToArray();
                if (aCambiarStatusCoberturas.Count() > 0)
                {
                    for (int i = 0; i < aCambiarStatusCoberturas.Count(); i++)
                    {
                        aCambiarStatusCoberturas[i].Activo = false;
                    }
                    db.SubmitChanges();
                }
            }

            if (endososEndososEmision)
            {
                PolizaEndosoEmision[] aCambiarStatusEndososEmision = (from x in db.PolizaEndosoEmision where x.Poliza == idPoliza && x.Activo == true select x).ToArray();
                if (aCambiarStatusEndososEmision.Count() > 0)
                {
                    for (int i = 0; i < aCambiarStatusEndososEmision.Count(); i++)
                    {
                        aCambiarStatusEndososEmision[i].Activo = false;
                    }
                    db.SubmitChanges();
                }
            }

            if (endososSublimites)
            {
                PolizaSublimites[] aCambiarStatusSublimites = (from x in db.PolizaSublimites where x.Poliza == idPoliza && x.Activo == true select x).ToArray();
                if (aCambiarStatusSublimites.Count() > 0)
                {
                    for (int i = 0; i < aCambiarStatusSublimites.Count(); i++)
                    {
                        aCambiarStatusSublimites[i].Activo = false;
                    }
                    db.SubmitChanges();
                }
            }

            if (endososDeducibles)
            {
                PolizaDeducible[] aCambiarStatusDeducibles = (from x in db.PolizaDeducible where x.Poliza == idPoliza && x.Activo == true select x).ToArray();
                if (aCambiarStatusDeducibles.Count() > 0)
                {
                    for (int i = 0; i < aCambiarStatusDeducibles.Count(); i++)
                    {
                        aCambiarStatusDeducibles[i].Activo = false;
                    }
                    db.SubmitChanges();
                }
            }

            if (endososExclusiones)
            {
                PolizaExclusion[] aCambiarStatusExclusiones = (from x in db.PolizaExclusion where x.Poliza == idPoliza && x.Activo == true select x).ToArray();
                if (aCambiarStatusExclusiones.Count() > 0)
                {
                    for (int i = 0; i < aCambiarStatusExclusiones.Count(); i++)
                    {
                        aCambiarStatusExclusiones[i].Activo = false;
                    }
                    db.SubmitChanges();
                }
            }

            if (endososCoaseguros)
            {
                PolizaCoaseguro[] aCambiarStatusCoaseguros = (from x in db.PolizaCoaseguro where x.Poliza == idPoliza && x.Activo == true select x).ToArray();
                if (aCambiarStatusCoaseguros.Count() > 0)
                {
                    for (int i = 0; i < aCambiarStatusCoaseguros.Count(); i++)
                    {
                        aCambiarStatusCoaseguros[i].Activo = false;
                    }
                    db.SubmitChanges();
                }
            }

            if (endososReaseguros)
            {
                PolizaReaseguro[] aCambiarStatusReaseguros = (from x in db.PolizaReaseguro where x.Poliza == idPoliza && x.Activo == true select x).ToArray();
                if (aCambiarStatusReaseguros.Count() > 0)
                {
                    for (int i = 0; i < aCambiarStatusReaseguros.Count(); i++)
                    {
                        aCambiarStatusReaseguros[i].Activo = false;
                    }
                    db.SubmitChanges();
                }
            }
        }

        void aplicarEndoso()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();

            PolizaCliente[] aCambiarStatusClientes = (from x in db.PolizaCliente where x.Poliza == idPoliza && x.Endoso == idEndoso select x).ToArray();
            if (aCambiarStatusClientes.Count() > 0)
            {
                for (int i = 0; i < aCambiarStatusClientes.Count(); i++)
                {
                    aCambiarStatusClientes[i].Activo = true;
                }
                db.SubmitChanges();
            }

            PolizaCobertura[] aCambiarStatusCoberturas = (from x in db.PolizaCobertura where x.Poliza == idPoliza && x.Endoso == idEndoso select x).ToArray();
            if (aCambiarStatusCoberturas.Count() > 0)
            {
                for (int i = 0; i < aCambiarStatusCoberturas.Count(); i++)
                {
                    aCambiarStatusCoberturas[i].Activo = true;
                }
                db.SubmitChanges();
            }

            PolizaEndosoEmision[] aCambiarStatusEndososEmision = (from x in db.PolizaEndosoEmision where x.Poliza == idPoliza && x.Endoso == idEndoso select x).ToArray();
            if (aCambiarStatusEndososEmision.Count() > 0)
            {
                for (int i = 0; i < aCambiarStatusEndososEmision.Count(); i++)
                {
                    aCambiarStatusEndososEmision[i].Activo = true;
                }
                db.SubmitChanges();
            }

            PolizaSublimites[] aCambiarStatusSublimites = (from x in db.PolizaSublimites where x.Poliza == idPoliza && x.Endoso == idEndoso select x).ToArray();
            if (aCambiarStatusSublimites.Count() > 0)
            {
                for (int i = 0; i < aCambiarStatusSublimites.Count(); i++)
                {
                    aCambiarStatusSublimites[i].Activo = true;
                }
                db.SubmitChanges();
            }

            PolizaDeducible[] aCambiarStatusDeducibles = (from x in db.PolizaDeducible where x.Poliza == idPoliza && x.Endoso == idEndoso select x).ToArray();
            if (aCambiarStatusDeducibles.Count() > 0)
            {
                for (int i = 0; i < aCambiarStatusDeducibles.Count(); i++)
                {
                    aCambiarStatusDeducibles[i].Activo = true;
                }
                db.SubmitChanges();
            }

            PolizaExclusion[] aCambiarStatusExclusiones = (from x in db.PolizaExclusion where x.Poliza == idPoliza && x.Endoso == idEndoso select x).ToArray();
            if (aCambiarStatusExclusiones.Count() > 0)
            {
                for (int i = 0; i < aCambiarStatusExclusiones.Count(); i++)
                {
                    aCambiarStatusExclusiones[i].Activo = true;
                }
                db.SubmitChanges();
            }

            PolizaCoaseguro[] aCambiarStatusCoaseguros = (from x in db.PolizaCoaseguro where x.Poliza == idPoliza && x.Endoso == idEndoso select x).ToArray();
            if (aCambiarStatusCoaseguros.Count() > 0)
            {
                for (int i = 0; i < aCambiarStatusCoaseguros.Count(); i++)
                {
                    aCambiarStatusCoaseguros[i].Activo = true;
                }
                db.SubmitChanges();
            }

            PolizaReaseguro[] aCambiarStatusReaseguros = (from x in db.PolizaReaseguro where x.Poliza == idPoliza && x.Endoso == idEndoso select x).ToArray();
            if (aCambiarStatusReaseguros.Count() > 0)
            {
                for (int i = 0; i < aCambiarStatusReaseguros.Count(); i++)
                {
                    aCambiarStatusReaseguros[i].Activo = true;
                }
                db.SubmitChanges();
            }
        }

        void borrarEndososPorError()
        {
            if (idEndoso != 0)
            {
                dbSmartGDataContext db = new dbSmartGDataContext();

                PolizaCliente[] aBorrarClientes = (from x in db.PolizaCliente where x.Endoso == idEndoso select x).ToArray();
                if (aBorrarClientes.Count() > 0)
                    db.PolizaCliente.DeleteAllOnSubmit(aBorrarClientes);

                PolizaCobertura[] aBorrarCoberturas = (from x in db.PolizaCobertura where x.Endoso == idEndoso select x).ToArray();
                if (aBorrarCoberturas.Count() > 0)
                    db.PolizaCobertura.DeleteAllOnSubmit(aBorrarCoberturas);

                PolizaEndosoEmision[] aBorrarEndososEmision = (from x in db.PolizaEndosoEmision where x.Endoso == idEndoso select x).ToArray();
                if (aBorrarEndososEmision.Count() > 0)
                    db.PolizaEndosoEmision.DeleteAllOnSubmit(aBorrarEndososEmision);

                PolizaSublimites[] aBorrarSublimites = (from x in db.PolizaSublimites where x.Endoso == idEndoso select x).ToArray();
                if (aBorrarSublimites.Count() > 0)
                    db.PolizaSublimites.DeleteAllOnSubmit(aBorrarSublimites);

                PolizaDeducible[] aBorrarDeducibles = (from x in db.PolizaDeducible where x.Endoso == idEndoso select x).ToArray();
                if (aBorrarDeducibles.Count() > 0)
                    db.PolizaDeducible.DeleteAllOnSubmit(aBorrarDeducibles);

                PolizaExclusion[] aBorrarExclusiones = (from x in db.PolizaExclusion where x.Endoso == idEndoso select x).ToArray();
                if (aBorrarExclusiones.Count() > 0)
                    db.PolizaExclusion.DeleteAllOnSubmit(aBorrarExclusiones);

                PolizaCoaseguro[] aBorrarCoaseguros = (from x in db.PolizaCoaseguro where x.Endoso == idEndoso select x).ToArray();
                if (aBorrarCoaseguros.Count() > 0)
                    db.PolizaCoaseguro.DeleteAllOnSubmit(aBorrarCoaseguros);

                PolizaReaseguro[] aBorrarReaseguros = (from x in db.PolizaReaseguro where x.Endoso == idEndoso select x).ToArray();
                if (aBorrarReaseguros.Count() > 0)
                    db.PolizaReaseguro.DeleteAllOnSubmit(aBorrarReaseguros);

                EndosoPoliza[] aBorrarEndososPoliza = (from x in db.EndosoPoliza where x.Endoso == idEndoso select x).ToArray();
                if (aBorrarEndososPoliza.Count() > 0)
                    db.EndosoPoliza.DeleteAllOnSubmit(aBorrarEndososPoliza);

                EndosoGeneral[] aBorrarEndosoGeneral = (from x in db.EndosoGeneral where x.Endoso == idEndoso select x).ToArray();
                if (aBorrarEndosoGeneral.Count() > 0)
                    db.EndosoGeneral.DeleteAllOnSubmit(aBorrarEndosoGeneral);

                Endoso aBorrarEndoso = (from x in db.Endoso where x.ID == idEndoso select x).SingleOrDefault();
                if (aBorrarEndoso != null)
                    db.Endoso.DeleteOnSubmit(aBorrarEndoso);
            }
            txtRetroValidaciones.Text += Environment.NewLine + "Cambios deshechos correctamente en la aplicación del endoso";

        }

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

                        PolizaSubCobertura[] aBorrarSubC = (from x in db.PolizaSubCobertura where x.Poliza == idPoliza select x).ToArray();
                        if (aBorrarSubC.Count() > 0)
                        {
                            db.PolizaSubCobertura.DeleteAllOnSubmit(aBorrarSubC);
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

                    case 8: // poliza liability producing
                        PolizaLiabilityProd aBorrarPoliLiaProd = (from x in db.PolizaLiabilityProd where x.PolizaLiability == idPolizaLia select x).SingleOrDefault();
                        if (aBorrarPoliLiaProd != null)
                        {
                            db.PolizaLiabilityProd.DeleteOnSubmit(aBorrarPoliLiaProd);
                            db.SubmitChanges();
                        }
                        break;

                    case 9:
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

        bool buscarCambiosPoliza(int save = 0)
        {
            bool hayCambios = false;
            polizaAnterior = "";
            polizaNuevo = "";

            for (int i = 0; i < dtControles.Rows.Count; i++)
            {
                string tipoControl = dtControles.Rows[i]["Tipo"].ToString();
                switch (tipoControl)
                {
                    case "int":
                        Infragistics.Win.UltraWinEditors.UltraNumericEditor controlInt = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)dtControles.Rows[i]["Control"];
                        dtControles.Rows[i]["Nuevo"] = controlInt.Value.ToString();
                        break;

                    case "string":
                        Control tmpControlS = (Control)dtControles.Rows[i]["Control"];
                        dtControles.Rows[i]["Nuevo"] = tmpControlS.Text;
                        break;

                    case "decimal":
                        //limiteMaximo.ToString("#,##0", new CultureInfo("en-US"))
                        Infragistics.Win.UltraWinEditors.UltraNumericEditor controlDecimal = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)dtControles.Rows[i]["Control"];
                        dtControles.Rows[i]["Nuevo"] = Convert.ToDecimal(controlDecimal.Value).ToString("#,##0", new CultureInfo("en-US"));
                        break;

                    case "bool":
                        Infragistics.Win.UltraWinEditors.UltraCheckEditor controlCheck = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)dtControles.Rows[i]["Control"];
                        dtControles.Rows[i]["Nuevo"] = controlCheck.Checked.ToString();
                        break;

                    case "date":
                        Infragistics.Win.UltraWinEditors.UltraDateTimeEditor controlFecha = (Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)dtControles.Rows[i]["Control"];
                        dtControles.Rows[i]["Nuevo"] = controlFecha.Value.ToString();
                        break;

                    case "double":
                        Infragistics.Win.UltraWinEditors.UltraNumericEditor controlDouble = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)dtControles.Rows[i]["Control"];
                        dtControles.Rows[i]["Nuevo"] = controlDouble.Value.ToString();
                        break;
                }
            }

            for (int i = 0; i < dtControles.Rows.Count; i++)
            {
                if (dtControles.Rows[i]["Anterior"].ToString() != dtControles.Rows[i]["Nuevo"].ToString())
                {
                    Control tmpControlS = (Control)dtControles.Rows[i]["Control"];

                    hayCambios = true;

                    if (!Convert.ToBoolean(dtControles.Rows[i]["InfoSchedule"].ToString()))
                    {
                        hayCambios = true;

                        if (polizaAnterior == "")
                        {
                            polizaAnterior = "- " + dtControles.Rows[i]["Campo"].ToString() + ":" + dtControles.Rows[i]["Anterior"].ToString();
                        }
                        else
                        {
                            polizaAnterior += Environment.NewLine + "- " + dtControles.Rows[i]["Campo"].ToString() + ":" + dtControles.Rows[i]["Anterior"].ToString();
                        }

                        if (polizaNuevo == "")
                        {
                            polizaNuevo = "- " + dtControles.Rows[i]["Campo"].ToString() + ":" + dtControles.Rows[i]["Nuevo"].ToString();
                        }
                        else
                        {
                            polizaNuevo += Environment.NewLine + "- " + dtControles.Rows[i]["Campo"].ToString() + ":" + dtControles.Rows[i]["Nuevo"].ToString();
                        }
                    }

                    if (save == 1 && !Convert.ToBoolean(dtControles.Rows[i]["InfoSchedule"].ToString()))
                        guardarEndosoPoliza(dtControles.Rows[i]["Anterior"].ToString(), dtControles.Rows[i]["Nuevo"].ToString(), tmpControlS.Name, dtControles.Rows[i]["Tipo"].ToString(), Convert.ToBoolean(dtControles.Rows[i]["InfoSchedule"].ToString()), dtControles.Rows[i]["Campo"].ToString());

                }
            }

            return hayCambios;
        }

        bool buscarCambiosClientePrincipal(int save = 0)
        {
            bool hayCambios = false;
            int? idTempClienteDir = 0;

            dbSmartGDataContext db = new dbSmartGDataContext();
            idTempClienteDir = (from x in db.PolizaCliente where x.Poliza == idPoliza && x.Principal == true && x.Activo == true select x.Direccion).SingleOrDefault();

            if (idTempClienteDir != Convert.ToInt32(cbDireccionRegistrada.Value))
            {
                hayCambios = true;
                if (save == 1)
                    guardarEndosoPolizaClientePrincipal();
            }

            return hayCambios;
        }

        bool buscarCambiosClientesAdicionales(int save = 0)
        {
            bool hayCambio = false;
            bool encontro = false;
            string tmpAsegurado = "";

            dbSmartGDataContext db = new dbSmartGDataContext();
            PolizaCliente[] tmpAseguradosAdicionales = (from x in db.PolizaCliente where x.Poliza == idPoliza && x.Principal == false && x.Activo == true select x).ToArray();

            if (tmpAseguradosAdicionales.Count() != dgAseguAdicionales.Rows.Count)
            {
                if (save == 1)
                    guardarEndosoPolizaClientesAdicionales();
                return true;
            }
            else
            {
                for (int i = 0; i < tmpAseguradosAdicionales.Count(); i++)
                {
                    tmpAsegurado = tmpAseguradosAdicionales[i].NombreAsegurado;
                    encontro = false;

                    for (int j = 0; j < dgAseguAdicionales.Rows.Count(); j++)
                    {
                        if (tmpAsegurado == dgAseguAdicionales.Rows[j].Cells["Asegurado Adicional"].Text)
                            encontro = true;
                    }

                    if (!encontro)
                    {
                        hayCambio = true;
                        if (save == 1)
                            guardarEndosoPolizaClientesAdicionales();
                        break;
                    }
                }

                return hayCambio;
            }
        }

        bool buscarCambiosCoberturas(int save = 0)
        {
            bool hayCambio = false;
            bool encontro = false;
            int? idTempCob = 0;
            dbSmartGDataContext db = new dbSmartGDataContext();

            PolizaCobertura[] coberturasPoliza = (from x in db.PolizaCobertura where x.Poliza == idPoliza && x.Activo == true select x).ToArray();

            if (coberturasPoliza.Count() != dgCoberturas.Rows.Count) // hay cambios porque son diferentes cantidades
            {
                for (int i = 0; i < coberturasPoliza.Count(); i++)
                {
                    if (i == 0)
                        coberturasAnterior = "- " + coberturasPoliza[i].Coberturas.Cobertura;
                    else
                        coberturasAnterior += Environment.NewLine + "- " + coberturasPoliza[i].Coberturas.Cobertura;
                }

                for (int i = 0; i < dgCoberturas.Rows.Count; i++)
                {
                    if (i == 0)
                        coberturasNuevo = "- " + dgCoberturas.Rows[i].Cells["Cobertura"].Text;
                    else
                        coberturasNuevo += Environment.NewLine + "- " + dgCoberturas.Rows[i].Cells["Cobertura"].Text;
                }

                if (save == 1)
                {
                    guardarEndosoPolizaCoberturas();

                    EndosoGeneral nuevoEndosoGeneral = new EndosoGeneral();
                    nuevoEndosoGeneral.Endoso = idEndoso;
                    nuevoEndosoGeneral.TipoCambio = "Cambio de Cobertura";
                    nuevoEndosoGeneral.Elemento = "Coberturas";
                    nuevoEndosoGeneral.ValorAnterior = coberturasAnterior;
                    nuevoEndosoGeneral.ValorNuevo = coberturasNuevo;
                    db.EndosoGeneral.InsertOnSubmit(nuevoEndosoGeneral);
                    db.SubmitChanges();
                }
                return true;
            }
            else
            {
                for (int i = 0; i < coberturasPoliza.Count(); i++)
                {
                    idTempCob = coberturasPoliza[i].Cobertura;
                    encontro = false;

                    for (int j = 0; j < dgCoberturas.Rows.Count; j++)
                    {
                        if (idTempCob == Convert.ToInt32(dgCoberturas.Rows[j].Cells["ID"].Text.ToString()))
                        {
                            encontro = true;
                        }
                    }

                    if (!encontro)
                    {
                        hayCambio = true;
                        for (int j = 0; j < coberturasPoliza.Count(); j++)
                        {
                            if (j == 0)
                                coberturasAnterior = "- " + coberturasPoliza[j].Coberturas.Cobertura;
                            else
                                coberturasAnterior += Environment.NewLine + "- " + coberturasPoliza[j].Coberturas.Cobertura;
                        }

                        for (int j = 0; j < dgCoberturas.Rows.Count; j++)
                        {
                            if (j == 0)
                                coberturasNuevo = "- " + dgCoberturas.Rows[j].Cells["Cobertura"].Text;
                            else
                                coberturasNuevo += Environment.NewLine + "- " + dgCoberturas.Rows[j].Cells["Cobertura"].Text;
                        }

                        if (save == 1)
                            guardarEndosoPolizaCoberturas();
                        break;
                    }
                }

                if (coberturasNuevo != "" || coberturasAnterior != "")
                {
                    EndosoGeneral nuevoEndosoGeneral = new EndosoGeneral();
                    nuevoEndosoGeneral.Endoso = idEndoso;
                    nuevoEndosoGeneral.TipoCambio = "Cambio de Cobertura";
                    nuevoEndosoGeneral.Elemento = "Coberturas";
                    nuevoEndosoGeneral.ValorAnterior = coberturasAnterior;
                    nuevoEndosoGeneral.ValorNuevo = coberturasNuevo;
                    db.EndosoGeneral.InsertOnSubmit(nuevoEndosoGeneral);
                    db.SubmitChanges();
                }

                return hayCambio;
            }
        }

        bool buscarCambiosEndososEmision(int save = 0)
        {
            bool hayCambio = false;
            int totalMarcadas = 0;
            bool encontro = false;
            int? idTempEndoso = 0;
            dbSmartGDataContext db = new dbSmartGDataContext();
            PolizaEndosoEmision[] endososEmisionPoliza = (from x in db.PolizaEndosoEmision where x.Poliza == idPoliza && x.Activo == true select x).ToArray();

            for (int i = 0; i < dgEndosos.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgEndosos.Rows[i].Cells["Aplica"].Value))
                    totalMarcadas++;
            }

            if (totalMarcadas != endososEmisionPoliza.Count())
            {
                if (save == 1)
                    guardarEndosoPolizaEndosoEmision();
                return true;
            }
            else
            {
                for (int i = 0; i < endososEmisionPoliza.Count(); i++)
                {
                    idTempEndoso = endososEmisionPoliza[i].EndosoEmision;
                    encontro = false;

                    for (int j = 0; j < dgEndosos.Rows.Count; j++)
                    {
                        if (idTempEndoso == Convert.ToInt32(dgEndosos.Rows[j].Cells["ID"].Text) && Convert.ToBoolean(dgEndosos.Rows[j].Cells["Aplica"].Value))
                        {
                            encontro = true;
                        }
                    }

                    if (!encontro)
                    {
                        hayCambio = true;
                        if (save == 1)
                            guardarEndosoPolizaEndosoEmision();
                        break;
                    }
                }

                return hayCambio;
            }
        }

        bool buscarCambiosSubLimites(int save = 0)
        {
            bool hayCambio = false;
            bool encontro = false;
            string sublimiteBusqueda = "";
            decimal? montoBusqueda = 0;
            dbSmartGDataContext db = new dbSmartGDataContext();
            PolizaSublimites[] sublimitesPoliza = (from x in db.PolizaSublimites where x.Poliza == idPoliza && x.Activo == true select x).ToArray();

            if (sublimitesPoliza.Count() != dgSublimites.Rows.Count)
            {
                if (save == 1)
                    guardarEndosoPolizaSublimites();
                return true;
            }
            else
            {
                for (int i = 0; i < sublimitesPoliza.Count(); i++)
                {
                    sublimiteBusqueda = sublimitesPoliza[i].SubLimite;
                    montoBusqueda = sublimitesPoliza[i].Monto;
                    encontro = false;

                    for (int j = 0; j < dgSublimites.Rows.Count; j++)
                    {
                        if ((sublimiteBusqueda == dgSublimites.Rows[j].Cells["Sublimite"].Text) && (montoBusqueda == Convert.ToDecimal(dgSublimites.Rows[j].Cells["Monto"].Text)))
                        {
                            encontro = true;
                        }
                    }

                    if (!encontro)
                    {
                        hayCambio = true;
                        if (save == 1)
                            guardarEndosoPolizaSublimites();
                        break;
                    }
                }

                return hayCambio;
            }
        }

        bool buscarCambiosDeducibles(int save = 0)
        {
            bool hayCambio = false;
            bool encontro = false;
            string deducibleBusqueda = "";
            decimal? porcentajeBusqueda = 0;
            decimal? minimoBusqueda = 0;
            decimal? maximoBusqueda = 0;
            bool? SIRBusqueda;
            decimal? agregadoBusqueda = 0;
            dbSmartGDataContext db = new dbSmartGDataContext();
            PolizaDeducible[] deduciblesPoliza = (from x in db.PolizaDeducible where x.Poliza == idPoliza && x.Activo == true select x).ToArray();

            if (deduciblesPoliza.Count() != dgDeducibles.Rows.Count)
            {
                if (save == 1)
                    guardarEndosoPolizaDeducibles();
                return true;
            }
            else
            {
                for (int i = 0; i < deduciblesPoliza.Count(); i++)
                {
                    deducibleBusqueda = deduciblesPoliza[i].Deducible;
                    porcentajeBusqueda = deduciblesPoliza[i].Porcentaje;
                    minimoBusqueda = deduciblesPoliza[i].Minimo;
                    maximoBusqueda = deduciblesPoliza[i].Maximo;
                    SIRBusqueda = deduciblesPoliza[i].SIR;
                    agregadoBusqueda = deduciblesPoliza[i].Agregado;

                    for (int j = 0; j < dgDeducibles.Rows.Count; j++)
                    {
                        if (deducibleBusqueda == dgDeducibles.Rows[j].Cells["Deducible"].Text && porcentajeBusqueda == Convert.ToDecimal(dgDeducibles.Rows[j].Cells["Porcentaje"].Text)
                            && minimoBusqueda == Convert.ToDecimal(dgDeducibles.Rows[j].Cells["Minimo"].Text) && maximoBusqueda == Convert.ToDecimal(dgDeducibles.Rows[j].Cells["Maximo"].Text)
                            && SIRBusqueda == Convert.ToBoolean(dgDeducibles.Rows[j].Cells["SIR"].Value) && agregadoBusqueda == Convert.ToDecimal(dgDeducibles.Rows[j].Cells["Agregado"].Text))
                        {
                            encontro = true;
                        }
                    }

                    if (!encontro)
                    {
                        hayCambio = true;
                        if (save == 1)
                            guardarEndosoPolizaDeducibles();
                        break;
                    }
                }
                return hayCambio;
            }
        }

        bool buscarCambiosExclusiones(int save = 0)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            bool hayCambio = false;
            string textoCompara = "";

            PolizaExclusion buscaPoliExclu = (from x in db.PolizaExclusion where x.Poliza == idPoliza && x.Activo == true select x).FirstOrDefault();
            Exclusiones buscaExclusion = (from x in db.Exclusiones where x.ID == buscaPoliExclu.Exclusion select x).SingleOrDefault();
            if (buscaExclusion != null)
            {
                try
                {
                    textoCompara = txtExclusiones.Rtf;
                }
                catch
                {
                    textoCompara = txtExclusiones.Text;
                }

                if (textoCompara != buscaExclusion.Exclusion)
                {
                    hayCambio = true;
                }
            }
            else
                hayCambio = true;

            if (save == 1 && hayCambio)
                guardarEndosoPolizaExclusion();

            return hayCambio;
        }

        bool buscarCambiosInfoSchedule(int save = 0)
        {
            bool hayCambios = false;
            endososIsInfoSchedule = false;
            for (int i = 0; i < dtControles.Rows.Count; i++)
            {
                string tipoControl = dtControles.Rows[i]["Tipo"].ToString();

                switch (tipoControl)
                {
                    case "int":
                        Infragistics.Win.UltraWinEditors.UltraNumericEditor controlInt = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)dtControles.Rows[i]["Control"];
                        dtControles.Rows[i]["Nuevo"] = controlInt.Value.ToString();
                        break;

                    case "string":
                        Control tmpControlS = (Control)dtControles.Rows[i]["Control"];
                        dtControles.Rows[i]["Nuevo"] = tmpControlS.Text;
                        break;

                    case "decimal":
                        Infragistics.Win.UltraWinEditors.UltraNumericEditor controlDecimal = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)dtControles.Rows[i]["Control"];
                        dtControles.Rows[i]["Nuevo"] = controlDecimal.Value.ToString();
                        break;

                    case "bool":
                        Infragistics.Win.UltraWinEditors.UltraCheckEditor controlCheck = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)dtControles.Rows[i]["Control"];
                        dtControles.Rows[i]["Nuevo"] = controlCheck.Checked.ToString();
                        break;

                    case "date":
                        Infragistics.Win.UltraWinEditors.UltraDateTimeEditor controlFecha = (Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)dtControles.Rows[i]["Control"];
                        dtControles.Rows[i]["Nuevo"] = controlFecha.Value.ToString();
                        break;

                    case "double":
                        Infragistics.Win.UltraWinEditors.UltraNumericEditor controlDouble = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)dtControles.Rows[i]["Control"];
                        dtControles.Rows[i]["Nuevo"] = controlDouble.Value.ToString();
                        break;
                }
            }

            for (int i = 0; i < dtControles.Rows.Count; i++)
            {
                if (dtControles.Rows[i]["Anterior"].ToString() != dtControles.Rows[i]["Nuevo"].ToString())
                {
                    Control tmpControlS = (Control)dtControles.Rows[i]["Control"];

                    if (Convert.ToBoolean(dtControles.Rows[i]["InfoSchedule"].ToString()))
                    {
                        endososIsInfoSchedule = true;
                        hayCambios = true;
                    }

                    if (save == 1 && Convert.ToBoolean(dtControles.Rows[i]["InfoSchedule"].ToString()))
                        guardarEndosoInfoScheduleDetalle(dtControles.Rows[i]["Anterior"].ToString(), dtControles.Rows[i]["Nuevo"].ToString(), tmpControlS.Name, dtControles.Rows[i]["Tipo"].ToString(), Convert.ToBoolean(dtControles.Rows[i]["InfoSchedule"].ToString()), dtControles.Rows[i]["Campo"].ToString());
                }
            }

            if (save == 1 && hayCambios)
            {
                guardarEndosoInfoSchedule();
            }

            return hayCambios;
        }

        bool buscarCambiosTexto(int save = 0)
        {
            bool hayCambio = false;

            if (txtTextoLibre.Text != "")
                hayCambio = true;
            else
                hayCambio = false;

            if (save == 1)
                guardarEndosoPoliza("", txtTextoLibre.Text, "txtTextoLibre", "string", false, "Texto Libre");

            return hayCambio;
        }

        void calcularBrokerage()
        {
            double tmpPrima = 0;
            if (ventana == 1 || ventana == 0)
                tmpPrima = Convert.ToDouble(txtPrimaMain.Value);
            else
                tmpPrima = Convert.ToDouble(Math.Abs(Convert.ToDouble(txtPrimaEndoso.Value)));

            double tmpPorcBrokerage = Convert.ToDouble(txtBrokeragePorc.Value) / 100;
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
            if (tmpDescuentos <= tmpPrima)
            {
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
            else
            {
                txtDescuentos.Value = 0;
            }
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

        void cambiarControles()
        {
            if (ventana == 2)
            {
                ToolsBarLiabilityProd.Ribbon.Tabs[0].Groups[0].Tools[0].SharedProps.Caption = "Guardar Endoso";
                ToolsBarLiabilityProd.Ribbon.Tabs[0].Groups[0].Tools[2].SharedProps.Enabled = false;
                ToolsBarLiabilityProd.Ribbon.Tabs[0].Groups[3].Tools[1].SharedProps.Enabled = false;
                txtPolizaMX.Enabled = false;
                txtPolizaES.Enabled = false;
                txtQuoteNumber.Enabled = false;
                cbMoneda.Enabled = false;
                cbPrograma.Enabled = false;
                dateInicioVig.Enabled = false;
                dateEmision.Enabled = false;
                cbAseguradoMain.Enabled = false;
                cbEstructuraLimite.Enabled = false;
                grpTipoCambio.Enabled = false;
                txtTipoPoliza.Enabled = false;
                cbFormaPago.Enabled = false;
                cbIVA.Enabled = false;
                txtNumPagos.Enabled = false;
                txtRecFraccionado.Enabled = false;
                txtDescuentos.Enabled = false;
                tabControlLiability.Tabs[7].Visible = false;
                tabControlLiability.Tabs[8].Visible = false;
                tabControlLiability.Tabs[9].Visible = true;
                lbPrimaEndoso.Text = "Prima a sumar/restar";
                lbPrimaEndoso.Visible = true;
                txtPrimaEndoso.Visible = true;
                lbPrima.Text = "Prima c/Endosos";
                txtPrimaMain.Enabled = false;
                dbSmartGDataContext db = new dbSmartGDataContext();
                DateTime minValueDate = Convert.ToDateTime((from x in db.Poliza where x.ID == idPoliza select x.FinVig).SingleOrDefault());
                dateFinVigencia.MinDate = minValueDate;
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
            if (ventana != 2)
            {
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
            else
            {
                cbAseguradoMain.Value = (from x in db.PolizaCliente where x.Poliza == idPoliza && x.Principal == true && x.Activo == true select x.Cliente).SingleOrDefault();
                cbDireccionRegistrada.Value = (from x in db.PolizaCliente where x.Poliza == idPoliza && x.Principal == true && x.Activo == true select x.Direccion).SingleOrDefault();
                direccionAnterior = cbDireccionRegistrada.Text;
                PolizaCliente[] aseguAdicionales = (from x in db.PolizaCliente where x.Poliza == idPoliza && x.Principal == false && x.Activo == true select x).ToArray();
                if (aseguAdicionales.Count() > 0)
                {
                    for (int i = 0; i < aseguAdicionales.Count(); i++)
                    {
                        dtAseguradosAdicionales.Rows.Add(aseguAdicionales[i].NombreAsegurado);
                    }
                }
            }

            if(dgAseguAdicionales.Rows.Count > 0)
                dgAseguAdicionales.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
        }

        void cargarCoberturas()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            int?[] idCoberturas = null;
            if (ventana != 2)
                idCoberturas = (from x in db.PolizaCobertura where x.Poliza == idPoliza select x.Cobertura).ToArray();
            else 
                idCoberturas = (from x in db.PolizaCobertura where x.Poliza == idPoliza && x.Activo == true select x.Cobertura).ToArray();

            string[] descripciones = (from x in db.PolizaCobertura where x.Poliza == idPoliza select x.Descripcion).ToArray();

            if (idCoberturas.Count() > 0)
            {
                dsCoberturas.Tables[0].Clear();
                dsCoberturasDB.Tables[0].Clear();
                DataTable dtTemp2 = liIncCoberturasDBTableAdapter.GetDataByTodosDB(Liability, Origen);
                for (int i = 0; i < dtTemp2.Rows.Count; i++)
                {
                    dsCoberturasDB.Tables[0].Rows.Add(Convert.ToInt32(dtTemp2.Rows[i]["ID"].ToString()), Liability, dtTemp2.Rows[i]["Cobertura"].ToString(), 
                        dtTemp2.Rows[i]["CoberturaIngles"].ToString(), dtTemp2.Rows[i]["GeniusCode"].ToString(), Convert.ToBoolean(dtTemp2.Rows[i]["Defecto"].ToString()), Convert.ToBoolean(dtTemp2.Rows[i]["userAdd"].ToString()), 
                        Convert.ToBoolean(dtTemp2.Rows[i]["Eliminado"].ToString()),Origen);
                }

                bool encontro = false;
                for (int i = 0; i < idCoberturas.Count(); i++)
                {
                    encontro = false;
                    for (int j = 0; j < dgCoberturasDB.Rows.Count; j++)
                    {
                        if (idCoberturas[i] == Convert.ToInt32(dgCoberturasDB.Rows[j].Cells["ID"].Text.ToString()))
                        {
                            dsCoberturas.Tables[0].Rows.Add(Convert.ToInt32(dgCoberturasDB.Rows[j].Cells["ID"].Text.ToString()),
                           Liability, dgCoberturasDB.Rows[j].Cells["Cobertura"].Text.ToString(), dgCoberturasDB.Rows[j].Cells["CoberturaIngles"].Text.ToString(),
                           dgCoberturasDB.Rows[j].Cells["GeniusCode"].Text.ToString(), Convert.ToBoolean(dgCoberturasDB.Rows[j].Cells["Defecto"].Text),
                           Convert.ToBoolean(dgCoberturasDB.Rows[j].Cells["userAdd"].Text), Convert.ToBoolean(dgCoberturasDB.Rows[j].Cells["Eliminado"].Text), Origen);

                            dsCoberturasDB.Tables[0].Rows.RemoveAt(dgCoberturasDB.Rows[j].Index);
                            encontro = true;
                        }
                    }

                    if (!encontro)
                    {
                        Coberturas cobTMP = (from x in db.Coberturas where x.ID == idCoberturas[i] select x).SingleOrDefault();
                        dsCoberturas.Tables[0].Rows.Add(cobTMP.ID, Liability, cobTMP.Cobertura, cobTMP.CoberturaIngles, cobTMP.GeniusCode, cobTMP.Defecto, cobTMP.userAdd, cobTMP.Eliminado, Origen);
                    }

                    dgCoberturas.Rows[i].Cells["Descripcion"].Value = descripciones[i];
                }
            }
            expandirGrids();

            txtRetroValidaciones.Text += Environment.NewLine + "2) Coberturas cargadas satisfactoriamente";
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

        void cargarEndososPoliza()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            Endoso[] endososPoliza = (from x in db.Endoso where x.Poliza == idPoliza orderby x.ID ascending select x).ToArray();
            if (endososPoliza.Count() > 0)
            {
                for (int j = 0; j < endososPoliza.Count(); j++)
                {
                    EndosoPoliza[] cambiar = (from x in db.EndosoPoliza where x.Endoso == endososPoliza[j].ID select x).ToArray();
                    if (cambiar.Count() > 0)
                    {
                        for (int i = 0; i < cambiar.Count(); i++)
                        {
                            Control[] ctrl = this.Controls.Find(cambiar[i].Control, true);
                            if (ctrl.Count() > 0)
                            {
                                string tipoControl = cambiar[i].TipoControl;
                                switch (tipoControl)
                                {
                                    case "int":
                                        Infragistics.Win.UltraWinEditors.UltraNumericEditor controlInt = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)ctrl[0];
                                        controlInt.Value = Convert.ToInt32(cambiar[i].ValorNuevo);
                                        break;

                                    case "string":
                                        ctrl[0].Text = cambiar[i].ValorNuevo;
                                        break;

                                    case "decimal":
                                        Infragistics.Win.UltraWinEditors.UltraNumericEditor controlDecimal = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)ctrl[0];
                                        controlDecimal.Value = Convert.ToDecimal(cambiar[i].ValorNuevo);
                                        break;

                                    case "bool":
                                        Infragistics.Win.UltraWinEditors.UltraCheckEditor controlCheck = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)ctrl[0];
                                        controlCheck.Checked = Convert.ToBoolean(cambiar[i].ValorNuevo);
                                        break;

                                    case "date":
                                        Infragistics.Win.UltraWinEditors.UltraDateTimeEditor controlFecha = (Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)ctrl[0];
                                        controlFecha.Value = Convert.ToDateTime(cambiar[i].ValorNuevo);
                                        break;

                                    case "double":
                                        Infragistics.Win.UltraWinEditors.UltraNumericEditor controlDouble = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)ctrl[0];
                                        controlDouble.Value = Convert.ToDouble(cambiar[i].ValorNuevo);
                                        break;
                                }
                            }
                        }
                        txtPrimaMain_Leave(null, null);
                    }
                }
            }
        }

        void cargarExclusiones()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            int? idExclusion = null;
            if(ventana != 2)
                idExclusion = (from x in db.PolizaExclusion where x.Poliza == idPoliza select x.Exclusion).SingleOrDefault();
            else
                idExclusion = (from x in db.PolizaExclusion where x.Poliza == idPoliza && x.Activo == true select x.Exclusion).SingleOrDefault();

            if (idExclusion != null)
            {
                try
                {
                    txtExclusiones.Rtf = (from x in db.Exclusiones where x.ID == idExclusion select x.Exclusion).SingleOrDefault();
                }
                catch
                {
                    txtExclusiones.Text = (from x in db.Exclusiones where x.ID == idExclusion select x.Exclusion).SingleOrDefault();
                }

                if (txtExclusiones.Text != "")
                    chkExclusiones.Checked = true;
            }
            txtRetroValidaciones.Text += Environment.NewLine + "5) Exclusiones Cargadas satisfactoriamente";
        }

        void cargarDeducibles()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            PolizaDeducible[] deducibles = null;
            if(ventana != 2)
                deducibles = (from x in db.PolizaDeducible where x.Poliza == idPoliza select x).ToArray();
            else
                deducibles = (from x in db.PolizaDeducible where x.Poliza == idPoliza && x.Activo == true select x).ToArray();

            if (deducibles.Count() > 0)
            {
                chkDeducibles.Checked = true;
                dtDeducibles.Rows.Clear();
                for (int i = 0; i < deducibles.Count(); i++)
                {
                    dtDeducibles.Rows.Add(deducibles[i].Deducible, deducibles[i].GeniusCode, deducibles[i].Porcentaje, deducibles[i].Minimo, deducibles[i].Maximo, deducibles[i].SIR, deducibles[i].Agregado, deducibles[i].Descripcion);
                }
            }
            dgDeducibles.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            txtRetroValidaciones.Text += Environment.NewLine + "4) Deducibles Cargados satisfactoriamente";
        }

        void cargarInfoSchedule()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            if (ventana != 2)
            {
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
            }
            else
            {
                InfoSchedule infoOriginal = (from x in db.InfoSchedule where x.Poliza == idPoliza && x.Endoso == null select x).SingleOrDefault();
                InfoSchedule[] infoAumento = (from x in db.InfoSchedule where x.Poliza == idPoliza && x.TipoEndoso == "A" select x).ToArray();
                InfoSchedule[] infoReduccion = (from x in db.InfoSchedule where x.Poliza == idPoliza && x.TipoEndoso == "D" select x).ToArray();

                decimal? primaOriginal = infoOriginal.Prima;
                decimal? primaAumento = 0;
                decimal? primaReduccion = 0;

                if (infoAumento.Count() > 0)
                {
                    for (int i = 0; i < infoAumento.Count(); i++)
                    {
                        primaAumento += infoAumento[i].Prima;
                    }
                }

                if (infoReduccion.Count() > 0)
                {
                    for (int i = 0; i < infoReduccion.Count(); i++)
                    {
                        primaReduccion += infoReduccion[i].Prima;
                    }
                }

                primaOriginal = primaOriginal + primaAumento - primaReduccion;
                primaAnterior = Convert.ToDecimal(primaOriginal);

                cbFormaPago.Value = infoOriginal.FormaPago;
                txtPrimaMain.Value = primaOriginal;
                txtPrimaNeta.Value = primaOriginal;
                cbIVA.Text = infoOriginal.IVA;
                if (infoOriginal.isBrokerage != null)
                {
                    if (Convert.ToBoolean(infoOriginal.isBrokerage))
                    {
                        chkIsBrokerage.Checked = true;
                        txtBrokeragePorc.Value = infoOriginal.PorcentajeBrokerage;
                    }
                }
                cbTipoPrima.Text = infoOriginal.TipoPrima;
                txtTurnOver.Value = infoOriginal.TurnOver;
                txtTipoPoliza.Text = infoOriginal.TipoPoliza;
                txtNumPagos.Value = infoOriginal.NumeroPagos;
                txtObservaciones.Text = infoOriginal.Observaciones;
                txtDescuentos.Value = infoOriginal.Descuentos;
                txtRecFraccionado.Value = infoOriginal.RecargoFraccionado;
                calcularPrimaTotal();
                calcularBrokerage();
            }

            txtRetroValidaciones.Text += Environment.NewLine + "7) Prima Cargada satisfactoriamente";
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
            txtInformacionRiesgo.Text = tmpPoliza.InformacionReaseguro;
            txtRetroValidaciones.Text += "1) Datos Generales cargados satisfactoriamente";

            PolizaLiability tmpPolizaLia = (from y in db.PolizaLiability where y.Poliza == idPoliza select y).SingleOrDefault();
            if (tmpPolizaLia != null)
            {
                idPolizaLia = tmpPolizaLia.ID;

                if (tmpPolizaLia.Retroactivo != null)
                {
                    if (Convert.ToBoolean(tmpPolizaLia.Retroactivo))
                    {
                        chkRetroactiva.Checked = true;
                        dateRetroactiva.Value = tmpPolizaLia.FechaRetroactivo;
                    }
                }
                if (tmpPolizaLia.Ajustable != null)
                {
                    if (Convert.ToBoolean(tmpPolizaLia.Ajustable))
                        chkAjustable.Checked = true;
                }
                cbAggregationPL.Value = tmpPolizaLia.AggregationPL;
                cbAggregationPR.Value = tmpPolizaLia.AggregationPR;
                cbEstructuraLimite.Text = tmpPolizaLia.EstructuraLimite;
                cbGastosDefensa.Text = tmpPolizaLia.GastosDefensa;
                txtSujecion.Value = tmpPolizaLia.Sujecion;
                txtGastosDefensa.Value = tmpPolizaLia.PorcentajeLimite;
                cbPrograma.Value = tmpPolizaLia.Programa;
            }

            PolizaLiabilityProd tmpPoliLiaProd = (from x in db.PolizaLiabilityProd where x.PolizaLiability == idPolizaLia select x).SingleOrDefault();
            if (tmpPoliLiaProd != null)
            {
                txtQuoteNumber.Text = tmpPoliLiaProd.QuoteNumber;
                cbJurisdiccion.Text = tmpPoliLiaProd.Jurisdiccion;
                txtJurisOtro.Text = tmpPoliLiaProd.JurisdiccionOtro;
                try
                {
                    txtInteresAsegurable.Rtf = tmpPoliLiaProd.InteresAsegurable;
                }
                catch
                {
                    txtInteresAsegurable.Text = tmpPoliLiaProd.InteresAsegurable;
                }
                txtUbicacion.Text = tmpPoliLiaProd.UbicacionRiesgo;
                txtBaseCalculo.Text = tmpPoliLiaProd.BaseCalculo;
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

        void cargarSublimites()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            PolizaSublimites[] sublimites = null;
            if(ventana != 2)
                sublimites = (from x in db.PolizaSublimites where x.Poliza == idPoliza select x).ToArray();
            else
                sublimites = (from x in db.PolizaSublimites where x.Poliza == idPoliza && x.Activo == true select x).ToArray();

            if (sublimites.Count() > 0)
            {
                chkSublimites.Checked = true;
                dtSublimites.Rows.Clear();
                for (int i = 0; i < sublimites.Count(); i++)
                {
                    dtSublimites.Rows.Add(sublimites[i].SubLimite, sublimites[i].Monto, sublimites[i].Descripcion);
                }
            }

            dgSublimites.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            txtRetroValidaciones.Text += Environment.NewLine + "3) Sublimites Cargados satisfactoriamente";
        }

        void expandirGrids()
        {
            dgCoberturas.DisplayLayout.Bands[0].Columns["Descripcion"].Hidden = false;
            dgCoberturasDB.DisplayLayout.Bands[1].Columns["SubCobertura"].Width = 600;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in dgCoberturas.Rows)
            {
                if (!row.HasChild())
                {
                    row.ExpandAll();
                }
            }

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in dgCoberturasDB.Rows)
            {
                if (!row.HasChild())
                {
                    row.ExpandAll();
                }
            }
        }

        string formatearFecha(DateTime fecha, int tipoFormato)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            if (tipoFormato == 1) // fecha y hora
                return fecha.ToString("dd") + " de " + fecha.ToString("MMMM") + " de " + fecha.ToString("yyyy") + " a las " + fecha.ToString("HH:mm:ss");
            else
                return fecha.ToString("dd") + " de " + fecha.ToString("MMMM") + " de " + fecha.ToString("yyyy");
        }

        void generarEndoso(string file, int tipo, int idEndosoImprimir = 0)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();

            #region Busqueda de informacion

            #region Declaración de variables y búsquedas

            if (txtObservaciones.Text == "")
                txtObservaciones.Text = "Según especificación adjunta";

            PolizaCobertura[] coberturasEndosoAntes;
            PolizaCobertura[] coberturasEndosoDespues;
            PolizaDeducible[] deduciblesEndosoAntes;
            PolizaDeducible[] deduciblesEndosoDespues;
            PolizaSublimites[] sublimitesEndosoAntes;
            PolizaSublimites[] sublimitesEndosoDespues;

            Endoso[] endososConsulta = (from x in db.Endoso where x.Poliza == idPoliza orderby x.ID descending select x).ToArray();

            if (endososConsulta.Count() == 1)
            {
                coberturasEndosoAntes = (from x in db.PolizaCobertura where x.Endoso == null && x.Poliza == idPoliza select x).ToArray();
                coberturasEndosoDespues = (from x in db.PolizaCobertura where x.Endoso == idEndoso select x).ToArray();

                deduciblesEndosoAntes = (from x in db.PolizaDeducible where x.Endoso == null && x.Poliza == idPoliza select x).ToArray();
                deduciblesEndosoDespues = (from x in db.PolizaDeducible where x.Endoso == idEndoso select x).ToArray();

                sublimitesEndosoAntes = (from x in db.PolizaSublimites where x.Endoso == null && x.Poliza == idPoliza select x).ToArray();
                sublimitesEndosoDespues = (from x in db.PolizaSublimites where x.Endoso == idEndoso select x).ToArray();
            }
            else
            {
                int? idtmpConsultas = (from x in db.PolizaCobertura where x.Endoso != idEndoso orderby x.Endoso descending select x.Endoso).FirstOrDefault();

                coberturasEndosoAntes = (from x in db.PolizaCobertura where x.Endoso == idtmpConsultas select x).ToArray();
                coberturasEndosoDespues = (from x in db.PolizaCobertura where x.Endoso == idEndoso select x).ToArray();

                idtmpConsultas = (from x in db.PolizaDeducible where x.Endoso != idEndoso orderby x.Endoso descending select x.Endoso).FirstOrDefault();

                deduciblesEndosoAntes = (from x in db.PolizaDeducible where x.Endoso == idtmpConsultas select x).ToArray();
                deduciblesEndosoDespues = (from x in db.PolizaDeducible where x.Endoso == idEndoso select x).ToArray();

                idtmpConsultas = (from x in db.PolizaSublimites where x.Endoso != idEndoso orderby x.Endoso descending select x.Endoso).FirstOrDefault();

                sublimitesEndosoAntes = (from x in db.PolizaSublimites where x.Endoso == idtmpConsultas select x).ToArray();
                sublimitesEndosoDespues = (from x in db.PolizaSublimites where x.Endoso == idEndoso select x).ToArray();
            }

            string strCoberturasAgregadas = "";
            string strCoberturasEliminadas = "";
            string strDeduciblesAgregados = "";
            string strDeduciblesEliminados = "";
            string strDeduciblesModificadosA = "";
            string strDeduciblesModificadosD = "";
            string strSublimitesAgregados = "";
            string strSublimitesEliminados = "";
            string strSublimitesModificadosA = "";
            string strSublimitesModificadosB = "";

            #endregion

            #region Coberturas

            if (coberturasEndosoDespues.Count() > 0)
            {
                // evaluamos los eliminados
                for (int i = 0; i < coberturasEndosoAntes.Count(); i++)
                {
                    bool encontroCobertura = false;

                    for (int j = 0; j < coberturasEndosoDespues.Count(); j++)
                    {
                        if (coberturasEndosoAntes[i].Cobertura == coberturasEndosoDespues[j].Cobertura)
                        {
                            encontroCobertura = true;
                        }
                    }

                    if (!encontroCobertura)
                    {
                        strCoberturasEliminadas += coberturasEndosoAntes[i].Coberturas.Cobertura + " " + coberturasEndosoAntes[i].Descripcion + Environment.NewLine;
                    }
                }

                // evaluamos los agregados
                for (int i = 0; i < coberturasEndosoDespues.Count(); i++)
                {
                    bool encontroCobertura = false;

                    for (int j = 0; j < coberturasEndosoAntes.Count(); j++)
                    {
                        if (coberturasEndosoDespues[i].Cobertura == coberturasEndosoAntes[j].Cobertura)
                        {
                            encontroCobertura = true;
                        }
                    }

                    if (!encontroCobertura)
                    {
                        strCoberturasAgregadas += coberturasEndosoDespues[i].Coberturas.Cobertura + " " + coberturasEndosoDespues[i].Descripcion + Environment.NewLine;
                    }
                }
            }

            #endregion

            #region Deducibles

            if (deduciblesEndosoDespues.Count() > 0)
            {
                // evaluamos los eliminados y modificados
                for (int i = 0; i < deduciblesEndosoAntes.Count(); i++)
                {
                    bool encontroDeducible = false;

                    for (int j = 0; j < deduciblesEndosoDespues.Count(); j++)
                    {
                        // si los deducibles son iguales se evaluan sus atributos y se determina si hubo modificación
                        if (deduciblesEndosoAntes[i].Deducible == deduciblesEndosoDespues[j].Deducible)
                        {
                            encontroDeducible = true;
                            if (deduciblesEndosoAntes[i].Porcentaje != deduciblesEndosoDespues[j].Porcentaje || deduciblesEndosoAntes[i].Minimo != deduciblesEndosoDespues[j].Minimo
                                || deduciblesEndosoAntes[i].Maximo != deduciblesEndosoDespues[j].Maximo || deduciblesEndosoAntes[i].SIR != deduciblesEndosoDespues[j].SIR
                                || deduciblesEndosoAntes[i].Agregado != deduciblesEndosoDespues[j].Agregado)
                            {
                                strDeduciblesModificadosA += deduciblesEndosoAntes[i].Deducible + " " + deduciblesEndosoAntes[i].Descripcion + " con un porcentaje de " + double.Parse(deduciblesEndosoAntes[i].Porcentaje.ToString()).ToString("#,##0", new CultureInfo("en-US")) +
                            " %, mínimo de " + double.Parse(deduciblesEndosoAntes[i].Minimo.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon +
                            " , máximo de " + double.Parse(deduciblesEndosoAntes[i].Maximo.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon +
                            " y agregado de " + double.Parse(deduciblesEndosoAntes[i].Agregado.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + Environment.NewLine;

                                strDeduciblesModificadosD += deduciblesEndosoDespues[j].Deducible + " " + deduciblesEndosoDespues[j].Descripcion + " con un porcentaje de " + double.Parse(deduciblesEndosoDespues[j].Porcentaje.ToString()).ToString("#,##0", new CultureInfo("en-US")) +
                            " %, mínimo de " + double.Parse(deduciblesEndosoDespues[j].Minimo.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon +
                            " , máximo de " + double.Parse(deduciblesEndosoDespues[j].Maximo.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon +
                            " y agregado de " + double.Parse(deduciblesEndosoDespues[j].Agregado.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + Environment.NewLine;
                            }
                        }
                    }

                    if (!encontroDeducible)
                    {
                        strDeduciblesEliminados += deduciblesEndosoAntes[i].Deducible + " " + deduciblesEndosoAntes[i].Descripcion + Environment.NewLine;
                    }
                }

                // evaluamos los agregados
                for (int i = 0; i < deduciblesEndosoDespues.Count(); i++)
                {
                    bool encontroDeducible = false;

                    for (int j = 0; j < deduciblesEndosoAntes.Count(); j++)
                    {
                        if (deduciblesEndosoDespues[i].Deducible == deduciblesEndosoAntes[j].Deducible)
                        {
                            encontroDeducible = true;
                        }
                    }

                    if (!encontroDeducible)
                    {
                        strDeduciblesAgregados += deduciblesEndosoDespues[i].Deducible + " " + deduciblesEndosoDespues[i].Descripcion + " con un porcentaje de " + double.Parse(deduciblesEndosoDespues[i].Porcentaje.ToString()).ToString("#,##0", new CultureInfo("en-US")) +
                            " %, mínimo de " + double.Parse(deduciblesEndosoDespues[i].Minimo.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon +
                            " , máximo de " + double.Parse(deduciblesEndosoDespues[i].Maximo.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon +
                            " y agregado de " + double.Parse(deduciblesEndosoDespues[i].Agregado.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + Environment.NewLine;
                    }
                }
            }

            #endregion

            #region Sublímites

            if (sublimitesEndosoDespues.Count() > 0)
            {
                // evaluamos los eliminados
                for (int i = 0; i < sublimitesEndosoAntes.Count(); i++)
                {
                    bool encontroSublimite = false;

                    for (int j = 0; j < sublimitesEndosoDespues.Count(); j++)
                    {
                        if (sublimitesEndosoAntes[i].SubLimite == sublimitesEndosoDespues[j].SubLimite)
                        {
                            encontroSublimite = true;
                            if (sublimitesEndosoAntes[i].Monto != sublimitesEndosoDespues[j].Monto)
                            {
                                strSublimitesModificadosA += sublimitesEndosoAntes[i].SubLimite + " " + sublimitesEndosoAntes[i].Descripcion + " con un monto de " + double.Parse(sublimitesEndosoAntes[i].Monto.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + Environment.NewLine;

                                strSublimitesModificadosB += sublimitesEndosoDespues[j].SubLimite + " " + sublimitesEndosoDespues[j].Descripcion +  " con un monto de " + double.Parse(sublimitesEndosoDespues[j].Monto.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + Environment.NewLine;
                            }
                        }
                    }

                    if (!encontroSublimite)
                    {
                        strSublimitesEliminados += sublimitesEndosoAntes[i].SubLimite + " " + sublimitesEndosoAntes[i].Descripcion + Environment.NewLine;
                    }
                }

                // evaluamos los agregados
                for (int i = 0; i < sublimitesEndosoDespues.Count(); i++)
                {
                    bool encontroSublimite = false;

                    for (int j = 0; j < sublimitesEndosoAntes.Count(); j++)
                    {
                        if (sublimitesEndosoDespues[i].SubLimite == sublimitesEndosoAntes[j].SubLimite)
                        {
                            encontroSublimite = true;
                        }
                    }

                    if (!encontroSublimite)
                    {
                        strSublimitesAgregados += sublimitesEndosoDespues[i].SubLimite + " " + sublimitesEndosoDespues[i].Descripcion + " con un monto de " + double.Parse(sublimitesEndosoDespues[i].Monto.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + Environment.NewLine;
                    }
                }
            }

            #endregion

            #region Prima
            if (tipoEndosoG == "A")
                infoPrima = "Se aumentó la prima por un monto de " + double.Parse(Convert.ToDouble(txtPrimaEndoso.Value).ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + Environment.NewLine;
            else if (tipoEndosoG == "D")
                infoPrima = "Se disminuyó la prima por un monto de " + double.Parse((Convert.ToDouble(txtPrimaEndoso.Value) * -1).ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + Environment.NewLine;
            #endregion

            #endregion


            if (tipo == 1)
            {
                txtRetroValidaciones.Text += Environment.NewLine + "Comienzo de creación de previo del endoso. por favor espere...";
            }
            else
            {
                txtRetroValidaciones.Text += Environment.NewLine + "Comienzo de creación del endoso. por favor espere...";
            }

            string outputFile = "C:\\SmartG\\" + file; // FIX
            object m = System.Reflection.Missing.Value;
            object readOnly = (object)false;
            Word.Application ac = null;
            ac = new Word.Application();
            Word.Document doc = ac.Documents.Open(outputFile, m, readOnly,
                  m, m, m, m, m, m, m, m, m, m, m, m, m);
            //ac.Visible = true;

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
                bookmarkName = "Endoso";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["Endoso"].Start;
                    object finB = doc.Bookmarks["Endoso"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    if (idEndosoImprimir == 0)
                        ac.Selection.TypeText("PREVIO");
                    else
                        ac.Selection.TypeText(idEndosoImprimir.ToString().PadLeft(3, '0') + "-" + tipoEndosoG);
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
                    ac.Selection.TypeText(Convert.ToDouble(txtPrimaEndoso.Value).ToString("#,##0.00", new CultureInfo("en-US")));
                }
                bookmarkName = "prima2";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["prima2"].Start;
                    object finB = doc.Bookmarks["prima2"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(Convert.ToDouble(txtPrimaEndoso.Value).ToString("#,##0.00", new CultureInfo("en-US")));
                }
                bookmarkName = "descuentos";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["descuentos"].Start;
                    object finB = doc.Bookmarks["descuentos"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(Convert.ToDouble(txtGastosExpedicion.Value).ToString("#,##0.00", new CultureInfo("en-US")));
                }
                bookmarkName = "recargos";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["recargos"].Start;
                    object finB = doc.Bookmarks["recargos"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(Convert.ToDouble(txtGastosExpedicion.Value).ToString("#,##0.00", new CultureInfo("en-US")));
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
                    ac.Selection.TypeText(Convert.ToDouble(Convert.ToDouble(txtPrimaEndoso.Value) * 0.16).ToString("#,##0.00", new CultureInfo("en-US")));
                }
                bookmarkName = "total";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["total"].Start;
                    object finB = doc.Bookmarks["total"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(Convert.ToDouble(Convert.ToDouble(txtPrimaEndoso.Value) * 1.16).ToString("#,##0.00", new CultureInfo("en-US")));
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

                #region Detalles
                bookmarkName = "EndosoGeneral";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["EndosoGeneral"].Start;
                    object finB = doc.Bookmarks["EndosoGeneral"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    int fila = 1;
                    Word.Table tabla = doc.Tables.Add(rng, 1, 2);
                    if (polizaAnterior != "" || polizaNuevo != "")
                    {
                        tabla.Rows[fila].Cells[1].Merge(tabla.Rows[fila].Cells[2]);
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Se actualizaron los valores para los siguientes datos:" + Environment.NewLine); fila++;
                        tabla.Rows.Add();

                        tabla.Cell(fila, 1).Select(); tabla.Rows[fila].Cells[1].Split(1, 2); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Valores Anteriores");
                        tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Valores Nuevos" + Environment.NewLine); fila++;
                        tabla.Rows.Add();
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 0; ac.Selection.TypeText(polizaAnterior);
                        tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 0; ac.Selection.TypeText(polizaNuevo + Environment.NewLine); fila++;
                        tabla.Rows.Add();
                    }
                    if (infoPrima != "")
                    {
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Se modificó la prima:" + Environment.NewLine); fila++;
                        tabla.Rows.Add();
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 0; ac.Selection.TypeText(infoPrima); fila++;
                        tabla.Rows.Add();
                    }
                    if (strCoberturasAgregadas != "")
                    {
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Se agregaron las coberturas:" + Environment.NewLine); fila++;
                        tabla.Rows.Add();
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 0; ac.Selection.TypeText(strCoberturasAgregadas); fila++;
                        tabla.Rows.Add();
                    }
                    if (strCoberturasEliminadas != "")
                    {
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Se eliminaron las coberturas:" + Environment.NewLine); fila++;
                        tabla.Rows.Add();
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 0; ac.Selection.TypeText(strCoberturasEliminadas); fila++;
                        tabla.Rows.Add();
                    }
                    if (strDeduciblesAgregados != "")
                    {
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Se agregaron los deducibles:" + Environment.NewLine); fila++;
                        tabla.Rows.Add();
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 0; ac.Selection.TypeText(strDeduciblesAgregados); fila++;
                        tabla.Rows.Add();
                    }
                    if (strDeduciblesEliminados != "")
                    {
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Se eliminaron los deducibles:" + Environment.NewLine); fila++;
                        tabla.Rows.Add();
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 0; ac.Selection.TypeText(strDeduciblesEliminados); fila++;
                        tabla.Rows.Add();
                    }
                    if (strDeduciblesModificadosA != "" || strDeduciblesModificadosD != "")
                    {
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Se actualizaron los deducibles:" + Environment.NewLine); fila++;
                        tabla.Rows.Add();
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Valores Anteriores");
                        tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Valores Nuevos" + Environment.NewLine); fila++;
                        tabla.Rows.Add();
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 0; ac.Selection.TypeText(strDeduciblesModificadosA);
                        tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 0; ac.Selection.TypeText(strDeduciblesModificadosD + Environment.NewLine); fila++;
                        tabla.Rows.Add();
                    }
                    if (strSublimitesAgregados != "")
                    {
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Se agregaron los sublímites:" + Environment.NewLine); fila++;
                        tabla.Rows.Add();
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 0; ac.Selection.TypeText(strSublimitesAgregados); fila++;
                        tabla.Rows.Add();
                    }
                    if (strSublimitesEliminados != "")
                    {
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Se eliminaron los sublímites:" + Environment.NewLine); fila++;
                        tabla.Rows.Add();
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 0; ac.Selection.TypeText(strSublimitesEliminados); fila++;
                        tabla.Rows.Add();
                    }
                    if (strSublimitesModificadosA != "" || strSublimitesModificadosB != "")
                    {
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Se actualizaron los sublímites:" + Environment.NewLine); fila++;
                        tabla.Rows.Add();
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Valores Anteriores");
                        tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Valores Nuevos" + Environment.NewLine); fila++;
                        tabla.Rows.Add();
                        tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 0; ac.Selection.TypeText(strSublimitesModificadosA);
                        tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 0; ac.Selection.TypeText(strSublimitesModificadosB + Environment.NewLine); fila++;
                        tabla.Rows.Add();
                    }
                    if (txtTextoLibre.Text != "")
                    {
                        tabla.Rows[fila].Cells[1].Merge(tabla.Rows[fila].Cells[2]);
                        bool tipoTexto = false;
                        try
                        { Clipboard.SetText(txtTextoLibre.Rtf, TextDataFormat.Rtf); tipoTexto = true; }
                        catch
                        { Clipboard.SetText(txtTextoLibre.Text, TextDataFormat.Text); tipoTexto = false; }
                        if (tipoTexto)
                        { tabla.Cell(fila, 1).Select(); ac.Selection.PasteAndFormat(Word.Enums.WdRecoveryType.wdFormatOriginalFormatting); fila++; }
                        else
                        { tabla.Cell(fila, 1).Select(); ac.Selection.TypeText(Clipboard.GetText(TextDataFormat.Text) + Environment.NewLine); fila++; }
                        tabla.Rows.Add();
                    }

                }
                #endregion

                #region Remplazar booleanos True
                object inicioR = doc.Content.Start;
                object finR = doc.Content.End;
                Word.Range rngR = doc.Range(inicioR, finR);
                rngR.Select();

                Word.Find encuentra = ac.Selection.Find;
                encuentra.Text = "True";
                encuentra.Replacement.ClearFormatting();
                encuentra.Replacement.Text = "Aplica";
                object remplaza = Word.Enums.WdReplace.wdReplaceAll;

                encuentra.Execute(m, m, m, m, m, m, m, m, m, m, remplaza, m, m, m, m);
                #endregion

                #region Remplazar booleanos False
                object iniciof = doc.Content.Start;
                object finf = doc.Content.End;
                Word.Range rngf = doc.Range(iniciof, finf);
                rngf.Select();

                Word.Find encuentraf = ac.Selection.Find;
                encuentraf.Text = "False";
                encuentraf.Replacement.ClearFormatting();
                encuentraf.Replacement.Text = "No Aplica";
                object remplazaF = Word.Enums.WdReplace.wdReplaceAll;

                encuentraf.Execute(m, m, m, m, m, m, m, m, m, m, remplazaF, m, m, m, m);
                #endregion


                // generamos el documento
                string outputFilePDF;
                string outputFileWord;
                string bloquea = "";
                if (tipo == 1)
                {
                    outputFilePDF = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\Previews\Preview_" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_Endoso_" + polizaMX + ".pdf";
                    outputFileWord = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\Previews\Preview_" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_Endoso_" + polizaMX + ".docx";
                    Directory.CreateDirectory(Path.GetDirectoryName(outputFilePDF));
                }
                else
                {
                    outputFilePDF = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_Endoso_" + polizaMX + ".pdf";
                    outputFileWord = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_Endoso_" + polizaMX + ".docx";
                    Directory.CreateDirectory(Path.GetDirectoryName(outputFilePDF));
                }
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
                MessageBox.Show("Ocurrió un error al generar el Endoso, favor de contactar al soporte técnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                controlSave = false;
            }
        }

        public int guardarAvances()
        {
            // codigos de errores
            // 0 = guardado Correcto
            // 1 = error en la creación de la póliza, falta el MX
            // 2 = error en la creación de la póliza, MX ya registrado
            // 3 = error en la creación de la póliza, error no controlado al generarla
            // 4 = error en poliza liability
            // 5 = error en poliza liability
            // 6 = error en coberturas
            // 7 = error en endosos emision
            // 8 = error en sublimites
            // 9 = error en deducibles
            // 10 = error en exclusiones
            // 11 = error en info schedule
            // 12 = error en clientes
            // 13 = error en coaseguro
            // 14 = error en reaseguro

            int codigoVuelta = 0;

            if (ventana == 0 || ventana == 1) // caso de pólizas nuevas / a continuar
            {
                if (txtPolizaMX.Text != "")
                {
                    if (validarPoliza(txtPolizaMX))
                    {
                        guardarVariables();
                        bool tmpContinuarSave = guardarPoliza();
                        if (tmpContinuarSave)
                        {
                            if (guardarPolizaLiability())
                            {
                                if (guardarPolizaLiabilityProducing())
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
                                                                        codigoVuelta = 14;
                                                                    }
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
                            for (int i = 0; i < 10; i++)
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

        int guardarEndosos()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            bool primerSave = false;
            // intentamos guardar el endoso, si funciona guardamos los detalles en póliza y en general
            Endoso nuevoEndoso = new Endoso();
            try
            {
                nuevoEndoso.Usuario = Program.Globals.UserID;
                nuevoEndoso.Poliza = idPoliza;
                nuevoEndoso.Fecha = DateTime.Now;
                nuevoEndoso.Consecutivo = consecutivoAnteriorEndoso;
                db.Endoso.InsertOnSubmit(nuevoEndoso);
                db.SubmitChanges();

                idEndoso = nuevoEndoso.ID;
                primerSave = true;
            }
            catch
            {
                txtRetroValidaciones.Text += Environment.NewLine + "Ocurrió un error al generar el endoso (primer guardado).";
                MessageBox.Show("Ocurrió un error al generar el endoso, favor de contactar al soporte técnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return 0;
            }

            // se generó el endoso correctamente, procedemos a crear los registros en la tabla póliza y general
            if (primerSave == true)
            {
                try
                {
                    // guardamos todos los componentes para ese endoso uno por uno
                    string tipoEndoso = "B";
                    int statusEndoso = 2;
                    int contadorModificadores = 0;

                    if (buscarCambiosPoliza(1)) contadorModificadores++;
                    txtRetroValidaciones.Text += Environment.NewLine + "Detalles del endoso guardados satisfactoriamente.";
                    // guardamos al asegurado
                    if (buscarCambiosClientePrincipal(1)) contadorModificadores++;

                    // guardamos los asegurados adicionales
                    if (buscarCambiosClientesAdicionales(1)) contadorModificadores++;

                    // guardamos las coberturas
                    if (buscarCambiosCoberturas(1)) contadorModificadores++;

                    // guardamos los endosos emision
                    if (buscarCambiosEndososEmision(1)) contadorModificadores++;

                    // guardamos los sublimites
                    if (buscarCambiosSubLimites(1)) contadorModificadores++;

                    // guardamos los deducibles
                    if (buscarCambiosDeducibles(1)) contadorModificadores++;

                    // guardamos las exclusiones
                    if (buscarCambiosExclusiones(1)) contadorModificadores++;

                    // procesamos el texto
                    if (buscarCambiosTexto(1)) contadorModificadores++;

                    if (endososIsInfoSchedule)
                    {
                        statusEndoso = 1;
                        if (Convert.ToDecimal(txtPrimaEndoso.Value) > 0)
                            tipoEndoso = "A";
                        else
                            tipoEndoso = "D";

                        tipoEndosoG = tipoEndoso;
                        // guardamos la info schedule
                        buscarCambiosInfoSchedule(1);

                        // cambiamos el status de la info schedule
                        InfoSchedule[] aCambiarStatusInfoSchedule = (from x in db.InfoSchedule where x.Poliza == idPoliza && x.Activo == true select x).ToArray();
                        if (aCambiarStatusInfoSchedule.Count() > 0)
                        {
                            for (int i = 0; i < aCambiarStatusInfoSchedule.Count(); i++)
                            {
                                aCambiarStatusInfoSchedule[i].Activo = false;
                            }
                            db.SubmitChanges();
                        }

                        // aplicamos el endoso
                        InfoSchedule[] aplicarInfoSchedule = (from x in db.InfoSchedule where x.Poliza == idPoliza && x.Endoso == idEndoso select x).ToArray();
                        if (aplicarInfoSchedule.Count() > 0)
                        {
                            for (int i = 0; i < aplicarInfoSchedule.Count(); i++)
                            {
                                aplicarInfoSchedule[i].Activo = true;
                            }
                            db.SubmitChanges();
                        }
                    }

                    tipoEndosoG = tipoEndoso;
                    nuevoEndoso.Tipo = tipoEndoso;
                    nuevoEndoso.Status = statusEndoso; // el endoso de tipo B nace autorizado
                    if (statusEndoso == 2)
                    {
                        nuevoEndoso.UsuarioAutoriza = Program.Globals.UserID;
                        nuevoEndoso.fechaAutorizacion = DateTime.Now;
                    }

                    db.SubmitChanges(); // guardamos los cambios de nuevo

                    // actualizamos los status de lo ingresado
                    actualizarStatusEndosos();

                    // paso final, activamos los endosos
                    aplicarEndoso();

                    if (tipoEndoso == "B")
                    {
                        if (MessageBox.Show("¿Deseas que este endoso genere documentos para entregar al cliente?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            return 1;
                        else
                            return 2;
                    }
                    else
                        return 3;
                }
                catch (Exception ex)
                {
                    borrarEndososPorError();
                    txtRetroValidaciones.Text += Environment.NewLine + "Ocurrió un error al generar los detalles del endoso (segundo guardado)." + Environment.NewLine + ex.ToString();
                    MessageBox.Show("Ocurrió un error al generar el endoso, favor de contactar al soporte técnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return 0;
                }
            }
            else
                return 0;
        }

        void guardarEndosoInfoSchedule()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            decimal nuevaPrimaEndoso = Convert.ToDecimal(Math.Abs(Convert.ToDecimal(txtPrimaEndoso.Value)));

            // registramos los nuevos valores
            InfoSchedule nuevaInfo = new InfoSchedule();
            nuevaInfo.Poliza = idPoliza;
            nuevaInfo.Endoso = idEndoso;
            nuevaInfo.FormaPago = formaPago;
            nuevaInfo.Prima = nuevaPrimaEndoso;
            nuevaInfo.IVA = IVA;
            nuevaInfo.isBrokerage = isBrokerage;
            nuevaInfo.PorcentajeBrokerage = porcBrokerage;
            nuevaInfo.Comision = comisionTotalBrokerage;
            nuevaInfo.TipoPrima = tipoPrima;
            nuevaInfo.TurnOver = turnOver;
            nuevaInfo.TipoPoliza = tipoPoliza;
            nuevaInfo.NumeroPagos = numeroPagos;
            nuevaInfo.Observaciones = observaciones;
            nuevaInfo.Descuentos = 0;
            nuevaInfo.RecargoFraccionado = 0;
            nuevaInfo.GastosExpedicion = 0;
            nuevaInfo.IVAmonto = nuevaPrimaEndoso * Convert.ToDecimal(0.16);
            nuevaInfo.TotalPoliza = nuevaPrimaEndoso + (nuevaPrimaEndoso * Convert.ToDecimal(0.16));
            nuevaInfo.TipoEndoso = tipoEndosoG;
            db.InfoSchedule.InsertOnSubmit(nuevaInfo);
            db.SubmitChanges();
        }

        void guardarEndosoInfoScheduleDetalle(string valorAnterior, string valorNuevo, string control, string tipoControl, bool isInfoSchedule, string campo)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();

            EndosoGeneral nuevoEndosoGeneral = new EndosoGeneral();
            nuevoEndosoGeneral.Endoso = idEndoso;
            nuevoEndosoGeneral.TipoCambio = "Actualización de valor";
            nuevoEndosoGeneral.Elemento = campo;
            nuevoEndosoGeneral.ValorAnterior = valorAnterior;
            nuevoEndosoGeneral.ValorNuevo = valorNuevo;
            db.EndosoGeneral.InsertOnSubmit(nuevoEndosoGeneral);
            db.SubmitChanges();
        }

        void guardarEndosoPoliza(string valorAnterior, string valorNuevo, string control, string tipoControl, bool isInfoSchedule, string campo)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            EndosoPoliza nuevoEndosoPoliza = new EndosoPoliza();
            nuevoEndosoPoliza.Endoso = idEndoso;
            nuevoEndosoPoliza.ValorAnterior = valorAnterior;
            nuevoEndosoPoliza.ValorNuevo = valorNuevo;
            nuevoEndosoPoliza.Control = control;
            nuevoEndosoPoliza.TipoControl = tipoControl;
            nuevoEndosoPoliza.InfoSchedule = isInfoSchedule;
            nuevoEndosoPoliza.Campo = campo;
            db.EndosoPoliza.InsertOnSubmit(nuevoEndosoPoliza);
            db.SubmitChanges();

            EndosoGeneral nuevoEndosoGeneral = new EndosoGeneral();
            nuevoEndosoGeneral.Endoso = idEndoso;
            nuevoEndosoGeneral.TipoCambio = "Actualización de valor";
            nuevoEndosoGeneral.Elemento = campo;
            nuevoEndosoGeneral.ValorAnterior = valorAnterior;
            nuevoEndosoGeneral.ValorNuevo = valorNuevo;
            db.EndosoGeneral.InsertOnSubmit(nuevoEndosoGeneral);
            db.SubmitChanges();
        }

        void guardarEndosoPolizaClientePrincipal()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();

            // registramos los nuevos valores
            PolizaCliente nuevoCliente = new PolizaCliente();
            nuevoCliente.Poliza = idPoliza;
            nuevoCliente.Cliente = aseguradoPrincipal;
            nuevoCliente.Principal = true;
            nuevoCliente.Direccion = direccionAseguradoPrincipal;
            nuevoCliente.Endoso = idEndoso;
            db.PolizaCliente.InsertOnSubmit(nuevoCliente);

            EndosoGeneral nuevoEndosoGeneral = new EndosoGeneral();
            nuevoEndosoGeneral.Endoso = idEndoso;
            nuevoEndosoGeneral.TipoCambio = "Cambio en la dirección del asegurado principal";
            nuevoEndosoGeneral.Elemento = "Poliza";
            nuevoEndosoGeneral.ValorAnterior = direccionAnterior;
            nuevoEndosoGeneral.ValorNuevo = cbDireccionRegistrada.Text;
            db.EndosoGeneral.InsertOnSubmit(nuevoEndosoGeneral);
            endososClientePrincipal = true;
            db.SubmitChanges();

        }

        void guardarEndosoPolizaClientesAdicionales()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();

            PolizaCliente clienteAdi = new PolizaCliente();

            for (int i = 0; i < dgAseguAdicionales.Rows.Count; i++)
            {
                clienteAdi = new PolizaCliente();
                clienteAdi.Poliza = idPoliza;
                clienteAdi.Principal = false;
                clienteAdi.Endoso = idEndoso;
                clienteAdi.NombreAsegurado = dgAseguAdicionales.Rows[i].Cells["Asegurado Adicional"].Text.ToString();
                db.PolizaCliente.InsertOnSubmit(clienteAdi);

                EndosoGeneral nuevoEndosoGeneral = new EndosoGeneral();
                nuevoEndosoGeneral.Endoso = idEndoso;
                nuevoEndosoGeneral.TipoCambio = "Se registró un nuevo asegurado adicional";
                nuevoEndosoGeneral.Elemento = "Poliza";
                nuevoEndosoGeneral.ValorAnterior = "-";
                nuevoEndosoGeneral.ValorNuevo = dgAseguAdicionales.Rows[i].Cells["Asegurado Adicional"].Text;
                db.EndosoGeneral.InsertOnSubmit(nuevoEndosoGeneral);
                db.SubmitChanges();
                endososClienteAdicional = true;
            }
        }

        void guardarEndosoPolizaCoberturas()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();

            // registramos los nuevos valores
            for (int i = 0; i < dgCoberturas.Rows.Count; i++)
            {
                PolizaCobertura nuevaCobertura = new PolizaCobertura();
                nuevaCobertura.Poliza = idPoliza;
                nuevaCobertura.OrdenImpresion = i;
                nuevaCobertura.Endoso = idEndoso;
                nuevaCobertura.Descripcion = dgCoberturas.Rows[i].Cells["Descripcion"].Text.ToString();
                if (Convert.ToInt32(dgCoberturas.Rows[i].Cells["ID"].Text.ToString()) < 0)
                {
                    Coberturas nuevaCoberturaDB = new Coberturas();
                    nuevaCoberturaDB.LineaNegocios = Liability;
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
            endososCoberturas = true;
            txtRetroValidaciones.Text += Environment.NewLine + "Coberturas guardados satisfactoriamente.";
        }

        void guardarEndosoPolizaEndosoEmision()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();

            // registramos los nuevos valores
            for (int i = 0; i < dgEndosos.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgEndosos.Rows[i].Cells["Aplica"].Value))
                {
                    PolizaEndosoEmision nuevaPolizaEndoso = new PolizaEndosoEmision();
                    nuevaPolizaEndoso.Poliza = idPoliza;
                    nuevaPolizaEndoso.EndosoEmision = Convert.ToInt32(dgEndosos.Rows[i].Cells["ID"].Text);
                    nuevaPolizaEndoso.Texto = "";
                    nuevaPolizaEndoso.Endoso = idEndoso;
                    db.PolizaEndosoEmision.InsertOnSubmit(nuevaPolizaEndoso);

                    EndosoGeneral nuevoEndosoGeneral = new EndosoGeneral();
                    nuevoEndosoGeneral.Endoso = idEndoso;
                    nuevoEndosoGeneral.TipoCambio = "Cambio de Endoso Emisión";
                    nuevoEndosoGeneral.Elemento = "Endosos Emisión";
                    nuevoEndosoGeneral.ValorAnterior = "-";
                    nuevoEndosoGeneral.ValorNuevo = dgEndosos.Rows[i].Cells["Endoso"].Text;
                    db.EndosoGeneral.InsertOnSubmit(nuevoEndosoGeneral);

                    db.SubmitChanges();
                }
            }

            if (dgEndosos.Rows.Count == 0)
            {
                EndosoGeneral nuevoEndosoGeneral = new EndosoGeneral();
                nuevoEndosoGeneral.Endoso = idEndoso;
                nuevoEndosoGeneral.TipoCambio = "Usuario Eliminó todos los Endosos de Emisión";
                nuevoEndosoGeneral.Elemento = "Endosos Emisión";
                nuevoEndosoGeneral.ValorAnterior = "-";
                nuevoEndosoGeneral.ValorNuevo = "-";
                db.EndosoGeneral.InsertOnSubmit(nuevoEndosoGeneral);
                db.SubmitChanges();
            }

            endososEndososEmision = true;
            txtRetroValidaciones.Text += Environment.NewLine + "Endosos Emisión guardados satisfactoriamente.";
        }

        void guardarEndosoPolizaSublimites()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();

            if (chkSublimites.Checked)
            {
                // registramos los nuevos valores
                for (int i = 0; i < dgSublimites.Rows.Count; i++)
                {
                    PolizaSublimites nuevaPolizaSub = new PolizaSublimites();
                    nuevaPolizaSub.Poliza = idPoliza;
                    nuevaPolizaSub.SubLimite = dgSublimites.Rows[i].Cells["Sublimite"].Text.ToString();
                    nuevaPolizaSub.Monto = Convert.ToDecimal(dgSublimites.Rows[i].Cells["Monto"].Text.ToString());
                    nuevaPolizaSub.Endoso = idEndoso;
                    nuevaPolizaSub.Descripcion = dgSublimites.Rows[i].Cells["Descripcion"].Text.ToString();
                    db.PolizaSublimites.InsertOnSubmit(nuevaPolizaSub);

                    EndosoGeneral nuevoEndosoGeneral = new EndosoGeneral();
                    nuevoEndosoGeneral.Endoso = idEndoso;
                    nuevoEndosoGeneral.TipoCambio = "Cambio de Sublímite";
                    nuevoEndosoGeneral.Elemento = "Sublímites";
                    nuevoEndosoGeneral.ValorAnterior = "-";
                    nuevoEndosoGeneral.ValorNuevo = dgSublimites.Rows[i].Cells["Sublimite"].Text.ToString();
                    db.EndosoGeneral.InsertOnSubmit(nuevoEndosoGeneral);

                    db.SubmitChanges();

                }
            }

            else
            {
                EndosoGeneral nuevoEndosoGeneral = new EndosoGeneral();
                nuevoEndosoGeneral.Endoso = idEndoso;
                nuevoEndosoGeneral.TipoCambio = "Usuario Eliminó todos los sublímites de la póliza";
                nuevoEndosoGeneral.Elemento = "Sublímites";
                nuevoEndosoGeneral.ValorAnterior = "-";
                nuevoEndosoGeneral.ValorNuevo = "-";
                db.EndosoGeneral.InsertOnSubmit(nuevoEndosoGeneral);
                db.SubmitChanges();
            }

            endososSublimites = true;
            txtRetroValidaciones.Text += Environment.NewLine + "Sublímites guardados satisfactoriamente.";
        }

        void guardarEndosoPolizaDeducibles()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();

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
                    nuevaPoliDedu.Descripcion = dgDeducibles.Rows[i].Cells["Descripcion"].Text.ToString();
                    nuevaPoliDedu.Endoso = idEndoso;
                    db.PolizaDeducible.InsertOnSubmit(nuevaPoliDedu);

                    EndosoGeneral nuevoEndosoGeneral = new EndosoGeneral();
                    nuevoEndosoGeneral.Endoso = idEndoso;
                    nuevoEndosoGeneral.TipoCambio = "Cambio de Deducibles";
                    nuevoEndosoGeneral.Elemento = "Deducibles";
                    nuevoEndosoGeneral.ValorAnterior = "-";
                    nuevoEndosoGeneral.ValorNuevo = dgDeducibles.Rows[i].Cells["Deducible"].Text.ToString();
                    db.EndosoGeneral.InsertOnSubmit(nuevoEndosoGeneral);

                    db.SubmitChanges();
                }
            }

            else
            {
                EndosoGeneral nuevoEndosoGeneral = new EndosoGeneral();
                nuevoEndosoGeneral.Endoso = idEndoso;
                nuevoEndosoGeneral.TipoCambio = "Usuario Eliminó todos los deducibles de la póliza";
                nuevoEndosoGeneral.Elemento = "Deducibles";
                nuevoEndosoGeneral.ValorAnterior = "-";
                nuevoEndosoGeneral.ValorNuevo = "-";
                db.EndosoGeneral.InsertOnSubmit(nuevoEndosoGeneral);
                db.SubmitChanges();
            }

            endososDeducibles = true;
            txtRetroValidaciones.Text += Environment.NewLine + "Deducibles guardados satisfactoriamente.";
        }

        void guardarEndosoPolizaExclusion()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            PolizaExclusion buscaPoliExclu = (from x in db.PolizaExclusion where x.Poliza == idPoliza && x.Activo == true select x).FirstOrDefault();
            Exclusiones buscaExclusion = (from x in db.Exclusiones where x.ID == buscaPoliExclu.Exclusion select x).SingleOrDefault();
            //if (buscaExclusion != null)
            //{
            //    // cancelamos la anterior poliza exclusion
            //    buscaPoliExclu.Activo = false;
            //    db.SubmitChanges();
            //}

            // creamos la nueva exclusión
            Exclusiones nuevaExclusion = new Exclusiones();
            nuevaExclusion.LineaNegocios = Liability;
            nuevaExclusion.userAdd = true;
            nuevaExclusion.Eliminado = false;
            try { nuevaExclusion.Exclusion = txtExclusiones.Rtf; }
            catch { nuevaExclusion.Exclusion = txtExclusiones.Text; }
            db.Exclusiones.InsertOnSubmit(nuevaExclusion);
            db.SubmitChanges();

            // creamos la nueva póliza exclusión
            PolizaExclusion nuevaPoliExclu = new PolizaExclusion();
            nuevaPoliExclu.Poliza = idPoliza;
            nuevaPoliExclu.Exclusion = nuevaExclusion.ID;
            nuevaPoliExclu.Endoso = idEndoso;
            //nuevaPoliExclu.Activo = true;
            db.PolizaExclusion.InsertOnSubmit(nuevaPoliExclu);
            db.SubmitChanges();

            // guardamos en el log
            EndosoGeneral nuevoEndosoGeneral = new EndosoGeneral();
            nuevoEndosoGeneral.Endoso = idEndoso;
            if (txtExclusiones.Text != "")
                nuevoEndosoGeneral.TipoCambio = "Cambio de Exclusiones";
            else
                nuevoEndosoGeneral.TipoCambio = "Usuario eliminó las Exclusiones";

            nuevoEndosoGeneral.Elemento = "Exclusiones";
            if (buscaExclusion != null)
                nuevoEndosoGeneral.ValorAnterior = buscaExclusion.Exclusion.ToString();
            else
                nuevoEndosoGeneral.ValorAnterior = "-";
            nuevoEndosoGeneral.ValorNuevo = nuevaExclusion.Exclusion.ToString();
            db.EndosoGeneral.InsertOnSubmit(nuevoEndosoGeneral);
            db.SubmitChanges();

            endososExclusiones = true;
            txtRetroValidaciones.Text += Environment.NewLine + "Exclusiones guardados satisfactoriamente.";
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
                nuevaPoliza.LineaNegocios = Liability;
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

        bool guardarPolizaLiability()
        {
            try
            {
                bool tmpAgregar = false;
                dbSmartGDataContext db = new dbSmartGDataContext();
                PolizaLiability nuevaPolizaLia = (from x in db.PolizaLiability where x.Poliza == idPoliza select x).SingleOrDefault();
                if (nuevaPolizaLia == null)
                {
                    nuevaPolizaLia = new PolizaLiability();
                    nuevaPolizaLia.Poliza = idPoliza;
                    tmpAgregar = true;
                }
                nuevaPolizaLia.Retroactivo = retroactiva;
                nuevaPolizaLia.FechaRetroactivo = fechaRetroactiva;
                nuevaPolizaLia.Ajustable = ajustable;
                nuevaPolizaLia.AggregationPL = aggregationPL;
                nuevaPolizaLia.AggregationPR = aggregationPR;
                nuevaPolizaLia.EstructuraLimite = estructuraLimite;
                nuevaPolizaLia.GastosDefensa = gastosDefensa;
                nuevaPolizaLia.Sujecion = sujecion;
                nuevaPolizaLia.PorcentajeLimite = defensaGastosCantidad;
                nuevaPolizaLia.Origen = Origen;
                nuevaPolizaLia.Programa = programa;
                if (tmpAgregar)
                    db.PolizaLiability.InsertOnSubmit(nuevaPolizaLia);
                db.SubmitChanges();
                idPolizaLia = nuevaPolizaLia.ID;
                return true;
            }
            catch
            {
                return false;
            }
        }

        bool guardarPolizaLiabilityProducing()
        {
            try
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                // borramos los registros anteriores
                borrarRegistros(8);

                PolizaLiabilityProd nuevaPoliProd = new PolizaLiabilityProd();
                nuevaPoliProd.PolizaLiability = idPolizaLia;
                nuevaPoliProd.QuoteNumber = quoteNumber;
                nuevaPoliProd.Jurisdiccion = jurisdiccion;
                nuevaPoliProd.JurisdiccionOtro = jurisdiccionOtro;
                nuevaPoliProd.InteresAsegurable = interesAsegurable;
                nuevaPoliProd.UbicacionRiesgo = ubicacionRiesgo;
                nuevaPoliProd.BaseCalculo = baseCalculo;
                db.PolizaLiabilityProd.InsertOnSubmit(nuevaPoliProd);
                db.SubmitChanges();
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
                    nuevaCobertura.Descripcion = dgCoberturas.Rows[i].Cells["Descripcion"].Text.ToString();
                    nuevaCobertura.Activo = true;
                    if (Convert.ToInt32(dgCoberturas.Rows[i].Cells["ID"].Text.ToString()) < 0)
                    {
                        Coberturas nuevaCoberturaDB = new Coberturas();
                        nuevaCoberturaDB.LineaNegocios = Liability;
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

                    // registramos las subcoberturas
                    if (dgCoberturas.Rows[i].HasChild())
                    {
                        for (int j = 0; j < dgCoberturas.Rows[i].ChildBands[0].Rows.Count; j++)
                        {
                            PolizaSubCobertura nuevaSubC = new PolizaSubCobertura();
                            nuevaSubC.Poliza = idPoliza;
                            nuevaSubC.SubCobertura = Convert.ToInt32(dgCoberturas.Rows[i].ChildBands[0].Rows[j].Cells["ID"].Value.ToString());
                            nuevaSubC.Cobertura = nuevaCobertura.ID;
                            nuevaSubC.OrdenImpresion = j;
                            db.PolizaSubCobertura.InsertOnSubmit(nuevaSubC);
                            db.SubmitChanges();
                        }
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
                        nuevaPolizaSub.SubLimite = dgSublimites.Rows[i].Cells["Sublimite"].Text;
                        nuevaPolizaSub.Monto = Convert.ToDecimal(dgSublimites.Rows[i].Cells["Monto"].Value);
                        nuevaPolizaSub.Descripcion = dgSublimites.Rows[i].Cells["Descripcion"].Text;
                        nuevaPolizaSub.Activo = true;
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
                        nuevaPoliDedu.Deducible = dgDeducibles.Rows[i].Cells["Deducible"].Text;
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
                        nuevaPoliDedu.Descripcion = dgDeducibles.Rows[i].Cells["Descripcion"].Text.ToString();
                        nuevaPoliDedu.GeniusCode = dgDeducibles.Rows[i].Cells["GeniusCode"].Text.ToString();
                        nuevaPoliDedu.Activo = true;
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
                borrarRegistros(9);

                // registramos los nuevos valores
                for (int i = 0; i < dgEndosos.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgEndosos.Rows[i].Cells["Aplica"].Value))
                    {
                        PolizaEndosoEmision nuevaPolizaEndoso = new PolizaEndosoEmision();
                        nuevaPolizaEndoso.Poliza = idPoliza;
                        nuevaPolizaEndoso.EndosoEmision = Convert.ToInt32(dgEndosos.Rows[i].Cells["ID"].Text);
                        nuevaPolizaEndoso.Texto = "";
                        nuevaPolizaEndoso.Activo = true;
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

                bool yaExiste = true;
                int? idExclu = (from x in db.PolizaExclusion where x.Poliza == idPoliza select x.Exclusion).FirstOrDefault();
                Exclusiones nuevaExclusion = (from x in db.Exclusiones where x.ID == idExclu select x).SingleOrDefault();
                if (nuevaExclusion == null)
                {
                    yaExiste = false;
                    nuevaExclusion = new Exclusiones();
                    nuevaExclusion.LineaNegocios = Liability;
                    nuevaExclusion.userAdd = true;
                    nuevaExclusion.Eliminado = false;
                }
                try { nuevaExclusion.Exclusion = txtExclusiones.Rtf; }
                catch { nuevaExclusion.Exclusion = txtExclusiones.Text; }
                if (!yaExiste)
                    db.Exclusiones.InsertOnSubmit(nuevaExclusion);
                db.SubmitChanges();

                PolizaExclusion nuevaPoliExclu;
                if (!yaExiste)
                    nuevaPoliExclu = new PolizaExclusion();
                else
                    nuevaPoliExclu = (from x in db.PolizaExclusion where x.Poliza == idPoliza select x).SingleOrDefault();
                nuevaPoliExclu.Poliza = idPoliza;
                nuevaPoliExclu.Exclusion = nuevaExclusion.ID;
                nuevaPoliExclu.Activo = true;
                if (!yaExiste)
                    db.PolizaExclusion.InsertOnSubmit(nuevaPoliExclu);
                db.SubmitChanges();

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
                nuevaInfo.Activo = true;
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

        bool guardarReaseguros()
        {
            try
            {
                dbSmartGDataContext db = new dbSmartGDataContext();

                // borramos todos los registros
                borrarRegistros(7);

                if(chkReaseguro.Checked)
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
            quoteNumber = txtQuoteNumber.Text;
            tipoOperacion = lbTipoTransaccionTxt.Text;
            ajustable = chkAjustable.Checked;
            portafolio = chkPortafolio.Checked;

            if (cbToB.Value != null)
                ToB = Convert.ToInt32(cbToB.Value);

            if (cbMoneda.Value != null)
            {
                moneda = Convert.ToInt32(cbMoneda.Value);
                strMoneda = cbMoneda.Text;
            }

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
            jurisdiccion = cbJurisdiccion.Text;
            jurisdiccionOtro = txtJurisOtro.Text;
            if (txtInteresAsegurable.Text != "")
            {
                try
                {
                    interesAsegurable = txtInteresAsegurable.Rtf;
                }
                catch
                {
                    interesAsegurable = txtInteresAsegurable.Text;
                }
            }
            else
                interesAsegurable = "No Aplica";
            ubicacionRiesgo = txtUbicacion.Text;
            ///////////////////////////////////////////////////////////////////////////////////
            //     segunda tab
            ///////////////////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////////////////////
            //     tercera tab
            ///////////////////////////////////////////////////////////////////////////////////
            limiteMaximo = Convert.ToDecimal(txtLimiteMaximo.Value);
            if (cbAggregationPL.Text != "")
                aggregationPL = Convert.ToInt32(cbAggregationPL.Value);

            if (cbAggregationPR.Text != "")
                aggregationPR = Convert.ToInt32(cbAggregationPR.Value);
            estructuraLimite = cbEstructuraLimite.Text;
            sujecion = Convert.ToDecimal(txtSujecion.Value);
            gastosDefensa = cbGastosDefensa.Text;
            defensaGastosCantidad = Convert.ToDecimal(txtGastosDefensa.Value);

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
            gastosExpedicion = Convert.ToDecimal(txtGastosExpedicion.Value);
            impuestosNetos = Convert.ToDecimal(txtImpuestos.Value);
            totalPoliza = Convert.ToDecimal(txtPrimaTotal.Value);
            baseCalculo = txtBaseCalculo.Text;
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
            strCoberturasAdicional = "";
            strAseguAdicional = "";
            strIniVig = "Desde: " + formatearFecha(Convert.ToDateTime(dateInicioVig.Value), 1) + " Hrs.";
            strFinVig = "Hasta: " + formatearFecha(Convert.ToDateTime(dateFinVigencia.Value), 1) + " Hrs.";
            strIniVig2 = formatearFecha(Convert.ToDateTime(dateInicioVig.Value), 2);
            strFinVig2 = formatearFecha(Convert.ToDateTime(dateFinVigencia.Value), 2);
            strEmision = formatearFecha(Convert.ToDateTime(dateEmision.Value), 1);
            strEmision2 = formatearFecha(Convert.ToDateTime(dateEmision.Value), 2);
            if (chkReaseguro.Checked)
                diaAnterior = formatearFecha(obtenerDiaHabilAnterior(), 2);
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
            if (cbDelimitacionTerritorial.Text == "Mexicana")
                strdelimitacionTerritorial = "Dentro del territorio de los Estados Unidos Mexicanos únicamente.";
            else if (cbDelimitacionTerritorial.Text == "Mundial (Excepto USA, PR y Canadá)")
                strdelimitacionTerritorial = "Dentro del territorio de los Estados Unidos Mexicanos y en todo el Mundo, excluyendo los Estados Unidos de América, Puerto Rico, Canadá (inclusive los territorios y posesiones de estos últimos).";
            else
                strdelimitacionTerritorial = "Dentro del territorio de los Estados Unidos Mexicanos y en todo el Mundo, incluyendo los Estados Unidos de América, Puerto Rico, Canadá (inclusive los territorios y posesiones de estos últimos).";

            if (chkRetroactiva.Checked)
            {
                strDelimitacionTemporal = "Modalidad: “Claims Made”";
                strDelimitacionTemporalTXT = "El seguro surte efecto cuando las reclamaciones de terceros son presentadas por primera vez contra el Asegurado durante la vigencia del seguro y dentro  de los dos años siguientes a su terminación.";
                modoClaims = "C - Claims Made";
                strRetroactiva = formatearFecha(Convert.ToDateTime(dateRetroactiva.Value), 1);
            }
            else
            {
                strDelimitacionTemporal = "Modalidad: “Occurrence”";
                strDelimitacionTemporalTXT = "El seguro surte efecto cuando los daños materiales o lesiones personales que fundamentan la reclamación ocurren durante la vigencia del seguro.";
                modoClaims = "O - Ocurrence";
                strRetroactiva = "";
            }

            int indexCobertura = 2;
            for (int i = 0; i < dgCoberturas.Rows.Count; i++)
            {
                if (dgCoberturas.Rows[i].Cells["Cobertura"].Value.ToString() == "Responsabilidad Civil Actividades e Inmuebles")
                {
                    strCoberturas = "1)\t Responsabilidad Civil Actividades e Inmuebles " + dgCoberturas.Rows[i].Cells["Descripcion"].Value.ToString();
                    if (dgCoberturas.Rows[i].HasChild())
                    {
                        strCoberturas = strCoberturas + " incluyendo:" + Environment.NewLine;
                        char indice = 'a';
                        for (int j = 0; j < dgCoberturas.Rows[i].ChildBands[0].Rows.Count; j++)
                        {
                            strCoberturas += indice + "." + "\t" + dgCoberturas.Rows[i].ChildBands[0].Rows[j].Cells["Subcobertura"].Value.ToString() + Environment.NewLine;
                            indice++;
                        }
                    }
                }
                else
                {
                    strCoberturasAdicional += indexCobertura.ToString() + ")\t " + dgCoberturas.Rows[i].Cells["Cobertura"].Value.ToString() + " " + dgCoberturas.Rows[i].Cells["Descripcion"].Value.ToString();
                    if (dgCoberturas.Rows[i].HasChild())
                    {
                        strCoberturasAdicional += " incluyendo:" + Environment.NewLine;
                        char indice = 'a';
                        for (int j = 0; j < dgCoberturas.Rows[i].ChildBands[0].Rows.Count; j++)
                        {
                            strCoberturasAdicional += indice + "." + "\t" + dgCoberturas.Rows[i].ChildBands[0].Rows[j].Cells["Subcobertura"].Value.ToString() + Environment.NewLine;
                            indice++;
                        }
                    }
                    else
                        strCoberturasAdicional += Environment.NewLine;
                    indexCobertura++;
                }
            }

            for (int i = 0; i < dgSublimites.Rows.Count; i++)
            {
                strSublimites += "- " + dgSublimites.Rows[i].Cells["Sublimite"].Text + ": " + double.Parse(dgSublimites.Rows[i].Cells["Monto"].Value.ToString()).ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon + " " + dgSublimites.Rows[i].Cells["Descripcion"].Text + "\n";
            }

            if (dgDeducibles.Rows.Count == 0)
                strDeducibles = "No aplican deducibles";
            else
            {
                string txtSir;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in dgDeducibles.Rows)
                {
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
                    strDeducibles += " " + row.Cells["Descripcion"].Text + "\n";
                }
            }

            strLimite = "Limite por evento y en el Agregado Anual: " + limiteMaximo.ToString("#,##0", new CultureInfo("en-US")) + " " + strAbreMon;

            if (cbGastosDefensa.SelectedIndex != 0)
                strGastosDefensa = "Gastos de Defensa cubiertos de forma adicional hasta un " + txtGastosDefensa.Value.ToString() + "% sobre el límite de Responsabilidad.";
            else
                strGastosDefensa = "Gastos de Defensa incluidos en el Límite de Indemnización";

            if (jurisdiccionOtro != "")
                strJurisdiccion = jurisdiccionOtro;
            else
                strJurisdiccion = jurisdiccion;

            if (chkReaseguro.Checked)
            {
                for (int i = 0; i < dgReaseguro.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgReaseguro.Rows[i].Cells["Treaty"].Value) && i != 0)
                    {
                        strPartReasegurada += Convert.ToDouble(dgReaseguro.Rows[i].Cells["PorcentajePoliza"].Value);
                        strComisionInter += Convert.ToDouble(dgReaseguro.Rows[i].Cells["Comision"].Value);
                    }

                    if (Convert.ToBoolean(dgReaseguro.Rows[i].Cells["Treaty"].Value))
                    {
                        strPartTotal += Convert.ToDouble(dgReaseguro.Rows[i].Cells["PorcentajePoliza"].Value);
                    }
                }
            }
            strInternationalCalc = (strComisionInter / (Convert.ToDouble(txtPrimaNeta.Value) * (strPartReasegurada / 100))) * 100;
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
            // llena los paises del form en inglés
            liIncPaisTableAdapter.Fill(this.liabilityInc1.LiIncPais);
            // llena los programas para liability incoming
            liIncProgramasTableAdapter.FillByDefaultLiInc(this.liabilityInc1.LiIncProgramas, Liability, Origen);
            // llena las monedas default
            liIncMonedaTableAdapter.Fill(this.liabilityInc1.LiIncMoneda);
            cbMoneda.Value = 1;
            // llena los producing office default
            lNPOTableAdapter.FillByConsultaLNPOporIDLineaNegocio(this.liabilityInc1.LNPO, Liability);
            cbProducingOffice.DisplayMember = "Producing Office";
            cbProducingOffice.ValueMember = "ID";
            // llena los activity Code
            liIncActivityCodeTableAdapter.FillByDefaultLi(this.liabilityInc1.LiIncActivityCode, Liability);
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
            idIntermediarioDefault = (from x in db.IntermediariosReaseguro where x.Clave == "0000" select x.ID).SingleOrDefault();
            // llenado de las formas de pago default
            liIncFormaPagoTableAdapter.Fill(this.liabilityInc1.LiIncFormaPago);
            // llenado de los aggregation PR
            liIncAggregationPRTableAdapter.Fill(this.liabilityInc1.LiIncAggregationPR);
            // llenado de los aggregation PL
            liIncAggregationPLTableAdapter.Fill(this.liabilityInc1.LiIncAggregationPL);
            // llenado de las coberturas DB
            dtCoberturasDB = liIncCoberturasDBTableAdapter.GetDataByDefaultDBOrigen(Liability,Origen);
            // llenado de las coberturas default
            dtCoberturas = liIncCoberturasTableAdapter.GetDataByDefaultOrigen(Liability,Origen);
            dtCoberturas.Columns.Add("Descripcion", typeof(string));
            // iniciamos los datatable de las subcoberturas
            dtSubCoberturas = liIncSubCoberturasTableAdapter.GetData();
            dtSubCoberturasDB = liIncSubCoberturasTableAdapter.GetData(); 
            // iniciamos los datasets que tendrá las relaciones entre las tablas
            dsCoberturas = new DataSet();
            dsCoberturas.Tables.Add(dtCoberturas);
            dsCoberturas.Tables.Add(dtSubCoberturas);
            dsCoberturas.Relations.Add("Rel1", dtCoberturas.Columns["ID"], dtSubCoberturas.Columns["Cobertura"], false);
            dgCoberturas.DataSource = dsCoberturas;
            dsCoberturasDB = new DataSet();
            dsCoberturasDB.Tables.Add(dtCoberturasDB);
            dsCoberturasDB.Tables.Add(dtSubCoberturasDB);
            dsCoberturasDB.Relations.Add("Rel1", dtCoberturasDB.Columns["ID"], dtSubCoberturasDB.Columns["Cobertura"], false);
            dgCoberturasDB.DataSource = dsCoberturasDB;
            #region formatodeGrids
            //ocultamos y formateamos las columnas para los grids de coberturas
            dgCoberturas.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[0].Columns["Origen"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[0].Columns["LineaNegocios"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[0].Columns["Defecto"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[0].Columns["userAdd"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[0].Columns["CoberturaIngles"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[0].Columns["GeniusCode"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[0].Columns["Eliminado"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[0].Columns["Cobertura"].Width = 450;
            dgCoberturas.DisplayLayout.Bands[0].Columns["Descripcion"].Width = 800;
            dgCoberturas.DisplayLayout.Bands[0].Columns["Cobertura"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            dgCoberturas.DisplayLayout.Bands[1].Columns["ID"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[1].Columns["Cobertura"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[1].Columns["Defecto"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[1].Columns["UserAdd"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[1].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree;
            dgCoberturas.DisplayLayout.Bands[1].Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            dgCoberturas.DisplayLayout.Bands[1].Columns["Subcobertura"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            dgCoberturas.DisplayLayout.Bands[1].Columns["Subcobertura"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;

            dgCoberturasDB.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[0].Columns["Origen"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[0].Columns["LineaNegocios"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[0].Columns["Defecto"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[0].Columns["userAdd"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[0].Columns["CoberturaIngles"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[0].Columns["GeniusCode"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[0].Columns["Eliminado"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[1].Columns["ID"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[1].Columns["Cobertura"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[1].Columns["Defecto"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[1].Columns["UserAdd"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[0].Columns["Cobertura"].Width = 800;
            #endregion
            expandirGrids();
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
            DataTable dttmpEnd = endosoEmisionTableAdapter.GetDataByActivos(Liability, Origen);
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
            // iniciamos el textbox del DAM con el mismo valor del usuario que entra
            txtDAM.Text = txtPAM.Text;
            //  iniciamos el dt de controles por tipo
            dtControles = new DataTable();
            dtControles.Columns.Add("Control", typeof(Control));
            dtControles.Columns.Add("Tipo", typeof(string));
            dtControles.Columns.Add("InfoSchedule", typeof(bool));
            dtControles.Columns.Add("Anterior", typeof(string));
            dtControles.Columns.Add("Nuevo", typeof(string));
            dtControles.Columns.Add("Campo", typeof(string));
            // iniciamos el cb de codigos genius 
            if(dgCoberturasDB.Rows.Count > 0)
            {
                for (int i = 0; i < dgCoberturasDB.Rows.Count; i++)
                {
                    if (dgCoberturasDB.Rows[i].Cells["GeniusCode"].Text.ToString() != "OTH")
                        cbGeniusCode.Items.Add("D" + dgCoberturasDB.Rows[i].Cells["GeniusCode"].Text.ToString());
                }
            }
            if (dgCoberturas.Rows.Count > 0)
            {
                for (int i = 0; i < dgCoberturas.Rows.Count; i++)
                {
                    if (dgCoberturas.Rows[i].Cells["GeniusCode"].Text.ToString() != "OTH")
                        cbGeniusCode.Items.Add("D" + dgCoberturas.Rows[i].Cells["GeniusCode"].Text.ToString());
                }
            }
            cbGeniusCode.Items.Add("OTH");
        }

        void llenarControlesDatos()
        {
            dtControles.Rows.Add(chkAjustable, "bool", false, "", "", "Ajustable");
            dtControles.Rows.Add(chkPortafolio, "bool", false, "", "", "Portafolio");
            dtControles.Rows.Add(cbProducingOffice, "string", false, "", "", "Producing Office");
            dtControles.Rows.Add(cbToB, "string", false, "", "", "ToB");
            dtControles.Rows.Add(dateFinVigencia, "date", false, "", "", "Fin de Vigencia");
            dtControles.Rows.Add(chkRetroactiva, "bool", false, "", "", "Retroactiva");
            dtControles.Rows.Add(dateRetroactiva, "date", false, "", "", "Fecha Retroactiva");
            dtControles.Rows.Add(txtDAM, "string", false, "", "", "DAM");
            dtControles.Rows.Add(txtPAM, "string", false, "", "", "PAM");
            dtControles.Rows.Add(cbCountry, "string", false, "", "", "País");
            dtControles.Rows.Add(cbBroker, "string", false, "", "", "Broker");
            dtControles.Rows.Add(cbDelimitacionTerritorial, "string", false, "", "", "Delimitación Territorial");
            dtControles.Rows.Add(cbJurisdiccion, "string", false, "", "", "Jurisdiccion");
            dtControles.Rows.Add(txtJurisOtro, "string", false, "", "", "Detalle Jurisdiccion");
            dtControles.Rows.Add(txtInteresAsegurable, "string", false, "", "", "Interes Asegurable");
            dtControles.Rows.Add(txtUbicacion, "string", false, "", "", "Ubicacion");
            dtControles.Rows.Add(txtLimiteMaximo, "decimal", false, "", "", "Límite Máximo");
            dtControles.Rows.Add(cbAggregationPL, "string", false, "", "", "Aggregation PL");
            dtControles.Rows.Add(cbAggregationPR, "string", false, "", "", "Aggregation PR");
            dtControles.Rows.Add(txtSujecion, "decimal", false, "", "", "Sujeción");
            dtControles.Rows.Add(cbGastosDefensa, "string", false, "", "", "Gastos de defensa");
            dtControles.Rows.Add(txtGastosDefensa, "double", false, "", "", "% Gastos de defensa");
            dtControles.Rows.Add(txtExclusiones, "string", false, "", "", "Exclusiones");
            dtControles.Rows.Add(txtTituloPolizaGenius, "string", false, "", "", "Título póliza Genius");
            dtControles.Rows.Add(chkLTARenegotiable, "bool", false, "", "", "LTA Renegotiable");
            dtControles.Rows.Add(dateLTAInception, "date", false, "", "", "LTA Inception");
            dtControles.Rows.Add(dateLTAExpiry, "date", false, "", "", "LTA Expiry");
            dtControles.Rows.Add(cbPaymentConditions, "string", false, "", "", "Payment Conditions");
            dtControles.Rows.Add(cbActivityCode, "string", false, "", "", "Activity Code");
            dtControles.Rows.Add(chkAdminClaims, "bool", false, "", "", "Admin Claims");
            dtControles.Rows.Add(chkAdminPremium, "bool", false, "", "", "Admin Premium");
            dtControles.Rows.Add(chkGenerateDocuments, "bool", false, "", "", "Generate Documents");
            dtControles.Rows.Add(txtPrimaMain, "decimal", true, "", "", "Prima");
            dtControles.Rows.Add(cbIVA, "string", true, "", "", "IVA");
            dtControles.Rows.Add(cbTipoPrima, "string", true, "", "", "Tipo de Prima");
            dtControles.Rows.Add(txtTurnOver, "decimal", true, "", "", "TurnOver");
            dtControles.Rows.Add(chkIsBrokerage, "bool", true, "", "", "Aplica Brokerage");
            dtControles.Rows.Add(txtBrokeragePorc, "double", true, "", "", "Porcentaje Brokerage");
            dtControles.Rows.Add(txtObservaciones, "string", true, "", "", "Observaciones");
            dtControles.Rows.Add(txtDescuentos, "decimal", true, "", "", "Descuentos");
            dtControles.Rows.Add(txtBaseCalculo, "string", false, "", "", "Bsse de calculo");

            for (int i = 0; i < dtControles.Rows.Count; i++)
            {
                string tipoControl = dtControles.Rows[i]["Tipo"].ToString();

                switch (tipoControl)
                {
                    case "int":
                        Infragistics.Win.UltraWinEditors.UltraNumericEditor controlInt = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)dtControles.Rows[i]["Control"];
                        dtControles.Rows[i]["Anterior"] = controlInt.Value.ToString();
                        break;

                    case "string":
                        Control tmpControlS = (Control)dtControles.Rows[i]["Control"];
                        dtControles.Rows[i]["Anterior"] = tmpControlS.Text;
                        break;

                    case "decimal":
                        Infragistics.Win.UltraWinEditors.UltraNumericEditor controlDecimal = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)dtControles.Rows[i]["Control"];
                        dtControles.Rows[i]["Anterior"] = Convert.ToDecimal(controlDecimal.Value).ToString("#,##0", new CultureInfo("en-US"));
                        break;

                    case "bool":
                        Infragistics.Win.UltraWinEditors.UltraCheckEditor controlCheck = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)dtControles.Rows[i]["Control"];
                        dtControles.Rows[i]["Anterior"] = controlCheck.Checked.ToString();
                        break;

                    case "date":
                        Infragistics.Win.UltraWinEditors.UltraDateTimeEditor controlFecha = (Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)dtControles.Rows[i]["Control"];
                        dtControles.Rows[i]["Anterior"] = controlFecha.Value.ToString();
                        break;

                    case "double":
                        Infragistics.Win.UltraWinEditors.UltraNumericEditor controlDouble = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)dtControles.Rows[i]["Control"];
                        dtControles.Rows[i]["Anterior"] = controlDouble.Value.ToString();
                        break;
                }
            }
        }

        void llenarControlesObligatorios()
        {
            controlesObligatorios = new Control[30];
            controlesObligatorios[0] = txtPolizaMX;
            controlesObligatorios[1] = txtPolizaES;
            controlesObligatorios[2] = txtQuoteNumber;
            controlesObligatorios[3] = cbProducingOffice;
            controlesObligatorios[4] = cbToB;
            controlesObligatorios[5] = cbMoneda;
            controlesObligatorios[6] = cbPrograma;
            controlesObligatorios[7] = txtDAM;
            controlesObligatorios[8] = txtPAM;
            controlesObligatorios[9] = cbCountry;
            controlesObligatorios[10] = cbBroker;
            controlesObligatorios[11] = cbAseguradoMain;
            controlesObligatorios[12] = cbDireccionRegistrada;
            controlesObligatorios[13] = cbDelimitacionTerritorial;
            controlesObligatorios[14] = cbJurisdiccion;
            //controlesObligatorios[15] = txtInteresAsegurable;
            controlesObligatorios[16] = txtLimiteMaximo;
            controlesObligatorios[17] = cbAggregationPL;
            controlesObligatorios[18] = cbAggregationPR;
            controlesObligatorios[19] = cbEstructuraLimite;
            controlesObligatorios[20] = cbGastosDefensa;
            controlesObligatorios[21] = txtTituloPolizaGenius;
            controlesObligatorios[22] = cbPaymentConditions;
            controlesObligatorios[23] = cbActivityCode;
            controlesObligatorios[24] = txtPrimaMain;
            controlesObligatorios[25] = cbIVA;
            controlesObligatorios[26] = cbTipoPrima;
            controlesObligatorios[27] = txtTipoPoliza;
            controlesObligatorios[28] = cbFormaPago;
            controlesObligatorios[29] = txtNumPagos;
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
            int aggregationPLtmp = Convert.ToInt32(cbAggregationPL.Value);
            int aggregationPRtmp = Convert.ToInt32(cbAggregationPR.Value);
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
            // llena los programas para liability incoming
            liIncProgramasTableAdapter.FillByDefaultLiInc(this.liabilityInc1.LiIncProgramas, Liability, Origen);
            // llena las monedas default
            liIncMonedaTableAdapter.Fill(this.liabilityInc1.LiIncMoneda);
            // llena los producing office default
            lNPOTableAdapter.FillByConsultaLNPOporIDLineaNegocio(this.liabilityInc1.LNPO, Liability);
            cbProducingOffice.DisplayMember = "Producing Office";
            cbProducingOffice.ValueMember = "ID";
            // llena los activity Code
            liIncActivityCodeTableAdapter.FillByDefaultLi(this.liabilityInc1.LiIncActivityCode, Liability);
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
            dtCoberturasDB = liIncCoberturasDBTableAdapter.GetDataByDefaultDB(Liability);
            // llenado de las coberturas default
            dtCoberturas = liIncCoberturasTableAdapter.GetDataByDefault(Liability);
            dtCoberturas.Columns.Add("Descripcion", typeof(string));
            // iniciamos los datatable de las subcoberturas
            dtSubCoberturas = liIncSubCoberturasTableAdapter.GetData();
            dtSubCoberturasDB = liIncSubCoberturasTableAdapter.GetData();
            // iniciamos los datasets que tendrá las relaciones entre las tablas
            dsCoberturas = new DataSet();
            dsCoberturas.Tables.Add(dtCoberturas);
            dsCoberturas.Tables.Add(dtSubCoberturas);
            dsCoberturas.Relations.Add("Rel1", dtCoberturas.Columns["ID"], dtSubCoberturas.Columns["Cobertura"], false);
            dgCoberturas.DataSource = dsCoberturas;
            dsCoberturasDB = new DataSet();
            dsCoberturasDB.Tables.Add(dtCoberturasDB);
            dsCoberturasDB.Tables.Add(dtSubCoberturasDB);
            dsCoberturasDB.Relations.Add("Rel1", dtCoberturasDB.Columns["ID"], dtSubCoberturasDB.Columns["Cobertura"], false);
            dgCoberturasDB.DataSource = dsCoberturasDB;
            #region formatodeGrids
            //ocultamos y formateamos las columnas para los grids de coberturas
            dgCoberturas.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[0].Columns["Origen"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[0].Columns["LineaNegocios"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[0].Columns["Defecto"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[0].Columns["userAdd"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[0].Columns["CoberturaIngles"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[0].Columns["GeniusCode"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[0].Columns["Eliminado"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[0].Columns["Cobertura"].Width = 450;
            dgCoberturas.DisplayLayout.Bands[0].Columns["Descripcion"].Width = 800;
            dgCoberturas.DisplayLayout.Bands[0].Columns["Cobertura"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            dgCoberturas.DisplayLayout.Bands[1].Columns["ID"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[1].Columns["Cobertura"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[1].Columns["Defecto"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[1].Columns["UserAdd"].Hidden = true;
            dgCoberturas.DisplayLayout.Bands[1].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree;
            dgCoberturas.DisplayLayout.Bands[1].Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            dgCoberturas.DisplayLayout.Bands[1].Columns["Subcobertura"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            dgCoberturas.DisplayLayout.Bands[1].Columns["Subcobertura"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;

            dgCoberturasDB.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[0].Columns["Origen"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[0].Columns["LineaNegocios"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[0].Columns["Defecto"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[0].Columns["userAdd"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[0].Columns["CoberturaIngles"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[0].Columns["GeniusCode"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[0].Columns["Eliminado"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[1].Columns["ID"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[1].Columns["Cobertura"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[1].Columns["Defecto"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[1].Columns["UserAdd"].Hidden = true;
            dgCoberturasDB.DisplayLayout.Bands[0].Columns["Cobertura"].Width = 800;
            #endregion
            expandirGrids();
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
            DataTable dttmpEnd = endosoEmisionTableAdapter.GetDataByActivos(Liability, Origen);
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
            cbAggregationPL.Value = aggregationPLtmp;
            cbAggregationPR.Value = aggregationPRtmp;
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
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar los datos Liability.";
                    break;
                case 5:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar los datos Liability Producing.";
                    break;
                case 6:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar las coberturas.";
                    break;
                case 7:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar los endosos de emisión.";
                    break;
                case 8:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar los sublimites.";
                    break;
                case 9:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar los deducibles.";
                    break;
                case 10:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar las exclusiones.";
                    break;
                case 11:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar la información de facturación.";
                    break;
                case 12:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar asegurados.";
                    break;
                case 13:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar los coaseguros.";
                    break;
                case 14:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar los reaseguros.";
                    break;
            }
        }

        void solicitarDocumentos()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            guardarVariables();
            guardarVariablesWording();

            #region Obtener Ultimo día hábil
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
            #endregion

            #region Creacion de wording
            WordingLiabilityProducing nuevoWording = new WordingLiabilityProducing();

            nuevoWording.IDPoliza = idPoliza;
            nuevoWording.PolizaMX = polizaMX;
            nuevoWording.PolizaES = polizaES;
            nuevoWording.Moneda = strMoneda;
            nuevoWording.AbreMoneda = strAbreMon;
            nuevoWording.FechaInicioVigencia = strIniVig;
            nuevoWording.FechaFinVigencia = strFinVig;
            nuevoWording.FechaEmision = formatearFecha(Convert.ToDateTime(dateEmision.Value), 2);
            nuevoWording.FechaDiaAnterior = formatearFecha(result, 2);
            nuevoWording.Asegurado = cbAseguradoMain.Text;
            nuevoWording.DireccionAsegurado = strDireccionAsegu;
            nuevoWording.RFC = strRFC;
            nuevoWording.GiroEmpresarial = strGiroE;
            nuevoWording.AseguradosAdicionales = strAseguAdicional;
            nuevoWording.DelimitacionTemporal = strDelimitacionTemporal;
            nuevoWording.DelimitacionTemporalTXT = strDelimitacionTemporalTXT;
            nuevoWording.FechaRetroactiva = strRetroactiva;
            nuevoWording.DelimitacionTerritorial = strdelimitacionTerritorial;
            nuevoWording.UbicacionesAseguradas = "Todas y cada una de las ubicaciones dentro del territorio de los Estados Unidos Mexicanos, que el Asegurado y sus empresas filiales y/o subsidiarias nombradas como Asegurados en esta póliza, tengan como propietario, arrendatario, tenedor o usuario, y en las cuales realicen las operaciones propias al giro de su negocio y/o a su servicio.";
            nuevoWording.Coberturas = strCoberturas;
            nuevoWording.LimiteMaximo = strLimite;
            nuevoWording.GastosDefensa = strGastosDefensa;
            nuevoWording.Sublimites = strSublimites;
            nuevoWording.Deducibles = strDeducibles;
            nuevoWording.PrimaNeta = primaNeta;
            nuevoWording.Descuentos = descuentos;
            nuevoWording.Recargos = recargoFraccionado;
            nuevoWording.Impuestos = Convert.ToDecimal(txtImpuestos.Value);
            nuevoWording.PrimaTotal = primaTotal;
            nuevoWording.FormaPago = strFormaPago;
            nuevoWording.Asegurador = "XL Seguros México, S.A. de C.V. " + Environment.NewLine + "Antonio Dovalí Jaime No. 70" + Environment.NewLine + "Torre C, Piso 8" + Environment.NewLine
                        + "Col. Zedec Santa Fe, C.P. 01210" + Environment.NewLine + "Ciudad de México." + Environment.NewLine + Environment.NewLine + "R.F.C.: XIM - 040220 – 119" + Environment.NewLine;
            nuevoWording.Broker = strBroker;
            try { nuevoWording.Exclusiones = txtExclusiones.Rtf; }
            catch { nuevoWording.Exclusiones = txtExclusiones.Text; }
            nuevoWording.TipoSeguro = txtTipoPoliza.Text;
            nuevoWording.IniVig = formatearFecha(Convert.ToDateTime(dateInicioVig.Value), 2);
            nuevoWording.FinVig = formatearFecha(Convert.ToDateTime(dateFinVigencia.Value), 2);
            nuevoWording.HoraIniVig = Convert.ToDateTime(dateInicioVig.Value).ToShortTimeString();
            nuevoWording.HoraFinVig = Convert.ToDateTime(dateFinVigencia.Value).ToShortTimeString();
            nuevoWording.TipoOperacion = lbTipoTransaccionTxt.Text;
            nuevoWording.LimiteMaximoSolo = Convert.ToDecimal(txtLimiteMaximo.Value);
            nuevoWording.PartReasegurada = strPartReasegurada.ToString();
            nuevoWording.PartTotal = strPartTotal.ToString();
            nuevoWording.ComisionInter = Convert.ToDecimal(strComisionInter);
            nuevoWording.InformacionReaseguro = txtInformacionRiesgo.Text;
            nuevoWording.IvaTexto = cbIVA.Text;
            nuevoWording.GastosExpedicion = Convert.ToDecimal(txtGastosExpedicion.Value);
            nuevoWording.Observaciones = txtObservaciones.Text;
            nuevoWording.AplicaReaseguro = chkReaseguro.Checked;
            nuevoWording.Jurisdiccion = strJurisdiccion;
            nuevoWording.UbicacionRiesgo = ubicacionRiesgo;
            nuevoWording.InteresAsegurable = interesAsegurable;
            nuevoWording.CoberturasAdicional = strCoberturasAdicional;
            nuevoWording.BaseCalculo = baseCalculo;
            db.WordingLiabilityProducing.InsertOnSubmit(nuevoWording);
            db.SubmitChanges();
            #endregion

            #region Nueva solicitud
            SolicitudesServidor nuevaSolicitud = new SolicitudesServidor();
            nuevaSolicitud.Usuario = Program.Globals.UserID;
            nuevaSolicitud.FechaSolicitud = DateTime.Now;
            nuevaSolicitud.Poliza = idPoliza;
            nuevaSolicitud.Status = 1;
            nuevaSolicitud.TipoSolicitud = 2;
            db.SolicitudesServidor.InsertOnSubmit(nuevaSolicitud);
            db.SubmitChanges();
            #endregion

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");////////////////////////////////////////////////////////

            txtRetroValidaciones.Text = "Solicitud envíada al servidor, cuando haya generado los documentos se te notificará, puedes seguir trabajando con normalidad dentro o fuera de SmartG.";
        }

        void solicitarPrevio()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            guardarVariables();
            guardarVariablesWording();

            #region Obtener Ultimo día hábil
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
            #endregion

            #region Creacion de wording
            WordingLiabilityProducing nuevoWording = new WordingLiabilityProducing();

            nuevoWording.IDPoliza = idPoliza;
            nuevoWording.PolizaMX = polizaMX;
            nuevoWording.PolizaES = polizaES;
            nuevoWording.Moneda = strMoneda;
            nuevoWording.AbreMoneda = strAbreMon;
            nuevoWording.FechaInicioVigencia = strIniVig;
            nuevoWording.FechaFinVigencia = strFinVig;
            nuevoWording.FechaEmision = formatearFecha(Convert.ToDateTime(dateEmision.Value), 2);
            nuevoWording.FechaDiaAnterior = formatearFecha(result, 2);
            nuevoWording.Asegurado = cbAseguradoMain.Text;
            nuevoWording.DireccionAsegurado = strDireccionAsegu;
            nuevoWording.RFC = strRFC;
            nuevoWording.GiroEmpresarial = strGiroE;
            nuevoWording.AseguradosAdicionales = strAseguAdicional;
            nuevoWording.DelimitacionTemporal = strDelimitacionTemporal;
            nuevoWording.DelimitacionTemporalTXT = strDelimitacionTemporalTXT;
            nuevoWording.FechaRetroactiva = strRetroactiva;
            nuevoWording.DelimitacionTerritorial = strdelimitacionTerritorial;
            nuevoWording.UbicacionesAseguradas = "Todas y cada una de las ubicaciones dentro del territorio de los Estados Unidos Mexicanos, que el Asegurado y sus empresas filiales y/o subsidiarias nombradas como Asegurados en esta póliza, tengan como propietario, arrendatario, tenedor o usuario, y en las cuales realicen las operaciones propias al giro de su negocio y/o a su servicio.";
            nuevoWording.Coberturas = strCoberturas;
            nuevoWording.LimiteMaximo = strLimite;
            nuevoWording.GastosDefensa = strGastosDefensa;
            nuevoWording.Sublimites = strSublimites;
            nuevoWording.Deducibles = strDeducibles;
            nuevoWording.PrimaNeta = primaNeta;
            nuevoWording.Descuentos = descuentos;
            nuevoWording.Recargos = recargoFraccionado;
            nuevoWording.Impuestos = Convert.ToDecimal(txtImpuestos.Value);
            nuevoWording.PrimaTotal = primaTotal;
            nuevoWording.FormaPago = strFormaPago;
            nuevoWording.Asegurador = "XL Seguros México, S.A. de C.V. " + Environment.NewLine + "Antonio Dovalí Jaime No. 70" + Environment.NewLine + "Torre C, Piso 8" + Environment.NewLine
                        + "Col. Zedec Santa Fe, C.P. 01210" + Environment.NewLine + "Ciudad de México." + Environment.NewLine + Environment.NewLine + "R.F.C.: XIM - 040220 – 119" + Environment.NewLine;
            nuevoWording.Broker = strBroker;
            if (txtExclusiones.Text != "")
            {
                try { nuevoWording.Exclusiones = txtExclusiones.Rtf; }
                catch { nuevoWording.Exclusiones = txtExclusiones.Text; }
            }
            else
                nuevoWording.Exclusiones = "No Aplica";
            nuevoWording.TipoSeguro = txtTipoPoliza.Text;
            nuevoWording.IniVig = formatearFecha(Convert.ToDateTime(dateInicioVig.Value), 2);
            nuevoWording.FinVig = formatearFecha(Convert.ToDateTime(dateFinVigencia.Value), 2);
            nuevoWording.HoraIniVig = Convert.ToDateTime(dateInicioVig.Value).ToShortTimeString();
            nuevoWording.HoraFinVig = Convert.ToDateTime(dateFinVigencia.Value).ToShortTimeString();
            nuevoWording.TipoOperacion = lbTipoTransaccionTxt.Text;
            nuevoWording.LimiteMaximoSolo = Convert.ToDecimal(txtLimiteMaximo.Value);
            nuevoWording.PartReasegurada = strPartReasegurada.ToString();
            nuevoWording.PartTotal = strPartTotal.ToString();
            nuevoWording.ComisionInter = Convert.ToDecimal(strComisionInter);
            nuevoWording.InformacionReaseguro = txtInformacionRiesgo.Text;
            nuevoWording.IvaTexto = cbIVA.Text;
            nuevoWording.GastosExpedicion = Convert.ToDecimal(txtGastosExpedicion.Value);
            nuevoWording.Observaciones = txtObservaciones.Text;
            nuevoWording.AplicaReaseguro = chkReaseguro.Checked;
            nuevoWording.Jurisdiccion = strJurisdiccion;
            nuevoWording.UbicacionRiesgo = ubicacionRiesgo;
            nuevoWording.InteresAsegurable = interesAsegurable;
            nuevoWording.CoberturasAdicional = strCoberturasAdicional;
            nuevoWording.BaseCalculo = baseCalculo;
            db.WordingLiabilityProducing.InsertOnSubmit(nuevoWording);
            db.SubmitChanges();
            #endregion

            #region Nueva solicitud
            SolicitudesServidor nuevaSolicitud = new SolicitudesServidor();
            nuevaSolicitud.Usuario = Program.Globals.UserID;
            nuevaSolicitud.FechaSolicitud = DateTime.Now;
            nuevaSolicitud.Poliza = idPoliza;
            nuevaSolicitud.Status = 1;
            nuevaSolicitud.TipoSolicitud = 1;
            db.SolicitudesServidor.InsertOnSubmit(nuevaSolicitud);
            db.SubmitChanges();
            #endregion

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");////////////////////////////////////////////////////////

            txtRetroValidaciones.Text = "Solicitud envíada al servidor, cuando haya generado los documentos se te notificará, puedes seguir trabajando con normalidad dentro o fuera de SmartG.";
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
                            txtRetroValidaciones.Text += Environment.NewLine + "Error: el campo Poliza MX debe llenarse correctamente: MX + 8 dígitos seguimiento + LI + 2 dígitos año de emisión + caracter A,B o C  (Datos Generales)";
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
                            txtRetroValidaciones.Text += Environment.NewLine + "Error: el campo Poliza ES debe llenarse correctamente: ES + 8 dígitos seguimiento + LI + 2 dígitos año de emisión + caracter A,B o C (Datos Generales)";
                        }
                    }
                    if (txtQuoteNumber.Text == "")
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: el campo Quote Number no puede estar vacio (Datos Generales)";
                    }
                    else if (txtQuoteNumber.Text != "")
                    {
                        if (!validarPoliza(txtQuoteNumber))
                        {
                            tmpValida = false;
                            txtRetroValidaciones.Text += Environment.NewLine + "Error: el campo Quote Number debe llenarse correctamente: QMX + 7 dígitos seguimiento + LI + 2 dígitos año de emisión + caracter A,B o C (Datos Generales)";
                        }
                    }
                    for (int i = 2; i < 15; i++)
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
                    if (chkPortafolio.Checked && txtPolizaES.Text == "")
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: Si está activa la opción de portafolio es necesario llenar el campo ES (Datos Generales)";
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

                case 2:// tab endosos
                    if (tmpValida) // pasó todas las validaciones
                        txtRetroValidaciones.Text += Environment.NewLine + "3) Sección Endosos emisión OK";
                    break;

                case 3: // tab limites y sublimites
                    if (Convert.ToDecimal(txtLimiteMaximo.Value) <= 0)
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: el límite máximo no puede ser cero (Límites y sublímites)";
                    }
                    if (cbAggregationPL.Text == "")
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debes seleccionar un valor para el Aggregation PL (Límites y sublímites)";
                    }
                    if (cbAggregationPR.Text == "")
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debes seleccionar un valor para el Aggregation PR (Límites y sublímites)";
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
                    if (cbGastosDefensa.Text == "")
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debes seleccionar un valor para los gastos de defensa (Límites y sublímites)";
                    }
                    if (txtGastosDefensa.Visible && Convert.ToDecimal(txtGastosDefensa.Value) <= 0)
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: el valor de gastos defensa no puede ser cero (Límites y sublímites)";
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
                    if (chkExclusiones.Checked && txtExclusiones.Text == "")
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debes de introducir valor(es) si activaste la opción de exclusiones (Deducibles y Exclusiones)";
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

                case 9:
                    if (ventana == 2)
                    {
                        if (tmpValida) // pasó todas las validaciones
                            txtRetroValidaciones.Text += Environment.NewLine + "10) Sección Texto OK";
                    }
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

        bool validarEndososPoliza()
        {
            txtRetroValidaciones.Text = "Buscando cambios en la póliza, por favor espere...";
            int contadorModificadores = 0;
            if (buscarCambiosPoliza()) contadorModificadores++;
            if (buscarCambiosClientePrincipal()) contadorModificadores++;
            if (buscarCambiosClientesAdicionales()) contadorModificadores++;
            if (buscarCambiosCoberturas()) contadorModificadores++;
            if (buscarCambiosEndososEmision()) contadorModificadores++;
            if (buscarCambiosSubLimites()) contadorModificadores++;
            if (buscarCambiosDeducibles()) contadorModificadores++;
            if (buscarCambiosExclusiones()) contadorModificadores++;
            if (buscarCambiosInfoSchedule()) contadorModificadores++;
            if (buscarCambiosTexto()) contadorModificadores++;

            if (contadorModificadores > 0)
            {
                txtRetroValidaciones.Text += Environment.NewLine + "Cambios encontrados, preparandose para generar endoso.";
                return true;
            }
            else
            {
                txtRetroValidaciones.Text += Environment.NewLine + "No se encontraron cambios en la póliza.";
                return false;
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
                if (Convert.ToDecimal(row.Cells["Porcentaje"].Value) == 0 && Convert.ToDecimal(row.Cells["Minimo"].Value) != 0 && Convert.ToDecimal(row.Cells["Maximo"].Value) != 0 && Convert.ToDecimal(row.Cells["Agregado"].Value) != 0) { caso = 8; }
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
                if (!dgCoberturasDB.ActiveRow.HasParent() && dgCoberturasDB.Selected.Rows.Count > 0)
                {
                    //Agrega una cobertura a la póliza de la lista de la DB
                    dsCoberturas.Tables[0].Rows.Add(Convert.ToInt32(dgCoberturasDB.ActiveRow.Cells["ID"].Value.ToString()), Liability, dgCoberturasDB.ActiveRow.Cells["Cobertura"].Value.ToString(), 
                        dgCoberturasDB.ActiveRow.Cells["CoberturaIngles"].Value.ToString(), dgCoberturasDB.ActiveRow.Cells["GeniusCode"].Value.ToString(), Convert.ToBoolean(dgCoberturasDB.ActiveRow.Cells["Defecto"].Value), 
                        Convert.ToBoolean(dgCoberturasDB.ActiveRow.Cells["userAdd"].Value), Convert.ToBoolean(dgCoberturasDB.ActiveRow.Cells["Eliminado"].Value), Origen);
                    dsCoberturasDB.Tables[0].Rows.RemoveAt(dgCoberturasDB.ActiveRow.Index);
                    expandirGrids();
                }
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
            if (dgCoberturas.Selected.Rows.Count == 1 || dgCoberturas.Selected.Cells.Count > 0)
            {
                if (!dgCoberturas.ActiveRow.HasParent() && dgCoberturas.Selected.Cells.Count > 0)
                {
                    //regresa las coberturas al grid de DB
                    int idBorrar = Convert.ToInt32(dgCoberturas.ActiveRow.Cells["ID"].Value.ToString());
                    dsCoberturasDB.Tables[0].Rows.Add(Convert.ToInt32(dgCoberturas.ActiveRow.Cells["ID"].Value.ToString()), Liability, dgCoberturas.ActiveRow.Cells["Cobertura"].Value.ToString(), 
                        dgCoberturas.ActiveRow.Cells["CoberturaIngles"].Value.ToString(), dgCoberturas.ActiveRow.Cells["GeniusCode"].Value.ToString(), Convert.ToBoolean(dgCoberturas.ActiveRow.Cells["Defecto"].Value), 
                        Convert.ToBoolean(dgCoberturas.ActiveRow.Cells["userAdd"].Value), Convert.ToBoolean(dgCoberturas.ActiveRow.Cells["Eliminado"].Value), Origen);
                    dsCoberturas.Tables[0].Rows.RemoveAt(dgCoberturas.ActiveRow.Index);
                    expandirGrids();
                }
            }
            else
            {
                if (dgCoberturas.Selected.Rows.Count < 1)
                    MessageBox.Show("Debes seleccionar una cobertura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Debes seleccionar solo una cobertura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRecargarDeducibles_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas sustituir los valores por los que están actualmente en la sección Coberturas?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                dtDeducibles.Rows.Clear();
                for (int i = 0; i < dgCoberturas.Rows.Count; i++)
                {
                    dtDeducibles.Rows.Add(dgCoberturas.Rows[i].Cells["Cobertura"].Text.ToString(), dgCoberturas.Rows[i].Cells["GeniusCode"].Text.ToString(), 0, 0, 0, false, 0, "");
                }
                dgDeducibles.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
        }

        private void btnRecargarSublimites_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas sustituir los valores por los que están actualmente en la sección Coberturas?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                dtSublimites.Rows.Clear();
                for (int i = 0; i < dgCoberturas.Rows.Count; i++)
                {
                    dtSublimites.Rows.Add(dgCoberturas.Rows[i].Cells["Cobertura"].Text.ToString(), 0, "");
                }
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
                //Comenzamos con el line of business (Liability)
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

        private void cbGastosDefensa_ValueChanged(object sender, EventArgs e)
        {
            if (cbGastosDefensa.Text == "Encima del Limite")
            {
                lbPorcentajeLimite.Visible = true;
                txtGastosDefensa.Visible = true;
                //lbMon3.Visible = true;
            }
            else
            {
                lbPorcentajeLimite.Visible = false;
                txtGastosDefensa.Visible = false;
                //lbMon3.Visible = false;
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
                dtDeducibles.Columns.Add("GeniusCode", typeof(string));
                dtDeducibles.Columns.Add("Porcentaje", typeof(decimal));
                dtDeducibles.Columns.Add("Minimo", typeof(decimal));
                dtDeducibles.Columns.Add("Maximo", typeof(decimal));
                dtDeducibles.Columns.Add("SIR", typeof(bool));
                dtDeducibles.Columns.Add("Agregado", typeof(decimal));
                dtDeducibles.Columns.Add("Descripcion", typeof(string));
                dtDeducibles.Rows.Add("Deducible General", "PPC", 0, 0, 0, false, 0, "");
                
                dgDeducibles.DataSource = dtDeducibles;
                dgDeducibles.DisplayLayout.Bands[0].Columns["GeniusCode"].Header.VisiblePosition = 1;
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
                lbExclusionManual.Visible = true;
                txtExclusiones.Visible = true;
            }
            //se ocultan y se resetean todos los controles
            else
            {
                lbExclusionManual.Visible = false;
                txtExclusiones.Visible = false;
                txtExclusiones.Text = "";
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
                lbPrimaReaseguro.Text = "$ 0.00";
                txtPolizaES.Text = "";
            }
        }

        private void chkRetroactiva_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRetroactiva.Checked)
            {
                dateRetroactiva.Visible = true;
                dateRetroactiva.Value = dateInicioVig.Value;
            }
            else
            {
                dateRetroactiva.Visible = false;
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
                dtSublimites.Columns.Add("Descripcion", typeof(string));

                for (int i = 0; i < dgCoberturas.Rows.Count; i++)
                {
                    dtSublimites.Rows.Add(dgCoberturas.Rows[i].Cells["Cobertura"].Text.ToString(), 0, "");
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

        private void dgDeducibles_AfterRowUpdate(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            if (dgDeducibles.Rows.Count > 0)
                dgDeducibles.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
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

        private void dgSublimites_AfterRowUpdate(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            if (dgSublimites.Rows.Count > 0)
                dgSublimites.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
        }

        private void dgSublimites_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
        }

        public LiabilityProd(int idVentana = 0, int idPolizaTemp = 0)
        {
            InitializeComponent();
            llenarControlesObligatorios();
            dbSmartGDataContext db = new dbSmartGDataContext();
            // obtenemos los id's importantes utilizados en todo el formulario
            Liability = (from x in db.LineaNegocios where x.LineaNegocios1 == "Liability" select x.ID).SingleOrDefault();
            Origen = (from x in db.Origen where x.Origen1 == "Producing" select x.ID).SingleOrDefault();
            ventana = idVentana;
            if (idPolizaTemp != 0)
                idPoliza = idPolizaTemp;
        }

        private void LiabilityProd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ventana == 0 || ventana == 1)
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
        }

        private void LiabilityProd_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this, tabControlLiability, ToolsBarLiabilityProd);

            llenarMonedas();
            iniciarDatos();
            if (ventana == 1 || ventana == 2) // carga de ventanas para edicion de guardados - endosos nuevos
            {
                cargarAvances();
                if (ventana == 2)
                {
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    idEndoso = (from x in db.Endoso where x.Poliza == idPoliza orderby x.ID descending select x.ID).FirstOrDefault();
                    if (idEndoso != null)
                    {
                        cambiarControles();
                        cargarEndososPoliza();
                        llenarControlesDatos();
                        Endoso paraConse = (from x in db.Endoso where x.ID == idEndoso select x).SingleOrDefault();
                        if (paraConse != null)
                        {
                            if (paraConse.Consecutivo != null)
                                consecutivoAnteriorEndoso = Convert.ToInt32(paraConse.Consecutivo);
                        }
                        txtTextoLibre.Text = "";
                    }
                    else
                        idEndoso = 0;
                }
            }
            validarDatos(tabControlLiability.ActiveTab.Index);
            txtRetroValidaciones.Text = "";
            tabAnterior = tabControlLiability.ActiveTab.Index;

            this.FormClosing += LiabilityProd_FormClosing;
        }

        private void revisar_Fechas(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas que el sistema ajuste las horas conforme a las reglas de negocio?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int diaInicio = Convert.ToDateTime(dateInicioVig.Value).Day;
                int diaFin = Convert.ToDateTime(dateFinVigencia.Value).Day;
                int mesInicio = Convert.ToDateTime(dateInicioVig.Value).Month;
                int mesFin = Convert.ToDateTime(dateFinVigencia.Value).Month;

                if (diaInicio != diaFin)
                {
                    DateTime tmpIniVig = Convert.ToDateTime(Convert.ToDateTime(dateInicioVig.Value).ToShortDateString());
                    DateTime tmpFinVig = Convert.ToDateTime(Convert.ToDateTime(dateFinVigencia.Value).ToShortDateString());

                    dateInicioVig.Value = tmpIniVig.AddHours(0).AddMinutes(0);
                    dateFinVigencia.Value = tmpFinVig.AddHours(23).AddMinutes(59);
                }
                else
                {
                    if (mesInicio != mesFin)
                    {
                        DateTime tmpIniVig = Convert.ToDateTime(Convert.ToDateTime(dateInicioVig.Value).ToShortDateString());
                        DateTime tmpFinVig = Convert.ToDateTime(Convert.ToDateTime(dateFinVigencia.Value).ToShortDateString());

                        dateInicioVig.Value = tmpIniVig.AddHours(0).AddMinutes(0);
                        dateFinVigencia.Value = tmpFinVig.AddHours(23).AddMinutes(59);
                    }
                    else if (diaInicio == diaFin && mesInicio == mesFin)
                    {
                        DateTime tmpIniVig = Convert.ToDateTime(Convert.ToDateTime(dateInicioVig.Value).ToShortDateString());
                        DateTime tmpFinVig = Convert.ToDateTime(Convert.ToDateTime(dateFinVigencia.Value).ToShortDateString());

                        dateInicioVig.Value = tmpIniVig.AddHours(12);
                        dateFinVigencia.Value = tmpFinVig.AddHours(11).AddMinutes(59);
                    }
                }
            }
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
                    if (ventana == 0 || ventana == 1)
                    {
                        txtRetroValidaciones.Text = "1) Sistema preparandose para guardar";
                        retroalimentacion(guardarAvances());
                    }
                    else if (ventana == 2)
                    {
                        Endoso validar = (from x in db.Endoso where x.Poliza == idPoliza && x.Status == 1 select x).SingleOrDefault();
                        if (validar == null)
                        {
                            if (MessageBox.Show("Para utilizar esta función es necesario validar los datos de la póliza, ¿deseas continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                            {
                                for (int i = 0; i < 10; i++)
                                {
                                    validarDatos(i);
                                }

                                if (validarCorrectos() && validarCliente())
                                {
                                    if (validarEndososPoliza())
                                    {
                                        if (MessageBox.Show("Esta función generará un endoso que modificará la póliza permanentemente, se recomienda generar un previo de la póliza para su revisión, si aun así deseas continuar con la generación del endoso has click en Si", "Aviso importante", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                        {
                                            guardarVariables();
                                            if (guardarEndosos() != 2)
                                            {
                                                guardarVariablesWording();

                                                Endoso tmpConsecutivo = (from x in db.Endoso where x.ID == idEndoso select x).SingleOrDefault();
                                                tmpConsecutivo.Consecutivo = consecutivoAnteriorEndoso + 1;
                                                db.SubmitChanges();

                                                DocumentosDB nuevoPreview = new DocumentosDB();
                                                if (nuevoPreview.ExtraerDocumentoDB("Endoso.docx"))
                                                {
                                                    txtRetroValidaciones.Text += Environment.NewLine + "Generando Endoso...";
                                                    generarEndoso("Endoso.docx", 1, consecutivoAnteriorEndoso + 1);
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Ocurrió un error inesperado al generar el documento (Endoso), comprueba que el archivo no lo tengas abierto, en caso de que esté abierto cierralo y vuelve a solicitar al sistema que genere los documentos, en caso contrario favor de contactar al soporte técnico para futura referencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    return;
                                                }
                                                txtRetroValidaciones.SelectionStart = txtRetroValidaciones.TextLength;
                                                txtRetroValidaciones.ScrollToCaret();

                                                if (MessageBox.Show("Archivo generado satisfactoriamente, ¿Deseas abrir la carpeta?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                                                {
                                                    string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX;
                                                    Process.Start(folder);
                                                }
                                            }

                                            this.Close();
                                        }
                                    }
                                    else
                                        MessageBox.Show("El sistema no ha detectado cambios en la póliza, debes de generar cambios para poder usar la función de Endosos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                            MessageBox.Show("Error: esta póliza tiene un endoso pendiente de autorizar. No se pueden generar endosos nuevos si hay pendientes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                        WordingLiabilityProducing aBloquear = (from x in db.WordingLiabilityProducing where x.IDPoliza == idPoliza select x).SingleOrDefault();
                        if (aBloquear == null)
                        {
                            Poliza aBloquearPoliza = (from x in db.Poliza where x.ID == idPoliza select x).SingleOrDefault();
                            if (aBloquearPoliza.Status != 3)
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
                                            solicitarDocumentos();
                                            controlSave = true;
                                            this.Close();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Todos los campos deben de ser ingresados correctamente, da click en el botón 'Validar Registro' para conocer qué falta. Así mismo el cliente debe de haber sido previamente autorizado por un Administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("La póliza ya se encuentra registrada en el sistema como 'Completada', por lo tanto esta ventana se cerrará y ya no puedes generar documentos, si quieres hacer cambios en la póliza debe ser a través de un endoso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                controlSave = true;
                                this.Close();
                            }
                        }
                        else
                            txtRetroValidaciones.Text = "El sistema se encuentra generando tus documentos, en caso de que esté tomando mucho tiempo contacta al soporte.";
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
                        WordingLiabilityProducing aBloquear = (from x in db.WordingLiabilityProducing where x.IDPoliza == idPoliza select x).SingleOrDefault();
                        if (aBloquear == null)
                        {
                            Poliza aBloquearPoliza = (from x in db.Poliza where x.ID == idPoliza select x).SingleOrDefault();
                            if (aBloquearPoliza.Status != 3)
                            {
                                if (MessageBox.Show("Para utilizar esta función es necesario validar los datos de la póliza, ¿deseas continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                                {
                                    for (int i = 0; i < 9; i++)
                                    {
                                        validarDatos(i);
                                    }

                                    if (validarCorrectos())
                                    {
                                        solicitarPrevio();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("La póliza ya se encuentra registrada en el sistema como 'Completada', por lo tanto esta ventana se cerrará y ya no puedes generar documentos, si quieres hacer cambios en la póliza debe ser a través de un endoso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                controlSave = true;
                                this.Close();
                            }

                        }
                        else
                            txtRetroValidaciones.Text = "El sistema se encuentra generando tus documentos, en caso de que esté tomando mucho tiempo contacta al soporte.";
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
                dtDeducibles.Rows.Add(txtDeducibleManual.Text, 0, 0, 0, false, 0, "");
                txtDeducibleManual.Text = "";
                dgDeducibles.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
        }

        private void txtNuevaCobertura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtNuevaCobertura.Text != "")
            {
                dsCoberturas.Tables[0].Rows.Add(coberturaM, Liability, txtNuevaCobertura.Text, "TBD", "OTH", false, true, false, Origen);
                coberturaM--;
                txtNuevaCobertura.Text = "";
                dgCoberturas.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                expandirGrids();
            }
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
                dtSublimites.Rows.Add(txtSublimiteManual.Text, 0, "");
                txtSublimiteManual.Text = "";
                dgSublimites.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
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
            MessageBox.Show("El formato correcto para la póliza MX es el siguiente: MX + 8 dígitos de seguimiento + LI + 2 dítigos del año de emisión + 1 caracter, verifica los datos ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtQuoteNumber_Leave(object sender, EventArgs e)
        {
            if (txtQuoteNumber.Text != "")
                txtQuoteNumber.Text = txtQuoteNumber.Text.ToUpper();
        }

        private void txtQuoteNumber_MaskValidationError(object sender, Infragistics.Win.UltraWinMaskedEdit.MaskValidationErrorEventArgs e)
        {
            MessageBox.Show("El formato correcto para el Quote Number es el siguiente: QMX + 7 dígitos de seguimiento + LI + 2 dítigos del año de emisión + 1 caracter, verifica los datos ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtPrimaEndoso_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtPrimaEndoso_Leave(object sender, EventArgs e)
        {
            decimal primaAntes = Convert.ToDecimal(txtPrimaMain.Value);
            decimal primaNueva = Convert.ToDecimal(txtPrimaEndoso.Value);
            if (primaNueva == 0)
            {
                txtPrimaMain.Value = primaAnterior;
                txtPrimaMain_Leave(null, null);
            }
            else
            {
                if (primaAntes + primaNueva > 0)
                {
                    txtPrimaMain.Value = primaAntes + primaNueva;
                    txtPrimaMain_Leave(null, null);
                }
                else
                {
                    MessageBox.Show("No puedes restar más del valor actual de la prima, no puede haber primas negativas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgSublimites_AfterRowsDeleted(object sender, EventArgs e)
        {
            if (dgSublimites.Rows.Count > 0)
                dgSublimites.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
        }

        private void dgDeducibles_AfterRowsDeleted(object sender, EventArgs e)
        {
            if (dgDeducibles.Rows.Count > 0)
                dgDeducibles.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
        }







        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************



    }
}
