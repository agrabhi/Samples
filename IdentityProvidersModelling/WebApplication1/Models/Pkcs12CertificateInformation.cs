namespace WebApplication1.Models
{
    public class Pkcs12CertificateInformation
    {
        public bool IsActive { get; set; }

        public string Thumbprint { get; set; }

        public long NotAfter { get; set; }

        public long NotBefore { get; set; }
    }
}