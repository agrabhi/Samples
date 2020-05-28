using System.Runtime.Serialization;

namespace WebApplication1.Models
{
    /// <summary>
    /// Userflow types
    /// </summary>
    [DataContract(Name = "UserFlowType")]
    public enum UserFlowType
    {
        /// <summary>
        /// The SignUp Policy
        /// </summary>
        [EnumMember(Value = "SignUp")]
        SignUp = 1,

        /// <summary>
        /// The SignIn Policy
        /// </summary>
        [EnumMember(Value = "SignIn")]
        SignIn = 2,

        /// <summary>
        /// The SignupOrSignIn policy
        /// </summary>
        [EnumMember(Value = "SignUpOrSignIn")]
        SignUpOrSignIn = 3,

        /// <summary>
        /// The PasswordReset policy
        /// </summary>
        [EnumMember(Value = "PasswordReset")]
        PasswordReset = 4,

        /// <summary>
        /// The ProfileUpdate policy
        /// </summary>
        [EnumMember(Value = "ProfileUpdate")]
        ProfileUpdate = 5,

        /// <summary>
        /// The Resource owner policy
        /// </summary>
        [EnumMember(Value = "ResourceOwnerPasswordCredentialSignIn")]
        ResourceOwnerPasswordCredentialSignIn = 6,

        /// <summary>
        /// Marker for non-exposed types
        /// </summary>
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue = 8,
    }

}