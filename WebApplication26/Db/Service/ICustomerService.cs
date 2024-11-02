using WebApplication26.Db.Entity;

namespace WebApplication26.Db.Service
{
    public interface ICustomerService
    {
        CustomerEntity GetByCompanyName(string companyName);

        void TestDbTran();
    }
}
