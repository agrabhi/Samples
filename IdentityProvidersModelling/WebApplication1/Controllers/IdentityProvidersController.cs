using Microsoft.AspNet.OData;
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
    [ODataRoutePrefix("identityProviders")]
    public class IdentityProvidersController : ODataController
    {
        static List<IdentityProvider> idps = new List<IdentityProvider>()
        {
            new IdentityProvider() { Name = "MyIdp", ClientId = "sdas", ClientSecret = "sakdjnaskd", Id = "Facebook-OAuth", Type = "Facebook" },
            new CustomIdentityProvider() { Name = "CustomIdp", ClientId = "sdas", ClientSecret = "sakdjnaskd", Id = "Custom-OAuth", Type = "Custom", Protocol = "OIDC" },
        };

        [EnableQuery]
        [HttpGet]
        [ODataRoute]
        public IQueryable<IdentityProvider> GetIdentityProviders()
        {
            return idps.AsQueryable();
        }

        [HttpPost]
        [ODataRoute]
        public IdentityProvider CreateIdentityProvider(IdentityProvider idp)
        {
            idp.Type = idp.GetType().FullName;
            idps.Add(idp);
            return idp;
        }


    }
}
