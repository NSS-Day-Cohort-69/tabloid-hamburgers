using Microsoft.VisualBasic;

namespace Tabloid.Models.DTOs;

public class PutProfileImageDTO
{
    public string FileName { get; set; }
    public IFormFile FormFile { get; set; }
}
