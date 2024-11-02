using FluentValidation;

using WebApplication13.DTO;
using WebApplication13.Tools;

namespace WebApplication13.Validators
{
    public class UserLoginInfoDTOValidator : AbstractValidator<UserLoginInfoDTO>
    {
        public UserLoginInfoDTOValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Continue;

            RuleFor(x => x.Username)
                .Must(x => RegExpTool.IsUsername(x))
                .WithMessage("Invalid Username!");

            RuleFor(x => x.Password)
                .Must(x => RegExpTool.IsUsername(x))
                .WithMessage("Invalid Password!");
        }
    }
}