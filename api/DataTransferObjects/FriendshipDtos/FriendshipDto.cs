namespace api.DataTransferObjects.FriendshipDtos;

public class FriendshipDto
{
    public int Id { get; set; }
    public string FriendOneId { get; set; }
    public string? FriendOneUsername { get; set; }
    public string? FriendOneAvatar { get; set; }
    public string? FriendTwoId { get; set; }
    public string? FriendTwoUsername { get; set; }
    public string? FriendTwoAvatar { get; set; }
    public DateTime CreatedAt { get; set; }
}