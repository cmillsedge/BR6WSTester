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
    public class FilterGenerator
    {
        public static FilterArray SimpleFilter(string field, string op, string val)
        {
            Filter filter = new Filter(field, op, new List<string>() { val });
            FilterArray filters = new FilterArray { filter };
            return filters;
        }
    }
}
