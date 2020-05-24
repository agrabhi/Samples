using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserFlowSingleSignOnSessionConfiguration
    {
        public int SessionLifetimeInMinutes { get; set; }

        public bool IsSessionLifetimeAbsolute { get; set; }

        public UserFlowSingleSignOnConfigurationScope SessionScope { get; set; }

        public bool EnforceIdTokenHintOnLogout { get; set; }
    }
}