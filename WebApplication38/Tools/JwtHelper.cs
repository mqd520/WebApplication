using System.Text;

using Newtonsoft.Json;

using WebApplication38.Def;

namespace WebApplication38.Tools
{
    public static class JwtHelper
    {
        public static JwtInfo Parse(string token)
        {
            var arr = token.Split('.').ToList();
            if (!(arr.Count() == 3))
            {
                throw new Exception("Jwt data format invalid");
            }

            var headerBuf = Convert.FromBase64String(arr.ElementAt(0) + "=");
            var headerString = Encoding.UTF8.GetString(headerBuf);
            var header = JsonConvert.DeserializeObject<JwtHeaderInfo>(headerString);

            var payloadBuf = Convert.FromBase64String(arr.ElementAt(1) + "=");
            string payloadString = Encoding.UTF8.GetString(payloadBuf);
            var payload = JsonConvert.DeserializeObject<JwtPayloadInfo>(payloadString);

            var jwtInfo = new JwtInfo
            {
                Header = header!,
                Payload = payload!
            };

            return jwtInfo;
        }
    }

    public class class1
    {
        public string typ { get; set; } = string.Empty;
        public string alg { get; set; } = string.Empty;
    }
}
