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
    public partial class WriteOffConsultas : Form
    {
        int IDWriteOff;

        public WriteOffConsultas(int idWriteOff)
        {
            InitializeComponent();
            IDWriteOff = idWriteOff;
        }

        private void WriteOffConsultas_Load(object sender, EventArgs e)
        {
            this.journalWriteOffsTableAdapter.FillByJournalID(this.complementosPago.JournalWriteOffs, IDWriteOff);
        }
    }
}
