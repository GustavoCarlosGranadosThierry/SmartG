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
    public partial class EditarAjustadores : Form
    {
        int IDEmpresa;
        int IDAjustador;

        public EditarAjustadores(int IDempresa, int IDajustador)
        {
            InitializeComponent();
            IDEmpresa = IDempresa;
            IDAjustador = IDajustador;
        }

        private void EditarAjustadores_Load(object sender, EventArgs e)
        {
            this.clasificacionAjustadoresTableAdapter.Fill(this.claims.ClasificacionAjustadores);
            this.ramosHonorariosAjustadoresTableAdapter.Fill(this.claims.RamosHonorariosAjustadores, IDEmpresa);
            if (IDAjustador != 0)
                RecuperarDatos();
        }

        void RecuperarDatos()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            Ajustadore AjustaRecupera = (from x in db.Ajustadores where x.ID == IDAjustador select x).SingleOrDefault();
            txtNombre.Text=AjustaRecupera.Nombre ;
            txtDireccion.Text=AjustaRecupera.Direccion ;
            txtEmail.Text =AjustaRecupera.Email;
            txtTel.Text = AjustaRecupera.Telefono;
            txtObservaciones.Text= AjustaRecupera.Observaciones;
            cbClasifiacion.Value = Convert.ToInt32(  AjustaRecupera.Clasificacion);

            AjustadorRamo[] RamosUsados = (from x in db.AjustadorRamos where x.Ajustador == IDAjustador select x).ToArray();
            if (RamosUsados.Count() > 0)
            {
                for (int i = 0; i < RamosUsados.Count(); i++)
                {
                    int RamoUsado = Convert.ToInt32( RamosUsados[i].Ramo);
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgRamos.Rows)
                    {
                        if (RamoUsado == Convert.ToInt32(item.Cells["ID"].Value))
                            item.Cells["Check"].Value = true;
                    }
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Valida
            if (txtNombre.Text == "" || txtDireccion.Text == "" || txtEmail.Text == "" || txtTel.Text == "" || cbClasifiacion.Text == "")
            {
                MessageBox.Show("Ingrese los valores de identificación (Nombre, dirección, telefono, email y clasifiación) para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool checkRamos = false;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgRamos.Rows)
            {
                if (Convert.ToBoolean(item.Cells["Check"].Value))
                    checkRamos = true;
            }
            if (!checkRamos)
            {
                MessageBox.Show("Seleccione al menos 1 Ramo para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Guarda
            dbSmartGDataContext db = new dbSmartGDataContext();
            Ajustadore nuevoAjustador = null;
            if (IDAjustador == 0)
                nuevoAjustador = new Ajustadore();
            else
                nuevoAjustador = (from x in db.Ajustadores where x.ID == IDAjustador select x).SingleOrDefault();

            nuevoAjustador.Organizacion = IDEmpresa;
            nuevoAjustador.Nombre = txtNombre.Text;
            nuevoAjustador.Direccion = txtDireccion.Text;
            nuevoAjustador.Email = txtEmail.Text;
            nuevoAjustador.Telefono = txtTel.Text;
            nuevoAjustador.Observaciones = txtObservaciones.Text;
            nuevoAjustador.Clasificacion = Convert.ToInt32(cbClasifiacion.Value);
            nuevoAjustador.Eliminado = false;

            if (IDAjustador == 0)
                db.Ajustadores.InsertOnSubmit(nuevoAjustador);
            db.SubmitChanges();

            IDAjustador = nuevoAjustador.ID;

            // Mata los ramos anteriores
            AjustadorRamo[] borrarRamo = (from x in db.AjustadorRamos where x.Ajustador == IDAjustador select x).ToArray();
            if(borrarRamo.Count() > 0)
            {
                db.AjustadorRamos.DeleteAllOnSubmit(borrarRamo);
                db.SubmitChanges();
            }

            // ingresa nuevos ramos
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in dgRamos.Rows)
            {
                if (Convert.ToBoolean(item.Cells["Check"].Value))
                {
                    AjustadorRamo nuevoRamo = new AjustadorRamo();
                    nuevoRamo.Ajustador = IDAjustador;
                    nuevoRamo.Ramo = Convert.ToInt32(item.Cells["ID"].Value);
                    db.AjustadorRamos.InsertOnSubmit(nuevoRamo);
                    db.SubmitChanges();
                }
            }

            MessageBox.Show("Ajustador ingresado correctamente");
            DialogResult = DialogResult.Yes;
            Close();
        }
    }
}
