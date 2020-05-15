using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class B2CAuthenticationMethods
    {
        public Boolean PhoneOneTimePasswordAuthenticationEnabled { get; set; }

        public Boolean EmailPasswordAuthenticationEnabled { get; set; }

        public Boolean UserNameAuthenticationEnabled { get; set; }
    }
}