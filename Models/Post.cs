using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabloid.Models;

public class Post
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(40)]
    public string Title { get; set; }
    [Required]
    [ForeignKey("UserProfile")]
    public int AuthorId { get; set; }
    [Required]
    public string Content { get; set; }
    public string ImageURL { get; set; }
    [Required]
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    [Required]
    public bool IsApproved { get; set; }
    [Required]
    public DateTime? Publication { get; set; }
}
