using System.Reflection;

using Castle.DynamicProxy;

using WebApplication4.Db;
using WebApplication4.Tools;

namespace WebApplication4.Interceptors
{
    public class DbTranInterceptor : IInterceptor
    {
        private readonly ILogger<DbTranInterceptor> _logger;

        private readonly IUnitOfWorkManage _unitOfWorkManage;

        public DbTranInterceptor(ILogger<DbTranInterceptor> logger,
            IUnitOfWorkManage unitOfWorkManage)
        {
            _logger = logger;
            _unitOfWorkManage = unitOfWorkManage;
        }

        public void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget ?? invocation.Method;
            if (method.GetCustomAttribute<UseDbTranAttribute>(true) is not null)
            {
                try
                {
                    _unitOfWorkManage.BeginTran();

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

                    _unitOfWorkManage.CommitTran();
                    Console.WriteLine("DbTranInterceptor: Commit Transaction");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());
                    _unitOfWorkManage.RollbackTran();
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
