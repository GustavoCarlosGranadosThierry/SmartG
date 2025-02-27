using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Catalogos.Emision
{
    public partial class MainCoaseguradoras : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region Variables
        int tabAnterior = 1;
        public static int idCoaseguradora = 0;
        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region Metodos programados
        void autorizarCoaseguradora()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            if (MessageBox.Show("¿Deseas autorizar esta Coaseguradora en este momento?", "Notificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int status = (from y in db.StatusFacturacions where y.Status == "Solicitado" select y.ID).SingleOrDefault();
                CoaseguradorasSolicitud solicitudActiva = (from x in db.CoaseguradorasSolicitud where x.Coaseguradora == idCoaseguradora && x.Status == status select x).SingleOrDefault();
                if (solicitudActiva != null)
                {
                    solicitudActiva.Status = (from y in db.StatusFacturacions where y.Status == "Aplicado" select y.ID).SingleOrDefault();
                    solicitudActiva.FechaAtencion = DateTime.Now;
                    solicitudActiva.UsuarioAtencion = Program.Globals.UserID;
                    Coaseguradoras coaseguAuto = (from x in db.Coaseguradoras where x.ID == idCoaseguradora select x).SingleOrDefault();
                    coaseguAuto.Aprobado = true;
                    db.SubmitChanges();
                }
            }
        }

        void iniciarDatos()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            int idPerfil = (from x in db.Perfiles where x.KeyName == "tabSolicitudesCoase" select x.ID).SingleOrDefault();
            if (idPerfil != 0)
            {
                int perfil = (from x in db.UsuariosPerfils where x.Usuario == Program.Globals.UserID && x.Perfil == idPerfil select x.ID).SingleOrDefault();
                if (perfil != 0)
                {
                    tabControlMainBrokers.Tabs[1].Visible = true;
                }
            }
            coaseguradorasTableAdapter.FillByActivos(this.catalogosGral.Coaseguradoras);
            dgCoaseguradoras.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
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
            int idSolicitud = (from x in db.CoaseguradorasSolicitud where x.Coaseguradora == idCoaseguradora select x.ID).SingleOrDefault();
            Coaseguradoras rechazadoCoase = (from x in db.Coaseguradoras where x.ID == idCoaseguradora select x).SingleOrDefault();
            rechazadoCoase.Aprobado = false;
            CoaseguradorasSolicitud solicitudActiva = (from x in db.CoaseguradorasSolicitud where x.ID == idSolicitud select x).SingleOrDefault();
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
        public MainCoaseguradoras()
        {
            InitializeComponent();
        }

        private void MainCoaseguradoras_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this, tabControlMainBrokers, ToolbarsManagerCoase);
            iniciarDatos();
        }

        private void tabControlMainBrokers_SelectedTabChanging(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangingEventArgs e)
        {
            if (tabAnterior == 0)
            {
                ToolbarsManagerCoase.Ribbon.Tabs[0].Groups[0].Tools[0].SharedProps.Visible = false;
                ToolbarsManagerCoase.Ribbon.Tabs[0].Groups[0].Tools[1].SharedProps.Visible = false;
                ToolbarsManagerCoase.Ribbon.Tabs[0].Groups[0].Tools[2].SharedProps.Visible = false;
                ToolbarsManagerCoase.Ribbon.Tabs[0].Groups[0].Tools[3].SharedProps.Visible = true;
                ToolbarsManagerCoase.Ribbon.Tabs[0].Groups[0].Tools[4].SharedProps.Visible = true;
                coaseguradorasTableAdapter.FillByEnSolicitud(this.catalogosGral.Coaseguradoras);
                dgSolicitudes.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
            else
            {
                ToolbarsManagerCoase.Ribbon.Tabs[0].Groups[0].Tools[0].SharedProps.Visible = true;
                ToolbarsManagerCoase.Ribbon.Tabs[0].Groups[0].Tools[1].SharedProps.Visible = true;
                ToolbarsManagerCoase.Ribbon.Tabs[0].Groups[0].Tools[2].SharedProps.Visible = true;
                ToolbarsManagerCoase.Ribbon.Tabs[0].Groups[0].Tools[3].SharedProps.Visible = false;
                ToolbarsManagerCoase.Ribbon.Tabs[0].Groups[0].Tools[4].SharedProps.Visible = false;
                coaseguradorasTableAdapter.FillByActivos(this.catalogosGral.Coaseguradoras);
                dgCoaseguradoras.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
            tabAnterior = tabControlMainBrokers.ActiveTab.Index;
        }

        private void ToolbarsManagerCoase_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btnAgregarCoase":
                    Catalogos.Emision.agregarEditarCoaseguros frmAgregar = new agregarEditarCoaseguros();
                    if (frmAgregar.ShowDialog() == DialogResult.OK)
                    {
                        dbSmartGDataContext db = new dbSmartGDataContext();

                        if (tabControlMainBrokers.Tabs[1].Visible == true)
                        {
                            autorizarCoaseguradora();
                            coaseguradorasTableAdapter.FillByActivos(this.catalogosGral.Coaseguradoras);
                            dgCoaseguradoras.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                        }
                        else
                        {
                            MessageBox.Show("Coaseguradora Solicitada y en espera de su autorización", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    break;

                case "btnEditarCoase":
                    if (dgCoaseguradoras.Selected.Rows.Count == 1)
                    {
                        Catalogos.Emision.agregarEditarCoaseguros frmEditar = new agregarEditarCoaseguros(Convert.ToInt32(dgCoaseguradoras.ActiveRow.Cells["ID"].Text));
                        if (frmEditar.ShowDialog() == DialogResult.OK)
                        {
                            dbSmartGDataContext db = new dbSmartGDataContext();

                            if (tabControlMainBrokers.Tabs[1].Visible == true)
                            {
                                autorizarCoaseguradora();
                                coaseguradorasTableAdapter.FillByActivos(this.catalogosGral.Coaseguradoras);
                                dgCoaseguradoras.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                            }
                            else
                            {
                                MessageBox.Show("Coaseguradora Solicitada y en espera de su autorización", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }

                    }
                    break;

                case "btnEliminarCoase":
                    if (dgCoaseguradoras.Selected.Rows.Count == 1)
                    {
                        if (MessageBox.Show("¿Deseas eliminar al coasegurador seleccionado?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            dbSmartGDataContext db = new dbSmartGDataContext();
                            Coaseguradoras aEliminar = (from x in db.Coaseguradoras where x.ID == Convert.ToInt32(dgCoaseguradoras.ActiveRow.Cells["ID"].Text) select x).SingleOrDefault();
                            aEliminar.Eliminado = true;
                            aEliminar.Aprobado = false;
                            db.SubmitChanges();
                            MessageBox.Show("Coasegurador eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            coaseguradorasTableAdapter.FillByActivos(this.catalogosGral.Coaseguradoras);
                            dgCoaseguradoras.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                        }
                    }
                    break;

                case "btnAutorizaCoase":
                    if (dgSolicitudes.Selected.Rows.Count == 1)
                    {
                        idCoaseguradora = Convert.ToInt32(dgSolicitudes.ActiveRow.Cells["ID"].Text);
                        autorizarCoaseguradora();
                        coaseguradorasTableAdapter.FillByEnSolicitud(this.catalogosGral.Coaseguradoras);
                        dgSolicitudes.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                    }
                    break;

                case "btnCancelaSolicitud":
                    if (dgSolicitudes.Selected.Rows.Count == 1)
                    {
                        idCoaseguradora = Convert.ToInt32(dgSolicitudes.ActiveRow.Cells["ID"].Text);
                        RechazoSolicitud();
                        coaseguradorasTableAdapter.FillByEnSolicitud(this.catalogosGral.Coaseguradoras);
                        dgSolicitudes.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                    }
                    break;

            }

        }
        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
    }
}
