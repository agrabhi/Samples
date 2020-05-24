using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public enum UserFlowPasswordComplexityLevel
    {
        Simple = 1,

        Strong = 2,

        Custom = 3,

        Legacy = 4,
    }
}