using api.Contracts;
using api.DataTransferObjects.NotificationDtos;
using api.Models;
using AutoMapper;

namespace api.Services.NotificationServices;

public class NotificationService : INotificationService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public NotificationService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<NotificationDto>> GetNotificationsForReceiverAsync(string receiverId)
    {
        var notifications = await _repository.Notification
            .GetNotificationsForReceiverAsync(receiverId);
        return _mapper.Map<IEnumerable<NotificationDto>>(notifications);
    }

}