using WebApplication16.Db.Entity;
using WebApplication16.Db.Interceptors;
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

        [UseDbTran]
        public virtual void TestTran()
        {
            var entity = new CustomerEntity
            {
                CompanyName = "Berglunds snabbkp " + DateTime.Now.ToString("mm:ss.fff"),
                CustomerID = "BERGS"
            };
            var result = _repo.AsUpdateable(entity).UpdateColumns(x => new { x.CompanyName }).ExecuteCommand();

            var entity2 = new CustomerEntity
            {
                CompanyName = "Blauer See Delikatessen Blauer See Delikatessen Blauer See Delikatessen Blauer See Delikatessen " + DateTime.Now.ToString("mm:ss.fff"),
                CustomerID = "BLAUS"
            };
            var result2 = _repo.AsUpdateable(entity2).UpdateColumns(x => new { x.CompanyName }).ExecuteCommand();
        }
    }
}
