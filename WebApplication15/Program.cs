using SqlSugar;

using WebApplication15.Db;
using WebApplication15.Db.Repository;
using WebApplication15.Db.Repository.Implements;
using WebApplication15.Services;
using WebApplication15.Services.Implements;

namespace WebApplication15
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSingleton<ITestService, TestService>();
            builder.Services.AddSingleton<ISqlSugarClient>(serviceProvider =>
            {
                SqlSugarHelper.ServiceProvider = serviceProvider;
                var connectingString = builder.Configuration.GetValue<string>("DbConnection");
                return SqlSugarHelper.GetSqlSugarScope(connectingString ?? "");
            });
            builder.Services.AddSingleton<SqlSugarHelperLogger>();
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            builder.Services.AddScoped<ICustomerService, CustomerService>();

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
    }
}
