using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;

using SqlSugar;

using WebApplication16.Db;
using WebApplication16.Db.Interceptors;
using WebApplication16.Db.Repository;
using WebApplication16.Db.Repository.Implements;

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
            InitDbService(builder);
        }

        static void InitAutofac(WebApplicationBuilder builder)
        {
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        }

        static void InitDbService(WebApplicationBuilder builder)
        {
            #region Inject SqlSugarCore
            builder.Services.AddSingleton<ISqlSugarClient>(provider =>
            {
                SqlSugarHelper.ServiceProvider = provider;
                var connectingString = builder.Configuration.GetValue<string>("DbConnection");
                return SqlSugarHelper.GetSqlSugarScope(connectingString ?? "");
            });
            builder.Services.AddSingleton<SqlSugarHelperLogger>();
            #endregion

            #region Inject Repo
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterGeneric(typeof(BaseRepository<>));
                containerBuilder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>))
                    .InterceptedBy(typeof(DbTranInterceptor))
                    .EnableInterfaceInterceptors();
                containerBuilder.RegisterType(typeof(DbTranInterceptor));
            });
            #endregion
        }
    }
}
