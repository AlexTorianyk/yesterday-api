using System;

namespace YesterdayApi.Core.Users.Posts.Comments
{
  public class Comment
  {
    public int Id { get; set; }
    
    public string Content { get; set; }
    
    public DateTime PublishDate { get; set; }
    
    public int UserId { get; set; }
    
    public int PostId { get; set; }
  }
}