using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Operaciones.Emision
{
    public partial class SelectorLN : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // nombres y valores de todos los objetos que se encuentran en el formulario
        #region Coleccion objetos
        //lbTipoTransaccion     Tipo de transaccion:
        //lbTipoTransaccionTxt
        //lbOrigen     Origen:
        //lbOrigenTxt
        //lbLineaNegocios     Linea de negocios:
        //cbLineaNegocios
        //btnAceptar     Comenzar
        //btnCancelar     Cancelar
        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region Variables
        public static string origen;
        public static string tipoNegocio;
        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region MetodosProgramados

        void IniciarDatos()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            UsuariosPerfil[] usuarioAcceso = (from x in db.UsuariosPerfils where x.Perfile.KeyName == "LN" + origen && x.Usuario == Program.Globals.UserID select x).ToArray();
            for (int j = 0; j < usuarioAcceso.Count(); j++)
            {
                string textoLN = usuarioAcceso[j].Perfile.Descripcion.Split('-')[0];
                textoLN = textoLN.Substring(0, textoLN.Length - 1);
                cbLineaNegocios.Items.Add(textoLN);
            }
        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region EventosForm

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cbLineaNegocios.Text != "")
            {
                Main.lineaNegocios = cbLineaNegocios.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public SelectorLN()
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
        }

        private void SelectorLN_Load(object sender, EventArgs e)
        {
            // iniciamos las lineas de negocios
            Extensiones.Traduccion.traducirVentana(this);
            //lineaNegociosTableAdapter.Fill(this.liabilityInc.LineaNegocios);
            lbOrigenTxt.Text = origen;
            lbTipoTransaccionTxt.Text = tipoNegocio;

            IniciarDatos();
        }

        #endregion
    }
}
