
using Coravel.Invocable;

namespace WebApplication57.Invocables
{
    public class MyInvocable2 : IInvocable
    {
        private readonly ILogger<MyInvocable2> _logger;
        private readonly int _seconds;

        public MyInvocable2(ILogger<MyInvocable2> logger, int seconds)
        {
            _logger = logger;
            _seconds = seconds;
        }

        public Task Invoke()
        {
            Console.WriteLine($"MyInvocable2.Invoke(), Seconds: {_seconds}");
            return Task.CompletedTask;
        }
    }
}
