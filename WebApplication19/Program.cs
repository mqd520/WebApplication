namespace WebApplication19
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Use(ExceptionHandler);
                });
            }
            app.UseStatusCodePagesWithReExecute("/error/{0}");

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        private static async Task ExceptionHandler(HttpContext context, Func<Task> next)
        {
            context.Response.Clear();
            context.Response.StatusCode = 400;
            context.Response.ContentType = "";
            await context.Response.WriteAsync("");
        }
    }
}
