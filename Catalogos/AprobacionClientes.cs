using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SmartG.Catalogos
{
    public partial class AprobacionClientes : Form
    {
        int IDCliente = 0;
        int IDsolicitud = 0;
        int IDPaisMexico;

        void CargarDataSets()
        {
            this.clientesSolicitudTableAdapter.Fill(this.catalogosGral.ClientesSolicitud);
            this.clientesDireccionesTableAdapter.FillByCliente(this.catalogosGral.ClientesDirecciones, 0);
            this.paisTableAdapter.Fill(this.catalogosGral.Pais);
            this.tipoClienteTableAdapter.Fill(this.catalogosGral.TipoCliente);
        }

        void CambiarLayout(int modo, bool borrarIds = true)
        {
            // 0 - inicial todo oculto
            // 1 - Nuevo cliente
            // 2 - Cliente existente

            CargarDataSets();
            if (borrarIds)
            {
                IDCliente = 0;
                IDsolicitud = 0;
            }
            ToolbarsManagerAprobacionClientes.Ribbon.Tabs[0].Groups["rgbCliente"].Visible = false;
            ToolbarsManagerAprobacionClientes.Ribbon.Tabs[0].Groups["rgbDocumentos"].Visible = false;
            tabAprobacionClientes.Visible = false;
            tabAprobacionClientes.Tabs[0].Visible = false;
            tabAprobacionClientes.Tabs[1].Visible = false;
            tabAprobacionClientes.Tabs[2].Visible = false;


            switch (modo)
            {
                case 0:
                    tabAprobacionClientes.Visible = true;
                    tabAprobacionClientes.Tabs[0].Visible = true;
                    LimpiarFormularios();
                    break;

                case 1:
                    ToolbarsManagerAprobacionClientes.Ribbon.Tabs[0].Groups["rgbCliente"].Visible = true;
                    ToolbarsManagerAprobacionClientes.Ribbon.Tabs[0].Groups["rgbDocumentos"].Visible = true;
                    tabAprobacionClientes.Visible = true; ;
                    tabAprobacionClientes.Tabs[1].Visible = true;
                    ToolbarsManagerAprobacionClientes.Tools["btnAceptarSolicitud"].SharedProps.Enabled = false;
                    ToolbarsManagerAprobacionClientes.Tools["btnRechazar"].SharedProps.Enabled = false;
                    break;

                case 2:
                    ToolbarsManagerAprobacionClientes.Ribbon.Tabs[0].Groups["rgbCliente"].Visible = true;
                    ToolbarsManagerAprobacionClientes.Ribbon.Tabs[0].Groups["rgbDocumentos"].Visible = true;
                    tabAprobacionClientes.Visible = true; ;
                    tabAprobacionClientes.Tabs[2].Visible = true;
                    ToolbarsManagerAprobacionClientes.Tools["btnAceptarSolicitud"].SharedProps.Enabled = false;
                    ToolbarsManagerAprobacionClientes.Tools["btnRechazar"].SharedProps.Enabled = false;
                    break;
            }
        }

        void LimpiarFormularios()
        {
            // Editar Cliente
            cbNacionalidad.Text = "México";
            cbTipoCliente.Text = "Persona Moral";
            txNombre.Text = "";
            txtApellidoP.Text = "";
            txtApellidoM.Text = "";
            txtRazonSocial.Text = "";
            txtRfc.Text = "";
            txtNameCode.Text = "";
            txtGiro.Text = "";
            txtFiel.Text = "";
            txtEmail.Text = "";
            txtCurp.Text = "";
            this.clientesDireccionesTableAdapter.FillByCliente(this.catalogosGral.ClientesDirecciones, 0);

            cbTipoMod.Appearance.BackColor = Color.White;
            txtNombreMod.Appearance.BackColor = Color.White;
            txtApellidoPMod.Appearance.BackColor = Color.White;
            txtApellidoMMod.Appearance.BackColor = Color.White;
            txtRazonSocialMod.Appearance.BackColor = Color.White;
            txtRfcMod.Appearance.BackColor = Color.White;
            txtGiroMod.Appearance.BackColor = Color.White;
            txtCurpMod.Appearance.BackColor = Color.White;
            txtFielMod.Appearance.BackColor = Color.White;
            txtTelefonoMod.Appearance.BackColor = Color.White;
            txtEmailMod.Appearance.BackColor = Color.White;
            txtNameCodeMod.Appearance.BackColor = Color.White;

        }

        bool ValidarDatos(bool VerificacionModificacion)
        {
            if (cbTipoCliente.Text == "Persona Moral")
            {
                if (txtRazonSocial.Text == "")
                {
                    MessageBox.Show("Error: Datos incompletos: razon social faltante, completar los datos minimos");
                    return false;
                }
            }
            else
            {
                if (txNombre.Text == "" || txtApellidoP.Text == "" || txtApellidoM.Text == "")
                {
                    MessageBox.Show("Error: Datos incompletos: nombre faltante, completar los datos minimos");
                    return false;
                }
            }
            if (txtRfc.Text == "" || txtGiro.Text == "")
            {
                MessageBox.Show("Error: Datos incompletos, completar los datos minimos");
                return false;
            }

            if (chkExtranjero.Checked && txtFiel.Text == "")
            {
                MessageBox.Show("No se ha expecificado un Documento de identificación extranjero para este cliente, agregar esta información", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            dbSmartGDataContext db = new dbSmartGDataContext();
            if (VerificacionModificacion)
            {
                if (dgDirecciones.Rows.Count == 0)
                {
                    MessageBox.Show("No se han agregado direcciones validas para este cliente, agregar esta información", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!validarRFC(txtRfc.Value.ToString()))
                {
                    MessageBox.Show("RFC Invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if ((from x in db.Clientes where x.NameCode == txtNameCode.Text select x).ToArray().Count() > 0)
                {
                    MessageBox.Show("Error: El NameCode ya ha sido dado de alta anteriormente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        bool validarRFC(string rfc)
        {
            if (cbTipoCliente.Text == "Persona Moral")
            {
                //Valida primera sección (3 caracteres sean letras)
                bool v1 = rfc.Substring(0, 3).All(Char.IsLetter);
                if (v1 == false)
                {
                    v1 = rfc.Substring(0, 3).All(char.IsNumber);
                    if (v1)
                        return false;
                }

                //Valida segunda sección (6 caracteres solo numeros)
                try
                {
                    //012345678901
                    //CAF870923AF5
                    int sec_total = int.Parse(rfc.Substring(3, 6));
                    int sec1 = int.Parse(rfc.Substring(3, 2));
                    int sec2 = int.Parse(rfc.Substring(5, 2));
                    int sec3 = int.Parse(rfc.Substring(7, 2));

                    if (sec2 > 12) { return false; } // Valida el mes
                    if (sec3 > 31) { return false; } // Valida el dia
                }
                catch { return false; }

                // Salida si todas las validaciones fueron cumplidas
                return true;
            }
            else
            {
                //Valida primera sección (4 caracteres sean letras)
                bool v1 = rfc.Substring(0, 4).All(Char.IsLetter);
                if (v1 == false) { return false; }

                //Valida segunda sección (6 caracteres solo numeros)
                try
                {
                    //0123456789012
                    //CADF870923AF5
                    int sec_total = int.Parse(rfc.Substring(4, 6));
                    int sec1 = int.Parse(rfc.Substring(4, 2));
                    int sec2 = int.Parse(rfc.Substring(6, 2));
                    int sec3 = int.Parse(rfc.Substring(8, 2));

                    if (sec2 > 12) { return false; } //Valida el mes
                    if (sec3 > 31) { return false; } //Valida el dia
                }
                catch { return false; }

                // Salida si todas las validaciones fueron cumplidas
                return true;
            }
        }

        void CargarNuevoCliente()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            Cliente clienteRecuperado = (from x in db.Clientes where x.ID == IDCliente select x).SingleOrDefault();
            cbTipoCliente.Value = clienteRecuperado.TipoCliente;
            txNombre.Text = clienteRecuperado.Nombre;
            txtApellidoP.Text = clienteRecuperado.ApellidoPaterno;
            txtApellidoM.Text = clienteRecuperado.ApellidoMaterno;
            txtRazonSocial.Text = clienteRecuperado.RazonSocial;
            txtRfc.Text = clienteRecuperado.RFC;
            txtGiro.Text = clienteRecuperado.GiroEmpresarial;
            txtCurp.Text = clienteRecuperado.CURP;
            txtFiel.Text = clienteRecuperado.FIEL;
            txtTelefono.Text = clienteRecuperado.Telefono;
            txtEmail.Text = clienteRecuperado.Email;
            txtNameCode.Text = clienteRecuperado.NameCode;
            chkNameCodePrincipal.Checked = Convert.ToBoolean(clienteRecuperado.NameCodePrincipal);
            cbNacionalidad.Value = (from x in db.ClientesDirecciones where x.Cliente == clienteRecuperado.ID select x.Pais).FirstOrDefault();
            this.clientesDireccionesTableAdapter.FillByCliente(this.catalogosGral.ClientesDirecciones, IDCliente);
        }

        void CargarClienteModificado()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            // Datos Originales
            Cliente clienteRecuperado = (from x in db.Clientes where x.ID == IDCliente select x).SingleOrDefault();
            cbTipoOri.Value = clienteRecuperado.TipoCliente;
            txtNombreOri.Text = clienteRecuperado.Nombre;
            txtApellidoPOri.Text = clienteRecuperado.ApellidoPaterno;
            txtApellidoMOri.Text = clienteRecuperado.ApellidoMaterno;
            txtRazonSocialOri.Text = clienteRecuperado.RazonSocial;
            txtRfcOri.Text = clienteRecuperado.RFC;
            txtGiroOri.Text = clienteRecuperado.GiroEmpresarial;
            txtCurpOri.Text = clienteRecuperado.CURP;
            txtFielOri.Text = clienteRecuperado.FIEL;
            txtTelefonoOri.Text = clienteRecuperado.Telefono;
            txtEmailOri.Text = clienteRecuperado.Email;
            txtNameCodeOri.Text = clienteRecuperado.NameCode;
            chkNameCodePrincipalOri.Checked = Convert.ToBoolean(clienteRecuperado.NameCodePrincipal);

            // Datos MOdificados
            ClientesSolicitud clienteModificado = (from x in db.ClientesSolicituds where x.ID == IDsolicitud select x).SingleOrDefault();
            cbTipoMod.Value = clienteModificado.TipoCliente;
            txtNombreMod.Text = clienteModificado.Nombre;
            txtApellidoPMod.Text = clienteModificado.ApellidoPaterno;
            txtApellidoMMod.Text = clienteModificado.ApellidoMaterno;
            txtRazonSocialMod.Text = clienteModificado.RazonSocial;
            txtRfcMod.Text = clienteModificado.RFC;
            txtGiroMod.Text = clienteModificado.GiroEmpresarial;
            txtCurpMod.Text = clienteModificado.CURP;
            txtFielMod.Text = clienteModificado.FIEL;
            txtTelefonoMod.Text = clienteModificado.Telefono;
            txtEmailMod.Text = clienteModificado.Email;
            txtNameCodeMod.Text = clienteModificado.NameCode;
            chkNameCodePrincipalOri.Checked = chkNameCodePrincipalOri.Checked;

            // Compara
            if (cbTipoOri.Value != cbTipoMod.Value) cbTipoMod.Appearance.BackColor = Color.Gold;
            if (txtNombreOri.Text != txtNombreMod.Text) txtNombreMod.Appearance.BackColor = Color.Gold;
            if (txtApellidoPOri.Text != txtApellidoPMod.Text) txtApellidoPMod.Appearance.BackColor = Color.Gold;
            if (txtApellidoMOri.Text != txtApellidoMMod.Text) txtApellidoMMod.Appearance.BackColor = Color.Gold;
            if (txtRazonSocialOri.Text != txtRazonSocialMod.Text) txtRazonSocialMod.Appearance.BackColor = Color.Gold;
            if (txtRfcOri.Text != txtRfcMod.Text) txtRfcMod.Appearance.BackColor = Color.Gold;
            if (txtGiroOri.Text != txtGiroMod.Text) txtGiroMod.Appearance.BackColor = Color.Gold;
            if (txtCurpOri.Text != txtCurpMod.Text) txtCurpMod.Appearance.BackColor = Color.Gold;
            if (txtFielOri.Text != txtFielMod.Text) txtFielMod.Appearance.BackColor = Color.Gold;
            if (txtTelefonoOri.Text != txtTelefonoMod.Text) txtTelefonoMod.Appearance.BackColor = Color.Gold;
            if (txtEmailOri.Text != txtEmailMod.Text) txtEmailMod.Appearance.BackColor = Color.Gold;
            if (txtNameCodeOri.Text != txtNameCodeMod.Text) txtNameCodeMod.Appearance.BackColor = Color.Gold;
        }

        void MensajeClienteAutorizado( string Mensaje, bool isRechazo = false)
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            ClientesSolicitudSeguimiento clientesSolicitudSeguimientoNuevo = new ClientesSolicitudSeguimiento();
            clientesSolicitudSeguimientoNuevo.ClienteSolicitud = IDsolicitud;

            if (!isRechazo)
                clientesSolicitudSeguimientoNuevo.Comentario = "Cliente autorizado para su uso en SmartG";
            else
                clientesSolicitudSeguimientoNuevo.Comentario = "Solicitude de cliente rechazada para su uso en SmartG, razon: " + Mensaje;

            clientesSolicitudSeguimientoNuevo.UsuarioLevantamiento = Program.Globals.UserID;
            clientesSolicitudSeguimientoNuevo.FechaLevantamiento = DateTime.Now;
            db.ClientesSolicitudSeguimientos.InsertOnSubmit(clientesSolicitudSeguimientoNuevo);
            db.SubmitChanges();
        }


        void AceptarNuevoCliente(bool isNuevo)
        {
            if (MessageBox.Show("Se aprobará este cliente para su uso en producción, continuar?", "Mensaje",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

                if (isNuevo)
            {
                // cliente nuevo
                if (!ValidarDatos(false)) return;
                else
                {
                    // Check documentos
                    dbSmartGDataContext db = new dbSmartGDataContext();

                    int ConteoDocs = (from x in db.DocumentosAMLs where x.Cliente == IDCliente select x).ToArray().Count();
                    if(ConteoDocs == 0)
                    {
                        if (MessageBox.Show("No se han detectado documentos guardados en la base de datos para este cliente. " +
                            "Continuar con esta aprobación sin documentos (Puede tener implicaciones legales)?", "Mensaje",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            return;
                    }

                    Cliente AprobarCliente = (from x in db.Clientes where x.ID == IDCliente select x).SingleOrDefault();
                    AprobarCliente.TipoCliente = Convert.ToInt32(cbTipoCliente.Value);
                    AprobarCliente.Nombre = txNombre.Text;
                    AprobarCliente.ApellidoPaterno = txtApellidoP.Text;
                    AprobarCliente.ApellidoMaterno = txtApellidoM.Text;
                    AprobarCliente.RazonSocial = txtRazonSocial.Text;
                    AprobarCliente.RFC = txtRfc.Text;
                    AprobarCliente.GiroEmpresarial = txtGiro.Text;
                    AprobarCliente.CURP = txtCurp.Text;
                    AprobarCliente.FIEL = txtFiel.Text;
                    AprobarCliente.Telefono = txtTelefono.Text;
                    AprobarCliente.Email = txtEmail.Text;
                    AprobarCliente.NameCode = txtNameCode.Text;
                    AprobarCliente.Eliminado = false;
                    AprobarCliente.Aprobado = true;
                    db.SubmitChanges();
                    AprobarDocumentos();
                    MensajeClienteAutorizado("");
                }
            }
            else
            {
                //cliente modificado
                dbSmartGDataContext db = new dbSmartGDataContext();

                int ConteoDocs = (from x in db.DocumentosAMLs where x.Cliente == IDCliente select x).ToArray().Count();
                if (ConteoDocs == 0)
                {
                    if (MessageBox.Show("No se han detectado documentos guardados en la base de datos para este cliente. " +
                        "Continuar con esta aprobación sin documentos (Puede tener implicaciones legales)?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;
                }

                Cliente AprobarCliente = (from x in db.Clientes where x.ID == IDCliente select x).SingleOrDefault();
                AprobarCliente.TipoCliente = Convert.ToInt32(cbTipoMod.Value);
                AprobarCliente.Nombre = txtNombreMod.Text;
                AprobarCliente.ApellidoPaterno = txtApellidoPMod.Text;
                AprobarCliente.ApellidoMaterno = txtApellidoMMod.Text;
                AprobarCliente.RazonSocial = txtRazonSocialMod.Text;
                AprobarCliente.RFC = txtRfcMod.Text;
                AprobarCliente.GiroEmpresarial = txtGiroMod.Text;
                AprobarCliente.CURP = txtCurpMod.Text;
                AprobarCliente.FIEL = txtFielMod.Text;
                AprobarCliente.Telefono = txtTelefonoMod.Text;
                AprobarCliente.Email = txtEmailMod.Text;
                AprobarCliente.NameCode = txtNameCodeMod.Text;

                AprobarCliente.Eliminado = false;
                AprobarCliente.Aprobado = true;
                db.SubmitChanges();
                AprobarDocumentos();
                MensajeClienteAutorizado("");
            }

            CompletarRegistroExitoso();
            MessageBox.Show("Cliente aprobado para su uso en polizas y facturas. Documentos AML Aprobados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            CambiarLayout(0);

        }

        void AprobarDocumentos()
        {
            // Actualiza a todos desaprobados
            dbSmartGDataContext db = new dbSmartGDataContext();
            SmartG.DocumentosAML[] docsDesAprobar = (from x in db.DocumentosAMLs where x.Cliente == IDCliente select x).ToArray();
            if(docsDesAprobar.Count() > 0)
            {
                for (int i = 0; i < docsDesAprobar.Count(); i++)
                {
                    docsDesAprobar[i].Activo = false;
                    db.SubmitChanges();
                }
            }

            // Aprueba los ultimos x tipo de documento
            int TipoCliente = Convert.ToInt32((from x in db.Clientes where x.ID == IDCliente select x.TipoCliente).SingleOrDefault());
            string RFC = (from x in db.Clientes where x.ID == IDCliente select x.RFC).SingleOrDefault();
            bool Extranjero = false;
            if (RFC == "XEXX010101000") Extranjero = true;

            TipoDocumentosAML[] DocAplicables = (from x in db.TipoDocumentosAMLs where x.TipoCliente == TipoCliente && x.Extranjero == Extranjero select x).ToArray();
            for (int i = 0; i < DocAplicables.Count(); i++)
            {
                int IDTipoDocumento = DocAplicables[i].ID;
                SmartG.DocumentosAML[] DocsSubidos = (from x in db.DocumentosAMLs where x.Cliente == IDCliente && x.TipoDocumento == IDTipoDocumento orderby x.ID descending select x).ToArray();
                if (DocsSubidos.Count() > 0)
                {
                    DocsSubidos[0].Activo = true;
                    DocsSubidos[0].FechaActivacion = DateTime.Now;
                    db.SubmitChanges();
                }
            }
        }

        void DesAprobarDocumentos()
        {
            // Actualiza a todos desaprobados
            dbSmartGDataContext db = new dbSmartGDataContext();
            SmartG.DocumentosAML[] docsDesAprobar = (from x in db.DocumentosAMLs where x.Cliente == IDCliente select x).ToArray();
            if (docsDesAprobar.Count() > 0)
            {
                for (int i = 0; i < docsDesAprobar.Count(); i++)
                {
                    docsDesAprobar[i].Activo = false;
                    db.SubmitChanges();
                }
            }
        }

        void CompletarRegistroExitoso()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            ClientesSolicitud solicitudActiva = (from x in db.ClientesSolicituds where x.ID == IDsolicitud select x).SingleOrDefault();
            solicitudActiva.status = (from y in db.StatusFacturacions where y.Status == "Aplicado" select y.ID).SingleOrDefault();
            solicitudActiva.FechaAtencion = DateTime.Now;
            solicitudActiva.UsuarioAtencion = Program.Globals.UserID;
            db.SubmitChanges();
        }

        void RechazoSolicitud()
        {
            string vDef = "";
            Extensiones.Edicion.InputBox("Rechazo de Solicitud", "Ingrese una descripción del Rechazo de la Solicitud", ref vDef);
            if (vDef == "")
            {
                MessageBox.Show("Ingrese una razon del rechazo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dbSmartGDataContext db = new dbSmartGDataContext();
            Cliente RechazadoCliente = (from x in db.Clientes where x.ID == IDCliente select x).SingleOrDefault();
            RechazadoCliente.Aprobado = false;
            ClientesSolicitud solicitudActiva = (from x in db.ClientesSolicituds where x.ID == IDsolicitud select x).SingleOrDefault();
            solicitudActiva.status = (from y in db.StatusFacturacions where y.Status == "Rechazado" select y.ID).SingleOrDefault();
            solicitudActiva.FechaAtencion = DateTime.Now;
            solicitudActiva.UsuarioAtencion = Program.Globals.UserID;
            solicitudActiva.ObservacionesAtencion = vDef;
            db.SubmitChanges();
            DesAprobarDocumentos();
            MensajeClienteAutorizado(vDef, true);

            MessageBox.Show("Solicitud Rechazada y todos los documentos desactivados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            CambiarLayout(0);
        }

        void RecuperarSolicitud()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            int StatusRechazoID = (from x in db.StatusFacturacions where x.Status == "Rechazado" select x.ID).SingleOrDefault();
            int StatusSolicitud = Convert.ToInt32( (from x in db.ClientesSolicituds where x.ID == IDsolicitud select x.status).SingleOrDefault());

            if(StatusRechazoID != StatusSolicitud)
            {
                MessageBox.Show("Esta función solo aplica para recuperar solicitudes que se encuentren en status de Rechazado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("Se modificará el status de esta solicitud de Rechazado a Solicitado, continuar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ClientesSolicitud SolActualizar = (from x in db.ClientesSolicituds where x.ID == IDsolicitud select x).SingleOrDefault();
                    SolActualizar.status = (from x in db.StatusFacturacions where x.Status == "Solicitado" select x.ID).SingleOrDefault();
                    db.SubmitChanges();
                    // Agrega Mensaje de seguimiento
                    ClientesSolicitudSeguimiento clientesSolicitudSeguimientoNuevo = new ClientesSolicitudSeguimiento();
                    clientesSolicitudSeguimientoNuevo.ClienteSolicitud = IDsolicitud;
                    clientesSolicitudSeguimientoNuevo.Comentario = "Solicitud de cliente actualizada de Rechazo a Solicitada";
                    clientesSolicitudSeguimientoNuevo.UsuarioLevantamiento = Program.Globals.UserID;
                    clientesSolicitudSeguimientoNuevo.FechaLevantamiento = DateTime.Now;
                    db.ClientesSolicitudSeguimientos.InsertOnSubmit(clientesSolicitudSeguimientoNuevo);
                    db.SubmitChanges();
                    MessageBox.Show("Status modificado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        void AgregarComentario()
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
            clientesSolicitudNuevo.ClienteSolicitud = IDsolicitud;
            clientesSolicitudNuevo.Comentario = vDef;
            clientesSolicitudNuevo.UsuarioLevantamiento = Program.Globals.UserID;
            clientesSolicitudNuevo.FechaLevantamiento = DateTime.Now;
            db.ClientesSolicitudSeguimientos.InsertOnSubmit(clientesSolicitudNuevo);
            db.SubmitChanges();
        }

        void RevisarHistorial()
        {
            VisorSolicitudesUsuario frmSolicitudes = new VisorSolicitudesUsuario(IDsolicitud);
            frmSolicitudes.ShowDialog();
        }

        public AprobacionClientes()
        {
            InitializeComponent();
            dbSmartGDataContext db = new dbSmartGDataContext();
            IDPaisMexico = (from x in db.Pais where x.Nombre == "México" select x.ID).SingleOrDefault();
        }

        void RevisarDocumentos()
        {
            DocumentosAML frmDocumentosAML = new DocumentosAML(IDCliente, IDsolicitud);
            frmDocumentosAML.ShowDialog();
        }

        private void AprobacionClientes_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this, tabAprobacionClientes, ToolbarsManagerAprobacionClientes);
            CargarDataSets();
            CambiarLayout(0);
            cbParametro.SelectedIndex = 0;
        }

        private void ToolbarsManagerAprobacionClientes_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btnAceptarSolicitud":
                    if (tabAprobacionClientes.Tabs[1].Visible == true)
                        AceptarNuevoCliente(true);
                    else
                        AceptarNuevoCliente(false);
                    break;

                case "btnRechazar":
                    RechazoSolicitud();
                    break;

                case "btnRecuperarSolicitud":
                    RecuperarSolicitud();
                    break;                    

                case "btnActualizar":
                    CargarDataSets();
                    break;

                case "btnCerrar":
                    CambiarLayout(0);
                    break;

               // Documentacion y comentarios sguimiento

                case "btnAgregarComentario":
                    AgregarComentario();
                    break;

                case "btnHistorialSeguimiento":
                    RevisarHistorial();
                    break;

                case "btnDocumentosAML":
                    RevisarDocumentos();
                    break;
            }
        }

        private void dgBaseClientes_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            IDsolicitud = Convert.ToInt32(dgBaseClientes.ActiveRow.Cells["ID"].Value);            
            if (IDsolicitud != 0)
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                string rfc = (from x in db.ClientesSolicituds where x.ID == IDsolicitud select x.RFC).SingleOrDefault();
                IDCliente = Convert.ToInt32((from x in db.ClientesSolicituds where x.ID == IDsolicitud select x.cliente).SingleOrDefault());
                if (rfc == null)
                {
                    // Cliente nuevo
                    CambiarLayout(1, false);
                    ToolbarsManagerAprobacionClientes.Tools["btnAceptarSolicitud"].SharedProps.Enabled = true;
                    ToolbarsManagerAprobacionClientes.Tools["btnRechazar"].SharedProps.Enabled = true;
                    CargarNuevoCliente();
                }
                else
                {
                    // CLiente Modificado
                    CambiarLayout(2, false);
                    ToolbarsManagerAprobacionClientes.Tools["btnAceptarSolicitud"].SharedProps.Enabled = true;
                    ToolbarsManagerAprobacionClientes.Tools["btnRechazar"].SharedProps.Enabled = true;
                    CargarClienteModificado();
                }
            }
            else
            {
                MessageBox.Show("El cliente seleccionado no es valido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbTipoCliente_ValueChanged(object sender, EventArgs e)
        {
            if (cbTipoCliente.Text == "Persona Moral")
            {
                // Nombres
                pnlFisica.Visible = false;
                pnlMoral.Visible = true;
                //RFC
                txtRfc.Text = "";
                txtRfc.InputMask = ">&&&######AAA";
                grpNacionalidad.Height = 700;
            }
            else
            {
                // Nombres
                pnlFisica.Visible = true;
                pnlMoral.Visible = false;
                //RFC
                txtRfc.Text = "";
                txtRfc.InputMask = ">&&&&######AAA";
                grpNacionalidad.Height = 700;
            }
        }

        private void cbNacionalidad_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbNacionalidad.Value) == IDPaisMexico)
                chkExtranjero.Checked = false;
            else
                chkExtranjero.Checked = true;
        }

        private void chkExtranjero_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExtranjero.Checked)
            {
                cbTipoCliente.Text = "Persona Moral";
                cbTipoCliente.Enabled = false;
                txtRfc.InputMask = ">&&&&######AAA";
                txtRfc.Text = "XEXX010101000";
                txtRfc.Enabled = false;
                lbFiel.Text = "TAX ID extranjero";
            }
            else
            {
                cbTipoCliente.Text = "Persona Fisica";
                cbTipoCliente.Text = "Persona Moral";
                cbTipoCliente.Enabled = true;
                txtRfc.Text = "";
                txtRfc.Enabled = true;
                lbFiel.Text = "FIEL:";
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            switch (cbParametro.SelectedIndex)
            {
                case 0: //Cliente
                    this.clientesSolicitudTableAdapter.FillByNombreCliente(this.catalogosGral.ClientesSolicitud, txtBusqueda.Text);
                    break;
                case 1: //rfc
                    this.clientesSolicitudTableAdapter.FillByRFC(this.catalogosGral.ClientesSolicitud, txtBusqueda.Text);
                    break;
                case 2: //poliza
                    this.clientesSolicitudTableAdapter.FillByNameCode(this.catalogosGral.ClientesSolicitud, txtBusqueda.Text);
                    break;
            }
            if (this.catalogosGral.ClientesSolicitud.Rows.Count == 0)
                MessageBox.Show("No hay registros", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}

