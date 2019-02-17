using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Core.Users
{
    public class UserIdentity : IdentityUser<int>
    {
        public string RefreshToken { get; private set; }

        public void UpdateRefreshToken(string refreshToken)
        {
            RefreshToken = refreshToken;
        }

        public void Update(UserIdentity user)
        {
            UserName = user.UserName;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
        }
    }
}
