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
    public partial class EditarEsquemaHonorarios : Form
    {
        int IDHonorarios;
        public EditarEsquemaHonorarios(int idhonorarios)
        {
            InitializeComponent();
            IDHonorarios = idhonorarios;
        }

        private void EditarEsquemaHonorarios_Load(object sender, EventArgs e)
        {
            this.monedaTableAdapter.Fill(this.facturacion.Moneda);
            this.viaticosTableAdapter.Fill(this.claims.Viaticos);
            cbMoneda.SelectedIndex = 0;
            if (IDHonorarios != 0)
                RecuperarDatos();
        }

        void RecuperarDatos()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            txtNombre.Text = (from x in db.Honorarios where x.ID == IDHonorarios select x.NombreEstructura).SingleOrDefault();
            cbMoneda.Value = Convert.ToInt32((from x in db.Honorarios where x.ID == IDHonorarios select x.Moneda).SingleOrDefault());
            HonorarioLimite[] LimiteRec = (from x in db.HonorarioLimites where x.Honorario == IDHonorarios orderby x.De ascending select x).ToArray();
            if(LimiteRec.Count() >0)
            {
                for (int i = 0; i < LimiteRec.Count(); i++)
                {
                    dtEsquemas.Rows.Add(new object[] 
                    {
                        LimiteRec[i].ID,
                        LimiteRec[i].De,
                        LimiteRec[i].Hasta,
                        LimiteRec[i].Monto
                    });
                }
            }

            HonorariosViatico[] ViaticoRec = (from x in db.HonorariosViaticos where x.Honorario == IDHonorarios orderby x.ID ascending select x).ToArray();
            if (ViaticoRec.Count() > 0)
            {
                for (int i = 0; i < ViaticoRec.Count(); i++)
                {
                    dtViaticos.Rows.Add(new object[]
                    {
                        ViaticoRec[i].ID,
                        ViaticoRec[i].Viatico,
                        ViaticoRec[i].Descripcion
                    });
                }
            }
        }

        private void dgEsquema_AfterRowInsert(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            int RowIndex = dgEsquema.Rows.Count - 1;
            if (RowIndex == 0)
            {
                dgEsquema.Rows[RowIndex].Cells["De"].Value = 0;
                dgEsquema.Rows[RowIndex].Cells["Hasta"].Value = 1000;
                return;
            }
            else
            {
                try { dgEsquema.Rows[RowIndex].Cells["De"].Value = Convert.ToDecimal(dgEsquema.Rows[RowIndex - 1].Cells["Hasta"].Value) + 1; } catch { }
            }
        }

        private void dgEsquema_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            dgEsquema.ActiveRow.Delete(false);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text == "")
            {
                MessageBox.Show("Ingrese un nombre para el esquema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            if(dgEsquema.Rows.Count == 0)
            {
                MessageBox.Show("Ingrese al menos 1 linea al esquema de honorarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }

            // ingresa honorario
            dbSmartGDataContext db = new dbSmartGDataContext();
            Honorario honorarioEdicion = null;
            if (IDHonorarios == 0)
                honorarioEdicion = new Honorario();
            else
                honorarioEdicion = (from x in db.Honorarios where x.ID == IDHonorarios select x).SingleOrDefault();

            honorarioEdicion.NombreEstructura = txtNombre.Text;
            honorarioEdicion.Moneda = Convert.ToInt32(cbMoneda.Value);
            if (IDHonorarios == 0)
                db.Honorarios.InsertOnSubmit(honorarioEdicion);

            db.SubmitChanges();

            IDHonorarios = honorarioEdicion.ID;

            //Borra  Limites anteriores
            HonorarioLimite[] LimitesBorrar = (from x in db.HonorarioLimites where x.Honorario == IDHonorarios select x).ToArray();
            if (LimitesBorrar.Count() > 0)
            {
                db.HonorarioLimites.DeleteAllOnSubmit(LimitesBorrar);
                db.SubmitChanges();
            }

            // ingresa Nuevos Limites
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgEsquema.Rows)
            {
                HonorarioLimite nuevoLimite = new HonorarioLimite();
                nuevoLimite.Honorario = IDHonorarios;
                nuevoLimite.De = Convert.ToDecimal(item.Cells["De"].Value);
                nuevoLimite.Hasta = Convert.ToDecimal(item.Cells["Hasta"].Value);
                nuevoLimite.Monto = Convert.ToDecimal(item.Cells["MontoHonorario"].Value);
                db.HonorarioLimites.InsertOnSubmit(nuevoLimite);
                db.SubmitChanges();
            }


            //Borra  Viaticos anteriores
            HonorariosViatico[] ViaticosBorrar = (from x in db.HonorariosViaticos where x.Honorario == IDHonorarios select x).ToArray();
            if (ViaticosBorrar.Count() > 0)
            {
                db.HonorariosViaticos.DeleteAllOnSubmit(ViaticosBorrar);
                db.SubmitChanges();
            }

            // ingresa Nuevos Viaticos
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgViaticos.Rows)
            {
                HonorariosViatico nuevoViatico = new HonorariosViatico();
                nuevoViatico.Honorario = IDHonorarios;
                nuevoViatico.Viatico = Convert.ToInt32(item.Cells["Viatico"].Value);
                nuevoViatico.Descripcion = item.Cells["Descripcion"].Value.ToString();
                db.HonorariosViaticos.InsertOnSubmit(nuevoViatico);
                db.SubmitChanges();
            }

            MessageBox.Show("Agregado la estructura de Honorarios");
            this.DialogResult = DialogResult.Yes;
            this.Close();

        }

        private void dgViaticos_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            dgViaticos.ActiveRow.Delete(false);

        }
    }
}
