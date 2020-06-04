namespace WebApplication1.Models
{
    public class ApiParameter : UserFlowAttribute
    {
        public bool IsAllowedInRequests { get; set; }

        public bool IsAllowedInResponses { get; set; }
    }
}