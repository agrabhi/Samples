namespace WebApplication1.Models
{
    public abstract class InvokableAction
    {
        public int Priority { get; set; }

        public AuthenticationSourceFilter Filter { get; set; }
    }
}