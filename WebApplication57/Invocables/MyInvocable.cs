
using Coravel.Invocable;

namespace WebApplication57.Invocables
{
    public class MyInvocable : IInvocable
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MyInvocable(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task Invoke()
        {
            using var httpClient = _httpClientFactory.CreateClient("Demo");
            var response = await httpClient.GetAsync("https://www.baidu.com");
            var content = response.Content.ReadAsStringAsync();
            Console.WriteLine(response.StatusCode);
        }
    }
}
