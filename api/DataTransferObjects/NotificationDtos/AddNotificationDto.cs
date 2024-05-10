namespace api.DataTransferObjects.NotificationDtos;

public class AddNotificationDto
{
    public string SenderId { get; set; } = string.Empty;
    public string ReceiverId { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}