using Arch.EntityFrameworkCore.UnitOfWork;

using WebApplication16.Db.Entity;

using WebApplication26.Db.Contexts;

namespace WebApplication26.Db.Service.Implement
{
    public class CategoryService : BaseService<CategoryEntity>, ICategoryService
    {
        public CategoryService(ApplicationDbContext dbContext
            , IUnitOfWork unitOfWork)
            : base(dbContext, unitOfWork)
        {

        }
    }
}
