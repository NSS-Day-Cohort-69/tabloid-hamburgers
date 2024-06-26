using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.VisualBasic;
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

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        Post post = _dbContext
            .Posts.Include(p => p.Author)
            .Include(p => p.Comments)
            .ThenInclude(c => c.Commenteer)
            .ThenInclude(u => u.IdentityUser)
            .Include(p => p.PostTags)
            .SingleOrDefault(p => p.Id == id);

        if (post == null)
        {
            return NotFound("this post doesnt exist");
        }
        if (post.IsApproved == false)
        {
            return BadRequest("Unauthorized request, this post isnt approved");
        }

        return Ok(new GetPostDTO(post));
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult GetPosts()
    {
        return Ok(
            _dbContext
                .Posts.Include(p => p.Author)
                .Include(p => p.Category)
                .Include(p => p.PostTags)
                .ThenInclude(p => p.Tag)
                .Select(p => new GetPostsDTO(p))
        );
    }

    [HttpGet("unapproved")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetUnapprovedPosts()
    {
        return Ok(
            _dbContext
                .Posts.Where(p => p.IsApproved == false)
                .Include(p => p.Author)
                .Include(p => p.Category)
                .Include(p => p.PostTags)
                .ThenInclude(pt => pt.Tag)
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
                .Include(p => p.PostTags)
                .ThenInclude(pt => pt.Tag)
                .Select(p => new GetPostsDTO(p))
        );
    }

    [HttpPost]
    [Route("by-me")]
    [Authorize]
    public IActionResult CreatePostByMe([FromForm] PostPostByMeDTO postedPost)
    {
        string identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        UserProfile profile = _dbContext.UserProfiles.SingleOrDefault(up =>
            up.IdentityUserId == identityUserId
        );

        bool isAdmin = User.IsInRole("Admin");

        Post post = new Post
        {
            Title = postedPost.Title,
            AuthorId = profile.Id,
            Content = postedPost.Content,
            CategoryId = postedPost.CategoryId,
            IsApproved = isAdmin,
            Publication = postedPost.Publication,
            CreationDate = DateTime.Now
        };

        _dbContext.Posts.Add(post);
        _dbContext.SaveChanges();

        foreach (int tagId in postedPost.TagIds)
        {
            PostTag postTag = new PostTag { PostId = post.Id, TagId = tagId };

            _dbContext.PostTags.Add(postTag);
        }

        if (postedPost.FormFile != null)
        {
            byte[] file;
            using (var memoryStream = new MemoryStream())
            {
                postedPost.FormFile.CopyTo(memoryStream);
                file = memoryStream.ToArray();
            }

            post.ImageBlob = file;
        }

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPut]
    [Route("{id}")]
    [Authorize]
    public IActionResult EditPost([FromForm] PutPostByMeDTO puttedPost, int id)
    {
        string identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        UserProfile profile = _dbContext.UserProfiles.SingleOrDefault(up =>
            up.IdentityUserId == identityUserId
        );

        Post existingPost = _dbContext.Posts.SingleOrDefault(p =>
            p.Id == id && p.AuthorId == profile.Id
        );

        if (existingPost != null)
        {
            foreach (PostTag postTag in _dbContext.PostTags)
            {
                if (postTag.PostId == id)
                {
                    _dbContext.PostTags.Remove(postTag);
                }
            }

            _dbContext.Posts.Remove(existingPost);

            Post post = new Post
            {
                Id = id,
                Title = puttedPost.Title,
                AuthorId = puttedPost.AuthorId,
                Content = puttedPost.Content,
                CategoryId = puttedPost.CategoryId,
                IsApproved = true,
                Publication = puttedPost.Publication,
                CreationDate = DateTime.Now
            };

            _dbContext.Posts.Add(post);

            _dbContext.SaveChanges();

            foreach (int tagId in puttedPost.TagIds)
            {
                PostTag postTag = new PostTag { PostId = post.Id, TagId = tagId };

                _dbContext.PostTags.Add(postTag);
            }

            if (puttedPost.FormFile != null)
            {
                byte[] file;
                using (var memoryStream = new MemoryStream())
                {
                    puttedPost.FormFile.CopyTo(memoryStream);
                    file = memoryStream.ToArray();
                }

                post.ImageBlob = file;
            }

            _dbContext.SaveChanges();

            return NoContent();
        }

        return BadRequest("There is no post with given id or you are not the owner of this post.");
    }

    [HttpDelete]
    [Route("{id}")]
    [Authorize]
    public IActionResult DeletePost(int id)
    {
        string identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        UserProfile profile = _dbContext.UserProfiles.SingleOrDefault(up =>
            up.IdentityUserId == identityUserId
        );

        //we want to return bad request if the user isn't the author of the post. Adding the check for that here means that if it fails, post will be null and the endpoint will return bad request.
        Post post = _dbContext.Posts.SingleOrDefault(p => p.Id == id && p.AuthorId == profile.Id);

        if (post == null)
        {
            return BadRequest();
        }

        _dbContext.Remove(post);
        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPut]
    [Route("unapprove/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult UnapprovePost(int id)
    {
        Post postToUnapprove = _dbContext.Posts.SingleOrDefault(p => p.Id == id);

        if (postToUnapprove != null)
        {
            postToUnapprove.IsApproved = false;
            _dbContext.SaveChanges();

            return NoContent();
        }

        return BadRequest("There is no post with given id.");
    }

    [HttpPut]
    [Route("approve/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult ApprovePost(int id)
    {
        Post postToApprove = _dbContext.Posts.SingleOrDefault(p => p.Id == id);

        if (postToApprove != null)
        {
            postToApprove.IsApproved = true;
            _dbContext.SaveChanges();

            return NoContent();
        }

        return BadRequest("There is no post with given id.");
    }

    [HttpGet("user/{id}")]
    [Authorize]
    public IActionResult GetPostsByUserId(int id)
    {
        List<Post> postsByUser = _dbContext
            .Posts.Include(p => p.Author)
            .Include(p => p.Comments)
            .ThenInclude(c => c.Commenteer)
            .ThenInclude(u => u.IdentityUser)
            .Include(p => p.PostTags)
            .Where(p => p.AuthorId == id && p.IsApproved == true)
            .ToList();

        if (postsByUser == null)
        {
            return NotFound("no posts by this user");
        }

        return Ok(postsByUser);
    }

    [HttpGet("subscribed")]
    [Authorize]
    public IActionResult GetSubscribedPosts()
    {
        string identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        UserProfile profile = _dbContext.UserProfiles.SingleOrDefault(up =>
            up.IdentityUserId == identityUserId
        );

        List<Post> posts = _dbContext
            .Subscriptions.Where(s => s.FollowerId == profile.Id && s.UnsubbedDate == null)
            .Include(s => s.Subscriber)
            .ThenInclude(u => u.Posts)
            .ThenInclude(p => p.Author)
            .Include(s => s.Subscriber)
            .ThenInclude(u => u.Posts)
            .ThenInclude(p => p.Category)
            .Include(s => s.Subscriber)
            .ThenInclude(u => u.Posts)
            .ThenInclude(p => p.PostTags)
            .ThenInclude(pt => pt.Tag)
            .SelectMany(s => s.Subscriber.Posts)
            .ToList();

        return Ok(posts.Select(p => new GetPostsDTO(p)));
    }
}
