using System.ComponentModel.DataAnnotations;

namespace Tabloid.Models;

public class Tags
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string TagName { get; set; }
}
