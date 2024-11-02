using System.Text.RegularExpressions;

namespace WebApplication13.Tools
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
    }
}
