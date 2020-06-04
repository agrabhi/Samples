using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class AuthenticationSourceFilter
    {
        public ICollection<string> IncludeApplications { get; set; }

        public ICollection<string> ExcludeApplications { get; set; }

        public ICollection<string> IncludeRegions { get; set; }

        public ICollection<string> ExcludeRegions { get; set; }
    }
}