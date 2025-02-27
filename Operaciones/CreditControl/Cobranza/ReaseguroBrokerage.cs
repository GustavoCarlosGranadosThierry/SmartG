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
    public partial class ReaseguroBrokerage : Form
    {

        int IDReaseguradora;

        void CambiarLayout(int modo)
        {
            // 0 - seleccion rease
            // 1 - Detalle rease

            IDReaseguradora = 0;
            ToolsBarReaseguroBrokerage.Ribbon.Tabs[0].Groups["rgbEdoCuenta"].Visible = false;
            ToolsBarReaseguroBrokerage.Ribbon.Tabs[0].Groups["rgbSeleccion"].Visible = false;
            tabBrokerage.Tabs[0].Visible = false;
            tabBrokerage.Tabs[1].Visible = false;
            tabBrokerage.Tabs[2].Visible = false;

            switch (modo)
            {
                case 0:
                    ToolsBarReaseguroBrokerage.Ribbon.Tabs[0].Groups["rgbSeleccion"].Visible = true;
                    tabBrokerage.Tabs[0].Visible = true;
                    break;

                case 1:
                    ToolsBarReaseguroBrokerage.Ribbon.Tabs[0].Groups["rgbEdoCuenta"].Visible = true;
                    tabBrokerage.Tabs[1].Visible = true;
                    tabBrokerage.Tabs[2].Visible = true;
                    break;
            }
        }

        void cargarDataSets()
        {
            this.reaseguradorasTableAdapter.Fill(this.cobranza.Reaseguradoras);
        }

        public ReaseguroBrokerage()
        {
            InitializeComponent();
        }

        private void ReaseguroBrokerage_Load(object sender, EventArgs e)
        {
            cargarDataSets();
            CambiarLayout(0);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            switch (cbParametro.SelectedIndex)
            {
                case 0: //Nombre
                    this.reaseguradorasTableAdapter.FillByNombre(this.cobranza.Reaseguradoras, txtBusqueda.Text);
                    break;
                case 2: //NameCode
                    this.reaseguradorasTableAdapter.FillByNameCode(this.cobranza.Reaseguradoras, txtBusqueda.Text);
                    break;
            }
            if (this.cobranza.Reaseguradoras.Rows.Count == 0)
                MessageBox.Show("No hay registros", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar_Click(null, null);
        }
    }
}
