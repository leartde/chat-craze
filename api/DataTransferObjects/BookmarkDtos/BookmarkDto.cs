namespace api.DataTransferObjects.BookmarkDtos;

public class BookmarkDto
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public string? PostTitle { get; set; }
    public string? PostImage { get; set; }
    public string UserId { get; set; }
    public DateTime CreatedAt { get; set; }
}