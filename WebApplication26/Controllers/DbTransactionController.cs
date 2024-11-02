using Microsoft.AspNetCore.Mvc;

using WebApplication26.Db.Service;

namespace WebApplication26.Controllers
{
    public class DbTransactionController : Controller
    {
        private readonly ICustomerService _customerService;

        public DbTransactionController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TestDbTran()
        {
            _customerService.TestDbTran();
            return Ok("OK");
        }
    }
}
