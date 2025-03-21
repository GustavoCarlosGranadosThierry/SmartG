﻿using System;
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
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Globalization;
using System.Threading;

namespace SmartG.Operaciones.Emision
{
    public partial class PropertyInc : Form
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
        //dateEmision

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
        //lbAseguradoAdicional      Asegurado Adicional (separe la dirección con una coma)
        //txtAseguAdicional
        //grpListaAseguAdicionales
        //dgAseguAdicionales
        //lbBenefPref	Beneficiario Preferente
        //txtBenefPref
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
        #region cuarta tab limites
        //grpLimitesInfo		1) Informacion de Limites
        //grpLimiteMaximo     Limite Máximo de Responsabilidad
        //lbLimiteMaximoCombinado Limite Máximo Combinado
        //txtLimiteMaximo
        //lbMon1          Mon1
        //grpLimites	2) Límites de Responsabilidad
        //lbTipoLimite	Tipo de límite
        //cbTipoLimite
        //cbCombinadoSL
        //btnClausulasAdicionales	Clausulas adicionales Contratadas
        //grpEstructuraLimite Estructura del Limite
        //lbEstructuraLimite Estructura Limite
        //lbGastosDefensa     Gastos de Defensa
        //cbEstructuraLimite
        //lbSujecion      Sujecion
        //txtSujecion
        //grpControlLimites Control de Límites
        //lbMon2          Mon2
        //chkLimites	Aplican límites
        //dgLimites
        //lbRecargarLimites	1) Click para recargar los límites por defecto
        //btnRecargarLimites
        //lbLimiteManual		2) Agrege un límite manualmente
        //txtLimiteManual
        #endregion
        #region quinta tab sublimites
        //grpSublimites		1) Sublimites de Responsabilidad
        //grpControlSublimites    Control de Sublimites
        //chkSublimites       Aplican Sublimites
        //btnRecargarSublimites
        //lbRecargarSublimites	1) Click para recargar los sublimites con las coberturas de la Póliza
        //lbSublimiteManual	2) Agrege un sublimite manualmente
        //txtSublimiteManual
        //dgSublimites
        #endregion
        #region sexta tab deducibles
        //grpDeducibles		1) Deducibles aplicables a la póliza
        //grpControlDeducibles    Control de Deducibles
        //chkDeducibles       Aplican Deducibles
        //btnRecargarDeducibles
        //lbRecargarDeducibles	1) Click para recargar los deducibles por las coberturas de la Póliza
        //lbDeducibleManual	2) Agrege un deducible manualmente
        //txtDeducibleManual
        //dgDeducibles
        #endregion
        #region septima tab ubicaciones
        //grpUbicacionesProp	1) Ubicaciones
        //grpControlUbicaciones Control de Ubicaciones
        //chkUbicaciones    Aplican Ubicaciones
        //dgUbicaciones
        //grpCalculoUbica		2) Cálculo de las ubicaciones
        //lbSumEdif		∑ Edificios
        //txtSumEdif
        //lbSumConte		∑ Contenidos
        //txtSumConte
        //lbSumInventa		∑ Inventarios
        //txtSumInventa
        //lbSumPD			∑ PD
        //txtSumPD
        //lbSumBI			∑ BI
        //txtSumBI
        //lbSumTotales		∑ Total
        //txtSumTotales
        //lbMon3 Mon3
        #endregion
        #region octava tab valores genius
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
        #region novena tab desglose de IVA
        //grpDesglosePrimaPrinc		1) Introduzca la prima neta instruida de la póliza
        //grpPrimaDesglose
        //lbPrimaInstruida        Prima instruida
        //txtPrimaInstruida
        //lbMon17             Mon17
        //btnGenerarDesglose      Generar Desglose
        //dgDesglosePrima
        #endregion
        #region decima tab info schedule
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
        #region onceava Tab coaseguros
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
        #region doceava tab reaseguros
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
        int? idPolizaPro = 0;
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
        string DAM;
        int? PAM;
        int? country;
        int? Broker;
        int? aseguradoPrincipal;
        int? direccionAseguradoPrincipal;
        DataTable dtAseguradosAdicionales;
        string beneficiarioPreferente;
        string delimitacionTerritorial;
        #endregion
        #region segunda tab coberturas
        DataTable dtCoberturas;
        DataTable dtCoberturasDB;
        #endregion
        #region tercera tab endosos
        DataTable dtEndosos;
        #endregion
        #region cuarta tab limites
        decimal limiteMaximo;
        string estructuraLimite;
        decimal sujecion;
        DataTable dtLimites;
        public static string coberturasAdicionales = "";
        string tipoLimite;
        #endregion
        #region quinta tab sublimites
        DataTable dtSublimites;
        #endregion
        #region sexta tab deducibles
        DataTable dtDeducibles;
        #endregion
        #region septima tab ubicaciones
        DataTable dtUbicaciones;
        decimal totalEdificios = 0;
        decimal totalContenidos = 0;
        decimal totalInventarios = 0;
        decimal totalPD = 0;
        decimal totalBI = 0;
        decimal totalTotal = 0;
        #endregion
        #region octava tab valores Genius
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
        #region novena tab Desglose IVA
        DataTable dtDesgloseIVA;
        #endregion
        #region decima tab info schedule
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
        #region onceava tab coaseguro
        int? idCoaseguradorLider;
        decimal porcParticipacionXL;
        DataTable dtCoaseguros;
        decimal cantidadCoaseguro = 0;
        #endregion
        #region doceava tab reaseguro
        DataTable dtReaseguro;
        int idIntermediarioDefault;
        decimal cantidadReaseguro = 0;
        int loadReaseguro = 0;
        #endregion
        #region Variables Generales
        Control[] controlesObligatorios;
        Control[] labelsMonedas;
        int Property;
        int Origen;
        int coberturaM = -1;
        string[] columnasObligatorias;
        bool controlSave = false;
        int? idDefaultCoaseguradora = 0;
        int? idDefaultReaseguradora = 0;
        int ventana = 0;
        int tabAnterior = 0;
        bool bloqueoPaste = false;
        #endregion
        #region Variables Wording
        string strIniVig;
        string strFinVig;
        string strIniVig2;
        string strFinVig2;
        string diaAnterior;
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
        string strTipoLimite;
        string strLimite;
        string strCoberturas;
        string strDeducibles;
        double strPartReasegurada = 0;
        double strPartTotal = 0;
        double strInternationalCalc = 0;
        double strComisionInter = 0;
        string ubicacionesSumas = "";
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

                    case 1: //PolizaLimites
                        PolizaLimites[] aBorrarLim = (from x in db.PolizaLimites where x.Poliza == idPoliza select x).ToArray();
                        if (aBorrarLim.Count() > 0)
                        {
                            db.PolizaLimites.DeleteAllOnSubmit(aBorrarLim);
                            db.SubmitChanges();
                        }
                        break;

                    case 2: // PolizaSublimites
                        PolizaSublimites[] aBorrarSubL = (from x in db.PolizaSublimites where x.Poliza == idPoliza select x).ToArray();
                        if (aBorrarSubL.Count() > 0)
                        {
                            db.PolizaSublimites.DeleteAllOnSubmit(aBorrarSubL);
                            db.SubmitChanges();
                        }
                        break;

                    case 3: // PolizaDeducibles
                        PolizaDeducible[] aBorrarDedu = (from x in db.PolizaDeducible where x.Poliza == idPoliza select x).ToArray();
                        if (aBorrarDedu.Count() > 0)
                        {
                            db.PolizaDeducible.DeleteAllOnSubmit(aBorrarDedu);
                            db.SubmitChanges();
                        }
                        break;

                    case 4: // PolizaUbicacionesRiesgo
                        PolizaUbicacionesRiesgo[] aBorrarUbi = (from x in db.PolizaUbicacionesRiesgo where x.PolizaProperty == idPolizaPro select x).ToArray();
                        if (aBorrarUbi.Count() > 0)
                        {
                            db.PolizaUbicacionesRiesgo.DeleteAllOnSubmit(aBorrarUbi);
                            db.SubmitChanges();
                        }
                        break;

                    case 5: // InfoSchedule
                        InfoSchedule infoDelete = (from x in db.InfoSchedule where x.Poliza == idPoliza select x).SingleOrDefault();
                        if (infoDelete != null)
                        {
                            db.InfoSchedule.DeleteOnSubmit(infoDelete);
                            db.SubmitChanges();
                        }
                        break;

                    case 6: // Clientes
                        PolizaCliente[] aBorrarClientes = (from x in db.PolizaCliente where x.Poliza == idPoliza select x).ToArray();
                        if (aBorrarClientes.Count() > 0)
                        {
                            db.PolizaCliente.DeleteAllOnSubmit(aBorrarClientes);
                            db.SubmitChanges();
                        }
                        break;

                    case 7: // Coaseguros
                        PolizaCoaseguro[] aBorrarCoase = (from x in db.PolizaCoaseguro where x.Poliza == idPoliza select x).ToArray();
                        if (aBorrarCoase.Count() > 0)
                        {
                            db.PolizaCoaseguro.DeleteAllOnSubmit(aBorrarCoase);
                            db.SubmitChanges();
                        }
                        break;

                    case 8: // reaseguro
                        PolizaReaseguro[] aBorrarRease = (from x in db.PolizaReaseguro where x.Poliza == idPoliza select x).ToArray();
                        if (aBorrarRease.Count() > 0)
                        {
                            db.PolizaReaseguro.DeleteAllOnSubmit(aBorrarRease);
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

        string calcularIndiceLetraExcel(int indice)
        {
            string letra = "";
            switch (indice)
            {
                case 0:
                    letra = "A";
                    break;
                case 1:
                    letra = "B";
                    break;
                case 2:
                    letra = "C";
                    break;
                case 3:
                    letra = "D";
                    break;
                case 4:
                    letra = "E";
                    break;
                case 5:
                    letra = "F";
                    break;
                case 6:
                    letra = "G";
                    break;
                case 7:
                    letra = "H";
                    break;
                case 8:
                    letra = "I";
                    break;
                case 9:
                    letra = "J";
                    break;
                case 10:
                    letra = "K";
                    break;
                case 11:
                    letra = "L";
                    break;
                case 12:
                    letra = "M";
                    break;
                case 13:
                    letra = "N";
                    break;
                case 14:
                    letra = "O";
                    break;
                case 15:
                    letra = "P";
                    break;
                case 16:
                    letra = "Q";
                    break;
                case 17:
                    letra = "R";
                    break;
                case 18:
                    letra = "S";
                    break;
                case 19:
                    letra = "T";
                    break;
                case 20:
                    letra = "U";
                    break;
                case 21:
                    letra = "V";
                    break;
                case 22:
                    letra = "W";
                    break;
                case 23:
                    letra = "X";
                    break;
                case 24:
                    letra = "Y";
                    break;
                case 25:
                    letra = "Z";
                    break;
            }
            return letra;
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

        void calcularUbicaciones()
        {
            for (int i = 0; i < dgUbicaciones.Rows.Count; i++)
            {
                if (dgUbicaciones.Rows[i].Cells["Direccion"].Text != "")
                {
                    dgUbicaciones.Rows[i].Cells["PD"].Value = Convert.ToDecimal(dgUbicaciones.Rows[i].Cells["Edificio"].Text) + Convert.ToDecimal(dgUbicaciones.Rows[i].Cells["Contenidos"].Text) +
                    Convert.ToDecimal(dgUbicaciones.Rows[i].Cells["Inventarios"].Text);
                    dgUbicaciones.Rows[i].Cells["BI"].Value = Convert.ToDecimal(dgUbicaciones.Rows[i].Cells["Consecuenciales"].Text);
                    dgUbicaciones.Rows[i].Cells["Total"].Value = Convert.ToDecimal(dgUbicaciones.Rows[i].Cells["PD"].Text) + Convert.ToDecimal(dgUbicaciones.Rows[i].Cells["BI"].Text);
                }
            }
        }

        void calcularTotalesUbicaciones()
        {
            txtSumEdif.Value = 0;
            txtSumConte.Value = 0;
            txtSumInventa.Value = 0;
            txtSumPD.Value = 0;
            txtSumBI.Value = 0;
            txtSumTotales.Value = 0;

            for (int i = 0; i < dgUbicaciones.Rows.Count; i++)
            {
                if (dgUbicaciones.Rows[i].Cells["Direccion"].Text != "")
                {
                    txtSumEdif.Value = Convert.ToDecimal(txtSumEdif.Value) + Convert.ToDecimal(dgUbicaciones.Rows[i].Cells["Edificio"].Text);
                    txtSumConte.Value = Convert.ToDecimal(txtSumConte.Value) + Convert.ToDecimal(dgUbicaciones.Rows[i].Cells["Contenidos"].Text);
                    txtSumInventa.Value = Convert.ToDecimal(txtSumInventa.Value) + Convert.ToDecimal(dgUbicaciones.Rows[i].Cells["Inventarios"].Text);
                    txtSumPD.Value = Convert.ToDecimal(txtSumPD.Value) + Convert.ToDecimal(dgUbicaciones.Rows[i].Cells["PD"].Text);
                    txtSumBI.Value = Convert.ToDecimal(txtSumBI.Value) + Convert.ToDecimal(dgUbicaciones.Rows[i].Cells["BI"].Text);
                    txtSumTotales.Value = Convert.ToDecimal(txtSumTotales.Value) + Convert.ToDecimal(dgUbicaciones.Rows[i].Cells["Total"].Text);
                }
            }
        }

        void cargarAvances()
        {
            txtRetroValidaciones.Text = "";
            cargarPoliza();
            cargarCoberturas();
            cargarEndosos();
            cargarLimites();
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
            txtRetroValidaciones.Text += "1) Datos Generales cargados satisfactoriamente";

            PolizaProperty tmpPolizaProp = (from y in db.PolizaProperty where y.Poliza == idPoliza select y).SingleOrDefault();
            if (tmpPolizaProp != null)
            {
                txtBenefPref.Text = tmpPolizaProp.BeneficiarioPreferente;
                cbTipoLimite.Text = tmpPolizaProp.LimiteEvento;
                coberturasAdicionales = tmpPolizaProp.CoberturasAdicionales;
                cbPrograma.Value = tmpPolizaProp.Programa;
                if (tmpPolizaProp.Ajustable != null)
                {
                    if (Convert.ToBoolean(tmpPolizaProp.Ajustable))
                        chkAjustable.Checked = true;
                }
                cbEstructuraLimite.Text = tmpPolizaProp.EstructuraLimite;
                txtSujecion.Value = tmpPolizaProp.Sujecion;
                idPolizaPro = tmpPolizaProp.ID;

                if (tmpPolizaProp.Ubicaciones != null)
                {
                    DocumentosDB dbExtractor = new DocumentosDB();
                    dbExtractor.ExtraerUbicacionesProperty(Convert.ToInt32(idPolizaPro), 1);
                    #region cargarExcel
                    Excel.Application xlApp = new Excel.Application();
                    Excel.Workbook xlWorkbook = xlApp.Workbooks.Open("C:\\SmartG\\temp.xls");
                    Excel.Worksheet workSheet = (Excel.Worksheet)xlWorkbook.Worksheets[1];
                    Excel.Range last = workSheet.Cells.SpecialCells(Excel.Enums.XlCellType.xlCellTypeLastCell, Type.Missing);
                    Excel.Range range = workSheet.get_Range("A1", last);
                    range.Copy();
                    chkUbicaciones.Checked = true;
                    importarExcel(0);
                    xlApp.DisplayAlerts = false;
                    xlApp.DisplayClipboardWindow = false;
                    xlWorkbook.Close();
                    xlApp.Quit();
                    xlApp.Dispose();
                    File.Delete("C:\\SmartG\\temp.xls");
                    #endregion
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

        void cargarCoberturas()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
           
            int?[] idCoberturas = (from x in db.PolizaCobertura where x.Poliza == idPoliza select x.Cobertura).ToArray();
            if (idCoberturas.Count() > 0)
            {
                coberturasDBTableAdapter.FillByTodosDB(this.coberturasOrdenadas.CoberturasDB, Property, Origen);
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
                           Property, dgCoberturasDB.Rows[j].Cells["Cobertura"].Text.ToString(), dgCoberturasDB.Rows[j].Cells["CoberturaIngles"].Text.ToString(),
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
                        coberturasOrdenadas.Coberturas.Rows.Add(cobTMP.ID, Property, cobTMP.Cobertura, cobTMP.CoberturaIngles, cobTMP.GeniusCode, cobTMP.Defecto, cobTMP.userAdd, cobTMP.Eliminado, cobTMP.Origen, cobTMP.OrdenImpresion);
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
            txtRetroValidaciones.Text += Environment.NewLine + "Endosos Cargados satisfactoriamente";
        }

        void cargarLimites()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            PolizaLimites[] limites = (from x in db.PolizaLimites where x.Poliza == idPoliza select x).ToArray();
            if (limites.Count() > 0)
            {
                chkLimites.Checked = true;
                dtLimites.Rows.Clear();
                for (int i = 0; i < limites.Count(); i++)
                {
                    dtLimites.Rows.Add(limites[i].Limite, limites[i].Descripcion, limites[i].Monto);
                }
                dgLimites.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
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
                    dtSublimites.Rows.Add(sublimites[i].SubLimite, sublimites[i].Monto, sublimites[i].MaximoEn, sublimites[i].Descripcion);
                    dgSublimites.Rows[i].Cells["Combinado"].Value = sublimites[i].Combinado;
                }
                dgSublimites.DisplayLayout.Bands[0].Columns["Sublimite"].Width = 800;
                dgSublimites.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree;
            }
            txtRetroValidaciones.Text += Environment.NewLine + "3) Limites Sublimites Cargados satisfactoriamente";
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
                    dtDeducibles.Rows.Add(deducibles[i].Deducible, deducibles[i].Porcentaje, deducibles[i].Minimo, deducibles[i].Maximo, deducibles[i].Agregado, deducibles[i].Descripcion);
                    dgDeducibles.Rows[i].Cells["Seccion"].Value = deducibles[i].Seccion;
                }
                dgDeducibles.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
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

                txtPrimaInstruida.Value = txtPrimaMain.Value;
                txtPrimaInstruida_Leave(null, null);
            }
            calcularPrimaTotal();
            calcularBrokerage();
            terminarEdicionGrids();
            txtRetroValidaciones.Text += Environment.NewLine + "6) Prima Cargada satisfactoriamente";
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
                    string[] tmpAseAdi = aseguAdicionales[i].NombreAsegurado.Split('|');
                    dtAseguradosAdicionales.Rows.Add(tmpAseAdi[0],tmpAseAdi[1]);
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
                    ac.Selection.TypeText(Convert.ToDouble(txtLimiteMaximo.Value).ToString("#,##0.00", new CultureInfo("en-US")));
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

                // desglose de prima
                bookmarkName = "DesglosePrima";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["DesglosePrima"].Start;
                    object finB = doc.Bookmarks["DesglosePrima"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    int fila = 1;
                    Word.Table tabla = doc.Tables.Add(rng, 2, 2);
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Secciones contratadas");
                    tabla.Cell(fila, 2).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Desglose de prima"); fila = fila+2;
                    for (int i = 0; i < dgDesglosePrima.Rows.Count; i++)
                    {
                        if (Convert.ToDouble(dgDesglosePrima.Rows[i].Cells["PrimaNeta"].Text) > 0)
                        {
                            tabla.Rows.Add();
                            tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText(dgDesglosePrima.Rows[i].Cells["Concepto"].Text);
                            tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strAbreMon + "        " + Convert.ToDouble(dgDesglosePrima.Rows[i].Cells["PrimaNeta"].Text).ToString("#,##0.00", new CultureInfo("en-US"))); fila++;
                        }
                    }
                    tabla.Rows.Add();
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.TypeText("Prima Total");
                    tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strAbreMon + "        " + primaNeta.ToString("#,##0.00", new CultureInfo("en-US"))); fila = fila + 2;
                }

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
            catch (Exception ex)
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

        bool generarUbicaciones()
        {
            // Genera la tabla y el archivo XLS
            ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook();
            try
            {
                string outputFile = "C:\\SmartG\\tmpUbicaciones.xlsx";
                DataTable dtUbicaciones = new DataTable();
                for (int i = 0; i < dgUbicaciones.DisplayLayout.Bands[0].Columns.Count; i++)
                {
                    double controlTipo = 0;
                    if (double.TryParse(dgUbicaciones.Rows[0].Cells[i].Text, out controlTipo))
                    {
                        if(dgUbicaciones.DisplayLayout.Bands[0].Columns[i].Header.Caption != "Codigo Postal")
                            dtUbicaciones.Columns.Add(dgUbicaciones.DisplayLayout.Bands[0].Columns[i].Header.Caption, typeof(double));
                        else
                            dtUbicaciones.Columns.Add(dgUbicaciones.DisplayLayout.Bands[0].Columns[i].Header.Caption, typeof(string));
                    }
                    else
                        dtUbicaciones.Columns.Add(dgUbicaciones.DisplayLayout.Bands[0].Columns[i].Header.Caption, typeof(string));
                }
                for (int i = 0; i < dgUbicaciones.Rows.Count; i++)
                {
                    DataRow row = dtUbicaciones.NewRow();
                    for (int j = 0; j < dgUbicaciones.DisplayLayout.Bands[0].Columns.Count; j++)
                    {
                        if (dgUbicaciones.Rows[i].Cells[j].Text != "")
                            row[j] = dgUbicaciones.Rows[i].Cells[j].Text;
                        else
                            break;
                    }
                    dtUbicaciones.Rows.Add(row);
                }

                dtUbicaciones.Columns["Direccion"].SetOrdinal(0);
                dtUbicaciones.Columns["Edificio"].SetOrdinal(1);
                dtUbicaciones.Columns["Contenidos"].SetOrdinal(2);
                dtUbicaciones.Columns["Inventarios"].SetOrdinal(3);
                dtUbicaciones.Columns["Consecuenciales"].SetOrdinal(4);
                dtUbicaciones.Columns["PD"].SetOrdinal(5);
                dtUbicaciones.Columns["BI"].SetOrdinal(6);
                dtUbicaciones.Columns["Total"].SetOrdinal(7);

                // Agrega columnas, asigna y ordena
                dtUbicaciones.Columns.Add("TOTAL PD", typeof(double));
                dtUbicaciones.Columns.Add("TOTAL BI", typeof(double));
                dtUbicaciones.Columns.Add("Período de Indemnización", typeof(string));
                dtUbicaciones.Columns.Add("TOTAL PD+BI", typeof(double));
                dtUbicaciones.Columns.Add("Contador", typeof(int));
                dtUbicaciones.Columns["Contador"].SetOrdinal(0);

                // guardamos los indices para las sumas
                string indiceSumas = calcularIndiceLetraExcel(dtUbicaciones.Columns["TOTAL PD"].Ordinal);
                indiceSumas += "|" + calcularIndiceLetraExcel(dtUbicaciones.Columns["TOTAL BI"].Ordinal);
                indiceSumas += "|" + calcularIndiceLetraExcel(dtUbicaciones.Columns["TOTAL PD+BI"].Ordinal);

                ubicacionesSumas = indiceSumas;

                int cont = 1;
                foreach (DataRow row in dtUbicaciones.Rows)
                {
                    if (row["Edificio"].ToString() != "")
                    {
                        //Contador
                        row["Contador"] = cont;
                        cont++;

                        // Total PD
                        double tPD = Convert.ToDouble(row["Edificio"].ToString()) + Convert.ToDouble(row["Contenidos"].ToString()) + Convert.ToDouble(row["Inventarios"].ToString());
                        row["TOTAL PD"] = tPD;

                        // Total BI
                        row["TOTAL BI"] = row["Consecuenciales"].ToString();
                        row["Período de Indemnización"] = "12";

                        // Total PD+BI
                        double tPDBI = tPD + Convert.ToDouble(row["Consecuenciales"].ToString());
                        row["TOTAL PD+BI"] = tPDBI;
                    }
                }

               
                wb.Worksheets.Add(dtUbicaciones, "Desgloce de Ubicaciones");
                wb.SaveAs(outputFile);
               
                wb.Dispose();

                // Agrega los encabezados
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(outputFile);
                Excel.Worksheet workSheet = (Excel.Worksheet)xlWorkbook.Worksheets[1];
                //xlApp.Visible = true;

                workSheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                workSheet.PageSetup.Zoom = false;
                workSheet.PageSetup.FitToPagesWide = 1;
                workSheet.PageSetup.PaperSize = XlPaperSize.xlPaperLetter;
                xlApp.ActiveWorkbook.Save();
                xlApp.Quit();
                xlApp.Dispose();
                return true;

            }
            catch
            {
                MessageBox.Show("Ocurrió un error al generar el desglose de ubicaciones, favor de contactar al soporte técnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                wb.Dispose();
                return false;
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
            //ac.Visible = true;

            Word.Document doc = ac.Documents.Open(outputFile, m, readOnly,
                 m, m, m, m, m, m, m, m, m, m, m, m, m);

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
                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.Font.Name = "Arial"; ac.Selection.Font.Size = 10; ac.Selection.TypeText("Número de póliza:");
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
                        tabla.Cell(fila, 2).Select(); ac.Selection.TypeText(strAseguAdicional); fila++;
                    }
                }

                bookmarkName = "TablaSublimites";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    if (chkSublimites.Checked)
                    {
                        string tmpSubBookmark = "MonedaSublimites";
                        if (doc.Bookmarks.Exists(tmpSubBookmark))
                        {
                            object inicioT = doc.Bookmarks["MonedaSublimites"].Start;
                            object finT = doc.Bookmarks["MonedaSublimites"].End;
                            Word.Range rngT = doc.Range(inicioT, finT);
                            rngT.Select();
                            ac.Selection.TypeText(strAbreMon);
                        }
                        int rowDefault = 4;
                        int casoL = 0;
                        for (int i = 0; i < dgSublimites.Rows.Count; i++)
                        {
                            string CobGeneral = dgSublimites.Rows[i].Cells["Sublimite"].Text;//double.Parse(row.Cells["Porcentaje"].Text).ToString("#,##0.00", new CultureInfo("en-US"))
                            string Monto = ((int)double.Parse(dgSublimites.Rows[0].Cells["Por Evento"].Text)).ToString();
                            string Agregado = ((int)double.Parse(dgSublimites.Rows[i].Cells["Maximo En"].Text)).ToString();
                            string Combinado = dgSublimites.Rows[i].Cells["Combinado"].Text;
                            string IncluirEn = dgSublimites.Rows[i].Cells["Incluido En"].Text;

                            // formatea los valores
                            int validador = 0;
                            if (int.TryParse(CobGeneral.Substring(0, 2), out validador))
                            {
                                CobGeneral = CobGeneral.Substring(5, CobGeneral.Length - 5); // le quita los indices, si los tiene
                            }

                            if (Convert.ToDouble(Monto) == 0 && Convert.ToDouble(Agregado) == 0 && IncluirEn == "") { Monto = "Excluido"; casoL = 0; } // Caso de exclusion de cobertura
                            else if (Convert.ToDouble(Monto) != 0) { if (Convert.ToDouble(Agregado) == 0) Agregado = "-.-"; casoL = 1; } // Caso sin Agregado, solo Monto
                            else if (Convert.ToDouble(Monto) == 0 && Convert.ToDouble(Agregado) == 0 && IncluirEn != "") { casoL = 2; } // Caso con Incluido en alguna otra cobertura

                            int tablecount = doc.Tables.Count;
                            for (int j = 1; j <= tablecount; j++)
                            {
                                Word.Table wTable = doc.Tables[j];
                                Word.Cell pCell = wTable.Cell(3, 1);
                                if (pCell.Range.Text == "Coberturas Generales\r\a")
                                {
                                    if (i + 1 < dgSublimites.Rows.Count)
                                    {
                                        Word.Row row = wTable.Rows.Add();
                                    }

                                    switch (casoL)
                                    {
                                        case 0:
                                            wTable.Cell(rowDefault, 1).Range.Text = CobGeneral;
                                            wTable.Cell(rowDefault, 2).Range.Text = Convert.ToDouble(Monto).ToString("#,##0", new CultureInfo("en-US")); ;
                                            wTable.Rows[rowDefault].Cells[2].Merge(wTable.Rows[rowDefault].Cells[4]);
                                            wTable.Cell(rowDefault, 2).Range.ParagraphFormat.Alignment = Word.Enums.WdParagraphAlignment.wdAlignParagraphCenter;
                                            break;
                                        case 1:
                                            wTable.Cell(rowDefault, 1).Range.Text = CobGeneral;
                                            wTable.Cell(rowDefault, 2).Range.Text = Convert.ToDouble(Monto).ToString("#,##0", new CultureInfo("en-US"));
                                            if(Agregado == "-.-")
                                                wTable.Cell(rowDefault, 3).Range.Text = Agregado;
                                            else
                                                wTable.Cell(rowDefault, 3).Range.Text = Convert.ToDouble(Agregado).ToString("#,##0", new CultureInfo("en-US"));
                                            wTable.Cell(rowDefault, 4).Range.Text = Combinado;
                                            break;
                                        case 2:
                                            wTable.Cell(rowDefault, 1).Range.Text = CobGeneral;
                                            wTable.Cell(rowDefault, 2).Range.Text = IncluirEn;
                                            wTable.Cell(rowDefault, 4).Range.Text = Combinado;
                                            wTable.Rows[rowDefault].Cells[2].Merge(wTable.Rows[rowDefault].Cells[3]);
                                            wTable.Cell(rowDefault, 2).Range.ParagraphFormat.Alignment = Word.Enums.WdParagraphAlignment.wdAlignParagraphCenter;
                                            break;
                                    }
                                    rowDefault++;

                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        object inicioB = doc.Bookmarks["TablaSublimites"].Start;
                        object finB = doc.Bookmarks["TablaSublimites"].End;
                        Word.Range rng = doc.Range(inicioB, finB);
                        rng.Select();
                        ac.Selection.Cut();
                    }
                }

                int entro = 0;
                int tablecount2 = doc.Tables.Count;
                for (int j = 1; j <= tablecount2; j++)
                {
                    Word.Table wTable = doc.Tables[j];
                    Word.Cell pCell = wTable.Cell(1, 1);
                    if (pCell.Range.Text == "\r\rCondiciones especiales\r\a")
                    {
                        string CobAdicionalFull = coberturasAdicionales; // Texto Completo
                        string[] CobAdicionalLinea = CobAdicionalFull.Split('|');  // Linea de cobertura
                        for (int i = 0; i < CobAdicionalLinea.Length; i++)
                        {
                            string[] CobAdiInd = CobAdicionalLinea[i].Split(';'); // Individual
                            for (int k = 0; k < CobAdiInd.Length; k++)
                            {
                                string valor = CobAdiInd[k]; // Valor individual a pegar
                                if (valor == "T") { valor = "X"; }
                                else { continue; } // Salta al siguiente valor si no esta chequeado el valor
                                wTable.Cell(i + 3, k).Range.Text = valor;
                                entro++;
                            }
                        }
                        break;
                    }
                }
                if (entro == 0)
                {
                    bookmarkName = "CoberturasAdicionales";
                    if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                    {
                        object inicioB = doc.Bookmarks["CoberturasAdicionales"].Start;
                        object finB = doc.Bookmarks["CoberturasAdicionales"].End;
                        Word.Range rng = doc.Range(inicioB, finB);
                        rng.Select();
                        ac.Selection.Cut();
                    }
                }

                bookmarkName = "TablaLimites";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    if (chkLimites.Checked)
                    {
                        int rowDefault2 = 2;
                        int tablecount3 = doc.Tables.Count;
                        for (int j = 1; j <= tablecount3; j++)
                        {
                            Word.Table wTable = doc.Tables[j];
                            Word.Cell pCell = wTable.Cell(1, 1);
                            if (pCell.Range.Text == "Sumas Aseguradas declaradas al 100%:\r\a")
                            {
                                string ValorSeccion = "";
                                for (int i = 0; i < dgLimites.Rows.Count; i++)
                                {
                                    string Seccion = dgLimites.Rows[i].Cells["Seccion"].Text;
                                    if (Seccion == ValorSeccion)
                                    {
                                        Seccion = "";
                                    }
                                    else
                                    {
                                        if (i != 0)
                                        {
                                            Word.Row rowAdd = wTable.Rows.Add();
                                            rowDefault2++;
                                        }
                                    }
                                    string Descripcion = dgLimites.Rows[i].Cells["Descripcion"].Text;
                                    string Monto = dgLimites.Rows[i].Cells["Monto"].Text;
                                    string MontoCur = double.Parse(Monto).ToString("#,##0.00", new CultureInfo("en-US")) + " " + strAbreMon;
                                    wTable.Cell(rowDefault2, 1).Range.Text = Seccion;
                                    wTable.Cell(rowDefault2, 2).Range.Text = Descripcion;
                                    wTable.Cell(rowDefault2, 3).Range.Text = MontoCur;
                                    Word.Row row = wTable.Rows.Add();

                                    ValorSeccion = dgLimites.Rows[i].Cells["Seccion"].Text;
                                    rowDefault2++;
                                }
                                wTable.Rows[rowDefault2].Delete();
                                break;
                            }

                        }
                    }
                    else
                    {
                        object inicioB = doc.Bookmarks["TablaLimites"].Start;
                        object finB = doc.Bookmarks["TablaLimites"].End;
                        Word.Range rng = doc.Range(inicioB, finB);
                        rng.Select();
                        ac.Selection.Cut();
                    }
                }

                bookmarkName = "TipoLimite";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["TipoLimite"].Start;
                    object finB = doc.Bookmarks["TipoLimite"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strTipoLimite);
                }

                bookmarkName = "Limite";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["Limite"].Start;
                    object finB = doc.Bookmarks["Limite"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strLimite);
                }

                bookmarkName = "MonedaLimite";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["MonedaLimite"].Start;
                    object finB = doc.Bookmarks["MonedaLimite"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strAbreMon);
                }

                // deducibles
                bookmarkName = "MonedaDeducible";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["MonedaDeducible"].Start;
                    object finB = doc.Bookmarks["MonedaDeducible"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strAbreMon);
                }
                int tablecount4 = doc.Tables.Count;
                int rowDefault4 = 2;
                for (int k = 1; k <= tablecount4; k++)
                {
                    Word.Table wTableDed = doc.Tables[k];
                    Word.Cell pCellDed = wTableDed.Cell(1, 1);
                    if (pCellDed.Range.Text == "Deducibles-Tabla\r\a")
                    {
                        if (chkDeducibles.Checked)
                        {
                            dgDeducibles.DisplayLayout.Bands[0].Columns["Seccion"].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending;
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
                                switch (caso)
                                {
                                    case 1: // Solo porcentaje
                                        strDeducibles = double.Parse(row.Cells["Porcentaje"].Text).ToString("#,##0.00", new CultureInfo("en-US")) + "% por evento.";
                                        break;
                                    case 2: // Porcentaje con minimo
                                        strDeducibles = double.Parse(row.Cells["Porcentaje"].Text).ToString("#,##0.00", new CultureInfo("en-US")) + "% con mínimo de " + double.Parse(row.Cells["Minimo"].Text).ToString("#,##0.00", new CultureInfo("en-US")) + " " + strAbreMon + " por evento";
                                        break;
                                    case 3: // Porcentaje con min y max
                                        strDeducibles = double.Parse(row.Cells["Porcentaje"].Text).ToString("#,##0.00", new CultureInfo("en-US")) + "% con mínimo de " + double.Parse(row.Cells["Minimo"].Text).ToString("#,##0.00", new CultureInfo("en-US")) + " " + strAbreMon + " y máximo de " + double.Parse(row.Cells["Maximo"].Text).ToString("#,##0.00", new CultureInfo("en-US")) + " " + strAbreMon + " por evento";
                                        break;
                                    case 4: // Solo min
                                        strDeducibles = double.Parse(row.Cells["Minimo"].Text).ToString("#,##0.00", new CultureInfo("en-US")) + " " + strAbreMon + " por evento";
                                        break;
                                    case 5: // Min y Max
                                        strDeducibles = double.Parse(row.Cells["Minimo"].Text).ToString("#,##0.00", new CultureInfo("en-US")) + " " + strAbreMon + " con máximo de " + double.Parse(row.Cells["Maximo"].Text.ToString()).ToString("#,##0.00", new CultureInfo("en-US")) + " " + strAbreMon + " por evento";
                                        break;
                                    case 6: // Caso con Agregado y Minimo
                                        strDeducibles = double.Parse(row.Cells["Minimo"].Text).ToString("#,##0.00", new CultureInfo("en-US")) + " " + strAbreMon + " por evento y " + double.Parse(row.Cells["Agregado"].Text).ToString("#,##0.00", new CultureInfo("en-US")) + " " + strAbreMon + " en el agregado por el periodo de la póliza";
                                        break;
                                    case 7: // Caso con Agregado solo
                                        strDeducibles = double.Parse(row.Cells["Agregado"].Text).ToString("#,##0.00", new CultureInfo("en-US")) + " " + strAbreMon + " en el agregado por el periodo de la póliza";
                                        break;
                                }
                                wTableDed.Cell(rowDefault4, 1).Range.Text = row.Cells["Deducible"].Text;
                                wTableDed.Cell(rowDefault4, 2).Range.Text = strDeducibles;
                                wTableDed.Cell(rowDefault4, 3).Range.Text = row.Cells["Seccion"].Text;
                                rowDefault4++;
                                if (row.Index < dgDeducibles.Rows.Count)
                                {
                                    Word.Row rowNew = wTableDed.Rows.Add();
                                }
                            }
                            wTableDed.Rows[rowDefault4].Delete();
                        }
                        else
                        {
                            wTableDed.Cell(rowDefault4, 1).Range.Text = "No aplican deducibles";
                            wTableDed.Cell(rowDefault4, 2).Range.Text = "";
                        }
                    }
                }

                bookmarkName = "FormaPago";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["FormaPago"].Start;
                    object finB = doc.Bookmarks["FormaPago"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strFormaPago);
                }

                bookmarkName = "Broker";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    object inicioB = doc.Bookmarks["Broker"].Start;
                    object finB = doc.Bookmarks["Broker"].End;
                    Word.Range rng = doc.Range(inicioB, finB);
                    rng.Select();
                    ac.Selection.TypeText(strBroker);
                }

                bookmarkName = "EndososEmision";
                if (doc.Bookmarks.Exists(bookmarkName.ToString()))
                {
                    if (dgEndosos.Rows.Count > 0)
                    {
                        bool entrob = false;
                        for (int i = 0; i < dgEndosos.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(dgEndosos.Rows[i].Cells["Aplica"].Value))
                            {
                                entrob = true;
                                break;
                            }
                        }

                        if (entrob)
                        {
                            object inicioB = doc.Bookmarks["EndososEmision"].Start;
                            object finB = doc.Bookmarks["EndososEmision"].End;
                            Word.Range rng = doc.Range(inicioB, finB);
                            rng.Select();
                            int fila = 1;
                            Word.Table tabla = doc.Tables.Add(rng, 1, 1);

                            for (int i = 0; i < dgEndosos.Rows.Count; i++)
                            {
                                if (Convert.ToBoolean(dgEndosos.Rows[i].Cells["Aplica"].Value))
                                {
                                    bool tipoTexto = false;
                                    entrob = true;
                                    tabla.Cell(fila, 1).Select(); ac.Selection.Font.Bold = 1; ac.Selection.ParagraphFormat.Style = Word.Enums.WdBuiltinStyle.wdStyleHeading4;
                                    //ac.Selection.Font.Size = 12;
                                    ac.Selection.TypeText(dgEndosos.Rows[i].Cells["Endoso"].Text);
                                    try
                                    { Clipboard.SetText(dgEndosos.Rows[i].Cells["Texto"].Text, TextDataFormat.Rtf); tipoTexto = true; }
                                    catch
                                    { Clipboard.SetText(dgEndosos.Rows[i].Cells["Texto"].Text, TextDataFormat.Text); tipoTexto = false; }
                                    tabla.Rows.Add();
                                    fila++;
                                    if (tipoTexto)
                                    { tabla.Cell(fila, 1).Select(); ac.Selection.PasteAndFormat(Word.Enums.WdRecoveryType.wdFormatOriginalFormatting); fila++; }
                                    else
                                    { tabla.Cell(fila, 1).Select(); ac.Selection.TypeText(Clipboard.GetText(TextDataFormat.Text) + Environment.NewLine); fila++; }
                                    tabla.Rows.Add();
                                }
                            }
                        }
                        else
                        {
                            object inicioB = doc.Bookmarks["CondicionesParticulares"].Start;
                            object finB = doc.Bookmarks["CondicionesParticulares"].End;
                            Word.Range rng = doc.Range(inicioB, finB);
                            rng.Select();
                            ac.Selection.Cut();
                        }
                    }
                    else
                    {
                        object inicioB = doc.Bookmarks["CondicionesParticulares"].Start;
                        object finB = doc.Bookmarks["CondicionesParticulares"].End;
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
            ((Word._Document)doc).Close();
                ((Word._Application)ac).Quit();
                File.Delete("C:\\SmartG\\" + file); // borramos el documento temporal
                txtRetroValidaciones.Text += Environment.NewLine + "Wording generado satisfactoriamente";
            }
            catch (Exception ex)
            {
                ((Word._Document)doc).Close();
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
                string UbicacionesPDF = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaMX + @"\" + cbAseguradoMain.Text + Convert.ToDateTime(dateEmision.Value).Year.ToString() + "_Desgloce Ubicaciones_" + polizaMX + ".pdf";
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
                // añade las ubicaciones si aplica
                if (chkUbicaciones.Checked)
                {
                    using (PdfDocument pdfDoc = PdfReader.Open(UbicacionesPDF, PdfDocumentOpenMode.Import))
                    {
                        for (int i = 0; i < pdfDoc.PageCount; i++)
                        {
                            targetDoc.AddPage(pdfDoc.Pages[i]);
                        }
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //MessageBox.Show("Error al combinar los documentos en una póliza, favor de contactar al soporte técnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int guardarAvances()
        {
            // codigos de errores
            // 0 = guardado Correcto
            // 1 = error en la creación de la póliza, falta el MX
            // 2 = error en la creación de la póliza, MX ya registrado
            // 3 = error en la creación de la póliza, error no controlado al generarla
            // 4 = error en poliza Property
            // 5 = error en coberturas
            // 6 = error en endosos emision
            // 7 = error en limites
            // 8 = error en sublimites
            // 9 = error en deducibles
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
                            if (guardarPolizaProperty())
                            {
                                if (guardarPolizaCobertura())
                                {
                                    if (guardarPolizaEndosos())
                                    {
                                        if (guardarLimites())
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

        bool guardarClientes()
        {
            try
            {
                dbSmartGDataContext db = new dbSmartGDataContext();

                // borramos todos los registros
                borrarRegistros(6);

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
                    clienteAdi.NombreAsegurado = dgAseguAdicionales.Rows[i].Cells["Asegurado Adicional"].Text.ToString() + "|" + dgAseguAdicionales.Rows[i].Cells["Dirección"].Text.ToString();
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
                borrarRegistros(7);

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

        bool guardarLimites()
        {
            try
            {
                dbSmartGDataContext db = new dbSmartGDataContext();

                // borramos los registros anteriores
                borrarRegistros(1);

                if (chkLimites.Checked)
                {
                    // registramos los nuevos valores
                    for (int i = 0; i < dgLimites.Rows.Count; i++)
                    {
                        PolizaLimites nuevaPolizaLim = new PolizaLimites();
                        nuevaPolizaLim.Poliza = idPoliza;
                        nuevaPolizaLim.Limite = dgLimites.Rows[i].Cells["Seccion"].Text;
                        nuevaPolizaLim.Descripcion = dgLimites.Rows[i].Cells["Descripcion"].Text;
                        nuevaPolizaLim.Monto = Convert.ToDecimal(dgLimites.Rows[i].Cells["Monto"].Value);
                        db.PolizaLimites.InsertOnSubmit(nuevaPolizaLim);
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
                nuevaPoliza.LineaNegocios = Property;
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
                        nuevaCoberturaDB.LineaNegocios = Property;
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

        bool guardarPolizaDeducibles()
        {
            try
            {
                dbSmartGDataContext db = new dbSmartGDataContext();

                // borramos los registros anteriores
                borrarRegistros(3);

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
                        nuevaPoliDedu.Agregado = Convert.ToDecimal(dgDeducibles.Rows[i].Cells["Agregado"].Value);
                        nuevaPoliDedu.Descripcion = dgDeducibles.Rows[i].Cells["Descripcion"].Text.ToString();
                        nuevaPoliDedu.Seccion = dgDeducibles.Rows[i].Cells["Seccion"].Text.ToString();
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

        bool guardarPolizaProperty()
        {
            string debug = "";
            try
            {
                bool agregar = false;
                Byte[] bytes = null;
                Byte[] bytesUbicaciones = null;
                bool tmpAgregar = false;

                dbSmartGDataContext db = new dbSmartGDataContext();
                PolizaProperty nuevaPolizaProp = (from x in db.PolizaProperty where x.Poliza == idPoliza select x).SingleOrDefault();

                if (nuevaPolizaProp == null)
                {
                    nuevaPolizaProp = new PolizaProperty();
                    nuevaPolizaProp.Poliza = idPoliza;
                    tmpAgregar = true;
                }

                if (dgUbicaciones.Rows.Count > 0 && dgUbicaciones.Rows[0].Cells["Direccion"].Text != "")
                {
                    if (dgUbicaciones.Rows[dgUbicaciones.Rows.Count - 1].Cells["Direccion"].Text == "")
                    {
                        dtUbicaciones.Rows.RemoveAt(dgUbicaciones.Rows.Count - 1);
                    }
                    xlsExportarUbicaciones.Export(dgUbicaciones, "C:\\SmartG\\temp.xls");
                    Stream fs = File.Open("C:\\SmartG\\temp.xls", FileMode.Open);
                    BinaryReader br = new BinaryReader(fs);
                    bytes = br.ReadBytes((Int32)fs.Length);
                    fs.Dispose();
                    xlsExportarUbicaciones.Dispose();

                    debug = "Paso el primer save";
                    if (generarUbicaciones())
                    {
                        bool satisfactorio = false;
                        do
                        {
                            try
                            {
                                Stream fsA = File.Open("C:\\SmartG\\tmpUbicaciones.xlsx", FileMode.Open);
                                BinaryReader brA = new BinaryReader(fsA);
                                bytesUbicaciones = brA.ReadBytes((Int32)fsA.Length);
                                fsA.Dispose();
                                agregar = true;
                                satisfactorio = true;
                            }
                            catch
                            {

                            }
                        } while (!satisfactorio);
                    }
                    else
                        agregar = false;
                }

                nuevaPolizaProp.BeneficiarioPreferente = beneficiarioPreferente;
                nuevaPolizaProp.LimiteEvento = tipoLimite;
                nuevaPolizaProp.CoberturasAdicionales = coberturasAdicionales;
                nuevaPolizaProp.Origen = Origen;
                nuevaPolizaProp.Programa = programa;
                nuevaPolizaProp.Ajustable = ajustable;
                nuevaPolizaProp.EstructuraLimite = estructuraLimite;
                nuevaPolizaProp.Sujecion = sujecion;
                if (agregar)
                {
                    nuevaPolizaProp.Ubicaciones = bytes;
                    nuevaPolizaProp.UbicacionesWording = bytesUbicaciones;
                    debug = "Guardó con exito";
                }
                if (tmpAgregar)
                    db.PolizaProperty.InsertOnSubmit(nuevaPolizaProp);
                db.SubmitChanges();
                idPolizaPro = nuevaPolizaProp.ID;

                File.Delete("C:\\SmartG\\temp.xls");
                File.Delete("C:\\SmartG\\tmpUbicaciones.xls");
                debug = "borro bien";
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(debug + Environment.NewLine + ex.ToString());
                return false;
            }
        }

        bool guardarPolizaSublimite()
        {
            try
            {
                dbSmartGDataContext db = new dbSmartGDataContext();

                // borramos los registros anteriores
                borrarRegistros(2);

                if (chkSublimites.Checked)
                {
                    // registramos los nuevos valores
                    for (int i = 0; i < dgSublimites.Rows.Count; i++)
                    {
                        PolizaSublimites nuevaPolizaSub = new PolizaSublimites();
                        nuevaPolizaSub.Poliza = idPoliza;
                        nuevaPolizaSub.SubLimite = dgSublimites.Rows[i].Cells["Sublimite"].Text.ToString();
                        nuevaPolizaSub.Monto = Convert.ToDecimal(dgSublimites.Rows[i].Cells["Por Evento"].Value);
                        nuevaPolizaSub.MaximoEn = Convert.ToDecimal(dgSublimites.Rows[i].Cells["Maximo En"].Value);
                        nuevaPolizaSub.Descripcion = dgSublimites.Rows[i].Cells["Incluido En"].Text.ToString();
                        nuevaPolizaSub.Combinado = dgSublimites.Rows[i].Cells["Combinado"].Text.ToString();
                        db.PolizaSublimites.InsertOnSubmit(nuevaPolizaSub);
                        db.SubmitChanges();
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
                borrarRegistros(8);

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
            catch 
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
            beneficiarioPreferente = txtBenefPref.Text;
            ///////////////////////////////////////////////////////////////////////////////////
            //     segunda tab
            ///////////////////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////////////////////
            //     tercera tab
            ///////////////////////////////////////////////////////////////////////////////////
            limiteMaximo = Convert.ToDecimal(txtLimiteMaximo.Value);
            estructuraLimite = cbEstructuraLimite.Text;
            sujecion = Convert.ToDecimal(txtSujecion.Value);
            tipoLimite = cbTipoLimite.Text;

            ///////////////////////////////////////////////////////////////////////////////////
            //     cuarta tab
            ///////////////////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////////////////////
            //     quinta tab
            ///////////////////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////////////////////
            //     sexta tab
            ///////////////////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////////////////////
            //     septima tab
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
            //     octava tab
            ///////////////////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////////////////////
            //     novena tab
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
            //     onceava tab
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
            //     doceava tab
            ///////////////////////////////////////////////////////////////////////////////////
        }

        void guardarVariablesWording()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            strCoberturas = "";
            strDeducibles = "";
            strAseguAdicional = "N/A";
            strIniVig = "Desde: " + formatearFecha(Convert.ToDateTime(dateInicioVig.Value), 1) + " Hrs."; ;
            strFinVig = "Hasta: " + formatearFecha(Convert.ToDateTime(dateFinVigencia.Value), 1) + " Hrs."; ;
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
            for (int i = 0; i < dgAseguAdicionales.Rows.Count; i++)// asegurados adicionales
            {
                if (i == 0)
                {
                    strAseguAdicional = "- " + dgAseguAdicionales.Rows[i].Cells["Asegurado Adicional"].Text;
                    if (dgAseguAdicionales.Rows[i].Cells["Dirección"].Text != "")
                    {
                        strAseguAdicional += "\n" + dgAseguAdicionales.Rows[i].Cells["Dirección"].Text;
                    }
                }
                else
                {
                    strAseguAdicional += "\n" + "- " + dgAseguAdicionales.Rows[i].Cells["Asegurado Adicional"].Text;
                    if (dgAseguAdicionales.Rows[i].Cells["Dirección"].Text != "")
                    {
                        strAseguAdicional += "\n" + dgAseguAdicionales.Rows[i].Cells["Dirección"].Text;
                    }
                }
            }

            string[] secciones = new string[] { "Sección I", "Sección II", "Sección III", "Sección IV", "Sección V", "Sección VI", "Sección VII", "Sección VIII", "Sección IX", "Sección X", "Coberturas General" };
            string[] complementos = new string[] { " - Daños materiales" , " - Pérdidas Consecuenciales", " - Cristales", " - Anuncios luminosos y rótulos", " - Robo de contenidos", " - Dinero y valores", " - Equipo electrónico"
            , " - Calderas y recipientes sujetos a presión", " - Rotura de maquinaria", " - Equipo de contratistas y maquinaria pesada móvil", "" };
            string[] cobSecciones = new string[] { "", "", "", "", "", "", "", "", "", "", "" };
            //dgCoberturas.DisplayLayout.Bands[0].Columns["Cobertura"].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending;
            for (int i = 0; i < dgCoberturas.Rows.Count; i++)
            {
                string[] partido = dgCoberturas.Rows[i].Cells["Cobertura"].Text.Split('-');
                for (int j = 0; j < secciones.Count(); j++)
                {
                    if (Regex.IsMatch(dgCoberturas.Rows[i].Cells["Cobertura"].Text, @"(^|\s)" + secciones[j] + @"(\s|$)"))
                    {
                        if (cobSecciones[j] == "")
                        {
                            if (partido.Count() == 2)
                                cobSecciones[j] = partido[1];
                            else
                                cobSecciones[j] = dgCoberturas.Rows[i].Cells["Cobertura"].Text;
                        }
                        else
                        {
                            if (partido.Count() == 2)
                                cobSecciones[j] += "\n" + partido[1];
                            else
                                cobSecciones[j] += "\n" + dgCoberturas.Rows[i].Cells["Cobertura"].Text;
                        }
                    }
                }
            }

            for (int i = 0; i < cobSecciones.Count(); i++)
            {
                if (cobSecciones[i] != "")
                {
                    strCoberturas += secciones[i] + complementos[i] + "\n" + cobSecciones[i] + "\n" + "\n";
                }
            }

            strTipoLimite = cbTipoLimite.Text;
            strLimite = limiteMaximo.ToString("#,##0.00", new CultureInfo("en-US"));

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");////////////////////////////////////////////////////////
        }

        void importarExcel(int opcion)
        {
            try
            {
                if (opcion != 0)
                {
                    // abrimos el excel y copiamos todo al portapapeles
                }

                bloqueoPaste = true;
                DataObject o = (DataObject)Clipboard.GetDataObject();
                if (o.GetDataPresent(DataFormats.Text))
                {
                    if (dtUbicaciones.Rows.Count > 0)
                        dtUbicaciones.Rows.Clear();

                    if (dtUbicaciones.Columns.Count > 0)
                        dtUbicaciones.Columns.Clear();

                    bool columnsAdded = false;
                    string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                    int j = 0;
                    foreach (string pastedRow in pastedRows)
                    {
                        string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });

                        if (!columnsAdded)
                        {
                            try
                            {
                                for (int i = 0; i < pastedRowCells.Length; i++)
                                {
                                    bool tipoDato = false;
                                    string tmp = pastedRowCells[i];
                                    tmp = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(tmp.ToLower());
                                    if (tmp == "Dirección" || tmp == "Direccion") { tmp = "Direccion"; tipoDato = true; }
                                    if (tmp == "Codigo Postal") tipoDato = true;
                                    if(tmp != "Edificio" && tmp != "Contenidos" && tmp != "Inventarios" && tmp != "Consecuenciales" && tmp != "Pd"
                                        && tmp != "Bi" && tmp != "Total") tipoDato = true;
                                    if (tmp == "Pd") tmp = "PD";
                                    if (tmp == "Bi") tmp = "BI";
                                    if (tipoDato)
                                        dtUbicaciones.Columns.Add(tmp, typeof(string));
                                    else
                                        dtUbicaciones.Columns.Add(tmp, typeof(decimal));
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Error en el formato fuente, verifique la información", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dtUbicaciones.Rows.Clear();
                                dtUbicaciones.Columns.Clear();
                                return;
                            }

                            columnsAdded = true;
                            continue;
                        }

                        int myRowIndex = dtUbicaciones.Rows.Count - 1;
                        DataRow myDataGridViewRow = dtUbicaciones.NewRow();
                        for (int i = 0; i < pastedRowCells.Length; i++)
                        {
                            myDataGridViewRow[i] = pastedRowCells[i];
                        }
                        dtUbicaciones.Rows.Add(myDataGridViewRow);
                        j++;
                    }
                    dtUbicaciones.Rows.Add();
                }

                bool control = false;

                for (int i = 0; i < columnasObligatorias.Count(); i++)
                {
                    for (int j = 0; j < dgUbicaciones.DisplayLayout.Bands[0].Columns.Count; j++)
                    {
                        if ((columnasObligatorias[i] == dgUbicaciones.DisplayLayout.Bands[0].Columns[j].Header.Caption))
                        {
                            control = true;
                        }
                    }

                    if (!control)
                    {
                        MessageBox.Show("No está la columna " + columnasObligatorias[i] + " en la información ingresada, favor de verificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dtUbicaciones.Rows.Clear();
                        dtUbicaciones.Columns.Clear();
                        return;
                    }

                    control = false;
                }

                if (dtUbicaciones.Columns.Count < columnasObligatorias.Count())
                {
                    MessageBox.Show("No se han ingresado todas las columnas, verifique la información", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtUbicaciones.Rows.Clear();
                    dtUbicaciones.Columns.Clear();
                    return;

                }

                control = true;

                for (int i = 0; i < dgUbicaciones.Rows.Count; i++)
                {
                    for (int j = 1; j < columnasObligatorias.Count(); j++)
                    {
                        if (!decimal.TryParse(dgUbicaciones.Rows[i].Cells[columnasObligatorias[j]].Text, out decimal resultado) && dgUbicaciones.Rows[i].Cells["Direccion"].Text != "")
                        {
                            MessageBox.Show("Error en el formato fuente, verifique la información, necesita ingresar números en todos los campos obligatorios excepto en Direccion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dtUbicaciones.Rows.Clear();
                            dtUbicaciones.Columns.Clear();
                            return;
                        }
                    }
                }

                calcularUbicaciones();
                calcularTotalesUbicaciones();
                txtRetroValidaciones.Text = "Información pegada satisfactoriamente";
                bloqueoPaste = false;
            }
            catch
            {
                MessageBox.Show("Error al importar, verifique que haya conexión a la base de datos y que se tenga acceso a la carpeta del sistema SmartG", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // llena los paises del form en inglés
            liIncPaisTableAdapter.Fill(this.liabilityInc1.LiIncPais);
            // llena los programas para Property incoming
            liIncProgramasTableAdapter.FillByDefaultLiInc(this.liabilityInc1.LiIncProgramas, Property, Origen);
            // llena las monedas default
            liIncMonedaTableAdapter.Fill(this.liabilityInc1.LiIncMoneda);
            cbMoneda.Value = 1;
            // llena los producing office default
            lNPOTableAdapter.FillByConsultaLNPOporIDLineaNegocio(this.liabilityInc1.LNPO, Property);
            cbProducingOffice.DisplayMember = "Producing Office";
            cbProducingOffice.ValueMember = "ID";
            // llena los activity Code
            liIncActivityCodeTableAdapter.FillByDefaultLi(this.liabilityInc1.LiIncActivityCode, Property);
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
            coberturasDBTableAdapter.FillByDefaultDBOrigen(this.coberturasOrdenadas.CoberturasDB, Property, Origen);
            // llenado de las coberturas default
            coberturasTableAdapter.FillByDefaultOrigen(this.coberturasOrdenadas.Coberturas, Property, Origen);
            dgCoberturas.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            dgCoberturasDB.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            #region columnasObligatorias
            columnasObligatorias = new string[8];
            columnasObligatorias[0] = "Direccion";
            columnasObligatorias[1] = "Edificio";
            columnasObligatorias[2] = "Contenidos";
            columnasObligatorias[3] = "Inventarios";
            columnasObligatorias[4] = "Consecuenciales";
            columnasObligatorias[5] = "PD";
            columnasObligatorias[6] = "BI";
            columnasObligatorias[7] = "Total";
            #endregion
            // formateamos el dt para los asegurados adicionales
            dtAseguradosAdicionales = new DataTable();
            dtAseguradosAdicionales.Columns.Add("Asegurado Adicional", typeof(string));
            dtAseguradosAdicionales.Columns.Add("Dirección", typeof(string));
            dgAseguAdicionales.DataSource = dtAseguradosAdicionales;
            // formateamos el dt para el desglose de iva
            dtDesgloseIVA = new DataTable();
            dtDesgloseIVA.Columns.Add("Seccion", typeof(string));
            dtDesgloseIVA.Columns.Add("ClaveG", typeof(string));
            dtDesgloseIVA.Columns.Add("Concepto", typeof(string));
            dtDesgloseIVA.Columns.Add("SumaAsegurada", typeof(decimal));
            dtDesgloseIVA.Columns.Add("PrimaNeta", typeof(decimal));
            dtDesgloseIVA.Columns.Add("Part", typeof(decimal));
            dtDesgloseIVA.Columns.Add("Division", typeof(decimal));
            // formateamos el dt para las ubicaciones
            dtUbicaciones = new DataTable();
            dtUbicaciones.Columns.Add("Direccion", typeof(string));
            dtUbicaciones.Columns.Add("Edificio", typeof(decimal));
            dtUbicaciones.Columns.Add("Contenidos", typeof(decimal));
            dtUbicaciones.Columns.Add("Inventarios", typeof(decimal));
            dtUbicaciones.Columns.Add("Consecuenciales", typeof(decimal));
            dtUbicaciones.Columns.Add("Codigo Postal", typeof(string));
            dtUbicaciones.Columns.Add("PD", typeof(decimal));
            dtUbicaciones.Columns.Add("BI", typeof(decimal));
            dtUbicaciones.Columns.Add("Total", typeof(decimal));
            dgUbicaciones.DataSource = dtUbicaciones;
            dgUbicaciones.DisplayLayout.Bands[0].Columns["BI"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            dgUbicaciones.DisplayLayout.Bands[0].Columns["PD"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            dgUbicaciones.DisplayLayout.Bands[0].Columns["Total"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            dtUbicaciones.Rows.Add("", 0, 0, 0, 0, "", 0, 0, 0);
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
            // buscamos el reasegurador default xl seguros y el intermediario
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
            DataTable dttmpEnd = endosoEmisionTableAdapter.GetDataByActivos(Property, Origen);
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
        }

        void iniciarDeducibles()
        {
            dtDeducibles = new DataTable();
            dtDeducibles.Columns.Add("Deducible", typeof(string));
            dtDeducibles.Columns.Add("Porcentaje", typeof(decimal));
            dtDeducibles.Columns.Add("Minimo", typeof(decimal));
            dtDeducibles.Columns.Add("Maximo", typeof(decimal));
            dtDeducibles.Columns.Add("Agregado", typeof(decimal));
            dtDeducibles.Columns.Add("Descripcion", typeof(string));
            dgDeducibles.DataSource = dtDeducibles;
            dgDeducibles.DisplayLayout.Bands[0].Columns["Seccion"].Header.VisiblePosition = 1;
            dgDeducibles.DisplayLayout.Bands[0].Columns["Porcentaje"].MinValue = 0;
            dgDeducibles.DisplayLayout.Bands[0].Columns["Porcentaje"].MaxValue = 100;
            dgDeducibles.DisplayLayout.Bands[0].Columns["Minimo"].MinValue = 0;
            dgDeducibles.DisplayLayout.Bands[0].Columns["Maximo"].MinValue = 0;
            dgDeducibles.DisplayLayout.Bands[0].Columns["Agregado"].MinValue = 0;

            dbSmartGDataContext db = new dbSmartGDataContext();
            int tmpPos = 0;

            for (int i = 0; i < dgCoberturas.Rows.Count; i++)
            {
                int idTemp = Convert.ToInt32(dgCoberturas.Rows[i].Cells["ID"].Text);
                int?[] idsTemp = (from x in db.CoberturasTextoDedu where x.Cobertura == idTemp select x.TextoDeducibles).ToArray();
                if (idsTemp.Count() > 0)
                {
                    for (int j = 0; j < idsTemp.Count(); j++)
                    {
                        TextoDeducibles txtTmp = (from y in db.TextoDeducibles where y.ID == idsTemp[j] select y).SingleOrDefault();
                        dtDeducibles.Rows.Add(txtTmp.Texto, 0, 0, 0, 0, ""); dgDeducibles.Rows[tmpPos].Cells["Seccion"].Value = txtTmp.Descripcion; tmpPos++;
                    }
                }
            }

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
            terminarEdicionGrids();
        }

        void iniciarLimites()
        {

            dtLimites = new DataTable();
            dtLimites.Columns.Add("Seccion", typeof(string));
            dtLimites.Columns.Add("Descripcion", typeof(string));
            dtLimites.Columns.Add("Monto", typeof(decimal));
            dgLimites.DataSource = dtLimites;

            dbSmartGDataContext db = new dbSmartGDataContext();

            for (int i = 0; i < dgCoberturas.Rows.Count; i++)
            {
                int idTemp = Convert.ToInt32(dgCoberturas.Rows[i].Cells["ID"].Text);
                int?[] idsTemp = (from x in db.CoberturasTextoLim where x.Cobertura == idTemp select x.TextoLimites).ToArray();
                if (idsTemp.Count() > 0)
                {
                    for (int j = 0; j < idsTemp.Count(); j++)
                    {
                        TextoLimites txtTmp = (from y in db.TextoLimites where y.ID == idsTemp[j] select y).SingleOrDefault();
                        dtLimites.Rows.Add(txtTmp.Texto, txtTmp.Descripcion, 0);
                    }
                }
            }

            dgLimites.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            dgLimites.DisplayLayout.Bands[0].Columns["Seccion"].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending; //¿?
            dgLimites.DisplayLayout.Bands[0].Columns["Seccion"].NullText = "Nuevo Límite";
            dgLimites.DisplayLayout.Bands[0].Columns["Monto"].MinValue = 0;
            dgLimites.DisplayLayout.Bands[0].Columns["Monto"].DefaultCellValue = 0;
            dgLimites.DisplayLayout.Bands[0].Columns["Monto"].MaskInput = "{LOC}$ nnn,nnn,nnn,nnn";
            dgLimites.DisplayLayout.Bands[0].Columns["Monto"].PromptChar = '\0';
            dgLimites.DisplayLayout.Bands[0].Columns["Monto"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            dgLimites.DisplayLayout.Bands[0].Columns["Descripcion"].NullText = "Nuevo Límite";
            terminarEdicionGrids();
        }

        void iniciarSublimites()
        {
            dtSublimites = new DataTable();
            dtSublimites.Columns.Add("Sublimite", typeof(string));
            dtSublimites.Columns.Add("Por Evento", typeof(decimal));
            dtSublimites.Columns.Add("Maximo En", typeof(decimal));
            dtSublimites.Columns.Add("Incluido En", typeof(string));
            dgSublimites.DataSource = dtSublimites;
            dgSublimites.DisplayLayout.Bands[0].Columns["Combinado"].Header.VisiblePosition = 3;

            dbSmartGDataContext db = new dbSmartGDataContext();
            int tmpPos = 0;

            for (int i = 0; i < dgCoberturas.Rows.Count; i++)
            {
                int idTemp = Convert.ToInt32(dgCoberturas.Rows[i].Cells["ID"].Text);
                int?[] idsTemp = (from x in db.CoberturasTextoSubl where x.Cobertura == idTemp select x.TextoSublimites).ToArray();
                if (idsTemp.Count() > 0)
                {
                    for (int j = 0; j < idsTemp.Count(); j++)
                    {
                        TextoSublimites txtTmp = (from y in db.TextoSublimites where y.ID == idsTemp[j] select y).SingleOrDefault();
                        dtSublimites.Rows.Add(txtTmp.Texto, 0, 0, ""); dgSublimites.Rows[tmpPos].Cells["Combinado"].Value = txtTmp.Descripcion; tmpPos++;
                    }
                }
            }

            dgSublimites.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree;
            dgSublimites.DisplayLayout.Bands[0].Columns["Sublimite"].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending;
            dgSublimites.DisplayLayout.Bands[0].Columns["Sublimite"].NullText = "Nuevo Sublímite";
            dgSublimites.DisplayLayout.Bands[0].Columns["Sublimite"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            dgSublimites.DisplayLayout.Bands[0].Columns["Por Evento"].MinValue = 0;
            dgSublimites.DisplayLayout.Bands[0].Columns["Por Evento"].DefaultCellValue = 0;
            dgSublimites.DisplayLayout.Bands[0].Columns["Por Evento"].MaskInput = "{LOC}$ nnn,nnn,nnn,nnn";
            dgSublimites.DisplayLayout.Bands[0].Columns["Por Evento"].PromptChar = '\0';
            dgSublimites.DisplayLayout.Bands[0].Columns["Por Evento"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            dgSublimites.DisplayLayout.Bands[0].Columns["Maximo En"].MinValue = 0;
            dgSublimites.DisplayLayout.Bands[0].Columns["Maximo En"].DefaultCellValue = 0;
            dgSublimites.DisplayLayout.Bands[0].Columns["Maximo En"].MaskInput = "{LOC}$ nnn,nnn,nnn,nnn";
            dgSublimites.DisplayLayout.Bands[0].Columns["Maximo En"].PromptChar = '\0';
            dgSublimites.DisplayLayout.Bands[0].Columns["Maximo En"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            dgSublimites.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            dgSublimites.DisplayLayout.Bands[0].Columns["Sublimite"].Width = 800;
            terminarEdicionGrids();
        }

        void iniciarUbicaciones()
        {
            // formateamos el dt para las ubicaciones
            dtUbicaciones = new DataTable();
            dtUbicaciones.Columns.Add("Direccion", typeof(string));
            dtUbicaciones.Columns.Add("Edificio", typeof(decimal));
            dtUbicaciones.Columns.Add("Contenidos", typeof(decimal));
            dtUbicaciones.Columns.Add("Inventarios", typeof(decimal));
            dtUbicaciones.Columns.Add("Consecuenciales", typeof(decimal));
            dtUbicaciones.Columns.Add("Codigo Postal", typeof(string));
            dtUbicaciones.Columns.Add("PD", typeof(decimal));
            dtUbicaciones.Columns.Add("BI", typeof(decimal));
            dtUbicaciones.Columns.Add("Total", typeof(decimal));
            dgUbicaciones.DataSource = dtUbicaciones;
            dgUbicaciones.DisplayLayout.Bands[0].Columns["BI"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            dgUbicaciones.DisplayLayout.Bands[0].Columns["PD"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            dgUbicaciones.DisplayLayout.Bands[0].Columns["Total"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            dtUbicaciones.Rows.Add("", 0, 0, 0, 0, "", 0, 0, 0);
        }

        void llenarControlesObligatorios()
        {
            controlesObligatorios = new Control[24];
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
            controlesObligatorios[14] = cbEstructuraLimite;
            controlesObligatorios[15] = txtTituloPolizaGenius;
            controlesObligatorios[16] = cbPaymentConditions;
            controlesObligatorios[17] = cbActivityCode;
            controlesObligatorios[18] = txtPrimaMain;
            controlesObligatorios[19] = cbIVA;
            controlesObligatorios[20] = cbTipoPrima;
            controlesObligatorios[21] = txtTipoPoliza;
            controlesObligatorios[22] = cbFormaPago;
            controlesObligatorios[23] = txtNumPagos;
        }

        void llenarMonedas()
        {
            labelsMonedas = new Control[17];
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
            labelsMonedas[16] = lbMon17;
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
            // llena los programas para Property incoming
            liIncProgramasTableAdapter.FillByDefaultLiInc(this.liabilityInc1.LiIncProgramas, Property, Origen);
            // llena las monedas default
            liIncMonedaTableAdapter.Fill(this.liabilityInc1.LiIncMoneda);
            cbMoneda.Value = 1;
            // llena los producing office default
            lNPOTableAdapter.FillByConsultaLNPOporIDLineaNegocio(this.liabilityInc1.LNPO, Property);
            cbProducingOffice.DisplayMember = "Producing Office";
            cbProducingOffice.ValueMember = "ID";
            // llena los activity Code
            liIncActivityCodeTableAdapter.FillByDefaultLi(this.liabilityInc1.LiIncActivityCode, Property);
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
            coberturasDBTableAdapter.FillByDefaultDBOrigen(this.coberturasOrdenadas.CoberturasDB, Property, Origen);
            // llenado de las coberturas default
            coberturasTableAdapter.FillByDefaultOrigen(this.coberturasOrdenadas.Coberturas, Property, Origen);
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
            DataTable dttmpEnd = endosoEmisionTableAdapter.GetDataByActivos(Property, Origen);
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
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar los datos Property.";
                    break;
                case 5:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar las coberturas.";
                    break;
                case 6:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar los endosos de emisión.";
                    break;
                case 7:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar los limites.";
                    break;
                case 8:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar los sublimites.";
                    break;
                case 9:
                    txtRetroValidaciones.Text += Environment.NewLine + "Error al guardar los deducibles.";
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
            WordingPropertyIncoming nuevoWording = new WordingPropertyIncoming();

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
            nuevoWording.DelimitacionTemporal = "";
            nuevoWording.DelimitacionTemporalTXT = "";
            nuevoWording.FechaRetroactiva = "";
            nuevoWording.DelimitacionTerritorial = "";
            nuevoWording.UbicacionesAseguradas = "";
            nuevoWording.Coberturas = strCoberturas;
            nuevoWording.LimiteMaximo = strTipoLimite;
            nuevoWording.GastosDefensa = "";
            nuevoWording.Sublimites = "";
            nuevoWording.Deducibles = "";
            nuevoWording.PrimaNeta = primaNeta;
            nuevoWording.Descuentos = descuentos;
            nuevoWording.Recargos = recargoFraccionado;
            nuevoWording.Impuestos = Convert.ToDecimal(txtImpuestos.Value);
            nuevoWording.PrimaTotal = primaTotal;
            nuevoWording.FormaPago = strFormaPago;
            nuevoWording.Asegurador = "XL Seguros México, S.A. de C.V. " + Environment.NewLine + "Antonio Dovalí Jaime No. 70" + Environment.NewLine + "Torre C, Piso 8" + Environment.NewLine
                        + "Col. Zedec Santa Fe, C.P. 01210" + Environment.NewLine + "Ciudad de México." + Environment.NewLine + Environment.NewLine + "R.F.C.: XIM - 040220 – 119" + Environment.NewLine;
            nuevoWording.Broker = strBroker;
            nuevoWording.Exclusiones = "";
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
            nuevoWording.Jurisdiccion = "";
            if (chkUbicaciones.Checked)
            {
                nuevoWording.UbicacionRiesgo = ubicacionesSumas;
            }
            nuevoWording.InteresAsegurable = "";
            nuevoWording.CoberturasAdicional = coberturasAdicionales;
            string tmpDesglose = "";
            for (int i = 0; i < dgDesglosePrima.Rows.Count; i++)
            {
                if (Convert.ToDouble(dgDesglosePrima.Rows[i].Cells["PrimaNeta"].Text) > 0)
                {
                    tmpDesglose += dgDesglosePrima.Rows[i].Cells["Concepto"].Text + "|" + Convert.ToDouble(dgDesglosePrima.Rows[i].Cells["PrimaNeta"].Text).ToString("#,##0.00", new CultureInfo("en-US")) + ";";
                }
            }
            nuevoWording.BaseCalculo = tmpDesglose;
            db.WordingPropertyIncoming.InsertOnSubmit(nuevoWording);
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
            WordingPropertyIncoming nuevoWording = new WordingPropertyIncoming();

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
            nuevoWording.DelimitacionTemporal = "";
            nuevoWording.DelimitacionTemporalTXT = "";
            nuevoWording.FechaRetroactiva = "";
            nuevoWording.DelimitacionTerritorial = "";
            nuevoWording.UbicacionesAseguradas = "";
            nuevoWording.Coberturas = strCoberturas;
            nuevoWording.LimiteMaximo = strTipoLimite;
            nuevoWording.GastosDefensa = "";
            nuevoWording.Sublimites = "";
            nuevoWording.Deducibles = "";
            nuevoWording.PrimaNeta = primaNeta;
            nuevoWording.Descuentos = descuentos;
            nuevoWording.Recargos = recargoFraccionado;
            nuevoWording.Impuestos = Convert.ToDecimal(txtImpuestos.Value);
            nuevoWording.PrimaTotal = primaTotal;
            nuevoWording.FormaPago = strFormaPago;
            nuevoWording.Asegurador = "XL Seguros México, S.A. de C.V. " + Environment.NewLine + "Antonio Dovalí Jaime No. 70" + Environment.NewLine + "Torre C, Piso 8" + Environment.NewLine
                        + "Col. Zedec Santa Fe, C.P. 01210" + Environment.NewLine + "Ciudad de México." + Environment.NewLine + Environment.NewLine + "R.F.C.: XIM - 040220 – 119" + Environment.NewLine;
            nuevoWording.Broker = strBroker;
            nuevoWording.Exclusiones = "";
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
            nuevoWording.Jurisdiccion = "";
            if (chkUbicaciones.Checked)
            {
                nuevoWording.UbicacionRiesgo = ubicacionesSumas;
            }
            nuevoWording.InteresAsegurable = "";
            nuevoWording.CoberturasAdicional = coberturasAdicionales;
            string tmpDesglose = "";
            for (int i = 0; i < dgDesglosePrima.Rows.Count; i++)
            {
                if (Convert.ToDouble(dgDesglosePrima.Rows[i].Cells["PrimaNeta"].Text) > 0)
                {
                    tmpDesglose += dgDesglosePrima.Rows[i].Cells["Concepto"].Text + "|" + Convert.ToDouble(dgDesglosePrima.Rows[i].Cells["PrimaNeta"].Text).ToString("#,##0.00", new CultureInfo("en-US")) + ";";
                }
            }
            nuevoWording.BaseCalculo = tmpDesglose;
            db.WordingPropertyIncoming.InsertOnSubmit(nuevoWording);
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

            if (dgDesglosePrima.Rows.Count > 0)
            {
                for (int i = 0; i < dgDesglosePrima.Rows.Count; i++)
                    dgDesglosePrima.Rows[i].Update();
            }

            if (dgLimites.Rows.Count > 0)
            {
                for (int i = 0; i < dgLimites.Rows.Count; i++)
                    dgLimites.Rows[i].Update();
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

            if (dgUbicaciones.Rows.Count > 0)
            {
                for (int i = 0; i < dgUbicaciones.Rows.Count; i++)
                    dgUbicaciones.Rows[i].Update();
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
            for (int i = 0; i < 12; i++)
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
                            txtRetroValidaciones.Text += Environment.NewLine + "Error: el campo Poliza MX debe llenarse correctamente: MX + 8 dígitos seguimiento + PR + 2 dígitos año de emisión + caracter A,B o C  (Datos Generales)";
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
                            txtRetroValidaciones.Text += Environment.NewLine + "Error: el campo Poliza ES debe llenarse correctamente: ES + 8 dígitos seguimiento + PR + 2 dígitos año de emisión + caracter A,B o C (Datos Generales)";
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

                case 2:
                    if (tmpValida) // pasó todas las validaciones
                        txtRetroValidaciones.Text += Environment.NewLine + "3) Sección Endosos emisión OK";
                    break;

                case 3: // tab limites
                    if (Convert.ToDecimal(txtLimiteMaximo.Value) <= 0)
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: el límite máximo no puede ser cero (Límites)";
                    }
                    if (coberturasAdicionales == "")
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: no se han ingresado coberturas adicionales (Límites)";
                    }
                    if (cbTipoLimite.Text == "")
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: el tipo de límite no puede estar vacío (Límites)";
                    }
                    if (cbEstructuraLimite.Text == "")
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debes seleccionar un valor para la estructura límite (Límites)";
                    }
                    if (txtSujecion.Visible && Convert.ToDecimal(txtSujecion.Value) <= 0)
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: el valor de la sujeción no puede ser cero (Límites)";
                    }
                    if (chkLimites.Checked && dgLimites.Rows.Count == 0)
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debes de introducir limites si activaste la opción de limites (Límites)";
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
                        txtRetroValidaciones.Text += Environment.NewLine + "4) Sección Limites OK";
                    break;

                case 4: // tab sublimites
                    if (chkSublimites.Checked && dgSublimites.Rows.Count == 0)
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debes de introducir sublimites si activaste la opción de sublimites (Sublímites)";
                    }
                    if (chkSublimites.Checked)
                    {
                        for (int i = 0; i < dgSublimites.Rows.Count; i++)
                        {
                            if (Convert.ToDecimal(dgSublimites.Rows[i].Cells["Por Evento"].Value) > Convert.ToDecimal(txtLimiteMaximo.Value))
                            {
                                tmpValida = false;
                                txtRetroValidaciones.Text += Environment.NewLine + "Error: el sublímite: " + dgSublimites.Rows[i].Cells["Sublimite"].Text + " no pueden ser cero ni mayor al límite máximo (Límites y sublímites)";
                            }
                        }
                    }
                    if (tmpValida) // pasó todas las validaciones
                        txtRetroValidaciones.Text += Environment.NewLine + "5) Sección Sublimites OK";
                    break;

                case 5: // tab deducibles
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
                        txtRetroValidaciones.Text += Environment.NewLine + "6) Sección Deducibles OK";
                    break;

                case 6: // tab ubicaciones
                    if (chkUbicaciones.Checked && (dgUbicaciones.Rows.Count == 0 || dgUbicaciones.Rows[0].Cells["Direccion"].Text == ""))
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debes de introducir ubicaciones si activaste la opción de ubicaciones (Ubicaciones)";
                    }
                    if (Convert.ToDecimal(txtSumTotales.Value) <= 0 && grpCalculoUbica.Visible == true)
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debes de introducir valores válidos para las ubicaciones, la suma de los totales no puede ser cero (Ubicaciones)";
                    }
                    if (tmpValida) // pasó todas las validaciones
                        txtRetroValidaciones.Text += Environment.NewLine + "7) Sección Ubicaciones OK";
                    break;

                case 7: // tab valores Genius
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
                        txtRetroValidaciones.Text += Environment.NewLine + "8) Sección Valores Genius OK";
                    break;

                case 8: // tab desglose Prima
                    if (Convert.ToDecimal(txtPrimaInstruida.Value) <= 0)
                    {
                        tmpValida = false;
                        txtRetroValidaciones.Text += Environment.NewLine + "Error: debes de ingresar una prima válida (Desglose Prima)";
                    }
                    if (tmpValida) // pasó todas las validaciones
                        txtRetroValidaciones.Text += Environment.NewLine + "9) Sección desglose Prima OK";
                    break;

                case 9: // tab prima
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
                        txtRetroValidaciones.Text += Environment.NewLine + "10) Sección Prima OK";
                    break;

                case 10: // tab coaseguros
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
                        txtRetroValidaciones.Text += Environment.NewLine + "11) Sección Coaseguro OK";
                    break;

                case 11: // tab reaseguros
                    if (chkReaseguro.Checked)
                    {
                        if (!validarTablaReaseguros())
                        {
                            tmpValida = false;
                        }
                    }
                    if (tmpValida) // pasó todas las validaciones
                        txtRetroValidaciones.Text += Environment.NewLine + "12) Sección Reaseguro OK";
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
                if (row.Cells["Seccion"].Text == "")
                {
                    txtRetroValidaciones.Text += Environment.NewLine + "Error: el deducible " + row.Cells["Deducible"].Value.ToString() + " no tiene una sección asignada (Deducibles)";
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

        private void btnClausulasAdicionales_Click(object sender, EventArgs e)
        {
            Operaciones.Emision.PropertyClausulasAdicionales frmClausulasAdi = new PropertyClausulasAdicionales(Property, coberturasAdicionales);
            frmClausulasAdi.ShowDialog();
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
                    Property, dgCoberturasDB.ActiveRow.Cells["Cobertura"].Text.ToString(), dgCoberturasDB.ActiveRow.Cells["CoberturaIngles"].Text.ToString(),
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
        }

        private void btnGenerarUbi_Click(object sender, EventArgs e)
        {
            if (dgUbicaciones.Rows.Count > 0)
            {
                if (MessageBox.Show("Se borrarán los datos de la tabla, ¿deseas continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    iniciarUbicaciones();
                }
            }
            else
                iniciarUbicaciones();
        }

        private void btnImportarExcel_Click(object sender, EventArgs e)
        {
            if (dgUbicaciones.Rows.Count > 0)
            {
                if (MessageBox.Show("Se borrarán los datos de la tabla, ¿deseas continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    importarExcel(0);
                }
            }
            else
                importarExcel(0);
            
            terminarEdicionGrids();

        }

        private void btnQuitarCobertura_Click(object sender, EventArgs e)
        {
            if (dgCoberturas.Selected.Rows.Count == 1)
            {
                coberturasOrdenadas.CoberturasDB.Rows.Add(Convert.ToInt32(dgCoberturas.ActiveRow.Cells["ID"].Text.ToString()),
                   Property, dgCoberturas.ActiveRow.Cells["Cobertura"].Text.ToString(), dgCoberturas.ActiveRow.Cells["CoberturaIngles"].Text.ToString(),
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
        }

        private void btnRecargarDeducibles_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas actualizar la lista con la información de coberturas? se perderán los datos ya ingresados", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                dtDeducibles.Rows.Clear();
                iniciarDeducibles();
            }
        }

        private void btnRecargarLimites_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas actualizar la lista con la información de coberturas? se perderán los datos ya ingresados", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                dtLimites.Rows.Clear();
                iniciarLimites();
            }
        }

        private void btnRecargarSublimites_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas actualizar la lista con la información de coberturas? se perderán los datos ya ingresados", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                dtSublimites.Rows.Clear();
                iniciarSublimites();
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

        private void btnGenerarDesglose_Click(object sender, EventArgs e)
        {
            //decimal x = Convert.ToDecimal(txtPrimaInstruida.Value);

            dtDesgloseIVA.Rows.Clear();
            dgDesglosePrima.DataSource = dtDesgloseIVA;
            #region formatearGrid
            dgDesglosePrima.DisplayLayout.Bands[0].Columns["Part"].Hidden = true;
            dgDesglosePrima.DisplayLayout.Bands[0].Columns["Division"].Hidden = true;
            dgDesglosePrima.DisplayLayout.Bands[0].Columns["SumaAsegurada"].Hidden = true;
            #endregion   

            string[] ConcepSep = {
                "PD;Todo Riesgo;PFRC",
                "PD;Terremoto y/o Erupción Volcánica;PEVC",
                "PD;Granizo, ciclón, huracán o vientos tempestuosos;PHUC",
                "PD;Inundación y lluvia;PFOP", "PD;Cristales;PGBK",
                "PD;Anuncions Luminosos y Rótulos;PBBD",
                "PD;Dinero y Valores;PMSI",
                "PD;Equipo Electrónico;PEEB",
                "PD;Calderas y Recipientes a Sujetos a Presión;PBVB",
                "PD;Rotura de Maquinaria;PMBB",
                "PD;Equipo de Contratistas y Maquinaria Pesada Móvil;PCMB",
                "BI;Pérdidas Consecuenciales;PBI",
                "Burgary;Robo de contenidos;PBRG" };

            foreach (string str in ConcepSep)
            {
                string[] ConcepInd = str.Split(';');
                dtDesgloseIVA.Rows.Add(ConcepInd[0], ConcepInd[2], ConcepInd[1]);
            }

            string[] dic = {
                "Sección I Daños materiales - Cobertura amplia de Incendio",
                "Sección I Daños materiales - Terremoto y/o Erupción Volcánica",
                "Sección I Daños materiales - Granizo, ciclón, huracán o vientos tempestuosos",
                "Sección I Daños materiales - Inundación y lluvia",
                "Sección III",
                "Sección IV",
                "Sección VI",
                "Sección VII",
                "Sección VIII",
                "Sección IX",
                "Sección X",
                "Sección II",
                "Sección V" };

            for (int i = 0; i < dic.Length; i++)
            {
                string dicAct = dic[i];
                bool verificacion = false;

                for (int j = 0; j < dgCoberturas.Rows.Count; j++)
                {
                    int largo = dgCoberturas.Rows[j].Cells["Cobertura"].Text.Length;
                    if (dicAct.Length < largo) { largo = dicAct.Length; }
                    if (dgCoberturas.Rows[j].Cells["Cobertura"].Text.Substring(0, largo) == dicAct)
                    {
                        verificacion = true;
                    }
                }

                if (verificacion == true)
                {
                    dtDesgloseIVA.Rows[i]["Part"] = 1;
                }
                else
                {
                    dtDesgloseIVA.Rows[i]["Part"] = 0;
                }
            }

            // Cuenta los valores de las coberturas diferentes a la seccion 1
            int sumCob = 0;
            for (int i = 4; i <= 12; i++)
            {
                if (dgDesglosePrima.Rows[i].Cells["Part"].Text == "1") { sumCob++; }
            }

            // Asigna el valor de la seccion 1 completa
            double ValS1 = 100;
            if (sumCob >= 1) { ValS1 = 90; }

            // Realiza las divisiones de la seccion 1
            if (dgDesglosePrima.Rows[1].Cells["Part"].Text == "1") { dgDesglosePrima.Rows[1].Cells["Division"].Value = 30; } else { dgDesglosePrima.Rows[1].Cells["Division"].Value = 0; }
            if (dgDesglosePrima.Rows[2].Cells["Part"].Text == "1") { dgDesglosePrima.Rows[2].Cells["Division"].Value = 10; } else { dgDesglosePrima.Rows[2].Cells["Division"].Value = 0; }
            if (dgDesglosePrima.Rows[3].Cells["Part"].Text == "1") { dgDesglosePrima.Rows[3].Cells["Division"].Value = 10; } else { dgDesglosePrima.Rows[3].Cells["Division"].Value = 0; }

            int ValIncendio = 0;
            for (int i = 1; i <= 3; i++) // Realiza el calculo del restante aplicable a incendio
            {
                ValIncendio += int.Parse(dgDesglosePrima.Rows[i].Cells["Division"].Text);
            }
            dgDesglosePrima.Rows[0].Cells["Division"].Value = (100 - ValIncendio).ToString();

            for (int i = 0; i <= 3; i++)
            {
                double val = double.Parse(dgDesglosePrima.Rows[i].Cells["Division"].Text);
                dgDesglosePrima.Rows[i].Cells["Division"].Value = (val * (ValS1 / 100)).ToString();
            }

            // Asigna los valores para el resto de la secciones
            double resto = (100 - ValS1) / sumCob;
            for (int i = 4; i <= 12; i++)
            {
                if (dgDesglosePrima.Rows[i].Cells["Part"].Text == "1") { dgDesglosePrima.Rows[i].Cells["Division"].Value = resto.ToString(); } else { dgDesglosePrima.Rows[i].Cells["Division"].Value = 0; }
            }

            for (int i = 0; i < dgDesglosePrima.Rows.Count; i++)
            {
                try
                {
                    decimal PNeta = Convert.ToDecimal(txtPrimaInstruida.Value) * Convert.ToDecimal(dgDesglosePrima.Rows[i].Cells["Division"].Text) / 100;
                    dgDesglosePrima.Rows[i].Cells["PrimaNeta"].Value = PNeta;
                }
                catch { }
            }

            dgDesglosePrima.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            txtPrimaMain.Value = txtPrimaInstruida.Value;
            txtPrimaMain_Leave(sender, e);
            terminarEdicionGrids();
        }

        private void btnTituloPolizaGenius_Click(object sender, EventArgs e)
        {
            if (cbAseguradoMain.Text != "")
            {
                //Comenzamos con el line of business (Property)
                string codigoGenius = "PROP";

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

        private void chkUbicaciones_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUbicaciones.Checked)
            {
                dgUbicaciones.Visible = true;
                grpCalculoUbica.Visible = true;
                btnImportarExcel.Visible = true;
                btnGenerarUbi.Visible = true;
                btnCrearTemplate.Visible = true;
                if (dgUbicaciones.Rows.Count == 0)
                    iniciarUbicaciones();
            }
            else
            {
                dtUbicaciones.Rows.Clear();
                dtUbicaciones.Columns.Clear();
                iniciarUbicaciones();
                calcularUbicaciones();
                calcularTotalesUbicaciones();
                dgUbicaciones.Visible = false;
                grpCalculoUbica.Visible = false;
                btnCrearTemplate.Visible = false;
                btnImportarExcel.Visible = false;
                btnGenerarUbi.Visible = false;
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
                iniciarDeducibles();
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

        private void chkLimites_CheckedChanged(object sender, EventArgs e)
        {
            // se agregan los limites al form
            if (chkLimites.Checked)
            {
                btnRecargarLimites.Visible = true;
                lbRecargarLimites.Visible = true;
                lbLimiteManual.Visible = true;
                txtLimiteManual.Visible = true;
                dgLimites.Visible = true;
                iniciarLimites();
            }
            // se eliminan los limites y se ocultan los controles
            else
            {
                btnRecargarLimites.Visible = false;
                lbRecargarLimites.Visible = false;
                lbLimiteManual.Visible = false;
                txtLimiteManual.Visible = false;
                dgLimites.Visible = false;
                dtLimites.Rows.Clear();
            }
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
                iniciarSublimites();
                terminarEdicionGrids();
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

        private void dgLimites_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
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

        private void dgUbicaciones_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            if (dgUbicaciones.ActiveRow.Index + 1 == dgUbicaciones.Rows.Count)
                dtUbicaciones.Rows.Add("", 0, 0, 0, 0, "", 0, 0, 0);
        }

        private void dgUbicaciones_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell.Column.Header.Caption == "Direccion")
            {
                if (e.Cell.Row.Index + 1 == dgUbicaciones.Rows.Count && e.Cell.Text.ToString() != "")
                {
                    dtUbicaciones.Rows.Add("", 0, 0, 0, 0, "", 0, 0, 0);
                }
            }
            else if (e.Cell.Column.Header.Caption != "Codigo Postal")
            {

                if (e.Cell.Text == "")
                    e.Cell.Value = 0;
            }

            calcularUbicaciones();
            calcularTotalesUbicaciones();
        }

        private void dgUbicaciones_AfterRowsDeleted(object sender, EventArgs e)
        {
            if (dgUbicaciones.Rows.Count == 0)
                dtUbicaciones.Rows.Add("", 0, 0, 0, 0, "", 0, 0, 0);
            calcularUbicaciones();
            calcularTotalesUbicaciones();
        }

        public PropertyInc(int idVentana = 0, int idPolizaTemp = 0)
        {
            InitializeComponent();
            llenarControlesObligatorios();
            dbSmartGDataContext db = new dbSmartGDataContext();

            // obtenemos los id's importantes utilizados en todo el formulario
            Property = (from x in db.LineaNegocios where x.LineaNegocios1 == "Property" select x.ID).SingleOrDefault();
            Origen = (from x in db.Origen where x.Origen1 == "Incoming" select x.ID).SingleOrDefault();
            ventana = idVentana;
            if (idPolizaTemp != 0)
                idPoliza = idPolizaTemp;

        }

        private void PropertyInc_FormClosing(object sender, FormClosingEventArgs e)
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

        private void PropertyInc_Load(object sender, EventArgs e)
        {
            //Extensiones.Traduccion.traducirVentana(this, tabControlLiability, ToolsBarPropertyInc);

            llenarMonedas();
            iniciarDatos();
            if (ventana == 1) // carga de ventanas para edicion de guardados
            {
                cargarAvances();
            }
            validarDatos(tabControlLiability.ActiveTab.Index);
            txtRetroValidaciones.Text = "";
            tabAnterior = tabControlLiability.ActiveTab.Index;
            this.FormClosing += PropertyInc_FormClosing;
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
                    for (int i = 0; i < 12; i++)
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
                            for (int i = 0; i < 12; i++)
                            {
                                validarDatos(i);
                            }

                            if (validarCorrectos() && validarCliente())
                            {
                                if (MessageBox.Show("Esta función concluirá el registro y generará los documentos finales, se recomienda generar un previo de la póliza para su revisión ya que una vez finalizado el registro no se podrá cambiar, si aun así deseas continuar con la conclusión del proceso has click en Si", "Aviso importante", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                {
                                    retroalimentacion(guardarAvances());
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
                            for (int i = 0; i < 12; i++)
                            {
                                validarDatos(i);
                            }

                            if (validarCorrectos())
                            {
                                retroalimentacion(guardarAvances());
                                solicitarPrevio();
                            }
                        }
                    }

                    break;

            }

        }

        private void tabControlLiability_SelectedTabChanging(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangingEventArgs e)
        {
            validarDatos(tabAnterior);
            tabAnterior = tabControlLiability.ActiveTab.Index;
        }

        private void txtAseguAdicional_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtAseguAdicional.Text != "")
            {
                string[] tmpAseAdi = txtAseguAdicional.Text.Split(',');
                if (tmpAseAdi.Count() > 1)
                {
                    dtAseguradosAdicionales.Rows.Add(tmpAseAdi[0],tmpAseAdi[1]);

                }
                else
                {
                    dtAseguradosAdicionales.Rows.Add(tmpAseAdi[0], "");
                }
                
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
                dtDeducibles.Rows.Add(txtDeducibleManual.Text, 0, 0, 0, 0, "");
                txtDeducibleManual.Text = "";
                dgDeducibles.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
        }

        private void txtNuevaCobertura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtNuevaCobertura.Text != "")
            {
                coberturasOrdenadas.Coberturas.Rows.Add(coberturaM, Property, txtNuevaCobertura.Text, "N/A", "OTH", false, true, false, 1, 11);
                coberturaM--;
                txtNuevaCobertura.Text = "";
                dgCoberturas.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
        }

        private void txtPrimaInstruida_Leave(object sender, EventArgs e)
        {
            btnGenerarDesglose_Click(sender, e);
            txtPrimaMain.Value = txtPrimaInstruida.Value;
            txtPrimaMain_Leave(sender, e);

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
            MessageBox.Show("El formato correcto para la póliza MX es el siguiente: MX + 8 dígitos de seguimiento + PR + 2 dítigos del año de emisión + 1 caracter, verifica los datos ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtLimiteManual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && txtLimiteManual.Text != "")
            {
                dtLimites.Rows.Add(txtLimiteManual.Text, "", 0);
                txtLimiteManual.Text = "";
                dgLimites.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
        }

        private void txtSublimiteManual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && txtSublimiteManual.Text != "")
            {
                dtSublimites.Rows.Add(txtSublimiteManual.Text, 0, 0, ""); dgSublimites.Rows[dgSublimites.Rows.Count-1].Cells["Combinado"].Value = "Si";
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

        private void btnDebug_Click(object sender, EventArgs e)
        {
            generarUbicaciones();
        }

        private void btnCrearTemplate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Consejos para generar la importación correctamente:" + Environment.NewLine + Environment.NewLine +
                "1) Todas las celdas deben estar en formato General y no debe de haber caracteres alfabéticos en los campos destinados para números (Edificio, Contenidos, etc), si no se tiene un valor utilizar cero" + Environment.NewLine +
                "2) El sistema hace una sumatoria automáticamente de los campos Total PD, BI y PD+BI, por lo cual sobreescribirá lo que se tenga en el archivo de Excel." + Environment.NewLine +
                "3) No debe de haber saltos de linea en el documento, para eliminarlos abre la opción de 'Buscar y seleccionar' > 'Remplazar' > posicionate en la casilla 'Buscar ' y presiona Ctrl+J, verás un punto parpadeando, oprime remplazar y listo." + Environment.NewLine +
                Environment.NewLine + "Si tienes dudas o la importación no está funcionando favor de contactar al soporte técnico", "Consejos para importación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
            Excel.Worksheet workSheet = (Excel.Worksheet)xlWorkbook.Worksheets[1];
            xlApp.Visible = true;

            workSheet.Range("A1").Value = "Direccion";
            workSheet.Range("B1").Value = "Edificio";
            workSheet.Range("C1").Value = "Contenidos";
            workSheet.Range("D1").Value = "Inventarios";
            workSheet.Range("E1").Value = "Consecuenciales";
            workSheet.Range("F1").Value = "Codigo Postal";
            workSheet.Range("G1").Value = "PD";
            workSheet.Range("H1").Value = "BI";
            workSheet.Range("I1").Value = "Total";

            workSheet.Range("G2").Value = "0";
            workSheet.Range("H2").Value = "0";
            workSheet.Range("I2").Value = "0";
        }

        private void dgLimites_AfterRowUpdate(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            if (dgLimites.Rows.Count > 0)
                dgLimites.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
        }

        private void dgSublimites_AfterRowUpdate(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            if (dgSublimites.Rows.Count > 0)
                dgSublimites.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
        }

        private void dgDeducibles_AfterRowUpdate(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            if (dgDeducibles.Rows.Count > 0)
                dgDeducibles.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
        }

        private void dgSublimites_BeforeRowsDeleted_1(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
        }

        private void dgLimites_AfterRowsDeleted(object sender, EventArgs e)
        {
            if (dgLimites.Rows.Count > 0)
                dgLimites.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
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
