using Coravel;

using WebApplication57.Invocables;

namespace WebApplication57
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<MyInvocable>();
            builder.Services.AddTransient<MyInvocable3>();
            builder.Services.AddScheduler();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.Services.UseScheduler(scheduler =>
            {
                //scheduler.Schedule<MyInvocable>()
                //    .EverySeconds(35)
                //    .RunOnceAtStart();

                //scheduler.ScheduleWithParams<MyInvocable2>(5)
                //    .EverySeconds(5)
                //    .RunOnceAtStart();

                scheduler.Schedule<MyInvocable3>()
                    .Cron("44/2 * * * *");
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
