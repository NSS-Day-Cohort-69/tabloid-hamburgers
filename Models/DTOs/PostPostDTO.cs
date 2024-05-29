namespace Tabloid.Models;

public class PostPostDTO
{
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public string Content { get; set; }
    public string ImageURL { get; set; }
    public int CategoryId { get; set; }
    public DateTime? Publication { get; set; }
}
