using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace BRWS6
{
    class BRTaskTester
    {
        private Session _session;
        private string _url;
        public BRTaskTester(Session session, string url)
        {
            _session = session;
            _url = url;
        }

        public TestOutcome GetLookupValues()
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Catalog";
            outcome.methodName = "DataValues";
            try
            {
                CatalogueApi catalogueApi = new CatalogueApi(_url);
                NamedArray dataElements = catalogueApi.DataValues(_session.SessionId, "/Root/Internal/User/User", "", 100, 0);
                foreach (Named dataElement in dataElements)
                {
                    Console.WriteLine(dataElement.Name);
                }
                outcome.outcome = "Success";
                return outcome;
            }
            catch (Exception ex)
            {
                outcome.outcome = ex.Message;
                return outcome;
            }
        }

        public List<TestOutcome> TestAll()
        {
            List<TestOutcome> outcomes = new List<TestOutcome>();

            SessionOperations.RefreshSession(_url, _session.SessionId);
            //run all methods
            TestOutcome values = GetLookupValues();
            outcomes.Add(values);
            SessionOperations.RefreshSession(_url, _session.SessionId);

            //return all the outcomes
            return outcomes;
        }
    }
}
