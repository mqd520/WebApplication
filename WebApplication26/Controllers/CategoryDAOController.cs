using Microsoft.AspNetCore.Mvc;

using WebApplication26.Db.DAO;

namespace WebApplication26.Controllers
{
    public class CategoryDAOController : Controller
    {
        private readonly ICategoryDAO _categoryDAO;

        public CategoryDAOController(ICategoryDAO categoryDAO)
        {
            _categoryDAO = categoryDAO;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            var ls = _categoryDAO.GetAll();
            return new JsonResult(ls);
        }
    }
}
