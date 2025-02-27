using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using NetOffice;
using NetOffice.OutlookApi.Enums;


namespace SmartG.Operaciones.Compliance
{
    public partial class Compliance : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // coleccion objetos
        #region objetos

        //grpCompletadas Registros de Pagos en Efectivo
        //grpBusqueda Opciones de Busqueda
        //lbParametro Parametro:
        //lbBuscar Buscar:
        //btnConsultar Consultar
        //lbDesde Desde:
        //lbHasta Hasta:
        //tabPagos_Efectivo Pagos Efectivo
        //btnActualizar   Actualizar
        //btnGenerarReporte   Generar Reporte
        //btnGeneraryEnviaraCompliance Generar y Enviar a Compliance
        //MainCompliance Compliance
        //grbActualizar Actualizar
        //grpReportes Reportes

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region variables

        bool Ingresos = false;

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region metodos

        void CargarDataSets()
        {
            this.reporteEfectivoTableAdapter.Fill(this.complementosPago.ReporteEfectivo);
        }
        void GenerarReporteDesdeIngresos()
        {
            DateTime inicioMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime finMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));

            reporteEfectivoTableAdapter.FillByXfecha(this.complementosPago.ReporteEfectivo, inicioMes, finMes);

            string rutaFile = @"C:\SmartG\ReporteDepositosEfectivo.xlsx";
            try { File.Delete(rutaFile); } catch { }
            try
            {
                // Genera el reporte
                ultraGridExcelExporter1.Export(dgDepositosEfectivo, rutaFile);
                // Agrega los encabezados
                Extensiones.Reportes.EditarEncabezados(rutaFile, DateTime.Now, DateTime.Now, true, "Reporte Depositos Efectivo", 20);

                // Genera un correo
                NetOffice.OutlookApi.Application outlookApp = new NetOffice.OutlookApi.Application();
                NetOffice.OutlookApi.MailItem mailItem = outlookApp.CreateItem(OlItemType.olMailItem) as NetOffice.OutlookApi.MailItem;

                dbSmartGDataContext db = new dbSmartGDataContext();
                EmailDistribucion email = (from x in db.EmailDistribucions where x.ListaDistribucion == "Deposito Efectivo" select x).SingleOrDefault();
                if (email != null)
                {
                    mailItem.Subject = email.TituloEmail + " " + DateTime.Today.ToLongDateString();
                    mailItem.To = email.DireccionEmailPrincipal;
                    mailItem.CC = email.DireccionEmailCC;
                    mailItem.HTMLBody = email.Contenido;

                    //Inserta reporte al correo
                    try { mailItem.Attachments.Add(rutaFile, OlAttachmentType.olByValue, Type.Missing, Type.Missing); }
                    catch { }

                    mailItem.Display(true);
                }
                else { MessageBox.Show("No se encontraron formatos disponibles en la tabla de ListaDistruciónEmails en la BD", "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
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
                    ultraGridExcelExporter1.Export(dgDepositosEfectivo, rutaFile);
                    // Agrega los encabezados
                    Extensiones.Reportes.EditarEncabezados(rutaFile, DateTime.Now, DateTime.Now, true, "Reporte Depositos Efectivo", 20);
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

        void EnviarEmail(string filepath)
        {
            if (filepath == "") return;
            // Genera un correo
            NetOffice.OutlookApi.Application outlookApp = new NetOffice.OutlookApi.Application();
            NetOffice.OutlookApi.MailItem mailItem = outlookApp.CreateItem(OlItemType.olMailItem) as NetOffice.OutlookApi.MailItem;

            dbSmartGDataContext db = new dbSmartGDataContext();
            EmailDistribucion email = (from x in db.EmailDistribucions where x.ListaDistribucion == "Deposito Efectivo" select x).SingleOrDefault();
            if (email != null)
            {
                mailItem.Subject = email.TituloEmail + " " + DateTime.Today.ToLongDateString();
                mailItem.To = email.DireccionEmailPrincipal;
                mailItem.CC = email.DireccionEmailCC;
                mailItem.HTMLBody = email.Contenido;

                //Inserta reporte al correo
                try { mailItem.Attachments.Add(filepath, OlAttachmentType.olByValue, Type.Missing, Type.Missing); }
                catch { }

                mailItem.Display(false);
            }
            else { MessageBox.Show("No se encontraron formatos disponibles en la tabla de ListaDistruciónEmails en la BD", "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region eventos

        public Compliance(bool abiertoDesdeIngreso = false)
        {
            InitializeComponent();
            Ingresos = abiertoDesdeIngreso;
        }

        private void Compliance_Load(object sender, EventArgs e)
        {
            CargarDataSets();
            if (Ingresos) GenerarReporteDesdeIngresos();
            Extensiones.Traduccion.traducirVentana(this, TabControlCompliance, ToolsBarCompliance);
        }

        private void ToolsBarCompliance_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btnActualizar":    
                    CargarDataSets();            
                    break;

                case "btnGenerarReporte":
                    GenerarReporte(true);
                    break;

                case "btnGeneraryEnviaraCompliance":
                    string ruta = GenerarReporte(false);
                    EnviarEmail(ruta);

                    break;

            }

        }
        #endregion

    }
}
