namespace Tabloid.Models.DTOs;

public class GetPostCommentDTO
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public int PostId { get; set; }
    public int CommenteerId { get; set; }
    public GetPostCommentCommenteerDTO Commenteer { get; set; }
    public DateTime CreationDate { get; set; }

    public GetPostCommentDTO(Comment comment)
    {
        Id = comment.Id;
        Subject = comment.Subject;
        Content = comment.Content;
        PostId = comment.PostId;
        CommenteerId = comment.CommenteerId;
        Commenteer = new GetPostCommentCommenteerDTO(comment.Commenteer);
        CreationDate = comment.CreationDate;
    }
}
