namespace Tabloid.Models;

public class PutPostByMeDTO
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string ImageURL { get; set; }
    public int CategoryId { get; set; }
    public int AuthorId { get; set; }
    public List<int> TagIds { get; set; }
    public DateTime? Publication { get; set; }
}
