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
    public static class RequestGenerator
    {
        public static Request GetSimpleRequest()
        {
            Guid g = Guid.NewGuid();
            string suffix = g.ToString().Replace('-', '_');
            DateTime started_at = DateTime.Now;
            DateTime expected_at = DateTime.Now + new TimeSpan(14);
            //get a context
            //TasksApi tasksApi = new TasksApi(url);
            Request request = new Request(Name: "BRReq" + suffix,
                                          Description: "this is a description",
                                          ElementTypeName: "Request",
                                          DataElementPath: "/Root/Inventory/Sample Types/Batch",
                                          MembershipPath: "all/dana scully",
                                          ExpectedAt: expected_at,
                                          StartedAt: started_at,
                                          PriorityName: "medium",
                                          QueueItems: null,
                                          CustomProperties: null
                                          );

            request.QueueItems = new QueueItemArray { GetQueueItem() };
            return request;
        }

        public static QueueItem GetQueueItem()
        {
            //get a context
            QueueItem queueItem = new QueueItem(
                                                 Id: null,
                                                 ProcessVersionPath: "services/service_a_in:1",
                                                 OutlineMethodPath: "services/method_a",
                                                 DataName: "ED10-1:1",
                                                 StateName: "pending",
                                                 StockOnHand: false,
                                                 Comments: "queue item comment",
                                                 OrderRef: null,
                                                 ExternalRefId: null,
                                                 ExternalRefType: null,
                                                 Properties: null
                                               );
            //Note if we wanted to set properties we would do it like this
            //new Dictionary<string, string> { { "conc", "10 mM" } }
                
            return queueItem;

        }
    }
}
