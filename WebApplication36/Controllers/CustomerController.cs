using Microsoft.AspNetCore.Mvc;

using Polly;

namespace WebApplication36.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SampleAsync()
        {
            var policy = Policy.Handle<HttpRequestException>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
            var result = await policy.ExecuteAsync(async () =>
                {
                    using HttpClient httpClient = _httpClientFactory.CreateClient("demo");
                    return await httpClient.GetStringAsync("/CustomerRepository/GetAll");
                });

            return Content(result);
        }

        public async Task<IActionResult> Sample2Async()
        {
            var policy = Policy.TimeoutAsync<string>(10);
            var result = await policy.ExecuteAsync(async () =>
                {
                    using HttpClient httpClient = _httpClientFactory.CreateClient("demo");
                    return await httpClient.GetStringAsync("/CustomerRepository/GetAll");
                });

            return Content(result);
        }

        public async Task<IActionResult> Sample3Async()
        {
            var policy = Policy.Handle<HttpRequestException>()
                .CircuitBreakerAsync(2, TimeSpan.FromSeconds(30));
            var result = await policy.ExecuteAsync(async () =>
            {
                using HttpClient httpClient = _httpClientFactory.CreateClient("demo");
                return await httpClient.GetStringAsync("/CustomerRepository/GetAll");
            });

            return Content(result);
        }

        public async Task<IActionResult> Sample4Async()
        {
            var policy = Policy.Handle<HttpRequestException>()
                .CircuitBreakerAsync(2, TimeSpan.FromSeconds(30));
            var policy2 = Policy.Handle<HttpRequestException>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
            var policy3 = Policy.TimeoutAsync<string>(10);
            var policies = Policy.WrapAsync(policy, policy2);

            var result = await policies.ExecuteAsync(async () =>
            {
                using HttpClient httpClient = _httpClientFactory.CreateClient("demo");
                return await httpClient.GetStringAsync("/CustomerRepository/GetAll");
            });

            return Content(result);
        }
    }
}
