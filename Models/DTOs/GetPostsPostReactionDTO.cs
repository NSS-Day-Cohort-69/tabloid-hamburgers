using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabloid.Models.DTOs;

public class GetPostsPostReactionDTO
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public int ReactorId { get; set; }
    public int ReactionId { get; set; }
}
