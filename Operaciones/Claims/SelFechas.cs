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
    public partial class SelFechas : Form
    {
        public SelFechas()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if(Convert.ToDateTime(dateFin.Value) <= Convert.ToDateTime( dateInicio.Value))
            {
                MessageBox.Show("Fechas invalidas");
                return;
            }

            DateTime p1 = Convert.ToDateTime(dateInicio.Value);
            DateTime p2 = Convert.ToDateTime(dateFin.Value);
            TimeSpan ts = new TimeSpan(0, 0, 0);
            p1 = p1.Date + ts;
            ts = new TimeSpan(23, 59, 59);
            p2 = p2.Date + ts;

            ReportesRegulatorios.fechaInicioReporte = p1;
            ReportesRegulatorios.fechaFinReporte = p2;
            ReportesRegulatorios.LineaNegoSel = ultraComboEditor1.Value.ToString();
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void SelFechas_Load(object sender, EventArgs e)
        {
            dateInicio.Value = DateTime.Now;
            dateFin.Value = DateTime.Now.AddMonths(1);
            ultraComboEditor1.Text = "Property";
        }

        private void ultraLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
