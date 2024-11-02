using WebApplication2.Exceptions;
using WebApplication2.Filters;

namespace WebApplication2
{
    public class Program
    {
        private static ILogger<Program>? _logger;

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<CustomControllerExceptionFilter>();
            });

            builder.Services.AddSingleton<GlobalExceptionHandler>();

            var app = builder.Build();

            _logger = app.Services.GetRequiredService<ILogger<Program>>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    var instance = app.Services.GetRequiredService<GlobalExceptionHandler>();
                    builder.Use(instance.ExceptionHandler);
                });
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            app.Run();
        }
    }
}
