using WebApplication16.Db.Entity;

namespace WebApplication16.Db.Services
{
    public interface ICustomerService : IBaseService<CustomerEntity>
    {
        CustomerEntity GetByCustomerId(string customerId);

        void TestTran();
    }
}
