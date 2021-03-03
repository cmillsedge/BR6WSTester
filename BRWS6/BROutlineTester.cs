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
    class BROutlineTester
    {
        private Session _session;
        private string _url;
        public BROutlineTester(Session session, string url)
        {
            _session = session;
            _url = url;
        }

        public TestOutcome GetAnOutline(string outlineName)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Outlines";
            outcome.methodName = "OutlineFind";
            try
            {
                OutlinesApi outlinesApi = new OutlinesApi(_url);
                Outline outline = outlinesApi.OutlineFind(_session.SessionId, outlineName);
                Console.WriteLine(outline.Name);
                outcome.outcome = "Success";
                return outcome;
            }
            catch (Exception ex)
            {
                outcome.outcome = ex.Message;
                return outcome;
            }
        }

        public TestOutcome GetAllOutlines()
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Outlines";
            outcome.methodName = "OutlineList";
            try
            {
                OutlinesApi outlinesApi = new OutlinesApi(_url);
                FolderArray outlines = outlinesApi.OutlineList(_session.SessionId, ""); //note path not really needed for this method so pass empty
                foreach (Folder outline in outlines)
                {
                    Console.WriteLine(outline.Name);
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
            TestOutcome oneOutline = GetAnOutline("services");
            outcomes.Add(oneOutline);
            TestOutcome allOutlines = GetAllOutlines();
            outcomes.Add(allOutlines);

            SessionOperations.RefreshSession(_url, _session.SessionId);

            //return all the outcomes
            return outcomes;
        }
    }
}
