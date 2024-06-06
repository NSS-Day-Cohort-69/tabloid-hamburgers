namespace Tabloid.Models;

public class PostPostByMeDTO
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string ImageURL { get; set; }
    public int CategoryId { get; set; }
    public List<int> TagIds { get; set; }
    public DateTime? Publication { get; set; }
    public IFormFile? FormFile { get; set; }
}
