using Microsoft.AspNetCore.Mvc;

using TanvirArjel.EFCore.GenericRepository;

using WebApplication29.Db;
using WebApplication29.Db.Entity;

namespace WebApplication29.Controllers
{
    public class RepositoryController : Controller
    {
        private readonly IRepository<ApplicationDbContext> _repository;

        public RepositoryController(IRepository<ApplicationDbContext> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetList()
        {
            var customers = await _repository.GetListAsync<CustomerEntity>();
            return Json(customers);
        }

        public async Task<IActionResult> GetListWithPagination(int pageIndex, int pageSize)
        {
            var specification = new PaginationSpecification<CustomerEntity>();
            specification.PageIndex = pageIndex;
            specification.PageSize = pageSize;
            var customers = await _repository.GetListAsync<CustomerEntity>(specification);
            return Json(customers);
        }

        public async Task<IActionResult> GetById(string customerId)
        {
            var customer = await _repository.GetByIdAsync<CustomerEntity>(customerId);
            return Json(customer);
        }

        public async Task<IActionResult> Get(string customerId)
        {
            var customer = await _repository.GetAsync<CustomerEntity>(x => x.CustomerID == customerId);
            return Json(customer);
        }

        public async Task<IActionResult> Add()
        {
            var customer = new CustomerEntity
            {
                CustomerID = "ERCSH",
                CompanyName = "Company Name",
                ContactName = "Contact Name",
                ContactTitle = "Contact Title",
                Address = "Address",
                City = "Xiang Yang",
                Region = "Region",
                PostalCode = "444100",
                Country = "China",
                Phone = "18271251097",
                Fax = "Fax"
            };

            await _repository.AddAsync(customer);
            var count = await _repository.SaveChangesAsync();

            return Ok(count);
        }
    }
}
