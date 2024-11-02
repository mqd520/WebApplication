using Newtonsoft.Json;

namespace WebApplication6.DTO
{
    public class UserInfoDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
