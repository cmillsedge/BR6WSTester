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
    class BRProcessTester
    {
        private Session _session;
        private string _url;
        public BRProcessTester(Session session, string url)
        {
            _session = session;
            _url = url;
        }

        public TestOutcome GetProcessesByOutline(string outline)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "OutlineProcesses";
            outcome.methodName = "ProcessList";
            try
            {
                OutlineProcessesApi processesApi = new OutlineProcessesApi(_url);
                FolderArray processes = processesApi.ProcessList(_session.SessionId, outline, 100);
                foreach (Folder process in processes)
                {
                    Console.WriteLine(process.Name);
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

        public TestOutcome GetProcessByPath(string path)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "OutlineProcesses";
            outcome.methodName = "ProcessFind";
            try
            {
                OutlineProcessesApi processesApi = new OutlineProcessesApi(_url);
                Process process = processesApi.ProcessFind(_session.SessionId, path);
                Console.WriteLine(process.Description);
                outcome.outcome = "Success";
                return outcome;
            }
            catch (Exception ex)
            {
                outcome.outcome = ex.Message;
                return outcome;
            }
        }

        public TestOutcome CreateProcess(string outline)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "OutlineProcesses";
            outcome.methodName = "ProcessImport";
            try
            {
                OutlineProcessesApi processesApi = new OutlineProcessesApi(_url);
                Process proc = ProcessGenerator.GetASimpleProcess(_url, _session.SessionId);
                Folder folder = processesApi.ProcessImport(_session.SessionId, outline, proc);
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
            TestOutcome getProcesses = GetProcessesByOutline("main");
            outcomes.Add(getProcesses);
            TestOutcome getProcess = GetProcessByPath("main/process_processing:1");
            outcomes.Add(getProcess);
            TestOutcome createProcess = CreateProcess("main");
            outcomes.Add(createProcess);

            RefreshSession();

            //return all the outcomes
            return outcomes;
        }
    }
}
