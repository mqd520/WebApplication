using Microsoft.AspNetCore.Mvc;

using WebApplication16.Db.Entity;
using WebApplication16.Db.Services;

namespace WebApplication16.Controllers
{
    public class BaseServiceController : Controller
    {
        private readonly IBaseService<CustomerEntity> _baseService;

        public BaseServiceController(IBaseService<CustomerEntity> baseService)
        {
            _baseService = baseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllCustomers()
        {
            var ls = _baseService.GetList();
            return new JsonResult(ls);
        }
    }
}
