using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace BRWS6
{
    public partial class frmSelect : Form
    {
        Session _session;
        string _url;
        public frmSelect(Session wsSession, string url)
        {
            InitializeComponent();
            _session = wsSession;
            _url = url;
        }

        private void btnCatalog_Click(object sender, EventArgs e)
        {
            using (frmCatalog frmCat = new frmCatalog(_session, _url))
            {
                frmCat.Location = this.Location;
                this.Hide();
                frmCat.ShowDialog();

            }
            this.Show();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            using (frmAll frmAllTests = new frmAll(_session,_url))
            {
                frmAllTests.Location = this.Location;
                this.Hide();
                frmAllTests.ShowDialog();

            }
            this.Show();

        }
    }
}
