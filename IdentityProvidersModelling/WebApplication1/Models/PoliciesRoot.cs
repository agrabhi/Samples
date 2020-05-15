using Microsoft.AspNet.OData.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication1.Models
{
    public class PoliciesRoot
    {
        /// <summary>
        /// Gets or sets Policies's ID. Property is present to make OData libs and Graph happy. Because every object MUST have id.
        /// </summary>
        [IgnoreDataMember]
        public string Id { get; set; }

        [Contained]
        public B2cAuthenticationMethodsPolicy B2cAuthenticationMethodsPolicy { get; set; }
    }
}