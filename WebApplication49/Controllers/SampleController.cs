using Microsoft.AspNetCore.Mvc;

using NuGet.Configuration;

namespace WebApplication49.Controllers
{
    public class SampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test1()
        {
            var hrm = new HttpRequestMessage();
            hrm.Method = HttpMethod.Get;
            hrm.RequestUri = new Uri("https://www.baidu.com");

            var hmh = new SocketsHttpHandler
            {
                AllowAutoRedirect = true,
                UseProxy = true,
                Proxy = new WebProxy("http://127.0.0.1:8888")
            };
            var hmi = new HttpMessageInvoker(hmh);
            var reponse = hmi.Send(hrm, Request.HttpContext.RequestAborted);

            return Content(Response.StatusCode.ToString());
        }
    }
}
