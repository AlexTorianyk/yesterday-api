using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace YesterdayApi.UserIdentity.Data.Core.Users
{
    public class AspIdentityUser : IdentityUser<int>
    {
        public string RefreshToken { get; private set; }

        public void UpdateRefreshToken(string refreshToken)
        {
            RefreshToken = refreshToken;
        }

        public void Update(AspIdentityUser user)
        {
            UserName = user.UserName;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
        }
    }
}
