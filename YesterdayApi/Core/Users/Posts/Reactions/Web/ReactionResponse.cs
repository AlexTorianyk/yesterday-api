using System;

namespace YesterdayApi.Core.Users.Posts.Reactions.Web
{
  public class ReactionResponse
  {
    public int Id { get; set; }

    public Type Type { get; set; }

    public DateTime PublishDate { get; set; }

    public int UserId { get; set; }

    public int PostId { get; set; }
  }
}