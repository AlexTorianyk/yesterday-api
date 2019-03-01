using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using YesterdayApi.Core.Users.Web;
using YesterdayApi.Utilities.AutomaticDI;

namespace YesterdayApi.Core.Identity.Validators
{
    public class UserIdentityRequestValidator : AbstractValidator<UserRequest>, ITransient
    {
        public UserIdentityRequestValidator()
        {
            RuleFor(ur => ur.Password).NotNull();
            RuleFor(ur => ur.Password).Length(5, 50);
        }
    }
}
