namespace WebApplication6.Tools
{
    public interface IRedisHelper
    {
        Task<string> GetStringAsync(string key, int? dbIndex = null, bool autoAddKeyPrefix = true);

        Task<bool> SetStringAsync(string key, string value, TimeSpan? expire, int? dbIndex = null, bool autoAddKeyPrefix = true);
    }
}
