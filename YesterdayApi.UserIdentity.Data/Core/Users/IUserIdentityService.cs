using System.Threading.Tasks;

namespace YesterdayApi.UserIdentity.Data.Core.Users
{
    public interface IUserIdentityService
    {
        Task<UserIdentity> GetById(int id);
    }
}
