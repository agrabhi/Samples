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
using WebApplication1.Utils;

namespace WebApplication1.Controllers
{
    [ODataRoutePrefix("identity/b2xUserFlows")]
    public class B2xIdentityUserFlowController : ODataController
    {
        static List<B2xIdentityUserFlow> userFlows = new List<B2xIdentityUserFlow>()
        {
            new B2xIdentityUserFlow()
            {
                Id = "B2X_1_Partner",
                UserFlowType = UserFlowType.SignUpOrSignIn,
                UserFlowTypeVersion = 1F,
                IdentityProviders = new List<IdentityProvider>()
                {
                    new IdentityProvider() { Name = "MyIdp", ClientId = "sdas", ClientSecret = "****", Id = "Facebook-OAuth", Type = "Facebook" },
                },
                UserAttributes = new List<UserFlowAttribute>()
                {
                    new BuiltInUserProfileAttribute() { Id = "City", DisplayName = "City", DataType = UserFlowAttributeDataType.@string, Description = "your city", UserFlowAttributeType = UserFlowAttributeType.BuiltIn },
                    new CustomUserFlowAttribute() { Id = "extension_guid_shoeSize", DisplayName = "Shoe size", DataType = UserFlowAttributeDataType.@string, Description = "Your shoe size", UserFlowAttributeType = UserFlowAttributeType.Custom },
                }
            }           
        };

        [EnableQuery(AllowedQueryOptions=AllowedQueryOptions.Select | AllowedQueryOptions.Expand)]        
        [HttpGet]
        [ODataRoute]
        public IQueryable<B2xIdentityUserFlow> List()
        {
            return userFlows.AsQueryable();
        }

        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select | AllowedQueryOptions.Expand)]
        [HttpGet]
        [ODataRoute("({id})")]
        public SingleResult<B2xIdentityUserFlow> Get(string id)
        {
            var u = userFlows.Where(x => x.Id.Equals(id)).Single();
            return SingleResult.Create(new[] { u }.AsQueryable());

        }

        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select | AllowedQueryOptions.Expand)]
        [HttpGet]
        [ODataRoute("({id})/Microsoft.Graph.B2cIdentityUserFlow/identityProviders")]
        [ODataRoute("({id})/Microsoft.Graph.B2xIdentityUserFlow/identityProviders")]
        public IQueryable<IdentityProvider> GetIdentityProviders(string id)
        {
            var u = userFlows.Where(x => x.Id.Equals(id)).Single();
            var up =  u as B2xIdentityUserFlow;

            if (up != null)
                return up.IdentityProviders.AsQueryable();

            var upc = u as B2cIdentityUserFlow;
            return upc.IdentityProviders.AsQueryable();
        }

        [HttpPost]
        [ODataRoute("({id})/Microsoft.Graph.b2cIdentityUserFlow/identityProviders/$ref")]
        [ODataRoute("({id})/Microsoft.Graph.b2xIdentityUserFlow/identityProviders/$ref")]
        public IHttpActionResult AddIdentityProviders([FromODataUri] string id, [FromBody] Uri link)
        {
            var u = userFlows.Where(x => x.Id.Equals(id)).Single();
            if (u == null)
            {
                return NotFound();
            }
            var up = u as B2xIdentityUserFlow;
            var upc = u as B2cIdentityUserFlow;

            var relatedKey = Helpers.GetKeyFromUri<string>(Request, link);
            var idp = IdentityProvidersController.idps.First(X => X.Id.Equals(relatedKey));
            if (idp == null)
            {
                return NotFound();
            }

            up?.IdentityProviders.Add(idp);
            upc?.IdentityProviders.Add(idp);


            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [ODataRoute("({id})/Microsoft.Graph.B2cIdentityUserFlow/identityProviders({identityProviderId})/$ref")]
        [ODataRoute("({id})/Microsoft.Graph.B2xIdentityUserFlow/identityProviders({identityProviderId})/$ref")]
        public IHttpActionResult DeleteIdentityProviders([FromODataUri] string id, [FromODataUri] string identityProviderId)
        {
            var u = userFlows.Where(x => x.Id.Equals(id)).Single();
            if (u == null)
            {
                return NotFound();
            }
            var up = u as B2xIdentityUserFlow;
            var upc = u as B2cIdentityUserFlow;

            up?.IdentityProviders.Remove(up?.IdentityProviders.First(x => x.Id.Equals(identityProviderId)));
            upc?.IdentityProviders.Remove(upc?.IdentityProviders.First(x => x.Id.Equals(identityProviderId)));
            
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [ODataRoute]
        public B2xIdentityUserFlow Create([FromBody] B2xIdentityUserFlow up)
        {
            if (up == null)
            {
                throw new Exception("NULL");
            }

            if (userFlows.Any(x => x.Id.Equals(up.Id, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception("Duplicate");
            }

            userFlows.Add(up);
            return up;
        }

        //[HttpPost]
        //[ODataRoute]
        //public B2xIdentityUserFlow CreateB2C([FromBody] B2cIdentityUserFlow up)
        //{
        //    if (up == null)
        //    {
        //        throw new Exception("NULL");
        //    }

        //    userFlows.Add(up);
        //    return up;
        //}

        [HttpPatch]
        [ODataRoute("({id})")]
        public B2xIdentityUserFlow Patch(string id, [FromBody] Delta<B2xIdentityUserFlow> delta)
        {
            var original = userFlows.Where(x => x.Id.Equals(id, StringComparison.OrdinalIgnoreCase)).Single();

            delta.Patch(original);

            return original;
        }


    }
}
