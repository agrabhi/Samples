using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserFlowTokenClaimsConfiguration
    {
        /// <summary>
        /// Gets or sets the issuer claim .
        /// </summary>
        /// <value>
        /// Set if the issuer claim is tenant specific or user flow specific         /// 
        /// </value>
        public bool DoesIssuerClaimhasUserFlow { get; set; }

        public bool UseTfpClaimForUserFlow { get; set; }

        public bool UseAcrClaimForUserFlow { get; set; }

        /// <summary>
        /// If yes, it will have objectId
        /// </summary>
        public bool IsSubjectClaimSupported{ get; set; }
    }
}