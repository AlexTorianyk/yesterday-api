using System.Threading.Tasks;

namespace YesterdayApi.UserIdentity.Data.Core.Users
{
    public interface IAspIdentityUserService
    {
        Task<AspIdentityUser> GetById(int id);
    }
}
