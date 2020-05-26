using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [Flags]
    public enum B2cAuthenticationMethods
    {
        PhoneOneTimePassword = 1 << 1,

        EmailPassword = 1 << 2,

        UserName = 1 << 3,

        UnknownFutureValue = 1 << 4,
    }
}