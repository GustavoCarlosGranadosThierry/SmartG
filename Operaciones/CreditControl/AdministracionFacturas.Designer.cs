namespace SmartG.Operaciones.CreditControl
{
    partial class AdministracionFacturas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("CheckFacturas", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocumento");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Serie");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Folio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CondicionesPago");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Confirmacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Cliente");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoCambio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Moneda");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Subtotal");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Descuentos");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ImpuestosTransladados");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ImpuestosRetenidos");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("StatusFacturacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaSolicitud", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UsuarioSolicitud");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaTimbrado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UUID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RFC");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("iniVig");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("finVig");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario Solicitante");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaPago_str");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Mon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Status_str");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NomComp");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Total");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RechazoDes");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Poliza_str");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AuditNumber");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FK_ClientesDirecciones_Clientes1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FK_Facturacion_Clientes1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("chkSolicitud", 0);
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FK_ClientesDirecciones_Clientes1", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Cliente");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Calle");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NumExterior");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NumInterior");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CP");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Colonia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Municipio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Estado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Pais");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Residencia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn45 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Eliminado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn46 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DirComp");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn47 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FK_Facturacion_ClientesDirecciones");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FK_Facturacion_ClientesDirecciones", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn48 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn49 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocumento");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn50 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Serie");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn51 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Folio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn52 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaPagoSAT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn53 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CondicionesPago");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn54 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MetodoPago");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn55 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UsoCDFI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn56 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DireccionCompañia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn57 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Plazo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn58 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LimitePago");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn59 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Confirmacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn60 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Cliente");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn61 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ClienteDireccion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn62 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ClienteCuentaBancaria");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn63 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoCambio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn64 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Moneda");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn65 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Subtotal");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn66 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Descuentos");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn67 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ImpuestosTransladados");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn68 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ImpuestosRetenidos");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn69 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Total");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn70 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("StatusFacturacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn71 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaSolicitud");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn72 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UsuarioSolicitud");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn73 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaTimbrado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn74 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UUID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn75 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UsuarioTimbrado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn76 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RamoSeguro");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn77 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ReferenciaFacCancelada");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn78 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ConceptoCancelacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn79 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Poliza_str");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn80 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("iniVig");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn81 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("finVig");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn82 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RechazoDes");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn308 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreAnexo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn309 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AuditNumber");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn310 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IVA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn83 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FK_SolicitudCancelaciones_Facturacion");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand4 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FK_SolicitudCancelaciones_Facturacion", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn84 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn85 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn86 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaSolicitud");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn87 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Factura");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn88 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ObservacionesUsuario");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn89 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAtencion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn90 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ObservacionesCC");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn91 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCancelacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn92 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Serie");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn93 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Folio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn94 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Status");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn95 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UserName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn96 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NomCom");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn97 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Poliza_str");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand5 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FK_Facturacion_Clientes1", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn98 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn99 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocumento");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn100 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Serie");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn101 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Folio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn102 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaPagoSAT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn103 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CondicionesPago");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn104 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MetodoPago");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn105 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UsoCDFI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn106 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DireccionCompañia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn107 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Plazo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn108 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LimitePago");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn109 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Confirmacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn110 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Cliente");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn111 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ClienteDireccion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn112 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ClienteCuentaBancaria");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn113 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoCambio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn114 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Moneda");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn115 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Subtotal");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn116 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Descuentos");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn117 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ImpuestosTransladados");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn118 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ImpuestosRetenidos");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn119 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Total");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn120 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("StatusFacturacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn121 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaSolicitud");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn122 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UsuarioSolicitud");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn123 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaTimbrado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn124 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UUID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn125 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UsuarioTimbrado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn126 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RamoSeguro");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn127 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ReferenciaFacCancelada");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn128 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ConceptoCancelacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn129 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Poliza_str");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn130 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("iniVig");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn131 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("finVig");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn132 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RechazoDes");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn311 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreAnexo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn312 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AuditNumber");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn313 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IVA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn133 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FK_SolicitudCancelaciones_Facturacion");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand6 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FK_SolicitudCancelaciones_Facturacion", 4);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn134 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn135 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn136 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaSolicitud");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn137 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Factura");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn138 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ObservacionesUsuario");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn139 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAtencion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn140 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ObservacionesCC");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn141 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCancelacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn142 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Serie");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn143 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Folio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn144 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Status");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn145 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UserName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn146 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NomCom");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn147 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Poliza_str");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand7 = new Infragistics.Win.UltraWinGrid.UltraGridBand("CheckFacturas", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn148 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn149 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocumento");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn150 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Serie");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn151 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Folio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn152 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CondicionesPago");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn153 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Confirmacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn154 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Cliente");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn155 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoCambio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn156 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Moneda");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn157 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Subtotal");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn158 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Descuentos");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn159 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ImpuestosTransladados");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn160 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ImpuestosRetenidos");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn161 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("StatusFacturacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn162 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaSolicitud");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn163 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UsuarioSolicitud");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn164 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaTimbrado", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn165 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UUID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn166 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RFC");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn167 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("iniVig");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn168 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("finVig");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn169 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario Solicitante");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn170 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaPago_str");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn171 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Mon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn172 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Status_str");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn173 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NomComp");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn174 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Total");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn175 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RechazoDes");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn176 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Poliza_str");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn177 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AuditNumber");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn178 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FK_ClientesDirecciones_Clientes1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn179 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FK_Facturacion_Clientes1");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand8 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FK_ClientesDirecciones_Clientes1", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn180 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn181 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Cliente");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn182 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Calle");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn183 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NumExterior");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn184 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NumInterior");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn185 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CP");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn186 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Colonia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn187 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Municipio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn188 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Estado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn189 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Pais");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn190 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Residencia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn191 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Eliminado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn192 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DirComp");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn193 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FK_Facturacion_ClientesDirecciones");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand9 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FK_Facturacion_ClientesDirecciones", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn194 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn195 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocumento");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn196 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Serie");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn197 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Folio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn198 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaPagoSAT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn199 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CondicionesPago");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn200 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MetodoPago");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn201 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UsoCDFI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn202 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DireccionCompañia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn203 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Plazo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn204 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LimitePago");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn205 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Confirmacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn206 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Cliente");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn207 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ClienteDireccion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn208 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ClienteCuentaBancaria");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn209 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoCambio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn210 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Moneda");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn211 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Subtotal");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn212 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Descuentos");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn213 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ImpuestosTransladados");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn214 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ImpuestosRetenidos");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn215 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Total");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn216 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("StatusFacturacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn217 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaSolicitud");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn218 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UsuarioSolicitud");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn219 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaTimbrado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn220 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UUID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn221 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UsuarioTimbrado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn222 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RamoSeguro");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn223 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ReferenciaFacCancelada");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn224 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ConceptoCancelacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn225 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Poliza_str");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn226 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("iniVig");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn227 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("finVig");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn228 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RechazoDes");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn314 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreAnexo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn315 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AuditNumber");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn316 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IVA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn229 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FK_SolicitudCancelaciones_Facturacion");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand10 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FK_SolicitudCancelaciones_Facturacion", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn230 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn231 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn232 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaSolicitud");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn233 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Factura");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn234 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ObservacionesUsuario");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn235 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAtencion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn236 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ObservacionesCC");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn237 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCancelacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn238 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Serie");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn239 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Folio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn240 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Status");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn241 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UserName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn242 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NomCom");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn243 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Poliza_str");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand11 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FK_Facturacion_Clientes1", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn244 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn245 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocumento");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn246 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Serie");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn247 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Folio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn248 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaPagoSAT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn249 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CondicionesPago");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn250 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MetodoPago");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn251 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UsoCDFI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn252 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DireccionCompañia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn253 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Plazo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn254 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LimitePago");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn255 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Confirmacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn256 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Cliente");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn257 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ClienteDireccion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn258 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ClienteCuentaBancaria");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn259 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoCambio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn260 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Moneda");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn261 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Subtotal");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn262 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Descuentos");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn263 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ImpuestosTransladados");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn264 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ImpuestosRetenidos");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn265 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Total");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn266 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("StatusFacturacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn267 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaSolicitud");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn268 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UsuarioSolicitud");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn269 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaTimbrado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn270 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UUID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn271 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UsuarioTimbrado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn272 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RamoSeguro");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn273 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ReferenciaFacCancelada");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn274 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ConceptoCancelacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn275 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Poliza_str");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn276 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("iniVig");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn277 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("finVig");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn278 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RechazoDes");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn317 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreAnexo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn318 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AuditNumber");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn319 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IVA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn279 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FK_SolicitudCancelaciones_Facturacion");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand12 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FK_SolicitudCancelaciones_Facturacion", 4);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn280 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn281 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn282 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaSolicitud");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn283 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Factura");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn284 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ObservacionesUsuario");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn285 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAtencion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn286 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ObservacionesCC");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn287 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCancelacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn288 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Serie");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn289 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Folio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn290 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Status");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn291 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UserName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn292 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NomCom");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn293 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Poliza_str");
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand13 = new Infragistics.Win.UltraWinGrid.UltraGridBand("SolicitudCancelaciones", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn294 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn295 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn296 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaSolicitud", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn297 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Factura");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn298 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ObservacionesUsuario");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn299 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAtencion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn300 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ObservacionesCC");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn301 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCancelacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn302 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Serie");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn303 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Folio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn304 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Status");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn305 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UserName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn306 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NomCom");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn307 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Poliza_str");
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab4 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.RibbonTab ribbonTab1 = new Infragistics.Win.UltraWinToolbars.RibbonTab("MainAdminFacturacion");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup4 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("rbgSolicitudes");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("btnNuevaFactura");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnEditarSolicitud");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool24 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnRechazarSolicitud");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool25 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnProcesarSeleccionadas");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool26 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnGenerarReporte");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup7 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("rgbBase");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnEditarDatos");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnDescargarFactura");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool29 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnEditarRegistro");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool27 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnCopiaRegistro");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool28 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnReprocesar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnGenerarRecibos");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnRegenerarFactura");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnVerErrores");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnReporteSaldosInsolutos");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup8 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("rgbCancelaciones");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnProcesarCancelacion");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnGenerarReporte");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup5 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("rgbCobranzaUniversal");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup6 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("rbgActualizar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnActualizar");
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnRechazarSolicitud");
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool30 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnEditarSolicitud");
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool31 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnActualizar");
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool32 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnProcesarSeleccionadas");
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnCopiaRegistro");
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnReprocesar");
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnGenerarRecibos");
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnEditarRegistro");
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnVerErrores");
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnProcesarCancelacion");
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnGenerarReporte");
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnEditarDatos");
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnRegenerarFactura");
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnDescargarFactura");
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnReporteSaldosInsolutos");
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("btnNuevaFactura");
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnNuevaFacturaOpen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool34 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnNuevoRetenciones");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool33 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnNuevaFacturaOpen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool35 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnNuevoRetenciones");
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.grpPendientes = new Infragistics.Win.Misc.UltraGroupBox();
            this.dgPendientes = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.cms_dgSolicitudes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timbrarDocumentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarSolicitudToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rechazarSolicitudToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkFacturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturacion = new SmartG.Datasets.CreditControl.Facturacion();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.grpBusqueda = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnExcelReporteJournal = new Infragistics.Win.Misc.UltraButton();
            this.cbParametro = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btnBuscar = new Infragistics.Win.Misc.UltraButton();
            this.lbBuscar = new Infragistics.Win.Misc.UltraLabel();
            this.lbParametro = new Infragistics.Win.Misc.UltraLabel();
            this.txtBusqueda = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.dateBusqueda = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.grpCompletadas = new Infragistics.Win.Misc.UltraGroupBox();
            this.dgCompletadas = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.cms_dgCompletados = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarStatusRecibosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descargarFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.regenerarPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarDocumentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.verErroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarDocumentosRelacionadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarSaldoPendienteDePagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BasebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Basefacturacion = new SmartG.Datasets.CreditControl.Facturacion();
            this.ultraTabPageControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.grpCancelaciones = new Infragistics.Win.Misc.UltraGroupBox();
            this.dgCancelaciones = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.cms_dgCancelaciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cancelarDocumentoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.solicitudCancelacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.AdministracionFacturas_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this.AdminFactTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this._LiabilityInc_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.AdministracionFacToolBar = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._LiabilityInc_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._LiabilityInc_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._LiabilityInc_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.checkFacturasTableAdapter = new SmartG.Datasets.CreditControl.FacturacionTableAdapters.CheckFacturasTableAdapter();
            this.solicitudCancelacionesTableAdapter = new SmartG.Datasets.CreditControl.FacturacionTableAdapters.SolicitudCancelacionesTableAdapter();
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpPendientes)).BeginInit();
            this.grpPendientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPendientes)).BeginInit();
            this.cms_dgSolicitudes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkFacturasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturacion)).BeginInit();
            this.ultraTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpBusqueda)).BeginInit();
            this.grpBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbParametro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBusqueda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBusqueda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCompletadas)).BeginInit();
            this.grpCompletadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCompletadas)).BeginInit();
            this.cms_dgCompletados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BasebindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Basefacturacion)).BeginInit();
            this.ultraTabPageControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpCancelaciones)).BeginInit();
            this.grpCancelaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCancelaciones)).BeginInit();
            this.cms_dgCancelaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.solicitudCancelacionesBindingSource)).BeginInit();
            this.AdministracionFacturas_Fill_Panel.ClientArea.SuspendLayout();
            this.AdministracionFacturas_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdminFactTabControl)).BeginInit();
            this.AdminFactTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdministracionFacToolBar)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.AutoScroll = true;
            this.ultraTabPageControl1.AutoScrollMargin = new System.Drawing.Size(0, 50);
            this.ultraTabPageControl1.Controls.Add(this.grpPendientes);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(1198, 574);
            // 
            // grpPendientes
            // 
            this.grpPendientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPendientes.Controls.Add(this.dgPendientes);
            this.grpPendientes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpPendientes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpPendientes.Location = new System.Drawing.Point(23, 25);
            this.grpPendientes.Name = "grpPendientes";
            this.grpPendientes.Size = new System.Drawing.Size(1147, 500);
            this.grpPendientes.TabIndex = 0;
            this.grpPendientes.Text = "Solicitudes Pendientes de Procesamiento (Doble Clic para Editar)";
            this.grpPendientes.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // dgPendientes
            // 
            this.dgPendientes.ContextMenuStrip = this.cms_dgSolicitudes;
            this.dgPendientes.DataSource = this.checkFacturasBindingSource;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgPendientes.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 11;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 12;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 13;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 14;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 15;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 16;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 17;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 18;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 19;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 20;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 21;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 22;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn14.Header.Editor = null;
            ultraGridColumn14.Header.VisiblePosition = 23;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn15.Header.Caption = "Fecha Solicitud";
            ultraGridColumn15.Header.Editor = null;
            ultraGridColumn15.Header.VisiblePosition = 2;
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 24;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn17.Header.Editor = null;
            ultraGridColumn17.Header.VisiblePosition = 25;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn18.Header.Editor = null;
            ultraGridColumn18.Header.VisiblePosition = 26;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn19.Header.Editor = null;
            ultraGridColumn19.Header.VisiblePosition = 7;
            ultraGridColumn20.Header.Editor = null;
            ultraGridColumn20.Header.VisiblePosition = 27;
            ultraGridColumn21.Header.Editor = null;
            ultraGridColumn21.Header.VisiblePosition = 28;
            ultraGridColumn22.Header.Editor = null;
            ultraGridColumn22.Header.VisiblePosition = 5;
            ultraGridColumn23.Header.Caption = "Forma Pago";
            ultraGridColumn23.Header.Editor = null;
            ultraGridColumn23.Header.VisiblePosition = 4;
            ultraGridColumn24.Header.Caption = "Moneda";
            ultraGridColumn24.Header.Editor = null;
            ultraGridColumn24.Header.VisiblePosition = 9;
            ultraGridColumn25.Header.Caption = "Status";
            ultraGridColumn25.Header.Editor = null;
            ultraGridColumn25.Header.VisiblePosition = 6;
            ultraGridColumn26.Header.Caption = "Nombre Cliente";
            ultraGridColumn26.Header.Editor = null;
            ultraGridColumn26.Header.VisiblePosition = 8;
            ultraGridColumn27.Header.Caption = "Total $";
            ultraGridColumn27.Header.Editor = null;
            ultraGridColumn27.Header.VisiblePosition = 10;
            ultraGridColumn27.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn27.MaskInput = "{LOC}$ -n,nnn,nnn.nn";
            ultraGridColumn28.Header.Editor = null;
            ultraGridColumn28.Header.VisiblePosition = 29;
            ultraGridColumn28.Hidden = true;
            ultraGridColumn29.Header.Caption = "Poliza";
            ultraGridColumn29.Header.Editor = null;
            ultraGridColumn29.Header.VisiblePosition = 3;
            ultraGridColumn30.Header.Editor = null;
            ultraGridColumn30.Header.VisiblePosition = 30;
            ultraGridColumn31.Header.Editor = null;
            ultraGridColumn31.Header.VisiblePosition = 31;
            ultraGridColumn32.Header.Editor = null;
            ultraGridColumn32.Header.VisiblePosition = 32;
            ultraGridColumn33.DataType = typeof(bool);
            ultraGridColumn33.DefaultCellValue = false;
            ultraGridColumn33.Header.Caption = "Procesar";
            ultraGridColumn33.Header.Editor = null;
            ultraGridColumn33.Header.VisiblePosition = 1;
            ultraGridColumn33.Hidden = true;
            ultraGridColumn33.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            ultraGridColumn33.Width = 69;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32,
            ultraGridColumn33});
            ultraGridColumn34.Header.Editor = null;
            ultraGridColumn34.Header.VisiblePosition = 0;
            ultraGridColumn35.Header.Editor = null;
            ultraGridColumn35.Header.VisiblePosition = 1;
            ultraGridColumn36.Header.Editor = null;
            ultraGridColumn36.Header.VisiblePosition = 2;
            ultraGridColumn37.Header.Editor = null;
            ultraGridColumn37.Header.VisiblePosition = 3;
            ultraGridColumn38.Header.Editor = null;
            ultraGridColumn38.Header.VisiblePosition = 4;
            ultraGridColumn39.Header.Editor = null;
            ultraGridColumn39.Header.VisiblePosition = 5;
            ultraGridColumn40.Header.Editor = null;
            ultraGridColumn40.Header.VisiblePosition = 6;
            ultraGridColumn41.Header.Editor = null;
            ultraGridColumn41.Header.VisiblePosition = 7;
            ultraGridColumn42.Header.Editor = null;
            ultraGridColumn42.Header.VisiblePosition = 8;
            ultraGridColumn43.Header.Editor = null;
            ultraGridColumn43.Header.VisiblePosition = 9;
            ultraGridColumn44.Header.Editor = null;
            ultraGridColumn44.Header.VisiblePosition = 10;
            ultraGridColumn45.Header.Editor = null;
            ultraGridColumn45.Header.VisiblePosition = 11;
            ultraGridColumn46.Header.Editor = null;
            ultraGridColumn46.Header.VisiblePosition = 12;
            ultraGridColumn47.Header.Editor = null;
            ultraGridColumn47.Header.VisiblePosition = 13;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn34,
            ultraGridColumn35,
            ultraGridColumn36,
            ultraGridColumn37,
            ultraGridColumn38,
            ultraGridColumn39,
            ultraGridColumn40,
            ultraGridColumn41,
            ultraGridColumn42,
            ultraGridColumn43,
            ultraGridColumn44,
            ultraGridColumn45,
            ultraGridColumn46,
            ultraGridColumn47});
            ultraGridColumn48.Header.Editor = null;
            ultraGridColumn48.Header.VisiblePosition = 0;
            ultraGridColumn49.Header.Editor = null;
            ultraGridColumn49.Header.VisiblePosition = 1;
            ultraGridColumn50.Header.Editor = null;
            ultraGridColumn50.Header.VisiblePosition = 2;
            ultraGridColumn51.Header.Editor = null;
            ultraGridColumn51.Header.VisiblePosition = 3;
            ultraGridColumn52.Header.Editor = null;
            ultraGridColumn52.Header.VisiblePosition = 4;
            ultraGridColumn53.Header.Editor = null;
            ultraGridColumn53.Header.VisiblePosition = 5;
            ultraGridColumn54.Header.Editor = null;
            ultraGridColumn54.Header.VisiblePosition = 6;
            ultraGridColumn55.Header.Editor = null;
            ultraGridColumn55.Header.VisiblePosition = 7;
            ultraGridColumn56.Header.Editor = null;
            ultraGridColumn56.Header.VisiblePosition = 8;
            ultraGridColumn57.Header.Editor = null;
            ultraGridColumn57.Header.VisiblePosition = 9;
            ultraGridColumn58.Header.Editor = null;
            ultraGridColumn58.Header.VisiblePosition = 10;
            ultraGridColumn59.Header.Editor = null;
            ultraGridColumn59.Header.VisiblePosition = 11;
            ultraGridColumn60.Header.Editor = null;
            ultraGridColumn60.Header.VisiblePosition = 12;
            ultraGridColumn61.Header.Editor = null;
            ultraGridColumn61.Header.VisiblePosition = 13;
            ultraGridColumn62.Header.Editor = null;
            ultraGridColumn62.Header.VisiblePosition = 14;
            ultraGridColumn63.Header.Editor = null;
            ultraGridColumn63.Header.VisiblePosition = 15;
            ultraGridColumn64.Header.Editor = null;
            ultraGridColumn64.Header.VisiblePosition = 16;
            ultraGridColumn65.Header.Editor = null;
            ultraGridColumn65.Header.VisiblePosition = 17;
            ultraGridColumn66.Header.Editor = null;
            ultraGridColumn66.Header.VisiblePosition = 18;
            ultraGridColumn67.Header.Editor = null;
            ultraGridColumn67.Header.VisiblePosition = 19;
            ultraGridColumn68.Header.Editor = null;
            ultraGridColumn68.Header.VisiblePosition = 20;
            ultraGridColumn69.Header.Editor = null;
            ultraGridColumn69.Header.VisiblePosition = 21;
            ultraGridColumn70.Header.Editor = null;
            ultraGridColumn70.Header.VisiblePosition = 22;
            ultraGridColumn71.Header.Editor = null;
            ultraGridColumn71.Header.VisiblePosition = 23;
            ultraGridColumn72.Header.Editor = null;
            ultraGridColumn72.Header.VisiblePosition = 24;
            ultraGridColumn73.Header.Editor = null;
            ultraGridColumn73.Header.VisiblePosition = 25;
            ultraGridColumn74.Header.Editor = null;
            ultraGridColumn74.Header.VisiblePosition = 26;
            ultraGridColumn75.Header.Editor = null;
            ultraGridColumn75.Header.VisiblePosition = 27;
            ultraGridColumn76.Header.Editor = null;
            ultraGridColumn76.Header.VisiblePosition = 28;
            ultraGridColumn77.Header.Editor = null;
            ultraGridColumn77.Header.VisiblePosition = 29;
            ultraGridColumn78.Header.Editor = null;
            ultraGridColumn78.Header.VisiblePosition = 30;
            ultraGridColumn79.Header.Editor = null;
            ultraGridColumn79.Header.VisiblePosition = 31;
            ultraGridColumn80.Header.Editor = null;
            ultraGridColumn80.Header.VisiblePosition = 32;
            ultraGridColumn81.Header.Editor = null;
            ultraGridColumn81.Header.VisiblePosition = 33;
            ultraGridColumn82.Header.Editor = null;
            ultraGridColumn82.Header.VisiblePosition = 34;
            ultraGridColumn308.Header.Editor = null;
            ultraGridColumn308.Header.VisiblePosition = 35;
            ultraGridColumn309.Header.Editor = null;
            ultraGridColumn309.Header.VisiblePosition = 36;
            ultraGridColumn310.Header.Editor = null;
            ultraGridColumn310.Header.VisiblePosition = 37;
            ultraGridColumn83.Header.Editor = null;
            ultraGridColumn83.Header.VisiblePosition = 38;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn48,
            ultraGridColumn49,
            ultraGridColumn50,
            ultraGridColumn51,
            ultraGridColumn52,
            ultraGridColumn53,
            ultraGridColumn54,
            ultraGridColumn55,
            ultraGridColumn56,
            ultraGridColumn57,
            ultraGridColumn58,
            ultraGridColumn59,
            ultraGridColumn60,
            ultraGridColumn61,
            ultraGridColumn62,
            ultraGridColumn63,
            ultraGridColumn64,
            ultraGridColumn65,
            ultraGridColumn66,
            ultraGridColumn67,
            ultraGridColumn68,
            ultraGridColumn69,
            ultraGridColumn70,
            ultraGridColumn71,
            ultraGridColumn72,
            ultraGridColumn73,
            ultraGridColumn74,
            ultraGridColumn75,
            ultraGridColumn76,
            ultraGridColumn77,
            ultraGridColumn78,
            ultraGridColumn79,
            ultraGridColumn80,
            ultraGridColumn81,
            ultraGridColumn82,
            ultraGridColumn308,
            ultraGridColumn309,
            ultraGridColumn310,
            ultraGridColumn83});
            ultraGridColumn84.Header.Editor = null;
            ultraGridColumn84.Header.VisiblePosition = 0;
            ultraGridColumn85.Header.Editor = null;
            ultraGridColumn85.Header.VisiblePosition = 1;
            ultraGridColumn86.Header.Editor = null;
            ultraGridColumn86.Header.VisiblePosition = 2;
            ultraGridColumn87.Header.Editor = null;
            ultraGridColumn87.Header.VisiblePosition = 3;
            ultraGridColumn88.Header.Editor = null;
            ultraGridColumn88.Header.VisiblePosition = 4;
            ultraGridColumn89.Header.Editor = null;
            ultraGridColumn89.Header.VisiblePosition = 5;
            ultraGridColumn90.Header.Editor = null;
            ultraGridColumn90.Header.VisiblePosition = 6;
            ultraGridColumn91.Header.Editor = null;
            ultraGridColumn91.Header.VisiblePosition = 7;
            ultraGridColumn92.Header.Editor = null;
            ultraGridColumn92.Header.VisiblePosition = 8;
            ultraGridColumn93.Header.Editor = null;
            ultraGridColumn93.Header.VisiblePosition = 9;
            ultraGridColumn94.Header.Editor = null;
            ultraGridColumn94.Header.VisiblePosition = 10;
            ultraGridColumn95.Header.Editor = null;
            ultraGridColumn95.Header.VisiblePosition = 11;
            ultraGridColumn96.Header.Editor = null;
            ultraGridColumn96.Header.VisiblePosition = 12;
            ultraGridColumn97.Header.Editor = null;
            ultraGridColumn97.Header.VisiblePosition = 13;
            ultraGridBand4.Columns.AddRange(new object[] {
            ultraGridColumn84,
            ultraGridColumn85,
            ultraGridColumn86,
            ultraGridColumn87,
            ultraGridColumn88,
            ultraGridColumn89,
            ultraGridColumn90,
            ultraGridColumn91,
            ultraGridColumn92,
            ultraGridColumn93,
            ultraGridColumn94,
            ultraGridColumn95,
            ultraGridColumn96,
            ultraGridColumn97});
            ultraGridColumn98.Header.Editor = null;
            ultraGridColumn98.Header.VisiblePosition = 0;
            ultraGridColumn99.Header.Editor = null;
            ultraGridColumn99.Header.VisiblePosition = 1;
            ultraGridColumn100.Header.Editor = null;
            ultraGridColumn100.Header.VisiblePosition = 2;
            ultraGridColumn101.Header.Editor = null;
            ultraGridColumn101.Header.VisiblePosition = 3;
            ultraGridColumn102.Header.Editor = null;
            ultraGridColumn102.Header.VisiblePosition = 4;
            ultraGridColumn103.Header.Editor = null;
            ultraGridColumn103.Header.VisiblePosition = 5;
            ultraGridColumn104.Header.Editor = null;
            ultraGridColumn104.Header.VisiblePosition = 6;
            ultraGridColumn105.Header.Editor = null;
            ultraGridColumn105.Header.VisiblePosition = 7;
            ultraGridColumn106.Header.Editor = null;
            ultraGridColumn106.Header.VisiblePosition = 8;
            ultraGridColumn107.Header.Editor = null;
            ultraGridColumn107.Header.VisiblePosition = 9;
            ultraGridColumn108.Header.Editor = null;
            ultraGridColumn108.Header.VisiblePosition = 10;
            ultraGridColumn109.Header.Editor = null;
            ultraGridColumn109.Header.VisiblePosition = 11;
            ultraGridColumn110.Header.Editor = null;
            ultraGridColumn110.Header.VisiblePosition = 12;
            ultraGridColumn111.Header.Editor = null;
            ultraGridColumn111.Header.VisiblePosition = 13;
            ultraGridColumn112.Header.Editor = null;
            ultraGridColumn112.Header.VisiblePosition = 14;
            ultraGridColumn113.Header.Editor = null;
            ultraGridColumn113.Header.VisiblePosition = 15;
            ultraGridColumn114.Header.Editor = null;
            ultraGridColumn114.Header.VisiblePosition = 16;
            ultraGridColumn115.Header.Editor = null;
            ultraGridColumn115.Header.VisiblePosition = 17;
            ultraGridColumn116.Header.Editor = null;
            ultraGridColumn116.Header.VisiblePosition = 18;
            ultraGridColumn117.Header.Editor = null;
            ultraGridColumn117.Header.VisiblePosition = 19;
            ultraGridColumn118.Header.Editor = null;
            ultraGridColumn118.Header.VisiblePosition = 20;
            ultraGridColumn119.Header.Editor = null;
            ultraGridColumn119.Header.VisiblePosition = 21;
            ultraGridColumn120.Header.Editor = null;
            ultraGridColumn120.Header.VisiblePosition = 22;
            ultraGridColumn121.Header.Editor = null;
            ultraGridColumn121.Header.VisiblePosition = 23;
            ultraGridColumn122.Header.Editor = null;
            ultraGridColumn122.Header.VisiblePosition = 24;
            ultraGridColumn123.Header.Editor = null;
            ultraGridColumn123.Header.VisiblePosition = 25;
            ultraGridColumn124.Header.Editor = null;
            ultraGridColumn124.Header.VisiblePosition = 26;
            ultraGridColumn125.Header.Editor = null;
            ultraGridColumn125.Header.VisiblePosition = 27;
            ultraGridColumn126.Header.Editor = null;
            ultraGridColumn126.Header.VisiblePosition = 28;
            ultraGridColumn127.Header.Editor = null;
            ultraGridColumn127.Header.VisiblePosition = 29;
            ultraGridColumn128.Header.Editor = null;
            ultraGridColumn128.Header.VisiblePosition = 30;
            ultraGridColumn129.Header.Editor = null;
            ultraGridColumn129.Header.VisiblePosition = 31;
            ultraGridColumn130.Header.Editor = null;
            ultraGridColumn130.Header.VisiblePosition = 32;
            ultraGridColumn131.Header.Editor = null;
            ultraGridColumn131.Header.VisiblePosition = 33;
            ultraGridColumn132.Header.Editor = null;
            ultraGridColumn132.Header.VisiblePosition = 34;
            ultraGridColumn311.Header.Editor = null;
            ultraGridColumn311.Header.VisiblePosition = 35;
            ultraGridColumn312.Header.Editor = null;
            ultraGridColumn312.Header.VisiblePosition = 36;
            ultraGridColumn313.Header.Editor = null;
            ultraGridColumn313.Header.VisiblePosition = 37;
            ultraGridColumn133.Header.Editor = null;
            ultraGridColumn133.Header.VisiblePosition = 38;
            ultraGridBand5.Columns.AddRange(new object[] {
            ultraGridColumn98,
            ultraGridColumn99,
            ultraGridColumn100,
            ultraGridColumn101,
            ultraGridColumn102,
            ultraGridColumn103,
            ultraGridColumn104,
            ultraGridColumn105,
            ultraGridColumn106,
            ultraGridColumn107,
            ultraGridColumn108,
            ultraGridColumn109,
            ultraGridColumn110,
            ultraGridColumn111,
            ultraGridColumn112,
            ultraGridColumn113,
            ultraGridColumn114,
            ultraGridColumn115,
            ultraGridColumn116,
            ultraGridColumn117,
            ultraGridColumn118,
            ultraGridColumn119,
            ultraGridColumn120,
            ultraGridColumn121,
            ultraGridColumn122,
            ultraGridColumn123,
            ultraGridColumn124,
            ultraGridColumn125,
            ultraGridColumn126,
            ultraGridColumn127,
            ultraGridColumn128,
            ultraGridColumn129,
            ultraGridColumn130,
            ultraGridColumn131,
            ultraGridColumn132,
            ultraGridColumn311,
            ultraGridColumn312,
            ultraGridColumn313,
            ultraGridColumn133});
            ultraGridColumn134.Header.Editor = null;
            ultraGridColumn134.Header.VisiblePosition = 0;
            ultraGridColumn135.Header.Editor = null;
            ultraGridColumn135.Header.VisiblePosition = 1;
            ultraGridColumn136.Header.Editor = null;
            ultraGridColumn136.Header.VisiblePosition = 2;
            ultraGridColumn137.Header.Editor = null;
            ultraGridColumn137.Header.VisiblePosition = 3;
            ultraGridColumn138.Header.Editor = null;
            ultraGridColumn138.Header.VisiblePosition = 4;
            ultraGridColumn139.Header.Editor = null;
            ultraGridColumn139.Header.VisiblePosition = 5;
            ultraGridColumn140.Header.Editor = null;
            ultraGridColumn140.Header.VisiblePosition = 6;
            ultraGridColumn141.Header.Editor = null;
            ultraGridColumn141.Header.VisiblePosition = 7;
            ultraGridColumn142.Header.Editor = null;
            ultraGridColumn142.Header.VisiblePosition = 8;
            ultraGridColumn143.Header.Editor = null;
            ultraGridColumn143.Header.VisiblePosition = 9;
            ultraGridColumn144.Header.Editor = null;
            ultraGridColumn144.Header.VisiblePosition = 10;
            ultraGridColumn145.Header.Editor = null;
            ultraGridColumn145.Header.VisiblePosition = 11;
            ultraGridColumn146.Header.Editor = null;
            ultraGridColumn146.Header.VisiblePosition = 12;
            ultraGridColumn147.Header.Editor = null;
            ultraGridColumn147.Header.VisiblePosition = 13;
            ultraGridBand6.Columns.AddRange(new object[] {
            ultraGridColumn134,
            ultraGridColumn135,
            ultraGridColumn136,
            ultraGridColumn137,
            ultraGridColumn138,
            ultraGridColumn139,
            ultraGridColumn140,
            ultraGridColumn141,
            ultraGridColumn142,
            ultraGridColumn143,
            ultraGridColumn144,
            ultraGridColumn145,
            ultraGridColumn146,
            ultraGridColumn147});
            this.dgPendientes.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgPendientes.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.dgPendientes.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.dgPendientes.DisplayLayout.BandsSerializer.Add(ultraGridBand4);
            this.dgPendientes.DisplayLayout.BandsSerializer.Add(ultraGridBand5);
            this.dgPendientes.DisplayLayout.BandsSerializer.Add(ultraGridBand6);
            this.dgPendientes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgPendientes.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.dgPendientes.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgPendientes.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.dgPendientes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgPendientes.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.dgPendientes.DisplayLayout.MaxColScrollRegions = 1;
            this.dgPendientes.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgPendientes.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgPendientes.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.dgPendientes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.dgPendientes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.dgPendientes.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgPendientes.DisplayLayout.Override.CellAppearance = appearance8;
            this.dgPendientes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.dgPendientes.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.dgPendientes.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.dgPendientes.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.dgPendientes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgPendientes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.dgPendientes.DisplayLayout.Override.RowAppearance = appearance11;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgPendientes.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.dgPendientes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgPendientes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgPendientes.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.dgPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPendientes.Font = new System.Drawing.Font("Arial", 9.75F);
            this.dgPendientes.Location = new System.Drawing.Point(2, 21);
            this.dgPendientes.Name = "dgPendientes";
            this.dgPendientes.Size = new System.Drawing.Size(1143, 477);
            this.dgPendientes.TabIndex = 0;
            this.dgPendientes.Text = "ultraGrid1";
            this.dgPendientes.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.dgPendientes_DoubleClickRow);
            this.dgPendientes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGrid_MouseDown);
            // 
            // cms_dgSolicitudes
            // 
            this.cms_dgSolicitudes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timbrarDocumentoToolStripMenuItem,
            this.editarSolicitudToolStripMenuItem,
            this.rechazarSolicitudToolStripMenuItem});
            this.cms_dgSolicitudes.Name = "cms_dgSolicitudes";
            this.cms_dgSolicitudes.Size = new System.Drawing.Size(183, 70);
            this.cms_dgSolicitudes.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cms_dgSolicitudes_ItemClicked);
            // 
            // timbrarDocumentoToolStripMenuItem
            // 
            this.timbrarDocumentoToolStripMenuItem.Name = "timbrarDocumentoToolStripMenuItem";
            this.timbrarDocumentoToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.timbrarDocumentoToolStripMenuItem.Text = "Timbrar Documento";
            // 
            // editarSolicitudToolStripMenuItem
            // 
            this.editarSolicitudToolStripMenuItem.Name = "editarSolicitudToolStripMenuItem";
            this.editarSolicitudToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.editarSolicitudToolStripMenuItem.Text = "Editar Solicitud";
            // 
            // rechazarSolicitudToolStripMenuItem
            // 
            this.rechazarSolicitudToolStripMenuItem.Name = "rechazarSolicitudToolStripMenuItem";
            this.rechazarSolicitudToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.rechazarSolicitudToolStripMenuItem.Text = "Rechazar Solicitud";
            // 
            // checkFacturasBindingSource
            // 
            this.checkFacturasBindingSource.DataMember = "CheckFacturas";
            this.checkFacturasBindingSource.DataSource = this.facturacion;
            // 
            // facturacion
            // 
            this.facturacion.DataSetName = "Facturacion";
            this.facturacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.AutoScrollMargin = new System.Drawing.Size(0, 50);
            this.ultraTabPageControl2.Controls.Add(this.grpBusqueda);
            this.ultraTabPageControl2.Controls.Add(this.grpCompletadas);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(116, 1);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(1198, 599);
            // 
            // grpBusqueda
            // 
            this.grpBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBusqueda.Controls.Add(this.btnExcelReporteJournal);
            this.grpBusqueda.Controls.Add(this.cbParametro);
            this.grpBusqueda.Controls.Add(this.btnBuscar);
            this.grpBusqueda.Controls.Add(this.lbBuscar);
            this.grpBusqueda.Controls.Add(this.lbParametro);
            this.grpBusqueda.Controls.Add(this.txtBusqueda);
            this.grpBusqueda.Controls.Add(this.dateBusqueda);
            this.grpBusqueda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpBusqueda.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpBusqueda.Location = new System.Drawing.Point(25, 22);
            this.grpBusqueda.Name = "grpBusqueda";
            this.grpBusqueda.Size = new System.Drawing.Size(1136, 104);
            this.grpBusqueda.TabIndex = 2;
            this.grpBusqueda.Text = "Busqueda de Facturas";
            this.grpBusqueda.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // btnExcelReporteJournal
            // 
            appearance13.ImageBackground = global::SmartG.Properties.Resources.analytics;
            this.btnExcelReporteJournal.Appearance = appearance13;
            this.btnExcelReporteJournal.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnExcelReporteJournal.Location = new System.Drawing.Point(857, 42);
            this.btnExcelReporteJournal.Name = "btnExcelReporteJournal";
            this.btnExcelReporteJournal.Size = new System.Drawing.Size(46, 46);
            this.btnExcelReporteJournal.TabIndex = 22;
            this.btnExcelReporteJournal.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnExcelReporteJournal.Click += new System.EventHandler(this.btnExcelReporteJournal_Click);
            // 
            // cbParametro
            // 
            this.cbParametro.DisplayMember = "DirComp";
            this.cbParametro.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.cbParametro.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbParametro.Font = new System.Drawing.Font("Arial", 9.75F);
            valueListItem9.DataValue = "Nombre Cliente";
            valueListItem10.DataValue = "RFC";
            valueListItem11.DataValue = "Poliza";
            valueListItem12.DataValue = "Folio";
            valueListItem13.DataValue = "UUID";
            valueListItem14.DataValue = "Fecha Solicitud";
            valueListItem15.DataValue = "Fecha Timbrado";
            valueListItem1.DataValue = "Audit Number";
            this.cbParametro.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem9,
            valueListItem10,
            valueListItem11,
            valueListItem12,
            valueListItem13,
            valueListItem14,
            valueListItem15,
            valueListItem1});
            this.cbParametro.LimitToList = true;
            this.cbParametro.Location = new System.Drawing.Point(122, 54);
            this.cbParametro.Name = "cbParametro";
            this.cbParametro.Size = new System.Drawing.Size(228, 24);
            this.cbParametro.TabIndex = 21;
            this.cbParametro.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbParametro.ValueMember = "ID";
            this.cbParametro.ItemNotInList += new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.ValidarCB);
            this.cbParametro.ValueChanged += new System.EventHandler(this.cbParametro_ValueChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnBuscar.Location = new System.Drawing.Point(724, 53);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(111, 23);
            this.btnBuscar.TabIndex = 18;
            this.btnBuscar.Text = "Consultar";
            this.btnBuscar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lbBuscar
            // 
            appearance14.BackColor = System.Drawing.Color.Transparent;
            appearance14.TextVAlignAsString = "Middle";
            this.lbBuscar.Appearance = appearance14;
            this.lbBuscar.Location = new System.Drawing.Point(356, 53);
            this.lbBuscar.Name = "lbBuscar";
            this.lbBuscar.Size = new System.Drawing.Size(58, 23);
            this.lbBuscar.TabIndex = 15;
            this.lbBuscar.Text = "Buscar:";
            // 
            // lbParametro
            // 
            appearance15.BackColor = System.Drawing.Color.Transparent;
            appearance15.TextVAlignAsString = "Middle";
            this.lbParametro.Appearance = appearance15;
            this.lbParametro.Location = new System.Drawing.Point(26, 53);
            this.lbParametro.Name = "lbParametro";
            this.lbParametro.Size = new System.Drawing.Size(115, 23);
            this.lbParametro.TabIndex = 10;
            this.lbParametro.Text = "Parametro:";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.txtBusqueda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(420, 52);
            this.txtBusqueda.MaxLength = 50;
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(259, 24);
            this.txtBusqueda.TabIndex = 17;
            this.txtBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBusqueda_KeyDown);
            // 
            // dateBusqueda
            // 
            this.dateBusqueda.DateTime = new System.DateTime(2018, 6, 18, 0, 0, 0, 0);
            this.dateBusqueda.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.dateBusqueda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateBusqueda.Location = new System.Drawing.Point(420, 52);
            this.dateBusqueda.MaskInput = "{date} {time}";
            this.dateBusqueda.Name = "dateBusqueda";
            this.dateBusqueda.PromptChar = ' ';
            this.dateBusqueda.Size = new System.Drawing.Size(259, 24);
            this.dateBusqueda.TabIndex = 16;
            this.dateBusqueda.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.dateBusqueda.Value = new System.DateTime(2018, 6, 18, 0, 0, 0, 0);
            // 
            // grpCompletadas
            // 
            this.grpCompletadas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCompletadas.Controls.Add(this.dgCompletadas);
            this.grpCompletadas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpCompletadas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpCompletadas.Location = new System.Drawing.Point(23, 149);
            this.grpCompletadas.Name = "grpCompletadas";
            this.grpCompletadas.Size = new System.Drawing.Size(1138, 407);
            this.grpCompletadas.TabIndex = 1;
            this.grpCompletadas.Text = "Solicitudes  Procesadas por Credit Control";
            this.grpCompletadas.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // dgCompletadas
            // 
            this.dgCompletadas.ContextMenuStrip = this.cms_dgCompletados;
            this.dgCompletadas.DataSource = this.BasebindingSource;
            appearance16.BackColor = System.Drawing.SystemColors.Window;
            appearance16.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgCompletadas.DisplayLayout.Appearance = appearance16;
            ultraGridColumn148.Header.Editor = null;
            ultraGridColumn148.Header.VisiblePosition = 17;
            ultraGridColumn148.Hidden = true;
            ultraGridColumn149.Header.Editor = null;
            ultraGridColumn149.Header.VisiblePosition = 18;
            ultraGridColumn149.Hidden = true;
            ultraGridColumn150.Header.Editor = null;
            ultraGridColumn150.Header.VisiblePosition = 1;
            ultraGridColumn151.Header.Editor = null;
            ultraGridColumn151.Header.VisiblePosition = 2;
            ultraGridColumn152.Header.Editor = null;
            ultraGridColumn152.Header.VisiblePosition = 19;
            ultraGridColumn152.Hidden = true;
            ultraGridColumn153.Header.Editor = null;
            ultraGridColumn153.Header.VisiblePosition = 20;
            ultraGridColumn153.Hidden = true;
            ultraGridColumn154.Header.Editor = null;
            ultraGridColumn154.Header.VisiblePosition = 21;
            ultraGridColumn154.Hidden = true;
            ultraGridColumn155.Header.Editor = null;
            ultraGridColumn155.Header.VisiblePosition = 13;
            ultraGridColumn156.Header.Editor = null;
            ultraGridColumn156.Header.VisiblePosition = 22;
            ultraGridColumn156.Hidden = true;
            ultraGridColumn157.Header.Editor = null;
            ultraGridColumn157.Header.VisiblePosition = 6;
            ultraGridColumn157.Hidden = true;
            ultraGridColumn157.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn157.MaskInput = "{LOC}$ -n,nnn,nnn.nn";
            ultraGridColumn158.Header.Editor = null;
            ultraGridColumn158.Header.VisiblePosition = 16;
            ultraGridColumn158.Hidden = true;
            ultraGridColumn159.Header.Editor = null;
            ultraGridColumn159.Header.VisiblePosition = 23;
            ultraGridColumn159.Hidden = true;
            ultraGridColumn160.Header.Editor = null;
            ultraGridColumn160.Header.VisiblePosition = 24;
            ultraGridColumn160.Hidden = true;
            ultraGridColumn161.Header.Editor = null;
            ultraGridColumn161.Header.VisiblePosition = 25;
            ultraGridColumn161.Hidden = true;
            ultraGridColumn162.Header.Editor = null;
            ultraGridColumn162.Header.VisiblePosition = 14;
            ultraGridColumn163.Header.Editor = null;
            ultraGridColumn163.Header.VisiblePosition = 26;
            ultraGridColumn163.Hidden = true;
            ultraGridColumn164.Header.Editor = null;
            ultraGridColumn164.Header.VisiblePosition = 4;
            ultraGridColumn165.Header.Editor = null;
            ultraGridColumn165.Header.VisiblePosition = 15;
            ultraGridColumn166.Header.Editor = null;
            ultraGridColumn166.Header.VisiblePosition = 12;
            ultraGridColumn167.Header.Editor = null;
            ultraGridColumn167.Header.VisiblePosition = 27;
            ultraGridColumn167.Hidden = true;
            ultraGridColumn168.Header.Editor = null;
            ultraGridColumn168.Header.VisiblePosition = 28;
            ultraGridColumn168.Hidden = true;
            ultraGridColumn169.Header.Editor = null;
            ultraGridColumn169.Header.VisiblePosition = 11;
            ultraGridColumn170.Header.Editor = null;
            ultraGridColumn170.Header.VisiblePosition = 8;
            ultraGridColumn171.Header.Editor = null;
            ultraGridColumn171.Header.VisiblePosition = 5;
            ultraGridColumn172.Header.Editor = null;
            ultraGridColumn172.Header.VisiblePosition = 0;
            ultraGridColumn173.Header.Editor = null;
            ultraGridColumn173.Header.VisiblePosition = 9;
            ultraGridColumn174.Header.Editor = null;
            ultraGridColumn174.Header.VisiblePosition = 7;
            ultraGridColumn174.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn174.MaskInput = "{LOC}$ -n,nnn,nnn.nn";
            ultraGridColumn175.Header.Editor = null;
            ultraGridColumn175.Header.VisiblePosition = 29;
            ultraGridColumn175.Hidden = true;
            ultraGridColumn176.Header.Editor = null;
            ultraGridColumn176.Header.VisiblePosition = 3;
            ultraGridColumn177.Header.Editor = null;
            ultraGridColumn177.Header.VisiblePosition = 10;
            ultraGridColumn178.Header.Editor = null;
            ultraGridColumn178.Header.VisiblePosition = 30;
            ultraGridColumn179.Header.Editor = null;
            ultraGridColumn179.Header.VisiblePosition = 31;
            ultraGridBand7.Columns.AddRange(new object[] {
            ultraGridColumn148,
            ultraGridColumn149,
            ultraGridColumn150,
            ultraGridColumn151,
            ultraGridColumn152,
            ultraGridColumn153,
            ultraGridColumn154,
            ultraGridColumn155,
            ultraGridColumn156,
            ultraGridColumn157,
            ultraGridColumn158,
            ultraGridColumn159,
            ultraGridColumn160,
            ultraGridColumn161,
            ultraGridColumn162,
            ultraGridColumn163,
            ultraGridColumn164,
            ultraGridColumn165,
            ultraGridColumn166,
            ultraGridColumn167,
            ultraGridColumn168,
            ultraGridColumn169,
            ultraGridColumn170,
            ultraGridColumn171,
            ultraGridColumn172,
            ultraGridColumn173,
            ultraGridColumn174,
            ultraGridColumn175,
            ultraGridColumn176,
            ultraGridColumn177,
            ultraGridColumn178,
            ultraGridColumn179});
            ultraGridColumn180.Header.Editor = null;
            ultraGridColumn180.Header.VisiblePosition = 0;
            ultraGridColumn181.Header.Editor = null;
            ultraGridColumn181.Header.VisiblePosition = 1;
            ultraGridColumn182.Header.Editor = null;
            ultraGridColumn182.Header.VisiblePosition = 2;
            ultraGridColumn183.Header.Editor = null;
            ultraGridColumn183.Header.VisiblePosition = 3;
            ultraGridColumn184.Header.Editor = null;
            ultraGridColumn184.Header.VisiblePosition = 4;
            ultraGridColumn185.Header.Editor = null;
            ultraGridColumn185.Header.VisiblePosition = 5;
            ultraGridColumn186.Header.Editor = null;
            ultraGridColumn186.Header.VisiblePosition = 6;
            ultraGridColumn187.Header.Editor = null;
            ultraGridColumn187.Header.VisiblePosition = 7;
            ultraGridColumn188.Header.Editor = null;
            ultraGridColumn188.Header.VisiblePosition = 8;
            ultraGridColumn189.Header.Editor = null;
            ultraGridColumn189.Header.VisiblePosition = 9;
            ultraGridColumn190.Header.Editor = null;
            ultraGridColumn190.Header.VisiblePosition = 10;
            ultraGridColumn191.Header.Editor = null;
            ultraGridColumn191.Header.VisiblePosition = 11;
            ultraGridColumn192.Header.Editor = null;
            ultraGridColumn192.Header.VisiblePosition = 12;
            ultraGridColumn193.Header.Editor = null;
            ultraGridColumn193.Header.VisiblePosition = 13;
            ultraGridBand8.Columns.AddRange(new object[] {
            ultraGridColumn180,
            ultraGridColumn181,
            ultraGridColumn182,
            ultraGridColumn183,
            ultraGridColumn184,
            ultraGridColumn185,
            ultraGridColumn186,
            ultraGridColumn187,
            ultraGridColumn188,
            ultraGridColumn189,
            ultraGridColumn190,
            ultraGridColumn191,
            ultraGridColumn192,
            ultraGridColumn193});
            ultraGridColumn194.Header.Editor = null;
            ultraGridColumn194.Header.VisiblePosition = 0;
            ultraGridColumn195.Header.Editor = null;
            ultraGridColumn195.Header.VisiblePosition = 1;
            ultraGridColumn196.Header.Editor = null;
            ultraGridColumn196.Header.VisiblePosition = 2;
            ultraGridColumn197.Header.Editor = null;
            ultraGridColumn197.Header.VisiblePosition = 3;
            ultraGridColumn198.Header.Editor = null;
            ultraGridColumn198.Header.VisiblePosition = 4;
            ultraGridColumn199.Header.Editor = null;
            ultraGridColumn199.Header.VisiblePosition = 5;
            ultraGridColumn200.Header.Editor = null;
            ultraGridColumn200.Header.VisiblePosition = 6;
            ultraGridColumn201.Header.Editor = null;
            ultraGridColumn201.Header.VisiblePosition = 7;
            ultraGridColumn202.Header.Editor = null;
            ultraGridColumn202.Header.VisiblePosition = 8;
            ultraGridColumn203.Header.Editor = null;
            ultraGridColumn203.Header.VisiblePosition = 9;
            ultraGridColumn204.Header.Editor = null;
            ultraGridColumn204.Header.VisiblePosition = 10;
            ultraGridColumn205.Header.Editor = null;
            ultraGridColumn205.Header.VisiblePosition = 11;
            ultraGridColumn206.Header.Editor = null;
            ultraGridColumn206.Header.VisiblePosition = 12;
            ultraGridColumn207.Header.Editor = null;
            ultraGridColumn207.Header.VisiblePosition = 13;
            ultraGridColumn208.Header.Editor = null;
            ultraGridColumn208.Header.VisiblePosition = 14;
            ultraGridColumn209.Header.Editor = null;
            ultraGridColumn209.Header.VisiblePosition = 15;
            ultraGridColumn210.Header.Editor = null;
            ultraGridColumn210.Header.VisiblePosition = 16;
            ultraGridColumn211.Header.Editor = null;
            ultraGridColumn211.Header.VisiblePosition = 17;
            ultraGridColumn212.Header.Editor = null;
            ultraGridColumn212.Header.VisiblePosition = 18;
            ultraGridColumn213.Header.Editor = null;
            ultraGridColumn213.Header.VisiblePosition = 19;
            ultraGridColumn214.Header.Editor = null;
            ultraGridColumn214.Header.VisiblePosition = 20;
            ultraGridColumn215.Header.Editor = null;
            ultraGridColumn215.Header.VisiblePosition = 21;
            ultraGridColumn216.Header.Editor = null;
            ultraGridColumn216.Header.VisiblePosition = 22;
            ultraGridColumn217.Header.Editor = null;
            ultraGridColumn217.Header.VisiblePosition = 23;
            ultraGridColumn218.Header.Editor = null;
            ultraGridColumn218.Header.VisiblePosition = 24;
            ultraGridColumn219.Header.Editor = null;
            ultraGridColumn219.Header.VisiblePosition = 25;
            ultraGridColumn220.Header.Editor = null;
            ultraGridColumn220.Header.VisiblePosition = 26;
            ultraGridColumn221.Header.Editor = null;
            ultraGridColumn221.Header.VisiblePosition = 27;
            ultraGridColumn222.Header.Editor = null;
            ultraGridColumn222.Header.VisiblePosition = 28;
            ultraGridColumn223.Header.Editor = null;
            ultraGridColumn223.Header.VisiblePosition = 29;
            ultraGridColumn224.Header.Editor = null;
            ultraGridColumn224.Header.VisiblePosition = 30;
            ultraGridColumn225.Header.Editor = null;
            ultraGridColumn225.Header.VisiblePosition = 31;
            ultraGridColumn226.Header.Editor = null;
            ultraGridColumn226.Header.VisiblePosition = 32;
            ultraGridColumn227.Header.Editor = null;
            ultraGridColumn227.Header.VisiblePosition = 33;
            ultraGridColumn228.Header.Editor = null;
            ultraGridColumn228.Header.VisiblePosition = 34;
            ultraGridColumn314.Header.Editor = null;
            ultraGridColumn314.Header.VisiblePosition = 35;
            ultraGridColumn315.Header.Editor = null;
            ultraGridColumn315.Header.VisiblePosition = 36;
            ultraGridColumn316.Header.Editor = null;
            ultraGridColumn316.Header.VisiblePosition = 37;
            ultraGridColumn229.Header.Editor = null;
            ultraGridColumn229.Header.VisiblePosition = 38;
            ultraGridBand9.Columns.AddRange(new object[] {
            ultraGridColumn194,
            ultraGridColumn195,
            ultraGridColumn196,
            ultraGridColumn197,
            ultraGridColumn198,
            ultraGridColumn199,
            ultraGridColumn200,
            ultraGridColumn201,
            ultraGridColumn202,
            ultraGridColumn203,
            ultraGridColumn204,
            ultraGridColumn205,
            ultraGridColumn206,
            ultraGridColumn207,
            ultraGridColumn208,
            ultraGridColumn209,
            ultraGridColumn210,
            ultraGridColumn211,
            ultraGridColumn212,
            ultraGridColumn213,
            ultraGridColumn214,
            ultraGridColumn215,
            ultraGridColumn216,
            ultraGridColumn217,
            ultraGridColumn218,
            ultraGridColumn219,
            ultraGridColumn220,
            ultraGridColumn221,
            ultraGridColumn222,
            ultraGridColumn223,
            ultraGridColumn224,
            ultraGridColumn225,
            ultraGridColumn226,
            ultraGridColumn227,
            ultraGridColumn228,
            ultraGridColumn314,
            ultraGridColumn315,
            ultraGridColumn316,
            ultraGridColumn229});
            ultraGridColumn230.Header.Editor = null;
            ultraGridColumn230.Header.VisiblePosition = 0;
            ultraGridColumn231.Header.Editor = null;
            ultraGridColumn231.Header.VisiblePosition = 1;
            ultraGridColumn232.Header.Editor = null;
            ultraGridColumn232.Header.VisiblePosition = 2;
            ultraGridColumn233.Header.Editor = null;
            ultraGridColumn233.Header.VisiblePosition = 3;
            ultraGridColumn234.Header.Editor = null;
            ultraGridColumn234.Header.VisiblePosition = 4;
            ultraGridColumn235.Header.Editor = null;
            ultraGridColumn235.Header.VisiblePosition = 5;
            ultraGridColumn236.Header.Editor = null;
            ultraGridColumn236.Header.VisiblePosition = 6;
            ultraGridColumn237.Header.Editor = null;
            ultraGridColumn237.Header.VisiblePosition = 7;
            ultraGridColumn238.Header.Editor = null;
            ultraGridColumn238.Header.VisiblePosition = 8;
            ultraGridColumn239.Header.Editor = null;
            ultraGridColumn239.Header.VisiblePosition = 9;
            ultraGridColumn240.Header.Editor = null;
            ultraGridColumn240.Header.VisiblePosition = 10;
            ultraGridColumn241.Header.Editor = null;
            ultraGridColumn241.Header.VisiblePosition = 11;
            ultraGridColumn242.Header.Editor = null;
            ultraGridColumn242.Header.VisiblePosition = 12;
            ultraGridColumn243.Header.Editor = null;
            ultraGridColumn243.Header.VisiblePosition = 13;
            ultraGridBand10.Columns.AddRange(new object[] {
            ultraGridColumn230,
            ultraGridColumn231,
            ultraGridColumn232,
            ultraGridColumn233,
            ultraGridColumn234,
            ultraGridColumn235,
            ultraGridColumn236,
            ultraGridColumn237,
            ultraGridColumn238,
            ultraGridColumn239,
            ultraGridColumn240,
            ultraGridColumn241,
            ultraGridColumn242,
            ultraGridColumn243});
            ultraGridColumn244.Header.Editor = null;
            ultraGridColumn244.Header.VisiblePosition = 0;
            ultraGridColumn245.Header.Editor = null;
            ultraGridColumn245.Header.VisiblePosition = 1;
            ultraGridColumn246.Header.Editor = null;
            ultraGridColumn246.Header.VisiblePosition = 2;
            ultraGridColumn247.Header.Editor = null;
            ultraGridColumn247.Header.VisiblePosition = 3;
            ultraGridColumn248.Header.Editor = null;
            ultraGridColumn248.Header.VisiblePosition = 4;
            ultraGridColumn249.Header.Editor = null;
            ultraGridColumn249.Header.VisiblePosition = 5;
            ultraGridColumn250.Header.Editor = null;
            ultraGridColumn250.Header.VisiblePosition = 6;
            ultraGridColumn251.Header.Editor = null;
            ultraGridColumn251.Header.VisiblePosition = 7;
            ultraGridColumn252.Header.Editor = null;
            ultraGridColumn252.Header.VisiblePosition = 8;
            ultraGridColumn253.Header.Editor = null;
            ultraGridColumn253.Header.VisiblePosition = 9;
            ultraGridColumn254.Header.Editor = null;
            ultraGridColumn254.Header.VisiblePosition = 10;
            ultraGridColumn255.Header.Editor = null;
            ultraGridColumn255.Header.VisiblePosition = 11;
            ultraGridColumn256.Header.Editor = null;
            ultraGridColumn256.Header.VisiblePosition = 12;
            ultraGridColumn257.Header.Editor = null;
            ultraGridColumn257.Header.VisiblePosition = 13;
            ultraGridColumn258.Header.Editor = null;
            ultraGridColumn258.Header.VisiblePosition = 14;
            ultraGridColumn259.Header.Editor = null;
            ultraGridColumn259.Header.VisiblePosition = 15;
            ultraGridColumn260.Header.Editor = null;
            ultraGridColumn260.Header.VisiblePosition = 16;
            ultraGridColumn261.Header.Editor = null;
            ultraGridColumn261.Header.VisiblePosition = 17;
            ultraGridColumn262.Header.Editor = null;
            ultraGridColumn262.Header.VisiblePosition = 18;
            ultraGridColumn263.Header.Editor = null;
            ultraGridColumn263.Header.VisiblePosition = 19;
            ultraGridColumn264.Header.Editor = null;
            ultraGridColumn264.Header.VisiblePosition = 20;
            ultraGridColumn265.Header.Editor = null;
            ultraGridColumn265.Header.VisiblePosition = 21;
            ultraGridColumn266.Header.Editor = null;
            ultraGridColumn266.Header.VisiblePosition = 22;
            ultraGridColumn267.Header.Editor = null;
            ultraGridColumn267.Header.VisiblePosition = 23;
            ultraGridColumn268.Header.Editor = null;
            ultraGridColumn268.Header.VisiblePosition = 24;
            ultraGridColumn269.Header.Editor = null;
            ultraGridColumn269.Header.VisiblePosition = 25;
            ultraGridColumn270.Header.Editor = null;
            ultraGridColumn270.Header.VisiblePosition = 26;
            ultraGridColumn271.Header.Editor = null;
            ultraGridColumn271.Header.VisiblePosition = 27;
            ultraGridColumn272.Header.Editor = null;
            ultraGridColumn272.Header.VisiblePosition = 28;
            ultraGridColumn273.Header.Editor = null;
            ultraGridColumn273.Header.VisiblePosition = 29;
            ultraGridColumn274.Header.Editor = null;
            ultraGridColumn274.Header.VisiblePosition = 30;
            ultraGridColumn275.Header.Editor = null;
            ultraGridColumn275.Header.VisiblePosition = 31;
            ultraGridColumn276.Header.Editor = null;
            ultraGridColumn276.Header.VisiblePosition = 32;
            ultraGridColumn277.Header.Editor = null;
            ultraGridColumn277.Header.VisiblePosition = 33;
            ultraGridColumn278.Header.Editor = null;
            ultraGridColumn278.Header.VisiblePosition = 34;
            ultraGridColumn317.Header.Editor = null;
            ultraGridColumn317.Header.VisiblePosition = 35;
            ultraGridColumn318.Header.Editor = null;
            ultraGridColumn318.Header.VisiblePosition = 36;
            ultraGridColumn319.Header.Editor = null;
            ultraGridColumn319.Header.VisiblePosition = 37;
            ultraGridColumn279.Header.Editor = null;
            ultraGridColumn279.Header.VisiblePosition = 38;
            ultraGridBand11.Columns.AddRange(new object[] {
            ultraGridColumn244,
            ultraGridColumn245,
            ultraGridColumn246,
            ultraGridColumn247,
            ultraGridColumn248,
            ultraGridColumn249,
            ultraGridColumn250,
            ultraGridColumn251,
            ultraGridColumn252,
            ultraGridColumn253,
            ultraGridColumn254,
            ultraGridColumn255,
            ultraGridColumn256,
            ultraGridColumn257,
            ultraGridColumn258,
            ultraGridColumn259,
            ultraGridColumn260,
            ultraGridColumn261,
            ultraGridColumn262,
            ultraGridColumn263,
            ultraGridColumn264,
            ultraGridColumn265,
            ultraGridColumn266,
            ultraGridColumn267,
            ultraGridColumn268,
            ultraGridColumn269,
            ultraGridColumn270,
            ultraGridColumn271,
            ultraGridColumn272,
            ultraGridColumn273,
            ultraGridColumn274,
            ultraGridColumn275,
            ultraGridColumn276,
            ultraGridColumn277,
            ultraGridColumn278,
            ultraGridColumn317,
            ultraGridColumn318,
            ultraGridColumn319,
            ultraGridColumn279});
            ultraGridColumn280.Header.Editor = null;
            ultraGridColumn280.Header.VisiblePosition = 0;
            ultraGridColumn281.Header.Editor = null;
            ultraGridColumn281.Header.VisiblePosition = 1;
            ultraGridColumn282.Header.Editor = null;
            ultraGridColumn282.Header.VisiblePosition = 2;
            ultraGridColumn283.Header.Editor = null;
            ultraGridColumn283.Header.VisiblePosition = 3;
            ultraGridColumn284.Header.Editor = null;
            ultraGridColumn284.Header.VisiblePosition = 4;
            ultraGridColumn285.Header.Editor = null;
            ultraGridColumn285.Header.VisiblePosition = 5;
            ultraGridColumn286.Header.Editor = null;
            ultraGridColumn286.Header.VisiblePosition = 6;
            ultraGridColumn287.Header.Editor = null;
            ultraGridColumn287.Header.VisiblePosition = 7;
            ultraGridColumn288.Header.Editor = null;
            ultraGridColumn288.Header.VisiblePosition = 8;
            ultraGridColumn289.Header.Editor = null;
            ultraGridColumn289.Header.VisiblePosition = 9;
            ultraGridColumn290.Header.Editor = null;
            ultraGridColumn290.Header.VisiblePosition = 10;
            ultraGridColumn291.Header.Editor = null;
            ultraGridColumn291.Header.VisiblePosition = 11;
            ultraGridColumn292.Header.Editor = null;
            ultraGridColumn292.Header.VisiblePosition = 12;
            ultraGridColumn293.Header.Editor = null;
            ultraGridColumn293.Header.VisiblePosition = 13;
            ultraGridBand12.Columns.AddRange(new object[] {
            ultraGridColumn280,
            ultraGridColumn281,
            ultraGridColumn282,
            ultraGridColumn283,
            ultraGridColumn284,
            ultraGridColumn285,
            ultraGridColumn286,
            ultraGridColumn287,
            ultraGridColumn288,
            ultraGridColumn289,
            ultraGridColumn290,
            ultraGridColumn291,
            ultraGridColumn292,
            ultraGridColumn293});
            this.dgCompletadas.DisplayLayout.BandsSerializer.Add(ultraGridBand7);
            this.dgCompletadas.DisplayLayout.BandsSerializer.Add(ultraGridBand8);
            this.dgCompletadas.DisplayLayout.BandsSerializer.Add(ultraGridBand9);
            this.dgCompletadas.DisplayLayout.BandsSerializer.Add(ultraGridBand10);
            this.dgCompletadas.DisplayLayout.BandsSerializer.Add(ultraGridBand11);
            this.dgCompletadas.DisplayLayout.BandsSerializer.Add(ultraGridBand12);
            this.dgCompletadas.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgCompletadas.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance17.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance17.BorderColor = System.Drawing.SystemColors.Window;
            this.dgCompletadas.DisplayLayout.GroupByBox.Appearance = appearance17;
            appearance18.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgCompletadas.DisplayLayout.GroupByBox.BandLabelAppearance = appearance18;
            this.dgCompletadas.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance19.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance19.BackColor2 = System.Drawing.SystemColors.Control;
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance19.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgCompletadas.DisplayLayout.GroupByBox.PromptAppearance = appearance19;
            this.dgCompletadas.DisplayLayout.MaxColScrollRegions = 1;
            this.dgCompletadas.DisplayLayout.MaxRowScrollRegions = 1;
            appearance20.BackColor = System.Drawing.SystemColors.Window;
            appearance20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgCompletadas.DisplayLayout.Override.ActiveCellAppearance = appearance20;
            appearance21.BackColor = System.Drawing.SystemColors.Highlight;
            appearance21.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgCompletadas.DisplayLayout.Override.ActiveRowAppearance = appearance21;
            this.dgCompletadas.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.dgCompletadas.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.dgCompletadas.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance22.BackColor = System.Drawing.SystemColors.Window;
            this.dgCompletadas.DisplayLayout.Override.CardAreaAppearance = appearance22;
            appearance23.BorderColor = System.Drawing.Color.Silver;
            appearance23.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgCompletadas.DisplayLayout.Override.CellAppearance = appearance23;
            this.dgCompletadas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.dgCompletadas.DisplayLayout.Override.CellPadding = 0;
            appearance24.BackColor = System.Drawing.SystemColors.Control;
            appearance24.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance24.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance24.BorderColor = System.Drawing.SystemColors.Window;
            this.dgCompletadas.DisplayLayout.Override.GroupByRowAppearance = appearance24;
            appearance25.TextHAlignAsString = "Left";
            this.dgCompletadas.DisplayLayout.Override.HeaderAppearance = appearance25;
            this.dgCompletadas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgCompletadas.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance26.BackColor = System.Drawing.SystemColors.Window;
            appearance26.BorderColor = System.Drawing.Color.Silver;
            this.dgCompletadas.DisplayLayout.Override.RowAppearance = appearance26;
            this.dgCompletadas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance27.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgCompletadas.DisplayLayout.Override.TemplateAddRowAppearance = appearance27;
            this.dgCompletadas.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgCompletadas.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgCompletadas.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.dgCompletadas.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.dgCompletadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCompletadas.Font = new System.Drawing.Font("Arial", 9.75F);
            this.dgCompletadas.Location = new System.Drawing.Point(2, 21);
            this.dgCompletadas.Name = "dgCompletadas";
            this.dgCompletadas.Size = new System.Drawing.Size(1134, 384);
            this.dgCompletadas.TabIndex = 1;
            this.dgCompletadas.Text = "ultraGrid1";
            this.dgCompletadas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGrid_MouseDown);
            // 
            // cms_dgCompletados
            // 
            this.cms_dgCompletados.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarStatusRecibosToolStripMenuItem,
            this.editarFacturaToolStripMenuItem,
            this.descargarFacturaToolStripMenuItem,
            this.toolStripSeparator1,
            this.regenerarPDFToolStripMenuItem,
            this.cancelarDocumentoToolStripMenuItem,
            this.toolStripSeparator2,
            this.verErroresToolStripMenuItem,
            this.buscarDocumentosRelacionadosToolStripMenuItem,
            this.consultarSaldoPendienteDePagoToolStripMenuItem});
            this.cms_dgCompletados.Name = "cms_dgCompletados";
            this.cms_dgCompletados.Size = new System.Drawing.Size(267, 192);
            this.cms_dgCompletados.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cms_dgCompletados_ItemClicked);
            // 
            // editarStatusRecibosToolStripMenuItem
            // 
            this.editarStatusRecibosToolStripMenuItem.Name = "editarStatusRecibosToolStripMenuItem";
            this.editarStatusRecibosToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.editarStatusRecibosToolStripMenuItem.Text = "Editar Status / Recibos";
            // 
            // editarFacturaToolStripMenuItem
            // 
            this.editarFacturaToolStripMenuItem.Name = "editarFacturaToolStripMenuItem";
            this.editarFacturaToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.editarFacturaToolStripMenuItem.Text = "Editar Factura";
            // 
            // descargarFacturaToolStripMenuItem
            // 
            this.descargarFacturaToolStripMenuItem.Name = "descargarFacturaToolStripMenuItem";
            this.descargarFacturaToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.descargarFacturaToolStripMenuItem.Text = "Descargar documentos de la Factura";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(263, 6);
            // 
            // regenerarPDFToolStripMenuItem
            // 
            this.regenerarPDFToolStripMenuItem.Name = "regenerarPDFToolStripMenuItem";
            this.regenerarPDFToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.regenerarPDFToolStripMenuItem.Text = "Regenerar PDF";
            // 
            // cancelarDocumentoToolStripMenuItem
            // 
            this.cancelarDocumentoToolStripMenuItem.Name = "cancelarDocumentoToolStripMenuItem";
            this.cancelarDocumentoToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.cancelarDocumentoToolStripMenuItem.Text = "Cancelar Documento";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(263, 6);
            // 
            // verErroresToolStripMenuItem
            // 
            this.verErroresToolStripMenuItem.Name = "verErroresToolStripMenuItem";
            this.verErroresToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.verErroresToolStripMenuItem.Text = "Ver Errores de Timbrado";
            // 
            // buscarDocumentosRelacionadosToolStripMenuItem
            // 
            this.buscarDocumentosRelacionadosToolStripMenuItem.Name = "buscarDocumentosRelacionadosToolStripMenuItem";
            this.buscarDocumentosRelacionadosToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.buscarDocumentosRelacionadosToolStripMenuItem.Text = "Buscar Documentos Relacionados";
            // 
            // consultarSaldoPendienteDePagoToolStripMenuItem
            // 
            this.consultarSaldoPendienteDePagoToolStripMenuItem.Name = "consultarSaldoPendienteDePagoToolStripMenuItem";
            this.consultarSaldoPendienteDePagoToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.consultarSaldoPendienteDePagoToolStripMenuItem.Text = "Consultar Saldo Pendiente de Pago";
            // 
            // BasebindingSource
            // 
            this.BasebindingSource.DataMember = "CheckFacturas";
            this.BasebindingSource.DataSource = this.Basefacturacion;
            // 
            // Basefacturacion
            // 
            this.Basefacturacion.DataSetName = "Facturacion";
            this.Basefacturacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ultraTabPageControl4
            // 
            this.ultraTabPageControl4.Controls.Add(this.grpCancelaciones);
            this.ultraTabPageControl4.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl4.Name = "ultraTabPageControl4";
            this.ultraTabPageControl4.Size = new System.Drawing.Size(1198, 599);
            // 
            // grpCancelaciones
            // 
            this.grpCancelaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCancelaciones.Controls.Add(this.dgCancelaciones);
            this.grpCancelaciones.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpCancelaciones.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpCancelaciones.Location = new System.Drawing.Point(23, 25);
            this.grpCancelaciones.Name = "grpCancelaciones";
            this.grpCancelaciones.Size = new System.Drawing.Size(1149, 525);
            this.grpCancelaciones.TabIndex = 1;
            this.grpCancelaciones.Text = "Solicitudes de Cancelaciones (Doble Clic para Procesar)";
            this.grpCancelaciones.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // dgCancelaciones
            // 
            this.dgCancelaciones.ContextMenuStrip = this.cms_dgCancelaciones;
            this.dgCancelaciones.DataSource = this.solicitudCancelacionesBindingSource;
            appearance28.BackColor = System.Drawing.SystemColors.Window;
            appearance28.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgCancelaciones.DisplayLayout.Appearance = appearance28;
            ultraGridColumn294.Header.Editor = null;
            ultraGridColumn294.Header.VisiblePosition = 7;
            ultraGridColumn294.Hidden = true;
            ultraGridColumn295.Header.Editor = null;
            ultraGridColumn295.Header.VisiblePosition = 8;
            ultraGridColumn295.Hidden = true;
            ultraGridColumn296.Header.Editor = null;
            ultraGridColumn296.Header.VisiblePosition = 4;
            ultraGridColumn297.Header.Editor = null;
            ultraGridColumn297.Header.VisiblePosition = 9;
            ultraGridColumn297.Hidden = true;
            ultraGridColumn298.Header.Editor = null;
            ultraGridColumn298.Header.VisiblePosition = 10;
            ultraGridColumn299.Header.Editor = null;
            ultraGridColumn299.Header.VisiblePosition = 11;
            ultraGridColumn300.Header.Editor = null;
            ultraGridColumn300.Header.VisiblePosition = 12;
            ultraGridColumn301.Header.Editor = null;
            ultraGridColumn301.Header.VisiblePosition = 13;
            ultraGridColumn302.Header.Editor = null;
            ultraGridColumn302.Header.VisiblePosition = 1;
            ultraGridColumn303.Header.Editor = null;
            ultraGridColumn303.Header.VisiblePosition = 2;
            ultraGridColumn304.Header.Editor = null;
            ultraGridColumn304.Header.VisiblePosition = 0;
            ultraGridColumn305.Header.Editor = null;
            ultraGridColumn305.Header.VisiblePosition = 3;
            ultraGridColumn306.Header.Editor = null;
            ultraGridColumn306.Header.VisiblePosition = 6;
            ultraGridColumn307.Header.Editor = null;
            ultraGridColumn307.Header.VisiblePosition = 5;
            ultraGridBand13.Columns.AddRange(new object[] {
            ultraGridColumn294,
            ultraGridColumn295,
            ultraGridColumn296,
            ultraGridColumn297,
            ultraGridColumn298,
            ultraGridColumn299,
            ultraGridColumn300,
            ultraGridColumn301,
            ultraGridColumn302,
            ultraGridColumn303,
            ultraGridColumn304,
            ultraGridColumn305,
            ultraGridColumn306,
            ultraGridColumn307});
            this.dgCancelaciones.DisplayLayout.BandsSerializer.Add(ultraGridBand13);
            this.dgCancelaciones.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgCancelaciones.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance29.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance29.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance29.BorderColor = System.Drawing.SystemColors.Window;
            this.dgCancelaciones.DisplayLayout.GroupByBox.Appearance = appearance29;
            appearance30.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgCancelaciones.DisplayLayout.GroupByBox.BandLabelAppearance = appearance30;
            this.dgCancelaciones.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance31.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance31.BackColor2 = System.Drawing.SystemColors.Control;
            appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance31.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgCancelaciones.DisplayLayout.GroupByBox.PromptAppearance = appearance31;
            this.dgCancelaciones.DisplayLayout.MaxColScrollRegions = 1;
            this.dgCancelaciones.DisplayLayout.MaxRowScrollRegions = 1;
            appearance32.BackColor = System.Drawing.SystemColors.Window;
            appearance32.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgCancelaciones.DisplayLayout.Override.ActiveCellAppearance = appearance32;
            appearance33.BackColor = System.Drawing.SystemColors.Highlight;
            appearance33.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgCancelaciones.DisplayLayout.Override.ActiveRowAppearance = appearance33;
            this.dgCancelaciones.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.dgCancelaciones.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance34.BackColor = System.Drawing.SystemColors.Window;
            this.dgCancelaciones.DisplayLayout.Override.CardAreaAppearance = appearance34;
            appearance35.BorderColor = System.Drawing.Color.Silver;
            appearance35.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgCancelaciones.DisplayLayout.Override.CellAppearance = appearance35;
            this.dgCancelaciones.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.dgCancelaciones.DisplayLayout.Override.CellPadding = 0;
            appearance36.BackColor = System.Drawing.SystemColors.Control;
            appearance36.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance36.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance36.BorderColor = System.Drawing.SystemColors.Window;
            this.dgCancelaciones.DisplayLayout.Override.GroupByRowAppearance = appearance36;
            appearance37.TextHAlignAsString = "Left";
            this.dgCancelaciones.DisplayLayout.Override.HeaderAppearance = appearance37;
            this.dgCancelaciones.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgCancelaciones.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance38.BackColor = System.Drawing.SystemColors.Window;
            appearance38.BorderColor = System.Drawing.Color.Silver;
            this.dgCancelaciones.DisplayLayout.Override.RowAppearance = appearance38;
            appearance39.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgCancelaciones.DisplayLayout.Override.TemplateAddRowAppearance = appearance39;
            this.dgCancelaciones.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgCancelaciones.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgCancelaciones.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.dgCancelaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCancelaciones.Font = new System.Drawing.Font("Arial", 9.75F);
            this.dgCancelaciones.Location = new System.Drawing.Point(2, 21);
            this.dgCancelaciones.Name = "dgCancelaciones";
            this.dgCancelaciones.Size = new System.Drawing.Size(1145, 502);
            this.dgCancelaciones.TabIndex = 0;
            this.dgCancelaciones.Text = "ultraGrid1";
            this.dgCancelaciones.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.dgCancelaciones_DoubleClickRow);
            this.dgCancelaciones.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGrid_MouseDown);
            // 
            // cms_dgCancelaciones
            // 
            this.cms_dgCancelaciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelarDocumentoToolStripMenuItem1});
            this.cms_dgCancelaciones.Name = "cms_dgCompletados";
            this.cms_dgCancelaciones.Size = new System.Drawing.Size(187, 26);
            this.cms_dgCancelaciones.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cms_dgCancelaciones_ItemClicked);
            // 
            // cancelarDocumentoToolStripMenuItem1
            // 
            this.cancelarDocumentoToolStripMenuItem1.Name = "cancelarDocumentoToolStripMenuItem1";
            this.cancelarDocumentoToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.cancelarDocumentoToolStripMenuItem1.Text = "Cancelar Documento";
            // 
            // solicitudCancelacionesBindingSource
            // 
            this.solicitudCancelacionesBindingSource.DataMember = "SolicitudCancelaciones";
            this.solicitudCancelacionesBindingSource.DataSource = this.facturacion;
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(1198, 599);
            // 
            // AdministracionFacturas_Fill_Panel
            // 
            // 
            // AdministracionFacturas_Fill_Panel.ClientArea
            // 
            this.AdministracionFacturas_Fill_Panel.ClientArea.Controls.Add(this.AdminFactTabControl);
            this.AdministracionFacturas_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.AdministracionFacturas_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdministracionFacturas_Fill_Panel.Location = new System.Drawing.Point(1, 151);
            this.AdministracionFacturas_Fill_Panel.Name = "AdministracionFacturas_Fill_Panel";
            this.AdministracionFacturas_Fill_Panel.Size = new System.Drawing.Size(1315, 601);
            this.AdministracionFacturas_Fill_Panel.TabIndex = 8;
            // 
            // AdminFactTabControl
            // 
            this.AdminFactTabControl.Controls.Add(this.ultraTabSharedControlsPage1);
            this.AdminFactTabControl.Controls.Add(this.ultraTabPageControl1);
            this.AdminFactTabControl.Controls.Add(this.ultraTabPageControl2);
            this.AdminFactTabControl.Controls.Add(this.ultraTabPageControl4);
            this.AdminFactTabControl.Controls.Add(this.ultraTabPageControl3);
            this.AdminFactTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdminFactTabControl.Location = new System.Drawing.Point(0, 0);
            this.AdminFactTabControl.Name = "AdminFactTabControl";
            this.AdminFactTabControl.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.AdminFactTabControl.Size = new System.Drawing.Size(1315, 601);
            this.AdminFactTabControl.TabIndex = 2;
            this.AdminFactTabControl.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.LeftTop;
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "Solicitudes";
            ultraTab4.TabPage = this.ultraTabPageControl2;
            ultraTab4.Text = "Base de Facturación";
            ultraTab2.TabPage = this.ultraTabPageControl4;
            ultraTab2.Text = "Cancelaciones";
            ultraTab3.TabPage = this.ultraTabPageControl3;
            ultraTab3.Text = "Cobranza Universal";
            ultraTab3.Visible = false;
            this.AdminFactTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab4,
            ultraTab2,
            ultraTab3});
            this.AdminFactTabControl.TextOrientation = Infragistics.Win.UltraWinTabs.TextOrientation.Horizontal;
            this.AdminFactTabControl.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007;
            this.AdminFactTabControl.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.TabMisFacturas_SelectedTabChanged);
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(1198, 599);
            // 
            // _LiabilityInc_Toolbars_Dock_Area_Right
            // 
            this._LiabilityInc_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._LiabilityInc_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._LiabilityInc_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._LiabilityInc_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._LiabilityInc_Toolbars_Dock_Area_Right.InitialResizeAreaExtent = 1;
            this._LiabilityInc_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1316, 151);
            this._LiabilityInc_Toolbars_Dock_Area_Right.Name = "_LiabilityInc_Toolbars_Dock_Area_Right";
            this._LiabilityInc_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(1, 601);
            this._LiabilityInc_Toolbars_Dock_Area_Right.ToolbarsManager = this.AdministracionFacToolBar;
            // 
            // AdministracionFacToolBar
            // 
            appearance40.BackColor = System.Drawing.Color.White;
            this.AdministracionFacToolBar.Appearance = appearance40;
            this.AdministracionFacToolBar.DesignerFlags = 1;
            this.AdministracionFacToolBar.DockWithinContainer = this;
            this.AdministracionFacToolBar.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            ribbonTab1.Caption = "Administracion Facturas";
            ribbonGroup4.Caption = "Solicitudes de Facturacion";
            popupMenuTool1.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            buttonTool23.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            buttonTool24.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            buttonTool25.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            buttonTool26.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            ribbonGroup4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            buttonTool23,
            buttonTool24,
            buttonTool25,
            buttonTool26});
            ribbonGroup7.Caption = "Base de Facturacion";
            buttonTool2.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            buttonTool6.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            buttonTool29.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            buttonTool27.InstanceProps.MinimumSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            buttonTool28.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            buttonTool10.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            buttonTool4.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            buttonTool12.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            buttonTool8.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            ribbonGroup7.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool2,
            buttonTool6,
            buttonTool29,
            buttonTool27,
            buttonTool28,
            buttonTool10,
            buttonTool4,
            buttonTool12,
            buttonTool8});
            ribbonGroup8.Caption = "Cancelaciones";
            buttonTool19.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            buttonTool1.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            ribbonGroup8.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool19,
            buttonTool1});
            ribbonGroup5.Caption = "Cobranza Universal";
            ribbonGroup6.Caption = "Actualizar";
            buttonTool21.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            ribbonGroup6.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool21});
            ribbonTab1.Groups.AddRange(new Infragistics.Win.UltraWinToolbars.RibbonGroup[] {
            ribbonGroup4,
            ribbonGroup7,
            ribbonGroup8,
            ribbonGroup5,
            ribbonGroup6});
            appearance41.BackColor = System.Drawing.Color.WhiteSmoke;
            ribbonTab1.Settings.Appearance = appearance41;
            this.AdministracionFacToolBar.Ribbon.NonInheritedRibbonTabs.AddRange(new Infragistics.Win.UltraWinToolbars.RibbonTab[] {
            ribbonTab1});
            this.AdministracionFacToolBar.Ribbon.Visible = true;
            this.AdministracionFacToolBar.ShowFullMenusDelay = 500;
            this.AdministracionFacToolBar.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2013;
            appearance42.Image = global::SmartG.Properties.Resources.cancel;
            buttonTool13.SharedPropsInternal.AppearancesLarge.Appearance = appearance42;
            buttonTool13.SharedPropsInternal.Caption = "Rechazar Solicitud";
            appearance43.Image = global::SmartG.Properties.Resources.edit;
            buttonTool30.SharedPropsInternal.AppearancesLarge.Appearance = appearance43;
            buttonTool30.SharedPropsInternal.Caption = "Editar Solicitud";
            appearance44.Image = global::SmartG.Properties.Resources.reload;
            buttonTool31.SharedPropsInternal.AppearancesLarge.Appearance = appearance44;
            buttonTool31.SharedPropsInternal.Caption = "Actualizar";
            appearance45.Image = global::SmartG.Properties.Resources.renovacionInc;
            buttonTool32.SharedPropsInternal.AppearancesLarge.Appearance = appearance45;
            buttonTool32.SharedPropsInternal.Caption = "Procesar Seleccionadas";
            appearance46.Image = global::SmartG.Properties.Resources.copy;
            buttonTool14.SharedPropsInternal.AppearancesLarge.Appearance = appearance46;
            buttonTool14.SharedPropsInternal.Caption = "Copia Registro";
            appearance47.Image = global::SmartG.Properties.Resources.refresh;
            buttonTool15.SharedPropsInternal.AppearancesLarge.Appearance = appearance47;
            buttonTool15.SharedPropsInternal.Caption = "Reprocesar Timbrado";
            appearance48.Image = global::SmartG.Properties.Resources.document;
            buttonTool16.SharedPropsInternal.AppearancesLarge.Appearance = appearance48;
            buttonTool16.SharedPropsInternal.Caption = "Generar Recibos";
            appearance49.Image = global::SmartG.Properties.Resources.edit;
            buttonTool17.SharedPropsInternal.AppearancesLarge.Appearance = appearance49;
            buttonTool17.SharedPropsInternal.Caption = "Editar Status del Registro ";
            appearance50.Image = global::SmartG.Properties.Resources.error2;
            buttonTool18.SharedPropsInternal.AppearancesLarge.Appearance = appearance50;
            buttonTool18.SharedPropsInternal.Caption = "Ver Errores";
            appearance51.Image = global::SmartG.Properties.Resources.renovacionProd;
            buttonTool20.SharedPropsInternal.AppearancesLarge.Appearance = appearance51;
            buttonTool20.SharedPropsInternal.Caption = "Procesar Cancelacion";
            appearance52.Image = global::SmartG.Properties.Resources.analytics;
            buttonTool22.SharedPropsInternal.AppearancesLarge.Appearance = appearance52;
            buttonTool22.SharedPropsInternal.Caption = "Generar Reporte";
            appearance53.Image = global::SmartG.Properties.Resources.edit2;
            buttonTool3.SharedPropsInternal.AppearancesLarge.Appearance = appearance53;
            buttonTool3.SharedPropsInternal.Caption = "Editar datos de la factura";
            appearance54.Image = global::SmartG.Properties.Resources.document1;
            buttonTool5.SharedPropsInternal.AppearancesLarge.Appearance = appearance54;
            buttonTool5.SharedPropsInternal.Caption = "Regenerar PDF";
            appearance55.Image = global::SmartG.Properties.Resources.obtener;
            buttonTool7.SharedPropsInternal.AppearancesLarge.Appearance = appearance55;
            buttonTool7.SharedPropsInternal.Caption = "Descargar Factura";
            appearance56.Image = global::SmartG.Properties.Resources.analytics;
            buttonTool9.SharedPropsInternal.AppearancesLarge.Appearance = appearance56;
            buttonTool9.SharedPropsInternal.Caption = "Reporte Saldos Insolutos";
            appearance57.Image = global::SmartG.Properties.Resources.clipboard;
            popupMenuTool2.SharedPropsInternal.AppearancesLarge.Appearance = appearance57;
            popupMenuTool2.SharedPropsInternal.Caption = "NuevaFactura";
            popupMenuTool2.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool11,
            buttonTool34});
            buttonTool33.SharedPropsInternal.Caption = "Nueva Factura";
            buttonTool35.SharedPropsInternal.Caption = "Nuevo Comprobante de Retenciones";
            this.AdministracionFacToolBar.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool13,
            buttonTool30,
            buttonTool31,
            buttonTool32,
            buttonTool14,
            buttonTool15,
            buttonTool16,
            buttonTool17,
            buttonTool18,
            buttonTool20,
            buttonTool22,
            buttonTool3,
            buttonTool5,
            buttonTool7,
            buttonTool9,
            popupMenuTool2,
            buttonTool33,
            buttonTool35});
            this.AdministracionFacToolBar.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ToolsBarAdminFacturas_ToolClick);
            // 
            // _LiabilityInc_Toolbars_Dock_Area_Left
            // 
            this._LiabilityInc_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._LiabilityInc_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._LiabilityInc_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._LiabilityInc_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._LiabilityInc_Toolbars_Dock_Area_Left.InitialResizeAreaExtent = 1;
            this._LiabilityInc_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 151);
            this._LiabilityInc_Toolbars_Dock_Area_Left.Name = "_LiabilityInc_Toolbars_Dock_Area_Left";
            this._LiabilityInc_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(1, 601);
            this._LiabilityInc_Toolbars_Dock_Area_Left.ToolbarsManager = this.AdministracionFacToolBar;
            // 
            // _LiabilityInc_Toolbars_Dock_Area_Bottom
            // 
            this._LiabilityInc_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._LiabilityInc_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._LiabilityInc_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._LiabilityInc_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._LiabilityInc_Toolbars_Dock_Area_Bottom.InitialResizeAreaExtent = 1;
            this._LiabilityInc_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 752);
            this._LiabilityInc_Toolbars_Dock_Area_Bottom.Name = "_LiabilityInc_Toolbars_Dock_Area_Bottom";
            this._LiabilityInc_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1317, 1);
            this._LiabilityInc_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.AdministracionFacToolBar;
            // 
            // _LiabilityInc_Toolbars_Dock_Area_Top
            // 
            this._LiabilityInc_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._LiabilityInc_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._LiabilityInc_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._LiabilityInc_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._LiabilityInc_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._LiabilityInc_Toolbars_Dock_Area_Top.Name = "_LiabilityInc_Toolbars_Dock_Area_Top";
            this._LiabilityInc_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1317, 151);
            this._LiabilityInc_Toolbars_Dock_Area_Top.ToolbarsManager = this.AdministracionFacToolBar;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xlsx";
            this.saveFileDialog1.Filter = "Excel Workbook|*.xlsx";
            // 
            // checkFacturasTableAdapter
            // 
            this.checkFacturasTableAdapter.ClearBeforeFill = true;
            // 
            // solicitudCancelacionesTableAdapter
            // 
            this.solicitudCancelacionesTableAdapter.ClearBeforeFill = true;
            // 
            // AdministracionFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1317, 753);
            this.Controls.Add(this.AdministracionFacturas_Fill_Panel);
            this.Controls.Add(this._LiabilityInc_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._LiabilityInc_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._LiabilityInc_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._LiabilityInc_Toolbars_Dock_Area_Top);
            this.Name = "AdministracionFacturas";
            this.Text = "AdministracionFacturas";
            this.Load += new System.EventHandler(this.AdministracionFacturas_Load);
            this.ultraTabPageControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpPendientes)).EndInit();
            this.grpPendientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPendientes)).EndInit();
            this.cms_dgSolicitudes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkFacturasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturacion)).EndInit();
            this.ultraTabPageControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpBusqueda)).EndInit();
            this.grpBusqueda.ResumeLayout(false);
            this.grpBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbParametro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBusqueda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBusqueda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCompletadas)).EndInit();
            this.grpCompletadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCompletadas)).EndInit();
            this.cms_dgCompletados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BasebindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Basefacturacion)).EndInit();
            this.ultraTabPageControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpCancelaciones)).EndInit();
            this.grpCancelaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCancelaciones)).EndInit();
            this.cms_dgCancelaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.solicitudCancelacionesBindingSource)).EndInit();
            this.AdministracionFacturas_Fill_Panel.ClientArea.ResumeLayout(false);
            this.AdministracionFacturas_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AdminFactTabControl)).EndInit();
            this.AdminFactTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AdministracionFacToolBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Infragistics.Win.Misc.UltraPanel AdministracionFacturas_Fill_Panel;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl AdminFactTabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.Misc.UltraGroupBox grpPendientes;
        private Infragistics.Win.UltraWinGrid.UltraGrid dgPendientes;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private Infragistics.Win.Misc.UltraGroupBox grpBusqueda;
        private Infragistics.Win.Misc.UltraGroupBox grpCompletadas;
        private Infragistics.Win.UltraWinGrid.UltraGrid dgCompletadas;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl4;
        private System.Windows.Forms.BindingSource checkFacturasBindingSource;
        private Datasets.CreditControl.FacturacionTableAdapters.CheckFacturasTableAdapter checkFacturasTableAdapter;
        private Datasets.CreditControl.Facturacion facturacion;
        private System.Windows.Forms.BindingSource BasebindingSource;
        private Datasets.CreditControl.Facturacion Basefacturacion;
        private Infragistics.Win.Misc.UltraLabel lbParametro;
        private Infragistics.Win.Misc.UltraLabel lbBuscar;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dateBusqueda;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtBusqueda;
        private Infragistics.Win.Misc.UltraButton btnBuscar;
        private Infragistics.Win.Misc.UltraGroupBox grpCancelaciones;
        private Infragistics.Win.UltraWinGrid.UltraGrid dgCancelaciones;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        private System.Windows.Forms.BindingSource solicitudCancelacionesBindingSource;
        private Datasets.CreditControl.FacturacionTableAdapters.SolicitudCancelacionesTableAdapter solicitudCancelacionesTableAdapter;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager AdministracionFacToolBar;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _LiabilityInc_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _LiabilityInc_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _LiabilityInc_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _LiabilityInc_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbParametro;
        private Infragistics.Win.Misc.UltraButton btnExcelReporteJournal;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
        private System.Windows.Forms.ContextMenuStrip cms_dgCompletados;
        private System.Windows.Forms.ToolStripMenuItem descargarFacturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verErroresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regenerarPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarDocumentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarDocumentosRelacionadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip cms_dgCancelaciones;
        private System.Windows.Forms.ToolStripMenuItem cancelarDocumentoToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip cms_dgSolicitudes;
        private System.Windows.Forms.ToolStripMenuItem timbrarDocumentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rechazarSolicitudToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarSolicitudToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarStatusRecibosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarFacturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarSaldoPendienteDePagoToolStripMenuItem;
    }
}