namespace WebApplication51.Redis
{
    public interface IRedisClient
    {
        Task<string> GetStringAsync(string key, int? db = null, bool autoAddKeyPrefix = true);

        Task<bool> SetStringAsync(string key, string value, TimeSpan? expire = null, int? db = null, bool autoAddKeyPrefix = true);
    }
}
