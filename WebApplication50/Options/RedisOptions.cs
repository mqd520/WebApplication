namespace WebApplication50.Options
{
    public class RedisOptions
    {
        public const string SectionName = "Redis";

        public string ConnectionString { get; set; } = string.Empty;
        public string InstanceName { get; set; } = "WebApplication6:";
        public int DatabaseIndex { get; set; } = 0;
    }
}
