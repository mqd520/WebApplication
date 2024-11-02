namespace WebApplication13
{
    public class ServiceLocator
    {
        public static IServiceProvider ServiceProvider { get; set; } = null!;

        public static WebApplication App { get; set; } = null!;

        public static IHttpContextAccessor GetHttpContextAccessor()
        {
            return ServiceProvider.GetRequiredService<IHttpContextAccessor>();
        }

        public static HttpContext GetCurrentHttpContext()
        {
            var accessor = GetHttpContextAccessor();
            return accessor?.HttpContext ?? null!;
        }
    }
}
