using Arch.EntityFrameworkCore.UnitOfWork;

using WebApplication26.Db.Contexts;
using WebApplication26.Db.Entity;
using WebApplication26.Db.Trans;

namespace WebApplication26.Db.Service.Implement
{
    public class CustomerService : BaseService<CustomerEntity>, ICustomerService
    {
        public CustomerService(ApplicationDbContext dbContext
            , IUnitOfWork unitOfWork)
            : base(dbContext, unitOfWork)
        {

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
            _context.Attach(entity);
            _context.Entry<CustomerEntity>(entity).Property(x => x.CompanyName).IsModified = true;
            _context.SaveChanges();
        }
    }
}
