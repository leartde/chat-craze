namespace api.DataTransferObjects.FriendshipDtos;

public class FriendshipDto
{
    public int Id { get; set; }
    public string FriendOneId { get; set; } = string.Empty;
    public string FriendOneUsername { get; set; } = string.Empty;
    public string FriendOneAvatar { get; set; } = string.Empty;
    public string FriendTwoId { get; set; } = string.Empty;
    public string FriendTwoUsername { get; set; } = string.Empty;
    public string FriendTwoAvatar { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } 
}