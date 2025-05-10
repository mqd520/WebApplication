
using Coravel.Invocable;

namespace WebApplication57.Invocables
{
    public class MyInvocable2 : IInvocable
    {
        public Task Invoke()
        {
            Console.WriteLine("MyInvocable2");
            return Task.CompletedTask;
        }
    }
}
