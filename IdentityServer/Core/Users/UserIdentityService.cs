using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IdentityServer.Core.Users
{
    public class UserIdentityService : UserManager<UserIdentity>, IUserIdentityService
    {
        private readonly UserIdentityDbContext _context;

        public UserIdentityService(UserIdentityDbContext context, IUserStore<UserIdentity> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<UserIdentity> passwordHasher, IEnumerable<IUserValidator<UserIdentity>> userValidators, IEnumerable<IPasswordValidator<UserIdentity>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<UserIdentity>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _context = context;
        }

        public async Task<UserIdentity> GetById(int id)
        {
            if (await UserExists(id))
                return await _context.Users.FindAsync(id).ConfigureAwait(false);
            return null;
        }

        public async Task UpdateUserRefreshToken(string name, string refreshToken)
        {
            var user = await FindByNameAsync(name);
            user.UpdateRefreshToken(refreshToken);
            await UpdateAsync(user).ConfigureAwait(false);
        }

        private Task<bool> UserExists(int id)
        {
            return _context.Users.AnyAsync(x => x.Id.Equals(id));
        }
    }
}
