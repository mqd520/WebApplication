using Newtonsoft.Json;
using System.Text;

namespace WebApplication72.Common
{
    public static class SessionExtension
    {
        public static void SetObj<T>(this ISession session, string key, T value)
            where T : class, new()
        {
            var text = JsonConvert.SerializeObject(value);
            var buf = Encoding.UTF8.GetBytes(text);
            session.Set(key, buf);
        }

        public static T? GetObj<T>(this ISession session, string key)
            where T : class, new()
        {
            var buf = session.Get(key);
            var text = Encoding.UTF8.GetString(buf ?? new byte[] { });
            var obj = JsonConvert.DeserializeObject<T>(text);
            return obj;
        }

        public static void SetBoolean(this ISession session, string key, bool value)
        {
            var value2 = value == true ? 1 : 0;
            session.SetInt32(key, value2);
        }

        public static bool GetBoolean(this ISession session, string key)
        {
            var value = session.GetInt32(key);
            return value == 1;
        }
    }
}
