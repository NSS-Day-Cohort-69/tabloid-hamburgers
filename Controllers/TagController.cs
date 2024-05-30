



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

    [HttpGet("{Id}")]
    [Authorize(Roles = "Admin")]
      public IActionResult GetTagById(int Id)
    {
        return Ok(_db.Tags.Select(c => new TagDTO
        {
            Id = c.Id,
            TagName = c.TagName
        }).SingleOrDefault(i => i.Id == Id));
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

    [HttpDelete("{Id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteATag(int Id)
    {
        Tag tagToDelete = _db.Tags.FirstOrDefault(i => i.Id == Id);

        if (tagToDelete != null)
        {
            _db.Tags.Remove(tagToDelete);
            _db.SaveChanges();

            return Ok();
        }
        return NotFound();
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateATag(Tag tagToUpdate)
    {
        if (tagToUpdate == null)
        {
            return NoContent();
        }

        Tag foundTag = _db.Tags.FirstOrDefault(i => i.Id == tagToUpdate.Id);
        if (foundTag != null)
        {
            foundTag.TagName = tagToUpdate.TagName;
            _db.SaveChanges();

            return Ok();
        }

        return NotFound();
    }

}