using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TokenLifetimeConfiguration
    {
        public int AccessAndIdTokenLifetime { get; set; }

        public int RefreshTokenLifetimeInDays { get; set; }

        /// <summary>
        /// After this time period elapses the user is forced to re-authenticate, irrespective of the validity 
        /// period of the most recent refresh token acquired by the app.
        /// If set to -1, the refresh token can be indefinitely used to get a new refresh token
        /// </summary>
        public int RollingRefreshTokenLifetimeInDays { get; set; }
    }
}