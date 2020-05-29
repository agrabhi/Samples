using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication1.Models
{
    [Flags]
    public enum B2cAuthenticationMethods
    {
        [EnumMember(Value = "emailWithPassword")]
        EmailWithPassword = 1 << 0,

        [EnumMember(Value = "userName")]
        UserName = 1 << 1,

        [EnumMember(Value = "phoneWithOneTimePassword")]
        PhoneWithOneTimePassword = 1 << 2,

        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue = 1 << 3,
    }
}