using WebApplication16.Db.Entity;
using WebApplication16.Db.Repository;

namespace WebApplication16.Services.Implements
{
    public class CustomerService : BaseService<CustomerEntity>, ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public virtual CustomerEntity GetByCustomerId(string customerId)
        {
            return _baseRepo.GetById(customerId);
        }
    }
}
