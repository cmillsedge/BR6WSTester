using System;
using System.Windows.Forms;
using IO.Swagger.Api;
using IO.Swagger.Model;


namespace BRWS6
{
    public partial class frmCatalog : Form
    {
        Session _session;
        public frmCatalog(Session wsSession, string url)
        {
            InitializeComponent();
            _session = wsSession;
            GetParameterTypes();
            GetConcepts();
            GetLookups();
        }

        public void GetParameterTypes()
        {
            try
            {
                CatalogueApi catalogueApi = new CatalogueApi();
                ParameterTypeArray parameterTypes = catalogueApi.CatalogueParameterTypes(_session.SessionId);
                foreach (ParameterType parameterType in parameterTypes)
                {
                    cmbParamTypes.Items.Add(parameterType.Name);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetConcepts()
        {
            try
            { 
                CatalogueApi catalogueApi = new CatalogueApi();
                NamedArray dataConcepts = catalogueApi.DataConcepts(_session.SessionId);
                foreach (Named dataConcept in dataConcepts)
                {
                    cmbConcepts.Items.Add(dataConcept.Path);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetLookups()
        {
            try
            { 
                CatalogueApi catalogueApi = new CatalogueApi();
                NamedArray dataElements = catalogueApi.DataElements(_session.SessionId);
                foreach (Named dataElement in dataElements)
                {
                    cmbLookups.Items.Add(dataElement.Path + dataElement.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLookupsByPath_Click(object sender, System.EventArgs e)
        {
            try
            {
                NamedArray dataElements = null;
                cmbLookups.Items.Clear();
                CatalogueApi catalogueApi = new CatalogueApi();
                if (cmbConcepts.Text != null && cmbConcepts.Text != "")
                { dataElements = catalogueApi.DataElements(_session.SessionId, cmbConcepts.Text); }
                else
                { dataElements = catalogueApi.DataElements(_session.SessionId); }

                foreach (Named dataElement in dataElements)
                {
                    cmbLookups.Items.Add(dataElement.Path + dataElement.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
