using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Operaciones.Emision
{
    public partial class BusquedaPolizas : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // nombres y valores de todos los objetos que se encuentran en el formulario



        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region Variables Generales
        int status;
        DataTable dtResultados;
        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region Métodos programados
        void buscarPolizas(string Filtro)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            int tipoBusqueda = 0;
            //dtResultados.Rows.Clear();

            //Todas
            if (cbLineaNegocios.Text == "Todas")
                tipoBusqueda = 0;
            else
                tipoBusqueda = (from x in db.LineaNegocios where x.LineaNegocios1 == cbLineaNegocios.Text select x.ID).SingleOrDefault();

            if (tipoBusqueda == 0)
            {
                switch (Filtro)
                {
                    case "Asegurado":
                        dtResultados = busquedaPolizaTableAdapter.GetDataByCliente(status, Convert.ToInt32(cbParaFiltros.Value));
                        dgBusquedaPolizas.DataSource = dtResultados;
                        break;

                    case "Broker":
                        dtResultados = busquedaPolizaTableAdapter.GetDataByBroker(status, Convert.ToInt32(cbParaFiltros.Value));
                        dgBusquedaPolizas.DataSource = dtResultados;
                        break;

                    case "Poliza ES":
                        dtResultados = busquedaPolizaTableAdapter.GetDataByPolizaES(status, txtBusqueda.Text);
                        dgBusquedaPolizas.DataSource = dtResultados;
                        break;

                    case "Poliza MX":
                        dtResultados = busquedaPolizaTableAdapter.GetDataByPolizaMX(status, txtBusqueda.Text);
                        dgBusquedaPolizas.DataSource = dtResultados;
                        break;

                    case "Usuario":
                        dtResultados = busquedaPolizaTableAdapter.GetDataByPAM(status, Convert.ToInt32(cbParaFiltros.Value));
                        dgBusquedaPolizas.DataSource = dtResultados;
                        break;
                }
            }
            else
            {
                switch (Filtro)
                {
                    case "Asegurado":
                        dtResultados = busquedaPolizaTableAdapter.GetDataByClienteLN(status, Convert.ToInt32(cbParaFiltros.Value), tipoBusqueda);
                        dgBusquedaPolizas.DataSource = dtResultados;
                        break;

                    case "Broker":
                        dtResultados = busquedaPolizaTableAdapter.GetDataByBrokerLN(status, Convert.ToInt32(cbParaFiltros.Value), tipoBusqueda);
                        dgBusquedaPolizas.DataSource = dtResultados;
                        break;

                    case "Poliza ES":
                        dtResultados = busquedaPolizaTableAdapter.GetDataByPolizaESLN(status, txtBusqueda.Text, tipoBusqueda);
                        dgBusquedaPolizas.DataSource = dtResultados;
                        break;

                    case "Poliza MX":
                        dtResultados = busquedaPolizaTableAdapter.GetDataByPolizaMXLN(status, txtBusqueda.Text, tipoBusqueda);
                        dgBusquedaPolizas.DataSource = dtResultados;
                        break;

                    case "Usuario":
                        dtResultados = busquedaPolizaTableAdapter.GetDataByPAMLN(status, Convert.ToInt32(cbParaFiltros.Value), tipoBusqueda);
                        dgBusquedaPolizas.DataSource = dtResultados;
                        break;
                }
            }

            if (dgBusquedaPolizas.Rows.Count > 0)
            {
                dgBusquedaPolizas.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                dgBusquedaPolizas.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
            }
        }

        void iniciarDatos()
        {
            // llenado de los brokers
            liIncBrokersTableAdapter.Fill(liabilityInc.LiIncBrokers);
            // llenado de los clientes
            liIncClientesTableAdapter.Fill(liabilityInc.LiIncClientes);
            // llenado de los usuarios (PAM)
            liIncUsuariosTableAdapter.Fill(liabilityInc.LiIncUsuarios);

            dbSmartGDataContext db = new dbSmartGDataContext();

            LineaNegocios[] lNeg = (from x in db.LineaNegocios select x).ToArray();
            for (int i = 0; i < lNeg.Count(); i++)
            {
                cbLineaNegocios.Items.Add(lNeg[i].ID, lNeg[i].LineaNegocios1);
            }
            cbLineaNegocios.Text = "Todas";
            cbFiltro.Text = "Poliza MX";
            if (status == 2)
            {
                lbTipoBusqueda.Text = "Continuar Póliza Guardada";
            }
            else if (status == 3)
            {
                lbTipoBusqueda.Text = "Crear un nuevo Endoso";
            }
        }

        #endregion


        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region Eventos del Form
        public BusquedaPolizas(int statusBusqueda = 0)
        {
            InitializeComponent();
            status = statusBusqueda;
        }

        private void BusquedaPolizas_Load(object sender, EventArgs e)
        {
            iniciarDatos();
        }

        private void ToolbarsManagerBusquedasP_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btnBuscar":  // búsqueda de pólizas
                    buscarPolizas(cbFiltro.Text);
                    break;

            }
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                buscarPolizas(cbFiltro.Text);
            }
        }

        private void dgBusquedaPolizas_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (dgBusquedaPolizas.Selected.Rows.Count == 1)
            {
                this.DialogResult = DialogResult.OK;
                Main.guardado = Convert.ToInt32(dgBusquedaPolizas.ActiveRow.Cells["ID"].Text.ToString());
                Main.lineaNegocios = dgBusquedaPolizas.ActiveRow.Cells["Linea de Negocios"].Text;
                this.Close();
            }
        }

        private void cbFiltro_ValueChanged(object sender, EventArgs e)
        {
            if (cbFiltro.Text == "Poliza MX" || cbFiltro.Text == "Poliza ES")
            {
                cbParaFiltros.Visible = false;
                txtBusqueda.Visible = true;
                ToolbarsManagerBusquedasP.Ribbon.Tabs[0].Groups[0].Tools[2].Control = txtBusqueda;
            }
            else
            {
                cbParaFiltros.Text = "";
                switch (cbFiltro.Text)
                {
                    case "Asegurado":
                        cbParaFiltros.DataSource = aseguradosBindingSource;
                        cbParaFiltros.DisplayMember = "Cliente";
                        cbParaFiltros.ValueMember = "ID";
                        break;
                    case "Broker":
                        cbParaFiltros.DataSource = brokersBindingSource;
                        cbParaFiltros.DisplayMember = "Broker";
                        cbParaFiltros.ValueMember = "ID";
                        break;
                    case "Usuario":
                        cbParaFiltros.DataSource = usuariosBindingSource;
                        cbParaFiltros.DisplayMember = "FullName";
                        cbParaFiltros.ValueMember = "ID";
                        break;
                }
                cbParaFiltros.Visible = true;
                txtBusqueda.Visible = false;
                ToolbarsManagerBusquedasP.Ribbon.Tabs[0].Groups[0].Tools[2].Control = cbParaFiltros;
            }
        }

        private void cbParaFiltros_Leave(object sender, EventArgs e)
        {
            if(cbParaFiltros.Value != null)
            {
                if (int.TryParse(cbParaFiltros.Value.ToString(), out int i))
                {
                    buscarPolizas(cbFiltro.Text);
                }
                else
                {
                    MessageBox.Show("Debes introducir un valor válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbParaFiltros_KeyDown(object sender, KeyEventArgs e)
       {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        #endregion

    }
}
