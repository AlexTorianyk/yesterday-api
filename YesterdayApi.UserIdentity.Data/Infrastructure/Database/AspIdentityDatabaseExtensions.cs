using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YesterdayApi.UserIdentity.Data.Core.Users;

namespace YesterdayApi.UserIdentity.Data.Infrastructure.Database
{
    public static class AspIdentityDatabaseExtensions
    {
        public static void AddAspIdentityDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("yesterday")));

            services.AddIdentityCore<AspIdentityUser>(options => { });
            new IdentityBuilder(typeof(AspIdentityUser), typeof(IdentityRole<int>), services)
                .AddRoleManager<RoleManager<IdentityRole<int>>>()
                .AddSignInManager<SignInManager<AspIdentityUser>>()
                .AddEntityFrameworkStores<UserDbContext>();

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
