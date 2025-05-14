using Autofac;
using Autofac.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection.Extensions;

using WebApplication72.Db.Repository;
using WebApplication72.Db.Repository.Implement;

namespace WebApplication72.Autofac
{
    public static class AutofacConfig
    {
        public static void Init(WebApplicationBuilder builder)
        {
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                var baseControllerType = typeof(ControllerBase);
                builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                    .Where(t => baseControllerType.IsAssignableFrom(t)
                        && t != baseControllerType)
                    .PropertiesAutowired(new CustomPropertySelector());
                builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>));
                builder.RegisterType<ServiceBasedControllerActivator>().As<IControllerActivator>();
            });
            // Add services to the container.
            builder.Services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
