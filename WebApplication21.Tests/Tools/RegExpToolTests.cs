using Xunit;

namespace WebApplication21.Tools.Tests
{
    public class RegExpToolTests
    {
        [Theory]
        [InlineData("1506816370@qq.com")]
        public void IsEmailTest(string value)
        {
            var result = RegExpTool.IsEmail(value);
            Xunit.Assert.True(result);
        }

        [Theory]
        [InlineData("192.168.10.44")]
        [InlineData("192.168.10.-1")]
        [InlineData("192.168.10.256")]
        [InlineData("192.192.192.192.192")]
        [InlineData("192.168.0.1")]
        [InlineData("0.0.0.0")]
        [InlineData("1.1.1.1")]
        [InlineData("255.255.255.255")]
        [InlineData("-1.-1.-1.-1")]
        [InlineData("10.1.2.3")]
        public void IsIpTest(string value)
        {
            var result = RegExpTool.IsIp(value);
            Xunit.Assert.True(result);
        }

        [Theory]
        [InlineData("<div>")]
        [InlineData("<div></div>")]
        [InlineData("<div/>")]
        [InlineData("<label/>")]
        [InlineData("<br/>")]
        public void IsHtmlTagTest(string value)
        {
            var result = RegExpTool.IsHtmlTag(value);
            Xunit.Assert.True(result);
        }

        [Theory]
        [InlineData("简体中文")]
        [InlineData("繁體中文漢字")]
        [InlineData("123!@#qweZAS")]
        public void IsChineseCharacterTest(string value)
        {
            var result = RegExpTool.IsChineseCharacter(value);
            Xunit.Assert.True(result);
        }

        [Theory]
        [InlineData("http://baidu.com")]
        [InlineData("http://192.168.0.101")]
        [InlineData("http://192.168.0.101:8080")]
        [InlineData("http://192.168.0.101:8080/")]
        [InlineData("http://192.168.0.101:8080/Home/Index")]
        [InlineData("http://192.168.0.101:8080/Home/Index?")]
        [InlineData("http://192.168.0.101:8080/Home/Index?key=123&key2=qwer")]
        [InlineData("http://192.168.0.101:8080/Home/Index?key=123&key2=")]
        [InlineData("http://localhost:5227/Home/Index?key=123%20qwer&key2=123qwer")]
        public void IsUrlTest(string value)
        {
            var result = RegExpTool.IsUrl(value);
            Xunit.Assert.True(result);
        }
    }
}