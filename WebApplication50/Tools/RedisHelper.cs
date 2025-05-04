using Newtonsoft.Json;

using StackExchange.Redis;

using WebApplication50.Options;

namespace WebApplication50.Tools
{
    public class RedisHelper : IRedisHelper
    {
        private readonly ConnectionMultiplexer connectionMultiPlexer;
        private readonly int dbIndex;
        private readonly string redisKeyPrefix;

        public RedisHelper(RedisOptions redisOptions)
        {
            var config = new ConfigurationOptions();
            connectionMultiPlexer = ConnectionMultiplexer.Connect(redisOptions.ConnectionString.ToString());
            dbIndex = redisOptions.DatabaseIndex;
            redisKeyPrefix = redisOptions.InstanceName;
        }

        public IDatabase GetDatabase(int db)
        {
            var database = connectionMultiPlexer.GetDatabase(db);
            return database;
        }

        public string GetRedisKey(string key)
        {
            return redisKeyPrefix + key;
        }

        public string GetString(string key)
        {
            var value = GetDatabase(dbIndex).StringGet(GetRedisKey(key));
            return value.ToString();
        }

        public bool SetString(string key
            , string value
            , TimeSpan? expire)
        {
            return GetDatabase(dbIndex).StringSet(GetRedisKey(key), value, expire);
        }

        public int? GetInt32(string key)
        {
            var value = GetDatabase(dbIndex).StringGet(GetRedisKey(key));
            return value.IsNull ? null : (int)value;
        }

        public bool SetInt32(string key, int value, TimeSpan? expire)
        {
            return GetDatabase(dbIndex).StringSet(GetRedisKey(key), value, expire);
        }

        public Int16? GetInt16(string key)
        {
            var value = GetDatabase(dbIndex).StringGet(GetRedisKey(key));
            return value.IsNull ? null : (Int16)value;
        }

        public bool SetInt16(string key
            , Int16 value
            , TimeSpan? expire)
        {
            return GetDatabase(dbIndex).StringSet(GetRedisKey(key), value, expire);
        }

        public Int64? GetInt64(string key)
        {
            var value = GetDatabase(dbIndex).StringGet(GetRedisKey(key));
            return value.IsNull ? null : (Int64)value;
        }

        public bool SetInt64(string key
            , Int64 value
            , TimeSpan? expire)
        {
            return GetDatabase(dbIndex).StringSet(GetRedisKey(key), value, expire);
        }

        public bool? GetBoolean(string key)
        {
            var value = GetDatabase(dbIndex).StringGet(GetRedisKey(key));
            return value.IsNull ? null : Convert.ToBoolean(value.ToString());
        }

        public bool SetBoolean(string key
            , bool value
            , TimeSpan? expire)
        {
            return GetDatabase(dbIndex).StringSet(GetRedisKey(key), value ? "True" : "False", expire);
        }

        public float? GetFloat(string key)
        {
            var value = GetDatabase(dbIndex).StringGet(GetRedisKey(key));
            return value.IsNull ? null : (float)value;
        }

        public bool SetFloat(string key
            , float value
            , TimeSpan? expire)
        {
            return GetDatabase(dbIndex).StringSet(GetRedisKey(key), value, expire);
        }

        public double? GetDouble(string key)
        {
            var value = GetDatabase(dbIndex).StringGet(GetRedisKey(key));
            return value.IsNull ? null : (double)value;
        }

        public bool SetDouble(string key
            , double value
            , TimeSpan? expire)
        {
            return GetDatabase(dbIndex).StringSet(GetRedisKey(key), value, expire);
        }

        public decimal? GetDecimal(string key)
        {
            var value = GetDatabase(dbIndex).StringGet(GetRedisKey(key));
            return value.IsNull ? null : (decimal)value;
        }

        public bool SetDecimal(string key
            , decimal value
            , TimeSpan? expire)
        {
            return GetDatabase(dbIndex).StringSet(GetRedisKey(key), value.ToString(), expire);
        }

        public DateTime? GetDatetime(string key)
        {
            var value = GetDatabase(dbIndex).StringGet(GetRedisKey(key));
            return value.IsNull ? null : Convert.ToDateTime(value);
        }

        public bool SetDatetime(string key
            , DateTime value
            , TimeSpan? expire
            , string formater = "yyyy-MM-dd HH:mm:ss")
        {
            return GetDatabase(dbIndex).StringSet(GetRedisKey(key), value.ToString(formater), expire);
        }

        public TValue? GetObject<TValue>(string key)
        {
            var value = GetDatabase(dbIndex).StringGet(GetRedisKey(key));
            return JsonConvert.DeserializeObject<TValue>(value.ToString());
        }

        public bool SetObject<TValue>(string key
            , TValue value
            , TimeSpan? expire)
        {
            var text = JsonConvert.SerializeObject(value);
            return GetDatabase(dbIndex).StringSet(GetRedisKey(key), text, expire);
        }
    }
}
