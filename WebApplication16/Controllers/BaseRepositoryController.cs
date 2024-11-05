using Microsoft.AspNetCore.Mvc;

using WebApplication16.Db.Entity;
using WebApplication16.Db.Repository;

namespace WebApplication16.Controllers
{
    public class BaseRepositoryController : Controller
    {
        private readonly IBaseRepository<CustomerEntity> _baseRepository;

        public BaseRepositoryController(IBaseRepository<CustomerEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllCustomers()
        {
            var ls = _baseRepository.GetList();
            return new JsonResult(ls);
        }
    }
}
