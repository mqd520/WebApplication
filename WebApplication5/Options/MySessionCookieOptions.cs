namespace WebApplication5.Options
{
    public class MySessionCookieOptions
    {
        public const string SectionName = "Cookie";

        public string Name { get; set; } = string.Empty;
        public bool HttpOnly { get; set; } = true;
    }
}
