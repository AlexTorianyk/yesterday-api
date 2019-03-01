using FluentValidation;
using YesterdayApi.Core.Identity.Web;
using YesterdayApi.Core.Users.Web;
using YesterdayApi.Utilities.AutomaticDI;

namespace YesterdayApi.Core.Identity.Validators
{
    public class UserIdentityRequestValidator : AbstractValidator<UserIdentityRequest>, ITransient
    {
        public UserIdentityRequestValidator()
        {
            RuleFor(ur => ur.Password).NotNull();
            RuleFor(ur => ur.Password).Length(5, 50);
        }
    }
}
