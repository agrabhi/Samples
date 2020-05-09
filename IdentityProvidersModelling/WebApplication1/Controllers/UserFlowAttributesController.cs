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
    [ODataRoutePrefix("userFlowAttributes")]
    public class UserFlowAttributesController : ODataController
    {
        static List<UserFlowAttribute> userProfileAttributes = new List<UserFlowAttribute>()
        {
            new BuiltInUserProfileAttribute() { Id = "City", Name = "City", DataType = UserFlowAttributeDataType.String, Description = "your city" },            
            new CustomUserFlowAttribute() { Id = "extension_guid_shoeSize", Name = "Shoe size", DataType = UserFlowAttributeDataType.String, Description = "Your shoe size" },            
        };

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
