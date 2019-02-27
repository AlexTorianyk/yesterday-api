using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Core.Users
{
    public interface IUserIdentityService
    {
        Task<UserIdentity> GetById(int id);
        Task<UserIdentity> FindByNameAsync(string name);
        Task<IdentityResult> UpdateAsync(UserIdentity user);
        Task UpdateUserRefreshToken(string name, string refreshToken);
        Task<IdentityResult> CreateAsync(UserIdentity user, string password);
        Task<IdentityResult> AddToRoleAsync(UserIdentity user, string role);
        Task<bool> IsInRoleAsync(UserIdentity user, string role);
        Task<bool> CheckPasswordAsync(UserIdentity user, string password);
    }
}
