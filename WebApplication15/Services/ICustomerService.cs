using WebApplication15.Db.Entity;

namespace WebApplication15.Services
{
    public interface ICustomerService : IBaseService<CustomerEntity>
    {
        CustomerEntity GetByCustomerId(string customerId);
    }
}
