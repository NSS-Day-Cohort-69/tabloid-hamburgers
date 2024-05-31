






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
    public IActionResult AddNewComment(PostCommentDTO newComment)
    {
        _db.Comments.Add(new Comment{
            Subject = newComment.Subject,
            Content = newComment.Content,
            PostId = newComment.PostId,
            CommenteerId = newComment.CommenteerId,
            CreationDate = DateTime.Now
        });
        _db.SaveChanges();
        
        return Ok();
    }

}