using Microsoft.AspNetCore.Mvc;

using WebApplication26.Db.Service;

namespace WebApplication26.Controllers
{
    public class CategoryServiceController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryServiceController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return View();
        }
    }
}
