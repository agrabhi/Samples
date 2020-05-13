using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ODataRoutePrefix("policies/userFlowAuthenticationMethodsPolicy")]
    public class UserFlowAuthenticationMethodsPolicyController : ODataController
    {
        private static UserFlowAuthenticationMethodsPolicy policy = new UserFlowAuthenticationMethodsPolicy();

        [EnableQuery]
        [HttpGet]
        [ODataRoute]
        public SingleResult<UserFlowAuthenticationMethodsPolicy> GetUserProfileAttribute()
        {
            return SingleResult.Create(new[] { policy }.AsQueryable());
        }

        [HttpPatch]
        [ODataRoute]
        public void Patch([FromBody] Delta<UserFlowAuthenticationMethodsPolicy> up)
        {
            up.Patch(policy);
            
        }
    }
}
