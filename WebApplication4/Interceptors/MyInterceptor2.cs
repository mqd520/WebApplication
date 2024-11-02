using System.Diagnostics;
using System.Reflection;

using Castle.DynamicProxy;

using WebApplication4.Interceptors;

namespace WebApplication4.AOP
{
    public class MyInterceptor2 : IInterceptor
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

            Console.WriteLine($"MyInterceptor2: Before executing method: {className}.{methodName}({arguments})");

            var stopwatch = Stopwatch.StartNew();

            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MyInterceptor2: Exception occurred in method: {className}.{methodName}");
                Console.WriteLine($"MyInterceptor2: Exception details: {ex}");
                throw;
            }
            finally
            {
                stopwatch.Stop();
                Console.WriteLine($"MyInterceptor2: After executing method: {className}.{methodName}");
                Console.WriteLine($"MyInterceptor2: Execution time: {stopwatch.ElapsedMilliseconds} ms");
            }
        }
    }
}
