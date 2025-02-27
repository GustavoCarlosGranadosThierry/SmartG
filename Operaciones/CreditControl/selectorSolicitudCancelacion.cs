using System;
using System.Windows.Forms;

namespace SmartG.Operaciones.CreditControl
{
    public partial class selectorSolicitudCancelacion : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // coleccion objetos
        #region objetos

        //btnSolicitar Solicitar una Cancelación
        //lbOpciones Seleccione una opción
        //btnGenerarCancelacion Generar una Cancelación

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region eventos

        public selectorSolicitudCancelacion()
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
        }

        private void selectorSolicitudCancelacion_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this);
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            MisFacturas.sele = 1;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnGenerarCancelacion_Click(object sender, EventArgs e)
        {
            MisFacturas.sele = 2;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
