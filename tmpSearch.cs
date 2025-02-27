using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG
{
    public partial class tmpSearch : Form
    {
        int tipoVentana;
        public tmpSearch(int tipo=0)
        {
            tipoVentana = tipo;
            InitializeComponent();
        }

        private void tmpSearch_Load(object sender, EventArgs e)
        {
            if (tipoVentana == 0)
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                Poliza[] polizas = (from x in db.Poliza where x.Status == 3 select x).ToArray();
                ultraGrid1.DataSource = polizas;
            }
            else
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                DoctosTemplates[] templates = (from x in db.DoctosTemplates select x).ToArray();
                ultraGrid1.DataSource = templates;
            }
        }

        private void ultraGrid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (tipoVentana == 0)
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                this.DialogResult = DialogResult.OK;
                Main.guardado = Convert.ToInt32(ultraGrid1.ActiveRow.Cells["ID"].Text.ToString());
                Main.lineaNegocios = (from x in db.LineaNegocios where x.ID == Convert.ToInt32(ultraGrid1.ActiveRow.Cells["LineaNegocios"].Text) select x.LineaNegocios1).SingleOrDefault();
                this.Close();
            }
            else
            {
                if (ultraGrid1.Selected.Rows.Count == 1)
                {
                    DocumentosDB docto = new DocumentosDB();
                    if (docto.ExtraerDocumentoDB(ultraGrid1.ActiveRow.Cells["NombreDocumento"].Text))
                        MessageBox.Show("Documento extraido");
                }

            }
        }
    }
}
