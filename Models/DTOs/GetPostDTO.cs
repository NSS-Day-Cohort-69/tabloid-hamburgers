namespace Tabloid.Models.DTOs;

public class GetPostDTO
{
    public int Id { get; set; }

    public string Title { get; set; }

    public int AuthorId { get; set; }

    public UserProfileForGetPostDTO Author { get; set; }
    public string Content { get; set; }
    public int CategoryId { get; set; }

    public bool IsApproved { get; set; }

    public DateTime? Publication { get; set; }
    public List<int> TagIds { get; set; }
    public List<GetPostCommentsDTO> Comments { get; set; }
    public byte[] Image { get; set; }

    public GetPostDTO(Post post)
    {
        if (post.Comments == null || post.Author == null || post.PostTags == null)
        {
            throw new Exception("Must include comments, author and post tags");
        }

        Id = post.Id;
        Title = post.Title;
        AuthorId = post.AuthorId;
        Content = post.Content;
        CategoryId = post.CategoryId;
        IsApproved = post.IsApproved;
        Publication = post.Publication;
        TagIds = post.PostTags.Select(pt => pt.TagId).ToList();
        Comments = post.Comments.Select(c => new GetPostCommentsDTO(c)).ToList();
        Author = new UserProfileForGetPostDTO(post.Author);
        Image = post.ImageBlob;
    }
}
