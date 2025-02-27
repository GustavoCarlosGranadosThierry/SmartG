using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Operaciones.CreditControl
{
    public partial class WriteOff : Form
    {
        int IDJournal;
        decimal DiferenciaMasMenos;
        bool AplicacionAutomatica;
        decimal AumentoDisminucion;

        public WriteOff(int idjournal, bool DesdeAplicacionAutomatica = false, decimal aumentodisminucion = 0)
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
            IDJournal = idjournal;
            AplicacionAutomatica = DesdeAplicacionAutomatica;
            AumentoDisminucion = aumentodisminucion;
        }

        private void WriteOff_Load(object sender, EventArgs e)
        {
            this.monedaTableAdapter.Fill(this.facturacion.Moneda);

            //CargarDatos
            dbSmartGDataContext db = new dbSmartGDataContext();
            Journal JournalRecu = (from x in db.Journals where x.ID == IDJournal select x).SingleOrDefault();
            txtSnum.Text = JournalRecu.SNum.ToString();
            cbMoneda.Value = JournalRecu.MonPrimaAplicada;
            txtMontoOriginal.Value = JournalRecu.PrimaAplicada;

            if (Convert.ToInt32(cbMoneda.Value) == Convert.ToInt32((from x in db.Monedas where x.Abreviacion == "MXN" select x.ID).SingleOrDefault()))
                DiferenciaMasMenos = Convert.ToDecimal((from x in db.JournalWriteOffLimites orderby x.ID descending select x.LimiteMasMenosMXN).FirstOrDefault());
            else
                DiferenciaMasMenos = Convert.ToDecimal((from x in db.JournalWriteOffLimites orderby x.ID descending select x.LimiteMasMenosUSD).FirstOrDefault());

            if(AplicacionAutomatica)
            {
                cbMoneda.Enabled = false;
                txtMontoModificado.Enabled = false;
                btnCancelar.Enabled = false;
                txtMontoModificado.Value = Convert.ToDecimal(txtMontoOriginal.Value) + AumentoDisminucion;                
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtMontoModificado_ValueChanged(object sender, EventArgs e)
        {
            decimal Diferencia = - Convert.ToDecimal(txtMontoOriginal.Value) + Convert.ToDecimal(txtMontoModificado.Value);
            txtDiferencia.Value = Diferencia;
            if (Diferencia < 0)
                txtTipoMovimiento.Text = "Reducción";
            else
                txtTipoMovimiento.Text = "Aumento";
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            if (Convert.ToDecimal(txtMontoModificado.Value) == 0 || Convert.ToDecimal(txtDiferencia.Value) == 0 || txtJustificacion.Text == "" || 
                txtTipoMovimiento.Text == "")
            {
                MessageBox.Show("Valores incompletos o invalidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Math.Abs(Convert.ToDecimal(txtDiferencia.Value)) > DiferenciaMasMenos)
            {
                int btnWO = (from x in db.Perfiles where x.KeyName == "btnEditarLimitesWriteOffs" select x.ID).SingleOrDefault();
                int AccesosLimitesWO = (from x in db.UsuariosPerfils where x.Usuario == Program.Globals.UserID && x.Perfil == btnWO select x).ToArray().Count();

                if(AccesosLimitesWO == 0)
                {
                    MessageBox.Show("El valor de la diferencia ingresado excede el limite definido de: $" + DiferenciaMasMenos.ToString("N2") + " " + cbMoneda.Text,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Consulta el numero de WriteOffs aplicados
            int ConteoWriteOffs = Convert.ToInt32((from x in db.JournalWriteOffs where x.Journal == IDJournal select x).ToArray().Count());
            if (ConteoWriteOffs > 0)
            {
                if(ConteoWriteOffs == 1) // Mensaje advertencia
                {
                    if( MessageBox.Show("Este Journal ya tiene aplicado un WriteOff previamente, desea reaplicar nuevo un cambio a este?", "Mensaje Advertencia",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.No)
                        return;
                }
                else // Bloqueo de WirteOffs
                {
                    MessageBox.Show("Este Journal ya tiene aplicado un 2 WriteOff previamente, no se pueden aplicar mas cambios a este registro", "Mensaje Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Guarda Write Off
            JournalWriteOff journalWriteNuevo = new JournalWriteOff();
            journalWriteNuevo.Journal = IDJournal;
            journalWriteNuevo.TipoMovimiento = txtTipoMovimiento.Text;
            journalWriteNuevo.MontoOriginal = Convert.ToDecimal(txtMontoOriginal.Value);
            journalWriteNuevo.NuevoMonto = Convert.ToDecimal(txtMontoModificado.Value);
            journalWriteNuevo.Diferencia = Convert.ToDecimal(txtDiferencia.Value);
            journalWriteNuevo.JustificacionUsuario = txtJustificacion.Text;
            journalWriteNuevo.Usuario = Program.Globals.UserID;
            journalWriteNuevo.FechaAplicacion = DateTime.Now;
            db.JournalWriteOffs.InsertOnSubmit(journalWriteNuevo);
            db.SubmitChanges();

            // Actualiza Journal
            Journal JournalMod = (from x in db.Journals where x.ID == IDJournal select x).SingleOrDefault();
            JournalMod.PrimaAplicada = Convert.ToDecimal(txtMontoModificado.Value);
            db.SubmitChanges();

            MessageBox.Show("Write Off aplicado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            DialogResult = DialogResult.Yes;
            Close();
        }
    }
}
