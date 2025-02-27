using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Operaciones
{
    public partial class DescargarDocumentos : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // coleccion objetos
        #region objetos

            //lbTipoBusqueda Documentos Emisión
            //cbLNMain    cbLNMain
            //ctrlLineaNegocios   L.Negocios
            //ctrlFiltro  Filtro
            //ctrlBuscar  Buscar
            //btnBuscar   Buscar
            //lbBusqueda
            //rbnMainDescargas Descarga Documentos
            //grpFiltros  Filtros de Búsqueda
            //grpDatos    Estas buscando en

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region variables

        bool MostrarFacturas = false;
        bool MostrarDocumentos = false;

        string[] filtrosFactura = { "Nombre Cliente", "RFC", "Poliza", "Folio", "Serie" };
        string[] filtrosEmision = { "Poliza", "Usuario" };

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region metodos

        async void GenerarRecibos(int idFactura)
        {
            Espera frmWait = new Espera();
            frmWait.Show();
            this.Enabled = false;
            await Task.Run(() => Extensiones.Cobranza.GenerarRecibosPago(idFactura, true));
            frmWait.Close();
            this.Enabled = true;
        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region eventos

        public DescargarDocumentos(bool isFactura)
        {
            InitializeComponent();

            if (isFactura)
            {
                MostrarFacturas = true;
                lbTipoBusqueda.Text = "Facturas";
                dgFacturas.Visible = true;
                dgFacturas.Dock = DockStyle.Fill;
                this.documentosFacturacionNuevoTableAdapter.FillByUsuario(this.bDdocs.DocumentosFacturacionNuevo, Program.Globals.NombreCompletoUsuario);

                for (int i = 0; i < filtrosFactura.Length; i++)
                {
                    cbFiltro.Items.Add(i, filtrosFactura[i]);
                }
            }
            else
            {
                MostrarDocumentos = true;
                lbTipoBusqueda.Text = "Documentos Emisión";
                dgPolizas.Visible = true;
                dgPolizas.Dock = DockStyle.Fill;
                this.documentosEmisionNuevoTableAdapter.FillByUsuario(this.bDdocs.DocumentosEmisionNuevo, Program.Globals.NombreCompletoUsuario);
                for (int i = 0; i < filtrosEmision.Length; i++)
                {
                    cbFiltro.Items.Add(i, filtrosEmision[i]);
                }
            }
            cbFiltro.SelectedIndex = 0;
        }

        private void DescargarDocumentos_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this, null, ToolbarsManagerDescargarDocs);
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBusqueda.Text == "")
                {
                    MessageBox.Show("Ingrese un valor valido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
                if (MostrarFacturas)
                {
                    switch (cbFiltro.Text)
                    {
                        case "Nombre Cliente":
                            this.documentosFacturacionNuevoTableAdapter.FillByNombreCliente(this.bDdocs.DocumentosFacturacionNuevo, txtBusqueda.Text);
                            break;

                        case "RFC":
                            this.documentosFacturacionNuevoTableAdapter.FillByRFC(this.bDdocs.DocumentosFacturacionNuevo, txtBusqueda.Text);
                            break;

                        case "Poliza":
                            this.documentosFacturacionNuevoTableAdapter.FillByPoliza(this.bDdocs.DocumentosFacturacionNuevo, txtBusqueda.Text);
                            break;

                        case "Folio":
                            this.documentosFacturacionNuevoTableAdapter.FillByFolio(this.bDdocs.DocumentosFacturacionNuevo, txtBusqueda.Text);
                            break;

                        case "Serie":
                            this.documentosFacturacionNuevoTableAdapter.FillBySerie(this.bDdocs.DocumentosFacturacionNuevo, txtBusqueda.Text);
                            break;
                    }
                    if (this.bDdocs.DocumentosFacturacionNuevo.Rows.Count == 0)
                        MessageBox.Show("No hay resultados para la busqueda", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }
                else
                {
                    switch (cbFiltro.Text)
                    {
                        case "Usuario":
                            this.documentosEmisionNuevoTableAdapter.FillByUsuario(this.bDdocs.DocumentosEmisionNuevo, txtBusqueda.Text);
                            break;

                        //case "Linea de Negocio":
                        //    this.documentosEmisionNuevoTableAdapter.FillByLN(this.bDdocs.DocumentosEmisionNuevo, txtBusqueda.Text);
                        //    break;

                        case "Poliza":
                            this.documentosEmisionNuevoTableAdapter.FillByPoliza(this.bDdocs.DocumentosEmisionNuevo, txtBusqueda.Text);
                            break;
                    }
                    if (this.bDdocs.DocumentosEmisionNuevo.Rows.Count == 0)
                        MessageBox.Show("No hay resultados para la busqueda", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgFacturas_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            Datasets.DBdocumentos.BDdocsTableAdapters.DocumentosFacturacionNuevoTableAdapter documentosFacturacionNuevoTableAdapter = new Datasets.DBdocumentos.BDdocsTableAdapters.DocumentosFacturacionNuevoTableAdapter();
            DataTable dtTemp = documentosFacturacionNuevoTableAdapter.GetDataByFolioSerie(dgFacturas.ActiveRow.Cells["Folio"].Value.ToString(), dgFacturas.ActiveRow.Cells["Serie"].Value.ToString());
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                DocumentosDB.ExtraerDocumentosFacturacionDB(Convert.ToInt32(dtTemp.Rows[i]["Factura"].ToString()), dtTemp.Rows[i]["NombreDocumento"].ToString(),
                    dtTemp.Rows[i]["Folio"].ToString(), dtTemp.Rows[i]["Serie"].ToString());
            }
            MessageBox.Show("Archivos extraidos con éxito", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            dbSmartGDataContext db = new dbSmartGDataContext();
            try
            {
                int IDfactura = (from x in db.Facturacions where (x.Folio == Convert.ToInt32(dtTemp.Rows[0]["Folio"].ToString()) && x.Serie == dtTemp.Rows[0]["Serie"].ToString()) select x.ID).SingleOrDefault();
                string CondPago = (from x in db.Facturacions where x.ID == IDfactura select x.FormaPago.FormaPago1).SingleOrDefault().ToString();
                if (CondPago == "Anual" || CondPago == "Contado") { }
                else
                {
                    if (MessageBox.Show("Desea Generar los recibos de Pago para esta factura con forma de pago: " + CondPago + "?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        GenerarRecibos(IDfactura);
                    }
                }
            }
            catch { }
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SmartG-Documentos\");

        }

        private void dgPolizas_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            try
            {
                DataTable dtTemp = documentosEmisionNuevoTableAdapter.GetDataByPoliza(dgPolizas.ActiveRow.Cells["PolizaMX"].Text.ToString());
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    DocumentosDB.ExtraerDocumentosEmisionDB(dtTemp.Rows[i]["PolizaMX"].ToString(), dtTemp.Rows[i]["NombreDocumento"].ToString());
                }
                MessageBox.Show("Archivos extraidos con éxito", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SmartG-Documentos\");
            }
            catch
            {
                MessageBox.Show("Error al generar los documentos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

    }
}
