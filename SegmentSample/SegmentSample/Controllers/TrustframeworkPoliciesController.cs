using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using SegmentSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SegmentSample.Controllers
{
    [ODataRoutePrefix("trustframework/Policies")]
    [ODataRoutePrefix("trustframeworkPolicies")]
    public class TrustframeworkPoliciesController : ODataController
    {
        List<TrustframeworkPolicy> policies = new List<TrustframeworkPolicy>()
        {
            new TrustframeworkPolicy(){ Id = "1" },
            new TrustframeworkPolicy(){ Id = "2" },
        };

        [ODataRoute]
        public IQueryable<TrustframeworkPolicy> GetPolicies()
        {
            return policies.AsQueryable();
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("({id})")]
        public SingleResult<TrustframeworkPolicy> GetPolicy(string id)
        {
            TrustframeworkPolicy trustframeworkPolicy = new TrustframeworkPolicy() { Id = id };

            return SingleResult.Create(new[] { trustframeworkPolicy }.AsQueryable());
        }

        [HttpPost]
        [ODataRoute("({id})/restore")]
        public IHttpActionResult Restore([FromODataUri] string id, ODataActionParameters odataparams)
        {
            return StatusCode(HttpStatusCode.OK);
        }


    }
}
