using System;
using System.Collections.Generic;
using IdentityServer.Core.Users;
using YesterdayApi.Core.Email;
using YesterdayApi.Core.Users.Posts.Comments;
using YesterdayApi.Core.Users.Posts.Reactions;
using YesterdayApi.Core.Users.Profiles;

namespace YesterdayApi.Core.Users
{
  public class User : UserIdentity, IEmailReceiver
  {
    public DateTime BirthDate { get; set; }

    public Profile Profile { get; set; }

    public ICollection<Reaction> Reactions { get; set; }

    public ICollection<Comment> Comments { get; set; }
  }
}