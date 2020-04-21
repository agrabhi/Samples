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
    [ODataRoutePrefix("userProfileAttributes")]
    public class UserProfilesAttributesController : ODataController
    {
        static List<UserProfileAttribute> userProfileAttributes = new List<UserProfileAttribute>()
        {
            new BuiltInUserProfileAttribute() { Id = "City", Name = "City", DataType = UserProfileAttributeDataType.String, Description = "your city" },            
            new CustomUserProfileAttribute() { Id = "extension_guid_shoeSize", Name = "Shoe size", DataType = UserProfileAttributeDataType.String, Description = "Your shoe size" },            
        };

        [EnableQuery]
        [HttpGet]
        [ODataRoute]
        public IQueryable<UserProfileAttribute> GetUserProfileAttributes()
        {
            return userProfileAttributes.AsQueryable();
        }

        [EnableQuery]
        [HttpGet]
        [ODataRoute("({id})")]
        public SingleResult<UserProfileAttribute> GetUserProfileAttribute(string id)
        {
            var u = userProfileAttributes.Where(x => x.Id.Equals(id)).Single();
            return SingleResult.Create(new[] { u }.AsQueryable());
            
        }

        [HttpPost]
        [ODataRoute]
        public UserProfileAttribute Create([FromBody] CustomUserProfileAttribute up)
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
        public UserProfileAttribute Patch(string id, [FromBody] Delta<CustomUserProfileAttribute> up)
        {
            var u = userProfileAttributes.Where(x => x.Id.Equals(id)).Single();

            up.Patch(u as CustomUserProfileAttribute);

            return u;
        }


    }
}
