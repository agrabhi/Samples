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
        [EnumMember(Value = "signUp")]
        SignUp = 1,

        /// <summary>
        /// The SignIn Policy
        /// </summary>
        [EnumMember(Value = "signIn")]
        SignIn = 2,

        /// <summary>
        /// The SignupOrSignIn policy
        /// </summary>
        [EnumMember(Value = "signUpOrSignIn")]
        SignUpOrSignIn = 3,

        /// <summary>
        /// The PasswordReset policy
        /// </summary>
        [EnumMember(Value = "passwordReset")]
        PasswordReset = 4,

        /// <summary>
        /// The ProfileUpdate policy
        /// </summary>
        [EnumMember(Value = "profileUpdate")]
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