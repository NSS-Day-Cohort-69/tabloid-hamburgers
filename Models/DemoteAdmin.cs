using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabloid.Models;

public class DemoteAdmin
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string AdminApprovalId { get; set; }
    [Required]
    public string AdminToDemoteId { get; set; }
}