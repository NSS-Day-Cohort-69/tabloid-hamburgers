using System.Diagnostics;
using Microsoft.AspNetCore.Identity;

namespace Tabloid.Models;

public class GetPostCommentCommenteerDTO
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string ImageLocation { get; set; }

    public GetPostCommentCommenteerDTO(UserProfile userProfile)
    {
        Id = userProfile.Id;

        UserName = userProfile.IdentityUser.UserName;
        ImageLocation = userProfile.ImageLocation;
    }
}
