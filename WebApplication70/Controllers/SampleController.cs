using Microsoft.AspNetCore.Mvc;

using RestSharp;

namespace WebApplication70.Controllers
{
    public class SampleController : Controller
    {
        private readonly string _webApiAddress;

        public SampleController(IConfiguration configuration)
        {
            _webApiAddress = configuration["WebApiAddress"]!;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sample()
        {
            var restClient = new RestClient(_webApiAddress + "/api");
            var restRequest = new RestRequest("/User", Method.Get);
            var response = restClient.Execute(restRequest);
            var content = response.Content!;
            return Content(content);
        }
    }
}
