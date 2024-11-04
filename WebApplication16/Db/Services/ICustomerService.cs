using WebApplication16.Db.Entity;

namespace WebApplication16.Services
{
    public interface ICustomerService : IBaseService<CustomerEntity>
    {
        CustomerEntity GetByCustomerId(string customerId);
    }
}
