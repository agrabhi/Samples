using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserFlowCustomPasswordComplexity
    {
        public int MinimumLength { get; set; }

        public int MaximumLength { get; set; }

        public bool RestrictToNumbersOnly { get; set; }

        /// <summary>
        /// Indicates how many character classes are required from uppercase, lowercase, number and symbols
        /// Valid values => 0/1 = none, 2, 3, 4
        /// </summary>
        public int MinCharacterClassesRequired { get; set; }
    }
}