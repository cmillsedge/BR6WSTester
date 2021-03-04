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
    class BRRequestTester
    {
        private Session _session;
        private string _url;
        public BRRequestTester(Session session, string url)
        {
            _session = session;
            _url = url;
        }

        public TestOutcome GetRequestById(int id)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Request";
            outcome.methodName = "RequestGet";
            try
            {
                RequestsApi reqApi = new RequestsApi(_url);
                Request request = reqApi.RequestGet(_session.SessionId, id.ToString());
                foreach (QueueItem qi in request.QueueItems)
                {
                    Console.WriteLine(qi.Id);
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

        public TestOutcome GetRequestByName(string name)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Request";
            outcome.methodName = "RequestFind";
            try
            {
                RequestsApi reqApi = new RequestsApi(_url);
                Request request = reqApi.RequestFind(_session.SessionId, name);
                foreach (QueueItem qi in request.QueueItems)
                {
                    Console.WriteLine(qi.Id);
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

        public TestOutcome SearchRequests(string filterstring)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Request";
            outcome.methodName = "RequestsSearch";
            try
            {
                RequestsApi requestsApi = new RequestsApi(_url);
                NamedArray requests = requestsApi.RequestsSearch(_session.SessionId, "all", FilterGenerator.SimpleFilter("name", "like", filterstring + "%"), 100);
                foreach (Named request in requests)
                {
                    Console.WriteLine(request.Name);
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

        public TestOutcome CreateRequest()
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Request";
            outcome.methodName = "RequestCreateJob";
            try
            {
                RequestsApi requestsApi = new RequestsApi(_url);
                Request request = RequestGenerator.GetSimpleRequest();
                JobReport job = requestsApi.RequestCreateJob(_session.SessionId, "all", request);

                JobReport polledJob = JobHandler.pollJob(job, _session.SessionId, _url);
                if (polledJob.ErrorMessage != null)
                { outcome.outcome = polledJob.ErrorMessage; }
                else
                { outcome.outcome = "Success"; }
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
            TestOutcome getRequest = GetRequestById(10002);
            outcomes.Add(getRequest);
            TestOutcome findRequest = GetRequestByName("powder_service_request");
            outcomes.Add(findRequest);
            TestOutcome searchRequest = SearchRequests("powder");
            outcomes.Add(searchRequest);
            TestOutcome createRequest = CreateRequest();
            outcomes.Add(createRequest);

            SessionOperations.RefreshSession(_url, _session.SessionId);

            //return all the outcomes
            return outcomes;
        }
    }
}
