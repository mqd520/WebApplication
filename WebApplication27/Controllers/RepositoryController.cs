using Arch.EntityFrameworkCore.UnitOfWork;

using Microsoft.AspNetCore.Mvc;

using WebApplication27.Db.Entity;

namespace WebApplication27.Controllers
{
    public class RepositoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RepositoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            var repo = _unitOfWork.GetRepository<CustomerEntity>();
            var ls = repo.GetPagedList();
            return new JsonResult(ls);
        }
    }
}
