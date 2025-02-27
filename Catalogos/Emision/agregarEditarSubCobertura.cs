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
    public partial class agregarEditarSubCobertura : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region variables
        int idSubCobertura;
        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region metodos programados
        bool validarDatos()
        {
            if (cbCobertura.Text == "" || txtSubCobertura.Text == "")
            {
                MessageBox.Show("Debes llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            dbSmartGDataContext db = new dbSmartGDataContext();
            SubCoberturas tmpSub = (from x in db.SubCoberturas where x.SubCobertura == txtSubCobertura.Text && x.Cobertura == Convert.ToInt32(cbCobertura.Value) select x).SingleOrDefault();
            if (tmpSub != null)
            {
                MessageBox.Show("La Subcobertura que intentas ingresar ya está registrada en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region eventos form

        public agregarEditarSubCobertura(int id=0)
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
            idSubCobertura = id;
        }

        private void agregarEditarSubCobertura_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this);
            coberturasTableAdapter.FillByActivos(catalogosGral.Coberturas);
            if (idSubCobertura != 0)
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                SubCoberturas tmpSub = (from x in db.SubCoberturas where x.ID == idSubCobertura select x).SingleOrDefault();
                if (tmpSub != null)
                {
                    cbCobertura.Value = tmpSub.Cobertura;
                    txtSubCobertura.Text = tmpSub.SubCobertura;
                    chkDefecto.Checked = Convert.ToBoolean(tmpSub.Defecto);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                SubCoberturas nuevaSub;
                if (idSubCobertura == 0)
                    nuevaSub = new SubCoberturas();
                else
                    nuevaSub = (from x in db.SubCoberturas where x.ID == idSubCobertura select x).SingleOrDefault();
                nuevaSub.Cobertura = Convert.ToInt32(cbCobertura.Value);
                nuevaSub.SubCobertura = txtSubCobertura.Text;
                nuevaSub.Defecto = chkDefecto.Checked;
                nuevaSub.userAdd = false;
                nuevaSub.Eliminado = false;
                if (idSubCobertura == 0)
                    db.SubCoberturas.InsertOnSubmit(nuevaSub);
                db.SubmitChanges();
                MessageBox.Show("SubCobertura Guardada Satisfactoriamente", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
    }
}
