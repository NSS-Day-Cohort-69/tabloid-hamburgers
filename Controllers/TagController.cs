



using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabloid.Data;
using Tabloid.Models;
using Tabloid.Models.DTOs;

[ApiController]
[Route("/api/[controller]")]
public class TagController : ControllerBase
{

    private TabloidDbContext _db;

    public TagController(TabloidDbContext context)
    {
        _db = context;
    }


    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAllTags()
    {
        return Ok(_db.Tags.Select(c => new TagDTO
        {
            Id = c.Id,
            TagName = c.TagName
        }));
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult PostNewTag(Tag newTag)
    {
        _db.Tags.Add(newTag);
        _db.SaveChanges();
        return Ok(_db.Tags.Select(c => new TagDTO {
            Id = c.Id,
            TagName = c.TagName
        }).SingleOrDefault(i => i.Id == newTag.Id));
    }

}