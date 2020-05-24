namespace WebApplication1.Models
{
    public class B2cIdentityUserFlow: IdentityUserFlow
    {
        public bool IsMultifactorAuthenticationEnabled { get; set; }

        public TokenLifetimeConfiguration TokenLifetimeConfiguration { get; set; }

        public UserFlowSingleSignOnSessionConfiguration SingleSignOnSessionConfiguration { get; set; }

        public UserFlowTokenClaimsConfiguration TokenClaimsConfiguration { get; set; }


    }
}