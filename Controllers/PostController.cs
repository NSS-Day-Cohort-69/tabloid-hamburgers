using Microsoft.AspNetCore.Mvc;
using Tabloid.Models;
using Tabloid.Models.DTOs;
using Tabloid.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Npgsql.Internal;

namespace Tabloid.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private TabloidDbContext _dbContext;

    public PostController(TabloidDbContext context)
    {
        _dbContext = context;
    }



    [HttpGet ("{id}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        Post post = _dbContext.Posts
        .Include(p => p.Author)
        .SingleOrDefault(p => p.Id == id);

        if (post == null)
        {
            return NotFound("this post doesnt exist");
        }

        return Ok(new GetPostDTO
        {
            Id = post.Id,
            Title = post.Title,
            Author =  new UserProfileForGetPostDTO 
            {
                Id = post.Author.Id,
                UserName = post.Author.UserName
            },
            Content = post.Content,
            ImageURL = post.ImageURL,
            Publication = post.Publication,
            IsApproved = post.IsApproved
     
        });
    }




}