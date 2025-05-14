using Flurl;
using Flurl.Http;

using Microsoft.AspNetCore.Mvc;

namespace WebApplication71.Controllers
{
    public class SampleController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _webApiAddress;

        public SampleController(IConfiguration configuration)
        {
            _configuration = configuration;
            _webApiAddress = configuration["WebApiAddress"]!;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Sample()
        {
            var response = await _webApiAddress
                .AppendPathSegment("api")
                .AppendPathSegments("User")
                .GetStringAsync();
            return Content(response);
        }
    }
}
