using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class BasicAuthentication : ApiAuthenticationConfigurationBase
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}