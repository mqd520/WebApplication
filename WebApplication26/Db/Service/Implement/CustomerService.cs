using Arch.EntityFrameworkCore.UnitOfWork;

using WebApplication26.Db.Contexts;
using WebApplication26.Db.Entity;
using WebApplication26.Db.Trans;

namespace WebApplication26.Db.Service.Implement
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<CustomerEntity> _repo;

        public CustomerService(ApplicationDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
            _repo = unitOfWork.GetRepository<CustomerEntity>();
        }

        public CustomerEntity GetByCompanyName(string companyName)
        {
            return _repo.GetFirstOrDefault(predicate: x => x.CompanyName.Contains(companyName));
        }

        [UseDbTran]
        public void TestDbTran()
        {
            var entity = new CustomerEntity
            {
                CustomerID = "ANTON",
                CompanyName = "Antonio Moreno Taquera 123"
            };
            _dbContext.Attach(entity);
            _dbContext.Entry<CustomerEntity>(entity).Property(x => x.CompanyName).IsModified = true;
            _dbContext.SaveChanges();
        }
    }
}
