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
    public partial class SelPorcentajeBrokerage : Form
    {
        public SelPorcentajeBrokerage()
        {
            InitializeComponent();
        }

        private void SelPorcentajeBrokerage_Load(object sender, EventArgs e)
        {
            txtPorcentaje.Value = 0;
        }

        private void btnBuscarJournal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Extensiones.Cobranza.PorcentajeBroker = Convert.ToDecimal(txtPorcentaje.Value);
            this.Close();
        }
    }
}
