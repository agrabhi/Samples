using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class B2xIdentityUserFlow: IdentityUserFlow
    {
        public ICollection<IdentityProvider> IdentityProviders { get; set; }

        public ICollection<UserFlowAttribute> UserAttributes { get; set; }
    }
}