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
    public partial class MainReaseguradoras : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region Variables
        int tabAnterior = 1;
        public static int idReaseguradora = 0;

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region Metodos programados
        void autorizarReaseguradora()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            if (MessageBox.Show("¿Deseas autorizar esta Reaseguradora en este momento?", "Notificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int status = (from y in db.StatusFacturacions where y.Status == "Solicitado" select y.ID).SingleOrDefault();
                ReaseguradorasSolicitudes solicitudActiva = (from x in db.ReaseguradorasSolicitudes where x.Reaseguradora == idReaseguradora && x.Status == status select x).SingleOrDefault();
                if (solicitudActiva != null)
                {
                    solicitudActiva.Status = (from y in db.StatusFacturacions where y.Status == "Aplicado" select y.ID).SingleOrDefault();
                    solicitudActiva.FechaAtencion = DateTime.Now;
                    solicitudActiva.UsuarioAtencion = Program.Globals.UserID;
                    Reaseguradoras reaseguAuto = (from x in db.Reaseguradoras where x.ID == idReaseguradora select x).SingleOrDefault();
                    reaseguAuto.Aprobado = true;
                    db.SubmitChanges();
                }
            }
        }

        void iniciarDatos()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            int idPerfil = (from x in db.Perfiles where x.KeyName == "tabSolicitudesRease" select x.ID).SingleOrDefault();
            if (idPerfil != 0)
            {
                int perfil = (from x in db.UsuariosPerfils where x.Usuario == Program.Globals.UserID && x.Perfil == idPerfil select x.ID).SingleOrDefault();
                if (perfil != 0)
                {
                    tabControlMainBrokers.Tabs[1].Visible = true;
                }
            }
            reaseguradorasTableAdapter.FillByActivos(this.catalogosGral.Reaseguradoras);
            dgReaseguradoras.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
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
            int idSolicitud = (from x in db.ReaseguradorasSolicitudes where x.Reaseguradora == idReaseguradora select x.ID).SingleOrDefault();
            Reaseguradoras rechazadoRease = (from x in db.Reaseguradoras where x.ID == idReaseguradora select x).SingleOrDefault();
            rechazadoRease.Aprobado = false;
            ReaseguradorasSolicitudes solicitudActiva = (from x in db.ReaseguradorasSolicitudes where x.ID == idSolicitud select x).SingleOrDefault();
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
        #region eventos Form
        public MainReaseguradoras()
        {
            InitializeComponent();
        }

        private void MainReaseguradoras_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this, tabControlMainBrokers, ToolsbarsReaseguradoras);
            iniciarDatos();
        }

        private void ToolsbarsReaseguradoras_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btnAgregarRease":
                    Catalogos.Emision.agregarEditarReaseguradoras frmAgregar = new agregarEditarReaseguradoras();
                    if (frmAgregar.ShowDialog() == DialogResult.OK)
                    {
                        dbSmartGDataContext db = new dbSmartGDataContext();

                        if (tabControlMainBrokers.Tabs[1].Visible == true)
                        {
                            autorizarReaseguradora();
                            reaseguradorasTableAdapter.FillByActivos(this.catalogosGral.Reaseguradoras);
                            dgReaseguradoras.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                        }
                        else
                        {
                            MessageBox.Show("Reasegurador Solicitado y en espera de su autorización", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    break;

                case "btnEditarRease":
                    if (dgReaseguradoras.Selected.Rows.Count == 1)
                    {
                        Catalogos.Emision.agregarEditarReaseguradoras frmEditar = new agregarEditarReaseguradoras(Convert.ToInt32(dgReaseguradoras.ActiveRow.Cells["ID"].Text));
                        if (frmEditar.ShowDialog() == DialogResult.OK)
                        {
                            dbSmartGDataContext db = new dbSmartGDataContext();

                            if (tabControlMainBrokers.Tabs[1].Visible == true)
                            {
                                autorizarReaseguradora();
                                reaseguradorasTableAdapter.FillByActivos(this.catalogosGral.Reaseguradoras);
                                dgReaseguradoras.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                            }
                            else
                            {
                                MessageBox.Show("Reasegurador Solicitado y en espera de su autorización", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                    }
                    break;

                case "btnEliminarRease":
                    if (dgReaseguradoras.Selected.Rows.Count == 1)
                    {
                        if (MessageBox.Show("¿Deseas eliminar al reasegurador seleccionado?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            dbSmartGDataContext db = new dbSmartGDataContext();
                            Reaseguradoras aEliminar = (from x in db.Reaseguradoras where x.ID == Convert.ToInt32(dgReaseguradoras.ActiveRow.Cells["ID"].Text) select x).SingleOrDefault();
                            aEliminar.Eliminado = true;
                            aEliminar.Aprobado = false;
                            db.SubmitChanges();
                            MessageBox.Show("Reasegurador eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            reaseguradorasTableAdapter.FillByActivos(this.catalogosGral.Reaseguradoras);
                            dgReaseguradoras.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                        }
                    }
                    break;

                case "btnAutorizaRease":
                    if (dgSolicitudes.Selected.Rows.Count == 1)
                    {
                        idReaseguradora = Convert.ToInt32(dgSolicitudes.ActiveRow.Cells["ID"].Text);
                        autorizarReaseguradora();
                        reaseguradorasTableAdapter.FillByEnSolicitud(this.catalogosGral.Reaseguradoras);
                        dgSolicitudes.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                    }
                    break;

                case "btnCancelaRease":
                    if (dgSolicitudes.Selected.Rows.Count == 1)
                    {
                        idReaseguradora = Convert.ToInt32(dgSolicitudes.ActiveRow.Cells["ID"].Text);
                        RechazoSolicitud();
                        reaseguradorasTableAdapter.FillByEnSolicitud(this.catalogosGral.Reaseguradoras);
                        dgSolicitudes.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                    }
                    break;
            }

        }

        private void tabControlMainBrokers_SelectedTabChanging(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangingEventArgs e)
        {
            if (tabAnterior == 0)
            {
                ToolsbarsReaseguradoras.Ribbon.Tabs[0].Groups[0].Tools[0].SharedProps.Visible = false;
                ToolsbarsReaseguradoras.Ribbon.Tabs[0].Groups[0].Tools[1].SharedProps.Visible = false;
                ToolsbarsReaseguradoras.Ribbon.Tabs[0].Groups[0].Tools[2].SharedProps.Visible = false;
                ToolsbarsReaseguradoras.Ribbon.Tabs[0].Groups[0].Tools[3].SharedProps.Visible = true;
                ToolsbarsReaseguradoras.Ribbon.Tabs[0].Groups[0].Tools[4].SharedProps.Visible = true;
                reaseguradorasTableAdapter.FillByEnSolicitud(this.catalogosGral.Reaseguradoras);
                dgSolicitudes.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
            else
            {
                ToolsbarsReaseguradoras.Ribbon.Tabs[0].Groups[0].Tools[0].SharedProps.Visible = true;
                ToolsbarsReaseguradoras.Ribbon.Tabs[0].Groups[0].Tools[1].SharedProps.Visible = true;
                ToolsbarsReaseguradoras.Ribbon.Tabs[0].Groups[0].Tools[2].SharedProps.Visible = true;
                ToolsbarsReaseguradoras.Ribbon.Tabs[0].Groups[0].Tools[3].SharedProps.Visible = false;
                ToolsbarsReaseguradoras.Ribbon.Tabs[0].Groups[0].Tools[4].SharedProps.Visible = false;
                reaseguradorasTableAdapter.FillByActivos(this.catalogosGral.Reaseguradoras);
                dgReaseguradoras.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
            tabAnterior = tabControlMainBrokers.ActiveTab.Index;
        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************

    }
}
