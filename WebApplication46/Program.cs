using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Refit;

using WebApplication46.Api.WebApplication24;

namespace WebApplication46
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var settings = new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                })
            };
            builder.Services
                .AddRefitClient<IUserApi>(settings)
                .ConfigureHttpClient(hc =>
                {
                    hc.BaseAddress = new Uri("http://localhost:5000");
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

            app.MapControllerRoute(
                name: "WebApplication24",
                pattern: "WebApplication24/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
