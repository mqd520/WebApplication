using System.Text.RegularExpressions;

namespace WebApplication21.Tools
{
    public static class RegExpTool
    {
        public static bool IsUsername(string value)
        {
            var reg = new Regex(@"^[a-zA-Z]{1}[0-9a-zA-Z_]{4,14}$", RegexOptions.IgnoreCase);
            return reg.IsMatch(value);
        }

        public static bool IsPassword(string value)
        {
            var reg = new Regex(@"^[a-zA-Z]{1}[0-9a-zA-Z_]{7,14}$", RegexOptions.IgnoreCase);
            return reg.IsMatch(value);
        }

        public static bool IsEmail(string value)
        {
            var reg = new Regex("^[a-z\\d]+(\\.[a-z\\d]+)*@([\\da-z](-[\\da-z])?)+(\\.{1,2}[a-z]+)+$", RegexOptions.IgnoreCase);
            return reg.IsMatch(value);
        }

        public static bool IsIp(string value)
        {
            var reg = new Regex(
                "^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
            return reg.IsMatch(value);
        }

        public static bool IsHtmlTag(string value)
        {
            var reg = new Regex("^<([a-z]+)([^<]+)*(?:>(.*)<\\/\\1>|\\s+\\/>)$", RegexOptions.IgnoreCase);
            return reg.IsMatch(value);
        }

        public static bool IsChineseCharacter(string value)
        {
            var reg = new Regex("^[\\u2E80-\\u9FFF]+$");
            return reg.IsMatch(value);
        }

        public static bool IsUrl(string value)
        {
            var reg = new Regex("^(https?|ftp):\\/\\/(\\w+\\.)+[\\w\\.]+(\\:[0-9]{2,5})?(\\/[\\w\\-\\u4e00-\\u9fa5]*)*\\/?(\\?[\\w\\-\\u4e00-\\u9fa5%=&]*)?(#\\w*)?$", RegexOptions.IgnoreCase);
            return reg.IsMatch(value);
        }
    }
}
