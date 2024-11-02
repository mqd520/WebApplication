using Newtonsoft.Json;

namespace WebApplication3.Def
{
    public class JsonResultData
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public DateTime Time { get; set; }

        public UserInfo? UserInfo { get; set; }

        public bool Success { get; set; }

        [JsonIgnore]
        public int Ignore { get; set; }
    }
}
