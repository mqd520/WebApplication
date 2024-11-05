using Microsoft.AspNetCore.Mvc;

using WebApplication16.Db.Repository;

namespace WebApplication16.Controllers
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

        public IActionResult GetAll()
        {
            var ls = _customerRepository.GetList();
            return new JsonResult(ls);
        }
    }
}
