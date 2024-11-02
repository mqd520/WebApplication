using Arch.EntityFrameworkCore.UnitOfWork;

using Microsoft.AspNetCore.Mvc;

using WebApplication26.Db.Entity;
using WebApplication26.Db.Service;

namespace WebApplication26.Controllers
{
    public class CustomerServiceController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IRepository<CustomerEntity> _repo;

        public CustomerServiceController(ICustomerService customerService
            , IUnitOfWork unitOfWork)
        {
            _customerService = customerService;
            _repo = unitOfWork.GetRepository<CustomerEntity>();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            var ls = _repo.GetPagedList();
            return new JsonResult(ls);
        }

        public IActionResult GetPageList(int page, int pageSize)
        {
            var ls = _repo.GetPagedList(pageIndex: page, pageSize: pageSize);
            return new JsonResult(ls);
        }

        public IActionResult GetByCustomerId(string customerId)
        {
            var entity = _repo.GetFirstOrDefault(predicate: x => x.CustomerID.Contains(customerId));
            return new JsonResult(entity);
        }

        public IActionResult GetByCompanyName(string companyName)
        {
            var entity = _customerService.GetByCompanyName(companyName);
            return new JsonResult(entity);
        }
    }
}
