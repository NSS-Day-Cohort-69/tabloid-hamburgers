

namespace Tabloid.Models.DTOs;

public class GetPostDTO
{
  
    public int Id { get; set; }

    public string Title { get; set; }

    public int AuthorId { get; set; }

    public UserProfileForGetPostDTO Author {get ; set;}
    public string Content { get; set; }
    public string ImageURL { get; set; }

    public int CategoryId { get; set; }

    public bool IsApproved { get; set; }

    public DateTime? Publication { get; set; }
}
