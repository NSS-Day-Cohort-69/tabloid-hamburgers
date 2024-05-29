using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    [Authorize(Roles = "Admin")]
    public IActionResult GetPosts()
    {
        return Ok(
            _dbContext
                .Posts.Include(p => p.Author)
                .Include(p => p.Category)
                .Select(p => new GetPostsDTO(p))
        );
    }

    [HttpGet]
    [Route("public")]
    [Authorize]
    public IActionResult GetPublicPosts()
    {
        return Ok(
            _dbContext
                .Posts.Where(p =>
                    p.IsApproved && p.Publication != null && p.Publication < DateTime.Now
                )
                .Include(p => p.Author)
                .Include(p => p.Category)
                .Select(p => new GetPostsDTO(p))
        );
    }
}
