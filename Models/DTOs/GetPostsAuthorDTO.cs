using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Tabloid.Models;

public class GetPostsAuthorDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public DateTime CreateDateTime { get; set; }
    public string ImageLocation { get; set; }
    public string IdentityUserId { get; set; }
    public string FullName
    {
        get { return $"{FirstName} {LastName}"; }
    }
    public bool IsDeactivated { get; set; }

    public GetPostsAuthorDTO(UserProfile userProfile)
    {
        Id = userProfile.Id;
        FirstName = userProfile.FirstName;
        LastName = userProfile.LastName;
        Email = userProfile.Email;
        CreateDateTime = userProfile.CreateDateTime;
        ImageLocation = userProfile.ImageLocation;
        IdentityUserId = userProfile.IdentityUserId;
        IsDeactivated = userProfile.IsDeactivated;
    }
}
