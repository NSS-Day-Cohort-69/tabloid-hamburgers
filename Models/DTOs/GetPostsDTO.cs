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
    public GetPostsCategoryDTO Category { get; set; }
    public bool IsApproved { get; set; }
    public DateTime? Publication { get; set; }
    public List<GetPostsPostTagDTO> PostTags {get;set;}
    public GetPostsAuthorDTO Author { get; set; }

    public double ReadTime {
        get {

            int WordAmount = Content.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Count();

            double minutes = WordAmount / 265;
            return minutes;
        }
    }

    public GetPostsDTO(Post post)
    {
        if (post.Author == null || post.Category == null)
        {
            throw new Exception("parameter post must include author and category.");
        }

        Id = post.Id;
        Title = post.Title;
        AuthorId = post.AuthorId;
        Content = post.Content;
        ImageURL = post.ImageURL;
        CategoryId = post.CategoryId;
        IsApproved = post.IsApproved;
        Publication = post.Publication;
        PostTags = post.PostTags.Select(pt => new GetPostsPostTagDTO(pt)).ToList();
        Author = new GetPostsAuthorDTO(post.Author);
        Category = new GetPostsCategoryDTO(post.Category);
    }
}

// Comments = post.Comments.Select(c => new GetPostCommentsDTO(c)).ToList();