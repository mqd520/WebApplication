namespace WebApplication74.Services
{
    public class MyService : IMyService
    {
        private readonly ILogger<MyService> _logger;

        public MyService(ILogger<MyService> logger)
        {
            _logger = logger;
        }

        public void DoSomething()
        {
            _logger.LogInformation("Doing something in MyService.");
        }
    }
}
