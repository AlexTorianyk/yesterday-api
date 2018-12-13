using System;
using System.Collections.Generic;
using YesterdayApi.Core.Users.Posts.Comments;
using YesterdayApi.Core.Users.Posts.Reactions;
using YesterdayApi.Core.Users.Profiles;
using YesterdayApi.Core.Users.UserRoles;

namespace YesterdayApi.Core.Users
{
  public class User
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public DateTime BirthDate { get; set; }

    public Profile Profile { get; set; }

    public UserRole UserRole { get; set; }

    public ICollection<Reaction> Reactions { get; set; }

    public ICollection<Comment> Comments { get; set; }
  }
}