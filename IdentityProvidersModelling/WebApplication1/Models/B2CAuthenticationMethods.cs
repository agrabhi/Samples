using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [Flags]
    public enum B2cAuthenticationMethods
    {
        EmailWithPassword = 1 << 0,

        UserName = 1 << 1,

        PhoneWithOneTimePassword = 1 << 2,

        UnknownFutureValue = 1 << 3,
    }
}