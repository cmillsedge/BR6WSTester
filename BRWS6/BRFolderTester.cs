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
    class BRFolderTester
    {
        private Session _session;
        private string _url;
        public BRFolderTester(Session session, string url)
        {
            _session = session;
            _url = url;
        }

        public TestOutcome GetFoldersUnder(string path)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Folders";
            outcome.methodName = "FolderList";
            try
            {
                FoldersApi foldersApi = new FoldersApi(_url);
                FolderArray folders = foldersApi.FolderList(_session.SessionId, path, 100);
                foreach (Folder folder in folders)
                {
                    Console.WriteLine(folder.Name);
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

        public TestOutcome GetFolderByPath(string path)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Folders";
            outcome.methodName = "FolderFind";
            try
            {
                FoldersApi foldersApi = new FoldersApi();
                Folder folder = foldersApi.FolderFind(_session.SessionId, path);
                Console.WriteLine(folder.Description);
                outcome.outcome = "Success";
                return outcome;
            }
            catch (Exception ex)
            {
                outcome.outcome = ex.Message;
                return outcome;
            }
        }

        public TestOutcome GetFolderBySearch()
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Folders";
            outcome.methodName = "FolderSearch";
            try
            {
                FoldersApi foldersApi = new FoldersApi(_url);
                FolderArray folders = foldersApi.FolderSearch(_session.SessionId, "", true, 100, SimpleFilter("_", "contains", "method"));
                foreach (Folder folder in folders)
                {
                    Console.WriteLine(folder.Name);
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

        private FilterArray SimpleFilter(string field, string op, string val)
        {
            Filter filter = new Filter(field, op, new List<string>() { val });
            FilterArray filters = new FilterArray { filter };
            return filters;
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
            TestOutcome foldersUnder = GetFoldersUnder("services");
            outcomes.Add(foldersUnder);
            TestOutcome folderByPath = GetFolderByPath("all");
            outcomes.Add(folderByPath);
            TestOutcome folderSearch = GetFolderBySearch();
            outcomes.Add(folderSearch);

            RefreshSession();

            //return all the outcomes
            return outcomes;
        }
    }
}
