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

        public TestOutcome GetTaskByPath(string path)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Task";
            outcome.methodName = "TaskFind";
            try
            {
                TasksApi tasksApi = new TasksApi(_url);
                IO.Swagger.Model.Task task = tasksApi.TaskFind(_session.SessionId, path);
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

        public TestOutcome GetTaskNoRows(string path)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Task";
            outcome.methodName = "TaskFind(norows)";
            try
            {
                TasksApi tasksApi = new TasksApi(_url);
                IO.Swagger.Model.Task task = tasksApi.TaskFind(_session.SessionId, path, true);
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

        public TestOutcome SearchForTasks(string filterstring)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Task";
            outcome.methodName = "TaskSearch";
            try
            {
                TasksApi tasksApi = new TasksApi(_url);
                FolderArray tasks = tasksApi.TaskSearch(_session.SessionId, "", true, 100, FilterGenerator.SimpleFilter("tasks.name", "like", filterstring + "%"));
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

        public TestOutcome CreateFlatTask()
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Task";
            outcome.methodName = "TaskCreate(Flat)";
            try
            {
                TasksApi tasksApi = new TasksApi(_url);
                IO.Swagger.Model.Task task = TaskGenerator.GetFlatTask();
                JobReport job = tasksApi.TaskCreate(_session.SessionId, "all", task);
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

        public TestOutcome CreateHierarchicalTask()
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Task";
            outcome.methodName = "TaskCreate(Hierarchical)";
            try
            {
                TasksApi tasksApi = new TasksApi(_url);
                IO.Swagger.Model.Task task = TaskGenerator.GetHierarchicalTask();
                JobReport job = tasksApi.TaskCreate(_session.SessionId, "all", task);
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

        public TestOutcome UpdateTask(string path)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Task";
            outcome.methodName = "TaskEdit";
            try
            {
                TasksApi tasksApi = new TasksApi(_url);
                IO.Swagger.Model.Task task = tasksApi.TaskFind(_session.SessionId, path);
                task.Rows[0].Values["conc"] = "55";
                JobReport job = tasksApi.TaskEdit(_session.SessionId, path, task);
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
            TestOutcome allTasks = GetAllTasksForFolder("all");
            outcomes.Add(allTasks);
            TestOutcome idTask = GetTaskById(10066);
            outcomes.Add(idTask);
            TestOutcome pathTask = GetTaskByPath("all/task_pending");
            outcomes.Add(pathTask);
            TestOutcome pathTaskNoRows = GetTaskNoRows("all/task_pending");
            outcomes.Add(pathTaskNoRows);
            TestOutcome searchTask = SearchForTasks("t");
            outcomes.Add(searchTask);
            TestOutcome flatTask = CreateFlatTask();
            outcomes.Add(flatTask);
            TestOutcome hierTask = CreateHierarchicalTask();
            outcomes.Add(hierTask);
            TestOutcome updateTask = UpdateTask("all/task_pending");
            outcomes.Add(updateTask);
            TestOutcome delTask = DestroyTask("BRFlatTask");
            outcomes.Add(delTask);

            SessionOperations.RefreshSession(_url, _session.SessionId);

            //return all the outcomes
            return outcomes;
        }
    }
}
