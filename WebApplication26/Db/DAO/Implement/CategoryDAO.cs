using WebApplication16.Db.Entity;

using WebApplication26.Db.Contexts;

namespace WebApplication26.Db.DAO.Implement
{
    public class CategoryDAO : ICategoryDAO
    {
        public readonly ApplicationDbContext Context;

        public CategoryDAO(ApplicationDbContext context)
        {
            Context = context;
        }

        public IList<CategoryEntity> GetAll()
        {
            return Context.Categories.ToList();
        }
    }
}
