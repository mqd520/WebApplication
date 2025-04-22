using Consul;

using WebApplication42.Options;

namespace WebApplication42.ServiceCollectionExtensions
{
    public static class ConsulExtensions
    {
        public static IApplicationBuilder RegisterConsul(this IApplicationBuilder app
            , IConfiguration configuration
            , IHostApplicationLifetime lifetime)
        {
            var option = configuration.GetSection("Consul").Get<ConsulOption>()!;

            var httpCheck = new AgentServiceCheck()
            {
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
                Interval = TimeSpan.FromSeconds(10),
                HTTP = $"http://{option.ClientInfo.Host}:{option.ClientInfo.Port}{option.HealthCheckPath}",
                Timeout = TimeSpan.FromSeconds(5),
            };

            var registration = new AgentServiceRegistration()
            {
                Checks = new[] { httpCheck },
                ID = Guid.NewGuid().ToString(),
                Name = option.ServiceName,
                Address = option.ClientInfo.Host,
                Port = option.ClientInfo.Port,
                Meta = new Dictionary<string, string>() {
                    { "Weight", option.Weight.ToString()}
                },
                Tags = new[] { $"http" },
            };

            var client = new ConsulClient(config =>
            {
                config.Address = new Uri(option.Address);
            });

            lifetime.ApplicationStarted.Register(() =>
            {
                Console.WriteLine(string.Format("Register to consul, consul address: {0}, client address: http://{1}:{2}, Id: {3}"
                    , option.Address
                    , option.ClientInfo.Host
                    , option.ClientInfo.Port
                    , registration.ID)
                );
                client.Agent.ServiceRegister(registration).Wait();
            });

            lifetime.ApplicationStopping.Register(() =>
            {
                client.Agent.ServiceDeregister(registration.ID).Wait();
            });

            app.Map(option.HealthCheckPath, application =>
            {
                application.Run(async context =>
                {
                    Console.WriteLine("Recv Consul Health Check!");
                    await context.Response.WriteAsync("ok");
                });
            });

            return app;
        }
    }
}
