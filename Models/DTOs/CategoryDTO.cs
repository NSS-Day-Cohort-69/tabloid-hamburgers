using System.ComponentModel.DataAnnotations;

namespace Tabloid.Models.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
}
