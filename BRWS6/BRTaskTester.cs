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

        public TestOutcome GetTaskById(int taskid)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Task";
            outcome.methodName = "TaskGet";
            try
            {
                TasksApi tasksApi = new TasksApi(_url);
                IO.Swagger.Model.Task task = tasksApi.TaskGet(_session.SessionId, taskid.ToString());
                Console.WriteLine(task.ProcessPath);
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
            //!CMills change this before sending to tester
            //TestOutcome idTasks = GetTaskById(10066);
            TestOutcome idTasks = GetTaskById(6709999);
            outcomes.Add(idTasks);
            
            SessionOperations.RefreshSession(_url, _session.SessionId);

            //return all the outcomes
            return outcomes;
        }
    }
}
