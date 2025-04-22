using Consul;

namespace WebApplication43.Consul
{
    public interface IConsulServiceManager
    {
        Task<string> GetServiceInfoAsync(string serviceName);

        Task<AgentService> GetServiceAsync(string serviceName);

        Task<IList<AgentService>> GetServiceListAsync(string serviceName);
    }
}
