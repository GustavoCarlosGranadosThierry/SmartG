using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SmartG.Operaciones.CreditControl
{
    public partial class IngresoEstadoCuentaBancarios : Form
    {

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // coleccion objetos
        #region objetos

            //btnConsultarEdoCuenta Consultar
            //checkBox_Check checkBox Check
            //tabEstados_de_Cuentas   Estados de Cuentas
            //btnImportarPortapapelesExcel    Importar Portapapeles Excel
            //btnGuardarenBasedeDatos Guardar en Base de Datos
            //btnCargarRegistrosnoRelacionados    Cargar Registros no Relacionados
            //btnConsultarRegistosRelacionados Consultar los Registros Ligados a Journals
            //btnGenerarReporte   Generar Reporte
            //MainEstadoCuenta Estados de Cuenta
            //rgbIngreso Ingreso de Cuentas

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region variables

        string[] columnasObligatorias;
        bool BuscarHuerf;
        Datasets.CreditControl.ComplementosPagoTableAdapters.JournalCuentasBancariasTableAdapter JournalCuentasBancariasTableAdapter = new Datasets.CreditControl.ComplementosPagoTableAdapters.JournalCuentasBancariasTableAdapter();
        Datasets.CreditControl.ComplementosPagoTableAdapters.JournalTableAdapter JournalTableAdapter = new Datasets.CreditControl.ComplementosPagoTableAdapters.JournalTableAdapter();

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region metodos

        void CargarDataSets()
        {
            this.checkJournalCuentasTableAdapter.Fill(this.complementosPago.CheckJournalCuentas);
        }

        void FormatearColumnasGrid()
        {
            columnasObligatorias = new string[16];
            columnasObligatorias[0] = "Fecha";
            columnasObligatorias[1] = "CONCEPTO TRANSACCION";
            columnasObligatorias[2] = "MONTO";
            columnasObligatorias[3] = "REFERENCIA NUMERICA";
            columnasObligatorias[4] = "REF ALFANUMERICA";
            columnasObligatorias[5] = "DIVISA";
            columnasObligatorias[6] = "TIPO OPERACIÓN";
            columnasObligatorias[7] = "NOMBRE ORDENANTE";
            columnasObligatorias[8] = "CUENTA ORDENANTE";
            columnasObligatorias[9] = "RFC ORDENANTE";
            columnasObligatorias[10] = "BANCO ORDENANTE";
            columnasObligatorias[11] = "NOMBRE BENEFICIARIO";
            columnasObligatorias[12] = "RFC BENEFICIARIO";
            columnasObligatorias[13] = "CUENTA BENEFICIARIO";
            columnasObligatorias[14] = "CLAVE RASTREO";
            columnasObligatorias[15] = "Cuenta Virtual";
        }

        void ImportarExcel()
        {
            CerrarCheck();
            dgBanamex.DataSource = null;
            dgBanamex.AllowUserToAddRows = true;

            DataObject o = (DataObject)Clipboard.GetDataObject();
            if (o.GetDataPresent(DataFormats.Text))
            {
                if (dgBanamex.RowCount > 0)
                    dgBanamex.Rows.Clear();

                if (dgBanamex.ColumnCount > 0)
                    dgBanamex.Columns.Clear();

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
                                dgBanamex.Columns.Add(pastedRowCells[i], pastedRowCells[i]);
                        }
                        catch
                        {
                            MessageBox.Show("Error en el formato fuente, verifique la información", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgBanamex.Rows.Clear();
                            dgBanamex.Columns.Clear();
                            return;
                        }

                        columnsAdded = true;
                        continue;
                    }

                    dgBanamex.Rows.Add();
                    int myRowIndex = dgBanamex.Rows.Count - 1;

                    using (DataGridViewRow myDataGridViewRow = dgBanamex.Rows[j])
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            myDataGridViewRow.Cells[i].Value = pastedRowCells[i];
                    }
                    j++;
                }
            }

            bool control = false;

            for (int i = 0; i < columnasObligatorias.Count(); i++)
            {
                for (int j = 0; j < dgBanamex.Columns.Count; j++)
                {
                    if (columnasObligatorias[i] == dgBanamex.Columns[j].HeaderText)
                    {
                        control = true;
                    }
                }

                if (!control)
                {
                    MessageBox.Show("No está la columna " + columnasObligatorias[i] + " en la información ingresada, favor de verificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgBanamex.Rows.Clear();
                    dgBanamex.Columns.Clear();
                    return;
                }
            }

            if (dgBanamex.Columns.Count < 16)
            {
                MessageBox.Show("No se han ingresado todas las columnas, verifique la información", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgBanamex.Rows.Clear();
                dgBanamex.Columns.Clear();
                return;

            }

            // Borrado duplicados
            int ConteoDuplicados = 0;
            DataTable dtConsulta = JournalCuentasBancariasTableAdapter.GetData();

            for (int i = dgBanamex.Rows.Count - 1; i >= 0; i--)
            {
                try
                {
                    string ClaveRasteo = dgBanamex.Rows[i].Cells["CLAVE RASTREO"].FormattedValue.ToString().Replace(" ", "");
                    foreach (DataRow dtRow in dtConsulta.Rows)
                    {
                        if (ClaveRasteo == dtRow["CLAVE_RASTREO"].ToString().Replace(" ", ""))
                        {
                            dgBanamex.Rows.Remove(dgBanamex.Rows[i]);
                            ConteoDuplicados++;
                            continue;
                        }
                    }
                }
                catch { }
            }
            if (ConteoDuplicados > 0)
            {
                MessageBox.Show("Se encontraron : " + ConteoDuplicados + " registros duplicados con la Base de datos, por lo que fueron removidos"
                    , "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            AgregarColumnas();
        }

        void AgregarColumnas()
        {
            // Agrega la Columna de busqueda con el Journal ID, Agrega la columna de Alerta Deposito en Efectivo e Identifica al Cliente
            dgBanamex.Columns.Add("IDJournal", "IDJournal");
            dgBanamex.Columns.Add("IDCliente", "IDCliente");
            dgBanamex.Columns.Add("Status", "Status");

            int ContadorJournals = 0;

            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "DepositoEfectivo";
            checkColumn.HeaderText = "DepositoEfectivo";
            checkColumn.Width = 100;
            checkColumn.ReadOnly = true;
            dgBanamex.Columns.Add(checkColumn);
            string ClaveEfectivo = "EFEC";

            foreach (DataGridViewRow row in dgBanamex.Rows)
            {
                if (row.Cells["MONTO"].FormattedValue.ToString() == "") { continue; }
                else
                {
                    // Relacion a Journal y status
                    decimal MontoBanamex = 0;
                    try { MontoBanamex = Convert.ToDecimal(row.Cells["MONTO"].FormattedValue.ToString().Replace('$', ' ')); }
                    catch { }
                    string MonedaBanamex = row.Cells["DIVISA"].FormattedValue.ToString();
                    string RFCCliente = ""; try { RFCCliente = row.Cells["RFC ORDENANTE"].FormattedValue.ToString(); } catch { }
                    string NomCliente = ""; try { NomCliente = row.Cells["NOMBRE ORDENANTE"].FormattedValue.ToString(); } catch { }
                    DateTime dtBanamex = DateTime.Now;
                    try { dtBanamex = FechaBanamex(row.Cells["Fecha"].FormattedValue.ToString()); }
                    catch { dtBanamex = Convert.ToDateTime(row.Cells["Fecha"].FormattedValue.ToString()); }
                    DateTime p1 = dtBanamex.AddDays(-2);
                    DateTime p2 = dtBanamex.AddDays(2);

                    dbSmartGDataContext db = new dbSmartGDataContext();
                    Journal temJournal = (from x in db.Journals
                                          where
                    x.Acc_Ccy == MonedaBanamex &&
                    x.Acc_Amount == MontoBanamex &&
                    x.Value_Date >= p1 && x.Value_Date <= p2
                                          select x).FirstOrDefault();

                    if (temJournal == null)
                    {
                        row.Cells["IDJournal"].Value = "";
                        row.Cells["Status"].Value = "No Aplicado";

                    }
                    else
                    {
                        row.Cells["IDJournal"].Value = temJournal.ID;
                        row.Cells["Status"].Value = "Aplicado";
                        ContadorJournals++;
                    }

                    // Deposito en efectivo
                    try
                    {
                        if (row.Cells["TIPO OPERACIÓN"].FormattedValue.ToString().Contains(ClaveEfectivo))
                            row.Cells["DepositoEfectivo"].Value = true;
                    }
                    catch
                    {
                        if (row.Cells["TIPO_OPERACIÓN"].FormattedValue.ToString().Contains(ClaveEfectivo))
                            row.Cells["DepositoEfectivo"].Value = true;
                    }

                    // Busqueda del Cliente
                    int IDCliente = 0;
                    if (RFCCliente == "XEXX01010100")
                    {
                        try { IDCliente = (from x in db.Clientes where x.RFC == RFCCliente && x.RazonSocial == NomCliente select x.ID).SingleOrDefault(); } catch { }
                    }
                    else
                    {
                        try { IDCliente = (from x in db.Clientes where x.RFC == RFCCliente select x.ID).SingleOrDefault(); } catch { }
                    }
                    if (IDCliente != 0)
                    {
                        row.Cells["IDCliente"].Value = IDCliente;
                    }
                    else
                    {
                        row.Cells["IDCliente"].Value = "";
                    }
                }
            }

            DataGridViewComboBoxColumn ComboColumn = new DataGridViewComboBoxColumn();
            ComboColumn.Name = "Categoria";
            ComboColumn.HeaderText = "Categoria";
            ComboColumn.Width = 100;
            ComboColumn.ReadOnly = true;
            ComboColumn.Items.Add("Deposito de Prima");
            ComboColumn.Items.Add("Otros");
            ComboColumn.ReadOnly = false;
            ComboColumn.DefaultCellStyle.NullValue = "Deposito de Prima";
            dgBanamex.Columns.Add(ComboColumn);

            // Ordena las columnas
            dgBanamex.Columns["Categoria"].DisplayIndex = 0;
            dgBanamex.Columns["Status"].DisplayIndex = 1;
            dgBanamex.Columns["IDJournal"].DisplayIndex = 2;
            dgBanamex.Columns["IDCliente"].DisplayIndex = 2;
            dgBanamex.Columns["DepositoEfectivo"].DisplayIndex = 3;
            try { dgBanamex.Columns["CLAVE RASTREO"].DisplayIndex = 4; } catch { dgBanamex.Columns["CLAVE_RASTREO"].DisplayIndex = 4; }

            dgBanamex.AllowUserToAddRows = false;
            MessageBox.Show("Información importada satisfactoriamente." + Environment.NewLine + Environment.NewLine +
                "Se encontraron : " + ContadorJournals + " coincidencias con los Journals actuales" + Environment.NewLine
                + "de un total de: " + dgBanamex.Rows.Count + " registros de Bancarios ingresados", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        void GuardarRegistros()
        {
            CerrarCheck();

            bool update = false;
            try
            {
                if (Convert.ToInt32(dgBanamex.Columns["ID"].Index) >= 0)
                {
                    update = true;
                }
            }
            catch { }

            int ConteoExito = 0;
            int ConteoError = 0;
            int DepEfectivo = 0;
            string LogErrores = "";

            dbSmartGDataContext db = new dbSmartGDataContext();
            foreach (DataGridViewRow row in dgBanamex.Rows)
            {
                if (row.Cells["MONTO"].FormattedValue.ToString() == "") { continue; }
                try
                {
                    int? JournalID = null; try { JournalID = Convert.ToInt32(row.Cells["IDJournal"].FormattedValue.ToString()); } catch { }
                    int? ClienteID = null; try { ClienteID = Convert.ToInt32(row.Cells["IDCliente"].FormattedValue.ToString()); } catch { }

                    if (update == false)
                    {
                        JournalCuentasBancaria newJournalCuenta = new JournalCuentasBancaria();
                        newJournalCuenta.Fecha = FechaBanamex(row.Cells["Fecha"].FormattedValue.ToString());
                        newJournalCuenta.CONCEPTO_TRANSACCION = row.Cells["CONCEPTO TRANSACCION"].FormattedValue.ToString();
                        newJournalCuenta.MONTO = Convert.ToDecimal(row.Cells["MONTO"].FormattedValue.ToString().Replace("$", "")).ToString("N2");
                        newJournalCuenta.REFERENCIA_NUMERICA = row.Cells["REFERENCIA NUMERICA"].FormattedValue.ToString();
                        newJournalCuenta.REF_ALFANUMERICA = row.Cells["REF ALFANUMERICA"].FormattedValue.ToString();
                        newJournalCuenta.DIVISA = row.Cells["DIVISA"].FormattedValue.ToString();
                        newJournalCuenta.TIPO_OPERACIÓN = row.Cells["TIPO OPERACIÓN"].FormattedValue.ToString();
                        newJournalCuenta.NOMBRE_ORDENANTE = row.Cells["NOMBRE ORDENANTE"].FormattedValue.ToString();
                        newJournalCuenta.CUENTA_ORDENANTE = row.Cells["CUENTA ORDENANTE"].FormattedValue.ToString();
                        newJournalCuenta.RFC_ORDENANTE = row.Cells["RFC ORDENANTE"].FormattedValue.ToString();
                        newJournalCuenta.BANCO_ORDENANTE = row.Cells["BANCO ORDENANTE"].FormattedValue.ToString();
                        newJournalCuenta.NOMBRE_BENEFICIARIO = row.Cells["NOMBRE BENEFICIARIO"].FormattedValue.ToString();
                        newJournalCuenta.RFC_BENEFICIARIO = row.Cells["RFC BENEFICIARIO"].FormattedValue.ToString();
                        newJournalCuenta.CUENTA_BENEFICIARIO = row.Cells["CUENTA BENEFICIARIO"].FormattedValue.ToString();
                        newJournalCuenta.CLAVE_RASTREO = row.Cells["CLAVE RASTREO"].FormattedValue.ToString();
                        newJournalCuenta.Cuenta_Virtual = row.Cells["Cuenta Virtual"].FormattedValue.ToString();
                        newJournalCuenta.Status = (from x in db.StatusFacturacions where x.Status == row.Cells["Status"].FormattedValue.ToString() select x.ID).SingleOrDefault();
                        newJournalCuenta.Journal = JournalID;
                        newJournalCuenta.Cliente = ClienteID;
                        newJournalCuenta.Efectivo = Convert.ToBoolean(row.Cells["DepositoEfectivo"].FormattedValue.ToString());
                        newJournalCuenta.Categoria = row.Cells["Categoria"].FormattedValue.ToString();
                        db.JournalCuentasBancarias.InsertOnSubmit(newJournalCuenta);
                        db.SubmitChanges();
                    }
                    else
                    {
                        if (JournalID != null)
                        {
                            JournalCuentasBancaria updateJournalCuenta = (from x in db.JournalCuentasBancarias where x.ID == Convert.ToInt32(row.Cells["ID"].FormattedValue.ToString()) select x).SingleOrDefault();
                            updateJournalCuenta.Status = (from x in db.StatusFacturacions where x.Status == row.Cells["Status"].FormattedValue.ToString() select x.ID).SingleOrDefault();
                            updateJournalCuenta.Journal = JournalID;
                            updateJournalCuenta.Cliente = ClienteID;
                            updateJournalCuenta.Efectivo = Convert.ToBoolean(row.Cells["DepositoEfectivo"].FormattedValue.ToString());
                            updateJournalCuenta.Categoria = row.Cells["Categoria"].FormattedValue.ToString();
                            db.SubmitChanges();
                        }
                        else ConteoExito--;
                    }

                    // Actualiza datos directamente en el registro del Journal
                    if (JournalID != null)
                    {
                        int? idFormaPago = null;
                        if (row.Cells["TIPO OPERACIÓN"].FormattedValue.ToString() == "TRANSF ELECTR")
                            idFormaPago = (from x in db.FormaPagoSATs where x.Descripcion == "Transferencia electrónica de fondos" select x.ID).SingleOrDefault();
                        string BancoOrdenante = row.Cells["BANCO ORDENANTE"].FormattedValue.ToString();
                        BancoOrdenante = BancoOrdenante.Replace(" ", "").Replace(".", "").Replace(",", "").ToUpper();
                        Journal updateJournal = (from x in db.Journals where x.ID == JournalID select x).SingleOrDefault();
                        updateJournal.FormaPago = idFormaPago;
                        updateJournal.RFC_EmisorCuentaOrdenante = ClienteID;
                        updateJournal.Cuenta_BancoOrdenante = BancoOrdenante;
                        db.SubmitChanges();
                    }
                    if (Convert.ToBoolean(row.Cells["DepositoEfectivo"].FormattedValue.ToString()))
                    {
                        DepEfectivo++;
                    }
                    ConteoExito++;

                }
                catch (Exception ex)
                {
                    ConteoError++;
                    LogErrores += "Error, clave rastreo: " + row.Cells["CLAVE RASTREO"].FormattedValue.ToString() + ", descripción: " + ex.Message + Environment.NewLine
                        + Environment.NewLine;
                }
            }

            MessageBox.Show("Se han procesado " + ConteoExito + " registros exitos de un total de " + (dgBanamex.Rows.Count).ToString() + " y se encontraron "
                + ConteoError + " errores", "Procesamiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            if (ConteoExito > 0)
            {
                // FIX Extensiones.AgregarLog("Journal / Estado Cuenta", "Insert", 0, "Agregados " + ConteoExito + " registros a la base de datos con información de Depositos desde Estados de cuenta Bancarios");
            }

            if (ConteoError > 0)
            {
                MessageBox.Show("Log de errores de procesamiento:" + Environment.NewLine + Environment.NewLine + LogErrores, "Errores de Procesamiento",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (DepEfectivo > 0)
            {
                MessageBox.Show("Se han encontrado un total de " + DepEfectivo + " depositos en efectivo realizados. Se generará el reporte correspondiente para su envio a compliance.", "Deposito Efectivo",
                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DepositoEfectivoEncontrado();
            }
            try { dgBanamex.Rows.Clear(); } catch { dgBanamex.DataSource = null; }
            dgBanamex.DataSource = null;
            dgBanamex.Columns.Clear();

            checkBox_Check.Checked = false;
            CambiarLayout();
            CargarDataSets();
        }

        void CargarHuefanos()
        {
            CerrarCheck();

            DataTable dt_Cuentas = JournalCuentasBancariasTableAdapter.GetDataByNoAsignados();
            if (dt_Cuentas.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros en Status No Asignado en la base de datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                dt_Cuentas.Columns.Remove("Status");
                dt_Cuentas.Columns.Remove("Journal");
                dt_Cuentas.Columns.Remove("Cliente");
                dt_Cuentas.Columns.Remove("Efectivo");
                dt_Cuentas.Columns.Remove("Categoria");

                dgBanamex.DataSource = null;
                dgBanamex.Columns.Clear();
                dgBanamex.Rows.Clear();
                dgBanamex.DataSource = dt_Cuentas;
                AgregarColumnas();
            }
        }

        void DepositoEfectivoEncontrado()
        {
            Operaciones.Compliance.Compliance frmComp = new Compliance.Compliance(true);
            frmComp.ShowDialog();
        }

        DateTime FechaBanamex(string FechaSTR)
        {
            int Dia = 0;
            int Mes = 0;
            int Año = 0;

            try
            {
                Dia = Convert.ToInt32(FechaSTR.Substring(0, 2));
                Mes = Convert.ToInt32(FechaSTR.Substring(3, 2));
                Año = Convert.ToInt32(FechaSTR.Substring(6, 4));
            }
            catch
            {
                string[] fechaSplit = FechaSTR.Split('/');
                Dia = Convert.ToInt32(fechaSplit[1]);
                Mes = Convert.ToInt32(fechaSplit[0]);
                Año = Convert.ToInt32(fechaSplit[2]);
            }

            DateTime result = new DateTime(Año, Mes, Dia);
            return result;
        }

        void CerrarCheck()
        {
            checkBox_Check.Checked = true;
            CambiarLayout();
        }

        void CambiarLayout()
        {
            if (!checkBox_Check.Checked) // Abre
            {
                checkBox_Check.Checked = true;
                CargarDataSets();
                grpBusqueda.Enabled = true;
                dgCheck.Visible = true;
                dgBanamex.Visible = false;
                ToolsBarEstadoCuentas.Tools["btnConsultarRegistosRelacionados"].SharedProps.Caption = "Cerrar Consulta de los Registros Ligados a Journals";
                ToolsBarEstadoCuentas.Tools["btnImportarPortapapelesExcel"].SharedProps.Enabled = false;
                ToolsBarEstadoCuentas.Tools["btnGuardarenBasedeDatos"].SharedProps.Enabled = false;
                ToolsBarEstadoCuentas.Tools["btnCargarRegistrosnoRelacionados"].SharedProps.Enabled = false;
            }
            else // cierra
            {
                checkBox_Check.Checked = false;
                grpBusqueda.Enabled = false;
                dgCheck.Visible = false;
                dgBanamex.Visible = true;
                ToolsBarEstadoCuentas.Tools["btnConsultarRegistosRelacionados"].SharedProps.Caption = "Consultar los Registros Ligados a Journals";
                ToolsBarEstadoCuentas.Tools["btnImportarPortapapelesExcel"].SharedProps.Enabled = true;
                ToolsBarEstadoCuentas.Tools["btnGuardarenBasedeDatos"].SharedProps.Enabled = true;
                ToolsBarEstadoCuentas.Tools["btnCargarRegistrosnoRelacionados"].SharedProps.Enabled = true;
            }
        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region eventos

        public IngresoEstadoCuentaBancarios(bool BuscarHuerfanos = false)
        {
            InitializeComponent();
            BuscarHuerf = BuscarHuerfanos;

        }

        private void IngresoEstadoCuentaBancarios_Load(object sender, EventArgs e)
        {
            CargarDataSets();
            FormatearColumnasGrid();
            checkBox_Check.Checked = true;
            CambiarLayout();

            if (BuscarHuerf) CargarHuefanos();
            Extensiones.Traduccion.traducirVentana(this,AdminFactTabControl,ToolsBarEstadoCuentas);

        }

        private void ToolsBarEstadoCuentas_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btnImportarPortapapelesExcel":
                    ImportarExcel();
                    break;

                case "btnGuardarenBasedeDatos":
                    GuardarRegistros();
                    break;

                case "btnCargarRegistrosnoRelacionados":
                    CargarHuefanos();
                    break;

                case "btnConsultarRegistosRelacionados":
                    CambiarLayout();
                    break;

                case "btnActualizar":
                    CargarDataSets();       
                    break;
            }
        }

        private void validarCB(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
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

        #endregion

    }
}
