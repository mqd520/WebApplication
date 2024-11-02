using Microsoft.AspNetCore.Mvc;

using WebApplication15.Db.Entity;
using WebApplication15.Db.Repository;

namespace WebApplication15.Controllers
{
    public class BaseRepositoryController : Controller
    {
        private readonly IBaseRepository<CustomerEntity> _baseRepository;

        public BaseRepositoryController(IBaseRepository<CustomerEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Get
        public IActionResult GetList()
        {
            var ls = _baseRepository.GetList();
            return new JsonResult(ls);
        }

        public IActionResult GetList2()
        {
            var ls = _baseRepository.GetList(x => x.CustomerID.StartsWith("A")
                        || x.CustomerID.StartsWith("B"));
            return new JsonResult(ls);
        }

        public IActionResult GetPageList()
        {
            var page = new SqlSugar.PageModel();
            page.PageIndex = 1;
            page.PageSize = 10;
            var ls = _baseRepository.GetPageList(x => true, page);
            return new JsonResult(ls);
        }

        public IActionResult GetById()
        {
            var entity = _baseRepository.GetById("ANATR");
            return new JsonResult(entity);
        }

        [Route("/[controller]/GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            var entity = await _baseRepository.GetByIdAsync("ANTON");
            return new JsonResult(entity);
        }
        #endregion

        #region Add
        public IActionResult Insert()
        {
            var entity = new CustomerEntity
            {
                CustomerID = "ABCDE",
                CompanyName = "ABCDEFGHIGUUU"
            };
            var result = _baseRepository.Insert(entity);
            return new ContentResult { Content = result.ToString() };
        }
        #endregion
    }
}
