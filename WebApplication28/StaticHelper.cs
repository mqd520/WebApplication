using DependencyInjection.StaticAccessor;

using WebApplication28.Services;

namespace WebApplication28
{
    public static class StaticHelper
    {
        public static void Fun1()
        {
            var service = PinnedScope.ScopedServices?.GetRequiredService<ITestService>();
        }
    }
}
