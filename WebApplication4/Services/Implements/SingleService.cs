using WebApplication4.Interceptors;

namespace WebApplication4.Services.Implements
{
    public class SingleService : ISingleService
    {
        public string Fun1()
        {
            return "SingleService.Fun1()";
        }

        [NoInterceptor]
        public string Fun2()
        {
            return "SingleService.Fun2()";
        }
    }
}
