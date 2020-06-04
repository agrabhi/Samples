using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class ClientCertificateAuthentication : ApiAuthenticationConfigurationBase
    {
        public ICollection<Pkcs12CertificateInformation> CertificateList { get; set; }
    }
}