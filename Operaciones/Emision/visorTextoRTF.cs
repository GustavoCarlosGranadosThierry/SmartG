using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Operaciones.Emision
{
    public partial class visorTextoRTF : Form
    {
        public visorTextoRTF()
        {
            InitializeComponent();
        }

        private void visorTextoRTF_Load(object sender, EventArgs e)
        {
            string texto = Clipboard.GetText(TextDataFormat.Rtf);
            try
            {
                txtTexto.Rtf = texto;
            }
            catch
            {
                txtTexto.Text = texto;
            }
        }
    }
}
