
using StackExchange.Redis;

namespace WebApplication51.Redis
{
    public class RedisClient : IRedisClient
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisClient(IConnectionMultiplexer connectionMultiplexer)
        {
            var servers = connectionMultiplexer.GetServers();
            _connectionMultiplexer = connectionMultiplexer;
        }

        private int GetDatabaseIndex(int? db = null)
        {
            return db.HasValue ? db.Value : 0;
        }

        private string GetFullKey(string key, bool autoAddKeyPrefix = true)
        {

            return autoAddKeyPrefix ? "WebApplication51:" + key : key;
        }

        public async Task<string> GetStringAsync(string key, int? db = null, bool autoAddKeyPrefix = true)
        {
            var database = _connectionMultiplexer.GetDatabase(GetDatabaseIndex(db));
            var fullKey = GetFullKey(key, autoAddKeyPrefix);
            var result = await database.StringGetAsync(fullKey);
            return result.ToString();
        }

        public async Task<bool> SetStringAsync(string key, string value, TimeSpan? expire = null, int? db = null, bool autoAddKeyPrefix = true)
        {
            var database = _connectionMultiplexer.GetDatabase(GetDatabaseIndex(db));
            var fullKey = GetFullKey(key, autoAddKeyPrefix);
            var result = await database.StringSetAsync(fullKey, value, expire);
            return result;
        }
    }
}
