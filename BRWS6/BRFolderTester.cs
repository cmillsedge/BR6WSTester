using System;
using System.Globalization;
using System.Collections.Generic;
using System.Resources;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
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
                FoldersApi foldersApi = new FoldersApi(_url);
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
                FolderArray folders = foldersApi.FolderSearch(_session.SessionId, "", true, 100, FilterGenerator.SimpleFilter("_", "contains", "method"));
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

        public TestOutcome CreateFolder(string path)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Folders";
            outcome.methodName = "FolderCreate";
            string folderName = "folder_new" + System.DateTime.Now.ToString("G", CultureInfo.CreateSpecificCulture("en-US")).Replace('/', '-').Replace(':', '_');
            try
            {
                FoldersApi foldersApi = new FoldersApi(_url);
                Folder newFolder = new Folder(null, folderName, null, "this is a new folder", null, "ProjectFolder");
                Folder folder = foldersApi.FolderCreate(_session.SessionId, path , newFolder);
                Console.WriteLine(folder.Path);
                outcome.outcome = "Success";
                return outcome;
            }
            catch (Exception ex)
            {
                outcome.outcome = ex.Message;
                return outcome;
            }
        }

        public TestOutcome UpdateFolder(string path)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Folders";
            outcome.methodName = "FolderUpdate";
            try
            {
                FoldersApi foldersApi = new FoldersApi(_url);
                Folder folder = foldersApi.FolderFind(_session.SessionId, path);
                folder.Description = "this is a new description";
                Folder upFolder = foldersApi.FolderUpdate(_session.SessionId, folder.Id, folder);
                Console.WriteLine(upFolder.Description);
                outcome.outcome = "Success";
                return outcome;
            }
            catch (Exception ex)
            {
                outcome.outcome = ex.Message;
                return outcome;
            }
        }

        public TestOutcome CreateNote(string path)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Folders";
            outcome.methodName = "FolderNote";
            string noteName = "Note-" + System.DateTime.Now.ToString("G", CultureInfo.CreateSpecificCulture("en-US")).Replace('/', '-').Replace(':', '_');
            try
            {
                FoldersApi foldersApi = new FoldersApi(_url);
                Folder containingFolder = foldersApi.FolderFind(_session.SessionId, path);
                ProjectContent content = new ProjectContent(@"
                                                             <h1>A note</h1>
                                                             <p>This is a new note</p>
                                                            ");
                Folder folder = foldersApi.FolderNote(_session.SessionId, containingFolder.Id, "ProjectContent", noteName, content);
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

        public TestOutcome CreateFile(string path)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Folders";
            outcome.methodName = "FolderFile";
            string imageName = "World-" + System.DateTime.Now.ToString("G", CultureInfo.CreateSpecificCulture("en-US")).Replace('/', '-').Replace(':', '_');
            try
            {
                FoldersApi foldersApi = new FoldersApi(_url);
                //string systempath = Environment.CurrentDirectory;
                string systempath = Application.StartupPath;
                using (FileStream fs = new FileStream(systempath + "\\world.jpg", FileMode.Open))
                {
                    foldersApi.FolderFile(_session.SessionId, path, fs, imageName);
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

        public TestOutcome GetFile(string path)
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Folders";
            outcome.methodName = "FolderDownload";
            try
            {
                FoldersApi foldersApi = new FoldersApi(_url);
                string fileName = path + @"/" + "file";
                string localfilename = "World-" + System.DateTime.Now.ToString("G", CultureInfo.CreateSpecificCulture("en-US")).Replace('/', '-').Replace(':', '_').Replace(' ', '_') + ".png";
                localfilename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), localfilename);
                Stream downloadedFile = foldersApi.FolderDownload(_session.SessionId, fileName);
                using (FileStream localFile = File.Create(localfilename))
                    
                {
                    downloadedFile.CopyTo(localFile);
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
            TestOutcome foldersUnder = GetFoldersUnder("services");
            outcomes.Add(foldersUnder);
            TestOutcome folderByPath = GetFolderByPath("biology");
            outcomes.Add(folderByPath);
            TestOutcome folderSearch = GetFolderBySearch();
            outcomes.Add(folderSearch);
            TestOutcome folderCreate = CreateFolder("services");
            outcomes.Add(folderCreate);
            TestOutcome folderUpdate = UpdateFolder("biology");
            outcomes.Add(folderUpdate);
            TestOutcome noteCreate = CreateNote("support");
            outcomes.Add(noteCreate);
            TestOutcome fileGet = GetFile("project");
            outcomes.Add(fileGet);
            TestOutcome fileCreate = CreateFile("all");
            outcomes.Add(fileCreate);
            

            SessionOperations.RefreshSession(_url, _session.SessionId);

            //return all the outcomes
            return outcomes;
        }
    }
}
