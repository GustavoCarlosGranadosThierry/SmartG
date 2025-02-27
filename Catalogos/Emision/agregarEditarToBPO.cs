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
    public partial class agregarEditarToBPO : Form
    {
        public int idElemento = 0;
        public int tipoElemento = 0;

        public agregarEditarToBPO()
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
        }

        private void agregarEditarToBPO_Load(object sender, EventArgs e)
        {
            if (tipoElemento == 1)
                lbTOBPO.Text = "Producing Office";
            else
                lbTOBPO.Text = "ToB";

            if(idElemento != 0)
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                if (tipoElemento == 1)
                    txtTOBPO.Text = (from x in db.ProducingOffice where x.ID == idElemento select x.ProducingOffice1).SingleOrDefault();
                else
                    txtTOBPO.Text = (from x in db.ToB where x.ID == idElemento select x.ToB1).SingleOrDefault();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtTOBPO.Text != "")
            {
                dbSmartGDataContext db = new dbSmartGDataContext();

                if (tipoElemento == 1)
                {
                    ProducingOffice tmpPO = (from x in db.ProducingOffice where x.ProducingOffice1.ToUpper() == txtTOBPO.Text.ToUpper() select x).SingleOrDefault();
                    if (tmpPO == null)
                    {
                        if (idElemento == 0)
                            tmpPO = new ProducingOffice();
                        else
                            tmpPO = (from x in db.ProducingOffice where x.ID == idElemento select x).SingleOrDefault();
                        tmpPO.ProducingOffice1 = txtTOBPO.Text;
                        tmpPO.Eliminado = false;
                        if (idElemento == 0)
                            db.ProducingOffice.InsertOnSubmit(tmpPO);
                        db.SubmitChanges();
                        MessageBox.Show("Registro añadido", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El Producing Office que quieres agregar ya se encuentra en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    ToB tmpTOB = (from x in db.ToB where x.ToB1.ToUpper() == txtTOBPO.Text.ToUpper() select x).FirstOrDefault();
                    if (tmpTOB == null)
                    {
                        if (idElemento == 0)
                            tmpTOB = new ToB();
                        else
                            tmpTOB = (from x in db.ToB where x.ID == idElemento select x).SingleOrDefault();
                        tmpTOB.ToB1 = txtTOBPO.Text;
                        tmpTOB.Eliminado = false;
                        if (idElemento == 0)
                            db.ToB.InsertOnSubmit(tmpTOB);
                        db.SubmitChanges();
                        MessageBox.Show("Registro añadido", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El ToB que quieres agregar ya se encuentra en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
