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
    public partial class BuscarParticipantes : Form
    {
        int TipoRelacion;
        int IDClaim;

        void CargarDataSets()
        {
            this.participantesClaimsTableAdapter.FillByTipo(this.claims.ParticipantesClaims, TipoRelacion);
        }

        public BuscarParticipantes(int TipoRel, int idclaim)
        {
            InitializeComponent();
            TipoRelacion = TipoRel;
            IDClaim = idclaim;
        }

        private void BuscarParticipantes_Load(object sender, EventArgs e)
        {
            CargarDataSets();
            cbFiltro.SelectedIndex = 0;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarDataSets();
        }

        private void ultraTextEditor1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                switch (cbFiltro.Text)
                {
                    case "Nombre":
                        this.participantesClaimsTableAdapter.FillByNombre(this.claims.ParticipantesClaims, TipoRelacion, ultraTextEditor1.Text);
                        break;

                    case "Direccion":
                        this.participantesClaimsTableAdapter.FillByDireccion(this.claims.ParticipantesClaims, TipoRelacion, ultraTextEditor1.Text);
                        break;

                    case "RFC":
                        this.participantesClaimsTableAdapter.FillByRFC(this.claims.ParticipantesClaims, TipoRelacion, ultraTextEditor1.Text);
                        break;
                }
                if (this.claims.ParticipantesClaims.Rows.Count == 0)
                    MessageBox.Show("No hay resultados");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void dgParticipantes_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if(MessageBox.Show("Agregar a este partipante al siniestro?","Mensaje",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                int idParticipante = Convert.ToInt32(dgParticipantes.ActiveRow.Cells["ID"].Value);

                // Check no agregado previamente
                int Check = (from x in db.FNOLParticipantes where x.FNOL == IDClaim && x.Participante == idParticipante select x).ToArray().Count();
                if(Check > 0)
                {
                    MessageBox.Show("Este participante ya fue agregado previamente al siniestro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Agregar Participante
                FNOLParticipante participante = new FNOLParticipante();
                participante.FNOL = IDClaim;
                participante.Participante = idParticipante;
                db.FNOLParticipantes.InsertOnSubmit(participante);
                db.SubmitChanges();
                MessageBox.Show("Participante Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DialogResult = DialogResult.Yes;
                Close();
            }
        }
    }
}
