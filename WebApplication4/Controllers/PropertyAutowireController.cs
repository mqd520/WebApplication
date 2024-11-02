using Microsoft.AspNetCore.Mvc;

using WebApplication4.Autofac;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    public class PropertyAutowireController : Controller
    {
        [CustomPropertySelector]
        private ILogger<PropertyAutowireController> Logger { get; set; } = null!;

        [CustomPropertySelector]
        private ISingleService SingleService { get; set; } = null!;

        public IActionResult Index()
        {
            var value = SingleService.Fun1();
            return new ContentResult { Content = value };
        }
    }
}
