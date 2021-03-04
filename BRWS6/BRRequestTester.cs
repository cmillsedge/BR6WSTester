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

        public TestOutcome DestroyTask(string filterstring)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Task";
            outcome.methodName = "TaskDestroy";
            try
            {
                TasksApi tasksApi = new TasksApi(_url);
                IO.Swagger.Model.Task task = TaskGenerator.GetFlatTask();
                JobReport job = tasksApi.TaskCreate(_session.SessionId, "all", task);
                JobReport polledJob = JobHandler.pollJob(job, _session.SessionId, _url);
                FolderArray tasks = tasksApi.TaskSearch(_session.SessionId, "", true, 100, FilterGenerator.SimpleFilter("tasks.name", "like", filterstring + "%"));
                tasksApi.TaskDestroy(_session.SessionId, tasks[0].ReferenceId);
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
            TestOutcome delTask = DestroyTask("BRFlatTask");
            outcomes.Add(delTask);

            SessionOperations.RefreshSession(_url, _session.SessionId);

            //return all the outcomes
            return outcomes;
        }
    }
}
