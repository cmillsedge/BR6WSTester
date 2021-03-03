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
    class BRQueryTester
    {
        private Session _session;
        private string _url;
        public BRQueryTester(Session session, string url)
        {
            _session = session;
            _url = url;
        }

        public TestOutcome GetQueriesByTemplate()
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Queries";
            outcome.methodName = "QueriesTemplates";
            try
            {
                QueriesApi queriesApi = new QueriesApi(_url);
                QueryTemplateArray templates = queriesApi.QueriesTemplates(_session.SessionId, "ResultTask", "", 100);
                foreach (QueryTemplate template in templates)
                {
                    Console.WriteLine(template.Title);
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

        public TestOutcome GetQueriesByFilter(string filterstring)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Queries";
            outcome.methodName = "QueriesSearch";
            try
            {
                QueriesApi queriesApi = new QueriesApi(_url);
                NamedArray queries = queriesApi.QueriesSearch(_session.SessionId, 100, FilterGenerator.SimpleFilter("name", "like", filterstring + "%"));
                foreach (Named query in queries)
                {
                    Console.WriteLine(query.Name);
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

        public TestOutcome CreateQuery(string queryName)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Queries";
            outcome.methodName = "QueriesBuild";
            try
            {
                QueriesApi queriesApi = new QueriesApi(_url);
                QueryTemplateArray templates = queriesApi.QueriesTemplates(_session.SessionId, "ResultTask");
                foreach (QueryTemplate template in templates)
                {
                    Console.WriteLine(template.Title);
                }
                QueryTemplate a_template = templates[0];
                Console.WriteLine(a_template.InternalRef);

                Query query = queriesApi.QueriesBuild(_session.SessionId, a_template.InternalRef);
                outcome.outcome = "Success";
                return outcome;
            }
            catch (Exception ex)
            {
                outcome.outcome = ex.Message;
                return outcome;
            }
        }

        private void RefreshSession()
        {
            //if the tests take a long time to run we want to avoid a timeout. This method will do that
            SessionsApi s = new SessionsApi(_url);
            s.Refresh(_session.SessionId);
        }

        public List<TestOutcome> TestAll()
        {
            List<TestOutcome> outcomes = new List<TestOutcome>();

            RefreshSession();
            //run all methods
            TestOutcome queryByTemplate = GetQueriesByTemplate();
            outcomes.Add(queryByTemplate);
            TestOutcome queryByFilter = GetQueriesByFilter("task");
            outcomes.Add(queryByFilter);
            TestOutcome queryCreate = CreateQuery("task");
            outcomes.Add(queryCreate);
            RefreshSession();

            //return all the outcomes
            return outcomes;
        }
    }
}
