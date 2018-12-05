using Microsoft.EntityFrameworkCore;

namespace YesterdayApi.Infrastructure.Data
{
  public class YesterdayContext : DbContext
  {
    public YesterdayContext(DbContextOptions options) : base(options)
    {
    }
  }
}