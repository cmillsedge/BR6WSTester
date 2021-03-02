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
using IO.Swagger.Model;

namespace BRWS6
{
    public partial class frmAll : Form
    {
        Session _session;
        string _url;
        public frmAll(Session wsSession, string url)
        {
            InitializeComponent();
            _session = wsSession;
            _url = url;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            //reset everything
            Cursor.Current = Cursors.WaitCursor;
            dgvTestResults.Rows.Clear();
            rtbProgress.Text = "";
            //Run tests 
            RunCatalogTests();
            RunFolderTests();
            //Colour the grid at the end
            ColourGrid();
            Cursor.Current = Cursors.Default;
        }

       

        private void RunCatalogTests()
        {

            //test module -- catalog
            rtbProgress.AppendText("Started Catalog Tests ..." + Environment.NewLine);
            BRCatalogTester catTest = new BRCatalogTester(_session, _url);
            List<TestOutcome> catOutcomes = catTest.TestAll();
            PopulateOutcomes(catOutcomes);
            rtbProgress.AppendText("Completed Catalog Tests" + Environment.NewLine);
            ForceRefresh();
            //test next thing
        }
        private void RunFolderTests()
        {

            //test module -- folders
            rtbProgress.AppendText("Started Folder Tests ..." + Environment.NewLine);
            BRFolderTester folTest = new BRFolderTester(_session, _url);
            List<TestOutcome> folOutcomes = folTest.TestAll();
            PopulateOutcomes(folOutcomes);
            rtbProgress.AppendText("Completed Folder Tests" + Environment.NewLine);
            ForceRefresh();
            //test next thing
        }

        private void ForceRefresh()
        {
            rtbProgress.Update();
            dgvTestResults.Update();
        }

        private void PopulateOutcomes(List<TestOutcome> outcomes)
        {

            dgvTestResults.AllowUserToAddRows = true;
            dgvTestResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            foreach (TestOutcome outcome in outcomes)
            {
                dgvTestResults.Rows.Add(outcome.moduleName, outcome.methodName, outcome.outcome);

            }
            dgvTestResults.AllowUserToAddRows = false;
        }

        private void ColourGrid()
        {

            rtbProgress.AppendText("Set row colours started ..." + Environment.NewLine);
            foreach (DataGridViewRow dgr in dgvTestResults.Rows)
            {
                if (dgr.Cells[2].Value.ToString() == "Success")
                {
                    dgr.DefaultCellStyle.BackColor = Color.LightGreen;

                }
                else
                {
                    dgr.DefaultCellStyle.BackColor = Color.LightPink;
                }
            }
            rtbProgress.AppendText("Set row colours complete" + Environment.NewLine);
        }
    }
}
