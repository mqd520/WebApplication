namespace WebApplication6.Tools
{
    public class StackExchangeRedisLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new StackExchangeRedisLogger();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
