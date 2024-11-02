using Xunit;

namespace WebApplication12.Tools.Tests
{
    public class RegExpToolTests
    {
        [Fact()]
        public void validateUsernameTest()
        {
            var result = RegExpTool.ValidateUsername("abcd123ABC_");
            Xunit.Assert.True(result);
        }

        [Fact()]
        public void validatePasswordTest()
        {
            var result = RegExpTool.ValidatePassword("abcd123ABC_");
            Xunit.Assert.True(result);
        }
    }
}