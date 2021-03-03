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
            //orderNum: 31, productName: "Red Mug", sellerName: "Gift Shop"
            OutlineParameter outlineParameter = new OutlineParameter(Id: null, 
                                                                     Name: "amount" + System.DateTime.Now.ToString("g", CultureInfo.CreateSpecificCulture("en-US")).Replace('/', '_').Replace(':', '_').Replace(' ', '_'), 
                                                                     Path: null, 
                                                                     Description: "amount" + System.DateTime.Now.ToString("g", CultureInfo.CreateSpecificCulture("en-US")).Replace('/', '_').Replace(':', '_').Replace(' ', '_'), 
                                                                     ParameterTypeName: palias.ParameterTypeName, 
                                                                     ParameterRoleName: palias.ParameterRoleName, 
                                                                     DataTypeName: palias.DataTypeName, 
                                                                     DataFormatName: palias.DataFormatName, 
                                                                     DataElementPath: null, 
                                                                     DisplayUnit: null);

            return outlineParameter;
    
        }
    }
}
