namespace api.DataTransferObjects.NotificationDtos;

public class NotificationDto
{
    public int Id { get; set; }
    public string SenderId { get; set; }
    public string? SenderUsername { get; set; }
    public string? ReceiverId { get; set; }
    public string? ReceiverUsername { get; set; }
    public string? Content { get; set; }
    public  DateTime CreatedAt { get; set; }
    public bool IsRead { get; set; }
}