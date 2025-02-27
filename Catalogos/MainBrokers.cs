using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Catalogos
{
    public partial class MainBrokers : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // nombres y valores de todos los objetos que se encuentran en el formulario
        #region coleccion objetos

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region Variables
        int tabAnterior = 1;
        public static int idBroker = 0;

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region Metodos programados
        void autorizarBroker()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            if (MessageBox.Show("¿Deseas autorizar este Broker en este momento?", "Notificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int status = (from y in db.StatusFacturacions where y.Status == "Solicitado" select y.ID).SingleOrDefault();
                BrokersSolicitud solicitudActiva = (from x in db.BrokersSolicitud where x.Broker == idBroker && x.Status == status select x).SingleOrDefault();
                if (solicitudActiva != null)
                {
                    solicitudActiva.Status = (from y in db.StatusFacturacions where y.Status == "Aplicado" select y.ID).SingleOrDefault();
                    solicitudActiva.FechaAtencion = DateTime.Now;
                    solicitudActiva.UsuarioAtencion = Program.Globals.UserID;

                    Broker brokerAuto = (from x in db.Brokers where x.ID == idBroker select x).SingleOrDefault();
                    brokerAuto.Aprobado = true;

                    db.SubmitChanges();
                }
            }
        }

        void iniciarDatos()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            int idPerfil = (from x in db.Perfiles where x.KeyName == "tabSolicitudesBrokers" select x.ID).SingleOrDefault();
            if (idPerfil != 0)
            {
                int perfil = (from x in db.UsuariosPerfils where x.Usuario == Program.Globals.UserID && x.Perfil == idPerfil select x.ID).SingleOrDefault();
                if (perfil != 0)
                {
                    tabControlMainBrokers.Tabs[1].Visible = true;
                }
            }
            brokersTableAdapter.FillByActivos(this.catalogosGral.Brokers);
            dgBrokers.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            tabAnterior = 0;
        }

        void RechazoSolicitud()
        {
            string vDef = "";
            Extensiones.Edicion.InputBox("Rechazo de Solicitud", "Ingrese una descripción del Rechazo de la Solicitud", ref vDef);
            if (vDef == "")
            {
                MessageBox.Show("Ingrese una razon del rechazo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dbSmartGDataContext db = new dbSmartGDataContext();
            int idSolicitud = (from x in db.BrokersSolicitud where x.Broker == idBroker select x.ID).SingleOrDefault();
            Broker rechazadoBroker = (from x in db.Brokers where x.ID == idBroker select x).SingleOrDefault();
            rechazadoBroker.Aprobado = false;
            BrokersSolicitud solicitudActiva = (from x in db.BrokersSolicitud where x.ID == idSolicitud select x).SingleOrDefault();
            solicitudActiva.Status = (from y in db.StatusFacturacions where y.Status == "Rechazado" select y.ID).SingleOrDefault();
            solicitudActiva.FechaAtencion = DateTime.Now;
            solicitudActiva.UsuarioAtencion = Program.Globals.UserID;
            solicitudActiva.ObservacionesAtencion = vDef;
            db.SubmitChanges();
            MessageBox.Show("Solicitud Rechazada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region eventos form

        public MainBrokers()
        {
            InitializeComponent();
        }

        private void MainBrokers_Load(object sender, EventArgs e)
        {
            iniciarDatos();
            Extensiones.Traduccion.traducirVentana(this, tabControlMainBrokers, ToolbarsBrokersMain);
        }

        private void ToolbarsBrokersMain_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btnAgregarBroker":
                    Catalogos.AgregarEditarBrokers frmAgregar = new AgregarEditarBrokers();
                    if (frmAgregar.ShowDialog() == DialogResult.OK)
                    {
                        dbSmartGDataContext db = new dbSmartGDataContext();

                        if (tabControlMainBrokers.Tabs[1].Visible == true)
                        {
                            autorizarBroker();
                            brokersTableAdapter.FillByActivos(this.catalogosGral.Brokers);
                            dgBrokers.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                        }
                        else
                        {
                            MessageBox.Show("Broker Solicitado y en espera de su autorización", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    break;

                case "btnEditarBroker":
                    if (dgBrokers.Selected.Rows.Count == 1)
                    {
                        Catalogos.AgregarEditarBrokers frmEditar = new AgregarEditarBrokers(Convert.ToInt32(dgBrokers.ActiveRow.Cells["ID"].Text));
                        if (frmEditar.ShowDialog() == DialogResult.OK)
                        {
                            dbSmartGDataContext db = new dbSmartGDataContext();

                            if (tabControlMainBrokers.Tabs[1].Visible == true)
                            {
                                autorizarBroker();
                                brokersTableAdapter.FillByActivos(this.catalogosGral.Brokers);
                                dgBrokers.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                            }
                            else
                            {
                                MessageBox.Show("Broker Solicitado y en espera de su autorización", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }

                    }
                    break;

                case "btnEliminarBroker":
                    if (dgBrokers.Selected.Rows.Count == 1)
                    {
                        if (MessageBox.Show("¿Deseas eliminar al broker seleccionado?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            dbSmartGDataContext db = new dbSmartGDataContext();
                            Broker brkElimina = (from x in db.Brokers where x.ID == Convert.ToInt32(dgBrokers.ActiveRow.Cells["ID"].Text) select x).SingleOrDefault();
                            brkElimina.Eliminado = true;
                            brkElimina.Aprobado = false;
                            db.SubmitChanges();
                            MessageBox.Show("Broker eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            brokersTableAdapter.FillByActivos(this.catalogosGral.Brokers);
                            dgBrokers.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                        }
                    }
                    break;

                case "btnAutorizarBroker":
                    if (dgSolicitudes.Selected.Rows.Count == 1)
                    {
                        idBroker = Convert.ToInt32(dgSolicitudes.ActiveRow.Cells["ID"].Text);
                        autorizarBroker();
                        brokersTableAdapter.FillByEnSolicitud(this.catalogosGral.Brokers);
                        dgSolicitudes.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                    }
                    break;

                case "btnCancelarSolicitud":
                    if (dgSolicitudes.Selected.Rows.Count == 1)
                    {
                        idBroker = Convert.ToInt32(dgSolicitudes.ActiveRow.Cells["ID"].Text);
                        RechazoSolicitud();
                        brokersTableAdapter.FillByEnSolicitud(this.catalogosGral.Brokers);
                        dgSolicitudes.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                    }
                    break;
            }
        }

        private void tabControlMainBrokers_SelectedTabChanging(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangingEventArgs e)
        {
            if (tabAnterior == 0)
            {
                ToolbarsBrokersMain.Ribbon.Tabs[0].Groups[0].Tools[0].SharedProps.Visible = false;
                ToolbarsBrokersMain.Ribbon.Tabs[0].Groups[0].Tools[1].SharedProps.Visible = false;
                ToolbarsBrokersMain.Ribbon.Tabs[0].Groups[0].Tools[2].SharedProps.Visible = false;
                ToolbarsBrokersMain.Ribbon.Tabs[0].Groups[0].Tools[3].SharedProps.Visible = true;
                ToolbarsBrokersMain.Ribbon.Tabs[0].Groups[0].Tools[4].SharedProps.Visible = true;
                brokersTableAdapter.FillByEnSolicitud(this.catalogosGral.Brokers);
                dgSolicitudes.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
            else
            {
                ToolbarsBrokersMain.Ribbon.Tabs[0].Groups[0].Tools[0].SharedProps.Visible = true;
                ToolbarsBrokersMain.Ribbon.Tabs[0].Groups[0].Tools[1].SharedProps.Visible = true;
                ToolbarsBrokersMain.Ribbon.Tabs[0].Groups[0].Tools[2].SharedProps.Visible = true;
                ToolbarsBrokersMain.Ribbon.Tabs[0].Groups[0].Tools[3].SharedProps.Visible = false;
                ToolbarsBrokersMain.Ribbon.Tabs[0].Groups[0].Tools[4].SharedProps.Visible = false;
                brokersTableAdapter.FillByActivos(this.catalogosGral.Brokers);
                dgBrokers.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
            tabAnterior = tabControlMainBrokers.ActiveTab.Index;
        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************

    }
}
