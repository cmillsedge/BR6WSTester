using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO.Swagger.Api;

namespace BRWS6
{
    public static class SessionOperations
    {
        public static void RefreshSession(string url, string sessionid)
        {
            //if the tests take a long time to run we want to avoid a timeout. This method will do that
            SessionsApi s = new SessionsApi(url);
            s.Refresh(sessionid);
        }
    }
}
