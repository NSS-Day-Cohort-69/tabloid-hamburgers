using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Tabloid.Data;
using Tabloid.Models;
using Tabloid.Models.DTOs;

namespace Tabloid.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private TabloidDbContext _dbContext;

    public UserProfileController(TabloidDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext.UserProfiles.ToList());
    }

    [HttpGet("withroles")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetWithRoles()
    {
        return Ok(
            _dbContext
                .UserProfiles.Include(up => up.IdentityUser)
                .Select(up => new UserProfile
                {
                    Id = up.Id,
                    FirstName = up.FirstName,
                    LastName = up.LastName,
                    Email = up.IdentityUser.Email,
                    UserName = up.IdentityUser.UserName,
                    IdentityUserId = up.IdentityUserId,
                    IsDeactivated = up.IsDeactivated,
                    Roles = _dbContext
                        .UserRoles.Where(ur => ur.UserId == up.IdentityUserId)
                        .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
                        .ToList()
                })
        );
    }

    [HttpPost("promote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Promote(string id)
    {
        IdentityRole role = _dbContext.Roles.SingleOrDefault(r => r.Name == "Admin");
        _dbContext.UserRoles.Add(new IdentityUserRole<string> { RoleId = role.Id, UserId = id });
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpPost("demote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Demote(string id)
    {
        IdentityRole role = _dbContext.Roles.SingleOrDefault(r => r.Name == "Admin");

        IdentityUserRole<string> userRole = _dbContext.UserRoles.SingleOrDefault(ur =>
            ur.RoleId == role.Id && ur.UserId == id
        );

        _dbContext.UserRoles.Remove(userRole);
        _dbContext.SaveChanges();
        return NoContent();
    }

    [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        UserProfile user = _dbContext
            .UserProfiles.Include(up => up.IdentityUser)
            .SingleOrDefault(up => up.Id == id);

        if (user == null)
        {
            return NotFound();
        }
        user.Email = user.IdentityUser.Email;
        user.UserName = user.IdentityUser.UserName;
        user.Roles = _dbContext
            .UserRoles.Where(ur => ur.UserId == user.IdentityUserId)
            .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
            .ToList();

        return Ok(user);
    }


    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Deactivate(int id)
    {
        UserProfile userToDeactivate = _dbContext
            .UserProfiles.Include(up => up.IdentityUser)
            .SingleOrDefault(up => up.Id == id);

        if (userToDeactivate == null)
        {
            return BadRequest("This user does not exist");
        }

        IdentityRole adminRole = _dbContext.Roles.SingleOrDefault(r => r.Name == "Admin");
        bool isUserAdmin = _dbContext.UserRoles
        .Any(ur => ur.UserId == userToDeactivate.IdentityUserId && ur.RoleId == adminRole.Id);
        
        if (isUserAdmin)
        {
            int activeAdminCount = _dbContext.UserRoles
                .Count(ur => ur.RoleId == adminRole.Id && !_dbContext.UserProfiles
                .Any(up => up.IdentityUserId == ur.UserId && up.IsDeactivated));

            if (activeAdminCount <= 1)
            {
                return BadRequest("You cannot deactivate the last remaining admin. Please assign another admin before proceeding.");
            }
        }

        userToDeactivate.IsDeactivated = true;

        _dbContext.SaveChanges();
        return Ok();
    }

    [HttpPut("{userId}/image")]
    public IActionResult UpdateImage(int userId, [FromForm] PutProfileImageDTO image)
    {
        UserProfile userProfile = _dbContext.UserProfiles.SingleOrDefault(u => u.Id == userId);

        if (userProfile == null || image.FormFile.Length == 0)
        {
            return BadRequest();
        }

        byte[] file;
        using (var memoryStream = new MemoryStream())
        {
            image.FormFile.CopyTo(memoryStream);
            file = memoryStream.ToArray();
        }

        userProfile.ImageBlob = file;

        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpPut("reactivate/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Reactivate(int id)
    {
        UserProfile userToReactivate = _dbContext.UserProfiles.FirstOrDefault(u => u.Id == id);
        if (userToReactivate == null)
        {
            return BadRequest("This user does not exist");
        }

        userToReactivate.IsDeactivated = false;

        _dbContext.SaveChanges();
        return Ok();
    }

    [HttpGet("deactivated")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetDeactivated()
    {
        return Ok(_dbContext.UserProfiles
        .Include(up => up.IdentityUser).Where(up => up.IsDeactivated == true)
        .Select(up => new UserProfile
        {
            Id = up.Id,
            FirstName = up.FirstName,
            LastName = up.LastName,
            Email = up.IdentityUser.Email,
            UserName = up.IdentityUser.UserName,
            IdentityUserId = up.IdentityUserId,
            IsDeactivated = up.IsDeactivated,
            Roles = _dbContext.UserRoles
            .Where(ur => ur.UserId == up.IdentityUserId)
            .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
            .ToList()
        }));
    }


}
