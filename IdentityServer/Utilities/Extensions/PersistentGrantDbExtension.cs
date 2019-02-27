using IdentityServer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Utilities.Extensions
{
    public static class PersistentGrantDbExtension
    {
        public static void AddPersistentGrantDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PersistentGrantDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PersistentGrantDb"))
                    .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning)));
        }
    }
}
