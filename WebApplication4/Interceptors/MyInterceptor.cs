using System.Diagnostics;
using System.Reflection;

using Castle.DynamicProxy;

namespace WebApplication4.Interceptors
{
    public class MyInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget ?? invocation.Method;
            if (method.GetCustomAttribute<NoInterceptorAttribute>(true) != null)
            {
                invocation.Proceed();
                return;
            }

            var methodName = invocation.Method.Name;
            var className = invocation.TargetType.Name;
            var arguments = string.Join(", ", invocation.Arguments);

            Console.WriteLine($"MyInterceptor: Before executing method: {className}.{methodName}({arguments})");

            var stopwatch = Stopwatch.StartNew();

            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MyInterceptor: Exception occurred in method: {className}.{methodName}");
                Console.WriteLine($"MyInterceptor: Exception details: {ex}");
                throw;
            }
            finally
            {
                stopwatch.Stop();
                Console.WriteLine($"MyInterceptor: After executing method: {className}.{methodName}");
                Console.WriteLine($"MyInterceptor: Execution time: {stopwatch.ElapsedMilliseconds} ms");
            }
        }
    }
}
