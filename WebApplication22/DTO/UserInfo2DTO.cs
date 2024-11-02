using System.ComponentModel.DataAnnotations;

namespace WebApplication22.DTO
{
    public class UserInfo2DTO
    {
        [Required(ErrorMessage = "UserName Is Required")]
        [Length(10, 20, ErrorMessage = "Invalid UserName Length")]
        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
