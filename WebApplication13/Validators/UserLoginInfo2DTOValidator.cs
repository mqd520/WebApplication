using FluentValidation;

using WebApplication13.DTO;
using WebApplication13.Tools;

namespace WebApplication13.Validators
{
    public class UserLoginInfo2DTOValidator : AbstractValidator<UserLoginInfo2DTO>
    {
        public UserLoginInfo2DTOValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Username)
                .Must(x => RegExpTool.IsUsername(x))
                .WithMessage("Invalid Username!");

            RuleFor(x => x.Password)
                .Must(x => RegExpTool.IsUsername(x))
                .WithMessage("Invalid Password!");
        }
    }
}
