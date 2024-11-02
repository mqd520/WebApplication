namespace WebApplication25.VO
{
    public class UserLoginRequestVO
    {
        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string VerifyCode { get; set; } = string.Empty;
    }
}
