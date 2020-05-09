using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public abstract class UserFlowAttribute
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public UserFlowAttributeDataType DataType { get; set; }
    }
}