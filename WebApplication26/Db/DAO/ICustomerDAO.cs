using WebApplication26.Db.Entity;

namespace WebApplication26.Db.DAO
{
    public interface ICustomerDAO
    {
        IList<CustomerEntity> GetAll();
    }
}
