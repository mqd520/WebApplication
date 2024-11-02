using Autofac.Annotation;

namespace WebApplication14.Aspects
{
    [Pointcut(Class = "*Service")]
    public class MyAspect
    {
        [Before]
        public void Before()
        {
            Console.WriteLine("MyAspect.Before");
        }
    }
}
