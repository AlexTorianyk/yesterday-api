using System;

namespace YesterdayApi.Core.Users.Posts.Comments.Web
{
  public class CommentResponse
  {
    public int Id { get; set; }
    
    public string Content { get; set; }
    
    public DateTime PublishDate { get; set; }
    
    public int UserId { get; set; }
  }
}