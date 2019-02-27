using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer.Infrastructure.Data;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Core
{
    public class PersistentGrantStore : IPersistedGrantStore
    {
        private readonly PersistentGrantDbContext _context;

        public PersistentGrantStore(PersistentGrantDbContext context)
        {
            _context = context;
        }

        public async Task<PersistedGrant> GetAsync(string key)
        {
            var grants = await _context.PersistedGrants.AsNoTracking().FirstOrDefaultAsync(g => g.Key == key);
            return grants;
        }

        public async Task<IEnumerable<PersistedGrant>> GetAllAsync(string subjectId)
        {
            var grants = await _context.PersistedGrants.AsNoTracking().Where(g => g.SubjectId == subjectId).ToListAsync();
            return grants;
        }

        public async Task RemoveAsync(string key)
        {
            var grant = await _context.PersistedGrants.FirstAsync(g => g.Key == key);
            _context.PersistedGrants.Remove(grant);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task RemoveAllAsync(string subjectId, string clientId)
        {
            var grants = await _context.PersistedGrants.Where(g => g.SubjectId == subjectId && g.ClientId == clientId).ToListAsync();
            _context.PersistedGrants.RemoveRange(grants);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task RemoveAllAsync(string subjectId, string clientId, string type)
        {
            var grants = await _context.PersistedGrants.Where(g => g.SubjectId == subjectId && g.ClientId == clientId && g.Type == type).ToListAsync();
            _context.PersistedGrants.RemoveRange(grants);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task StoreAsync(PersistedGrant grant)
        {
            if (await GrantExists(grant.Key))
            {
                _context.PersistedGrants.Update(grant);
                await _context.SaveChangesAsync();
            }
            else
            {
                await _context.PersistedGrants.AddAsync(grant);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        private Task<bool> GrantExists(string key)
        {
            return _context.PersistedGrants.AnyAsync(g => g.Key == key);
        }
    }
}
