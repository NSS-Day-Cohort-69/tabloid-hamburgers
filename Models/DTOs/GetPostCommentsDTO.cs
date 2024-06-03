namespace Tabloid.Models.DTOs;

public class GetPostCommentsDTO
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public int PostId { get; set; }
    public int CommenteerId { get; set; }
    public GetPostCommentCommenteerDTO Commenteer { get; set; }
    public DateTime CreationDate { get; set; }

    public GetPostCommentsDTO(Comment comment)
    {
        if (comment.Commenteer == null)
        {
            throw new Exception("Must include commenteer");
        }
        Id = comment.Id;
        Subject = comment.Subject;
        Content = comment.Content;
        PostId = comment.PostId;
        CommenteerId = comment.CommenteerId;
        Commenteer = new GetPostCommentCommenteerDTO(comment.Commenteer);
        CreationDate = comment.CreationDate;
    }
}
