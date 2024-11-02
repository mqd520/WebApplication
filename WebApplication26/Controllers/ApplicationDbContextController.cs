using Microsoft.AspNetCore.Mvc;

using WebApplication26.Db.Contexts;

namespace WebApplication26.Controllers
{
    public class ApplicationDbContextController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ApplicationDbContextController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            var ls = _applicationDbContext.Customers.AsQueryable().ToList();
            return new JsonResult(ls);
        }

        public IActionResult GetPageList(int page, int pageSize)
        {
            var ls = _applicationDbContext.Customers.AsQueryable().Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return new JsonResult(ls);
        }
    }
}
