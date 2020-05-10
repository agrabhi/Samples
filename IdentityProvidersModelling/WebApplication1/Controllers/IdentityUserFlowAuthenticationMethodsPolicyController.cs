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
    [ODataRoutePrefix("policies/identityUserFlowAuthenticationMethodsPolicy")]
    public class IdentityUserFlowAuthenticationMethodsPolicyController : ODataController
    {
        static List<UserFlowAttribute> userProfileAttributes = new List<UserFlowAttribute>()
        {
            new BuiltInUserProfileAttribute() { Id = "City", DisplayName = "City", DataType = UserFlowAttributeDataType.@string, Description = "your city", UserFlowAttributeType = UserFlowAttributeType.BuiltIn },            
            new CustomUserFlowAttribute() { Id = "extension_guid_shoeSize", DisplayName = "Shoe size", DataType = UserFlowAttributeDataType.@string, Description = "Your shoe size", UserFlowAttributeType = UserFlowAttributeType.Custom },            
        };

        // [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Filter)]
        // public IQueryable<UserFlowAttribute> GetUserProfileAttributes(ODataQueryOptions<UserFlowAttribute> queryOptions)

        [EnableQuery]
        [HttpGet]
        [ODataRoute]        
        public IQueryable<UserFlowAttribute> GetUserProfileAttributes()
        {
            return userProfileAttributes.AsQueryable();
        }

        [EnableQuery]
        [HttpGet]
        [ODataRoute("({id})")]
        public SingleResult<UserFlowAttribute> GetUserProfileAttribute(string id)
        {
            var u = userProfileAttributes.Where(x => x.Id.Equals(id)).Single();
            return SingleResult.Create(new[] { u }.AsQueryable());
            
        }

        [HttpPost]
        [ODataRoute]
        public UserFlowAttribute Create([FromBody] CustomUserFlowAttribute up)
        {
            if (up == null)
            {
                throw new Exception("NULL");
            }

            userProfileAttributes.Add(up);
            return up;
        }

        [HttpPatch]
        [ODataRoute("({id})")]
        public UserFlowAttribute Patch(string id, [FromBody] Delta<CustomUserFlowAttribute> up)
        {
            var u = userProfileAttributes.Where(x => x.Id.Equals(id)).Single();

            up.Patch(u as CustomUserFlowAttribute);

            return u;
        }


    }
}
