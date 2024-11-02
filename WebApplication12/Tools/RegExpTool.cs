using System.Text.RegularExpressions;

namespace WebApplication12.Tools
{
    public static class RegExpTool
    {
        public static bool ValidateUsername(string value)
        {
            var reg = new Regex(@"^[a-zA-Z]{1}[0-9a-zA-Z_]{4,14}$", RegexOptions.IgnoreCase);
            return reg.IsMatch(value);
        }

        public static bool ValidatePassword(string value)
        {
            var reg = new Regex(@"^[a-zA-Z]{1}[0-9a-zA-Z_]{7,14}$", RegexOptions.IgnoreCase);
            return reg.IsMatch(value);
        }
    }
}
