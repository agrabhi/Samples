using Microsoft.AspNet.OData.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class IdentityContainer
    {
        /// <summary>
        /// Gets or sets IdentityContainer's ID. Property is present to make OData libs and Graph happy. Because every object MUST have id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the user flows.
        /// </summary>
        [Contained]
        public List<IdentityUserFlow> UserFlows { get; set; }
    }
}