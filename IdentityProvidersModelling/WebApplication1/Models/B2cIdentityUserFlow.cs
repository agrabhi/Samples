using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class B2cIdentityUserFlow: IdentityUserFlow
    {
        public bool IsMultifactorAuthenticationEnabled { get; set; }

        public UserFlowTokenLifetimeConfiguration TokenLifetimeConfiguration { get; set; }

        public UserFlowSingleSignOnSessionConfiguration SingleSignOnSessionConfiguration { get; set; }

        public UserFlowTokenClaimsConfiguration TokenClaimsConfiguration { get; set; }

        public UserFlowPasswordComplexityConfiguration PasswordComplexityConfiguration { get; set; }

        public ICollection<IdentityProvider> IdentityProviders { get; set; }

        public B2cAuthenticationMethods AuthenticationMethods { get; set; }

        public ICollection<UserFlowAttribute> UserAttributes { get; set; }

        public ICollection<UserFlowAttribute> ApplicationClaims { get; set; }

        public UserFlowApiConnectorConfiguration ApiConnectorConfiguration { get; set; }
    }
}