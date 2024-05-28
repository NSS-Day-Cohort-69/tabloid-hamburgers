using System.ComponentModel.DataAnnotations;

namespace Tabloid.Models;

public class Reaction
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string ImageURL { get; set; }
}
