using System.Threading.Tasks;
using IdentityServer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Core.Users
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly UserIdentityDbContext _context;

        public UserIdentityService(UserIdentityDbContext context)
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
