using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabloid.Models.DTOs;

public class GetPostsPostTagDTO
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public int TagId { get; set; }
    public TagDTO Tag {get;set;}
    public GetPostsPostTagDTO(PostTag postTag)
    {
        Id = postTag.Id;
        PostId = postTag.PostId;
        TagId = postTag.TagId;
        Tag = new TagDTO {
            Id = postTag.Tag.Id,
            TagName = postTag.Tag.TagName
        };
    }
    
}


    // public GetPostsCategoryDTO(Category category)
    // {
    //     Id = category.Id;
    //     CategoryName = category.CategoryName;
    // }