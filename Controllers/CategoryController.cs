



using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabloid.Data;
using Tabloid.Models.DTOs;

[ApiController]
[Route("/api/[controller]")]
public class CategoryController : ControllerBase
{

    private TabloidDbContext _db;

    public CategoryController(TabloidDbContext context)
    {
        _db = context;
    }


    [HttpGet]
    // [Authorize(Roles = "Admin")]
    public IActionResult GetAllCategories()
    {
        return Ok(_db.Categories.Select(c => new CategoryDTO
        {
            Id = c.Id,
            CategoryName = c.CategoryName
        }));
    }
}