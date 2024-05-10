namespace api.DataTransferObjects.NotificationDtos;

public class NotificationDto
{
    public int Id { get; set; }
    public string SenderId { get; set; } = string.Empty;
    public string SenderUsername { get; set; } = string.Empty;
    public string ReceiverId { get; set; } = string.Empty;
    public string ReceiverUsername { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public  DateTime CreatedAt { get; set; }
    public bool IsRead { get; set; }
}