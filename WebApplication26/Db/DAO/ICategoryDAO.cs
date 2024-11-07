using WebApplication16.Db.Entity;

namespace WebApplication26.Db.DAO
{
    public interface ICategoryDAO
    {
        IList<CategoryEntity> GetAll();
    }
}
