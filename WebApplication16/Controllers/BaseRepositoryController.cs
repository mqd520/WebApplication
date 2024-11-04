using Microsoft.AspNetCore.Mvc;

using WebApplication16.Db.Entity;
using WebApplication16.Db.Repository;
using WebApplication16.Db.Repository.Implements;

namespace WebApplication16.Controllers
{
    public class BaseRepositoryController : Controller
    {
        private readonly IBaseRepository<CustomerEntity> _baseRepository;
        private readonly BaseRepository<CustomerEntity> _baseRepository2;

        public BaseRepositoryController(IBaseRepository<CustomerEntity> baseRepository
            , BaseRepository<CustomerEntity> baseRepository2)
        {
            _baseRepository = baseRepository;
            _baseRepository2 = baseRepository2;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult QueryAll()
        {
            var ls = _baseRepository2.GetList();
            return new JsonResult(ls);
        }
    }
}
