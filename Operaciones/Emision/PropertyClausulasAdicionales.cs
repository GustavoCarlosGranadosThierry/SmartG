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
    public partial class PropertyClausulasAdicionales : Form
    {
        int ln = 0;
        string LineaCap;

        public PropertyClausulasAdicionales(int tmpLN=0,string tmpLineaCap="")
        {
            InitializeComponent();
            ln = tmpLN;
            LineaCap = tmpLineaCap;
        }

        private void PropertyClausulasAdicionales_Load(object sender, EventArgs e)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            CoberturasAdicionales[] coberturasAdi = (from x in db.CoberturasAdicionales where x.LineaNegocios == ln select x).ToArray();
            dgCoberturasAdi.DataSource = coberturasAdi;

            #region modificar Grid
            dgCoberturasAdi.DisplayLayout.Bands[0].Columns["LineaNegocios"].Hidden = true;
            dgCoberturasAdi.DisplayLayout.Bands[0].Columns["userAdd"].Hidden = true;
            dgCoberturasAdi.DisplayLayout.Bands[0].Columns["Eliminado"].Hidden = true;
            dgCoberturasAdi.DisplayLayout.Bands[0].Columns["LineaNegocios1"].Hidden = true;
            dgCoberturasAdi.DisplayLayout.Bands[0].Columns["Cobertura"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            dgCoberturasAdi.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            #endregion

            if (LineaCap != "")
                llenarDatos();

            this.FormClosing += PropertyClausulasAdicionales_FormClosing;
        }

        void llenarDatos()
        {
            string[] datos = LineaCap.Split('|');
            for (int i = 0; i < datos.Count(); i++)
            {
                string[] datosLoad = datos[i].Split(';');
                int contador = 1;
                for (int k = 2; k < 11; k++)
                {
                    if (datosLoad[k] == "T")
                        dgCoberturasAdi.Rows[i].Cells["S" + contador.ToString()].Value = true;
                    else
                        dgCoberturasAdi.Rows[i].Cells["S" + contador.ToString()].Value = false;
                    contador++;
                }
            }
        }

        private void PropertyClausulasAdicionales_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Desea guardar los cambios antes de salir?", "Aviso", MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                dgCoberturasAdi.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);

                this.DialogResult = DialogResult.OK;
                LineaCap = "";
                int contador = 1;
                for (int i = 0; i < dgCoberturasAdi.Rows.Count; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        if (j == 0)
                            LineaCap += dgCoberturasAdi.Rows[i].Cells["ID"].Text.ToString();
                        else if (j == 1)
                            LineaCap += ";" + dgCoberturasAdi.Rows[i].Cells["Cobertura"].Text.ToString();
                        else
                        {
                            if (Convert.ToBoolean(dgCoberturasAdi.Rows[i].Cells["S"+contador.ToString()].Value))
                                LineaCap += ";" + "T";
                            else
                                LineaCap += ";" + "F";
                            contador++;
                        }
                    }
                    contador = 1;
                    if (i + 1 < dgCoberturasAdi.Rows.Count)
                        LineaCap += "|";
                }

                Operaciones.Emision.PropertyInc.coberturasAdicionales = LineaCap;
            }
        }
    }
}
