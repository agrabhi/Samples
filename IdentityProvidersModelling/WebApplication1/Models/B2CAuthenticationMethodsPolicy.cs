using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class B2cAuthenticationMethodsPolicy: PolicyBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationFlowsPolicy"/> class.
        /// </summary>
        public B2cAuthenticationMethodsPolicy()
            : base(
                  id: "b2CAuthenticationMethodsPolicy",
                  description: "b2CAuthenticationMethodsPolicy allows configuration of authentication methods related to Azure AD B2C.",
                  displayName: "Azure AD B2C authentication methods policy")
        {
        }

        public Boolean IsPhoneOneTimePasswordAuthenticationEnabled { get; set; }

        public Boolean IsEmailPasswordAuthenticationEnabled { get; set; }

        public Boolean IsUserNameAuthenticationEnabled { get; set; }
    }
}