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
    public partial class MainCoberturasSubCoberturas : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region Variables
        int tabAnterior = 1;
        public static int idElemento = 0;
        #endregion


        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region Metodos programados
        void iniciarDatos()
        {
            // iniciamos las coberturas activas
            subCoberturasTableAdapter.FillByActivos(catalogosGral.SubCoberturas);
            // iniciamos las subcoberturas activas
            coberturasTableAdapter.FillByActivos(catalogosGral.Coberturas);
        }
        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region eventos Form

        public MainCoberturasSubCoberturas()
        {
            InitializeComponent();
        }

        private void MainCoberturasSubCoberturas_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this, tabControlMainBrokers, ToolsBarMainCoberturas);
            iniciarDatos();
        }

        private void tabControlMainBrokers_SelectedTabChanging(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangingEventArgs e)
        {
            if (tabAnterior == 0)
            {
                subCoberturasTableAdapter.FillByActivos(catalogosGral.SubCoberturas);
                dgSubCoberturas.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
            else
            {
                coberturasTableAdapter.FillByActivos(catalogosGral.Coberturas);
                dgCoberturas.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
            tabAnterior = tabControlMainBrokers.ActiveTab.Index;
        }

        private void ToolsBarMainCoberturas_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btnAgregarCobertura":
                    if (tabControlMainBrokers.SelectedTab.Index == 0)
                    {
                        Catalogos.Emision.agregarEditarCoberturas frmAgregar = new agregarEditarCoberturas();
                        if (frmAgregar.ShowDialog() == DialogResult.OK)
                        {
                            coberturasTableAdapter.FillByActivos(catalogosGral.Coberturas);
                            dgCoberturas.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                        }
                    }
                    else
                    {
                        Catalogos.Emision.agregarEditarSubCobertura frmAgregar = new agregarEditarSubCobertura();
                        if (frmAgregar.ShowDialog() == DialogResult.OK)
                        {
                            subCoberturasTableAdapter.FillByActivos(catalogosGral.SubCoberturas);
                            dgSubCoberturas.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                        }
                    }
                    break;

                case "btnEditarCobertura":
                    if (tabControlMainBrokers.SelectedTab.Index == 0)
                    {
                        if (dgCoberturas.Selected.Rows.Count == 1)
                        {
                            Catalogos.Emision.agregarEditarCoberturas frmEditar = new agregarEditarCoberturas(Convert.ToInt32(dgCoberturas.ActiveRow.Cells["ID"].Text));
                            if (frmEditar.ShowDialog() == DialogResult.OK)
                            {
                                coberturasTableAdapter.FillByActivos(catalogosGral.Coberturas);
                                dgCoberturas.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                            }
                        }
                    }
                    else
                    {
                        if (dgSubCoberturas.Selected.Rows.Count == 1)
                        {
                            Catalogos.Emision.agregarEditarSubCobertura frmEditar = new agregarEditarSubCobertura(Convert.ToInt32(dgSubCoberturas.ActiveRow.Cells["ID"].Text));
                            if (frmEditar.ShowDialog() == DialogResult.OK)
                            {
                                subCoberturasTableAdapter.FillByActivos(catalogosGral.SubCoberturas);
                                dgSubCoberturas.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                            }
                        }
                    }
                    break;

                case "btnEliminarCobertura":
                    if (tabControlMainBrokers.SelectedTab.Index == 0)
                    {
                        if (dgCoberturas.Selected.Rows.Count == 1)
                        {
                            if (MessageBox.Show("¿Deseas eliminar la cobertura seleccionada?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                dbSmartGDataContext db = new dbSmartGDataContext();
                                Coberturas aBorrar = (from x in db.Coberturas where x.ID == Convert.ToInt32(dgCoberturas.ActiveRow.Cells["ID"].Text) select x).SingleOrDefault();
                                aBorrar.Eliminado = true;
                                db.SubmitChanges();
                                MessageBox.Show("Cobertura eliminada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                coberturasTableAdapter.FillByActivos(catalogosGral.Coberturas);
                                dgCoberturas.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                            }
                        }
                    }
                    else
                    {
                        if (dgSubCoberturas.Selected.Rows.Count == 1)
                        {
                            if (MessageBox.Show("¿Deseas eliminar la Subcobertura seleccionada?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                dbSmartGDataContext db = new dbSmartGDataContext();
                                SubCoberturas aBorrar = (from x in db.SubCoberturas where x.ID == Convert.ToInt32(dgSubCoberturas.ActiveRow.Cells["ID"].Text) select x).SingleOrDefault();
                                aBorrar.Eliminado = true;
                                db.SubmitChanges();
                                MessageBox.Show("SubCobertura eliminada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                subCoberturasTableAdapter.FillByActivos(catalogosGral.SubCoberturas);
                                dgSubCoberturas.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                            }
                        }
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
