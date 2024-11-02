using FluentValidation;

using WebApplication13.Exceptions;

namespace WebApplication13
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpContextAccessor();

            // Add services to the container.
            builder.Services.AddControllersWithViews(options =>
            {

            });

            builder.Services.AddSingleton<GlobalExceptionHandler>();

            builder.Services.AddValidatorsFromAssemblyContaining<Program>(ServiceLifetime.Scoped);

            var app = builder.Build();

            ServiceLocator.ServiceProvider = app.Services;
            ServiceLocator.App = app;

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}