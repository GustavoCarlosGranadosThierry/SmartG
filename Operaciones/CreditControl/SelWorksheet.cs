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
    public partial class SelWorksheet : Form
    {
        public SelWorksheet(string[] Cadena)
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
            for (int i = 0; i < Cadena.Length; i++)
            {
                ultraComboEditor1.Items.Add(i, Cadena[i]);
            }
        }

        private void btnBuscarJournal_Click(object sender, EventArgs e)
        {
            Ingresos.SelWS = Convert.ToInt32(ultraComboEditor1.Value) + 1;
            Close();
        }
    }
}
