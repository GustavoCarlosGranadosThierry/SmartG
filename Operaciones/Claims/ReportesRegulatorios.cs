using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Operaciones.Claims
{
    public partial class ReportesRegulatorios : Form
    {
        public static DateTime fechaInicioReporte;
        public static DateTime fechaFinReporte;
        public static string LineaNegoSel;

        void CargarDataSets()
        {
            this.claimsReporteGCTableAdapter.Fill(this.claims.ClaimsReporteGC);
        }

        async void IngresarReporte()
        {
            // Abre una ventana de selección de archivos
            Stream myStream = null;
            OpenFileDialog xlsfiledialog = new OpenFileDialog();
            xlsfiledialog.InitialDirectory = Directory.GetCurrentDirectory();
            xlsfiledialog.Filter = "Excel Worksheets Files|*.xls; *.xlsx";
            xlsfiledialog.FilterIndex = 1;
            xlsfiledialog.RestoreDirectory = true;

            //Verifica que la respuesta no este vacia
            if (xlsfiledialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = xlsfiledialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            Espera frmWait = new Espera();                            
                            frmWait.Show();
                            this.Enabled = false;
                            await Task.Run(() => AgregarRegistros(xlsfiledialog.FileName));
                            frmWait.Close();
                            this.Enabled = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }

        private void AgregarRegistros(string filepath)
        {
            // Abre un nuevo excel
            NetOffice.ExcelApi.Application xlApp = new NetOffice.ExcelApi.Application();
            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }
            xlApp.Visible = false;
            try
            {
                //Abre la aplicacion
                NetOffice.ExcelApi.Workbook xlWorkbook = xlApp.Workbooks.Open(filepath);
                NetOffice.ExcelApi.Worksheet workSheet = (NetOffice.ExcelApi.Worksheet)xlWorkbook.Worksheets[1];

                // Validación de la estructura del archivo
                bool EstructuraOK = true;
                string ValorA = ""; try { ValorA = workSheet.Range("A4").Value.ToString(); } catch { }
                if (ValorA != "Legacy System") EstructuraOK = false;
                string ValorB = ""; try { ValorB = workSheet.Range("B4").Value.ToString(); } catch { }
                if (ValorB != "Insured Name") EstructuraOK = false;
                string ValorC = ""; try { ValorC = workSheet.Range("C4").Value.ToString(); } catch { }
                if (ValorC != "Policy Number") EstructuraOK = false;
                string ValorD = ""; try { ValorD = workSheet.Range("D4").Value.ToString(); } catch { }
                if (ValorD != "XL Share of Risk (%)") EstructuraOK = false;
                string ValorE = ""; try { ValorE = workSheet.Range("E4").Value.ToString(); } catch { }
                if (ValorE != "UW Year") EstructuraOK = false;
                string ValorF = ""; try { ValorF = workSheet.Range("F4").Value.ToString(); } catch { }
                if (ValorF != "Producing Office") EstructuraOK = false;
                string ValorG = ""; try { ValorG = workSheet.Range("G4").Value.ToString(); } catch { }
                if (ValorG != "Lead / Follow") EstructuraOK = false;
                string ValorH = ""; try { ValorH = workSheet.Range("H4").Value.ToString(); } catch { }
                if (ValorH != "Line of Business") EstructuraOK = false;
                string ValorI = ""; try { ValorI = workSheet.Range("I4").Value.ToString(); } catch { }
                if (ValorI != "Policy Type") EstructuraOK = false;
                string ValorJ = ""; try { ValorJ = workSheet.Range("J4").Value.ToString(); } catch { }
                if (ValorJ != "Claim Number") EstructuraOK = false;
                string ValorK = ""; try { ValorK = workSheet.Range("K4").Value.ToString(); } catch { }
                if (ValorK != "Legacy Claim Number") EstructuraOK = false;
                string ValorL = ""; try { ValorL = workSheet.Range("L4").Value.ToString(); } catch { }
                if (ValorL != "Cause of Loss") EstructuraOK = false;
                string ValorM = ""; try { ValorM = workSheet.Range("M4").Value.ToString(); } catch { }
                if (ValorM != "Claim Description") EstructuraOK = false;
                string ValorN = ""; try { ValorN = workSheet.Range("N4").Value.ToString(); } catch { }
                if (ValorN != "Trigger Date") EstructuraOK = false;
                string ValorO = ""; try { ValorO = workSheet.Range("O4").Value.ToString(); } catch { }
                if (ValorO != "Received Date") EstructuraOK = false;
                string ValorP = ""; try { ValorP = workSheet.Range("P4").Value.ToString(); } catch { }
                if (ValorP != "Registration Date") EstructuraOK = false;
                string ValorQ = ""; try { ValorQ = workSheet.Range("Q4").Value.ToString(); } catch { }
                if (ValorQ != "Loss Location Street") EstructuraOK = false;
                string ValorR = ""; try { ValorR = workSheet.Range("R4").Value.ToString(); } catch { }
                if (ValorR != "Loss Location City") EstructuraOK = false;
                if (!EstructuraOK)
                {
                    MessageBox.Show("La estructura del archivo seleccionado no coincide con el formato del Reporte de Claims XLGC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Calculo de la ultima fila a procesar - contador
                NetOffice.ExcelApi.Range last = workSheet.Cells.SpecialCells(NetOffice.ExcelApi.Enums.XlCellType.xlCellTypeLastCell, Type.Missing);
                NetOffice.ExcelApi.Range range = workSheet.get_Range("A4", last);

                int lastUsedRow = last.Row;
                dbSmartGDataContext db = new dbSmartGDataContext();
                int contador = 0;
                int Status_Aplicacion = (from x in db.StatusClaims where x.Status == "Incompleto" select x.ID).SingleOrDefault();

                // Loop por los registro del archivo
                for (int i = 5; i <= lastUsedRow; i++)
                {                    
                    if (workSheet.Range("C" + i).Value.ToString().Substring(0, 2) != "MX") return;
                    // check duplicados
                    db = new dbSmartGDataContext();
                    int conteoDup = (from x in db.ClaimsReporteGCs where x.ClaimNumber == workSheet.Range("J" + i).Value.ToString() select x).ToArray().Count();
                    if (conteoDup > 0) continue;
                    // Get Data

                    ClaimsReporteGC newClaim = new ClaimsReporteGC();
                    try { newClaim.InsuredName = workSheet.Range("B" + i).Value.ToString(); } catch { }
                    try { newClaim.PolicyNumber = workSheet.Range("C" + i).Value.ToString(); } catch { }
                    try { newClaim.ShareRisk = Convert.ToDecimal(workSheet.Range("D" + i).Value.ToString()); } catch { }
                    try { newClaim.UWYear = Convert.ToInt32(workSheet.Range("E" + i).Value.ToString()); } catch { }
                    try { newClaim.ProducingOffice = workSheet.Range("F" + i).Value.ToString(); } catch { }
                    try { newClaim.LeadFollow = workSheet.Range("G" + i).Value.ToString(); } catch { }
                    try { newClaim.LineBusiness = workSheet.Range("H" + i).Value.ToString(); } catch { }
                    try { newClaim.PolicyType = workSheet.Range("I" + i).Value.ToString(); } catch { }
                    try { newClaim.ClaimNumber = workSheet.Range("J" + i).Value.ToString(); } catch { }
                    try { newClaim.LegacyClaimNumber = workSheet.Range("K" + i).Value.ToString(); } catch { }
                    try { newClaim.CauseLoss = workSheet.Range("L" + i).Value.ToString(); } catch { }
                    try { newClaim.ClaimDescription = workSheet.Range("M" + i).Value.ToString(); } catch { }
                    try { newClaim.TriggerDate = Convert.ToDateTime(workSheet.Range("N" + i).Value.ToString()); } catch { }
                    try { newClaim.ReceivedDate = Convert.ToDateTime(workSheet.Range("O" + i).Value.ToString()); } catch { }
                    try { newClaim.RegistrationDate = Convert.ToDateTime(workSheet.Range("P" + i).Value.ToString()); } catch { }
                    try { newClaim.LossLocationStreet = workSheet.Range("Q" + i).Value.ToString(); } catch { }
                    try { newClaim.LossLocationCity = workSheet.Range("R" + i).Value.ToString(); } catch { }
                    try { newClaim.LossLocationCountry = workSheet.Range("S" + i).Value.ToString(); } catch { }
                    try { newClaim.LossLocationDescription = workSheet.Range("T" + i).Value.ToString(); } catch { }
                    try { newClaim.ClaimOwnerName = workSheet.Range("U" + i).Value.ToString(); } catch { }
                    try { newClaim.IndependentAdjuster = workSheet.Range("V" + i).Value.ToString(); } catch { }
                    try { newClaim.OfficeName = workSheet.Range("W" + i).Value.ToString(); } catch { }
                    try { newClaim.Hub = workSheet.Range("X" + i).Value.ToString(); } catch { }
                    try { newClaim.ClaimStatus = workSheet.Range("Y" + i).Value.ToString(); } catch { }
                    try { newClaim.ClosingDate = Convert.ToDateTime(workSheet.Range("Z" + i).Value.ToString()); } catch { }
                    try { newClaim.RepCcyCode = workSheet.Range("AA" + i).Value.ToString(); } catch { }
                    try { newClaim.GrossReserveIndemnity = Convert.ToDecimal(workSheet.Range("AB" + i).Value.ToString()); } catch { }
                    try { newClaim.GrossReserveExpenses = Convert.ToDecimal(workSheet.Range("AC" + i).Value.ToString()); } catch { }
                    try { newClaim.GrossReserveAmount = Convert.ToDecimal(workSheet.Range("AD" + i).Value.ToString()); } catch { }
                    try { newClaim.RecoverableIndemnity = Convert.ToDecimal(workSheet.Range("AE" + i).Value.ToString()); } catch { }
                    try { newClaim.RecoverableExpenses = Convert.ToDecimal(workSheet.Range("AF" + i).Value.ToString()); } catch { }
                    try { newClaim.RecoverableAmount = Convert.ToDecimal(workSheet.Range("AG" + i).Value.ToString()); } catch { }
                    try { newClaim.NetReserveIndemnity = Convert.ToDecimal(workSheet.Range("AH" + i).Value.ToString()); } catch { }
                    try { newClaim.NetReserveExpenses = Convert.ToDecimal(workSheet.Range("AI" + i).Value.ToString()); } catch { }
                    try { newClaim.NetReserveAmount = Convert.ToDecimal(workSheet.Range("AJ" + i).Value.ToString()); } catch { }
                    try { newClaim.PaymentIndemnity = Convert.ToDecimal(workSheet.Range("AK" + i).Value.ToString()); } catch { }
                    try { newClaim.PaymentExpenses = Convert.ToDecimal(workSheet.Range("AL" + i).Value.ToString()); } catch { }
                    try { newClaim.PaymentAmount = Convert.ToDecimal(workSheet.Range("AM" + i).Value.ToString()); } catch { }
                    try { newClaim.ReceivableIndemnity = Convert.ToDecimal(workSheet.Range("AN" + i).Value.ToString()); } catch { }
                    try { newClaim.ReceivableExpenses = Convert.ToDecimal(workSheet.Range("AO" + i).Value.ToString()); } catch { }
                    try { newClaim.ReceivableAmount = Convert.ToDecimal(workSheet.Range("AP" + i).Value.ToString()); } catch { }
                    try { newClaim.TotalIncurred = Convert.ToDecimal(workSheet.Range("AQ" + i).Value.ToString()); } catch { }
                    newClaim.Status = Status_Aplicacion;
                    db.ClaimsReporteGCs.InsertOnSubmit(newClaim);
                    db.SubmitChanges();
                    contador++;
                }

                // Mensaje de procesamiento
                if (contador == 0) { MessageBox.Show("No se encontraron registros nuevos en el reporte", "Mensaje"); }
                else
                {
                    MessageBox.Show("Se agregaron " + contador + " registro(s) a la base del Claims", "Mensaje");
                    // FIX Extensiones.AgregarLog("Journal", "Insert", 0, "Se agregaron " + contador + " registros por medio de subida de archivo de Excel");
                }

                // Termina la app
                xlApp.Quit();
                CargarDataSets();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                xlApp.Quit();
            }
        }

        void GenerarReporte()
        {
            SelFechas frmSelFechas = new SelFechas();
            if (frmSelFechas.ShowDialog() == DialogResult.Yes)
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                ClaimsReporteGC[] Reporte = (from x in db.ClaimsReporteGCs
                                             where x.RegistrationDate >= fechaInicioReporte 
                                             && x.RegistrationDate <= fechaFinReporte
                                             && x.LineBusiness == LineaNegoSel
                                             select x).ToArray();
                if(Reporte.Count() == 0)
                {
                    MessageBox.Show("Sin registros en las fechas seleccionadas");
                }
                else
                {
                    saveFileDialog1.FileName = "Reporte Regulatorio " + DateTime.Today.Day.ToString().PadLeft(2, '0') + DateTime.Today.Month.ToString().PadLeft(2, '0') + DateTime.Today.Year;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream fs = File.Create(saveFileDialog1.FileName))
                        {
                            for (int i = 0; i < Reporte.Count(); i++)
                            {
                                string Linea = "";
                                Linea += Reporte[i].PolicyNumber.Trim() + "|"; //1 Número de póliza 
                                Linea += Reporte[i].LossLocationCity.Trim() + "|"; //2 Ubicación
                                Linea += "|"; //3 Entidad / Municipio de la ubicación 
                                Linea += "|"; //4 Tipo bien
                                Linea += "|"; //5 Cobertura
                                Linea += Reporte[i].ClaimNumber.Trim() + "|"; //6 Número de siniestro
                                Linea += Convert.ToDateTime(Reporte[i].TriggerDate).ToString("yyyyMMdd") + "|"; //7 Fecha de ocurrencia del siniestro
                                Linea += Convert.ToDateTime(Reporte[i].RegistrationDate).ToString("yyyyMMdd") + "|"; //8 Fecha de reporte del siniestro
                                Linea += "1|"; //9 Causa siniestro
                                Linea += Reporte[i].GrossReserveAmount + "|"; //10 Monto del siniestro ocurrido 
                                Linea += "?|"; //11 Gastos de ajuste
                                Linea += Reporte[i].ReceivableAmount + "|"; //12 Salvamentos
                                Linea += Reporte[i].PaymentAmount + "|"; //13 Monto pagado
                                Linea += Reporte[i].RecoverableAmount + "|"; //14 Monto de deducible 
                                Linea += "0|"; //15 Monto de coaseguro
                                Linea += Reporte[i].TotalIncurred + "|"; //16 Valor total del bien siniestrado
                                if (Reporte[i].ClosingDate != null)
                                    Linea += Convert.ToDateTime(Reporte[i].ClosingDate).ToString("yyyyMMdd") + ";"; //17 Fecha de pago del siniestro
                                else
                                    Linea += ";";
                                Linea += Environment.NewLine;

                                byte[] LineaTxt = new UTF8Encoding(true).GetBytes(Linea);
                                fs.Write(LineaTxt, 0, LineaTxt.Length);
                            }
                            fs.Close();
                        }
                        MessageBox.Show("Texto generado");
                        Process.Start(saveFileDialog1.FileName);
                    }
                }
            }
        }

        void RevisarMovimientos()
        {
            MovimeintosReserva frmMov = new MovimeintosReserva(Convert.ToInt32(dgRegistrosClaims.ActiveRow.Cells["ID"].Value));
            frmMov.ShowDialog();
        }

        public ReportesRegulatorios()
        {
            InitializeComponent();
        }

        private void ReportesRegulatorios_Load(object sender, EventArgs e)
        {
            this.claimsCatalogoUbicaciones163TableAdapter.Fill(this.claims.ClaimsCatalogoUbicaciones163);
            CargarDataSets();
            cbParametro.SelectedIndex = 0;
        }

        private void ToolsBarCompliance_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btnActualizar":
                    CargarDataSets();
                    break;

                case "Ingresar Reporte XLGC":
                    IngresarReporte();
                    break;

                case "btnGenerarReporte":
                    GenerarReporte();
                    break;

                case "Ver Movimientos de Reserva":
                    RevisarMovimientos();
                    break;


            }

        }

        private void dgRegistrosClaims_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            int idRegistro = Convert.ToInt32(dgRegistrosClaims.ActiveRow.Cells["ID"].Value);
            EditarRegistroReporte frmEditar = new EditarRegistroReporte(idRegistro);
            if (frmEditar.ShowDialog() == DialogResult.Yes)
                CargarDataSets();

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            this.claimsReporteGCTableAdapter.FillByClaimNum(this.claims.ClaimsReporteGC, txtBusqueda.Text);

        }
    }
}
