using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabloid.Models;

public class DemoteAdmin
{
    [Required]
    public int Id { get; set; }
    [Required]
    [ForeignKey("UserProfile")]
    public int AdminApprovalId { get; set; }
    [Required]
    [ForeignKey("UserProfile")]
    public int AdminToDemoteId { get; set; }
}