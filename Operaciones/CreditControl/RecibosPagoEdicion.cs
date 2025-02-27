using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SmartG.Operaciones.CreditControl
{
    public partial class RecibosPagoEdicion : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // coleccion objetos
        #region objetos

            //lbIniVig Inicio de Vigencia:
            //lbFinVig Fin de Vigencia:
            //lbTotalFactura Total de la Factura:
            //btnGuardar Guardar
            //btnCancelar Cancelar
            //lbTotalRecibos Total en los Recibos

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region variables

        int IDFactura;

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region metodos

        void RecuperarDatos()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            RecibosPagoEspecial[] recuperarRecibos = (from x in db.RecibosPagoEspecials where x.Facturacion == IDFactura select x).ToArray();
            for (int i = 0; i < recuperarRecibos.Count(); i++)
            {
                dsRecibosPago.Rows.Add(new object[]
                {
                    recuperarRecibos[i].X,
                    recuperarRecibos[i].IniVig_Part,
                    recuperarRecibos[i].FinVig_Part,
                    (Convert.ToDateTime( recuperarRecibos[i].duedate) - Convert.ToDateTime(recuperarRecibos[i].FinVig_Part)).TotalDays,
                    recuperarRecibos[i].duedate,
                    recuperarRecibos[i].sche_primaNeta_part,
                    recuperarRecibos[i].sche_impuestos_part,
                    recuperarRecibos[i].sche_primaTotal_part
                });
            }
            dgRecibosPago.DisplayLayout.Bands[0].SortedColumns.Clear();
            dgRecibosPago.DisplayLayout.Bands[0].Columns["Pago #"].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending;

        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region eventos

        public RecibosPagoEdicion(int idFactura)
        {
            InitializeComponent();
            IDFactura = idFactura;
        }

        private void RecibosPagoEdicion_Load(object sender, EventArgs e)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            SmartG.Facturacion fact = (from x in db.Facturacions where x.ID == IDFactura select x).SingleOrDefault();
            dateIniVig.Value = fact.iniVig;
            dateFinVig.Value = fact.finVig;
            txtPrimaTotal.Value = fact.Total;
            txtImpuestos.Value = Convert.ToDecimal((from x in db.Facturacions where x.ID == IDFactura select (x.ImpuestosTransladados / x.Subtotal)).SingleOrDefault());

            if ((from x in db.RecibosPagoEspecials where x.Facturacion == IDFactura select x).ToArray().Count() > 0)
                RecuperarDatos();
            //Extensiones.Traduccion.traducirVentana(this);
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Se borraran los registros y regresara a una distribución de pago de contado, continuar?","Mensaje",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if(dgRecibosPago.Rows.Count < 2)
            {
                MessageBox.Show("Debe ingresar por lo menos 1 linea de recibos para guardar esta operación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool TodosValoresIngresados = true;
            bool FechasCorrectas = true;
            bool FechasEmpalmadas = true;
            DateTime minInicio = DateTime.Now.AddYears(1000);
            DateTime maxFin = DateTime.Now.AddYears(-1000);
            dgRecibosPago.DisplayLayout.Bands[0].SortedColumns.Clear();
            dgRecibosPago.DisplayLayout.Bands[0].Columns["Pago #"].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending;
            for (int i = 0; i < dgRecibosPago.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgRecibosPago.Rows[i].Cells["Pago #"].Value) <= 0 ||
                     dgRecibosPago.Rows[i].Cells["Inicio Vigencia Recibo"].Text == "" ||
                     dgRecibosPago.Rows[i].Cells["Fin Vigencia Recibo"].Text == "" ||
                     Convert.ToInt32(dgRecibosPago.Rows[i].Cells["Plazo Pago"].Value) <= 0 ||
                     Convert.ToDecimal(dgRecibosPago.Rows[i].Cells["Prima Total"].Value) == 0)
                {
                    TodosValoresIngresados = false;
                    break;
                }
                if (Convert.ToDateTime(dgRecibosPago.Rows[i].Cells["Inicio Vigencia Recibo"].Value) >= Convert.ToDateTime(dgRecibosPago.Rows[i].Cells["Fin Vigencia Recibo"].Value))
                {
                    FechasCorrectas = false;
                    break;
                }
                if (Convert.ToDateTime(dgRecibosPago.Rows[i].Cells["Inicio Vigencia Recibo"].Value) < minInicio) minInicio = Convert.ToDateTime(dgRecibosPago.Rows[i].Cells["Inicio Vigencia Recibo"].Value);
                if (Convert.ToDateTime(dgRecibosPago.Rows[i].Cells["Fin Vigencia Recibo"].Value) > maxFin) maxFin = Convert.ToDateTime(dgRecibosPago.Rows[i].Cells["Fin Vigencia Recibo"].Value);

                if (i !=0)
                {
                    if(chkFechasInterpuestas.Checked == false)
                    {
                        if (Convert.ToDateTime(dgRecibosPago.Rows[i].Cells["Inicio Vigencia Recibo"].Value) < Convert.ToDateTime(dgRecibosPago.Rows[i - 1].Cells["Fin Vigencia Recibo"].Value))
                        {
                            FechasEmpalmadas = false;
                            break;
                        }
                    }
                }
            }
            if (!TodosValoresIngresados)
            {
                MessageBox.Show("Faltan datos a ingresar en la tabla de recibos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!FechasCorrectas)
            {
                MessageBox.Show("Las fechas ingresadas de inicio y fin de vigencia son incorrectas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Math.Round(Convert.ToDecimal(txtTotalRecibos.Value), 2) != Math.Round(Convert.ToDecimal(txtPrimaTotal.Value), 2))
            {
                MessageBox.Show("La suma de los recibos no es igual al total de la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(Convert.ToDateTime(dateFinVig.Value).Date != maxFin.Date )
            {
                MessageBox.Show("La fecha de fin de vigencia ingresada en los recibos no corresponde con la de la poliza", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToDateTime(dateIniVig.Value).Date != minInicio.Date)
            {
                MessageBox.Show("La fecha de inicio de vigencia ingresada en los recibos no corresponde con la de la poliza", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!FechasEmpalmadas)
            {
                MessageBox.Show("Las fechas ingresadas en el los recibos se empalman con fechas anteriores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Borrar Datos anteriores
            dbSmartGDataContext db = new dbSmartGDataContext();
            RecibosPagoEspecial[] recibosBorrar = (from x in db.RecibosPagoEspecials where x.Facturacion == IDFactura select x).ToArray();
            if (recibosBorrar.Count() > 0)
            {
                db.RecibosPagoEspecials.DeleteAllOnSubmit(recibosBorrar);
                db.SubmitChanges();
            }


            // Guardado de datos
            decimal primaPendiente = Convert.ToDecimal(txtPrimaTotal.Value);
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgRecibosPago.Rows)
            {
                primaPendiente = Math.Round(primaPendiente - Convert.ToDecimal(item.Cells["Prima Total"].Value), 2);
                RecibosPagoEspecial newRecibo = new RecibosPagoEspecial();
                newRecibo.Facturacion = IDFactura;
                newRecibo.X = Convert.ToInt32(item.Cells["Pago #"].Value);
                newRecibo.Y = dgRecibosPago.Rows.Count;
                newRecibo.IniVig_Part = Convert.ToDateTime(item.Cells["Inicio Vigencia Recibo"].Value);
                newRecibo.FinVig_Part = Convert.ToDateTime(item.Cells["Fin Vigencia Recibo"].Value);
                newRecibo.duedate = Convert.ToDateTime(item.Cells["Fecha Limite Pago"].Value);
                newRecibo.sche_primaNeta_part = Convert.ToDecimal(item.Cells["Prima Neta"].Value);
                newRecibo.sche_impuestos_part = Convert.ToDecimal(item.Cells["Impuesto"].Value);
                newRecibo.sche_primaTotal_part = Convert.ToDecimal(item.Cells["Prima Total"].Value);
                newRecibo.sche_primaTotal_pendiente = primaPendiente;
                db.RecibosPagoEspecials.InsertOnSubmit(newRecibo);
                db.SubmitChanges();
            }
            Facturacion.NuevoIniVig = Convert.ToDateTime(dateIniVig.Value);
            Facturacion.NuevoFinVig = Convert.ToDateTime(dateFinVig.Value);

            MessageBox.Show("Distribución de recibos de pago personalizada guardada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void dgRecibosPago_AfterRowInsert(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            int RowIndex = dgRecibosPago.Rows.Count - 1;
            if (RowIndex == 0)
            {
                dgRecibosPago.Rows[RowIndex].Cells["Pago #"].Value = 1;
                dgRecibosPago.Rows[RowIndex].Cells["Inicio Vigencia Recibo"].Value = Convert.ToDateTime(dateIniVig.Value);
                return;
            }

            try { dgRecibosPago.Rows[RowIndex].Cells["Pago #"].Value = Convert.ToInt32(dgRecibosPago.Rows[RowIndex - 1].Cells["Pago #"].Value) + 1; } catch { }
            try { dgRecibosPago.Rows[RowIndex].Cells["Inicio Vigencia Recibo"].Value = Convert.ToDateTime(dgRecibosPago.Rows[RowIndex - 1].Cells["Fin Vigencia Recibo"].Value); } catch { }

        }

        private void dgRecibosPago_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            dgRecibosPago.ActiveRow.Delete(false);
        }

        #endregion

    }
}
