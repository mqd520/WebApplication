﻿namespace WebApplication6.Options
{
    public class RedisOptions
    {
        public const string SectionName = "Redis";

        public string ConnectionString { get; set; } = string.Empty;
        public string InstanceName { get; set; } = string.Empty;
        public int DatabaseIndex { get; set; } = 0;
    }
}
