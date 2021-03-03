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
    class BROutParamTester
    {
        private Session _session;
        private string _url;
        public BROutParamTester(Session session, string url)
        {
            _session = session;
            _url = url;
        }


        public TestOutcome SearchParameters()
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "OutlineParameters";
            outcome.methodName = "OutlineParameterSearch";
            try
            {
                OutlineParametersApi outlineParametersApi = new OutlineParametersApi(_url);
                OutlineParameterArray outlineParameters = outlineParametersApi.OutlineParameterSearch(_session.SessionId, "main", FilterGenerator.SimpleFilter("name", "like", "c%"), 100);
                foreach (OutlineParameter op in outlineParameters)
                {
                    Console.WriteLine(op.Name);
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

        public TestOutcome CreateParameter()
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "OutlineParameters";
            outcome.methodName = "OutlineParameterCreate";
            try
            {
                OutlineParametersApi outlineParametersApi = new OutlineParametersApi(_url);
                OutlineParameter op = ParameterGenerator.GetOneSimpleParameter(_url, _session.SessionId);
                outlineParametersApi.OutlineParameterCreate(_session.SessionId, "main", op);
                Console.WriteLine(op.Id);
                outcome.outcome = "Success";
                return outcome;
            }
            catch (Exception ex)
            {
                outcome.outcome = ex.Message;
                return outcome;
            }
        }

        public TestOutcome UpdateParameter()
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "OutlineParameters";
            outcome.methodName = "OutlineParameterUpdate";
            try
            {
                OutlineParametersApi outlineParametersApi = new OutlineParametersApi(_url);
                OutlineParameter outlineParameter = outlineParametersApi.OutlineParameterFind(_session.SessionId, "main/plate_id");
                outlineParameter.Description = "a new description";
                Folder ops = outlineParametersApi.OutlineParameterUpdate(_session.SessionId, outlineParameter.Id, outlineParameter);
                Console.WriteLine(ops.Description);
                outcome.outcome = "Success";
                return outcome;
            }
            catch (Exception ex)
            {
                outcome.outcome = ex.Message;
                return outcome;
            }
        }

        public TestOutcome DestroyParameter()
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "OutlineParameters";
            outcome.methodName = "OutlineParameterDestroy";
            try
            {
                OutlineParametersApi outlineParametersApi = new OutlineParametersApi(_url);
                OutlineParameter op = ParameterGenerator.GetOneSimpleParameter(_url, _session.SessionId);
                outlineParametersApi.OutlineParameterCreate(_session.SessionId, "main", op);
                OutlineParameter op2 = outlineParametersApi.OutlineParameterFind(_session.SessionId, "main/" + op.Name);
                Console.WriteLine(op2.Id);
                outlineParametersApi.OutlineParameterDestroy(_session.SessionId, op2.Id);
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
            TestOutcome searchParams = SearchParameters();
            outcomes.Add(searchParams);
            TestOutcome createParam = CreateParameter();
            outcomes.Add(createParam);
            TestOutcome updateParam = UpdateParameter();
            outcomes.Add(updateParam);
            TestOutcome destroyParam = DestroyParameter();
            outcomes.Add(destroyParam);

            SessionOperations.RefreshSession(_url, _session.SessionId);

            //return all the outcomes
            return outcomes;
        }
    }
}
