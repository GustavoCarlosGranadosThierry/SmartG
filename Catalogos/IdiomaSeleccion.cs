using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Catalogos
{
    public partial class IdiomaSeleccion : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // nombres y valores de todos los objetos que se encuentran en el formulario
        #region coleccion objetos

            // grpEdicionIdioma         Edición de idioma SmartG
            // lbIdiomaSeleccionado     Idioma
            // lbIdiomaActual           Idioma Actual:
            // lbIdiomaSeleccionado     Idioma
            // lbCambiarIdioma          Cambiar Idioma:
            // btnCancelar              Cancelar
            // btnAplicar               Aplicar Cambios
        #endregion


        string idiomaSel;

        public IdiomaSeleccion()
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
        }

        private void IdiomaSeleccion_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this);
            lbIdiomaSeleccionado.Text = Properties.Settings.Default.idiomaSeleccionado.ToString();
            idiomaSel = Properties.Settings.Default.idiomaSeleccionado.ToString();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if(cbIdiomas.Value == null)
            {
                MessageBox.Show("No se selecciono ningún idioma", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbIdiomas.Value.ToString() == idiomaSel)
            {
                MessageBox.Show("Idioma ya selccionado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.Cancel;
                Close();
            }
            else
            {
                Properties.Settings.Default.idiomaSeleccionado = cbIdiomas.Value.ToString();
                Properties.Settings.Default.Save();
                MessageBox.Show("Idioma modificado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.Yes;
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cbIdiomas_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
            cbIdiomas.Text = "";
        }
    }
}
