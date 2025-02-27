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
    public partial class SeleccionEsquemaHonorario : Form
    {
        public SeleccionEsquemaHonorario()
        {
            InitializeComponent();
        }

        private void SeleccionEsquemaHonorario_Load(object sender, EventArgs e)
        {
            this.honorariosTableAdapter.Fill(this.claims.Honorarios);
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(cbViaticos.Text == "")
            {
                MessageBox.Show("No se selecciono ningun esquema");
                Close();
            }
            else
            {
                EditarEsquemaHonorarios frmHonorariosNuevo = new EditarEsquemaHonorarios(Convert.ToInt32(cbViaticos.Value));
                frmHonorariosNuevo.ShowDialog();
                Close();

            }
        }
    }
}
