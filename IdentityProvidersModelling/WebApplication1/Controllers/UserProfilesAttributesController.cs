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

        [HttpPost]
        [ODataRoute]
        public UserProfileAttribute CreateIdentityProvider(CustomUserProfileAttribute up)
        {
            userProfileAttributes.Add(up);
            return up;
        }


    }
}
