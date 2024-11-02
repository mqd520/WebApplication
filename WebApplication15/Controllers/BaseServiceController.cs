using Microsoft.AspNetCore.Mvc;

using WebApplication15.Db.Entity;
using WebApplication15.Services;

namespace WebApplication15.Controllers
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

        public IActionResult GetList()
        {
            var ls = _baseService.GetList();
            return new JsonResult(ls);
        }

        public IActionResult GetPageList()
        {
            int total = 0;
            var ls = _baseService.GetPageList(0, 10, out total);
            return new JsonResult(new { Data = ls, Total = total });
        }
    }
}
