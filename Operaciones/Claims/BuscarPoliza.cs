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
    public partial class BuscarPoliza : Form
    {
        public BuscarPoliza()
        {
            InitializeComponent();
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();

        }
        void CargarDataSets()
        {
            try { this.busquedaPolizaTableAdapter.Fill(this.liabilityInc.BusquedPolizas); } catch { }
        }

        private void BuscarPoliza_Load(object sender, EventArgs e)
        {
            CargarDataSets();
            cbFiltro.Text = "Poliza MX";
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarDataSets();
        }

        private void ultraTextEditor1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                switch (cbFiltro.Text)
                {
                    case "Asegurado":
                        this.busquedaPolizaTableAdapter.FillByAseguradoString(this.liabilityInc.BusquedPolizas, ultraTextEditor1.Text, 3);
                        break;

                    case "Poliza ES":
                        this.busquedaPolizaTableAdapter.FillByPolizaES(this.liabilityInc.BusquedPolizas, 3, ultraTextEditor1.Text);
                        break;

                    case "Poliza MX":
                        this.busquedaPolizaTableAdapter.FillByPolizaMX(this.liabilityInc.BusquedPolizas, 3, ultraTextEditor1.Text);
                        break;
                }
            }
        }

        private void dgPolizas_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            EditarFNOL.IDPolizaBusqueda = Convert.ToInt32(dgPolizas.ActiveRow.Cells["ID"].Value);
            DialogResult = DialogResult.Yes;
            Close();
        }
    }
}
