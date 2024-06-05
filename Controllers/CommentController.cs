






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

    [HttpGet("{Id}")]
    [Authorize]
    public IActionResult GetCommentById(int Id) 
    {
        return Ok(_db.Comments.Select(c => new Comment{
            Id = c.Id,
            Subject = c.Subject,
            Content = c.Content,
            PostId = c.PostId,
            CommenteerId = c.CommenteerId,
            CreationDate = c.CreationDate
        }).Single(i => i.Id == Id));
    }

    [HttpPut]
    [Authorize]
    public IActionResult UpdateCommentByBody(Comment commentInfo)
    {
        Comment foundComment = _db.Comments.FirstOrDefault(i => i.Id == commentInfo.Id);

        if (foundComment != null)
        {
            foundComment.Content = commentInfo.Content;
            foundComment.Subject = commentInfo.Subject;

            _db.SaveChanges();
        }

        return Ok();
    }

    [HttpDelete("{Id}")]
    [Authorize]
    public IActionResult DeleteComment(int Id) {

        Comment commentToDelete = _db.Comments.FirstOrDefault(i => i.Id == Id);

        if (commentToDelete != null) {
            _db.Comments.Remove(commentToDelete);

            _db.SaveChanges();
        }

        return Ok();
    }
}