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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string url = txtURL.Text.TrimEnd('/');
                SessionsApi s = new SessionsApi(url + "/api/v6");
                Session key = s.Login(txtUser.Text, txtPass.Text);
                Console.WriteLine(key.SessionId);
                using (frmSelect frmSel = new frmSelect(key, url + "/api/v6"))
                {
                    this.Hide();
                    frmSel.Location = this.Location;
                    frmSel.ShowDialog();
                }
                //frmSel closed re-display logon
                this.Show();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
