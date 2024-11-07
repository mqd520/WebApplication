using System.Reflection;

using Castle.DynamicProxy;

using WebApplication16.Db.Tran;
using WebApplication16.Tools;

namespace WebApplication16.Db.Interceptors
{
    public class DbTranInterceptor : IInterceptor
    {
        private readonly ILogger<DbTranInterceptor> _logger;
        private readonly IUnitOfWorkManage _unitOfWorkManage;

        public DbTranInterceptor(ILogger<DbTranInterceptor> logger
            , IUnitOfWorkManage unitOfWorkManage)
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
                    Console.WriteLine("DbTranInterceptor: Begin Transaction");
                    _unitOfWorkManage.BeginTran();

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
                    _unitOfWorkManage.CommitTran();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());
                    Console.WriteLine("DbTranInterceptor: Rollback Transaction");
                    _unitOfWorkManage.RollbackTran();
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
