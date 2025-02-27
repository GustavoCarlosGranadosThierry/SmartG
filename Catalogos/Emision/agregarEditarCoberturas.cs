using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Catalogos.Emision
{
    public partial class agregarEditarCoberturas : Form
    {

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region variables
        int idCobertura;
        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region metodos programados

        bool validarRegistro()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            if (txtCobertura.Text == "" || txtCoberturaIngles.Text == "" || txtGeniusCode.Text == "" || cbLineaNegocios.Text == "" || cbOrigen.Text == "")
            {
                MessageBox.Show("Debes llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Coberturas tmpCobertura = (from x in db.Coberturas where x.Cobertura.ToUpper() == txtCobertura.Text.ToUpper() && x.CoberturaIngles.ToUpper() == txtCoberturaIngles.Text.ToUpper() 
                                      && x.GeniusCode.ToUpper() == txtGeniusCode.Text.ToUpper() && x.Origen == Convert.ToInt32(cbOrigen.Value) 
                                       && x.LineaNegocios == Convert.ToInt32(cbLineaNegocios.Value) select x).SingleOrDefault();

            if (tmpCobertura != null)
            {
                MessageBox.Show("La cobertura que intentas ingresar ya está registrada en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;

        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region Eventos form

        public agregarEditarCoberturas(int id = 0)
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
            idCobertura = id;
        }

        private void agregarEditarCoberturas_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this);
            // TODO: esta línea de código carga datos en la tabla 'catalogosGral.Origen' Puede moverla o quitarla según sea necesario.
            this.origenTableAdapter.Fill(this.catalogosGral.Origen);
            // TODO: esta línea de código carga datos en la tabla 'catalogosGral.LineaNegocios' Puede moverla o quitarla según sea necesario.
            this.lineaNegociosTableAdapter.Fill(this.catalogosGral.LineaNegocios);
            dbSmartGDataContext db = new dbSmartGDataContext();
            if (idCobertura != 0)
            {
                Coberturas aBuscar = (from x in db.Coberturas where x.ID == idCobertura select x).SingleOrDefault();
                txtCobertura.Text = aBuscar.Cobertura;
                txtCoberturaIngles.Text = aBuscar.CoberturaIngles;
                txtGeniusCode.Text = aBuscar.GeniusCode;
                cbLineaNegocios.Value = aBuscar.LineaNegocios;
                cbOrigen.Value = aBuscar.Origen;
                chkDefecto.Checked = Convert.ToBoolean(aBuscar.Defecto);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarRegistro())
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                Coberturas nuevaCobertura;
                if (idCobertura == 0)
                    nuevaCobertura = new Coberturas();
                else
                    nuevaCobertura = (from x in db.Coberturas where x.ID == idCobertura select x).SingleOrDefault();
                nuevaCobertura.Cobertura = txtCobertura.Text;
                nuevaCobertura.CoberturaIngles = txtCoberturaIngles.Text;
                nuevaCobertura.GeniusCode = txtGeniusCode.Text;
                nuevaCobertura.LineaNegocios = Convert.ToInt32(cbLineaNegocios.Value);
                nuevaCobertura.Origen = Convert.ToInt32(cbOrigen.Value);
                nuevaCobertura.Eliminado = false;
                nuevaCobertura.userAdd = false;
                nuevaCobertura.Defecto = chkDefecto.Checked;
                if (idCobertura == 0)
                    db.Coberturas.InsertOnSubmit(nuevaCobertura);
                db.SubmitChanges();
                MessageBox.Show("Cobertura Guardada Satisfactoriamente", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        #endregion


        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
    }
}
