using System.Collections.Generic;

namespace YesterdayApi.Core.Users.Posts.Reactions.Types
{
  public class Type
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<Reaction> Reactions { get; set; }
  }
}