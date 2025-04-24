using System.Text;

namespace WebApplication38.Tools
{
    public static class Base64Helper
    {
        public static string Base64UrlEncode(byte[] input)
        {
            var base64 = Convert.ToBase64String(input);
            base64 = base64.Split('=')[0]; // Remove any trailing '='s
            base64 = base64.Replace('+', '-'); // 62nd char of encoding
            base64 = base64.Replace('/', '_'); // 63rd char of encoding
            return base64;
        }

        public static string Base64UrlEncode(string input)
        {
            var text = Encoding.UTF8.GetBytes(input);
            return Base64UrlEncode(text);
        }

        public static string Base64UrlDecode(string input)
        {
            input += "=";
            input = input.Replace('-', '+');
            input = input.Replace('_', '/');
            var buf = Convert.FromBase64String(input);
            return Encoding.UTF8.GetString(buf);
        }
    }
}
