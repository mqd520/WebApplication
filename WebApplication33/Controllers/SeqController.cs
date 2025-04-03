using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Seq.Api;
using Seq.Api.Client;
using Seq.Api.Model;

using WebApplication33.Config;

namespace WebApplication33.Controllers
{
    public class SeqController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly SeqSettings _seqSettings;

        public SeqController(IConfiguration configuration, IOptions<SeqSettings> option)
        {
            _configuration = configuration;
            _seqSettings = option.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Demo([FromServices] IOptions<SeqSettings> option)
        {
            var url = _configuration["Seq:ServerUrl"] ?? string.Empty;
            var key = _configuration["Seq:ApiKey"] ?? string.Empty;

            {
                var connection = new SeqConnection(url, key);
                var installedApps = await connection.Apps.ListAsync();
            }

            var client = new SeqApiClient(url, key);
            var rootEntity = await client.GetRootAsync();
            var serverInfo = await client.GetAsync<ResourceGroup>(rootEntity, "EventsResources");
            return Content("Demo");
        }
    }
}
