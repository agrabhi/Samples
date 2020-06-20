using Microsoft.AspNet.OData.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserFlowApiConnectorConfiguration
    {
        [Contained]
        public IdentityApiConnector PostFederation { get; set; }

        [Contained]
        public IdentityApiConnector PostAttributeCollection { get; set; }
    }
}