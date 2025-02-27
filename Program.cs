using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG
{
    public static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            int ControlLogin = 0;
            string[] args = Environment.GetCommandLineArgs();
            if ((args.Length > 1) && ((args[1].StartsWith("/d")) || (args[1].StartsWith("/p") )))
            {
                ControlLogin = 1;
                if ((args[1].StartsWith("/p")))
                {
                    Properties.Settings.Default.XLCatlinConnectionString = "Data Source=" + Globals.server + ";Initial Catalog=AxaXLProduccion;Persist Security Info=True;User ID=" + Globals.UserDB + ";Password=" + Globals.PassDB;
                    Properties.Settings.Default.DocumentosSmartGConnectionString = "Data Source=" + Globals.server + ";Initial Catalog=DocumentosSmartG;Persist Security Info=True;User ID=" + Globals.UserDB + ";Password=" + Globals.PassDB;
                }
                else if ((args[1].StartsWith("/d")))
                {
                    Properties.Settings.Default.XLCatlinConnectionString = "Data Source=" + Globals.server + ";Initial Catalog=AxaXLCopyLive;Persist Security Info=True;User ID=" + Globals.UserDB + ";Password=" + Globals.PassDB;
                    Properties.Settings.Default.DocumentosSmartGConnectionString = "Data Source=" + Globals.server + ";Initial Catalog=DocumentosSmartG_Debug;Persist Security Info=True;User ID=" + Globals.UserDB + ";Password=" + Globals.PassDB;
                }
                else if ((args[1].StartsWith("/c")))
                {
                    Properties.Settings.Default.XLCatlinConnectionString = "Data Source=" + Globals.server + ";Initial Catalog=AxaXLClaims;Persist Security Info=True;User ID=" + Globals.UserDB + ";Password=" + Globals.PassDB;
                    Properties.Settings.Default.DocumentosSmartGConnectionString = "Data Source=" + Globals.server + ";Initial Catalog=DocumentosSmartG_Debug;Persist Security Info=True;User ID=" + Globals.UserDB + ";Password=" + Globals.PassDB;
                }
            }
            if (ControlLogin > 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Splash());
            }
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(Extensiones.Traduccion.GetMessageText("UnhandlerErrorMessage"),"Error Report",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            ErrorHandler frmError = new ErrorHandler(e.Exception.Message, e.Exception.StackTrace);
            frmError.ShowDialog();
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(Extensiones.Traduccion.GetMessageText("UnhandlerErrorMessage"), "Error Report", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ErrorHandler frmError = new ErrorHandler((e.ExceptionObject as Exception).Message, ((e.ExceptionObject as Exception).StackTrace));
            frmError.ShowDialog();
        }

        public static class Globals
        {
            // Pass de la BD
            public const string UserDB = "UsuarioXL";
            public const string PassDB = "kreios1020";
            public const string server = @"MAXLAP\SQLEXPRESS";

            // Valores del Usuario Actual
            public static int UserID;
            public static string TipoUsuario;
            public static string UserName;
            public static int CurrentSessionID;
            public static string NombreCompletoUsuario;
        }
    }
}