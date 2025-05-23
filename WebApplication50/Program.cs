using WebApplication50.Options;
using WebApplication50.Tools;

namespace WebApplication50
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var redisOptions = builder.Configuration.GetSection(RedisOptions.SectionName).Get<RedisOptions>();
            var helper = new RedisHelper(redisOptions!);
            builder.Services.AddSingleton<IRedisHelper>(helper);

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
    }
}
