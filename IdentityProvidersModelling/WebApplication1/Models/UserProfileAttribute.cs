using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public abstract class UserProfileAttribute
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public UserProfileAttributeDataType DataType { get; set; }
    }
}