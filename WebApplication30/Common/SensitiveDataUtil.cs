namespace WebApplication30.Common
{
    public class SensitiveDataUtil
    {
        public static string MaskEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return email;
            }
            var parts = email.Split('@');
            if (parts.Length != 2)
            {
                return email;
            }
            var name = parts[0];
            var domain = parts[1];
            if (name.Length <= 2)
            {
                return email;
            }
            return $"{name.Substring(0, 2)}***@{domain}";
        }
    }
}
