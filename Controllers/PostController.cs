using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tabloid.Data;
using Tabloid.Models;
using Tabloid.Models.DTOs;

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

    [HttpGet]
    public IActionResult GetPosts()
    {
        return Ok(_dbContext.Posts.Select(p => new GetPostsDTO(p)));
    }

    [HttpGet]
    [Route("public")]
    public IActionResult GetPublicPosts()
    {
        return Ok(
            _dbContext
                .Posts.Where(p =>
                    p.IsApproved && p.Publication != null && p.Publication < DateTime.Now
                )
                .Select(p => new GetPostsDTO(p))
        );
    }
}
