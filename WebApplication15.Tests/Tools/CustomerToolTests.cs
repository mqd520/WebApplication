using Xunit;
using Xunit.Abstractions;

using Assert = Xunit.Assert;

namespace WebApplication15.Tools.Tests
{
    public class CustomerToolTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public CustomerToolTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact()]
        public void CreateCustomerIdTest()
        {
            var customerId = CustomerTool.CreateCustomerId();
            Assert.NotNull(customerId);
        }

        [Fact()]
        public void CreateCustomerIdTest2()
        {
            var ls = new List<string>();
            for (int i = 0; i < 100000; i++)
            {
                var customerId = CustomerTool.CreateCustomerId();
                ls.Add(customerId);
            }

            var ls2 = ls.GroupBy(x => x)
                        .Where(x => x.Count() > 1)
                        .Select(x =>
                        {
                            return new { Key = x.Key, Count = x.Count() };
                        }).ToList();
            if (ls2.Count > 0)
            {
                foreach (var item in ls2)
                {
                    _testOutputHelper.WriteLine($"CustomerId: {item.Key}, Count: {item.Count}");
                }
            }
            else
            {
                _testOutputHelper.WriteLine("No Repeat CustomerId");
            }
        }

        [Fact()]
        public void CreateCustomerIdTest3()
        {
            var ls = new List<string>();
            for (int i = 0; i < 100000; i++)
            {
                var customerId = CustomerTool.CreateCustomerId();
                ls.Add(customerId);
                Thread.Sleep(100);
            }

            var ls2 = ls.GroupBy(x => x)
                .Where(x => x.Count() > 1)
                .Select(x =>
                {
                    return new { Key = x.Key, Count = x.Count() };
                }).ToList();
            if (ls2.Count > 0)
            {
                foreach (var item in ls2)
                {
                    _testOutputHelper.WriteLine($"CustomerId: {item.Key}, Count: {item.Count}");
                }
            }
            else
            {
                _testOutputHelper.WriteLine("No Repeat CustomerId");
            }
        }
    }
}