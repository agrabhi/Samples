namespace WebApplication1.Models
{
    public class Pkcs12Certificate : ApiAuthenticationConfigurationBase
    {
        public string Password { get; set; }

        public string Pkcs12Value { get; set; }
    }
}