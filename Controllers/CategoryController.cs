



using System.Data.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabloid.Data;
using Tabloid.Models;
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
    [Authorize]
    public IActionResult GetAllCategories()
    {
        return Ok(_db.Categories.Select(c => new CategoryDTO
        {
            Id = c.Id,
            CategoryName = c.CategoryName
        }));
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult PostNewCategory(Category newCategory)
    {
        _db.Categories.Add(newCategory);
        _db.SaveChanges();
        return Ok(_db.Categories.Select(c => new CategoryDTO {
            Id = c.Id,
            CategoryName = c.CategoryName
        }).SingleOrDefault(i => i.Id == newCategory.Id));
    }

    [HttpDelete("{Id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteCategory(int Id)
    {
        Category foundCategory = _db.Categories.FirstOrDefault(i => i.Id == Id);
        if (foundCategory != null)
        {
            _db.Categories.Remove(foundCategory);
            _db.SaveChanges();
            return Ok();
        }
        return NotFound();
    }

}