using System;

namespace YesterdayApi.Core.Users.Posts.Reactions
{
  public class Reaction
  {
    public int Id { get; set; }

    public int TypeId { get; set; }

    public DateTime PublishDate { get; set; }

    public int UserId { get; set; }

    public int PostId { get; set; }
  }
}