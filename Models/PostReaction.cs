using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabloid.Models;

public class PostReaction
{
    [Required]
    public int Id { get; set; }

    [Required]
    [ForeignKey("Post")]
    public int PostId { get; set; }

    [Required]
    [ForeignKey("UserProfile")]
    public int ReactorId { get; set; }

    [Required]
    [ForeignKey("UserProfile")]
    public int ReactionId { get; set; }
}
