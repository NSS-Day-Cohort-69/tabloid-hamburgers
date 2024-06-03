namespace Tabloid.Models.DTOs;

public class UserProfileForGetPostDTO
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string FirstName { get; set; }

    public UserProfileForGetPostDTO(UserProfile userProfile)
    {
        Id = userProfile.Id;
        FirstName = userProfile.FirstName;
        UserName = userProfile.UserName;
    }
}
