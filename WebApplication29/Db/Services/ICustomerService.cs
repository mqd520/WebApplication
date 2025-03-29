using WebApplication29.Db.Entity;

namespace WebApplication29.Db.Services
{
    public interface ICustomerService
    {
        Task<IList<CustomerEntity>> GetAllCustomersAsync();
    }
}
