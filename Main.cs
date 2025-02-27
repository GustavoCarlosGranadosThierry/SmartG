using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Reflection;

namespace SmartG
{
    public partial class Main : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region variables
        public static int guardado;
        public static string lineaNegocios;
        string idiomaSel;
        public static bool cerrarDirecto = false;
        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region Metodos programados

        void guardarEmision(int avance)
        {
            switch (avance)
            {
                case 25:
                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Liability Incoming").Count() > 0)
                    {
                        Operaciones.Emision.LiabilityInc frmLiaInc = new Operaciones.Emision.LiabilityInc();
                        frmLiaInc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Liability Incoming").First() as Operaciones.Emision.LiabilityInc;
                        frmLiaInc.guardarAvances();
                    }
                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Liability Producing").Count() > 0)
                    {
                        Operaciones.Emision.LiabilityProd frmLiaInc = new Operaciones.Emision.LiabilityProd();
                        frmLiaInc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Liability Producing").First() as Operaciones.Emision.LiabilityProd;
                        frmLiaInc.guardarAvances();
                    }
                    break;

                case 50:
                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Financial Lines Incoming").Count() > 0)
                    {
                        Operaciones.Emision.FinancialLinesInc frmFLinc = new Operaciones.Emision.FinancialLinesInc();
                        frmFLinc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Financial Lines Incoming").First() as Operaciones.Emision.FinancialLinesInc;
                        frmFLinc.guardarAvances();
                    }
                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Financial Lines Producing").Count() > 0)
                    {
                        Operaciones.Emision.FinancialLinesProd frmFLinc = new Operaciones.Emision.FinancialLinesProd();
                        frmFLinc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Financial Lines Producing").First() as Operaciones.Emision.FinancialLinesProd;
                        frmFLinc.guardarAvances();
                    }
                    break;

                case 75:
                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Marine Incoming").Count() > 0)
                    {
                        Operaciones.Emision.MarineInc frmMarInc = new Operaciones.Emision.MarineInc();
                        frmMarInc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Marine Incoming").First() as Operaciones.Emision.MarineInc;
                        frmMarInc.guardarAvances();
                    }
                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Marine Producing").Count() > 0)
                    {
                        Operaciones.Emision.MarineProd frmMarProd = new Operaciones.Emision.MarineProd();
                        frmMarProd = this.MdiChildren.Where(p => p.Text == "Emision Poliza Marine Producing").First() as Operaciones.Emision.MarineProd;
                        frmMarProd.guardarAvances();
                    }
                    break;

                case 100:
                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Property Incoming").Count() > 0)
                    {
                        Operaciones.Emision.PropertyInc frmPropInc = new Operaciones.Emision.PropertyInc();
                        frmPropInc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Property Incoming").First() as Operaciones.Emision.PropertyInc;
                        frmPropInc.guardarAvances();
                    }
                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Property Producing").Count() > 0)
                    {
                        Operaciones.Emision.PropertyProd frmPropInc = new Operaciones.Emision.PropertyProd();
                        frmPropInc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Property Producing").First() as Operaciones.Emision.PropertyProd;
                        frmPropInc.guardarAvances();
                    }
                    break;
            }
        }

        void IdiomaSeleccionado()
        {
            lbIdiomaSeleccionado.Text = Properties.Settings.Default.idiomaSeleccionado.ToString();
            idiomaSel = Properties.Settings.Default.idiomaSeleccionado.ToString();
            cbIdiomas.Value = idiomaSel;
        }

        void SelectColorScheme()
        {
            cbStyles.Text = Properties.Settings.Default.ColorScheme;

            if (Properties.Settings.Default.ColorScheme == "White")
                ToolbarsMain.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2013;

            if (Properties.Settings.Default.ColorScheme == "Blue")
                ToolbarsMain.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2010;

        }

        void NombreVentanaPrincipal()
        {
            string BDConexion = "Produccion";
            dbSmartGDataContext db = new dbSmartGDataContext();
            if (Properties.Settings.Default.XLCatlinConnectionString.Contains("CopyLive")) BDConexion = "Pruebas";
            ToolbarsMain.Ribbon.Caption = this.Text + " - " + (from x in db.EmpresaDetalles where x.Principal == true select x.Nombre).SingleOrDefault() + "  (" + BDConexion + ")";            
        }
        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region eventos del form

        private void BackgroundWorkerGuardar_DoWork(object sender, DoWorkEventArgs e)
        {
            BeginInvoke(new Action(() => {
                desbloquearSistema frmDesbloquear = new desbloquearSistema();
                frmDesbloquear.ShowDialog();
                timerMain.Start();
            }));
        }

        private void BackgroundWorkerGuardar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        public Main()
        {
            InitializeComponent();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!cerrarDirecto)
            {
                if (MessageBox.Show("Se cerraran todas las ventanas del sistema actual, continuar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    try { Extensiones.ChangeLog.LogOut(); } catch { }
                }

            }
            else
                e.Cancel = false;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            NombreVentanaPrincipal();
            Extensiones.PerfilesUsuario.AplicarAccesosXperfil(ToolbarsMain);
            //Extensiones.Traduccion.traducirVentana(this, null, ToolbarsMain);
            IdiomaSeleccionado();
            SelectColorScheme();
            txtBloqueoSmartG.Value = Properties.Settings.Default.TiempoEsperaBloqueo;

            ToolbarsMain.Tools["PopupUsuario"].SharedProps.Caption = Program.Globals.NombreCompletoUsuario + " (" + Program.Globals.TipoUsuario + ")";
            backgroundWorkerGuardar.DoWork += BackgroundWorkerGuardar_DoWork;
            backgroundWorkerGuardar.ProgressChanged += BackgroundWorkerGuardar_ProgressChanged;
            backgroundWorkerGuardar.WorkerReportsProgress = true;

            timerMain.Start();
            timerSolicitudDocumentos.Start();
            timerUpdate.Start();
        }

        private void ToolbarsMain_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                #region Menu Principal
                // Funciones del Menu Principal ********************************************************************************************************************************
                case "btnEditarIdioma":
                    Catalogos.IdiomaSeleccion frmSelectorIdioma = new Catalogos.IdiomaSeleccion();
                    frmSelectorIdioma.ShowDialog();
                    if (frmSelectorIdioma.DialogResult == DialogResult.Yes)
                        Extensiones.Traduccion.traducirVentana(this, null, ToolbarsMain);
                    break;


                case "btnReportarError":
                    ErrorHandler frmErrorH = new ErrorHandler("", "");
                    frmErrorH.ShowDialog();
                    break;

                case "PopupEditarUsuario":
                case "PopupEditarPerfil":
                    UsuarioLabel();
                    break;

                case "btnAcerca":
                    AboutBox frmAbout = new AboutBox();
                    frmAbout.ShowDialog();
                    break;

                case "PopupConexion":
                    Extensiones.Edicion.VerificarRutaBD();
                    break;                    

                case "PopupMenuSalir":
                    this.Close();
                    break;

                case "PopupConsultarMisTickets":
                    Operaciones.TicketsSoporte.ConsultaUsuarios frmConsultaTickets = new Operaciones.TicketsSoporte.ConsultaUsuarios();
                    frmConsultaTickets.ShowDialog();
                    break;

                #endregion

                #region Emisión
                // Funciones del Menu Emision ********************************************************************************************************************************
                case "btnNuevaPolizaInc":                    // Nueva póliza incoming
                    Operaciones.Emision.SelectorLN frmSelectorInc = new Operaciones.Emision.SelectorLN();
                    Operaciones.Emision.SelectorLN.origen = "Incoming";
                    Operaciones.Emision.SelectorLN.tipoNegocio = "Nueva Póliza";
                    if (frmSelectorInc.ShowDialog() == DialogResult.OK)
                    {
                        switch (lineaNegocios)
                        {
                            case "Liability":
                                Operaciones.Emision.LiabilityInc frmLiaInc = new Operaciones.Emision.LiabilityInc();
                                if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Liability Incoming").Count() > 0)
                                {
                                    frmLiaInc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Liability Incoming").First() as Operaciones.Emision.LiabilityInc;
                                    frmLiaInc.Select();
                                    ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                    ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                }
                                else
                                {
                                    frmLiaInc.MdiParent = this;
                                    frmLiaInc.Show();
                                    ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                    ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                }
                                break;

                            case "Marine":
                                Operaciones.Emision.MarineInc frmMarInc = new Operaciones.Emision.MarineInc();
                                if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Marine Incoming").Count() > 0)
                                {
                                    frmMarInc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Marine Incoming").First() as Operaciones.Emision.MarineInc;
                                    frmMarInc.Select();
                                    ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                    ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                }
                                else
                                {
                                    frmMarInc.MdiParent = this;
                                    frmMarInc.Show();
                                    ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                    ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                }
                                break;

                            case "Property":
                                Operaciones.Emision.PropertyInc frmPropInc = new Operaciones.Emision.PropertyInc();
                                if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Property Incoming").Count() > 0)
                                {
                                    frmPropInc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Property Incoming").First() as Operaciones.Emision.PropertyInc;
                                    frmPropInc.Select();
                                    ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                    ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                }
                                else
                                {
                                    frmPropInc.MdiParent = this;
                                    frmPropInc.Show();
                                    ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                    ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                }
                                break;

                            case "Financial Lines":
                                Operaciones.Emision.FinancialLinesInc frmFLinc = new Operaciones.Emision.FinancialLinesInc();
                                if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Financial Lines Incoming").Count() > 0)
                                {
                                    frmFLinc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Financial Lines Incoming").First() as Operaciones.Emision.FinancialLinesInc;
                                    frmFLinc.Select();
                                    ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                    ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                }
                                else
                                {
                                    frmFLinc.MdiParent = this;
                                    frmFLinc.Show();
                                    ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                    ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                }
                                break;

                            case "Construction":
                                Operaciones.Emision.Construction frmCAinc = new Operaciones.Emision.Construction(1);
                                if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Construction Incoming").Count() > 0)
                                {
                                    frmCAinc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Construction").First() as Operaciones.Emision.Construction;
                                    frmCAinc.Select();
                                    ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                    ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                }
                                else
                                {
                                    frmCAinc.MdiParent = this;
                                    frmCAinc.Show();
                                    ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                    ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                }
                                break;
                        }
                    }
                    break;

                case "btnNuevaPolizaProd":            // Nueva póliza Producing
                    Operaciones.Emision.SelectorLN frmSelectorProd = new Operaciones.Emision.SelectorLN();
                    Operaciones.Emision.SelectorLN.origen = "Producing";
                    Operaciones.Emision.SelectorLN.tipoNegocio = "Nueva Póliza";
                    if (frmSelectorProd.ShowDialog() == DialogResult.OK)
                    {
                        switch (lineaNegocios)
                        {
                            case "Liability":
                                Operaciones.Emision.LiabilityProd frmLiaInc = new Operaciones.Emision.LiabilityProd();
                                if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Liability Producing").Count() > 0)
                                {
                                    frmLiaInc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Construction").First() as Operaciones.Emision.LiabilityProd;
                                    frmLiaInc.Select();
                                    ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                    ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                }
                                else
                                {
                                    frmLiaInc.MdiParent = this;
                                    frmLiaInc.Show();
                                    ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                    ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                }
                                break;

                            case "Marine":
                                Operaciones.Emision.MarineProd frmMarProd = new Operaciones.Emision.MarineProd();
                                if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Marine Producing").Count() > 0)
                                {
                                    frmMarProd = this.MdiChildren.Where(p => p.Text == "Emision Poliza Marine Producing").First() as Operaciones.Emision.MarineProd;
                                    frmMarProd.Select();
                                    ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                    ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                }
                                else
                                {
                                    frmMarProd.MdiParent = this;
                                    frmMarProd.Show();
                                    ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                    ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                }
                                break;

                            case "Property":
                                Operaciones.Emision.PropertyProd frmPropInc = new Operaciones.Emision.PropertyProd();
                                if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Property Producing").Count() > 0)
                                {
                                    frmPropInc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Property Producing").First() as Operaciones.Emision.PropertyProd;
                                    frmPropInc.Select();
                                    ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                    ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                }
                                else
                                {
                                    frmPropInc.MdiParent = this;
                                    frmPropInc.Show();
                                    ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                    ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                }
                                break;

                            case "Financial Lines":
                                Operaciones.Emision.FinancialLinesProd frmFLinc = new Operaciones.Emision.FinancialLinesProd();
                                if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Financial Lines Producing").Count() > 0)
                                {
                                    frmFLinc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Financial Lines Producing").First() as Operaciones.Emision.FinancialLinesProd;
                                    frmFLinc.Select();
                                    ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                    ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                }
                                else
                                {
                                    frmFLinc.MdiParent = this;
                                    frmFLinc.Show();
                                    ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                    ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                }
                                break;

                            case "Construction":
                                Operaciones.Emision.Construction frmCAinc = new Operaciones.Emision.Construction(2);
                                if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Construction").Count() > 0)
                                {
                                    frmCAinc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Construction").First() as Operaciones.Emision.Construction;
                                    frmCAinc.Select();
                                    ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                    ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                }
                                else
                                {
                                    frmCAinc.MdiParent = this;
                                    frmCAinc.Show();
                                    ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                    ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                }
                                break;
                        }
                    }
                    break;

                case "btnCargarPoliInc":                    // Continuar Registros guardados sin concluir
                    Operaciones.Emision.BusquedaPolizas frmBusquedaI = new Operaciones.Emision.BusquedaPolizas(2);
                    if (frmBusquedaI.ShowDialog() == DialogResult.OK)
                    {
                        dbSmartGDataContext db = new dbSmartGDataContext();
                        switch (lineaNegocios)
                        {
                            case "Liability":
                                int? tmpOrigenLi = (from x in db.PolizaLiability where x.Poliza == guardado select x.Origen).SingleOrDefault();
                                if (tmpOrigenLi == 1)
                                {
                                    Operaciones.Emision.LiabilityInc frmLiaInc = new Operaciones.Emision.LiabilityInc(1, guardado);
                                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Liability Incoming").Count() > 0)
                                    {
                                        frmLiaInc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Liability Incoming").First() as Operaciones.Emision.LiabilityInc;
                                        frmLiaInc.Select();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                        frmLiaInc.idPoliza = guardado;
                                        frmLiaInc.cargarPolizaMain();
                                    }
                                    else
                                    {
                                        frmLiaInc.MdiParent = this;
                                        frmLiaInc.Show();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                }
                                else
                                {
                                    Operaciones.Emision.LiabilityProd frmLiaInc = new Operaciones.Emision.LiabilityProd(1, guardado);
                                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Liability Producing").Count() > 0)
                                    {
                                        frmLiaInc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Liability Producing").First() as Operaciones.Emision.LiabilityProd;
                                        frmLiaInc.Select();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                        frmLiaInc.idPoliza = guardado;
                                        frmLiaInc.cargarPolizaMain();
                                    }
                                    else
                                    {
                                        frmLiaInc.MdiParent = this;
                                        frmLiaInc.Show();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                }
                                break;

                            case "Marine":
                                int? tmpOrigenMa = (from x in db.PolizaMarine where x.Poliza == guardado select x.Origen).SingleOrDefault();
                                if (tmpOrigenMa == 1)
                                {
                                    Operaciones.Emision.MarineInc frmMarInc = new Operaciones.Emision.MarineInc(1, guardado);
                                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Marine Incoming").Count() > 0)
                                    {
                                        frmMarInc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Marine Incoming").First() as Operaciones.Emision.MarineInc;
                                        frmMarInc.Select();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                        frmMarInc.idPoliza = guardado;
                                        frmMarInc.cargarPolizaMain();
                                    }
                                    else
                                    {
                                        frmMarInc.MdiParent = this;
                                        frmMarInc.Show();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                }
                                else
                                {
                                    Operaciones.Emision.MarineProd frmMarProd = new Operaciones.Emision.MarineProd(1, guardado);
                                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Marine Producing").Count() > 0)
                                    {
                                        frmMarProd = this.MdiChildren.Where(p => p.Text == "Emision Poliza Marine Producing").First() as Operaciones.Emision.MarineProd;
                                        frmMarProd.Select();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                    else
                                    {
                                        frmMarProd.MdiParent = this;
                                        frmMarProd.Show();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                }
                                break;

                            case "Property":
                                int? tmpOrigenPr = (from x in db.PolizaProperty where x.Poliza == guardado select x.Origen).SingleOrDefault();
                                if (tmpOrigenPr == 1)
                                {
                                    Operaciones.Emision.PropertyInc frmPropInc = new Operaciones.Emision.PropertyInc(1, guardado);
                                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Property Incoming").Count() > 0)
                                    {
                                        frmPropInc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Property Incoming").First() as Operaciones.Emision.PropertyInc;
                                        frmPropInc.Select();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                        frmPropInc.idPoliza = guardado;
                                        frmPropInc.cargarPolizaMain();
                                    }
                                    else
                                    {
                                        frmPropInc.MdiParent = this;
                                        frmPropInc.Show();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                }
                                else
                                {
                                    Operaciones.Emision.PropertyProd frmPropInc = new Operaciones.Emision.PropertyProd(1, guardado);
                                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Property Producing").Count() > 0)
                                    {
                                        frmPropInc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Property Producing").First() as Operaciones.Emision.PropertyProd;
                                        frmPropInc.Select();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                        frmPropInc.idPoliza = guardado;
                                        frmPropInc.cargarPolizaMain();
                                    }
                                    else
                                    {
                                        frmPropInc.MdiParent = this;
                                        frmPropInc.Show();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                }
                                break;

                            case "Financial Lines":
                                int? tmpOrigenFL = (from x in db.PolizaFL where x.Poliza == guardado select x.Origen).SingleOrDefault();
                                if (tmpOrigenFL == 1)
                                {
                                    Operaciones.Emision.FinancialLinesInc frmFLinc = new Operaciones.Emision.FinancialLinesInc(1, guardado);
                                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Financial Lines Incoming").Count() > 0)
                                    {
                                        frmFLinc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Financial Lines Incoming").First() as Operaciones.Emision.FinancialLinesInc;
                                        frmFLinc.Select();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                        frmFLinc.idPoliza = guardado;
                                        frmFLinc.cargarPolizaMain();
                                    }
                                    else
                                    {
                                        frmFLinc.MdiParent = this;
                                        frmFLinc.Show();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                }
                                else
                                {
                                    Operaciones.Emision.FinancialLinesProd frmFLinc = new Operaciones.Emision.FinancialLinesProd(1, guardado);
                                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Financial Lines Producing").Count() > 0)
                                    {
                                        frmFLinc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Financial Lines Producing").First() as Operaciones.Emision.FinancialLinesProd;
                                        frmFLinc.Select();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                        frmFLinc.idPoliza = guardado;
                                        frmFLinc.cargarPolizaMain();
                                    }
                                    else
                                    {
                                        frmFLinc.MdiParent = this;
                                        frmFLinc.Show();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                }
                                break;
                        }
                    }
                    break;

                case "btnInterfazGenius":                    // Funcion demo
                    MessageBox.Show("Esta es una función en desarrollo con fines de demostración, el sistema seleccionará una póliza apta para su captura en el sistema Genius", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Process execute = new Process();
                    execute.StartInfo.FileName = "C:\\Program Files (x86)\\XLCapital\\XLGlobalUILauncher\\5.0.86\\XLGlobalUILauncher.exe";
                    execute.StartInfo.CreateNoWindow = true;
                    execute.EnableRaisingEvents = true;
                    execute.Start();
                    //"C:\Program Files (x86)\UiPath\Studio\UiRobot.exe" -file "C:\Users\Kreios\Documents\UiPath\Abrir Visual Studio\Main.xaml"
                    Process executeR = new Process();
                    executeR.StartInfo.FileName = @"C:\Program Files (x86)\UiPath\Studio\UiRobot.exe";
                    executeR.StartInfo.Arguments = @"-file C:\SmartG\Genius\Main.xaml";
                    executeR.StartInfo.CreateNoWindow = true;
                    executeR.StartInfo.RedirectStandardOutput = true;
                    executeR.StartInfo.RedirectStandardError = true;
                    executeR.StartInfo.UseShellExecute = false;
                    executeR.EnableRaisingEvents = true;
                    executeR.Start();
                    //string numPoliza = guardado.ToString();
                    //var client = new UiPathRobotClient();
                    //var job = @"{'WorkflowFile': 'C:\\SmartG\\Genius\\Main.xaml' , 'InputArguments': {'Poliza': '" + numPoliza + "'}}";
                    //Console.WriteLine(client.StartJob(job));
                    //Console.ReadLine();
                    break;

                case "btnEndosos":      //Generar Endosos
                    Operaciones.Emision.BusquedaPolizas frmBusquedaE = new Operaciones.Emision.BusquedaPolizas(3);
                    if (frmBusquedaE.ShowDialog() == DialogResult.OK)
                    {
                        dbSmartGDataContext db = new dbSmartGDataContext();
                        switch (lineaNegocios)
                        {
                            case "Liability":
                                int? tmpOrigenLi = (from x in db.PolizaLiability where x.Poliza == guardado select x.Origen).SingleOrDefault();
                                if (tmpOrigenLi == 1)
                                {
                                    Operaciones.Emision.LiabilityInc frmLiaInc = new Operaciones.Emision.LiabilityInc(2, guardado);
                                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Liability Incoming").Count() > 0)
                                    {
                                        frmLiaInc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Liability Incoming").First() as Operaciones.Emision.LiabilityInc;
                                        frmLiaInc.Select();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                    else
                                    {
                                        frmLiaInc.MdiParent = this;
                                        frmLiaInc.Show();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                }
                                else
                                {
                                    Operaciones.Emision.LiabilityProd frmLiaInc = new Operaciones.Emision.LiabilityProd(2, guardado);
                                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Liability Producing").Count() > 0)
                                    {
                                        frmLiaInc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Liability Producing").First() as Operaciones.Emision.LiabilityProd;
                                        frmLiaInc.Select();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                    else
                                    {
                                        frmLiaInc.MdiParent = this;
                                        frmLiaInc.Show();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                }
                                break;

                            case "Marine":
                                int? tmpOrigenMa = (from x in db.PolizaMarine where x.Poliza == guardado select x.Origen).SingleOrDefault();
                                if (tmpOrigenMa == 1)
                                {
                                    Operaciones.Emision.MarineInc frmMarInc = new Operaciones.Emision.MarineInc(1, guardado);
                                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Marine Incoming").Count() > 0)
                                    {
                                        frmMarInc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Marine Incoming").First() as Operaciones.Emision.MarineInc;
                                        frmMarInc.Select();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                    else
                                    {
                                        frmMarInc.MdiParent = this;
                                        frmMarInc.Show();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                }
                                else
                                {
                                    Operaciones.Emision.MarineProd frmMarProd = new Operaciones.Emision.MarineProd(1, guardado);
                                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Marine Producing").Count() > 0)
                                    {
                                        frmMarProd = this.MdiChildren.Where(p => p.Text == "Emision Poliza Marine Producing").First() as Operaciones.Emision.MarineProd;
                                        frmMarProd.Select();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                    else
                                    {
                                        frmMarProd.MdiParent = this;
                                        frmMarProd.Show();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                }
                                break;

                            case "Property":
                                int? tmpOrigenPr = (from x in db.PolizaProperty where x.Poliza == guardado select x.Origen).SingleOrDefault();
                                if (tmpOrigenPr == 1)
                                {
                                    Operaciones.Emision.PropertyInc frmPropInc = new Operaciones.Emision.PropertyInc(1, guardado);
                                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Property Incoming").Count() > 0)
                                    {
                                        frmPropInc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Property Incoming").First() as Operaciones.Emision.PropertyInc;
                                        frmPropInc.Select();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                    else
                                    {
                                        frmPropInc.MdiParent = this;
                                        frmPropInc.Show();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                }
                                else
                                {
                                    Operaciones.Emision.PropertyProd frmPropInc = new Operaciones.Emision.PropertyProd(1, guardado);
                                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Property Producing").Count() > 0)
                                    {
                                        frmPropInc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Property Producing").First() as Operaciones.Emision.PropertyProd;
                                        frmPropInc.Select();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                    else
                                    {
                                        frmPropInc.MdiParent = this;
                                        frmPropInc.Show();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                }
                                break;

                            case "Financial Lines":
                                int? tmpOrigenFL = (from x in db.PolizaFL where x.Poliza == guardado select x.Origen).SingleOrDefault();
                                if (tmpOrigenFL == 1)
                                {
                                    Operaciones.Emision.FinancialLinesInc frmFLinc = new Operaciones.Emision.FinancialLinesInc(1, guardado);
                                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Financial Lines Incoming").Count() > 0)
                                    {
                                        frmFLinc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Financial Lines Incoming").First() as Operaciones.Emision.FinancialLinesInc;
                                        frmFLinc.Select();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                    else
                                    {
                                        frmFLinc.MdiParent = this;
                                        frmFLinc.Show();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                }
                                else
                                {
                                    Operaciones.Emision.FinancialLinesProd frmFLinc = new Operaciones.Emision.FinancialLinesProd(1, guardado);
                                    if (this.MdiChildren.Where(p => p.Text == "Emision Poliza Financial Lines Producing").Count() > 0)
                                    {
                                        frmFLinc = this.MdiChildren.Where(p => p.Text == "Emision Poliza Financial Lines Producing").First() as Operaciones.Emision.FinancialLinesProd;
                                        frmFLinc.Select();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                    else
                                    {
                                        frmFLinc.MdiParent = this;
                                        frmFLinc.Show();
                                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                                    }
                                }
                                break;
                        }

                    }
                    break;

                case "btnObtenerDoctosEmi":
                    //Operaciones.DescargarDocumentos frmDescargarEmi = new Operaciones.DescargarDocumentos(false);
                    //frmDescargarEmi.ShowDialog();
                    string folderS = @"\\SMARTG_SERVERXL\Documentos Emision\";
                    Process.Start(folderS);
                    break;
                #endregion

                #region Facturacion
                // Funciones del Menu Facturación ********************************************************************************************************************************

                case "btnNuevaFactura":
                    Operaciones.CreditControl.Facturacion frmFact = new Operaciones.CreditControl.Facturacion(0, "Normal");
                    if (this.MdiChildren.Where(p => p.Text == "Facturacion").Count() > 0)
                    {
                        frmFact = this.MdiChildren.Where(p => p.Text == "Facturacion").First() as Operaciones.CreditControl.Facturacion;
                        frmFact.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmFact.MdiParent = this;
                        frmFact.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "btnMisFacturas":
                    Operaciones.CreditControl.MisFacturas frmMisFacturas = new Operaciones.CreditControl.MisFacturas(this);
                    if (this.MdiChildren.Where(p => p.Text == "MisFacturas").Count() > 0)
                    {
                        frmMisFacturas = this.MdiChildren.Where(p => p.Text == "MisFacturas").First() as Operaciones.CreditControl.MisFacturas;
                        frmMisFacturas.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmMisFacturas.MdiParent = this;
                        frmMisFacturas.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "btnObtenerFacturas":
                    Operaciones.DescargarDocumentos frmDescargarFac = new Operaciones.DescargarDocumentos(true);
                    frmDescargarFac.ShowDialog();
                    break;

                case "btnAdministracionFacturas":
                    Operaciones.CreditControl.AdministracionFacturas frmAdminFact = new Operaciones.CreditControl.AdministracionFacturas(this);
                    if (this.MdiChildren.Where(p => p.Text == "AdministracionFacturas").Count() > 0)
                    {
                        frmAdminFact = this.MdiChildren.Where(p => p.Text == "AdministracionFacturas").First() as Operaciones.CreditControl.AdministracionFacturas;
                        frmAdminFact.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmAdminFact.MdiParent = this;
                        frmAdminFact.Show();
                        try
                        {
                            ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                            ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                        }
                        catch { }
                    }
                    break;

                case "btnIngresosComplementos":
                    Operaciones.CreditControl.Ingresos frmIngresos = new Operaciones.CreditControl.Ingresos(this);
                    if (this.MdiChildren.Where(p => p.Text == "Ingresos").Count() > 0)
                    {
                        frmIngresos = this.MdiChildren.Where(p => p.Text == "Ingresos").First() as Operaciones.CreditControl.Ingresos;
                        frmIngresos.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmIngresos.MdiParent = this;
                        frmIngresos.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;


                case "btnCobranzaBrokerage":
                    Operaciones.CreditControl.Cobranza.Brokerage frmBrokerage = new Operaciones.CreditControl.Cobranza.Brokerage();
                    if (this.MdiChildren.Where(p => p.Text == "Brokerage").Count() > 0)
                    {
                        frmBrokerage = this.MdiChildren.Where(p => p.Text == "Brokerage").First() as Operaciones.CreditControl.Cobranza.Brokerage;
                        frmBrokerage.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmBrokerage.MdiParent = this;
                        frmBrokerage.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;


                case "btnCobranzaReaseguro":
                    Operaciones.CreditControl.Cobranza.ReaseguroBrokerage frmRease = new Operaciones.CreditControl.Cobranza.ReaseguroBrokerage();
                    if (this.MdiChildren.Where(p => p.Text == "Reaseguro Brokerage").Count() > 0)
                    {
                        frmRease = this.MdiChildren.Where(p => p.Text == "Reaseguro Brokerage").First() as Operaciones.CreditControl.Cobranza.ReaseguroBrokerage;
                        frmRease.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmRease.MdiParent = this;
                        frmRease.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;

                    

                #endregion

                #region Catalogos
                // Funciones del Menu Catálogos ********************************************************************************************************************************

                case "btnTmpTOBPO":                    // temporal para lnpo y lntb
                    Catalogos.mainToByPO frmTOByPO = new Catalogos.mainToByPO();
                    if (this.MdiChildren.Where(p => p.Text == "Catalogo Producing Office y Trade of Business").Count() > 0)
                    {
                        frmTOByPO = this.MdiChildren.Where(p => p.Text == "Catalogo Producing Office y Trade of Business").First() as Catalogos.mainToByPO;
                        frmTOByPO.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmTOByPO.MdiParent = this;
                        frmTOByPO.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "btnClientes":                    // Clientes
                    Catalogos.clientes frmClientes = new Catalogos.clientes(0);
                    if (this.MdiChildren.Where(p => p.Text == "Clientes").Count() > 0)
                    {
                        frmClientes = this.MdiChildren.Where(p => p.Text == "Clientes").First() as Catalogos.clientes;
                        frmClientes.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmClientes.MdiParent = this;
                        frmClientes.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "btnAprobacionClientes":                    // Clientes
                    Catalogos.AprobacionClientes frmAproClientes = new Catalogos.AprobacionClientes();
                    if (this.MdiChildren.Where(p => p.Text == "Aprobacion Clientes").Count() > 0)
                    {
                        frmAproClientes = this.MdiChildren.Where(p => p.Text == "Aprobacion Clientes").First() as Catalogos.AprobacionClientes;
                        frmAproClientes.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmAproClientes.MdiParent = this;
                        frmAproClientes.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "btnUsuarios":                    // Usuarios
                    Catalogos.Usuarios frmUsuarios = new Catalogos.Usuarios();
                    if (this.MdiChildren.Where(p => p.Text == "Usuarios").Count() > 0)
                    {
                        frmUsuarios = this.MdiChildren.Where(p => p.Text == "Usuarios").First() as Catalogos.Usuarios;
                        frmUsuarios.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmUsuarios.MdiParent = this;
                        frmUsuarios.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;


                case "btnPerfilesYaccesos":                    // Priles de Usuarios
                    Catalogos.UsuariosPerfil frmUsuariosPerfil = new Catalogos.UsuariosPerfil();
                    if (this.MdiChildren.Where(p => p.Text == "UsuariosPerfil").Count() > 0)
                    {
                        frmUsuariosPerfil = this.MdiChildren.Where(p => p.Text == "UsuariosPerfil").First() as Catalogos.UsuariosPerfil;
                        frmUsuariosPerfil.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmUsuariosPerfil.MdiParent = this;
                        frmUsuariosPerfil.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "btnDetallesEmpresa":
                    Catalogos.EditarEmpresa frmEmpresa = new Catalogos.EditarEmpresa();
                    if (this.MdiChildren.Where(p => p.Text == "EditarEmpresa").Count() > 0)
                    {
                        frmEmpresa = this.MdiChildren.Where(p => p.Text == "EditarEmpresa").First() as Catalogos.EditarEmpresa;
                        frmEmpresa.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmEmpresa.MdiParent = this;
                        frmEmpresa.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "btnChangeLog":
                    Catalogos.ChangeLog frmChangeLog = new Catalogos.ChangeLog();
                    if (this.MdiChildren.Where(p => p.Text == "ChangeLog").Count() > 0)
                    {
                        frmChangeLog = this.MdiChildren.Where(p => p.Text == "ChangeLog").First() as Catalogos.ChangeLog;
                        frmChangeLog.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmChangeLog.MdiParent = this;
                        frmChangeLog.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "btnEndososEmision":
                    Catalogos.Emision.mainEndosos frmMainEndosos = new Catalogos.Emision.mainEndosos();
                    if (this.MdiChildren.Where(p => p.Text == "Endosos del Sistema").Count() > 0)
                    {
                        frmMainEndosos = this.MdiChildren.Where(p => p.Text == "Endosos del Sistema").First() as Catalogos.Emision.mainEndosos;
                        frmMainEndosos.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmMainEndosos.MdiParent = this;
                        frmMainEndosos.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;


                case "btnTimbradoFacturas":
                    Catalogos.TimbradoFacturas frmEditarTimbrado = new Catalogos.TimbradoFacturas();
                    if (this.MdiChildren.Where(p => p.Text == "TimbradoFacturas").Count() > 0)
                    {
                        frmEditarTimbrado = this.MdiChildren.Where(p => p.Text == "TimbradoFacturas").First() as Catalogos.TimbradoFacturas;
                        frmEditarTimbrado.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmEditarTimbrado.MdiParent = this;
                        frmEditarTimbrado.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "btnBrokers":
                    Catalogos.MainBrokers frmMainBrokers = new Catalogos.MainBrokers();
                    if (this.MdiChildren.Where(p => p.Text == "Ventana Principal de Brokers").Count() > 0)
                    {
                        frmMainBrokers = this.MdiChildren.Where(p => p.Text == "Ventana Principal de Brokers").First() as Catalogos.MainBrokers;
                        frmMainBrokers.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmMainBrokers.MdiParent = this;
                        frmMainBrokers.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "btnCoberturas":
                    Catalogos.Emision.MainCoberturasSubCoberturas frmMainCoberturas = new Catalogos.Emision.MainCoberturasSubCoberturas();
                    if (this.MdiChildren.Where(p => p.Text == "Principal Coberturas y Subcoberturas").Count() > 0)
                    {
                        frmMainCoberturas = this.MdiChildren.Where(p => p.Text == "Principal Coberturas y Subcoberturas").First() as Catalogos.Emision.MainCoberturasSubCoberturas;
                        frmMainCoberturas.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmMainCoberturas.MdiParent = this;
                        frmMainCoberturas.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "btnReaseguradoras":
                    Catalogos.Emision.MainReaseguradoras frmMainReasegu = new Catalogos.Emision.MainReaseguradoras();
                    if (this.MdiChildren.Where(p => p.Text == "Principal Reaseguradoras").Count() > 0)
                    {
                        frmMainReasegu = this.MdiChildren.Where(p => p.Text == "Principal Reaseguradoras").First() as Catalogos.Emision.MainReaseguradoras;
                        frmMainReasegu.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmMainReasegu.MdiParent = this;
                        frmMainReasegu.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "btnCoaseguradoras":
                    Catalogos.Emision.MainCoaseguradoras frmMainCoasegu = new Catalogos.Emision.MainCoaseguradoras();
                    if (this.MdiChildren.Where(p => p.Text == "Principal Coaseguradoras").Count() > 0)
                    {
                        frmMainCoasegu = this.MdiChildren.Where(p => p.Text == "Principal Coaseguradoras").First() as Catalogos.Emision.MainCoaseguradoras;
                        frmMainCoasegu.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmMainCoasegu.MdiParent = this;
                        frmMainCoasegu.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "btnSubirTemplate":
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (openFileDialog1.FileName != "")
                        {
                            dbSmartGDataContext db = new dbSmartGDataContext();
                            DoctosTemplates aBorrar = (from x in db.DoctosTemplates where x.NombreDocumento == openFileDialog1.SafeFileName select x).SingleOrDefault();
                            if (aBorrar != null)
                            {
                                db.DoctosTemplates.DeleteOnSubmit(aBorrar);
                                db.SubmitChanges();
                            }
                            DocumentosDB docto = new DocumentosDB();
                            if (docto.GuardarDocumentoDBTemplates(openFileDialog1.FileName, openFileDialog1.SafeFileName))
                            {
                                MessageBox.Show("Documento Guardado satisfactoriamente");
                            }
                        }
                    }
                    break;

                case "btnDescargarDocumento":
                    tmpSearch frmTMPG1 = new tmpSearch(1);
                    frmTMPG1.ShowDialog();
                    break;

                case "btnConsultarTicketsSoporte":
                    Operaciones.TicketsSoporte.ConsultarTickets frmTickets = new Operaciones.TicketsSoporte.ConsultarTickets();
                    if (this.MdiChildren.Where(p => p.Text == "ConsultarTickets").Count() > 0)
                    {
                        frmTickets = this.MdiChildren.Where(p => p.Text == "ConsultarTickets").First() as Operaciones.TicketsSoporte.ConsultarTickets;
                        frmTickets.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmTickets.MdiParent = this;
                        frmTickets.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "btnEditarLimitesWriteOffs":
                    Operaciones.CreditControl.WriteOffLimitesEdicion frmLimitesWO = new Operaciones.CreditControl.WriteOffLimitesEdicion();
                    frmLimitesWO.ShowDialog();
                    break;

                #endregion

                #region Compliance
                // Funciones de Compliance ********************************************************************************************************************************
                case "btnCompliance":
                    Operaciones.Compliance.Compliance frmComp = new Operaciones.Compliance.Compliance();
                    if (this.MdiChildren.Where(p => p.Text == "Compliance").Count() > 0)
                    {
                        frmComp = this.MdiChildren.Where(p => p.Text == "Compliance").First() as Operaciones.Compliance.Compliance;
                        frmComp.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmComp.MdiParent = this;
                        frmComp.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;
                    #endregion
                    
                #region Reportes
                // Funciones de Reportes ********************************************************************************************************************************
                case "btnPolizasGeneradas":
                    Operaciones.Reportes.ReportesEmision frmEmiRep = new Operaciones.Reportes.ReportesEmision();
                    if (this.MdiChildren.Where(p => p.Text == "Reportes Emision").Count() > 0)
                    {
                        frmEmiRep = this.MdiChildren.Where(p => p.Text == "Reportes Emision").First() as Operaciones.Reportes.ReportesEmision;
                        frmEmiRep.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmEmiRep.MdiParent = this;
                        frmEmiRep.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;
                #endregion

                #region Siniestros
                // Funciones de Compliance ********************************************************************************************************************************
                case "btnReportesRegulatorios":
                    Operaciones.Claims.ReportesRegulatorios frmRepRegClaims = new Operaciones.Claims.ReportesRegulatorios();
                    if (this.MdiChildren.Where(p => p.Text == "ReportesRegulatorios").Count() > 0)
                    {
                        frmRepRegClaims = this.MdiChildren.Where(p => p.Text == "ReportesRegulatorios").First() as Operaciones.Claims.ReportesRegulatorios;
                        frmRepRegClaims.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmRepRegClaims.MdiParent = this;
                        frmRepRegClaims.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;
                     
                case "btnAdministracionSiniestros":
                    Operaciones.Claims.FNOL frmFNOL = new Operaciones.Claims.FNOL();
                    if (this.MdiChildren.Where(p => p.Text == "Administración Claims").Count() > 0)
                    {
                        frmFNOL = this.MdiChildren.Where(p => p.Text == "Administración Claims").First() as Operaciones.Claims.FNOL;
                        frmFNOL.Select();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        frmFNOL.MdiParent = this;
                        frmFNOL.Show();
                        ToolbarsMain.Ribbon.SelectedTab = ToolbarsMain.ActiveMdiChildManager.Ribbon.Tabs[0].AttachedParentTab;
                        ToolbarsMain.ActiveMdiChildManager.Appearance.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "btnNuevoAvisoPerdida":
                    Operaciones.Claims.EditarFNOL frmNuevo = new Operaciones.Claims.EditarFNOL(0);
                    frmNuevo.ShowDialog();
                    break;

                    #endregion

            }
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            GC.Collect();
            inactividad nueva = new inactividad();
            long segundosInactividad = nueva.GetLastInputTime();
            if (segundosInactividad > Properties.Settings.Default.TiempoEsperaBloqueo)
            {
                timerMain.Stop();
                statusBarMain.Panels[0].Visible = true;
                statusBarMain.Panels[1].Visible = true;
                for (int i = 25; i < 125; i = i + 25)
                {
                    guardarEmision(i);
                    statusBarMain.Panels[1].ProgressBarInfo.Value = i;
                }
                statusBarMain.Panels[0].Visible = false;
                statusBarMain.Panels[1].Visible = false;
                desbloquearSistema frmDesbloquear = new desbloquearSistema();
                frmDesbloquear.ShowDialog();
                timerMain.Start();
            }
        }

        void UsuarioLabel()
        {
            Catalogos.UsuariosEditar_ frmEditarUser = new Catalogos.UsuariosEditar_(Program.Globals.UserID, true);
            if (frmEditarUser.ShowDialog() == DialogResult.Yes)
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                Usuario logIn = (from x in db.Usuarios where x.ID == Program.Globals.UserID select x).SingleOrDefault();
                Program.Globals.NombreCompletoUsuario = logIn.Nombre + " " + logIn.ApellidoPaterno + " " + logIn.ApellidoMaterno;
                ToolbarsMain.Tools["PopupUsuario"].SharedProps.Caption = Program.Globals.NombreCompletoUsuario + " (" + Program.Globals.TipoUsuario + ")";
            }
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            Extensiones.Cobranza.NuevaSolicitudFacturacion(680, this);
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName != "")
                {
                    Byte[] bytes = null;
                    dbSmartGDataContext db = new dbSmartGDataContext();

                    EmpresaDetalles tmpEmpresa = (from x in db.EmpresaDetalles where x.Principal == true select x).SingleOrDefault();
                    if (tmpEmpresa != null)
                    {
                        Stream fs = File.Open(openFileDialog1.FileName, FileMode.Open);
                        BinaryReader br = new BinaryReader(fs);
                        bytes = br.ReadBytes((Int32)fs.Length);
                        fs.Dispose();

                        tmpEmpresa.FirmaCEO = bytes;
                        db.SubmitChanges();
                        MessageBox.Show("Firma OK");
                    }
                }
            }
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    if (openFileDialog1.FileName != "")
            //    {
            //        dbSmartGDataContext db = new dbSmartGDataContext();
            //        DoctosTemplates aBorrar = (from x in db.DoctosTemplates where x.NombreDocumento == openFileDialog1.SafeFileName select x).SingleOrDefault();
            //        if (aBorrar != null)
            //        {
            //            db.DoctosTemplates.DeleteOnSubmit(aBorrar);
            //            db.SubmitChanges();
            //        }
            //        DocumentosDB docto = new DocumentosDB();
            //        if (docto.guardarDocumentoDBTemplates(openFileDialog1.FileName, openFileDialog1.SafeFileName))
            //        {
            //            MessageBox.Show("Documento Guardado satisfactoriamente");
            //        }
            //    }
            //}
            //DocumentosDB docto = new DocumentosDB();
            //if (docto.ExtraerFirmaCEO())
            //{
            //    MessageBox.Show("Documento extraido satisfactoriamente");
            //}
            //Catalogos.MainLimiteMaximo frmLimite = new Catalogos.MainLimiteMaximo();
            //frmLimite.ShowDialog();
            //Catalogos.MainPasswordDocumentos frmPass = new Catalogos.MainPasswordDocumentos();
            //frmPass.ShowDialog();


        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            // Idioma
            if (cbIdiomas.Value.ToString() != idiomaSel)
            {
                Properties.Settings.Default.idiomaSeleccionado = cbIdiomas.Value.ToString();
                Properties.Settings.Default.Save();
                Extensiones.Traduccion.traducirVentana(this, null, ToolbarsMain);
                IdiomaSeleccionado();
            }

            // Tiempo espera bloqueo
            Properties.Settings.Default.TiempoEsperaBloqueo = Convert.ToInt32(txtBloqueoSmartG.Value);
            Properties.Settings.Default.Save();
            txtBloqueoSmartG.Value = Properties.Settings.Default.TiempoEsperaBloqueo;

            // ColorSchema
            Properties.Settings.Default.ColorScheme = cbStyles.Text;
            Properties.Settings.Default.Save();
            SelectColorScheme();

            MessageBox.Show("Cambios aplicados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void timerSolicitudDocumentos_Tick(object sender, EventArgs e)
        {
            try
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                SolicitudesServidor revisarSolicitudes = (from x in db.SolicitudesServidor where x.Usuario == Program.Globals.UserID && x.Status == 2 select x).FirstOrDefault();
                if (revisarSolicitudes != null)
                {
                    timerSolicitudDocumentos.Stop();

                    Poliza polizaUpdate = (from x in db.Poliza where x.ID == revisarSolicitudes.Poliza select x).SingleOrDefault();
                    int? idUsuario = revisarSolicitudes.Usuario; 
                    string nombreUsuario = "default";
                    if (idUsuario != null)
                    {
                        nombreUsuario = (from x in db.Usuarios where x.ID == idUsuario select x.Nombre + "_" + x.ApellidoPaterno + "_" + x.ApellidoMaterno).SingleOrDefault();
                    }
                    string folderS = "";
                    string folderD = "";

                    switch (revisarSolicitudes.TipoSolicitud)
                    {
                        case 1:
                        case 2:
                            // copiamos los archivos del server a la carpeta local
                            if (revisarSolicitudes.TipoSolicitud == 1)
                            {
                                folderD = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaUpdate.Poliza1 + "\\Previews";
                                folderS = @"\\SMARTG_SERVERXL\Documentos Emision\" + nombreUsuario + "\\Emision\\" + polizaUpdate.Poliza1 + "\\Previews";
                            }
                            else if (revisarSolicitudes.TipoSolicitud == 2)
                            {
                                folderD = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiddleOffice Docs Poliza\" + polizaUpdate.Poliza1;
                                folderS = @"\\SMARTG_SERVERXL\Documentos Emision\" + nombreUsuario + "\\Emision\\" + polizaUpdate.Poliza1;
                            }
                            Directory.CreateDirectory(folderD);
                            foreach (var file in Directory.GetFiles(folderS))
                                File.Copy(file, Path.Combine(folderD, Path.GetFileName(file)), true);
                            if (MessageBox.Show("SmartG ha detectado que el servidor ha terminado tus documentos para la póliza : " + polizaUpdate.Poliza1 + " , ¿quieres abrir la carpeta? puedes consultar tus documentos en cualquier momento desde la opción 'Obtener documentos de emisión'", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Process.Start(folderD);
                            }
                            if (revisarSolicitudes.TipoSolicitud == 2)
                            {
                                polizaUpdate.Status = 3;
                                db.SubmitChanges();

                                #region REGISTRO EN GENIUS
                                //funcion demo
                                if (polizaUpdate.LineaNegocios == 1)
                                {
                                    PolizaLiability tmpLiability = (from x in db.PolizaLiability where x.Poliza == polizaUpdate.ID select x).SingleOrDefault();
                                    if (tmpLiability.Origen == 2) // producing, generamos la solicitud en genius
                                    {
                                        SolicitudesServidor nuevaSolicitud = new SolicitudesServidor();
                                        nuevaSolicitud.Usuario = Program.Globals.UserID;
                                        nuevaSolicitud.TipoSolicitud = 3;
                                        nuevaSolicitud.FechaSolicitud = DateTime.Now;
                                        nuevaSolicitud.Poliza = polizaUpdate.ID;
                                        nuevaSolicitud.Status = 1;
                                        db.SolicitudesServidor.InsertOnSubmit(nuevaSolicitud);
                                        db.SubmitChanges();
                                    }
                                }
                                #endregion

                                if (MessageBox.Show("¿Deseas crear una factura con la información de esta póliza?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                                {
                                    Extensiones.Cobranza.NuevaSolicitudFacturacion(Convert.ToInt32(revisarSolicitudes.Poliza), this);
                                }
                            }
                            break;

                        case 3:// captura en genius liability producing
                            MessageBox.Show("SmartG ha detectado que La póliza : " + polizaUpdate.Poliza1 + " ya fué procesada por el robot y se encuentra en el sistema Genius, por favor entra y verifica que toda la información esté correcta y concluye el registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }

                    revisarSolicitudes.Status = 5;
                    db.SubmitChanges();
                    timerSolicitudDocumentos.Start();
                }
            }
            catch { }
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args[1].StartsWith("/p")) // Solo producción
            {
                try
                {
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    string VersionBD = (from x in db.dbVersion select x.SmartGVersion).SingleOrDefault();
                    string VersionApp = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    if (VersionBD != VersionApp)
                    {
                        timerUpdate.Stop();
                        if (MessageBox.Show("Hay una versión disponible en el servidor, desea cerrar la sesion actual para actualizar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            cerrarDirecto = true;
                            Process.Start(@"C:\SmartG\SmartGLauncher.exe");
                            Application.Exit();
                        }
                        else
                            timerUpdate.Start();
                    }
                }
                catch  { timerUpdate.Start(); }
            }
        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
    }
}
