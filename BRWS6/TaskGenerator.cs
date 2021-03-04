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
    public static class TaskGenerator
    {
        public static IO.Swagger.Model.Task GetFlatTask()
        {
            Guid g = Guid.NewGuid();
            string suffix = g.ToString().Replace('-', '_');
            //get a context
            //TasksApi tasksApi = new TasksApi(url);
            IO.Swagger.Model.Task task = new IO.Swagger.Model.Task( Name: "BRFlatTask" + suffix,
                                                                    Description: "A task with one row",
                                                                    StateName: "pending",
                                                                    ElementTypeName: "ResultTask",
                                                                    ProcessPath: "main/flat:1",
                                                                    MembershipPath: "all/support",
                                                                    StartedAt: new DateTime(2025, 4, 4),
                                                                    ExpectedAt: new DateTime(2026, 6, 4),
                                                                    CustomProperties: null,
                                                                    Rows: null
                                                                    );
            task.Rows = GetFlatRows();
            return task;
        }

        private static TaskRowArray GetFlatRows()
        {
            //build rows
            Dictionary<string, string> vals = new Dictionary<string, string>();
            vals.Add("batch", "ED10-1:1");
            vals.Add("conc", "10 mM");
            TaskRow row = new TaskRow(Label: "top.1",
                                      Parent: null,
                                      Values: vals
                                      );
            TaskRowArray rows = new TaskRowArray { row };
            return rows;
        }

        public static IO.Swagger.Model.Task GetHierarchicalTask()
        {
            Guid g = Guid.NewGuid();
            string suffix = g.ToString().Replace('-', '_');
            //get a context
            //TasksApi tasksApi = new TasksApi(url);
            IO.Swagger.Model.Task task = new IO.Swagger.Model.Task( Name: "BRHierTask" + suffix,
                                                                    Description: "A task with more than one row",
                                                                    StateName: "pending",
                                                                    ElementTypeName: "ResultTask",
                                                                    ProcessPath: "main/tree:1",
                                                                    MembershipPath: "all/support",
                                                                    StartedAt: new DateTime(2025, 4, 4),
                                                                    ExpectedAt: new DateTime(2026, 6, 4),
                                                                    CustomProperties: null,
                                                                    Rows: null
                                                                    );

            task.Rows = GetHierRows();
            return task;
        }
        private static TaskRowArray GetHierRows()
        {
            //build rows
            Dictionary<string, string> top1 = new Dictionary<string, string>();
            top1.Add("a", "21");
            top1.Add("b", "22");
            Dictionary<string, string> child11 = new Dictionary<string, string>();
            child11.Add("batch", "ED10-1:1");
            child11.Add("conc", "10");
            Dictionary<string, string> child12 = new Dictionary<string, string>();
            child12.Add("batch", "ED10-1:1");
            child12.Add("conc", "20");
            Dictionary<string, string> child13 = new Dictionary<string, string>();
            child13.Add("batch", "ED10-1:1");
            child13.Add("conc", "20");
            TaskRow row_top1 = new TaskRow(
                    "top.1",
                    null,
                    top1
            );
            TaskRow row_child11 = new TaskRow(
                    "well.1.1",
                    null,
                    child11
            );
            TaskRow row_child12 = new TaskRow(
                    "well.1.2",
                    null,
                    child12
            );
            TaskRow row_child13 = new TaskRow(
                    "well.1.3",
                    null,
                    child13
            );
            
            TaskRowArray rows = new TaskRowArray { row_top1, row_child11, row_child12, row_child13 };
            return rows;
        }
    }
}
