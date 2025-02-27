using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SmartG.Operaciones.CreditControl
{
    public partial class BuscarRecibo : Form
    {

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // coleccion objetos
        #region objetos

        //Facturacion - BuscarRecibo  - Control btnSeleccionar  Seleccionar
        //Facturacion - BuscarRecibo  - Control grpRecibos  Busqueda de Recibos de Pago(doble clic para agregar)
        //Facturacion - BuscarRecibo  - Control btnGenenerarComprobante Generar Comprobante de Pago
        //Facturacion - BuscarRecibo  - Control grpRecibosSeleccionados Recibos Seleccionados
        //Facturacion - BuscarRecibo  - Control lbSnum  S.Number: 
        //Facturacion - BuscarRecibo  - Control lbMonedaJournal Moneda Original:
        //Facturacion - BuscarRecibo  - Control lbTotalJournal  Total del Journal:
        //Facturacion - BuscarRecibo  - Control lbJournalAplicado   Monto Aplicado

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region variables

        public static decimal cambioUsuario;
        static string Pol;
        int IDjournal;
        Form MainForm;

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region metodos

        void CargarValoresJournal()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            txtSNum.Text = (from x in db.Journals where x.ID == IDjournal select x.SNum).SingleOrDefault().ToString();
            txtMonOriginal.Text = (from x in db.Journals where x.ID == IDjournal select x.Moneda.Abreviacion).SingleOrDefault().ToString();
            txtTotalJournal.Value = Convert.ToDecimal((from x in db.Journals where x.ID == IDjournal select x.PrimaAplicada).SingleOrDefault());
            txtTipoCambio.Value = 0;
            txtTipoCambio.Enabled = false;
        }

        bool ValidacionRecibos()
        {
            // Hay valores
            if (dgRecibosSeleccionados.Rows.Count == 0)
            { MessageBox.Show("No se han seleccionado recibos para procesar", "Error Validación", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }

            // Monto de las aplicacion != del monto del journal
            if (Math.Round(Convert.ToDecimal(txtSumaMontoAplicado.Value)) != Math.Round(Convert.ToDecimal(txtTotalJournal.Value)))
            { MessageBox.Show("La suma de los montos aplicados de los recibos es diferente al total de Journal, debe ajustar los montos aplicados en cada recibo.", "Error Validación", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }

            foreach (UltraGridRow row in dgRecibosSeleccionados.Rows)
            {
                string identificacion = row.Cells["Serie"].Value.ToString() + row.Cells["Folio"].Value.ToString() + ", poliza: " + row.Cells["Poliza"].Value.ToString();

                //Valores 0 o negativos en el monto a aplicar
                if (Convert.ToDecimal(row.Cells["Monto a aplicar en este comprobante"].Value) < 0)
                { MessageBox.Show("En el recibo " + identificacion + " se intenta aplicar montos negativos al comprobante. No se pueden generar comprobantes de pago con montos de pago 0 o negativos", "Error Validación", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }

                // Montos negativos en el total pendiente despues de la aplicación
                if (Convert.ToDecimal(row.Cells["Monto pendiente despues de esta aplicación"].Value) < 0)
                { MessageBox.Show("El recibo " + identificacion + " contiene valores negativos posteriores a la aplicación, no se puede sobre pagar una factura.", "Error Validación", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }

                // Montos excedentes de una factura sumando todos los recibos de pago
                decimal TotalaplicadoXfactura = 0;
                string facturaSerieFolioBuscar = row.Cells["Serie"].Value.ToString() + row.Cells["Folio"].Value.ToString();
                decimal PendienteFactura = Convert.ToDecimal(Convert.ToDecimal(row.Cells["Pendiente de Cobro"].Value));
                foreach (UltraGridRow row2 in dgRecibosSeleccionados.Rows)
                {
                    string facturaSerieFolioActual = row2.Cells["Serie"].Value.ToString() + row2.Cells["Folio"].Value.ToString();
                    if (facturaSerieFolioBuscar == facturaSerieFolioActual)
                        TotalaplicadoXfactura += Convert.ToDecimal(Convert.ToDecimal(row2.Cells["Monto a aplicar en este comprobante"].Value));
                }
                if (TotalaplicadoXfactura > PendienteFactura)
                { MessageBox.Show("El monto pendiente de la factura " + identificacion + " es menor a la suma de los recibos que se intentan aplicar", "Error Validación", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }

            }
            return true;
        }

        void SeleccionarRecibo()
        {
            int IDrecibo = Convert.ToInt32(dgRecibos.ActiveRow.Cells["ID"].Value);

            // validacion de que no haya sido seleccionado previamente
            bool idenuso = false;
            foreach (UltraGridRow item in dgRecibosSeleccionados.Rows)
            {
                if (Convert.ToInt32(item.Cells["ID"].Value) == IDrecibo)
                {
                    idenuso = true; break;
                }
            }
            if (idenuso)
            { MessageBox.Show("Este recibo ya ha sido seleccionado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }

            // Validación del mismo tipo de moneda
            dbSmartGDataContext db = new dbSmartGDataContext();
            int IDfactura = (from x in db.RecibosPagos where x.ID == IDrecibo select x.Facturacion1.ID).SingleOrDefault();
            int MonedaFactura = Convert.ToInt32((from x in db.Facturacions where x.ID == IDfactura select x.Moneda).SingleOrDefault());
            int IDmonedaMXN = (from x in db.Monedas where x.Abreviacion == "MXN" select x.ID).SingleOrDefault();
            int IDmonedaUSD = (from x in db.Monedas where x.Abreviacion == "USD" select x.ID).SingleOrDefault();

            if (dgRecibosSeleccionados.Rows.Count > 0)
            {
                string monedaUsada = dgRecibosSeleccionados.Rows[0].Cells["Moneda"].Value.ToString();
                int idMonenaUsada = 0;
                if (monedaUsada == "MXN") idMonenaUsada = IDmonedaMXN;
                if (monedaUsada == "USD") idMonenaUsada = IDmonedaUSD;

                if (MonedaFactura != idMonenaUsada)
                { MessageBox.Show("La moneda del recibo seleccionada no corresponde a la de los recibos ya seleccionados, no se pueden realizar comprobantes con mas de una divisa.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }

            }
            else
            {
                if (!CambioMonedaJournal(IDfactura))
                    return;
            }

            // Valores del recibo
            string reciboSerie = dgRecibos.ActiveRow.Cells["Serie"].Value.ToString();
            int reciboFolio = Convert.ToInt32(dgRecibos.ActiveRow.Cells["Folio"].Value);
            int reciboPagoNumero = Convert.ToInt32(dgRecibos.ActiveRow.Cells["X"].Value);
            int reciboInstancias = Convert.ToInt32(dgRecibos.ActiveRow.Cells["Y"].Value);
            decimal reciboPago = Convert.ToDecimal(dgRecibos.ActiveRow.Cells["sche_primaTotal_part"].Value);
            string poliza = dgRecibos.ActiveRow.Cells["Poliza_str"].Value.ToString();

            // Calculo del saldo insoluto
            decimal TotalFactura = Convert.ToDecimal((from x in db.Facturacions where x.ID == IDfactura select x.Total).SingleOrDefault());
            decimal tipoCambioFactura = Convert.ToDecimal((from x in db.Facturacions where x.ID == IDfactura select x.TipoCambio).SingleOrDefault());

            int IDstatusAplicado = (from x in db.StatusFacturacions where x.Status == "Aplicado" select x.ID).SingleOrDefault();
            int IDstatusFacGen = (from x in db.StatusFacturacions where x.Status == "Factura Generada" select x.ID).SingleOrDefault();
            int IDstatusRecGen = (from x in db.StatusFacturacions where x.Status == "Recibos Generados" select x.ID).SingleOrDefault();

            string MonedaAplicar = (from x in db.Monedas where x.ID == MonedaFactura select x.Abreviacion).SingleOrDefault();

            decimal MontoPagado = Convert.ToDecimal((from   x in db.JournalDivisions
                                                       where  x.RecibosPago.Facturacion == IDfactura &&
                                                              x.ComprobantesPago.Status == IDstatusAplicado
                                                       select x).ToArray().Sum(x => x.Monto_division));

            decimal MontoNCs = Convert.ToDecimal((from x in db.Facturacions where 
                                                  x.Serie == "NC" && 
                                                  x.ReferenciaFacCancelada == IDfactura && 
                                                  (x.StatusFacturacion == IDstatusFacGen || x.StatusFacturacion == IDstatusRecGen)
                                                  select x).ToArray().Sum(x => x.Total));

            decimal PendienteCobro = TotalFactura - MontoPagado - MontoNCs;
            decimal PendienteDespuesAplicacion = PendienteCobro - reciboPago;

            // Agrega recibo al grid
            dsFacturasSeleccionadas.Rows.Add(new object[] { IDrecibo, reciboSerie, reciboFolio, reciboPagoNumero, reciboInstancias, MonedaAplicar,
                TotalFactura, PendienteCobro, reciboPago, poliza, MontoNCs });
        }

        bool CambioMonedaJournal(int IDFactura, decimal tipoCambioManual = 0)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            string AbrMonedaJournalOriginal = (from x in db.Journals where x.ID == IDjournal select x.Moneda.Abreviacion).SingleOrDefault().ToString();
            string AbrMonedaFactura = (from x in db.Facturacions where x.ID == IDFactura select x.Moneda1.Abreviacion).SingleOrDefault().ToString();
            txtTipoCambio.Value = 0;
            txtTipoCambio.Enabled = false;

            // Caso 1 Monedas Iguales
            if (AbrMonedaFactura == AbrMonedaJournalOriginal)
            {
                if (AbrMonedaFactura == "USD")
                    txtTipoCambio.Value = Convert.ToDecimal((from x in db.Facturacions where x.ID == IDFactura select x.TipoCambio).SingleOrDefault());
                return true;
            }

            // caso 2 Factura MXN y Journal USD (cambiar journal a MXN)
            if (AbrMonedaFactura == "MXN" && AbrMonedaJournalOriginal == "USD")
            {
                decimal MontoJournal = Convert.ToDecimal((from x in db.Journals where x.ID == IDjournal select x.PrimaAplicada).SingleOrDefault());
                cambioUsuario = Extensiones.ConsultaBanxico.ObtenerTipoCambio(Convert.ToDateTime((from x in db.Journals where x.ID == IDjournal select x.Value_Date).SingleOrDefault()));
                if(cambioUsuario == 0)
                {
                    tipoCambio frmTipoCambio = new tipoCambio(true);
                    cambioUsuario = 0;
                    if (tipoCambioManual == 0)
                    {
                        if (frmTipoCambio.ShowDialog() == DialogResult.OK)
                        {
                            txtMonOriginal.Text = "MXN";
                            txtTotalJournal.Value = MontoJournal * cambioUsuario;
                            txtTipoCambio.Value = cambioUsuario;
                            txtTipoCambio.Enabled = true;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No se ha ingresado un tipo de cambio valido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        txtMonOriginal.Text = "MXN";
                        txtTipoCambio.Value = tipoCambioManual;
                        txtTotalJournal.Value = MontoJournal * tipoCambioManual;
                        txtTipoCambio.Enabled = true;
                        return true;
                    }
                }
                else
                {
                    txtMonOriginal.Text = "MXN";
                    txtTotalJournal.Value = MontoJournal * cambioUsuario;
                    txtTipoCambio.Value = cambioUsuario;
                    txtTipoCambio.Enabled = true;
                    return true;
                }
            }

            // caso 2 Factura USD y Journal MXN (cambiar journal a USD)
            if (AbrMonedaFactura == "USD" && AbrMonedaJournalOriginal == "MXN")
            {
                decimal MontoJournal = Convert.ToDecimal((from x in db.Journals where x.ID == IDjournal select x.PrimaAplicada).SingleOrDefault());
                decimal tipoCambioFactura = 0;
                if (tipoCambioManual == 0)
                    tipoCambioFactura = Convert.ToDecimal((from x in db.Facturacions where x.ID == IDFactura select x.TipoCambio).SingleOrDefault());
                else
                    tipoCambioFactura = tipoCambioManual;
                txtMonOriginal.Text = "USD";
                txtTotalJournal.Value = MontoJournal / tipoCambioFactura;
                txtTipoCambio.Value = tipoCambioFactura;
                txtTipoCambio.Enabled = true;

                return true;
            }

            MessageBox.Show("No se pudo realizar la transformación del tipo de cambio del Journal, contactar con soporte. Error de Base de datos", "Error de base datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region eventos

        public BuscarRecibo(string Poliza, int idjournal, Form mainform)
        {
            InitializeComponent();
            Pol = Poliza;
            IDjournal = idjournal;
            MainForm = mainform;
        }

        private void BuscarRecibo_Load(object sender, EventArgs e)
        {
            CargarValoresJournal();
            txtBusqueda.Text = Pol;
            this.buscarRecibosTableAdapter.FillByXpoliza(this.complementosPago.BuscarRecibos, Pol);

            cbParametro.SelectedIndex = 2;
            Extensiones.Traduccion.traducirVentana(this);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            switch (cbParametro.Text)
            {
                case "Numero de Serie":
                    int folio = 0;
                    int.TryParse(txtBusqueda.Text, out folio);
                    this.buscarRecibosTableAdapter.FillByXfolio(this.complementosPago.BuscarRecibos, folio);
                    break;
                case "Poliza":
                    this.buscarRecibosTableAdapter.FillByXpoliza(this.complementosPago.BuscarRecibos, txtBusqueda.Text);
                    break;
                case "RFC Cliente":
                    this.buscarRecibosTableAdapter.FillByXrfc(this.complementosPago.BuscarRecibos, txtBusqueda.Text);
                    break;
                case "Nombre Cliente":
                    this.buscarRecibosTableAdapter.FillByXnombreCliente(this.complementosPago.BuscarRecibos, txtBusqueda.Text);
                    break;
            }
            if (this.complementosPago.BuscarRecibos.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados de la busqueda");
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGenerarComprobante_Click(object sender, EventArgs e)
        {
            // Valiodación de la informacion
            if (!ValidacionRecibos()) return;
            string MensajeComprobacion = "";
            foreach (UltraGridRow row in dgRecibosSeleccionados.Rows)
            {
                MensajeComprobacion += row.Cells["Serie"].Value.ToString() + row.Cells["Folio"].Value.ToString() + ", (" + 
                    row.Cells["Pago #"].Value.ToString() + "/" + row.Cells["Total Instancias"].Value.ToString() + ")" + 
                    row.Cells["Poliza"].Value.ToString() + "        aplicado:   " + row.Cells["Monto a aplicar en este comprobante"].Value.ToString() 
                    + Environment.NewLine;
            }
            MensajeComprobacion += Environment.NewLine + "Al journal con Snum: " + txtSNum.Text + " con un total de " + txtMonOriginal.Text + " $ " + 
                txtTotalJournal.Value + Environment.NewLine + Environment.NewLine;

            if (MessageBox.Show("Se aplicaran las siguientes cuentas en el comprobante de pago:" + Environment.NewLine + Environment.NewLine +
                    MensajeComprobacion + "Continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Seleccion del tipo de comprobante (simple o complejo)
                bool isSimple = true;
                string facturaRow1 = dgRecibosSeleccionados.Rows[0].Cells["Serie"].Value.ToString() + dgRecibosSeleccionados.Rows[0].Cells["Folio"].Value.ToString();
                foreach (UltraGridRow row in dgRecibosSeleccionados.Rows)
                {
                    if (facturaRow1 != row.Cells["Serie"].Value.ToString() + row.Cells["Folio"].Value.ToString())
                    {
                        isSimple = false;
                        break;
                    }
                }

                // Guarda los valores en la base de datos
                dbSmartGDataContext db = new dbSmartGDataContext();                
                int statusTxtgenerado = (from x in db.StatusFacturacions where x.Status == "En Proceso" select x.ID).SingleOrDefault();
                Journal journalModificar = (from x in db.Journals where x.ID == IDjournal select x).SingleOrDefault();
                journalModificar.PrimaAplicada = Math.Round(Convert.ToDecimal(txtTotalJournal.Value), 2);
                journalModificar.MonPrimaAplicada = (from x in db.Monedas where x.Abreviacion == txtMonOriginal.Text select x.ID).SingleOrDefault();
                journalModificar.FormaPago = (from x in db.RecibosPagos where x.ID == Convert.ToInt32(dgRecibosSeleccionados.Rows[0].Cells["ID"].Value) select x.Facturacion1.FormaPagoSAT).SingleOrDefault();
                journalModificar.RFC_EmisorCuentaOrdenante = (from x in db.RecibosPagos where x.ID == Convert.ToInt32(dgRecibosSeleccionados.Rows[0].Cells["ID"].Value) select x.Facturacion1.Cliente).SingleOrDefault();
                journalModificar.tipoCambio = Convert.ToDecimal(txtTipoCambio.Value);
                journalModificar.Status_Aplicacion = statusTxtgenerado;

                ComprobantesPago nuevoComprobante = new ComprobantesPago();
                int nuevoFolioPP = Convert.ToInt32((from x in db.ComprobantesPagos select x.Folio).Max()) + 1;
                nuevoComprobante.Folio = nuevoFolioPP;
                nuevoComprobante.Status = statusTxtgenerado;
                db.ComprobantesPagos.InsertOnSubmit(nuevoComprobante);
                db.SubmitChanges();
                int IDcomprobante = nuevoComprobante.ID;

                string CadenaIDsRecibos = "";
                foreach (UltraGridRow row in dgRecibosSeleccionados.Rows)
                {
                    int IDrecibo = Convert.ToInt32(row.Cells["ID"].Value);
                    CadenaIDsRecibos += IDrecibo + ",";
                    RecibosPago reciboModificar = (from x in db.RecibosPagos where x.ID == IDrecibo select x).SingleOrDefault();
                    reciboModificar.Status = statusTxtgenerado;

                    JournalDivision nuevaDivision = new JournalDivision();
                    nuevaDivision.JournalID = IDjournal;
                    nuevaDivision.ReciboID = IDrecibo;
                    nuevaDivision.ComprobantePagoID = IDcomprobante;
                    nuevaDivision.Monto_division = Math.Round(Convert.ToDecimal(row.Cells["Monto a aplicar en este comprobante"].Value),2);
                    db.JournalDivisions.InsertOnSubmit(nuevaDivision);
                    db.SubmitChanges();
                }

                if (isSimple)
                {
                    Extensiones.TimbradoWSfinkok.TimbrarPagoSimple(IDcomprobante, MainForm);
                }
                else
                {
                    Extensiones.TimbradoWSfinkok.TimbrarPagoMultiple(IDcomprobante, MainForm);
                }
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }
        
        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(null, null);
            }
        }

        private void dgRecibos_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            SeleccionarRecibo();
        }

        private void cbParametro_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
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

        private void dgRecibosSeleccionados_ClickCellButton(object sender, CellEventArgs e)
        {
            if(e.Cell.Column.Key == "Remover")
            {
                dgRecibosSeleccionados.ActiveRow.Delete(false);
                if (dgRecibosSeleccionados.Rows.Count == 0)
                    CargarValoresJournal();
            }
            else if (e.Cell.Column.Key == "Igualar")
            {
                e.Cell.Row.Cells["Monto a aplicar en este comprobante"].Value = txtTotalJournal.Value;
            }

        }

        private void txtTipoCambio_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtTipoCambio.Value) >= 1)
            {
                if (dgRecibosSeleccionados.Rows.Count > 0)
                {
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    int idfac = (from x in db.RecibosPagos where x.ID == Convert.ToInt32(dgRecibosSeleccionados.Rows[0].Cells["ID"].Value) select x.Facturacion1.ID).SingleOrDefault();
                    CambioMonedaJournal(idfac, Convert.ToDecimal(txtTipoCambio.Value));
                }
            }
            else
            {
                MessageBox.Show("Valor no valido","Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
        }

        private void btnAplicarWriteOff_Click(object sender, EventArgs e)
        {
            WriteOff writeOffNuevo = new WriteOff(IDjournal);
            if (writeOffNuevo.ShowDialog() == DialogResult.Yes)
            {
                do
                {
                    try
                    {
                        foreach (UltraGridRow row in dgRecibosSeleccionados.Rows)
                        {
                            row.Delete(false);
                        }
                        CargarValoresJournal();
                    }
                    catch { }
                }
                while (dgRecibosSeleccionados.Rows.Count > 0);
            }
        }

        #endregion
        }
}
