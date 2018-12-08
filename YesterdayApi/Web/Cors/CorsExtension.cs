using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace YesterdayApi.Web.Cors
{
  public static class CorsExtension
  {
    public static void AddCorsPolicy(this IServiceCollection services)
    {
    }

    public static void UseCorsPolicy(this IApplicationBuilder app)
    {
    }
  }
}