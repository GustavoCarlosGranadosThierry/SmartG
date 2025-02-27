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
    public partial class agregarEditarCoaseguros : Form
    {
        int idCoaseguradora;

        bool verificarCoaseguradora()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            if (idCoaseguradora != 0)
            {
                int status = (from y in db.StatusFacturacions where y.Status == "Solicitado" select y.ID).SingleOrDefault();
                CoaseguradorasSolicitud revisarSol = (from x in db.CoaseguradorasSolicitud where x.Coaseguradora == idCoaseguradora && x.Status == status select x).SingleOrDefault();
                if (revisarSol != null)
                    return false;
            }

            if (txtBroker.Text == "" || txtBrokerCode.Text == "")
                return false;

            Coaseguradoras coaseguraN = (from x in db.Coaseguradoras where x.Codigo.ToUpper() == txtBrokerCode.Text.ToUpper() select x).SingleOrDefault();
            if (coaseguraN != null)
            {
                if (coaseguraN.Nombre == txtBroker.Text)
                    return false;
            }

            return true;
        }

        public agregarEditarCoaseguros(int id=0)
        {
            idCoaseguradora = id;
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
        }

        private void agregarEditarCoaseguros_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this);

            if (idCoaseguradora != 0)
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                Coaseguradoras coaseEditar = (from x in db.Coaseguradoras where x.ID == idCoaseguradora select x).SingleOrDefault();
                txtBrokerCode.Text = coaseEditar.Codigo;
                txtBroker.Text = coaseEditar.Nombre;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (verificarCoaseguradora())
            {
                if (txtBroker.Text != "" && txtBrokerCode.Text != "")
                {
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    Coaseguradoras coaseN;
                    if (idCoaseguradora == 0)
                        coaseN = new Coaseguradoras();
                    else
                        coaseN = (from x in db.Coaseguradoras where x.ID == idCoaseguradora select x).SingleOrDefault();
                    coaseN.Codigo = txtBrokerCode.Text;
                    coaseN.Nombre = txtBroker.Text;
                    coaseN.Aprobado = false;
                    coaseN.Eliminado = false;
                    if (idCoaseguradora == 0)
                        db.Coaseguradoras.InsertOnSubmit(coaseN);
                    db.SubmitChanges();

                    CoaseguradorasSolicitud nuevaSolicitud = new CoaseguradorasSolicitud();
                    nuevaSolicitud.UsuarioSolicitud = Program.Globals.UserID;
                    nuevaSolicitud.FechaSolicitud = DateTime.Now;
                    nuevaSolicitud.Coaseguradora = coaseN.ID;
                    if (idCoaseguradora != 0)
                    {
                        nuevaSolicitud.NombreCoaseguradora = txtBroker.Text;
                        nuevaSolicitud.CodigoCoaseguradora = txtBrokerCode.Text;
                    }
                    nuevaSolicitud.Status = (from y in db.StatusFacturacions where y.Status == "Solicitado" select y.ID).SingleOrDefault();
                    db.CoaseguradorasSolicitud.InsertOnSubmit(nuevaSolicitud);
                    db.SubmitChanges();
                    MessageBox.Show("Registro añadido", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    MainCoaseguradoras.idCoaseguradora = coaseN.ID;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("La coaseguradora que quieres agregar ya se encuentra en la base de datos o tiene pendiente una modificación, favor de contactar a un administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
