using System;
using System.Collections.Generic;
using YesterdayApi.Core.Users.Posts.Comments;
using YesterdayApi.Core.Users.Posts.Reactions;
using YesterdayApi.Core.Users.Profiles;
using YesterdayApi.UserIdentity.Data.Core.Users;

namespace YesterdayApi.Core.Users
{
  public class User : AspIdentityUser
  {
    public DateTime BirthDate { get; set; }

    public Profile Profile { get; set; }

    public ICollection<Reaction> Reactions { get; set; }

    public ICollection<Comment> Comments { get; set; }
  }
}