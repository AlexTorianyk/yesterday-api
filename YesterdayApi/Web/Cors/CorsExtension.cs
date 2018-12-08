using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace YesterdayApi.Web.Cors
{
  public static class CorsExtension
  {
    public static void AddCorsPolicy(this IServiceCollection services)
    {
      services.AddCors();
    }

    public static void UseCorsPolicy(this IApplicationBuilder app)
    {
      app.UseCors(builder => builder.WithOrigins("http://yesterday.com"));
    }
  }
}