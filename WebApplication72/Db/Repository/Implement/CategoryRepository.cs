using SqlSugar;
using WebApplication72.Db.Entity;

namespace WebApplication72.Db.Repository.Implement
{
    public class CategoryRepository : BaseRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(ISqlSugarClient context) : base(context)
        {

        }
    }
}
