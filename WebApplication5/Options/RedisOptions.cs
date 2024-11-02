﻿namespace WebApplication5.Options
{
    public class RedisOptions
    {
        public const string SectionName = "Redis";

        public string ConnectionString { get; set; } = string.Empty;
        public string InstanceName { get; set; } = "WebApplication5:";
        public int DatabaseIndex { get; set; } = 0;
    }
}
