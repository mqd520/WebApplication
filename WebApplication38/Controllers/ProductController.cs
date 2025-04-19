using Microsoft.AspNetCore.Mvc;

using WebApplication38.Dto;

namespace WebApplication38.Controllers
{
    [ApiController]
    [Route("~/api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly IList<ProductInfo> _ls;

        static ProductController()
        {
            _ls = new List<ProductInfo>();
            _ls.Add(new ProductInfo
            {
                Id = 1,
                Name = "Product 1",
                Description = "Description 1"
            });
            _ls.Add(new ProductInfo
            {
                Id = 2,
                Name = "Product 2",
                Description = "Description 2"
            });
        }

        [HttpGet]
        public IEnumerable<ProductInfo> GetAll()
        {
            return _ls.AsEnumerable();
        }

        [HttpGet]
        [Route("{productId}")]
        public ProductInfo? GetById(int productId)
        {
            var item = _ls.FirstOrDefault(x => x.Id == productId);
            return item;
        }
    }
}
