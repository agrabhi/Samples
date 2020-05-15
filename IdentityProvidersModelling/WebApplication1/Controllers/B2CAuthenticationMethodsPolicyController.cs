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
    [ODataRoutePrefix("policies/b2cAuthenticationMethodsPolicy")]
    public class B2cAuthenticationMethodsPolicyController : ODataController
    {
        private static B2cAuthenticationMethodsPolicy policy = new B2cAuthenticationMethodsPolicy();

        [EnableQuery]
        [HttpGet]
        [ODataRoute]
        public SingleResult<B2cAuthenticationMethodsPolicy> Get()
        {
            return SingleResult.Create(new[] { policy }.AsQueryable());
        }

        [HttpPatch]
        [ODataRoute]
        public void Patch([FromBody] Delta<B2cAuthenticationMethodsPolicy> up)
        {
            up.Patch(policy);
            
        }
    }
}
