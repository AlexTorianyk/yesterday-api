using FluentValidation;
using YesterdayApi.Core.Identity.Web;
using YesterdayApi.Utilities.AutomaticDI;

namespace YesterdayApi.Core.Identity.Validators
{
    public class UserRegistrationRequestValidator : AbstractValidator<UserRegistrationRequest>, ITransient
    {
        public UserRegistrationRequestValidator()
        {
            Include(new UserIdentityRequestValidator());
            RuleFor(urr => urr.Email).NotNull();
            RuleFor(urr => urr.Email).Length(7, 230);
        }
    }
}
