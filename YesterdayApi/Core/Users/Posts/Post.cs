using System;
using System.Collections.Generic;
using YesterdayApi.Core.Users.Posts.Reactions;

namespace YesterdayApi.Core.Users.Posts
{
  public class Post
  {
    public int Id { get; set; }

    public string Content { get; set; }

    public DateTime PublishDate { get; set; }

    public int UserId { get; set; }

    public ICollection<Reaction> Reactions { get; set; }
  }
}