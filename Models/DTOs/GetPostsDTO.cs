using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tabloid.Models;

namespace Tabloid.Models.DTOs;

public class GetPostsDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public string Content { get; set; }
    public string ImageURL { get; set; }
    public int CategoryId { get; set; }
    public bool IsApproved { get; set; }
    public DateTime Publication { get; set; }

    public GetPostsDTO(Post post)
    {
        Id = post.Id;
        Title = post.Title;
        AuthorId = post.AuthorId;
        Content = post.Content;
        ImageURL = post.ImageURL;
        CategoryId = post.CategoryId;
        IsApproved = post.IsApproved;
        Publication = post.Publication;
    }
}
