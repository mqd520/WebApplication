using Microsoft.AspNetCore.Mvc;

using Xunit;

namespace WebApplication23.Controllers.Tests
{
    public class TestControllerTests
    {
        [Fact()]
        public void Index_Returns_ViewResult()
        {
            var controller = new TestController();
            var result = controller.Index();
            Xunit.Assert.IsType<ViewResult>(result);
        }
    }
}