using api.Models;

namespace api.Contracts;

public interface INotificationRepository
{
    Task<IEnumerable<Notification>> GetNotificationsForReceiverAsync(String receiverId);
    void CreateNotification(Notification notification);
    void UpdateNotification(Notification notification);
    void DeleteNotification(Notification notification);
}