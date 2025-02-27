using System;
using System.Windows.Forms;
using System.Linq;


namespace SmartG.Operaciones.CreditControl
{
    public partial class SeleccionVariable : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // coleccion objetos
        #region objetos

            //lbFormaPago Seleccione las condiciones de Pago
            //lbFormaPagoSAT Seleccione la forma de Pago
            //btnSeleFormaPagoSAT Seleccionar
            //lbBancoExt Ingrese el Banco Extranjero Ordenante
            //btnBancoExt Seleccionar
            //btnSeleFormaPago Solicitar

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region variables

        public static int FormaPago;
        public static int CondPago;
        public static string BancoOrdenante;

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region eventos

        public SeleccionVariable(int SeleccionVariable)
        {
            // SeleccionVariable
            // 1 - Forma de Pago SAT
            // 2 - Condiciones de Pago (FormaPago)
            // 3 - Banco Extranjero Ordenante

            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
            panel_FormaPagoSAT.Visible = false;
            panel_CondPago.Visible = false;
            panel_BancoExt.Visible = false;

            switch (SeleccionVariable)
            {
                case 1:
                    panel_FormaPagoSAT.Visible = true;
                    break;
                case 2:
                    panel_CondPago.Visible = true;
                    break;
                case 3:
                    panel_BancoExt.Visible = true;
                    break;
            }
        }

        private void SeleccionFormaPago_Load(object sender, EventArgs e)
        {
            this.formaPagoTableAdapter.Fill(this.facturacion.FormaPago);
            this.formaPagoSATTableAdapter.Fill(this.facturacion.FormaPagoSAT);
            dbSmartGDataContext db = new dbSmartGDataContext();
            cbFormaPagoSAT.Value = (from x in db.FormaPagoSATs where x.Descripcion == "Transferencia electrónica de fondos" select x.ID).SingleOrDefault();

            Extensiones.Traduccion.traducirVentana(this);

        }

        private void btnSeleFormaPagoSAT_Click(object sender, EventArgs e)
        {
            if (cbFormaPagoSAT.Text == "")
            {
                MessageBox.Show("Error, seleccione un valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            if (cbFormaPagoSAT.Text == "Por definir")
            {
                MessageBox.Show("Error, Seleccione un avalor diferente a Por Definir", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            else
            {
                FormaPago = Convert.ToInt32(cbFormaPagoSAT.Value);
                this.Close();
            }
        }

        private void btnSeleFormaPago_Click(object sender, EventArgs e)
        {
            if (cbFormaPago.Text == "")
            {
                MessageBox.Show("Error, seleccione un valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            else
            {
                CondPago = Convert.ToInt32(cbFormaPago.Value);
                this.Close();
            }
        }

        private void btnBancoExt_Click(object sender, EventArgs e)
        {
            if (txtBancoExt.Text == "")
            {
                MessageBox.Show("Ingrese un valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            BancoOrdenante = txtBancoExt.Text;
            this.Close();
        }

        private void cbFormaPago_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
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
