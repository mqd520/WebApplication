using Arch.EntityFrameworkCore.UnitOfWork;

using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;

using Microsoft.EntityFrameworkCore;

using WebApplication26.Db.Contexts;
using WebApplication26.Db.DAO;
using WebApplication26.Db.DAO.Implement;
using WebApplication26.Db.Interceptors;
using WebApplication26.Db.Service;
using WebApplication26.Db.Service.Implement;
using WebApplication26.Db.Trans;

namespace WebApplication26
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpContextAccessor();

            InitAll3rdServices(builder);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            ServiceLocator.ServiceProvider = app.Services;
            ServiceLocator.App = app;

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

        /// <summary>
        /// Init All 3rd Services
        /// </summary>
        /// <param name="builder"></param>
        static void InitAll3rdServices(WebApplicationBuilder builder)
        {
            InitAutofac(builder);
            InitLog4Net(builder);
            InitDbService(builder);
        }

        /// <summary>
        /// Init Autofac
        /// </summary>
        /// <param name="builder"></param>
        static void InitAutofac(WebApplicationBuilder builder)
        {
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        }

        /// <summary>
        /// Init Log4Net
        /// </summary>
        /// <param name="builder"></param>
        static void InitLog4Net(WebApplicationBuilder builder)
        {
            builder.Services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddConsole();
                loggingBuilder.AddLog4Net();
            });
        }

        /// <summary>
        /// Init Db Service
        /// </summary>
        /// <param name="builder"></param>
        static void InitDbService(WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration as IConfiguration;
            var connectionString = configuration["ConnectionString"];

            #region Inject DAO
            builder.Services.AddScoped<ICustomerDAO, CustomerDAO>();
            #endregion

            #region Inject DbContext
            builder.Services.AddDbContext<ApplicationDbContext>((provider, options) =>
            {
                options.UseMySQL(connectionString!).EnableSensitiveDataLogging();
            });
            #endregion

            #region Inject UnitOfWork
            builder.Services.AddUnitOfWork<ApplicationDbContext>();
            #endregion

            #region Inject Transaction
            builder.Services.AddScoped<IDbTranUnitOfWork, DbTranUnitOfWork>();
            #endregion

            #region Inject Interceptor
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterType<DbTranInterceptor>();
            });
            #endregion

            #region Inject Db Service
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterType<CustomerService>().As<ICustomerService>()
                                .EnableInterfaceInterceptors()
                                .InterceptedBy(typeof(DbTranInterceptor));
            });
            #endregion
        }
    }
}
