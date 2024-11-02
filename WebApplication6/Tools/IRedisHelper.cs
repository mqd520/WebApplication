namespace WebApplication6.Tools
{
    public interface IRedisHelper
    {
        string GetString(string key);

        bool SetString(string key, string value, TimeSpan? expire);

        int? GetInt32(string key);

        bool SetInt32(string key, int value, TimeSpan? expire);

        Int16? GetInt16(string key);

        bool SetInt16(string key, Int16 value, TimeSpan? expire);

        Int64? GetInt64(string key);

        bool SetInt64(string key, Int64 value, TimeSpan? expire);

        bool? GetBoolean(string key);

        bool SetBoolean(string key, bool value, TimeSpan? expire);

        float? GetFloat(string key);

        bool SetFloat(string key, float value, TimeSpan? expire);

        double? GetDouble(string key);

        bool SetDouble(string key, double value, TimeSpan? expire);

        decimal? GetDecimal(string key);

        bool SetDecimal(string key, decimal value, TimeSpan? expire);

        DateTime? GetDatetime(string key);

        bool SetDatetime(string key, DateTime value, TimeSpan? expire, string formater = "yyyy-MM-dd HH:mm:ss");

        TValue? GetObject<TValue>(string key);

        bool SetObject<TValue>(string key, TValue value, TimeSpan? expire);
    }
}
