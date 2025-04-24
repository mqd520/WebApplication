using Newtonsoft.Json;

namespace WebApplication38.Def
{
    public class JwtInfo
    {
        public JwtHeaderInfo Header { get; set; } = new();
        public JwtPayloadInfo Payload { get; set; } = new();
    }

    public class JwtHeaderInfo
    {
        [JsonProperty("alg")]
        public string Alg { get; set; } = string.Empty;

        [JsonProperty("typ")]
        public string Typ { get; set; } = string.Empty;

        [JsonProperty("kid")]
        public string Kid { get; set; } = string.Empty;
    }

    public class JwtPayloadInfo
    {
        [JsonProperty("iss")]
        public string Iss { get; set; } = string.Empty;

        [JsonProperty("scope")]
        public string[] Scopes { get; set; } = [];

        [JsonProperty("aud")]
        public string Aud { get; set; } = string.Empty;

        [JsonProperty("exp")]
        public long Exp { get; set; }

        [JsonProperty("nbf")]
        public long Nbf { get; set; }

        [JsonProperty("iat")]
        public long Iat { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; } = string.Empty;

        [JsonProperty("jti")]
        public string Jti { get; set; } = string.Empty;
    }
}
