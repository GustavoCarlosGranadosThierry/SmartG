using System;
using System.Windows.Forms;

namespace SmartG.Operaciones.CreditControl
{
    public partial class tipoCambio : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // coleccion objetos
        #region objetos

            //lbMensajeTipoCambio La moneda del recibo seleccionado(MXN) no coincide con la moneda del Journal(USD), favor de ingresar el tipo de cambio para esta operacion para poder continuar:
            //lbTipoCambio1 Tipo de Cambio
            //lbTipoCambio2 MXN > USD

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region eventos

        public tipoCambio(bool ProcesamientoJournal = false)
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
            if (ProcesamientoJournal == true)
            {
                lbMensajeTipoCambio.Visible = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtTipoCambio.Value) != 0)
            {
                BuscarRecibo.cambioUsuario = Convert.ToDecimal(txtTipoCambio.Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor indique un valor valido para el tipo de cambio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void tipoCambio_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this);
        }

        private void txtTipoCambio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAceptar_Click(null, null);
        }

        #endregion

    }
}
