using Microsoft.AspNetCore.Mvc;

using WebApplication15.Services;

namespace WebApplication15.Controllers
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

        public IActionResult GetByCustomerId()
        {
            var entity = _customerService.GetByCustomerId("ALFKI");
            return new JsonResult(entity);
        }
    }
}
