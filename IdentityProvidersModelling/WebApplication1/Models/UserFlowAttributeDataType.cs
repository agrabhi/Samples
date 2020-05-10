using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public enum UserFlowAttributeDataType
    {
        none = 0,

        @string = 1,

        @boolean = 2,

        @int64 = 3,

        stringcollection = 4,

        unknownFutureValue = 5,
    }
}