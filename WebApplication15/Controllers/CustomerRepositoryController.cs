using Microsoft.AspNetCore.Mvc;

using WebApplication15.Db.Repository;

namespace WebApplication15.Controllers
{
    public class CustomerRepositoryController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerRepositoryController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult QueryAllCustomers()
        {
            var ls = _customerRepository.QueryAllCustomers();
            return new JsonResult(ls);
        }
    }
}
