using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabloid.Models;

public class Comment
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Subject { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    [ForeignKey("Post")]
    public int PostId { get; set; }

    [Required]
    [ForeignKey("UserProfile")]
    public int CommenteerId { get; set; }

    [Required]
    public DateTime CreationDate { get; set; }
}
