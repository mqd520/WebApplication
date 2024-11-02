namespace WebApplication15
{
    public static class ServiceLocator
    {
        public static IServiceProvider ServiceProvider { get; set; } = null!;

        public static WebApplication App { get; set; } = null!;
    }
}
