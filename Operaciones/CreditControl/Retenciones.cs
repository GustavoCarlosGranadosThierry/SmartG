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
    public partial class Retenciones : Form
    {
        Form MainFrm;

        public Retenciones(Form mainfrm)
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
            MainFrm = mainfrm;
        }

        private void Retenciones_Load(object sender, EventArgs e)
        {
            cbTipoRetencion.Items.Add("01", "Servicios profesionales");
            cbTipoRetencion.Items.Add("02", "Regalías por derechos de autor");
            cbTipoRetencion.Items.Add("03", "Autotransporte terrestre de carga");
            cbTipoRetencion.Items.Add("04", "Servicios prestados por comisionistas");
            cbTipoRetencion.Items.Add("05", "Arrendamiento");
            cbTipoRetencion.Items.Add("06", "Enajenación de acciones.");
            cbTipoRetencion.Items.Add("07", "Enajenación de bienes objeto de la LIEPS, a través de mediadores, agentes, representantes, corredores, consignatarios o distribuidores");
            cbTipoRetencion.Items.Add("08", "Enajenación de bienes inmuebles consignada en escritura pública");
            cbTipoRetencion.Items.Add("09", "Enajenación de otros bienes, no consignada en escritura pública");
            cbTipoRetencion.Items.Add("10", "Adquisición de desperdicios industriales");
            cbTipoRetencion.Items.Add("11", "Adquisición de bienes consignada en escritura pública");
            cbTipoRetencion.Items.Add("12", "Adquisición de otros bienes, no consignada en escritura pública");
            cbTipoRetencion.Items.Add("13", "Otros retiros de AFORE.");
            cbTipoRetencion.Items.Add("14", "Dividendos o utilidades distribuidas");
            cbTipoRetencion.Items.Add("15", "Remanente distribuible.");
            cbTipoRetencion.Items.Add("16", "Intereses.");
            cbTipoRetencion.Items.Add("17", "Arrendamiento en fideicomiso.");
            cbTipoRetencion.Items.Add("18", "Pagos realizados a favor de residentes en el extranjero.");
            cbTipoRetencion.Items.Add("19", "Enajenación de acciones u operaciones en bolsa de valores.");
            cbTipoRetencion.Items.Add("20", "Obtención de premios.");
            cbTipoRetencion.Items.Add("21", "Fideicomisos que no realizan actividades empresariales.");
            cbTipoRetencion.Items.Add("22", "Planes personales de retiro.");
            cbTipoRetencion.Items.Add("23", "Intereses reales deducibles por créditos hipotecarios.");
            cbTipoRetencion.Items.Add("24", "Operaciones Financieras Derivadas de Capital");
            cbTipoRetencion.Items.Add("25", "Otro tipo de retenciones");
            cbTipoRetencion.SelectedIndex = 0;
            cbImpuesto.SelectedIndex = 0;
            cbTipoPagoRetencion.SelectedIndex = 0;
        }

        private void cbTipoRetencion_ValueChanged(object sender, EventArgs e)
        {
            if (cbTipoRetencion.Value.ToString() == "25")
                txtDescripcionRetencion.Enabled = true;
            else
                txtDescripcionRetencion.Enabled = false;
        }

        private void rgbNacional_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbNacional.Checked)
            {
                txtNacionalCURP.Enabled = true;
                txtNacionalRazonSocial.Enabled = true;
                txtNacionalRFC.Enabled = true;

                txtExtranjeroIDExtranjero.Enabled = false;
                txtExtranjeroRazonSocial.Enabled = false;

            }
            else
            {
                txtNacionalCURP.Enabled = false;
                txtNacionalRazonSocial.Enabled = false;
                txtNacionalRFC.Enabled = false;

                txtExtranjeroIDExtranjero.Enabled = true;
                txtExtranjeroRazonSocial.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimbrar_Click(object sender, EventArgs e)
        {
            if(txtFolio.Text =="" || txtAño.Text == "" || txtMesIni.Text == "" || txtMesFin.Text == "" || txtTotalOperacion.Text == "" || txtTotalGrav.Text == "" ||
                txtTotalExento.Text == "" || txtTotalRetencion.Text == "" || txtBaseRetencion.Text == "" || txtMontoRetencion.Text == "")
            {
                MessageBox.Show("Valores Incompletos");
                return;
            }
            else
            {
                if (MessageBox.Show("Se guardaran estos datos en la base de datos y se mandara a timbrar, continuar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    FacturacionRetencione facturacionRetencione = new FacturacionRetencione();
                    facturacionRetencione.Folio = txtFolio.Text;
                    facturacionRetencione.TipoRetencion = cbTipoRetencion.Value.ToString();
                    facturacionRetencione.DescripcionRetencion = txtDescripcionRetencion.Text;
                    facturacionRetencione.Nac_RFC = txtNacionalRFC.Text;
                    facturacionRetencione.Nac_RazonSocial = txtNacionalRazonSocial.Text;
                    facturacionRetencione.Nac_Curp = txtNacionalCURP.Text;
                    facturacionRetencione.Ext_RazonSocial = txtExtranjeroRazonSocial.Text;
                    facturacionRetencione.Ext_IDExtranjero = txtExtranjeroIDExtranjero.Text;
                    facturacionRetencione.Ejercicio = Convert.ToInt32(txtAño.Value);
                    facturacionRetencione.MesIni = Convert.ToInt32(txtMesIni.Value);
                    facturacionRetencione.MesFin = Convert.ToInt32(txtMesFin.Value);
                    facturacionRetencione.TotalOperacion = Convert.ToDecimal(txtTotalOperacion.Value);
                    facturacionRetencione.TotalGravado = Convert.ToDecimal(txtTotalGrav.Value);
                    facturacionRetencione.TotalExento = Convert.ToDecimal(txtTotalExento.Value);
                    facturacionRetencione.TotalRetencion = Convert.ToDecimal(txtTotalRetencion.Value);
                    facturacionRetencione.Impuesto = cbImpuesto.Value.ToString();
                    facturacionRetencione.TipoPagoRetencion = cbTipoPagoRetencion.Value.ToString();
                    facturacionRetencione.BaseRetencion = Convert.ToDecimal(txtBaseRetencion.Value);
                    facturacionRetencione.MontoRetencion = Convert.ToDecimal(txtMontoRetencion.Value);
                    facturacionRetencione.Status = (from x in db.StatusFacturacions where x.Status == "En Proceso" select x.ID).SingleOrDefault();
                    facturacionRetencione.EmpresaTimbrada = (from x in db.EmpresaDetalles where x.Principal == true select x.ID).SingleOrDefault(); 
                    db.FacturacionRetenciones.InsertOnSubmit(facturacionRetencione);
                    db.SubmitChanges();
                    Extensiones.TimbradoWSfinkok.TimbrarRetenciones(facturacionRetencione.ID, MainFrm);
                    Close();
                }
            }
        }
    }
}
