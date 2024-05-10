namespace api.DataTransferObjects.LikeDtos;

public class LikeDto
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public int PostId { get; set; }
    public string PostTitle { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}