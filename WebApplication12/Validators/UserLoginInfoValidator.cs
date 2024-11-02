using FluentValidation;

using WebApplication12.DTO;
using WebApplication12.Tools;

namespace WebApplication12.Validators
{
    public class UserLoginInfoValidator : AbstractValidator<UserLoginInfoDTO>
    {
        public UserLoginInfoValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Username)
                .Must(x => RegExpTool.ValidateUsername(x))
                .WithMessage("Invalid Username!");

            RuleFor(x => x.Password)
                .Must(x => RegExpTool.ValidateUsername(x))
                .WithMessage("Invalid Password!");
        }
    }
}
