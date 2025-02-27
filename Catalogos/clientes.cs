using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG.Catalogos
{
    public partial class clientes : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // nombres y valores de todos los objetos que se encuentran en el formulario
        #region coleccion objetos
        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region variables

        int IDPaisMexico;
        int IDCliente;
        int IDClienteDireccionEditar = 0;

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region Metodos programados

        void CargarDataSets()
        {
            this.tipoClienteTableAdapter.Fill(this.catalogosGral1.TipoCliente);
            this.paisTableAdapter.Fill(this.catalogosGral.Pais);
            this.clientesTableAdapter.Fill(this.catalogosGral1.Clientes);
            this.clientesTableAdapter.FillByNameCodePrincipal(this.catalogosGral2.Clientes);
            this.clientesSolicitudTableAdapter.FillByXusuario(this.catalogosGral1.ClientesSolicitud, Program.Globals.UserID);
        }

        void CambiarLayout(int modo)
        {
            // 0 - inicial todo oculto
            // 1 - agregar un nuevo cliente
            // 2 - ediatr un cliente existente
            // 3 - agrgar direcciones
            // 4 - Solicitudes

            IDCliente = 0;
            ToolbarsManagerClientes.Ribbon.Tabs[0].Groups["rgbMenu"].Visible = false;
            ToolbarsManagerClientes.Ribbon.Tabs[0].Groups["rgbNuevo"].Visible = false;
            ToolbarsManagerClientes.Ribbon.Tabs[0].Groups["rgbActualizar"].Visible = false;
            ToolbarsManagerClientes.Ribbon.Tabs[0].Groups["rgbDirecciones"].Visible = false;
            ToolbarsManagerClientes.Ribbon.Tabs[0].Groups["rgbSolicitudesAML"].Visible = false;
            tabClientes.Visible = false;
            tabClientes.Tabs[0].Visible = false;
            tabClientes.Tabs[1].Visible = false;
            tabClientes.Tabs[2].Visible = false;
            grpDireccion.Visible = true;
            grpNacionalidad.Enabled = true;
            grpDatosCliente.Enabled = true;

            switch (modo)
            {
                case 0:
                    ToolbarsManagerClientes.Ribbon.Tabs[0].Groups["rgbMenu"].Visible = true;
                    LimpiarFormularios();
                    break;

                case 1:
                    ToolbarsManagerClientes.Ribbon.Tabs[0].Groups["rgbNuevo"].Visible = true;
                    tabClientes.Visible = true; ;
                    tabClientes.Tabs[1].Visible = true;
                    this.clientesDireccionesTableAdapter.FillByCliente(this.catalogosGral1.ClientesDirecciones, 0);
                    break;

                case 2:
                    ToolbarsManagerClientes.Ribbon.Tabs[0].Groups["rgbActualizar"].Visible = true;
                    ToolbarsManagerClientes.Tools["btnEdiarClienteEnviarSolicitud"].SharedProps.Enabled = false;
                    tabClientes.Visible = true; ;
                    tabClientes.Tabs[0].Visible = true;
                    break;

                case 3:
                    ToolbarsManagerClientes.Ribbon.Tabs[0].Groups["rgbDirecciones"].Visible = true;
                    ToolbarsManagerClientes.Tools["btnDireccionGuardar"].SharedProps.Enabled = false;
                    tabClientes.Visible = true; ;
                    tabClientes.Tabs[0].Visible = true;
                    break;
                case 4:
                    ToolbarsManagerClientes.Ribbon.Tabs[0].Groups["rgbSolicitudesAML"].Visible = true;
                    tabClientes.Visible = true; ;
                    tabClientes.Tabs[2].Visible = true;
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
            txtCalle.Text = "";
            txtNumExt.Text = "";
            txtNumInt.Text = "";
            txtCP.Text = "";
            txtColonia.Text = "";
            txtMunicipio.Text = "";
            txtEstado.Text = "";
            this.clientesDireccionesTableAdapter.FillByCliente(this.catalogosGral1.ClientesDirecciones, 0);
            IDClienteDireccionEditar = 0;
            btnCancelarDireccion.Visible = false;
            btnAgregarDireccion.Text = "Agregar dirección";
        }

        void CambiarFisicaMoral()
        {
            if (cbTipoCliente.Text == "Persona Moral")
            {
                // Nombres
                pnlFisica.Visible = false;
                pnlMoral.Visible = true;
                //RFC
                txtRfc.Text = "";
                txtRfc.InputMask = ">&&&######AAA";
                grpDatosCliente.Height = 330;

                txNombre.Text = "";
                txtApellidoP.Text = "";
                txtApellidoM.Text = "";
            }
            else
            {
                // Nombres
                pnlFisica.Visible = true;
                pnlMoral.Visible = false;
                //RFC
                txtRfc.Text = "";
                txtRfc.InputMask = ">&&&&######AAA";
                grpDatosCliente.Height = 410;

                txtRazonSocial.Text = "";
            }

            grpDireccion.Location = new Point(grpDireccion.Location.X, (grpDatosCliente.Location.Y + grpDatosCliente.Height + 20));

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

        private void BusquedaCP()
        {
            //Bloquea el proceso si el cliente es extranjero
            if (chkExtranjero.Checked) { return; }

            string cp = txtCP.Text;
            string request = "https://api-codigos-postales.herokuapp.com/v2/codigo_postal/" + cp;
            try
            {
                //Limpia todo
                txtMunicipio.Text = "";
                txtEstado.Text = "";
                txtColonia.Items.Clear();

                //Obtiene la respuesta del API y corrigue el texto
                WebClient client2 = new WebClient();
                //string response = client2.DownloadString(request).ToString();
                string response = new Extensiones.ConsultaBanxico.TimedWebClient { Timeout = 3000 }.DownloadString(request);

                byte[] bytes = Encoding.GetEncoding(1252).GetBytes(response);
                var strFixed = Encoding.UTF8.GetString(bytes);

                // Separa municipio y estado

                string[] strarray = strFixed.Split(',');
                char[] trimchar = { '"', ']', '}' };

                //Municipio
                string municipio = strarray[1].Substring(12).Trim(trimchar);
                txtMunicipio.Text = municipio;

                //Estado
                string estado = strarray[2].Substring(9).Trim(trimchar);
                txtEstado.Text = estado;

                // Rellena los combobox

                string[] strarray_col = strFixed.Split('[');
                string colonias = strarray_col[1].Replace("\"", "").TrimEnd(trimchar);
                string[] lista_colonias = colonias.Split(',');

                Infragistics.Win.ValueList vl = new Infragistics.Win.ValueList();
                int contador = 0;
                for (int i = 0; i < lista_colonias.Length; i++)
                {
                    vl.ValueListItems.Add(contador, lista_colonias[i]);
                    contador++;
                }
                txtColonia.ValueList = vl;

                if (txtColonia.Items.Count > 0)
                {
                    txtColonia.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error due to: " + ex.Message);
            }
        }

        void AgregarDireccion()
        {
            // Valida
            if (txtCalle.Text.Length == 0 ||
                    txtNumExt.Text.Length == 0 ||
                    txtCP.Text.Length == 0 ||
                    txtColonia.Text.Length == 0 ||
                    txtMunicipio.Text.Length == 0 ||
                    txtEstado.Text.Length == 0)
            {
                MessageBox.Show("Error: Datos incompletos, completar los datos minimos");
                return;
            }

            string Residencia;
            if (!chkExtranjero.Checked)
                Residencia = "Nacional";
            else
                Residencia = "Extranjero";

            if (IDClienteDireccionEditar == 0)
            {
                dgDirecciones.DisplayLayout.Bands[0].AddNew();
                Infragistics.Win.UltraWinGrid.UltraGridRow newRow = dgDirecciones.Rows.LastOrDefault();
                newRow.Cells["Calle"].Value = txtCalle.Text;
                newRow.Cells["NumExterior"].Value = txtNumExt.Text;
                newRow.Cells["NumInterior"].Value = txtNumInt.Text;
                newRow.Cells["CP"].Value = txtCP.Text;
                newRow.Cells["Colonia"].Value = txtColonia.Text;
                newRow.Cells["Municipio"].Value = txtMunicipio.Text;
                newRow.Cells["Estado"].Value = txtEstado.Text;
                newRow.Cells["Pais"].Value = cbPais.Value;
                newRow.Cells["Residencia"].Value = Residencia;
                newRow.Cells["NomPais"].Value = cbPais.Text;
            }
            else
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in dgDirecciones.Rows)
                {
                    if (Convert.ToInt32(row.Cells["ID"].Value) == IDClienteDireccionEditar)
                    {
                        row.Cells["Calle"].Value = txtCalle.Text;
                        row.Cells["NumExterior"].Value = txtNumExt.Text;
                        row.Cells["NumInterior"].Value = txtNumInt.Text;
                        row.Cells["CP"].Value = txtCP.Text;
                        row.Cells["Colonia"].Value = txtColonia.Text;
                        row.Cells["Municipio"].Value = txtMunicipio.Text;
                        row.Cells["Estado"].Value = txtEstado.Text;
                        row.Cells["Pais"].Value = cbPais.Value;
                        row.Cells["Residencia"].Value = Residencia;
                        row.Cells["NomPais"].Value = cbPais.Text;
                        break;
                    }
                }
            }

            // Limpieza
            txtCalle.Text = "";
            txtNumExt.Text = "";
            txtNumInt.Text = "";
            txtCP.Text = "";
            txtColonia.Text = "";
            txtMunicipio.Text = "";
            txtEstado.Text = "";
            IDClienteDireccionEditar = 0;
            btnCancelarDireccion.Visible = false;
            btnAgregarDireccion.Text = "Agregar dirección";
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
                    if(!chkExtranjero.Checked)
                    {
                        MessageBox.Show("RFC Invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (txtNameCode.Text == "" && chkNameCodePrincipal.Checked == true)
                {
                    MessageBox.Show("No se ha ingresado un NameCode primario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (cbNameCodeSecundario.Text.ToString() == "" && chkNameCodePrincipal.Checked == false)
                {
                    MessageBox.Show("No se ha ingresado un NameCode secundario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }


                if (chkNameCodePrincipal.Checked == true && (from x in db.Clientes where x.NameCode == txtNameCode.Text select x).ToArray().Count() > 0)
                {
                    MessageBox.Show("Error: El NameCode ya ha sido dado de alta anteriormente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNameCode.Text = "";
                    return false;
                }

                // Verifica si no el cliente ya esta dado de alta
                if (!chkExtranjero.Checked)
                {
                    if ((from x in db.Clientes where x.RFC == txtRfc.Text select x).ToArray().Count() > 0)
                    {
                        MessageBox.Show("Error: El Cliente nuevo ya se encuentra registrado en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }

            return true;
        }

        void AgregarSolicitudNuevoCliente()
        {
            if (!ValidarDatos(true)) return;
            else
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                // Ingreso del cliente
                Cliente NuevoCliente = new Cliente();
                NuevoCliente.TipoCliente = Convert.ToInt32(cbTipoCliente.Value);
                NuevoCliente.Nombre = txNombre.Text;
                NuevoCliente.ApellidoPaterno = txtApellidoP.Text;
                NuevoCliente.ApellidoMaterno = txtApellidoM.Text;
                NuevoCliente.RazonSocial = txtRazonSocial.Text;
                NuevoCliente.RFC = txtRfc.Text;
                NuevoCliente.GiroEmpresarial = txtGiro.Text;
                NuevoCliente.CURP = txtCurp.Text;
                NuevoCliente.FIEL = txtFiel.Text;
                NuevoCliente.Telefono = txtTelefono.Text;
                NuevoCliente.Email = txtEmail.Text;
                NuevoCliente.Eliminado = false;
                NuevoCliente.Aprobado = false;

                if (chkNameCodePrincipal.Checked)
                {
                    NuevoCliente.NameCode = txtNameCode.Text;
                    NuevoCliente.NameCodePrincipal = true;
                }
                else
                {
                    NuevoCliente.NameCode = cbNameCodeSecundario.Value.ToString();
                    NuevoCliente.NameCodePrincipal = false;
                }

                db.Clientes.InsertOnSubmit(NuevoCliente);
                db.SubmitChanges();
                int clienteID = NuevoCliente.ID;

                // Direcciones
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow newRow in dgDirecciones.Rows)
                {
                    ClientesDireccione NuevaDireccion = new ClientesDireccione();
                    NuevaDireccion.Cliente = clienteID;
                    NuevaDireccion.Calle = newRow.Cells["Calle"].Value.ToString();
                    NuevaDireccion.NumExterior = newRow.Cells["NumExterior"].Value.ToString();
                    NuevaDireccion.NumInterior = newRow.Cells["NumInterior"].Value.ToString();
                    NuevaDireccion.CP = newRow.Cells["CP"].Value.ToString();
                    NuevaDireccion.Colonia = newRow.Cells["Colonia"].Value.ToString();
                    NuevaDireccion.Municipio = newRow.Cells["Municipio"].Value.ToString();
                    NuevaDireccion.Estado = newRow.Cells["Estado"].Value.ToString();
                    NuevaDireccion.Pais = Convert.ToInt32(newRow.Cells["Pais"].Value);
                    NuevaDireccion.Residencia = newRow.Cells["Residencia"].Value.ToString();
                    NuevaDireccion.Eliminado = false;
                    db.ClientesDirecciones.InsertOnSubmit(NuevaDireccion);
                    db.SubmitChanges();
                }

                // Ingreso de la solicitud
                ClientesSolicitud NuevaSolicitud = new ClientesSolicitud();
                NuevaSolicitud.UsuarioSolicitud = Program.Globals.UserID;
                NuevaSolicitud.fechaSolicitud = DateTime.Now;
                NuevaSolicitud.cliente = clienteID;
                NuevaSolicitud.status = (from x in db.StatusFacturacions where x.Status == "Solicitado" select x.ID).SingleOrDefault();
                NuevaSolicitud.TipoSolicitud = (from x in db.TipoSolicitudAMLs where x.TipoSolicitud == "Nuevo Cliente" select x.ID).SingleOrDefault();
                db.ClientesSolicituds.InsertOnSubmit(NuevaSolicitud);
                db.SubmitChanges();

                // Ingresa primer Comentario
                ClientesSolicitudSeguimiento clientesSolicitudNuevo = new ClientesSolicitudSeguimiento();
                clientesSolicitudNuevo.ClienteSolicitud = NuevaSolicitud.ID;
                clientesSolicitudNuevo.Comentario = "Nueva Solicitud de Cliente";
                clientesSolicitudNuevo.UsuarioLevantamiento = Program.Globals.UserID;
                clientesSolicitudNuevo.FechaLevantamiento = DateTime.Now;
                db.ClientesSolicitudSeguimientos.InsertOnSubmit(clientesSolicitudNuevo);
                db.SubmitChanges();

                MessageBox.Show("Solicitud realizada, esta solicitud debera ser autorizada por un administrador AML para poder ser utilizada en polizas y facturas." + Environment.NewLine + Environment.NewLine +
                    " Favor de enviar los documentos probatorios de identificación del cliente a su oficial de cumplimiento." +
                    " Puede verificar el status de su solicitud en el menu de seguimiento." + Environment.NewLine + Environment.NewLine +
                    "Se recomienda ingresar un comentario nuevo cuando se envien los documentos por email a su ofial de cumplimiento",
                    "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                CambiarLayout(0);
            }
        }

        void GuardarSolicitudModificacion()
        {
            if (!ValidarDatos(false)) return;
            dbSmartGDataContext db = new dbSmartGDataContext();

            // Busca Soliciudes Previas
            ClientesSolicitud busquedaSol = (from x in db.ClientesSolicituds where x.cliente == IDCliente && x.status != (from y in db.StatusFacturacions where y.Status == "Aplicado" select y.ID).SingleOrDefault() select x).FirstOrDefault();
            if (busquedaSol != null)
            {
                if (MessageBox.Show("Este cliente ya tiene una solicitud de modificación en proceso, desea sobreescribirla?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    busquedaSol.UsuarioSolicitud = Program.Globals.UserID;
                    busquedaSol.fechaSolicitud = DateTime.Now;
                    busquedaSol.cliente = IDCliente;
                    busquedaSol.status = (from x in db.StatusFacturacions where x.Status == "Solicitado" select x.ID).SingleOrDefault();
                    busquedaSol.TipoCliente = Convert.ToInt32(cbTipoCliente.Value);
                    busquedaSol.Nombre = txNombre.Text;
                    busquedaSol.ApellidoPaterno = txtApellidoP.Text;
                    busquedaSol.ApellidoMaterno = txtApellidoM.Text;
                    busquedaSol.RazonSocial = txtRazonSocial.Text;
                    busquedaSol.RFC = txtRfc.Text;
                    busquedaSol.GiroEmpresarial = txtGiro.Text;
                    busquedaSol.CURP = txtCurp.Text;
                    busquedaSol.FIEL = txtFiel.Text;
                    busquedaSol.Telefono = txtTelefono.Text;
                    busquedaSol.Email = txtEmail.Text;

                    if (chkNameCodePrincipal.Checked)
                        busquedaSol.NameCode = txtNameCode.Text;
                    else
                        busquedaSol.NameCode = cbNameCodeSecundario.Value.ToString();

                    db.SubmitChanges();
                    MessageBox.Show("Solicitud completada, los cambios se veran reflejados hasta que el autorizador acepte los cambios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    CambiarLayout(0);
                    return;
                }
                else return;
            }
            else
            {
                // Ingreso de la solicitud Nueva
                ClientesSolicitud NuevaSolicitud = new ClientesSolicitud();
                NuevaSolicitud.UsuarioSolicitud = Program.Globals.UserID;
                NuevaSolicitud.fechaSolicitud = DateTime.Now;
                NuevaSolicitud.cliente = IDCliente;
                NuevaSolicitud.status = (from x in db.StatusFacturacions where x.Status == "Solicitado" select x.ID).SingleOrDefault();
                NuevaSolicitud.TipoCliente = Convert.ToInt32(cbTipoCliente.Value);
                NuevaSolicitud.Nombre = txNombre.Text;
                NuevaSolicitud.ApellidoPaterno = txtApellidoP.Text;
                NuevaSolicitud.ApellidoMaterno = txtApellidoM.Text;
                NuevaSolicitud.RazonSocial = txtRazonSocial.Text;
                NuevaSolicitud.RFC = txtRfc.Text;
                NuevaSolicitud.GiroEmpresarial = txtGiro.Text;
                NuevaSolicitud.CURP = txtCurp.Text;
                NuevaSolicitud.FIEL = txtFiel.Text;
                NuevaSolicitud.Telefono = txtTelefono.Text;
                NuevaSolicitud.Email = txtEmail.Text;
                NuevaSolicitud.NameCode = txtNameCode.Text;

                db.ClientesSolicituds.InsertOnSubmit(NuevaSolicitud);
                db.SubmitChanges();
                MessageBox.Show("Solicitud completada, los cambios se veran reflejados hasta que el autorizador acepte los cambios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                CambiarLayout(0);
                return;
            }
        }

        void GuardarCambiosDireccion()
        {
            if (dgDirecciones.Rows.Count > 0)
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                // Borra todas direcciones existentes
                ClientesDireccione[] borrarDirecciones = (from x in db.ClientesDirecciones where x.Cliente == IDCliente select x).ToArray();
                for (int i = 0; i < borrarDirecciones.Count(); i++)
                {
                    borrarDirecciones[i].Eliminado = true;
                    db.SubmitChanges();
                }

                int[] IDdireccionesBorrar = (from x in db.ClientesDirecciones where x.Cliente == IDCliente select x.ID).ToArray();
                for (int i = 0; i < IDdireccionesBorrar.Length; i++)
                {
                    try
                    {
                        db = new dbSmartGDataContext();
                        ClientesDireccione borrarDireccionesFull = (from x in db.ClientesDirecciones where x.ID == IDdireccionesBorrar[i] select x).SingleOrDefault();
                        db.ClientesDirecciones.DeleteOnSubmit(borrarDireccionesFull);
                        db.SubmitChanges();
                    }
                    catch { }
                }

                db = new dbSmartGDataContext();
                // Agrega los nuevos
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow newRow in dgDirecciones.Rows)
                {
                    ClientesDireccione NuevaDireccion = new ClientesDireccione();
                    NuevaDireccion.Cliente = IDCliente;
                    NuevaDireccion.Calle = newRow.Cells["Calle"].Value.ToString();
                    NuevaDireccion.NumExterior = newRow.Cells["NumExterior"].Value.ToString();
                    NuevaDireccion.NumInterior = newRow.Cells["NumInterior"].Value.ToString();
                    NuevaDireccion.CP = newRow.Cells["CP"].Value.ToString();
                    NuevaDireccion.Colonia = newRow.Cells["Colonia"].Value.ToString();
                    NuevaDireccion.Municipio = newRow.Cells["Municipio"].Value.ToString();
                    NuevaDireccion.Estado = newRow.Cells["Estado"].Value.ToString();
                    NuevaDireccion.Pais = Convert.ToInt32(newRow.Cells["Pais"].Value);
                    NuevaDireccion.Residencia = newRow.Cells["Residencia"].Value.ToString();
                    NuevaDireccion.Eliminado = false;
                    db.ClientesDirecciones.InsertOnSubmit(NuevaDireccion);
                    db.SubmitChanges();
                }
                MessageBox.Show("Las direcciones han sido cargadas en el sistema, estas no requieren aprobación previa por lo que ya estan disponibles para su uso",
                    "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                CambiarLayout(0);
            }
            else
            {
                MessageBox.Show("No se han agregado direcciones validas para este cliente, agregar esta información", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        void CargarModificacion()
        {
            IDCliente = Convert.ToInt32(dgBaseClientes.ActiveRow.Cells["ID"].Value);
            ToolbarsManagerClientes.Ribbon.Tabs[0].Groups["rgbMenu"].Visible = false;
            ToolbarsManagerClientes.Ribbon.Tabs[0].Groups["rgbNuevo"].Visible = false;
            ToolbarsManagerClientes.Ribbon.Tabs[0].Groups["rgbActualizar"].Visible = true;
            ToolbarsManagerClientes.Ribbon.Tabs[0].Groups["rgbDirecciones"].Visible = false;
            tabClientes.Tabs[0].Visible = false;
            tabClientes.Tabs[1].Visible = true;

            dbSmartGDataContext db = new dbSmartGDataContext();
            Cliente clienteRecuperado = (from x in db.Clientes where x.ID == IDCliente select x).SingleOrDefault();
            ClientesDireccione clientesDireccione = (from x in db.ClientesDirecciones where x.Cliente == clienteRecuperado.ID select x).FirstOrDefault();

            if(clientesDireccione != null)
            {
                cbNacionalidad.Value = clientesDireccione.Pai.ID;
            }

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

            chkNameCodePrincipal.Checked = Convert.ToBoolean(clienteRecuperado.NameCodePrincipal);

            if (chkNameCodePrincipal.Checked)
                txtNameCode.Text = clienteRecuperado.NameCode;
            else
                cbNameCodeSecundario.Value = clienteRecuperado.NameCode;

            grpDireccion.Visible = false;
        }

        void DescargarDocsActivos()
        {
            dbSmartGDataContext db = new dbSmartGDataContext();
            saveFileDialog1.FileName = (from x in db.Clientes where x.ID == IDCliente select x.RFC).SingleOrDefault() + "_AML_" + DateTime.Now.ToShortDateString().Replace("/", "");
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Directory.CreateDirectory(@"C:\SmartG\temp");
                SmartG.DocumentosAML[] DocsBajar;
                DocsBajar = (from x in db.DocumentosAMLs where x.Cliente == IDCliente && x.Activo == true select x).ToArray();
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

        void CargarCambiosDireccion()
        {
            IDCliente = Convert.ToInt32(dgBaseClientes.ActiveRow.Cells["ID"].Value);
            ToolbarsManagerClientes.Ribbon.Tabs[0].Groups["rgbMenu"].Visible = false;
            ToolbarsManagerClientes.Ribbon.Tabs[0].Groups["rgbNuevo"].Visible = false;
            ToolbarsManagerClientes.Ribbon.Tabs[0].Groups["rgbActualizar"].Visible = false;
            ToolbarsManagerClientes.Ribbon.Tabs[0].Groups["rgbDirecciones"].Visible = true;
            tabClientes.Tabs[0].Visible = false;
            tabClientes.Tabs[1].Visible = true;

            dbSmartGDataContext db = new dbSmartGDataContext();
            Cliente clienteRecuperado = (from x in db.Clientes where x.ID == IDCliente select x).SingleOrDefault();
            ClientesDireccione clientesDireccione = (from x in db.ClientesDirecciones where x.Cliente == clienteRecuperado.ID select x).FirstOrDefault();

            if (clientesDireccione != null)
            {
                cbNacionalidad.Value = clientesDireccione.Pai.ID;
                cbPais.Value = clientesDireccione.Pai.ID;
            }

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
            this.clientesDireccionesTableAdapter.FillByCliente(this.catalogosGral1.ClientesDirecciones, IDCliente);

            grpNacionalidad.Enabled = false;
            grpDatosCliente.Enabled = false;
        }

        public clientes(int Idcliente)
        {
            InitializeComponent();
            IDCliente = Idcliente;
        }

        private void TrimThisText(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinEditors.UltraTextEditor Control = (Infragistics.Win.UltraWinEditors.UltraTextEditor)sender;
            Control.Text = Control.Text.Trim();
        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region eventos del form

        private void clientes_Load(object sender, EventArgs e)
        {
            Extensiones.Traduccion.traducirVentana(this, tabClientes, ToolbarsManagerClientes);
            dbSmartGDataContext db = new dbSmartGDataContext();
            IDPaisMexico = (from x in db.Pais where x.Nombre == "México" select x.ID).SingleOrDefault();
            CargarDataSets();
            CambiarLayout(0);
            cbParametro.SelectedIndex = 0;

            // Valores default
            cbNacionalidad.Text = "México";
            cbTipoCliente.Text = "Persona Moral";
        }

        private void cbTipoCliente_ValueChanged(object sender, EventArgs e)
        {
            CambiarFisicaMoral();
        }

        private void cbNacionalidad_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbNacionalidad.Value) == IDPaisMexico)
                chkExtranjero.Checked = false;
            else
                chkExtranjero.Checked = true;

            cbPais.Value = cbNacionalidad.Value;
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

        private void txtCP_Leave(object sender, EventArgs e)
        {
            if (txtCP.TextLength == 5)
                BusquedaCP();
        }

        private void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            AgregarDireccion();
        }

        private void dgDirecciones_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            IDClienteDireccionEditar = Convert.ToInt32(dgDirecciones.ActiveRow.Cells["ID"].Value);
            txtCalle.Text = dgDirecciones.ActiveRow.Cells["Calle"].Value.ToString();
            txtNumExt.Text = dgDirecciones.ActiveRow.Cells["NumExterior"].Value.ToString();
            txtNumInt.Text = dgDirecciones.ActiveRow.Cells["NumInterior"].Value.ToString();
            txtCP.Text = dgDirecciones.ActiveRow.Cells["CP"].Value.ToString();
            txtColonia.Text = dgDirecciones.ActiveRow.Cells["Colonia"].Text;
            txtMunicipio.Text = dgDirecciones.ActiveRow.Cells["Municipio"].Value.ToString();
            txtEstado.Text = dgDirecciones.ActiveRow.Cells["Estado"].Value.ToString();
            btnCancelarDireccion.Visible = true;
            btnAgregarDireccion.Text = "Actualizar dirección";
        }

        private void dgDirecciones_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (Convert.ToInt32(dgDirecciones.ActiveRow.Cells["ID"].Value) <= 0) // Sin BD
            {
                dgDirecciones.ActiveRow.Delete();
            }
            else  // En BD
            {
                dbSmartGDataContext db = new dbSmartGDataContext();
                ClientesDireccione editarDireccion = (from x in db.ClientesDirecciones where x.ID == Convert.ToInt32(dgDirecciones.ActiveRow.Cells["ID"].Value) && x.Cliente == IDCliente select x).SingleOrDefault();
                try
                {
                    db.ClientesDirecciones.DeleteOnSubmit(editarDireccion);
                    db.SubmitChanges();
                }
                catch
                {
                    db = new dbSmartGDataContext();
                    editarDireccion.Eliminado = true;
                    db.SubmitChanges();
                }
                dgDirecciones.ActiveRow.Delete();
            }
        }

        private void btnCancelarDireccion_Click(object sender, EventArgs e)
        {
            // Limpieza
            txtCalle.Text = "";
            txtNumExt.Text = "";
            txtNumInt.Text = "";
            txtCP.Text = "";
            txtColonia.Text = "";
            txtMunicipio.Text = "";
            txtEstado.Text = "";
            IDClienteDireccionEditar = 0;
            btnCancelarDireccion.Visible = false;
            btnAgregarDireccion.Text = "Agregar dirección";
        }

        private void ToolbarsManagerClientes_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (dgDirecciones.Rows.Count > 0)
            {
                for (int i = 0; i < dgDirecciones.Rows.Count; i++)
                    dgDirecciones.Rows[i].Update();
            }

            switch (e.Tool.Key)
            {
                // Main
                case "btnAgregarNuevoCliente":
                    CambiarLayout(1);
                    break;

                case "btnModificarCliente":
                    CambiarLayout(2);
                    break;

                case "btnAgreagarDirecciones":
                    CambiarLayout(3);
                    break;

                //Nuevo Cliente
                case "btnNuevoClienteSolicitarCambios":
                    AgregarSolicitudNuevoCliente();
                    break;

                case "btnNuevoClienteCancelar":
                    CambiarLayout(0);
                    break;

                // Editar Cliente

                case "btnEdiarClienteEnviarSolicitud":
                    GuardarSolicitudModificacion();
                    break;

                case "btnModificarClienteCancelar":
                    CambiarLayout(0);
                    break;

                // Direcciones

                case "btnDireccionGuardar":
                    GuardarCambiosDireccion();
                    break;

                case "btnDireccionesCancelar":
                    if (dgDirecciones.Rows.Count() == 0)
                    {
                        MessageBox.Show("Agregue al menos una direccione para este clienete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    CambiarLayout(0);
                    break;

                //Solicitudes
                case "btnSeguimientoSolicitudes":
                    this.clientesSolicitudTableAdapter.FillByXusuario(this.catalogosGral1.ClientesSolicitud, Program.Globals.UserID);
                    CambiarLayout(4);
                    break;

                case "btnConsultarStatus":
                    dgSolicitudesAML_DoubleClickRow(null, null);
                    break;

                case "Consultar Documentos":
                    DescargarDocsActivos();
                    break;

                case "btnCancelarSolicitud":
                    break;

                // Actualizar

                case "btnActualizar":
                    CargarDataSets();
                    break;
            }
        }

        private void txtRfc_Leave(object sender, EventArgs e)
        {
            if (txtRfc.Value.ToString() == "") return;
            if (!validarRFC(txtRfc.Value.ToString()))
            {
                MessageBox.Show("RFC Invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void clientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            CambiarLayout(0);
        }

        private void dgBaseClientes_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (ToolbarsManagerClientes.Ribbon.Tabs[0].Groups["rgbActualizar"].Visible == true)
            {
                ToolbarsManagerClientes.Tools["btnEdiarClienteEnviarSolicitud"].SharedProps.Enabled = true;
                CargarModificacion();
            }
            if (ToolbarsManagerClientes.Ribbon.Tabs[0].Groups["rgbDirecciones"].Visible == true)
            {
                ToolbarsManagerClientes.Tools["btnDireccionGuardar"].SharedProps.Enabled = true;
                CargarCambiosDireccion();
            }
        }

        private void chkNameCodePrincipal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNameCodePrincipal.Checked)
            {
                txtNameCode.Enabled = true;
                lbNameCodeSeleccion.Visible = false;
                cbNameCodeSecundario.Value = "";
                cbNameCodeSecundario.Enabled = false;
            }
            else
            {
                txtNameCode.Enabled = false;
                lbNameCodeSeleccion.Visible = true;
                cbNameCodeSecundario.Enabled = true;
                txtNameCode.Text = "";
            }
        }

        private void cb_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            try
            {
                Infragistics.Win.UltraWinEditors.UltraComboEditor cb = (Infragistics.Win.UltraWinEditors.UltraComboEditor)sender;

                if (cb.Items.Count > 0)
                {
                    MessageBox.Show("Debe seleccionar un elemento valido de la lista " + cb.DisplayMember.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.RetainFocus = true;
                }
                else
                {
                    e.RetainFocus = false;
                    cb.Text = "";
                }
            }
            catch
            {
                Infragistics.Win.UltraWinGrid.UltraCombo cb = (Infragistics.Win.UltraWinGrid.UltraCombo)sender;

                if (cb.Rows.Count > 0)
                {
                    MessageBox.Show("Debe seleccionar un elemento valido de la lista " + cb.DisplayMember.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.RetainFocus = true;
                }
                else
                {
                    e.RetainFocus = false;
                    cb.Text = "";
                }
            }
        }

        private void txtNameCode_Leave(object sender, EventArgs e)
        {
            txtNameCode.Text = txtNameCode.Text.ToUpper();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            switch (cbParametro.SelectedIndex)
            {
                case 0: //Cliente
                    this.clientesTableAdapter.FillByNomComp(this.catalogosGral1.Clientes, txtBusqueda.Text);
                    break;
                case 1: //rfc
                    this.clientesTableAdapter.FillByRFC(this.catalogosGral1.Clientes, txtBusqueda.Text);
                    break;
                case 2: //poliza
                    this.clientesTableAdapter.FillByNameCode(this.catalogosGral1.Clientes, txtBusqueda.Text);
                    break;
            }
            if (this.catalogosGral1.Clientes.Count == 0)
                MessageBox.Show("No hay registros", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar_Click(null, null);
        }

        private void dgSolicitudesAML_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            VisorSolicitudesUsuario frmSolicitudes = new VisorSolicitudesUsuario(Convert.ToInt32(dgSolicitudesAML.ActiveRow.Cells["ID"].Value));
            frmSolicitudes.ShowDialog();
            CargarDataSets();
        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************       
    }
}
