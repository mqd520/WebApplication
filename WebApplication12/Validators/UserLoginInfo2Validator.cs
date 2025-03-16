using FluentValidation;

using WebApplication12.Tools;
using WebApplication12.VO;

namespace WebApplication12.Validators
{
    public class UserLoginInfo2Validator : AbstractValidator<UserLoginInfo2VO>
    {
        public UserLoginInfo2Validator()
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
