using FreeRedis;

namespace WebApplication54
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var redisClient = new RedisClient(
                "mymaster",
                new[] {
                    "192.168.44.14:26379"
                    //,"192.168.44.14:26380"
                    //,"192.168.44.14:26381"
                },
                true
            );

            redisClient.Notice += (s, e) =>
            {
                Console.WriteLine($"NoticeType: {e.NoticeType}, Exception: {e.Exception?.Message ?? ""} Log: {e.Log}");
            };

            redisClient.Connected += (s, e) =>
            {
                Console.WriteLine($"Host: {e.Host}");
            };

            builder.Services.AddSingleton<IRedisClient>(redisClient);

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

        private static void OnRedisNotice(object? sender, NoticeEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
