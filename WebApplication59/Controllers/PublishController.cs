using DotNetCore.CAP;

using Microsoft.AspNetCore.Mvc;

namespace WebApplication59.Controllers
{
    public class PublishController : Controller
    {
        private readonly ICapPublisher _capPublisher;

        public PublishController(ICapPublisher capPublisher)
        {
            _capPublisher = capPublisher;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Sample()
        {
            var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
            await _capPublisher.PublishAsync("time", time);
            return Content(time);
        }
    }
}
