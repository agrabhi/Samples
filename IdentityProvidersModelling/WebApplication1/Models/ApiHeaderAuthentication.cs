using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class ApiHeaderAuthentication : ApiAuthenticationConfigurationBase
    {
        public ICollection<ApiHeaderKeyValue> HeaderList { get; set; }
    }
}