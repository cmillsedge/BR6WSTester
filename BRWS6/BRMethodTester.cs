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
    class BRMethodTester
    {
        private Session _session;
        private string _url;
        public BRMethodTester(Session session, string url)
        {
            _session = session;
            _url = url;
        }
        public TestOutcome GetMethods(string outline)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "OutlineMethods";
            outcome.methodName = "OutlineMethodList";
            try
            {
                OutlineMethodsApi methodsApi = new OutlineMethodsApi(_url);
                OutlineMethodArray outlineMethods = methodsApi.OutlineMethodList(_session.SessionId, outline, 100);
                foreach (OutlineMethod outlineMethod in outlineMethods)
                {
                    Console.WriteLine(outlineMethod.Path);
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

        public TestOutcome GetSingleMethod(string path)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "OutlineMethods";
            outcome.methodName = "OutlineMethodFind";
            try
            {
                OutlineMethodsApi methodsApi = new OutlineMethodsApi(_url);
                OutlineMethod method = methodsApi.OutlineMethodFind(_session.SessionId, path);
                Console.WriteLine(method);
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
            TestOutcome methodsByOutline = GetMethods("main");
            outcomes.Add(methodsByOutline);
            TestOutcome methodByName = GetSingleMethod("main/rat");
            outcomes.Add(methodByName);

            RefreshSession();

            //return all the outcomes
            return outcomes;
        }
    }
}
