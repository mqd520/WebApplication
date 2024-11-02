using Moq;

using SqlSugar;

using WebApplication15.Db.Entity;
using WebApplication15.Services;

using Xunit;
using Xunit.Sdk;

namespace WebApplication15.Db.Repository.Implements.Tests
{
    public class BaseRepositoryTests
    {
        private readonly TestOutputHelper _outputHelper;
        private readonly BaseRepository<CustomerEntity> _baseRepository;

        public BaseRepositoryTests()
        {
            _outputHelper = new TestOutputHelper();
            var db = new Mock<SqlSugarClient>();
            var mockTestService = new Mock<ITestService>();
            var text = mockTestService.Object.Fun1();
            _baseRepository = new BaseRepository<CustomerEntity>(db.Object);
        }

        [Fact()]
        public void GetPageListTest()
        {
            int total = 0;
            var ls = _baseRepository.GetPageList(1, 10, out total);
            if (ls != null)
            {
                foreach (var item in ls)
                {
                    _outputHelper.WriteLine($"{item}");
                }
            }
            Xunit.Assert.NotNull(ls);
        }
    }
}