using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Catalogos
{
    public partial class MainLimiteMaximo : Form
    {
        int idAnterior = 0;
        public MainLimiteMaximo()
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
        }

        private void MainLimiteMaximo_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this);
            dbSmartGDataContext db = new dbSmartGDataContext();
            LimiteMaximo tmpLimite = (from x in db.LimiteMaximo where x.Activo == true select x).SingleOrDefault();
            if (tmpLimite != null)
            {
                txtLimiteActual.Value = tmpLimite.LimiteMaximo1;
                txtDivisaActual.Value = tmpLimite.Divisa;
                idAnterior = tmpLimite.ID;
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtLimiteNuevo.Value) > 0 && Convert.ToDecimal(txtDivisaNueva.Value) > 0)
            {
                if (MessageBox.Show("¿Deseas actualizar el valor del límite máximo de retención para México y su divisa?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    LimiteMaximo nuevoLimite = new LimiteMaximo();
                    nuevoLimite.LimiteMaximo1 = Convert.ToDecimal(txtLimiteNuevo.Value);
                    nuevoLimite.Divisa = Convert.ToDecimal(txtDivisaNueva.Value);
                    nuevoLimite.Usuario = Program.Globals.UserID;
                    nuevoLimite.FechaRegistro = DateTime.Now;
                    nuevoLimite.Activo = true;
                    db.LimiteMaximo.InsertOnSubmit(nuevoLimite);

                    LimiteMaximo tmpLimite = (from x in db.LimiteMaximo where x.ID == idAnterior select x).SingleOrDefault();
                    if (tmpLimite != null)
                    {
                        tmpLimite.Activo = false;
                    }

                    db.SubmitChanges();

                    MessageBox.Show("Límite actualizado correctamente, esta ventana se cerrará", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Los valores deben de ser ambos mayores a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
