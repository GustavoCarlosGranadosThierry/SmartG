using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Operaciones.CreditControl
{
    public partial class IngresosAutomaticos : Form
    {
        Form MainForm;

        public IngresosAutomaticos(Form mainform)
        {
            InitializeComponent();
            MainForm = mainform;
        }

        void CargarDataSets()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            decimal limite = Convert.ToDecimal((from x in db.JournalWriteOffLimites orderby x.ID descending select x.LimiteMasMenosUSD).FirstOrDefault());

            DataTable dtFull = journalAutomaticoSimpleTableAdapter.GetData(limite, limite);
            DataTable dtFiltro = journalAutomaticoSimpleTableAdapter.GetData(limite, limite);
            dtFiltro.Rows.Clear();
            if (dtFull.Rows.Count > 0)
            {
                // Capta un listado unico de IDs de Journals
                List<int> IDsJournals = new List<int>();
                foreach (DataRow RowFull in dtFull.Rows)
                {
                    int IDJo = Convert.ToInt32(RowFull["ID"].ToString());
                    bool yaIngresado = false;
                    foreach (int idsIngresado in IDsJournals)
                        if (idsIngresado == IDJo)
                            yaIngresado = true;

                    if (!yaIngresado)
                        IDsJournals.Add(IDJo);
                }

                // Genera un emparejamiento con los recibos
                List<int> IDsRecibos = new List<int>();
                foreach (int IDjournal in IDsJournals)
                {
                    int IDRecibo = 0;
                    foreach (DataRow RowFull in dtFull.Rows)
                    {
                        if(Convert.ToInt32(RowFull["ID"].ToString()) == IDjournal)
                        {
                            if (IDRecibo == 0)
                                IDRecibo = Convert.ToInt32(RowFull["IDRec"].ToString());
                            else
                            {
                                if (IDRecibo > Convert.ToInt32(RowFull["IDRec"].ToString()))
                                    IDRecibo = Convert.ToInt32(RowFull["IDRec"].ToString());                                
                            }
                        }
                    }
                    IDsRecibos.Add(IDRecibo);
                }

                int[] ListadoIdsJournal = IDsJournals.ToArray();
                int[] ListadoIdsRecibos = IDsRecibos.ToArray();

                for (int i = 0; i < ListadoIdsJournal.Length; i++)
                {
                    foreach (DataRow RowFull in dtFull.Rows)
                    {
                        if(Convert.ToInt32(RowFull["ID"].ToString()) == ListadoIdsJournal[i] && Convert.ToInt32(RowFull["IDRec"].ToString()) == ListadoIdsRecibos[i])
                        {
                            dtFiltro.ImportRow(RowFull);
                        }
                    }
                }
                dgJournalAutomatico.DataSource = dtFiltro;
                SelAll();
            }
        }

        void SelAll()
        {
            if (dgJournalAutomatico.Rows.Count() > 0)
            {
                bool FirstIsCheck = false;
                if (Convert.ToBoolean(dgJournalAutomatico.Rows[0].Cells["Check"].Value))
                    FirstIsCheck = true;

                bool Invertido = false;
                if (FirstIsCheck)
                    Invertido = false;
                else
                    Invertido = true;

                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgJournalAutomatico.Rows)
                    item.Cells["Check"].Value = Invertido;
            }
        }

        void ProcesarPagos()
        {
            int ConteoOperaciones = 0;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow Row in dgJournalAutomatico.Rows)
            {
                if(Convert.ToBoolean(Row.Cells["Check"].Value))
                    ConteoOperaciones++;
            }

            if(ConteoOperaciones > 0)
            {
                if(MessageBox.Show("Se procesaran " + ConteoOperaciones + " comprobantes de pago, continuar?","Mensaje",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int ContadorExitos = 0;
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow Row in dgJournalAutomatico.Rows)
                    {
                        if (Convert.ToBoolean(Row.Cells["Check"].Value))
                        {
                            dbSmartGDataContext db = new dbSmartGDataContext();
                            int nuevoFolioPP = Convert.ToInt32((from x in db.ComprobantesPagos select x.Folio).Max()) + 1;
                            int IDJournal = Convert.ToInt32(Row.Cells["ID"].Value);
                            int IDRecibo = Convert.ToInt32(Row.Cells["IDRec"].Value);

                            if (Convert.ToDecimal(Row.Cells["DiferenciaWriteOff"].Value) != 0)
                            {
                                WriteOff frmWriteOff = new WriteOff(IDJournal, true, - Convert.ToDecimal(Row.Cells["DiferenciaWriteOff"].Value));
                                if(frmWriteOff.ShowDialog() != DialogResult.Yes)
                                {
                                    MessageBox.Show("WriteOff no completado correctamente por el usuario, se continuara con el siguiente registro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    continue;
                                }
                            }

                            // Guarda los valores en la base de datos
                            int statusTxtgenerado = (from x in db.StatusFacturacions where x.Status == "En Proceso" select x.ID).SingleOrDefault();
                            Journal journalModificar = (from x in db.Journals where x.ID == IDJournal select x).SingleOrDefault();
                            journalModificar.FormaPago = (from x in db.RecibosPagos where x.ID == IDRecibo select x.Facturacion1.FormaPagoSAT).SingleOrDefault();
                            journalModificar.RFC_EmisorCuentaOrdenante = (from x in db.RecibosPagos where x.ID == IDRecibo select x.Facturacion1.Cliente).SingleOrDefault();
                            journalModificar.Status_Aplicacion = statusTxtgenerado;
                            journalModificar.tipoCambio = (from x in db.RecibosPagos where x.ID == IDRecibo select x.Facturacion1.TipoCambio).SingleOrDefault();

                            ComprobantesPago nuevoComprobante = new ComprobantesPago();
                            nuevoComprobante.Folio = nuevoFolioPP;
                            nuevoComprobante.Status = statusTxtgenerado;
                            db.ComprobantesPagos.InsertOnSubmit(nuevoComprobante);
                            db.SubmitChanges();
                            int IDcomprobante = nuevoComprobante.ID;

                            RecibosPago reciboModificar = (from x in db.RecibosPagos where x.ID == IDRecibo select x).SingleOrDefault();
                            reciboModificar.Status = statusTxtgenerado;

                            JournalDivision nuevaDivision = new JournalDivision();
                            nuevaDivision.JournalID = IDJournal;
                            nuevaDivision.ReciboID = IDRecibo;
                            nuevaDivision.ComprobantePagoID = IDcomprobante;
                            nuevaDivision.Monto_division = Math.Round(Convert.ToDecimal(reciboModificar.sche_primaTotal_part), 2);
                            db.JournalDivisions.InsertOnSubmit(nuevaDivision);
                            db.SubmitChanges();

                            Extensiones.TimbradoWSfinkok.TimbrarPagoSimple(IDcomprobante, MainForm);
                            ContadorExitos++;
                        }
                    }
                    CargarDataSets();
                }
            }
            else
            {
                MessageBox.Show("No se han seleccionado registros a procesar", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                return;
            }
        }

        void ExportarExcel()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ultraGridExcelExporter1.Export(dgJournalAutomatico, saveFileDialog1.FileName);
                    // Agrega los encabezados
                    Extensiones.Reportes.EditarEncabezados(saveFileDialog1.FileName, DateTime.Now, DateTime.Now, true, "Reporte Aplicación Automatica " , 20);
                    System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

            private void IngresosAutomaticos_Load(object sender, EventArgs e)
        {
            CargarDataSets();
        }

        private void ToolsBarIngresosAutomaticos_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (dgJournalAutomatico.Rows.Count > 0)
            {
                for (int i = 0; i < dgJournalAutomatico.Rows.Count; i++)
                    dgJournalAutomatico.Rows[i].Update();
            }

            switch (e.Tool.Key)
            {
                case "btnBuscarCoincidencias":
                    CargarDataSets();
                    break;

                case "btnGenerarComplementos":
                    ProcesarPagos();
                    break;

                case "btnSeleccionarTodos":
                    SelAll();
                    break;

                case "btnExportarExcel":
                    ExportarExcel();
                    break;
            }
        }
    }
}
