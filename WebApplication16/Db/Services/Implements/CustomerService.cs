using WebApplication16.Db.Entity;
using WebApplication16.Db.Repository;

namespace WebApplication16.Db.Services.Implements
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

        //[UseDbTran]
        public virtual void TestTran()
        {
            var entity = new CustomerEntity
            {
                CompanyName = "Berglunds snabbkp 123",
                CustomerID = "BERGS"
            };
            var result = _repo.AsUpdateable(entity).UpdateColumns(x => new { x.CompanyName }).ExecuteCommand();
        }
    }
}
