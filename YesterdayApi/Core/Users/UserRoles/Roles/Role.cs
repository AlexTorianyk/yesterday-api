using YesterdayApi.Core.Users.Roles;

namespace YesterdayApi.Core.Users.UserRoles.Roles
{
  public class Role
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public UserRole UserRole { get; set; }
  }
}