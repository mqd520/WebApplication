using Exceptionless;

namespace WebApplication32
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddExceptionless(config =>
            {
                //config.ApiKey = "b32Ny127PJE4cmjrAfWKUZoz3egVKmpTXqnKqoDT";
                config.ApiKey = "PquNXaxuiHieDlUVcR7L0W9aj9eWPkzxIbwFvdIz";
                config.ServerUrl = "http://192.168.44.12:5200";
                config.SetDefaultMinLogLevel(Exceptionless.Logging.LogLevel.Trace);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseExceptionless();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
