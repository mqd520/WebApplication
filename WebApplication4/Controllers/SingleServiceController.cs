using Microsoft.AspNetCore.Mvc;

using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    public class SingleServiceController : Controller
    {
        private readonly ISingleService _singleService;
        private readonly ISingleService _singleService2;

        public SingleServiceController(ISingleService singleService
            , ISingleService singleService2)
        {
            _singleService = singleService;
            _singleService2 = singleService2;
        }

        public IActionResult Index()
        {
            var text = _singleService.Fun1();
            return new ContentResult { Content = text };
        }

        public IActionResult Index2()
        {
            var flag = _singleService == _singleService2;
            return new ContentResult { Content = flag.ToString() };
        }

        public IActionResult Index3()
        {
            var text = _singleService.Fun2();
            return new ContentResult { Content = text };
        }
    }
}
