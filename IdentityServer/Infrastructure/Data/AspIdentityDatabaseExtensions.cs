using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Infrastructure.Data
{
    public static class AspIdentityDatabaseExtensions
    {
        public static void AddAspIdentityDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserIdentityDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("yesterday")));

            services.AddIdentityCore<Core.Users.UserIdentity>();
            new IdentityBuilder(typeof(Core.Users.UserIdentity), typeof(IdentityRole<int>), services)
                .AddRoleManager<RoleManager<IdentityRole<int>>>()
                .AddSignInManager<SignInManager<Core.Users.UserIdentity>>()
                .AddEntityFrameworkStores<UserIdentityDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 1;

                options.User.RequireUniqueEmail = true;
            });
        }
    }
}
