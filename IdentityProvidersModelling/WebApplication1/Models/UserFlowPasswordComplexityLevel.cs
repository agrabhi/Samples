using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication1.Models
{
    public enum UserFlowPasswordComplexityLevel
    {
        [EnumMember(Value = "simple")]
        Simple = 1,

        [EnumMember(Value = "strong")]
        Strong = 2,
        
        [EnumMember(Value = "custom")]
        Custom = 3,

        [EnumMember(Value = "legacy")]
        Legacy = 4,
    }
}