namespace api.DataTransferObjects.LikeDtos;

public class LikeDto
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public string? Username { get; set; }
    public int PostId { get; set; }
    public string? PostTitle { get; set; }
    public DateTime CreatedAt { get; set; }
}