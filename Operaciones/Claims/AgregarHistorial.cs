using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Operaciones.Claims
{
    public partial class AgregarHistorial : Form
    {
        int IDClaim;

        void CargarDataSets()
        {
            this.tipoHistorialClaimsTableAdapter.Fill(this.claims.TipoHistorialClaims);
            this.fNOLHisParticipanteTableAdapter.Fill(this.claims.FNOLHisParticipante, IDClaim);
            this.polizaCoberturaClaimTableAdapter.Fill(this.claims.PolizaCoberturaClaim, IDClaim);
        }

        public AgregarHistorial(int idclaim)
        {
            InitializeComponent();
            IDClaim = idclaim;
        }

        private void AgregarHistorial_Load(object sender, EventArgs e)
        {
            CargarDataSets();
            dbSmartGDataContext db = new dbSmartGDataContext();
            lbNumSiniestro.Text = (from x in db.FNOLs where x.ID == IDClaim select x.ClaimNum).SingleOrDefault();
            cbCategoriaHistorial.SelectedIndex = 0;
            cbCoberturaAfectada.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dsFiles.Rows.Add(new object[] { openFileDialog1.FileName });
            }
        }

        private void dgFiles_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            dgFiles.ActiveRow.Delete();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtDescripcion.Text == "" || txtNotasHistorial.Text == "" || dgParticipantesHistorial.Rows.Count == 0)
            {
                MessageBox.Show("Datos Incompletos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dbSmartGDataContext db = new dbSmartGDataContext();
            FNOLHistorial historialNuevo = new FNOLHistorial();
            historialNuevo.FNOL = IDClaim;
            historialNuevo.Tipo = Convert.ToInt32(cbCategoriaHistorial.Value);
            historialNuevo.Descripcion = txtDescripcion.Text;
            historialNuevo.Notas = txtNotasHistorial.Text;
            historialNuevo.Cobertura = Convert.ToInt32(cbCoberturaAfectada.Value);
            historialNuevo.Usuario = Program.Globals.UserID;
            historialNuevo.FechaCreacion = DateTime.Now;
            db.FNOLHistorials.InsertOnSubmit(historialNuevo);
            db.SubmitChanges();
            int IDHistorial = historialNuevo.ID;

            // Guarda Participantes;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in dgParticipantesHistorial.Rows)
            {
                FNOLHistorialParticipante historialParticipante = new FNOLHistorialParticipante();
                historialParticipante.FNOLHistorial = IDHistorial;
                historialParticipante.FNOLParticipante = Convert.ToInt32(row.Cells["ID"].Value);
                db.FNOLHistorialParticipantes.InsertOnSubmit(historialParticipante);
                db.SubmitChanges();
            }

            // Guarda Files
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in dgFiles.Rows)
            {
                db = new dbSmartGDataContext();
                try
                {
                    Stream fs = File.Open(row.Cells["Archivo"].Value.ToString(), FileMode.Open);
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    FNOLHistorialArchivo historialArchivo = new FNOLHistorialArchivo();
                    historialArchivo.FNOLHistorial = IDHistorial;
                    historialArchivo.FileName = Path.GetFileName(row.Cells["Archivo"].Value.ToString());
                    historialArchivo.FileData = bytes;
                    db.FNOLHistorialArchivos.InsertOnSubmit(historialArchivo);
                    db.SubmitChanges();
                }
                catch { }
            }
            MessageBox.Show("Registro Agregado exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void dgParticipantesDB_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            dsParticipantesSeleccionados.Rows.Add(new object[] { e.Row.Cells["IDFNOLParticipante"].Value, e.Row.Cells["Nombre"].Value });
        }

        private void dgParticipantesHistorial_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            dgParticipantesHistorial.ActiveRow.Delete();
        }
    }
}
