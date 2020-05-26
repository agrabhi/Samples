using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class B2cAuthenticationMethodsPolicy
    {
        public string Id { get; set; }

        public Boolean IsPhoneOneTimePasswordAuthenticationEnabled { get; set; }

        public Boolean IsEmailPasswordAuthenticationEnabled { get; set; }

        public Boolean IsUserNameAuthenticationEnabled { get; set; }
    }
}