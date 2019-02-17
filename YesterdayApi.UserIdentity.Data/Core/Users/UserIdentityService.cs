using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YesterdayApi.UserIdentity.Data.Infrastructure.Database;

namespace YesterdayApi.UserIdentity.Data.Core.Users
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly UserDbContext _context;

        public UserIdentityService(UserDbContext context)
        {
            _context = context;
        }
        public async Task<UserIdentity> GetById(int id)
        {
            if (await UserExists(id))
                return await _context.Users.FindAsync(id).ConfigureAwait(false);
            return null;
        }

        private Task<bool> UserExists(int id)
        {
            return _context.Users.AnyAsync(x => x.Id.Equals(id));
        }
    }
}
