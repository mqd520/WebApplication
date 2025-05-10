using Microsoft.AspNetCore.Mvc;

namespace WebApplication55.Controllers
{
    public class HttpClientFactoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientFactoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Sample()
        {
            using var httpClient = _httpClientFactory.CreateClient("demo");
            var response = await httpClient.GetAsync("/api/User");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content);
        }

        public async Task<IActionResult> Sample2()
        {
            using var httpClient = _httpClientFactory.CreateClient("demo");
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "/api/User");
            var response = await httpClient.SendAsync(httpRequestMessage);
            var content = await response.Content.ReadAsStringAsync();
            return Content(content);
        }
    }
}
