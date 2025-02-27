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
    public partial class EditarParticipantes : Form
    {
        int IDclaim;

        void CargarDataSets()
        {
            try { this.participantesClaimsTableAdapter.FillByClaimAndTipo(this.claimsPeritos.ParticipantesClaims, IDclaim, "Peritos"); } catch { }
            try { this.participantesClaimsTableAdapter.FillByClaimAndTipo(this.claimsEspecialistas.ParticipantesClaims, IDclaim, "Especialistas Tecnicos"); } catch { }
            try {this.participantesClaimsTableAdapter.FillByClaimAndTipo(this.claimsAdicionales.ParticipantesClaims, IDclaim, "Asegurados Adicionales"); } catch { }
            try {this.participantesClaimsTableAdapter.FillByClaimAndTipo(this.claimsAfectados.ParticipantesClaims, IDclaim, "Afectados"); } catch { }
        }

        public EditarParticipantes(int idclaim)
        {
            InitializeComponent();
            IDclaim = idclaim;
        }

        private void EditarParticipantes_Load(object sender, EventArgs e)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            lbTXTasegurado.Text = ((from x in db.PolizaCliente
                                    where x.Poliza == Convert.ToInt32((from y in db.FNOLs where y.ID == IDclaim select y.Poliza).SingleOrDefault()) && x.Principal == true
                                    orderby x.Endoso descending
                                    select (x.Cliente1.RazonSocial + " " + x.Cliente1.Nombre + " " + x.Cliente1.ApellidoPaterno + " " + x.Cliente1.ApellidoMaterno)).FirstOrDefault()).Trim();
            lbTXTnumSiniestro.Text = (from x in db.FNOLs where x.ID == IDclaim select x.ClaimNum).SingleOrDefault();
            CargarDataSets();
        }

        private void btnAgregarParticipante_Click(object sender, EventArgs e)
        {
            AgregarParticipante frmAgrPart = new AgregarParticipante(IDclaim);
            if (frmAgrPart.ShowDialog() == DialogResult.Yes)
                CargarDataSets();
        }

        void AgregarParticipante(int TipoRel)
        {
            // 1 - Peritos
            // 2 - Especial
            // 3 - Asegurados
            // 4 - Afectados
            BuscarParticipantes frmBuscar = new BuscarParticipantes(TipoRel, IDclaim);
            if (frmBuscar.ShowDialog() == DialogResult.Yes)
                CargarDataSets();
        }

        void EliminarParticipante(int GridIndex)
        {
            // 1 - Peritos
            // 2 - Especial
            // 3 - Asegurados
            // 4 - Afectados

            int idParticipante = 0;

            switch (GridIndex)
            {
                case 0:
                    try { idParticipante = Convert.ToInt32(dgPeritos.ActiveRow.Cells["ID"].Value); } catch { } break;
                case 1:
                    try { idParticipante = Convert.ToInt32(dgEspecialistas.ActiveRow.Cells["ID"].Value); } catch { }   break;
                case 2:
                    try { idParticipante = Convert.ToInt32(dgAdicionales.ActiveRow.Cells["ID"].Value); } catch { }  break;
                case 3:
                    try { idParticipante = Convert.ToInt32(dgAfectados.ActiveRow.Cells["ID"].Value); } catch { } break;
            }
            if(idParticipante == 0)
            {
                MessageBox.Show("No hay ningún participante seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                FNOLParticipante participanteBorrar = (from x in db.FNOLParticipantes where x.Participante == idParticipante && x.FNOL == IDclaim select x).FirstOrDefault();
                if(participanteBorrar != null)
                {
                    db.FNOLParticipantes.DeleteOnSubmit(participanteBorrar);
                    db.SubmitChanges();
                    MessageBox.Show("Participante Borrado");
                    CargarDataSets();
                }
            }
        }

        private void btnEliminarPeritos_Click(object sender, EventArgs e)
        {
            EliminarParticipante(1);
        }

        private void btnEliminarEspecialista_Click(object sender, EventArgs e)
        {
            EliminarParticipante(2);
        }

        private void btnEliminarAsegu_Click(object sender, EventArgs e)
        {
            EliminarParticipante(3);
        }

        private void btnEliminarAfectado_Click(object sender, EventArgs e)
        {
            EliminarParticipante(4);
        }

        private void btnBuscarPeritos_Click(object sender, EventArgs e)
        {
            AgregarParticipante(1);
        }

        private void btnBuscarEspecialista_Click(object sender, EventArgs e)
        {
            AgregarParticipante(2);
        }

        private void btnBuscarAsegu_Click(object sender, EventArgs e)
        {
            AgregarParticipante(3);
        }

        private void btnBuscarAfectado_Click(object sender, EventArgs e)
        {
            AgregarParticipante(4);
        }
    }
}
