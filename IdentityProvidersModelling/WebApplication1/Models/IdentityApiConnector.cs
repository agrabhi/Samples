using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class IdentityApiConnector
    {
        public string Id { get; set; }

        public string DisplayName { get; set; }

        public string TargetUrl { get; set; }

        public ApiAuthenticationConfigurationBase AuthenticationConfiguration { get; set; }

        public ICollection<ApiParameter> RequestParameters { get; set; }

        public ICollection<ApiParameter> ResponseParameters { get; set; }
    }
}