using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public enum UserFlowSingleSignOnConfigurationScope
    {
        Tenant = 1,

        Application = 2,

        Policy = 3,

        Disabled = 4,
    }
}