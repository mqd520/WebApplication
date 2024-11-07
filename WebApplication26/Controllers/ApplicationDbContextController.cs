using Microsoft.AspNetCore.Mvc;

using WebApplication26.Db.Contexts;
using WebApplication26.Db.Entity;

namespace WebApplication26.Controllers
{
    public class ApplicationDbContextController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ApplicationDbContextController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Query
        public IActionResult GetAll()
        {
            var ls = _applicationDbContext.Customers.AsQueryable().ToList();
            return new JsonResult(ls);
        }

        public IActionResult GetPageList(int page, int pageSize)
        {
            var ls = _applicationDbContext.Customers.AsQueryable().Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return new JsonResult(ls);
        }
        #endregion

        #region Add
        public IActionResult Add()
        {
            var entity = new CustomerEntity
            {
                CustomerID = "ABCDE",
                CompanyName = "ABCDE"
            };
            var result = _applicationDbContext.Customers.Add(entity);
            _applicationDbContext.SaveChanges();
            return Ok("Ok");
        }

        public async Task<IActionResult> Add2()
        {
            var entity = new CustomerEntity
            {
                CustomerID = "EDCBA",
                CompanyName = "EDCBA"
            };
            var result = await _applicationDbContext.Customers.AddAsync(entity);
            _applicationDbContext.SaveChanges();
            return Ok("Ok");
        }
        #endregion
    }
}
