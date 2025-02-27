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
    public partial class EditarFactura : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // nombres y valores de todos los objetos que se encuentran en el formulario
        #region coleccion objetos

        // grpDatos         Datos de la Factura
        // lbCondiciones    Condiciones de Pago
        // lbStatus         Status Facturación
        // btnCancelar      Cancelar
        // btnAplicar       Aplicar Cambios
        // cbCondiciones
        // cbStatus

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // nombres y valores de todos los objetos que se encuentran en el formulario
        #region Variables
        int IDfactura;

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // nombres y valores de todos los objetos que se encuentran en el formulario
        #region Eventos de la ventana

        public EditarFactura(int idFactura)
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
            IDfactura = idFactura;
        }

        private void EditarFactura_Load(object sender, EventArgs e)
        {
            this.statusFacturacionTableAdapter.Fill(this.facturacion.StatusFacturacion);
            this.formaPagoTableAdapter.Fill(this.facturacion.FormaPago);

            dbSmartGDataContext db = new dbSmartGDataContext();
            SmartG.Facturacion editFactura = (from x in db.Facturacions where x.ID == IDfactura select x).SingleOrDefault();
            cbCondicones.Value = editFactura.CondicionesPago;
            cbStatus.Value = editFactura.StatusFacturacion;
            this.clientesDireccionesTableAdapter.FillByCliente(this.facturacion.ClientesDirecciones, editFactura.Cliente);
            cbDirecciones.Value = editFactura.ClienteDireccion;
            //Extensiones.Traduccion.traducirVentana(this);

        }


        private void ultraButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAsignarCuenta_Click(object sender, EventArgs e)
        {
            if (cbCondicones.Value == null || cbStatus.Value == null)
            {
                MessageBox.Show("Valores no validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dbSmartGDataContext db = new dbSmartGDataContext();
            SmartG.Facturacion editFactura = (from x in db.Facturacions where x.ID == IDfactura select x).SingleOrDefault();

            bool CambiarRecibos = false;

            if (editFactura.CondicionesPago != Convert.ToInt32(cbCondicones.Value))
                CambiarRecibos = true;

            if(CambiarRecibos)
                if (!ValidacionRecibos(IDfactura)) return;

            editFactura.CondicionesPago = Convert.ToInt32(cbCondicones.Value);
            editFactura.StatusFacturacion = Convert.ToInt32(cbStatus.Value);
            editFactura.ClienteDireccion = Convert.ToInt32(cbDirecciones.Value);
            db.SubmitChanges();

            if (CambiarRecibos)
                BorrarRecibosYaplicarNuevos();

                this.DialogResult = DialogResult.OK;
            this.Close();
        }


         bool ValidacionRecibos(int idfactura)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            int RecibosAplicados = (from x in db.RecibosPagos where x.Facturacion == idfactura && x.StatusFacturacion.Status != "No Aplicado" select x).ToArray().Count();
            if (RecibosAplicados > 0)
            {
                MessageBox.Show("Alguno de los recibos asociados a esta factura ya han sido aplicados a un Comprobante de Pago, contacte con el Administrador para modificar estos registros",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if( MessageBox.Show("Se eliminaran los recibos de pago de esta Factura para sustituirlos con la Condiciones de Pago Seleccionada, continuar?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    return true;
                else
                    return false;
            }
        }

        void BorrarRecibosYaplicarNuevos()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            // Elimina los recibos
            RecibosPago[] RecibosEliminar = (from x in db.RecibosPagos where x.Facturacion1.ID == IDfactura select x).ToArray();
            if (RecibosEliminar.Count() > 0)
            {
                db.RecibosPagos.DeleteAllOnSubmit(RecibosEliminar);
                db.SubmitChanges();
            }

            // Cambia la forma de pago de la factura y genera los nuevos recibos en la base
            Extensiones.Cobranza.GenerarRecibosPago(IDfactura, false);
            MessageBox.Show("Reprocesamiento de los recibos de pagos aplicado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnNuevoReciboCeros_Click(object sender, EventArgs e)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            int IDstatusNoAplicado = (from x in db.StatusFacturacions where x.Status == "No Aplicado" select x.ID).SingleOrDefault();
            int ConteoNoAplicados = (from x in db.RecibosPagos where x.Facturacion == IDfactura && x.Status == IDstatusNoAplicado select x).ToArray().Count();
            if(ConteoNoAplicados == 0)
            {
                if (MessageBox.Show("Se agregara un nuevo recibo en ceros para esta factura, continuar?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    RecibosPago lastRecibo = (from x in db.RecibosPagos where x.Facturacion == IDfactura orderby x.ID descending select x).FirstOrDefault();
                    RecibosPago nuevoRecCeros = new RecibosPago();
                    Extensiones.Edicion.ClonarRegistro(db, lastRecibo, nuevoRecCeros);
                    nuevoRecCeros.ID = 0;
                    nuevoRecCeros.sche_impuestos_part = 0;
                    nuevoRecCeros.sche_primaNeta_part = 0;
                    nuevoRecCeros.sche_primaTotal_part = 0;
                    nuevoRecCeros.sche_primaTotal_pendiente = 0;
                    nuevoRecCeros.Status = IDstatusNoAplicado;
                    db.RecibosPagos.InsertOnSubmit(nuevoRecCeros);
                    db.SubmitChanges();
                    MessageBox.Show("Recibo en ceros agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Esta factura aun tiene recibos de pago no aplicados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
