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
    public partial class ChangeLog : Form
    {
        public ChangeLog()
        {
            InitializeComponent();
        }

        private void ChangeLog_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'catalogosGral.ChangeLog' table. You can move, or remove it, as needed.
            this.changeLogTableAdapter.Fill(this.catalogosGral.ChangeLog);
            // TODO: This line of code loads data into the 'catalogosGral.LoginLogs' table. You can move, or remove it, as needed.
            this.loginLogsTableAdapter.Fill(this.catalogosGral.LoginLogs);

        }
    }
}
