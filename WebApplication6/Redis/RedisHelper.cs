using Microsoft.Extensions.Options;

using StackExchange.Redis;

using WebApplication6.Options;

namespace WebApplication6.Tools
{
    public class RedisHelper : IRedisHelper
    {
        private readonly IConnectionMultiplexer _connectionMultiPlexer;
        private readonly int _dbIndex;
        private readonly string _instanceName;

        public RedisHelper(IOptions<RedisOptions> redisOptions)
        {
            _connectionMultiPlexer = ConnectionMultiplexer.Connect(redisOptions.Value.ConnectionString);
            _dbIndex = redisOptions.Value.DatabaseIndex;
            _instanceName = redisOptions.Value.InstanceName;
        }

        public IDatabase GetDatabase(int? dbIndex)
        {
            var index = dbIndex.HasValue ? dbIndex.Value : _dbIndex;
            return _connectionMultiPlexer.GetDatabase(index);
        }

        public string GetFullKey(string key, bool autoAddKeyPrefix = true)
        {
            return autoAddKeyPrefix ? _instanceName + key : key;
        }

        public async Task<string> GetStringAsync(string key, int? dbIndex = null, bool autoAddKeyPrefix = true)
        {
            var database = GetDatabase(dbIndex);
            var realKey = GetFullKey(key, autoAddKeyPrefix);
            var value = await database.StringGetAsync(realKey);
            return value.ToString()!;
        }

        public async Task<bool> SetStringAsync(string key
            , string value
            , TimeSpan? expire
            , int? dbIndex = null
            , bool autoAddKeyPrefix = true)
        {
            var database = GetDatabase(dbIndex);
            var realKey = GetFullKey(key, autoAddKeyPrefix);
            var result = await database.StringSetAsync(realKey, value, expire);
            return result;
        }
    }
}
