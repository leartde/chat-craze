namespace api.DataTransferObjects.ReplyDtos;

public class ReplyDto
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public int CommentId { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Username { get; set; }
    public string? UserAvatar { get; set; }
}