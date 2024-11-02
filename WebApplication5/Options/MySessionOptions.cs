namespace WebApplication5.Options
{
    public class MySessionOptions
    {
        public const string SectionName = "Session";

        public int Timeout { get; set; } = 20;

        public string Prefix { get; set; } = "Session:";

        public MySessionCookieOptions Cookie { get; set; } = new MySessionCookieOptions();
    }
}
