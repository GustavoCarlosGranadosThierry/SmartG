using Infragistics.Documents.Excel;
using Infragistics.Win;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Operaciones.CreditControl.Cobranza
{
    public partial class Brokerage : Form
    {
        int IDBroker;
        string NomBroker;
        bool isMoral = false;

        void CambiarLayout(int modo)
        {
            // 0 - seleccion Broker
            // 1 - Detalle Broker

            IDBroker = 0;
            ToolsBarBrokerage.Ribbon.Tabs[0].Groups["rgbEdoCuenta"].Visible = false;
            ToolsBarBrokerage.Ribbon.Tabs[0].Groups["rgbSeleccion"].Visible = false;
            tabBrokerage.Tabs[0].Visible = false;
            tabBrokerage.Tabs[1].Visible = false;
            tabBrokerage.Tabs[2].Visible = false;

            switch (modo)
            {
                case 0:
                    ToolsBarBrokerage.Ribbon.Tabs[0].Groups["rgbSeleccion"].Visible = true;
                    tabBrokerage.Tabs[0].Visible = true;
                    break;

                case 1:
                    ToolsBarBrokerage.Ribbon.Tabs[0].Groups["rgbEdoCuenta"].Visible = true;
                    tabBrokerage.Tabs[1].Visible = true;
                    tabBrokerage.Tabs[2].Visible = true;
                    break;
            }
        }

        void CargarDataSets()
        {
            cbParametro.SelectedIndex = 0;
            this.brokersTableAdapter.Fill(this.cobranza.Brokers);
            this.liIncMonedaTableAdapter.Fill(this.liabilityInc.LiIncMoneda);
        }

        void CargarDataBroker()
        {
            cbMonedaAplicar.SelectedIndex = 0;
            DateTime p1;
            DateTime p2;

            if (cbAño.Text == "Todos")
            {
                p1 = new DateTime(1900, 1, 1);
                p2 = new DateTime(2555, 12, 31);
                try { this.primaIngresadaTableAdapter.FillByID(this.cobranza.PrimaIngresada, IDBroker, p1, p2); } catch { }
                try { this.ordenesPagoTableAdapter.FillByBroker(this.cobranza1.OrdenesPago, p1, p2, 13, IDBroker); } catch { }
                try { this.ordenesPagoTableAdapter.FillByBroker(this.cobranza2.OrdenesPago, p1, p2, 12, IDBroker); } catch { }
            }
            else
            {
                if (cbMes.Text == "Todos")
                {
                    p1 = new DateTime(Convert.ToInt32(cbAño.Text), 1, 1);
                    p2 = new DateTime(Convert.ToInt32(cbAño.Text), 12, 31);
                    try { this.primaIngresadaTableAdapter.FillByID(this.cobranza.PrimaIngresada, IDBroker, p1, p2); } catch { }
                    try { this.ordenesPagoTableAdapter.FillByBroker(this.cobranza1.OrdenesPago, p1, p2, 13, IDBroker); } catch { }
                    try { this.ordenesPagoTableAdapter.FillByBroker(this.cobranza2.OrdenesPago, p1, p2, 12, IDBroker); } catch { }
                }
                else
                {
                    p1 = new DateTime(Convert.ToInt32(cbAño.Text), Convert.ToInt32(cbMes.Value), 1);
                    p2 = new DateTime(Convert.ToInt32(cbAño.Text), Convert.ToInt32(cbMes.Value), DateTime.DaysInMonth(Convert.ToInt32(cbAño.Text), Convert.ToInt32(cbMes.Value)));
                    try { this.primaIngresadaTableAdapter.FillByID(this.cobranza.PrimaIngresada, IDBroker, p1, p2); } catch { }
                    try { this.ordenesPagoTableAdapter.FillByBroker(this.cobranza1.OrdenesPago, p1, p2, 13, IDBroker); } catch { }
                    try { this.ordenesPagoTableAdapter.FillByBroker(this.cobranza2.OrdenesPago, p1, p2, 12, IDBroker); } catch { }
                }
            }
            if (this.cobranza.PrimaIngresada.Rows.Count == 0)
                MessageBox.Show("No hay registros", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgPrimaIngresada.Rows)
                item.Cells["MonedaAplicable"].Value = cbMonedaAplicar.Text;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgOrdenesPendientes.Rows)
                item.Cells["MonedaAplicable"].Value = cbMonedaAplicar.Text;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgOrdenesPagadas.Rows)
                item.Cells["MonedaAplicable"].Value = cbMonedaAplicar.Text;

            // Esconde columnas segun Moral o Fisica
            if (isMoral)
            {
                dgPrimaIngresada.DisplayLayout.Bands[0].Columns["Comision Total"].Hidden = false;
                dgPrimaIngresada.DisplayLayout.Bands[0].Columns["Comision con Ret"].Hidden = true;
                dgOrdenesPendientes.DisplayLayout.Bands[0].Columns["Comision Total"].Hidden = false;
                dgOrdenesPendientes.DisplayLayout.Bands[0].Columns["Comision Total (Ret)"].Hidden = true;
                dgOrdenesPagadas.DisplayLayout.Bands[0].Columns["Comision Total"].Hidden = false;
                dgOrdenesPagadas.DisplayLayout.Bands[0].Columns["Comision Total (Ret)"].Hidden = true;

            }
            else
            {
                dgPrimaIngresada.DisplayLayout.Bands[0].Columns["Comision Total"].Hidden = true;
                dgPrimaIngresada.DisplayLayout.Bands[0].Columns["Comision con Ret"].Hidden = false;
                dgOrdenesPendientes.DisplayLayout.Bands[0].Columns["Comision Total"].Hidden = true;
                dgOrdenesPendientes.DisplayLayout.Bands[0].Columns["Comision Total (Ret)"].Hidden = false;
                dgOrdenesPagadas.DisplayLayout.Bands[0].Columns["Comision Total"].Hidden = true;
                dgOrdenesPagadas.DisplayLayout.Bands[0].Columns["Comision Total (Ret)"].Hidden = false;
            }

            dgPrimaIngresada.DisplayLayout.Bands[0].Columns["ISR Ret"].Hidden = isMoral;
            dgPrimaIngresada.DisplayLayout.Bands[0].Columns["IVA Ret"].Hidden = isMoral;
            dgPrimaIngresada.DisplayLayout.Bands[0].Columns["Total Ret"].Hidden = isMoral;
            dgOrdenesPendientes.DisplayLayout.Bands[0].Columns["ISR Ret"].Hidden = isMoral;
            dgOrdenesPendientes.DisplayLayout.Bands[0].Columns["IVA Ret"].Hidden = isMoral;
            dgOrdenesPendientes.DisplayLayout.Bands[0].Columns["Total Ret"].Hidden = isMoral;
            dgOrdenesPagadas.DisplayLayout.Bands[0].Columns["ISR Ret"].Hidden = isMoral;
            dgOrdenesPagadas.DisplayLayout.Bands[0].Columns["IVA Ret"].Hidden = isMoral;
            dgOrdenesPagadas.DisplayLayout.Bands[0].Columns["Total Ret"].Hidden = isMoral;

        }

        void GenerarReporte()
        {
            string rutaFile = "";
            string Broker = saveFileDialog1.FileName = "Estado de Cuenta " + DateTime.Now.ToString("yyyy-MM-dd") + " " + NomBroker + ".xlsx";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rutaFile = saveFileDialog1.FileName;
                try
                {
                    Workbook workbook = new Workbook(WorkbookFormat.Excel2007);

                    Worksheet sheetReportes = workbook.Worksheets.Add("Prima Ingresada");
                    ultraGridExcelExporter1.Export(dgPrimaIngresada, sheetReportes);

                    Worksheet sheetEmails = workbook.Worksheets.Add("Comisiones Pendientes");
                    ultraGridExcelExporter1.Export(dgOrdenesPendientes, sheetEmails);

                    Worksheet sheetErrores = workbook.Worksheets.Add("Comisiones Pagadas");
                    ultraGridExcelExporter1.Export(dgOrdenesPagadas, sheetErrores);

                    workbook.Save(rutaFile);

                    // Carga los encabezados
                    Extensiones.Reportes.EditarEncabezados(rutaFile, DateTime.Now, DateTime.Now, true, "Estado de Cuenta " + NomBroker, 10);
                    System.Diagnostics.Process.Start(rutaFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        void IngresarPago()
        {
            MessageBox.Show("Development");
        }

        public Brokerage()
        {
            InitializeComponent();
        }
        private void Brokerage_Load(object sender, EventArgs e)
        {
            CambiarLayout(0);
            CargarDataSets();

            string[] Meses = { "Todos", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            string[] Años = { "Todos", "2017", "2018", "2019" };

            for (int i = 0; i < Meses.Length; i++)
            {
                ValueListItem vl1 = new ValueListItem(i, Meses[i]);
                cbMes.Items.Add(vl1);
            }
            for (int i = 0; i < Años.Length; i++)
            {
                ValueListItem vl1 = new ValueListItem(Años[i], Años[i].ToString());
                cbAño.Items.Add(vl1);
            }
            cbAño.SelectedIndex = 0;
            cbMes.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            switch (cbParametro.SelectedIndex)
            {
                case 0: //Broker
                    this.brokersTableAdapter.FillByBrokerName(this.cobranza.Brokers, txtBusqueda.Text);
                    break;
                case 1: //rfc
                    this.brokersTableAdapter.FillByRFC(this.cobranza.Brokers, txtBusqueda.Text);
                    break;
                case 2: //NameCode
                    this.brokersTableAdapter.FillByBrokerCode(this.cobranza.Brokers, txtBusqueda.Text);
                    break;
            }
            if (this.cobranza.Brokers.Rows.Count == 0)
                MessageBox.Show("No hay registros", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void dgBaseBrokers_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            CambiarLayout(1);
            IDBroker = Convert.ToInt32(dgBaseBrokers.ActiveRow.Cells["ID"].Value);
            dbSmartGDataContext db = new dbSmartGDataContext();
            NomBroker = (from x in db.Brokers where x.ID == IDBroker select x.Broker1).SingleOrDefault();
            string RFC = (from x in db.Brokers where x.ID == IDBroker select x.RFC).SingleOrDefault();
            if (RFC.Length == 13)
                isMoral = false;
            else
                isMoral = true;
            ToolsBarBrokerage.Tools["lbBrokerSerleccionado"].SharedProps.Caption = "Broker: " + NomBroker;
            CargarDataBroker();
        }

        private void ToolsBarBrokerage_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btnSeleccionarBroker":
                    dgBaseBrokers_DoubleClickRow(null, null);
                    break;

                case "btnLimpiarBusqueda":
                    CargarDataSets();
                    break;

                case "btnConsultarOtroBroker":
                    IDBroker = 0;
                    CambiarLayout(0);
                    CargarDataSets();
                    break;

                case "btnGenerarEdoCuenta":
                    GenerarReporte();
                    break;

                case "btnIngresarPago":
                    IngresarPago();
                    break;
            }
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar_Click(null, null);
        }

        private void cbAño_ValueChanged(object sender, EventArgs e)
        {
            if (cbAño.Text == "Todos")
            {
                cbMes.Enabled = false;
                cbMes.SelectedIndex = 0;
            }
            else
                cbMes.Enabled = true;

            if (IDBroker != 0)
            {
                CargarDataBroker();
            }
        }

        private void cbMes_ValueChanged(object sender, EventArgs e)
        {
            if (IDBroker != 0)
            {
                CargarDataBroker();
            }
        }

        private void cbMonedaAplicar_ValueChanged(object sender, EventArgs e)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgPrimaIngresada.Rows)
            {
                item.Cells["MonedaAplicable"].Value = cbMonedaAplicar.Text;
            }
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgOrdenesPendientes.Rows)
            {
                item.Cells["MonedaAplicable"].Value = cbMonedaAplicar.Text;
            }
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgOrdenesPagadas.Rows)
            {
                item.Cells["MonedaAplicable"].Value = cbMonedaAplicar.Text;
            }

            Mon1.Text = cbMonedaAplicar.Text;
            Mon2.Text = cbMonedaAplicar.Text;
            Mon3.Text = cbMonedaAplicar.Text;
            Mon4.Text = cbMonedaAplicar.Text;
        }
    }
}
