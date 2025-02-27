using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Operaciones.CreditControl
{
    public partial class Ingresos : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // coleccion objetos
        #region objetos

            //grpComplementos Complementos de pago
            //grpBusquedaComplementos Busqueda de complementos de pago
            //lbParametrosComplementos Parametro:
            //lbBuscarComplementos Buscar:
            //btnBuscarComplementos Consultar
            //grpJournal Solicitudes pendientes de aplicación(Doble clic para buscar recibo)
            //grpBusquedaJournal Busqueda de ingresos Journal/Daily Cash
            //lbParametroJournal Parametro:
            //lbBuscarJournal Buscar:
            //btnBuscarJournal Consultar
            //tabIngresos_-_Daily_Cash Ingresos - Daily Cash
            //tabComplementos_de_Pago Complementos de Pago
            //btnIngresarJournal Ingresar Journal
            //btnIngresarEdoCuentaBanamex Ingresar Estado Cuenta
            //btnBuscarRecibo Buscar Recibo
            //btnGenerarComprobante Generar Comprobante
            //btnDividirJournal   Dividir Journal
            //btnReprocesarPrintFile Reprocesar PrintFile
            //btnCancelarComprobante  Cancelar Comprobante
            //MainIngresos Ingresos y Complementos
            //rgbIngresos Ingresos: Daily Cash / Journal
            //rgbComplementos Complementos de Pago

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region variables

        public static string ReciboSelec;
        public static string FacRec;
        public static string PolizaSel;
        public static decimal cambioUsuario;
        public static int SelWS;
        string ruta;
        Form MainForm;

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region metodos

        void CargarDataSets()
        {
            this.journalTableAdapter.FillByNoAplicado(this.complementosPago.Journal);
            try { this.checkComprobantesTableAdapter.Fill(this.complementosPago.checkComprobantes); } catch { }
        }

        async void IngresarJournal()
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
                            ruta = xlsfiledialog.FileName;
                            Espera frmWait = new Espera();
                            frmWait.Show();
                            this.Enabled = false;
                            await Task.Run(() => AgregarRegistros(ruta));
                            frmWait.Close();
                            this.Enabled = true;
                            if (MessageBox.Show("Desea abrir la ventana de Ingreso de Estados de Cuenta Bancarios " +
                                "para buscar coincidencias con los Journals recien ingresados?",
                                "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                IngresoCuentasBancarias();
                            }
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
                int SelWorkS = 1;
                if (xlWorkbook.Worksheets.Count > 1 )
                {
                    List<string> SheetsList = new List<string>();
                    for (int i = 1; i -1 < xlWorkbook.Worksheets.Count; i++)
                    {
                        NetOffice.ExcelApi.Worksheet workSheeti = (NetOffice.ExcelApi.Worksheet)xlWorkbook.Worksheets[i];
                        SheetsList.Add(workSheeti.Name);
                    }
                    string[] listado = SheetsList.ToArray();
                    SelWorksheet frmSelWS = new SelWorksheet(listado);
                    frmSelWS.ShowDialog();
                    SelWorkS = SelWS;
                }

                NetOffice.ExcelApi.Worksheet workSheet = (NetOffice.ExcelApi.Worksheet)xlWorkbook.Worksheets[SelWorkS];
                workSheet.Range("A:AZ").Columns.AutoFit();

                // Validación de la estructura del archivo
                bool EstructuraOK = true;
                string ValorA = ""; try { ValorA = workSheet.Range("A1").Value.ToString(); } catch { }
                if (ValorA != "S. No") EstructuraOK = false;
                string ValorB = ""; try { ValorB = workSheet.Range("B1").Value.ToString(); } catch { }
                if (ValorB != "AccountCode") EstructuraOK = false;
                string ValorC = ""; try { ValorC = workSheet.Range("C1").Value.ToString(); } catch { }
                if (ValorC != "Citi Ref") EstructuraOK = false;
                string ValorD = ""; try { ValorD = workSheet.Range("D1").Value.ToString(); } catch { }
                if (ValorD != "Credit") EstructuraOK = false;
                string ValorE = ""; try { ValorE = workSheet.Range("E1").Value.ToString(); } catch { }
                if (ValorE != "Description") EstructuraOK = false;
                string ValorF = ""; try { ValorF = workSheet.Range("F1").Value.ToString(); } catch { }
                if (ValorF != "Account Ref") EstructuraOK = false;
                string ValorG = ""; try { ValorG = workSheet.Range("G1").Value.ToString(); } catch { }
                if (ValorG != "Entry Date") EstructuraOK = false;
                string ValorH = ""; try { ValorH = workSheet.Range("H1").Value.ToString(); } catch { }
                if (ValorH != "Value Date ") EstructuraOK = false;
                string ValorI = ""; try { ValorI = workSheet.Range("I1").Value.ToString(); } catch { }
                if (ValorI != "Orig Ccy") EstructuraOK = false;
                string ValorJ = ""; try { ValorJ = workSheet.Range("J1").Value.ToString(); } catch { }
                if (ValorJ != "Orig Amount") EstructuraOK = false;
                string ValorK = ""; try { ValorK = workSheet.Range("K1").Value.ToString(); } catch { }
                if (ValorK != "Acc Ccy") EstructuraOK = false;
                string ValorL = ""; try { ValorL = workSheet.Range("L1").Value.ToString(); } catch { }
                if (ValorL != "Acc Amount") EstructuraOK = false;
                string ValorM = ""; try { ValorM = workSheet.Range("M1").Value.ToString(); } catch { }
                if (ValorM != "Payment Details") EstructuraOK = false;
                string ValorN = ""; try { ValorN = workSheet.Range("N1").Value.ToString(); } catch { }
                if (ValorN != "Notes") EstructuraOK = false;
                string ValorO = ""; try { ValorO = workSheet.Range("O1").Value.ToString(); } catch { }
                if (ValorO != "Notes 1") EstructuraOK = false;
                string ValorP = ""; try { ValorP = workSheet.Range("P1").Value.ToString(); } catch { }
                if (ValorP != "Credit Officer") EstructuraOK = false;
                string ValorQ = ""; try { ValorQ = workSheet.Range("Q1").Value.ToString(); } catch { }
                if (ValorQ != "Account Code") EstructuraOK = false;
                string ValorR = ""; try { ValorR = workSheet.Range("R1").Value.ToString(); } catch { }
                if (ValorR != "Policy No") EstructuraOK = false;
                if (!EstructuraOK)
                {
                    xlApp.Quit();
                    MessageBox.Show("La estructura del archivo seleccionado no coincide con el formato del Journal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Calculo de la ultima fila a procesar - contador
                NetOffice.ExcelApi.Range last = workSheet.Cells.SpecialCells(NetOffice.ExcelApi.Enums.XlCellType.xlCellTypeLastCell, Type.Missing);
                NetOffice.ExcelApi.Range range = workSheet.get_Range("A1", last);

                int lastUsedRow = last.Row;
                dbSmartGDataContext db = new dbSmartGDataContext();
                int contador = 0;
                int Status_Aplicacion = (from x in db.StatusFacturacions where x.Status == "No Aplicado" select x.ID).SingleOrDefault();

                // Variables de seguimiento de las operaciones
                int countFail = 0;

                // Loop por los registro del archivo
                for (int i = 2; i <= lastUsedRow; i++)
                {
                    //Verifica si existe el registro en la base de datos previamente
                    try { if (Convert.ToInt32(workSheet.Range("A" + i).Value.ToString()) < 1) continue; } catch { }
                    string Snum = "";
                    try
                    {
                        Snum = workSheet.Range("A" + i).Value.ToString();
                    }
                    catch { }
                    if (countFail > 20) { break; }  // Skip despues de 20 lineas vacias seguidas                 
                    if (Snum == "") { countFail++; continue; } // skip para linea vacia
                    int ConteoRepetidos = (from x in db.Journals where x.SNum == Convert.ToInt32(Snum) select x).ToArray().Count();
                    if (ConteoRepetidos == 0)
                    {
                        countFail = 0;
                        // Calcula la prima a aplicar
                        decimal PrimaAplicar = 0;
                        string MonAplicar = "";
                        decimal diferencia = 0;
                        decimal val1 = 0;
                        decimal val2 = 0;

                        string mon1 = workSheet.Range("K" + i).Text.ToString();
                        string mon2 = workSheet.Range("I" + i).Text.ToString();
                        decimal.TryParse(workSheet.Range("L" + i).Text.ToString(), out val1);
                        decimal.TryParse(workSheet.Range("J" + i).Text.ToString(), out val2);

                        // Selecciona Caso
                        int caso = 0;
                        if (mon2 == "") { caso = 1; }
                        else if (mon1 == mon2 && val1 == val2) { caso = 2; }
                        else if (mon1 == mon2 && val1 != val2) { caso = 3; }
                        else if (mon1 != mon2) { caso = 4; }

                        switch (caso)
                        {
                            case 1:
                                PrimaAplicar = val1;
                                MonAplicar = mon1;
                                diferencia = 0;
                                break;

                            case 2:
                                PrimaAplicar = val1;
                                MonAplicar = mon1;
                                diferencia = 0;
                                break;

                            case 3:
                                PrimaAplicar = val1;
                                MonAplicar = mon1;
                                diferencia = val2 - val1;
                                break;

                            case 4:
                                PrimaAplicar = val1;
                                MonAplicar = mon1;
                                diferencia = 0;
                                break;

                            default:
                                PrimaAplicar = val1;
                                MonAplicar = mon1;
                                diferencia = 0;
                                break;
                        }

                        // Get Data

                        int? SNum = null; try { SNum = Convert.ToInt32(workSheet.Range("A" + i).Value.ToString()); } catch { }
                        decimal BankAccountCode = 0; try { BankAccountCode = Convert.ToDecimal(workSheet.Range("B" + i).Value.ToString()); } catch { }
                        string Citi_Ref = ""; try { Citi_Ref = workSheet.Range("C" + i).Value.ToString(); } catch { }
                        string Credit = ""; try { Credit = workSheet.Range("D" + i).Value.ToString(); } catch { }
                        string Description = ""; try { Description = workSheet.Range("E" + i).Value.ToString(); } catch { }
                        string Account_Ref = ""; try { Account_Ref = workSheet.Range("F" + i).Value.ToString(); } catch { }
                        DateTime? Entry_Date = null; try { Entry_Date = Convert.ToDateTime(workSheet.Range("G" + i).Value.ToString()); } catch { }
                        DateTime? Value_Date = null; try { Value_Date = Convert.ToDateTime(workSheet.Range("H" + i).Value.ToString()); } catch { }
                        string Orig_Ccy = ""; try { Orig_Ccy = workSheet.Range("I" + i).Value.ToString(); } catch { }
                        decimal Orig_Amount = 0; try { Orig_Amount = Convert.ToDecimal(workSheet.Range("J" + i).Value.ToString()); } catch { }
                        string Acc_Ccy = ""; try { Acc_Ccy = workSheet.Range("K" + i).Value.ToString(); } catch { }
                        decimal Acc_Amount = 0; try { Acc_Amount = Convert.ToDecimal(workSheet.Range("L" + i).Value.ToString()); } catch { }
                        string Payment_Details = ""; try { Payment_Details = workSheet.Range("M" + i).Value.ToString(); } catch { }
                        string Notes = ""; try { Notes = workSheet.Range("N" + i).Value.ToString(); } catch { }
                        string Notes2 = ""; try { Notes2 = workSheet.Range("O" + i).Value.ToString(); } catch { }
                        string Credit_Office = ""; try { Credit_Office = workSheet.Range("P" + i).Value.ToString(); } catch { }
                        string Account_Code = ""; try { Account_Code = workSheet.Range("Q" + i).Value.ToString(); } catch { }
                        string Policy = ""; try { Policy = workSheet.Range("R" + i).Value.ToString(); } catch { }
                        string Date_Posted = ""; try { Date_Posted = workSheet.Range("S" + i).Value.ToString(); } catch { }
                        string Comment = ""; try { Comment = workSheet.Range("T" + i).Value.ToString(); } catch { }
                        string Status = ""; try { Status = workSheet.Range("U" + i).Value.ToString(); } catch { }
                        string Country = ""; try { Country = workSheet.Range("V" + i).Value.ToString(); } catch { }
                        string JVNo = ""; try { JVNo = workSheet.Range("W" + i).Value.ToString(); } catch { }
                        string Allocation_No = ""; try { Allocation_No = workSheet.Range("X" + i).Value.ToString(); } catch { }
                        string Response_Date = ""; try { Response_Date = workSheet.Range("Y" + i).Value.ToString(); } catch { }
                        string Processed = ""; try { Processed = workSheet.Range("Z" + i).Value.ToString(); } catch { }
                        string Audit_Number = ""; try { Audit_Number = workSheet.Range("AA" + i).Value.ToString(); } catch { }
                        string OCI_Comments = ""; try { OCI_Comments = workSheet.Range("AB" + i).Value.ToString(); } catch { }
                        string Transaction_Description = ""; try { Transaction_Description = workSheet.Range("AC" + i).Value.ToString(); } catch { }
                        string OCI_Allocation = ""; try { OCI_Allocation = workSheet.Range("AD" + i).Value.ToString(); } catch { }
                        string f_Notes = ""; try { f_Notes = workSheet.Range("AE" + i).Value.ToString(); } catch { }
                        string Allocation_date = ""; try { Allocation_date = workSheet.Range("AF" + i).Value.ToString(); } catch { }
                        string Final_Allocation_Date = ""; try { Final_Allocation_Date = workSheet.Range("AG" + i).Value.ToString(); } catch { }
                        string Allocation_Processed = ""; try { Allocation_Processed = workSheet.Range("AH" + i).Value.ToString(); } catch { }
                        decimal PrimaAplicada = 0; try { PrimaAplicada = PrimaAplicar; } catch { }
                        int MonPrimaAplicada = (from x in db.Monedas where x.Abreviacion == MonAplicar select x.ID).SingleOrDefault();
                        decimal Diferencia = 0; try { Diferencia = diferencia; } catch { }
                        int FormaPago = 3;
                        string Cuenta_BancoOrdenante = ""; try { Cuenta_BancoOrdenante = ""; } catch { }
                        int? RFC_EmisorCuentaOrdenante = null;
                        decimal? tipoCambio = null;

                        Journal newJournal = new Journal();
                        newJournal.SNum = SNum;
                        newJournal.Bank_Account_Code = BankAccountCode;
                        newJournal.Citi_Ref = Citi_Ref;
                        newJournal.Credit = Credit;
                        newJournal.Description = Description;
                        newJournal.Entry_Date = Entry_Date;
                        newJournal.Value_Date = Value_Date;
                        newJournal.Orig_Ccy = Orig_Ccy;
                        newJournal.Orig_Amount = Orig_Amount;
                        newJournal.Acc_Ccy = Acc_Ccy;
                        newJournal.Acc_Amount = Acc_Amount;
                        newJournal.Payment_Details = Payment_Details;
                        newJournal.Notes = Notes;
                        newJournal.Notes2 = Notes2;
                        newJournal.Credit_Office = Credit_Office;
                        newJournal.Account_Code = Account_Code;
                        newJournal.Policy = Policy;
                        newJournal.Date_Posted = Date_Posted;
                        newJournal.Status = Status;
                        newJournal.Country = Country;
                        newJournal.JVNo = JVNo;
                        newJournal.Allocation_No = Allocation_No;
                        newJournal.Response_Date = Response_Date;
                        newJournal.Processed = Processed;
                        newJournal.Transaction_Description = Transaction_Description;
                        newJournal.OCI_Allocation = OCI_Allocation;
                        newJournal.f_Notes = f_Notes;
                        newJournal.Allocation_date = Allocation_date;
                        newJournal.Allocation_Processed = Allocation_Processed;
                        newJournal.Status_Aplicacion = Status_Aplicacion;
                        newJournal.MonPrimaAplicada = MonPrimaAplicada;
                        newJournal.PrimaAplicada = PrimaAplicada;
                        newJournal.Diferencia = Diferencia;
                        newJournal.FormaPago = FormaPago;
                        newJournal.Cuenta_BancoOrdenante = Cuenta_BancoOrdenante;
                        newJournal.RFC_EmisorCuentaOrdenante = RFC_EmisorCuentaOrdenante;
                        newJournal.tipoCambio = tipoCambio;
                        db.Journals.InsertOnSubmit(newJournal);
                        db.SubmitChanges();
                        contador++;
                    }
                }

                // Mensaje de procesamiento
                if (contador == 0) { MessageBox.Show("No se encontraron registros nuevos en el reporte", "Mensaje"); }
                else
                {
                    MessageBox.Show("Se agregaron " + contador + " registro(s) a la base del Journal", "Mensaje");
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

        void BuscarRecibos()
        {
            ReciboSelec = "";
            FacRec = "";
            PolizaSel = "";
            if(dgJournal.ActiveRow.Cells["Status_str"].Value.ToString() != "No Aplicado")
            {
                MessageBox.Show("Journal no disponible para timbrar","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            BuscarRecibo frm = new BuscarRecibo(dgJournal.ActiveRow.Cells["Policy"].Value.ToString(), Convert.ToInt32(dgJournal.ActiveRow.Cells["ID"].Value), MainForm);

            if (frm.ShowDialog() == DialogResult.OK)
                CargarDataSets();
        }

        void GenerarComprobante()
        {
        }

        void IngresoCuentasBancarias()
        {
            CreditControl.IngresoEstadoCuentaBancarios frmIngresoCuentas = new IngresoEstadoCuentaBancarios();
            if (this.MdiParent.MdiChildren.Where(p => p.Text == "Ingreso Estado Cuenta Bancarios").Count() > 0)
            {
                frmIngresoCuentas = this.MdiParent.MdiChildren.Where(p => p.Text == "Ingreso Estado Cuenta Bancarios").First() as CreditControl.IngresoEstadoCuentaBancarios;
                frmIngresoCuentas.Select();
            }
            else
            {
                frmIngresoCuentas.MdiParent = this.MdiParent;
                frmIngresoCuentas.Show();
            }
        }

        void ReprocesarComprobante()
        {
            if(dgComplementos.ActiveRow.Cells["Status"].Value.ToString() == "Error" || dgComplementos.ActiveRow.Cells["Status"].Value.ToString() == "En Proceso")
            {
                int ComprobanteID = Convert.ToInt32(dgComplementos.ActiveRow.Cells["ID"].Value);
                dbSmartGDataContext db = new dbSmartGDataContext();
                JournalDivision[] JournalDivReprocesar = (from x in db.JournalDivisions where x.ComprobantePagoID == ComprobanteID select x).ToArray();
                bool isSimple = true;

                if (JournalDivReprocesar.Count() == 0)
                {
                    MessageBox.Show("No hay recibos y/o Journal asignados a este comprobante", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int IDfactura0 = Convert.ToInt32(JournalDivReprocesar[0].RecibosPago.Facturacion);
                string CadenaIDsRecibos = "";
                for (int i = 0; i < JournalDivReprocesar.Count(); i++)
                {
                    CadenaIDsRecibos += JournalDivReprocesar[i].ReciboID + ",";

                    int IdfacturaActual = Convert.ToInt32(JournalDivReprocesar[i].RecibosPago.Facturacion);
                    if (IDfactura0 != IdfacturaActual)
                    {
                        isSimple = false;
                    }
                }

                if (isSimple)
                {
                    Extensiones.TimbradoWSfinkok.TimbrarPagoSimple(ComprobanteID, MainForm);
                }
                else
                {
                    Extensiones.TimbradoWSfinkok.TimbrarPagoMultiple(ComprobanteID, MainForm);
                }
                CargarDataSets();
            }
            else
                MessageBox.Show("Este comprobante no puede ser reprocesado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        void CancelarComprobante()
        {
            if (dgComplementos.ActiveRow.Cells["Status"].Value.ToString() == "Aplicado")
            {
                if (MessageBox.Show("Se generará la cancelacion de este complemento de pago, continuar? " +
                     "continuar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    int FolioPP = Convert.ToInt32((from x in db.ComprobantesPagos where x.ID == Convert.ToInt32(dgComplementos.ActiveRow.Cells["ID"].Value) select x.Folio).SingleOrDefault());

                    // Selecciona si la factura fue timbrada por Buzone o Finkok
                    if (FolioPP >= Extensiones.TimbradoWSfinkok.PrimerFolioFinkok("PP"))
                        Extensiones.TimbradoWSfinkok.TimbrarCancelacion(Convert.ToInt32(dgComplementos.ActiveRow.Cells["ID"].Value), 2, MainForm);
                    else
                        Extensiones.TimbradoWSfinkok.TimbrarCancelacionExterna(Convert.ToInt32(dgComplementos.ActiveRow.Cells["ID"].Value), 2, MainForm);

                    CargarDataSets();
                }

            }
            else if(dgComplementos.ActiveRow.Cells["Status"].Value.ToString() == "Cancelado")
            {
                MessageBox.Show("Este complemento de pago ya se encuentra cancelado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else // cualquier otro estatus
            {
                if (MessageBox.Show("Se borraran las relaciones de este complemento y se liberaran los journals y recibos de pago relacionados, " +
                    "continuar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int IDcomplemento = Convert.ToInt32(dgComplementos.ActiveRow.Cells["ID"].Value);
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    int IDstatusNoAplicado = (from x in db.StatusFacturacions where x.Status == "No Aplicado" select x.ID).SingleOrDefault();
                    int IDstatusCancelado = (from x in db.StatusFacturacions where x.Status == "Cancelado" select x.ID).SingleOrDefault();

                    JournalDivision[] journalDivisionCancelar = (from x in db.JournalDivisions where x.ComprobantePagoID == IDcomplemento select x).ToArray();

                    for (int i = 0; i < journalDivisionCancelar.Count(); i++)
                    {
                        // libera el journal y lo regresa a moneda original
                        Journal journalLiberar = (from x in db.Journals where x.ID == journalDivisionCancelar[i].JournalID select x).SingleOrDefault();
                        journalLiberar.Status_Aplicacion = IDstatusNoAplicado;
                        if(journalLiberar.Moneda.Abreviacion != journalLiberar.Acc_Ccy)
                        {
                            journalLiberar.MonPrimaAplicada = (from x in db.Monedas where x.Abreviacion == journalLiberar.Acc_Ccy select x.ID).SingleOrDefault();
                            journalLiberar.PrimaAplicada = journalLiberar.Acc_Amount;
                        }

                        // libera los recibos
                        RecibosPago reciboLiberar = (from x in db.RecibosPagos where x.ID == journalDivisionCancelar[i].ReciboID select x).SingleOrDefault();
                        reciboLiberar.Status = IDstatusNoAplicado;

                        // cancela el complemento
                        ComprobantesPago complementoLiberar = (from x in db.ComprobantesPagos where x.ID == journalDivisionCancelar[i].ComprobantePagoID select x).SingleOrDefault();
                        complementoLiberar.Status = IDstatusCancelado;

                        db.SubmitChanges();
                    }
                    db.JournalDivisions.DeleteAllOnSubmit(journalDivisionCancelar);
                    db.SubmitChanges();
                    MessageBox.Show("Comprobante cancelado. Los journals y recibos de pago han sido liberados para su uso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    CargarDataSets();
                }
            }
        }

        private void ValidarCB(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            Infragistics.Win.UltraWinEditors.UltraComboEditor cb = (Infragistics.Win.UltraWinEditors.UltraComboEditor)sender;

            if (cb.Items.Count > 0)
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

        void VerErrores()
        {
            if (dgComplementos.ActiveRow.Cells["ErrorDescripcion"].Value.ToString() == "")
            {
                MessageBox.Show("No hay error para mostrar", "Error de timbrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Detalle del error de Timbrado:" + Environment.NewLine + Environment.NewLine + dgComplementos.ActiveRow.Cells["ErrorDescripcion"].Value.ToString(), "Error de timbrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        void NuevoWriteOff()
        {
            if (dgJournal.ActiveRow.Cells["Status_str"].Value.ToString() != "No Aplicado")
            {
                MessageBox.Show("Journal ya se encuentra asignado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                WriteOff writeOffNuevo = new WriteOff(Convert.ToInt32(dgJournal.ActiveRow.Cells["ID"].Value));
                if (writeOffNuevo.ShowDialog() == DialogResult.Yes)
                    CargarDataSets();
            }
        }

        void VerWriteOffs()
        {
            WriteOffConsultas frmWOConsulta = new WriteOffConsultas(Convert.ToInt32(dgJournal.ActiveRow.Cells["ID"].Value));
            frmWOConsulta.ShowDialog();
        }

        void BusquedaAutomatica()
        {
            IngresosAutomaticos frmIngAut = new IngresosAutomaticos(MainForm);
            if (this.MdiChildren.Where(p => p.Text == "Ingresos Automaticos").Count() > 0)
            {
                frmIngAut = this.MdiParent.MdiChildren.Where(p => p.Text == "Ingresos Automaticos").First() as IngresosAutomaticos;
                frmIngAut.Select();
            }
            else
            {
                frmIngAut.MdiParent = this.MdiParent;
                frmIngAut.Show();
            }
        }

        void RegenerarPDF()
        {
            if (dgComplementos.ActiveRow != null)
            {
                if (dgComplementos.ActiveRow.Cells["Status"].Value.ToString() == "Aplicado")
                {
                    RegenerarPDF frmRegenerar = new RegenerarPDF(Convert.ToInt32(dgComplementos.ActiveRow.Cells["ID"].Value), false);
                    frmRegenerar.ShowDialog();
                }
                else
                    MessageBox.Show("Este comprobante aun no ha sido procesado o esta cancelado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void DescargarDocs()
        {
            Datasets.DBdocumentos.BDdocsTableAdapters.DocumentosFacturacionNuevoTableAdapter documentosFacturacionNuevoTableAdapter = new Datasets.DBdocumentos.BDdocsTableAdapters.DocumentosFacturacionNuevoTableAdapter();
            DataTable dtTemp = documentosFacturacionNuevoTableAdapter.GetDataByFolioSerie(dgComplementos.ActiveRow.Cells["Folio"].Value.ToString(), "PP");
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                DocumentosDB.ExtraerDocumentosFacturacionDB(Convert.ToInt32(dtTemp.Rows[i]["Factura"].ToString()), dtTemp.Rows[i]["NombreDocumento"].ToString(),
                    dtTemp.Rows[i]["Folio"].ToString(), dtTemp.Rows[i]["Serie"].ToString());
            }
            MessageBox.Show("Archivos extraidos con éxito", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            dbSmartGDataContext db = new dbSmartGDataContext();
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SmartG-Documentos\");
        }

        void DividirJournal()
        {
            if(dgJournal.ActiveRow.Cells["Status_str"].Value.ToString() == "No Aplicado")
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                int ContWriteOffs = (from x in db.JournalWriteOffs where x.Journal == Convert.ToInt32(dgJournal.ActiveRow.Cells["ID"].Value) select x).ToArray().Count();
                if(ContWriteOffs > 0)
                {
                    MessageBox.Show("Este ingreso cuenta con almenos 1 writeoff ingresado y no puede ser dividido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int Contador = (from x in db.JournalDivisions where x.JournalID == Convert.ToInt32(dgJournal.ActiveRow.Cells["ID"].Value) select x).ToArray().Count();
                if(Contador == 0)
                {
                    DivisionJournal frmDivisionJournal = new DivisionJournal(Convert.ToInt32(dgJournal.ActiveRow.Cells["ID"].Value));
                    if (frmDivisionJournal.ShowDialog() == DialogResult.Yes)
                        CargarDataSets();
                }
                else
                    MessageBox.Show("Este ingreso se encuentra en proceso de aplicación", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Este ingreso ya ha sido aplicado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region eventos

        public Ingresos(Form mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
        }

        private void Ingresos_Load(object sender, EventArgs e)
        {
            CargarDataSets();
            cbParametroJournal.SelectedIndex = 0;
            cbParametroComplementos.SelectedIndex = 0;
            //Extensiones.Traduccion.traducirVentana(this,tabIngresos,ToolsBarIngresos);
        }

        private void ToolsBarIngresos_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btnActualizar":
                    CargarDataSets();                
                    break;

                case "btnIngresarJournal":
                    IngresarJournal();
                    break;

                case "btnIngresarEdoCuentaBanamex":
                    IngresoCuentasBancarias();
                    break;

                case "btnBuscarRecibo":
                    BuscarRecibos();
                    break;

                case "btnGenerarComprobante":
                    GenerarComprobante();
                    break;

                case "btnReprocesarPrintFile":
                    ReprocesarComprobante();
                    break;

                case "btnDescargarDocumentos":
                    DescargarDocs();
                    break;                    

                case "btnRegenerarFactura":
                    RegenerarPDF();
                    break;                    

                case "btnCancelarComprobante":
                    CancelarComprobante();
                    break;

                case "btnVerErrores":
                    VerErrores();
                    break;

                case "btnAgregarWriteOff":
                    NuevoWriteOff();
                    break;

                case "btnConsultarWriteOff":
                    VerWriteOffs();
                    break;

                case "btnBusquedaAutomatica":
                    BusquedaAutomatica();
                    break;

                case "btnDivisionIngreso":
                    DividirJournal();
                    break;                   
            }
        }

        private void dgJournal_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            BuscarRecibos();
            CargarDataSets();   
        }

        private void tabIngresos_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            ToolsBarIngresos.Ribbon.Tabs[0].Groups["rgbIngresos"].Visible = false;
            ToolsBarIngresos.Ribbon.Tabs[0].Groups["rgbComplementos"].Visible = false;

            switch (tabIngresos.SelectedTab.Index)
            {
                case 0:
                    ToolsBarIngresos.Ribbon.Tabs[0].Groups["rgbIngresos"].Visible = true;
                    break;
                case 1:
                    ToolsBarIngresos.Ribbon.Tabs[0].Groups["rgbComplementos"].Visible = true;
                    break;
            }
        }

        private void btnBuscarJournal_Click(object sender, EventArgs e)
        {
            DateTime p1 = Convert.ToDateTime(dateBusquedaJournal.Value);
            DateTime p2 = Convert.ToDateTime(dateBusquedaJournal.Value);
            TimeSpan ts = new TimeSpan(0, 0, 0);
            p1 = p1.Date + ts;
            ts = new TimeSpan(23, 59, 59);
            p2 = p2.Date + ts;
            switch (cbParametroJournal.SelectedIndex)
            {
                case 0: //Cliente
                    this.journalTableAdapter.FillByPolicy(this.complementosPago.Journal, txtBusquedaJournal.Text);
                    break;
                case 1: //rfc
                    this.journalTableAdapter.FillByMonedaAbr(this.complementosPago.Journal, txtBusquedaJournal.Text);
                    break;
                case 2: //poliza
                    decimal busqueda = 0;
                    if (decimal.TryParse(txtBusquedaJournal.Text, out busqueda))
                    {
                        this.journalTableAdapter.FillByMonto(this.complementosPago.Journal, busqueda);
                    }
                    else { MessageBox.Show("Valor invalido"); return; }
                    break;
                case 3: //folio
                    int busqueda2 = 0;
                    if (int.TryParse(txtBusquedaJournal.Text, out busqueda2))
                    {
                        this.journalTableAdapter.FillBySnum(this.complementosPago.Journal, busqueda2);
                    }
                    else { MessageBox.Show("Valor invalido"); return; }
                    break;
                case 4://uuid
                    this.journalTableAdapter.FillByFechaDeposito(this.complementosPago.Journal, p1,p2);
                    break;
                case 5://auditNum
                    this.journalTableAdapter.FillByAuditNumber(this.complementosPago.Journal, txtBusquedaJournal.Text);
                    break;

            }
            if (this.complementosPago.Journal.Count == 0)
                MessageBox.Show("No hay registros", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void cbParametroJournal_ValueChanged(object sender, EventArgs e)
        {
            txtBusquedaJournal.Visible = false;
            dateBusquedaJournal.Visible = false;
            if (cbParametroJournal.SelectedIndex == 4)
                dateBusquedaJournal.Visible = true;
            else
                txtBusquedaJournal.Visible = true;
        }

        private void txtBusquedaJournal_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnBuscarJournal_Click(null, null);
            }
        }

        private void btnExcelReporteJournal_Click(object sender, EventArgs e)
        {
            string rutaFile = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rutaFile = saveFileDialog1.FileName;
                try
                {
                    // Genera el reporte
                    ultraGridExcelExporter1.Export(dgJournal, rutaFile);
                    // Agrega los encabezados
                    Extensiones.Reportes.EditarEncabezados(rutaFile, DateTime.Now, DateTime.Now, true, "Reporte Journal", 20);
                    System.Diagnostics.Process.Start(rutaFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnExcelReporteComp_Click(object sender, EventArgs e)
        {
            string rutaFile = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rutaFile = saveFileDialog1.FileName;
                try
                {
                    // Genera el reporte
                    ultraGridExcelExporter1.Export(dgComplementos, rutaFile);
                    // Agrega los encabezados
                    Extensiones.Reportes.EditarEncabezados(rutaFile, DateTime.Now, DateTime.Now, true, "Reporte Complementos Pago", 20);
                    System.Diagnostics.Process.Start(rutaFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cbParametroComplementos_ValueChanged(object sender, EventArgs e)
        {
            txtBuscarComplementos.Visible = false;
            dateBusquedaComplementos.Visible = false;
            if (cbParametroComplementos.SelectedIndex == 5)
                dateBusquedaComplementos.Visible = true;
            else
                txtBuscarComplementos.Visible = true;

        }

        private void btnBuscarComplementos_Click(object sender, EventArgs e)
        {
            DateTime p1 = Convert.ToDateTime(dateBusquedaComplementos.Value);
            DateTime p2 = Convert.ToDateTime(dateBusquedaComplementos.Value);
            TimeSpan ts = new TimeSpan(0, 0, 0);
            p1 = p1.Date + ts;
            ts = new TimeSpan(23, 59, 59);
            p2 = p2.Date + ts;
            switch (cbParametroComplementos.SelectedIndex)
            {
                case 0: //folio pp
                    int busqueda = 0;
                    if (int.TryParse(txtBuscarComplementos.Text, out busqueda))
                    {
                        try { this.checkComprobantesTableAdapter.FillByFolioComp(this.complementosPago.checkComprobantes, busqueda); } catch { }
                    }
                    else { MessageBox.Show("Valor invalido"); return; }
                    break;
                case 1: //status
                    try { this.checkComprobantesTableAdapter.FillByStatus(this.complementosPago.checkComprobantes, txtBuscarComplementos.Text); } catch { }
                    break;
                case 2: //uuid pp
                    try { this.checkComprobantesTableAdapter.FillByUUIDcomp(this.complementosPago.checkComprobantes, txtBuscarComplementos.Text); } catch { }
                    break;
                case 3: //folio fact
                    int busqueda1 = 0;
                    if (int.TryParse(txtBuscarComplementos.Text, out busqueda1))
                    {
                        try { this.checkComprobantesTableAdapter.FillByFolioFact(this.complementosPago.checkComprobantes, busqueda1); } catch { }
                    }
                    else { MessageBox.Show("Valor invalido"); return; }
                    break;
                case 4://snum
                    int busqueda2 = 0;
                    if (int.TryParse(txtBuscarComplementos.Text, out busqueda2))
                    {
                        try { this.checkComprobantesTableAdapter.FillBySnum(this.complementosPago.checkComprobantes, busqueda2); } catch { }
                    }
                    else { MessageBox.Show("Valor invalido"); return; }
                    break;
                case 5://fecha timbra
                    try { this.checkComprobantesTableAdapter.FillByFechaTimbradoComp(this.complementosPago.checkComprobantes, p1,p2); } catch { }
                    break;
                case 6: //poliza
                    try { this.checkComprobantesTableAdapter.FillByPoliza(this.complementosPago.checkComprobantes, txtBuscarComplementos.Text); } catch { }
                    break;


            }
            if (this.complementosPago.checkComprobantes.Count == 0)
                MessageBox.Show("No hay registros", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void txtBuscarComplementos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscarComplementos_Click(null, null);
        }

        private void dgComplementos_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            DescargarDocs();
        }

        private void DataGrid_MouseDown(object sender, MouseEventArgs e)
        {
            UltraGrid DG = (UltraGrid)sender;
            if (e.Button == MouseButtons.Right)
            {
                UIElement element = ((UltraGrid)sender).DisplayLayout.UIElement.LastElementEntered;

                UltraGridCell cell = element.GetContext(typeof(UltraGridCell)) as UltraGridCell;
                if (cell != null)
                {
                    DG.ActiveRow = cell.Row;
                    Point mousePoint = new Point(e.X, e.Y);
                    ContextMenuStrip CMS = DG.ContextMenuStrip;
                    if (CMS != null)
                    {
                        DG.ActiveRow = null;
                        cell.Row.Selected = true;
                        DG.ActiveCell = cell;
                        CMS.Show(DG, mousePoint);
                    }
                }
            }
        }


        #endregion

        private void cmsJournals_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (dgJournal.ActiveRow == null)
            {
                MessageBox.Show("No se ha seleccionado ningún registro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                switch (e.ClickedItem.Text)
                {
                    case "Generar Comprobante de Pago":
                        BuscarRecibos();
                        break;

                    case "Agregar WriteOff":
                        NuevoWriteOff();
                        break;

                    case "Consultar WriteOffs":
                        VerWriteOffs();
                        break;

                    case "Dividir Journal":
                        DividirJournal();
                        break;  
                }
            }

        }

        private void cmsComplementos_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (dgComplementos.ActiveRow == null)
            {
                MessageBox.Show("No se ha seleccionado ningún registro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                switch (e.ClickedItem.Text)
                {
                    case "Reprocesar Timbrado del comprobante":
                        ReprocesarComprobante();
                        break;

                    case "Cancelar Comprobante":
                        CancelarComprobante();
                        break;

                    case "Descargar documentos":
                        DescargarDocs();
                        break;

                    case "Reprocesar PDF":
                        RegenerarPDF();
                        break;

                    case "Ver errores de Timbrado":
                        VerErrores();
                        break;
                }
            }
        }
    }
}
