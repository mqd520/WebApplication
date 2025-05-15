using Mapster;

using Microsoft.AspNetCore.Mvc;

using WebApplication76.Dto;
using WebApplication76.Entity;

namespace WebApplication76.Controllers
{
    public class SampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sample()
        {
            var entity = new UserInfoEntity
            {
                Id = 1001,
                Name = "John Doe"
            };
            var dto = entity.Adapt<UserInfoDto>();
            return Json(dto);
        }

        public IActionResult Sample2()
        {
            var entity = new UserInfo2Entity
            {
                Id = 1002,
                Name = "Jane Doe"
            };
            var dto = entity.Adapt<UserInfo2Dto>();
            return Json(dto);
        }

        public IActionResult Sample3()
        {
            var entity = new UserInfo3Entity
            {
                Id = 1003,
                Name = "Doe John"
            };
            var dto = entity.Adapt<UserInfo3Dto>();
            return Json(dto);
        }
    }
}
