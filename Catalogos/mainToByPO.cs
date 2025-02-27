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
    public partial class mainToByPO : Form
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
        #region variables
        DataTable dtLNPO;
        DataTable dtLNTB;
        int idPosPO;
        int idPosLNPO;
        string tmpPO;
        int idTmp = -1;
        bool bloqueo = false;
        int elementoEditar = 0;
        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region MetodosProgramados
        void iniciarDatos()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            // llenar los ToB
            toBTableAdapter.FillByActivos(this.catalogosGral.ToB);
            // llenar los PO
            producingOfficeTableAdapter.FillByActivos(this.catalogosGral.ProducingOffice);
            // llenar las lineas de negocios
            lineaNegociosTableAdapter.Fill(this.catalogosGral.LineaNegocios);
        }

        void desbloquearPO()
        {
            bloqueo = false;
            dgPOLN.Enabled = true;
            grpLNMain.Visible = false;
            ToolbarsManagerTOBPO.Ribbon.Tabs[0].Groups[1].Tools["btnGuardarCambios"].SharedProps.Enabled = false;
            ToolbarsManagerTOBPO.Ribbon.Tabs[0].Groups[1].Tools["btnCancelarCambios"].SharedProps.Enabled = false;
        }

        void desbloquearToB()
        {
            bloqueo = false;
            dgLNPOTOB.Enabled = true;
            btnSeleccionarLN.Enabled = true;
            grpLNPOTOB.Visible = false;
            grpAsignarToB.Visible = false;
            cbToB.Text = "";
            cbLNToB.Text = "";
            ToolbarsManagerTOBPO.Ribbon.Tabs[0].Groups[1].Tools["btnGuardarCambios"].SharedProps.Enabled = false;
            ToolbarsManagerTOBPO.Ribbon.Tabs[0].Groups[1].Tools["btnCancelarCambios"].SharedProps.Enabled = false;
        }

        #endregion
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region EventosForm
        public mainToByPO()
        {
            InitializeComponent();
        }

        private void mainToByPO_Load(object sender, EventArgs e)
        {
            iniciarDatos();
        }

        private void dgPOLN_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (!bloqueo)
            {
                if (dgPOLN.Selected.Rows.Count == 1)
                {
                    grpLNMain.Visible = true;
                    // llenamos los lnpo con el po seleccionado
                    dtLNPO = new DataTable();
                    dtLNPO = lNPOTableAdapter.GetDataByPO(Convert.ToInt32(dgPOLN.ActiveRow.Cells["ID"].Text));
                    dgLNPO.DataSource = dtLNPO;
                    idPosPO = Convert.ToInt32(dgPOLN.ActiveRow.Cells["ID"].Text);
                    tmpPO = dgPOLN.ActiveRow.Cells["ProducingOffice"].Text;
                    #region formatear Grid
                    dgLNPO.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
                    dgLNPO.DisplayLayout.Bands[0].Columns["LineaNegocios"].Hidden = true;
                    dgLNPO.DisplayLayout.Bands[0].Columns["ProducingOffice"].Hidden = true;
                    dgLNPO.DisplayLayout.Bands[0].Columns["Eliminado"].Hidden = true;
                    #endregion
                    ToolbarsManagerTOBPO.Ribbon.Tabs[0].Groups[1].Tools["btnGuardarCambios"].SharedProps.Enabled = true;
                    ToolbarsManagerTOBPO.Ribbon.Tabs[0].Groups[1].Tools["btnCancelarCambios"].SharedProps.Enabled = true;
                    dgPOLN.Enabled = false;
                    bloqueo = true;
                    elementoEditar = 1;
                }
            }
            else
            {
                MessageBox.Show("Solo puede editar un elemento a la vez (PO-Linea de negocios o ToB-PO)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToolbarsManagerTOBPO_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btnAgregarElemento":

                    break;

                case "btnModificarElemento":

                    break;

                case "btnEliminarElemento":

                    break;

                case "btnGuardarCambios":
                    switch (elementoEditar)
                    {
                        case 1:
                            if (MessageBox.Show("Se guardarán los cambios para el PO: " + tmpPO + ", ¿Deseas continuar?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                            {
                                dbSmartGDataContext db = new dbSmartGDataContext();
                                LNPO aGuardar;
                                LNPO[] enDB = (from x in db.LNPO where x.ProducingOffice == idPosPO select x).ToArray();
                                bool encontro = false;

                                for (int j = 0; j < enDB.Count(); j++)
                                {
                                    for (int i = 0; i < dgLNPO.Rows.Count; i++)
                                    {
                                        if ((Convert.ToInt32(dgLNPO.Rows[i].Cells["ProducingOffice"].Text) == enDB[j].ProducingOffice) && (Convert.ToInt32(dgLNPO.Rows[i].Cells["LineaNegocios"].Text) == enDB[j].LineaNegocios))
                                        {
                                            encontro = true;
                                        }
                                    }

                                    if (!encontro)
                                    {
                                        enDB[j].Eliminado = true;
                                        db.SubmitChanges();
                                    }
                                    encontro = false;
                                }

                                for (int i = 0; i < dgLNPO.Rows.Count; i++)
                                {
                                    for (int j = 0; j < enDB.Count(); j++)
                                    {
                                        if ((Convert.ToInt32(dgLNPO.Rows[i].Cells["ProducingOffice"].Text) == enDB[j].ProducingOffice) && (Convert.ToInt32(dgLNPO.Rows[i].Cells["LineaNegocios"].Text) == enDB[j].LineaNegocios))
                                        {
                                            if (enDB[j].Eliminado == true)
                                            {
                                                enDB[j].Eliminado = false;
                                                db.SubmitChanges();
                                            }
                                            encontro = true;
                                        }
                                    }

                                    if (!encontro)
                                    {
                                        aGuardar = new LNPO();
                                        aGuardar.LineaNegocios = Convert.ToInt32(dgLNPO.Rows[i].Cells["LineaNegocios"].Text);
                                        aGuardar.ProducingOffice = Convert.ToInt32(dgLNPO.Rows[i].Cells["ProducingOffice"].Text);
                                        aGuardar.Eliminado = false;
                                        db.LNPO.InsertOnSubmit(aGuardar);
                                        db.SubmitChanges();
                                    }
                                    encontro = false;
                                }

                                MessageBox.Show("Registros actualizados con éxito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                desbloquearPO();
                            }
                            else
                            {
                                if (MessageBox.Show("¿Deseas cancelar los cambios?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                                {
                                    desbloquearPO();
                                }
                            }
                            break;
                        case 2:
                            if (MessageBox.Show("Se guardarán los cambios para el PO: " + lbNombrePO.Text + ", ¿Deseas continuar?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                            {
                                dbSmartGDataContext db = new dbSmartGDataContext();
                                LNTB aGuardar;
                                LNTB[] enDB = (from x in db.LNTB where x.LNPO == idPosLNPO select x).ToArray();
                                bool encontro = false;
                                for (int j = 0; j < enDB.Count(); j++)
                                {
                                    for (int i = 0; i < dgLNTB.Rows.Count; i++)
                                    {
                                        if ((Convert.ToInt32(dgLNTB.Rows[i].Cells["LNPO"].Text) == enDB[j].LNPO) && (Convert.ToInt32(dgLNTB.Rows[i].Cells["ToB"].Text) == enDB[j].ToB))
                                        {
                                            encontro = true;
                                        }
                                    }

                                    if (!encontro)
                                    {
                                        enDB[j].Eliminado = true;
                                        db.SubmitChanges();
                                    }
                                    encontro = false;
                                }

                                for (int i = 0; i < dgLNTB.Rows.Count; i++)
                                {
                                    for (int j = 0; j < enDB.Count(); j++)
                                    {
                                        if ((Convert.ToInt32(dgLNTB.Rows[i].Cells["LNPO"].Text) == enDB[j].LNPO) && (Convert.ToInt32(dgLNTB.Rows[i].Cells["ToB"].Text) == enDB[j].ToB))
                                        {
                                            if (enDB[j].Eliminado == true)
                                            {
                                                enDB[j].Eliminado = false;
                                                db.SubmitChanges();
                                            }
                                            encontro = true;
                                        }
                                    }

                                    if (!encontro)
                                    {
                                        aGuardar = new LNTB();
                                        aGuardar.LNPO = Convert.ToInt32(dgLNTB.Rows[i].Cells["LNPO"].Text);
                                        aGuardar.ToB = Convert.ToInt32(dgLNTB.Rows[i].Cells["ToB"].Text);
                                        aGuardar.Eliminado = false;
                                        db.LNTB.InsertOnSubmit(aGuardar);
                                        db.SubmitChanges();
                                    }
                                    encontro = false;
                                }

                                MessageBox.Show("Registros actualizados con éxito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                desbloquearToB();
                            }
                            else
                            {
                                if (MessageBox.Show("¿Deseas cancelar los cambios?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                                {
                                    desbloquearToB();
                                }
                            }
                            break;
                    }
                    break;

                case "btnCancelarCambios":
                    switch (elementoEditar)
                    {
                        case 1:
                            desbloquearPO();
                            break;
                        case 2:
                            desbloquearToB();
                            break;
                    }
                    break;

            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbLineaNegocios.Text != "")
            {
                for (int i = 0; i < dgLNPO.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dgLNPO.Rows[i].Cells["LineaNegocios"].Text) == Convert.ToInt32(cbLineaNegocios.Value))
                    {
                        MessageBox.Show("La línea de negocios ya está asignada a este Producing Office", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cbLineaNegocios.Text = "";
                        return;
                    }
                }
                dtLNPO.Rows.Add(idTmp, Convert.ToInt32(cbLineaNegocios.Value), idPosPO, false, tmpPO, cbLineaNegocios.Text);
                cbLineaNegocios.Text = "";
                idTmp--;
            }
        }

        private void validarCB(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            Infragistics.Win.UltraWinEditors.UltraComboEditor cb = (Infragistics.Win.UltraWinEditors.UltraComboEditor)sender;

            if (cb.Items.Count > 0 && cb.Visible == true)
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

        private void btnSeleccionarLN_Click(object sender, EventArgs e)
        {
            if (cbLNToB.Text != "")
            {
                dtLNPO = lNPOTableAdapter.GetDataByLN(Convert.ToInt32(cbLNToB.Value));
                dgLNPOTOB.DataSource = dtLNPO;
                #region formatear Grid
                dgLNPOTOB.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
                dgLNPOTOB.DisplayLayout.Bands[0].Columns["LineaNegocios"].Hidden = true;
                dgLNPOTOB.DisplayLayout.Bands[0].Columns["ProducingOffice"].Hidden = true;
                dgLNPOTOB.DisplayLayout.Bands[0].Columns["Eliminado"].Hidden = true;
                #endregion
                grpLNPOTOB.Visible = true;
            }
        }

        private void dgLNPOTOB_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (!bloqueo)
            {
                if (dgLNPOTOB.Selected.Rows.Count == 1)
                {
                    dgLNPOTOB.Enabled = false;
                    btnSeleccionarLN.Enabled = false;
                    grpAsignarToB.Visible = true;
                    lbNombrePO.Text = dgLNPOTOB.ActiveRow.Cells["Producing Office"].Text;
                    dtLNTB = new DataTable();
                    idPosLNPO = Convert.ToInt32(dgLNPOTOB.ActiveRow.Cells["ID"].Text);
                    dtLNTB = lNTBTableAdapter.GetDataByLNPO(idPosLNPO);
                    dgLNTB.DataSource = dtLNTB;
                    ToolbarsManagerTOBPO.Ribbon.Tabs[0].Groups[1].Tools["btnGuardarCambios"].SharedProps.Enabled = true;
                    ToolbarsManagerTOBPO.Ribbon.Tabs[0].Groups[1].Tools["btnCancelarCambios"].SharedProps.Enabled = true;
                    bloqueo = true;
                    elementoEditar = 2;
                    #region formatear Grid
                    dgLNTB.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
                    dgLNTB.DisplayLayout.Bands[0].Columns["LNPO"].Hidden = true;
                    dgLNTB.DisplayLayout.Bands[0].Columns["ToB"].Hidden = true;
                    dgLNTB.DisplayLayout.Bands[0].Columns["Eliminado"].Hidden = true;
                    #endregion
                }
            }
            else
            {
                MessageBox.Show("Solo puede editar un elemento a la vez (PO-Linea de negocios o ToB-PO)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarTOB_Click(object sender, EventArgs e)
        {
            if (cbToB.Text != "")
            {
                for (int i = 0; i < dgLNTB.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dgLNTB.Rows[i].Cells["ToB"].Text) == Convert.ToInt32(cbToB.Value))
                    {
                        MessageBox.Show("El Trade of Business ya está asignado al Producing Office", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cbToB.Text = "";
                        return;
                    }
                }
                dtLNTB.Rows.Add(idTmp, idPosLNPO, Convert.ToInt32(cbToB.Value),false, cbToB.Text);
                cbToB.Text = "";
                idTmp--;
            }
        }

        private void dgLNPO_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
        }

        private void dgLNTB_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
    }
}
