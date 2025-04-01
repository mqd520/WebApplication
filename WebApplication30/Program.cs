using Serilog;

using WebApplication30.Serilog;

namespace WebApplication30
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //var logger = new LoggerConfiguration()
            //            .WriteTo.Console()
            //            .WriteTo.File("Logs/WebApplication30.log", rollingInterval: RollingInterval.Day)
            //            .MinimumLevel.Verbose()
            //            .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
            //            .CreateLogger();
            builder.Host.UseSerilog((context, configuration) =>
            {
                var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("Serilog.json")
                            .Build();
                configuration.ReadFrom.Configuration((IConfiguration)config)
                             .Enrich.With<ThreadPriorityEnricher>();
            });

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
