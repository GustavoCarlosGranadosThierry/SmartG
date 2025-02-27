using System;
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
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.DataVisualization;

namespace SmartG
{
    public partial class tmpImportador : Form
    {
        string rutaDocumentoImportar = "";
        DataTable dtUbicaciones = new DataTable();

        public tmpImportador()
        {
            InitializeComponent();
        }

        void importarExcel(int opcion)
        {
            try
            {
                if (opcion != 0)
                {
                    // abrimos el excel y copiamos todo al portapapeles
                }

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
                                    bool tipoDato = true;
                                    string tmp = pastedRowCells[i];
                                    tmp = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(tmp.ToLower());
                                    if (tmp == "Prima Neta" || tmp == "Límite Máximo de Resp.") tipoDato = false;
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
                dgDatosImportar.DataSource = dtUbicaciones;
                dgDatosImportar.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
            catch
            {
                MessageBox.Show("Error al importar, verifique que haya conexión a la base de datos y que se tenga acceso a la carpeta del sistema SmartG", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCargarExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog importarFile = new OpenFileDialog();
            importarFile.InitialDirectory = Directory.GetCurrentDirectory();
            importarFile.Filter = "Archivos Excel (*.xlsx)|*.xlsx";
            importarFile.FilterIndex = 1;
            importarFile.RestoreDirectory = true;

            if (importarFile.ShowDialog() == DialogResult.OK)
            {
                rutaDocumentoImportar = importarFile.FileName;

                #region cargarExcel
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(rutaDocumentoImportar);
                Excel.Worksheet workSheet = (Excel.Worksheet)xlWorkbook.Worksheets[1];
                Excel.Range last = workSheet.Cells.SpecialCells(Excel.Enums.XlCellType.xlCellTypeLastCell, Type.Missing);
                Excel.Range range = workSheet.get_Range("A1", last);
                range.Copy();
                importarExcel(0);
                xlApp.DisplayAlerts = false;
                xlWorkbook.Close();
                xlApp.Quit();
                xlApp.Dispose();
                #endregion
            }
        }

        private void dgDatosImportar_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {

            if (e.Row.Cells["Endosos"].Text == "P")
            {
                if (e.Row.Cells["Pólizas"].Text == "" || e.Row.Cells["Nombre"].Text == "" || e.Row.Cells["Ramo"].Text == "" || e.Row.Cells["De"].Text == ""
                || e.Row.Cells["A"].Text == "" || e.Row.Cells["Moneda"].Text == "" || e.Row.Cells["Forma pago"].Text == "" || e.Row.Cells["Prima Neta"].Text == "0" || e.Row.Cells["Límite Máximo de Resp."].Text == "0")
                {
                    e.Row.Appearance.BackColor = Color.Red;
                    e.Row.Appearance.ForeColor = Color.White;
                }
            }
            else
            {
                if (e.Row.Cells["Prima Neta"].Text == "0" && e.Row.Cells["Límite Máximo de Resp."].Text == "0")
                {
                    e.Row.Appearance.BackColor = Color.Red;
                    e.Row.Appearance.ForeColor = Color.White;
                }
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();

            LineaNegocios[] lobCatalogo = (from x in db.LineaNegocios select x).ToArray();
            FormaPago[] formasCatalogo = (from x in db.FormaPago select x).ToArray();
            Moneda[] monedaCatalogo = (from x in db.Monedas select x).ToArray();
            string tmpMX = "";
            bool validarConversion = true;
            int numP = 0;
            int idPoliza = 0;
            string tipoOperacion = "Nuevo Negocio";

            for (int i = 0; i < dgDatosImportar.Rows.Count; i++)
            {
                // reseteamos las variables de control
                validarConversion = true;
                numP = 0;
                idPoliza = 0;

                // tomamos un row del datagrid y lo metemos al grupo
                UltraGridGroupByRow grupoRows = dgDatosImportar.Rows[i] as UltraGridGroupByRow;
                if (grupoRows != null)
                {
                    // validamos si es nuevo negocio o renovacion
                    if (i != 0)
                    {
                        if (tmpMX.Substring(0,10) == grupoRows.Value.ToString().Substring(0,10))
                            tipoOperacion = "Renovación";
                        else
                            tipoOperacion = "Nuevo Negocio";
                    }

                    // barremos todos los hijitos de la fila
                    for (int j = 0; j < dgDatosImportar.Rows[i].ChildBands[0].Rows.Count; j++)
                    {
                        if (dgDatosImportar.Rows[i].ChildBands[0].Rows[j].Appearance.BackColor != Color.Red)
                        {
                            // validamos que se puedan convertir los datos de la póliza
                            #region Validaciones
                            if (!DateTime.TryParse(dgDatosImportar.Rows[i].ChildBands[0].Rows[j].Cells["De"].Text, out DateTime De))
                                validarConversion = false;
                            if (!DateTime.TryParse(dgDatosImportar.Rows[i].ChildBands[0].Rows[j].Cells["A"].Text, out DateTime A))
                                validarConversion = false;
                            if (!decimal.TryParse(dgDatosImportar.Rows[i].ChildBands[0].Rows[j].Cells["Límite Máximo de Resp."].Text, out decimal LimiteM))
                                validarConversion = false;
                            if (!decimal.TryParse(dgDatosImportar.Rows[i].ChildBands[0].Rows[j].Cells["Prima Neta"].Text, out decimal PrimaTotal))
                                validarConversion = false;
                            #endregion

                            if (validarConversion)
                            {
                                // registramos la póliza solo una vez
                                if (dgDatosImportar.Rows[i].ChildBands[0].Rows[j].Cells["Endosos"].Text == "P")
                                {
                                    if (numP == 0)
                                    {
                                        // registro de póliza
                                        Poliza nuevaPoliza = new Poliza();
                                        nuevaPoliza.Poliza1 = grupoRows.Value.ToString();
                                        nuevaPoliza.IniVig = De;
                                        nuevaPoliza.FinVig = A;
                                        nuevaPoliza.TipoTransaccion = tipoOperacion;
                                        if (dgDatosImportar.Rows[i].ChildBands[0].Rows[j].Cells["Moneda"].Text.Contains("USD"))
                                            nuevaPoliza.Moneda = 2;
                                        else
                                            nuevaPoliza.Moneda = 1;
                                        nuevaPoliza.LimiteMaximo = LimiteM;
                                        db.Poliza.InsertOnSubmit(nuevaPoliza);
                                        db.SubmitChanges();

                                        // registro de info schedule
                                        InfoSchedule nuevoInfo = new InfoSchedule();
                                        nuevoInfo.Poliza = nuevaPoliza.ID;
                                        switch (dgDatosImportar.Rows[i].ChildBands[0].Rows[j].Cells["Forma pago"].Text)
                                        {
                                            case "Contado":
                                                nuevoInfo.FormaPago = 1;
                                                break;

                                            case "Mensual":
                                                nuevoInfo.FormaPago = 2;
                                                break;

                                            case "Trimestral":
                                                nuevoInfo.FormaPago = 3;
                                                break;

                                            case "Semestral":
                                                nuevoInfo.FormaPago = 4;
                                                break;

                                            case "Anual":
                                                nuevoInfo.FormaPago = 5;
                                                break;

                                            case "Cuatrimestral":
                                                nuevoInfo.FormaPago = 6;
                                                break;

                                            default:
                                                nuevoInfo.FormaPago = 7;
                                                break;
                                        }
                                        nuevoInfo.TotalPoliza = PrimaTotal;
                                        db.InfoSchedule.InsertOnSubmit(nuevoInfo);
                                        db.SubmitChanges();

                                        idPoliza = nuevaPoliza.ID;
                                        numP++;
                                        tmpMX = grupoRows.Value.ToString();
                                    }
                                }

                                // registramos los endosos 
                                else
                                {
                                    if (idPoliza != 0)
                                    {
                                        // registro de info schedule
                                        InfoSchedule nuevoInfo = new InfoSchedule();
                                        nuevoInfo.Poliza = idPoliza;
                                        switch (dgDatosImportar.Rows[i].ChildBands[0].Rows[j].Cells["Forma pago"].Text)
                                        {
                                            case "Contado":
                                                nuevoInfo.FormaPago = 1;
                                                break;

                                            case "Mensual":
                                                nuevoInfo.FormaPago = 2;
                                                break;

                                            case "Trimestral":
                                                nuevoInfo.FormaPago = 3;
                                                break;

                                            case "Semestral":
                                                nuevoInfo.FormaPago = 4;
                                                break;

                                            case "Anual":
                                                nuevoInfo.FormaPago = 5;
                                                break;

                                            case "Cuatrimestral":
                                                nuevoInfo.FormaPago = 6;
                                                break;

                                            default:
                                                nuevoInfo.FormaPago = 7;
                                                break;
                                        }
                                        nuevoInfo.TotalPoliza = PrimaTotal;
                                        db.InfoSchedule.InsertOnSubmit(nuevoInfo);
                                        db.SubmitChanges();
                                    }
                                }
                            }
                        }
                    }
                }

                
                /*  1	Contado	False
                    2	Mensual	False
                    3	Trimestral	False
                    4	Semestral	False
                    5	Anual	False
                    6	Cuatrimestral	False
                    7	Otro	False

                Fraccionado
                Other
                 * */
                //validarConversion = true;
                //// antes que nada vemos si la fila es susceptible para importación
                //if (dgDatosImportar.Rows[i].ChildBands[0].Rows[0].Appearance.BackColor != Color.Red)
                //{
                //    // tomamos un row del datagrid y lo metemos al grupo
                //    UltraGridGroupByRow grupoRows = dgDatosImportar.Rows[i] as UltraGridGroupByRow;
                //    if (null != grupoRows)
                //    {
                //        // validamos que se puedan convertir los datos de la póliza
                //        #region Validaciones
                //        if (!DateTime.TryParse(dgDatosImportar.Rows[i].ChildBands[0].Rows[0].Cells["De"].Text, out DateTime De))
                //            validarConversion = false;
                //        if (!DateTime.TryParse(dgDatosImportar.Rows[i].ChildBands[0].Rows[0].Cells["A"].Text, out DateTime A))
                //            validarConversion = false;
                //        if (!decimal.TryParse(dgDatosImportar.Rows[i].ChildBands[0].Rows[0].Cells["Límite Máximo de Resp."].Text, out decimal LimiteM))
                //            validarConversion = false;
                //        if (!decimal.TryParse(dgDatosImportar.Rows[i].ChildBands[0].Rows[0].Cells["Prima Neta"].Text, out decimal PrimaTotal))
                //            validarConversion = false;
                //        #endregion

                //        // si pasa las validaciones continuamos
                //        if (validarConversion)
                //        {
                //            //preguntamos si tiene solo un hijo, si lo tiene es una póliza simple a importar
                //            if (dgDatosImportar.Rows[i].ChildBands[0].Rows.Count == 1)
                //            {
                //                Poliza nuevaPoliza = new Poliza();
                //                nuevaPoliza.Poliza1 = dgDatosImportar.ActiveRow.Cells["Pólizas"].Text;
                //                nuevaPoliza.IniVig = De;
                //                nuevaPoliza.FinVig = A;
                //                nuevaPoliza.Moneda = 1;
                //                nuevaPoliza.LimiteMaximo = LimiteM;
                //                db.Poliza.InsertOnSubmit(nuevaPoliza);
                //                db.SubmitChanges();
                //            }
                //        }
                //    }
                //}
            }
            MessageBox.Show("HE TERMINADO");
            //dgSecciones.Rows[i].Cells["Status"].Appearance.BackColor  
            //for (int i = 10; i < 15; i++)
            //{
            //    UltraGridGroupByRow groupByRow = dgDatosImportar.Rows[i] as UltraGridGroupByRow;
            //    if (null != groupByRow)
            //    {
            //        MessageBox.Show(groupByRow.Value.ToString());
            //        MessageBox.Show(dgDatosImportar.Rows[i].ChildBands[0].Rows.Count.ToString());
            //        MessageBox.Show(dgDatosImportar.Rows[i].ChildBands[0].Rows[0].Cells["Nombre"].Text);
            //    }
            //}
            //if (dgDatosImportar.Selected.Rows.Count == 1)
            //{
            //    bool validarConversion = true;

            //    if (DateTime.TryParse(dgDatosImportar.ActiveRow.Cells["De"].Text, out DateTime De))
            //    {

            //    }
            //    else validarConversion = false;

            //    if (DateTime.TryParse(dgDatosImportar.ActiveRow.Cells["A"].Text, out DateTime A))
            //    {

            //    }
            //    else validarConversion = false;

            //    if (decimal.TryParse(dgDatosImportar.ActiveRow.Cells["Límite Máximo de Resp."].Text, out decimal LimiteM))
            //    {
            //    }
            //    else validarConversion = false;

            //    if (decimal.TryParse(dgDatosImportar.ActiveRow.Cells["Prima Neta"].Text, out decimal PrimaTotal))
            //    {
            //    }
            //    else validarConversion = false;

            //    if (validarConversion)
            //    {
            //        dbSmartGDataContext db = new dbSmartGDataContext();

            //        Poliza nuevaPoliza = new Poliza();
            //        nuevaPoliza.Poliza1 = dgDatosImportar.ActiveRow.Cells["Pólizas"].Text;
            //        nuevaPoliza.IniVig = De;
            //        nuevaPoliza.FinVig = A;
            //        nuevaPoliza.Moneda = 1;
            //        nuevaPoliza.LimiteMaximo = LimiteM;
            //        db.Poliza.InsertOnSubmit(nuevaPoliza);
            //        db.SubmitChanges();

            //        InfoSchedule nuevoInfo = new InfoSchedule();
            //        nuevoInfo.Poliza = nuevaPoliza.ID;
            //        nuevoInfo.FormaPago = 1;

            //        nuevoInfo.TotalPoliza = PrimaTotal;
            //        db.InfoSchedule.InsertOnSubmit(nuevoInfo);
            //        db.SubmitChanges();

            //        MessageBox.Show("Poliza importada");
            //    }
            //    else
            //    {
            //        MessageBox.Show("No se pudo convertir algun dato");
            //    }
            //}


        }

        private void tmpImportador_Load(object sender, EventArgs e)
        {
            
        }

        private void btnDemoReporte_Click(object sender, EventArgs e)
        {
            //(DateTime.Compare(Convert.ToDateTime(dateFinVigencia.Value), Convert.ToDateTime(dateInicioVig.Value)) != 1)
            int yearI = Convert.ToDateTime(dateInicio.Value).Year;
            int yearF = Convert.ToDateTime(dateInicio.Value).Year;

            if (DateTime.Compare(Convert.ToDateTime(dateInicio.Value), Convert.ToDateTime(dateFin.Value)) == -1 && (yearI == yearF))
            {
                int mesInicio = Convert.ToDateTime(dateInicio.Value).Month;
                int mesFin = Convert.ToDateTime(dateFin.Value).Month;

                DataTable dtTmp = polizaReporteDemoTableAdapter.GetDataByPolizasMesYear(mesInicio, mesFin, yearI);
                DataTable dtReporte = new DataTable();
                dtReporte.Columns.Add("Mes", typeof(String));
                dtReporte.Columns.Add("Total", typeof(Decimal));
                string mesT = "";
                decimal totalT = 0;
                string[] meses = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

                for (int i = 0; i < meses.Count(); i++)
                {
                    mesT = meses[i];
                    totalT = 0;
                    for (int j = 0; j < dtTmp.Rows.Count; j++)
                    {
                        if (mesT == dtTmp.Rows[j]["Mes"].ToString())
                            totalT += Convert.ToDecimal(dtTmp.Rows[j]["TotalPoliza"].ToString());
                    }
                    dtReporte.Rows.Add(mesT, totalT);
                }

                ultraChart1.DataSource = dtReporte;
                ultraChart1.Data.DataBind();

                ultraChart2.DataSource = dtReporte;
                ultraChart2.Data.DataBind();

                ultraPieChart1.ValueMemberPath = "Total";
                ultraPieChart1.LabelMemberPath = "Mes";
                ultraPieChart1.LegendLabelMemberPath = "Mes";
                ultraPieChart1.DataSource = dtReporte;
                Infragistics.Win.DataVisualization.UltraLegend legend = new UltraLegend();
                this.Controls.Add(legend);
                legend.Dock = DockStyle.Right;
                legend.Height = 500;
                ultraPieChart1.Legend = legend;
                legend.BringToFront();
                ultraPieChart1.Update();
            }
            else
            {
                MessageBox.Show("La fecha inicio no puede ser mayor a la de fin y el año debe ser el mismo");
            }

       //     ultraDoughnutChart1.Series[0].ValueMemberPath = "Total";
       //     ultraDoughnutChart1.Series[0].LabelMemberPath = "Mes";
       //     ultraDoughnutChart1.Series[0].DataSource = dtReporte;
       //     //ultraDoughnutChart1.Series[0].Legend = legend;
       //     //legend.BringToFront();
       ////     ultraDoughnutChart1.Series[0].SetDataBinding(dtReporte, "Total");
       //     ultraDoughnutChart1.Update();
            
            /*UltraPieChart pieChart = new UltraPieChart();
this.Controls.Add(pieChart);
pieChart.Dock = DockStyle.Fill;
pieChart.LabelMemberPath = "Label";
pieChart.ValueMemberPath = "Value";
pieChart.DataSource = new Data();
UltraItemLegend legend = new UltraItemLegend();
this.Controls.Add(legend);
legend.Dock = DockStyle.Right;
legend.Height = 500;
pieChart.Legend = legend;
legend.BringToFront();
             * */
        }

        private void ultraPieChart1_SliceClick(object sender, SliceClickEventArgs e)
        {
            UltraPieChart pieChart = sender as UltraPieChart;
            e.IsExploded = !e.IsExploded;
        }

        private void btnImportarDocs_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");

                    //MessageBox.Show(Path.GetFileNameWithoutExtension(files[0]));

                    for (int i = 0; i < files.Count(); i++)
                    {
                        dbSmartGDataContext db = new dbSmartGDataContext();
                        string busqueda = Path.GetFileNameWithoutExtension(files[i]);
                        Coberturas coberturaBusqueda = (from x in db.Coberturas where x.Cobertura == busqueda && x.Origen == 1 && x.LineaNegocios == 2 select x).FirstOrDefault();
                        if (coberturaBusqueda != null)
                        {
                            string outputFile = files[i];
                            object m = System.Reflection.Missing.Value;
                            object readOnly = (object)false;
                            Word.Application ac = null;
                            ac = new Word.Application();

                            Word.Document doc = ac.Documents.Open(outputFile, m, readOnly,
                                  m, m, m, m, m, m, m, m, m, m, m, m, m);

                            object iniciof = doc.Content.Start;
                            object finf = doc.Content.End;
                            Word.Range rngf = doc.Range(iniciof, finf);
                            rngf.Select();
                            rngf.Copy();

                            string clipboardGetData = "";
                            try
                            {
                                clipboardGetData = (string)Clipboard.GetData(DataFormats.Rtf);
                            }
                            catch
                            {
                                clipboardGetData = (string)Clipboard.GetData(DataFormats.Text);
                            }

                            EndosoEmision nuevoendoso = new EndosoEmision();
                            nuevoendoso.LineaNegocios = 2;
                            nuevoendoso.Origen = 1;
                            nuevoendoso.Endoso = busqueda;
                            nuevoendoso.EndosoTXT = clipboardGetData;
                            nuevoendoso.Eliminado = false;
                            nuevoendoso.Defecto = false;
                            nuevoendoso.Cobertura = coberturaBusqueda.ID;
                            db.EndosoEmision.InsertOnSubmit(nuevoendoso);
                            db.SubmitChanges();
                            ((Word._Document)doc).Close();
                            ((Word._Application)ac).Quit();

                        }
                        
                    }
                    MessageBox.Show("Archivo importado");
                }
            }
        }
    }
}
