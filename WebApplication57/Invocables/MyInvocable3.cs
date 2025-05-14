
using Coravel.Invocable;

namespace WebApplication57.Invocables
{
    public class MyInvocable3 : IInvocable
    {
        private readonly ILogger<MyInvocable3> _logger;

        public MyInvocable3(ILogger<MyInvocable3> logger)
        {
            _logger = logger;
        }

        public Task Invoke()
        {
            Console.WriteLine($"MyInvocable3.Invoke(), Time: {DateTime.Now.ToString("HH:mm:ss")}");
            return Task.CompletedTask;
        }
    }
}
