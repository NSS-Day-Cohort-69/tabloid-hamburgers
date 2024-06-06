using System.Data.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabloid.Data;
using Tabloid.Models;
using Tabloid.Models.DTOs;

[ApiController]
[Route("/api/[controller]")]
public class ReactionController : ControllerBase
{
    private TabloidDbContext _db;

    public ReactionController(TabloidDbContext context)
    {
        _db = context;
    }

   [HttpGet]
   [Authorize]
   public IActionResult GetAllReactions()
   {
    return Ok(_db.Reactions.Select(r => new ReactionDTO
    {
        Id = r.Id,
        ImageURL = r.ImageURL
    }));
   }

   [HttpPost]
   [Authorize(Roles = "Admin")]
   public IActionResult CreateReaction(Reaction newReaction)
   {
    if (newReaction != null)
    {
        _db.Reactions.Add(newReaction);
        _db.SaveChanges();

        return Ok();
    }
    
    return NoContent();
   }

   [HttpPost("postreaction")]
   [Authorize]
   public IActionResult PostNewPostReaction(PostReaction newPostReaction)
   {
    _db.PostReactions.Add(newPostReaction);
    _db.SaveChanges();

    return Ok();
   }

   [HttpGet("{PostId}/postreaction")]
   [Authorize]
   public IActionResult GetPostsPostReactionsById(int PostId)
   {
    return Ok(_db.PostReactions.Select(pr => new GetPostsPostReactionDTO{
        Id = pr.Id,
        PostId = pr.PostId,
        ReactionId = pr.ReactionId,
        ReactorId = pr.ReactorId
    }).Where(pr => pr.PostId == PostId));
   }

}
