using System;

namespace YesterdayApi.Core.Users.Posts.Comments.Web
{
  public class CommentRequest
  {
    public string Content { get; set; }

    public DateTime PublishDate { get; set; }

    public int UserId { get; set; }

    public int PostId { get; set; }
  }
}