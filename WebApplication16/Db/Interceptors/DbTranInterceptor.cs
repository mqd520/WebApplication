using System.Reflection;

using Castle.DynamicProxy;

using WebApplication16.Tools;

namespace WebApplication16.Db.Interceptors
{
    public class DbTranInterceptor : IInterceptor
    {
        private readonly ILogger<DbTranInterceptor> _logger;

        public DbTranInterceptor(ILogger<DbTranInterceptor> logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget ?? invocation.Method;
            if (method.GetCustomAttribute<UseDbTranAttribute>(true) is not null)
            {
                try
                {
                    Console.WriteLine("DbTranInterceptor: Begin Transaction");

                    invocation.Proceed();

                    if (CommonTool.IsAsyncMethod(invocation.Method))
                    {
                        var result = invocation.ReturnValue;
                        if (result is Task task)
                        {
                            Task.WaitAll([task]);
                        }
                    }

                    Console.WriteLine("DbTranInterceptor: Commit Transaction");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());
                    Console.WriteLine("DbTranInterceptor: Rollback Transaction");
                    throw;
                }
            }
            else
            {
                invocation.Proceed();
            }
        }
    }
}
