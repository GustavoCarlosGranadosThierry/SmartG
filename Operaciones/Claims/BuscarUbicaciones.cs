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
    public partial class BuscarUbicaciones : Form
    {
        public BuscarUbicaciones()
        {
            InitializeComponent();
        }

        private void dgRegistrosClaims_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

        }

        private void BuscarUbicaciones_Load(object sender, EventArgs e)
        {
            this.claimsCatalogoUbicaciones163TableAdapter.Fill(this.claims.ClaimsCatalogoUbicaciones163);
            cbParametro.SelectedIndex = 0;
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                switch(cbParametro.SelectedIndex)
                {
                    case 0: // cep
                        this.claimsCatalogoUbicaciones163TableAdapter.FillByCP(this.claims.ClaimsCatalogoUbicaciones163, txtBusqueda.Text);
                        break;
                    case 1: //mun
                        this.claimsCatalogoUbicaciones163TableAdapter.FillByMunicipio(this.claims.ClaimsCatalogoUbicaciones163, txtBusqueda.Text);
                        break;
                    case 2: // ent
                        this.claimsCatalogoUbicaciones163TableAdapter.FillByEntidad(this.claims.ClaimsCatalogoUbicaciones163, txtBusqueda.Text);
                        break;
                }
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            this.claimsCatalogoUbicaciones163TableAdapter.Fill(this.claims.ClaimsCatalogoUbicaciones163);

        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void dgUbicaciones_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            EditarFNOL.IDUbicacion = Convert.ToInt32(dgUbicaciones.ActiveRow.Cells["ID"].Value);
            DialogResult = DialogResult.Yes;
            Close();
        }
    }
}
