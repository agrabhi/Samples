using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class B2xIdentityUserFlow: IdentityUserFlow
    {
        public UserFlowOtherTenantsSignUpConfiguration OtherTenantsSignUpConfiguration { get; set; }

        public ICollection<IdentityProvider> IdentityProviders { get; set; }

        public ICollection<UserFlowAttribute> UserAttributes { get; set; }
    }
}