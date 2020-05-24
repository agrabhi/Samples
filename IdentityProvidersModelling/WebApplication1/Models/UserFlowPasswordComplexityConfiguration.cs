using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserFlowPasswordComplexityConfiguration
    {
        public UserFlowPasswordComplexityLevel ComplexityLevel { get; set; }

        public UserFlowCustomPasswordComplexity CustomConfiguration { get; set; }
     
    }
}