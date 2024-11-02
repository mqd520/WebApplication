using Microsoft.AspNetCore.Http;

using Moq;

using Xunit;

namespace WebApplication21.Tools.Tests
{
    public class WebRequestToolTests
    {
        [Fact()]
        public void IsAjaxRequestTest()
        {
            var mock = new Mock<HttpRequest>();
            var result = WebRequestTool.IsAjaxRequest(mock.Object);
            Xunit.Assert.True(result);
        }
    }
}