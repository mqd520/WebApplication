using SqlSugar;

using WebApplication16.Db.Entity;

namespace WebApplication16.Db.Repository.Implements
{
    public class CategoryRepository : BaseRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(ISqlSugarClient context) : base(context)
        {

        }
    }
}
