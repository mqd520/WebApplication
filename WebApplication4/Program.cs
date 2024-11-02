using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

using WebApplication4.AOP;
using WebApplication4.Autofac;
using WebApplication4.Db;
using WebApplication4.Interceptors;
using WebApplication4.Services;
using WebApplication4.Services.Implements;

namespace WebApplication4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                // 支持控制器属性自定义注入
                var baseControllerType = typeof(ControllerBase);
                containerBuilder.RegisterAssemblyTypes(typeof(Program).Assembly)
                    .Where(x => baseControllerType.IsAssignableFrom(x) && baseControllerType != x)
                    .PropertiesAutowired(new CustomPropertySelector());
                containerBuilder.RegisterType<ServiceBasedControllerActivator>().As<IControllerActivator>();

                // 注册拦截器
                containerBuilder.RegisterType<MyInterceptor>();
                containerBuilder.RegisterType<MyInterceptor2>();
                containerBuilder.RegisterType<DbTranInterceptor>();

                // 注册IUnitOfWorkManage
                containerBuilder.RegisterType<UnitOfWorkManage>().As<IUnitOfWorkManage>();

                // 注册单例服务
                containerBuilder.RegisterType<SingleService>().SingleInstance().As<ISingleService>()
                    .InterceptedBy(typeof(MyInterceptor))
                    .InterceptedBy(typeof(MyInterceptor2))
                    .EnableInterfaceInterceptors();

                // 批量注册Service
                containerBuilder.RegisterAssemblyTypes(typeof(Program).Assembly)
                    .Where(x => !x.Name.Equals(nameof(SingleService)))
                    .Where(x => x.Name.EndsWith("Service"))
                    .AsImplementedInterfaces();

                // 批量注册Repository
                containerBuilder.RegisterAssemblyTypes(typeof(Program).Assembly)
                    .Where(x => x.Name.EndsWith("Repository"))
                    .AsImplementedInterfaces()
                    .EnableInterfaceInterceptors()
                    .InterceptedBy(typeof(DbTranInterceptor));
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
