namespace api.DataTransferObjects.NotificationDtos;

public class AddNotificationDto
{
    public string SenderId { get; set; }
    public string ReceiverId { get; set; }
    public string Content { get; set; }
}