using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Operaciones.CreditControl
{
    public partial class DivisionJournal : Form
    {
        int IDJournal;

        public DivisionJournal(int idjournal)
        {
            InitializeComponent();
            IDJournal = idjournal;
        }

        private void DivisionJournal_Load(object sender, EventArgs e)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            Journal journal = (from x in db.Journals where x.ID == IDJournal select x).SingleOrDefault();
            txtSNum.Text = journal.SNum.ToString();
            txtMonOriginal.Text = (from x in db.Monedas where x.ID == journal.MonPrimaAplicada select x.Abreviacion).SingleOrDefault();
            txtTotalJournal.Value = Convert.ToDecimal(journal.PrimaAplicada);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtTotalJournal.Value) != Convert.ToDecimal(txtTotalDivision.Value))
            {
                MessageBox.Show("Los montos de la división no coinciden con el monto del Journal original", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if(MessageBox.Show("Se dividirá el ingreso, continuar?","Mensaje",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    Journal journalOriginal = (from x in db.Journals where x.ID == IDJournal select x).SingleOrDefault();

                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgDivision.Rows)
                    {
                        Journal journalNuevo = new Journal();
                        Extensiones.Edicion.ClonarRegistro(db, journalOriginal, journalNuevo);
                        journalNuevo.ID = 0;
                        journalNuevo.Acc_Amount = Convert.ToDecimal(item.Cells["Monto"].Value);
                        journalNuevo.PrimaAplicada = Convert.ToDecimal(item.Cells["Monto"].Value);

                        db.Journals.InsertOnSubmit(journalNuevo);
                        db.SubmitChanges();
                    }

                    db.Journals.DeleteOnSubmit(journalOriginal);
                    db.SubmitChanges();

                    MessageBox.Show("Division Completa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DialogResult = DialogResult.Yes;
                    Close();
                }
            }
        }

        private void dgDivision_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            dgDivision.ActiveRow.Delete();
        }
    }
}
