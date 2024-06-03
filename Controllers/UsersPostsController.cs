
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tabloid.Data;
using Tabloid.Models;
using Tabloid.Models.DTOs;

namespace Tabloid.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UsersPostController : ControllerBase
{
    private TabloidDbContext _db;

    public UsersPostController(TabloidDbContext context)
    {
        _db = context;
    }


    [HttpGet("{authorId}")]
    //[Authorize]
    public IActionResult GetPostByAuthor(int authorId)
   {

        List<Post> posts = _db.Posts
            .Include(p => p.Author)
            .Include(p => p.Category)
            .Where(p => p.AuthorId == authorId)
            .OrderByDescending(p => p.Publication)
            .ToList();

        if (posts == null)
        {
            return NotFound();
        }
           List<UsersPostsDTO> postsDTO = posts
                .Select(p => new UsersPostsDTO(p))
                .ToList();

            return Ok(postsDTO);
    }
}