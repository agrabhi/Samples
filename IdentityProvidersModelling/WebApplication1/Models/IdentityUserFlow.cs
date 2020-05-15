namespace WebApplication1.Models
{
    public class IdentityUserFlow
    {
        /// <summary>
        /// Gets or sets The unique identifier of the IdentityUserFlow. 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the Type 
        /// </summary>
        public UserFlowType UserFlowType { get; set; }

        /// <summary>
        /// Gets or sets the version of the user flow type 
        /// </summary>
        public float UserFlowTypeVersion { get; set; }

        public B2CAuthenticationMethods AuthenticationMethods { get; set; }
    }
}