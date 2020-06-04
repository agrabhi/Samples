using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ODataRoutePrefix("identity/events")]
    public class AuthenticationEventsConfigurationPolicyController : ODataController
    {
        public static List<AuthenticationEventsConfigurationPolicy> events = new List<AuthenticationEventsConfigurationPolicy>()
        {
            new AuthenticationEventsConfigurationPolicy() 
            {
                Id = "4594600a-3fac-483d-9d71-fc3260f6a809",
                OnSignup = new List<InvokableAction>()
                {
                    new InvokableUserFlowAction()
                    {
                        Priority = 100,
                        Filter = new AuthenticationSourceFilter() { IncludeApplications = new List<string>() { Guid.NewGuid().ToString() } },
                        UserFlowToInvoke = new B2xIdentityUserFlowController().List().First()
                    }
                }
            }
        };

        [HttpGet]
        [ODataRoute]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Expand)]
        public IQueryable<AuthenticationEventsConfigurationPolicy> List()
        {
            return events.AsQueryable();
        }

        [HttpGet]
        [ODataRoute("({id})")]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Expand)]
        public SingleResult<AuthenticationEventsConfigurationPolicy> Get(string id)
        {
            var e = events.Where(x => x.Id.Equals(id)).Single();
            return SingleResult.Create(new[] { e }.AsQueryable());
        }

        [HttpPost]
        [ODataRoute]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Expand)]
        public IHttpActionResult Create([FromBody] AuthenticationEventsConfigurationPolicy ev)
        {
            if (ev == null)
            {
                throw new Exception("NULL");
            }

            if (!string.IsNullOrEmpty(ev.Id))
            {
                throw new Exception("Id should not be supplied. It is auto-generated.");
            }

            ev.Id = Guid.NewGuid().ToString();
            events.Add(ev);
            return this.Created(ev);
        }

        [HttpPatch]
        [ODataRoute("({id})")]
        public void Patch(string id, [FromBody] Delta<AuthenticationEventsConfigurationPolicy> delta)
        {
            if (!events.Any(x => x.Id.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                throw new HttpException((int) HttpStatusCode.NotFound, "Not found");
            }

            var original = events.Where(x => x.Id.Equals(id, StringComparison.OrdinalIgnoreCase)).Single();

            delta.Patch(original);
        }

        [HttpDelete]
        [ODataRoute("({id})")]
        public void Delete(string id)
        {
            if (!events.Any(x => x.Id.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                throw new HttpException((int)HttpStatusCode.NotFound, "Not found");
            }

            events.Remove(events.First(x => x.Id.Equals(id, StringComparison.OrdinalIgnoreCase)));
        }
    }
}
