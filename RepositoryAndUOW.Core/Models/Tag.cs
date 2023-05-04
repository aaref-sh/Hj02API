namespace RepositoryAndUOW.Core.Models;

public class Tag
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public virtual ICollection<Post>? Posts { get; set; }
}
