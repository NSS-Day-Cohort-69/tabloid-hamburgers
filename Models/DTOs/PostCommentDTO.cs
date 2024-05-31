using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabloid.Models.DTOs;

public class PostCommentDTO
{
    public string Subject { get; set; }
    public string Content { get; set; }
    public int PostId { get; set; }
    public int CommenteerId { get; set; }
}
