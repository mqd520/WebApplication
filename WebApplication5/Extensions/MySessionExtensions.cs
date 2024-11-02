using Newtonsoft.Json;

namespace WebApplication5.Extensions
{
    public static class MySessionExtensions
    {
        public static void SetObject<TValue>(this ISession session
            , string key
            , TValue obj)
        {
            var text = JsonConvert.SerializeObject(obj);
            session.SetString(key, text);
        }

        public static TValue? GetObject<TValue>(this ISession session, string key)
        {
            var text = session.GetString(key);
            return JsonConvert.DeserializeObject<TValue>(text?.ToString() ?? "");
        }

        public static void SetBoolean(this ISession session
            , string key
            , bool value)
        {
            var text = value ? "True" : "False";
            session.SetString(key, text);
        }

        public static bool? GetBoolean(this ISession session, string key)
        {
            var text = session.GetString(key);
            return text == null ? null : text.ToString() == "True";
        }

        public static void SetFloat(this ISession session
            , string key
            , float value)
        {
            session.SetString(key, value.ToString());
        }

        public static float? GetFloat(this ISession session, string key)
        {
            var text = session.GetString(key);
            return text == null ? null : float.Parse(text.ToString());
        }

        public static void SetDouble(this ISession session
            , string key
            , double value)
        {
            session.SetString(key, value.ToString());
        }

        public static double? GetDouble(this ISession session, string key)
        {
            var text = session.GetString(key);
            return text == null ? null : double.Parse(text.ToString());
        }

        public static void SetInt16(this ISession session
            , string key
            , Int16 value)
        {
            session.SetString(key, value.ToString());
        }

        public static Int16? GetInt16(this ISession session, string key)
        {
            var text = session.GetString(key);
            return text == null ? null : Int16.Parse(text.ToString());
        }

        public static void SetInt64(this ISession session
            , string key
            , Int64 value)
        {
            session.SetString(key, value.ToString());
        }

        public static Int64? GetInt64(this ISession session, string key)
        {
            var text = session.GetString(key);
            return text == null ? null : Int64.Parse(text.ToString());
        }

        public static void SetDecimal(this ISession session
            , string key
            , decimal value)
        {
            session.SetString(key, value.ToString());
        }

        public static decimal? GetDecimal(this ISession session, string key)
        {
            var text = session.GetString(key);
            return text == null ? null : decimal.Parse(text.ToString());
        }

        public static void SetDatetime(this ISession session
            , string key
            , DateTime value
            , string formater = "yyyy-MM-dd HH:mm:ss")
        {
            session.SetString(key, value.ToString(formater));
        }

        public static DateTime? GetDatetime(this ISession session, string key)
        {
            var text = session.GetString(key);
            return text == null ? null : Convert.ToDateTime(text.ToString());
        }
    }
}
