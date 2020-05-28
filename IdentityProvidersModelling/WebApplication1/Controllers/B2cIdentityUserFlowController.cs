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
    [ODataRoutePrefix("identity/b2cUserFlows")]
    public class B2cIdentityUserFlowController : ODataController
    {
        static List<B2cIdentityUserFlow> userFlows = new List<B2cIdentityUserFlow>()
        {
            new B2cIdentityUserFlow()
            {
                Id = "B2C_1_Consumer",
                IsMultifactorAuthenticationEnabled = false,
                AuthenticationMethods = B2cAuthenticationMethods.EmailWithPassword,
                PasswordComplexityConfiguration = new UserFlowPasswordComplexityConfiguration()
                {
                    ComplexityLevel = UserFlowPasswordComplexityLevel.Simple
                },
                SingleSignOnSessionConfiguration = new UserFlowSingleSignOnSessionConfiguration()
                {
                    EnforceIdTokenHintOnLogout = true,
                    IsSessionLifetimeAbsolute = true,
                    SessionLifetimeInMinutes = 120,
                    SessionScope = UserFlowSingleSignOnConfigurationScope.Policy,
                },
                TokenClaimsConfiguration = new UserFlowTokenClaimsConfiguration()
                {
                    IsIssuerEntityUserFlow = true,
                    IsSubjectClaimSupported = true,
                    ClaimTypeForUserFlowId = "acr",
                },
                TokenLifetimeConfiguration = new UserFlowTokenLifetimeConfiguration()
                {
                    AccessAndIdTokenLifetimeInMinutes = 120,
                    RefreshTokenLifetimeInDays = 120,
                    RollingRefreshTokenLifetimeInDays = -1,
                },
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
                },
                ApplicationClaims = new List<UserFlowAttribute>()
                {
                    new BuiltInUserProfileAttribute() { Id = "City", DisplayName = "City", DataType = UserFlowAttributeDataType.@string, Description = "your city", UserFlowAttributeType = UserFlowAttributeType.BuiltIn },                    
                }
            }
        };

        [EnableQuery(AllowedQueryOptions=AllowedQueryOptions.Select | AllowedQueryOptions.Expand)]        
        [HttpGet]
        [ODataRoute]
        public IQueryable<B2cIdentityUserFlow> List()
        {
            return userFlows.AsQueryable();
        }

        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select | AllowedQueryOptions.Expand)]
        [HttpGet]
        [ODataRoute("({id})")]
        public SingleResult<B2cIdentityUserFlow> Get(string id)
        {
            var u = userFlows.Where(x => x.Id.Equals(id)).Single();
            return SingleResult.Create(new[] { u }.AsQueryable());

        }

        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select | AllowedQueryOptions.Expand)]
        [HttpGet]
        [ODataRoute("({id})/identityProviders")]
        public IQueryable<IdentityProvider> GetIdentityProviders(string id)
        {
            var u = userFlows.Where(x => x.Id.Equals(id)).Single();
            return u.IdentityProviders.AsQueryable();
        }

        [HttpPost]
        [ODataRoute("({id})/identityProviders/$ref")]
        public IHttpActionResult AddIdentityProviders([FromODataUri] string id, [FromBody] Uri link)
        {
            var u = userFlows.Where(x => x.Id.Equals(id)).Single();
            if (u == null)
            {
                return NotFound();
            }
            
            var relatedKey = Helpers.GetKeyFromUri<string>(Request, link);
            var idp = IdentityProvidersController.idps.First(X => X.Id.Equals(relatedKey));
            if (idp == null)
            {
                return NotFound();
            }

            u.IdentityProviders.Add(idp);
            
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [ODataRoute("({id})/identityProviders({identityProviderId})/$ref")]
        public IHttpActionResult DeleteIdentityProviders([FromODataUri] string id, [FromODataUri] string identityProviderId)
        {
            var u = userFlows.Where(x => x.Id.Equals(id)).Single();
            if (u == null)
            {
                return NotFound();
            }
            
            u.IdentityProviders.Remove(u.IdentityProviders.First(x => x.Id.Equals(identityProviderId)));
            
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [ODataRoute]
        public B2cIdentityUserFlow Create([FromBody] B2cIdentityUserFlow up)
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
        //public B2cIdentityUserFlow CreateB2C([FromBody] B2cIdentityUserFlow up)
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
        public B2cIdentityUserFlow Patch(string id, [FromBody] Delta<B2cIdentityUserFlow> delta)
        {
            var original = userFlows.Where(x => x.Id.Equals(id, StringComparison.OrdinalIgnoreCase)).Single();

            delta.Patch(original);

            return original;
        }


    }
}
