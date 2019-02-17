using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Infrastructure.Data
{
    public class PersistentGrantDbContext : DbContext
    {
        public PersistentGrantDbContext(DbContextOptions<PersistentGrantDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PersistedGrant> PersistedGrants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var persistedGrant = modelBuilder.Entity<PersistedGrant>();
            persistedGrant.HasKey(pg => pg.Key);
        }
    }
}
