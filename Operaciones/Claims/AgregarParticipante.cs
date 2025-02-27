using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Operaciones.Claims
{
    public partial class AgregarParticipante : Form
    {
        int IDClaim;

        bool ValidarInfo()
        {
            if(cbTipo.Text == "" || txtNombre.Text == "" || txtDireccion.Text == "" || txtTelefono.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Datos generales incompletos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtRFC.Text == "" || txtBanco.Text == "" || txtCuenta.Text == "" || txtClabe.Text == "" )
            {
                MessageBox.Show("Datos de pago incompletos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        int GuardarDatos()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            ParticipantesClaim newParticipante = new ParticipantesClaim();
            newParticipante.TipoRelacion = Convert.ToInt32(cbTipo.Value);
            newParticipante.Nombre = txtNombre.Text;
            newParticipante.Dirección = txtDireccion.Text;
            newParticipante.TelefonoContacto = txtTelefono.Text;
            newParticipante.EmailContacto = txtEmail.Text;
            newParticipante.RFC = txtRFC.Text;
            newParticipante.Banco = txtBanco.Text;
            newParticipante.NumCuenta = txtCuenta.Text;
            newParticipante.CLABE = txtClabe.Text;
            newParticipante.Eliminado = false;
            db.ParticipantesClaims.InsertOnSubmit(newParticipante);
            db.SubmitChanges();
            return newParticipante.ID;
        }

        void AgregarAclaim(int idClaim, int idParticipante)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            FNOLParticipante fNOLParticipanteNuevo = new FNOLParticipante();
            fNOLParticipanteNuevo.FNOL = idClaim;
            fNOLParticipanteNuevo.Participante = idParticipante;
            db.FNOLParticipantes.InsertOnSubmit(fNOLParticipanteNuevo);
            db.SubmitChanges();
        }

        public AgregarParticipante(int idclaim)
        {
            InitializeComponent();
            IDClaim = idclaim;
        }

        private void AgregarParticipante_Load(object sender, EventArgs e)
        {
            this.tipoRelacionParticipantesClaimsTableAdapter.Fill(this.claims.TipoRelacionParticipantesClaims);
            cbTipo.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(ValidarInfo())
            {
                int IDnuevoParticipante = GuardarDatos();
                DialogResult = DialogResult.Yes;
                Close();
            }
        }

        private void btnGuardarAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarInfo())
            {
                int IDnuevoParticipante = GuardarDatos();
                AgregarAclaim(IDClaim, IDnuevoParticipante);
                DialogResult = DialogResult.Yes;
                Close();
            }
        }
    }
}
