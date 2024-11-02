namespace WebApplication18.Options
{
    public class UserInfoOptions
    {
        public const string SectionName = "UserInfo";

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public int Id { get; set; } = 0;

        public bool IsAdmin { get; set; } = false;

        public UserExtraInfoOptions UserExtraInfo { get; set; } = new UserExtraInfoOptions();
    }
}
