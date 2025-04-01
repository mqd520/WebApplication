using Xunit;

namespace WebApplication30.Common.Tests
{
    public class SensitiveDataUtilTests
    {
        [Fact()]
        public void MaskEmailTest()
        {
            var result = SensitiveDataUtil.MaskEmail("1506816370@qq.com");
            Xunit.Assert.Equal("15***@qq.com", result);

            var result2 = SensitiveDataUtil.MaskEmail("");
            Xunit.Assert.Equal("", result2);

            var result3 = SensitiveDataUtil.MaskEmail("null");
            Xunit.Assert.Equal("null", result3);

            var result4 = SensitiveDataUtil.MaskEmail("1506816370qq.com");
            Xunit.Assert.Equal("1506816370qq.com", result4);
        }
    }
}