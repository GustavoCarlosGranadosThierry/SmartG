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
    public partial class VisorSolicitudesUsuario : Form
    {
        int IDSol;

        void NuevoComentario()
        {
            string vDef = "";
            Extensiones.Edicion.InputBox("Nuevo Comentario", "Ingrese una descripción del Comentario de seguimiento", ref vDef);
            if (vDef == "")
            {
                MessageBox.Show("Ingrese una comentario valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dbSmartGDataContext db = new dbSmartGDataContext();
            ClientesSolicitudSeguimiento clientesSolicitudNuevo = new ClientesSolicitudSeguimiento();
            clientesSolicitudNuevo.ClienteSolicitud = IDSol;
            clientesSolicitudNuevo.Comentario = vDef;
            clientesSolicitudNuevo.UsuarioLevantamiento = Program.Globals.UserID;
            clientesSolicitudNuevo.FechaLevantamiento = DateTime.Now;
            db.ClientesSolicitudSeguimientos.InsertOnSubmit(clientesSolicitudNuevo);
            db.SubmitChanges();
            CargarDataSets();
        }

        void DescargarDocumentos()
        {
            //fix
        }

        void CargarDataSets()
        {
            this.clientesSolicitudSeguimientoTableAdapter.FillByID(this.catalogosGral.ClientesSolicitudSeguimiento, IDSol);
        }

        public VisorSolicitudesUsuario(int IDSolicitud)
        {
            IDSol = IDSolicitud;
            InitializeComponent();
        }

        private void VisorSolicitudesUsuario_Load(object sender, EventArgs e)
        {
            CargarDataSets();
        }

        private void ToolbarsManagerConsultasAML_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btnNuevoComentario":
                    break;

                case "btnDescargarDocumentos":
                    break;

                case "btnActualizar":
                    CargarDataSets();
                    break;

            }

        }
    }
}
