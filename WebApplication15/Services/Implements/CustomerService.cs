using WebApplication15.Db.Entity;
using WebApplication15.Db.Repository;

namespace WebApplication15.Services.Implements
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
            return _repo.GetById(customerId);
        }
    }
}
