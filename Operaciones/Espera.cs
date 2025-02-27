using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartG.Operaciones
{
    public partial class Espera : Form
    {
        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // declaración de variables utilizadas en el form por tab
        #region variables

        int tipoVentana = 0;

        #endregion

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************
        // eventos del form (clicks, loads, etc)
        #region eventos

        public Espera(int selector = 0)
        {
            InitializeComponent();
            Extensiones.Edicion.RoundCorners(this);
            if (selector != 0)
                tipoVentana = 1;
        }

        public string Message
        {
            set { lbTitulo.Text = value; }
        }

        private void Espera_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;

            Random rand = new Random();
            int PicInt = rand.Next(1, 4);

            switch (PicInt)
            {
                case 1:
                    pictureBox1.Visible = true;
                    if (tipoVentana != 0)
                        pictureBox1.Dock = DockStyle.Fill;
                    break;
                case 2:
                    pictureBox2.Visible = true;
                    if (tipoVentana != 0)
                        pictureBox2.Dock = DockStyle.Fill;
                    break;
                case 3:
                    pictureBox3.Visible = true;
                    if (tipoVentana != 0)
                        pictureBox3.Dock = DockStyle.Fill;
                    break;
            }

            if (tipoVentana != 0)
            {
                var screen = Screen.FromPoint(this.Location);
                this.Size = new Size(120, 150);
                lbTitulo.Font = new Font("Arial", 8, FontStyle.Bold);
                this.Location = new Point(screen.WorkingArea.Right - this.Width, screen.WorkingArea.Bottom - this.Height);
                lbTitulo.Text = "Capturando en Genius, espere...";
                //base.OnLoad(e);
            }

        }

        #endregion
    }
}
