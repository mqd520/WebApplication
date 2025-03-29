using Microsoft.AspNetCore.Mvc;

using WebApplication29.Db.Services;

namespace WebApplication29.Controllers
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

        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Json(customers);
        }
    }
}
