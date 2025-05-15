
namespace WebApplication75.CustomServiceScopeFactory
{
    public class CustomServiceScope : IServiceScope
    {
        public IServiceProvider ServiceProvider { get; }

        public CustomServiceScope()
        {
            ServiceProvider = new CustomServiceProvider();
        }

        public void Dispose()
        {

        }
    }
}
