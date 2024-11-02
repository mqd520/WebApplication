using WebApplication15.Db.Entity;

namespace WebApplication15.Db.Repository
{
    public interface ICustomerRepository : IBaseRepository<CustomerEntity>
    {
        IList<CustomerEntity> QueryAllCustomers();
    }
}
