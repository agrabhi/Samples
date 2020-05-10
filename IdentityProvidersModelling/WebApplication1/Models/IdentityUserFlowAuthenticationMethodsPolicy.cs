using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class IdentityUserFlowAuthenticationMethodsPolicy: PolicyBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationFlowsPolicy"/> class.
        /// </summary>
        public IdentityUserFlowAuthenticationMethodsPolicy()
            : base(
                  id: "identityUserFlowAuthenticationMethodsPolicy",
                  description: "IdentityUserFlowAuthenticationMethodsPolicy allows configuration of authentication methods related to user flows.",
                  displayName: "User flow authentication methods policy")
        {
        }

        public Boolean PhoneOneTimePasswordAuthenticationEnabled { get; set; }

        public Boolean EmailPasswordAuthenticationEnabled { get; set; }

        public Boolean UserNameAuthenticationEnabled { get; set; }
    }
}