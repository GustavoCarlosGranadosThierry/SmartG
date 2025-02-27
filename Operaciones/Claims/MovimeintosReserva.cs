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
    public partial class MovimeintosReserva : Form
    {
        int IDclaim;

        public MovimeintosReserva(int IDClaimNum)
        {
            InitializeComponent();
            IDclaim = IDClaimNum;
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MovimeintosReserva_Load(object sender, EventArgs e)
        {
            this.liIncMonedaTableAdapter.Fill(this.liabilityInc.LiIncMoneda);
            dbSmartGDataContext db = new dbSmartGDataContext();
            cbParametro.SelectedIndex = 0;
            ultraComboEditor1.SelectedIndex = 0;
        }

        private void cbParametro_ValueChanged(object sender, EventArgs e)
        {
            if(cbParametro.SelectedIndex == 0)
                this.claimsReporteMovimientosTableAdapter.FillByIndemnity(this.claims.ClaimsReporteMovimientos, IDclaim);
            else
                this.claimsReporteMovimientosTableAdapter.FillByExpenses(this.claims.ClaimsReporteMovimientos, IDclaim);

            ultraComboEditor1_ValueChanged(null, null);
            ultraButton2_Click(null, null);
        }

        private void ultraComboEditor1_ValueChanged(object sender, EventArgs e)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgRegistrosClaims.Rows)
            {
                item.Cells["MonedaAplicada"].Value = ultraComboEditor1.Text;
            }
            ultraButton2_Click(null, null);

        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow itemMain in dgRegistrosClaims.Rows)
            {
                decimal suma = 0;
                DateTime fecha = Convert.ToDateTime(itemMain.Cells["DatePosted"].Value);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow itemBuscar in dgRegistrosClaims.Rows)
                {
                    if (fecha == Convert.ToDateTime(itemBuscar.Cells["DatePosted"].Value))
                        suma += Convert.ToDecimal(itemBuscar.Cells["MontoAplicado"].Value);
                }
                itemMain.Cells["TotalMovimiento"].Value = suma;
            }

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow itemMain in dgRegistrosClaims.Rows)
            {
                // detecta la fecha mas proxima anterior
                DateTime fechaMain = Convert.ToDateTime(itemMain.Cells["DatePosted"].Value);
                DateTime fechaAnterior = Convert.ToDateTime(itemMain.Cells["DatePosted"].Value);

                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow itemBuscar in dgRegistrosClaims.Rows)
                {
                    double diasDif = (fechaMain - Convert.ToDateTime(itemBuscar.Cells["DatePosted"].Value)).TotalDays;
                    if (diasDif <= 0) continue;
                    if (diasDif > (fechaAnterior - fechaMain).TotalDays)
                        fechaAnterior = Convert.ToDateTime(itemBuscar.Cells["DatePosted"].Value);
                }
                itemMain.Cells["FechaAnterior"].Value = fechaAnterior;

                // Coloca el valor del flujo
                if (Convert.ToDateTime(itemMain.Cells["DatePosted"].Value) == Convert.ToDateTime(itemMain.Cells["FechaAnterior"].Value))
                    itemMain.Cells["FlujoReserva"].Value = itemMain.Cells["TotalMovimiento"].Value;
                else
                {
                    decimal valorReservaPrevio = 0;
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow itemBuscar in dgRegistrosClaims.Rows)
                    {
                        if(Convert.ToDateTime(itemBuscar.Cells["DatePosted"].Value) == Convert.ToDateTime(itemMain.Cells["FechaAnterior"].Value))
                        {
                            valorReservaPrevio = Convert.ToDecimal(itemBuscar.Cells["TotalMovimiento"].Value);
                            break;
                        }
                    }
                    itemMain.Cells["FlujoReserva"].Value = Convert.ToDecimal(itemMain.Cells["TotalMovimiento"].Value) - valorReservaPrevio ;
                }
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string rutaFile = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rutaFile = saveFileDialog1.FileName;
                try
                {
                    string NomReporte = "";
                    ultraGridExcelExporter1.Export(dgRegistrosClaims, rutaFile);
                    NomReporte = "Pendientes de Autorizar";
                    // Agrega los encabezados
                    Extensiones.Reportes.EditarEncabezados(rutaFile, DateTime.Now, DateTime.Now, true, "Reporte Movimientos de Reservas " + NomReporte, 20);
                    System.Diagnostics.Process.Start(rutaFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}
