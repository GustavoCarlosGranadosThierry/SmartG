using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Operaciones.Reportes
{
    public partial class ReportesEmision : Form
    {
        public ReportesEmision()
        {
            InitializeComponent();
        }

        private void ToolsBarCompliance_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btnActualizar":   
                    this.polizaTableAdapter.Fill(this.reportesEmision1.Poliza);
                    
                    break;

                case "btnGenerarReporte":
                    GenerarReporte(true);
                    break;

                case "btnGeneraryEnviaraCompliance":   
                                                        
                    break;

            }

        }

        private void ultraGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            string[] ConcepSep = {
                "PD;Todo Riesgo;PFRC",
                "PD;Terremoto y/o Erupción Volcánica;PEVC",
                "PD;Granizo, ciclón, huracán o vientos tempestuosos;PHUC",
                "PD;Inundación y lluvia;PFOP", "PD;Cristales;PGBK",
                "PD;Anuncions Luminosos y Rótulos;PBBD",
                "PD;Dinero y Valores;PMSI",
                "PD;Equipo Electrónico;PEEB",
                "PD;Calderas y Recipientes a Sujetos a Presión;PBVB",
                "PD;Rotura de Maquinaria;PMBB",
                "PD;Equipo de Contratistas y Maquinaria Pesada Móvil;PCMB",
                "BI;Pérdidas Consecuenciales;PBI",
                "Burgary;Robo de contenidos;PBRG" };

            string[] dic = {
                "Sección I Daños materiales - Cobertura amplia de Incendio",
                "Sección I Daños materiales - Terremoto y/o Erupción Volcánica",
                "Sección I Daños materiales - Granizo, ciclón, huracán o vientos tempestuosos",
                "Sección I Daños materiales - Inundación y lluvia",
                "Sección III",
                "Sección IV",
                "Sección VI",
                "Sección VII",
                "Sección VIII",
                "Sección IX",
                "Sección X",
                "Sección II",
                "Sección V" };

            dbSmartGDataContext db = new dbSmartGDataContext();
            SmartG.Poliza[] polizas = (from x in db.Poliza where x.Poliza1.Contains("PR") select x).ToArray();
            int ConteoEntradas = 0;
            for (int x = 0; x < polizas.Count(); x++)
            {
                int IDPoliza = Convert.ToInt32(polizas[x].ID);
                PolizaCobertura[] coberturas = (from y in db.PolizaCobertura where y.Poliza == IDPoliza select y).ToArray();
                decimal PrimaInstruida = Convert.ToDecimal((from y in db.InfoSchedule where y.Poliza == IDPoliza && y.Endoso == null select y.Prima).FirstOrDefault());
                string Poliza = polizas[x].Poliza1;
                string statusPoliza = polizas[x].Status1.Status1;

                DataTable dtDesgloseIVA = new DataTable();
                dtDesgloseIVA.Columns.Add("Status", typeof(string));
                dtDesgloseIVA.Columns.Add("Poliza", typeof(string));
                dtDesgloseIVA.Columns.Add("Seccion", typeof(string));
                dtDesgloseIVA.Columns.Add("ClaveG", typeof(string));
                dtDesgloseIVA.Columns.Add("Concepto", typeof(string));
                dtDesgloseIVA.Columns.Add("SumaAsegurada", typeof(decimal));
                dtDesgloseIVA.Columns.Add("PrimaNeta", typeof(decimal));
                dtDesgloseIVA.Columns.Add("Part", typeof(decimal));
                dtDesgloseIVA.Columns.Add("Division", typeof(decimal));

                dtDesgloseIVA.Rows.Clear();
                dgDesglosePrima.DataSource = dtDesgloseIVA;
                dgDesglosePrima.DisplayLayout.Bands[0].Columns["Part"].Hidden = false;
                dgDesglosePrima.DisplayLayout.Bands[0].Columns["Division"].Hidden = false;
                dgDesglosePrima.DisplayLayout.Bands[0].Columns["SumaAsegurada"].Hidden = false;


                foreach (string str in ConcepSep)
                {
                    string[] ConcepInd = str.Split(';');
                    dtDesgloseIVA.Rows.Add(statusPoliza, Poliza, ConcepInd[0], ConcepInd[2], ConcepInd[1]);
                }                

                for (int i = 0; i < dic.Length; i++)
                {
                    string dicAct = dic[i];
                    bool verificacion = false;

                    for (int j = 0; j < coberturas.Count(); j++)
                    {
                        int largo = coberturas[j].Coberturas.Cobertura.Length;
                        if (dicAct.Length < largo) { largo = dicAct.Length; }
                        if (coberturas[j].Coberturas.Cobertura.Substring(0, largo) == dicAct)
                        {
                            verificacion = true;
                        }
                    }

                    if (verificacion == true)
                    {
                        dtDesgloseIVA.Rows[i]["Part"] = 1;
                    }
                    else
                    {
                        dtDesgloseIVA.Rows[i]["Part"] = 0;
                    }
                }

                // Cuenta los valores de las coberturas diferentes a la seccion 1
                int sumCob = 0;
                for (int i = 4; i <= 12; i++)
                {
                    if (dgDesglosePrima.Rows[i].Cells["Part"].Text == "1") { sumCob++; }
                }

                // Asigna el valor de la seccion 1 completa
                double ValS1 = 100;
                if (sumCob >= 1) { ValS1 = 90; }

                // Realiza las divisiones de la seccion 1
                if (dgDesglosePrima.Rows[1].Cells["Part"].Text == "1") { dgDesglosePrima.Rows[1].Cells["Division"].Value = 30; } else { dgDesglosePrima.Rows[1].Cells["Division"].Value = 0; }
                if (dgDesglosePrima.Rows[2].Cells["Part"].Text == "1") { dgDesglosePrima.Rows[2].Cells["Division"].Value = 10; } else { dgDesglosePrima.Rows[2].Cells["Division"].Value = 0; }
                if (dgDesglosePrima.Rows[3].Cells["Part"].Text == "1") { dgDesglosePrima.Rows[3].Cells["Division"].Value = 10; } else { dgDesglosePrima.Rows[3].Cells["Division"].Value = 0; }

                int ValIncendio = 0;
                for (int i = 1; i <= 3; i++) // Realiza el calculo del restante aplicable a incendio
                {
                    ValIncendio += int.Parse(dgDesglosePrima.Rows[i].Cells["Division"].Text);
                }
                dgDesglosePrima.Rows[0].Cells["Division"].Value = (100 - ValIncendio).ToString();

                for (int i = 0; i <= 3; i++)
                {
                    double val = double.Parse(dgDesglosePrima.Rows[i].Cells["Division"].Text);
                    dgDesglosePrima.Rows[i].Cells["Division"].Value = (val * (ValS1 / 100)).ToString();
                }

                // Asigna los valores para el resto de la secciones
                double resto = (100 - ValS1) / sumCob;
                for (int i = 4; i <= 12; i++)
                {
                    if (dgDesglosePrima.Rows[i].Cells["Part"].Text == "1") { dgDesglosePrima.Rows[i].Cells["Division"].Value = resto.ToString(); } else { dgDesglosePrima.Rows[i].Cells["Division"].Value = 0; }
                }

                for (int i = 0; i < dgDesglosePrima.Rows.Count; i++)
                {
                    try
                    {
                        decimal PNeta = PrimaInstruida * Convert.ToDecimal(dgDesglosePrima.Rows[i].Cells["Division"].Text) / 100;
                        dgDesglosePrima.Rows[i].Cells["PrimaNeta"].Value = PNeta;
                    }
                    catch { }
                }

                // Guarda en BD
                for (int i = 0; i < dgDesglosePrima.Rows.Count; i++)
                {
                    PolizaDesglosePrima polizaDesglosePrima = new PolizaDesglosePrima();
                    polizaDesglosePrima.Poliza = IDPoliza;
                    polizaDesglosePrima.Concepto = dgDesglosePrima.Rows[i].Cells["Concepto"].Text;
                    polizaDesglosePrima.Prima = Convert.ToDecimal(dgDesglosePrima.Rows[i].Cells["PrimaNeta"].Value);
                    polizaDesglosePrima.Endoso = null;
                    polizaDesglosePrima.Activo = true;
                    db.PolizaDesglosePrima.InsertOnSubmit(polizaDesglosePrima);
                    db.SubmitChanges();
                    ConteoEntradas++;
                }                 
            }

            dgDesglosePrima.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            MessageBox.Show(ConteoEntradas.ToString());         

        }

        private void ReportesEmision_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'reportesEmision1.Poliza' table. You can move, or remove it, as needed.
            try { this.polizaTableAdapter.Fill(this.reportesEmision1.Poliza); } catch { }

        }

        string GenerarReporte(bool mostrar)
        {
            string rutaFile = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rutaFile = saveFileDialog1.FileName;
                try
                {
                    // Genera el reporte
                    ultraGridExcelExporter1.Export(ultraGrid1, rutaFile);
                    // Agrega los encabezados
                    Extensiones.Reportes.EditarEncabezados(rutaFile, DateTime.Now, DateTime.Now, true, "Reporte Desgloce Prima", 20);
                    if (mostrar)
                        System.Diagnostics.Process.Start(rutaFile);

                    return saveFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return "";
                }
            }
            else
                return "";
        }

    }
}
