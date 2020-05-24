namespace WebApplication1.Models
{
    public class B2cIdentityUserFlow: IdentityUserFlow
    {
        public bool IsMultifactorAuthenticationEnabled { get; set; }

        /// <summary>
        /// Gets or sets the Token Lifetime configuration
        /// </summary>
        public TokenLifetimeConfiguration TokenLifetimeConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the SSO session configuration
        /// </summary>
        public SingleSignOnSessionConfiguration SingleSignOnSessionConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the claims configuration that specifies the values sent in the token.
        /// </summary>
        public TokenClaimsConfiguration TokenClaimsConfiguration { get; set; }


    }
}