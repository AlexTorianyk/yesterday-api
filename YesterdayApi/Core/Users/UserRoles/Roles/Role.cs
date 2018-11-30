namespace YesterdayApi.Core.Users.Roles.Role
{
  public class Role
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public UserRole UserRole { get; set; }
  }
}