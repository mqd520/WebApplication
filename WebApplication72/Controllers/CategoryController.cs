using Microsoft.AspNetCore.Mvc;

using WebApplication72.Autofac;
using WebApplication72.Common;
using WebApplication72.Db.Entity;
using WebApplication72.Db.Repository;
using WebApplication72.Def;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication72.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [CustomPropertySelector]
        private ILogger<CategoryController> Logger { get; set; }

        [CustomPropertySelector]
        private ICategoryRepository CategoryRepository { get; set; }

        #region Query
        [HttpGet]
        public ApiResultData GetAll()
        {
            Logger.LogInformation("Get All Categories");
            var ls = CategoryRepository.QueryAll();
            var principal = HttpContext.User;
            return CommonTool.CreateApiResult(success: true, data: ls);
        }

        [HttpGet]
        public ActionResult GetFirstPicture()
        {
            Logger.LogInformation("Get First Category Picture");
            var entity = CategoryRepository.QueryById<int>(1);
            var fcr = new FileContentResult(entity.Picture, "image/jpeg");
            return fcr;
        }
        #endregion

        #region Delete
        [HttpGet]
        public ApiResultData DeleteById()
        {
            Logger.LogInformation("Delete Category By Id");
            bool b = CategoryRepository.DeleteById<int>(9);
            return CommonTool.CreateApiResult(success: b);
        }

        [HttpGet]
        public ApiResultData DeleteByIds()
        {
            Logger.LogInformation("Delete Category By Id List");
            var ids = new int[] { 21, 22 };
            var n = CategoryRepository.DeleteByIds<int>(ids);
            return CommonTool.CreateApiResult(success: ids.Length == n);
        }

        [HttpGet]
        public ApiResultData DeleteByWhere()
        {
            Logger.LogInformation("Delete Category By Where");
            var ids = new int[] { 23, 24 };
            var n = CategoryRepository.DeleteByWhere(x => ids.Contains(x.CategoryID));
            return CommonTool.CreateApiResult(success: true, msg: n.ToString());
        }

        [HttpGet]
        public ApiResultData DeleteByWhere2()
        {
            Logger.LogInformation("Delete Category By Where2");
            var sql = "';delete from categories;";
            var sql2 = "';";
            var names = new string[] { sql, sql2 };
            var n = CategoryRepository.DeleteByWhere(x => names.Contains(x.CategoryName));
            return CommonTool.CreateApiResult(success: true, msg: n.ToString());
        }
        #endregion

        #region Add
        [HttpGet]
        public ApiResultData AddAndReturnId()
        {
            Logger.LogInformation("Add And Return Id");
            var entity = new CategoryEntity
            {
                CategoryName = "Category Name",
                Description = "Description",
                Picture = []
            };
            var id = CategoryRepository.AddAndReturnId(entity);
            return CommonTool.CreateApiResult(success: id > 0, msg: id.ToString());
        }
        #endregion
    }
}
