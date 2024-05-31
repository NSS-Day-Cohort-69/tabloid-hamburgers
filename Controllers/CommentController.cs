






using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabloid.Data;
using Tabloid.Models;
using Tabloid.Models.DTOs;

[ApiController]
[Route("/api/[controller]")]
public class CommentController : ControllerBase
{

    private TabloidDbContext _db;

    public CommentController(TabloidDbContext context)
    {
        _db = context;
    }


    [HttpPost]
    [Authorize]
    public IActionResult AddNewComment(Comment newComment)
    {
        newComment.CreationDate = DateTime.Now;

        _db.Comments.Add(newComment);
        _db.SaveChanges();
        
        return Ok();
    }

}