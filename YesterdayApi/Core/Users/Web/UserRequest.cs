using System;

namespace YesterdayApi.Core.Users.Web
{
  public class UserRequest
  {
    public string Name { get; set; }

    public string Surname { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public DateTime BirthDate { get; set; }
  }
}