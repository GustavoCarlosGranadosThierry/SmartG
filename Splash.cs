using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartG
{
    public partial class Splash : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // metodos programados utilizados en el form
        #region metodos

        async void Conexion()
        {
            await Task.Run(() => (Login.StatusConexion = Login.IsServerConnected()));
        }

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region eventos

        public Splash()
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            Conexion();
            this.labelVersion.Text = "Versión " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            timerMain.Start();
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            Login frmLogin = new Login();
            timerMain.Stop();
            Hide();
            frmLogin.ShowDialog();
            Close();
        }

        #endregion

    }
}
