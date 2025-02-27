using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Catalogos.Emision
{
    public partial class mainEndosos : Form
    {
        public mainEndosos()
        {
            InitializeComponent();
        }

        void actualizarGrid()
        {
            // llenamos los endosos
            catalogoEndosoTableAdapter.Fill(this.liabilityInc.CatalogoEndoso);
            dgEndosos.DisplayLayout.PerformAutoResizeColumns(false, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
        }

        private void mainEndosos_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this, null, ToolbarsManagerEndosos);
            actualizarGrid();
            if (dgEndosos.Rows.Count > 0)
                dgEndosos.Selected.Rows.Add(dgEndosos.Rows[0]);
        }

        private void ToolbarsManagerEndosos_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            Catalogos.Emision.EndosoEdit frmEdit;

            switch (e.Tool.Key)
            {
                case "btnNuevoEndoso":    // Nuevo Endoso
                    frmEdit = new EndosoEdit();
                    if (frmEdit.ShowDialog() == DialogResult.OK)
                    {
                        actualizarGrid();
                    }
                    break;

                case "btnModificarEndoso":    // Modificamos los endosos
                    if (dgEndosos.Selected.Rows.Count == 1)
                    {
                        frmEdit = new EndosoEdit(Convert.ToInt32(dgEndosos.ActiveRow.Cells["ID"].Text));
                        if (frmEdit.ShowDialog() == DialogResult.OK)
                        {
                            actualizarGrid();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debes de seleccionar una fila para continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "btnEliminarEndoso":    // Eliminamos los endosos
                    if (dgEndosos.Selected.Rows.Count == 1)
                    {
                        if (MessageBox.Show("¿Deseas eliminar al endoso seleccionado? confirma por favor", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            dbSmartGDataContext db = new dbSmartGDataContext();
                            EndosoEmision endosoBorrar = (from x in db.EndosoEmision where x.ID == Convert.ToInt32(dgEndosos.ActiveRow.Cells["ID"].Text) select x).SingleOrDefault();
                            if (endosoBorrar != null)
                            {
                                endosoBorrar.Eliminado = true;
                                db.SubmitChanges();
                            }
                            MessageBox.Show("Endoso eliminado satisfactoriamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            actualizarGrid();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debes de seleccionar una fila para continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

            }//if (dgEndosos.Selected.Rows.Count == 1)
        }
    }
}
