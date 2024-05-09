namespace api.DataTransferObjects.ReplyDtos;

public class ReplyDto
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public int CommentId { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } 
    public string Username { get; set; } = string.Empty;
    public string UserAvatar { get; set; } = string.Empty;
}