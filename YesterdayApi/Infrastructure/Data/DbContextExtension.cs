using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace YesterdayApi.Infrastructure.Data
{
  public static class DbContextExtension
  {
    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<YesterdayContext>(opt =>
        opt.UseSqlServer(configuration.GetConnectionString("yesterday")));
    }
  }
}