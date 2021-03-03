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
    public static class ProcessGenerator
    {
        public static Process GetASimpleProcess(string url, string sessionid)
        {
            Guid g = Guid.NewGuid();
            string suffix = g.ToString().Replace('-', '_');
            //get a context
            ParameterContextArray contexts = new ParameterContextArray {new ParameterContext("top") };
            //get params
            ProcessParameterArray parameters = ParameterGenerator.GetSomeProcessParams(url, sessionid);
            //build process
            Process proc = new Process(Name: "SimpleProcess" + suffix,
                                       Description: "a description",
                                       ElementTypeName: "ProcessDefinition",
                                       StateName: "pending",
                                       MethodUsage: "optional",
                                       IsValidUsage: "optional",
                                       OutputStyle: "sheet",
                                       CustomProperties: null,
                                       Parameters: parameters,
                                       Steps: null,
                                       Contexts: contexts,
                                       Rows: null);


            //ProcessParameterArray
            return proc;
        }

    }
}
