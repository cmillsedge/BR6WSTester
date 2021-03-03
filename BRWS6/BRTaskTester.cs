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

        public TestOutcome GetAllTasksForFolder(string folder)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Task";
            outcome.methodName = "TaskList";
            try
            {
                TasksApi tasksApi = new TasksApi(_url);
                FolderArray tasks = tasksApi.TaskList(_session.SessionId, folder);
                foreach (Folder task in tasks)
                {
                    Console.WriteLine(task.Name);
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
            TestOutcome allTasks = GetAllTasksForFolder("all");
            outcomes.Add(allTasks);
            SessionOperations.RefreshSession(_url, _session.SessionId);

            //return all the outcomes
            return outcomes;
        }
    }
}
