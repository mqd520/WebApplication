using Microsoft.AspNetCore.Mvc;

using WebApplication16.Db.Repository;

namespace WebApplication16.Controllers
{
    public class CategoryRepositoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryRepositoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            var ls = _categoryRepository.GetList();
            return new JsonResult(ls);
        }
    }
}
