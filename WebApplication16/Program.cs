using System.Reflection;

using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;

using SqlSugar;

using WebApplication16.Db;
using WebApplication16.Db.Interceptors;

namespace WebApplication16
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpContextAccessor();

            InitAll3rdService(builder);

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

        static void InitAll3rdService(WebApplicationBuilder builder)
        {
            InitAutofac(builder);
            InitLog4Net(builder);
            InitDbService(builder);
        }

        static void InitAutofac(WebApplicationBuilder builder)
        {
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        }

        static void InitLog4Net(WebApplicationBuilder builder)
        {
            builder.Services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddConsole();
                loggingBuilder.AddLog4Net();
            });
        }

        static void InitDbService(WebApplicationBuilder builder)
        {
            #region Inject SqlSugarCore
            builder.Services.AddSingleton<ISqlSugarClient>(provider =>
            {
                SqlSugarHelper.ServiceProvider = provider;
                var connectingString = builder.Configuration.GetValue<string>("DbConnection");
                return SqlSugarHelper.CreateSqlSugarScope(connectingString ?? "");
            });
            builder.Services.AddSingleton<SqlSugarLogger>();
            #endregion

            #region Inject Repo
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .PublicOnly()
                                .Where(x => x.Namespace?.StartsWith("WebApplication16.Db.Repository.Implements") ?? false
                                       && x.IsClass
                                       && x.Name.EndsWith("Repository"))
                                .AsImplementedInterfaces()
                                .InstancePerLifetimeScope();
            });
            #endregion

            #region Inject Interceptor
            builder.Services.AddScoped<DbTranInterceptor>();
            #endregion

            #region Inject Db Service
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .PublicOnly()
                                .Where(x => x.Namespace?.StartsWith("WebApplication16.Db.Services.Implements") ?? false
                                            && x.IsClass
                                            && x.Name.EndsWith("Service"))
                                .AsImplementedInterfaces()
                                .InstancePerLifetimeScope()
                                .InterceptedBy(typeof(DbTranInterceptor))
                                .EnableInterfaceInterceptors();
            });
            #endregion
        }
    }
}
