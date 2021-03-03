using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace BRWS6
{
    public static class ParameterGenerator
    {
        public static OutlineParameter GetOneSimpleParameter(string url, string sessionid)
        {
            CatalogueApi catalogueApi = new CatalogueApi(url);
            ParameterTypeAliasArray aliases = catalogueApi.CatalogueParameters(sessionid);
            ParameterTypeAlias palias = aliases[0];
            Guid g = Guid.NewGuid();
            //orderNum: 31, productName: "Red Mug", sellerName: "Gift Shop"
            OutlineParameter outlineParameter = new OutlineParameter(Id: null, 
                                                                     Name: "amount" + g.ToString().Replace('-','_'), 
                                                                     Path: null, 
                                                                     Description: "amount" + g.ToString().Replace('-', '_'), 
                                                                     ParameterTypeName: palias.ParameterTypeName, 
                                                                     ParameterRoleName: palias.ParameterRoleName, 
                                                                     DataTypeName: palias.DataTypeName, 
                                                                     DataFormatName: palias.DataFormatName, 
                                                                     DataElementPath: null, 
                                                                     DisplayUnit: null);

            return outlineParameter;
    
        }

        public static ProcessParameterArray GetSomeProcessParams(string url, string sessionid)
        {
            Guid g = Guid.NewGuid();
            string suffix = g.ToString().Replace('-', '_');
            ProcessParameterArray parameters = new ProcessParameterArray();
            ProcessParameter param1 = new ProcessParameter(
                                                            Name: "Batch" + suffix,
                                                            Description: "a description",
                                                            ContextLabel: "top",
                                                            OutlineParameterName: "batch",
                                                            DisplayUnit: null,
                                                            Mandatory: true
                                                          );
            ProcessParameter param2 = new ProcessParameter(
                                                            Name: "Conc" + suffix,
                                                            Description: "a description",
                                                            ContextLabel: "top",
                                                            OutlineParameterName: "conc",
                                                            DisplayUnit: null,
                                                            Mandatory: true
                                                          );
            parameters.Add(param1);
            parameters.Add(param2);
            return parameters;

        }
    }
}
