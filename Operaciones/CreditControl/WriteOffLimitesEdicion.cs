using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Operaciones.CreditControl
{
    public partial class WriteOffLimitesEdicion : Form
    {
        int idRegistro;

        public WriteOffLimitesEdicion()
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
        }

        private void WriteOffLimitesEdicion_Load(object sender, EventArgs e)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            txtLimiteMXN.Value = (from x in db.JournalWriteOffLimites orderby x.ID descending select x.LimiteMasMenosMXN).SingleOrDefault();
            txtLimiteUSD.Value = (from x in db.JournalWriteOffLimites orderby x.ID descending select x.LimiteMasMenosUSD).SingleOrDefault();
            idRegistro = (from x in db.JournalWriteOffLimites orderby x.ID descending select x.ID).SingleOrDefault();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            JournalWriteOffLimite journalWriteOffLimite = (from x in db.JournalWriteOffLimites where x.ID == idRegistro select x).SingleOrDefault();
            journalWriteOffLimite.LimiteMasMenosMXN = Convert.ToDecimal(txtLimiteMXN.Value);
            journalWriteOffLimite.LimiteMasMenosUSD = Convert.ToDecimal(txtLimiteUSD.Value);
            db.SubmitChanges();
            Extensiones.ChangeLog.AgregarLog(3, 5, "Limites WriteOff", "Update", idRegistro, "Modificacion de los Registros de WriteOff, valores nuevos: MXN:$" + txtLimiteMXN.Value + " USD:$" + txtLimiteUSD.Value);
            MessageBox.Show("Limites modificados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Close();
        }
    }
}
