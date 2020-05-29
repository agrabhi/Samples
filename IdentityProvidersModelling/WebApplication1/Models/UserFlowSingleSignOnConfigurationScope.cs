using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication1.Models
{
    public enum UserFlowSingleSignOnConfigurationScope
    {
        [EnumMember(Value = "tenant")]
        Tenant = 1,

        [EnumMember(Value = "application")]
        Application = 2,

        [EnumMember(Value = "policy")]
        Policy = 3,

        [EnumMember(Value = "disabled")]
        Disabled = 4,
    }
}