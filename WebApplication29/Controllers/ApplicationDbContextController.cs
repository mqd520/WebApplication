using Microsoft.AspNetCore.Mvc;

using WebApplication29.Db;

namespace WebApplication29.Controllers
{
    public class ApplicationDbContextController : Controller
    {
        private ApplicationDbContext _applicationDbContext;

        public ApplicationDbContextController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CanConnect()
        {
            var result = _applicationDbContext.Database.CanConnect();
            return Ok(result);
        }
    }
}
