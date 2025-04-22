using Consul;

using Microsoft.AspNetCore.Mvc;

using WebApplication43.Consul;

namespace WebApplication43.Controllers
{
    [ApiController]
    [Route("~/[Controller]")]
    public class SampleController : ControllerBase
    {
        private IConsulClient _consulClient;
        private IConsulServiceManager _consulServiceManager;

        public SampleController(IConsulClient consulClient, IConsulServiceManager consulServiceManager)
        {
            _consulClient = consulClient;
            _consulServiceManager = consulServiceManager;
        }

        [HttpGet]
        [Route("GetServiceInfo")]
        public async Task<string> GetServiceInfo()
        {
            return await _consulServiceManager.GetServiceInfoAsync("WebApplication42");
        }
    }
}
