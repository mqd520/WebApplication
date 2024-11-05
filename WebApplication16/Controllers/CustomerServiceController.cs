using Microsoft.AspNetCore.Mvc;

using WebApplication16.Db.Services;

namespace WebApplication16.Controllers
{
    public class CustomerServiceController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerServiceController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TestTran()
        {
            _customerService.TestTran();
            return Ok("Ok");
        }
    }
}
