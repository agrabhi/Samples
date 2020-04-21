using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public enum UserProfileAttributeDataType
    {
        None = 0,

        String = 1,

        Boolean = 2,

        Int64 = 3,

        Stringcollection = 4,

        unknownFutureValue = 5,
    }
}