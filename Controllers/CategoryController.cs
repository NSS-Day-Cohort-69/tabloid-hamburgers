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
    public IActionResult GetAllCategories(int? CategoryId)
    {
        if (CategoryId == null)
        {
            return Ok(
                _db.Categories.Select(c => new CategoryDTO
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName
                })
            );
        }
        else
        {
            return Ok(
                _db.Categories.Select(c => new CategoryDTO
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName
                })
                    .Single(i => i.Id == CategoryId)
            );
        }
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult PostNewCategory(Category newCategory)
    {
        _db.Categories.Add(newCategory);
        _db.SaveChanges();
        return Ok(
            _db.Categories.Select(c => new CategoryDTO { Id = c.Id, CategoryName = c.CategoryName })
                .SingleOrDefault(i => i.Id == newCategory.Id)
        );
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

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateCategory(Category categoryToUpdate)
    {
        if (categoryToUpdate == null)
        {
            return NoContent();
        }

        Category foundCategory = _db.Categories.FirstOrDefault(i => i.Id == categoryToUpdate.Id);
        if (foundCategory != null)
        {
            foundCategory.CategoryName = categoryToUpdate.CategoryName;
            _db.SaveChanges();

            return Ok();
        }

        return NotFound();
    }
}
