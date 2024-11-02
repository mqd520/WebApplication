using System.Reflection;

using Castle.DynamicProxy;

using WebApplication26.Db.Trans;
using WebApplication26.Tools;

namespace WebApplication26.Db.Interceptors
{
    public class DbTranInterceptor : IInterceptor
    {
        private readonly ILogger<DbTranInterceptor> _logger;
        private readonly IDbTranUnitOfWork _dbTranUnitOfWork;

        public DbTranInterceptor(ILogger<DbTranInterceptor> logger,
            IDbTranUnitOfWork dbTranUnitOfWork)
        {
            _logger = logger;
            _dbTranUnitOfWork = dbTranUnitOfWork;
        }

        public void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget ?? invocation.Method;
            if (method.GetCustomAttribute<UseDbTranAttribute>(true) is not null)
            {
                try
                {
                    _dbTranUnitOfWork.BeginTransaction();

                    invocation.Proceed();

                    if (CommonTool.IsAsyncMethod(invocation.Method))
                    {
                        var result = invocation.ReturnValue;
                        if (result is Task task)
                        {
                            Task.WaitAll([task]);
                        }
                    }

                    _dbTranUnitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _logger.LogError(message: ex.ToString());
                    _dbTranUnitOfWork.RoolbackTransaction();
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
