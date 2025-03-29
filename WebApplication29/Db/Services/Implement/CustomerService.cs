
using TanvirArjel.EFCore.GenericRepository;

using WebApplication29.Db.Entity;

namespace WebApplication29.Db.Services.Implement
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<ApplicationDbContext> _repository;

        public CustomerService(IRepository<ApplicationDbContext> repository)
        {
            _repository = repository;
        }

        public async Task<IList<CustomerEntity>> GetAllCustomersAsync()
        {
            return await _repository.GetListAsync<CustomerEntity>();
        }
    }
}
