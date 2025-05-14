namespace WebApplication72.Config
{
    public static class MyConfig
    {
        public static DbOptions DbOptions { get; private set; }
        public static JwtOptions JwtOptions { get; private set; }
        public static SessionOptions SessionOptions { get; private set; }
        public static RedisOptions RedisOptions { get; private set; }

        public static void Init(WebApplicationBuilder builder)
        {
            {
                var option = builder.Configuration.GetSection("ConnectionStrings").Get<DbOptions>();
                if (option != null)
                {
                    DbOptions = option;
                }
            }

            {
                var option = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();
                if (option != null)
                {
                    JwtOptions = option;
                }
            }

            {
                var option = builder.Configuration.GetSection("Session").Get<SessionOptions>();
                if (option != null)
                {
                    SessionOptions = option;
                }
            }

            {
                var option = builder.Configuration.GetSection("Redis").Get<RedisOptions>();
                if (option != null)
                {
                    RedisOptions = option;
                }
            }
        }
    }
}
