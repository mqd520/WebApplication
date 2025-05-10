using Microsoft.AspNetCore.Mvc;

namespace WebApplication56.Controllers
{
    public class PollyHttpClientController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PollyHttpClientController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Sample()
        {
            var httpClient = _httpClientFactory.CreateClient("myHttpClient");
            var response = await httpClient.GetAsync("http://localhost:50241/api/User");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content);
        }
    }
}
