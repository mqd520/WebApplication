namespace WebApplication11.Options
{
    public class JWTOptions
    {
        public const string Section = "JWT";

        public string Audience { get; set; } = string.Empty;

        public string Issuer { get; set; } = string.Empty;

        public string SecurityKey { get; set; } = string.Empty;

        /// <summary>
        /// Expire Time(Unit: Minute)
        /// </summary>
        public int ExpireTime { get; set; } = 30;
    }
}
