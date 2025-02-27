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
    public partial class EdiciónOrganizacionAjustadores : Form
    {
        int IDEmpresa;
        public EdiciónOrganizacionAjustadores(int idempresa)
        {
            InitializeComponent();
            IDEmpresa = idempresa;
        }

        private void EdiciónOrganizacionAjustadores_Load(object sender, EventArgs e)
        {
            CargarDataSets();

            if (IDEmpresa != 0)
            {
                CargarDatos();
            }
        }

        void CargarDataSets()
        {
            this.ajustadoresTableAdapter.FillByOrganizacion(this.claims.Ajustadores, IDEmpresa);
            this.ramosSegurosTableAdapter.Fill(this.facturacion.RamosSeguros);
            this.honorariosTableAdapter.Fill(this.claims.Honorarios);

        }

        void CargarDatos()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            AjustadorEmpresa EmpresaRec = (from x in db.AjustadorEmpresas where x.ID == IDEmpresa select x).SingleOrDefault();

            txtNombre.Text = EmpresaRec.Nombre;
            txtRFC.Text = EmpresaRec.RFC;
            txtDireccion.Text = EmpresaRec.Direccion;
            txtEmail.Text = EmpresaRec.Email;

            AjustadorEmpresaHonorariosRamo[] ramosHonorarios = (from x in db.AjustadorEmpresaHonorariosRamos where x.EmpresaAjuste == IDEmpresa select x).ToArray();
            if(ramosHonorarios.Count() > 0)
            {
                for (int i = 0; i < ramosHonorarios.Count(); i++)
                {
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgRamosHonorarios.Rows)
                    {
                        if(Convert.ToInt32(ramosHonorarios[i].Ramo) == Convert.ToInt32(item.Cells["ID"].Value))
                        {
                            item.Cells["Check"].Value = true;
                            item.Cells["Estructura Honorario"].Value = Convert.ToInt32(ramosHonorarios[i].Honorario);
                        }
                    }
                }
            }

        }

        private void btnNuevoAjustador_Click(object sender, EventArgs e)
        {
            if (!GuardarEmpresaRamosHonorarios())
                return;

            EditarAjustadores frmNuevoAjus = new EditarAjustadores(IDEmpresa, 0);
            if(frmNuevoAjus.ShowDialog() == DialogResult.Yes)
                this.ajustadoresTableAdapter.FillByOrganizacion(this.claims.Ajustadores, IDEmpresa);
        }

        bool GuardarEmpresaRamosHonorarios()
        {
            // Validaciones
            if (txtNombre.Text == "" || txtDireccion.Text == "" || txtEmail.Text == "" || txtRFC.Text == "")
            {
                MessageBox.Show("Ingrese los valores de identificación de la empresa (Nombre, RFC, dirección y email) para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool ValCheck = false;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgRamosHonorarios.Rows)
            {
                if (Convert.ToBoolean(item.Cells["Check"].Value) == true)
                {
                    ValCheck = true;
                    if (item.Cells["Estructura Honorario"].Text == "")
                    {
                        MessageBox.Show("No se han ingresado los valores completos de alguno de los Ramos/Honorarios seleccionados, ingreselos para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            if (!ValCheck)
            {
                MessageBox.Show("No se ha seleccionado ningún Ramos/Honorarios, ingrese al menos 1 para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Guardar Empresa
            dbSmartGDataContext db = new dbSmartGDataContext();
            AjustadorEmpresa NuevaEmpresa = null;

            if (IDEmpresa == 0)
                NuevaEmpresa = new AjustadorEmpresa();
            else
                NuevaEmpresa = (from x in db.AjustadorEmpresas where x.ID == IDEmpresa select x).SingleOrDefault();

            NuevaEmpresa.Nombre = txtNombre.Text;
            NuevaEmpresa.RFC = txtRFC.Text;
            NuevaEmpresa.Direccion = txtDireccion.Text;
            NuevaEmpresa.Email = txtEmail.Text;
            NuevaEmpresa.Eliminado = false;

            if (IDEmpresa == 0)
                db.AjustadorEmpresas.InsertOnSubmit(NuevaEmpresa);

            db.SubmitChanges();
            IDEmpresa = NuevaEmpresa.ID;

            //Borra los Ramos y Honorarios
            AjustadorEmpresaHonorariosRamo[] BorrarIntermedios = (from x in db.AjustadorEmpresaHonorariosRamos where x.EmpresaAjuste == IDEmpresa select x).ToArray();
            if( BorrarIntermedios.Count() > 0)
            {
                db.AjustadorEmpresaHonorariosRamos.DeleteAllOnSubmit(BorrarIntermedios);
                db.SubmitChanges();
            }

            //Guardar Ramos y Honorarios
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgRamosHonorarios.Rows)
            {
                if(Convert.ToBoolean(item.Cells["Check"].Value))
                {
                    AjustadorEmpresaHonorariosRamo nuevoIntermedio = new AjustadorEmpresaHonorariosRamo();
                    nuevoIntermedio.EmpresaAjuste = IDEmpresa;
                    nuevoIntermedio.Ramo = Convert.ToInt32(item.Cells["ID"].Value);
                    nuevoIntermedio.Honorario = Convert.ToInt32(item.Cells["Estructura Honorario"].Value);
                    db.AjustadorEmpresaHonorariosRamos.InsertOnSubmit(nuevoIntermedio);
                    db.SubmitChanges();
                }
            }
            return true;
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevoHonorarios_Click(object sender, EventArgs e)
        {
            EditarEsquemaHonorarios frmHonorariosNuevo = new EditarEsquemaHonorarios(0);
            if(frmHonorariosNuevo.ShowDialog() == DialogResult.Yes)
                this.honorariosTableAdapter.Fill(this.claims.Honorarios);

        }

        private void btnEditarHonorarios_Click(object sender, EventArgs e)
        {
            SeleccionEsquemaHonorario frmSelHono = new SeleccionEsquemaHonorario();
            frmSelHono.ShowDialog();
            this.honorariosTableAdapter.Fill(this.claims.Honorarios);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!GuardarEmpresaRamosHonorarios())
                return;
            MessageBox.Show("Empresa de Ajuste guadada correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void btnEditarAjustador_Click(object sender, EventArgs e)
        {
            if (dgAjustadores.ActiveRow == null)
                return;
            if (!GuardarEmpresaRamosHonorarios())
                return;

            EditarAjustadores frmNuevoAjus = new EditarAjustadores(IDEmpresa, Convert.ToInt32(dgAjustadores.ActiveRow.Cells["ID"].Value));
            if (frmNuevoAjus.ShowDialog() == DialogResult.Yes)
                this.ajustadoresTableAdapter.FillByOrganizacion(this.claims.Ajustadores, IDEmpresa);

        }

        private void ultraButton3_Click(object sender, EventArgs e)
        {
            if (dgAjustadores.ActiveRow == null)
                return;

            if (MessageBox.Show("Se borrará el Ajustador seleccionado, continuar?","Mensaje",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                Ajustadore EditarAjustador = (from x in db.Ajustadores where x.ID == Convert.ToInt32(dgAjustadores.ActiveRow.Cells["ID"].Value) select x).SingleOrDefault();
                EditarAjustador.Eliminado = true;
                db.SubmitChanges();
                CargarDataSets();

            }
        }
    }
}
