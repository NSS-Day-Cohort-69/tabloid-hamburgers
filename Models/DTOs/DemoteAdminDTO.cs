using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabloid.Models.DTOs;

public class DemoteAdminDTO
{
    public int Id { get; set; }
    public string AdminApprovalId { get; set; }
    public string AdminToDemoteId { get; set; }
}