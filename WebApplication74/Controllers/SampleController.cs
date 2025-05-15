using Microsoft.AspNetCore.Mvc;

using WebApplication74.Services;

namespace WebApplication74.Controllers
{
    public class SampleController : Controller
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public SampleController(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sample()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var myService = scope.ServiceProvider.GetRequiredService<IMyService>();
            myService.DoSomething();
            return Content("Ok");
        }
    }
}
