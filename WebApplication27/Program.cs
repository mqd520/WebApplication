using Arch.EntityFrameworkCore.UnitOfWork;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using WebApplication27.Db.Contexts;

namespace WebApplication27
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
            InitLog4Net(builder);
            InitEFCore(builder);
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
        /// Init EF Core
        /// </summary>
        /// <param name="builder"></param>
        static void InitEFCore(WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration as IConfiguration;
            var connectionString = configuration["ConnectionString"];

            #region Inject DbContext
            builder.Services.AddDbContext<CustomerDbContext>((provider, options) =>
            {
                options.UseMySQL(connectionString!, options2 =>
                {
                    var assembly = typeof(CustomerDbContext).Assembly;
                    var assemblyName = assembly.GetName();
                    options2.MigrationsAssembly(assemblyName.Name);
                });
                options.EnableSensitiveDataLogging();
                options.ConfigureWarnings(x => x.Ignore(RelationalEventId.AmbientTransactionWarning));
            });
            #endregion

            builder.Services.AddUnitOfWork<CustomerDbContext>();
        }
    }
}
