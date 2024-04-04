using api.DataTransferObjects.NotificationDtos;

namespace api.Services.NotificationServices;

public interface INotificationService
{
    Task<IEnumerable<NotificationDto>> GetNotificationsForReceiverAsync(string receiverId);

    
}