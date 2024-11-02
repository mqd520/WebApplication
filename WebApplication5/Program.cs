using WebApplication5.Options;

namespace WebApplication5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var redisOptions = builder.Configuration.GetSection(RedisOptions.SectionName).Get<RedisOptions>();
            var sessionOptions = builder.Configuration.GetSection(MySessionOptions.SectionName).Get<MySessionOptions>();
            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisOptions?.ConnectionString ?? "";
                options.InstanceName = (redisOptions?.InstanceName ?? "") + (sessionOptions?.Prefix ?? "");
            });
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(sessionOptions?.Timeout ?? 0);
                options.Cookie.HttpOnly = sessionOptions?.Cookie.HttpOnly ?? true;
                options.Cookie.Name = sessionOptions?.Cookie.Name ?? "";
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
