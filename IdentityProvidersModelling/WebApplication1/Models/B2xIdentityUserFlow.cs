using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Query;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class B2xIdentityUserFlow: IdentityUserFlow
    {
        //[AutoExpand]
        [Expand]
        [Select]
        public ICollection<IdentityProvider> IdentityProviders { get; set; }

        public ICollection<UserFlowAttribute> UserAttributes { get; set; }
    }
}