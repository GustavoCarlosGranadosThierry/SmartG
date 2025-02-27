using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Operaciones.CreditControl
{
    public partial class EdiciónVariosPagadores : Form
    {
        int IDPoliza;

        public EdiciónVariosPagadores(int idPoliza)
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
            IDPoliza = idPoliza;
        }

        private void EdiciónVariosPagadores_Load(object sender, EventArgs e)
        {
            this.clientesTableAdapter.Fill(this.catalogosGral.Clientes);
            dbSmartGDataContext db = new dbSmartGDataContext();
            txtPrimaTotal.Value = Convert.ToDecimal((from x in db.InfoSchedule where x.Poliza == IDPoliza select x.TotalPoliza).SingleOrDefault());
            decimal IVA = 0;
            string IVA_StrBD= (from x in db.InfoSchedule where x.Poliza == IDPoliza select x.IVA).SingleOrDefault();
            switch (IVA_StrBD)
            {
                case "16%": IVA = 0.16M; break;
                case "0%": IVA = 0; break;
                case "Exento": IVA = 0; break;
                default: IVA = 0; break;
            }
            txtImpuestos.Value = IVA;
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                this.clientesTableAdapter.FillByNomComp(this.catalogosGral.Clientes, txtBusqueda.Text);
        }

        private void dgClientes_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            dsClientesSelec.Rows.Add(new object[] {
                dgClientes.ActiveRow.Cells["ID"].Value,
                dgClientes.ActiveRow.Cells["NomComp"].Value,
                dgClientes.ActiveRow.Cells["RFC"].Value,
                0 });
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(Convert.ToDecimal( txtPrimaTotal.Value )!= Convert.ToDecimal( txtPrimaAsignada.Value))
            {
                if( MessageBox.Show("Los montos de las primas asignadas no son iguales a la prima total, desea continuar de esta manera?", "Error Calculo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgSeleccion.Rows)
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                SmartG.Facturacion newFactura = new SmartG.Facturacion();
                Poliza poliza = (from x in db.Poliza where x.ID == IDPoliza select x).SingleOrDefault();
                InfoSchedule polizaInfo = (from x in db.InfoSchedule where x.Poliza == IDPoliza select x).SingleOrDefault();

                newFactura.TipoDocumento = (from x in db.TipoDocumentos where x.Descripcion == "Factura" select x.ID).SingleOrDefault();
                newFactura.Serie = "F";
                newFactura.FormaPagoSAT = (from x in db.FormaPagoSATs where x.Descripcion == "Por definir" select x.ID).SingleOrDefault();
                newFactura.CondicionesPago = polizaInfo.FormaPago;
                newFactura.MetodoPago = (from x in db.MetodoPagos where x.Codigo == "PPD" select x.ID).SingleOrDefault();
                newFactura.UsoCDFI = (from x in db.UsoCDFIs where x.Codigo == "P01" select x.ID).SingleOrDefault();
                newFactura.DireccionCompañia = (from x in db.EmpresaDetalles where x.Principal == true select x.ID).SingleOrDefault();
                newFactura.Plazo = 30;
                newFactura.LimitePago = Convert.ToDateTime(poliza.Emision).AddDays(30);
                newFactura.Cliente = Convert.ToInt32(item.Cells["ID"].Value);
                newFactura.ClienteDireccion = (from x in db.ClientesDirecciones where x.Cliente == Convert.ToInt32(item.Cells["ID"].Value) && x.Eliminado == false select x.ID).FirstOrDefault();

                // Cuenta bancaria cobranza universal
                SmartG.ClienteCuentaBancaria nuevaCuentaCliente;
                nuevaCuentaCliente = (from x in db.ClienteCuentaBancarias where (newFactura.Cliente == x.Cliente && 2 == x.CuentaBancaria) select x).SingleOrDefault();
                if (nuevaCuentaCliente == null)
                    nuevaCuentaCliente = new ClienteCuentaBancaria();

                nuevaCuentaCliente.Cliente = newFactura.Cliente;
                nuevaCuentaCliente.CuentaBancaria = 2;
                if (nuevaCuentaCliente.ID == 0)
                    db.ClienteCuentaBancarias.InsertOnSubmit(nuevaCuentaCliente);
                db.SubmitChanges();
                int idClienteCuenta = nuevaCuentaCliente.ID;
                newFactura.ClienteCuentaBancaria = idClienteCuenta;

                // Calculo del tipo de cambio
                newFactura.Moneda = poliza.Moneda;
                decimal tipoCambio = 1;
                if ((from x in db.Monedas where x.ID == poliza.Moneda select x.Abreviacion).SingleOrDefault() == "USD")
                {
                    try
                    {
                        tipoCambio = Extensiones.ConsultaBanxico.ObtenerTipoCambio(DateTime.Now);
                    }
                    catch
                    {
                        tipoCambio = 0;
                    }
                }

                if (tipoCambio != 0) newFactura.TipoCambio = tipoCambio;

                newFactura.Subtotal = Convert.ToDecimal(item.Cells["MontoPrimaTotal"].Value) / 1.16M;
                newFactura.Descuentos = 0;
                newFactura.ImpuestosTransladados = newFactura.Subtotal * .16M;
                newFactura.ImpuestosRetenidos = 0;
                newFactura.Total = Convert.ToDecimal(item.Cells["MontoPrimaTotal"].Value);
                newFactura.StatusFacturacion = (from x in db.StatusFacturacions where x.Status == "No solicitado" select x.ID).SingleOrDefault();
                newFactura.UsuarioSolicitud = Program.Globals.UserID;
                newFactura.RamoSeguro = (from x in db.RamosLineaNegocios where x.LineaNegocio == poliza.LineaNegocios orderby x.ID descending select x.RamoSeguro).FirstOrDefault();

                newFactura.ConceptoCancelacion = (from x in db.MotivosCancelacions where x.Descripcion == "Sin Especificar" select x.ID).SingleOrDefault();
                newFactura.Poliza_str = poliza.Poliza1;
                newFactura.iniVig = poliza.IniVig;
                newFactura.finVig = poliza.FinVig;
                db.Facturacions.InsertOnSubmit(newFactura);
                db.SubmitChanges();

                int idFactura = newFactura.ID;

                // Agrega Participantes
                SmartG.FacturaParticipante newFacturaPart;
                newFacturaPart = new SmartG.FacturaParticipante();
                newFacturaPart.Factura = idFactura;
                newFacturaPart.Coasegurador = (from x in db.PolizaCoaseguro where x.Poliza == IDPoliza && x.Tipo == "Seguidor" && x.Activo == true select x.Coaseguradora).FirstOrDefault();
                newFacturaPart.PorcentajeCoaseguroEmpresa = (from x in db.PolizaCoaseguro where x.Poliza == IDPoliza && x.Tipo == "Seguidor" && x.Activo == true select x.Participacion).FirstOrDefault(); ;
                newFacturaPart.Broker = poliza.Broker;
                newFacturaPart.PorcentajeBrokerage = Convert.ToDecimal(polizaInfo.PorcentajeBrokerage);
                db.FacturaParticipantes.InsertOnSubmit(newFacturaPart);
                db.SubmitChanges();

                // Agrega conceptos
                //principal
                SmartG.FacturacionConcepto newFacturaConce = new FacturacionConcepto();
                newFacturaConce.Facturacion = idFactura;
                newFacturaConce.ClaveProductoSAT = (from x in db.RamosLineaNegocios where x.LineaNegocio == poliza.LineaNegocios orderby x.ID descending select x.ProductoSAT).FirstOrDefault();
                newFacturaConce.ClaveUnidadSAT = (from x in db.ClaveUnidadSATs where x.Descripciion == "Unidad de servicio" select x.ID).SingleOrDefault(); ;
                newFacturaConce.Cantidad = 1;
                newFacturaConce.Identificacion = polizaInfo.TipoPoliza;
                newFacturaConce.Descripcion = (from x in db.ClaveProductoSATs where x.ID == newFacturaConce.ClaveProductoSAT select x.Descripcion).SingleOrDefault();
                newFacturaConce.Precio = Convert.ToDecimal(item.Cells["MontoPrimaTotal"].Value) / 1.16M;
                newFacturaConce.Total = Convert.ToDecimal(item.Cells["MontoPrimaTotal"].Value) / 1.16M;
                newFacturaConce.Descuento = 0;
                db.FacturacionConceptos.InsertOnSubmit(newFacturaConce);
                db.SubmitChanges();
            }

            MessageBox.Show("Solicitudes generadas, puede consultarlas en la sección de Mis Facturas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void dgSeleccion_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            dgSeleccion.ActiveRow.Delete();
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("No se guardará ninguna solicitud de facturación y se cerrará esta ventana, continuar?", "Mensaje", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se cerrará esta ventana y se generará solo 1 solicitud de facturación con el asegurado principal de la poliza, continuar?", 
                "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DialogResult = DialogResult.No;
                this.Close();
            }
        }

        private void lbClientesSistema_Click(object sender, EventArgs e)
        {

        }

        private void dgSeleccion_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            e.Row.Cells["Impuestos"].Column.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
        }
    }
}
