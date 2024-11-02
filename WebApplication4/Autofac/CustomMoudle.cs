using Autofac;

using WebApplication4.AOP;

namespace WebApplication4.Autofac
{
    public class CustomMoudle : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MyInterceptor2>();

            base.Load(builder);
        }
    }
}
