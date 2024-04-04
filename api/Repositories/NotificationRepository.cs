using api.Contracts;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
{
    public NotificationRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Notification>> GetNotificationsForReceiverAsync(string receiverId)
    {
        return await FindByCondition(n => n.Receiver.Id.Equals(receiverId))
            .Include(n => n.Sender)
            .Include(n => n.Receiver)
            .ToListAsync();
    }

    public void CreateNotification(Notification notification)
    {
       Create(notification);
    }

    public void UpdateNotification(Notification notification)
    {
        throw new NotImplementedException();
    }

    public void DeleteNotification(Notification notification)
    {
        throw new NotImplementedException();
    }
}