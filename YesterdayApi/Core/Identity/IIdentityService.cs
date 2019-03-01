using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using YesterdayApi.Core.Identity.Web;

namespace YesterdayApi.Core.Identity
{
    public interface IIdentityService
    {
        Task<string> GetAccessToken(UserIdentityRequest userIdentityRequest);
        Task<string> RefreshAccessToken(string authHeader);
        Task<IdentityResult> RegisterUser(UserRegistrationRequest userRegistrationRequest);
        Task SetAdmin(string userName);
    }
}
