using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using WebApplication25.DTO;
using WebApplication25.VO;

namespace WebApplication25.Controllers
{
    public class AutoMapperController : Controller
    {
        private readonly IMapper _mapper;

        public AutoMapperController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2(UserLoginRequestVO userLoginVO)
        {
            var dto = _mapper.Map<UserLoginRequestDTO>(userLoginVO);
            return new JsonResult(dto);
        }

        public IActionResult Index3()
        {
            var result = new UserLoginResultDTO
            {
                Code = 0,
                Message = "Success"
            };
            var vo = _mapper.Map<UserLoginResultVO>(result);
            return new JsonResult(vo);
        }

        public IActionResult Index4()
        {
            var result = new UserLoginResultDTO
            {
                Code = 1001,
                Message = "Invalid UserName"
            };
            var vo = _mapper.Map<UserLoginResultVO>(result);
            return new JsonResult(vo);
        }

        public IActionResult Index5()
        {
            var result = new UserLoginResultDTO
            {
                Code = 1002,
                Message = "User Password Error"
            };
            var vo = _mapper.Map<UserLoginResultVO>(result);
            return new JsonResult(vo);
        }
    }
}
