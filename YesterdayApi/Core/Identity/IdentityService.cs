using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using YesterdayApi.Core.Identity.Web;

namespace YesterdayApi.Core.Identity
{
    public class IdentityService : IIdentityService
    {
        public Task<string> GetAccessToken(UserIdentityRequest userIdentityRequest)
        {
            throw new NotImplementedException();
        }

        public Task<string> RefreshAccessToken(string authHeader)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> RegisterUser(UserRegistrationRequest userRegistrationRequest)
        {
            throw new NotImplementedException();
        }

        public Task SetAdmin(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
