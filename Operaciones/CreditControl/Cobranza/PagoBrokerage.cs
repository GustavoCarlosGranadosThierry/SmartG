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
    public partial class PagoBrokerage : Form
    {
        public PagoBrokerage()
        {
            InitializeComponent();
        }

        private void PagoBrokerage_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cobranza.OrdenesPago' table. You can move, or remove it, as needed.
            this.ordenesPagoTableAdapter.Fill(this.cobranza.OrdenesPago);

        }
    }
}
