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
    [ODataRoutePrefix("identity/userFlows")]
    public class IdentityUserFlowController : ODataController
    {
        static List<IdentityUserFlow> userFlows = new List<IdentityUserFlow>()
        {
            new B2xIdentityUserFlow()
            {
                Id = "B2X_1_Partner",
                UserFlowType = UserFlowType.B2xSignUpOrSignIn,
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
            },
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
                UserFlowType = UserFlowType.B2cSignUpOrSignIn,
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

        // [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Filter)]
        // public IQueryable<UserFlowAttribute> GetUserProfileAttributes(ODataQueryOptions<UserFlowAttribute> queryOptions)

        [EnableQuery(AllowedQueryOptions=AllowedQueryOptions.Select | AllowedQueryOptions.Expand)]        
        [HttpGet]
        [ODataRoute]
        public IQueryable<IdentityUserFlow> List()
        {
            return userFlows.AsQueryable();
        }

        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select | AllowedQueryOptions.Expand)]
        [HttpGet]
        [ODataRoute("({id})")]
        public SingleResult<IdentityUserFlow> Get(string id)
        {
            var u = userFlows.Where(x => x.Id.Equals(id)).Single();
            return SingleResult.Create(new[] { u }.AsQueryable());

        }

        [HttpPost]
        [ODataRoute]
        public IdentityUserFlow Create([FromBody] IdentityUserFlow up)
        {
            if (up == null)
            {
                throw new Exception("NULL");
            }

            userFlows.Add(up);
            return up;
        }

        [HttpPatch]
        [ODataRoute("({id})")]
        public IdentityUserFlow Patch(string id, [FromBody] Delta<CustomUserFlowAttribute> up)
        {
            //var u = userFlows.Where(x => x.Id.Equals(id)).Single();

            //up.Patch(u as CustomUserFlowAttribute);

            //return u;

            return null;
        }


    }
}
