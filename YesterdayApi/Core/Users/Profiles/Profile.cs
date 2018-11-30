namespace YesterdayApi.Core.Users.Profiles
{
  public class Profile
  {
    public int Id { get; set; }

    public string Description { get; set; }

    public string Nickname { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int UserId { get; set; }
  }
}