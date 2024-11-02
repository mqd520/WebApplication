using Microsoft.AspNetCore.Mvc;

using WebApplication26.Db.DAO;

namespace WebApplication26.Controllers
{
    public class CustomerDAOController : Controller
    {
        private readonly ICustomerDAO _customerDAO;

        public CustomerDAOController(ICustomerDAO customerDAO)
        {
            _customerDAO = customerDAO;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            var ls = _customerDAO.GetAll();
            return new JsonResult(ls);
        }
    }
}
