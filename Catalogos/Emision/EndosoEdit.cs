using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace SmartG.Catalogos.Emision
{
    public partial class EndosoEdit : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // nombres y valores de todos los objetos que se encuentran en el formulario
        #region Coleccion objetos
        //lbNombreEndoso       Nombre Endoso:
        //txtNombreEndoso
        //lbLineaNegocios       Linea Negocios:
        //cbLineaNegocios
        //lbOrigen      Origen:
        //cbOrigen
        //lbAnexo       Anexo:
        //cbAnexo
        //chkDefault        Por defecto
        //lbTexto       Texto ingresado:
        //txtStatus
        //btnIngresarTexto      Ingresar Texto
        //btnConsultarTexto     Ver Texto
        //btnGuardar        Guardar
        //btnCancelar       Cancelar
        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form
        #region Variables
        int tipoVentana = 0;
        public static string txtGuardar = "";
        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region Metodos Programados

        private void activarAnexo(object sender, EventArgs e)
        {
            if (cbLineaNegocios.Text != "" && cbOrigen.Text != "")
            {
                if (cbLineaNegocios.Text == "Property" && cbOrigen.Text == "Producing")
                {
                    lbAnexo.Visible = true;
                    cbAnexo.Visible = true;
                }
                else
                {
                    lbAnexo.Visible = false;
                    cbAnexo.Visible = false;
                }

                liIncCoberturasDBTableAdapter.FillByTodosDB(this.liabilityInc.LiIncCoberturasDB,Convert.ToInt32(cbLineaNegocios.Value), Convert.ToInt32(cbOrigen.Value));
            }
            else
            {
                cbCoberturas.Text = "";
                cbCoberturas.Items.Clear();
            }
        }

        private void validarCB(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            Infragistics.Win.UltraWinEditors.UltraComboEditor cb = (Infragistics.Win.UltraWinEditors.UltraComboEditor)sender;

            if (cb.Items.Count > 0)
            {
                
            }
            else
            {
                e.RetainFocus = false;
                cb.Text = "";
            }
        }

        bool validarDatos()
        {
            if (txtNombreEndoso.Text == "") { MessageBox.Show("Error: debes de asignar un nombre para el endoso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (cbLineaNegocios.Text == "") { MessageBox.Show("Error: debes de asignar una linea de negocios para el endoso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (cbOrigen.Text == "") { MessageBox.Show("Error: debes de asignar un origen para el endoso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtStatus.BackColor == Color.Red) { MessageBox.Show("Error: debes de asignar un texto para el endoso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (lbAnexo.Visible && cbAnexo.Text == "") { MessageBox.Show("Error: debes de asignar un anexo para el endoso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtGuardar == "" || txtGuardar == " " ) { MessageBox.Show("Error: ocurrió un error al ingresar el texto, por favor vuelvalo a intentar, si ya ingresaste el texto intenga dar click en el botón de ingresar texto y usa CTRL + V para pegar, si no ingresa texto entonces realiza el ingreso manualmente. Si el problema persiste contacta con el soporte técnico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            return true;
        }


        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region eventos Form

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas cancelar el proceso? los cambios no se guardarán", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnConsultarTexto_Click(object sender, EventArgs e)
        {
            if (txtGuardar != "")
            {
                try
                {
                    Clipboard.SetText(txtGuardar, TextDataFormat.Rtf);
                }
                catch
                {
                    Clipboard.SetText(txtGuardar, TextDataFormat.Text);
                }
                Operaciones.Emision.visorTextoRTF frmVisor = new Operaciones.Emision.visorTextoRTF();
                frmVisor.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay texto a mostrar, utiliza el boton de Ingresar Texto para poder usar esta función", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                if (MessageBox.Show("¿Deseas guardar los cambios?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dbSmartGDataContext db = new dbSmartGDataContext();
                    EndosoEmision endosoTmp;
                    int? idCobertura = null;
                    if (tipoVentana == 0) // nuevo endoso
                        endosoTmp = new EndosoEmision();
                    else
                        endosoTmp = (from x in db.EndosoEmision where x.ID == tipoVentana select x).SingleOrDefault();
                    endosoTmp.Endoso = txtNombreEndoso.Text;
                    endosoTmp.LineaNegocios = Convert.ToInt32(cbLineaNegocios.Value);
                    endosoTmp.Origen = Convert.ToInt32(cbOrigen.Value);
                    if (cbCoberturas.Text != "")
                        endosoTmp.Cobertura = Convert.ToInt32(cbCoberturas.Value);
                    else
                        endosoTmp.Cobertura = idCobertura;
                    if (chkDefault.Checked)
                        endosoTmp.Defecto = true;
                    else
                        endosoTmp.Defecto = false;
                    endosoTmp.EndosoTXT = txtGuardar;
                    endosoTmp.Eliminado = false;
                    if (cbAnexo.Visible)
                        endosoTmp.Anexo = Convert.ToInt32(cbAnexo.Text);
                    if (tipoVentana == 0) // nuevo endoso
                        db.EndosoEmision.InsertOnSubmit(endosoTmp);
                    db.SubmitChanges();
                    MessageBox.Show("Endoso Guardado Satisfactoriamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnIngresarTexto_Click(object sender, EventArgs e)
        {
            Process execute = new Process();
            execute.StartInfo.FileName = System.AppDomain.CurrentDomain.BaseDirectory + @"\WpfRichTextEditor.exe";
            execute.EnableRaisingEvents = true;
            execute.Exited += Execute_Exited;
            execute.Start();
            execute.WaitForExit();
        }

        public EndosoEdit(int tipo = 0)
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);

            if (tipo != 0)
                tipoVentana = tipo;
        }

        private void EndosoEdit_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this);
            origenTableAdapter.Fill(this.liabilityInc.Origen);
            lineaNegociosTableAdapter.Fill(this.liabilityInc.LineaNegocios);

            if (tipoVentana != 0)
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                EndosoEmision endosoTmp = (from x in db.EndosoEmision where x.ID == tipoVentana select x).SingleOrDefault();
                if (endosoTmp != null)
                {
                    txtNombreEndoso.Text = endosoTmp.Endoso;
                    cbLineaNegocios.Value = endosoTmp.LineaNegocios;
                    cbOrigen.Value = endosoTmp.Origen;
                    if (Convert.ToBoolean(endosoTmp.Defecto))
                        chkDefault.Checked = true;
                    if (endosoTmp.EndosoTXT != null || endosoTmp.EndosoTXT != "" || endosoTmp.EndosoTXT != " ")
                    {
                        txtStatus.BackColor = Color.Lime;
                        txtGuardar = endosoTmp.EndosoTXT;
                    }
                    else
                    {
                        txtStatus.BackColor = Color.Red;
                        txtGuardar = "";
                    }
                    if (cbAnexo.Visible)
                        cbAnexo.Text = endosoTmp.Anexo.ToString();
                    cbCoberturas.Value = endosoTmp.Cobertura;
                }
            }
            else
                txtStatus.BackColor = Color.Red;
        }

        private void Execute_Exited(object sender, EventArgs e)
        {
            Process proceso = (Process)sender;
            if (proceso.ExitCode != 0)
            {
                string clipboardGetData = "";
                try
                {
                    clipboardGetData = (string)Clipboard.GetData(DataFormats.Rtf);
                }
                catch
                {
                    clipboardGetData = (string)Clipboard.GetData(DataFormats.Text);
                }

                if (clipboardGetData != "" || clipboardGetData != "" || clipboardGetData != " ")
                {
                    if (txtStatus.BackColor == Color.Red)
                    {
                        txtGuardar = clipboardGetData;
                        MessageBox.Show("Datos ingresados correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtStatus.BackColor = Color.Lime;
                    }
                    else
                    {
                        if (MessageBox.Show("¿Deseas actualizar con el nuevo texto ingresado? todo texto antes de esto se eliminará", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            txtGuardar = clipboardGetData;
                            MessageBox.Show("Datos ingresados correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                else
                    txtStatus.BackColor = Color.Red;
            }
        }




        #endregion

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cbCoberturas.Text = "";
        }
    }
}
