using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Operaciones.CreditControl.Cobranza
{
    public partial class SelFormaOrdenPago : Form
    {
        public SelFormaOrdenPago()
        {
            InitializeComponent();
        }

        private void SelFormaOrdenPago_Load(object sender, EventArgs e)
        {
            cbFormaPagosBroker.SelectedIndex = 1;
        }

        private void btnBuscarJournal_Click(object sender, EventArgs e)
        {
            if (cbFormaPagosBroker.SelectedIndex == 0) // Contado - Yes
                DialogResult = DialogResult.Yes;
            else
                DialogResult = DialogResult.No; // Mismo que Recibos - No
            this.Close();
        }
    }
}
