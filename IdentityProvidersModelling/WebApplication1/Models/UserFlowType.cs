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
        [EnumMember(Value = "b2cSignUp")]
        B2cSignUp = 1,

        /// <summary>
        /// The SignIn Policy
        /// </summary>
        [EnumMember(Value = "b2cSignIn")]
        B2cSignIn = 2,

        /// <summary>
        /// The SignupOrSignIn policy
        /// </summary>
        [EnumMember(Value = "b2cSignUpOrSignIn")]
        B2cSignUpOrSignIn = 3,

        /// <summary>
        /// The PasswordReset policy
        /// </summary>
        [EnumMember(Value = "b2cPasswordReset")]
        B2cPasswordReset = 4,

        /// <summary>
        /// The ProfileUpdate policy
        /// </summary>
        [EnumMember(Value = "b2cProfileUpdate")]
        B2cProfileUpdate = 5,

        /// <summary>
        /// The Resource owner policy
        /// </summary>
        [EnumMember(Value = "b2cResourceOwnerPasswordCredentialSignIn")]
        B2cResourceOwnerPasswordCredentialSignIn = 6,

        /// <summary>
        /// The B2X SignupOrSignIn policy
        /// </summary>
        [EnumMember(Value = "b2xSignUpOrSignIn")]
        B2xSignUpOrSignIn = 7,

        /// <summary>
        /// Marker for non-exposed types
        /// </summary>
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue = 8,
    }

}