using System.Threading.Tasks;

namespace IdentityServer.Core.Users
{
    public interface IUserIdentityService
    {
        Task<UserIdentity> GetById(int id);
    }
}
