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
            RunMethodTests();
            RunOutlineTests();
            RunOutlineParamTests();
            RunProcessTests();
            RunQueryTests();
            RunTaskTests();
            RunRequestTests();
            //Colour the grid at the end
            ColourGrid();
            Cursor.Current = Cursors.Default;
        }

       

        private void RunCatalogTests()
        {

            //test module -- catalog
            rtbProgress.AppendText("Started Catalog Tests ..." + Environment.NewLine);
            ForceRefresh();
            BRCatalogTester catTest = new BRCatalogTester(_session, _url);
            List<TestOutcome> catOutcomes = catTest.TestAll();
            PopulateOutcomes(catOutcomes);
            rtbProgress.AppendText("Completed Catalog Tests" + Environment.NewLine);
            ForceRefresh();
        }
        private void RunFolderTests()
        {

            //test module -- folders
            rtbProgress.AppendText("Started Folder Tests ..." + Environment.NewLine);
            ForceRefresh();
            BRFolderTester folTest = new BRFolderTester(_session, _url);
            List<TestOutcome> folOutcomes = folTest.TestAll();
            PopulateOutcomes(folOutcomes);
            rtbProgress.AppendText("Completed Folder Tests" + Environment.NewLine);
            ForceRefresh();
        }

        private void RunMethodTests()
        {

            //test module -- catalog
            rtbProgress.AppendText("Started Method Tests ..." + Environment.NewLine);
            ForceRefresh();
            BRMethodTester metTest = new BRMethodTester(_session, _url);
            List<TestOutcome> metOutcomes = metTest.TestAll();
            PopulateOutcomes(metOutcomes);
            rtbProgress.AppendText("Completed Method Tests" + Environment.NewLine);
            ForceRefresh();
        }

        private void RunOutlineTests()
        {

            //test module -- catalog
            rtbProgress.AppendText("Started Outline Tests ..." + Environment.NewLine);
            ForceRefresh();
            BROutlineTester outlineTest = new BROutlineTester(_session, _url);
            List<TestOutcome> outlineOutcomes = outlineTest.TestAll();
            PopulateOutcomes(outlineOutcomes);
            rtbProgress.AppendText("Completed Outline Tests" + Environment.NewLine);
            ForceRefresh();
        }

        private void RunOutlineParamTests()
        {

            //test module -- catalog
            rtbProgress.AppendText("Started Outline Parameter Tests ..." + Environment.NewLine);
            ForceRefresh();
            BROutParamTester paramTest = new BROutParamTester(_session, _url);
            List<TestOutcome> paramOutcomes = paramTest.TestAll();
            PopulateOutcomes(paramOutcomes);
            rtbProgress.AppendText("Completed Outline Parameter Tests" + Environment.NewLine);
            ForceRefresh();
        }

        private void RunProcessTests()
        {

            //test module -- catalog
            rtbProgress.AppendText("Started Process Tests ..." + Environment.NewLine);
            ForceRefresh();
            BRProcessTester procTest = new BRProcessTester(_session, _url);
            List<TestOutcome> procOutcomes = procTest.TestAll();
            PopulateOutcomes(procOutcomes);
            rtbProgress.AppendText("Completed Process Tests" + Environment.NewLine);
            ForceRefresh();
        }

        private void RunQueryTests()
        {

            //test module -- catalog
            rtbProgress.AppendText("Started Query Tests ..." + Environment.NewLine);
            ForceRefresh();
            BRQueryTester queryTest = new BRQueryTester(_session, _url);
            List<TestOutcome> queryOutcomes = queryTest.TestAll();
            PopulateOutcomes(queryOutcomes);
            rtbProgress.AppendText("Completed Query Tests" + Environment.NewLine);
            ForceRefresh();
        }

        private void RunTaskTests()
        {

            //test module -- catalog
            rtbProgress.AppendText("Started Task Tests ..." + Environment.NewLine);
            ForceRefresh();
            BRTaskTester taskTest = new BRTaskTester(_session, _url);
            List<TestOutcome> taskOutcomes = taskTest.TestAll();
            PopulateOutcomes(taskOutcomes);
            rtbProgress.AppendText("Completed Task Tests" + Environment.NewLine);
            ForceRefresh();
        }

        private void RunRequestTests()
        {

            //test module -- catalog
            rtbProgress.AppendText("Started Request Tests ..." + Environment.NewLine);
            ForceRefresh();
            BRRequestTester reqTest = new BRRequestTester(_session, _url);
            List<TestOutcome> reqOutcomes = reqTest.TestAll();
            PopulateOutcomes(reqOutcomes);
            rtbProgress.AppendText("Completed Request Tests" + Environment.NewLine);
            ForceRefresh();
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

            rtbProgress.AppendText("Started setting row colours..." + Environment.NewLine);
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
            rtbProgress.AppendText("Completed setting row colours" + Environment.NewLine);
        }
    }
}
