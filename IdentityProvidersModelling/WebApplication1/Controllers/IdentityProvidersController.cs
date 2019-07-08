using Microsoft.AspNet.OData;
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
    [RoutePrefix("identityProviders")]
    public class IdentityProvidersController : ODataController
    {
        static List<IdentityProvider> idps = new List<IdentityProvider>()
        {
            new IdentityProvider() { Name = "MyIdp", ClientId = "sdas", ClientSecret = "sakdjnaskd", Id = "Facebook-OAuth", Type = "Facebook" },
            new LocalIdentityProvider() { Name = "localIdp", Id = "Phone-OAuth", Type = "LocalAccountPhone" },
            new CustomIdentityProvider() { Name = "CustomIdp", ClientId = "sdas", ClientSecret = "sakdjnaskd", Id = "Custom-OAuth", Type = "Custom", Protocol = "OIDC" },
        };

        [EnableQuery]
        [HttpGet]
        [Route]
        public IQueryable<IdentityProvider> ListIdentityProviders()
        {
            return idps.AsQueryable();
        }



    }
}
