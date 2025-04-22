
using System.Collections.Concurrent;

using Consul;

using WebApplication43.Options;

namespace WebApplication43.Consul
{
    public class DefaultConsulServiceManager : IConsulServiceManager
    {
        private readonly IConfiguration _configuration;
        private readonly IConsulClient _consulClient;

        private readonly ConcurrentDictionary<string, int> _dictServiceCalls = new ConcurrentDictionary<string, int>();

        public DefaultConsulServiceManager(IConfiguration confiruration, IConsulClient consulClient)
        {
            _configuration = confiruration;
            _consulClient = consulClient;
        }

        public async Task<string> GetServiceInfoAsync(string serviceName)
        {
            var service = await GetServiceAsync(serviceName);
            return $"http://{service.Address}:{service.Port}";
        }

        public async Task<AgentService> GetServiceAsync(string serviceName)
        {
            var services = await GetServiceListAsync(serviceName);
            return BalancingRoute(services, serviceName);
        }

        public async Task<IList<AgentService>> GetServiceListAsync(string serviceName)
        {
            var result = await _consulClient.Health.Service(serviceName);

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ConsulRequestException("获取服务信息失败！", result.StatusCode);
            }

            return result.Response.Select(s => s.Service).ToList();
        }

        private AgentService BalancingRoute(IList<AgentService> services, string key)
        {
            if (services == null || !services.Any())
            {
                throw new ArgumentNullException(nameof(services), $"当前未找到{key}可用服务！");
            }

            var option = _configuration.GetSection("Consul").Get<ConsulOption>()!;
            switch (option.LBStrategy)
            {
                case "First":
                    return First(services);
                case "Random":
                    return Random(services);
                case "RoundRobin":
                    return RoundRobin(services, key);
                case "WeightRandom":
                    return WeightRandom(services);
                case "WeightRoundRobin":
                    return WeightRoundRobin(services, key);
                default:
                    return RoundRobin(services, key);
            }
        }

        private AgentService First(IList<AgentService> services)
        {
            return services.First();
        }

        /// <summary>
        /// 随机
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private AgentService Random(IList<AgentService> services)
        {
            return services.ElementAt(new Random().Next(0, services.Count()));
        }

        /// <summary>
        /// 轮询
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private AgentService RoundRobin(IList<AgentService> services, string key)
        {
            var count = _dictServiceCalls.GetOrAdd(key, 0);
            var service = services.ElementAt(count++ % services.Count());
            _dictServiceCalls[key] = count;
            return service;
        }

        /// <summary>
        /// 加权随机
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private AgentService WeightRandom(IList<AgentService> services)
        {
            var pairs = services.SelectMany(s =>
            {
                var weight = 1;
                if (s.Meta.ContainsKey("Weight") && int.TryParse(s.Meta["Weight"], out int w))
                {
                    weight = w;
                }
                var result = new List<AgentService>();
                for (int i = 0; i < weight; i++)
                {
                    result.Add(s);
                }
                return result;
            }).ToList();
            return Random(pairs);
        }

        /// <summary>
        /// 加权轮询
        /// </summary>
        /// <param name="services"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private AgentService WeightRoundRobin(IList<AgentService> services, string key)
        {
            var pairs = services.SelectMany(s =>
            {
                var weight = 1;
                if (s.Meta.ContainsKey("Weight") && int.TryParse(s.Meta["Weight"], out int w))
                {
                    weight = w;
                }
                var result = new List<AgentService>();
                for (int i = 0; i < weight; i++)
                {
                    result.Add(s);
                }
                return result;
            }).ToList();
            return RoundRobin(pairs, key);
        }
    }
}
