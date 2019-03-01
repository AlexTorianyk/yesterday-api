using Microsoft.Extensions.DependencyInjection;

namespace YesterdayApi.Utilities.Policies
{
    public static class AdminPolicyExtension
    {
        public static void AddAdminPolicy(this IServiceCollection services)
        {
            services.AddAuthorization(options => options.AddPolicy("AdminOnly", policy => policy.RequireClaim("role", "admin")));
        }
    }
}
