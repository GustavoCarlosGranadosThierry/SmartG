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
    public partial class agregarEditarReaseguradoras : Form
    {
        int idReaseguradora;

        bool verificarReaseguradora()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            if (txtCodigoReaseguradora.Text == "" || txtReaseguradora.Text == "" || txtRIPolicy.Text == "")
            {
                MessageBox.Show("Ocurrió un error, todos los campos excepto grupo de finanzas son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Reaseguradoras tmpRease = (from x in db.Reaseguradoras where x.Codigo == txtCodigoReaseguradora.Text select x).SingleOrDefault();
            //if (tmpRease != null)
            //{
            //    if (tmpRease.Nombre == txtReaseguradora.Text && txtRIPolicy.Text == tmpRease.RI_Policy && Convert.ToDecimal(txtFijoInterno.Value) == tmpRease.Fijo_Interno && Convert.ToDecimal(txtComision.Value) == tmpRease.Comision)
            //    {
            //        MessageBox.Show("Ocurrió un error, la reaseguradora que intentas ingresar ya está en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
            //}

            return true;
        }

        public agregarEditarReaseguradoras(int id=0)
        {
            idReaseguradora = id;
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
        }

        private void agregarEditarReaseguradoras_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this);

            dbSmartGDataContext db = new dbSmartGDataContext();
            if (idReaseguradora != 0)
            {
                Reaseguradoras tmpRease = (from x in db.Reaseguradoras where x.ID == idReaseguradora select x).SingleOrDefault();
                txtCodigoReaseguradora.Text = tmpRease.Codigo;
                txtReaseguradora.Text = tmpRease.Nombre;
                txtRIPolicy.Text = tmpRease.RI_Policy;
                txtFijoInterno.Value = tmpRease.Fijo_Interno;
                txtComision.Value = tmpRease.Comision;
                chkTreaty.Checked = Convert.ToBoolean(tmpRease.Treaty);
                txtGrupoFinanzas.Text = tmpRease.GrupoFinanzas;
                chkLiability.Checked = Convert.ToBoolean(tmpRease.DefectoLI);
                chkMarine.Checked = Convert.ToBoolean(tmpRease.DefectoMA);
                chkProperty.Checked = Convert.ToBoolean(tmpRease.DefectoPR);
                chkFL.Checked = Convert.ToBoolean(tmpRease.DefectoFL);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (verificarReaseguradora())
            {
                if (txtCodigoReaseguradora.Text != "" && txtReaseguradora.Text != "" && txtRIPolicy.Text != "")
                {
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    Reaseguradoras nuevaRease;
                    if (idReaseguradora == 0)
                        nuevaRease = new Reaseguradoras();
                    else
                        nuevaRease = (from x in db.Reaseguradoras where x.ID == idReaseguradora select x).SingleOrDefault();
                    nuevaRease.Codigo = txtCodigoReaseguradora.Text;
                    nuevaRease.Nombre = txtReaseguradora.Text;
                    nuevaRease.RI_Policy = txtRIPolicy.Text;
                    nuevaRease.Fijo_Interno = Convert.ToDecimal(txtFijoInterno.Value);
                    nuevaRease.Comision = Convert.ToDecimal(txtComision.Value);
                    nuevaRease.Treaty = chkTreaty.Checked;
                    nuevaRease.GrupoFinanzas = txtGrupoFinanzas.Text;
                    nuevaRease.DefectoLI = chkLiability.Checked;
                    nuevaRease.DefectoMA = chkMarine.Checked;
                    nuevaRease.DefectoPR = chkProperty.Checked;
                    nuevaRease.DefectoFL = chkFL.Checked;
                    nuevaRease.Aprobado = false;
                    nuevaRease.Eliminado = false;
                    if (idReaseguradora == 0)
                        db.Reaseguradoras.InsertOnSubmit(nuevaRease);
                    db.SubmitChanges();

                    ReaseguradorasSolicitudes nuevaSolicitud = new ReaseguradorasSolicitudes();
                    nuevaSolicitud.UsuarioSolicitud = Program.Globals.UserID;
                    nuevaSolicitud.FechaSolicitud = DateTime.Now;
                    nuevaSolicitud.Reaseguradora = nuevaRease.ID;
                    if (idReaseguradora != 0)
                    {
                        nuevaSolicitud.NombreReaseguradora = txtReaseguradora.Text;
                        nuevaSolicitud.Codigo = txtCodigoReaseguradora.Text;
                        nuevaSolicitud.RI_Policy = txtRIPolicy.Text;
                        nuevaSolicitud.Fijo_Interno = Convert.ToDecimal(txtFijoInterno.Value);
                        nuevaSolicitud.Comision = Convert.ToDecimal(txtComision.Value);
                        nuevaSolicitud.Treaty = chkTreaty.Checked;
                        nuevaSolicitud.GrupoFinanzas = txtGrupoFinanzas.Text;
                        nuevaSolicitud.DefectoLI = chkLiability.Checked;
                        nuevaSolicitud.DefectoMA = chkMarine.Checked;
                        nuevaSolicitud.DefectoPR = chkProperty.Checked;
                        nuevaSolicitud.DefectoFL = chkFL.Checked;
                    }
                    nuevaSolicitud.Status = (from y in db.StatusFacturacions where y.Status == "Solicitado" select y.ID).SingleOrDefault();
                    db.ReaseguradorasSolicitudes.InsertOnSubmit(nuevaSolicitud);
                    db.SubmitChanges();
                    MessageBox.Show("Registro añadido", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    MainReaseguradoras.idReaseguradora = nuevaRease.ID;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
