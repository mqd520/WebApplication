using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;

using SqlSugar;

using WebApplication16.Db;
using WebApplication16.Db.Repository;
using WebApplication16.Db.Repository.Implements;
using WebApplication16.Interceptors;

namespace WebApplication16
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterType<SqlSugarHelperLogger>().SingleInstance();
                containerBuilder.RegisterType(typeof(DbTranInterceptor));
                containerBuilder.RegisterGeneric(typeof(BaseRepository<>));
                containerBuilder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>))
                    .InterceptedBy(typeof(DbTranInterceptor))
                    .EnableInterfaceInterceptors();
            });

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSingleton<ISqlSugarClient>(s =>
            {
                SqlSugarHelper.ServiceProvider = s;
                var connectingString = builder.Configuration.GetValue<string>("DbConnection");
                return SqlSugarHelper.GetSqlSugarScope(connectingString ?? "");
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
