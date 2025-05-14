
using Coravel.Invocable;

namespace WebApplication57.Invocables
{
    public class MyInvocable : IInvocable
    {
        private readonly ILogger<MyInvocable> _logger;

        public MyInvocable(ILogger<MyInvocable> logger)
        {
            _logger = logger;
        }

        public Task Invoke()
        {
            Console.WriteLine($"MyInvocable.Invoke()");
            return Task.CompletedTask;
        }
    }
}
