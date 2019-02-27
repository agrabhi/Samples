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
    public class TrustframeworkPoliciesController : ApiController
    {
        List<TrustframeworkPolicy> policies = new List<TrustframeworkPolicy>()
        {
            new TrustframeworkPolicy(){ Id = "1" },
            new TrustframeworkPolicy(){ Id = "2" },
        };

        public IQueryable<TrustframeworkPolicy> GetPolicies()
        {
            return policies.AsQueryable();
        }
    }
}
