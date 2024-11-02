using System.Reflection;

using Castle.DynamicProxy;

namespace WebApplication4.Autofac
{
    public class CustomInterceptorSelector : IInterceptorSelector
    {
        /// <summary>
        /// SelectInterceptors
        /// </summary>
        /// <param name="type"></param>
        /// <param name="method"></param>
        /// <param name="interceptors">如果类型有标注拦截器，这里会获取所有拦截器。</param>
        /// <returns></returns>       
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            IList<IInterceptor> interceptorsList = [new CustomInterfaceInterceptor()];
            return interceptorsList.ToArray();
        }
    }
}
