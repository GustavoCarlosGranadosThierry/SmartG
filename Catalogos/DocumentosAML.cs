using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Catalogos
{
    public partial class DocumentosAML : Form
    {
        int IDCliente;
        int IDClienteSolicitud;

        void CargarDataSets()
        {
            dsDocumentos.Rows.Clear();
            dbSmartGDataContext db = new dbSmartGDataContext();
            int TipoCliente = Convert.ToInt32((from x in db.Clientes where x.ID == IDCliente select x.TipoCliente).SingleOrDefault());
            string RFC = (from x in db.Clientes where x.ID == IDCliente select x.RFC).SingleOrDefault();
            bool Extranjero = false;
            if (RFC == "XEXX010101000") Extranjero = true;

            TipoDocumentosAML[] DocAplicables = (from x in db.TipoDocumentosAMLs where x.TipoCliente == TipoCliente && x.Extranjero == Extranjero select x).ToArray();

            for (int i = 0; i < DocAplicables.Count(); i++)
            {
                int IDTipoDocumento = DocAplicables[i].ID;
                SmartG.DocumentosAML[] DocsSubidos = (from x in db.DocumentosAMLs where x.Cliente == IDCliente && x.TipoDocumento == IDTipoDocumento select x).ToArray();
                if(DocsSubidos.Count() > 0)
                {
                    for (int j = 0; j < DocsSubidos.Count(); j++)
                    {
                        dsDocumentos.Rows.Add(new object[] { DocAplicables[i].ID, DocAplicables[i].NombreDocumento, DocsSubidos[j].ID, DocsSubidos[j].NombreFile, DocsSubidos[j].Usuario.UserName, DocsSubidos[j].FechaActivacion, DocsSubidos[j].Activo });
                    }
                }
                else
                {
                    dsDocumentos.Rows.Add(new object[] { DocAplicables[i].ID, DocAplicables[i].NombreDocumento });
                }
            }
        }

        Byte[] ConvertirAbytes(string FilePath)
        {
            Stream fs = File.Open(FilePath, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            return bytes;
        }

        void MensajeDocumentoSubido(string TipoDocumento, bool isBorrar = false)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            ClientesSolicitudSeguimiento clientesSolicitudSeguimientoNuevo = new ClientesSolicitudSeguimiento();
            clientesSolicitudSeguimientoNuevo.ClienteSolicitud = IDClienteSolicitud;

            if(!isBorrar)
                clientesSolicitudSeguimientoNuevo.Comentario = "Subido Nuevo Documento: " + TipoDocumento;
            else
                clientesSolicitudSeguimientoNuevo.Comentario = "Borrado documento: " + TipoDocumento;

            clientesSolicitudSeguimientoNuevo.UsuarioLevantamiento = Program.Globals.UserID;
            clientesSolicitudSeguimientoNuevo.FechaLevantamiento = DateTime.Now;
            db.ClientesSolicitudSeguimientos.InsertOnSubmit(clientesSolicitudSeguimientoNuevo);
            db.SubmitChanges();
        }

        void SubirDocumento()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            int IDTipoDocumento = Convert.ToInt32(dgDocumentos.ActiveRow.Cells["IDTipoDocumento"].Value);
            int IDDocumentoAML = 0; if(dgDocumentos.ActiveRow.Cells["IDDocumentoAML"].Text != "") IDDocumentoAML = Convert.ToInt32(dgDocumentos.ActiveRow.Cells["IDDocumentoAML"].Value);
            bool Activo = Convert.ToBoolean(dgDocumentos.ActiveRow.Cells["Activo"].Value);
            bool FechaActivo = false;  DateTime DTActivacion;
            if (DateTime.TryParse(dgDocumentos.ActiveRow.Cells["FechaActivación"].Text, out DTActivacion)) FechaActivo = true;
            bool ClienteActivado = Convert.ToBoolean((from x in db.Clientes where x.ID == IDCliente select x.Aprobado).SingleOrDefault());

            int CasoAplicable = 0;
            if (IDDocumentoAML == 0 && Activo == false && FechaActivo == false) CasoAplicable = 1;  // No hay docs
            if (IDDocumentoAML > 0 && Activo == false && FechaActivo == false) CasoAplicable = 2; // No autorizado
            if (IDDocumentoAML > 0 && Activo == true && FechaActivo == true) CasoAplicable = 3; // Doc Activo
            if (IDDocumentoAML > 0 && Activo == false && FechaActivo == true) CasoAplicable = 4; // Doc Historico
            if (CasoAplicable == 1 && ClienteActivado == true) CasoAplicable = 5; //Documento nuevo en un cliente ya aprobado
            switch (CasoAplicable)
            {
                case 1:
                    if (openFileDialog1.ShowDialog() != DialogResult.Yes)
                    {
                        SmartG.DocumentosAML nuevoDoc = new SmartG.DocumentosAML();
                        nuevoDoc.Cliente = IDCliente;
                        nuevoDoc.TipoDocumento = IDTipoDocumento;
                        nuevoDoc.NombreFile = openFileDialog1.SafeFileName;
                        nuevoDoc.UsuarioSubida = Program.Globals.UserID;
                        nuevoDoc.Activo = false;
                        nuevoDoc.DataFile = ConvertirAbytes(openFileDialog1.FileName);
                        db.DocumentosAMLs.InsertOnSubmit(nuevoDoc);
                        db.SubmitChanges();
                        MessageBox.Show("Documento agregado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        MensajeDocumentoSubido(nuevoDoc.TipoDocumentosAML.NombreDocumento);
                        CargarDataSets();
                    }
                    break;

                case 2:
                    if(MessageBox.Show("Se borrara el archivo anterior no autorizado, continuar?","Mensaje",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (openFileDialog1.ShowDialog() != DialogResult.Yes)
                        {
                            // borra el archivo viejo
                            SmartG.DocumentosAML borrarDoc = (from x in db.DocumentosAMLs where x.ID == IDDocumentoAML select x).SingleOrDefault();
                            db.DocumentosAMLs.DeleteOnSubmit(borrarDoc);
                            db.SubmitChanges();

                            SmartG.DocumentosAML nuevoDoc = new SmartG.DocumentosAML();
                            nuevoDoc.Cliente = IDCliente;
                            nuevoDoc.TipoDocumento = IDTipoDocumento;
                            nuevoDoc.NombreFile = openFileDialog1.SafeFileName;
                            nuevoDoc.UsuarioSubida = Program.Globals.UserID;
                            nuevoDoc.Activo = false;
                            nuevoDoc.DataFile = ConvertirAbytes(openFileDialog1.FileName);
                            db.DocumentosAMLs.InsertOnSubmit(nuevoDoc);
                            db.SubmitChanges();
                            MensajeDocumentoSubido(nuevoDoc.TipoDocumentosAML.NombreDocumento);
                            MessageBox.Show("Documento agregado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            CargarDataSets();
                        }
                    }
                    break;

                case 3:
                    if (MessageBox.Show("El documento autorizado previo sera actualizado y guardado como historico no activado, continuar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (openFileDialog1.ShowDialog() != DialogResult.Yes)
                        {
                            // actualiza el archivo viejo
                            SmartG.DocumentosAML actualizarDoc = (from x in db.DocumentosAMLs where x.ID == IDDocumentoAML select x).SingleOrDefault();
                            actualizarDoc.Activo = false;
                            db.SubmitChanges();

                            SmartG.DocumentosAML nuevoDoc = new SmartG.DocumentosAML();
                            nuevoDoc.Cliente = IDCliente;
                            nuevoDoc.TipoDocumento = IDTipoDocumento;
                            nuevoDoc.NombreFile = openFileDialog1.SafeFileName;
                            nuevoDoc.UsuarioSubida = Program.Globals.UserID;
                            nuevoDoc.FechaActivacion = DateTime.Now;
                            nuevoDoc.Activo = true;
                            nuevoDoc.DataFile = ConvertirAbytes(openFileDialog1.FileName);
                            db.DocumentosAMLs.InsertOnSubmit(nuevoDoc);
                            db.SubmitChanges();
                            MensajeDocumentoSubido(nuevoDoc.TipoDocumentosAML.NombreDocumento);
                            MessageBox.Show("Documento agregado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            CargarDataSets();
                        }
                    }
                    break;

                case 4:
                    MessageBox.Show("Este documento historico no puede ser modificado, si desea ingresar un nuevo documento, actualizar el vigente",
                        "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    break;

                case 5:
                    if (openFileDialog1.ShowDialog() != DialogResult.Yes)
                    {
                        SmartG.DocumentosAML nuevoDoc = new SmartG.DocumentosAML();
                        nuevoDoc.Cliente = IDCliente;
                        nuevoDoc.TipoDocumento = IDTipoDocumento;
                        nuevoDoc.NombreFile = openFileDialog1.SafeFileName;
                        nuevoDoc.UsuarioSubida = Program.Globals.UserID;
                        nuevoDoc.Activo = true;
                        nuevoDoc.FechaActivacion = DateTime.Now;
                        nuevoDoc.DataFile = ConvertirAbytes(openFileDialog1.FileName);
                        db.DocumentosAMLs.InsertOnSubmit(nuevoDoc);
                        db.SubmitChanges();
                        MensajeDocumentoSubido(nuevoDoc.TipoDocumentosAML.NombreDocumento);
                        MessageBox.Show("Documento agregado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        CargarDataSets();
                    }
                    break;

                case 0: //default
                    MessageBox.Show("Ocurrio un error no controlado, favor de contactar con soporte","Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        void BorrarDocumentos()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            int IDTipoDocumento = Convert.ToInt32(dgDocumentos.ActiveRow.Cells["IDTipoDocumento"].Value);
            int IDDocumentoAML = 0; if (dgDocumentos.ActiveRow.Cells["IDDocumentoAML"].Text != "") IDDocumentoAML= Convert.ToInt32(dgDocumentos.ActiveRow.Cells["IDDocumentoAML"].Value);
            bool Activo = Convert.ToBoolean(dgDocumentos.ActiveRow.Cells["Activo"].Value);
            bool FechaActivo = false; DateTime DTActivacion;
            if (DateTime.TryParse(dgDocumentos.ActiveRow.Cells["FechaActivación"].Text, out DTActivacion)) FechaActivo = true;
            bool ClienteActivado = Convert.ToBoolean((from x in db.Clientes where x.ID == IDCliente select x.Aprobado).SingleOrDefault());

            int CasoAplicable = 0;

            if (IDDocumentoAML == 0 && Activo == false && FechaActivo == false) CasoAplicable = 1;  // No hay docs
            if (IDDocumentoAML > 0 && Activo == false && FechaActivo == false) CasoAplicable = 2; // No autorizado
            if (IDDocumentoAML > 0 && Activo == true && FechaActivo == true) CasoAplicable = 3; // Doc Activo
            if (IDDocumentoAML > 0 && Activo == false && FechaActivo == true) CasoAplicable = 4; // Doc Historico
            if (CasoAplicable == 1 && ClienteActivado == true) CasoAplicable = 5; //Documento nuevo en un cliente ya aprobado

            switch (CasoAplicable)
            {
                case 2:
                    if (MessageBox.Show("Se borrara el archivo no autorizado, continuar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // borra el archivo viejo
                        SmartG.DocumentosAML borrarDoc = (from x in db.DocumentosAMLs where x.ID == IDDocumentoAML select x).SingleOrDefault();
                        db.DocumentosAMLs.DeleteOnSubmit(borrarDoc);
                        db.SubmitChanges();
                        MessageBox.Show("Documento borrado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        MensajeDocumentoSubido(borrarDoc.TipoDocumentosAML.NombreDocumento, true);

                        CargarDataSets();
                    }
                    break;

                case 1:
                case 3:
                case 4:
                case 5:
                    MessageBox.Show("Este archivo no puede ser borrado debido a su estatus", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 0: //default
                    MessageBox.Show("Ocurrio un error no controlado, favor de contactar con soporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        void DescargarDocs(bool SoloActivos)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            saveFileDialog1.FileName = (from x in db.Clientes where x.ID == IDCliente select x.RFC).SingleOrDefault() + "_AML_" + DateTime.Now.ToShortDateString().Replace("/","");
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Directory.CreateDirectory(@"C:\SmartG\temp");
                SmartG.DocumentosAML[] DocsBajar;
                if(SoloActivos)
                    DocsBajar = (from x in db.DocumentosAMLs where x.Cliente == IDCliente && x.Activo == true select x).ToArray();
                else
                    DocsBajar = (from x in db.DocumentosAMLs where x.Cliente == IDCliente select x).ToArray();

                if (DocsBajar.Count() > 0)
                {
                    for (int i = 0; i < DocsBajar.Count(); i++)
                    {
                        Byte[] bytData = DocsBajar[i].DataFile.ToArray();
                        if (bytData != null)
                            using (FileStream fs = new FileStream(@"C:\SmartG\temp\" + DocsBajar[i].NombreFile, FileMode.OpenOrCreate, FileAccess.Write))
                            {
                                BinaryWriter br = new BinaryWriter(fs);
                                br.Write(bytData);
                                fs.Dispose();
                            }
                    }
                    if (File.Exists(saveFileDialog1.FileName)) File.Delete(saveFileDialog1.FileName);
                    ZipFile.CreateFromDirectory(@"C:\SmartG\temp", saveFileDialog1.FileName);

                    // Borra la carperta
                    System.IO.DirectoryInfo di = new DirectoryInfo(@"C:\SmartG\temp");

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                    Process.Start(saveFileDialog1.FileName);
                }
                else
                {
                    MessageBox.Show("No existen documentos activos en la base de datos para este cliente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public DocumentosAML(int idcliente, int idClienteSolicitud)
        {
            InitializeComponent();
            IDCliente = idcliente;
            IDClienteSolicitud = idClienteSolicitud;
        }

        private void DocumentosAML_Load(object sender, EventArgs e)
        {
            CargarDataSets();
        }

        private void ToolbarsManagerDocumentosAML_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btnDescargarTodos":
                    DescargarDocs(false);
                    break;

                case "btnDescargarDocumentosActivos":
                    DescargarDocs(true);
                    break;

                case "btnActualizar":
                    CargarDataSets();
                    break;
            }
        }

        private void dgDocumentos_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell.Text == "Actualizar")
                SubirDocumento();
            else
                BorrarDocumentos();

        }

        private void ultraDataSource1_CellDataRequested(object sender, Infragistics.Win.UltraWinDataSource.CellDataRequestedEventArgs e)
        {

        }

        private void dgDocumentos_ClickCellButton_1(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell.Column.Key == "Actualizar")
                SubirDocumento();
            else if (e.Cell.Column.Key == "Borrar")
                BorrarDocumentos();
        }
    }
}
