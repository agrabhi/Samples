using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class AuthenticationEventsConfigurationPolicy
    {
        public string Id { get; set; }

        public ICollection<InvokableAction> OnSignup { get; set; }

        public ICollection<InvokableAction> OnMFAComplete { get; set; }
    }
}