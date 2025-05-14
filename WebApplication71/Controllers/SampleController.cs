using Flurl;
using Flurl.Http;

using Microsoft.AspNetCore.Mvc;

using WebApplication71.Def;

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

        public async Task<IActionResult> Sample2()
        {
            var response = await _webApiAddress
                .AppendPathSegment("api")
                .AppendPathSegments("User")
                .GetJsonAsync<List<UserInfo>>();
            return Json(response);
        }
    }
}
